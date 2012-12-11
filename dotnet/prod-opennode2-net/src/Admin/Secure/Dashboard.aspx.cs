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
using Windsor.Node2008.Admin.Code;
using Windsor.Node2008.WNOSProviders;
using Windsor.Commons.Core;
using Wintellect.PowerCollections;

namespace Windsor.Node2008.Admin.Secure
{
    public partial class Dashboard : SecurePage
    {

        #region Members

        private ChartConfig _chartConfig;
        private string _rssFeedUrl;
        private int _recentTransactionDisplayCount;
        private IActivityService _dataService;
        private DataModel _dataModel;
        private bool _provideUsageStats = true;
        private ISettingsProvider _settingsProvider;

        private class DataModel
        {
            public IList<Activity> SearchResults
            {
                get;
                set;
            }
            public OrderedSet<string> MoreInfoIds
            {
                get;
                set;
            }
        }
        #endregion

        #region Spring Biding Stuff

        protected override void InitializeModel()
        {
            base.InitializeModel();

            if (_dataService == null)
            {
                throw new ArgumentNullException("_dataService");
            }
            if (_settingsProvider == null)
            {
                throw new ArgumentNullException("_settingsProvider");
            }
            _dataModel = new DataModel();
            _dataModel.MoreInfoIds = new OrderedSet<string>();
            _dataModel.SearchResults =
                _dataService.GetRecentActivities(_recentTransactionDisplayCount, true, VisitHelper.GetVisit());
        }
        protected override void OnInitializeControls(EventArgs e)
        {
            base.OnInitializeControls(e);

            if (!this.IsPostBack)
            {
                try
                {
                    ChartTop.Display(_chartConfig);
                }
                catch (Exception ex)
                {
                    LOG.Error("Failed to load ChartTop.Display()", ex);
                }
                try
                {
                    NewsSideBar.Display(_rssFeedUrl + "?q=" + GetUsageStatsParamString());
                }
                catch (Exception ex)
                {
                    LOG.Error("Failed to load NewsSideBar.Display()", ex);
                }
            }
            if (!CollectionUtils.IsNullOrEmpty(_dataModel.SearchResults))
            {
                BindSearchResults();
            }
        }
        protected void BindSearchResults()
        {
            recentTransactionsGridView.DataSource = _dataModel.SearchResults;
            recentTransactionsGridView.DataBind();
        }

