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
using System.IO;
using System.Xml;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Windsor.Node2008.WNOSPlugin;
using Spring.Data.Core;
using Windsor.Commons.Core;
using Windsor.Commons.Logging;
using Windsor.Commons.Spring;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSProviders;


namespace Windsor.Node2008.WNOSPlugin.NEI_DB
{
    public class GetNEIPointDataByYear : QueryProcessor, ISolicitProcessor
    {
        protected const string PARAM_TRANSACTION_TYPE_KEY = "TransactionType";
        protected const string PARAM_ADD_HEADER_KEY = "AddHeader";

        protected const string CONFIG_ORGANIZATION = "Organization";
        protected const string CONFIG_CONTACT_INFO = "Contact Info";
        protected const string CONFIG_SENSITIVITY = "Sensitivity";
        protected const string CONFIG_GEOGRAPHIC_COVERAGE = "Geographic Coverage";

        private const string TRANSACTION_TYPE_PARAM_ORIGINAL = "original";
        private const string TRANSACTION_TYPE_PARAM_REPLACE = "replace";

        protected string _transactionType;
        protected bool _addHeader;
        protected IHeaderDocumentHelper _headerDocumentHelper;

        public GetNEIPointDataByYear()
        {
            ConfigurationArguments.Add(CONFIG_ORGANIZATION, null);
            ConfigurationArguments.Add(CONFIG_CONTACT_INFO, null);
            ConfigurationArguments.Add(CONFIG_SENSITIVITY, null);
            ConfigurationArguments.Add(CONFIG_GEOGRAPHIC_COVERAGE, null);
        }
        public void ProcessSolicit(string requestId)
        {
            base.ProcessSolicitRequest(requestId);

            AppendAuditLogEvent("Begin getting point data ...");

            string transactionTypeCode = (_transactionType == TRANSACTION_TYPE_PARAM_ORIGINAL) ? "00" : "05";
            PointSourceSubmissionGroupType points =
                Data.GetPoints(_baseDao, false, _reportingYear, transactionTypeCode, this);

            AppendAuditLogEvent("Finished getting point data.");

            if (_addHeader)
            {
                AppendAuditLogEvent("Adding header to data ...");
                string tempXmlFilePath = _settingsProvider.NewTempFilePath(".xml");
                string tempXmlFilePath2 = _settingsProvider.NewTempFilePath(".xml");
                string tempZipFilePath = _settingsProvider.NewTempFilePath(".zip");
                try
                {
                    _serializationHelper.Serialize(points, tempXmlFilePath);

                    XmlDocument doc = new XmlDocument();
                    doc.Load(tempXmlFilePath);

                    _headerDocumentHelper.Configure("Windsor Solutions, Inc.",
                                                    ValidateNonEmptyConfigParameter(CONFIG_ORGANIZATION),
                                                    "NEI", null,
                                                    ValidateNonEmptyConfigParameter(CONFIG_CONTACT_INFO),
                                                    ValidateNonEmptyConfigParameter(CONFIG_SENSITIVITY));
                    _headerDocumentHelper.AddPropery("GeographicCoverage", ValidateNonEmptyConfigParameter(CONFIG_GEOGRAPHIC_COVERAGE));
                    _headerDocumentHelper.AddPropery("InventoryYear", _reportingYear.ToString());
                    
                    _headerDocumentHelper.AddPayload("Point|"+_transactionType,
                                                     doc.DocumentElement);

                    _headerDocumentHelper.Serialize(tempXmlFilePath2);

                    _compressionHelper.CompressFile(tempXmlFilePath2, tempZipFilePath);

                    try
                    {
                        AppendAuditLogEvent("Adding result document to transaction ...");
                        _documentManager.AddDocument(_dataRequest.TransactionId, 
                                                     CommonTransactionStatusCode.Completed,
                                                     null, tempZipFilePath);
                    }
                    catch (Exception e)
                    {
                        AppendAuditLogEvent("Failed to attach xml results document \"{0}\" to transaction \"{1}\" with exception: {2}",
                                                  tempZipFilePath, _dataRequest.TransactionId, 
                                                  ExceptionUtils.ToShortString(e));
                        throw;
                    }
                }
                finally
                {
                }
            }
            else
            {
                SerializeDataAndAddToTransaction(points, _settingsProvider, _serializationHelper,
                                                 null, _documentManager, _dataRequest.TransactionId);
            }
        }
        protected override void LazyInit()
        {
            base.LazyInit();

            GetServiceImplementation(out _headerDocumentHelper);

            ValidateNonEmptyConfigParameter(CONFIG_ORGANIZATION);
            ValidateNonEmptyConfigParameter(CONFIG_CONTACT_INFO);
            ValidateNonEmptyConfigParameter(CONFIG_SENSITIVITY);
            ValidateNonEmptyConfigParameter(CONFIG_GEOGRAPHIC_COVERAGE);
        }
        protected override void ValidateRequest(string requestId)
        {
            base.ValidateRequest(requestId);

            GetParameter(_dataRequest, PARAM_TRANSACTION_TYPE_KEY, 1, out _transactionType);
            if ((_transactionType != TRANSACTION_TYPE_PARAM_ORIGINAL) &&
                 (_transactionType != TRANSACTION_TYPE_PARAM_REPLACE))
            {
                throw new ArgumentException(string.Format("The \"{0}\" parameter must be either \"{1}\" or \"{2},\" but it is \"{3}\"",
                                                          PARAM_TRANSACTION_TYPE_KEY, TRANSACTION_TYPE_PARAM_ORIGINAL,
                                                          TRANSACTION_TYPE_PARAM_REPLACE, _transactionType));
            }
            GetParameter(_dataRequest, PARAM_ADD_HEADER_KEY, 2, out _addHeader);

            AppendAuditLogEvent("Validated request with parameters: {0} = {1}, {2} = {3}, {4} = {5}",
                                      PARAM_REPORTING_YEAR_KEY, _reportingYear.ToString(), 
                                      PARAM_TRANSACTION_TYPE_KEY, _transactionType,
                                      PARAM_ADD_HEADER_KEY, _addHeader);
        }
        /// <summary>
        /// Return the Query, Solicit, or Execute data service parameters for specified data service.
        /// This method should NOT call GetServiceImplementation().
        /// </summary>
        public override IList<TypedParameter> GetDataServiceParameters(string serviceName, out DataServicePublishFlags publishFlags)
        {
            if (string.Equals(serviceName, "GetNEIPointDataByYear", StringComparison.InvariantCultureIgnoreCase))
            {
                List<TypedParameter> list = new List<TypedParameter>(3);
                list.Add(new TypedParameter("ReportingYear", "The reporting year for returned data", true, typeof(int), true));
                list.Add(new TypedParameter("TransactionType", "The transaction type for returned data (original or replace)", true, typeof(string), true));
                list.Add(new TypedParameter("AddHeader", "True to add an exchange header to the returned data, false otherwise", true, typeof(bool), true));
                publishFlags = DataServicePublishFlags.PublishToEndpointVersion11And20;
                return list;
            }
            else
            {
                publishFlags = DataServicePublishFlags.DoNotPublish;
                return null;
            }
        }
    }

