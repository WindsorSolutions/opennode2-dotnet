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
using System.Collections.Generic;
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

    public partial class TaskDetails : SecurePage
    {
        class DataModel
        {
            public NodeTransaction _nodeTransaction;
            public string _createdByName;
            public int _postbackCount;
        }
        #region Members

        private DataModel _pageData;
        private ITransactionService _transactionService;
        private IAccountService _accountService;

        #endregion

        public TaskDetails()
        {

        }

        #region Spring Biding Stuff

        protected override void InitializeModel()
        {
            base.InitializeModel();

            if (_transactionService == null)
            {
                throw new ArgumentNullException("_transactionService");
            }
            if (_accountService == null)
            {
                throw new ArgumentNullException("_accountService");
            }

            string id = Request["id"];
            string back = Request["back"];
            if (!string.IsNullOrEmpty(id))
            {
                try
                {
                    NodeTransaction nodeTransaction = _transactionService.Get(id, VisitHelper.GetVisit());
                    if (nodeTransaction == null)
                    {
                        throw new ArgumentException(string.Format("Could not find transaction with id: {0}.", id));
                    }
                    _pageData = new DataModel();
                    _pageData._nodeTransaction = nodeTransaction;
                    _pageData._createdByName = _accountService.GetUsernameById(nodeTransaction.ModifiedById);
                }
                catch (Exception ex)
                {
                    _pageData = null;
                    SetDivPageError(ex);
                }
            }
            else
            {
                SetDivPageError("Transaction Id is required");
            }
            if (!string.IsNullOrEmpty(back))
            {
                BackBtnTableRow.Visible = string.Equals(back, true.ToString(), StringComparison.InvariantCultureIgnoreCase);
            }
            else
            {
                BackBtnTableRow.Visible = false;
            }
        }

        protected override void OnInitializeControls(EventArgs e)
        {
            base.OnInitializeControls(e);

            if (!IsPostBack)
            {
                introParagraphs.DataSource = IntroParagraphs;
                introParagraphs.DataBind();
            }

            // http://localhost:1222/Secure/TaskDetails.aspx?id=_8b2e64a2-8915-4152-af14-c1cbbc72b897
            // ted@win.com;ted2@win.com;ted3@win.com
            if (_pageData != null)
            {
                _pageData._postbackCount--;
                try
                {
                    IList<StatusActivityEntry> details =
                        _transactionService.GetRealtimeTransactionDetails(_pageData._nodeTransaction.Id, VisitHelper.GetVisit());
                    listDetails.DataSource = details;
                    listDetails.DataBind();
                    TransactionStatus transactionStatus = _transactionService.GetTransactionStatus(_pageData._nodeTransaction.Id);
                    _pageData._nodeTransaction.Status = transactionStatus;

                    transactionCurrentStatusCtrl.Text = GetTransactionStatusName();
                    transactionStatusImage.ImageUrl = GetTransactionStatusImageUrl();
                    transactionStatusDetails.Text = GetTransactionStatusDetails();

                    if ((transactionStatus.Status != CommonTransactionStatusCode.Completed) &&
                         (transactionStatus.Status != CommonTransactionStatusCode.Failed))
                    {
                        timer.Enabled = true;
                    }
                    else
                    {
                        timer.Enabled = false;
                    }
                }
                catch (Exception)
                {
                }
                BackButton.Attributes.Remove("onclick");
                BackButton.Attributes.Add("onclick", string.Format("(history.go({0}))", _pageData._postbackCount.ToString()));
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
            BindingManager.AddBinding("taskNameCtrl.Text", "GetTaskName()", BindingDirection.TargetToSource);
            BindingManager.AddBinding("transactionIdCtrl.Text", "GetTransactionId()", BindingDirection.TargetToSource);
            BindingManager.AddBinding("transactionCreatedByCtrl.Text", "GetUsername()", BindingDirection.TargetToSource);
        }

        #endregion

        protected string GetTransactionId()
        {
            return (_pageData == null) ? string.Empty : _pageData._nodeTransaction.Id;
        }
        protected string GetUsername()
        {
            return (_pageData == null) ? string.Empty : _pageData._createdByName;
        }
        protected string GetTaskName()
        {
            return (_pageData == null) ? string.Empty :
                string.Format("{0} - {1}", _pageData._nodeTransaction.Flow.FlowName, _pageData._nodeTransaction.Operation);
        }
        protected string GetTransactionStatusName()
        {
            return (_pageData == null) ? string.Empty : EnumUtils.ToDescription(_pageData._nodeTransaction.Status.Status);
        }
        protected string GetTransactionStatusDetails()
        {
            if ( (_pageData == null) || (_pageData._nodeTransaction.Status == null) ||
                 (_pageData._nodeTransaction.Status.Description == null) ) {
                return string.Empty;
            }
            return _pageData._nodeTransaction.Status.Description;
        }
        //http://localhost:1222/Secure/TaskDetails.aspx?id=_cf170665-4bab-4cbb-af04-4f97e12ddb5c
        //ted@win.comp;ted2@win.com;ted3@win.com
        protected string GetTransactionStatusImageUrl()
        {
            if ( (_pageData == null) || (_pageData._nodeTransaction.Status == null) )
            {
                return "../Images/flag_white.gif";
            }
            switch (_pageData._nodeTransaction.Status.Status)
            {
                case CommonTransactionStatusCode.Completed: return "../Images/flag_green.gif";
                case CommonTransactionStatusCode.Failed: return "../Images/flag_red.gif";
                case CommonTransactionStatusCode.Pending:
                case CommonTransactionStatusCode.Processing: return "../Images/ajax-loader2.gif";
                default: return "../Images/flag_white.gif";
            }
        }
        protected string GetActivityStatusImageUrl(object statusType)
        {
            StatusActivityType status = (StatusActivityType) statusType;
            switch (status)
            {
                case StatusActivityType.Success: return "../Images/check.png";
                case StatusActivityType.Error: return "../Images/delete.png";
                default: return "../Images/information.png";
            }
        }
        public ITransactionService DataService
        {
            get { return _transactionService; }
            set { _transactionService = value; }
        }
        public IAccountService AccountService
        {
            get { return _accountService; }
            set { _accountService = value; }
        }
    }
}