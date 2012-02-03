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
using System.Collections;
using System.Text;
using System.Xml;
using System.IO;
using System.Data;
using System.Xml.Serialization;
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
using System.Runtime.InteropServices;
using System.ComponentModel;
using Windsor.Commons.Core;
using Windsor.Commons.Logging;
using Windsor.Commons.Spring;
using Windsor.Node2008.WNOSPlugin.CERS_12;
using Windsor.Commons.NodeDomain;

namespace Windsor.Node2008.WNOSPlugin.EIS_Bridge_12
{
    [Serializable]
    public class GetEISSubmission : BaseWNOSPlugin, ISolicitProcessor
    {
        protected static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());

        protected ISerializationHelper _serializationHelper;
        protected ICompressionHelper _compressionHelper;
        protected IDocumentManager _documentManager;
        protected ISettingsProvider _settingsProvider;
        protected IRequestManager _requestManager;

        protected SpringBaseDao _baseDao;
        protected DataRequest _dataRequest;
        protected bool _deleteDatabaseOnSuccess;
        protected string _databasePath;
        protected string _dataCategory;
        protected bool _passedSchemaValidation;

        protected const string CONFIG_SOURCE_DATABASE_PATH = "SourceDatabasePath";
        protected const string CONFIG_DELETE_DATABASE_ON_SUCCESS = "DeleteDatabaseOnSuccess (True or False)";
        protected const string CONFIG_EIS_DATA_CATEGORY = "Data Category (from Access DB)";

        protected const string PRODUCTION_SUBMISSION_TYPE_NAME = "Production";
        protected const string QA_SUBMISSION_TYPE_NAME = "QA";
        protected const string DATA_CATEGORY_HEADER_KEY = "DataCategory";
        protected const string SUBMISSION_TYPE_HEADER_KEY = "SubmissionType";

        protected const string XSL_REMOVE_EMPTY_TAGS = @"<?xml version=""1.0"" encoding=""UTF-8"" ?>
            <xsl:stylesheet version=""1.0"" xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"">
                <xsl:output omit-xml-declaration=""no"" indent=""no""/>
                <xsl:strip-space elements=""*"" />
                <xsl:template match=""*[not(node()) and not(./@*)]""/>
                <xsl:template match=""@* | node()"">
                    <xsl:copy>
                        <xsl:apply-templates select=""@* | node()""/>
                    </xsl:copy>
                </xsl:template>
            </xsl:stylesheet>";

        public GetEISSubmission()
        {
            
            ConfigurationArguments.Add(CONFIG_SOURCE_DATABASE_PATH, null);
            ConfigurationArguments.Add(CONFIG_DELETE_DATABASE_ON_SUCCESS, null);
            ConfigurationArguments.Add(CONFIG_EIS_DATA_CATEGORY, null);
        }

        public virtual void ProcessSolicit(string requestId)
        {

            LazyInit();

            ValidateRequest(requestId);

            string[] fileNames = Directory.GetFiles(_databasePath, "*.mdb");

            if (fileNames.Length < 1)
            {
                AppendAuditLogEvent(string.Format("No .mdb files found in directory: {0}",_databasePath));
                return;
            }
            _databasePath = fileNames[0];

            AppendAuditLogEvent(string.Format("Processing 1 of {0} file(s): {1}", fileNames.Length, _databasePath));

            GenerateSubmissionFileAndAddToTransaction();

            if (!_passedSchemaValidation)
            {
                throw new InvalidDataException("The XML file did not pass CERS v1.2 schema validation");
            }

            if (_deleteDatabaseOnSuccess)
            {
                if (!FileUtils.SafeDeleteFile(_databasePath))
                {
                    AppendAuditLogEvent("Tried but could not delete database file.");
                }
                else
                {
                    AppendAuditLogEvent("Successfully deleted database.");
                }
            }
        }

        protected virtual void LazyInit()
        {
            AppendAuditLogEvent("Initializing {0} plugin ...", this.GetType().Name);

            GetServiceImplementation(out _serializationHelper);
            GetServiceImplementation(out _compressionHelper);
            GetServiceImplementation(out _documentManager);
            GetServiceImplementation(out _settingsProvider);
            GetServiceImplementation(out _requestManager);

            _databasePath = ValidateNonEmptyConfigParameter(CONFIG_SOURCE_DATABASE_PATH);

            if (!Directory.Exists(_databasePath))
            {
                throw new ArgumentException(string.Format("The database path could not be found: \"{0}\"", _databasePath));
            }

            _dataCategory = ValidateNonEmptyConfigParameter(CONFIG_EIS_DATA_CATEGORY);

            if (_dataCategory.ToUpper() != "POINT" && _dataCategory.ToUpper() != "NONPOINT" && _dataCategory.ToUpper() != "FACILITYINVENTORY")
                throw new ArgumentException(string.Format("The supplied data category is not valid: \"{0}\". Expected 'Point', 'NonPoint' or 'FacilityInventory'.", _dataCategory));

            TryGetConfigParameter(CONFIG_DELETE_DATABASE_ON_SUCCESS, ref _deleteDatabaseOnSuccess);

        }
        protected virtual void ValidateRequest(string requestId)
        {
            AppendAuditLogEvent("Loading request with id \"{0}\"", requestId);
            _dataRequest = _requestManager.GetDataRequest(requestId);

            AppendAuditLogEvent("Validating request: {0}", _dataRequest);
        }

