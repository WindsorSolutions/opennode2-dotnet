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
using System.Collections;
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
using Windsor.Commons.Logging;

namespace Windsor.Node2008.WNOSPlugin.AQSWS
{

    public enum AQSServiceType
    {
        AQDEMonitorData,
        AQDERawData
    }

    public enum AQSServiceParameterType
    {
        DrDasReporterWsUrl,
        AQSSchemaVersion
    }

    public enum AQSDataProviderParameterType
    {

    }


    public enum MonitorDataArgType
    {
        FileGenerationPurposeCode,
        SubstanceName,
        MonitorType,
        StateName,
        CountyName,
        CityName,
        TribeName,
        FacilitySiteIdentifier,
        MinLatitudeMeasure,
        MaxLatitudeMeasure,
        MinLongitudeMeasure,
        MaxLongitudeMeasure,
        LastUpdatedDate
    }


    public enum RawDataArgType
    {
        FileGenerationPurposeCode,
        BeginDate,
        BeginTime,
        EndDate,
        EndTime,
        TimeType,
        SampleDuration,
        SubstanceName,
        MonitorType,
        DataValidityCode,
        DataApprovalIndicator,
        StateName,
        CountyName,
        CityName,
        TribeName,
        FacilitySiteIdentifier,
        MinLatitudeMeasure,
        MaxLatitudeMeasure,
        MinLongitudeMeasure,
        MaxLongitudeMeasure,
        LastUpdatedDate,
        IncludeMonitorDetails,
        IncludeEventData
    }




    [Serializable]
    public class DrDasProxyService : BaseWNOSPlugin, ISolicitProcessor, IQueryProcessor
    {

        #region fields
        private static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());
        private IRequestManager _requestManager;
        private ISerializationHelper _serializationHelper;
        private ICompressionHelper _compressionHelper;
        private IDocumentManager _documentManager;
        private ISettingsProvider _settingsProvider;
        #endregion

        /// <summary>
        /// Responsible for processing all AQS services
        /// </summary>
        public DrDasProxyService()
        {

            //Load Parameters
            foreach (string arg in Enum.GetNames(typeof(AQSServiceParameterType)))
            {
                ConfigurationArguments.Add(arg, null);
            }

            //Load Data Sources
            foreach (string arg in Enum.GetNames(typeof(AQSDataProviderParameterType)))
            {
                DataProviders.Add(arg, null);
            }

        }

        protected void LazyInit()
        {
            GetServiceImplementation(out _requestManager);
            GetServiceImplementation(out _serializationHelper);
            GetServiceImplementation(out _compressionHelper);
            GetServiceImplementation(out _documentManager);
            GetServiceImplementation(out _settingsProvider);
        }
        #region IQueryProcessor Interface Implementation

        /// <summary>
        /// ProcessQuery
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns></returns>
        public PaginatedContentResult ProcessQuery(string requestId)
        {
            LOG.DebugEnter(MethodBase.GetCurrentMethod(), requestId);

            LazyInit();

            DebugAndAudit("Getting request: " + requestId);
            DataRequest request = _requestManager.GetDataRequest(requestId);


            if (request == null)
            {
                throw new ApplicationException("Null request");
            }

            if (request.Service == null)
            {
                throw new ApplicationException("Null service");
            }

            DebugAndAudit("Getting data for: " + request.Service.Name);

            byte[] content = ProcessServiceRequest(request);

            DebugAndAudit("Creating paginated content result");
            PaginatedContentResult result = new PaginatedContentResult();
            result.Paging = new PaginationIndicator(request.RowIndex, request.MaxRowCount, true);

            DebugAndAudit("Loading content");
            result.Content = new SimpleContent(CommonContentType.XML, content);

            DebugAndAudit("Result: OK");
            return result;
        }

        #endregion

        #region ISolicitProcessor Interface Implementation

