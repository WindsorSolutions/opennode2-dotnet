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
using Windsor.Node2008.WNOSProviders;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.Admin.Controls;
using Windsor.Node2008.WNOSUtility;
using Spring.DataBinding;
using Windsor.Commons.Core;

namespace Windsor.Node2008.Admin.Secure
{
    public partial class SecurityManageUserRequests : SecurePage
    {
        #region Members

        public class ModelState
        {
            public ModelState()
            {
            }
            public SortableCollection<AccountAuthorizationRequest> Requests;
            public SortedList<string, DataFlow> Flows;
            public string SortProperty = "RequestGeneratedOn";
            public bool SortAscending = true;
        }
        private IAccountAuthorizationRequestService _accountAuthorizationRequestManagerService;
        private IFlowService _flowService;
        private ModelState _modelState;

        #endregion

        #region Spring Biding Stuff

        protected override void InitializeModel()
        {
            base.InitializeModel();

            if (_accountAuthorizationRequestManagerService == null)
            {
                throw new ArgumentNullException("_accountAuthorizationRequestManagerService");
            }
            if (_flowService == null)
            {
                throw new ArgumentNullException("_flowService");
            }

            _modelState = new ModelState();

            IList<DataFlow> flows = _flowService.GetProtectedFlows(VisitHelper.GetVisit(), false);
            _modelState.Flows = new SortedList<string, DataFlow>();
            if (!CollectionUtils.IsNullOrEmpty(flows))
            {
                foreach (DataFlow flow in flows)
                {
                    _modelState.Flows.Add(flow.FlowName.ToUpper(), flow);
                }
            }

            LoadRequests();
        }

