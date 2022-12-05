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
using Windsor.Commons.XsdOrm;
using Windsor.Commons.NodeDomain;
using Windsor.Commons.NodeClient;

namespace Windsor.Node2008.WNOSPlugin.RCRA_512
{
    [Serializable]
    public abstract class BasePerformRCRASubmission<T> : BaseRCRASubmissionPlugin where T : class
    {
        #region fields

        protected ISerializationHelper _serializationHelper;
        protected ICompressionHelper _compressionHelper;
        protected IDocumentManager _documentManager;
        protected IObjectsFromDatabase _objectsFromDatabase;
        protected IHeaderDocumentHelper _headerDocumentHelper;
        protected IPartnerManager _partnerManager;
        protected ISettingsProvider _settingsProvider;
        protected INodeEndpointClientFactory _nodeEndpointClientFactory;
        protected ITransactionManager _transactionManager;

        protected bool _addHeader;
        protected string _author;
        protected string _organization;
        protected string _contactInfo;
        protected string _notifications;
        protected string _payloadOperation;
        protected string _title;
        protected string _rcraInfoUserId;
        protected string _rcraInfoStateCode;
        protected PartnerIdentity _submitPartnerNode;
        protected string _submitUsername;
        protected Dictionary<string, UserSubmitInfo> _naasUsernameToPasswordMap;
        protected bool _validateXml;

        protected const string CONFIG_ADD_HEADER = "Add Header";
        protected const string CONFIG_AUTHOR = "Author";
        protected const string CONFIG_ORGANIZATION = "Organization";
        protected const string CONFIG_CONTACT_INFO = "Contact Info";
        protected const string CONFIG_NOTIFICATIONS = "Notifications";
        protected const string CONFIG_PAYLOAD_OPERATION = "Payload Operation";
        protected const string CONFIG_TITLE = "Title";
        protected const string CONFIG_RCRA_INFO_USER_ID = "RCRAInfoUserID";
        protected const string CONFIG_RCRA_INFO_STATE_CODE = "RCRAInfoStateCode";
        protected const string CONFIG_NAAS_USER_MAPPING_FILE_PATH = "NAAS User Mapping File Path";
        protected const string CONFIG_SUBMISSION_PARTNER_NAME = "Submission Partner Name";
        protected const string CONFIG_VALIDATE_XML = "Validate Xml (True or False)";

        protected const string PARAM_NAAS_SUBMIT_USERNAME = "SubmitUsername";
        #endregion

        public BasePerformRCRASubmission()
        {
            _useSubmissionHistoryTable = true; // By default
            
            ConfigurationArguments.Add(CONFIG_ADD_HEADER, null);
            ConfigurationArguments.Add(CONFIG_AUTHOR, null);
            ConfigurationArguments.Add(CONFIG_ORGANIZATION, null);
            ConfigurationArguments.Add(CONFIG_CONTACT_INFO, null);
            ConfigurationArguments.Add(CONFIG_NOTIFICATIONS, null);
            ConfigurationArguments.Add(CONFIG_PAYLOAD_OPERATION, null);
            ConfigurationArguments.Add(CONFIG_TITLE, null);
            ConfigurationArguments.Add(CONFIG_RCRA_INFO_USER_ID, null);
            ConfigurationArguments.Add(CONFIG_RCRA_INFO_STATE_CODE, null);
            ConfigurationArguments.Add(CONFIG_NAAS_USER_MAPPING_FILE_PATH, null);
            ConfigurationArguments.Add(CONFIG_SUBMISSION_PARTNER_NAME, null);
            ConfigurationArguments.Add(CONFIG_VALIDATE_XML, null);
        }

