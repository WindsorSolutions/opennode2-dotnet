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
using System.Collections;
using System.Collections.Specialized;
using System.Text;

using Windsor.Node2008.WNOSDomain;

namespace Windsor.Node2008.WNOSProviders
{
    /// <summary>
    /// Transaction manager interface.
    /// </summary>
    public interface ITransactionManager
    {

        /// <summary>
        /// SetNetworkId
        /// </summary>
        void SetNetworkId(string transactionId, string networkId, EndpointVersionType networkEndpointVersion,
                          string networkEndpointUrl);

        void SetNetworkIdStatus(string transactionId, CommonTransactionStatusCode statusCode,
                                string statusDetail);
        /// <summary>
        /// Get the network id of the specified transaction, null if the tranaction is not valid, or an empty
        /// string if there isn't a network id associated with this transaction.
        /// </summary>
        string GetNetworkId(string transactionId);

            /// <summary>
        /// SetTransactionStatus
        /// </summary>
        TransactionStatus SetTransactionStatus(string transactionId, CommonTransactionStatusCode statusCode,
                                               string statusDetail, bool sendStatusChangeNotifications);

		/// <summary>
		/// Return the current status of a transaction.
		/// </summary>
		TransactionStatus GetTransactionStatus(string transactionID);
        
        /// <summary>
        /// Return the current status of a transaction, along with other relevant information.
        /// </summary>
        TransactionStatus GetTransactionStatus(string transactionId, out string flowId,
											   out string operation, out NodeMethod webMethod);

        TransactionStatus GetTransactionStatusByNetworkId(string networkId, out string flowId,
                                                          out string operation, out NodeMethod webMethod);
        /// <summary>
        /// GetTransactionStatusAndFlowName
        /// </summary>
        TransactionStatus GetTransactionStatusAndFlowName(string transactionId, out string flowName,
                                                          out string operation, out NodeMethod webMethod,
                                                          out EndpointVersionType endpointVersion);
        /// <summary>
        /// Return a list of all unprocessed documents associated with a transaction.  The returned
        /// ids can be used with the methods in IDocumentManager.
        /// </summary>
        IList<string> GetAllUnprocessedDocumentDbIds(string transactionID);
       
        /// <summary>
        /// Return a notification associated with a transaction (should be used with 
        /// INotifyProcessor.ProcessNotify()).
        /// </summary>
        ComplexNotification GetNotifyTransactionByTransactionId(string transactionID);

        /// <summary>
        /// SubmitToTransactionRecipients
        /// Submit transactions status and documents to recipients.
        /// </summary>
        string DoTransactionNotifications(string transactionId);

        /// <summary>
        /// GetNotifications
        /// </summary>
        IDictionary<string, TransactionNotificationType> GetNotifications(string transactionId);
 
        /// <summary>
        /// GetRecipients
        /// </summary>
        IList<string> GetRecipients(string transactionId);

        /// <summary>
        /// GetZippedTransactionDocumentsAsTempFile
        /// </summary>
        string GetZippedTransactionDocumentsAsTempFile(string transactionId);
        /// <summary>
        /// GetZippedTransactionDocumentsAsTempFile
        /// </summary>
        bool GetZippedTransactionDocumentsAsFile(string transactionId, string filePath);
        /// <summary>
        /// Return the username associated with the input transaction
        /// </summary>
        string GetTransactionUsername(string transactionId);

        void AppendRealtimeTransactionDetail(string transactionId, string message,
                                             StatusActivityType statusType);

        IList<StatusActivityEntry> GetRealtimeTransactionDetails(string transactionId);

        void ClearRealtimeTransactionDetails(string transactionId);

        EndpointVersionType GetTransactionEndpointVersionType(string transactionId);

        IList<NodeTransaction> GetOutstandingNetworkTransactions(DateTime newerThan, IEnumerable<CommonTransactionStatusCode> notOutstandingCodes);

        string GetNetworkTransactionStatus(string localTransactionId, out CommonTransactionStatusCode status,
                                           out EndpointVersionType endpointVersion, out string endpointUrl);
    }
}
