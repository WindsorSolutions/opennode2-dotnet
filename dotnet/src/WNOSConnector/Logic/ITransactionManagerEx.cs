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
using Windsor.Node2008.WNOSProviders;

namespace Windsor.Node2008.WNOSConnector.Logic
{
    /// <summary>
    /// Transaction manager interface.
    /// </summary>
    public interface ITransactionManagerEx : ITransactionManager
    {

		/// <summary>
		/// SetTransactionStatusNoThrow
		/// </summary>
		TransactionStatus SetTransactionStatusNoThrow(string transactionId, CommonTransactionStatusCode statusCode, 
													  string statusDetail, bool sendStatusChangeNotifications);
		/// <summary>
		/// SetTransactionStatus
		/// </summary>
		TransactionStatus SetTransactionStatus(string transactionId, string userCreatorId,
											   CommonTransactionStatusCode statusCode, 
											   string statusDetail, bool sendStatusChangeNotifications);
		/// <summary>
		/// SetTransactionStatusIfNotStatus
		/// </summary>
		TransactionStatus SetTransactionStatusIfNotStatus(string transactionId, CommonTransactionStatusCode statusCodeToSet, 
														  string statusDetail, CommonTransactionStatusCode setIfNotStatusCodes,
														  bool sendStatusChangeNotifications);
		/// <summary>
		/// GetTransaction
		/// </summary>
		NodeTransaction GetTransaction(string transactionId, CommonTransactionStatusCode returnDocsWithStatus);
        /// <summary>
        /// GetTransaction
        /// </summary>
        NodeTransaction GetTransaction(string transactionId);
        /// <summary>
		/// CreateTransaction
		/// </summary>
		string CreateTransaction(NodeMethod webMethod, EndpointVersionType endpointVersion, string flowId, 
                                 string operation, string userCreatorId, CommonTransactionStatusCode statusCode, 
                                 string statusDetail, IDictionary<string, TransactionNotificationType> notifications, 
                                 IList<string> recipients, bool sendStatusChangeNotifications);

        /// <summary>
        /// CreateNotifyTransaction
        /// </summary>
        string CreateNotifyTransaction(string flowId, string operation, string userCreatorId,
                                       CommonTransactionStatusCode statusCode, string statusDetail,
                                       ComplexNotification notification, EndpointVersionType endpointVersion,
                                       bool sendStatusChangeNotifications);
		/// <summary>
		/// GetSubmitDocumentServiceForTransaction
		/// </summary>
        DataService GetSubmitDocumentServiceForTransaction(string transactionId, out string flowName,
                                                           out string operation);
		/// <summary>
		/// GetNotifyDocumentServiceForTransaction
		/// </summary>
        DataService GetNotifyDocumentServiceForTransaction(string transactionId, out string flowName,
                                                           out string operation);
		/// <summary>
        /// GetQueryServiceForTransaction
		/// </summary>
		DataService GetQueryServiceForTransaction(string transactionId, out string flowName,
                                                  out string operation, out string requestId);
		/// <summary>
		/// GetSolicitServiceForTransaction
		/// </summary>
		DataService GetSolicitServiceForTransaction(string transactionId, out string flowName,
                                                    out string operation, out string requestId);
        /// <summary>
        /// GetTaskServiceForTransaction
        /// </summary>
        DataService GetTaskServiceForTransaction(string transactionId, out string flowName,
                                                 out string operation, out string requestId);
        /// <summary>
        /// GetExecuteServiceForTransaction
        /// </summary>
        DataService GetExecuteServiceForTransaction(string transactionId, out string flowName,
                                                    out string operation, out string requestId);
        /// <summary>
		/// AddNotifications
		/// </summary>
		void AddNotifications(string transactionId, IDictionary<string, TransactionNotificationType> notifications);
		/// <summary>
		/// AddRecipients
		/// </summary>
		void AddRecipients(string transactionId, IList<string> recipients);
        /// <summary>
        /// GetAllUnprocessedSolicitTransactionDbIds
        /// </summary>
        IList<string> GetAllUnprocessedSolicitTransactionIds();
        /// <summary>
        /// GetAllUnprocessedTaskTransactionIds
        /// </summary>
        IList<string> GetAllUnprocessedTaskTransactionIds();
        /// <summary>
        /// GetAllUnprocessedExecuteTransactionIds
        /// </summary>
        IList<string> GetAllUnprocessedExecuteTransactionIds();
        /// <summary>
        /// GetAllUnprocessedNotifyTransactionDbIds
        /// </summary>
        IList<string> GetAllUnprocessedNotifyTransactionIds();
        /// <summary>
        /// GetAllUnprocessedSubmitTransactionDbIds
        /// </summary>
        IList<string> GetAllUnprocessedSubmitTransactionIds();
        /// <summary>
        /// IsUnprocessed
        /// </summary>
        bool IsUnprocessed(string transactionId);
        /// <summary>
        /// IsUnprocessed
        /// </summary>
        bool IsUnprocessed(string transactionId, out string userModifiedById);
        /// <summary>
        /// Create a task and queue it for execution.  Return the transcation id of the task.
        /// </summary>
        string QueueTask(string flowName, string serviceName, string taskCreatorId,
                         ByIndexOrNameDictionary<string> taskParameters);
    }
}
