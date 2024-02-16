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
using System.Xml;
using System.IO;
using System.Data;
using System.Data.Common;
using System.Data.ProviderBase;
using Windsor.Node2008.WNOSPlugin;
using System.Diagnostics;
using System.Reflection;
using Windsor.Node2008.WNOSUtility;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSProviders;
using Spring.Data.Common;
using Windsor.Commons.Core;
using Windsor.Commons.Logging;
using Windsor.Commons.Spring;
using Windsor.Commons.NodeDomain;
using Windsor.Commons.NodeClient;

namespace Windsor.Node2008.WNOSPlugin.Windsor
{
    [Serializable]
    public class UpdateStatusOfNetworkTransactions : BaseWNOSPlugin, ITaskProcessor
    {
        protected const string CHECK_NEWER_THAN_DAYS_KEY = "Check transactions newer than (days)";
        protected const string CHECK_FLOW_NAMES = "Check flow names (semicolon-separated)";
        protected const string DOWNLOAD_TRANSACTION_DOCS = "Download Transaction Docs";

        protected readonly CommonTransactionStatusCode[] _validTransactionStatusFinishedCodes =
            new CommonTransactionStatusCode[] { CommonTransactionStatusCode.Failed,
                                                CommonTransactionStatusCode.Processed,
                                                CommonTransactionStatusCode.Completed };

        public UpdateStatusOfNetworkTransactions()
        {
            ConfigurationArguments.Add(CHECK_NEWER_THAN_DAYS_KEY, "7");
            ConfigurationArguments.Add(CHECK_FLOW_NAMES, "");
            ConfigurationArguments.Add(DOWNLOAD_TRANSACTION_DOCS, "");
        }

