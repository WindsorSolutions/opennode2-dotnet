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
using System.Data;
using System.Data.Common;
using Spring.Data.Common;
using Windsor.Commons.Core;
using Windsor.Commons.Spring;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSProviders;

namespace Windsor.Node2008.WNOSPlugin.AQS3
{
    public class CsvFileImporter : BaseWNOSPlugin, ITaskProcessor
    {
        protected const string DESTINATION_PROVIDER_KEY = "Data Destination";

        protected const string PARAM_CSV_FILE_PATH = "CSV File Path";
        protected const string PARAM_MAPPING_TEMPLATE_NAME = "Mapping Template Name";
        protected const string PARAM_CLEAR_AQS_METADATA = "Clear AQS Metadata";

        protected IRequestManager _requestManager;

        protected SpringBaseDao _baseDao;
        protected DataRequest _dataRequest;

        protected string _csvFilePath;
        protected string _mappingTemplateName;
        protected bool _clearMetadata = true;

        public CsvFileImporter()
        {
            DataProviders.Add(DESTINATION_PROVIDER_KEY, null);
        }

        public virtual void ProcessTask(string requestId)
        {
            LazyInit();

            ValidateRequest(requestId);

            DoImport();
        }
        protected virtual void LazyInit()
        {
            AppendAuditLogEvent("Initializing {0} plugin ...", this.GetType().Name);

            GetServiceImplementation(out _requestManager);

            _baseDao = ValidateDBProvider(DESTINATION_PROVIDER_KEY, typeof(NamedNullMappingDataReader));
        }
        protected virtual void ValidateRequest(string requestId)
        {
            AppendAuditLogEvent("Loading request with id \"{0}\"", requestId);
            _dataRequest = _requestManager.GetDataRequest(requestId);

            AppendAuditLogEvent("Validating request: {0}", _dataRequest);

            GetParameter(_dataRequest, PARAM_CSV_FILE_PATH, 0, out _csvFilePath);
            GetParameter(_dataRequest, PARAM_MAPPING_TEMPLATE_NAME, 2, out _mappingTemplateName);
            TryGetParameter(_dataRequest, PARAM_CLEAR_AQS_METADATA, 3, ref _clearMetadata);

            AppendAuditLogEvent("Validated request with parameters: {0} = {1}, {2} = {3}, {4} = {5}",
                                PARAM_CSV_FILE_PATH, _csvFilePath, PARAM_MAPPING_TEMPLATE_NAME, _mappingTemplateName, 
                                PARAM_CLEAR_AQS_METADATA, _clearMetadata);
        }
        protected virtual void DoImport()
        {
            AppendAuditLogEvent("Importing CSV file \"{0}\" ...", _csvFilePath);

            try
            {
                AqsDeserializeCsv cdr = new AqsDeserializeCsv(_baseDao);

                AppendAuditLogEvent("Generating AQS data from CSV file \"{0}\" ...", _csvFilePath);
                AirQualitySubmissionType data =
                    cdr.GetAirQualityData(_csvFilePath, Windsor.Node2008.WNOSPlugin.AQS3.AqsDeserializeCsv.AqsFileType.rawResults,
                                          _mappingTemplateName, this);

                AppendAuditLogEvent("Importing AQS data into database ...");

                AQSPersistDataToDatabase dataPersister = new AQSPersistDataToDatabase(_baseDao, _clearMetadata);
                dataPersister.UpsertAirQualityData(data, this);

                AppendAuditLogEvent("Successfully imported CSV file");
            }
            catch (Exception e)
            {
                AppendAuditLogEvent("Failed to import CSV file with error: {0}",
                                    ExceptionUtils.GetDeepExceptionMessage(e));
                throw;
            }
        }
    }
}