        public override void ProcessTask(string requestId)
        {
            base.ProcessTask(requestId);

            CheckForPendingSubmissions(_baseDao);

            PrepareForSubmission();

            string recordId = SetPendingSubmission(_baseDao, _scheduleRunDate);

            try
            {
                PerformSubmission();

                UpdatePendingSubmissionInfo(_baseDao, recordId, _dataRequest.TransactionId);
            }
            catch (Exception)
            {
                SetSubmissionFailed(_baseDao, recordId);
                throw;
            }
        }
        protected override void LazyInit()
        {
            base.LazyInit();

            GetServiceImplementation(out _serializationHelper);
            GetServiceImplementation(out _compressionHelper);
            GetServiceImplementation(out _documentManager);
            GetServiceImplementation(out _objectsFromDatabase);
            GetServiceImplementation(out _headerDocumentHelper);
            GetServiceImplementation(out _partnerManager);
            GetServiceImplementation(out _settingsProvider);
            GetServiceImplementation(out _nodeEndpointClientFactory);
            GetServiceImplementation(out _transactionManager);

            GetConfigParameter(CONFIG_ADD_HEADER, true, out _addHeader);
            _author = ValidateNonEmptyConfigParameter(CONFIG_AUTHOR);
            _organization = ValidateNonEmptyConfigParameter(CONFIG_ORGANIZATION);
            _contactInfo = ValidateNonEmptyConfigParameter(CONFIG_CONTACT_INFO);
            _payloadOperation = ValidateNonEmptyConfigParameter(CONFIG_PAYLOAD_OPERATION);
            _title = ValidateNonEmptyConfigParameter(CONFIG_TITLE);
            TryGetConfigParameter(CONFIG_NOTIFICATIONS, ref _notifications);
            _rcraInfoUserId = ValidateNonEmptyConfigParameter(CONFIG_RCRA_INFO_USER_ID);
            _rcraInfoStateCode = ValidateNonEmptyConfigParameter(CONFIG_RCRA_INFO_STATE_CODE);

            ParseNaasUserMappingFile();

            string submitPartnerName = null;
            if (TryGetConfigParameter(CONFIG_SUBMISSION_PARTNER_NAME, ref submitPartnerName))
            {
                _submitPartnerNode = _partnerManager.GetByName(submitPartnerName);
                if (_submitPartnerNode == null)
                {
                    throw new ArgumentException(string.Format("A submission partner with the name \"{0}\" specified for this service cannot be found",
                                                              submitPartnerName));
                }
            }
            if (_submitPartnerNode != null)
            {
                if (_naasUsernameToPasswordMap == null)
                {
                    throw new ArgumentException(string.Format("The service specifies a \"{0},\" but does not specify a \"{1}\"",
                                                              CONFIG_SUBMISSION_PARTNER_NAME, CONFIG_NAAS_USER_MAPPING_FILE_PATH));
                }
            }
            else if (_naasUsernameToPasswordMap != null)
            {
                if (_submitPartnerNode == null)
                {
                    throw new ArgumentException(string.Format("The service specifies a \"{0},\" but does not specify a \"{1}\"",
                                                              CONFIG_NAAS_USER_MAPPING_FILE_PATH, CONFIG_SUBMISSION_PARTNER_NAME));
                }
            }
            TryGetConfigParameter(CONFIG_VALIDATE_XML, ref _validateXml);
        }
        protected void ParseNaasUserMappingFile()
        {
            string naasUserMappingFilePath = null;
            TryGetConfigParameter(CONFIG_NAAS_USER_MAPPING_FILE_PATH, ref naasUserMappingFilePath);
            _naasUsernameToPasswordMap = RCRABaseSolicitProcessor.ParseNaasUserMappingFile(naasUserMappingFilePath, this);
        }
        protected override void ValidateRequest(string requestId)
        {
            base.ValidateRequest(requestId);

            TryGetParameter(_dataRequest, PARAM_USE_SUBMISSION_HISTORY_TABLE_KEY, 0, ref _useSubmissionHistoryTable);

            if (TryGetParameter(_dataRequest, PARAM_NAAS_SUBMIT_USERNAME, 1, ref _submitUsername))
            {
                if (_naasUsernameToPasswordMap == null)
                {
                    throw new ArgumentException(string.Format("A request parameter \"{0}\" = \"{1}\" was specified, but the service does not specify a \"{2}\" config parameter",
                                                              PARAM_NAAS_SUBMIT_USERNAME, _submitUsername, CONFIG_NAAS_USER_MAPPING_FILE_PATH));
                }
                if (!_naasUsernameToPasswordMap.ContainsKey(_submitUsername.ToUpper()))
                {
                    throw new ArgumentException(string.Format("A request parameter \"{0}\" = \"{1}\" was specified, but the username was not found in the mapping file specified by the \"{2}\" config parameter",
                                                              PARAM_NAAS_SUBMIT_USERNAME, _submitUsername, CONFIG_NAAS_USER_MAPPING_FILE_PATH));
                }
                UserSubmitInfo userSubmitInfo = _naasUsernameToPasswordMap[_submitUsername.ToUpper()];
                _rcraInfoUserId = userSubmitInfo.RCRAInfoUserID;
                AppendAuditLogEvent("{0}: {1}", PARAM_NAAS_SUBMIT_USERNAME, _submitUsername);
            }
            else
            {
                AppendAuditLogEvent("{0} was not specified", PARAM_NAAS_SUBMIT_USERNAME);
            }

        }
        protected virtual string GenerateSubmissionFile(T data)
        {
            string serializedFilePath = null;
            try
            {
                if (_addHeader)
                {
                    AppendAuditLogEvent("Serializing results and making header...");
                    serializedFilePath = MakeHeaderFile(data);
                }
                else
                {
                    AppendAuditLogEvent("Serializing results to file...");
                    serializedFilePath = _serializationHelper.SerializeToTempFile(data);
                    if (_validateXml)
                    {
                        ValidateXmlFileAndAttachErrorsAndFileToTransaction(serializedFilePath, "xml_schema.xml_schema.zip",
                                                                           null, _dataRequest.TransactionId);
                    }
                }
            }
            catch (Exception)
            {
                FileUtils.SafeDeleteFile(serializedFilePath);
                throw;
            }
            return serializedFilePath;
        }
        protected string MakeHeaderFile(T dataObject)
        {
            string tempXmlFilePath = null, tempXmlFilePath2 = null;

            try
            {
                ISettingsProvider settingsProvider;
                GetServiceImplementation(out settingsProvider);

                // Configure the submission header helper
                _headerDocumentHelper.Configure(_author, _organization, _title, null, _contactInfo, null);
                _headerDocumentHelper.AddNotifications(_notifications);
                _headerDocumentHelper.AddPropery("RCRAInfoStateCode", _rcraInfoStateCode);
                _headerDocumentHelper.AddPropery("RCRAInfoUserID", _rcraInfoUserId);

                tempXmlFilePath = settingsProvider.NewTempFilePath(".xml");
                _serializationHelper.Serialize(dataObject, tempXmlFilePath);

                if (_validateXml)
                {
                    ValidateXmlFileAndAttachErrorsAndFileToTransaction(tempXmlFilePath, "xml_schema.xml_schema.zip",
                                                                       null, _dataRequest.TransactionId);
                }

                XmlDocument doc = new XmlDocument();
                doc.Load(tempXmlFilePath);

                _headerDocumentHelper.AddPayload(_payloadOperation, doc.DocumentElement);
                tempXmlFilePath2 = settingsProvider.NewTempFilePath(".xml");

                _headerDocumentHelper.Serialize(tempXmlFilePath2);

                return tempXmlFilePath2;
            }
            catch (Exception)
            {
                FileUtils.SafeDeleteFile(tempXmlFilePath2);
                throw;
            }
            finally
            {
                FileUtils.SafeDeleteFile(tempXmlFilePath);
            }
        }
        protected virtual string GenerateSubmissionFileAndAddToTransaction(T data)
        {
            string submitFile = GenerateSubmissionFile(data);
            string zippedFile = _settingsProvider.NewTempFilePath(".zip");
            try
            {
                _compressionHelper.CompressFile(submitFile, zippedFile);

                AppendAuditLogEvent("Attaching submission document to transaction \"{0}\"",
                                    _dataRequest.TransactionId);
                _documentManager.AddDocument(_dataRequest.TransactionId,
                                             CommonTransactionStatusCode.Completed,
                                             null, zippedFile);
            }
            catch (Exception e)
            {
                AppendAuditLogEvent("Failed to attach submission document \"{0}\" to transaction \"{1}\" with exception: {2}",
                                    submitFile, _dataRequest.TransactionId, ExceptionUtils.ToShortString(e));
                FileUtils.SafeDeleteFile(zippedFile);
                throw;
            }
            finally
            {
                FileUtils.SafeDeleteFile(submitFile);
            }
            return zippedFile;
        }
        protected virtual void PerformSubmission()
        {
            List<T> dataList = GetSubmissionData();

            if (CollectionUtils.IsNullOrEmpty(dataList))
            {
                throw new InvalidOperationException("The staging database does not contain any RCRA data.");
            }
            else if (dataList.Count > 1)
            {
                throw new InvalidOperationException(string.Format("The staging database contains more that one set of RCRA data ({0} sets).",
                                                                  dataList.Count));
            }
            T data = dataList[0];

            AppendAuditLogCountsString(data);

            string submissionFile = GenerateSubmissionFileAndAddToTransaction(data);

            ProcessSubmissionFile(submissionFile);
        }
        protected abstract List<T> GetSubmissionData();
        protected abstract void AppendAuditLogCountsString(T data);

