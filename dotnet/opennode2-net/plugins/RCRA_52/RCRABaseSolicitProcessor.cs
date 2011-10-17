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
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Xml;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSPlugin;
using Windsor.Node2008.WNOSProviders;
using Windsor.Commons.Logging;
using Windsor.Commons.XsdOrm;
using Windsor.Commons.Core;
using Windsor.Commons.Spring;
using Microsoft.VisualBasic.FileIO;
using Windsor.Commons.NodeDomain;
using Windsor.Commons.NodeClient;

namespace Windsor.Node2008.WNOSPlugin.RCRA_52
{
    [Serializable]
    public abstract class RCRABaseSolicitProcessor : BaseWNOSPlugin, ISolicitProcessor
	{
        protected class UserSubmitInfo
        {
            public UserSubmitInfo() { }
            public UserSubmitInfo(string password, string infoUserId)
            {
                Password = password;
                RCRAInfoUserID = infoUserId;
            }
            public string Password;
            public string RCRAInfoUserID;
        }
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
        protected const string RCRA_FLOW_NAME = "RCRA";

        protected const string PARAM_NAAS_SUBMIT_USERNAME = "SubmitUsername";

        public enum DataProviderParameterType
        {
            SourceProvider
        }

        #region fields
        protected static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());
        protected IRequestManager _requestManager;
        protected ISerializationHelper _serializationHelper;
        protected ICompressionHelper _compressionHelper;
        protected IDocumentManager _documentManager;
        protected IHeaderDocumentHelper _headerDocumentHelper;
        protected ISettingsProvider _settingsProvider;
        protected SpringBaseDao _baseDao;
        protected IPartnerManager _partnerManager;
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
        protected string _submitUsername;
        protected bool _validateXml;
        protected PartnerIdentity _submitPartnerNode;
        protected Dictionary<string, UserSubmitInfo> _naasUsernameToPasswordMap;
        protected DataRequest _dataRequest;
        #endregion

        public RCRABaseSolicitProcessor()
        {
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
            GetServiceImplementation(out _headerDocumentHelper);
            GetServiceImplementation(out _settingsProvider);
            GetServiceImplementation(out _partnerManager);
            GetServiceImplementation(out _nodeEndpointClientFactory);
            GetServiceImplementation(out _transactionManager);

            _baseDao = ValidateDBProvider(DataProviderParameterType.SourceProvider.ToString(), 
                                          typeof(NamedNullMappingDataReader));

            GetConfigParameter(CONFIG_ADD_HEADER, true, out _addHeader);
            if (_addHeader)
            {
                _author = ValidateNonEmptyConfigParameter(CONFIG_AUTHOR);
                _organization = ValidateNonEmptyConfigParameter(CONFIG_ORGANIZATION);
                _contactInfo = ValidateNonEmptyConfigParameter(CONFIG_CONTACT_INFO);
                _payloadOperation = ValidateNonEmptyConfigParameter(CONFIG_PAYLOAD_OPERATION);
                _title = ValidateNonEmptyConfigParameter(CONFIG_TITLE);
                TryGetConfigParameter(CONFIG_NOTIFICATIONS, ref _notifications);
                _rcraInfoUserId = ValidateNonEmptyConfigParameter(CONFIG_RCRA_INFO_USER_ID);
                _rcraInfoStateCode = ValidateNonEmptyConfigParameter(CONFIG_RCRA_INFO_STATE_CODE);
            }
            
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

        protected abstract object GetObjectFromRequest(DataRequest request);
        
        public void ProcessSolicit(string requestId)
		{
            LOG.DebugEnter(MethodBase.GetCurrentMethod(), requestId);

            LazyInit();

            _dataRequest = _requestManager.GetDataRequest(requestId);

            if (TryGetParameter(_dataRequest, PARAM_NAAS_SUBMIT_USERNAME, 0, ref _submitUsername))
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
            }

            object returnData = GetObjectFromRequest(_dataRequest);

            string serializedFilePath = null;
            if (_addHeader)
            {
                LOG.Debug("Serializing results and making header...");
                AppendAuditLogEvent("Serializing results and making header...");
                serializedFilePath = MakeHeaderFile(returnData);
            }
            else
            {
                LOG.Debug("Serializing results to file...");
                AppendAuditLogEvent("Serializing results to file...");
                serializedFilePath = _serializationHelper.SerializeToTempFile(returnData);
                if (_validateXml)
                {
                    ValidateXmlFileAndAttachErrorsAndFileToTransaction(serializedFilePath, "xml_schema.xml_schema.zip",
                                                                       null, _dataRequest.TransactionId);
                }
            }

            LOG.Debug("Serialized file path: " + serializedFilePath);
            AppendAuditLogEvent("Serialized file path: " + serializedFilePath);

            LOG.Debug("Compressing serialized file...");
            AppendAuditLogEvent("Compressing serialized file...");
            string compressedFilePath = _compressionHelper.CompressFile(serializedFilePath);
            LOG.Debug("Compressed file path: " + compressedFilePath);
            AppendAuditLogEvent("Compressed file path: " + compressedFilePath);

            LOG.Debug("Adding document...");
            AppendAuditLogEvent("Adding document...");
            _documentManager.AddDocument(_dataRequest.TransactionId,
                                         CommonTransactionStatusCode.Processed,
                                         "Request Processed: " + _dataRequest.ToString(),
                                         compressedFilePath);

            if (_submitUsername != null)
            {
                SubmitFile(compressedFilePath, _dataRequest.TransactionId);
            }
            LOG.Debug("OK");
            AppendAuditLogEvent("ProcessQuery: OK");
		}

