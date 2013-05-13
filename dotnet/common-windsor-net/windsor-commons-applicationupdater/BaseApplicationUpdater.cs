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
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;

using Windsor.Commons.Logging;
using Windsor.Commons.Core;
using Windsor.Commons.Compression;

using DbException = System.Data.SqlClient.SqlException;

namespace Windsor.Commons.ApplicationUpdater
{
    /// <summary>
    /// The database or application update action that was performed
    /// </summary>
    [Flags]
    public enum UpdateAction
    {
        /// <summary>
        /// Action is undefined or not relevant
        /// </summary>
        Undefined = 0x0000,
        /// <summary>
        /// No action was taken, the database is already up-to-date
        /// </summary>
        None = 0x0001,
        /// <summary>
        /// A full refresh of the database or application was performed (i.e., a database existed and was dropped and recreated from scratch).
        /// </summary>
        FullRefresh = 0x0002,
        /// <summary>
        /// Scripts were executed to update the database or application to the current version.
        /// </summary>
        VersionUpdate = 0x0004,
    }

    /// <summary>
    /// Called to report status of the database update process
    /// </summary>
    /// <param name="message">Displayable status message</param>
    /// <param name="message">Percentage complete for current operation (0..100), or -1 if indefinite</param>
    public delegate void UpdateProgressHandler(string message, int percentageComplete);

    /// <summary>
    /// Called to report that the database update has completed, either successfully or unsuccessfully.
    /// </summary>
    /// <param name="action">The database update action that was performed, may be Undefined
    /// if an error occurs</param>
    /// <param name="currentVersion">The current version of the database, may be null if the 
    /// current version of the database could not be determined due to error during processing</param>
    /// <param name="applicationCloseRequired">If true, the application should exit to allow updates to 
    /// complete</param>
    /// <param name="error">Non-null if an error occurred, null if successful without error</param>
    public delegate void UpdateCompleteHandler(UpdateAction action, Version currentVersion,
                                               bool applicationCloseRequired, Exception error);

    /// <summary>Utilities to help with database update tasks</summary>
    public abstract class BaseApplicationUpdater : LoggerBase
    {
        public BaseApplicationUpdater()
        {
        }

        public BaseApplicationUpdater(string manifestDownloadUrl, string downloadedContentPassword)
        {
            _manifestDownloadUrl = manifestDownloadUrl;
            _downloadedContentPassword = downloadedContentPassword;
            _tempFolderPath = Path.GetTempPath();
        }

        /// <summary>
        /// Perform any database updates in a separate thread.
        /// </summary>
        public virtual void DoUpdatesAsync()
        {
            ExceptionUtils.ThrowIfEmptyString(_manifestDownloadUrl, "ManifestDownloadUrl");
            ExceptionUtils.ThrowIfDirectoryNotFound(_tempFolderPath);
            if (string.IsNullOrEmpty(_downloadedContentPassword))
            {
                _downloadedContentPassword = null;
            }
            _zipHelper = new DotNetZipHelper();
            _serializationUtils = new SerializationUtils();

            ThreadPool.QueueUserWorkItem(delegate(Object state)
            {
                ThreadWorkProc();
            });
            _isRunning = true;
        }

        /// <summary>
        /// Cancel any update in progress.  If an update is in progress and was able to be
        /// cancelled, completeCallback will be called with an exception of OperationCanceledException.
        /// </summary>
        public virtual void CancelUpdate()
        {
            _cancelUpdate = true;
        }
        /// <summary>
        /// Return true if the update is currently in progress.
        /// </summary>
        public bool IsRunning
        {
            get
            {
                return _isRunning;
            }
        }

        public event UpdateProgressHandler Progress;

        public event UpdateCompleteHandler Complete;

        /// <summary>
        /// Return true if the update was cancelled.
        /// </summary>
        public bool DidCancel
        {
            get
            {
                return _cancelUpdate;
            }
        }

