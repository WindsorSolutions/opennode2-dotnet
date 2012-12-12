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
using Windsor.Node2008.WNOSDomain;
using System.Collections.Generic;
using Windsor.Node2008.WNOSConnector.Logic;
using Windsor.Commons.NodeDomain;
using Windsor.Node2008.WNOSDomain.TransactionTracking;

namespace Windsor.Node2008.WNOS.Data
{
    public interface ITransactionDao
    {
        void AddNotifications(string transactionId, IDictionary<string, TransactionNotificationType> notifications);
        void AddRecipients(string transactionId, IList<string> recipients);
        string CreateNotifyTransaction(string flowId, string operation, string userCreatorId, CommonTransactionStatusCode statusCode, string statusDetail, ComplexNotification notification, EndpointVersionType endpointVersion, bool sendStatusChangeNotifications);
        string CreateTransaction(NodeMethod webMethod, EndpointVersionType endpointVersion, string flowId, string operation, string userCreatorId, CommonTransactionStatusCode statusCode, string statusDetail, IDictionary<string, TransactionNotificationType> notifications, IList<string> recipients, bool sendStatusChangeNotifications);
        IList<string> GetAllDocumentNames(string transactionId);
        IList<string> GetAllUnprocessedDocumentDbIds(string transactionId);
        IList<string> GetAllUnprocessedExecuteTransactionIds();
        IList<string> GetAllUnprocessedNotifyTransactionIds();
        IList<string> GetAllUnprocessedSolicitTransactionIds();
        IList<string> GetAllUnprocessedTaskTransactionIds();
        IList<string> GetAllUnprocessedSubmitTransactionIds();
        DataService GetExecuteServiceForTransaction(string transactionId, out string flowName, out string operation, out string requestId);
        IDictionary<string, TransactionNotificationType> GetNotifications(string transactionId);
        DataService GetNotifyDocumentServiceForTransaction(string transactionId, out string flowName, out string operation);
        ComplexNotification GetNotifyTransactionByTransactionId(string transactionID);
        DataService GetQueryServiceForTransaction(string transactionId, out string flowName, out string operation, out string requestId);
        IList<string> GetRecipients(string transactionId);
        DataService GetSolicitServiceForTransaction(string transactionId, out string flowName, out string operation, out string requestId);
        DataService GetTaskServiceForTransaction(string transactionId, out string flowName, out string operation, out string requestId);
        DataService GetSubmitDocumentServiceForTransaction(string transactionId, out string flowName, out string operation);
        NodeTransaction GetTransaction(string transactionId, CommonTransactionStatusCode returnDocsWithStatus);
        NodeTransaction GetTransaction(string transactionId);
        Document GetTransactionDocument(string transactionID, string dbDocId);
        string GetTransactionFlowId(string transactionId, out string flowName, out string operation,
                                    out EndpointVersionType endpointVersion);
        string GetTransactionFlowId(string transactionId, out string flowName, out string operation, out bool isProtected);
        string GetTransactionFlowId(string transactionId, out string flowName, out string operation);
        string GetTransactionFlowId(string transactionId);
        string GetTransactionFlowId(string transactionId, out string operation);
        TransactionStatus GetTransactionStatus(string transactionId);
        TransactionStatus GetTransactionStatus(string transactionId, out string flowId, out string operation, out NodeMethod webMethod);
        TransactionStatus GetTransactionStatusAndFlowName(string transactionId, out string flowName,
                                                          out string operation, out NodeMethod webMethod,
                                                          out EndpointVersionType endpointVersion);
        TransactionStatus GetTransactionStatusByNetworkId(string networkId, out string flowId, out string operation, out NodeMethod webMethod);
        string GetSingleTransactionWithNetworkId(string networkId);
        string GetTransactionFlowName(string transactionId, out NodeMethod webMethod, out string flowOperation);
        string GetTransactionFlowName(string transactionId, out NodeMethod webMethod);
        string GetTransactionFlowName(string transactionId);
        bool IsUnprocessed(string transactionId);
        bool IsUnprocessed(string transactionId, out string userModifiedById);
        void SendStatusChangeNotifications(string transactionId);
        void SendStatusChangeNotifications(TransactionStatus status);
        void SendStatusChangeNotifications(TransactionStatus status, IDictionary<string, TransactionNotificationType> notifications);
        void SetNetworkId(string transactionId, string networkId, EndpointVersionType networkEndpointVersion,
                          string networkEndpointUrl, string networkFlowName, string networkFlowOperation, string networkStatusDetail);
        void SetNetworkId(string transactionId, string networkId, EndpointVersionType networkEndpointVersion,
                          string networkEndpointUrl, string networkFlowName, string networkFlowOperation);
        void SetNetworkIdStatus(string transactionId, CommonTransactionStatusCode networkStatus);
        void SetNetworkIdStatus(string transactionId, CommonTransactionStatusCode networkStatus, string statusDetail);
        string GetNetworkId(string transactionId);
        TransactionStatus SetTransactionStatus(string transactionId, string userCreatorId, CommonTransactionStatusCode statusCode, string statusDetail, bool sendStatusChangeNotifications);
        TransactionStatus SetTransactionStatus(string transactionId, CommonTransactionStatusCode statusCode, string statusDetail, bool sendStatusChangeNotifications);
        TransactionStatus SetTransactionStatusIfNotStatus(string transactionId, CommonTransactionStatusCode statusCodeToSet, string statusDetail, CommonTransactionStatusCode setIfNotStatusCodes, bool sendStatusChangeNotifications);
        Dictionary<string, string> GetTransactionTypes();
        string GetTransactionUsername(string transactionId);

        void AppendRealtimeTransactionDetail(string transactionId, string message,
                                             StatusActivityType statusType);
        IList<StatusActivityEntry> GetRealtimeTransactionDetails(string transactionId);
        void ClearRealtimeTransactionDetails(string transactionId);
        EndpointVersionType GetTransactionEndpointVersionType(string transactionId);
        IList<NodeTransaction> GetOutstandingNetworkTransactions(DateTime newerThan, IEnumerable<string> getFlowNames,
                                                                 IEnumerable<CommonTransactionStatusCode> notOutstandingCodes);
        string GetNetworkTransactionStatus(string localTransactionId, out CommonTransactionStatusCode status,
                                           out EndpointVersionType endpointVersion, out string endpointUrl);
        string GetNetworkTransactionStatusFromNetworkId(string networkTransactionId, out CommonTransactionStatusCode status,
                                                        out EndpointVersionType endpointVersion, out string endpointUrl);
        ICollection<string> GetAllOperationNames();
        ICollection<string> GetAllWebMethodNames();
        TransactionListType1 DoTransactionTrackingQuery(ICollection<KeyValuePair<TransactionTrackingQueryParameter, object>> queryParameters);
        TransactionCount GetTransactionTrackingQueryCount(ICollection<KeyValuePair<TransactionTrackingQueryParameter, object>> queryParameters);
        TransactionDetailType DoTransactionTrackingDetail(string transactionId);
        CommonTransactionStatusCode GetNetworkTransactionStatus(string localTransactionId);

        NodeTransaction GetLastTransaction(string flowName, string flowOperation, IEnumerable<NodeMethod> allowedNodeMethods,
                                           IEnumerable<CommonTransactionStatusCode> allowedTransactionStatus,
                                           IEnumerable<CommonTransactionStatusCode> notAllowedTransactionStatus,
                                           bool loadDocuments, bool loadDocumentsContent);
    }
}
