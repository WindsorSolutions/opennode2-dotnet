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
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.Admin.Controls;
using Windsor.Node2008.WNOSUtility;
using Windsor.Commons.Core;

namespace Windsor.Node2008.Admin.Secure
{
    public partial class Schedule : SecureListPage
    {
        public class ModelState
        {
            private Dictionary<string, string> _flows;
            private Dictionary<string, Dictionary<string, SimpleListDisplayInfo>> _scheduledItems;
            
            public ModelState()
            {
            }
            public Dictionary<string, string> Flows
            {
                get { return _flows; }
                set { _flows = value; }
            }
            public Dictionary<string, Dictionary<string, SimpleListDisplayInfo>> ScheduledItems
            {
                get { return _scheduledItems; }
                set { _scheduledItems = value; }
            }
        }
        #region Members
        const string showInfoScriptName = "ShowInfoScript";
        private IScheduleService _dataItemService;
        private ModelState _modelState;
        #endregion

        protected void lastRunInfoButton_Click(object sender, EventArgs e)
        {
            LinkButton control = sender as LinkButton;
            if (control != null)
            {
                Control control2 = control.Parent.FindControl("lastRunTextRow");
                if (control2 != null)
                {
                    control2.Visible = !control2.Visible;
                    if (control2.Visible)
                    {
                        control.Text = "Hide Last Run Info <<";
                    }
                    else
                    {
                        control.Text = "Show Last Run Info >>";
                    }
                }
            }
        }

        void repeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            HtmlTableCell cell = e.Item.FindControl("valueNameItem") as HtmlTableCell;
            if (cell != null)
            {
                cell.Style.Add(HtmlTextWriterStyle.FontWeight, "bold");
            }
            KeyValuePair<string, SimpleListDisplayInfo> pair =
                (KeyValuePair<string, SimpleListDisplayInfo>)e.Item.DataItem;
            ScheduledItem scheduledItem = pair.Value.Element as ScheduledItem;
            if (scheduledItem != null)
            {
                Image image = e.Item.FindControl("executeStatusImage") as Image;
                if (image != null)
                {
                    image.ImageUrl = GetImageUrlForExecuteStatus(scheduledItem.ExecuteStatus);
                    image.ToolTip = "Status: " + EnumUtils.ToDescription(scheduledItem.ExecuteStatus);
                }
                if (scheduledItem.ExecuteStatus == ScheduleExecuteStatus.Running)
                {
                    // Hide some fields if running
                    HtmlTableRow valueDescriptionRow = e.Item.FindControl("valueDescriptionRow") as HtmlTableRow;
                    if (valueDescriptionRow != null)
                    {
                        valueDescriptionRow.Visible = false;
                    }
                }
                else
                {
                    if (scheduledItem.LastExecuteInfo != null)
                    {
                        HtmlTableRow lastRunInfoRow = e.Item.FindControl("lastRunInfoRow") as HtmlTableRow;
                        lastRunInfoRow.Visible = true;
                        if (lastRunInfoRow != null)
                        {
                            ImageButton imageButton = e.Item.FindControl("transactionImageButton") as ImageButton;
                            if (imageButton != null)
                            {
                                if (string.IsNullOrEmpty(scheduledItem.LastExecuteInfo.TransactionId))
                                {
                                    imageButton.Visible = false;
                                }
                                else
                                {
                                    imageButton.ToolTip = string.Format("View Transaction Detail: {0}", scheduledItem.LastExecuteInfo.TransactionId);
                                    imageButton.CommandArgument = scheduledItem.LastExecuteInfo.TransactionId;
                                }
                            }
                        }
                        HtmlTableRow lastRunTextRow = e.Item.FindControl("lastRunTextRow") as HtmlTableRow;
                        if (lastRunTextRow != null)
                        {
                            Label infoLabel = e.Item.FindControl("infoTextLabel") as Label;
                            if (infoLabel != null)
                            {
                                string text = scheduledItem.LastExecuteInfo.Summary.Replace("\r\n", "<br/><br/>");
                                infoLabel.Text = text;
                            }
                        }
                    }
                }
            }
        }
        protected string GetImageUrlForExecuteStatus(ScheduleExecuteStatus type)
        {
            switch (type)
            {
                case ScheduleExecuteStatus.CompletedSuccess: return "../Images/flag_green.gif";
                case ScheduleExecuteStatus.CompletedFailure: return "../Images/flag_red.gif";
                case ScheduleExecuteStatus.Running: return "../Images/gear_run.gif";
                default: return "../Images/flag_white.gif";
            }
        }
        public void OnViewTransactionDetailClick(object source, CommandEventArgs e)
        {
            ResponseRedirect("../Secure/Transaction.aspx?back=true&id=" + e.CommandArgument);
        }
        #region Properties

