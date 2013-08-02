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
using Spring.Transaction.Support;
using Spring.Data.Core;
using System.ComponentModel;
using Windsor.Commons.Spring;
using Windsor.Commons.Core;
using Windsor.Commons.NodeDomain;
using Windsor.Commons.NodeClient;
using Windsor.Node2008.WNOSPlugin.RCRA_52;

namespace Windsor.Node2008.WNOSPlugin.GetRCRAInfoData_52
{
    [Serializable]
    public class SolicitRCRAInfoData : BaseGetRCRAInfoData, ITaskProcessor
    {
        protected const string CONFIG_PARTNER_NAME_KEY = "Solicit Partner Name";
        protected const string CONFIG_ENDPOINT_USER_NAME_KEY = "Solicit Endpoint Username";

        protected const string PARAM_SERVICE_NAME_KEY = "serviceName";

        protected IEndpointUserManager _endpointUserManager;
        protected IPartnerManager _partnerManager;

        protected PartnerIdentity _solicitPartner;
        protected string _solicitEndpointUsername;
        protected ByIndexOrNameDictionary<string> _queryParameters;
        protected string _queryServiceName;

        protected readonly string[] DATE_PARAMETER_NAMES = new string[] { "changeDate", "fromDate", "toDate" };

        public SolicitRCRAInfoData()
        {
            ConfigurationArguments.Add(CONFIG_PARTNER_NAME_KEY, null);
            ConfigurationArguments.Add(CONFIG_ENDPOINT_USER_NAME_KEY, null);
        }
        public virtual void ProcessTask(string requestId)
        {
            ProcessSolicitTask(requestId);
        }
        protected virtual void ProcessSolicitTask(string requestId)
        {
            LazyInit();

            ValidateRequest(requestId);

            PerformSolicit();
        }
        protected override void LazyInit()
        {
            base.LazyInit();

            GetServiceImplementation(out _endpointUserManager);
            GetServiceImplementation(out _partnerManager);

            string partnerName;
            GetConfigParameter(CONFIG_PARTNER_NAME_KEY, out partnerName);

            _solicitPartner = GetNetworkPartner(partnerName);

            if (_solicitPartner.Version != EndpointVersionType.EN20)
            {
                throw new ArgumentException(string.Format("The \"{0}\" configuration parameter for this service must reference a {1} node partner, but it is referencing the partner \"{2}\" ({3})",
                                                          CONFIG_PARTNER_NAME_KEY, EnumUtils.ToDescription(EndpointVersionType.EN20),
                                                          _solicitPartner.Name, EnumUtils.ToDescription(_solicitPartner.Version)));
            }

            TryGetConfigParameter(CONFIG_ENDPOINT_USER_NAME_KEY, ref _solicitEndpointUsername);
        }
        protected override void ValidateRequest(string requestId)
        {
            base.ValidateRequest(requestId);

            _queryParameters = ParseQueryParameters(_dataRequest.Parameters, out _queryServiceName);
        }
        protected virtual ByIndexOrNameDictionary<string> ParseQueryParameters(ByIndexOrNameDictionary<string> parameters, out string serviceName)
        {
            ByIndexOrNameDictionary<string> queryParameters = null;
            serviceName = null;

            if (CollectionUtils.IsNullOrEmpty(parameters))
            {
                throw new ArgumentException(string.Format("No parameters were passed to the service.  You must pass at least the \"{0}\" parameter.",
                                                          PARAM_SERVICE_NAME_KEY));
            }
            if (!parameters.IsByName)
            {
                throw new ArgumentException("The parameters to the service are \"by-index,\" but they must be \"by-name\"");
            }

            queryParameters = new ByIndexOrNameDictionary<string>(true);

            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, string> pair in parameters.NameValuePairs)
            {
                if (string.Equals(pair.Key, PARAM_SERVICE_NAME_KEY, StringComparison.OrdinalIgnoreCase))
                {
                    if (serviceName != null)
                    {
                        throw new ArgumentException(string.Format("More than one \"{0}\" parameter was passed to the service: \"{1}\" and \"{2}\"",
                                                                  PARAM_SERVICE_NAME_KEY, serviceName, pair.Key));
                    }
                    if (string.IsNullOrEmpty(pair.Value))
                    {
                        throw new ArgumentException(string.Format("The \"{0}\" parameter passed to the service is empty",
                                                                  PARAM_SERVICE_NAME_KEY));
                    }
                    if (!IsValidServiceName(pair.Value))
                    {
                        throw new ArgumentException(string.Format("The \"{0}\" parameter value is not supported: \"{1}\"",
                                                                  PARAM_SERVICE_NAME_KEY, pair.Value));
                    }
                    serviceName = pair.Value;
                }
                else
                {
                    if (CollectionUtils.Contains(DATE_PARAMETER_NAMES, pair.Key, StringComparison.OrdinalIgnoreCase))
                    {
                        DateTime dateTime;
                        if (TryParseNowDate(pair.Value, out dateTime))
                        {
                            queryParameters.Add(pair.Key, dateTime.ToString("yyyy-MM-dd"));
                        }
                        else
                        {
                            throw new ArgumentException(string.Format("The \"{0}\" parameter value cannot be parsed: \"{1}\"",
                                                                      PARAM_SERVICE_NAME_KEY, pair.Value));
                        }
                    }
                    else
                    {
                        queryParameters.Add(pair.Key, pair.Value);
                    }
                    if (sb.Length > 0)
                    {
                        sb.Append(", ");
                    }
                    int index = queryParameters.Count - 1;
                    sb.AppendFormat("{0} ({1})", pair.Key, queryParameters[pair.Key]);
                }
            }
            if (serviceName == null)
            {
                throw new ArgumentException(string.Format("A \"{0}\" parameter was not passed to the service", PARAM_SERVICE_NAME_KEY));
            }
            if (!CollectionUtils.IsNullOrEmpty(queryParameters))
            {
                AppendAuditLogEvent("Query parameters: {0}", sb.ToString());
            }
            else
            {
                AppendAuditLogEvent("No query parameters were specified");
            }

            return queryParameters;
        }
        protected virtual string PerformSolicit()
        {
            string transactionId;

            AppendAuditLogEvent("Soliciting endpoint \"{0}\" at url \"{1}\" with flow name \"{2}\" and service name \"{3}\"",
                                _solicitPartner.Name, _solicitPartner.Url, NETWORK_RCRA_FLOW_NAME, _queryServiceName);

            try
            {
                using (INodeEndpointClient endpointClient =
                    _endpointUserManager.GetNodeEndpointClient(_solicitPartner.Url, _solicitPartner.Version, _solicitEndpointUsername))
                {
                    transactionId = endpointClient.Solicit(NETWORK_RCRA_FLOW_NAME, _queryServiceName, _queryParameters);
                }
                AppendAuditLogEvent("Successfully solicited the node endpoint \"{0}\" with returned transaction id \"{1}\"",
                                    _solicitPartner.Name, transactionId);
            }
            catch (Exception e)
            {
                AppendAuditLogEvent("Failed to solicit the node endpoint \"{0}\" with exception: {1}",
                                    _solicitPartner.Name, ExceptionUtils.GetDeepExceptionMessage(e));
                throw;
            }
            _endpointUserManager.SetNetworkEndpointTransactionInfo(_dataRequest.TransactionId, transactionId, _solicitPartner.Version,
                                                                    _solicitPartner.Url, NETWORK_RCRA_FLOW_NAME, _queryServiceName,
                                                                    _solicitEndpointUsername);
            return transactionId;
        }
    }
}