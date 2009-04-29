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

namespace Windsor.Node2008.Admin.Secure
{
    public partial class ConfigPartnerEdit : SecurePage
    {
        #region Members

        private PartnerIdentity _dataItem;
        private IPartnerService _dataItemService;

        #endregion

        #region Spring Biding Stuff

        protected override void InitializeModel()
        {
            base.InitializeModel();

            if (_dataItemService == null)
            {
                throw new ArgumentNullException("DataItemService");
            }
            if (!string.IsNullOrEmpty(Request["id"]))
            {
                _dataItem = _dataItemService.GetByName(Request["id"], VisitHelper.GetVisit());
            }
            else
            {
                _dataItem = new PartnerIdentity();
            }
        }
        protected override void OnInitializeControls(EventArgs e)
        {
            base.OnInitializeControls(e);

            if (!IsPostBack)
            {
                introParagraphs.DataSource = IntroParagraphs;
                introParagraphs.DataBind();

                versionCtrl.DataSource = EnumUtils.GetAllDescriptions<EndpointVersionType>();
                versionCtrl.DataBind();

                AspNetUtils.SetFocus(this, nameCtrl, true);
            }
        }
        protected override void LoadModel(object savedModel)
        {
            _dataItem = (PartnerIdentity)savedModel;
        }

        protected override object SaveModel()
        {
            return _dataItem;
        }

        protected override void InitializeDataBindings()
        {
            BindingManager.AddBinding("idCtrl.Value", "DataItem.Id");
            BindingManager.AddBinding("nameCtrl.Text", "DataItem.Name");
            BindingManager.AddBinding("endpointCtrl.Text", "DataItem.Url");
            BindingManager.AddBinding("deleteBtn.Enabled", "!string.IsNullOrEmpty(DataItem.Id)", BindingDirection.TargetToSource);
            BindingManager.AddBinding("VersionDisplyStringToValue", "DataItem.Version");
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

                    _dataItem.Id = _dataItem.Id.Trim();
                }
            }
            catch (Exception ex)
            {
                divPageError.Visible = true;
                divPageError.InnerText = ExceptionUtils.GetDeepExceptionMessage(ex);
            }
        }
        #endregion
        protected EndpointVersionType VersionDisplyStringToValue
        {
            get
            {
                return EnumUtils.FromDescription<EndpointVersionType>(versionCtrl.SelectedValue);
            }
            set {
                versionCtrl.SelectedValue = EnumUtils.ToDescription<EndpointVersionType>(value);
            }

        }
        protected void SaveDataItem(object sender, EventArgs e)
        {
            try
            {
                _dataItem = _dataItemService.Save(_dataItem, VisitHelper.GetVisit());
                ResponseRedirect("../Secure/ConfigPartner.aspx");
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
                _dataItemService.Delete(_dataItem, VisitHelper.GetVisit());
                ResponseRedirect("../Secure/ConfigPartner.aspx");
            }
            catch (Exception ex)
            {
                LOG.Error(ex.Message, ex);
                divPageError.Visible = true;
                divPageError.InnerText = UIUtility.ParseException(ex);
            }
        }

        protected void OnCheckConnection(object sender, EventArgs e)
        {
            try
            {
                Exception exception = _dataItemService.CheckConnection(_dataItem);
                if (exception != null)
                {
                    divPageError.Visible = true;
                    divPageError.InnerText = UIUtility.ParseException(exception);
                }
                else
                {
                    divPageNote.Visible = true;
                    divPageNote.InnerText = "Node endpoint connection attempt was successful!";
                }
            }
            catch (Exception ex)
            {
                LOG.Error(ex.Message, ex);
                divPageError.Visible = true;
                divPageError.InnerText = UIUtility.ParseException(ex);
            }
        }
        #region Properties


        public PartnerIdentity DataItem
        {
            get { return _dataItem; }
            set { _dataItem = value; }
        }

        public IPartnerService DataItemService
        {
            get { return _dataItemService; }
            set { _dataItemService = value; }
        }

        #endregion
    }
}
