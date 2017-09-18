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
using System.Collections.Generic;
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
using Windsor.Node2008.WNOSProviders;

namespace Windsor.Node2008.Admin.Secure
{
    public partial class Flow : SecurePage
    {
        private const string FLOW_PAGE_SESSION_STATE_KEY = "FLOW_PAGE_SESSION_STATE_KEY";
        private bool NeedsRebind
        {
            get;
            set;
        }

        protected class SessionStateDataStorage
        {
            public IList<string> HiddenFlows;
        }

        #region Members
        public IFlowService FlowService
        {
            get;
            set;
        }
        public IUserSettingsManager UserSettingsManager
        {
            get;
            set;
        }
        protected SessionStateDataStorage SessionStateData
        {
            get;
            set;
        }
        #endregion

        #region Spring Biding Stuff

        protected override void InitializeModel()
        {
            base.InitializeModel();

            if (FlowService == null)
            {
                throw new ArgumentNullException("Missing FlowService");
            }
            if (UserSettingsManager == null)
            {
                throw new ArgumentNullException("Missing UserSettingsManager");
            }
        }

        protected override void OnInitializeControls(EventArgs e)
        {
            SessionStateData = Session[FLOW_PAGE_SESSION_STATE_KEY] as SessionStateDataStorage;
            if (SessionStateData == null)
            {
                SessionStateData = new SessionStateDataStorage();
                Session[FLOW_PAGE_SESSION_STATE_KEY] = SessionStateData;

                SessionStateData.HiddenFlows = UserSettingsManager.LoadAdminFlowPageHiddenFlowIds(GetCurrentUsername());

                if (SessionStateData.HiddenFlows == null)
                {
                    SessionStateData.HiddenFlows = new CaseInsensitiveList();
                }
            }

            base.OnInitializeControls(e);

            addExchangeBtn.Visible = UserIsAdmin();

            if (!IsPostBack)
            {
                introParagraphs.DataSource = IntroParagraphs;
                introParagraphs.DataBind();

                BindFlows();
            }
        }
        protected virtual void BindFlows()
        {
            flowRepeaterList.ItemDataBound += new RepeaterItemEventHandler(repeater_ItemDataBound);
            flowRepeaterList.DataSource = FlowService.GetFlows(VisitHelper.GetVisit(), true);
            flowRepeaterList.DataBind();
        }
        protected override void BindFormData()
        {
            try
            {
                if (!this.IsPostBack)
                {
                    base.BindFormData();
                }
                if (NeedsRebind)
                {
                    BindFlows();
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

                this.Validate();

                if (this.IsValid)
                {
                    base.UnbindFormData();
                }
            }
            catch (Exception ex)
            {
                SetDivPageError(ex);
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
        protected virtual bool IsFlowExpanded(string flowId)
        {
            return !SessionStateData.HiddenFlows.Contains(flowId);
        }
        protected virtual bool SetFlowExpanded(string flowId, bool isExpanded)
        {
            if (!isExpanded)
            {
                if (!SessionStateData.HiddenFlows.Contains(flowId))
                {
                    SessionStateData.HiddenFlows.Add(flowId);
                }
            }
            else
            {
                SessionStateData.HiddenFlows.Remove(flowId);
            }
            UserSettingsManager.SaveAdminFlowPageHiddenFlowIds(GetCurrentUsername(), SessionStateData.HiddenFlows);
            return isExpanded;
        }
        protected virtual string FlowServicesDisplay(object dataItem)
        {
            DataFlow dataFlow = (DataFlow)dataItem;
            return IsFlowExpanded(dataFlow.Id) ? "" : "display: none";
        }
        protected string ServiceDisplayName(object dataItem)
        {
            DataService dataService = (DataService)dataItem;
            return dataService.Name;
        }
        protected string ServiceToolTipEditName(object dataItem)
        {
            DataService dataService = (DataService)dataItem;
            string tooltip =
                FlowEditPrefixTextById(dataService.FlowId) + " '" + ServiceDisplayName(dataItem) + "  (" +
                ServiceDisplayDescription(dataItem) + ")'";
            return tooltip;
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
        protected string FlowToolTipEditName(object dataItem)
        {
            DataFlow dataFlow = (DataFlow)dataItem;
            string tooltip = FlowEditPrefixTextByName(dataFlow.FlowName) + " '" +
                             FlowDisplayName(dataItem) + "'";
            return tooltip;
        }
        protected void repeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            DataFlow dataFlow = (DataFlow)e.Item.DataItem;

            bool isExpanded = IsFlowExpanded(dataFlow.Id);

            ImageButton expandCollapseButton = e.Item.FindControl("expandCollapseServicesImageButton") as ImageButton;

            if (isExpanded)
            {
                expandCollapseButton.ImageUrl = "../Images/UI/collapse_16.png";
                expandCollapseButton.ToolTip = "Hide Services";
            }
            else
            {
                expandCollapseButton.ImageUrl = "../Images/UI/expand_16.png";
                expandCollapseButton.ToolTip = "Show Services";
            }

            if (isExpanded && !CollectionUtils.IsNullOrEmpty(dataFlow.Services))
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
        protected void OnExpandCollapseServicesClick(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                ImageButton control = sender as ImageButton;
                if (control == null)
                {
                    return;
                }
                bool isExpanded = SetFlowExpanded(control.CommandArgument, !IsFlowExpanded(control.CommandArgument));
                NeedsRebind = true;
            }
        }

        protected void ExpandAllLinkButton_Click(object sender, EventArgs e)
        {
            SessionStateData.HiddenFlows.Clear();
            UserSettingsManager.SaveAdminFlowPageHiddenFlowIds(GetCurrentUsername(), SessionStateData.HiddenFlows);
            NeedsRebind = true;
        }
        protected void CollapseAllLinkButton_Click(object sender, EventArgs e)
        {
            IList<DataFlow> flows = FlowService.GetFlows(VisitHelper.GetVisit(), true);
            SessionStateData.HiddenFlows.Clear();
            CollectionUtils.ForEach(flows, delegate(DataFlow dataFlow)
            {
                SessionStateData.HiddenFlows.Add(dataFlow.Id);
            });
            UserSettingsManager.SaveAdminFlowPageHiddenFlowIds(GetCurrentUsername(), SessionStateData.HiddenFlows);
            NeedsRebind = true;
        }
    }
}
