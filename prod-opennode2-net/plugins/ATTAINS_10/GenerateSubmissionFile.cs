#region License
/*
Copyright (c) 2011, The Environmental Council of the States (ECOS)
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
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Xml;
using Windsor.Commons.Core;
using Windsor.Commons.Logging;
using Windsor.Commons.NodeDomain;
using Windsor.Commons.Spring;
using Windsor.Commons.XsdOrm2;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSPlugin;
using Windsor.Node2008.WNOSProviders;

namespace Windsor.Node2008.WNOSPlugin.ATTAINS_10
{
    /// <summary>
    /// Generates an ATTAINS xml file from the database and adds it to the transaction.
    /// </summary>
    [Serializable]
    public class GenerateSubmissionFile : BaseWNOSPlugin, ITaskProcessor
    {
        protected enum DataSourceParams
        {
            None,
            [Description("Data Source")]
            DataSource,
        }
        protected enum ConfigParams
        {
            None,
            [Description("Author Name")]
            AuthorName,
            [Description("Organization Name")]
            OrganizationName,
            [Description("Document Title")]
            DocumentTitle,
            [Description("Sender Address")]
            SenderAddress,
            [Description("Sender Contact")]
            SenderContact,
            [Description("Payload Operation (\"Update-Insert\" or \"Delete\")")]
            PayloadOperation,
            [Description("Validate Xml (True or False)")]
            ValidateXml,
        }
        #region fields

        protected static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());

        protected const string FLOW_NAME = "ATTAINS";
        protected const string UPDATE_INSERT_OPERATION_NAME = "Update-Insert";
        protected const string DELETE_OPERATION_NAME = "Delete";

        protected IRequestManager _requestManager;
        protected ISerializationHelper _serializationHelper;
        protected ICompressionHelper _compressionHelper;
        protected IDocumentManager _documentManager;
        protected ISettingsProvider _settingsProvider;
        protected IObjectsFromDatabase _objectsFromDatabase;

        protected SpringBaseDao _baseDao;
        protected DataRequest _dataRequest;
        protected string _authorName;
        protected string _organizationName;
        protected string _documentTitle;
        protected string _senderAddress;
        protected string _senderContact;
        protected string _payloadOperation;
        protected bool _validateXml;

        #endregion

        public GenerateSubmissionFile()
        {
            AppendConfigArguments<ConfigParams>();

            AppendDataProviders<DataSourceParams>();
        }

        public virtual void ProcessTask(string requestId)
        {
            // Entry point for task processor plugin

            ProcessTaskInit(requestId);

            GenerateSubmissionFileAndAddToTransaction();
        }

        public virtual void ProcessTaskInit(string requestId)
        {
            LazyInit();

            ValidateRequest(requestId);
        }
        protected virtual void LazyInit()
        {
            AppendAuditLogEvent("Initializing {0} plugin ...", this.GetType().Name);

            GetServiceImplementation(out _requestManager);
            GetServiceImplementation(out _serializationHelper);
            GetServiceImplementation(out _compressionHelper);
            GetServiceImplementation(out _documentManager);
            GetServiceImplementation(out _settingsProvider);
            GetServiceImplementation(out _objectsFromDatabase);

            // Load config parameters

            _authorName = ValidateNonEmptyConfigParameter(EnumUtils.ToDescription(ConfigParams.AuthorName));
            _organizationName = ValidateNonEmptyConfigParameter(EnumUtils.ToDescription(ConfigParams.OrganizationName));
            _documentTitle = ValidateNonEmptyConfigParameter(EnumUtils.ToDescription(ConfigParams.DocumentTitle));
            _senderAddress = ValidateNonEmptyConfigParameter(EnumUtils.ToDescription(ConfigParams.SenderAddress));
            _senderContact = ValidateNonEmptyConfigParameter(EnumUtils.ToDescription(ConfigParams.SenderContact));
            _payloadOperation = ValidateNonEmptyConfigParameter(EnumUtils.ToDescription(ConfigParams.PayloadOperation));
            if (string.Equals(_payloadOperation, UPDATE_INSERT_OPERATION_NAME, StringComparison.OrdinalIgnoreCase))
            {
                _payloadOperation = UPDATE_INSERT_OPERATION_NAME;
            }
            else if (string.Equals(_payloadOperation, DELETE_OPERATION_NAME, StringComparison.OrdinalIgnoreCase))
            {
                _payloadOperation = DELETE_OPERATION_NAME;
            }
            else
            {
                throw new ArgException("The \"{0}\" configuration parameter must be either \"{1}\" or \"{2}\"",
                                       EnumUtils.ToDescription(ConfigParams.PayloadOperation), UPDATE_INSERT_OPERATION_NAME,
                                       DELETE_OPERATION_NAME);
            }
            TryGetConfigParameter(EnumUtils.ToDescription(ConfigParams.ValidateXml), ref _validateXml);

            AppendAuditLogEvent("Loaded the following configuration parameters: {0} ({1}), {2} ({3}), {4} ({5}), {6} ({7}), {8} ({9}), {10} ({11}), {12} ({13})",
                                EnumUtils.ToDescription(ConfigParams.AuthorName), _authorName,
                                EnumUtils.ToDescription(ConfigParams.OrganizationName), _organizationName,
                                EnumUtils.ToDescription(ConfigParams.DocumentTitle), _documentTitle,
                                EnumUtils.ToDescription(ConfigParams.SenderAddress), _senderAddress,
                                EnumUtils.ToDescription(ConfigParams.SenderContact), _senderContact,
                                EnumUtils.ToDescription(ConfigParams.PayloadOperation), _payloadOperation,
                                EnumUtils.ToDescription(ConfigParams.ValidateXml), _validateXml);

            // Load database provider

            _baseDao = ValidateDBProvider(EnumUtils.ToDescription(DataSourceParams.DataSource),
                                          typeof(NamedNullMappingDataReader));
        }
        protected virtual void ValidateRequest(string requestId)
        {
            AppendAuditLogEvent("Loading request with id \"{0}\"", requestId);
            _dataRequest = _requestManager.GetDataRequest(requestId);

            AppendAuditLogEvent("Validating request: {0}", _dataRequest);
        }
        protected string GenerateSubmissionFileAndAddToTransaction()
        {
            AppendAuditLogEvent("Generating submission xml file ...");

            // Load data from database

            List<Organization> dataList =
                _objectsFromDatabase.LoadFromDatabase<Organization>(_baseDao, null, typeof(MappingAttributes));

            if (CollectionUtils.IsNullOrEmpty(dataList))
            {
                throw new ArgumentException(string.Format("No {0} data was found to submit", FLOW_NAME));
            }
            else if (dataList.Count > 1)
            {
                throw new ArgumentException(string.Format("More than one set of {0} data was found to submit", FLOW_NAME));
            }
            else
            {
                Organization data = dataList[0];
                AppendAuditLogEvent(GetSubmissionResultsString(data));

                // Serialize data to xml and attach the xml file to the task transaction

                return GenerateSubmissionFileAndAddToTransaction(data);
            }
        }
        protected string GetSubmissionResultsString(Organization data)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Found the following ATTAINS submission data: ");
            int i = 0;
            AppendCountString("Actions", data.Actions, ++i == 1, sb);
            AppendCountString("Assessment Units", data.AssessmentUnits, ++i == 1, sb);
            AppendCountString("Organization Contacts", data.OrganizationContacts, ++i == 1, sb);
            AppendCountString("Reporting Cycles", data.ReportingCycle, ++i == 1, sb);
            AppendCountString("Priorities", data.Priorities, ++i == 1, sb);
            return sb.ToString();
        }
        protected void AppendCountString(string collectionName, ICollection collection, bool isFirst,
                                         StringBuilder sb)
        {
            if (!isFirst)
            {
                sb.Append(", ");
            }
            int count = CollectionUtils.IsNullOrEmpty(collection) ? 0 : collection.Count;
            sb.AppendFormat("{0} {1}", count.ToString(), collectionName);
        }
        protected string CreateSubmissionFile(Organization data)
        {
            string tempZipFilePath = _settingsProvider.NewTempFilePath(".zip");
            string tempXmlFilePath = _settingsProvider.NewTempFilePath(".xml");
            try
            {
                var content = new ATTAINSDataType()
                {
                    Organization = new Organization[] { data }
                };
                AppendAuditLogEvent("Serializing data to an xml file");
                _serializationHelper.Serialize(content, tempXmlFilePath);

                if (_validateXml)
                {
                    ValidateXmlFileAndAttachErrorsAndFileToTransaction(tempXmlFilePath, "xml_schema.xml_schema.zip",
                                                                       null, _dataRequest.TransactionId);
                }

                AppendAuditLogEvent("Generating submission file (with an exchange header) from results");

                IHeaderDocument2Helper headerDocumentHelper;
                GetServiceImplementation(out headerDocumentHelper);

                // Configure the submission exchange header and add header to xml file
                headerDocumentHelper.Configure(_authorName, _organizationName, _documentTitle, FLOW_NAME,
                                               null, _senderContact, null, null);
                headerDocumentHelper.AddNotification(_senderAddress);

                string tempXmlFilePath2 = _settingsProvider.NewTempFilePath(".xml");
                try
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(tempXmlFilePath);

                    headerDocumentHelper.AddPayload(_payloadOperation, doc.DocumentElement);

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
        protected string GenerateSubmissionFileAndAddToTransaction(Organization data)
        {
            // Serialize data to xml

            string submitFile = CreateSubmissionFile(data);

            try
            {
                // Attach the xml file to the task transaction

                AppendAuditLogEvent("Attaching submission document to transaction \"{0}\"",
                                    _dataRequest.TransactionId);
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