        /// <summary>
        /// ProcessTask
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns></returns>
        public virtual void ProcessTask(string requestId)
        {
            IRequestManager requestManager;
            ITransactionManager transactionManager;
            INodeEndpointClientFactory nodeEndpointClientFactory;

            int newerThanDays;
            GetConfigParameter<int>(CHECK_NEWER_THAN_DAYS_KEY, true, out newerThanDays);
            if (newerThanDays <= 0)
            {
                throw new ArgumentException(string.Format("\"{0}\" config parameter must be positive: {1}",
                                                          CHECK_NEWER_THAN_DAYS_KEY, newerThanDays));
            }
            DateTime newerThan = DateTime.Now - TimeSpan.FromDays(newerThanDays);

            string checkFlowNamesString = null;
            TryGetConfigParameter(CHECK_FLOW_NAMES, ref checkFlowNamesString);
            List<string> checkFlowNames = null;
            if (!string.IsNullOrEmpty(checkFlowNamesString))
            {
                checkFlowNames = StringUtils.SplitAndReallyRemoveEmptyEntries(checkFlowNamesString, ';');
            }

            bool downloadTransactionDocs = false;
            TryGetConfigParameter(DOWNLOAD_TRANSACTION_DOCS, ref downloadTransactionDocs);

            GetServiceImplementation(out requestManager);
            GetServiceImplementation(out transactionManager);
            GetServiceImplementation(out nodeEndpointClientFactory);

            if (CollectionUtils.IsNullOrEmpty(checkFlowNames))
            {
                AppendAuditLogEvent("Checking status of all transactions newer than {0} days (newer than {1})",
                                    newerThanDays.ToString(), newerThan.ToString());
            }
            else
            {
                string joinText = StringUtils.JoinCommaEnglish(checkFlowNames);
                AppendAuditLogEvent("Checking status of transactions newer than {0} days (newer than {1}) for flows {2}",
                                    newerThanDays.ToString(), newerThan.ToString(), joinText);
            }

            DataRequest dataRequest = requestManager.GetDataRequest(requestId);

            IList<NodeTransaction> transactions =
                transactionManager.GetOutstandingNetworkTransactions(newerThan, checkFlowNames, _validTransactionStatusFinishedCodes);

            if (CollectionUtils.IsNullOrEmpty(transactions))
            {
                AppendAuditLogEvent("Did not find any transactions that need updating that are newer than {0} days (newer than {1})",
                                    newerThanDays.ToString(), newerThan.ToString());
                return;
            }

            AppendAuditLogEvent("Found {0} transaction(s) that need updating ...", transactions.Count);

            foreach (NodeTransaction transaction in transactions)
            {
                UpdateStatusOfTransaction(transaction, transactionManager, nodeEndpointClientFactory, downloadTransactionDocs);
            }
        }
        protected virtual Exception UpdateStatusOfTransaction(NodeTransaction transaction, ITransactionManager transactionManager,
                                                              INodeEndpointClientFactory nodeEndpointClientFactory,
                                                              bool downloadTransactionDocs)
        {
            CommonTransactionStatusCode statusCode = CommonTransactionStatusCode.NotSpecified;
            using (INodeEndpointClient endpointClient =
                nodeEndpointClientFactory.Make(transaction.NetworkEndpointUrl, transaction.NetworkEndpointVersion))
            {
                Exception exception = null;
                try
                {
                    AppendAuditLogEvent("Attempting to update status of local transaction id \"{0}\" that has endpoint transaction id \"{1}\" and current endpoint transaction status of \"{2}\" at url \"{3}\" and endpoint version \"{4}\" ...",
                                        transaction.Id, transaction.NetworkId, transaction.NetworkEndpointStatus,
                                        transaction.NetworkEndpointUrl, transaction.NetworkEndpointVersion);

                    statusCode = endpointClient.GetStatus(transaction.NetworkId);
                    AppendAuditLogEvent("Successfully got an endpoint transaction status of \"{0}\"", statusCode.ToString());
                    transaction.NetworkEndpointStatus = statusCode;
                }
                catch (Exception e)
                {
                    exception = e;
                    AppendAuditLogEvent("Failed to get status of transaction: {0}", ExceptionUtils.GetDeepExceptionMessage(e));
                }
                if (exception == null && downloadTransactionDocs)
                {
                    AppendAuditLogEvent("Attempting to download documents for local transaction id \"{0}\" that has endpoint transaction id \"{1}\" and current endpoint transaction status of \"{2}\" at url \"{3}\" and endpoint version \"{4}\" ...",
                                        transaction.Id, transaction.NetworkId, transaction.NetworkEndpointStatus,
                                        transaction.NetworkEndpointUrl, transaction.NetworkEndpointVersion);

                    try
                    {
                        AddPartnerTransactionDocumentsToTransaction(transaction.Id, out CommonTransactionStatusCode outEndpointStatus);
                    }
                    catch (Exception e)
                    {
                        exception = e;
                        AppendAuditLogEvent("Failed to download documents for transactionn id \"{0}\" with error: {1}", transaction.Id, ExceptionUtils.GetDeepExceptionMessage(e));
                    }
                }
                if (exception == null)
                {
                    try
                    {
                        if (OnTransactionStatusChanged(transaction, endpointClient, statusCode))
                        {
                            AppendAuditLogEvent("Updating status of local transaction id \"{0}\" from \"{1}\" to \"{2}\"",
                                                transaction.Id, transaction.NetworkEndpointStatus, statusCode);
                            transactionManager.SetNetworkIdStatus(transaction.Id, statusCode);
                        }
                    }
                    catch (Exception e)
                    {
                        exception = e;
                        AppendAuditLogEvent("Failed to update status of transaction \"{0}\" with error: {1}", transaction.Id, ExceptionUtils.GetDeepExceptionMessage(e));
                    }
                }
                return exception;
            }
        }
        protected virtual bool OnTransactionStatusChanged(NodeTransaction transaction, INodeEndpointClient endpointClient,
                                                          CommonTransactionStatusCode newStatusCode)
        {
            return true;
        }
    }
    public class UpdateStatusOfNetworkTransactionsAndExecProc : UpdateStatusOfNetworkTransactions
    {
        protected const string POSTPROCESS_STORED_PROC_NAME = "Postprocess Stored Proc Name";
        protected const string POSTPROCESS_STORED_PROC_DATA_SOURCE = "Postprocess Stored Proc Data Source";
        protected const string p_transaction_id = "p_transaction_id";
        protected const string p_transaction_status = "p_transaction_status";
        protected const string SOURCE_PROVIDER_KEY = "Postprocess Stored Proc Data Source";

