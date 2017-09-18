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
using Windsor.Node2008.WNOSUtility;
using Windsor.Node2008.WNOSConnector.Admin;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.Admin.Controls;
using Spring.DataBinding;
using Windsor.Commons.Core;

namespace Windsor.Node2008.Admin.Secure
{
    public partial class ProfileChangePassword : SecurePage
    {

        #region Members

        private UserAccount _dataItem;
        private IAccountService _dataItemService;
        protected bool _didValidate;

        #endregion
        #region Spring Biding Stuff

        protected override void InitializeModel()
        {
            base.InitializeModel();

            if (_dataItemService == null)
            {
                throw new ArgumentNullException("DataItemService");
            }
            _dataItem = VisitHelper.GetVisit().Account;
        }
        protected override void OnInitializeControls(EventArgs e)
        {
            base.OnInitializeControls(e);

            if (!IsPostBack)
            {
                introParagraphs.DataSource = IntroParagraphs;
                introParagraphs.DataBind();

                currentPasswordValue.Text = newPasswordValue1.Text = newPasswordValue2.Text = string.Empty;

                AspNetUtils.SetFocus(this, currentPasswordValue, false);
            }
            else
            {
                divPageError.Visible = false;
            }
        }
        protected override void LoadModel(object savedModel)
        {
            _dataItem = (UserAccount)savedModel;
        }

        protected override object SaveModel()
        {
            return _dataItem;
        }

        protected override void InitializeDataBindings()
        {
            BindingManager.AddBinding("nameValue.Text", "DataItem.NaasAccount",
                                      BindingDirection.TargetToSource);
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
        protected override void UnbindFormData()
        {
            try
            {
                divPageError.Visible = false;

                base.UnbindFormData();
            }
            catch (Exception ex)
            {
                SetDivPageError(ex);
            }
        }

        #endregion

        public override void Validate()
        {
            if (!_didValidate)
            {
                divPageError.Visible = false;
                base.Validate();
                _didValidate = true;
            }
        }
        protected void ServerValidateCurrentPassword(Object source,
                                                       ServerValidateEventArgs e)
        {
            if (_didValidate) return;
            if (currentPasswordValue.Text.Length == 0)
            {
                e.IsValid = false;
                AppendDivPageError("Please enter the current password.");
                return;
            }
        }
        protected void ServerValidateNewPassword1(Object source, ServerValidateEventArgs e)
        {
            if (_didValidate) return;
            if ((newPasswordValue1.Text.Length == 0) || (newPasswordValue2.Text.Length == 0))
            {
                e.IsValid = false;
                AppendDivPageError("Please enter two matching new passwords.");
                return;
            }
            if ((newPasswordValue1.Text.Length > 0) && (newPasswordValue2.Text.Length > 0))
            {
                e.IsValid = (newPasswordValue1.Text == newPasswordValue2.Text);
                if (!e.IsValid)
                {
                    AppendDivPageError("The two new passwords do not match.  Please reenter them.");
                    return;
                }
                else
                {
                    string errorMessage = ValidationHelper.IsValidNAASPassword(newPasswordValue1.Text);
                    if (errorMessage != null)
                    {
                        e.IsValid = false;
                        AppendDivPageError("The new passwords are not valid: " + errorMessage + ".  Please reenter them.");
                        return;
                    }
                }
            }
        }
        protected void ServerValidateNewPassword2(Object source, ServerValidateEventArgs e)
        {
            if (_didValidate) return;
            if ((newPasswordValue1.Text.Length == 0) || (newPasswordValue2.Text.Length == 0))
            {
                e.IsValid = false;
                return;
            }
            if ((newPasswordValue1.Text.Length > 0) && (newPasswordValue2.Text.Length > 0))
            {
                e.IsValid = (newPasswordValue1.Text == newPasswordValue2.Text);
                if (!e.IsValid)
                {
                    return;
                }
                else
                {
                    string errorMessage = ValidationHelper.IsValidNAASPassword(newPasswordValue1.Text);
                    if (errorMessage != null)
                    {
                        e.IsValid = false;
                        return;
                    }
                }
            }
        }
        protected void OnChangePassword(object sender, EventArgs e)
        {
            if (divPageError.Visible || !Page.IsValid)
            {
                // Error on page, get out of here
                return;
            }
            try
            {
                _dataItem = _dataItemService.ResetPassword(currentPasswordValue.Text, newPasswordValue1.Text,
                                                           _dataItem, VisitHelper.GetVisit());
                ResponseRedirect("../Secure/Profile.aspx");
            }
            catch (Exception ex)
            {
                LOG.Error(ex.Message, ex);
                SetDivPageError(ex);
            }
        }
        #region Properties

        public IAccountService DataItemService
        {
            get { return _dataItemService; }
            set { _dataItemService = value; }
        }

        public UserAccount DataItem
        {
            get { return _dataItem; }
            set { _dataItem = value; }
        }

        #endregion
    }
}
