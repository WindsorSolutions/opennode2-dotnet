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
using System.IO;
using System.Reflection;
using System.Web.Services.Protocols;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOS.Service;
using Windsor.Node2008.WNOSUtility;
using Windsor.Node2008.WNOS.Logic;
using Windsor.Node2008.WNOSConnector.Provider;
using Windsor.Node2008.WNOSPlugin;
using Windsor.Node2008.WNOSConnector.Service;
using Windsor.Node2008.WNOSConnector.Logic;
using Windsor.Node2008.WNOS.Server;
using Windsor.Node2008.WNOSConnector.Server;
using Windsor.Commons.Core;
using Windsor.Commons.NodeDomain;

namespace Windsor.Node2008.WNOS.Service
{
    public class ContentServiceProvider : BaseEndpointService, IContentService
    {
		private ITransactionManagerEx _transactionManager;
		private IDocumentManagerEx _documentManager;
		private INotificationManagerEx _notificationManager;
		private INodeProcessor _submitDocumentProcessor;
        private ITransactionService _transactionService;

        #region IContentService Members

        public TransactionStatus Submit(AsyncComplexContent content, NamedEndpointVisit visit)
        {
            Activity activity = null;
			IList<string> newDocumentIds = null;
			bool isNewTransaction = false;
			
            try
            {
				// Validate inputs
                NodeVisit nodeVisit;
                MakeEndpointActivity(visit, ActivityType.Audit, NodeMethod.Submit,
                                     out nodeVisit, out activity);
				
				if ( content == null ) {
                    throw FaultProvider.GetFault(visit.Version, ENExceptionCodeType.E_InvalidParameter,
												 "Input content is null");
				}
				if ( CollectionUtils.IsNullOrEmpty(content.Documents) ) {
                    throw FaultProvider.GetFault(visit.Version, ENExceptionCodeType.E_InvalidParameter,
												 "Input document list is empty");
				}
				if ( content.Transaction == null ) {
                    throw FaultProvider.GetFault(visit.Version, ENExceptionCodeType.E_InvalidParameter,
												 "Input transaction is null");
				}
				if ( (content.Flow == null) || string.IsNullOrEmpty(content.Flow.FlowName) ) {
                    throw FaultProvider.GetFault(visit.Version, ENExceptionCodeType.E_InvalidParameter,
												 "Input flow is null");
				}
				bool isFlowProtected;
				string flowId = FlowManager.GetDataFlowIdByName(content.Flow.FlowName, out isFlowProtected);
                if (flowId == null)
                {
                    throw FaultProvider.GetFault(visit.Version, ENExceptionCodeType.E_InvalidDataflow,
                                                 "Flow \"{0}\" was not found", content.Flow.FlowName);
                }
                activity.FlowName = content.Flow.FlowName;
                activity.Operation = content.Flow.Operation;
				isNewTransaction = string.IsNullOrEmpty(content.Transaction.Id);
                string networkId = null;
				
				// Get the flow id associated with the transaction
				if ( isNewTransaction ) {

                } else {
					// Existing transaction
                    isNewTransaction =
                        ValidateTransaction(visit.Version, NodeMethod.Submit, content, (visit.Version != EndpointVersionType.EN11),
                                            flowId, out networkId);
                    if (!isNewTransaction)
                    {
                        activity.TransactionId = content.Transaction.Id;
                    }
				}
				
				DataService documentService = FlowManager.GetSubmitDocumentServiceForFlow(flowId, content.Flow.Operation);
                if (documentService == null)
                {
                    if (!string.IsNullOrEmpty(content.Flow.Operation))
                    {
                        throw FaultProvider.GetFault(visit.Version, ENExceptionCodeType.E_ServiceUnavailable,
                                                     "A valid Submit service was not found for the flow \"{0}\"", content.Flow.FlowName);
                    }
                    // Let empty operation pass through, even without a valid service, per Mark
                }
				else if ( !documentService.IsActive ) {
                    throw FaultProvider.GetFault(visit.Version, ENExceptionCodeType.E_ServiceUnavailable,
                                                 "The Submit service is not active for the flow \"{0}\"", content.Flow.FlowName);
				}

                if (isFlowProtected)
                {
                    ValidateUserPermissions(nodeVisit, content.Flow.FlowName, content.Flow.Operation, 
                                            NodeMethod.Submit, activity);
                }

                if ( isNewTransaction ) {
					// Create a new transaction
					content.Transaction.Id =
                        TransactionManager.CreateTransaction(NodeMethod.Submit, visit.Version, flowId, content.Flow.Operation,
                                                             nodeVisit.Account.Id, CommonTransactionStatusCode.Unknown,
															 null, content.Notifications, content.Recipients, false);
					activity.TransactionId = content.Transaction.Id;
                    if (networkId != null)
                    {
                        TransactionManager.SetNetworkId(content.Transaction.Id, networkId,
                                                        EndpointVersionType.Undefined, null, null, null);
                    }
                    activity.AppendFormat("Created new submit transaction id: {0}.", activity.TransactionId);
                }
                else
                {
                    activity.AppendFormat("Retrieved existing submit transaction id: {0}.", activity.TransactionId);
                }

                foreach (Document document in content.Documents)
                {
                    activity.AppendFormat("Adding submit document to transaction: {0}.", document);
                }
                // Add the documents to repository and DB
				newDocumentIds = 
					DocumentManager.AddDocuments(content.Transaction.Id, content.Documents);

#if DEBUG
				NodeTransaction nodeTransaction = TransactionManager.GetTransaction(content.Transaction.Id, 
																					CommonTransactionStatusCode.Received);
#endif // DEBUG
				TransactionStatus rtnTransactionStatus =
                    TransactionManager.SetTransactionStatus(content.Transaction.Id, nodeVisit.Account.Id,
															CommonTransactionStatusCode.Received,
															null, false);

                NotificationManager.DoSubmitNotifications(rtnTransactionStatus, flowId, content.Flow.FlowName, 
														  content.Flow.Operation,
                                                          nodeVisit.Account.NaasAccount);

				SubmitProcessor.Wakeup();
				
				return rtnTransactionStatus;
            }
            catch (Exception ex)
            {
				if ( newDocumentIds != null ) {
					DocumentManager.RollbackDocuments(content.Transaction.Id, newDocumentIds);
				}
				if ( isNewTransaction && !string.IsNullOrEmpty(content.Transaction.Id) ) {
					TransactionManager.SetTransactionStatusNoThrow(content.Transaction.Id, 
																   CommonTransactionStatusCode.Failed,
																   ex.Message, false);
				}
                if (activity != null)
                {
                    activity.Append(ExceptionUtils.ToShortString(ex));
                    activity.Type = ActivityType.Error;
                }
                if ( ex is SoapException ) {
					throw;	// Throw directly since already SoapException
                } else {
                    throw FaultProvider.GetFault(visit.Version, ex);
				}
            }
            finally
            {
				if ( activity != null )
				{
					ActivityManager.Log(activity);
				}
            }
        }

