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
using System.ComponentModel;
using Windsor.Commons.Core;
using Windsor.Commons.Spring;
using Windsor.Commons.XsdOrm;
using Windsor.Node2008.WNOSPlugin.WQX2XsdOrm;
using Microsoft.VisualBasic.FileIO;

namespace Windsor.Node2008.WNOSPlugin.WQX2
{
    [Serializable]
    public class WQXSubmissionProcessor : BaseWNOSPlugin, ISubmitProcessor
    {
        #region fields
        protected const string AUTHORIZATION_FILE_PATH_KEY = "Authorization CSV File Path";
        protected const string DESTINATION_PROVIDER_KEY = "Data Destination";

        protected ISerializationHelper _serializationHelper;
        protected ICompressionHelper _compressionHelper;
        protected IDocumentManager _documentManager;
        protected ISettingsProvider _settingsProvider;
        protected ITransactionManager _transactionManager;
        protected IObjectsToDatabase _objectsToDatabase;
        protected SpringBaseDao _baseDao;

        protected Dictionary<string, List<string>> _authorizedWqxUsers;
        protected string _submitUsername;
        #endregion

        public WQXSubmissionProcessor()
        {
            ConfigurationArguments.Add(AUTHORIZATION_FILE_PATH_KEY, null);

            DataProviders.Add(DESTINATION_PROVIDER_KEY, null);
        }
        public void ProcessSubmit(string transactionId)
        {
            LazyInit();

            if (_authorizedWqxUsers != null)
            {
                _submitUsername = _transactionManager.GetTransactionUsername(transactionId);
                if (string.IsNullOrEmpty(_submitUsername))
                {
                    throw new ArgumentException("A Submit username is not associated with the transaction");
                }
            }

            IList<string> documentIds = _documentManager.GetDocumentIds(transactionId);

            if (CollectionUtils.IsNullOrEmpty(documentIds))
            {
                AppendAuditLogEvent("Didn't find any submit documents to process.");
                return;
            }
            AppendAuditLogEvent("Found {0} submit documents to process.", documentIds.Count.ToString());

            foreach (string docId in documentIds)
            {
                ProcessSubmitDocument(transactionId, docId);
            }
        }
        protected virtual void LazyInit()
        {
            AppendAuditLogEvent("Initializing WQXSubmissionProcessor plugin ...");

            GetServiceImplementation(out _serializationHelper);
            GetServiceImplementation(out _compressionHelper);
            GetServiceImplementation(out _documentManager);
            GetServiceImplementation(out _settingsProvider);
            GetServiceImplementation(out _transactionManager);
            GetServiceImplementation(out _objectsToDatabase);

            _baseDao = ValidateDBProvider(DESTINATION_PROVIDER_KEY, typeof(NamedNullMappingDataReader));

            LoadWQXAuthorizationFile();
        }
        protected void ProcessSubmitDocument(string transactionId, string docId)
        {
            string tempXmlFilePath = _settingsProvider.NewTempFilePath();
            try
            {
                IHeaderDocumentHelper headerDocumentHelper;
                GetServiceImplementation(out headerDocumentHelper);

                AppendAuditLogEvent("Getting data for document with id \"{0}\"", docId);
                Document document = _documentManager.GetDocument(transactionId, docId, true);
                if (document.IsZipFile)
                {
                    AppendAuditLogEvent("Decompressing document to temporary file");
                    _compressionHelper.UncompressDeep(document.Content, tempXmlFilePath);
                }
                else
                {
                    AppendAuditLogEvent("Writing document data to temporary file");
                    File.WriteAllBytes(tempXmlFilePath, document.Content);
                }

                XmlElement loadElement = null;
                try
                {
                    AppendAuditLogEvent("Attempting to load document with Exchange Header");
                    headerDocumentHelper.Load(tempXmlFilePath);
                    loadElement = headerDocumentHelper.GetPayload("Update-Insert");
                    if (loadElement == null)
                    {
                        throw new ArgumentException("The submitted document does not contain an \"Update-Insert\" payload");
                    }
                }
                catch (Exception)
                {
                    AppendAuditLogEvent("Document does not contain an Exchange Header");
                    // Assume, for now, that document does not have a header
                }

                AppendAuditLogEvent("Deserializing document data to WQX data");
                WQXDataType data = null;
                Windsor.Node2008.WNOSPlugin.WQX1XsdOrm.WQXDataType data1 = null;
                if (loadElement != null)
                {
                    try
                    {
                        data = _serializationHelper.Deserialize<WQXDataType>(loadElement);
                    }
                    catch (Exception)
                    {
                        AppendAuditLogEvent("Failed to deserialize WQX v2, trying WQX v1 ...");
                        data1 = _serializationHelper.Deserialize<Windsor.Node2008.WNOSPlugin.WQX1XsdOrm.WQXDataType>(loadElement);
                    }
                }
                else
                {
                    try
                    {
                        data = _serializationHelper.Deserialize<WQXDataType>(tempXmlFilePath);
                    }
                    catch (Exception)
                    {
                        AppendAuditLogEvent("Failed to deserialize WQX v2, trying WQX v1 ...");
                        data1 = _serializationHelper.Deserialize<Windsor.Node2008.WNOSPlugin.WQX1XsdOrm.WQXDataType>(tempXmlFilePath);
                    }
                }
                AppendAuditLogEvent("Storing WQX data into database");

                string orgId;

                if (data != null)
                {
                    if (data.Organization == null)
                    {
                        throw new InvalidDataException("Deserialized WQX data does not contain an Organization element");
                    }
                    if ((data.Organization.OrganizationDescription == null) ||
                        string.IsNullOrEmpty(data.Organization.OrganizationDescription.OrganizationIdentifier))
                    {
                        throw new InvalidDataException("WQX data does not contain an OrganizationIdentifier element");
                    }
                    orgId = data.Organization.OrganizationDescription.OrganizationIdentifier;
                    AppendAuditLogEvent("WQX data contains {0} Projects, {1} Activities, {2} Biological Habitat Indexes, {3} Monitoring Locations, and {4} Activity Groups for Organization Id \"{5}\"",
                                        CollectionUtils.Count(data.Organization.Project).ToString(),
                                        CollectionUtils.Count(data.Organization.Activity).ToString(),
                                        CollectionUtils.Count(data.Organization.BiologicalHabitatIndex).ToString(),
                                        CollectionUtils.Count(data.Organization.MonitoringLocation).ToString(),
                                        CollectionUtils.Count(data.Organization.ActivityGroup).ToString(),
                                        orgId);
                }
                else
                {
                    if (data1.Organization == null)
                    {
                        throw new InvalidDataException("Deserialized WQX data does not contain an Organization element");
                    }
                    if ((data1.Organization.OrganizationDescription == null) ||
                        string.IsNullOrEmpty(data1.Organization.OrganizationDescription.OrganizationIdentifier))
                    {
                        throw new InvalidDataException("WQX data does not contain an OrganizationIdentifier element");
                    }

                    orgId = data1.Organization.OrganizationDescription.OrganizationIdentifier;

                    AppendAuditLogEvent("WQX data contains {0} Projects, {1} Activities, {2} Biological Habitat Indexes, {3} Monitoring Locations, and {4} Activity Groups for Organization Id \"{5}\"",
                                        CollectionUtils.Count(data1.Organization.Project).ToString(),
                                        CollectionUtils.Count(data1.Organization.Activity).ToString(),
                                        "0",
                                        CollectionUtils.Count(data1.Organization.MonitoringLocation).ToString(),
                                        CollectionUtils.Count(data1.Organization.ActivityGroup).ToString(),
                                        data1.Organization.OrganizationDescription.OrganizationIdentifier);
                }
                if (_authorizedWqxUsers != null)
                {
                    AppendAuditLogEvent("Validating that User \"{0}\" is authorized to submit WQX data for Organization Id \"{1}\" ...", _submitUsername, orgId);
                    List<string> usernames = null;
                    if (_authorizedWqxUsers.TryGetValue(orgId.ToUpper(), out usernames))
                    {
                        if (!usernames.Contains("*") && !usernames.Contains(_submitUsername.ToUpper()))
                        {
                            string orgName = _settingsProvider.NodeOrganizationName;
                            throw new UnauthorizedAccessException(string.Format("The User \"{0}\" is not authorized to provide data to the {1} for the Organization ID \"{2}.\"  If you feel you have received this message in error, please contact the {1} for further assistance.",
                                                                                _submitUsername, orgName, orgId));
                        }
                    }
                    else
                    {
                        string orgName = _settingsProvider.NodeOrganizationName;
                        throw new UnauthorizedAccessException(string.Format("Organization ID \"{0}\" has not been authorized to provide data to the {1}.  If you feel you have received this message in error, please contact the {1} for further assistance.",
                                                                            orgId, orgName));
                    }
                }
                AppendAuditLogEvent("Deleting existing WQX data from the data store for organization \"{0}\" ...", orgId);
                int numRowsDeleted = _baseDao.DoSimpleDelete("WQX_ORGANIZATION", "ORGID", orgId);
                if (numRowsDeleted > 0)
                {
                    AppendAuditLogEvent("Deleted {0} existing WQX data rows from the data store for organization \"{1}\"",
                                        numRowsDeleted.ToString(), orgId);
                }
                else
                {
                    AppendAuditLogEvent("Did not find any existing WQX data to delete from the data store for organization \"{0}\"",
                                        orgId);
                }
                Dictionary<string, int> tableRowCounts =
                    _objectsToDatabase.SaveToDatabase((data != null) ? (object)data : (object)data1, _baseDao);

                AppendAuditLogEvent("Stored WQX data content with organization primary key \"{0}\" into data store with the following table row counts: {1}",
                                    data.RecordId, CreateTableRowCountsString(tableRowCounts));
            }
            catch (Exception e)
            {
                AppendAuditLogEvent("Failed to process document with id \"{0}.\"  EXCEPTION: {1}",
                                    docId.ToString(), ExceptionUtils.ToShortString(e));
                throw;
            }
            finally
            {
                FileUtils.SafeDeleteFile(tempXmlFilePath);
            }
        }
        private string CreateTableRowCountsString(Dictionary<string, int> tableRowCounts)
        {
            if (CollectionUtils.IsNullOrEmpty(tableRowCounts))
            {
                return "None";
            }
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, int> pair in tableRowCounts)
            {
                if (sb.Length > 0)
                {
                    sb.Append(", ");
                }
                sb.AppendFormat("{0} ({1})", pair.Key, pair.Value.ToString());
            }
            return sb.ToString();
        }
        private void LoadWQXAuthorizationFile()
        {
            string filePath = null;
            if (TryGetConfigParameter(AUTHORIZATION_FILE_PATH_KEY, ref filePath))
            {
                try
                {
                    using (TextFieldParser parser = new TextFieldParser(filePath))
                    {
                        parser.TextFieldType = FieldType.Delimited;
                        parser.Delimiters = new string[] { "," };
                        _authorizedWqxUsers = new Dictionary<string, List<string>>();
                        for (; ; )
                        {
                            long lineNumber = parser.LineNumber;
                            string[] values = parser.ReadFields();
                            if (CollectionUtils.IsNullOrEmpty(values))
                            {
                                break;
                            }
                            string wqxOrgId = values[0].Trim().ToUpper();
                            if (string.IsNullOrEmpty(wqxOrgId))
                            {
                                throw new ArgumentException(string.Format("Missing WQX Org Id on line: {0}", lineNumber));
                            }
                            if (wqxOrgId.StartsWith("//"))
                            {
                                // Comment, so ignore line
                            }
                            else
                            {
                                List<string> usernames = null;
                                if (!_authorizedWqxUsers.TryGetValue(wqxOrgId, out usernames))
                                {
                                    usernames = new List<string>();
                                    _authorizedWqxUsers[wqxOrgId] = usernames;
                                }
                                for (int i = 1; i < values.Length; ++i)
                                {
                                    string username = values[i].Trim().ToUpper();
                                    if (!usernames.Contains(username))
                                    {
                                        usernames.Add(username);
                                    }
                                }
                            }
                        }
                        AppendAuditLogEvent("Found {0} organizations in authorization file", _authorizedWqxUsers.Count);
                    }
                }
                catch (Exception e)
                {
                    AppendAuditLogEvent("Failed to load WQX authorization file: {0}", e.Message);
                    throw;
                }
            }
            else
            {
                AppendAuditLogEvent("A WQX authorization file was not specified.");
            }
        }
    }
}