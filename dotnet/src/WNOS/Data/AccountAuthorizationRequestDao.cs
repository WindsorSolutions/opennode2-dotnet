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
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.Common;
using System.Reflection;
using System.Diagnostics;

using Spring.Data.Generic;
using Spring.Data.Common;


using Common.Logging;

using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSUtility;
using Windsor.Node2008.WNOSProviders;
using Windsor.Commons.Core;
using Windsor.Node2008.WNOSConnector.Logic;

using Windsor.HERE.CentralServer.Message;

namespace Windsor.Node2008.WNOS.Data
{
    public class AccountAuthorizationRequestDao : BaseDao, IAccountAuthorizationRequestDao
    {
        public const string TABLE_NAME = "NAccountAuthRequest";
        public const string FLOW_TABLE_NAME = "NAccountAuthRequestFlow";
        private ISerializationHelper _serializationHelper;
        private ITransactionDao _transactionDao;
        private IFlowDao _flowDao;
        private IDocumentManager _documentManager;

        #region Init

        new public void Init()
        {
            base.Init();

            FieldNotInitializedException.ThrowIfNull(this, ref _serializationHelper);
            FieldNotInitializedException.ThrowIfNull(this, ref _transactionDao);
            FieldNotInitializedException.ThrowIfNull(this, ref _documentManager);
            FieldNotInitializedException.ThrowIfNull(this, ref _flowDao);
        }

        #endregion

        #region Mappers

        private const string MAP_AUTH_REQUEST_COLUMNS =
                                       "Id;TransactionId;RequestGeneratedOn;RequestType;NAASAccount;FullName;OrganizationAffiliation;" +
                                       "TelephoneNumber;EmailAddress;AffiliatedNodeId;AffiliatedCounty;PurposeDescription;" +
                                       "RequestedNodeIds;AuthorizationAccountId;AuthorizationComments;AuthorizationGeneratedOn;DidCreateInNaas";
        private AccountAuthorizationRequest MapAccountAuthorizationRequest(IDataReader reader)
        {
            AccountAuthorizationRequest request = new AccountAuthorizationRequest();
            int index = 0;
            request.Id = reader.GetString(index++);
            request.TransactionId = reader.GetString(index++);
            request.RequestGeneratedOn = reader.GetDateTime(index++);
            request.RequestType = reader.GetString(index++);
            request.NaasAccount = reader.GetString(index++);
            request.FullName = reader.GetString(index++);
            request.OrganizationAffiliation = reader.GetString(index++);
            request.TelephoneNumber = reader.GetString(index++);
            request.EmailAddress = reader.GetString(index++);
            request.AffiliatedNodeId = reader.GetString(index++);
            request.AffiliatedCounty = reader.GetString(index++);
            request.PurposeDescription = reader.GetString(index++);
            request.RequestedNodeIds = reader.GetString(index++).Split(',');
            if (!reader.IsDBNull(index))
            {
                AccountAuthorizationResponse response = new AccountAuthorizationResponse();
                response.AuthorizationAccountId = reader.GetString(index++);
                response.AuthorizationComments = reader.GetString(index++);
                response.AuthorizationGeneratedOn = reader.GetDateTime(index++);
                response.DidCreateInNaas = DbUtils.ToBool(reader.GetString(index++));
                request.Response = response;
            }
            return request;
        }
        private const string MAP_AUTH_REQUEST_FLOW_COLUMNS = "Id;FlowName;AccessGranted";
        private AccountAuthorizationRequestFlow MapAccountAuthorizationRequestFlow(IDataReader reader)
        {
            AccountAuthorizationRequestFlow requestFlow = new AccountAuthorizationRequestFlow();
            int index = 0;
            requestFlow.Id = reader.GetString(index++);
            requestFlow.FlowName = reader.GetString(index++);
            requestFlow.AccessGranted = DbUtils.ToBool(reader.GetString(index++));
            return requestFlow;
        }
        private void PostMapAccountAuthorizationRequest(AccountAuthorizationRequest request)
        {
            request.RequestedFlows = GetRequestFlows(request.Id);
        }
        private void PostMapAccountAuthorizationRequests(IEnumerable<AccountAuthorizationRequest> requests)
        {
            if (requests != null)
            {
                foreach (AccountAuthorizationRequest request in requests)
                {
                    PostMapAccountAuthorizationRequest(request);
                }
            }
        }
        public IList<AccountAuthorizationRequestFlow> GetRequestFlows(string requestId)
        {
            List<AccountAuthorizationRequestFlow> flows = null;
            DoSimpleQueryWithRowCallbackDelegate(
                FLOW_TABLE_NAME, "AccountAuthRequestId", requestId, "FlowName",
                MAP_AUTH_REQUEST_FLOW_COLUMNS,
                delegate(IDataReader reader)
                {
                    if (flows == null)
                    {
                        flows = new List<AccountAuthorizationRequestFlow>();
                    }
                    flows.Add(MapAccountAuthorizationRequestFlow(reader));
                });
            return flows;
        }
        #endregion

