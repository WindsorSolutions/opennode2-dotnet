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
using System.Data;
using System.IO;
using Windsor.Commons.Core;
using Windsor.Commons.NodeDomain;
using Windsor.Commons.Spring;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSProviders;
using Windsor.Node2008.WNOSPlugin.AQS3Common;
using Windsor.Commons.XsdOrm2;

namespace Windsor.Node2008.WNOSPlugin.AQS3
{
    public abstract class AQSGetRawData : AQS3BaseHeaderPlugin
    {
        protected const string CONFIG_PARAM_ACTION_CODES = "Acceptable Action Codes (comma-separated character list)";

        protected const string SOURCE_PROVIDER_KEY = "Data Source";

        protected const string PARAM_START_DATE_KEY = "StartDate";
        protected const string PARAM_END_DATE_KEY = "EndDate";
        protected const string PARAM_SITE_ID_KEY = "SiteID";
        protected const string PARAM_COUNTY_CODE_KEY = "CountyCode";
        protected const string PARAM_INCLUDE_RAW_RESULTS_ONLY_KEY = "IncludeRawResultsOnly";
        protected const string PARAM_FILTER_BY_IMPORTED_DATE_KEY = "FilterByImportedDate";

        protected IRequestManager _requestManager;
        protected ITransactionManager _transactionManager;
        protected IObjectsFromDatabase _objectsFromDatabase;

        protected SpringBaseDao _baseDao;
        protected DataRequest _dataRequest;

        protected DateTime? _startDate;
        protected DateTime? _endDate;
        protected string _siteId;
        protected string _countyCode;
        protected string _commaSeparatedActionCodes;
        protected string _dataFilePath;
        protected bool _clearMetadataBeforeRun = true;
        protected bool _includeRawResultsOnly;
        protected bool _filterByImportedDate;

        public AQSGetRawData()
        {
            ConfigurationArguments.Add(CONFIG_PARAM_ACTION_CODES, null);

            DataProviders.Add(SOURCE_PROVIDER_KEY, null);
        }

        public virtual void ProcessSolicit(string requestId)
        {
            LazyInit();

            ValidateRequest(requestId);

            PrepareToLoadData();

            AirQualitySubmissionType data = LoadData();

            AppendAuditLogEvent("Generating submission file from results");

            _dataFilePath = AddExchangeDocumentHeader(data, true, _dataRequest.TransactionId);
        }

        public virtual PaginatedContentResult ProcessQuery(string requestId)
        {
            LazyInit();

            ValidateRequest(requestId);

            PrepareToLoadData();

            AirQualitySubmissionType data = LoadData();

            AppendAuditLogEvent("Generating serialized xml results for query");

            _dataFilePath = AddExchangeDocumentHeader(data, true, _dataRequest.TransactionId);

            PaginatedContentResult result =
                new PaginatedContentResult(_dataRequest.RowIndex, _dataRequest.MaxRowCount, true, CommonContentType.ZIP,
                                           File.ReadAllBytes(_dataFilePath));

            return result;
        }
        protected virtual void PrepareToLoadData()
        {
        }
        protected virtual AirQualitySubmissionType LoadData()
        {
            var submissions = 
                _objectsFromDatabase.LoadFromDatabase<AirQualitySubmissionType>(_baseDao, null, typeof(MappingAttributes));
            return null;
        }

        protected override void LazyInit()
        {
            base.LazyInit();

            GetServiceImplementation(out _requestManager);
            GetServiceImplementation(out _serializationHelper);
            GetServiceImplementation(out _compressionHelper);
            GetServiceImplementation(out _documentManager);
            GetServiceImplementation(out _settingsProvider);
            GetServiceImplementation(out _transactionManager);
            GetServiceImplementation(out _objectsFromDatabase);

            TryGetConfigParameter(CONFIG_PARAM_ACTION_CODES, ref _commaSeparatedActionCodes);
            AppendAuditLogEvent("Action Codes: {0}", _commaSeparatedActionCodes == null ? "NONE" :
                                _commaSeparatedActionCodes);

            _baseDao = ValidateDBProvider(SOURCE_PROVIDER_KEY, typeof(NamedNullMappingDataReader));
        }
        protected virtual void ValidateRequest(string requestId)
        {
            AppendAuditLogEvent("Loading request with id \"{0}\"", requestId);
            _dataRequest = _requestManager.GetDataRequest(requestId);

            AppendAuditLogEvent("Validating request: {0}", _dataRequest);

            TryGetParameter(_dataRequest, PARAM_START_DATE_KEY, 0, ref _startDate);
            TryGetParameter(_dataRequest, PARAM_END_DATE_KEY, 1, ref _endDate);
            TryGetParameter(_dataRequest, PARAM_SITE_ID_KEY, 2, ref _siteId);
            TryGetParameter(_dataRequest, PARAM_COUNTY_CODE_KEY, 3, ref _countyCode);
            TryGetParameter(_dataRequest, PARAM_INCLUDE_RAW_RESULTS_ONLY_KEY, 4, ref _includeRawResultsOnly);
            TryGetParameter(_dataRequest, PARAM_FILTER_BY_IMPORTED_DATE_KEY, 5, ref _filterByImportedDate);

            AppendAuditLogEvent("Validated request with parameters: {0} = {1}, {2} = {3}, {4} = {5}, {6} = {7}, {8} = {9}, {10} = {11}",
                                PARAM_START_DATE_KEY, _startDate.HasValue ? _startDate.Value.ToString() : "null",
                                PARAM_END_DATE_KEY, _endDate.HasValue ? _endDate.Value.ToString() : "null", 
                                PARAM_SITE_ID_KEY, _siteId, PARAM_COUNTY_CODE_KEY, _countyCode,
                                PARAM_INCLUDE_RAW_RESULTS_ONLY_KEY, _includeRawResultsOnly,
                                PARAM_FILTER_BY_IMPORTED_DATE_KEY, _filterByImportedDate);
        }
        /// <summary>
        /// Return the Query, Solicit, or Execute data service parameters for specified data service.
        /// This method should NOT call GetServiceImplementation().
        /// </summary>
        public override IList<TypedParameter> GetDataServiceParameters(string serviceName, out DataServicePublishFlags publishFlags)
        {
            List<TypedParameter> list = new List<TypedParameter>(4);
            list.Add(new TypedParameter(PARAM_START_DATE_KEY, "Start date for returned data (YYYY-MM-DD)", true, typeof(DateTime), true));
            list.Add(new TypedParameter(PARAM_END_DATE_KEY, "End date for returned data (YYYY-MM-DD)", true, typeof(DateTime), true));
            list.Add(new TypedParameter(PARAM_SITE_ID_KEY, "If specified, the site id for returned data", false, typeof(string), true));
            list.Add(new TypedParameter(PARAM_COUNTY_CODE_KEY, "If specified, the county code for returned data", false, typeof(string), true));
            publishFlags = DataServicePublishFlags.PublishToEndpointVersion11And20;
            return list;
        }
    }
}




