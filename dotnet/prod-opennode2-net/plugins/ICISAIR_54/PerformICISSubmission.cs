//#define XML_LOAD_ONLY
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
using Windsor.Commons.Core;
using Windsor.Commons.NodeClient;
using Windsor.Commons.Spring;
using Windsor.Commons.XsdOrm2;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSProviders;
using System.Text;
using Windsor.Commons.NodeDomain;
using System.IO;

namespace Windsor.Node2008.WNOSPlugin.ICISAIR_54
{
    [Serializable]
    public class PerformICISSubmission : ExecuteICISExtract
    {
        public const string ICIS_SUBMISSION_XML_FILENAME = "ICISSubmission.xml";
        public const string ICIS_SUBMISSION_ZIP_FILENAME = "ICISSubmission.zip";

        protected const string DATA_PARAM_STAGING_SOURCE = "Staging Data Source";

        protected const string CONFIG_PARAM_AUTHOR = "Author";
        protected const string CONFIG_PARAM_ORGANIZATION = "Organization";
        protected const string CONFIG_PARAM_CONTACT_INFO = "Contact Info";
        protected const string CONFIG_PARAM_SUBMISSION_PARTNER_NAME = "Submission Partner Name";
        protected const string CONFIG_PARAM_VALIDATE_XML = "Validate Xml (true or false)";
        protected const string CONFIG_PARAM_USER_ID = "ICIS User Id";
        protected const string CONFIG_PARAM_NOTIFY_EMAILS = "Notification Emails (semicolon separated)";
        protected const string CONFIG_PARAM_ICIS_FLOW_NAME = "ICIS Flow Name";

        protected string _author;
        protected string _organization;
        protected string _contactInfo;
        protected string _userId;
        protected IList<string> _notificationEmails;
        protected PartnerIdentity _submissionPartner;
        protected bool _validateXml = true;
        protected string _flowName = "ICIS-AIR";

        protected SpringBaseDao _stagingDao;
        protected SubmissionTrackingDataType _submissionTrackingDataType;

        protected ISerializationHelper _serializationHelper;
        protected ICompressionHelper _compressionHelper;
        protected IDocumentManager _documentManager;
        protected ISettingsProvider _settingsProvider;
        protected INodeEndpointClientFactory _nodeEndpointClientFactory;
        protected ITransactionManager _transactionManager;
        protected IObjectsFromDatabase _objectsFromDatabase;

