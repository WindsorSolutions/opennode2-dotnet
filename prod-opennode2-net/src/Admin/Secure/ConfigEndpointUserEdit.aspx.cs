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
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.Admin.Controls;
using Windsor.Node2008.WNOSUtility;
using Spring.DataBinding;
using Windsor.Commons.Core;
using Windsor.Commons.NodeDomain;

namespace Windsor.Node2008.Admin.Secure
{
    public partial class ConfigEndpointUserEdit : SecureConfigSectionPage
    {
        #region Spring Biding Stuff

        protected string m_TestPassword;
        protected string m_ProdPassword;

        protected override void InitializeModel()
        {
            base.InitializeModel();

            string id = UniqueDataModelKey;

            if (!string.IsNullOrEmpty(id))
            {
                DataItem = EndpointUserService.GetByName(id, VisitHelper.GetVisit());
            }
            else
            {
                DataItem = new UserAccount();
            }
        }
        protected override void OnInitializeControls(EventArgs e)
        {
            if (Response.IsRequestBeingRedirected)
            {
                return;
            }

            base.OnInitializeControls(e);

            addEndpointUserBtn.Visible = false;

            if (!IsPostBack)
            {
                introParagraphs.DataSource = IntroParagraphs;
                introParagraphs.DataBind();

                if (!string.IsNullOrEmpty(DataItem.Id))
                {
                    removeBtn.Visible = true;
                    usernameDropDownList.Visible = false;
                    usernameLabel.Visible = true;

                    AspNetUtils.SetFocus(this, testNaasPasswordCtrl, true);
                }
                else
                {
                    removeBtn.Visible = false;
                    usernameLabel.Visible = false;

                    usernameDropDownList.Visible = true;
                    usernameDropDownList.DataTextField = usernameDropDownList.DataValueField = "NaasAccount";
                    usernameDropDownList.DataSource = EndpointUserService.GetAllPossibleEndpointUsers(VisitHelper.GetVisit());
                    usernameDropDownList.DataBind();

                    AspNetUtils.SetFocus(this, usernameDropDownList, true);
                }
            }
        }
        public override string UniqueDataModelKey
        {
            get
            {
                return Request["id"];
            }
        }
        protected override void LoadModel(object savedModel)
        {
            DataItem = (UserAccount)savedModel;
        }

        protected override object SaveModel()
        {
            return DataItem;
        }

        protected void ServerValidateTestOrProdPassword(Object source, ServerValidateEventArgs e)
        {
            CustomValidator validator = (CustomValidator)source;
            PasswordTextBox passwordControl = AspNetUtils.FindDeepControl(this, validator.ControlToValidate) as PasswordTextBox;
            string password = passwordControl.Text.Trim();
            e.IsValid = (password.Length > 0);
        }
        protected override void InitializeDataBindings()
        {
            BindingManager.AddBinding("idCtrl.Value", "DataItem.Id");
            BindingManager.AddBinding("GetSetControlUsername", "DataItem.NaasAccount");
            BindingManager.AddBinding("testNaasPasswordCtrl.Text.Trim()", "m_TestPassword");
            BindingManager.AddBinding("prodNaasPasswordCtrl.Text.Trim()", "m_ProdPassword");
        }

        protected string GetSetControlUsername
        {
            get
            {
                if (!string.IsNullOrEmpty(DataItem.Id))
                {
                    return usernameLabel.Text;
                }
                else
                {
                    return usernameDropDownList.SelectedValue;
                }
            }
            set
            {
                if (!string.IsNullOrEmpty(DataItem.Id))
                {
                    usernameLabel.Text = value;
                }
                else
                {
                    usernameDropDownList.SelectedValue = value;
                }
            }

        }
        protected override void UnbindFormData()
        {
            try
            {
                divPageError.Visible = false;

                this.Validate();

                base.UnbindFormData();

                if (this.IsValid)
                {
                    DataItem.Id = DataItem.Id.Trim();
                }
            }
            catch (Exception ex)
            {
                divPageError.Visible = true;
                divPageError.InnerText = ExceptionUtils.GetDeepExceptionMessage(ex);
            }
        }
        #endregion
        protected void SaveDataItem(object sender, EventArgs e)
        {
            try
            {
                if (divPageError.Visible || !Page.IsValid)
                {
                    // Error on page, get out of here
                    return;
                }
                DataItem = EndpointUserService.Save(DataItem, m_TestPassword, m_ProdPassword, VisitHelper.GetVisit());
                ResponseRedirect("../Secure/ConfigEndpointUser.aspx");
            }
            catch (Exception ex)
            {
                LOG.Error(ex.Message, ex);
                divPageError.Visible = true;
                divPageError.InnerText = UIUtility.ParseException(ex);
            }
        }


        protected void RemoveDataItem(object sender, EventArgs e)
        {
            try
            {
                EndpointUserService.Remove(DataItem, VisitHelper.GetVisit());
                ResponseRedirect("../Secure/ConfigEndpointUser.aspx");
            }
            catch (Exception ex)
            {
                LOG.Error(ex.Message, ex);
                divPageError.Visible = true;
                divPageError.InnerText = UIUtility.ParseException(ex);
            }
        }

        protected void OnCheckPasswords(object sender, EventArgs e)
        {
            try
            {
                usernameValidator.Enabled = false;
                UnbindFormData();
            }
            finally
            {
                usernameValidator.Enabled = true;
            }
            if (!this.IsValid)
            {
                return;
            }
            try
            {
                string message = EndpointUserService.CheckPasswords(DataItem, m_TestPassword, m_ProdPassword, VisitHelper.GetVisit());
                if (!string.IsNullOrEmpty(message))
                {
                    divPageError.Visible = true;
                    message = HttpUtility.HtmlEncode(message);
                    divPageError.InnerHtml = message.Replace(Environment.NewLine, "<br />");
                }
                else
                {
                    divPageNote.Visible = true;
                    divPageNote.InnerText = "Passwords are valid!";
                }
            }
            catch (Exception ex)
            {
                LOG.Error(ex.Message, ex);
                divPageError.Visible = true;
                divPageError.InnerText = UIUtility.ParseException(ex);
            }
        }
        protected void OnAddEndpointUser(object sender, EventArgs e)
        {
            ResponseRedirect("../Secure/ConfigEndpointUserEdit.aspx");
        }
        #region Properties


        public UserAccount DataItem
        {
            get;
            set;
        }

        #endregion
    }
}
