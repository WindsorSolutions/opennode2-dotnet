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
using Wintellect.PowerCollections;

namespace Windsor.Node2008.Admin.Secure
{
    public partial class ActivitySearchCriteria : SecurePage
    {
        #region Members

        private const int DEFAULT_RESULTS_PER_PAGE = 10;
        private class DataModel
        {
            private ActivitySearchParams _searchParams;

            public ActivitySearchParams SearchParams
            {
                get { return _searchParams; }
                set { _searchParams = value; }
            }

            private IDictionary<string, string> _userIdToNameMap;

            public IDictionary<string, string> UserIdToNameMap
            {
                get { return _userIdToNameMap; }
                set { _userIdToNameMap = value; }
            }

            private SortableCollection<Activity> _searchResults;

            public SortableCollection<Activity> SearchResults
            {
                get { return _searchResults; }
                set { _searchResults = value; }
            }

            private int _resultsPerPage = DEFAULT_RESULTS_PER_PAGE;

            public int ResultsPerPage
            {
                get { return _resultsPerPage; }
                set { _resultsPerPage = value; }
            }

            private string _sortProperty = "ModifiedOn";

            public string SortProperty
            {
                get { return _sortProperty; }
                set { _sortProperty = value; }
            }

            private bool _sortAscending = false;

            public bool SortAscending
            {
                get { return _sortAscending; }
                set { _sortAscending = value; }
            }

            private OrderedSet<string> _moreInfoIds = new OrderedSet<string>();

            public OrderedSet<string> MoreInfoIds
            {
                get { return _moreInfoIds; }
                set { _moreInfoIds = value; }
            }

            private int _pageIndex;

            public int PageIndex
            {
                get { return _pageIndex; }
                set { _pageIndex = value; }
            }
            private bool _rebindResults;

            public bool RebindResults
            {
                get { return _rebindResults; }
                set { _rebindResults = value; }
            }

        }
        private DataModel _dataModel;
        private IActivityService _dataService;

        #endregion

        #region Spring Biding Stuff

