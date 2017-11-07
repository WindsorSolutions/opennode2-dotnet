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
using Windsor.Node2008.WNOSPlugin.RCRA_55;

namespace Windsor.Node2008.WNOSPlugin.GetRCRAInfoData_55
{
    [Serializable]
    public class BaseGetRCRAInfoData : BaseWNOSPlugin
    {
        public const string NETWORK_RCRA_FLOW_NAME = "RCRA";

        protected IRequestManager _requestManager;
        protected ITransactionManager _transactionManager;

        protected DataRequest _dataRequest;

        private Dictionary<string, Type> _serviceNameToTypeMap;

        public BaseGetRCRAInfoData()
        {
        }
        protected virtual void LazyInit()
        {
            AppendAuditLogEvent("Initializing {0} plugin ...", this.GetType().Name);

            GetServiceImplementation(out _requestManager);
            GetServiceImplementation(out _transactionManager);
        }
        protected virtual void ValidateRequest(string requestId)
        {
            AppendAuditLogEvent("Loading request with id \"{0}\"", requestId);
            _dataRequest = _requestManager.GetDataRequest(requestId);

            AppendAuditLogEvent("Validating request: {0}", _dataRequest);
        }
        protected bool IsValidServiceName(string serviceName)
        {
            if (string.IsNullOrEmpty(serviceName))
            {
                return false;
            }

            ValidateServiceNameToTypeMap();

            return _serviceNameToTypeMap.ContainsKey(serviceName.ToUpper());
        }
        protected Type GetServiceXmlType(string serviceName)
        {
            if (string.IsNullOrEmpty(serviceName))
            {
                return null;
            }

            ValidateServiceNameToTypeMap();

            Type rtnType;
            _serviceNameToTypeMap.TryGetValue(serviceName.ToUpper(), out rtnType);

            return rtnType;
        }
        private void ValidateServiceNameToTypeMap()
        {
            if (_serviceNameToTypeMap == null)
            {
                _serviceNameToTypeMap = new Dictionary<string, Type>();
                _serviceNameToTypeMap["GetHDDataByState".ToUpper()] =
                    typeof(HazardousWasteHandlerSubmissionDataType);
                _serviceNameToTypeMap["GetCEDataByState".ToUpper()] =
                    typeof(HazardousWasteCMESubmissionDataType);
                _serviceNameToTypeMap["GetCADataByState".ToUpper()] =
                    typeof(HazardousWasteCorrectiveActionDataType);
                _serviceNameToTypeMap["GetGSDataByState".ToUpper()] =
                    typeof(GeographicInformationSubmissionDataType);
                _serviceNameToTypeMap["GetPMDataByState".ToUpper()] =
                    typeof(HazardousWastePermitDataType);
                _serviceNameToTypeMap["GetFADataByState".ToUpper()] =
                    typeof(FinancialAssuranceSubmissionDataType);
            }
        }
    }
}