        protected void LoadRequests()
        {
            AdminVisit visit = VisitHelper.GetVisit();
            IList<AccountAuthorizationRequest> requests =
                _accountAuthorizationRequestManagerService.GetOpenUserRequests(visit);

            if (!CollectionUtils.IsNullOrEmpty(requests))
            {
                bool hasPreviousRequests = !CollectionUtils.IsNullOrEmpty(_modelState.Requests);
                foreach (AccountAuthorizationRequest request in requests)
                {
                    AccountAuthorizationRequest previousRequest = null;
                    if (hasPreviousRequests)
                    {
                        foreach (AccountAuthorizationRequest pRequest in _modelState.Requests)
                        {
                            if (pRequest.Id == request.Id)
                            {
                                previousRequest = pRequest;
                                break;
                            }
                        }
                    }
                    if (previousRequest != null)
                    {
                        request.Response = previousRequest.Response;
                        request.RequestedFlows = previousRequest.RequestedFlows;
                    }
                    else
                    {
                        request.Response = new AccountAuthorizationResponse();
                        if (CollectionUtils.IsNullOrEmpty(request.RequestedFlows))
                        {
                            if (!CollectionUtils.IsNullOrEmpty(_modelState.Flows))
                            {
                                List<AccountAuthorizationRequestFlow> requestedFlows =
                                    new List<AccountAuthorizationRequestFlow>(_modelState.Flows.Count);
                                foreach (DataFlow dataFlow in _modelState.Flows.Values)
                                {
                                    requestedFlows.Add(new AccountAuthorizationRequestFlow(dataFlow.FlowName));
                                }
                                request.RequestedFlows = requestedFlows;
                            }
                        }
                        // Pre check Access Granted to flows that the user already has access to
                        IList<string> existingProtectedFlows =
                            _accountAuthorizationRequestManagerService.GetProtectedFlowNamesForUser(visit, request.NaasAccount);
                        if (!CollectionUtils.IsNullOrEmpty(existingProtectedFlows))
                        {
                            foreach(string protectedFlowName in existingProtectedFlows)
                            {
                                foreach (AccountAuthorizationRequestFlow requestFlow in request.RequestedFlows)
                                {
                                    if (string.Equals(requestFlow.FlowName, protectedFlowName, StringComparison.InvariantCultureIgnoreCase))
                                    {
                                        requestFlow.AccessGranted = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            _modelState.Requests =
                new SortableCollection<AccountAuthorizationRequest>(requests);
            _modelState.Requests.Sort(_modelState.SortProperty, _modelState.SortAscending);
        }
        protected override void OnInitializeControls(EventArgs e)
        {
            base.OnInitializeControls(e);

            if (!this.IsPostBack)
            {
                SecureMasterPage.SetupPage(SideTabs, SelectedTabIndex);
                introParagraphs.DataSource = IntroParagraphs;
                introParagraphs.DataBind();

                userRepeaterList.DataSource = _modelState.Requests;
                userRepeaterList.DataBind();
            }
        }

        protected void requestsGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (!CollectionUtils.IsNullOrEmpty(_modelState.Requests))
            {
                if (e.SortExpression == _modelState.SortProperty)
                {
                    _modelState.SortAscending = !_modelState.SortAscending;
                }
                else
                {
                    _modelState.SortProperty = e.SortExpression;
                    _modelState.SortAscending = false;
                }
                _modelState.Requests.Sort(_modelState.SortProperty,
                                          _modelState.SortAscending);
                userRepeaterList.DataSource = _modelState.Requests;
                userRepeaterList.DataBind();
            }
        }
        protected string UserDisplayName(object dataItem)
        {
            AccountAuthorizationRequest request = (AccountAuthorizationRequest)dataItem;
            return string.Format("{0} ({1})", request.FullName, request.NaasAccount);
        }
        protected string RequestDateDisplayName(object dataItem)
        {
            AccountAuthorizationRequest request = (AccountAuthorizationRequest)dataItem;
            return string.Format("Requested: {0}", request.RequestGeneratedOn.ToShortDateString());
        }
        protected ICollection<DataFlow> FlowList(object dataItem)
        {
            AccountAuthorizationRequest request = (AccountAuthorizationRequest)dataItem;
            if (CollectionUtils.IsNullOrEmpty(request.RequestedFlows))
            {
                return _modelState.Flows.Values;
            }
            else
            {
                SortedList<string, DataFlow> list = new SortedList<string, DataFlow>();
                foreach (AccountAuthorizationRequestFlow requestedFlow in request.RequestedFlows)
                {
                    DataFlow dataFlow;
                    if (_modelState.Flows.TryGetValue(requestedFlow.FlowName.ToUpper(), out dataFlow))
                    {
                        list.Add(requestedFlow.FlowName, dataFlow);
                    }
                }
                return list.Values;
            }
        }
        protected AccountAuthorizationRequest GetRequest(CommandEventArgs e, out int index)
        {
            string id = e.CommandArgument.ToString();
            index = 0;
            if (!CollectionUtils.IsNullOrEmpty(_modelState.Requests))
            {
                foreach (AccountAuthorizationRequest request in _modelState.Requests)
                {
                    if (request.Id == id)
                    {
                        return request;
                    }
                    ++index;
                }
            }
            throw new ArgumentException(string.Format("The authorization request with id \"{0}\" was not found", id));
        }
        protected void DoUpdateRequest(CommandEventArgs e, bool doAccept)
        {
            HtmlGenericControl itemPageErrorDiv = null;
            try
            {
                UpdateRequestsToViewState();
                int index;
                AccountAuthorizationRequest request = GetRequest(e, out index);
                itemPageErrorDiv = (HtmlGenericControl)userRepeaterList.Items[index].FindControl("itemDivPageError");

                if (doAccept)
                {
                    bool atleastOneFlowChecked = false;
                    if (!CollectionUtils.IsNullOrEmpty(request.RequestedFlows))
                    {
                        foreach (AccountAuthorizationRequestFlow flow in request.RequestedFlows)
                        {
                            if (flow.AccessGranted)
                            {
                                atleastOneFlowChecked = true;
                                break;
                            }
                        }
                    }
                    if (!atleastOneFlowChecked)
                    {
                        SetDivPageError(itemPageErrorDiv, "Please allow the user access to at least one requested flow.");
                        return;
                    }
                    _accountAuthorizationRequestManagerService.AcceptRequest(request, VisitHelper.GetVisit());
                }
                else
                {
                    _accountAuthorizationRequestManagerService.RejectRequest(request, VisitHelper.GetVisit());
                }
                _modelState.Requests.RemoveAt(index);
                userRepeaterList.DataSource = _modelState.Requests;
                userRepeaterList.DataBind();
            }
            catch (Exception ex)
            {
                SetDivPageError(itemPageErrorDiv, ex);
            }
        }
        protected void OnAcceptClick(object source, CommandEventArgs e)
        {
            DoUpdateRequest(e, true);
        }
        protected void OnDenyClick(object source, CommandEventArgs e)
        {
            DoUpdateRequest(e, false);
        }
        protected void UpdateRequestsToViewState()
        {
            for (int i = 0; i < userRepeaterList.Items.Count; ++i)
            {
                RepeaterItem repeaterItem = userRepeaterList.Items[i];
                AccountAuthorizationRequest request = _modelState.Requests[i];
                TextBox commentsBox = (TextBox)repeaterItem.FindControl("commentsTextBox");
                request.Response.AuthorizationComments = commentsBox.Text;

                Repeater flowsRepeater = (Repeater)repeaterItem.FindControl("flowRepeaterList");
                for (int j = 0; j < flowsRepeater.Items.Count; ++j)
                {
                    RepeaterItem flowRepeaterItem = flowsRepeater.Items[j];
                    CheckBox allowCheckBox = (CheckBox)flowRepeaterItem.FindControl("allowCheckBox");
                    Label allowCheckTag = (Label)flowRepeaterItem.FindControl("allowCheckTag");
                    string flowName = allowCheckTag.Text;
                    foreach (AccountAuthorizationRequestFlow requestFlow in request.RequestedFlows)
                    {
                        if (string.Equals(flowName, requestFlow.FlowName, StringComparison.InvariantCultureIgnoreCase))
                        {
                            requestFlow.AccessGranted = allowCheckBox.Checked;
                            break;
                        }
                    }
                }
            }
        }
        protected override void ClearDivPageError()
        {
            base.ClearDivPageError();
            foreach(RepeaterItem repeaterItem in userRepeaterList.Items)
            {
                HtmlGenericControl itemPageErrorDiv = (HtmlGenericControl)repeaterItem.FindControl("itemDivPageError");
                itemPageErrorDiv.Visible = false;
                itemPageErrorDiv.InnerText = string.Empty;
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

        protected string UserDisplayTitle(object dataItem)
        {
            AccountAuthorizationRequest request = (AccountAuthorizationRequest)dataItem;
            return string.Format("{0} ({1})", request.FullName, request.NaasAccount);
        }
        protected string FlowDisplayName(object dataItem)
        {
            DataFlow dataFlow = (DataFlow)dataItem;
            if (!string.IsNullOrEmpty(dataFlow.Description))
            {
                return string.Format("{0} ({1})", dataFlow.FlowName, dataFlow.Description);
            }
            else
            {
                return dataFlow.FlowName;
            }
        }

        #endregion

        #region Properties

        public IAccountAuthorizationRequestService AccountAuthorizationRequestService
        {
            get { return _accountAuthorizationRequestManagerService; }
            set { _accountAuthorizationRequestManagerService = value; }
        }
        public IFlowService FlowService
        {
            get { return _flowService; }
            set { _flowService = value; }
        }

        public ModelState DataModel
        {
            get { return _modelState; }
            set { _modelState = value; }
        }

        #endregion

        protected void userRepeaterList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            AccountAuthorizationRequest request = (AccountAuthorizationRequest)e.Item.DataItem;
            Repeater flowsRepeater = (Repeater)e.Item.FindControl("flowRepeaterList");
            ICollection<DataFlow> flows = FlowList(e.Item.DataItem);
            if (CollectionUtils.IsNullOrEmpty(flows))
            {
                flowsRepeater.Visible = false;
                Control noFlowsControl = e.Item.FindControl("noFlowsLabel");
                noFlowsControl.Visible = true;
            }
            else
            {
                flowsRepeater.DataSource = flows;
                flowsRepeater.DataBind();
                int i = 0;
                foreach (DataFlow dataFlow in flows)
                {
                    RepeaterItem flowRepeaterItem = flowsRepeater.Items[i];
                    foreach (AccountAuthorizationRequestFlow requestedFlow in request.RequestedFlows)
                    {
                        if (string.Equals(requestedFlow.FlowName, dataFlow.FlowName, StringComparison.InvariantCultureIgnoreCase))
                        {
                            CheckBox allowCheckBox = (CheckBox)flowRepeaterItem.FindControl("allowCheckBox");
                            allowCheckBox.Checked = requestedFlow.AccessGranted;
                            break;
                        }
                    }
                    Label allowCheckTag = (Label)flowRepeaterItem.FindControl("allowCheckTag");
                    allowCheckTag.Text = dataFlow.FlowName;
                    ++i;
                }
            }
            TextBox commentsBox = (TextBox)e.Item.FindControl("commentsTextBox");
            commentsBox.Text = request.Response.AuthorizationComments ?? string.Empty;
        }
    }
}
