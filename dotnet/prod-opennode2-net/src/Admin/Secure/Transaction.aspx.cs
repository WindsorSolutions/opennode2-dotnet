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
using System.Threading;
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
using Windsor.Commons.NodeDomain;

namespace Windsor.Node2008.Admin.Secure
{

    public partial class Transaction : SecurePage
    {
        class DataModel
        {
            public NodeTransaction _dataItem;
            public int _postbackCount;
            public string _activityDetails;
        }
        #region Members

        private DataModel _pageData;
        private ITransactionService _dataService;
        private IAccountService _accountService;

        #endregion

        public Transaction()
        {
        }

        #region Spring Biding Stuff

        protected override void InitializeModel()
        {
            base.InitializeModel();

            if (_dataService == null)
            {
                throw new ArgumentNullException("TransactionService");
            }

            _pageData = new DataModel();

            AssignNodeTransaction();

            if ((_pageData._dataItem != null) && (_pageData._dataItem.Flow != null))
            {
                if (!VisitHelper.GetVisit().IsFlowPermittedByName(_pageData._dataItem.Flow.FlowName, FlowRoleType.View))
                {
                    ResponseRedirect("~/Secure/Dashboard.aspx");
                }
            }

            string back = Request["back"];

            if (!string.IsNullOrEmpty(back))
            {
                BackBtnTableRow.Visible = string.Equals(back, true.ToString(), StringComparison.InvariantCultureIgnoreCase);
            }
            else
            {
                BackBtnTableRow.Visible = false;
            }
        }

        protected string DocumentDisplayName(object dataItem)
        {
            Document document = dataItem as Document;
            if (document == null) return string.Empty;
            return string.Format("{0} ({1})", document.DocumentName,
                                 FileUtils.GetDisplayFileSize(document.ContentByteSize));
        }
        protected override void DoDownloadResponse(byte[] content, string fileName, CommonContentType contentType)
        {
            base.DoDownloadResponse(content, DocumentNameFromDisplayName(fileName), contentType);
        }
        protected string DocumentNameFromDisplayName(string displayName)
        {
            int index = displayName.LastIndexOf('(');
            if (index > 1)
            {
                return displayName.Substring(0, index - 1);
            }
            return displayName;
        }
        protected override void OnInitializeControls(EventArgs e)
        {
            if (Response.IsRequestBeingRedirected)
            {
                return;
            }

            base.OnInitializeControls(e);

            _pageData._postbackCount--;

            listTranDocs.ItemCommand += new RepeaterCommandEventHandler(DownloadDocument);

            if (!IsPostBack)
            {
                introParagraphs.DataSource = IntroParagraphs;
                introParagraphs.DataBind();

                if (Tran != null)
                {
                    listTranDocs.DataSource = Tran.Documents;
                    listTranDocs.DataBind();
                }
                UpdateTransactionNetworkTable();

                activityDetailsRow.Visible = false;
            }
            BackButton.Attributes.Remove("onclick");
            BackButton.Attributes.Add("onclick", string.Format("(history.go({0}))", _pageData._postbackCount.ToString()));
        }
        protected bool AssignNodeTransaction()
        {
            string id = Request["id"];
            if (!string.IsNullOrEmpty(id))
            {
                try
                {
                    _pageData._dataItem = _dataService.Get(id, VisitHelper.GetVisit());
                    if (_pageData._dataItem == null)
                    {
                        throw new ArgumentException(string.Format("Could not find transaction with id: {0}.", id));
                    }
                    ScheduledItemExecuteInfo scheduledItemExecuteInfo = _dataService.GetTransactionLastExecuteInfo(id);
                    string text = null;
                    if ((scheduledItemExecuteInfo != null) &&
                        !string.IsNullOrEmpty(scheduledItemExecuteInfo.Summary))
                    {
                        text = StringUtils.BreakUpText(scheduledItemExecuteInfo.Summary, 80, "<br/>");
                        text = text.Replace("\r\n", "<br/><br/>");
                    }
                    _pageData._activityDetails = text;
                    return true;
                }
                catch (Exception ex)
                {
                    SetDivPageError(ex);
                }
            }
            else
            {
                SetDivPageErrorFormat("Transaction Id is required");
            }
            return false;
        }
        protected void RefreshTransactionNetworkTable()
        {
            if (_pageData._dataItem != null)
            {
                try
                {
                    if (AssignNodeTransaction())
                    {
                        UpdateTransactionNetworkTable();
                    }
                }
                catch (Exception ex)
                {
                    SetDivPageError(ex);
                    return;
                }
            }
        }
        protected void UpdateTransactionNetworkTable()
        {
            transactionNetworkIdTable.Visible = false;
            if (_pageData._dataItem != null)
            {
                if (!string.IsNullOrEmpty(_pageData._dataItem.NetworkId) &&
                    !_pageData._dataItem.NetworkId.Equals(_pageData._dataItem.Id))
                {
                    if (!string.IsNullOrEmpty(_pageData._dataItem.NetworkEndpointUrl))
                    {
                        transactionNetworkIdTable.Visible = true;
                        networkUrl.Text = _pageData._dataItem.NetworkEndpointUrl;
                        networkVersion.Text = EnumUtils.ToDescription(_pageData._dataItem.NetworkEndpointVersion);
                        networkStatus.Text = EnumUtils.ToDescription(_pageData._dataItem.NetworkEndpointStatus);
                    }
                }
            }
        }
        public override string UniqueDataModelKey
        {
            get { return Request["id"]; }
        }
        protected override void LoadModel(object savedModel)
        {
            _pageData = (DataModel)savedModel;
        }

