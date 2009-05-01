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

namespace Windsor.Node2008.Admin.Secure
{
    public partial class SecurityUserEdit : SecurePage
    {
        #region Members

        public class ModelState
        {
            public ModelState()
            {
            }
            private UserAccount _dataItem;

            public UserAccount DataItem
            {
                get { return _dataItem; }
                set { _dataItem = value; }
            }
            private bool _isNewUser;

            public bool IsNewUser
            {
                get { return _isNewUser; }
                set { _isNewUser = value; }
            }
            private bool _wasDemoUser;

            public bool WasDemoUser
            {
                get { return _wasDemoUser; }
                set { _wasDemoUser = value; }
            }
            private bool _userExistsInNAAS;

            public bool UserExistsInNAAS
            {
                get { return _userExistsInNAAS; }
                set { _userExistsInNAAS = value; }
            }
            private bool _userPasswordExistsInDB;

            public bool UserPasswordExistsInDB
            {
                get { return _userPasswordExistsInDB; }
                set { _userPasswordExistsInDB = value; }
            }
            private string _affiliate;

            public string Affiliate
            {
                get { return _affiliate; }
                set { _affiliate = value; }
            }
            private bool _canDelete;

            public bool CanDelete
            {
                get { return _canDelete; }
                set { _canDelete = value; }
            }
        }
        private IAccountService _dataItemService;
        private ModelState _modelState;

        #endregion

        #region Spring Biding Stuff

        protected override void InitializeModel()
        {
            base.InitializeModel();

            if (_dataItemService == null)
            {
                throw new ArgumentNullException("_dataItemService");
            }

            _modelState = new ModelState();

            string id = Request["id"];
            _modelState.IsNewUser = string.IsNullOrEmpty(id);
            if (!_modelState.IsNewUser)
            {
                _modelState.DataItem = _dataItemService.Get(id, VisitHelper.GetVisit());
                if (_dataItemService.IsDemoNode)
                {
                    if (_modelState.DataItem.IsDemoUser == null)
                    {
                        _modelState.DataItem.IsDemoUser = new bool?(false);
                    }
                    else
                    {
                        _modelState.WasDemoUser = _modelState.DataItem.IsDemoUser.Value;
                    }
                    _modelState.UserPasswordExistsInDB =
                       _dataItemService.UserPasswordExistsInDB(_modelState.DataItem.NaasAccount);
                }
                string affiliate;
                bool canDelete;
                _modelState.UserExistsInNAAS =
                    _dataItemService.UserExistsInNAAS(_modelState.DataItem.NaasAccount, VisitHelper.GetVisit(),
                                                      out affiliate, out canDelete);
                _modelState.Affiliate = affiliate;
                _modelState.CanDelete = canDelete;
            }
            else
            {
                _modelState.DataItem = new UserAccount();
                _modelState.DataItem.IsActive = true;
                if (_dataItemService.IsDemoNode)
                {
                    _modelState.DataItem.IsDemoUser = new bool?(false);
                }
            }
        }
        protected override void OnInitializeControls(EventArgs e)
        {
            base.OnInitializeControls(e);

            if (!this.IsPostBack)
            {
                SecureMasterPage.SetupPage(SideTabs, SelectedTabIndex);
                introParagraphs.DataSource = IntroParagraphs;
                introParagraphs.DataBind();

                roleCtrl.DataSource = EnumUtils.GetAllDescriptions<SystemRoleType>();
                roleCtrl.DataBind();

                if (_modelState.DataItem.IsDemoUser == null)
                {
                    // Not a demo server
                    IsDemoUserLabel.Visible = IsDemoUserCheckBox.Visible = false;
                }
                else
                {
                    IsDemoUserCheckBox.Checked = _modelState.DataItem.IsDemoUser.Value;
                }
                passwordCtrl.Text = confirmPasswordCtrl.Text = string.Empty;
                ShowHidePasswordControl();
                if (string.IsNullOrEmpty(_modelState.Affiliate))
                {
                    affiliateLabel.Visible = affiliateValue.Visible = false;
                }
                else
                {
                    affiliateValue.Text = _modelState.Affiliate;
                }
                nameCtrl.Enabled = _modelState.IsNewUser;
                if (nameCtrl.Enabled)
                {
                    AspNetUtils.SetFocus(this, nameCtrl, false);
                }
                else if (passwordCtrl.Visible)
                {
                    AspNetUtils.SetFocus(this, passwordCtrl, false);
                }
            }
            IsDemoUserCheckBox.AutoPostBack = !_modelState.IsNewUser;
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
            BindingManager.AddBinding("idCtrl.Value", "DataItem.Id");
            BindingManager.AddBinding("nameCtrl.Text", "DataItem.NaasAccount");
            BindingManager.AddBinding("SystemRoleDisplyStringToValue", "DataItem.Role");
            BindingManager.AddBinding("activeCtrl.Checked", "DataItem.IsActive");
            BindingManager.AddBinding("deleteBtn.Enabled", "DataModel.CanDelete", BindingDirection.TargetToSource);
            BindingManager.AddBinding("resetBtn.Enabled", "DataModel.CanDelete", BindingDirection.TargetToSource);
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
                divPageError.Visible = true;
                divPageError.InnerText = ExceptionUtils.GetDeepExceptionMessage(ex);
            }
        }
        protected override void UnbindFormData()
        {
            try
            {
                divPageError.Visible = false;

                this.Validate();

                if (this.IsValid)
                {
                    base.UnbindFormData();
                    if (_modelState.DataItem.IsDemoUser != null)
                    {
                        _modelState.DataItem.IsDemoUser = new bool?(IsDemoUserCheckBox.Checked);
                    }
                    DataItem.NaasAccount = DataItem.NaasAccount.Trim();
                }
            }
            catch (Exception ex)
            {
                divPageError.Visible = true;
                divPageError.InnerText = ExceptionUtils.GetDeepExceptionMessage(ex);
            }
        }