    public class SetNEIPointDataByYear : QueryProcessor, ISolicitProcessor
    {
        protected const string PARAM_SOURCE_FILE_PATH_KEY = "SourceFilePath";
        protected string _sourceFilePath;

        public void ProcessSolicit(string requestId)
        {
            base.ProcessSolicitRequest(requestId);

            AppendAuditLogEvent("Begin processing source file data ...");

            DataPump.Pump(_baseDao, _sourceFilePath, _reportingYear, this);

            AppendAuditLogEvent("Finished processing source file data.");
        }
        protected override void ValidateRequest(string requestId)
        {
            base.ValidateRequest(requestId);

            GetParameter(_dataRequest, PARAM_SOURCE_FILE_PATH_KEY, 1, out _sourceFilePath);
            if (!File.Exists(_sourceFilePath))
            {
                throw new FileNotFoundException(string.Format("The source file was not found: \"{0}\"", 
                                                              _sourceFilePath));
            }

            AppendAuditLogEvent("Validated request with parameters: {0} = {1}, {2} = {3}",
                                      PARAM_REPORTING_YEAR_KEY, _reportingYear.ToString(),
                                      PARAM_SOURCE_FILE_PATH_KEY, _sourceFilePath);
        }
    }

    public abstract class QueryProcessor : BaseWNOSPlugin
    {
        protected const string SOURCE_PROVIDER_KEY = "Data Source";

        protected const string PARAM_REPORTING_YEAR_KEY = "ReportingYear";

        protected IRequestManager _requestManager;
        protected ISerializationHelper _serializationHelper;
        protected ICompressionHelper _compressionHelper;
        protected IDocumentManager _documentManager;
        protected ISettingsProvider _settingsProvider;

        protected SpringBaseDao _baseDao;
        protected DataRequest _dataRequest;

        protected int _reportingYear;

        public QueryProcessor()
        {
            DataProviders.Add(SOURCE_PROVIDER_KEY, null);
        }

        protected virtual void LazyInit()
        {
            AppendAuditLogEvent("Initializing plugin ...");

            GetServiceImplementation(out _requestManager);
            GetServiceImplementation(out _serializationHelper);
            GetServiceImplementation(out _compressionHelper);
            GetServiceImplementation(out _documentManager);
            GetServiceImplementation(out _settingsProvider);

            _baseDao = ValidateDBProvider(SOURCE_PROVIDER_KEY, typeof(NamedNullMappingDataReader));
        }
        protected virtual void ValidateRequest(string requestId)
        {
            AppendAuditLogEvent("Loading request with id \"{0}\"", requestId);
            _dataRequest = _requestManager.GetDataRequest(requestId);

            AppendAuditLogEvent("Validating request: {0}", _dataRequest);

            GetParameter(_dataRequest, PARAM_REPORTING_YEAR_KEY, 0, out _reportingYear);
        }

        protected virtual void ProcessSolicitRequest(string requestId)
        {
            LazyInit();

            ValidateRequest(requestId);
        }
    }
}