        #region Methods

        public bool HasOpenRequestForUser(string naasUsername)
        {
            bool found = false;
            DoSimpleQueryWithRowCallbackDelegate(
                TABLE_NAME, "NAASAccount;AuthorizationAccountId IS NULL", naasUsername, null,
                "NAASAccount",
                delegate(IDataReader reader)
                {
                    found = true;
                });
            return found;
        }

        public void Save(AccountAuthorizationRequest item)
        {

            if (item == null)
            {
                throw new ArgumentException("Null item");
            }
            string id = null;
            TransactionTemplate.Execute(delegate
            {
                string authorizationAccountId = null, authorizationComments = null;
                DateTime authorizationGeneratedOn = DbUtils.DB_MIN_DATE;
                string didCreateInNaas = null;
                if ( item.Response != null ) {
                    authorizationAccountId = item.Response.AuthorizationAccountId;
                    authorizationComments = item.Response.AuthorizationComments;
                    authorizationGeneratedOn = item.Response.AuthorizationGeneratedOn;
                    didCreateInNaas = DbUtils.ToDbBool(item.Response.DidCreateInNaas);
                }
                if ( string.IsNullOrEmpty(item.Id) )
                {
                    id = IdProvider.Get();
                    DoInsert(TABLE_NAME, MAP_AUTH_REQUEST_COLUMNS, id, item.TransactionId, item.RequestGeneratedOn, item.RequestType,
                             item.NaasAccount, item.FullName, item.OrganizationAffiliation, item.TelephoneNumber,
                             item.EmailAddress, item.AffiliatedNodeId, item.AffiliatedCounty, item.PurposeDescription,
                             StringUtils.Join(",", item.RequestedNodeIds), authorizationAccountId,
                             authorizationComments, authorizationGeneratedOn, didCreateInNaas);
                }
                else {
                    id = item.Id;
                    DoSimpleUpdateOne(TABLE_NAME, "Id", id, MAP_AUTH_REQUEST_COLUMNS, 
                             id, item.TransactionId, item.RequestGeneratedOn, item.RequestType,
                             item.NaasAccount, item.FullName, item.OrganizationAffiliation, item.TelephoneNumber,
                             item.EmailAddress, item.AffiliatedNodeId, item.AffiliatedCounty, item.PurposeDescription,
                             StringUtils.Join(",", item.RequestedNodeIds), authorizationAccountId,
                             authorizationComments, authorizationGeneratedOn, didCreateInNaas);
                }

                // Update flow requests
                DeleteAllFlowsForRequest(id);
                SaveRequestedFlows(id, item.RequestedFlows);
                return null;
            });
            if (string.IsNullOrEmpty(item.Id))
            {
                item.Id = id;
            }
        }

        public IList<AccountAuthorizationRequest> GetOpenUserRequests()
        {
            List<AccountAuthorizationRequest> userRequests = new List<AccountAuthorizationRequest>();

            string columnNames = GiveTableAliasToColumnNames(MAP_AUTH_REQUEST_COLUMNS, "a");

            DoSimpleQueryWithRowCallbackDelegate(
                string.Format("{0} a;{1} t", TABLE_NAME, Windsor.Node2008.WNOS.Data.TransactionDao.TABLE_NAME),
                "t.Status;a.TransactionId=t.Id", CommonTransactionStatusCode.Processed.ToString(), null,
                columnNames,
                delegate(IDataReader reader)
                {
                    userRequests.Add(MapAccountAuthorizationRequest(reader));
                });
            PostMapAccountAuthorizationRequests(userRequests);
            return userRequests;
        }

