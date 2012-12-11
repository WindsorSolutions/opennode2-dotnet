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
using Windsor.Node2008.WNOSConnector.Server;
using Windsor.Node2008.WNOSProviders;

namespace Windsor.Node2008.Admin.Secure
{
    public partial class Schedule : SecureListPage
    {
        public class ModelState
        {
            public Dictionary<string, string> Flows
            {
                get;
                set;
            }
            public Dictionary<string, Dictionary<string, ScheduledItem>> FlowToScheduledItems
            {
                get;
                set;
            }
            public Dictionary<string, ScheduledItem> ScheduledItems
            {
                get;
                set;
            }
        }
        #region Members
        const string showInfoScriptName = "ShowInfoScript";
        private ModelState _modelState;
        #endregion

        protected void lastRunInfoButton_Click(object sender, EventArgs e)
        {
            LinkButton control = sender as LinkButton;
            if (control != null)
            {
                HtmlTableRow tableRow = control.Parent.FindControl("lastRunTextRow") as HtmlTableRow;
                ShowHideLastRunInfo(tableRow, null);
            }
        }
        protected void ShowHideLastRunInfo(HtmlTableRow lastRunTextRow, bool? doHide)
        {
            if (lastRunTextRow != null)
            {
                Label infoLabel = lastRunTextRow.FindControl("infoTextLabel") as Label;
                HiddenField activityIdField = lastRunTextRow.FindControl("activityIdField") as HiddenField;
                if (doHide == null)
                {
                    lastRunTextRow.Visible = !lastRunTextRow.Visible;
                }
                else
                {
                    lastRunTextRow.Visible = !doHide.Value;
                }
                string text = string.Empty;
                LinkButton control = lastRunTextRow.Parent.FindControl("lastRunInfoButton") as LinkButton;
                if (lastRunTextRow.Visible)
                {
                    control.Text = "Hide Last Run Info <<";
                    if ((infoLabel != null) && (activityIdField != null) &&
                        !string.IsNullOrEmpty(activityIdField.Value))
                    {
                        ScheduledItemExecuteInfo scheduledItemExecuteInfo =
                            DataItemService.GetScheduleLastExecuteInfo(activityIdField.Value);
                        if ((scheduledItemExecuteInfo != null) &&
                            !string.IsNullOrEmpty(scheduledItemExecuteInfo.Summary))
                        {
                            string details = StringUtils.BreakUpText(scheduledItemExecuteInfo.Summary, 80, "\r\n");
                            details = HttpUtility.HtmlEncode(details);
                            text = details.Replace("\r\n", "<br/><br/>");
                        }
                    }
                }
                else
                {
                    control.Text = "Show Last Run Info >>";
                }
                if (infoLabel != null)
                {
                    infoLabel.Text = text;
                }
            }
        }

