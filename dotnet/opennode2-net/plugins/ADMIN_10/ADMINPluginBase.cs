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
using System.Xml;
using System.IO;
using System.Data;
using System.Xml.Serialization;
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
using System.Runtime.InteropServices;
using System.ComponentModel;
using Windsor.Commons.Core;
using Windsor.Commons.Logging;
using Windsor.Commons.Spring;
using Windsor.Commons.XsdOrm;
using Windsor.Commons.NodeDomain;
using Windsor.Node2008.WNOSDomain.TransactionTracking;

namespace Windsor.Node2008.WNOSPlugin.ADMIN_10
{
    [Serializable]
    public abstract class ADMINPluginBase : BaseWNOSPlugin, IQueryProcessor, ISolicitProcessor
    {
        protected static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());

        protected ISerializationHelper _serializationHelper;
        protected ICompressionHelper _compressionHelper;
        protected IDocumentManager _documentManager;
        protected ISettingsProvider _settingsProvider;
        protected IRequestManager _requestManager;
        protected ITransactionManager _transactionManager;
        protected DataRequest _dataRequest;
        protected List<KeyValuePair<TransactionTrackingQueryParameter, object>> _serviceParameters;

        public ADMINPluginBase()
        {
        }

        /// <summary>
        /// ProcessSolicit
        /// </summary>
        public virtual void ProcessSolicit(string requestId)
        {
            ProcessInit(requestId);

            GetServiceDataAndAddToTransaction();
        }

        /// <summary>
        /// ProcessQuery
        /// </summary>
        public virtual PaginatedContentResult ProcessQuery(string requestId)
        {
            ProcessInit(requestId);

            string filePath = GetServiceDataAndAddToTransaction();

            PaginatedContentResult result = new PaginatedContentResult(filePath);

            return result;
        }

        protected abstract object GetServiceData();

        protected virtual string GetServiceDataAndAddToTransaction()
        {
            object data = GetServiceData();

            string filePath = 
                SerializeDataAndAddToTransaction(data, _settingsProvider, _serializationHelper, _compressionHelper,
                                                 _documentManager, _dataRequest.TransactionId);

            return filePath;
        }

