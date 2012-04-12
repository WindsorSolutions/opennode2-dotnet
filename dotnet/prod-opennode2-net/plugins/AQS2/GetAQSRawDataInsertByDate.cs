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

using System.IO;
using System.Xml;
using System.Text;
using System.Collections.Generic;
using System;
using System.Data;
using Windsor.Node2008.WNOSPlugin;
using Spring.Data.Core;
using Windsor.Commons.Core;
using Windsor.Commons.Logging;
using Windsor.Commons.Spring;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSProviders;
using Microsoft.VisualBasic.FileIO;
using Windsor.Commons.NodeDomain;
using Windsor.Commons.NodeClient;

namespace Windsor.Node2008.WNOSPlugin.AQS2
{
    public class GetAQSRawDataInsertByDate : AQSGetRawData, ISolicitProcessor, IQueryProcessor
    {
        protected const string CONFIG_NAAS_USER_MAPPING_FILE_PATH = "NAAS User Mapping File Path";
        protected const string CONFIG_SUBMISSION_PARTNER_NAME = "Submission Partner Name";

        protected const string PARAM_NAAS_SUBMIT_USERNAME = "SubmitUsername";

        protected class UserSubmitInfo
        {
            public UserSubmitInfo() { }
            public UserSubmitInfo(string password)
            {
                Password = password;
            }
            public string Password;
        }
        protected IPartnerManager _partnerManager;
        protected INodeEndpointClientFactory _nodeEndpointClientFactory;
        protected string _submitUsername;
        protected PartnerIdentity _submitPartnerNode;
        protected Dictionary<string, UserSubmitInfo> _naasUsernameToPasswordMap;
        
        public GetAQSRawDataInsertByDate()
        {
            ConfigurationArguments.Add(CONFIG_NAAS_USER_MAPPING_FILE_PATH, null);
            ConfigurationArguments.Add(CONFIG_SUBMISSION_PARTNER_NAME, null);
        }
        
        public override void ProcessSolicit(string requestId)
        {
            base.ProcessSolicit(requestId);

            CheckToSubmitData(_dataFilePath);
        }
        public override PaginatedContentResult ProcessQuery(string requestId)
        {
            PaginatedContentResult result = base.ProcessQuery(requestId);

            CheckToSubmitData(_dataFilePath);

            return result;
        }
        protected virtual void CheckToSubmitData(string dataFilePath)
        {
            if (!string.IsNullOrEmpty(_submitUsername))
            {
                SubmitFile(dataFilePath, _dataRequest.TransactionId);
            }
        }
        protected override void LazyInit()
        {
            base.LazyInit();

            GetServiceImplementation(out _partnerManager);
            GetServiceImplementation(out _nodeEndpointClientFactory);

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
        }
        protected override void ValidateRequest(string requestId)
        {
            base.ValidateRequest(requestId);

            if (TryGetParameter(_dataRequest, PARAM_NAAS_SUBMIT_USERNAME, 4, ref _submitUsername))
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
            }

            AppendAuditLogEvent("Validated request with parameters: {0} = {1}",
                                      PARAM_NAAS_SUBMIT_USERNAME, _submitUsername ?? string.Empty);
        }
        protected string SubmitFile(string filePath, string localTransactionId)
        {
            string transactionId;
            try
            {
                UserSubmitInfo userSubmitInfo = _naasUsernameToPasswordMap[_submitUsername.ToUpper()];
                AppendAuditLogEvent("Submitting results to endpoint \"{0}\" using NAAS account: \"{1}\"", _submitPartnerNode.Name,
                                    _submitUsername);
                try
                {
                    using (INodeEndpointClient endpointClient = _nodeEndpointClientFactory.Make(_submitPartnerNode.Url, _submitPartnerNode.Version,
                                                                                                new AuthenticationCredentials(_submitUsername, userSubmitInfo.Password)))
                    {
                        if (endpointClient.Version == EndpointVersionType.EN20)
                        {
                            transactionId =
                                endpointClient.Submit(AQS_FLOW_NAME, string.Empty,
                                                      string.Empty, new string[] { filePath });
                        }
                        else
                        {
                            transactionId =
                                endpointClient.Submit(AQS_FLOW_NAME, null, new string[] { filePath });
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
                                                 _submitPartnerNode.Url, AQS_FLOW_NAME, null);
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
                                string password = values[1].Trim();
                                if (string.IsNullOrEmpty(password))
                                {
                                    throw new ArgumentException(string.Format("Missing NAAS password for username {0} on line: {1}", username, lineNumber));
                                }
                                _naasUsernameToPasswordMap.Add(username, new UserSubmitInfo(password));
                            }
                        }
                        AppendAuditLogEvent("Found {0} usernames in NAAS User Mapping File", _naasUsernameToPasswordMap.Count.ToString());
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