        protected string GetUsageStatsParamString()
        {
            if (_provideUsageStats)
            {
                NodeUsageStats stats = new NodeUsageStats();
                stats.NodeVersion = Global.GetVersionString();
                stats.OrgId = _settingsProvider.NodeId;
                stats.OrgName = _settingsProvider.NodeOrganizationName;
                string encryptedString = stats.GetEncryptedString();
                //NodeUsageStats stats2 = NodeUsageStats.DecryptFromString(encryptedString);
                encryptedString = HttpUtility.UrlEncode(encryptedString);
                return encryptedString;
            }
            return string.Empty;
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
            catch (Exception)
            {
            }
        }
        protected override void UnbindFormData()
        {
            try
            {
                if (this.IsValid)
                {
                    base.UnbindFormData();
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion // Spring Biding Stuff

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }
        protected void recentTransactionsGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Activity activity = (Activity)e.Row.DataItem;
                TableCell typeCell = e.Row.Cells[0];
                Image image = e.Row.FindControl("activityTypeImage") as Image;
                if (image != null)
                {
                    image.ImageUrl = UIUtility.GetImageUrlForActivityType(activity);
                    image.ToolTip = UIUtility.GetActivityTypeDescription(activity);
                }
            }
        }
        public void OnViewTransactionDetailClick(object source, CommandEventArgs e)
        {
            ResponseRedirect("../Secure/Transaction.aspx?" + Transaction.BACK_PAGE_PARAM + "=Dashboard.aspx&id=" + e.CommandArgument);
        }
        public void OnViewTaskDetailClick(object source, CommandEventArgs e)
        {
            ResponseRedirect("../Secure/TaskDetails.aspx?" + Transaction.BACK_PAGE_PARAM + "=Dashboard.aspx&id=" + e.CommandArgument);
        }
        protected bool IsTaskMethod(object method)
        {
            return (method.ToString() == NodeMethod.Task.ToString());
        }
        protected void OnMoreInfoClick(object sender, EventArgs e)
        {
            Control control = sender as Control;
            if (control == null)
                return;
            DataControlFieldCell dataControlFieldCell = control.Parent as DataControlFieldCell;
            if (dataControlFieldCell == null)
                return;
            GridViewRow gridViewRow = dataControlFieldCell.Parent as GridViewRow;
            if (gridViewRow == null)
                return;
            int itemIndex = gridViewRow.RowIndex;
            string id = _dataModel.SearchResults[itemIndex].Id;
            ImageButton button = sender as ImageButton;
            if (_dataModel.MoreInfoIds.Contains(id))
            {
                _dataModel.MoreInfoIds.Remove(id);
                button.ImageUrl = "../Images/UI/control-double-270-small.png";
                button.ToolTip = "Show Activity Detail";
            }
            else
            {
                _dataModel.MoreInfoIds.Add(id);
                button.ImageUrl = "../Images/UI/control-double-090-small.png";
                button.ToolTip = "Hide Activity Detail";
            }
        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            if (!CollectionUtils.IsNullOrEmpty(_dataModel.SearchResults))
            {
                int numRowsAdded = 0;
                Unit width = recentTransactionsGridView.Width;
                int rowOffset = 2;
                if (recentTransactionsGridView.PagerSettings.Position == PagerPosition.TopAndBottom)
                {
                    rowOffset++;
                }
                for (int i = 0; i < recentTransactionsGridView.Rows.Count; ++i)
                {
                    int activityIndex = i;
                    Activity activity = _dataModel.SearchResults[activityIndex];
                    if (_dataModel.MoreInfoIds.Contains(activity.Id))
                    {
                        if (activity.Entries == null)
                        {
                            try
                            {
                                activity = _dataService.GetActivityEntries(activity, VisitHelper.GetVisit());
                                if (activity.Entries != null)
                                {
                                    foreach (ActivityEntry entry in activity.Entries)
                                    {
                                        entry.Message = StringUtils.BreakUpText(entry.Message, 100, Environment.NewLine);
                                    }
                                }
                                _dataModel.SearchResults[activityIndex] = activity;
                            }
                            catch (Exception)
                            {
                            }
                        }
                        GridViewRow mainRow = recentTransactionsGridView.Rows[i];
                        Table table = recentTransactionsGridView.Rows[0].Parent as Table;
                        GridViewRow row =
                            new GridViewRow(-1, -1, DataControlRowType.DataRow, DataControlRowState.Normal);

                        row.BackColor = ((i & 1) == 0) ?
                            recentTransactionsGridView.RowStyle.BackColor : recentTransactionsGridView.AlternatingRowStyle.BackColor;
                        table.Rows.AddAt(i + numRowsAdded + rowOffset, row);

                        TableCell cell = new TableCell();
                        cell.Attributes["ColSpan"] = recentTransactionsGridView.Columns.Count.ToString();
                        ActivityDetailView detailView = (ActivityDetailView)LoadControl("ActivityDetailView.ascx");
                        cell.Controls.Add(detailView);
                        cell.Wrap = true;
                        detailView.ActivityDetailGridView.DataSource = activity.Entries;
                        detailView.ActivityDetailGridView.DataBind();
                        detailView.ActivityDetailGridView.Width = width;

                        row.Cells.Add(cell);

                        row.ID = activity.Id;
                        ++numRowsAdded;
                    }
                }
            }
        }
        #region Properties

        public string RssFeedUrl
        {
            set
            {
                _rssFeedUrl = value;
            }
        }

        public ChartConfig ChartConfig
        {
            set
            {
                _chartConfig = value;
            }
        }

        public IActivityService DataService
        {
            get
            {
                return _dataService;
            }
            set
            {
                _dataService = value;
            }
        }
        public int RecentTransactionDisplayCount
        {
            get
            {
                return _recentTransactionDisplayCount;
            }
            set
            {
                _recentTransactionDisplayCount = value;
            }
        }
        public bool ProvideUsageStats
        {
            get
            {
                return _provideUsageStats;
            }
            set
            {
                _provideUsageStats = value;
            }
        }
        public ISettingsProvider SettingsProvider
        {
            get
            {
                return _settingsProvider;
            }
            set
            {
                _settingsProvider = value;
            }
        }
        #endregion
    }
}
