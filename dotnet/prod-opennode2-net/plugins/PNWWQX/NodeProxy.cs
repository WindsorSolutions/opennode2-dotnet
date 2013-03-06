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
using System.Reflection;
using Spring.Data.Common;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSPlugin;
using Windsor.Node2008.WNOSProviders;
using Windsor.Commons.Logging;
using Windsor.Commons.NodeDomain;
using Windsor.Commons.Core;

namespace Windsor.Node2008.WNOSPlugin.PNWWQX
{

    [Serializable]
    public class NodeProxy : BaseWNOSPlugin, ISolicitProcessor, IQueryProcessor
    {
        public enum ServiceParameterType
        {

        }

        public enum DataProviderParameterType
        {
            SourceProvider
        }

        public enum ParameterType
        {
            PROVIDING_ORGANIZATION_NAME = 2,
            PROJECT_ORGANIZATION_NAME = 3,
            PROJECT_NAME = 4,
            PROJECT_STARTDATE = 5,
            PROJECT_ENDDATE = 6,
            RESPONSIBLE_ORGANIZATIONNAME = 7,
            MAXIMUM_LOCATION_LATITUDE = 8,
            MAXIMUM_LOCATION_LONGITUDE = 9,
            MINIMUM_LOCATION_LATITUDE = 10,
            MINIMUM_LOCATION_LONGITUDE = 11,
            LOCATION_DESCRIPTOR_CONTEXT = 12,
            LOCATION_DESCRIPTOR_NAME = 13,
            STATION_TYPE = 14,
            STATION_NAME = 15,
            SAMPLING_ORGANIZATION_NAME = 16,
            FIELD_EVENT_START_DATE = 17,
            FIELD_EVENT_END_DATE = 18,
            SAMPLED_MEDIA = 19,
            ANALYTE_NAME = 20,
            SAMPLED_TAXON = 21
        }


        #region fields
        private static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());
        private IRequestManager _requestManager;
        private ISerializationHelper _serializationHelper;
        private ICompressionHelper _compressionHelper;
        private IDocumentManager _documentManager;
        #endregion