        protected virtual void LazyInit()
        {
            AppendAuditLogEvent("Initializing {0} plugin ...", this.GetType().Name);

            GetServiceImplementation(out _serializationHelper);
            GetServiceImplementation(out _compressionHelper);
            GetServiceImplementation(out _documentManager);
            GetServiceImplementation(out _settingsProvider);
            GetServiceImplementation(out _requestManager);
            GetServiceImplementation(out _transactionManager);
        }
        protected virtual void ValidateRequest(string requestId)
        {
            AppendAuditLogEvent("Loading request with id \"{0}\"", requestId);
            _dataRequest = _requestManager.GetDataRequest(requestId);

            AppendAuditLogEvent("Validating request: {0}", _dataRequest);

            GetServiceParameters();
        }
        protected virtual void ProcessInit(string requestId)
        {
            LazyInit();

            ValidateRequest(requestId);
        }
        protected virtual object GetServiceParameterValue(TransactionTrackingQueryParameter key)
        {
            object value = null;
            CollectionUtils.ForEachBreak(_serviceParameters, delegate(KeyValuePair<TransactionTrackingQueryParameter, object> pair)
            {
                if (pair.Key == key)
                {
                    value = pair.Value;
                    return false;
                }
                return true;
            });
            return value;
        }
        protected virtual void GetServiceParameters()
        {
            Dictionary<TransactionTrackingQueryParameter, object> serviceParameters = 
                new Dictionary<TransactionTrackingQueryParameter, object>();

            IList<TransactionTrackingQueryParameter> possibleParameters = EnumUtils.GetAllEnumValues<TransactionTrackingQueryParameter>();
            bool transactionIdSpecified = false;
            DateTime fromDate = DateTime.MinValue, toDate = DateTime.MaxValue;
            for (int i = 0; i < possibleParameters.Count; ++i)
            {
                TransactionTrackingQueryParameter parameter = possibleParameters[i];
                object parameterValue = null;
                if (TryGetParameter(_dataRequest, possibleParameters[i].ToString(), i,
                                    ref parameterValue))
                {
                    switch (parameter)
                    {
                        case TransactionTrackingQueryParameter.fromDate:
                        case TransactionTrackingQueryParameter.toDate:
                            {
                                DateTime date;
                                if (!DateTime.TryParse(parameterValue.ToString(), out date))
                                {
                                    throw new ArgumentException(string.Format("Failed to convert the \"{0}\" parameter value \"{1}\" to a valid date.",
                                                                              parameter.ToString(), parameterValue.ToString()));
                                }
                                parameterValue = date;
                                if (parameter == TransactionTrackingQueryParameter.fromDate)
                                {
                                    fromDate = date;
                                }
                                else
                                {
                                    toDate = date;
                                }
                            }
                            break;
                        case TransactionTrackingQueryParameter.Status:
                            {
                                CommonTransactionStatusCode status;
                                try
                                {
                                    status = (CommonTransactionStatusCode)Enum.Parse(typeof(CommonTransactionStatusCode), parameterValue.ToString(), true);
                                }
                                catch (Exception)
                                {
                                    throw new ArgumentException(string.Format("Failed to convert the \"{0}\" parameter value \"{1}\" to a valid status code.",
                                                                              parameter.ToString(), parameterValue.ToString()));
                                }
                                parameterValue = status;
                            }
                            break;
                        case TransactionTrackingQueryParameter.Type:
                            {
                                NodeMethod type;
                                try
                                {
                                    type = (NodeMethod)Enum.Parse(typeof(NodeMethod), parameterValue.ToString(), true);
                                }
                                catch (Exception)
                                {
                                    throw new ArgumentException(string.Format("Failed to convert the \"{0}\" parameter value \"{1}\" to a valid transaction type.",
                                                                              parameter.ToString(), parameterValue.ToString()));
                                }
                                parameterValue = type;
                            }
                            break;
                        case TransactionTrackingQueryParameter.TransactionId:
                            transactionIdSpecified = true;
                            goto case TransactionTrackingQueryParameter.Dataflow;
                        case TransactionTrackingQueryParameter.Dataflow:
                        case TransactionTrackingQueryParameter.Organization:
                        case TransactionTrackingQueryParameter.Recipients:
                        case TransactionTrackingQueryParameter.Userid:
                            {
                                string value = parameterValue.ToString().Trim();
                                parameterValue = string.IsNullOrEmpty(value) ? null : value;
                            }
                            break;
                        default:
                            parameterValue = null;  // Unrecognized
                            break;
                    }
                    if (parameterValue != null)
                    {
                        if (serviceParameters.ContainsKey(parameter))
                        {
                            throw new ArgumentException(string.Format("More than one instance of the parameter \"{0}\" was specified: \"{1}\" and \"{2}\".  Please remove the duplicated query parameters.",
                                                                      parameter.ToString(), serviceParameters[parameter].ToString(), parameterValue.ToString()));
                        }
                        serviceParameters[parameter] = parameterValue;
                    }
                }
            }
            if (serviceParameters.Count > 0)
            {
                if (transactionIdSpecified && (serviceParameters.Count > 1))
                {
                    throw new ArgumentException(string.Format("The \"{0}\" parameter must be the only query parameter specified.  Please remove the other query parameters.",
                                                              TransactionTrackingQueryParameter.TransactionId.ToString()));
                }
                if (fromDate >= toDate)
                {
                    throw new ArgumentException(string.Format("\"{0}\" must be before \"{1}\"", TransactionTrackingQueryParameter.fromDate.ToString(),
                                                TransactionTrackingQueryParameter.toDate.ToString()));
                }
                StringBuilder sb = new StringBuilder("The following query parameters were passed to the service: ");
                _serviceParameters = new List<KeyValuePair<TransactionTrackingQueryParameter, object>>(serviceParameters.Count);
                bool first = true;
                foreach (KeyValuePair<TransactionTrackingQueryParameter, object> pair in serviceParameters)
                {
                    if (!first)
                    {
                        sb.Append(", ");
                    }
                    else
                    {
                        first = false;
                    }
                    sb.AppendFormat("{0} ({1})", pair.Key.ToString(), pair.Value.ToString());
                    _serviceParameters.Add(pair);
                }
                AppendAuditLogEvent(sb.ToString());
            }
            else
            {
                AppendAuditLogEvent("No query parameters were passed to the service.");
            }
        }
    }
}