        public IList<string> GetProtectedFlowNamesForUser(string username)
        {
            return _flowDao.GetProtectedFlowNamesForUser(username);
    }

        protected AuthorizationResponse GetAuthorizationResponse(AccountAuthorizationRequest request, bool doAccept)
        {
            AuthorizationResponse response = new AuthorizationResponse();
            response.GeneratedOn = request.Response.AuthorizationGeneratedOn;
            response.NaasUsername = request.NaasAccount;
            response.AccountCreatedInNaas = request.Response.DidCreateInNaas;
            response.Comments = request.Response.AuthorizationComments;
            if (!CollectionUtils.IsNullOrEmpty(request.RequestedFlows))
            {
                response.AuthorizationList = new AuthorizationItem[request.RequestedFlows.Count];
                for (int i = 0; i < request.RequestedFlows.Count; ++i)
                {
                    AccountAuthorizationRequestFlow requestFlow = request.RequestedFlows[i];
                    AuthorizationItem authorizationItem = new AuthorizationItem();
                    authorizationItem.AccessGranted = doAccept ? requestFlow.AccessGranted : false;
                    authorizationItem.RequestedDataSourceName = requestFlow.FlowName;
                    response.AuthorizationList[i] = authorizationItem;
                }
            }
            else
            {
                response.AuthorizationList = new AuthorizationItem[0];
            }
            return response;
        }
        public void DoRequestUpdate(AccountAuthorizationRequest request, string adminName, bool doAccept)
        {
            request.Response.AuthorizationGeneratedOn = DateTime.Now;
            AuthorizationResponse response = GetAuthorizationResponse(request, doAccept);
            byte[] authorizationResponsContent = _serializationHelper.Serialize(response);
            Document document = new Document(response.GetType().Name + ".xml", CommonContentType.XML, authorizationResponsContent);

            string statusDetail = string.Format("{0} {1} authorization request from user \"{2} ({3})\"",
                                                adminName, doAccept ? "accepted" : "rejected", 
                                                request.FullName, request.NaasAccount);

            TransactionTemplate.Execute(delegate
            {
                Save(request);
                _documentManager.AddDocument(request.TransactionId, CommonTransactionStatusCode.Completed,
                                             statusDetail, document);
                _transactionDao.SetTransactionStatus(request.TransactionId, CommonTransactionStatusCode.Completed,
                                                     statusDetail, true);
                return null;
            });
        }
        private void DeleteAllFlowsForRequest(string requestId)
        {
            DoSimpleDelete(FLOW_TABLE_NAME, "AccountAuthRequestId", new object[] { requestId });
        }
        private void SaveRequestedFlows(string requestId, IList<AccountAuthorizationRequestFlow> requestedFlows)
        {
            if (CollectionUtils.IsNullOrEmpty(requestedFlows))
            {
                return;
            }
            object[] insertValues = new object[4];
            DoBulkInsert(FLOW_TABLE_NAME, "Id;AccountAuthRequestId;FlowName;AccessGranted",
                 delegate(int currentInsertIndex)
                 {
                     if (currentInsertIndex < requestedFlows.Count)
                     {
                         AccountAuthorizationRequestFlow flow = requestedFlows[currentInsertIndex];
                         if (string.IsNullOrEmpty(flow.Id))
                         {
                             flow.Id = IdProvider.Get();
                         }
                         insertValues[0] = flow.Id;
                         insertValues[1] = requestId;
                         insertValues[2] = flow.FlowName;
                         insertValues[3] = DbUtils.ToDbBool(flow.AccessGranted);
                         return insertValues;
                     }
                     else
                     {
                         return null;
                     }
                 });
        }
        #endregion

        #region Properties
        public ISerializationHelper SerializationHelper
        {
            get { return _serializationHelper; }
            set { _serializationHelper = value; }
        }
        public ITransactionDao TransactionDao
        {
            get { return _transactionDao; }
            set { _transactionDao = value; }
        }
        public IDocumentManager DocumentManager
        {
            get { return _documentManager; }
            set { _documentManager = value; }
        }
        public IFlowDao FlowDao
        {
          get { return _flowDao; }
          set { _flowDao = value; }
        }
        #endregion
    }
}
