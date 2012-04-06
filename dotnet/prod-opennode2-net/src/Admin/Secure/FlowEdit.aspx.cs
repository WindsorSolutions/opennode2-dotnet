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
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.Caching;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Common.Logging;
using Windsor.Node2008.WNOSConnector.Admin;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.Admin.Controls;
using Windsor.Node2008.WNOSUtility;
using Spring.DataBinding;
using Windsor.Node2008.WNOSConnector.Server;
using Windsor.Commons.Core;

namespace Windsor.Node2008.Admin.Secure
{
    public partial class FlowEdit : SecurePage
    {
        #region Members

        private class DataModel
        {
            public DataFlow DataFlow { get; set; }
            public bool IsNewFlow { get; set; }
            public string ContactUsername { get; set; }
        }
        private DataModel Model { get; set; }
        public IFlowService FlowService { get; set; }

        #endregion

        protected override void OnInit(EventArgs e)
        {
            if (FlowService == null)
            {
                throw new ArgumentNullException("Missing FlowService");
            }
            base.OnInit(e);
        }

        protected override void OnInitializeControls(EventArgs e)
        {
            LoadModel();

            if (Response.IsRequestBeingRedirected)
            {
                return;
            }

            base.OnInitializeControls(e);

            bool disableEditing = (Model == null);

            if (!disableEditing && !this.IsPostBack)
            {
                SecureMasterPage.SetupPage(SideTabs, SelectedTabIndex);

                introParagraphs.DataSource = IntroParagraphs;
                introParagraphs.DataBind();

                contactsDropDownList.DataSource = FlowService.GetFlowContactList();
                contactsDropDownList.DataBind();

                if (Model.IsNewFlow)
                {
                    if (!CanEditNewFlows())
                    {
                        ResponseRedirect("~/Secure/Flow.aspx");
                        return;
                    }
                    deleteBtn.Visible = false;
                }
                else
                {
                    if (!CanViewFlowByName(Model.DataFlow.FlowName))
                    {
                        ResponseRedirect("~/Secure/Flow.aspx");
                        return;
                    }
                    nameEdit.Text = Model.DataFlow.FlowName;
                    descriptionTextBox.Text = Model.DataFlow.Description;
                    contactsDropDownList.SelectedValue = Model.ContactUsername;
                    webInfoTextBox.Text = Model.DataFlow.InfoUrl;
                    protectedCheckBox.Checked = Model.DataFlow.IsProtected;
                    disableEditing = !CanEditFlowByName(Model.DataFlow.FlowName);
                    nameEdit.Enabled = false;
                    deleteBtn.Visible = CanEditNewFlows();
                }
            }
            if (disableEditing)
            {
                nameEdit.Enabled = descriptionTextBox.Enabled = contactsDropDownList.Enabled =
                    webInfoTextBox.Enabled = protectedCheckBox.Enabled = false;
                deleteBtn.Visible = saveBtn.Visible = false;
                CustomValidator7.Visible = false;
                cancelBtn.Text = "Back";
            }
            else if (!this.IsPostBack)
            {
                if (nameEdit.Enabled)
                {
                    AspNetUtils.SetFocus(this, nameEdit, false);
                }
                else if (descriptionTextBox.Enabled)
                {
                    AspNetUtils.SetFocus(this, descriptionTextBox, true);
                }
            }
        }
        #region Spring Biding Stuff

        protected void LoadModel()
        {
            try
            {
                Model = new DataModel();
                string id = Request["id"];
                if (!string.IsNullOrEmpty(id))
                {
                    if (!CanViewFlowById(id))
                    {
                        Model = null;
                        ResponseRedirect("~/Secure/Flow.aspx");
                        return;
                    }
                    Model.DataFlow = FlowService.GetFlow(id, VisitHelper.GetVisit());
                    if (Model.DataFlow == null)
                    {
                        throw new ArgumentException(string.Format("Flow with id \"{0}\" not found", id));
                    }
                    if (!string.IsNullOrEmpty(Model.DataFlow.ContactUserId))
                    {
                        Model.ContactUsername = FlowService.GetUsernameById(Model.DataFlow.ContactUserId);
                    }
                }
                else
                {
                    Model.IsNewFlow = true;
                    Model.DataFlow = new DataFlow();
                }
            }
            catch (Exception ex)
            {
                Model = null;
                SetDivPageError("Failed to load data for flow: ", ex);
            }
        }
        protected void ControlsToModel()
        {
            Model.DataFlow.FlowName = nameEdit.Text.Trim();
            Model.DataFlow.Description = descriptionTextBox.Text.Trim();
            Model.ContactUsername = contactsDropDownList.SelectedValue;
            Model.DataFlow.InfoUrl = webInfoTextBox.Text.Trim();
            Model.DataFlow.IsProtected = protectedCheckBox.Checked;
            Model.DataFlow.ContactUserId = FlowService.GetUserIdByName(Model.ContactUsername);
            if (string.IsNullOrEmpty(Model.DataFlow.ContactUserId))
            {
                throw new ArgumentException("ContactUserId not found");
            }
        }
        protected void CancelItem(object sender, EventArgs e)
        {
            ResponseRedirect("../Secure/Flow.aspx");
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
                ControlsToModel();

                Model.DataFlow = FlowService.SaveFlow(Model.DataFlow, VisitHelper.GetVisit());

                ResponseRedirect("Flow.aspx");
            }
            catch (Exception ex)
            {
                LOG.Error(ex.Message, ex);
                SetDivPageError(ex);
            }
        }

        protected void DeleteDataItem(object sender, EventArgs e)
        {
            try
            {
                FlowService.DeleteFlow(Model.DataFlow, VisitHelper.GetVisit());
                ResponseRedirect("../Secure/Flow.aspx");
            }
            catch (Exception ex)
            {
                LOG.Error(ex.Message, ex);
                SetDivPageError(ex);
            }
        }
        #endregion
    }
}
