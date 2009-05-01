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
using Windsor.Commons.Core;
using Windsor.Commons.Logging;

namespace Windsor.Node2008.WNOSPlugin.Windsor
{

    [Serializable]
    public class CleanTemporaryFolder : BaseWNOSPlugin, ITaskProcessor
    {
        #region fields
        private static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());
        private const string DELETE_OLDER_THAN_DAYS_KEY = "Delete files older than days";
        #endregion

        /// <summary>
        /// Responsible for processing all FRS services
        /// </summary>
        public CleanTemporaryFolder()
        {
            ConfigurationArguments.Add(DELETE_OLDER_THAN_DAYS_KEY, null);
        }

        /// <summary>
        /// ProcessTask
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns></returns>
        public void ProcessTask(string requestId)
        {
            IRequestManager requestManager;
            ISettingsProvider settingsProvider;

            GetServiceImplementation(out requestManager);
            GetServiceImplementation(out settingsProvider);

            string tempFolderPath = settingsProvider.TempFolderPath;
            if (!Directory.Exists(tempFolderPath))
            {
                throw new DirectoryNotFoundException(string.Format("The node temporary folder does not exist: {0}",
                                                                   tempFolderPath));
            }
            int deleteOlderThanDays;
            if (!ConfigurationArguments.ContainsKey(DELETE_OLDER_THAN_DAYS_KEY))
            {
                throw new ArgumentException("DELETE_OLDER_THAN_DAYS_KEY configuration key not set");
            }
            if (!int.TryParse(ConfigurationArguments[DELETE_OLDER_THAN_DAYS_KEY], out deleteOlderThanDays) ||
                (deleteOlderThanDays < 1))
            {
                throw new ArgumentException(string.Format("DELETE_OLDER_THAN_DAYS_KEY value is not valid: {0}",
                                                          deleteOlderThanDays));
            }
            DateTime deleteFilesOlderThan = DateTime.Now - TimeSpan.FromDays(deleteOlderThanDays);
            AppendAuditLogEvent("Deleting all files older than {0} from the temporary folder: \"{1}\"",
                                      deleteFilesOlderThan, tempFolderPath);
            int deleteFileCount =
                FileUtils.DeleteAllFilesOlderThan(tempFolderPath, deleteFilesOlderThan, true, false);

            if (deleteFileCount > 0)
            {
                AppendAuditLogEvent("Deleted {0} file(s)", deleteFileCount.ToString("N0"));
            }
            else
            {
                AppendAuditLogEvent("Didn't find any files to delete");
            }

            AppendAuditLogEvent("Deleting all empty folders older than {0} from the temporary folder: \"{1}\"",
                                     deleteFilesOlderThan, tempFolderPath);
            int deleteFolderCount =
                FileUtils.DeleteAllEmptyFoldersOlderThan(tempFolderPath, deleteFilesOlderThan, false);

            if (deleteFolderCount > 0)
            {
                AppendAuditLogEvent("Deleted {0} empty folder(s)", deleteFolderCount.ToString("N0"));
            }
            else
            {
                AppendAuditLogEvent("Didn't find any empty folders to delete");
            }
        }
    }

    [Serializable]
    public class CreateLogInfoTransaction : BaseWNOSPlugin, ITaskProcessor
    {
        #region fields
        private static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());
        #endregion

        /// <summary>
        /// ProcessTask
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns></returns>
        public void ProcessTask(string requestId)
        {
            IRequestManager requestManager;
            IDocumentManager documentManager;
            ICompressionHelper compressionHelper;
            ISettingsProvider settingsProvider;

            GetServiceImplementation(out requestManager);
            GetServiceImplementation(out documentManager);
            GetServiceImplementation(out compressionHelper);
            GetServiceImplementation(out settingsProvider);

            ICollection<string> paths = WNOSRollingFileAppender.LogFilePaths;
            if (!CollectionUtils.IsNullOrEmpty(paths))
            {
                DataRequest request = requestManager.GetDataRequest(requestId);
                string tempPath = settingsProvider.NewTempFilePath(".zip");
                compressionHelper.CompressFiles(tempPath, paths);
                documentManager.AddDocument(request.TransactionId, CommonTransactionStatusCode.Completed,
                                            null, tempPath);
                AppendAuditLogEvent("Found and compressed {0} log files", paths.Count);
            }
            else
            {
                AppendAuditLogEvent("Didn't find any log files to add");
            }
        }
    }

    [Serializable]
    public class RefreshNAASUsers : BaseWNOSPlugin, ITaskProcessor
    {
        protected const string PARAM_FORCE_REFRESH = "ForceRefresh";
        #region fields
        private static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());
        #endregion

        /// <summary>
        /// Responsible for processing all FRS services
        /// </summary>
        public RefreshNAASUsers()
        {
        }

        /// <summary>
        /// ProcessTask
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns></returns>
        public void ProcessTask(string requestId)
        {
            INAASManager naasManager;
            IRequestManager _requestManager;

            GetServiceImplementation(out naasManager);
            GetServiceImplementation(out _requestManager);

            DataRequest dataRequest = _requestManager.GetDataRequest(requestId);
            bool forceRefresh = false;
            TryGetParameter(dataRequest, PARAM_FORCE_REFRESH, 0, ref forceRefresh);

            int numUsersRefreshed = 0;
            if (forceRefresh)
            {
                naasManager.RefreshNAASUsersAlways(out numUsersRefreshed);
                AppendAuditLogEvent("Successfully refreshed {0} NAAS users", numUsersRefreshed);
            }
            else
            {
                if (naasManager.RefreshNAASUsersIfExpired(out numUsersRefreshed))
                {
                    AppendAuditLogEvent("Successfully refreshed {0} NAAS users", numUsersRefreshed);
                }
                else
                {
                    AppendAuditLogEvent("NAAS user cache has not expired yet");
                }
            }
        }
        public override IList<PluginParameter> RuntimeParameters
        {
            get
            {
                List<PluginParameter> parameters = new List<PluginParameter>();
                parameters.Add(new PluginParameter("Force Refresh", "If true, this task will always refresh the user list.  If false, this task will only refresh the user list if it has expired.",
                                                   true, typeof(bool), false));
                return parameters;
            }
        }
    }
    [Serializable]
    public class CopySubmitFilesToFolder : BaseWNOSPlugin, ISubmitProcessor
    {
        #region fields
        private static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());
        private const string DESTINATION_FOLDER_PATH = "Destination parent folder (full path to the parent folder where submit files are copied)";
        private const string USE_USERNAME_SUBFOLDER = "Use username subfolder (optional: if true, create a destination subfolder using the submit username)";
        #endregion

        /// <summary>
        /// Responsible for processing all FRS services
        /// </summary>
        public CopySubmitFilesToFolder()
        {
            ConfigurationArguments.Add(DESTINATION_FOLDER_PATH, null);
            ConfigurationArguments.Add(USE_USERNAME_SUBFOLDER, null);
        }

        /// <summary>
        /// ProcessSubmit
        /// </summary>
        public void ProcessSubmit(string transactionId)
        {
            ITransactionManager transactionManager;
            ISettingsProvider settingsProvider;
            IDocumentManager documentManager;

            AppendAuditLogEvent("Enter CopySubmitFilesToFolder.ProcessSubmit({0})",
                                      transactionId);

            GetServiceImplementation(out transactionManager);
            GetServiceImplementation(out settingsProvider);
            GetServiceImplementation(out documentManager);

            string destinationFolderPath;
            if (!ConfigurationArguments.TryGetValue(DESTINATION_FOLDER_PATH, out destinationFolderPath))
            {
                throw new ArgumentException("DESTINATION_FOLDER_PATH configuration key not set");
            }
            if (!Directory.Exists(destinationFolderPath))
            {
                throw new DirectoryNotFoundException(string.Format("DESTINATION_FOLDER_PATH does not exist: {0}",
                                                                   destinationFolderPath));
            }
            bool createUsernameSubfolder = false;
            {
                string usernameSubfolder;
                if (ConfigurationArguments.TryGetValue(USE_USERNAME_SUBFOLDER, out usernameSubfolder) &&
                    !string.IsNullOrEmpty(usernameSubfolder))
                {
                    try
                    {
                        createUsernameSubfolder = bool.Parse(usernameSubfolder);
                    }
                    catch (Exception)
                    {
                        throw new FormatException(string.Format("Could not parse USE_USERNAME_SUBFOLDER true/false value: {0}",
                                                                usernameSubfolder));
                    }
                }
            }

            if (createUsernameSubfolder)
            {
                string username = transactionManager.GetTransactionUsername(transactionId);
                if (string.IsNullOrEmpty(username))
                {
                    throw new ArgumentException(string.Format("Could not username for transaction: {0}",
                                                              transactionId));
                }
                username = FileUtils.ReplaceInvalidFilenameChars(username, '_');
                destinationFolderPath = Path.Combine(destinationFolderPath, username);
            }

            AppendAuditLogEvent("DESTINATION_FOLDER_PATH: \"{0}\"", destinationFolderPath);

            IList<string> dbDocIds = transactionManager.GetAllUnprocessedDocumentDbIds(transactionId);
            if (!CollectionUtils.IsNullOrEmpty(dbDocIds))
            {
                if (!Directory.Exists(destinationFolderPath))
                {
                    Directory.CreateDirectory(destinationFolderPath);
                    AppendAuditLogEvent("Created folder DESTINATION_FOLDER_PATH: \"{0}\"",
                                              destinationFolderPath);
                }
                foreach (string dbDocId in dbDocIds)
                {
                    Document document = documentManager.GetDocument(transactionId, dbDocId, true);
                    string docName;
                    if (!string.IsNullOrEmpty(document.DocumentName))
                    {
                        docName = document.DocumentName;
                    }
                    else if (!string.IsNullOrEmpty(document.DocumentId))
                    {
                        docName = document.DocumentName;
                    }
                    else
                    {
                        docName = dbDocId;
                    }
                    docName = FileUtils.ReplaceInvalidFilenameChars(docName, '_');
                    docName = 
                        Path.ChangeExtension(docName, CommonContentAndFormatProvider.GetFileExtension(document.Type));
                    string copyPath = FileUtils.MakeUniqueIncrementalFilePath(destinationFolderPath, docName);
                    File.WriteAllBytes(copyPath, document.Content);
                    AppendAuditLogEvent("Copied file \"{0}\"", copyPath);
                    documentManager.SetDocumentStatus(transactionId, dbDocId, CommonTransactionStatusCode.Processed,
                                                      "Processed " + dbDocId);
                }
            }

            AppendAuditLogEvent("Exit CopySubmitFilesToFolder.ProcessSubmit({0})",
                                      transactionId);
        }
    }
    [Serializable]
    public class SolicitFilesFromFolder : BaseWNOSPlugin, ISolicitProcessor
    {
        #region fields
        private static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());
        private const string SOURCE_FOLDER_PATH = "Source parent folder (full path to the parent folder where files are found)";
        private const string PARAM_STATE_ID = "StateId";
        private const string PARAM_DOCUMENT_COUNT = "DocumentCount";
        private const string PARAM_DOCUMENTS_NEWER_THAN = "DocumentsNewerThan";
        #endregion

        /// <summary>
        /// Responsible for processing all FRS services
        /// </summary>
        public SolicitFilesFromFolder()
        {
            ConfigurationArguments.Add(SOURCE_FOLDER_PATH, null);
        }

        /// <summary>
        /// ProcessSolicit
        /// </summary>
        public void ProcessSolicit(string requestId)
        {
            IDocumentManager documentManager;
            IRequestManager requestManager;

            AppendAuditLogEvent("Enter SolicitFilesFromFolder.ProcessSolicit({0})",
                                      requestId);

            GetServiceImplementation(out requestManager);
            GetServiceImplementation(out documentManager);

            string sourceFolderPath;
            if (!ConfigurationArguments.TryGetValue(SOURCE_FOLDER_PATH, out sourceFolderPath))
            {
                throw new ArgumentException("SOURCE_FOLDER_PATH configuration key not set");
            }
            if (!Directory.Exists(sourceFolderPath))
            {
                throw new DirectoryNotFoundException(string.Format("SOURCE_FOLDER_PATH does not exist: {0}",
                                                                   sourceFolderPath));
            }
            DataRequest dataRequest = requestManager.GetDataRequest(requestId);
            int docCount = 1;
            DateTime docsNewerThan = DateTime.MinValue;
            string stateId = null;
            if (dataRequest.Parameters.IsByName)
            {
                TryGetParameterByName(dataRequest, PARAM_STATE_ID, ref stateId);
                TryGetParameterByName(dataRequest, PARAM_DOCUMENT_COUNT, ref docCount);
                TryGetParameterByName(dataRequest, PARAM_DOCUMENTS_NEWER_THAN, ref docsNewerThan);
            }
            else
            {
                TryGetParameterByIndex(dataRequest, 0, ref stateId);
                TryGetParameterByIndex(dataRequest, 1, ref docCount);
                TryGetParameterByIndex(dataRequest, 2, ref docsNewerThan);
            }
            if (!string.IsNullOrEmpty(stateId))
            {
                sourceFolderPath = Path.Combine(sourceFolderPath, stateId);
                if (!Directory.Exists(sourceFolderPath))
                {
                    throw new DirectoryNotFoundException(string.Format("State folder path does not exist: {0}",
                                                                       stateId));
                }
            }
            if (docCount < 0)
            {
                throw new ArgumentException("Invalid document count specified: {0}", docCount.ToString());
            }
            if (docsNewerThan > DateTime.Now.AddHours(2))
            {
                throw new ArgumentException("Invalid documents-newer-than date specified: {0}", docsNewerThan.ToString());
            }

            AppendAuditLogEvent("PARAM_DOCUMENT_COUNT ({0}), PARAM_DOCUMENTS_NEWER_THAN ({1})",
                                      docCount.ToString(), docsNewerThan.ToString());

            List<KeyValuePair<string, DateTime>> docPaths = new List<KeyValuePair<string, DateTime>>();
            using (FileSystemEnumerator enumerator = new FileSystemEnumerator(sourceFolderPath, "*", false,
                                                                              FileSystemEnumerator.EReturnTypes.eReturnFiles))
            {
                foreach (string path in enumerator)
                {
                    // Check date
                    DateTime fileTime = File.GetLastWriteTime(path);
                    if (fileTime > docsNewerThan)
                    {
                        docPaths.Add(new KeyValuePair<string, DateTime>(path, fileTime));
                    }
                }
                if (docPaths.Count > 0)
                {
                    docPaths.Sort(delegate(KeyValuePair<string, DateTime> x, KeyValuePair<string, DateTime> y)
                    {
                        return y.Value.CompareTo(x.Value);
                    });
                    if (docPaths.Count > docCount)
                    {
                        if (docCount > 0)
                        {
                            // Only return the # requested
                            docPaths.RemoveRange(docCount, docPaths.Count - docCount);
                        }
                    }
                }
            }
            if (docPaths.Count > 0)
            {
                AppendAuditLogEvent("Found {0} document(s) to add to solicit request", 
                                          docPaths.Count.ToString());
                documentManager.AddDocument(dataRequest.TransactionId, CommonTransactionStatusCode.Processed,
                                            string.Empty, GetSolictZipFile(docPaths));
            }
            else
            {
                AppendAuditLogEvent("Didn't find any documents to add to solicit request");
            }

            AppendAuditLogEvent("Exit SolicitFilesFromFolder.ProcessSolicit({0})",
                                      requestId);
        }
        private string GetSolictZipFile(List<KeyValuePair<string, DateTime>> docPaths)
        {
            if ((docPaths.Count == 1) &&
                 (CommonContentAndFormatProvider.GetFileTypeFromName(docPaths[0].Key) == CommonContentType.ZIP))
            {
                AppendAuditLogEvent("Added document \"{0}\" to solicit request",
                                          docPaths[0].Key);
                return docPaths[0].Key; // Single file and already zipped
            }
            ISettingsProvider settingsProvider;
            ICompressionHelper compressionHelper;

            GetServiceImplementation(out settingsProvider);
            GetServiceImplementation(out compressionHelper);

            List<string> files = new List<string>(docPaths.Count);
            foreach (KeyValuePair<string, DateTime> pair in docPaths) 
            {
                AppendAuditLogEvent("Added document \"{0}\" to solicit request",
                                          pair.Key);
                files.Add(pair.Key);
            }
            string tempFile = settingsProvider.NewTempFilePath(".zip");
            compressionHelper.CompressFiles(tempFile, files);
            return tempFile;
        }
    }
}
