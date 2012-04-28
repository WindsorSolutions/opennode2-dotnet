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
using Windsor.Commons.NodeDomain;
using Windsor.Node2008.WNOSPlugin.AQSCommon;

namespace Windsor.Node2008.WNOSPlugin.AQSWS
{

    public enum AQSServiceType
    {
        AQDEMonitorData,
        AQDERawData
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
    public class DrDasProxyService : AQSBaseHeaderPlugin, ISolicitProcessor, IQueryProcessor
    {

        protected const string CONFIG_REPORTER_URL = "Reporter Url";
        protected const string CONFIG_SCHEMA_VERSION = "Schema Version";

        #region fields
        private static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());
        private IRequestManager _requestManager;
        private DataRequest _request;

        private string _reporterUrl;
        private string _schemaVersion;
        #endregion

        /// <summary>
        /// Responsible for processing all AQS services
        /// </summary>
        public DrDasProxyService()
        {
            ConfigurationArguments.Add(CONFIG_REPORTER_URL, null);
            ConfigurationArguments.Add(CONFIG_SCHEMA_VERSION, null);
        }

        protected override void LazyInit()
        {
            base.LazyInit();

            GetServiceImplementation(out _requestManager);

            _reporterUrl = ValidateNonEmptyConfigParameter(CONFIG_REPORTER_URL);
            _schemaVersion = ValidateNonEmptyConfigParameter(CONFIG_SCHEMA_VERSION);
        }
        protected virtual void ValidateRequest(string requestId)
        {
            DebugAndAudit("Getting request: " + requestId);
            _request = _requestManager.GetDataRequest(requestId);


            if (_request == null)
            {
                throw new ApplicationException("Null request");
            }

            if (_request.Service == null)
            {
                throw new ApplicationException("Null service");
            }

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

            ValidateRequest(requestId);

            string xmlFilePath = GetXmlDocument();

            string zipFilePath = AddExchangeDocumentHeader(xmlFilePath, true, _request.TransactionId);

            DebugAndAudit("Creating paginated content result");
            PaginatedContentResult result =
                new PaginatedContentResult(_request.RowIndex, _request.MaxRowCount, true, CommonContentType.ZIP, 
                                           File.ReadAllBytes(zipFilePath));

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

            ValidateRequest(requestId);

            string xmlFilePath = GetXmlDocument();

            string zipFilePath = AddExchangeDocumentHeader(xmlFilePath, true, _request.TransactionId);
        }

        #endregion