        public string ManifestDownloadUrl
        {
            get
            {
                return _manifestDownloadUrl;
            }
            set
            {
                _manifestDownloadUrl = value;
            }
        }
        public string DownloadedContentPassword
        {
            get
            {
                return _downloadedContentPassword;
            }
            set
            {
                _downloadedContentPassword = value;
            }
        }
        public string TempFolderPath
        {
            get
            {
                return _tempFolderPath;
            }
            set
            {
                _tempFolderPath = value;
            }
        }
        protected void CheckToCancel()
        {
            if (_cancelUpdate)
            {
                throw new OperationCanceledException();
            }
        }
        protected UpdateApplicationManifest GetApplicationManifest()
        {
            LOG.Debug("GetApplicationManifest: Attempting to download application manifest");
            string statusString = "Retrieving update manifest file from server, please wait ...";
            DoStatusCallback(-1, statusString);
            byte[] manifestData = DownloadData(_manifestDownloadUrl,
                                                 delegate(int percentComplete, object callbackParam)
                                                 {
                                                     DoStatusCallback(percentComplete, callbackParam.ToString());
                                                     return !_cancelUpdate;
                                                 }, statusString
                                               );

            LOG.Debug("GetApplicationManifest: Attempting to deserialize application manifest");
            UpdateApplicationManifest appManifest = _serializationUtils.Deserialize<UpdateApplicationManifest>(manifestData);

            appManifest.CurrentDatabaseVersion = VersionFromString(appManifest.CurrentDatabaseVersionStr);
            appManifest.LastFullUpdateVersion = VersionFromString(appManifest.LastFullUpdateVersionStr);
            appManifest.CurrentApplicationVersion = VersionFromString(appManifest.CurrentApplicationVersionStr);
            if ((appManifest.CurrentDatabaseVersion != null) || (appManifest.LastFullUpdateVersion != null))
            {
                if ((appManifest.CurrentDatabaseVersion == null) || (appManifest.LastFullUpdateVersion == null))
                {
                    throw new InvalidDataException("Manifest file contains a unspecified database versions");
                }
                if (appManifest.CurrentDatabaseVersion < appManifest.LastFullUpdateVersion)
                {
                    throw new InvalidDataException(string.Format("Manifest file contains a current database version that is less than the last full update version: CurrentDatabaseVersion({0}) and LastFullUpdateVersion({1})",
                                                                 appManifest.CurrentDatabaseVersion.ToString(), appManifest.LastFullUpdateVersion.ToString()));
                }
                if (string.IsNullOrEmpty(appManifest.DatabaseFileDownloadUrl))
                {
                    throw new InvalidDataException("Manifest file does not contain DatabaseFileDownloadUrl");
                }
                if (string.IsNullOrEmpty(appManifest.DatabaseScriptsDownloadUrl))
                {
                    throw new InvalidDataException("Manifest file does not contain DatabaseScriptsDownloadUrl");
                }
            }
            if (appManifest.CurrentApplicationVersion != null)
            {
                if (string.IsNullOrEmpty(appManifest.ApplicationDownloadUrl))
                {
                    throw new InvalidDataException("Manifest file does not contain ApplicationDownloadUrl");
                }
            }
            LOG.Debug("GetApplicationManifest: Got application manifest: CurrentDatabaseVersion({0}) and LastFullUpdateVersion({1}) and CurrentApplicationVersion({2})",
                (appManifest.CurrentDatabaseVersion == null) ? "Unspecified" : appManifest.CurrentDatabaseVersion.ToString(),
                (appManifest.LastFullUpdateVersion == null) ? "Unspecified" : appManifest.LastFullUpdateVersion.ToString(),
                (appManifest.CurrentApplicationVersion == null) ? "Unspecified" : appManifest.CurrentApplicationVersion.ToString());

            return appManifest;
        }
        protected static Version VersionFromString(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }
            // Ignore revision if not specified
            Version version = new Version(str);
            if (version.Revision == -1)
            {
                version = new Version(version.Major, version.Minor, version.Build, 0);
            }
            return version;
        }
        protected string MakeTempFilePath(string parentDir, string extension)
        {
            return Path.Combine(parentDir, Guid.NewGuid().ToString() + extension);
        }
        protected string MakeTempFilePath(string extension)
        {
            return MakeTempFilePath(_tempFolderPath, extension);
        }
        protected string MakeTempFilePath()
        {
            return MakeTempFilePath(_tempFolderPath, ".tmp");
        }
        protected byte[] DownloadData(string url, NetworkUtils.DownloadProgressHandler progressCallback,
                                      object callbackParam)
        {
            try
            {
                LOG.Debug("DownloadData: Attempting to download data from url: {0}", url);
                byte[] data = NetworkUtils.DownloadData(url, progressCallback, callbackParam);
                data = _zipHelper.UncompressWithPassword(data, _downloadedContentPassword);
                LOG.Debug("DownloadData: Downloaded {0} content bytes from url: {0}", data.Length, url);
                return data;
            }
            catch (Exception e)
            {
                LOG.Error("DownloadData: Failed to download data from url: {0}", e, url);
                throw;
            }
        }
        protected void DownloadFile(string url, string contentFilePath)
        {
            DownloadFile(url, contentFilePath, null, null);
        }
        protected void DownloadFile(string url, string contentFilePath,
                                    NetworkUtils.DownloadProgressHandler progressCallback,
                                    object callbackParam)
        {
            string tempZipFile = MakeTempFilePath();
            try
            {
                LOG.Debug("DownloadFile: Attempting to download file from url: {0}", url);

                NetworkUtils.DownloadFile(url, tempZipFile, progressCallback, callbackParam);

                if (_zipHelper.IsCompressed(tempZipFile))
                {
                    _zipHelper.UncompressWithPassword(tempZipFile, contentFilePath, _downloadedContentPassword);
                }
                else
                {
                    File.Move(tempZipFile, contentFilePath);
                    tempZipFile = null;
                }

                LOG.Debug("DownloadFile: Downloaded {0} file bytes from url: {0}",
                          new FileInfo(contentFilePath).Length.ToString(), url);
            }
            catch (Exception e)
            {
                LOG.Error("DownloadFile: Failed to download data from url: {0}", e, url);
                throw;
            }
            finally
            {
                if (tempZipFile != null)
                {
                    FileUtils.SafeDeleteFile(tempZipFile);
                }
            }
        }
        protected string DownloadAllTempFiles(string url)
        {
            return DownloadAllTempFiles(url, null, null);
        }
        protected string DownloadAllTempFiles(string url, NetworkUtils.DownloadProgressHandler progressCallback,
                                              object callbackParam)
        {
            string downloadDirectoryPath = Path.Combine(_tempFolderPath, Guid.NewGuid().ToString());
            DownloadAllTempFiles(url, downloadDirectoryPath, progressCallback, callbackParam);
            return downloadDirectoryPath;
        }
        protected void DownloadAllTempFiles(string url, string downloadDirectoryPath)
        {
            DownloadAllTempFiles(url, downloadDirectoryPath, null, null);
        }
        protected void DownloadAllTempFiles(string url, string downloadDirectoryPath,
                                            NetworkUtils.DownloadProgressHandler progressCallback,
                                            object callbackParam)
        {
            try
            {
                LOG.Debug("DownloadAllTempFiles: Attempting to download files from url: {0}", url);
                string tempZipFile = MakeTempFilePath();
                NetworkUtils.DownloadFile(url, tempZipFile);
                try
                {
                    _zipHelper.UncompressDirectory(tempZipFile, downloadDirectoryPath, _downloadedContentPassword);
                }
                finally
                {
                    FileUtils.SafeDeleteFile(tempZipFile);
                }
                LOG.Debug("DownloadAllTempFiles: Downloaded files from url: {0}", url);
            }
            catch (Exception e)
            {
                LOG.Error("DownloadAllTempFiles: Failed to download data from url: {0}", e, url);
                throw;
            }
        }
        protected abstract UpdateAction GetUpdateAction(UpdateApplicationManifest appManifest,
                                                        out Version existingVersion);