        public IList<Document> Download(ComplexContent content, NamedEndpointVisit visit)
        {
            Activity activity = null;
			
            try
            {
				// Validate inputs
                NodeVisit nodeVisit;
                MakeEndpointActivity(visit, ActivityType.Audit, NodeMethod.Download,
                                     out nodeVisit, out activity);
				
				if ( content == null ) {
                    throw FaultProvider.GetFault(visit.Version, ENExceptionCodeType.E_InvalidParameter,
												 "Input content is null");
				}
				if ( (content.Transaction == null) || string.IsNullOrEmpty(content.Transaction.Id) ) {
                    throw FaultProvider.GetFault(visit.Version, ENExceptionCodeType.E_InvalidParameter,
												 "Input transaction is null");
				}
                bool isFlowProtected;
                string flowName, flowOperation;
                string flowId = TransactionManager.GetTransactionFlowId(content.Transaction.Id, out flowName, out flowOperation,
                                                                        out isFlowProtected);
                if (flowId == null)
                {
                    throw FaultProvider.GetFault(visit.Version, ENExceptionCodeType.E_InvalidDataflow,
                                                 "A flow with transaction id \"{0}\" was not found", content.Transaction.Id);
                }
                if ((content.Flow != null) && !string.IsNullOrEmpty(content.Flow.FlowName))
                {
                    if (!string.Equals(flowName, content.Flow.FlowName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        throw FaultProvider.GetFault(visit.Version, ENExceptionCodeType.E_InvalidDataflow,
                                                     "The input dataflow name \"{0}\" does not match the dataflow name for transaction id \"{1}\"",
                                                     content.Flow.FlowName, content.Transaction.Id);
                    }
                }
                if (content.Flow == null)
                {
                    content.Flow = new OperationDataFlow(flowName);
                }
                else if (string.IsNullOrEmpty(content.Flow.FlowName))
                {
                    content.Flow.FlowName = flowName;
                }
                activity.FlowName = content.Flow.FlowName;
                activity.Operation = content.Flow.Operation;
                string networkId;
                ValidateTransaction(visit.Version, NodeMethod.Download, content, false, flowId,
                                    out networkId);
                activity.TransactionId = content.Transaction.Id;
                if (isFlowProtected)
                {
                    ValidateUserPermissions(nodeVisit, content.Flow.FlowName, content.Flow.Operation,
                                            NodeMethod.Download, activity);
                }
                
                IList<Document> documents;
                try {
					documents = DocumentManager.GetDocuments(content.Transaction.Id,
                                                             content.Documents, true);
				}
				catch(FileNotFoundException fileNotFoundException) {
                    throw FaultProvider.GetFault(visit.Version, ENExceptionCodeType.E_FileNotFound,
												 string.Format("The document \"{0}\" was not found.",
															   Path.GetFileName(fileNotFoundException.FileName)));
				}
                
                if ( !CollectionUtils.IsNullOrEmpty(documents) ) {
					foreach(Document document in documents) {
						activity.AppendFormat("Document: {0}.", document);
					}
				}

                NotificationManager.DoDownloadNotifications(content.Transaction.Id, flowId, content.Flow.FlowName,
                                                            nodeVisit.Account.NaasAccount);
				return documents;
			}
            catch (Exception ex)
            {
                if (activity != null)
                {
                    activity.Append(ExceptionUtils.ToShortString(ex));
                    activity.Type = ActivityType.Error;
                }
                if ( ex is SoapException ) {
					throw;	// Throw directly since already SoapException
                } else {
                    throw FaultProvider.GetFault(visit.Version, ex);
				}
            }
            finally
            {
				if ( activity != null )
				{
					ActivityManager.Log(activity);
				}
            }
        }

        public SimpleContent GetMetaData(string category, NamedEndpointVisit visit)
        {
            PaginatedContentRequest request = new PaginatedContentRequest();
            request.FlowName = "ENDS_v20";
            request.OperationName = "GetServices";
            request.Paging = new PaginationIndicator();
            request.Paging.Start = 0;
            request.Paging.Count = -1;
            if (visit.Version == EndpointVersionType.EN20)
            {
                request.Parameters = new ByIndexOrNameDictionary<string>(true);
                request.Parameters.Add("ServiceCategory", category);
            }
            else
            {
                request.Parameters = new ByIndexOrNameDictionary<string>(false);
                request.Parameters.Add(category);
            }

            PaginatedContentResult result = _transactionService.Query(request, visit);

            return result.Content;
        }

        private bool ValidateTransaction(EndpointVersionType endpointVersion, NodeMethod transactionWebMethod, 
                                         ComplexContent content, bool doValidateFlowOperation,
								         string flowId, out string networkId) {
            
            networkId = null;
            string dbOperation;
			NodeMethod webMethod;
            bool isNetworkTransactionId = false;
            string transactionFlowId;
			TransactionStatus transactionStatus =
                TransactionManager.GetTransactionStatus(content.Transaction.Id, out transactionFlowId,
														out dbOperation, out webMethod);
			if ( transactionStatus == null )
			{
                transactionStatus =
                    TransactionManager.GetTransactionStatusByNetworkId(content.Transaction.Id, out transactionFlowId,
														               out dbOperation, out webMethod);
                if (transactionStatus == null)
                {
                    throw FaultProvider.GetFault(endpointVersion, ENExceptionCodeType.E_TransactionId,
                                                 "Transaction \"{0}\" was not found",
                                                 content.Transaction.Id);
                }
                isNetworkTransactionId = true;
			}
            if (transactionFlowId != flowId)
            {
                throw FaultProvider.GetFault(endpointVersion, ENExceptionCodeType.E_InvalidDataflow,
                                             "Flow operation \"{0}\" is not valid for transaction \"{1}\"",
                                             content.Flow.Operation, content.Transaction.Id);
            }
			if ( doValidateFlowOperation &&
				 !string.Equals(dbOperation, content.Flow.Operation ?? string.Empty, StringComparison.InvariantCultureIgnoreCase) ) {
                     throw FaultProvider.GetFault(endpointVersion, ENExceptionCodeType.E_InvalidDataflow,
											 "Flow operation \"{0}\" is not valid for transaction \"{1}\"", 
											 content.Flow.Operation, content.Transaction.Id);
			}
			if ( (transactionWebMethod == NodeMethod.Submit) && (webMethod != NodeMethod.Submit) ) {
                // Create new transaction and reference the input transaction id as the network id for 
                // the new transcation
                networkId = content.Transaction.Id;
			}
            if (networkId != null)
            {
                content.Transaction.Id = string.Empty;
                return true;
            }
            else
            {
                if (isNetworkTransactionId)
                {
                    // Use the "real" db transcation id
                    content.Transaction.Id = transactionStatus.Id;
                }
                return false;
            }
		}
        #endregion

        #region Init

		new public void Init()
		{
			base.Init();
			FieldNotInitializedException.ThrowIfNull(this, ref _transactionManager);
			FieldNotInitializedException.ThrowIfNull(this, ref _documentManager);
			FieldNotInitializedException.ThrowIfNull(this, ref _notificationManager);
			FieldNotInitializedException.ThrowIfNull(this, ref _submitDocumentProcessor);
            FieldNotInitializedException.ThrowIfNull(this, ref _transactionService);
        }

		#endregion // Init

		public INotificationManagerEx NotificationManager {
			get {
				return _notificationManager;
			}
			set {
				_notificationManager = value;
			}
		}

		public IDocumentManagerEx DocumentManager {
			get {
				return _documentManager;
			}
			set {
				_documentManager = value;
			}
		}
		
		public ITransactionManagerEx TransactionManager {
			get {
				return _transactionManager;
			}
			set {
				_transactionManager = value;
			}
		}
        public ITransactionService TransactionService
        {
            get { return _transactionService; }
            set { _transactionService = value; }
        }

		internal INodeProcessor SubmitProcessor {
			get {
				return _submitDocumentProcessor;
			}
			set {
				_submitDocumentProcessor = value;
			}
		}
    }
}