        protected string ScheduleDisplayName(object dataItem)
        {
            ScheduledItem scheduledItem = ((KeyValuePair<string, ScheduledItem>)dataItem).Value;
            return scheduledItem.Name;
        }
        protected string ScheduleToolTipEditName(object dataItem)
        {
            ScheduledItem scheduledItem = ((KeyValuePair<string, ScheduledItem>)dataItem).Value;
            string tooltip = FlowEditPrefixTextById(scheduledItem.FlowId) + " '" +
                             ScheduleDisplayName(dataItem) + "'";
            return tooltip;
        }
        protected string ScheduleEditImageUrl(object dataItem)
        {
            ScheduledItem scheduledItem = ((KeyValuePair<string, ScheduledItem>)dataItem).Value;
            return PermissionsHelper.CanEditFlowById(scheduledItem.FlowId) ? "../Images/UI/application_form_edit.png" :
                                                                             "../Images/UI/application_form_magnify.png";
        }
        protected void repeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            ScheduleItemDataBound(e.Item);
        }
        protected void ScheduleItemDataBound(RepeaterItem item)
        {
            HtmlTableCell cell = item.FindControl("valueNameItem") as HtmlTableCell;
            if (cell != null)
            {
                cell.Style.Add(HtmlTextWriterStyle.FontWeight, "bold");
            }
            KeyValuePair<string, ScheduledItem> pair =
                (KeyValuePair<string, ScheduledItem>)item.DataItem;
            ScheduledItem scheduledItem = pair.Value;
            if (scheduledItem != null)
            {
                ScheduleItemDataBound(item, scheduledItem);
            }
        }
        protected void ScheduleItemDataBound(RepeaterItem item, ScheduledItem scheduledItem)
        {
            Image imageStatus = item.FindControl("executeStatusImage") as Image;
            ImageButton runNowButton = item.FindControl("runNowImageButton") as ImageButton;
            HtmlTableRow valueDescriptionRow = item.FindControl("valueDescriptionRow") as HtmlTableRow;
            HtmlTableCell valueDescriptionItem = item.FindControl("valueDescriptionItem") as HtmlTableCell;
            Image scheduleImage = item.FindControl("scheduleImage") as Image;
            HiddenField hiddenScheduleId = item.FindControl("hiddenScheduleId") as HiddenField;
            HtmlTableRow lastRunInfoRow = item.FindControl("lastRunInfoRow") as HtmlTableRow;
            DebugUtils.AssertDebuggerBreak(runNowButton != null);
            DebugUtils.AssertDebuggerBreak(valueDescriptionRow != null);
            DebugUtils.AssertDebuggerBreak(valueDescriptionItem != null);
            DebugUtils.AssertDebuggerBreak(lastRunInfoRow != null);
            if (scheduledItem.ExecuteStatus == ScheduleExecuteStatus.Running)
            {
                valueDescriptionRow.Visible = false;
                runNowButton.Visible = false;
                lastRunInfoRow.Visible = false;
                scheduleImage.ImageUrl = ((item.ItemIndex % 2) == 0) ?
                    "../Images/UI/ajax-loader2_even.gif" : "../Images/UI/ajax-loader2_odd.gif";
            }
            else
            {
                valueDescriptionRow.Visible = true;
                runNowButton.Visible = true;
                scheduleImage.ImageUrl = "../Images/UI/time.png";
                runNowButton.ToolTip = string.Format("Run '{0}' Now", scheduledItem.Name);
                runNowButton.CommandArgument = scheduledItem.Id;
                valueDescriptionItem.InnerText = scheduledItem.Description;
                if (!string.IsNullOrEmpty(scheduledItem.LastExecuteActivityId))
                {
                    imageStatus.ImageUrl = GetImageUrlForExecuteStatus(scheduledItem.ExecuteStatus);
                    imageStatus.ToolTip = "Status: " + EnumUtils.ToDescription(scheduledItem.ExecuteStatus);
                    lastRunInfoRow.Visible = true;
                    if (lastRunInfoRow != null)
                    {
                        ImageButton imageButton = item.FindControl("transactionImageButton") as ImageButton;
                        if (imageButton != null)
                        {
                            imageButton.ToolTip = "View Transaction Detail";
                            imageButton.CommandArgument = scheduledItem.LastExecuteActivityId;
                        }
                    }
                    HtmlTableRow lastRunTextRow = item.FindControl("lastRunTextRow") as HtmlTableRow;
                    if (lastRunTextRow != null)
                    {
                        Label infoLabel = item.FindControl("infoTextLabel") as Label;
                        HiddenField activityIdField = item.FindControl("activityIdField") as HiddenField;
                        if ((infoLabel != null) && (activityIdField != null))
                        {
                            activityIdField.Value = scheduledItem.LastExecuteActivityId;
                        }
                    }
                }
                else
                {
                    imageStatus.Visible = false;
                    lastRunInfoRow.Visible = false;
                }
            }
        }
        public static string GetImageUrlForExecuteStatus(ScheduleExecuteStatus type)
        {
            switch (type)
            {
                case ScheduleExecuteStatus.CompletedSuccess:
                    return "../Images/UI/accept.png";
                case ScheduleExecuteStatus.CompletedFailure:
                    return "../Images/UI/exclamation.png";
                case ScheduleExecuteStatus.Running:
                    return "../Images/UI/cog_go.png";
                default:
                    return "../Images/UI/time.png";
            }
        }
        public void OnViewTransactionDetailClick(object source, CommandEventArgs e)
        {
            if (e.CommandArgument != null)
            {
                string transactionId = DataItemService.GetTransactionIdFromActivityId(e.CommandArgument.ToString());
                if (!string.IsNullOrEmpty(transactionId))
                {
                    ResponseRedirect("../Secure/Transaction.aspx?" + Transaction.BACK_PAGE_PARAM + "=Schedule.aspx&id=" + transactionId);
                }
            }
        }
        public void OnRunNowClick(object source, CommandEventArgs e)
        {
            try
            {
                Control control = source as Control;
                if (control != null)
                {
                    HtmlTableRow tableRow = control.Parent.FindControl("lastRunTextRow") as HtmlTableRow;
                    ShowHideLastRunInfo(tableRow, true);
                }
                DataItemService.RunNow(e.CommandArgument.ToString(), VisitHelper.GetVisit());
                if (ScheduleProcessor != null)
                {
                    ScheduleProcessor.Wakeup();
                }
            }
            catch (Exception ex)
            {
                LOG.Error(ex.Message, ex);
                divPageError.Visible = true;
                divPageError.InnerText = ExceptionUtils.GetDeepExceptionMessage(ex);
            }
        }
        #region Properties

        #region Spring Biding Stuff