        protected string MakeHeaderFile(object dataObject)
        {
            AppendAuditLogEvent("Generating header file from results");

            // Configure the submission header helper
            _headerDocumentHelper.Configure(_author, _organization, _title, null, _contactInfo, null);
            _headerDocumentHelper.AddNotifications(_notifications);
            _headerDocumentHelper.AddPropery("RCRAInfoStateCode", _rcraInfoStateCode);
            _headerDocumentHelper.AddPropery("RCRAInfoUserID", _rcraInfoUserId);

            string tempXmlFilePath = _settingsProvider.NewTempFilePath();
            tempXmlFilePath = Path.ChangeExtension(tempXmlFilePath, ".xml");
            AppendAuditLogEvent("Temp file before header:" + tempXmlFilePath);

            string tempXmlFilePath2 = _settingsProvider.NewTempFilePath();
            tempXmlFilePath2 = Path.ChangeExtension(tempXmlFilePath, ".xml");
            AppendAuditLogEvent("Temp file after header:" + tempXmlFilePath2);

            _serializationHelper.Serialize(dataObject, tempXmlFilePath);
            AppendAuditLogEvent("Temp file serialized");

            if (!File.Exists(tempXmlFilePath))
            {
                throw new IOException("Temp file does not exist: " + tempXmlFilePath);
            }

            if (_validateXml)
            {
                ValidateXmlFileAndAttachErrorsAndFileToTransaction(tempXmlFilePath, "xml_schema.xml_schema.zip",
                                                                   null, _dataRequest.TransactionId);
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(tempXmlFilePath);
            AppendAuditLogEvent("Xml document loaded");

            _headerDocumentHelper.AddPayload(_payloadOperation, doc.DocumentElement);

            AppendAuditLogEvent("Header payload added");

            _headerDocumentHelper.Serialize(tempXmlFilePath2);

            AppendAuditLogEvent("Header serialized");

            if (!File.Exists(tempXmlFilePath2))
            {
                throw new IOException("Header file does not exist: " + tempXmlFilePath2);
            }

            return tempXmlFilePath2;

        }


        /// <summary>
        /// Return the Query, Solicit, or Execute data service parameters for specified data service.
        /// This method should NOT call GetServiceImplementation().
        /// </summary>
        public override IList<TypedParameter> GetDataServiceParameters(string serviceName, out DataServicePublishFlags publishFlags)
        {
            publishFlags = DataServicePublishFlags.PublishToEndpointVersion11And20;
            return null;
        }
        protected string SubmitFile(string filePath, string localTransactionId)
        {
            string transactionId;
            try
            {
                UserSubmitInfo userSubmitInfo = _naasUsernameToPasswordMap[_submitUsername.ToUpper()];
                AppendAuditLogEvent("Submitting results to endpoint \"{0}\" using NAAS account: \"{1}\"", _submitPartnerNode.Name,
                                    _submitUsername);
                string networkFlowName = RCRA_FLOW_NAME, networkFlowOperation = null;
                try
                {
                    using (INodeEndpointClient endpointClient = _nodeEndpointClientFactory.Make(_submitPartnerNode.Url, _submitPartnerNode.Version,
                                                                                                new AuthenticationCredentials(_submitUsername, userSubmitInfo.Password)))
                    {
                        if (endpointClient.Version == EndpointVersionType.EN20)
                        {
                            transactionId =
                                endpointClient.Submit(RCRA_FLOW_NAME, "default",
                                                      string.Empty, new string[] { filePath });
                            networkFlowOperation = "default";
                        }
                        else
                        {
                            transactionId =
                                endpointClient.Submit(RCRA_FLOW_NAME, null, new string[] { filePath });
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
        protected void ParseNaasUserMappingFile()
        {
            string naasUserMappingFilePath = null;
            if (TryGetConfigParameter(CONFIG_NAAS_USER_MAPPING_FILE_PATH, ref naasUserMappingFilePath))
            {
                try
                {
                    AppendAuditLogEvent("Attempting to parse NAAS User Mapping File: \"{0}\"", naasUserMappingFilePath);
                    if (!File.Exists(naasUserMappingFilePath))
                    {
                        throw new ArgumentException(string.Format("The NAAS User Mapping File was not found: \"{0}\"",
                                                                  naasUserMappingFilePath));
                    }
                    using (TextFieldParser parser = new TextFieldParser(naasUserMappingFilePath))
                    {
                        parser.TextFieldType = FieldType.Delimited;
                        parser.Delimiters = new string[] { "," };
                        _naasUsernameToPasswordMap = new Dictionary<string, UserSubmitInfo>();
                        for (; ; )
                        {
                            long lineNumber = parser.LineNumber;
                            string[] values = parser.ReadFields();
                            if (CollectionUtils.IsNullOrEmpty(values))
                            {
                                break;
                            }
                            string username = values[0].Trim().ToUpper();
                            if (string.IsNullOrEmpty(username))
                            {
                                throw new ArgumentException(string.Format("Missing NAAS username on line: {0}", lineNumber));
                            }
                            if (username.StartsWith("//"))
                            {
                                // Comment, so ignore line
                            }
                            else
                            {
                                if (values.Length < 2)
                                {
                                    throw new ArgumentException(string.Format("Missing NAAS password for username {0} on line: {1}", username, lineNumber));
                                }
                                if (values.Length < 3)
                                {
                                    throw new ArgumentException(string.Format("Missing RCRAInfoUserID for username {0} on line: {1}", username, lineNumber));
                                }
                                string password = values[1].Trim();
                                if (string.IsNullOrEmpty(password))
                                {
                                    throw new ArgumentException(string.Format("Missing NAAS password for username {0} on line: {1}", username, lineNumber));
                                }
                                string infoUserId = values[2].Trim();
                                if (string.IsNullOrEmpty(infoUserId))
                                {
                                    throw new ArgumentException(string.Format("Missing RCRAInfoUserID for username {0} on line: {1}", username, lineNumber));
                                }
                                _naasUsernameToPasswordMap.Add(username, new UserSubmitInfo(password, infoUserId));
                            }
                        }
                        AppendAuditLogEvent("Found {0} usernames in NAAS User Mapping File", _naasUsernameToPasswordMap.Count);
                    }
                }
                catch (Exception e)
                {
                    AppendAuditLogEvent("Failed to load NAAS User Mapping File: {0}", e.Message);
                    throw;
                }
            }
            else
            {
                AppendAuditLogEvent("A NAAS User Mapping File was not specified.");
            }
        }
    }
}