        protected string GenerateSubmissionFile()
        {
            string authorName, organizationName;
            bool isProductionSubmission;

            CERSDataType data = GetCERSData.GetData(this, _databasePath, _dataCategory, out authorName, out organizationName, out isProductionSubmission);

            string tempZipFilePath = _settingsProvider.NewTempFilePath(".zip");
            string tempXmlFilePath = _settingsProvider.NewTempFilePath(".xml");
            string tempXmlCleanFilePath = _settingsProvider.NewTempFilePath(".xml");
            string validationResultsFilePath;

            // Required for the EIS backend parser:
            //XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            //ns.Add("cer", "http://www.exchangenetwork.net/schema/cer/1");
            try
            {
                //_serializationHelper.SerializerNamespaces = ns;
                _serializationHelper.Serialize(data, tempXmlFilePath);

                XmlDocument xsl = new XmlDocument();
                xsl.LoadXml(XSL_REMOVE_EMPTY_TAGS); // constant contains the XSL above

                System.Xml.Xsl.XslCompiledTransform transform = new System.Xml.Xsl.XslCompiledTransform();
                transform.Load(xsl);
                transform.Transform(tempXmlFilePath, tempXmlCleanFilePath);

                validationResultsFilePath = ValidateXmlFile(tempXmlCleanFilePath, "xml_schema.CER_Schema_v1.2.zip", null);

                if (validationResultsFilePath == null)
                {
                    _passedSchemaValidation = true;
                }
                else
                {
                    _passedSchemaValidation = false;
                    _documentManager.AddDocument(_dataRequest.TransactionId,
                                             CommonTransactionStatusCode.Failed,
                                             null, validationResultsFilePath);
                }
                AppendAuditLogEvent("Generating submission file (with an exchange header) from results");

                IHeaderDocument2Helper headerDocumentHelper;
                GetServiceImplementation(out headerDocumentHelper);

                //headerDocumentHelper.SerializerNamespaces = ns;
                // Configure the submission header helper
                headerDocumentHelper.Configure(authorName, organizationName, "EIS", "EIS_v1_0", string.Empty,
                                               string.Empty, null);

                DataCategory submissionDataCategory = data.DataCategory;

                headerDocumentHelper.AddPropery(SUBMISSION_TYPE_HEADER_KEY, 
                                                isProductionSubmission ? PRODUCTION_SUBMISSION_TYPE_NAME : QA_SUBMISSION_TYPE_NAME);
                headerDocumentHelper.AddPropery(DATA_CATEGORY_HEADER_KEY, 
                                                EnumUtils.ToDescription(submissionDataCategory));

                string tempXmlFilePath2 = _settingsProvider.NewTempFilePath(".xml");

                try
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(tempXmlCleanFilePath);

                    headerDocumentHelper.AddPayload(string.Empty, doc.DocumentElement);

                    headerDocumentHelper.Serialize(tempXmlFilePath2);

                    _compressionHelper.CompressFile(tempXmlFilePath2, tempZipFilePath);
                }
                finally
                {
                    FileUtils.SafeDeleteFile(tempXmlFilePath2);
                }
            }
            catch (Exception)
            {
                FileUtils.SafeDeleteFile(tempZipFilePath);
                throw;
            }
            finally
            {
                FileUtils.SafeDeleteFile(tempXmlFilePath);
            }

            return tempZipFilePath;
        }
        protected string GenerateSubmissionFileAndAddToTransaction()
        {
            string submitFile = GenerateSubmissionFile();
            try
            {
                AppendAuditLogEvent("Attaching submission document to transaction \"{0}\"", _dataRequest.TransactionId);

                _documentManager.AddDocument(_dataRequest.TransactionId,
                                             CommonTransactionStatusCode.Completed,
                                             null, submitFile);
            }
            catch (Exception e)
            {
                AppendAuditLogEvent("Failed to attach submission document \"{0}\" to transaction \"{1}\" with exception: {2}",
                                    submitFile, _dataRequest.TransactionId, ExceptionUtils.ToShortString(e));
                FileUtils.SafeDeleteFile(submitFile);
                throw;
            }
            return submitFile;
        }
    }
}