        public PerformICISSubmission()
        {
            DataProviders[DATA_PARAM_STAGING_SOURCE] = null;

            ConfigurationArguments[CONFIG_PARAM_AUTHOR] = null;
            ConfigurationArguments[CONFIG_PARAM_ORGANIZATION] = null;
            ConfigurationArguments[CONFIG_PARAM_CONTACT_INFO] = null;
            ConfigurationArguments[CONFIG_PARAM_SUBMISSION_PARTNER_NAME] = null;
            ConfigurationArguments[CONFIG_PARAM_VALIDATE_XML] = null;
            ConfigurationArguments[CONFIG_PARAM_USER_ID] = null;
            ConfigurationArguments[CONFIG_PARAM_NOTIFY_EMAILS] = null;
            ConfigurationArguments[CONFIG_PARAM_ICIS_FLOW_NAME] = null;
        }
        public override void ProcessTask(string requestId)
        {
            ProcessTaskInit(requestId);

#if !XML_LOAD_ONLY

            _submissionTrackingDataType = SubmissionTrackingTableHelper.GetActiveSubmissionTrackingElement(_stagingDao, out _submissionTrackingDataTypePK);

            if (_submissionTrackingDataType == null)
            {
                _submissionTrackingDataType = new SubmissionTrackingDataType();
            }

            if (_submissionTrackingDataType.WorkflowStatus == TransactionStatusCode.Pending && _submissionTrackingDataType.ETLCompletionDateTimeSpecified == false)
            {
                AppendAuditLogEvent("Previous ETL execution in the tracking table with primary key \"{0}\" did not complete due to unrecoverable database error. Setting transaction to Failed."
                    , _submissionTrackingDataTypePK);
                // Update submission status in tracking table
                _submissionTrackingDataType.WorkflowStatus = TransactionStatusCode.Failed;
                _submissionTrackingDataType.WorkflowStatusMessage = "ETL did not complete due to unrecoverable database error";
                SubmissionTrackingTableHelper.Update(_stagingDao, _submissionTrackingDataTypePK, _submissionTrackingDataType);

                //create a new submission tracking record for the current workflow execution
                _submissionTrackingDataType = new SubmissionTrackingDataType();
                _submissionTrackingDataTypePK = null;
            }
            else if (_submissionTrackingDataType.SubmissionDateTimeSpecified)
            {
                DebugUtils.AssertDebuggerBreak(_submissionTrackingDataTypePK != null);
                AppendAuditLogEvent("There is a pending partner submission in the tracking table with primary key \"{0}\", exiting plugin ...",
                                    _submissionTrackingDataTypePK);
                return;
            }
#endif // !XML_LOAD_ONLY
            try
            {
#if !XML_LOAD_ONLY
                // Attempt to run the ETL to populate staging tables
                if (!DoExtract())
                {
                    return;
                }
                DebugUtils.AssertDebuggerBreak(_submissionTrackingDataTypePK != null);
#endif // !XML_LOAD_ONLY

                // Attempt to load the submission file from staging
                string submitFilePath;
                if (!DoXmlLoad(out submitFilePath))
                {
                    return;
                }

#if !XML_LOAD_ONLY
                // Attempt to submit file
                string submitTransactionId;
                if (!DoSubmission(submitFilePath, out submitTransactionId))
                {
                    return;
                }

                // Update submission status in tracking table
                _submissionTrackingDataType.WorkflowStatus = TransactionStatusCode.Pending;
                _submissionTrackingDataType.WorkflowStatusMessage = "The ICIS data has been submitted";
                _submissionTrackingDataType.SubmissionDateTime = DateTime.Now;
                _submissionTrackingDataType.SubmissionDateTimeSpecified = true;
                _submissionTrackingDataType.SubmissionTransactionId = submitTransactionId;
                SubmissionTrackingTableHelper.Update(_stagingDao, _submissionTrackingDataTypePK, _submissionTrackingDataType);
#endif // !XML_LOAD_ONLY
            }
#if XML_LOAD_ONLY
            catch (Exception)
            {
                throw;
            }
#else // XML_LOAD_ONLY
            catch (Exception ex)
            {
                if (_submissionTrackingDataTypePK != null)
                {
                    _submissionTrackingDataType.WorkflowStatus = TransactionStatusCode.Failed;
                    _submissionTrackingDataType.WorkflowStatusMessage = string.Format("An error occurred during processing: {0}", ExceptionUtils.GetDeepExceptionMessage(ex));
                    SubmissionTrackingTableHelper.Update(_stagingDao, _submissionTrackingDataTypePK, _submissionTrackingDataType);
                }
                throw;
            }
#endif // !XML_LOAD_ONLY
        }
        protected virtual bool DoXmlLoad(out string submitFilePath)
        {
            submitFilePath = null;
            Type mappingAttributesType = typeof(Windsor.Node2008.WNOSPlugin.ICISAIR_54.MappingAttributes);
            IDictionary<string, DbAppendSelectWhereClause> selectClauses = Windsor.Node2008.WNOSPlugin.ICISAIR_54.Payload.GetDefaultSelectClauses(_stagingDao);
            List<Windsor.Node2008.WNOSPlugin.ICISAIR_54.Payload> payloads =
                _objectsFromDatabase.LoadFromDatabase<Windsor.Node2008.WNOSPlugin.ICISAIR_54.Payload>(_stagingDao, selectClauses, mappingAttributesType);

            // Remove payloads that don't contain any data
            if (payloads != null)
            {
                for (int i = payloads.Count - 1; i >= 0; i--)
                {
                    if (CollectionUtils.IsNullOrEmpty(payloads[i].Items))
                    {
                        // TSM: Is this log really necessary?
                        //AppendAuditLogEvent(string.Format("The payload with operation \"{0}\" will not be included in the submission because it does not contain any data", payloads[i].Operation.ToString()));
                        payloads.RemoveAt(i);
                    }
                }
            }

#if !XML_LOAD_ONLY
            if (CollectionUtils.IsNullOrEmpty(payloads))
            {
                _submissionTrackingDataType.WorkflowStatus = TransactionStatusCode.Completed;
                _submissionTrackingDataType.WorkflowStatusMessage = "The staging database does not contain any payloads to submit";
                AppendAuditLogEvent(_submissionTrackingDataType.WorkflowStatusMessage + ", exiting plugin ...");
                SubmissionTrackingTableHelper.Update(_stagingDao, _submissionTrackingDataTypePK, _submissionTrackingDataType);
                return false;
            }
#endif // !XML_LOAD_ONLY

            AppendAuditLogEvent("The following ICIS payload(s) were loaded from the database: {0}", GetPayloadsDescription(payloads));

            Windsor.Node2008.WNOSPlugin.ICISAIR_54.Document document = new Document();

            document.Payload = payloads.ToArray();
            document.Header = CreateHeader();

            string tempFolder = _settingsProvider.CreateNewTempFolderPath();
            string tempXmlPath = Path.Combine(tempFolder, ICIS_SUBMISSION_XML_FILENAME);
            string tempZipPath = Path.Combine(tempFolder, ICIS_SUBMISSION_ZIP_FILENAME);

            try
            {
                AppendAuditLogEvent("Serializing ICIS payload(s) to xml ...");

                _serializationHelper.Serialize(document, tempXmlPath);

                if (_validateXml)
                {
                    ValidateXmlFileAndAttachErrorsAndFileToTransaction(tempXmlPath, "xml_schema.xml_schema.zip",
                                                                       null, _dataRequest.TransactionId);
                }

                _compressionHelper.CompressFile(tempXmlPath, tempZipPath);

                _documentManager.AddDocument(_dataRequest.TransactionId, CommonTransactionStatusCode.Completed, null, tempZipPath);
            }
            catch (Exception)
            {
                FileUtils.SafeDeleteFile(tempZipPath);
                throw;
            }
            finally
            {
                FileUtils.SafeDeleteFile(tempXmlPath);
            }

            submitFilePath = tempZipPath;

            return true;
        }
        protected virtual bool DoSubmission(string submitFilePath, out string submitTransactionId)
        {
            submitTransactionId = null;

            if (_submissionPartner == null)
            {
                AppendAuditLogEvent("The \"{0}\" config param was not specified. Plugin will not submit.", CONFIG_PARAM_SUBMISSION_PARTNER_NAME);
                _submissionTrackingDataType.WorkflowStatus = TransactionStatusCode.Completed;
                _submissionTrackingDataType.WorkflowStatusMessage = "A submission partner was not specified";
                SubmissionTrackingTableHelper.Update(_stagingDao, _submissionTrackingDataTypePK, _submissionTrackingDataType);
                return false;
            }
            try
            {
                AppendAuditLogEvent("Submitting ICIS document to partner \"{0}\"", _submissionPartner.Name);

                submitTransactionId =
                    SubmitFileToPartner(_dataRequest.TransactionId, _submissionPartner, _flowName, null, submitFilePath);
            }
            finally
            {
                FileUtils.SafeDeleteFile(submitFilePath);
            }

            return true;
        }
        protected virtual Header CreateHeader()
        {
            Header header = new Header();
            header.Author = _author;
            header.ContactInfo = _contactInfo;
            header.Organization = _organization;
            header.Id = _userId;
            List<Property> properties = new List<Property>();
            properties.Add(new Property()
            {
                name = name.Source,
                value = "FullBatch"
            });
            if (!CollectionUtils.IsNullOrEmpty(_notificationEmails))
            {
                CollectionUtils.ForEach(_notificationEmails, delegate(string email)
                {
                    properties.Add(new Property()
                    {
                        name = name.email,
                        value = email
                    });
                });

            }
            header.Property = properties.ToArray();
            return header;
        }
        protected virtual string GetPayloadsDescription(IList<Windsor.Node2008.WNOSPlugin.ICISAIR_54.Payload> payloads)
        {
            StringBuilder sb = new StringBuilder();
            CollectionUtils.ForEach(payloads, delegate(Windsor.Node2008.WNOSPlugin.ICISAIR_54.Payload payload)
            {
                if (sb.Length > 0)
                {
                    sb.Append(", ");
                }
                sb.AppendFormat("{0} ({1})", payload.Operation.ToString(), CollectionUtils.Count(payload.Items).ToString());
            });
            return sb.ToString();
        }
        protected virtual bool DoExtract()
        {
            if (!_submissionTrackingDataType.ETLCompletionDateTimeSpecified || !_submissionTrackingDataType.DETChangeCompletionDateTimeSpecified)
            {
                // Attempt to run the ETL to populate staging tables
                if (_submissionTrackingDataType.ETLCompletionDateTimeSpecified || _submissionTrackingDataType.DETChangeCompletionDateTimeSpecified)
                {
                    // Both must be specified, or neither must be specified
                    throw new ArgException("Both ETL completion dates have not been set for row {0} in the submission tracking table",
                                           _submissionTrackingDataTypePK);
                }
                if (string.IsNullOrEmpty(_storedProcName))
                {
                    AppendAuditLogEvent("The \"{0}\" config param has not been specified for the service and the ETL stored procedure has not executed, so the service cannot continue, exiting plugin ...",
                                        CONFIG_PARAM_ETL_NAME);
                    return false;
                }
                _submissionTrackingDataTypePK = DoExtract(this, _etlDao, _storedProcName, _commandTimeout);
                if (_submissionTrackingDataTypePK == null)
                {
                    AppendAuditLogEvent("The ETL stored procedure indicated that this service should not continue, exiting plugin ...");
                    return false;
                }

                _submissionTrackingDataType = SubmissionTrackingTableHelper.GetActiveSubmissionTrackingElement(_stagingDao, _submissionTrackingDataTypePK);
            }
            else
            {
                AppendAuditLogEvent("The ETL stored procedure has already run as referenced by row {0} in the submission tracking table with status \"{1}\" ...",
                                    _submissionTrackingDataTypePK, _submissionTrackingDataType.WorkflowStatus.ToString());
            }
            return true;
        }
        protected override void LazyInit()
        {
            base.LazyInit();

            _stagingDao = ValidateDBProvider(DATA_PARAM_STAGING_SOURCE, typeof(NamedNullMappingDataReader));

            GetConfigParameter(CONFIG_PARAM_USER_ID, out _userId);
            TryGetConfigParameter(CONFIG_PARAM_AUTHOR, ref _author);
            TryGetConfigParameter(CONFIG_PARAM_ORGANIZATION, ref _organization);
            TryGetConfigParameter(CONFIG_PARAM_CONTACT_INFO, ref _contactInfo);

            string notificationEmails = null;
            if (TryGetConfigParameter(CONFIG_PARAM_NOTIFY_EMAILS, ref notificationEmails))
            {
                _notificationEmails = StringUtils.SplitAndReallyRemoveEmptyEntries(notificationEmails, ';');
            }

            TryGetConfigParameter(CONFIG_PARAM_ICIS_FLOW_NAME, ref _flowName);

            TryGetConfigParameter(CONFIG_PARAM_VALIDATE_XML, ref _validateXml);

            _submissionPartner = TryGetConfigNetworkPartner(CONFIG_PARAM_SUBMISSION_PARTNER_NAME);

            GetServiceImplementation(out _serializationHelper);
            GetServiceImplementation(out _compressionHelper);
            GetServiceImplementation(out _documentManager);
            GetServiceImplementation(out _settingsProvider);
            GetServiceImplementation(out _nodeEndpointClientFactory);
            GetServiceImplementation(out _transactionManager);
            GetServiceImplementation(out _objectsFromDatabase);
        }
    }
}