        protected void SaveDataItem(object sender, EventArgs e)
        {
            if (divPageError.Visible || !Page.IsValid)
            {
                // Error on page, get out of here
                return;
            }
            try
            {
                _modelState.DataItem = 
                    _dataItemService.Save(_modelState.DataItem, passwordCtrl.Text, VisitHelper.GetVisit());

                Button btn = sender as Button;

                if (btn != null && btn.ID == savePolicyBtn.ID)
                {
                    ResponseRedirect("../Secure/SecurityPolicyEdit.aspx?id=" + _modelState.DataItem.NaasAccount);
                }
                else
                {
                    ResponseRedirect("../Secure/SecurityUser.aspx");
                }


            }
            catch (Exception ex)
            {
                LOG.Error(ex.Message, ex);
                divPageError.Visible = true;
                divPageError.InnerText = UIUtility.ParseException(ex);
            }
        }

        protected void DeleteDataItem(object sender, EventArgs e)
        {
            try
            {
                if (_modelState.WasDemoUser)
                {
                    _modelState.DataItem.IsDemoUser = new bool?(_modelState.WasDemoUser);
                }
                else
                {
                    _modelState.DataItem.IsDemoUser = null;
                }
                _dataItemService.Delete(_modelState.DataItem, VisitHelper.GetVisit());
                ResponseRedirect("../Secure/SecurityUser.aspx");
            }
            catch (Exception ex)
            {
                LOG.Error(ex.Message, ex);
                divPageError.Visible = true;
                divPageError.InnerText = UIUtility.ParseException(ex);
            }
        }

        protected void ResetDataItem(object sender, EventArgs e)
        {
            try
            {
                _modelState.DataItem = 
                    _dataItemService.ResetPassword(_modelState.DataItem, VisitHelper.GetVisit());
                ResponseRedirect("../Secure/SecurityUser.aspx");
            }
            catch (Exception ex)
            {
                LOG.Error(ex.Message, ex);
                divPageError.Visible = true;
                divPageError.InnerText = UIUtility.ParseException(ex);
            }
        }

        protected void ServerValidatePasswordsMatch(Object source,
                                                    ServerValidateEventArgs e)
        {
            if ((passwordCtrl.Text.Length > 0) && (confirmPasswordCtrl.Text.Length > 0))
            {
                e.IsValid = (passwordCtrl.Text == confirmPasswordCtrl.Text);
            }
        }
        protected void ShowHidePasswordControl()
        {
            bool showPasswordCtrl;
            if (_modelState.DataItem.IsDemoUser == null)
            {
                // Not a demo server
                showPasswordCtrl = _modelState.IsNewUser ||
                                    !_modelState.UserExistsInNAAS;
            }
            else
            {
                if ( !_modelState.IsNewUser ) {
                    if (IsDemoUserCheckBox.Checked)
                    {
                        showPasswordCtrl = !_modelState.UserPasswordExistsInDB;
                    }
                    else
                    {
                        showPasswordCtrl = !_modelState.UserExistsInNAAS;
                    }
                } else {
                    showPasswordCtrl = true;
                }
            }
            passwordCtrlRow.Visible = confirmPasswordCtrlRow.Visible = showPasswordCtrl;
        }
        #endregion

        #region Properties

        public IAccountService DataItemService
        {
            get { return _dataItemService; }
            set { _dataItemService = value; }
        }

        public UserAccount DataItem
        {
            get { return _modelState.DataItem; }
            set { _modelState.DataItem = value; }
        }

        public ModelState DataModel
        {
            get { return _modelState; }
            set { _modelState = value; }
        }

        #endregion

        protected void IsDemoUserCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ShowHidePasswordControl();
        }
    }
}