        protected string GetXmlDocument()
        {
            DebugAndAudit("Getting data for: " + _request.Service.Name);
            XmlDocument doc = ProcessServiceRequest(_request);

            string path = _settingsProvider.NewTempFilePath(".xml");

            DebugAndAudit("Loading and saving content");

            using (StringWriter sw = new StringWriter())
            {
                using (XmlTextWriter xw = new XmlTextWriter(sw))
                {
                    doc.WriteTo(xw);
                    UTF8Encoding encoding = new UTF8Encoding(false, true);
                    byte[] content = encoding.GetBytes(sw.ToString());
                    File.WriteAllBytes(path, content);
                }
            }
            return path;
        }
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
        private XmlDocument ProcessServiceRequest(DataRequest request)
        {

            LOG.DebugEnter(MethodBase.GetCurrentMethod(), request);

            if (request == null || request.Parameters == null)
            {
                throw new ApplicationException("Null request or its parameters");
            }

            DebugAndAudit("Validating configuration arguments...");

            DebugAndAudit("Getting WS Proxy for: {0}", _reporterUrl);

            DebugAndAudit("Parsed Schema Version: {0}", _schemaVersion);

            DebugAndAudit("Initializing DrDAS client...");
            AQDEData client = new AQDEData();
            client.Url = _reporterUrl;
            client.AllowAutoRedirect = true;
            client.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap11;
            client.Timeout = 600000;
            client.UseDefaultCredentials = true;

            DebugAndAudit("Parsing target service from: {0}...", request.Service.Name);
            AQSServiceType serviceType = (AQSServiceType)Enum.Parse(typeof(AQSServiceType), request.Service.Name, true);


            XmlDocument doc = new XmlDocument();

            List<string> parameters = GetParameterListSortedByName(request.Parameters);

            switch (serviceType)
            {
                case AQSServiceType.AQDEMonitorData:

                    DebugAndAudit("Executing queryAQSMonitorData...");

                    doc.LoadXml(client.queryAQSMonitorData(
                        parameters[(Int32)MonitorDataArgType.FileGenerationPurposeCode],
                        parameters[(Int32)MonitorDataArgType.SubstanceName],
                        parameters[(Int32)MonitorDataArgType.MonitorType],
                        parameters[(Int32)MonitorDataArgType.StateName],
                        parameters[(Int32)MonitorDataArgType.CountyName],
                        parameters[(Int32)MonitorDataArgType.CityName],
                        parameters[(Int32)MonitorDataArgType.TribeName],
                        parameters[(Int32)MonitorDataArgType.FacilitySiteIdentifier],
                        parameters[(Int32)MonitorDataArgType.MinLatitudeMeasure],
                        parameters[(Int32)MonitorDataArgType.MaxLatitudeMeasure],
                        parameters[(Int32)MonitorDataArgType.MinLongitudeMeasure],
                        parameters[(Int32)MonitorDataArgType.MaxLongitudeMeasure],
                        parameters[(Int32)MonitorDataArgType.LastUpdatedDate],
                        _schemaVersion));

                    break;

                case AQSServiceType.AQDERawData:

                    //Remote request Id
                    string remoteRequestId = Guid.NewGuid().ToString();
                    DebugAndAudit("Remote request Id: {0}", remoteRequestId);
                    DebugAndAudit("Executing solicitAQSRawData...");
                    String resultUrl = client.solicitAQSRawData(
                        parameters[(Int32)RawDataArgType.FileGenerationPurposeCode],
                        parameters[(Int32)RawDataArgType.BeginDate],
                        parameters[(Int32)RawDataArgType.BeginTime],
                        parameters[(Int32)RawDataArgType.EndDate],
                        parameters[(Int32)RawDataArgType.EndTime],
                        parameters[(Int32)RawDataArgType.TimeType],
                        parameters[(Int32)RawDataArgType.SampleDuration],
                        parameters[(Int32)RawDataArgType.SubstanceName],
                        parameters[(Int32)RawDataArgType.MonitorType],
                        parameters[(Int32)RawDataArgType.DataValidityCode],
                        parameters[(Int32)RawDataArgType.DataApprovalIndicator],
                        parameters[(Int32)RawDataArgType.StateName],
                        parameters[(Int32)RawDataArgType.CountyName],
                        parameters[(Int32)RawDataArgType.CityName],
                        parameters[(Int32)RawDataArgType.TribeName],
                        parameters[(Int32)RawDataArgType.FacilitySiteIdentifier],
                        parameters[(Int32)RawDataArgType.MinLatitudeMeasure],
                        parameters[(Int32)RawDataArgType.MaxLatitudeMeasure],
                        parameters[(Int32)RawDataArgType.MinLongitudeMeasure],
                        parameters[(Int32)RawDataArgType.MaxLongitudeMeasure],
                        parameters[(Int32)RawDataArgType.LastUpdatedDate],
                        parameters[(Int32)RawDataArgType.IncludeMonitorDetails],
                        parameters[(Int32)RawDataArgType.IncludeEventData],
                        _schemaVersion,
                        remoteRequestId,
                        Boolean.FalseString);
                    DebugAndAudit("Remote result url: {0}", resultUrl);

                    using (XmlTextReader reader = new XmlTextReader(resultUrl))
                    {
                        reader.Read();
                        doc.Load(reader);
                    }

                    break;

                default:
                    throw new ApplicationException("Invalid service name: " + serviceType);
            }

            return doc;

        }
    }
}