        protected virtual void PrepareForSubmission()
        {
        }
        protected virtual void ProcessSubmissionFile(string submissionFile)
        {
            if (_submitUsername != null)
            {
                SubmitFile(submissionFile, _dataRequest.TransactionId);
            }
        }
        public string SubmitFile(string filePath, string localTransactionId)
        {
            string transactionId;
            try
            {
                UserSubmitInfo userSubmitInfo = _naasUsernameToPasswordMap[_submitUsername.ToUpper()];
                AppendAuditLogEvent("Submitting results to endpoint \"{0}\" using NAAS account: \"{1}\"", _submitPartnerNode.Name,
                                    _submitUsername);
                string networkFlowName = RCRABaseSolicitProcessor.RCRA_FLOW_NAME, networkFlowOperation = null;
                try
                {
                    using (INodeEndpointClient endpointClient = _nodeEndpointClientFactory.Make(_submitPartnerNode.Url, _submitPartnerNode.Version,
                                                                                                new AuthenticationCredentials(_submitUsername, userSubmitInfo.Password)))
                    {
                        if (endpointClient.Version == EndpointVersionType.EN20)
                        {
                            IList<string> notificationUris = null;
                            if (!string.IsNullOrEmpty(_notifications))
                            {
                                notificationUris = StringUtils.SplitAndReallyRemoveEmptyEntries(_notifications, ',', ';');
                            }
                            transactionId =
                                endpointClient.Submit(networkFlowName, "default",
                                                      string.Empty, notificationUris, new string[] { filePath });
                            networkFlowOperation = "default";
                        }
                        else
                        {
                            transactionId =
                                endpointClient.Submit(networkFlowName, null, new string[] { filePath });
                        }
                    }
                    AppendAuditLogEvent("Successfully submitted results to endpoint \"{0}\" with returned transaction id \"{1}\"",
                                        _submitPartnerNode.Name, transactionId);
                }
                catch (Exception e)
                {
                    AppendAuditLogEvent("Failed to submit results to endpoint \"{0}\": {1}",
                                        _submitPartnerNode.Name, ExceptionUtils.ToShortString(e));
                    throw;
                }
                _transactionManager.SetNetworkId(localTransactionId, transactionId, _submitPartnerNode.Version,
                                                 _submitPartnerNode.Url, networkFlowName, networkFlowOperation);
            }
            catch (Exception e)
            {
                AppendAuditLogEvent("Failed to submit results to endpoint \"{0}\" with exception: {1}",
                                    _submitPartnerNode.Name, ExceptionUtils.ToShortString(e));
                throw;
            }
            finally
            {
                FileUtils.SafeDeleteFile(filePath);
            }
            return transactionId;
        }
    }
}
