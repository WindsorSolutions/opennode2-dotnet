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
using Spring.DataBinding;
using Windsor.Node2008.WNOSUtility;
using Windsor.Commons.Core;

namespace Windsor.Node2008.Admin.Secure
{
    public partial class ConfigArgsEdit : SecureConfigSectionPage
    {
        private class DataModel
        {
            public ConfigItem _dataItem;
            public string _lastId;
        }
        #region Members

        private DataModel _dataModel;
        private IConfigService _dataItemService;

        #endregion

        #region Spring Biding Stuff

        protected override void InitializeModel()
        {
            base.InitializeModel();

            if (_dataItemService == null)
            {
                throw new ArgumentNullException("DataItemService");
            }

            _dataModel = new DataModel();
            string id = Request["id"];
            if (!string.IsNullOrEmpty(id))
            {
                _dataModel._dataItem = _dataItemService.Get(id);
                _dataModel._lastId = id;
            }
            else
            {
                _dataModel._dataItem = new ConfigItem();
                _dataModel._dataItem.IsEditable = true;
            }
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

                addArgumentBtn.Visible = !string.IsNullOrEmpty(_dataModel._dataItem.Id);

                AspNetUtils.SetFocus(this, codeCtrl, true);
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
            _dataModel = (DataModel)savedModel;
        }

        protected override object SaveModel()
        {
            return _dataModel;
        }

        protected override void InitializeDataBindings()
        {
            BindingManager.AddBinding("codeCtrl.Text", "DataItem.Id");
            BindingManager.AddBinding("codeCtrl.Enabled", "DataItem.IsEditable");
            BindingManager.AddBinding("valueCtrl.Text", "DataItem.Value");
            BindingManager.AddBinding("descriptionCtrl.Text", "DataItem.Description");
            BindingManager.AddBinding("deleteBtn.Enabled", "CanDelete()", BindingDirection.TargetToSource);
        }
        protected bool CanDelete()
        {
            return DataItem.IsEditable && !string.IsNullOrEmpty(DataItem.Id);
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
                    _dataModel._dataItem.Id = _dataModel._dataItem.Id.Trim();
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
            try
            {
                if (divPageError.Visible || !Page.IsValid)
                {
                    // Error on page, get out of here
                    return;
                }
                _dataModel._dataItem = _dataItemService.Save(_dataModel._lastId, _dataModel._dataItem, VisitHelper.GetVisit());
                _dataModel._lastId = _dataModel._dataItem.Id;
                ResponseRedirect("../Secure/ConfigArgs.aspx");
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
                _dataItemService.Delete(_dataModel._dataItem, VisitHelper.GetVisit());
                ResponseRedirect("../Secure/ConfigArgs.aspx");
            }
            catch (Exception ex)
            {
                LOG.Error(ex.Message, ex);
                divPageError.Visible = true;
                divPageError.InnerText = UIUtility.ParseException(ex);
            }
        }
        protected void OnAddArgument(object sender, EventArgs e)
        {
            ResponseRedirect("../Secure/ConfigArgsEdit.aspx");
        }


        #endregion

        #region Properties


        public ConfigItem DataItem
        {
            get
            {
                return _dataModel._dataItem;
            }
            set
            {
                _dataModel._dataItem = value;
            }
        }

        public IConfigService DataItemService
        {
            get
            {
                return _dataItemService;
            }
            set
            {
                _dataItemService = value;
            }
        }

        #endregion
    }
}
