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
using System.Web.Services.Protocols;
using System.Reflection;
using Windsor.Node2008.WNOSConnector.Service;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSConnector.Provider;
using Windsor.Node2008.WNOSConnector.Logic;
using Windsor.Node2008.WNOS.Logic;
using Windsor.Node2008.WNOSUtility;
using Common.Logging;
using Windsor.Node2008.WNOSPlugin;
using Windsor.Node2008.WNOS.Server;
using Windsor.Node2008.WNOS.Utilities;
using Windsor.Node2008.WNOSConnector.Server;
using Windsor.Commons.Core;

namespace Windsor.Node2008.WNOS.Service
{
    public class TransactionServiceProvider : BaseEndpointService, ITransactionService
    {

		private ITransactionManagerEx _transactionManager;
		private IFlowManagerEx _flowManager;
		private IDocumentManagerEx _documentManager;
		private INotificationManager _notificationManager;
        private IRequestManagerEx _requestManager;
		private IPluginLoader _pluginLoader;
		private INodeProcessor _notifyDocumentProcessor;
		private INodeProcessor _solicitProcessor;
        private INodeProcessor _executeProcessor;

        #region ITransactionService Members

        public TransactionStatus GetStatus(SimpleId transaction, NamedEndpointVisit visit)
        {
            Activity activity = null;

            try
            {
                UserAccount userAccount;
				MakeEndpointActivity(visit, ActivityType.Audit, NodeMethod.GetStatus,
                                     out userAccount, out activity);
				
				if ( (transaction == null) || string.IsNullOrEmpty(transaction.Id) )
				{
                    throw FaultProvider.GetFault(visit.Version, ENExceptionCodeType.E_InvalidParameter,
												 "Empty input transaction");
				}
				
				string flowId, operation;
				NodeMethod webMethod;
				TransactionStatus transactionStatus = 
					TransactionManager.GetTransactionStatus(transaction.Id, out flowId,
															out operation, out webMethod);
				if ( transactionStatus == null )
				{
                    throw FaultProvider.GetFault(visit.Version, ENExceptionCodeType.E_TransactionId,
												 "Transaction not found: \"{0}\"", transaction.Id);
				}
				
				activity.TransactionId = transaction.Id;

                bool isFlowProtected;
                string flowCode = FlowManager.GetDataFlowNameById(flowId, out isFlowProtected);
                activity.FlowName = flowCode;
				if ( flowCode == null )
				{
                    throw FaultProvider.GetFault(visit.Version, ENExceptionCodeType.E_InvalidDataflow,
												 "Flow id not found: \"{0}\" for transaction: \"{1}\"", 
												 flowId, transaction.Id);
				}

                if (isFlowProtected)
                {
                    ValidateUserPermissions(userAccount, flowCode, operation, NodeMethod.GetStatus,
                                            activity);
                }

                activity.AppendFormat("GetStatus request from {0} by {1} for transaction Id {2}. ",
									  visit.IP, userAccount.NaasAccount, transaction.Id);
                activity.AppendFormat("Result: {0}", transactionStatus);

				return transactionStatus;
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

        public TransactionStatus Notify(ComplexNotification notification, NamedEndpointVisit visit)
        {
            Activity activity = null;
            string transactionId = null;
            try
            {
                UserAccount userAccount;
                MakeEndpointActivity(visit, ActivityType.Audit, NodeMethod.Notify,
                                     out userAccount, out activity);
				if ( notification == null ) {
                    throw FaultProvider.GetFault(visit.Version, ENExceptionCodeType.E_InvalidParameter,
												 "Empty input notification");
				}
				if ( string.IsNullOrEmpty(notification.FlowName) ) {
                    throw FaultProvider.GetFault(visit.Version, ENExceptionCodeType.E_InvalidDataflow,
												 "Empty dataflow name");
				}
                bool isFlowProtected;
                string flowId = FlowManager.GetDataFlowIdByName(notification.FlowName, out isFlowProtected);
                if (flowId == null)
                {
                    throw FaultProvider.GetFault(visit.Version, ENExceptionCodeType.E_InvalidDataflow,
                                                 "Flow \"{0}\" was not found", notification.FlowName);
                }
                activity.FlowName = notification.FlowName;
                if (CollectionUtils.IsNullOrEmpty(notification.Notifications))
                {
                    throw FaultProvider.GetFault(visit.Version, ENExceptionCodeType.E_InvalidParameter,
												 "Notifications array is empty");
				}
                if (isFlowProtected)
                {
                    ValidateUserPermissions(userAccount, notification.FlowName, null, NodeMethod.Notify,
                                            activity);
                }
                
                activity.AppendFormat("Notify request from {0} by {1}.", visit.IP, userAccount.NaasAccount);
				foreach (Notification notifyElement in notification.Notifications)
				{
					activity.AppendFormat("Notify element name {0}, type {1}, status.", notifyElement.Name, 
										  notifyElement.Category.ToString(), notifyElement.Status.ToString());
                }

                transactionId = TransactionManager.CreateNotifyTransaction(flowId, string.Empty, userAccount.Id,
                                                                           CommonTransactionStatusCode.Received,
                                                                           null, notification, visit.Version, true);
				activity.TransactionId = transactionId;

                TransactionStatus rtnTransactionStatus = 
                        new TransactionStatus(transactionId, CommonTransactionStatusCode.Received);

                NotificationManager.DoNotifyNotifications(rtnTransactionStatus, flowId, notification.FlowName,
														  userAccount.NaasAccount);

				NotifyProcessor.Wakeup();

				return rtnTransactionStatus;
			}
            catch (Exception ex)
            {
                if (transactionId != null)
                {
                    TransactionManager.SetTransactionStatusNoThrow(transactionId,
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

        public PaginatedContentResult Query(PaginatedContentRequest request, NamedEndpointVisit visit)
        {
            Activity activity = null;
            string transactionId = null;

            try
            {
                UserAccount userAccount;
                MakeEndpointActivity(visit, ActivityType.Audit, NodeMethod.Query,
                                     out userAccount, out activity);
				if ( request == null )
				{
                    throw FaultProvider.GetFault(visit.Version, ENExceptionCodeType.E_InvalidParameter,
												 "Empty input request");
				}
                if (string.IsNullOrEmpty(request.OperationName))
                {
                    throw FaultProvider.GetFault(visit.Version, ENExceptionCodeType.E_InvalidParameter,
                                                 "Input request is null");
                }
                if (string.IsNullOrEmpty(request.FlowName))
                {
                    if (visit.Version == EndpointVersionType.EN11)
                    {
                        bool moreThanOneFlowFound;
                        string flowNameByServiceName = 
                            FlowManager.GetDataFlowNameByServiceName(request.OperationName, out moreThanOneFlowFound);
                        if (string.IsNullOrEmpty(flowNameByServiceName))
                        {
                            if (moreThanOneFlowFound)
                            {
                                throw FaultProvider.GetFault(visit.Version, ENExceptionCodeType.E_InvalidParameter,
                                                             string.Format("More than one flow was found for the service \"{0}\"",
                                                                           request.OperationName));
                            }
                            else
                            {
                                throw FaultProvider.GetFault(visit.Version, ENExceptionCodeType.E_InvalidParameter,
                                                             string.Format("Could not find a flow for the service \"{0}\"",
                                                                           request.OperationName));
                            }
                        }
                        request.FlowName = flowNameByServiceName;
                    }
                    else
                    {
                        throw FaultProvider.GetFault(visit.Version, ENExceptionCodeType.E_InvalidParameter,
                                                     "Input flow is null");
                    }
				}
                bool isFlowProtected;
                string flowId = FlowManager.GetDataFlowIdByName(request.FlowName, out isFlowProtected);
                if (flowId == null)
                {
                    throw FaultProvider.GetFault(visit.Version, ENExceptionCodeType.E_InvalidDataflow,
                                                 "Flow \"{0}\" was not found", request.FlowName);
                }
                activity.FlowName = request.FlowName;
                if (request.Paging == null)
                {
                    throw FaultProvider.GetFault(visit.Version, ENExceptionCodeType.E_InvalidParameter,
												 "Input paging is null");
				}
				if ( request.Paging.Count == -1 ) {
					if ( request.Paging.Start != 0 ) {
                        throw FaultProvider.GetFault(visit.Version, ENExceptionCodeType.E_InvalidParameter,
													 "Start row is not valid: \"{0}\"", request.Paging.Start);
					}
				} else if ( request.Paging.Count > 0 ) {
				} else {
                    throw FaultProvider.GetFault(visit.Version, ENExceptionCodeType.E_InvalidParameter,
												 "Max row count is not valid: \"{0}\"", request.Paging.Count);
				}
				
				DataService queryService = FlowManager.GetQueryServiceForFlow(flowId, request.OperationName);
				if ( (queryService == null) || !queryService.IsActive ) {
                    throw FaultProvider.GetFault(visit.Version, ENExceptionCodeType.E_ServiceUnavailable,
												 "A valid Query service was not found for the flow \"{0}\" and request \"{1}\"", 
												 request.FlowName, request.OperationName);
				}

                if (isFlowProtected)
                {
                    ValidateUserPermissions(userAccount, request.FlowName, request.OperationName, NodeMethod.Query,
                                            activity);
                }

                activity.AppendFormat("Query request from {0} by {1}. ", visit.IP, userAccount.NaasAccount);
                activity.AppendFormat("Service:{0} Parameters:{1} Row:{2} Rows:{3}. ", 
									  request.OperationName, ParsingHelper.ToQualifiedString(request.Parameters),
									  request.Paging.Start.ToString(), request.Paging.Count.ToString());
									  
				// Load the service plugin
				IQueryProcessor plugin;
                IPluginDisposer disposer;
				try {
                    string flowName = FlowManager.GetDataFlowNameById(queryService.FlowId);
                    disposer = PluginLoader.LoadQueryProcessor(queryService, out plugin);
				}
				catch(Exception) {
                    throw FaultProvider.GetFault(visit.Version, ENExceptionCodeType.E_ServiceUnavailable,
												 "Failed to load the Query service for the flow \"{0}\" and request \"{1}\"", 
												 request.FlowName, request.OperationName);
				}
                PaginatedContentResult result;
                using (disposer)
                {
                    transactionId =
                        TransactionManager.CreateTransaction(NodeMethod.Query, visit.Version, flowId, request.OperationName,
                                                             userAccount.Id, CommonTransactionStatusCode.Pending,
                                                             null, null, null, false);
                    activity.TransactionId = transactionId;

                    string requestId =
                        RequestManager.CreateDataRequest(transactionId, queryService.Id, request.Paging.Start,
                                                         request.Paging.Count, RequestType.Query, userAccount.Id,
                                                         request.Parameters);

                    try
                    {
                        result = plugin.ProcessQuery(requestId);
                    }
                    finally
                    {
                        activity.Append(plugin.GetAuditLogEvents());
                    }
                }

				TransactionManager.SetTransactionStatus(transactionId, CommonTransactionStatusCode.Processed,
														null, false);

                NotificationManager.DoQueryNotifications(flowId, transactionId, request.FlowName, userAccount.NaasAccount, 
														 request.OperationName, request.Paging.Start,
														 request.Paging.Count, request.Parameters);
				return result;
            }
            catch (Exception ex)
            {
				if ( transactionId != null ) {
					TransactionManager.SetTransactionStatusNoThrow(transactionId, 
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

        public TransactionStatus Solicit(AsyncContentRequest request, NamedEndpointVisit visit)
        {
            Activity activity = null;
            string transactionId = null;

            try
            {
                UserAccount userAccount;
                MakeEndpointActivity(visit, ActivityType.Audit, NodeMethod.Solicit,
                                     out userAccount, out activity);
				if ( request == null )
				{
                    throw FaultProvider.GetFault(visit.Version, ENExceptionCodeType.E_InvalidParameter,
												 "Empty input request");
				}
				if ( string.IsNullOrEmpty(request.OperationName) ) {
                    throw FaultProvider.GetFault(visit.Version, ENExceptionCodeType.E_InvalidParameter,
												 "Input request is null");
				}
                if ((request.FlowName == null) || string.IsNullOrEmpty(request.FlowName))
                {
                    if (visit.Version == EndpointVersionType.EN11)
                    {
                        bool moreThanOneFlowFound;
                        string flowNameByServiceName =
                            FlowManager.GetDataFlowNameByServiceName(request.OperationName, out moreThanOneFlowFound);
                        if (string.IsNullOrEmpty(flowNameByServiceName))
                        {
                            if (moreThanOneFlowFound)
                            {
                                throw FaultProvider.GetFault(visit.Version, ENExceptionCodeType.E_InvalidParameter,
                                                             string.Format("More than one flow was found for the service \"{0}\"",
                                                                           request.OperationName));
                            }
                            else
                            {
                                throw FaultProvider.GetFault(visit.Version, ENExceptionCodeType.E_InvalidParameter,
                                                             string.Format("Could not find a flow for the service \"{0}\"",
                                                                           request.OperationName));
                            }
                        }
                        request.FlowName = flowNameByServiceName;
                    }
                    else
                    {
                        throw FaultProvider.GetFault(visit.Version, ENExceptionCodeType.E_InvalidParameter,
                                                     "Input flow is null");
                    }
                }
                bool isFlowProtected;
				string flowId = FlowManager.GetDataFlowIdByName(request.FlowName, out isFlowProtected);
				if ( flowId == null )
				{
                    throw FaultProvider.GetFault(visit.Version, ENExceptionCodeType.E_InvalidDataflow,
												 "Flow \"{0}\" was not found", request.FlowName);
				}
                activity.FlowName = request.FlowName;
				DataService solicitService = FlowManager.GetSolicitServiceForFlow(flowId, request.OperationName);
				if ( (solicitService == null) || !solicitService.IsActive ) {
                    throw FaultProvider.GetFault(visit.Version, ENExceptionCodeType.E_ServiceUnavailable,
												 "A valid Solicit service was not found for the flow \"{0}\" and request \"{1}\"", 
												 request.FlowName, request.OperationName);
				}
                if (isFlowProtected)
                {
                    ValidateUserPermissions(userAccount, request.FlowName, request.OperationName, NodeMethod.Solicit,
                                            activity);
                }

                activity.AppendFormat("Solicit request from {0} by {1}. ", visit.IP, userAccount.NaasAccount);
                activity.AppendFormat("Service:{0} Parameters:{1}. ", 
									  request.OperationName, ParsingHelper.ToQualifiedString(request.Parameters));

				// Validate the service plugin
				try {
                    PluginLoader.ValidateSolicitProcessor(solicitService);
				}
				catch(Exception) {
                    throw FaultProvider.GetFault(visit.Version, ENExceptionCodeType.E_ServiceUnavailable,
												 "Failed to load the Solicit service for the flow \"{0}\" and request \"{1}\"", 
												 request.FlowName, request.OperationName);
				}

				transactionId =
                    TransactionManager.CreateTransaction(NodeMethod.Solicit, visit.Version, flowId, request.OperationName,
														 userAccount.Id, CommonTransactionStatusCode.Unknown,
														 null, request.Notifications, request.Recipients, false);
                activity.TransactionId = transactionId;
                
                string requestId = 
					RequestManager.CreateDataRequest(transactionId, solicitService.Id, 0, -1, RequestType.Solicit, userAccount.Id, 
													 request.Parameters);
													 
				TransactionStatus transactionStatus = 
					TransactionManager.SetTransactionStatus(transactionId, CommonTransactionStatusCode.Received,
															null, false);

				NotificationManager.DoSolicitNotifications(transactionStatus, flowId, request.FlowName, userAccount.NaasAccount, 
														   request.OperationName, request.Parameters);
				SolicitProcessor.Wakeup();

                return transactionStatus;
            }
            catch (Exception ex)
            {
				if ( transactionId != null ) {
					TransactionManager.SetTransactionStatusNoThrow(transactionId, CommonTransactionStatusCode.Failed,
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

        public ExecuteContentResultEx Execute(ServiceContentRequest request, NamedEndpointVisit visit)
        {
            Activity activity = null;
            string transactionId = null;

            try
            {
                UserAccount userAccount;
                MakeEndpointActivity(visit, ActivityType.Audit, NodeMethod.Execute,
                                     out userAccount, out activity);
                if (request == null)
                {
                    throw FaultProvider.GetFault(visit.Version, ENExceptionCodeType.E_InvalidParameter,
                                                 "Empty input request");
                }
                if ((request.Interface == null) || string.IsNullOrEmpty(request.Interface))
                {
                    throw FaultProvider.GetFault(visit.Version, ENExceptionCodeType.E_InvalidParameter,
                                                 "Input interface is null");
                }
                bool isFlowProtected;
                string flowId = FlowManager.GetDataFlowIdByName(request.Interface, out isFlowProtected);
                if (flowId == null)
                {
                    throw FaultProvider.GetFault(visit.Version, ENExceptionCodeType.E_InvalidDataflow,
                                                 "Interface \"{0}\" was not found", request.Interface);
                }
                activity.FlowName = request.Interface;
                DataService executeService = FlowManager.GetExecuteServiceForFlow(flowId, request.OperationName);
                if ((executeService == null) || !executeService.IsActive)
                {
                    throw FaultProvider.GetFault(visit.Version, ENExceptionCodeType.E_ServiceUnavailable,
                                                 "A valid Execute service was not found for the interface \"{0}\" and method \"{1}\"",
                                                 request.Interface, request.OperationName);
                }

                if (isFlowProtected)
                {
                    ValidateUserPermissions(userAccount, request.Interface, request.OperationName, NodeMethod.Execute,
                                            activity);
                }

                activity.AppendFormat("Execute request from {0} by {1}. ", visit.IP, userAccount.NaasAccount);
                activity.AppendFormat("Service:{0} Parameters:{1}. ",
                                      request.OperationName, ParsingHelper.ToQualifiedString(request.Parameters));

                // Load the service plugin
                IExecuteProcessor plugin;
                IPluginDisposer disposer;
                try
                {
                    string flowName = FlowManager.GetDataFlowNameById(executeService.FlowId);
                    disposer = PluginLoader.LoadExecuteProcessor(executeService, out plugin);
                }
                catch (Exception)
                {
                    throw FaultProvider.GetFault(visit.Version, ENExceptionCodeType.E_ServiceUnavailable,
                                                 "Failed to load the Execute service for the interface \"{0}\" and method \"{1}\"",
                                                 request.Interface, request.OperationName);
                }
                ExecuteContentResultEx result = new ExecuteContentResultEx();
                using (disposer)
                {
                    transactionId =
                        TransactionManager.CreateTransaction(NodeMethod.Execute, visit.Version, flowId, request.OperationName,
                                                             userAccount.Id, CommonTransactionStatusCode.Received,
                                                             null, null, null, false);
                    activity.TransactionId = transactionId;

                    string requestId =
                        RequestManager.CreateDataRequest(transactionId, executeService.Id, 0, -1,
                                                         RequestType.Execute, userAccount.Id,
                                                         request.Parameters);

                    try
                    {
                        ExecuteContentResult result2 = plugin.ProcessExecute(requestId);

                        result.Content = result2.Content;
                        result.Id = transactionId;
                        result.Status = result2.Status;
                    }
                    finally
                    {
                        activity.Append(plugin.GetAuditLogEvents());
                    }
                }

                TransactionManager.SetTransactionStatus(transactionId, result.Status,
                                                        string.Empty, false);

                NotificationManager.DoExecuteNotifications(result.Id, result.Status, flowId, 
                                                           request.Interface, userAccount.NaasAccount, 
                                                           request.OperationName, request.Parameters);
                ExecuteProcessor.Wakeup();

                return result;
            }
            catch (Exception ex)
            {
                if (transactionId != null)
                {
                    TransactionManager.SetTransactionStatusNoThrow(transactionId,
                                                                   CommonTransactionStatusCode.Failed,
                                                                   ex.Message, false);
                }
                if (activity != null)
                {
                    activity.Append(ExceptionUtils.ToShortString(ex));
                    activity.Type = ActivityType.Error;
                }
                if (ex is SoapException)
                {
                    throw;	// Throw directly since already SoapException
                }
                else
                {
                    throw FaultProvider.GetFault(visit.Version, ex);
                }
            }
            finally
            {
                if (activity != null)
                {
                    ActivityManager.Log(activity);
                }
            }
        }

        #endregion
        
        #region Init

        new public void Init()
        {
            base.Init();
 			FieldNotInitializedException.ThrowIfNull(this, ref _transactionManager);
 			FieldNotInitializedException.ThrowIfNull(this, ref _flowManager);
 			FieldNotInitializedException.ThrowIfNull(this, ref _documentManager);
 			FieldNotInitializedException.ThrowIfNull(this, ref _notificationManager);
 			FieldNotInitializedException.ThrowIfNull(this, ref _requestManager);
 			FieldNotInitializedException.ThrowIfNull(this, ref _pluginLoader);
			FieldNotInitializedException.ThrowIfNull(this, ref _notifyDocumentProcessor);
			FieldNotInitializedException.ThrowIfNull(this, ref _solicitProcessor);
		}

        #endregion // Init
        
		public INotificationManager NotificationManager {
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

		public IFlowManagerEx FlowManager {
			get {
				return _flowManager;
			}
			set {
				_flowManager = value;
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
        public IRequestManagerEx RequestManager
        {
			get {
				return _requestManager;
			}
			set {
				_requestManager = value;
			}
		}
		internal IPluginLoader PluginLoader {
			get {
				return _pluginLoader;
			}
			set {
				_pluginLoader = value;
			}
		}
		internal INodeProcessor NotifyProcessor
		{
			get
			{
				return _notifyDocumentProcessor;
			}
			set
			{
				_notifyDocumentProcessor = value;
			}
		}
		internal INodeProcessor SolicitProcessor
		{
			get { return _solicitProcessor; }
			set { _solicitProcessor = value; }
		}
        internal INodeProcessor ExecuteProcessor
        {
            get { return _executeProcessor; }
            set { _executeProcessor = value; }
        }
    }
}
