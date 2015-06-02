//#define DONT_USE_AUTH_FILE
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
using Windsor.Commons.Core;
using Windsor.Node2008.WNOSPlugin.WQX2XsdOrm;
using Windsor.Commons.XsdOrm;
using Windsor.Commons.NodeDomain;

namespace Windsor.Node2008.WNOSPlugin.WQX2
{
    [Serializable]
    public class WQXExecuteSchedule : BaseWNOSPlugin, IQueryProcessor
    {
        protected const string CONFIG_SCHEDULE_NAME_KEY = "Schedule Name";
        
        protected IRequestManager _requestManager;
        protected IScheduleManager _scheduleManager;
        protected ISerializationHelper _serializationHelper;
        protected ITransactionManager _transactionManager;
       
        protected string _scheduleName;
        protected string _organizationIdentifier;
        protected DataRequest _dataRequest;

        public WQXExecuteSchedule()
        {
            ConfigurationArguments.Add(CONFIG_SCHEDULE_NAME_KEY, null);
        }

        protected virtual void LazyInit()
        {
            AppendAuditLogEvent("Initializing WQXExecuteSchedule plugin ...");

            GetServiceImplementation(out _requestManager);
            GetServiceImplementation(out _scheduleManager);
            GetServiceImplementation(out _serializationHelper);
            GetServiceImplementation(out _transactionManager);

            _scheduleName = ValidateNonEmptyConfigParameter(CONFIG_SCHEDULE_NAME_KEY);
        }

        protected virtual void ValidateRequest(string requestId)
        {
            AppendAuditLogEvent("Loading request with id \"{0}\"", requestId);
            _dataRequest = _requestManager.GetDataRequest(requestId);

            AppendAuditLogEvent("Validating request: {0}", _dataRequest);
            GetParameter(_dataRequest, WQXExecuteScheduleQueryParameters.PARAM_ORGANIZATION_IDENTIFIER_KEY, 
                         0, out _organizationIdentifier);
        }

        public virtual PaginatedContentResult ProcessQuery(string requestId)
        {
            LazyInit();

            ValidateRequest(requestId);

            var parameters = new Dictionary<string, string>();
            parameters[WQXPluginBase.PARAM_ORGANIZATION_IDENTIFIER_KEY] = _organizationIdentifier;
            string executionInfo, transactionId;

            AppendAuditLogEvent("Executing schedule \"{0}\" for WQX organization \"{1}\"", _scheduleName, _organizationIdentifier);

            var scheduledItem = _scheduleManager.ExecuteSchedule(_scheduleName, parameters, out transactionId, out executionInfo);

            AppendAuditLogEvent("Successfully executed schedule \"{0}\" for WQX organization \"{1}\"", _scheduleName, _organizationIdentifier);

            var resultData = new WQXExecuteScheduleResult();
            resultData.LocalTransactionId = transactionId;
            CommonTransactionStatusCode status;
            EndpointVersionType endpointVersion;
            string endpointUrl;
            resultData.NetworkTransactionId =
                _transactionManager.GetNetworkTransactionStatus(transactionId, out status, out endpointVersion, out endpointUrl);
            resultData.NodeEndpointUrl = endpointUrl;
            resultData.NodeEndpointVersion = endpointVersion;
            resultData.ActivityDetails = executionInfo;

            var bytes = _serializationHelper.Serialize(resultData);

            File.WriteAllBytes(@"D:\Temp\Exec.xml", bytes);
            PaginatedContentResult result = new PaginatedContentResult(0, 1, true, CommonContentType.XML, bytes);
            return result;
        }
    }
}