        protected override void InitializeModel()
        {
            base.InitializeModel();

            if (_dataService == null)
            {
                throw new ArgumentNullException("_dataItemService");
            }
            _dataModel = new DataModel();
            _dataModel.SearchParams = new ActivitySearchParams();
            _dataModel.UserIdToNameMap = DataService.GetUserIdToNameMap();
        }
        protected override void OnInitializeControls(EventArgs e)
        {
            base.OnInitializeControls(e);
  
            if (!this.IsPostBack)
            {
                NodeVisit nodeVisit = VisitHelper.GetVisit();

                SecureMasterPage.SetupPage(SideTabs, SelectedTabIndex);

                introParagraphs.DataSource = IntroParagraphs;
                introParagraphs.DataBind();

                exchangeDropDownList.DataSource = DataService.GetAllFlowNames(nodeVisit);
                exchangeDropDownList.DataBind();
                exchangeDropDownList.Items.Insert(0, NOT_SELECTED_TEXT);
                exchangeDropDownList.SelectedIndex = 0;

                operationDropDownList.DataSource = DataService.GetAllOperationNames(nodeVisit);
                operationDropDownList.DataBind();
                operationDropDownList.Items.Insert(0, NOT_SELECTED_TEXT);
                operationDropDownList.SelectedIndex = 0;

                List<string> nodeMethodTypes = new List<string>(EnumUtils.GetAllDescriptions<NodeMethod>());
                nodeMethodTypes.Sort();
                nodeMethodTypeDropdown.DataSource = nodeMethodTypes;
                nodeMethodTypeDropdown.DataBind();
                nodeMethodTypeDropdown.Items.Insert(0, NOT_SELECTED_TEXT);
                nodeMethodTypeDropdown.SelectedIndex = 0;

                List<string> activityTypes = new List<string>(EnumUtils.GetAllDescriptions<ActivityType>());
                activityTypes.Sort();
                activityTypeCtrl.DataSource = activityTypes;
                activityTypeCtrl.DataBind();
                activityTypeCtrl.Items.Insert(0, NOT_SELECTED_TEXT);
                activityTypeCtrl.SelectedIndex = 0;

                fromIpCtrl.DataSource = DataService.GetDistinctFromIpList();
                fromIpCtrl.DataBind();
                fromIpCtrl.Items.Insert(0, NOT_SELECTED_TEXT);
                fromIpCtrl.SelectedIndex = 0;

                List<string> userNames = new List<string>(_dataModel.UserIdToNameMap.Values);
                userNames.Sort();
                byUserCtrl.DataSource = userNames;
                byUserCtrl.DataBind();
                byUserCtrl.Items.Insert(0, NOT_SELECTED_TEXT);
                byUserCtrl.SelectedIndex = 0;

                resultsPerPage.Text = _dataModel.ResultsPerPage.ToString();

                if (!nodeVisit.IsAdmin)
                {
                    DeleteAllButton.Visible = false;
                }
            }

            _dataModel.RebindResults = false;
            if (!CollectionUtils.IsNullOrEmpty(_dataModel.SearchResults))
            {
                BindSearchResults();
            }

            //Page.Form.DefaultButton = searchBtn.ID;
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
            BindingManager.AddBinding("fromDateImageButton.Text", "DataItem.CreatedFrom",
                                      BindingDirection.SourceToTarget);
            BindingManager.AddBinding("toDateImageButton.Text", "DataItem.CreatedTo",
                                      BindingDirection.SourceToTarget);
            BindingManager.AddBinding("ExchangeBinder", "DataItem.FlowNames",
                                      BindingDirection.SourceToTarget);
            BindingManager.AddBinding("OperationBinder", "DataItem.OperationName",
                                      BindingDirection.SourceToTarget);
            BindingManager.AddBinding("ActivityTypeBinder", "DataItem.Type",
                                      BindingDirection.SourceToTarget);
            BindingManager.AddBinding("NodeMethodBinder", "DataItem.NodeMethod",
                                      BindingDirection.SourceToTarget);
            BindingManager.AddBinding("transactionIdCtrl.Text", "DataItem.TransactionId",
                                      BindingDirection.SourceToTarget);
            BindingManager.AddBinding("fromIpCtrl.SelectedValue", "DataItem.IP",
                                      BindingDirection.SourceToTarget);
            BindingManager.AddBinding("byUserCtrl.SelectedValue", "DataItem.CreatedByUsername",
                                      BindingDirection.SourceToTarget);
            BindingManager.AddBinding("contentCtrl.Text", "DataItem.DetailContains",
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
                DeleteAllButton.Visible = !CollectionUtils.IsNullOrEmpty(_dataModel.SearchResults);
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
        protected void ServerValidateDate(Object source, ServerValidateEventArgs e)
        {
            DateTime result;
            e.IsValid = DateTime.TryParse(e.Value, out result);
            if (e.IsValid)
            {
                e.IsValid = (result >= ActivitySearchParams.MIN_DATETIME) && 
                            (result <= ActivitySearchParams.MAX_DATETIME);
            }
        }
        protected void UpdateCurrentPageLabel()
        {
            if ( resultsGridView.FooterRow != null ) {
                string text = string.Format("Page {0} of {1}", (_dataModel.PageIndex + 1).ToString(),
                                            this.TotalPages);
                SetLabelsText("currentPageLabel", text);
            }
        }
        protected void SetControlsVisible(string id, bool isVisible)
        {
            IList<Control> controls = AspNetUtils.FindDeepControls<Control>(resultsGridView, id);
            if (controls != null)
            {
                foreach (Control control in controls)
                {
                    control.Visible = isVisible;
                }
            }
        }
        protected void SetLabelsText(string id, string text)
        {
            IList<Label> controls = AspNetUtils.FindDeepControls<Label>(resultsGridView, id);
            if (controls != null)
            {
                foreach (Label control in controls)
                {
                    control.Text = text;
                }
            }
        }
        protected void UpdatePageNavigationButtons()
        {
            if (resultsGridView.FooterRow != null)
            {
                int totalPages = this.TotalPages;
                SetControlsVisible("firstPageButton", _dataModel.PageIndex > 0);
                SetControlsVisible("previousPageButton", _dataModel.PageIndex > 0);
                SetControlsVisible("nextPageButton", _dataModel.PageIndex < (totalPages - 1));
                SetControlsVisible("lastPageButton", _dataModel.PageIndex < (totalPages - 1));
            }
        }
        protected void BindSearchResults()
        {
            _dataModel.RebindResults = false;
            resultsGridView.DataSource = _dataModel.SearchResults;
            resultsGridView.PageIndex = _dataModel.PageIndex;
            resultsGridView.PageSize = _dataModel.ResultsPerPage;
            resultsGridView.DataBind();
            UpdateCurrentPageLabel();
            UpdatePageNavigationButtons();
        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            if ( _dataModel.RebindResults )
            {
                BindSearchResults();
            }
            if (!CollectionUtils.IsNullOrEmpty(_dataModel.SearchResults))
            {
                int startIndex = _dataModel.ResultsPerPage * _dataModel.PageIndex;
                int numRowsAdded = 0;
                Unit width = resultsGridView.Width;
                int rowOffset = 2;
                if (resultsGridView.PagerSettings.Position == PagerPosition.TopAndBottom)
                {
                    rowOffset++;
                }
                for (int i = 0; i < resultsGridView.Rows.Count; ++i)
                {
                    int activityIndex = startIndex + i;
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
                        GridViewRow mainRow = resultsGridView.Rows[i];
                        Table table = resultsGridView.Rows[0].Parent as Table;
                        GridViewRow row =
                            new GridViewRow(-1, -1, DataControlRowType.DataRow, DataControlRowState.Normal);

                        row.BackColor = ((i & 1) == 0) ? 
                            resultsGridView.RowStyle.BackColor : resultsGridView.AlternatingRowStyle.BackColor;
                        table.Rows.AddAt(i + numRowsAdded + rowOffset, row);

                        TableCell cell = new TableCell();
                        cell.Attributes["ColSpan"] = resultsGridView.Columns.Count.ToString();
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

        protected ActivityType ActivityTypeBinder
        {
            get
            {
                string type = activityTypeCtrl.SelectedValue;
                return (type == NOT_SELECTED_TEXT) ? ActivityType.None :
                    EnumUtils.FromDescription<ActivityType>(type);
            }
            set
            {
                if (value == ActivityType.None)
                {
                    activityTypeCtrl.SelectedValue = NOT_SELECTED_TEXT;
                }
                else
                {
                    activityTypeCtrl.SelectedValue = EnumUtils.ToDescription<ActivityType>(value);
                }
            }

        }
        protected NodeMethod NodeMethodBinder
        {
            get
            {
                string type = nodeMethodTypeDropdown.SelectedValue;
                return (type == NOT_SELECTED_TEXT) ? NodeMethod.None :
                    EnumUtils.FromDescription<NodeMethod>(type);
            }
            set
            {
                if (value == NodeMethod.None)
                {
                    nodeMethodTypeDropdown.SelectedValue = NOT_SELECTED_TEXT;
                }
                else
                {
                    nodeMethodTypeDropdown.SelectedValue = EnumUtils.ToDescription<NodeMethod>(value);
                }
            }

        }
        protected IList<string> ExchangeBinder
        {
            get
            {
                string name = exchangeDropDownList.SelectedValue;
                return (name == NOT_SELECTED_TEXT) ? null : new string[] { name };
            }
            set
            {
                if (CollectionUtils.IsNullOrEmpty(value))
                {
                    exchangeDropDownList.SelectedValue = NOT_SELECTED_TEXT;
                }
                else
                {
                    exchangeDropDownList.SelectedValue = value[0];
                }
            }

        }
        protected string OperationBinder
        {
            get
            {
                string name = operationDropDownList.SelectedValue;
                return (name == NOT_SELECTED_TEXT) ? null : name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    operationDropDownList.SelectedValue = NOT_SELECTED_TEXT;
                }
                else
                {
                    operationDropDownList.SelectedValue = value;
                }
            }

        }
        protected DateTime ValidateDateRange(DateTime checkDate, DateTime setDateIfInvalid)
        {
            if ((checkDate < ActivitySearchParams.MIN_DATETIME) || (checkDate > ActivitySearchParams.MAX_DATETIME))
            {
                return setDateIfInvalid;
            }
            else
            {
                return checkDate;
            }
        }
        protected void FillSearchParams()
        {
            DataItem.CreatedFrom = ValidateDateRange(DataItem.CreatedFrom, ActivitySearchParams.MIN_DATETIME);
            DataItem.CreatedTo = ValidateDateRange(DataItem.CreatedTo, ActivitySearchParams.MAX_DATETIME);
            if (DataItem.CreatedTo != ActivitySearchParams.MAX_DATETIME)
            {
                DataItem.CreatedTo = DataItem.CreatedTo + TimeSpan.FromMilliseconds((60 * 60 * 24 * 1000) - 1);
            }
            if (DataItem.IP == NOT_SELECTED_TEXT) DataItem.IP = null;
            if (DataItem.CreatedByUsername == NOT_SELECTED_TEXT) DataItem.CreatedByUsername = null;
            if (!string.IsNullOrEmpty(DataItem.TransactionId))
            {
                DataItem.TransactionId = DataItem.TransactionId.Trim();
            }
        }
        protected void DoSearch()
        {
            if (divPageError.Visible || !Page.IsValid)
            {
                // Error on page, get out of here
                return;
            }
            try
            {
                FillSearchParams();
                _dataModel.SearchResults =
                    _dataService.Search(DataItem, VisitHelper.GetVisit(), false);
                if (CollectionUtils.IsNullOrEmpty(_dataModel.SearchResults))
                {
                    noItemsDiv.Visible = true;
                }
                else
                {
                    noItemsDiv.Visible = false;
                    foreach (Activity activity in _dataModel.SearchResults)
                    {
                        activity.ModifiedById = GetUsernameById(activity.ModifiedById);
                    }
                    _dataModel.SearchResults.Sort(_dataModel.SortProperty, _dataModel.SortAscending);
                }
                _dataModel.PageIndex = 0;
                _dataModel.RebindResults = true;
            }
            catch (Exception ex)
            {
                LOG.Error(ex.Message, ex);
                divPageError.Visible = true;
                divPageError.InnerText = ExceptionUtils.GetDeepExceptionMessage(ex);
            }
        }
        protected void OnClickSearch(object sender, EventArgs e)
        {
            DoSearch();
        }

        protected void OnDeleteAllActivities(object sender, EventArgs e)
        {
            if (divPageError.Visible || !Page.IsValid)
            {
                // Error on page, get out of here
                return;
            }
            try
            {
                FillSearchParams();
                _dataService.DeleteActivities(DataItem, VisitHelper.GetVisit());
                DoSearch();
            }
            catch (Exception ex)
            {
                LOG.Error(ex.Message, ex);
                divPageError.Visible = true;
                divPageError.InnerText = ExceptionUtils.GetDeepExceptionMessage(ex);
            }
        }
        protected void OnClickReset(object sender, EventArgs e)
        {
            try
            {
                exchangeDropDownList.SelectedValue = NOT_SELECTED_TEXT;
                noItemsDiv.Visible = false;
                fromDateImageButton.Text = string.Empty;
                toDateImageButton.Text = string.Empty;
                fromDateCalendarExtender.SelectedDate = null;
                toDateCalendarExtender.SelectedDate = null;
                activityTypeCtrl.SelectedValue = NOT_SELECTED_TEXT;
                nodeMethodTypeDropdown.SelectedValue = NOT_SELECTED_TEXT;
                transactionIdCtrl.Text = string.Empty;
                fromIpCtrl.SelectedValue = NOT_SELECTED_TEXT;
                byUserCtrl.SelectedValue = NOT_SELECTED_TEXT;
                contentCtrl.Text = string.Empty;
                _dataModel.SearchResults = null;
                _dataModel.PageIndex = 0;
                _dataModel.RebindResults = true;
            }
            catch (Exception ex)
            {
                LOG.Error(ex.Message, ex);
                divPageError.Visible = true;
                divPageError.InnerText = ExceptionUtils.GetDeepExceptionMessage(ex);
            }
        }
        protected void OnMoreInfoClick(object sender, EventArgs e)
        {
            Control control = sender as Control;
            if ( control == null ) return;
            DataControlFieldCell dataControlFieldCell = control.Parent as DataControlFieldCell;
            if (dataControlFieldCell == null) return;
            GridViewRow gridViewRow = dataControlFieldCell.Parent as GridViewRow;
            if (gridViewRow == null) return;
            int itemIndex = (_dataModel.PageIndex * _dataModel.ResultsPerPage) + gridViewRow.RowIndex;
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

        #region Properties

        public ActivitySearchParams DataItem
        {
            get { return _dataModel.SearchParams; }
            set { _dataModel.SearchParams = value; }
        }
        public IActivityService DataService
        {
            get { return _dataService; }
            set { _dataService = value; }
        }
        #endregion

        protected void resultsGridView_RowDataBound(object sender, GridViewRowEventArgs e)
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
            else if (e.Row.RowType == DataControlRowType.Header)
            {
                AppendSortOrderImageToGridHeader(e.Row, _dataModel.SortProperty, _dataModel.SortAscending);
            }
        }
        public void OnViewTransactionDetailClick(object source, CommandEventArgs e)
        {
            ResponseRedirect("../Secure/Transaction.aspx?back=true&id=" + e.CommandArgument);
        }
        public void OnViewTaskDetailClick(object source, CommandEventArgs e)
        {
            ResponseRedirect("../Secure/TaskDetails.aspx?back=true&id=" + e.CommandArgument);
        }
        protected string GetUsernameById(string id)
        {
            string username;
            return _dataModel.UserIdToNameMap.TryGetValue(id, out username) ?
                username : string.Empty;
        }

        protected void resultsGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            _dataModel.PageIndex = e.NewPageIndex;
            _dataModel.RebindResults = true;
        }

        protected void resultsPerPage_TextChanged(object sender, EventArgs e)
        {
            int resultsPerPageValue;
            if (int.TryParse(resultsPerPage.Text, out resultsPerPageValue) &&
                (resultsPerPageValue > 0))
            {
                if (_dataModel.ResultsPerPage != resultsPerPageValue)
                {
                    int currentTopRow = _dataModel.ResultsPerPage * _dataModel.PageIndex;
                    int newPageIndex = currentTopRow / resultsPerPageValue;
                    _dataModel.ResultsPerPage = resultsPerPageValue;
                    _dataModel.PageIndex = newPageIndex;
                    _dataModel.RebindResults = true;
                }
            }
        }

        protected void resultsGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (!CollectionUtils.IsNullOrEmpty(_dataModel.SearchResults))
            {
                int currentTopRow = _dataModel.ResultsPerPage * _dataModel.PageIndex;
                Activity currentTopActivity = _dataModel.SearchResults[currentTopRow];
                if (e.SortExpression == _dataModel.SortProperty)
                {
                    _dataModel.SortAscending = !_dataModel.SortAscending;
                }
                else
                {
                    _dataModel.SortProperty = e.SortExpression;
                    _dataModel.SortAscending = false;
                }
                _dataModel.SearchResults.Sort(_dataModel.SortProperty,
                                              _dataModel.SortAscending);
                int newTopRow = _dataModel.SearchResults.IndexOf(currentTopActivity);
                _dataModel.RebindResults = true;
                /* Don't repage for now:
                if (newTopRow >= 0)
                {
                    int newPageIndex = newTopRow / _dataModel.ResultsPerPage;
                    _dataModel.PageIndex = newPageIndex;
                }
                else
                {
                    _dataModel.PageIndex = 0;
                }
                */
            }
        }
        protected int TotalPages
        {
            get { 
                if ( _dataModel.SearchResults != null ) {
                    return ((_dataModel.SearchResults.Count + _dataModel.ResultsPerPage - 1) / _dataModel.ResultsPerPage);
                } else {
                    return 0;
                }
            }
        }

        protected void OnFirstPageClick(object sender, EventArgs e)
        {
            if (_dataModel.PageIndex != 0)
            {
                _dataModel.PageIndex = 0;
                _dataModel.RebindResults = true;
            }
        }
        protected void OnPreviousPageClick(object sender, EventArgs e)
        {
            if (_dataModel.PageIndex > 0 )
            {
                _dataModel.PageIndex = _dataModel.PageIndex - 1;
                _dataModel.RebindResults = true;
            }
        }
        protected void OnNextPageClick(object sender, EventArgs e)
        {
            if (_dataModel.PageIndex < (TotalPages - 1))
            {
                _dataModel.PageIndex = _dataModel.PageIndex + 1;
                _dataModel.RebindResults = true;
            }
        }
        protected void OnLastPageClick(object sender, EventArgs e)
        {
            if (_dataModel.PageIndex < (TotalPages - 1))
            {
                _dataModel.PageIndex = TotalPages - 1;
                _dataModel.RebindResults = true;
            }
        }
        protected bool IsTaskMethod(object method)
        {
            return (method.ToString() == NodeMethod.Task.ToString());
        }
    }
}
