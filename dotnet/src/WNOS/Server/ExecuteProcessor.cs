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
using System.ComponentModel;
using System.Reflection;
using Windsor.Node2008.WNOS.Logic;
using Windsor.Node2008.WNOSUtility;
using Windsor.Node2008.WNOSConnector.Provider;
using Windsor.Node2008.WNOSConnector.Logic;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSPlugin;
using Spring.Transaction.Support;
using Windsor.Node2008.WNOSConnector.Server;
using Windsor.Node2008.WNOS.Utilities;
using Windsor.Commons.Core;

namespace Windsor.Node2008.WNOS.Server
{
    public class ExecuteProcessor : BaseTransactionProcessor
    {
        private IRequestManagerEx _requestManager;
		private IDocumentManagerEx _documentManager;

        #region Init

        new public void Init()
        {
			base.Init();
 			
 			FieldNotInitializedException.ThrowIfNull(this, ref _requestManager);
 			FieldNotInitializedException.ThrowIfNull(this, ref _documentManager);
		}

        #endregion

        public ExecuteProcessor()
        {
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
		public IDocumentManagerEx DocumentManager {
			get {
				return _documentManager;
			}
			set {
				_documentManager = value;
			}
		}
		protected override string MutexPrefix {
            get { return "ProcessExecuteTransaction_"; }
		}
		protected override IList<string> GetAllUnprocessedTransactionIds() {
			return TransactionManager.GetAllUnprocessedExecuteTransactionIds();
		}
		protected override IBlockingQueueServerWorker GetWorkerForTransaction(string inTransactionId) {
			return new TransactionRequestProcessor(inTransactionId, this);
		}
        protected void ProcessExecuteTransaction(string transactionId)
        {
			using (INodeProcessorMutex mutex = GetMutex(transactionId)) {
				
				if ( !mutex.IsAcquired ) {
					LOG.Debug("Exiting ProcessExecuteTransaction(), could not acquire mutex");
					return;	// Another thread is already working on this transaction, get out of here
				}
                // Make sure the transaction has not been processed yet
                string transactionModifiedBy;
                if (!TransactionManager.IsUnprocessed(transactionId, out transactionModifiedBy))
                {
                    LOG.Debug("Exiting ProcessExecuteTransaction(), transaction {0} has already been processed",
                              transactionId);
                    return;
                }
                Activity activity = new Activity(NodeMethod.Execute, null, null, ActivityType.Info, transactionId,
                                                 NetworkUtils.GetLocalIp(),
                                                 "Start processing execute transaction: \"{0}\"", transactionId);
                activity.ModifiedById = transactionModifiedBy;
                IList<string> newDocumentIds = null;
	            
				try {
                    TransactionManager.SetTransactionStatus(transactionId, CommonTransactionStatusCode.Pending,
                                                            "Processing execute transaction", false);
					
					// Get the request processing service
                    string requestId, flowName, operation;
					DataService executeService =
                        TransactionManager.GetExecuteServiceForTransaction(transactionId, out flowName, out operation, out requestId);
                    if ((executeService == null) || !executeService.IsActive)
                    {
						throw new ArgumentException(string.Format("A valid request service was not found for the transaction \"{0}\"",
																  transactionId));
					}
                    TimeSpan processLength;
                    IExecuteProcessor plugin;
                    using (IPluginDisposer disposer = PluginLoader.LoadExecuteProcessor(executeService, out plugin))
                    {

                        TransactionManager.SetTransactionStatus(transactionId, CommonTransactionStatusCode.Processing,
                                                                string.Format("Processing request with transaction id \"{0}\"",
                                                                              transactionId), true);
                        DateTime startTime = DateTime.Now;
                        activity.Append("Set transaction status to Processing");
                        activity.AppendFormat("Processing Execute transaction for flow \"{0}\" and operation \"{1}\" using plugin \"{2}\"",
                                              flowName, operation, plugin.GetType().FullName);

                        try
                        {
                            plugin.ProcessExecute(requestId);
                        }
                        finally
                        {
                            activity.Append(plugin.GetAuditLogEvents());
                        }
                        processLength = DateTime.Now - startTime;
                    }

					activity.AppendFormat("Process time: {0}", processLength.ToString());
					
                    TransactionStatus transactionStatus = 
					    TransactionManager.SetTransactionStatus(transactionId, CommonTransactionStatusCode.Processed,
															    string.Format("Processed request with transaction id \"{0}\"", 
																		       transactionId), true);
                    activity.AppendFormat("Transaction status set to \"{0}\"", transactionStatus.Status.ToString());
                }
				catch (Exception e) {
					if ( newDocumentIds != null ) {
						DocumentManager.RollbackDocuments(transactionId, newDocumentIds);
					}
                    TransactionStatus transactionStatus =
                        TransactionManager.SetTransactionStatusIfNotStatus(transactionId, CommonTransactionStatusCode.Failed,
                                                                           e.Message, CommonTransactionStatusCode.Received, true);

                    activity.AppendFormat("Transaction status set to \"{0}\"", transactionStatus.Status.ToString());
                    activity.Append(ExceptionUtils.ToShortString(e));
					activity.Type = ActivityType.Error;
                    LOG.Error("ProcessExecuteTransaction() threw an exception.", e);
				}
				finally {
					ActivityManager.Log(activity);
				}
			}
		}
		private class TransactionRequestProcessor : IBlockingQueueServerWorker {
			
			private string _transactionId;
			private ExecuteProcessor _requestProcessor;
			
			public TransactionRequestProcessor(string transactionId, ExecuteProcessor requestProcessor) {
				_transactionId = transactionId;
				_requestProcessor = requestProcessor;
			}
			public bool IsHighPriority {
				get {
					return false;
				}
			}
			public void DoWork() {
                _requestProcessor.ProcessExecuteTransaction(_transactionId);
			}
		}
    }
}