        protected abstract Version DoFullRefresh(UpdateApplicationManifest appManifest, out bool applicationCloseRequired);

        protected abstract Version DoVersionUpdate(UpdateApplicationManifest appManifest, Version existingVersion,
                                                   out bool applicationCloseRequired);

        protected void DoStatusCallback(int percentComplete, string format, params object[] args)
        {
            if (Progress != null)
            {
                string message;
                if (!CollectionUtils.IsNullOrEmpty(args))
                {
                    message = string.Format(format, args);
                }
                else
                {
                    message = format;
                }
                try
                {
                    Progress(message, percentComplete);
                }
                catch (Exception)
                {
                }
            }
        }
        protected void DoCompleteCallback(UpdateAction action, Version currentVersion,
                                          bool applicationCloseRequired, Exception error)
        {
            if (Complete != null)
            {
                try
                {
                    Complete(action, currentVersion, applicationCloseRequired, error);
                }
                catch (Exception)
                {
                }
            }
        }
        private void ThreadWorkProc()
        {
            Exception resultException = null;
            UpdateAction updateAction = UpdateAction.Undefined;
            Version currentVersion = null;
            bool applicationCloseRequired = false;

            // Do the work
            try
            {
                CheckToCancel();

                UpdateApplicationManifest appManifest = GetApplicationManifest();

                CheckToCancel();

                DoStatusCallback(-1, "Determining update actions ...");
                Version existingVersion;
                updateAction = GetUpdateAction(appManifest, out existingVersion);
                currentVersion = existingVersion;

                if (updateAction == UpdateAction.None)
                {
                    LOG.Debug("ThreadWorkProc: Exiting thread, updateAction == UpdateAction.None");
                }
                else
                {
                    CheckToCancel();
                    LOG.Debug("ThreadWorkProc: Performing {0} from version {1} to version {2}",
                              updateAction.ToString(), (existingVersion == null) ? "Unknown" :
                              existingVersion.ToString(), appManifest.CurrentDatabaseVersion.ToString());

                    if (EnumUtils.IsFlagSet(updateAction, UpdateAction.FullRefresh))
                    {
                        currentVersion = DoFullRefresh(appManifest, out applicationCloseRequired);
                    }
                    if (!applicationCloseRequired && EnumUtils.IsFlagSet(updateAction, UpdateAction.VersionUpdate))
                    {
                        currentVersion = DoVersionUpdate(appManifest, currentVersion, out applicationCloseRequired);
                    }
                }
            }
            catch (Exception e)
            {
                resultException = e;
                LOG.Error("ThreadWorkProc: Failed to run thread", e);
            }

            _isRunning = false;

            DoCompleteCallback(updateAction, currentVersion, applicationCloseRequired, resultException);
        }

        protected string _manifestDownloadUrl;
        protected string _downloadedContentPassword;
        protected string _tempFolderPath;
        protected bool _cancelUpdate;
        protected bool _isRunning;
        protected DotNetZipHelper _zipHelper;
        protected SerializationUtils _serializationUtils;
    }
}
