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
        private const string CHECK_NEWER_THAN_DAYS_KEY = "Check transactions newer than (days)";
        private readonly CommonTransactionStatusCode[] _validTransactionStatusFinishedCodes = 
            new CommonTransactionStatusCode[] { CommonTransactionStatusCode.Failed, CommonTransactionStatusCode.Processed,
                                                CommonTransactionStatusCode.Completed };

        public UpdateStatusOfNetworkTransactions()
        {
            ConfigurationArguments.Add(CHECK_NEWER_THAN_DAYS_KEY, "7");
        }

        /// <summary>
        /// ProcessTask
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns></returns>
        public void ProcessTask(string requestId)
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

            GetServiceImplementation(out requestManager);
            GetServiceImplementation(out transactionManager);
            GetServiceImplementation(out nodeEndpointClientFactory);

            AppendAuditLogEvent("Checking status of all transactions newer than {0} days (newer than {1})",
                                newerThanDays, newerThan);

            DataRequest dataRequest = requestManager.GetDataRequest(requestId);

            IList<NodeTransaction> transactions = 
                transactionManager.GetOutstandingNetworkTransactions(newerThan, _validTransactionStatusFinishedCodes);

            if (CollectionUtils.IsNullOrEmpty(transactions))
            {
                AppendAuditLogEvent("Did not find any transactions that need updating that are newer than {0} days (newer than {1})",
                                    newerThanDays, newerThan);
                return;
            }

            AppendAuditLogEvent("Found {0} transaction(s) that need updating ...", transactions.Count);

            foreach (NodeTransaction transaction in transactions)
            {
                UpdateStatusOfTransaction(transaction, transactionManager, nodeEndpointClientFactory);
            }
        }
        private void UpdateStatusOfTransaction(NodeTransaction transaction, ITransactionManager transactionManager,
                                               INodeEndpointClientFactory nodeEndpointClientFactory)
        {
            try
            {
                AppendAuditLogEvent("Attempting to update status of local transaction id \"{0}\" that has endpoint transaction id \"{1}\" and current endpoint transaction status of \"{2}\" at url \"{3}\" and endpoint version \"{4}\" ...",
                                    transaction.Id, transaction.NetworkId, transaction.NetworkEndpointStatus,
                                    transaction.NetworkEndpointUrl, transaction.NetworkEndpointVersion);

                CommonTransactionStatusCode statusCode;
                using (INodeEndpointClient endpointClient =
                    nodeEndpointClientFactory.Make(transaction.NetworkEndpointUrl, transaction.NetworkEndpointVersion))
                {
                    statusCode = endpointClient.GetStatus(transaction.NetworkId);
                }
                AppendAuditLogEvent("Successfully got an endpoint transaction status of \"{0}\"", statusCode.ToString());
                if (statusCode != transaction.NetworkEndpointStatus)
                {
                    AppendAuditLogEvent("Updating status of transaction from \"{0}\" to \"{1}\"",
                                        transaction.NetworkEndpointStatus, statusCode);
                    transactionManager.SetNetworkIdStatus(transaction.Id, statusCode);
                }
            }
            catch (Exception e)
            {
                AppendAuditLogEvent("Failed to get status of transaction: {0}", ExceptionUtils.GetDeepExceptionMessage(e));
            }
        }
    }
}
