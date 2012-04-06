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
using Windsor.Node2008.WNOSConnector.Server;
using Windsor.Node2008.WNOS.Utilities;
using Windsor.Commons.Core;
using Windsor.Commons.NodeDomain;

namespace Windsor.Node2008.WNOS.Server
{
    public class NotifyProcessor : BaseTransactionProcessor
	{
		#region Init

		new public void Init()
		{
			base.Init();
		}

		#endregion

		public NotifyProcessor()
		{
		}

		protected override IList<string> GetAllUnprocessedTransactionIds()
		{
			return TransactionManager.GetAllUnprocessedNotifyTransactionIds();
		}
		protected override IBlockingQueueServerWorker GetWorkerForTransaction(string inTransactionId)
		{
			return new NotifyTransactionWorker(inTransactionId, this);
		}
		protected override string MutexPrefix {
			get { return "NotifyProcessor_"; }
		}
		protected void ProcessNotifyTransaction(string transactionId)
		{
			using (INodeProcessorMutex mutex = GetMutex(transactionId))
			{

				if (!mutex.IsAcquired)
				{
                    LOG.Debug("Exiting ProcessNotifyTransaction(), could not acquire mutex");
					return;	// Another thread is already working on this transaction, get out of here
				}
                // Make sure the transaction has not been processed yet
                string transactionModifiedBy;
                if (!TransactionManager.IsUnprocessed(transactionId, out transactionModifiedBy))
                    if (!TransactionManager.IsUnprocessed(transactionId))
                {
                    LOG.Debug("Exiting ProcessNotifyTransaction(), transaction {0} has already been processed",
                              transactionId);
                    return;
                }
                Activity activity = 
                    new Activity(NodeMethod.Notify, null, null, ActivityType.Info, transactionId, NetworkUtils.GetLocalIp(),
                                 "Start processing notify transaction: \"{0}\"", transactionId);
                activity.ModifiedById = transactionModifiedBy;
                try
				{
                    TransactionManager.SetTransactionStatus(transactionId, CommonTransactionStatusCode.Pending,
                                                            "Processing notify transaction", false);
                    // Get the document processing service
					// TODO: No documentService means failure?
                    string flowName, operation;
					DataService notifyService =
                        TransactionManager.GetNotifyDocumentServiceForTransaction(transactionId, out flowName, out operation);
                    if (notifyService == null)
                    {
                        // Let notify pass through, even without a valid service, per Mark
                    }
                    else if (!notifyService.IsActive)
                    {
                        throw new ArgumentException(string.Format("The Notify service is not active for the flow \"{0}\"",
                                                                  flowName));
                    }
                    
                    if (notifyService == null)
                    {
                        activity.Append("No service found for Notify transaction");
                        TransactionStatus transactionStatus =
                            TransactionManager.SetTransactionStatusIfNotStatus(transactionId, CommonTransactionStatusCode.ReceivedUnprocessed,
                                                                               "Received unprocessed notify transaction",
                                                                               CommonTransactionStatusCode.Received, true);
                        activity.AppendFormat("Transaction status set to \"{0}\"", transactionStatus.Status.ToString());
                    }
                    else
                    {
                        INotifyProcessor plugin;
                        using (IPluginDisposer disposer = PluginLoader.LoadNotifyProcessor(notifyService, out plugin))
                        {
                            TransactionManager.SetTransactionStatus(transactionId, CommonTransactionStatusCode.Processing,
                                                                    "Processing notify transaction", true);
                            activity.Append("Set transaction status to Processing");
                            DateTime startTime = DateTime.Now;
                            activity.AppendFormat("Processing Notify transaction for flow \"{0}\" and operation \"{1}\" using plugin \"{2}\"",
                                                  flowName, operation, plugin.GetType().FullName);

                            try
                            {
                                plugin.ProcessNotify(transactionId);
                            }
                            finally
                            {
                                activity.Append(plugin.GetAuditLogEvents());
                            }

                            TimeSpan processLength = DateTime.Now - startTime;
                            activity.AppendFormat("Process time: {0}", processLength.ToString());
                        }
                        activity.Append("Finished processing notify transaction");
                        TransactionStatus transactionStatus =
                            TransactionManager.SetTransactionStatusIfNotStatus(transactionId, CommonTransactionStatusCode.Processed,
                                                                               "Finished processing notify transaction",
                                                                               CommonTransactionStatusCode.Received, true);
                        activity.AppendFormat("Transaction status set to \"{0}\"", transactionStatus.Status.ToString());
                    }
                }
				catch (Exception e)
				{
                    TransactionStatus transactionStatus =
                        TransactionManager.SetTransactionStatusIfNotStatus(transactionId, CommonTransactionStatusCode.Failed,
                                                                           e.Message, CommonTransactionStatusCode.Received, true);

                    activity.AppendFormat("Transaction status set to \"{0}\"", transactionStatus.Status.ToString());
                    activity.Append(ExceptionUtils.ToShortString(e));
					activity.Type = ActivityType.Error;
                    LOG.Error("ProcessNotifyTransaction() threw an exception.", e);
				}
				finally
				{
					ActivityManager.Log(activity);
				}
			}
		}
		private class NotifyTransactionWorker : IBlockingQueueServerWorker
		{
			private string _transactionId;
			private NotifyProcessor _documentProcessor;

			public NotifyTransactionWorker(string transactionId, NotifyProcessor documentProcessor)
			{
				_transactionId = transactionId;
				_documentProcessor = documentProcessor;
			}
			public bool IsHighPriority
			{
				get
				{
					return false;
				}
			}
			public void DoWork()
			{
				_documentProcessor.ProcessNotifyTransaction(_transactionId);
			}
		}
	}
}