        protected override void InitializeModel()
        {
            base.InitializeModel();

            if (DataItemService == null)
            {
                throw new ArgumentNullException("DataItemService");
            }

            _modelState = new ModelState();

            IList<ScheduledItem> scheduledItems = DataItemService.GetSchedules(VisitHelper.GetVisit());
            if (!CollectionUtils.IsNullOrEmpty(scheduledItems))
            {
                IDictionary<string, string> flows = DataItemService.GetExchangeList(VisitHelper.GetVisit(), false);
                _modelState.FlowToScheduledItems = new Dictionary<string, Dictionary<string, ScheduledItem>>();
                _modelState.Flows = new Dictionary<string, string>();
                _modelState.ScheduledItems = new Dictionary<string, ScheduledItem>();
                foreach (ScheduledItem scheduledItem in scheduledItems)
                {
                    Dictionary<string, ScheduledItem> scheduledItemList;
                    if (!_modelState.FlowToScheduledItems.TryGetValue(scheduledItem.FlowId, out scheduledItemList))
                    {
                        scheduledItemList = new Dictionary<string, ScheduledItem>();
                        _modelState.FlowToScheduledItems.Add(scheduledItem.FlowId, scheduledItemList);
                    }
                    scheduledItemList.Add(scheduledItem.Id, scheduledItem);
                    _modelState.ScheduledItems.Add(scheduledItem.Id, scheduledItem);
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

                addScheduleBtn.Visible = CanEditAnyFlow();

                if ((RefreshFrequencyInSeconds <= 0) || CollectionUtils.IsNullOrEmpty(_modelState.ScheduledItems))
                {
                    PageTimer.Enabled = false;
                    PageTimer.Interval = int.MaxValue;
                }
                else
                {
                    PageTimer.Enabled = true;
                    PageTimer.Interval = RefreshFrequencyInSeconds * 1000;
                }
            }
        }
        protected void OnAddScheduleClick(object sender, EventArgs e)
        {
            ResponseRedirect("../Secure/ScheduleEdit.aspx");
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
        public int RefreshFrequencyInSeconds
        {
            get;
            set;
        }
        public IScheduleService DataItemService
        {
            get;
            set;
        }
        public INodeProcessor ScheduleProcessor
        {
            get;
            set;
        }
        protected void flowRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            KeyValuePair<string, string> pair = (KeyValuePair<string, string>)e.Item.DataItem;
            Dictionary<string, ScheduledItem> scheduledItemList;
            if (_modelState.FlowToScheduledItems.TryGetValue(pair.Key, out scheduledItemList))
            {
                Repeater repeaterList = e.Item.FindControl("repeaterList") as Repeater;
                if (repeaterList != null)
                {
                    repeaterList.DataSource = UIUtility.GetSortedList(scheduledItemList,
                        delegate(KeyValuePair<string, ScheduledItem> x, KeyValuePair<string, ScheduledItem> y)
                        {
                            return string.Compare(x.Value.Name, y.Value.Name);
                        });
                    repeaterList.ItemDataBound += new RepeaterItemEventHandler(repeater_ItemDataBound);
                    repeaterList.DataBind();
                }
            }
        }

        #endregion

        protected void PageTimer_Tick(object sender, EventArgs e)
        {
            UpdateStatusOfSchedules();
        }
        protected void UpdateStatusOfScheduledItemsInModel()
        {
            if (CollectionUtils.IsNullOrEmpty(_modelState.ScheduledItems))
            {
                return;
            }
            IList<ScheduledItemExecuteStatus> scheduleStatusList =
                DataItemService.GetScheduledItemExecuteStatus(VisitHelper.GetVisit());
            CollectionUtils.ForEach(scheduleStatusList, delegate(ScheduledItemExecuteStatus scheduledItemExecuteStatus)
            {
                ScheduledItem scheduledItem;
                if (_modelState.ScheduledItems.TryGetValue(scheduledItemExecuteStatus.Id, out scheduledItem))
                {
                    scheduledItem.ExecuteStatus = scheduledItemExecuteStatus.ExecuteStatus;
                    scheduledItem.LastExecuteActivityId = scheduledItemExecuteStatus.LastExecuteActivityId;
                    scheduledItem.LastExecutedOn = scheduledItemExecuteStatus.LastExecutedOn;
                    scheduledItem.NextRunOn = scheduledItemExecuteStatus.NextRunOn;
                }
            });
        }
        protected void UpdateStatusOfSchedules()
        {
            try
            {
                if (CollectionUtils.IsNullOrEmpty(_modelState.ScheduledItems))
                {
                    return;
                }
                UpdateStatusOfScheduledItemsInModel();

                Repeater flowRepeater = flowRepeaterList;
                foreach (RepeaterItem flowItemRepeater in flowRepeater.Items)
                {
                    Repeater scheduleRepeater = flowItemRepeater.FindControl("repeaterList") as Repeater;
                    if (scheduleRepeater != null)
                    {
                        foreach (RepeaterItem scheduleItemRepeater in scheduleRepeater.Items)
                        {
                            HiddenField hiddenScheduleId = scheduleItemRepeater.FindControl("hiddenScheduleId") as HiddenField;
                            if (hiddenScheduleId != null)
                            {
                                ScheduledItem scheduledItem;
                                if (_modelState.ScheduledItems.TryGetValue(hiddenScheduleId.Value, out scheduledItem))
                                {
                                    ScheduleItemDataBound(scheduleItemRepeater, scheduledItem);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
