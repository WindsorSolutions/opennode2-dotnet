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

using System.IO;
using System.Xml;
using System.Text;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.Common;
using Windsor.Node2008.WNOSPlugin;
using Spring.Data.Common;
using Spring.Transaction.Support;
using Spring.Data.Core;
using Windsor.Commons.Core;
using Windsor.Commons.Logging;
using Windsor.Commons.Spring;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSProviders;
using Windsor.Commons.NodeDomain;
using Windsor.Node2008.WNOSPlugin.AQSCommon;

namespace Windsor.Node2008.WNOSPlugin.AQSAirVision
{
    public class GetAQSXmlData : AQSBaseHeaderPlugin, IQueryProcessor, ISolicitProcessor
    {
        // Config arguments:
        protected const string CONFIG_WEB_SERVICE_URL = "AirVision Web Service Url";
        protected const string CONFIG_WEB_SERVICE_TIMEOUT = "Web Service Timeout (in seconds)";

        // Service parameters:

        protected const string PARAM_AGENCY_CODE = "AgencyCode";
        protected const string PARAM_SITE_CODE = "SiteCode";
        protected const string PARAM_PARAMETER_CODE = "ParameterCode";
        protected const string PARAM_DURATION_CODE = "DurationCode";
        protected const string PARAM_OCCURRENCE_CODE = "OccurrenceCode";
        protected const string PARAM_STATE_CODE = "StateCode";
        protected const string PARAM_COUNTY_TRIBAL_CODE = "CountyTribalCode";

        protected const string PARAM_START_TIME = "StartTime";
        protected const string PARAM_END_TIME = "EndTime";
        protected const string PARAM_SCHEMA_VERSION = "AQSXMLSchemaVersion";
        protected const string PARAM_SEND_RD_TRANSACTIONS = "SendRDTransactions";
        protected const string PARAM_SEND_RB_TRANSACTIONS = "SendRBTransactions";
        protected const string PARAM_SEND_RA_TRANSACTIONS = "SendRATransactions";
        protected const string PARAM_SEND_RP_TRANSACTIONS = "SendRPTransactions";
        protected const string PARAM_SEND_ONLY_QA_DATA = "SendOnlyQAData";
      
        protected IRequestManager _requestManager;

        protected DataRequest _dataRequest;
        protected string _webServiceUrl = "http://173.10.212.9:9889/AirVision.Services.WebServices.AQSXml/AQSXmlService/";
        protected int _webServiceTimeoutInSeconds = 60 * 10;
        protected AQSWebServiceArgument _webServiceQueryArguments;

        public GetAQSXmlData()
        {
            ConfigurationArguments.Add(CONFIG_WEB_SERVICE_URL, null);
            ConfigurationArguments.Add(CONFIG_WEB_SERVICE_TIMEOUT, null);
        }

