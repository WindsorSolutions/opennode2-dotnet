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

        public class DataModel
        {
            private DataFlow _dataFlow;

            public DataFlow DataFlow
            {
                get { return _dataFlow; }
                set { _dataFlow = value; }
            }
            private bool _isNewFlow;

            public bool IsNewFlow
            {
                get { return _isNewFlow; }
                set { _isNewFlow = value; }
            }

            private string _contactUsername;

            public string ContactUsername
            {
                get { return _contactUsername; }
                set { _contactUsername = value; }
            }
        }
        private DataModel _dataModel;
        private IFlowService _dataItemService;

        #endregion

        /* Lifecycle
        OnInit() -> if ( !Postback ) InitializeModel()

        if ( Postback ) UnbindFormData()

        Page_Load()

        BindFormData()
        */

        protected override void OnInit(EventArgs e)
        {
            if (_dataItemService == null)
            {
                throw new ArgumentNullException("_dataItemService");
            }
            base.OnInit(e);

            if (_dataModel == null)
            {
                throw new ArgumentNullException("_dataModel");
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

                contactsDropDownList.DataSource = _dataItemService.GetFlowContactList();
                contactsDropDownList.DataBind();

                if (_dataModel.IsNewFlow)
                {
                    deleteBtn.Visible = false;
                    AspNetUtils.SetFocus(this, nameEdit, false);
                }
                else
                {
                    nameEdit.Enabled = false;
                    AspNetUtils.SetFocus(this, descriptionTextBox, true);
                }
            }
        }
        #region Spring Biding Stuff

        protected override void InitializeModel()
        {
            base.InitializeModel();

            _dataModel = new DataModel();
            string id = Request["id"];
            if (!string.IsNullOrEmpty(id))
            {
                _dataModel.DataFlow = _dataItemService.GetFlow(id, VisitHelper.GetVisit());
                if (_dataModel.DataFlow == null)
                {
                    throw new ArgumentException("Flow not found");
                }
                if ( !string.IsNullOrEmpty(_dataModel.DataFlow.ContactUserId) )
                {
                    _dataModel.ContactUsername = _dataItemService.GetUsernameById(_dataModel.DataFlow.ContactUserId);
                }
            }
            else
            {
                _dataModel.IsNewFlow = true;
                _dataModel.DataFlow = new DataFlow();
            }
        }

        public override string UniqueDataModelKey
        {
            get { return Request["id"]; }
        }
        protected override void LoadModel(object savedModel)
        {
            _dataModel = (DataModel)savedModel;
        }

        protected override object SaveModel()
        {
            return _dataModel;
        }
        protected override void InitializeDataBindings()
        {
            BindingManager.AddBinding("nameEdit.Text", "DataFlow.FlowName");
            BindingManager.AddBinding("descriptionTextBox.Text", "DataFlow.Description");
            BindingManager.AddBinding("contactsDropDownList.SelectedValue", "Model.ContactUsername");
            BindingManager.AddBinding("webInfoTextBox.Text", "DataFlow.InfoUrl");
            BindingManager.AddBinding("protectedCheckBox.Checked", "DataFlow.IsProtected");
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
                    DataFlow.FlowName = DataFlow.FlowName.Trim();
                }
            }
            catch (Exception ex)
            {
                divPageError.Visible = true;
                divPageError.InnerText = ExceptionUtils.GetDeepExceptionMessage(ex);
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
                _dataModel.DataFlow.ContactUserId = _dataItemService.GetUserIdByName(_dataModel.ContactUsername);
                if (string.IsNullOrEmpty(_dataModel.DataFlow.ContactUserId))
                {
                    throw new ArgumentException("ContactUserId not found");
                }
                _dataModel.DataFlow = 
                    _dataItemService.SaveFlow(_dataModel.DataFlow, VisitHelper.GetVisit());

                ResponseRedirect("Flow.aspx");
            }
            catch (Exception ex)
            {
                LOG.Error(ex.Message, ex);
                divPageError.Visible = true;
                divPageError.InnerText = ExceptionUtils.GetDeepExceptionMessage(ex);
            }
        }

        protected void DeleteDataItem(object sender, EventArgs e)
        {
            try
            {
                _dataItemService.DeleteFlow(_dataModel.DataFlow, VisitHelper.GetVisit());
                ResponseRedirect("../Secure/Flow.aspx");
            }
            catch (Exception ex)
            {
                LOG.Error(ex.Message, ex);
                divPageError.Visible = true;
                divPageError.InnerText = ExceptionUtils.GetDeepExceptionMessage(ex);
            }
        }
        #endregion

        #region Properties

        public IFlowService DataItemService
        {
            get { return _dataItemService; }
            set { _dataItemService = value; }
        }
        public DataFlow DataFlow
        {
            get { return _dataModel.DataFlow; }
            set { _dataModel.DataFlow = value; }
        }
        public DataModel Model
        {
            get { return _dataModel; }
            set { _dataModel = value; }
        }
        #endregion
    }
}
