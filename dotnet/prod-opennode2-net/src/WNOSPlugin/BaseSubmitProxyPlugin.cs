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
using System.Text;
using System.Data;
using System.Data.Common;
using System.Reflection;
using System.IO;
using Spring.Data.Generic;
using Spring.Context;
using Spring.Context.Support;
using Spring.Objects.Factory;
using Common.Logging;
using Spring.Data.Common;
using Windsor.Node2008.WNOSUtility;
using Windsor.Node2008.WNOSProviders;
using Windsor.Node2008.WNOSDomain;
using Windsor.Commons.Core;
using Windsor.Commons.Logging;
using Windsor.Commons.Spring;
using System.Xml;
using System.Threading;

using Windsor.Commons.NodeDomain;
using System.ComponentModel;
using Windsor.Commons.NodeClient;

namespace Windsor.Node2008.WNOSPlugin
{
    public abstract class BaseSubmitProxyPlugin : BaseWNOSPlugin
    {
        protected enum ConfigParams
        {
            None,
            [Description("Submission Network Partner v1.1 Name")]
            PartnerName11,
            [Description("Submission Network Partner v2.0 Name")]
            PartnerName20,
        }
        private static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());

        protected PartnerIdentity _submitPartner;
        protected string _submitFlowName;
        protected string _submitOperationName;
        protected bool _didSubmit;

        protected ITransactionManager _transactionManager;
        protected ISettingsProvider _settingsProvider;
        protected NodeTransaction _transaction;

        protected BaseSubmitProxyPlugin()
        {
            AppendConfigArguments<ConfigParams>();
        }

        protected virtual void Init(string transactionId)
        {
            LazyInit(transactionId);
        }

        protected virtual void LazyInit(string transactionId)
        {
            AppendAuditLogEvent("Initializing {0} plugin ...", this.GetType().Name);

            GetServiceImplementation(out _transactionManager);
            GetServiceImplementation(out _settingsProvider);

            _transaction = _transactionManager.GetTransaction(transactionId);
            if (_transaction == null)
            {
                throw new ArgumentException(string.Format("Could not locate local transaction \"{0}\"", 
                                                          transactionId));
            }

            _didSubmit = !string.IsNullOrEmpty(_transaction.NetworkEndpointUrl);

            _submitFlowName = _transaction.Flow.FlowName;

            if (_transaction.EndpointVersion == EndpointVersionType.EN11)
            {
                _submitPartner = GetConfigNetworkPartner(EnumUtils.ToDescription(ConfigParams.PartnerName11));
                if (_submitPartner.Version != EndpointVersionType.EN11)
                {
                    throw new ArgumentException(string.Format("The {0} \"{1}\" is not a {2} partner", 
                                                              EnumUtils.ToDescription(ConfigParams.PartnerName11),
                                                              _submitPartner.Name, 
                                                              EnumUtils.ToDescription(_submitPartner.Version)));
                }
            }
            else
            {
                _submitPartner = GetConfigNetworkPartner(EnumUtils.ToDescription(ConfigParams.PartnerName20));
                if (_submitPartner.Version != EndpointVersionType.EN20)
                {
                    throw new ArgumentException(string.Format("The {0} \"{1}\" is not a {2} partner", 
                                                              EnumUtils.ToDescription(ConfigParams.PartnerName20),
                                                              _submitPartner.Name, 
                                                              EnumUtils.ToDescription(_submitPartner.Version)));
                }
                _submitOperationName = _transaction.Operation;
                if (string.Equals(_submitPartner.Url, _settingsProvider.Endpoint11Url, 
                                  StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(_submitPartner.Url, _settingsProvider.Endpoint20Url,
                                  StringComparison.OrdinalIgnoreCase))
                {
                    throw new ArgumentException(string.Format("The {0} plugin has been configured to submit to itself",
                                                              this.GetType().Name));
                }
            }
        }
    }
    public abstract class SubmitProxyPlugin : BaseSubmitProxyPlugin, ISubmitProcessor
    {
        private static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());

