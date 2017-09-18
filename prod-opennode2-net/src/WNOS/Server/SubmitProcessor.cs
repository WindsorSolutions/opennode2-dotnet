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
    public class SubmitProcessor : BaseTransactionProcessor
    {
        #region Init

        new public void Init()
        {
            base.Init();
        }

        #endregion

        public SubmitProcessor()
        {
        }

        protected override IList<string> GetAllUnprocessedTransactionIds()
        {
            return TransactionManager.GetAllUnprocessedSubmitTransactionIds();
        }
        protected override IBlockingQueueServerWorker GetWorkerForTransaction(string inTransactionId)
        {
            return new SubmitTransactionWorker(inTransactionId, this);
        }
        protected override string MutexPrefix
        {
            get { return "SubmitProcessor_"; }
        }
        protected void ProcessSubmitTransaction(string transactionId)
        {

            using (INodeProcessorMutex mutex = GetMutex(transactionId))
            {
                if (!mutex.IsAcquired)
                {
                    LOG.Debug("Exiting ProcessTransactionRequest(), could not acquire mutex for transaction {0}",
                              transactionId);
                    return;	// Another thread is already working on this transaction, get out of here
                }
                // Make sure the transaction has not been processed yet
                string transactionModifiedBy;
                if (!TransactionManager.IsUnprocessed(transactionId, out transactionModifiedBy))
                {
                    LOG.Debug("Exiting ProcessSubmitTransaction(), transaction {0} has already been processed",
                              transactionId);
                    return;
                }
                DateTime startTime = DateTime.Now;
                Activity activity =
                    new Activity(NodeMethod.Submit, null, null, ActivityType.Info, transactionId, NetworkUtils.GetLocalIp(),
                                 "Start processing submit transaction: \"{0}\"", transactionId);
                activity.ModifiedById = transactionModifiedBy;

                try
                {
                    TransactionManager.SetTransactionStatus(transactionId, CommonTransactionStatusCode.Pending,
                                                            "Processing submit transaction", false);
                    // Get the document processing service
                    string flowName, operation;
                    DataService submitService =
                        TransactionManager.GetSubmitDocumentServiceForTransaction(transactionId, out flowName,
                                                                                  out operation);
                    if (submitService == null)
                    {
                        if (!string.IsNullOrEmpty(operation))
                        {
                            throw new ArgumentException(string.Format("A valid Submit service was not found for the flow \"{0}\" and operation \"{1}\"",
                                                        flowName, operation));
                        }
                        // Let empty operation pass through, even without a valid service, per Mark
                    }
                    else if (!submitService.IsActive)
                    {
                        throw new ArgumentException(string.Format("The Submit service is not active for the flow \"{0}\" and operation \"{1}\"",
                                                                  flowName, operation));
                    }
                    if (submitService == null)
                    {
                        activity.Append("No service found for Submit transaction");
                        TransactionStatus transactionStatus =
                            TransactionManager.SetTransactionStatusIfNotStatus(transactionId, CommonTransactionStatusCode.ReceivedUnprocessed,
                                                                               "Received unprocessed submit transaction",
                                                                               CommonTransactionStatusCode.Received, true);
                        activity.AppendFormat("Transaction status set to \"{0}\"", transactionStatus.Status.ToString());
                    }
                    else
                    {
                        CommonTransactionStatusCode submitTransactionStatus = CommonTransactionStatusCode.Processed;
                        string submitTransactionStatusDetail = "Finished processing submit transaction";
                        ISubmitProcessor submitProcessor;
                        using (IPluginDisposer disposer = PluginLoader.LoadSubmitProcessor(submitService, out submitProcessor))
                        {
                            TransactionManager.SetTransactionStatus(transactionId, CommonTransactionStatusCode.Processing,
                                                                    "Processing submit transaction", true);
                            activity.Append("Set transaction status to Processing");
                            activity.AppendFormat("Processing Submit transaction for flow \"{0}\" and operation \"{1}\" using plugin \"{2}\"",
                                                  flowName, operation, submitProcessor.GetType().FullName);

                            try
                            {
                                ISubmitProcessorEx submitProcessorEx = submitProcessor as ISubmitProcessorEx;
                                if (submitProcessorEx != null)
                                {
                                    submitTransactionStatus = 
                                        submitProcessorEx.ProcessSubmitAndReturnStatus(transactionId,
                                                                                       out submitTransactionStatusDetail);
                                    activity.AppendFormat("Submit processing plugin returned status of \"{0}\"", 
                                                          submitTransactionStatus.ToString());
                                }
                                else
                                {
                                    submitProcessor.ProcessSubmit(transactionId);
                                }
                            }
                            finally
                            {
                                activity.Append(submitProcessor.GetAuditLogEvents());
                            }

                            TimeSpan processLength = DateTime.Now - startTime;
                            activity.AppendFormat("Process time: {0}", processLength.ToString());
                        }
                        activity.Append("Finished processing submit transaction");
                        TransactionStatus transactionStatus =
                           TransactionManager.SetTransactionStatusIfNotStatus(transactionId, submitTransactionStatus,
                                                                              submitTransactionStatusDetail,
                                                                              CommonTransactionStatusCode.Received |
                                                                              CommonTransactionStatusCode.Completed |
                                                                              CommonTransactionStatusCode.Failed, true);
                        activity.AppendFormat("Transaction status set to \"{0}\"", transactionStatus.Status.ToString());
                        activity.AppendFormat(TransactionManager.DoTransactionNotifications(transactionId));
                    }
                }
                catch (Exception e)
                {
                    LOG.Error("ProcessSubmitTransaction() threw an exception.", e);
                    TransactionStatus transactionStatus =
                        TransactionManager.SetTransactionStatusIfNotStatus(transactionId, CommonTransactionStatusCode.Failed,
                                                                           e.Message, CommonTransactionStatusCode.Received, true);

                    activity.AppendFormat("Transaction status set to \"{0}\"", transactionStatus.Status.ToString());
                    activity.Append(ExceptionUtils.ToShortString(e));
                    activity.Type = ActivityType.Error;
                    activity.AppendFormat(TransactionManager.DoTransactionNotifications(transactionId));
                }
                finally
                {
                    ActivityManager.Log(activity);
                }
            }
        }
        private class SubmitTransactionWorker : IBlockingQueueServerWorker
        {

            private string _transactionId;
            private SubmitProcessor _documentProcessor;

            public SubmitTransactionWorker(string transactionId, SubmitProcessor documentProcessor)
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
                _documentProcessor.ProcessSubmitTransaction(_transactionId);
            }
        }
    }
}