        public NodeProxy()
        {
            //Load Parameters
            foreach (string arg in Enum.GetNames(typeof(ServiceParameterType)))
            {
                ConfigurationArguments.Add(arg, null);
            }

            //Load Data Sources
            foreach (string arg in Enum.GetNames(typeof(DataProviderParameterType)))
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

        public PaginatedContentResult ProcessQuery(string requestId)
        {
            LOG.DebugEnter(MethodBase.GetCurrentMethod(), requestId);

            LazyInit();

            DataRequest request = _requestManager.GetDataRequest(requestId);

            object returnData = GetObjectFromRequest(request);

            LOG.Debug("Creating PaginatedContentResult");
            PaginatedContentResult result = new PaginatedContentResult();
            result.Paging = new PaginationIndicator(request.RowIndex, request.MaxRowCount, true);

            LOG.Debug("Serializing data");
            result.Content = new SimpleContent(CommonContentType.XML, _serializationHelper.Serialize(returnData));

            LOG.Debug("OK");
            return result;

        }


        public void ProcessSolicit(string requestId)
        {
            try
            {
                AppendAuditLogEvent("Getting request...");
                LOG.DebugEnter(MethodBase.GetCurrentMethod(), requestId);

                LazyInit();

                DataRequest request = _requestManager.GetDataRequest(requestId);

                AppendAuditLogEvent("Getting data from request...");
                object returnData = GetObjectFromRequest(request);

                AppendAuditLogEvent("Serializing data to file...");
                LOG.Debug("Serializing results to file...");
                string serializedFilePath = _serializationHelper.SerializeToTempFile(returnData);
                LOG.Debug("Serialized file path: " + serializedFilePath);

                AppendAuditLogEvent("Compressing serialized data...");
                LOG.Debug("Compressing serialized file...");
                string compressedFilePath = _compressionHelper.CompressFile(serializedFilePath);
                LOG.Debug("Compressed file path: " + compressedFilePath);

                AppendAuditLogEvent("Saving compressed data...");
                LOG.Debug("Saving data");
                _documentManager.AddDocument(request.TransactionId,
                                             CommonTransactionStatusCode.Processed,
                                             "Request Processed: " + request.ToString(),
                                             compressedFilePath);

                AppendAuditLogEvent("Plugin done");
                LOG.Debug("OK");
            }
            catch (Exception ex)
            {
                LOG.Error(ex);
                AppendAuditLogEvent("Error: " + ex.StackTrace);
                throw new ApplicationException("Error while executing plugin", ex);
            }

        }





        private object GetObjectFromRequest(DataRequest request)
        {

            LOG.DebugEnter(MethodBase.GetCurrentMethod(), request);

            IDbProvider dbProvider = DataProviders[DataProviderParameterType.SourceProvider.ToString()];
            LOG.Debug("Provider: {0}", dbProvider);

            //Set the static property for conn string
            Config.connectionString = dbProvider.ConnectionString;

            object returnData = null;

            string testServiceName = request.Service.Name.Trim().ToLower();

            LOG.Debug("Original Service Name: " + testServiceName);

            if (testServiceName.Contains("_"))
            {
                testServiceName = testServiceName.Substring(testServiceName.IndexOf("_") + 1);
            }
            if (testServiceName.Contains("."))
            {
                testServiceName = testServiceName.Substring(testServiceName.IndexOf(".") + 1);
            }

            LOG.Debug("Parsed Service Name: " + testServiceName);

            int paramCount = CollectionUtils.Count(request.Parameters);
            if (paramCount < 22)
            {
                throw new ArgumentException(string.Format("An invalid number of parameters were supplied to the service.  22 parameters are required, but only {0} were supplied.",
                                                          paramCount.ToString()));
            }

            int rowIndex, maxRows;

            if (string.IsNullOrEmpty(request.Parameters[0]))
            {
                rowIndex = 0;
            }
            else
            {
                rowIndex = int.Parse(request.Parameters[0]);
            }
            if (string.IsNullOrEmpty(request.Parameters[1]))
            {
                maxRows = 1000000;
            }
            else
            {
                maxRows = int.Parse(request.Parameters[1]);
            }

            switch (testServiceName)
            {
                case "getmeasurements":
                    returnData = (object)PNWWQXProcessor.GetMeasurements
                        (
                        rowIndex,
                        maxRows,
                        request.Parameters[2],
                        request.Parameters[3],
                        request.Parameters[4],
                        request.Parameters[5],
                        request.Parameters[6],
                        request.Parameters[7],
                        request.Parameters[8],
                        request.Parameters[9],
                        request.Parameters[10],
                        request.Parameters[11],
                        request.Parameters[12],
                        request.Parameters[13].Split('|'),
                        request.Parameters[14].Split('|'),
                        request.Parameters[15],
                        request.Parameters[16],
                        request.Parameters[17],
                        request.Parameters[18],
                        request.Parameters[19].Split('|'),
                        request.Parameters[20].Split('|'),
                        request.Parameters[21].Split('|')
                        );
                    break;
                case "getprojects":
                    returnData = (object)PNWWQXProcessor.GetProjects
                        (
                        rowIndex,
                        maxRows,
                        request.Parameters[2],
                        request.Parameters[3],
                        request.Parameters[4],
                        request.Parameters[5],
                        request.Parameters[6],
                        request.Parameters[7],
                        request.Parameters[8],
                        request.Parameters[9],
                        request.Parameters[10],
                        request.Parameters[11],
                        request.Parameters[12],
                        request.Parameters[13].Split('|'),
                        request.Parameters[14].Split('|'),
                        request.Parameters[15],
                        request.Parameters[16],
                        request.Parameters[17],
                        request.Parameters[18],
                        request.Parameters[19].Split('|'),
                        request.Parameters[20].Split('|'),
                        request.Parameters[21].Split('|')
                        );
                    break;
                case "getstations":
                    returnData = (object)PNWWQXProcessor.GetStations
                        (
                        rowIndex,
                        maxRows,
                        request.Parameters[2],
                        request.Parameters[3],
                        request.Parameters[4],
                        request.Parameters[5],
                        request.Parameters[6],
                        request.Parameters[7],
                        request.Parameters[8],
                        request.Parameters[9],
                        request.Parameters[10],
                        request.Parameters[11],
                        request.Parameters[12],
                        request.Parameters[13].Split('|'),
                        request.Parameters[14].Split('|'),
                        request.Parameters[15],
                        request.Parameters[16],
                        request.Parameters[17],
                        request.Parameters[18],
                        request.Parameters[19].Split('|'),
                        request.Parameters[20].Split('|'),
                        request.Parameters[21].Split('|')
                        );
                    break;
                case "getdatacatalog":
                    returnData = (object)PNWWQXDataCatalog.GetDataCatalog();
                    break;
                default:
                    throw new ApplicationException(
                        string.Format("Service name not supported: [{0}] (parsed: {1})",
                        request.Service.Name, testServiceName));
            }

            return returnData;
        }
    }
}