        public UpdateStatusOfNetworkTransactionsAndExecProc() : base()
        {
            ConfigurationArguments.Add(POSTPROCESS_STORED_PROC_NAME, "");
            DataProviders.Add(SOURCE_PROVIDER_KEY, null);
        }

        protected override Exception UpdateStatusOfTransaction(NodeTransaction transaction, ITransactionManager transactionManager,
                                                              INodeEndpointClientFactory nodeEndpointClientFactory,
                                                              bool downloadTransactionDocs)
        {
            var exception = base.UpdateStatusOfTransaction(transaction, transactionManager, nodeEndpointClientFactory, downloadTransactionDocs);

            if ((exception == null) && ((transaction.NetworkEndpointStatus == CommonTransactionStatusCode.Failed) || (transaction.NetworkEndpointStatus == CommonTransactionStatusCode.Completed)))
            {
                try
                {
                    string postProcessStoredProcName = null;
                    TryGetConfigParameter(POSTPROCESS_STORED_PROC_NAME, ref postProcessStoredProcName);

                    if (!string.IsNullOrEmpty(postProcessStoredProcName))
                    {
                        var baseDao = ValidateDBProvider(SOURCE_PROVIDER_KEY);

                        ExecutePostProcessStoredProc(baseDao, postProcessStoredProcName, transaction.Id, transaction.NetworkEndpointStatus.ToString(), 600);
                    }
                }
                catch (Exception e)
                {
                    exception = e;
                }
            }
            return exception;
        }
        protected virtual void ExecutePostProcessStoredProc(SpringBaseDao baseDao, string postProcessStoredProcName, string transactionId, string transactionStatus,
                                                            int commandTimeout)
        {
            AppendAuditLogEvent("Executing post processing stored procedure \"{0}\" for transaction id \"{1}\" with transaction status \"{2}\" with timeout of {3} seconds ...",
                                postProcessStoredProcName, transactionId, transactionStatus, commandTimeout.ToString());

            try
            {
                IDbParameters parameters = baseDao.AdoTemplate.CreateDbParameters();
                parameters.AddWithValue(p_transaction_id, transactionId);
                parameters.AddWithValue(p_transaction_status, transactionStatus);

                baseDao.AdoTemplate.Execute<int>(delegate (DbCommand command)
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = postProcessStoredProcName;
                    command.CommandTimeout = commandTimeout;
                    Spring.Data.Support.ParameterUtils.CopyParameters(command, parameters);

                    try
                    {
                        SpringBaseDao.ExecuteCommandWithTimeout(command, commandTimeout, delegate (DbCommand commandToExecute)
                        {
                            commandToExecute.ExecuteNonQuery();
                        });
                    }
                    catch (Exception ex2)
                    {
                        command.Connection.Close();
                        AppendAuditLogEvent("Error returned from stored procedure: {0}", ExceptionUtils.GetDeepExceptionMessage(ex2));
                        throw;
                    }

                    return 0;
                });

                AppendAuditLogEvent("Successfully executed stored procedure \"{0}\"", postProcessStoredProcName);
            }
            catch (Exception e)
            {
                AppendAuditLogEvent("Failed to execute stored procedure \"{0}\" with error: {1}",
                                    postProcessStoredProcName, ExceptionUtils.GetDeepExceptionMessage(e));
                throw;
            }
        }
    }
}
