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
    public class WQXSubmissionProcessor : WQXBaseAuthorizationPlugin, ISubmitProcessor
    {
        #region fields
        protected const string DESTINATION_PROVIDER_KEY = "Data Destination";

        protected const string CONFIG_DELETE_DATA_BEFORE_INSERT = "Delete Org Data Before Insert (True or False)";

        protected ISerializationHelper _serializationHelper;
        protected ICompressionHelper _compressionHelper;
        protected IDocumentManager _documentManager;
        protected ISettingsProvider _settingsProvider;
        protected ITransactionManager _transactionManager;
        protected IObjectsToDatabase _objectsToDatabase;
        protected SpringBaseDao _baseDao;

        protected string _submitUsername;
        protected bool _deleteExistingDataBeforeInsert = true;
        #endregion

        public WQXSubmissionProcessor()
        {
            ConfigurationArguments.Add(CONFIG_DELETE_DATA_BEFORE_INSERT, null);

            DataProviders.Add(DESTINATION_PROVIDER_KEY, null);
        }
        public void ProcessSubmit(string transactionId)
        {
            try
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
                
                GenerateExecutionLogAndAttachToTransaction(transactionId, null);
            }
            catch (Exception ex)
            {
                GenerateExecutionLogAndAttachToTransaction(transactionId, ex);
                throw;
            }
        }
        protected override void LazyInit()
        {
            base.LazyInit();

            GetServiceImplementation(out _serializationHelper);
            GetServiceImplementation(out _compressionHelper);
            GetServiceImplementation(out _documentManager);
            GetServiceImplementation(out _settingsProvider);
            GetServiceImplementation(out _transactionManager);
            GetServiceImplementation(out _objectsToDatabase);

            GetConfigParameter(CONFIG_DELETE_DATA_BEFORE_INSERT, out _deleteExistingDataBeforeInsert);

            _baseDao = ValidateDBProvider(DESTINATION_PROVIDER_KEY, typeof(NamedNullMappingDataReader));
        }
        protected virtual void ProcessSubmitDocument(string transactionId, string docId)
        {
            try
            {
                WQXDataType data = null;
                WQXDeleteDataType deleteData = null;
                Windsor.Node2008.WNOSPlugin.WQX1XsdOrm.WQXDataType data1 = null;

                data = GetWQXData(transactionId, docId, out data1, out deleteData);

                AppendAuditLogEvent("Storing WQX data into database");

                string orgId;
                object addObject;

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
                    addObject = data;

                    AppendAuditLogEvent("WQX data contains {0} Projects, {1} Activities, {2} Biological Habitat Indexes, {3} Monitoring Locations, and {4} Activity Groups for Organization Id \"{5}\"",
                                        CollectionUtils.Count(data.Organization.Project).ToString(),
                                        CollectionUtils.Count(data.Organization.Activity).ToString(),
                                        CollectionUtils.Count(data.Organization.BiologicalHabitatIndex).ToString(),
                                        CollectionUtils.Count(data.Organization.MonitoringLocation).ToString(),
                                        CollectionUtils.Count(data.Organization.ActivityGroup).ToString(),
                                        orgId);
                }
                else if (data1 != null)
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
                    addObject = data1;

                    AppendAuditLogEvent("WQX data contains {0} Projects, {1} Activities, {2} Biological Habitat Indexes, {3} Monitoring Locations, and {4} Activity Groups for Organization Id \"{5}\"",
                                        CollectionUtils.Count(data1.Organization.Project).ToString(),
                                        CollectionUtils.Count(data1.Organization.Activity).ToString(),
                                        "0",
                                        CollectionUtils.Count(data1.Organization.MonitoringLocation).ToString(),
                                        CollectionUtils.Count(data1.Organization.ActivityGroup).ToString(),
                                        data1.Organization.OrganizationDescription.OrganizationIdentifier);
                }
                else
                {
                    if (deleteData.OrganizationDelete == null)
                    {
                        throw new InvalidDataException("Deserialized WQX data does not contain an Organization element");
                    }
                    if (string.IsNullOrEmpty(deleteData.OrganizationDelete.OrganizationIdentifier))
                    {
                        throw new InvalidDataException("WQX data does not contain an OrganizationIdentifier element");
                    }

                    orgId = deleteData.OrganizationDelete.OrganizationIdentifier;
                    addObject = deleteData;

                    AppendAuditLogEvent("WQX delete data contains {0} Projects, {1} Activities, {2} Biological Habitat Indexes, {3} Monitoring Locations, and {4} Activity Groups for Organization Id \"{5}\"",
                                        CollectionUtils.Count(deleteData.OrganizationDelete.ProjectIdentifier).ToString(),
                                        CollectionUtils.Count(deleteData.OrganizationDelete.ActivityIdentifier).ToString(),
                                        CollectionUtils.Count(deleteData.OrganizationDelete.IndexIdentifier).ToString(),
                                        CollectionUtils.Count(deleteData.OrganizationDelete.MonitoringLocationIdentifier).ToString(),
                                        CollectionUtils.Count(deleteData.OrganizationDelete.ActivityGroupIdentifier).ToString(),
                                        deleteData.OrganizationDelete.OrganizationIdentifier);
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
                    else if (_authorizedWqxUsers.TryGetValue("*", out usernames))
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
                _baseDao.TransactionTemplate.Execute(delegate
                {
                    if (_deleteExistingDataBeforeInsert)
                    {
                        AppendAuditLogEvent("Deleting existing WQX data from the data store for organization \"{0}\" ...", orgId);
                        int numRowsDeleted = 0;

                        string groupWhere = string.Format("PARENTID IN (SELECT RECORDID FROM WQX_ORGANIZATION WHERE UPPER(ORGID) = UPPER('{0}'))",
                                                          orgId);
                        _baseDao.DoSimpleDelete("WQX_ACTIVITYGROUP", groupWhere, null);
                        numRowsDeleted = _baseDao.DoSimpleDelete("WQX_ORGANIZATION", "ORGID", orgId);

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
                    }
                    AppendAuditLogEvent("Storing WQX data for organization \"{0}\" into data store ...",
                                        orgId);
                    Dictionary<string, int> tableRowCounts = _objectsToDatabase.SaveToDatabase(addObject, _baseDao);

                    string recordId = ReflectionUtils.GetFieldOrPropertyValueByName<string>(addObject, "RecordId");

                    AppendAuditLogEvent("Stored WQX data content with organization primary key \"{0}\" into data store with the following table row counts: {1}",
                                        recordId, CreateTableRowCountsString(tableRowCounts));
                    return null;
                });
            }
            catch (Exception e)
            {
                AppendAuditLogEvent("Failed to process document with id \"{0}.\"  EXCEPTION: {1}",
                                    docId.ToString(), ExceptionUtils.ToShortString(e));
                throw;
            }
        }
        protected virtual WQXDataType GetWQXData(string transactionId, string docId,
                                                 out Windsor.Node2008.WNOSPlugin.WQX1XsdOrm.WQXDataType data1,
                                                 out WQXDeleteDataType deleteData)
        {
            WQXDataType data = null;
            data1 = null;
            deleteData = null;
            string tempXmlFilePath = _settingsProvider.NewTempFilePath();
            try
            {
                IHeaderDocumentHelper headerDocumentHelper;
                GetServiceImplementation(out headerDocumentHelper);

                AppendAuditLogEvent("Getting data for document with id \"{0}\"", docId);
                Document document = _documentManager.GetDocument(transactionId, docId, true);
                if (document.IsZipFile)
                {
                    AppendAuditLogEvent("Decompressing document to temporary folder");
                    string tempFolder = _settingsProvider.CreateNewTempFolderPath();
                    _compressionHelper.UncompressDirectory(document.Content, tempFolder);
                    string[] xmlFiles = Directory.GetFiles(tempFolder, "*.xml");
                    if (xmlFiles.Length == 0)
                    {
                        throw new ArgException("Failed to locate an WQX xml file in the WQX data");
                    }
                    else if (xmlFiles.Length > 1)
                    {
                        throw new ArgException("More than one xml file was found in the WQX data");
                    }
                    tempXmlFilePath = xmlFiles[0];
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
                        loadElement = headerDocumentHelper.GetPayload("Delete");
                        if (loadElement == null)
                        {
                            throw new ArgumentException("The submitted document does not contain an \"Update-Insert\" or \"Delete\" payload");
                        }
                    }
                }
                catch (Exception)
                {
                    AppendAuditLogEvent("Document does not contain an Exchange Header");
                    // Assume, for now, that document does not have a header
                }

                AppendAuditLogEvent("Deserializing document data to WQX data");
                if (loadElement != null)
                {
                    try
                    {
                        data = _serializationHelper.Deserialize<WQXDataType>(loadElement);
                    }
                    catch (Exception)
                    {
                        AppendAuditLogEvent("Failed to deserialize WQX v2, trying WQX v1 ...");
                        try
                        {
                            data1 = _serializationHelper.Deserialize<Windsor.Node2008.WNOSPlugin.WQX1XsdOrm.WQXDataType>(loadElement);
                        }
                        catch (Exception)
                        {
                            AppendAuditLogEvent("Failed to deserialize WQX v1, trying WQX v2 Delete data ...");
                            deleteData = _serializationHelper.Deserialize<WQXDeleteDataType>(loadElement);
                        }
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
                        try
                        {
                            data1 = _serializationHelper.Deserialize<Windsor.Node2008.WNOSPlugin.WQX1XsdOrm.WQXDataType>(tempXmlFilePath);
                        }
                        catch (Exception)
                        {
                            AppendAuditLogEvent("Failed to deserialize WQX v1, trying WQX v2 Delete data ...");
                            deleteData = _serializationHelper.Deserialize<WQXDeleteDataType>(tempXmlFilePath);
                        }
                    }
                }
            }
            finally
            {
                FileUtils.SafeDeleteFile(tempXmlFilePath);
            }
            return data;
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
    }
}