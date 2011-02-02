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
    public partial class Flow : SecurePage
    {

        #region Members
        private IFlowService _dataItemService;
        #endregion

        #region Spring Biding Stuff

        protected override void InitializeModel()
        {
            base.InitializeModel();
            
            if (_dataItemService == null)
            {
                throw new ArgumentNullException("DataItemService");
            }
        }

        protected override void OnInitializeControls(EventArgs e)
        {
            base.OnInitializeControls(e);

            if (!IsPostBack)
            {
                introParagraphs.DataSource = IntroParagraphs;
                introParagraphs.DataBind();

                flowRepeaterList.ItemDataBound += new RepeaterItemEventHandler(repeater_ItemDataBound);
                flowRepeaterList.DataSource = _dataItemService.GetFlows(VisitHelper.GetVisit(), true);
                flowRepeaterList.DataBind();
            }
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

        #endregion

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
        protected string ServiceDisplayName(object dataItem)
        {
            DataService dataService = (DataService)dataItem;
            return dataService.Name;
        }
        protected string ServiceDisplayDescription(object dataItem)
        {
            DataService dataService = (DataService)dataItem;
            if (dataService.IsActive)
            {
                return EnumUtils.ToDescription(dataService.Type);
            }
            else
            {
                return EnumUtils.ToDescription(dataService.Type) + " [Inactive]";
            }
        }
        protected void OnAddFlowClick(object sender, EventArgs e)
        {
            ResponseRedirect("../Secure/FlowEdit.aspx");
        }
        protected void repeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            DataFlow dataFlow = (DataFlow)e.Item.DataItem;
            if (!CollectionUtils.IsNullOrEmpty(dataFlow.Services))
            {
                Repeater serviceRepeaterList = e.Item.FindControl("serviceRepeaterList") as Repeater;
                if (serviceRepeaterList != null)
                {
                    serviceRepeaterList.DataSource = dataFlow.Services;
                    serviceRepeaterList.DataBind();
                }
            }
        }
        public void OnAddService(object source, CommandEventArgs e)
        {
            ResponseRedirect("../Secure/FlowServiceEdit.aspx?flowid=" + e.CommandArgument);
        }
        #region Properties
        public IFlowService DataItemService
        {
            get { return _dataItemService; }
            set { _dataItemService = value; }
        }
        #endregion
    }
}
