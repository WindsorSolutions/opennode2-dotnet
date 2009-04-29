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
using Windsor.Commons.Logging;

namespace Windsor.Node2008.WNOSPlugin.FRS23
{

    public enum FRSServiceParameterType
    {
        SkipEIChildren,
        AllowMultipleGeoLocations
    }

    public enum FRSDataProviderParameterType
    {
        SourceProvider
    }

    [Serializable]
    public class SimpleFRSService : BaseWNOSPlugin, ISolicitProcessor, IQueryProcessor, IExecuteProcessor
    {

        private const int MAX_NUM_OF_FACS_IN_REAL_TIME = 3000;

        #region fields
        private static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());
        private IRequestManager _requestManager;
        private ISerializationHelper _serializationHelper;
        private ICompressionHelper _compressionHelper;
        private IDocumentManager _documentManager;
        #endregion

        /// <summary>
        /// Responsible for processing all FRS services
        /// </summary>
        public SimpleFRSService()
        {

            //Load Parameters
            foreach (string arg in Enum.GetNames(typeof(FRSServiceParameterType)))
            {
                ConfigurationArguments.Add(arg, null);
            }

            //Load Data Sources
            foreach (string arg in Enum.GetNames(typeof(FRSDataProviderParameterType)))
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

            AppendAuditLogEvent("Getting request: " + requestId);
            DataRequest request = _requestManager.GetDataRequest(requestId);

            LOG.Debug("Getting data for request: " + request);
            AppendAuditLogEvent("Getting data for request: " + request);
            FacilitySiteList list = ProcessServiceRequest(request);

            AppendAuditLogEvent("Records found: " + list.FacilitySiteAllDetails.Count);

            LOG.Debug("Creating PaginatedContentResult");
            PaginatedContentResult result = new PaginatedContentResult();
            result.Paging = new PaginationIndicator(request.RowIndex, request.MaxRowCount, true);

            LOG.Debug("Serializing data");
            AppendAuditLogEvent("Serializing data...");
            result.Content = new SimpleContent(CommonContentType.XML, _serializationHelper.Serialize(list));

            LOG.Debug("OK");
            AppendAuditLogEvent("ProcessQuery: OK");
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
            
            AppendAuditLogEvent("Getting request: " + requestId);
            DataRequest request = _requestManager.GetDataRequest(requestId);

            LOG.Debug("Getting data for: " + request);
            AppendAuditLogEvent("Getting data for request: " + request);
            FacilitySiteList list = ProcessServiceRequest(request);
            AppendAuditLogEvent("Records found: " + list.FacilitySiteAllDetails.Count);

            LOG.Debug("Serializing results to file...");
            AppendAuditLogEvent("Serializing results to file...");
            string serializedFilePath = _serializationHelper.SerializeToTempFile(list);
            LOG.Debug("Serialized file path: " + serializedFilePath);
            AppendAuditLogEvent("Serialized file path: " + serializedFilePath);

            LOG.Debug("Adding document...");
            AppendAuditLogEvent("Adding document...");
            _documentManager.AddDocument(request.TransactionId,
                                         CommonTransactionStatusCode.Processed,
                                         "Request Processed: " + request.ToString(),
                                         serializedFilePath);

            LOG.Debug("OK");
            AppendAuditLogEvent("ProcessQuery: OK");


        }

        #endregion

        #region IExecuteProcessor Interface Implementation

        /// <summary>
        /// ProcessExecute
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns></returns>
        public ExecuteContentResult ProcessExecute(string requestId)
        {

            LOG.DebugEnter(MethodBase.GetCurrentMethod(), requestId);

            LazyInit();

            AppendAuditLogEvent("Getting request: " + requestId);
            DataRequest request = _requestManager.GetDataRequest(requestId);

            LOG.Debug("Getting data for: " + request);
            AppendAuditLogEvent("Getting data for request: " + request);
            FacilitySiteList list = ProcessServiceRequest(request);
            AppendAuditLogEvent("Records found: " + list.FacilitySiteAllDetails.Count);

            LOG.Debug("Creating ExecuteContentResult");
            ExecuteContentResult result = new ExecuteContentResult();
            AppendAuditLogEvent("Serialized content...");
            result.Content = new SimpleContent(CommonContentType.XML, _serializationHelper.Serialize(list));
            result.Status = CommonTransactionStatusCode.Processed;

            LOG.Debug("OK");
            return result;

        }

        #endregion

        /// <summary>
        /// ProcessServiceRequest
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private FacilitySiteList ProcessServiceRequest(DataRequest request)
        {
            LOG.DebugEnter(MethodBase.GetCurrentMethod(), request);

            FRSServiceCriteria criteria = new FRSServiceCriteria(request);
            LOG.Debug("Criteria: {0}", criteria);

            IDbProvider dbProvider = DataProviders[FRSDataProviderParameterType.SourceProvider.ToString()];
            LOG.Debug("Provider: {0}", dbProvider);


            FRSData frsData = new FRSData(dbProvider, criteria);

            if (criteria.Type == FRSServiceCriteria.FRSServiceType.GetDeletedFacilityByChangeDate ||
                criteria.Type == FRSServiceCriteria.FRSServiceType.GetDeletedFacilityByChangePeriod)
            {
                throw new ApplicationException("Ups, not implemented");
            }
            else
            {
                Trace.WriteLine("Getting data.");
                FRS ds = frsData.GetFRSAddData();
                LOG.Debug("Data retrieved. (Record Count = {0}).", ds.FRS_FAC.Rows.Count);
                return FRSTransform.Transform(ds, request.RowIndex, request.MaxRowCount);
            }


        }

    }
}
