#region License
/*
Copyright (c) 2009, The Environmental Council of the States (ECOS)
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions
are met:

 * Redistributions of source code must retain the above copyright
   notice, this list of conditions and the following disclaimer.
 * Redistributions in binary form must reproduce the above copyright
   notice, this list of conditions and the following disclaimer in the
   documentation and/or other materials provided with the distribution.
 * Neither the name of the ECOS nor the names of its contributors may
   be used to endorse or promote products derived from this software
   without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
"AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS
FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE
COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT,
INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,
BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT
LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN
ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
POSSIBILITY OF SUCH DAMAGE.
*/
#endregion

using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Common.Logging;
using Windsor.Node2008.WNOSConnector.Admin;
using Windsor.Node2008.WNOSProviders;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.Admin.Controls;
using Windsor.Node2008.WNOSUtility;
using Spring.DataBinding;
using Windsor.Commons.Core;
using Windsor.Node2008.WNOSConnector.Server;

namespace Windsor.Node2008.Admin.Secure
{
    public partial class SecurityBulkAddUsers : SecurePage
    {
        #region Members

        public class ModelState
        {
            public ModelState()
            {
            }
        }
        private IAccountService _accountService;
        private IFlowService _flowService;
        private ModelState _modelState;
        private ICentralProcessor _centralProcessor;

        #endregion

        #region Spring Biding Stuff

        protected override void InitializeModel()
        {
            base.InitializeModel();

            if (_accountService == null)
            {
                throw new ArgumentNullException("_accountService");
            }
            if (_flowService == null)
            {
                throw new ArgumentNullException("_flowService");
            }
            if (_centralProcessor == null)
            {
                throw new ArgumentNullException("_centralProcessor");
            }

            _modelState = new ModelState();

        }
        protected override void OnInitializeControls(EventArgs e)
        {
            base.OnInitializeControls(e);

            if (!this.IsPostBack)
            {
                SecureMasterPage.SetupPage(SideTabs, SelectedTabIndex);
                introParagraphs.DataSource = IntroParagraphs;
                introParagraphs.DataBind();

                passwordCtrl.Text = confirmPasswordCtrl.Text = string.Empty;

                roleCtrl.DataSource = EnumUtils.GetAllDescriptions<SystemRoleType>();
                roleCtrl.DataBind();

                IList<DataFlow> flows = _flowService.GetProtectedFlows(VisitHelper.GetVisit(), false);
                flowRepeaterList.ItemDataBound += new RepeaterItemEventHandler(flowRepeater_ItemDataBound);
                flowRepeaterList.DataSource = flows;
                flowRepeaterList.DataBind();

                createInNaasCheckBox.Checked = true;

                AspNetUtils.SetFocus(this, nameCtrl, true);
            }
        }

        void flowRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            CheckBox checkBox = e.Item.FindControl("checkBox") as CheckBox;
            Label flowId = e.Item.FindControl("flowId") as Label;
            if ((checkBox != null) && (flowId != null))
            {
                DataFlow dataFlow = e.Item.DataItem as DataFlow;
                if (dataFlow != null)
                {
                    if (dataFlow.IsProtected)
                    {
                        checkBox.Text = "Allow: ";
                        checkBox.TextAlign = TextAlign.Left;
                        checkBox.Checked = false;
                    }
                    else
                    {
                        checkBox.Text = "(Flow is not protected) ";
                        checkBox.TextAlign = TextAlign.Left;
                        checkBox.Checked = true;
                        checkBox.Enabled = false;
                    }
                    flowId.Text = dataFlow.FlowName;
                }
            }
        }
        protected ICollection<string> GetCheckedFlowNames()
        {
            Repeater repeater = flowRepeaterList;
            List<string> checkedFlows = null;
            foreach (RepeaterItem item in repeater.Items)
            {
                CheckBox checkBox = item.FindControl("checkBox") as CheckBox;
                if ((checkBox != null) && checkBox.Checked && checkBox.Enabled)
                {
                    Label flowId = item.FindControl("flowId") as Label;
                    if (flowId != null)
                    {
                        if (checkedFlows == null)
                        {
                            checkedFlows = new List<string>();
                        }
                        checkedFlows.Add(flowId.Text);
                    }
                }
            }
            return checkedFlows;
        }
        protected override void LoadModel(object savedModel)
        {
            _modelState = (ModelState)savedModel;
        }

        protected override object SaveModel()
        {
            return _modelState;
        }