        protected override object SaveModel()
        {
            return _pageData;
        }
        protected override void InitializeDataBindings()
        {
            BindingManager.AddBinding("transactionIdCtrl.Text", "Tran.Id", BindingDirection.TargetToSource);
            BindingManager.AddBinding("transactionNetworkIdCtrl.Text", "Tran.NetworkId", BindingDirection.TargetToSource);
            BindingManager.AddBinding("transactionModifiedByCtrl.Text", "GetUsernameById(Tran.ModifiedById)", BindingDirection.TargetToSource);
            BindingManager.AddBinding("transactionModifiedOnCtrl.Text", "Tran.ModifiedOn", BindingDirection.TargetToSource);
            BindingManager.AddBinding("transactionFlowNameCtrl.Text", "Tran.Flow.FlowName", BindingDirection.TargetToSource);
            BindingManager.AddBinding("transactionCurrentStatusCtrl.Text", "Tran.Status.Status", BindingDirection.TargetToSource);
            BindingManager.AddBinding("transactionStatusImage.ImageUrl", "GetTransactionStatusImageUrl()", BindingDirection.TargetToSource);
            BindingManager.AddBinding("transactionStatusDetails.Text", "GetTransactionStatusDetails()", BindingDirection.TargetToSource);
            BindingManager.AddBinding("transactionActivityDetails.Text", "GetActivityDetails()", BindingDirection.TargetToSource);
            BindingManager.AddBinding("transactionServiceTypeCtrl.Text", "Tran.NodeMethod", BindingDirection.TargetToSource);
            BindingManager.AddBinding("transactionOperationNameCtrl.Text", "Tran.Operation", BindingDirection.TargetToSource);
        }

        protected string GetTransactionStatusImageUrl()
        {
            ScheduleExecuteStatus status = ScheduleExecuteStatus.None;
            if ((Tran != null) || (Tran.Status != null))
            {
                switch (Tran.Status.Status)
                {
                    case CommonTransactionStatusCode.Completed: status = ScheduleExecuteStatus.CompletedSuccess; break;
                    case CommonTransactionStatusCode.Failed: status = ScheduleExecuteStatus.CompletedFailure; break;
                    case CommonTransactionStatusCode.Pending:
                    case CommonTransactionStatusCode.Processing: status = ScheduleExecuteStatus.Running; break;
                }
            }
            return Schedule.GetImageUrlForExecuteStatus(status);
        }
        protected string GetTransactionStatusDetails()
        {
            if ((Tran == null) || (Tran.Status == null) ||
                 (Tran.Status.Description == null))
            {
                return string.Empty;
            }
            return Tran.Status.Description;
        }
        protected override void BindFormData()
        {
            try
            {
                if (Tran != null)
                {
                    if (!this.IsPostBack)
                    {
                        base.BindFormData();
                    }
                }
            }
            catch (Exception ex)
            {
                SetDivPageError(ex);
            }
        }
        #endregion

        /// <summary>
        /// Sends the document content to the uer
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void DownloadDocument(object source, CommandEventArgs e)
        {
            try
            {
                LinkButton button = source as LinkButton;
                if (button != null)
                {
                    byte[] content = _dataService.DownloadContent(Tran.Id, e.CommandName, VisitHelper.GetVisit());
                    DoDownloadResponse(content, button.Text, EnumUtils.ParseEnum<CommonContentType>(e.CommandArgument.ToString()));
                }
            }
            catch (ThreadAbortException)
            {
                throw;
            }
            catch (Exception ex)
            {
                SetDivPageError(ex);
            }
        }
        protected string GetUsernameById(string id)
        {
            return _accountService.GetUsernameById(id);
        }
        protected void showActivityDetailsButton_Click(object sender, EventArgs e)
        {
            Thread.Sleep(3000);

            LinkButton control = sender as LinkButton;
            if (control != null)
            {
                if (activityDetailsRow.Visible)
                {
                    activityDetailsRow.Visible = false;
                    control.Text = "Show Activity Details >>";
                }
                else
                {
                    activityDetailsRow.Visible = true;
                    control.Text = "Hide Activity Details <<";
                }
            }
        }
        protected void OnDownloadNetworkDocuments(object sender, EventArgs e)
        {
            try
            {
                byte[] content = _dataService.DownloadNetworkDocumentsAsZipFile(Tran.Id, VisitHelper.GetVisit());
                if (content == null)
                {
                    SetDivPageErrorFormat("No documents found.");
                    return;
                }
                DoDownloadResponse(content, Tran.NetworkId + ".zip", CommonContentType.ZIP);
            }
            catch (Exception ex)
            {
                SetDivPageError(ex);
            }
        }
        protected void OnRefreshNetworkStatus(object sender, EventArgs e)
        {
            try
            {
                DataService.RefreshNetworkStatus(Tran.Id, VisitHelper.GetVisit());
                RefreshTransactionNetworkTable();
            }
            catch (Exception ex)
            {
                SetDivPageError(ex);
            }
        }
        public ITransactionService DataService
        {
            get { return _dataService; }
            set { _dataService = value; }
        }
        public IAccountService AccountService
        {
            get { return _accountService; }
            set { _accountService = value; }
        }
        public NodeTransaction Tran
        {
            get { return _pageData._dataItem; }
            set { _pageData._dataItem = value; }
        }
        public string GetActivityDetails()
        {
            if ((_pageData != null) && (_pageData._activityDetails != null))
            {
                return _pageData._activityDetails;
            }
            else
            {
                return string.Empty;
            }
        }
        private DataModel PageData
        {
            get { return _pageData; }
            set { _pageData = value; }
        }

        protected void linkDoc_Init(object sender, EventArgs e)
        {
            //PostBackTrigger trigger = new PostBackTrigger();
            //trigger.ControlID = ((Control)sender).ClientID;
            //UpdatePanel.Triggers.Add(trigger);
        }
    }
}