        /// <summary>
        /// ProcessSolicit
        /// </summary>
        /// <param name="requestId"></param>
        public void ProcessSolicit(string requestId)
        {

            LOG.DebugEnter(MethodBase.GetCurrentMethod(), requestId);

            LazyInit();

            DebugAndAudit("Getting request: " + requestId);
            DataRequest request = _requestManager.GetDataRequest(requestId);

            if (request == null)
            {
                throw new ApplicationException("Null request");
            }

            if (request.Service == null)
            {
                throw new ApplicationException("Null service");
            }

            DebugAndAudit("Getting data for: " + request.Service.Name);
            byte[] content = ProcessServiceRequest(request);

            string path = _settingsProvider.NewTempFilePath(".xml");
            File.WriteAllBytes(path, content);

            DebugAndAudit("Compressing file...");
            string compressedFilePath = _compressionHelper.CompressFile(path);
            DebugAndAudit("Compressed file path: " + compressedFilePath);

            DebugAndAudit("Adding document...");
            _documentManager.AddDocument(request.TransactionId,
                                         CommonTransactionStatusCode.Processed,
                                         "Request Processed: " + request.ToString(),
                                         compressedFilePath);

            DebugAndAudit("Result: OK");


        }

        #endregion


        internal void DebugAndAudit(string message, params object[] args)
        {
            AppendAuditLogEvent(message, args);

            LOG.Debug(message, args);
        }

