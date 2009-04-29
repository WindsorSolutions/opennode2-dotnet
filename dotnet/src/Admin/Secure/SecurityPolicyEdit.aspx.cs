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
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSUtility;
using Windsor.Node2008.Admin.Controls;
using Spring.DataBinding;

namespace Windsor.Node2008.Admin.Secure
{
    public partial class SecurityPolicyEdit : SecureListPage
    {
        #region Members

        private UserAccount _dataItem;
        private NaasUserInfo _naasUserInfo;
        private IPolicyService _dataItemService;
        private IAccountService _accountService;

        private class ModelState
        {
            public ModelState(UserAccount dataItem, NaasUserInfo naasUserInfo)
            {
                _dataItem = dataItem;
                _naasUserInfo = naasUserInfo;
            }
            private UserAccount _dataItem;

            public UserAccount DataItem
            {
                get { return _dataItem; }
                set { _dataItem = value; }
            }
            private NaasUserInfo _naasUserInfo;

            public NaasUserInfo NaasUserInfo
            {
                get { return _naasUserInfo; }
                set { _naasUserInfo = value; }
            }
        }

        #endregion

        void repeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            CheckBox checkBox = e.Item.FindControl("checkBox") as CheckBox;
            Label checkTag = e.Item.FindControl("checkTag") as Label;
            if ((checkTag != null) && (checkBox != null))
            {
                KeyValuePair<string, SimpleListDisplayInfo> pair =
                    (KeyValuePair<string, SimpleListDisplayInfo>)e.Item.DataItem;
                DataFlow dataFlow = pair.Value.Element as DataFlow;
                if (dataFlow != null)
                {
                    if (dataFlow.IsProtected)
                    {
                        if (_dataItem != null)
                        {
                            checkBox.Text = "Allow: ";
                            checkBox.TextAlign = TextAlign.Left;
                            checkBox.Checked = _dataItemService.IsFlowPermitted(_dataItem.Policies, dataFlow.FlowName);
                            checkTag.Text = dataFlow.FlowName;
                        }
                    }
                    else
                    {
                        checkBox.Text = "(Flow is not protected) ";
                        checkBox.TextAlign = TextAlign.Left;
                        checkBox.Checked = true;
                        checkBox.Enabled = false;
                    }
                }
            }
        }

        protected void SavePolicies(object sender, EventArgs e)
        {
            try
            {
                if (_dataItem != null)
                {
                    IList<UserAccessPolicy> oldPolicies = _dataItem.Policies;
                    try
                    {
                        _dataItem.Policies = GetPolicies();
                        _dataItem = _dataItemService.Save(_dataItem, VisitHelper.GetVisit());
                    }
                    catch
                    {
                        _dataItem.Policies = oldPolicies;
                        throw;
                    }
                }
                ResponseRedirect("../Secure/SecurityPolicy.aspx");
            }
            catch (Exception ex)
            {
                LOG.Error(ex.Message, ex);
                divPageError.Visible = true;
                divPageError.InnerText = UIUtility.ParseException(ex);
            }
        }
        protected IList<UserAccessPolicy> GetPolicies()
        {
            Repeater repeater = list.RepeaterList;
            List<UserAccessPolicy> policies = null;
            AdminVisit visitor = VisitHelper.GetVisit();
            foreach (RepeaterItem item in repeater.Items)
            {
                CheckBox checkBox = item.FindControl("checkBox") as CheckBox;
                if ((checkBox != null) && checkBox.Checked && checkBox.Enabled)
                {
                    Label checkTag = item.FindControl("checkTag") as Label;
                    if (checkTag != null)
                    {
                        if (policies == null)
                        {
                            policies = new List<UserAccessPolicy>();
                        }
                        UserAccessPolicy policy = _dataItemService.CreatePolicy(_dataItem.Id, checkTag.Text, true);
                        policy.ModifiedById = visitor.Account.Id;
                        policies.Add(policy);
                    }
                }
            }
            return policies;
        }
        #region Spring Biding Stuff

        protected override void InitializeModel()
        {
            base.InitializeModel();

            if (_dataItemService == null)
            {
                throw new ArgumentNullException("DataItemService");
            }
            if (_accountService == null)
            {
                throw new ArgumentNullException("AccountService");
            }

            string id = Request["id"];
            if (!string.IsNullOrEmpty(id))
            {
                _dataItem = _dataItemService.GetOrCreateUser(id, VisitHelper.GetVisit(), out _naasUserInfo);
                if (_accountService.IsDemoNode && (_dataItem.IsDemoUser != null) && (_dataItem.IsDemoUser.Value == true))
                {
                    _naasUserInfo.Owner = _accountService.GetUsernameById(_dataItem.ModifiedById);
                }
            }
            else
            {
                string naasAccount = Request["naas"];
                if (!string.IsNullOrEmpty(naasAccount))
                {
                    _naasUserInfo = _dataItemService.GetNaasUserInfo(naasAccount);
                    _dataItem = new UserAccount();
                    _dataItem.IsActive = true;
                    if (_accountService.IsDemoNode)
                    {
                        _dataItem.IsDemoUser = new bool?(false);
                    }
                    _dataItem.NaasAccount = naasAccount;
                    _dataItem.Role = SystemRoleType.Authed;
                }
            }
        }
        protected override void OnInitializeControls(EventArgs e)
        {
            base.OnInitializeControls(e);
            list.Config = ListConfig;

            if (!IsPostBack)
            {
                Repeater repeater = list.RepeaterList;
                repeater.ItemDataBound += new RepeaterItemEventHandler(repeater_ItemDataBound);
            }
        }

        protected override void LoadModel(object savedModel)
        {
            ModelState state = (ModelState) savedModel;
            _dataItem = state.DataItem;
            _naasUserInfo = state.NaasUserInfo;
        }

        protected override object SaveModel()
        {
            return new ModelState(_dataItem, _naasUserInfo);
        }

        protected override void InitializeDataBindings()
        {
        }

        protected string FlowDisplayName(object dataItem)
        {
            DataFlow dataFlow = (DataFlow)dataItem;
            if (dataFlow.IsProtected)
            {
                return dataFlow.FlowName + " (Protected)";
            }
            else
            {
                return dataFlow.FlowName;
            }
        }
        #endregion

        #region Properties
        public IPolicyService DataItemService
        {
            get { return _dataItemService; }
            set { _dataItemService = value; }
        }

        public UserAccount DataItem
        {
            get { return _dataItem; }
            set { _dataItem = value; }
        }
        public NaasUserInfo UserInfo
        {
            get { return _naasUserInfo; }
            set { _naasUserInfo = value; }
        }
        public IAccountService AccountService
        {
            get { return _accountService; }
            set { _accountService = value; }
        }

        #endregion
    }
}
