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

            NodeTransaction transaction = _transactionManager.GetTransaction(transactionId);
            if (transaction == null)
            {
                throw new ArgumentException(string.Format("Could not locate local transaction \"{0}\"", 
                                                          transactionId));
            }

            _didSubmit = !string.IsNullOrEmpty(transaction.NetworkEndpointUrl);

            _submitFlowName = transaction.Flow.FlowName;

            if (transaction.EndpointVersion == EndpointVersionType.EN11)
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
                _submitOperationName = transaction.Operation;
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

            SubmitTransactionDocumentsToPartner(transactionId, _submitPartner, _submitFlowName, _submitOperationName);
        }
    }
    public abstract class SubmitProxyPluginEx : SubmitProxyPlugin, ISubmitProcessorEx
    {
        private static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());

        protected SubmitProxyPluginEx()
        {
        }
        public virtual CommonTransactionStatusCode ProcessSubmitAndReturnStatus(string transactionId, 
                                                                                out string statusDetail)
        {
            Init(transactionId);

            statusDetail = string.Empty;

            if (_didSubmit)
            {
                CommonTransactionStatusCode networkTransactionStatus;

                AddPartnerTransactionDocumentsToTransaction(transactionId, out networkTransactionStatus);

                if ((networkTransactionStatus == CommonTransactionStatusCode.Failed) ||
                    (networkTransactionStatus == CommonTransactionStatusCode.Completed))
                {
                    return networkTransactionStatus;
                }
            }
            else
            {
                SubmitTransactionDocumentsToPartner(transactionId, _submitPartner, _submitFlowName, 
                                                    _submitOperationName);
            }
            return CommonTransactionStatusCode.Pending;
        }
    }
}