        protected SystemRoleType SystemRoleDisplyStringToValue
        {
            get
            {
                return EnumUtils.FromDescription<SystemRoleType>(roleCtrl.SelectedValue);
            }
            set
            {
                roleCtrl.SelectedValue = EnumUtils.ToDescription<SystemRoleType>(value);
            }

        }
        protected override void InitializeDataBindings()
        {
//            BindingManager.AddBinding("idCtrl.Value", "DataItem.Id");
        }
        protected override void BindFormData()
        {
            try
            {
                if (!this.IsPostBack)
                {
                    base.BindFormData();
                }
            }
            catch (Exception ex)
            {
                SetDivPageError(ex);
            }
        }
        public override void Validate()
        {
            if (_didValidate)
            {
                return;
            }
            _didValidate = true;
            base.Validate();
        }

        protected void OnAddUsers(object sender, EventArgs e)
        {
            if (divPageError.Visible || !Page.IsValid)
            {
                // Error on page, get out of here
                return;
            }
            try
            {
                IList<string> emails = GetUserNames();
                ICollection<string> checkedFlowNames = GetCheckedFlowNames();
                SystemRoleType role = EnumUtils.FromDescription<SystemRoleType>(roleCtrl.SelectedValue);
                string transactionId =
                    _accountService.BulkAddUsers(emails, createInNaasCheckBox.Checked,
                                                 passwordCtrl.Text, role, checkedFlowNames,
                                                 VisitHelper.GetVisit());
                _centralProcessor.WakeupProcessor(NodeMethod.Task);

                ResponseRedirect("../Secure/TaskDetails.aspx?id=" + transactionId);
            }
            catch (Exception ex)
            {
                LOG.Error(ex.Message, ex);
                SetDivPageError(ex);
            }
        }

        protected void ServerValidatePassword(Object source, ServerValidateEventArgs e)
        {
            if (passwordCtrl.Text.Length == 0)
            {
                if (confirmPasswordCtrl.Text.Length > 0)
                {
                    e.IsValid = false;
                    AppendDivPageError("Please enter two matching passwords.");
                }
            } 
            else if (confirmPasswordCtrl.Text.Length > 0)
            {
                e.IsValid = (passwordCtrl.Text == confirmPasswordCtrl.Text);
                if (!e.IsValid)
                {
                    AppendDivPageError("The two passwords do not match.  Please reenter them.");
                }
            }
        }
        protected void ServerValidateConfirmPassword(Object source, ServerValidateEventArgs e)
        {
            if (confirmPasswordCtrl.Text.Length == 0)
            {
                if (passwordCtrl.Text.Length > 0)
                {
                    e.IsValid = false;
                    AppendDivPageError("Please enter two matching passwords.");
                }
            }
        }
        protected void ServerValidateSecondPassword(Object source,
                                                   ServerValidateEventArgs e)
        {
            if ((passwordCtrl.Text.Length > 0) && (confirmPasswordCtrl.Text.Length > 0))
            {
                e.IsValid = (passwordCtrl.Text == confirmPasswordCtrl.Text);
                if (!e.IsValid)
                {
                    AppendDivPageError("The two passwords do not match.  Please reenter them.");
                }
            }
        }
        protected IList<string> GetUserNames()
        {
            if (nameCtrl.Text.Length > 0)
            {
                List<string> userNames =
                    new List<string>(nameCtrl.Text.Split(new string[] { ",", ";", Environment.NewLine },
                                                         StringSplitOptions.RemoveEmptyEntries));
                for (int i = userNames.Count - 1; i >= 0; --i)
                {
                    string userName = userNames[i].Trim();
                    if (string.IsNullOrEmpty(userName))
                    {
                        userNames.RemoveAt(i);
                    }
                    else
                    {
                        userNames[i] = userName;
                    }
                }
                return userNames;
            }
            return null;
        }
        protected void ServerValidateUsernames(Object source, ServerValidateEventArgs e)
        {
            e.IsValid = true;
            IList<string> emails = GetUserNames();
            if (!CollectionUtils.IsNullOrEmpty(emails))
            {
                foreach (string email in emails)
                {
                    if (!ValidationHelper.IsValidEmail(email))
                    {
                        AppendDivPageError("\"{0}\" is not a valid email address.", email);
                        e.IsValid = false;
                        return;
                    }
                }
            }
            else
            {
                AppendDivPageError("Please enter at least one user name");
                e.IsValid = false;
            }
        }
        #endregion

        #region Properties

        public IAccountService AccountService
        {
            get { return _accountService; }
            set { _accountService = value; }
        }

        public IFlowService FlowService
        {
            get { return _flowService; }
            set { _flowService = value; }
        }
        public ICentralProcessor CentralProcessor
        {
            get { return _centralProcessor; }
            set { _centralProcessor = value; }
        }
        public ModelState DataModel
        {
            get { return _modelState; }
            set { _modelState = value; }
        }
        protected bool _didValidate;

        #endregion
    }
}
