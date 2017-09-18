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
using System.IO;
using Common.Logging;
using Windsor.Node2008.WNOSConnector.Admin;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.Admin.Controls;
using Windsor.Node2008.WNOSUtility;
using Spring.DataBinding;
using Windsor.Node2008.WNOSConnector.Server;
using Windsor.Node2008.WNOSProviders;
using Windsor.Commons.Core;

namespace Windsor.Node2008.Admin.Secure
{
    public partial class FlowUploadPlugin : SecurePage
    {
        #region Members

        public class DataModel
        {
            private string _flowName;

            public string FlowName
            {
                get { return _flowName; }
                set { _flowName = value; }
            }


        }
        private DataModel _dataModel;
        private IFlowService _dataItemService;
        private ISettingsProvider _settingsProviderService;

        #endregion
        #region Spring Biding Stuff

        protected override void InitializeModel()
        {
            base.InitializeModel();

            if (_dataItemService == null)
            {
                throw new ArgumentNullException("DataItemService");
            }
            if (_settingsProviderService == null)
            {
                throw new ArgumentNullException("_settingsProvider");
            }
            _dataModel = new DataModel();
        }
        protected override void OnInitializeControls(EventArgs e)
        {
            if (Response.IsRequestBeingRedirected)
            {
                return;
            }

            base.OnInitializeControls(e);

            if (!IsPostBack)
            {
                introParagraphs.DataSource = IntroParagraphs;
                introParagraphs.DataBind();

                flowDropDownList.DataSource = _dataItemService.GetDataFlowNames();
                flowDropDownList.DataBind();

                AspNetUtils.SetFocus(this, fileUpload, false);
            }
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
            BindingManager.AddBinding("flowDropDownList.SelectedValue", "Model.FlowName",
                                      BindingDirection.SourceToTarget);
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
            ResponseRedirect("Flow.aspx");
        }
        protected void UploadPlugin(object sender, EventArgs e)
        {
            if (divPageError.Visible || !Page.IsValid)
            {
                // Error on page, get out of here
                return;
            }
            try
            {
                _dataItemService.InstallPluginForFlow(fileUpload.FileBytes, Model.FlowName, 
                                                      VisitHelper.GetVisit());

                ResponseRedirect("Flow.aspx");
            }
            catch (Exception ex)
            {
                LOG.Error(ex.Message, ex);
                divPageError.Visible = true;
                divPageError.InnerText = ExceptionUtils.GetDeepExceptionMessage(ex);
            }
        }
        protected void ServerValidateFileUpload(Object source, ServerValidateEventArgs e)
        {
            e.IsValid = true;
            if (!fileUpload.HasFile)
            {
                fileUploadValidator.ErrorMessage = "Please choose a plugin file";
                e.IsValid = false;
            }
            else
            {
                string fileExtension = Path.GetExtension(fileUpload.FileName).ToLower();
                if (fileExtension != ".zip")
                {
                    fileUploadValidator.ErrorMessage = "Plugin file must be a zip file";
                    e.IsValid = false;
                }
            }
        }

        #endregion

        #region Properties

        public IFlowService DataItemService
        {
            get { return _dataItemService; }
            set { _dataItemService = value; }
        }
        public DataModel Model
        {
            get { return _dataModel; }
            set { _dataModel = value; }
        }
        public ISettingsProvider SettingsProviderService
        {
            get { return _settingsProviderService; }
            set { _settingsProviderService = value; }
        }
        #endregion
    }
}
