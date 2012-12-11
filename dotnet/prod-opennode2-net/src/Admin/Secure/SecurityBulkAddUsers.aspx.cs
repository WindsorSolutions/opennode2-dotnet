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
            public ICollection<KeyValuePair<string, string>> NaasUserList;
        }
        private IAccountService _accountService;
        private IPolicyService _policyService;
        private IFlowService _flowService;
        private ModelState _modelState;
        private ICentralProcessor _centralProcessor;
        private UserAccount _editUserAccount;
        private bool _canDeleteUser;
        private bool _canRemoveUser;
        private bool _canResetPassword;
        private string _userAffiliate;
        private bool _isAddUsers;
        protected bool _didValidate;
        private static readonly string[] ValidUsernameSeparators = new string[] { Environment.NewLine, ",", ";" };

        #endregion

        #region Spring Biding Stuff

        public override bool IsEditPage
        {
            get
            {
                return !_isAddUsers;
            }
        }

        protected override void InitializeModel()
        {
            base.InitializeModel();

            if (_accountService == null)
            {
                throw new ArgumentNullException("_accountService");
            }
            if (_policyService == null)
            {
                throw new ArgumentNullException("_policyService");
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

            _modelState.NaasUserList = _policyService.GetCachedNaasUsernameList(true, VisitHelper.GetVisit());

            _isAddUsers = true;

            AssignEditUserAccount(false);

            if (_editUserAccount != null)
            {
                bool userExistsInNAAS =
                    _accountService.UserExistsInNAAS(_editUserAccount.NaasAccount, VisitHelper.GetVisit(),
                                                     out _userAffiliate, out _canDeleteUser, out _canRemoveUser);
                _canResetPassword = _canDeleteUser;
                if (userExistsInNAAS)
                {
                    _isAddUsers = false;
                }
            }
        }
        private void AssignEditUserAccount(bool throwException)
        {
            _editUserAccount = null;
            string id = Request["id"];
            if (!string.IsNullOrEmpty(id))
            {
                _editUserAccount = _accountService.Get(id, VisitHelper.GetVisit());
                if ((_editUserAccount == null) && throwException)
                {
                    throw new ArgumentException(string.Format("Failed to load user account with id \"{0}\" from database.",
                                                id));
                }
            }
            else if (throwException)
            {
                throw new ArgumentException("Failed to load user account from database.");
            }
        }
        protected override void OnInitializeControls(EventArgs e)
        {
            if (Response.IsRequestBeingRedirected)
            {
                return;
            }

            base.OnInitializeControls(e);

            if (!this.IsPostBack)
            {
                SecureMasterPage.SetupPage(SideTabs, SelectedTabIndex);
                introParagraphs.DataSource = GetIntroParagraphs();
                introParagraphs.DataBind();

                roleCtrl.DataSource = EnumUtils.GetAllDescriptions<SystemRoleType>();
                roleCtrl.DataBind();

                if (!_isAddUsers)
                {
                    // Edit user
                    nameValue.Text = _editUserAccount.NaasAccount;

                    affiliateValue.Text = _userAffiliate;

                    activeCtrl.Checked = _editUserAccount.IsActive;

                    SelectedRole = _editUserAccount.Role;

                    addUsersBtn.Visible = false;
                    deleteUserBtn.Enabled = _canDeleteUser;
                    removeUserBtn.Enabled = _canRemoveUser;
                    resetPasswordBtn.Enabled = _canResetPassword;
                }
                else
                {
                    // Add users
                    passwordCtrl.Text = confirmPasswordCtrl.Text = string.Empty;

                    createInNaasCheckBox.Checked = true;

                    saveUserBtn.Visible = deleteUserBtn.Visible = resetPasswordBtn.Visible = false;

                    if (_editUserAccount != null)
                    {
                        SelectedRole = _editUserAccount.Role;
                        activeCtrl.Checked = _editUserAccount.IsActive;
                        nameCtrl.Text = _editUserAccount.NaasAccount;
                    }
                    else
                    {
                        SelectedRole = SystemRoleType.Authed;
                    }

                    AspNetUtils.SetFocus(this, nameCtrl, true);
                }

                UpdateVisibleRows();

                addSelectedUsers.Enabled = false;

                RebindFlowRepeater();
            }
            else
            {
                divPageError.Visible = false;
            }
        }

        private void RebindFlowRepeater()
        {
            IList<DataFlow> flows = _flowService.GetFlows(VisitHelper.GetVisit(), false);
            flowRepeaterList.DataSource = flows;
            flowRepeaterList.DataBind();
        }
        private SystemRoleType SelectedRole
        {
            get
            {
                return EnumUtils.FromDescription<SystemRoleType>(roleCtrl.SelectedValue);
            }
            set
            {
                roleCtrl.SelectedValue = EnumUtils.ToDescription(value);
            }
        }
        private FlowRoleType GetFlowRole(IList<UserAccessPolicy> policies, string flowName)
        {
            if (!CollectionUtils.IsNullOrEmpty(policies))
            {
                foreach (UserAccessPolicy policy in policies)
                {
                    if ((policy.PolicyType == ServiceRequestAuthorizationType.Flow) &&
                        string.Equals(policy.TypeQualifier, flowName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        return policy.FlowRoleType;
                    }
                }
            }
            return FlowRoleType.None;
        }
        protected string GetFlowName(string flowName, bool isProtected)
        {
            if (isProtected)
            {
                return flowName + " (Protected)";
            }
            else
            {
                return flowName;
            }
        }
        protected ICollection<FlowNameAndRole> GetPermissionedFlows()
        {
            SystemRoleType role = EnumUtils.FromDescription<SystemRoleType>(roleCtrl.SelectedValue);
            if (role == SystemRoleType.Admin)
            {
                return null;    // Everything is allowed
            }
            Repeater repeater = flowRepeaterList;
            List<FlowNameAndRole> permissionedFlows = null;
            foreach (RepeaterItem item in repeater.Items)
            {
                DropDownList flowRoleCtrl = item.FindControl("flowRoleCtrl") as DropDownList;
                Label flowCodeLabel = item.FindControl("FlowCode") as Label;
                HiddenField flowIsProtected = item.FindControl("flowIsProtected") as HiddenField;
                FlowRoleType flowRole = FlowRoleType.None;
                string flowName = null;

                if ((flowRoleCtrl != null) && (flowCodeLabel != null) && (flowIsProtected != null) &&
                    flowRoleCtrl.Visible)
                {
                    flowName = flowCodeLabel.Text;
                    flowRole = EnumUtils.FromDescription<FlowRoleType>(flowRoleCtrl.SelectedValue);
                    if (flowRole != FlowRoleType.None)
                    {
                        bool flowIsProtectedValue = flowIsProtected.Value == true.ToString();
                        if (flowIsProtectedValue || ((flowRole == FlowRoleType.View) || (flowRole == FlowRoleType.Modify)))
                        {
                            FlowNameAndRole flowNameAndRole = new FlowNameAndRole(flowName, flowRole);
                            CollectionUtils.Add(flowNameAndRole, ref permissionedFlows);
                        }
                    }
                }
            }
            return permissionedFlows;
        }
        protected override void LoadModel(object savedModel)
        {
            _modelState = (ModelState)savedModel;
        }

        protected override object SaveModel()
        {
            return _modelState;
        }

        public override void Validate()
        {
            if (!_didValidate)
            {
                divPageError.Visible = false;
                _didValidate = true;
                base.Validate();
            }
        }
        protected void OnAddUsers(object sender, EventArgs e)
        {
            if (!this.IsValid)
            {
                // Error on page, get out of here
                return;
            }
            try
            {
                IList<string> emails = GetUsernames();
                ICollection<FlowNameAndRole> permissionedFlows = GetPermissionedFlows();
                SystemRoleType role = EnumUtils.FromDescription<SystemRoleType>(roleCtrl.SelectedValue);
                string password = passwordCtrl.Text;
                bool createInNaas = createInNaasCheckBox.Checked;
                bool isActive = activeCtrl.Checked;
                if (emails.Count == 1)
                {
                    _accountService.BulkAddUser(emails[0], createInNaas, password, role,
                                                permissionedFlows, isActive, VisitHelper.GetVisit());
                    ResponseRedirect("../Secure/SecurityUser.aspx");
                }
                else
                {
                    string transactionId =
                        _accountService.BulkAddUsers(emails, createInNaas, password, role, permissionedFlows,
                                                     isActive, VisitHelper.GetVisit());
                    _centralProcessor.WakeupProcessor(NodeMethod.Task);

                    ResponseRedirect("../Secure/TaskDetails.aspx?id=" + transactionId);
                }
            }
            catch (Exception ex)
            {
                LOG.Error(ex.Message, ex);
                SetDivPageError(ex);
            }
        }
        protected void OnSaveUser(object sender, EventArgs e)
        {
            if (!this.IsValid)
            {
                // Error on page, get out of here
                return;
            }
            try
            {
                AssignEditUserAccount(true);

                ICollection<FlowNameAndRole> permissionedFlows = GetPermissionedFlows();
                SystemRoleType role = EnumUtils.FromDescription<SystemRoleType>(roleCtrl.SelectedValue);
                bool isActive = activeCtrl.Checked;
                _accountService.BulkAddUser(_editUserAccount.NaasAccount, false, string.Empty, role,
                                            permissionedFlows, isActive, VisitHelper.GetVisit());

                ResponseRedirect("../Secure/SecurityUser.aspx");
            }
            catch (Exception ex)
            {
                LOG.Error(ex.Message, ex);
                SetDivPageError(ex);
            }
        }
        protected void OnDeleteUser(object sender, EventArgs e)
        {
            try
            {
                AssignEditUserAccount(true);

                _accountService.Delete(_editUserAccount, VisitHelper.GetVisit());

                ResponseRedirect("../Secure/SecurityUser.aspx");
            }
            catch (Exception ex)
            {
                LOG.Error(ex.Message, ex);
                SetDivPageError(ex);
            }
        }
        protected void OnRemoveUser(object sender, EventArgs e)
        {
            try
            {
                AssignEditUserAccount(true);

                _accountService.Remove(_editUserAccount, VisitHelper.GetVisit());

                ResponseRedirect("../Secure/SecurityUser.aspx");
            }
            catch (Exception ex)
            {
                LOG.Error(ex.Message, ex);
                SetDivPageError(ex);
            }
        }
        protected void OnResetPassword(object sender, EventArgs e)
        {
            try
            {
                AssignEditUserAccount(true);

                _accountService.ResetPassword(_editUserAccount, VisitHelper.GetVisit());

                ResponseRedirect("../Secure/SecurityUser.aspx");
            }
            catch (Exception ex)
            {
                LOG.Error(ex.Message, ex);
                SetDivPageError(ex);
            }
        }

        protected void ServerValidatePassword(Object source, ServerValidateEventArgs e)
        {
            if (passwordCtrl.Visible)
            {
                if ((passwordCtrl.Text.Length == 0) || (confirmPasswordCtrl.Text.Length == 0))
                {
                    e.IsValid = false;
                    AppendDivPageError("Please enter two matching passwords.");
                }
                else
                {
                    e.IsValid = (passwordCtrl.Text == confirmPasswordCtrl.Text) &&
                                (ValidationHelper.IsValidNAASPassword(passwordCtrl.Text) == null);
                }
            }
        }
        protected void ServerValidateConfirmPassword(Object source, ServerValidateEventArgs e)
        {
            if (confirmPasswordCtrl.Visible)
            {
                if (confirmPasswordCtrl.Text.Length == 0)
                {
                    e.IsValid = false;
                }
                else if (passwordCtrl.Text.Length != 0)
                {
                    e.IsValid = (passwordCtrl.Text == confirmPasswordCtrl.Text);
                    if (!e.IsValid)
                    {
                        AppendDivPageError("The two passwords do not match.  Please reenter them.");
                    }
                    else
                    {
                        string errorMessage = ValidationHelper.IsValidNAASPassword(passwordCtrl.Text);
                        if (errorMessage != null)
                        {
                            e.IsValid = false;
                            AppendDivPageError("The passwords are not valid: " + errorMessage + ".  Please reenter them.");
                        }
                    }
                }
            }
        }
        protected List<string> GetUsernames()
        {
            if (nameCtrl.Text.Length > 0)
            {
                List<string> userNames =
                    new List<string>(nameCtrl.Text.Split(ValidUsernameSeparators,
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
        protected string FirstUsernameSeparator()
        {
            string separator = null;
            if (nameCtrl.Text.Length > 0)
            {
                int arrayIndex;
                int index = StringUtils.IndexOfAny(nameCtrl.Text, ValidUsernameSeparators, out arrayIndex);
                if (index >= 0)
                {
                    separator = ValidUsernameSeparators[arrayIndex];
                }
            }
            return separator ?? ValidUsernameSeparators[0];
        }
        protected void ServerValidateUsernames(Object source, ServerValidateEventArgs e)
        {
            e.IsValid = true;
            IList<string> emails = GetUsernames();
            if (!CollectionUtils.IsNullOrEmpty(emails))
            {
                foreach (string email in emails)
                {
                    if (!ValidationHelper.IsValidSingleEmail(email))
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
            get
            {
                return _accountService;
            }
            set
            {
                _accountService = value;
            }
        }
        public IPolicyService PolicyService
        {
            get
            {
                return _policyService;
            }
            set
            {
                _policyService = value;
            }
        }
        public IFlowService FlowService
        {
            get
            {
                return _flowService;
            }
            set
            {
                _flowService = value;
            }
        }
        public ICentralProcessor CentralProcessor
        {
            get
            {
                return _centralProcessor;
            }
            set
            {
                _centralProcessor = value;
            }
        }
        public ModelState DataModel
        {
            get
            {
                return _modelState;
            }
            set
            {
                _modelState = value;
            }
        }

        #endregion

        protected void textNaasUserFilter_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            RefreshNaasUserListBox();

            ScriptManager.GetCurrent(this).SetFocus(textNaasUserFilter);
        }
        private void BindListNaasUsers(ICollection<KeyValuePair<string, string>> list)
        {
            listNaasUsers.DataTextField = "Value";
            listNaasUsers.DataValueField = "Key";
            listNaasUsers.DataSource = list;
            listNaasUsers.DataBind();
        }
        private void RefreshNaasUserListBox()
        {
            try
            {
                string filter = textNaasUserFilter.Text;
                List<KeyValuePair<string, string>> userList = new List<KeyValuePair<string, string>>(100);
                if (!string.IsNullOrEmpty(filter) && (_modelState != null) && (_modelState.NaasUserList != null))
                {
                    foreach (KeyValuePair<string, string> userNamePair in _modelState.NaasUserList)
                    {
                        if (userNamePair.Key.StartsWith(filter, StringComparison.InvariantCultureIgnoreCase))
                        {
                            userList.Add(userNamePair);
                        }
                    }
                }
                BindListNaasUsers(userList);
            }
            catch (Exception ex)
            {
                LOG.Error(ex.Message, ex);
                SetDivPageError(ex);
            }
        }

        protected void UpdateVisibleRows()
        {
            if (addUsersBtn.Visible)
            {
                addUsersEditCtrlRow.Visible = createUsersInNaasEditCtrlRow.Visible =
                    passwordCtrlRow.Visible = confirmPasswordCtrlRow.Visible = true;
                bool passwordEnabled = createInNaasCheckBox.Checked;
                passwordCtrlRow.Visible = confirmPasswordCtrlRow.Visible = passwordEnabled;
                usernameCtrlRow.Visible = affiliateCtrlRow.Visible = false;
            }
            else
            {
                addUsersEditCtrlRow.Visible = createUsersInNaasEditCtrlRow.Visible =
                    passwordCtrlRow.Visible = confirmPasswordCtrlRow.Visible = false;
                usernameCtrlRow.Visible = affiliateCtrlRow.Visible = true;
            }
            if (SelectedRole != SystemRoleType.Admin)
            {
                exchangeAccessCtrlRow.Visible = true;
                exchangeAccessLabelRow.Visible = false;
            }
            else
            {
                exchangeAccessCtrlRow.Visible = false;
                exchangeAccessLabelRow.Visible = true;
            }
        }

        protected void createInNaasCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVisibleRows();
        }

        protected void roleCtrl_SelectedIndexChanged(object sender, EventArgs e)
        {
            AssignEditUserAccount(false);
            RebindFlowRepeater();
            UpdateVisibleRows();
        }

        protected void flowRepeaterList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            DataFlow dataFlow = e.Item.DataItem as DataFlow;
            DropDownList flowRoleCtrl = e.Item.FindControl("flowRoleCtrl") as DropDownList;
            Label flowRoleLabel = e.Item.FindControl("flowRoleLabel") as Label;
            HiddenField flowIsProtected = e.Item.FindControl("flowIsProtected") as HiddenField;
            FlowRoleType flowRole = FlowRoleType.None;
            if (_editUserAccount != null)
            {
                flowRole = GetFlowRole(_editUserAccount.Policies, dataFlow.FlowName);
            }
            List<string> possibleRoles = null;
            SystemRoleType selectedRole = SelectedRole;
            bool flowRoleCtrlEnabled = true;

            if (dataFlow.IsProtected)
            {
                flowIsProtected.Value = true.ToString();
                if (selectedRole == SystemRoleType.Authed)
                {
                    possibleRoles = CollectionUtils.CreateList(EnumUtils.ToDescription(FlowRoleType.None),
                                                               EnumUtils.ToDescription(FlowRoleType.Endpoint));
                }
                else
                {
                    possibleRoles = CollectionUtils.CreateList(EnumUtils.GetAllDescriptions<FlowRoleType>());
                }
            }
            else
            {
                if (selectedRole == SystemRoleType.Authed)
                {
                    flowRoleCtrlEnabled = false;
                }
                else
                {
                    possibleRoles = CollectionUtils.CreateList(EnumUtils.ToDescription(FlowRoleType.Endpoint),
                                                               EnumUtils.ToDescription(FlowRoleType.View),
                                                               EnumUtils.ToDescription(FlowRoleType.Modify));
                }
            }

            if (flowRoleCtrlEnabled)
            {
                flowRoleCtrl.DataSource = possibleRoles;
                flowRoleCtrl.DataBind();
                flowRoleCtrl.SelectedIndex = 0;
                flowRoleLabel.Visible = false;
                if (flowRole != FlowRoleType.None)
                {
                    flowRoleCtrl.SelectedValue = EnumUtils.ToDescription(flowRole);
                }
            }
            else
            {
                flowRoleCtrl.Visible = false;
                flowRoleLabel.Text = EnumUtils.ToDescription(FlowRoleType.Endpoint);
            }
        }

        protected void listNaasUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            addSelectedUsers.Enabled = (listNaasUsers.SelectedIndex >= 0);
        }

        protected void addSelectedUsers_Click(object sender, EventArgs e)
        {
            List<string> currentUsernames = GetUsernames();
            List<string> selectedUsernames = AspNetUtils.GetSelectedValues(listNaasUsers);
            List<string> mergedUsernames = CollectionUtils.MergeLists(currentUsernames, selectedUsernames);
            string separator = FirstUsernameSeparator();
            nameCtrl.Text = StringUtils.Join(separator, mergedUsernames);
        }
    }
}