        #region Spring Biding Stuff

        protected override void InitializeModel()
        {
            base.InitializeModel();

            if (_dataItemService == null)
            {
                throw new ArgumentNullException("DataItemService");
            }

            _modelState = new ModelState();
            IDictionary<string, SimpleListDisplayInfo> scheduledItems = _dataItemService.GetListInfo();
            if (!CollectionUtils.IsNullOrEmpty(scheduledItems))
            {
                IDictionary<string, string> flows = _dataItemService.GetExchangeList();
                _modelState.ScheduledItems = new Dictionary<string, Dictionary<string, SimpleListDisplayInfo>>();
                _modelState.Flows = new Dictionary<string, string>();
                foreach (KeyValuePair<string, SimpleListDisplayInfo> pair in scheduledItems)
                {
                    ScheduledItem scheduledItem = (ScheduledItem)pair.Value.Element;
                    Dictionary<string, SimpleListDisplayInfo> scheduledItemList;
                    if (!_modelState.ScheduledItems.TryGetValue(scheduledItem.FlowId, out scheduledItemList))
                    {
                        scheduledItemList = new Dictionary<string, SimpleListDisplayInfo>();
                        _modelState.ScheduledItems.Add(scheduledItem.FlowId, scheduledItemList);
                    }
                    scheduledItemList.Add(pair.Key, pair.Value);
                    if (!_modelState.Flows.ContainsKey(scheduledItem.FlowId))
                    {
                        string flowName = flows[scheduledItem.FlowId];
                        _modelState.Flows.Add(scheduledItem.FlowId, flowName);
                    }
                }
            }
        }
        protected override void OnInitializeControls(EventArgs e)
        {
            base.OnInitializeControls(e);

            if (!IsPostBack)
            {
                introParagraphs.DataSource = ListConfig.IntroParagraphs;
                introParagraphs.DataBind();

                flowRepeaterList.ItemDataBound += new RepeaterItemEventHandler(flowRepeater_ItemDataBound);
                flowRepeaterList.DataSource = UIUtility.GetSortedList(_modelState.Flows);
                flowRepeaterList.DataBind();
            }
        }
        protected override void LoadModel(object savedModel)
        {
            _modelState = (ModelState)savedModel;
        }

        protected override object SaveModel()
        {
            return _modelState;
        }
        #endregion // Spring Biding Stuff
        public IScheduleService DataItemService
        {
            get { return _dataItemService; }
            set { _dataItemService = value; }
        }
        protected void flowRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            KeyValuePair<string, string> pair = (KeyValuePair<string, string>)e.Item.DataItem;
            Dictionary<string, SimpleListDisplayInfo> scheduledItemList;
            if (_modelState.ScheduledItems.TryGetValue(pair.Key, out scheduledItemList))
            {
                Repeater repeaterList = e.Item.FindControl("repeaterList") as Repeater;
                if (repeaterList != null)
                {
                    repeaterList.DataSource = UIUtility.GetSortedList(scheduledItemList);
                    repeaterList.ItemDataBound += new RepeaterItemEventHandler(repeater_ItemDataBound);
                    repeaterList.DataBind();
                }
            }
        }

        #endregion
    }
}