        public virtual PaginatedContentResult ProcessQuery(string requestId)
        {
            Init(requestId);

            string zipFilePath = GetDataAndAddToTransaction();

            PaginatedContentResult result = 
                new PaginatedContentResult(0, 1, true, CommonContentType.ZIP, File.ReadAllBytes(zipFilePath));

            return result;
        }
        public virtual void ProcessSolicit(string requestId)
        {
            Init(requestId);

            GetDataAndAddToTransaction();
        }
        protected virtual void Init(string requestId)
        {
            LazyInit();

            ValidateRequest(requestId);
        }
        protected override void LazyInit()
        {
            base.LazyInit();

            GetServiceImplementation(out _requestManager);

            GetConfigParameter(CONFIG_WEB_SERVICE_URL, out _webServiceUrl);
            TryGetConfigParameter(CONFIG_WEB_SERVICE_TIMEOUT, ref _webServiceTimeoutInSeconds);
        }
        protected virtual void ValidateRequest(string requestId)
        {
            AppendAuditLogEvent("Loading request with id \"{0}\"", requestId);
            _dataRequest = _requestManager.GetDataRequest(requestId);

            AppendAuditLogEvent("Service was called with {0}", 
                                _dataRequest.Parameters.GetKeyValuesString());

            _webServiceQueryArguments = GetWebServiceArguments();
        }
        protected virtual AQSWebServiceArgument GetWebServiceArguments()
        {
            AQSWebServiceArgument arguments = new AQSWebServiceArgument();

            int paramIndex = 0;

            List<PipedParameter<string>> agencyCodes = TryGetPipedParameters<string>(_dataRequest, PARAM_AGENCY_CODE, paramIndex++);
            List<PipedParameter<string>> siteCodes = TryGetPipedParameters<string>(_dataRequest, PARAM_SITE_CODE, paramIndex++);
            List<PipedParameter<string>> parameterCodes = TryGetPipedParameters<string>(_dataRequest, PARAM_PARAMETER_CODE, paramIndex++);
            List<PipedParameter<string>> durationCodes = TryGetPipedParameters<string>(_dataRequest, PARAM_DURATION_CODE, paramIndex++);
            List<PipedParameter<string>> occurrenceCodes = TryGetPipedParameters<string>(_dataRequest, PARAM_OCCURRENCE_CODE, paramIndex++);
            List<PipedParameter<string>> stateCodes = TryGetPipedParameters<string>(_dataRequest, PARAM_STATE_CODE, paramIndex++);
            List<PipedParameter<string>> countyTribalCodes = TryGetPipedParameters<string>(_dataRequest, PARAM_COUNTY_TRIBAL_CODE, paramIndex++);
            
            int maxTagCount = CollectionUtils.Count(agencyCodes);
            maxTagCount = Math.Max(maxTagCount, CollectionUtils.Count(siteCodes));
            maxTagCount = Math.Max(maxTagCount, CollectionUtils.Count(parameterCodes));
            maxTagCount = Math.Max(maxTagCount, CollectionUtils.Count(durationCodes));
            maxTagCount = Math.Max(maxTagCount, CollectionUtils.Count(occurrenceCodes));
            maxTagCount = Math.Max(maxTagCount, CollectionUtils.Count(stateCodes));
            maxTagCount = Math.Max(maxTagCount, CollectionUtils.Count(countyTribalCodes));
            if (maxTagCount > 0)
            {
                List<AQSParameterTag> tags = new List<AQSParameterTag>(maxTagCount);
                for (int i = 0; i < maxTagCount; ++i)
                {
                    bool setAny = false;
                    AQSParameterTag tag = new AQSParameterTag();
                    if (CollectionUtils.Count(agencyCodes) > i)
                    {
                        setAny = true;
                        tag.AgencyCode = agencyCodes[i].Value;
                    }
                    if (CollectionUtils.Count(siteCodes) > i)
                    {
                        setAny = true;
                        tag.SiteCode = siteCodes[i].Value;
                    }
                    if (CollectionUtils.Count(parameterCodes) > i)
                    {
                        setAny = true;
                        tag.ParameterCode = parameterCodes[i].Value;
                    }
                    if (CollectionUtils.Count(durationCodes) > i)
                    {
                        setAny = true;
                        tag.DurationCode = durationCodes[i].Value;
                    }
                    if (CollectionUtils.Count(occurrenceCodes) > i)
                    {
                        string strValue = occurrenceCodes[i].Value;
                        if (!string.IsNullOrEmpty(strValue))
                        {
                            int occurrenceCode;
                            if (!int.TryParse(strValue, out occurrenceCode))
                            {
                                throw new ArgException("An occurrence code was specified that cannot be parsed as an integer: {0}", strValue);
                            }
                            setAny = true;
                            tag.ParameterOccurrenceCode = occurrenceCode;
                            tag.ParameterOccurrenceCodeSpecified = true;
                        }
                    }
                    if (CollectionUtils.Count(stateCodes) > i)
                    {
                        setAny = true;
                        tag.StateCode = stateCodes[i].Value;
                    }
                    if (CollectionUtils.Count(countyTribalCodes) > i)
                    {
                        setAny = true;
                        tag.CountyTribalCode = countyTribalCodes[i].Value;
                    }
                    if (setAny)
                    {
                        tags.Add(tag);
                    }
                }
                arguments.Tags = tags.ToArray();
            }

            if (!TryGetParameter(_dataRequest, PARAM_START_TIME, paramIndex++, ref arguments.StartTime))
            {
                arguments.StartTime = DateTime.Now.AddYears(-1);
            }
            if (!TryGetParameter(_dataRequest, PARAM_END_TIME, paramIndex++, ref arguments.EndTime))
            {
                arguments.EndTime = DateTime.Now;
            }

            if (!TryGetParameter(_dataRequest, PARAM_SCHEMA_VERSION, paramIndex++, ref arguments.AQSXMLSchemaVersion))
            {
                arguments.AQSXMLSchemaVersion = "2.2";
            }

            TryGetParameter(_dataRequest, PARAM_SEND_RD_TRANSACTIONS, paramIndex++, ref arguments.SendRDTransactions);
            TryGetParameter(_dataRequest, PARAM_SEND_RB_TRANSACTIONS, paramIndex++, ref arguments.SendRBTransactions);
            TryGetParameter(_dataRequest, PARAM_SEND_RA_TRANSACTIONS, paramIndex++, ref arguments.SendRATransactions);
            TryGetParameter(_dataRequest, PARAM_SEND_RP_TRANSACTIONS, paramIndex++, ref arguments.SendRPTransactions);
            TryGetParameter(_dataRequest, PARAM_SEND_ONLY_QA_DATA, paramIndex++, ref arguments.SendOnlyQAData);
            arguments.CompressPayload = true;

            //byte[] argumentBytes = _serializationHelper.SerializeWithLineBreaks(arguments);
            //Document doc = new Document("RequestArguments.xml", CommonContentType.XML, argumentBytes);
            //doc.DontAutoCompress = true;
            //_documentManager.AddDocument(_dataRequest.TransactionId, CommonTransactionStatusCode.Completed,
            //                             null, doc);

            string requestDataString = _dataRequest.Parameters.GetKeyValuesString();
            AppendAuditLogEvent("GetAQSXmlData request arguments, {0}", requestDataString);

            return arguments;
        }
        protected virtual string GetXmlData()
        {
            using (AQSXmlWebService webService = new AQSXmlWebService(_webServiceUrl))
            {
                webService.Timeout = _webServiceTimeoutInSeconds * 1000;
                
                AppendAuditLogEvent("Calling the GetAQSXmlData web method at url \"{0}\"", _webServiceUrl);

                AQSXmlResultData data = null;
                try
                {
                    data = webService.GetAQSXmlData(_webServiceQueryArguments);
                }
                catch (Exception e)
                {
                    AppendAuditLogEvent("The GetAQSXmlData web method returned an exception: {0}",
                                        ExceptionUtils.GetDeepExceptionMessage(e));
                    throw;
                }
                AppendAuditLogEvent("Successfully called the GetAQSXmlData web method");

                if (CollectionUtils.IsNullOrEmpty(data.ZipCompressedAQSXmlDocument))
                {
                    if (!CollectionUtils.IsNullOrEmpty(data.GenerationWarnings))
                    {
                        string errorMessage = StringUtils.Join("\r\n", data.GenerationWarnings);
                        AppendAuditLogEvent("The GetAQSXmlData web method returned generation warnings:\r\n{0}",
                                            errorMessage);
                        throw new InvalidOperationException(errorMessage);
                    }
                    else
                    {
                        throw new InvalidOperationException("The GetAQSXmlData web method did not return any xml");
                    }
                }
                else
                {
                    AppendAuditLogEvent("The GetAQSXmlData web method returned zipped xml data containing {0} bytes",
                                        data.ZipCompressedAQSXmlDocument.Length.ToString("N0"));
                }
                string filePath;
                if (_compressionHelper.IsCompressed(data.ZipCompressedAQSXmlDocument))
                {
                    filePath = _settingsProvider.NewTempFilePath(".zip");
                }
                else
                {
                    filePath = _settingsProvider.NewTempFilePath(".xml");
                }
                AppendAuditLogEvent("Saving returned file data to temp file \"{0}\"", filePath);
                File.WriteAllBytes(filePath, data.ZipCompressedAQSXmlDocument);
                return filePath;
            }
        }
        public virtual string GetDataAndAddToTransaction()
        {
            string filePath = GetXmlData();

            string zipFilePath = AddExchangeDocumentHeader(filePath, true, _dataRequest.TransactionId);

            return zipFilePath;
        }
    }
}