        protected SubmitProxyPlugin()
        {
        }
        public virtual void ProcessSubmit(string transactionId)
        {
            Init(transactionId);

            SubmitTransactionDocumentToPartner(transactionId, _submitPartner, _submitFlowName, _submitOperationName);
        }
    }
    public abstract class SubmitProxyPluginEx : SubmitProxyPlugin, ISubmitProcessorEx
    {
        private static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());
        private static int _checkStatusForNumDays = 2;
        private static int _checkStatusIntervalInMinutes = 5;

        protected const string CONFIG_CHECK_STATUS_NUM_DAYS = "Check Status Num Days (default: 2)";
        protected const string CONFIG_CHECK_STATUS_INTERVAL = "Check Status Interval (in minutes, default: 5)";

        protected const string SUBMISSION_CHECK_STATUS_INFO_FILE_NAME = "CheckStatusInfo.xml";

        protected IDocumentManager _documentManager;
        protected ISerializationHelper _serializationHelper;

        protected SubmitProxyPluginEx()
        {
            ConfigurationArguments.Add(CONFIG_CHECK_STATUS_NUM_DAYS, null);
            ConfigurationArguments.Add(CONFIG_CHECK_STATUS_INTERVAL, null);
        }
        protected override void LazyInit(string transactionId)
        {
            base.LazyInit(transactionId);

            GetServiceImplementation(out _documentManager);
            GetServiceImplementation(out _serializationHelper);

            TryGetConfigParameter(CONFIG_CHECK_STATUS_NUM_DAYS, ref _checkStatusForNumDays);
            if (_checkStatusForNumDays < 0)
            {
                throw new ArgumentException(string.Format("Invalid \"{0}\" config parameter specified: {1}",
                                                          CONFIG_CHECK_STATUS_NUM_DAYS, _checkStatusForNumDays.ToString()));
            }
            TryGetConfigParameter(CONFIG_CHECK_STATUS_INTERVAL, ref _checkStatusIntervalInMinutes);
            if (_checkStatusIntervalInMinutes < 1)
            {
                throw new ArgumentException(string.Format("Invalid \"{0}\" config parameter specified: {1}",
                                                          CONFIG_CHECK_STATUS_INTERVAL, _checkStatusIntervalInMinutes.ToString()));
            }
        }
        public virtual CommonTransactionStatusCode ProcessSubmitAndReturnStatus(string transactionId, 
                                                                                out string statusDetail)
        {
            Init(transactionId);

            statusDetail = string.Empty;

            if (_didSubmit)
            {
                CheckStatusInfo checkStatusInfo = ValidateCheckStatusInfo();

                if (checkStatusInfo != null)
                {
                    try
                    {
                        CommonTransactionStatusCode networkTransactionStatus;

                        AddPartnerTransactionDocumentsToTransaction(transactionId, out networkTransactionStatus);

                        checkStatusInfo.LastCheckStatusTime = DateTime.Now;
                        SaveCheckStatusInfo(checkStatusInfo);

                        if ((networkTransactionStatus == CommonTransactionStatusCode.Failed) ||
                            (networkTransactionStatus == CommonTransactionStatusCode.Completed))
                        {
                            return networkTransactionStatus;
                        }
                    }
                    catch (Exception)
                    {
                        // Will try again on next submit call
                        // TODO: Need to check for network exception and try again
                        throw;
                    }
                }
            }
            else
            {
                SubmitTransactionDocumentToPartner(transactionId, _submitPartner, _submitFlowName, 
                                                   _submitOperationName);
                
                SaveCheckStatusInfo();
                
                if (_checkStatusForNumDays == 0)
                {
                    // This means don't check status at all
                    return CommonTransactionStatusCode.Completed;
                }
            }
            return CommonTransactionStatusCode.Pending;
        }
        protected virtual void SaveCheckStatusInfo()
        {
            SaveCheckStatusInfo(new CheckStatusInfo(DateTime.Now));
        }
        protected virtual void SaveCheckStatusInfo(CheckStatusInfo info)
        {
            byte[] content = _serializationHelper.SerializeWithLineBreaks(info);
            Document doc = new Document(SUBMISSION_CHECK_STATUS_INFO_FILE_NAME, CommonContentType.XML, content);
            doc.DontAutoCompress = true;
            Document existingDoc = null;
            try
            {
                existingDoc = _documentManager.GetDocumentByName(_transaction.Id, SUBMISSION_CHECK_STATUS_INFO_FILE_NAME, false);
            }
            catch (FileNotFoundException)
            {
            }
            if (existingDoc != null)
            {
                _documentManager.DeleteDocument(_transaction.Id, existingDoc.Id);
            }
            _documentManager.AddDocument(_transaction.Id, CommonTransactionStatusCode.Completed, string.Empty, doc);
        }
        protected virtual CheckStatusInfo ValidateCheckStatusInfo()
        {
            Document existingDoc;
            try
            {
                existingDoc = _documentManager.GetDocumentByName(_transaction.Id, SUBMISSION_CHECK_STATUS_INFO_FILE_NAME, true);
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException(string.Format("The transaction is missing the required \"{0}\" attached document",
                                                              SUBMISSION_CHECK_STATUS_INFO_FILE_NAME));
            }
            CheckStatusInfo info = _serializationHelper.Deserialize<CheckStatusInfo>(existingDoc.Content);
            DateTime now = DateTime.Now;

            DateTime earliestSubmitTime = now.AddDays(-_checkStatusForNumDays);
            if (info.SubmitTime < earliestSubmitTime)
            {
                // Exceeded number of check days
                throw new ArgumentException("The remote transaction has not completed in the required amount of time.");
            }

            DateTime nextCheckTime = info.LastCheckStatusTime.AddMinutes(_checkStatusIntervalInMinutes);
            if (nextCheckTime > now)
            {
                // Not ready to check again yet
                return null;
            }
            return info;
        }
    }
    [Serializable]
    public class CheckStatusInfo
    {
        public CheckStatusInfo()
        {
        }
        public CheckStatusInfo(DateTime submitTime)
        {
            SubmitTime = LastCheckStatusTime = submitTime;
        }
        public DateTime SubmitTime;
        public DateTime LastCheckStatusTime;
    }
}
