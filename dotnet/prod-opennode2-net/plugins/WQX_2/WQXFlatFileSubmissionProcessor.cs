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
using Windsor.Commons.NodeDomain;

namespace Windsor.Node2008.WNOSPlugin.WQX2
{
    [Serializable]
    public class WQXFlatFileSubmissionProcessor : WQXSubmissionProcessor
    {
        #region fields
        protected const string DATA_SOURCE_STORED_PROC = "Postprocessing Stored Procedure Database";
        protected const string CONFIG_ORG_ID = "WQX Organization Id";
        protected const string CONFIG_ORG_NAME = "WQX Organization Name";
        protected const string CONFIG_STORED_PROC_NAME = "Postprocessing Stored Procedure Name";
        protected const string CONFIG_STORED_PROC_TIMEOUT = "Postprocessing Stored Procedure Execute Timeout (in seconds)";
        protected const string CONFIG_LOOKUP_TABLES_FILE_PATH = "Lookup Tables File Path";
        private string _organizationId;
        private string _organizationName;
        private string _storedProcName;
        private int _storedProcTimeout = 300;
        private SpringBaseDao _storedProcBaseDao;
        protected Dictionary<string, LookupValues> _sampleCollectionMethodLookups;
        protected Dictionary<string, LookupValues> _resultAnalyticalMethodLookups;
        #endregion

        public WQXFlatFileSubmissionProcessor()
        {
            ConfigurationArguments.Add(CONFIG_ORG_ID, null);
            ConfigurationArguments.Add(CONFIG_ORG_NAME, null);
            ConfigurationArguments.Add(CONFIG_STORED_PROC_NAME, null);
            ConfigurationArguments.Add(CONFIG_STORED_PROC_TIMEOUT, null);
            ConfigurationArguments.Add(CONFIG_LOOKUP_TABLES_FILE_PATH, null);

            DataProviders.Add(DATA_SOURCE_STORED_PROC, null);
            
            _deleteExistingDataBeforeInsert = false;
        }
        protected override void LazyInit()
        {
            base.LazyInit();

            _organizationId = ValidateNonEmptyConfigParameter(CONFIG_ORG_ID);
            _organizationName = ValidateNonEmptyConfigParameter(CONFIG_ORG_NAME);
            TryGetConfigParameter(CONFIG_STORED_PROC_NAME, ref _storedProcName);
            TryGetConfigParameter(CONFIG_STORED_PROC_TIMEOUT, ref _storedProcTimeout);

            string lookupTableFilePath = null;
            TryGetConfigParameter(CONFIG_LOOKUP_TABLES_FILE_PATH, ref lookupTableFilePath);
            if (!string.IsNullOrEmpty(lookupTableFilePath))
            {
                WQXFlatFileParser.GetLookups(lookupTableFilePath, out _resultAnalyticalMethodLookups, out _sampleCollectionMethodLookups);
                AppendAuditLogEvent("Found {0} SampleCollectionMethod lookup(s) and {1} ResultAnalyticalMethod lookup(s) in the lookup tables file \"{2}\".",
                                    CollectionUtils.Count(_sampleCollectionMethodLookups).ToString(),
                                    CollectionUtils.Count(_resultAnalyticalMethodLookups).ToString(),
                                    lookupTableFilePath);
            }
            else
            {
                AppendAuditLogEvent("No lookup tables file specified.");
            }

            if (!string.IsNullOrEmpty(_storedProcName))
            {
                _storedProcBaseDao = ValidateDBProvider(DATA_SOURCE_STORED_PROC, typeof(NamedNullMappingDataReader));
            }

            AppendAuditLogEvent("Config parameters: {0} ({1}), {2} ({3}), {4} ({5})", CONFIG_ORG_ID, _organizationId,
                                CONFIG_ORG_NAME, _organizationName, CONFIG_STORED_PROC_NAME, _storedProcName ?? "None");
        }
        protected override void ProcessSubmitDocument(string transactionId, string docId)
        {
            base.ProcessSubmitDocument(transactionId, docId);

            if (_storedProcBaseDao != null)
            {
                CallPostProcessingStoredProc();
            }
        }
        protected virtual void GetLookups(string lookupTableFilePath)
        {
            if (!File.Exists(lookupTableFilePath))
            {
                //throw new FileNotFoundException(string.Format("The lookup tables file \"{0}\" could not be found", lookupTableFilePath));
            }
            try {
                using (CommaSeparatedFileParser parser = new CommaSeparatedFileParser(lookupTableFilePath))
                {
                    while (parser.NextLine())
                    {
                        string context = parser["CONTEXT"];
                        string type = parser["TYPE"];
                        string id = parser["ID"].ToUpper();
                        string name, description;
                        parser.GetValue("NAME", out name);
                        parser.GetValue("DESCRIPTION", out description);
                        if (!string.IsNullOrEmpty(name) || !string.IsNullOrEmpty(description))
                        {
                            switch (type.ToUpper())
                            {
                                case "SAMPLECOLLECTIONMETHOD":
                                    CollectionUtils.Add(id, new LookupValues(context, name, description), 
                                                        ref _sampleCollectionMethodLookups);
                                    break;
                                case "RESULTANALYTICALMETHOD":
                                    CollectionUtils.Add(id + context.ToUpper(), new LookupValues(context, name, description), 
                                                        ref _resultAnalyticalMethodLookups);
                                    break;
                                default:
                                    throw new ArgumentException(string.Format("Invalid TYPE found in lookup tables file: {0}",
                                                                              type.ToString()));
                            }
                        }
                    }
                    AppendAuditLogEvent("Found {0} SampleCollectionMethod lookup(s) and {1} ResultAnalyticalMethod lookup(s) in the lookup tables file \"{2}\".",
                                        CollectionUtils.Count(_sampleCollectionMethodLookups).ToString(),
                                        CollectionUtils.Count(_resultAnalyticalMethodLookups).ToString(),
                                        lookupTableFilePath);
                }
            }
            catch(Exception e)
            {
                AppendAuditLogEvent("Failed to parse the lookup tables file \"{0}\" with error: {1}",
                                    lookupTableFilePath, ExceptionUtils.GetDeepExceptionMessage(e));
                throw;
            }
        }