        /// <summary>
        /// Return the Query, Solicit, or Execute data service parameters for specified data service.
        /// This method should NOT call GetServiceImplementation().
        /// </summary>
        public override IList<TypedParameter> GetDataServiceParameters(string serviceName, out DataServicePublishFlags publishFlags)
        {
            List<TypedParameter> list = null;
            string[] names = null;
            if (string.Equals(serviceName, AQSServiceType.AQDEMonitorData.ToString(), StringComparison.InvariantCultureIgnoreCase))
            {
                names = Enum.GetNames(typeof(MonitorDataArgType));
            }
            else if (string.Equals(serviceName, AQSServiceType.AQDERawData.ToString(), StringComparison.InvariantCultureIgnoreCase))
            {
                names = Enum.GetNames(typeof(RawDataArgType));
            }
            if (names != null)
            {
                list = new List<TypedParameter>(names.Length);
                for (int i = 0; i < names.Length; ++i)
                {
                    list.Add(new TypedParameter(string.Format("P{0} - {1}", (i + 1).ToString("D2"), names[i]),
                                                names[i], true, typeof(string), true));
                }
                publishFlags = DataServicePublishFlags.PublishToEndpointVersion11And20;
            }
            else
            {
                publishFlags = DataServicePublishFlags.DoNotPublish;
            }
            return list;
        }
        /// <summary>
        /// ProcessServiceRequest - returns result path
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private byte[] ProcessServiceRequest(DataRequest request)
        {

            LOG.DebugEnter(MethodBase.GetCurrentMethod(), request);

            if (request == null || request.Parameters == null)
            {
                throw new ApplicationException("Null request or its parameters");
            }

            DebugAndAudit("Validating configuration arguments...");

            string reporterUrl = ConfigurationArguments[AQSServiceParameterType.DrDasReporterWsUrl.ToString()];
            DebugAndAudit("Getting WS Proxy for: {0}", reporterUrl);

            string schemaVersion = ConfigurationArguments[AQSServiceParameterType.AQSSchemaVersion.ToString()];
            DebugAndAudit("Parsed Schema Version: {0}", schemaVersion);

            DebugAndAudit("Initializing DrDAS client...");
            DrDasProxy client = new DrDasProxy(reporterUrl);
            client.AllowAutoRedirect = true;
            client.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap11;
            client.Timeout = 600000;
            client.UseDefaultCredentials = true;

            DebugAndAudit("Parsing target service from: {0}...", request.Service.Name);
            AQSServiceType serviceType = (AQSServiceType)Enum.Parse(typeof(AQSServiceType), request.Service.Name, true);


            StringBuilder sb = new StringBuilder();
            sb.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            sb.Append(Environment.NewLine);

            switch (serviceType)
            {
                case AQSServiceType.AQDEMonitorData:

                    DebugAndAudit("Executing queryAQSMonitorData...");
                    sb.Append(client.queryAQSMonitorData(
                        request.Parameters[(Int32)MonitorDataArgType.FileGenerationPurposeCode],
                        request.Parameters[(Int32)MonitorDataArgType.SubstanceName],
                        request.Parameters[(Int32)MonitorDataArgType.MonitorType],
                        request.Parameters[(Int32)MonitorDataArgType.StateName],
                        request.Parameters[(Int32)MonitorDataArgType.CountyName],
                        request.Parameters[(Int32)MonitorDataArgType.CityName],
                        request.Parameters[(Int32)MonitorDataArgType.TribeName],
                        request.Parameters[(Int32)MonitorDataArgType.FacilitySiteIdentifier],
                        request.Parameters[(Int32)MonitorDataArgType.MinLatitudeMeasure],
                        request.Parameters[(Int32)MonitorDataArgType.MaxLatitudeMeasure],
                        request.Parameters[(Int32)MonitorDataArgType.MinLongitudeMeasure],
                        request.Parameters[(Int32)MonitorDataArgType.MaxLongitudeMeasure],
                        request.Parameters[(Int32)MonitorDataArgType.LastUpdatedDate],
                        schemaVersion));
                    break;

                case AQSServiceType.AQDERawData:

                    //Remote request Id
                    string remoteRequestId = Guid.NewGuid().ToString();
                    DebugAndAudit("Remote request Id: {0}", remoteRequestId);
                    DebugAndAudit("Executing solicitAQSRawData...");
                    String resultUrl = client.solicitAQSRawData(
                        request.Parameters[(Int32)RawDataArgType.FileGenerationPurposeCode],
                        request.Parameters[(Int32)RawDataArgType.BeginDate],
                        request.Parameters[(Int32)RawDataArgType.BeginTime],
                        request.Parameters[(Int32)RawDataArgType.EndDate],
                        request.Parameters[(Int32)RawDataArgType.EndTime],
                        request.Parameters[(Int32)RawDataArgType.TimeType],
                        request.Parameters[(Int32)RawDataArgType.SampleDuration],
                        request.Parameters[(Int32)RawDataArgType.SubstanceName],
                        request.Parameters[(Int32)RawDataArgType.MonitorType],
                        request.Parameters[(Int32)RawDataArgType.DataValidityCode],
                        request.Parameters[(Int32)RawDataArgType.DataApprovalIndicator],
                        request.Parameters[(Int32)RawDataArgType.StateName],
                        request.Parameters[(Int32)RawDataArgType.CountyName],
                        request.Parameters[(Int32)RawDataArgType.CityName],
                        request.Parameters[(Int32)RawDataArgType.TribeName],
                        request.Parameters[(Int32)RawDataArgType.FacilitySiteIdentifier],
                        request.Parameters[(Int32)RawDataArgType.MinLatitudeMeasure],
                        request.Parameters[(Int32)RawDataArgType.MaxLatitudeMeasure],
                        request.Parameters[(Int32)RawDataArgType.MinLongitudeMeasure],
                        request.Parameters[(Int32)RawDataArgType.MaxLongitudeMeasure],
                        request.Parameters[(Int32)RawDataArgType.LastUpdatedDate],
                        request.Parameters[(Int32)RawDataArgType.IncludeMonitorDetails],
                        request.Parameters[(Int32)RawDataArgType.IncludeEventData],
                        schemaVersion,
                        remoteRequestId,
                        Boolean.FalseString);
                    DebugAndAudit("Remote result url: {0}", resultUrl);

                    using (XmlTextReader reader = new XmlTextReader(resultUrl))
                    {
                        reader.Read();
                        XmlDocument doc = new XmlDocument();
                        doc.Load(reader);
                        sb.Append(doc.OuterXml);
                    }

                    break;

                default:
                    throw new ApplicationException("Invalid service name: " + serviceType);
            }

            UTF8Encoding encoding = new UTF8Encoding(false, true);
            return encoding.GetBytes(sb.ToString());

        }
    }
}