        protected override WQXDataType GetWQXData(string transactionId, string docId,
                                                  out Windsor.Node2008.WNOSPlugin.WQX1XsdOrm.WQXDataType data1,
                                                  out WQXDeleteDataType deleteData)
        {
            WQXDataType data = null;
            data1 = null;
            deleteData = null;
            string tempFolderPath = Path.Combine(_settingsProvider.TempFolderPath, Guid.NewGuid().ToString());
            try
            {
                AppendAuditLogEvent("Extracting contents of document with id \"{0}\" to temporary folder", docId);
                _compressionHelper.UncompressDirectory(_documentManager.GetContent(transactionId, docId), tempFolderPath);

                string projectsFile, monitoringFile, resultsFile;
                GetFlatFiles(tempFolderPath, out projectsFile, out monitoringFile, out resultsFile);

                AppendAuditLogEvent("Generating WQX data from flat files for Organization Id \"{0}\" and Name \"{1}\"",
                                    _organizationId, _organizationName);

                Dictionary<string, MonitoringLocationDataType> monitoringLocations =
                    WQXFlatFileParser.ParseMonitoringLocations(monitoringFile);
                if (CollectionUtils.IsNullOrEmpty(monitoringLocations))
                {
                    throw new InvalidDataException(string.Format("The document does not contain any monitoring locations inside the flat file"));
                }

                Dictionary<string, ProjectDataType> projects =
                    WQXFlatFileParser.ParseProjects(projectsFile);
                if (CollectionUtils.IsNullOrEmpty(projects))
                {
                    throw new InvalidDataException(string.Format("The document does not contain any projects inside the flat file"));
                }

                Dictionary<string, ActivityDataType> activities =
                    WQXFlatFileParser.ParseResults(resultsFile, projects, monitoringLocations, _resultAnalyticalMethodLookups, 
                                                   _sampleCollectionMethodLookups, false);

                data = new WQXDataType();
                data.Organization = new OrganizationDataType();
                data.Organization.OrganizationDescription = new OrganizationDescriptionDataType();
                data.Organization.OrganizationDescription.OrganizationIdentifier = _organizationId;
                data.Organization.OrganizationDescription.OrganizationFormalName = _organizationName;

                if (!CollectionUtils.IsNullOrEmpty(monitoringLocations))
                {
                    data.Organization.MonitoringLocation = new List<MonitoringLocationDataType>(monitoringLocations.Values).ToArray();
                }
                if (!CollectionUtils.IsNullOrEmpty(projects))
                {
                    data.Organization.Project = new List<ProjectDataType>(projects.Values).ToArray();
                }
                if (!CollectionUtils.IsNullOrEmpty(activities))
                {
                    data.Organization.Activity = new List<ActivityDataType>(activities.Values).ToArray();
                }
                SaveDataFileToTransaction(transactionId, data);
            }
            finally
            {
                FileUtils.SafeDeleteDirectory(tempFolderPath);
            }
            return data;
        }
        protected virtual void CallPostProcessingStoredProc()
        {
            AppendAuditLogEvent("Executing stored procedure \"{0}\" with ORGID of \"{1}\" and timeout of {2} seconds ...",
                                _storedProcName, _organizationId, _storedProcTimeout.ToString());

            try
            {
                IDbParameters parameters = _storedProcBaseDao.AdoTemplate.CreateDbParameters();
                parameters.AddWithValue("ORGID", _organizationId);

                _storedProcBaseDao.AdoTemplate.Execute<int>(delegate(DbCommand command)
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = _storedProcName;
                    Spring.Data.Support.ParameterUtils.CopyParameters(command, parameters);

                    try
                    {
                        SpringBaseDao.ExecuteCommandWithTimeout(command, _storedProcTimeout, 
                            delegate(DbCommand commandToExecute)
                            {
                                commandToExecute.ExecuteNonQuery();
                            });
                    }
                    catch (Exception ex2)
                    {
                        AppendAuditLogEvent("Error returned from stored procedure: {0}", ExceptionUtils.GetDeepExceptionMessage(ex2));
                        throw;
                    }

                    return 0;
                });

                AppendAuditLogEvent("Successfully executed stored procedure \"{0}\"", _storedProcName);
            }
            catch (Exception e)
            {
                AppendAuditLogEvent("Failed to execute stored procedure \"{0}\" with error: {1}",
                                    _storedProcName, ExceptionUtils.GetDeepExceptionMessage(e));
                throw;
            }
        }
        protected void SaveDataFileToTransaction(string transactionId, WQXDataType data)
        {
            string tempXmlFilePath = _settingsProvider.NewTempFilePath();
            tempXmlFilePath = Path.ChangeExtension(tempXmlFilePath, ".xml");

            try
            {
                AppendAuditLogEvent("Saving generated WQX xml file to transaction ...");
                
                _serializationHelper.Serialize(data, tempXmlFilePath);

                _documentManager.AddDocument(transactionId,
                                             CommonTransactionStatusCode.Completed,
                                             null, tempXmlFilePath);
            }
            catch (Exception e)
            {
                AppendAuditLogEvent("Failed to save generated WQX xml file to transaction: {0}",
                                    ExceptionUtils.GetDeepExceptionMessage(e));
                throw;
            }
            finally
            {
                FileUtils.SafeDeleteFile(tempXmlFilePath);
            }
        }
        protected void GetFlatFiles(string folderPath, out string projectsFile, out string monitoringFile, out string resultsFile)
        {
            string[] files = Directory.GetFiles(folderPath);
            if (CollectionUtils.IsNullOrEmpty(files))
            {
                throw new InvalidDataException(string.Format("The document does not contain any files"));
            }
            projectsFile = FindFirstFileStringThatContains(files, "Projects");
            monitoringFile = FindFirstFileStringThatContains(files, "Monitoring");
            resultsFile = FindFirstFileStringThatContains(files, "Results");

            if ((projectsFile == null) && (monitoringFile == null) && (resultsFile == null))
            {
                throw new InvalidDataException(string.Format("The document does not contain any flat files that are named correctly"));
            }
            if (((projectsFile != null) && ((projectsFile == monitoringFile) || (projectsFile == resultsFile))) ||
                ((monitoringFile != null) && ((monitoringFile == projectsFile) || (monitoringFile == resultsFile))) ||
                ((resultsFile != null) && ((resultsFile == monitoringFile) || (resultsFile == projectsFile))))
            {
                throw new InvalidDataException(string.Format("The document contains flat files that are not named correctly"));
            }

            // For now, assume all files MUST be present:
            if (projectsFile == null)
            {
                throw new InvalidDataException(string.Format("The document is missing the Projects flat file"));
            }
            if (monitoringFile == null)
            {
                throw new InvalidDataException(string.Format("The document is missing the Monitoring Locations flat file"));
            }
            if (resultsFile == null)
            {
                throw new InvalidDataException(string.Format("The document is missing the Results flat file"));
            }

            StringBuilder sb = new StringBuilder("Located flat file(s): ");
            bool addedAny = false;
            if (projectsFile != null)
            {
                sb.AppendFormat("Projects ({0})", Path.GetFileName(projectsFile));
                addedAny = true;
            }
            if (monitoringFile != null)
            {
                if (addedAny) sb.Append(", ");
                sb.AppendFormat("Monitoring Locations ({0})", Path.GetFileName(monitoringFile));
                addedAny = true;
            }
            if (resultsFile != null)
            {
                if (addedAny) sb.Append(", ");
                sb.AppendFormat(" Results ({0})", Path.GetFileName(resultsFile));
                addedAny = true;
            }
            AppendAuditLogEvent(sb.ToString());
        }
        protected string FindFirstFileStringThatContains(IEnumerable<string> strings, string contains)
        {
            foreach (string text in strings)
            {
                string testString = Path.GetFileName(text);
                if (testString.IndexOf(contains, StringComparison.InvariantCultureIgnoreCase) >= 0)
                {
                    return text;
                }
            }
            return null;
        }
    }
}