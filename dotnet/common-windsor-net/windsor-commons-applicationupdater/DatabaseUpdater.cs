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
using System.ServiceProcess;

using Windsor.Commons.Logging;
using Windsor.Commons.Core;
using Windsor.Commons.Compression;

using DbException = System.Data.SqlClient.SqlException;
using Windsor.Commons.Spring;
using Spring.Data.Common;

namespace Windsor.Commons.ApplicationUpdater
{
    /// <summary>Utilities to help with database update tasks</summary>
    public class DatabaseUpdater : BaseApplicationUpdater
    {
        public DatabaseUpdater() { }

        public DatabaseUpdater(string connectionString, string manifestDownloadUrl,
                               string downloadedContentPassword, string databaseVersionTableName) :
                               base(manifestDownloadUrl, downloadedContentPassword)
        {
            _connectionString = connectionString;
            _databaseVersionTableName = databaseVersionTableName;
        }

        /// <summary>
        /// Perform any database updates in a separate thread.
        /// </summary>
        public override void DoUpdatesAsync()
        {
            ExceptionUtils.ThrowIfEmptyString(_connectionString, "_connectionString");
            ExceptionUtils.ThrowIfEmptyString(_databaseVersionTableName, "_databaseVersionTableName");

            // Check to see if sql express is installed and running
            //try
            //{
            //    ServiceController serviceController = new ServiceController("MSSQL$SQLEXPRESS");
            //    if (serviceController.Status != ServiceControllerStatus.Running)
            //    {
            //        throw new InvalidOperationException("The SQL Server Express service is not running on this computer");
            //    }
            //}
            //catch (Exception)
            //{
            //    throw new InvalidOperationException("The SQL Server Express service could not be found on this computer");
            //}

            base.DoUpdatesAsync();
        }
        private IDbConnection GetDbConnection(string connectionString)
        {
            LOG.Debug("GetDbConnection: Returning database connection: {0}", connectionString);
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            return sqlConnection;
        }
        private IDbConnection OpenDbConnection(string connectionString)
        {
            IDbConnection dbConnection = GetDbConnection(connectionString);
            try
            {
                LOG.Debug("OpenDbConnection: Attempting to open database connection: {0}", dbConnection.ConnectionString);
                dbConnection.Open();
                return dbConnection;
            }
            catch (Exception e)
            {
                LOG.Error("OpenDbConnection: Failed to open database connection: {0}", e, dbConnection.ConnectionString);
                DisposableBase.SafeDispose(dbConnection);
                throw;
            }
        }
        private void ExecuteSqlCommandFileAndDelete(string filePath, string connectionString, bool throwException,
                                                    int retryCount)
        {
            try
            {
                do
                {
                    try
                    {
                        ExecuteSqlCommandFile(filePath, connectionString, throwException);
                        retryCount = 0;
                    }
                    catch (Exception)
                    {
                        if (retryCount == 0)
                        {
                            throw;
                        }
                    }
                } while (--retryCount >= 0);
            }
            finally
            {
                FileUtils.SafeDeleteFile(filePath);
            }
        }
        private void ExecuteSqlCommandFile(string filePath, string connectionString, bool throwException)
        {
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder(connectionString);

            LOG.Debug("ExecuteSqlCommandFile: Calling sqlcmd for file: {0}", filePath);
            string outputFilePath = filePath + ".txt";
            ProcessStartInfo psi = new ProcessStartInfo("sqlcmd");
            psi.Arguments = string.Format("-S \"{0}\" -d\"{1}\" -i \"{2}\" -r", sb.DataSource, sb.InitialCatalog, filePath, outputFilePath);
            if (!string.IsNullOrEmpty(sb.UserID))
            {
                psi.Arguments += string.Format(" -U \"{0}\" -P \"{1}\"", sb.UserID, sb.Password);
            }
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            psi.RedirectStandardError = true;
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            try
            {
                string errorString;
                using (Process process = new Process())
                {
                    process.StartInfo = psi;
                    process.Start();
                    errorString = process.StandardError.ReadToEnd();
                    process.WaitForExit();
                }
                if (!string.IsNullOrEmpty(errorString) && throwException)
                {
                    throw new InvalidOperationException(errorString);
                }
                // TSM: After running sqlcmd, we need to clear the in-memory connection pools since the database may have changed enough or
                // been dropped so that connection pool is no longer valid.  See http://forums.asp.net/p/1433838/3223633.aspx
                try
                {
                    SqlConnection.ClearAllPools();
                }
                catch (Exception e)
                {
                    LOG.Info("SqlConnection.ClearAllPools() failed: {0}", e);
                }
            }
            catch (Exception e)
            {
                LOG.Debug("ExecuteSqlCommandFile: Failed to call sqlcmd for file: {0}", e, filePath);
                throw;
            }
        }
        protected override UpdateAction GetUpdateAction(UpdateApplicationManifest appManifest,
                                                        out Version existingVersion)
        {
            existingVersion = null;
            if (appManifest.CurrentDatabaseVersion != null)
            {
                if (DatabaseExists(_connectionString))
                {
                    try
                    {
                        existingVersion = GetDatabaseVersion(_connectionString);
                    }
                    catch (Exception)
                    {
                    }
                }
                if (existingVersion == null)
                {
                    UpdateAction action = UpdateAction.FullRefresh;
                    if (appManifest.CurrentDatabaseVersion > appManifest.LastFullUpdateVersion)
                    {
                        action |= UpdateAction.VersionUpdate;
                    }
                    return action;
                }
                if (appManifest.CurrentDatabaseVersion > existingVersion)
                {
                    UpdateAction action = UpdateAction.None;
                    if (appManifest.LastFullUpdateVersion > existingVersion)
                    {
                        action |= UpdateAction.FullRefresh;
                    }
                    if (appManifest.CurrentDatabaseVersion > appManifest.LastFullUpdateVersion)
                    {
                        action |= UpdateAction.VersionUpdate;
                    }
                    return action;
                }
            }

            return UpdateAction.None;
        }
        protected override Version DoFullRefresh(UpdateApplicationManifest appManifest,
                                                 out bool applicationCloseRequired)
        {
            applicationCloseRequired = false;

            LOG.Debug("DoFullRefresh: Attempting to download database script file");
            string tempSqlFilePath = MakeTempFilePath(".sql");

            string statusString = string.Format("Downloading database content for version {0} ...",
                                                appManifest.LastFullUpdateVersion.ToString());

            DoStatusCallback(0, statusString);

            DownloadFile(appManifest.DatabaseFileDownloadUrl, tempSqlFilePath,
                         delegate(int percentComplete, object callbackParam)
                         {
                             DoStatusCallback(percentComplete, callbackParam.ToString());
                             return !_cancelUpdate;
                         },
                         statusString);

            CheckToCancel();

            DoStatusCallback(-1, "Performing database full refresh to version {0} (please be patient) ...", 
                                appManifest.LastFullUpdateVersion.ToString());

            if (DatabaseExists(_connectionString))
            {
                LOG.Debug("DoFullRefresh: Attempting to drop existing database for full refresh");
                DropDatabase(_connectionString);
            }

            LOG.Debug("DoFullRefresh: Attempting to create database for full refresh");
            CreateDatabase(_connectionString);

            LOG.Debug("DoFullRefresh: Attempting to run database script to populate database for full refresh");
            ExecuteSqlCommandFileAndDelete(tempSqlFilePath, _connectionString, true, 0);

            Version currentDatabaseVersion = GetDatabaseVersion(_connectionString);
            if (currentDatabaseVersion != appManifest.LastFullUpdateVersion)
            {
                throw new InvalidDataException(string.Format("Version mismatch during database full refresh: {0} vs. {1}",
                                                                currentDatabaseVersion.ToString(),
                                                                appManifest.LastFullUpdateVersion.ToString()));
            }
            
            return appManifest.LastFullUpdateVersion;
        }
        protected override Version DoVersionUpdate(UpdateApplicationManifest appManifest, Version existingVersion,
                                                   out bool applicationCloseRequired)
        {
            applicationCloseRequired = false;
            string statusString = string.Format("Downloading database script updates for version {0} ...",
                                                appManifest.CurrentDatabaseVersion.ToString());
            DoStatusCallback(0, statusString);

            string scriptsDirectory =
                DownloadAllTempFiles(appManifest.DatabaseScriptsDownloadUrl,
                         delegate(int percentComplete, object callbackParam)
                         {
                             DoStatusCallback(percentComplete, callbackParam.ToString());
                             return !_cancelUpdate;
                         },
                         statusString);

            try
            {
                DoStatusCallback(-1, "Performing database script updates ...");

                CheckToCancel();

                List<string> sortedScriptList = GetSortedScriptList(appManifest, scriptsDirectory,
                                                                    existingVersion);
                int i = 0;
                foreach (string scriptFile in sortedScriptList)
                {
                    Version fromVersion, toVersion;
                    GetVersionsFromScriptFileName(Path.GetFileName(scriptFile), out fromVersion, out toVersion);
                    int percentageComplete = (i++ * 100) / sortedScriptList.Count;
                    DoStatusCallback(percentageComplete, "Updating database version {0} to version {1} ...", fromVersion.ToString(), toVersion.ToString());
                    ExecuteSqlCommandFileAndDelete(scriptFile, _connectionString, true, 3);
                    CheckToCancel();
                }

                DoStatusCallback(100, "Performed database version updates");

                Version currentDatabaseVersion = GetDatabaseVersion(_connectionString);
                if (currentDatabaseVersion != appManifest.CurrentDatabaseVersion)
                {
                    throw new InvalidDataException(string.Format("Version mismatch during database update: {0} vs. {1}",
                                                                 currentDatabaseVersion.ToString(),
                                                                 appManifest.CurrentDatabaseVersion.ToString()));
                }
            }
            finally
            {
                FileUtils.SafeDeleteDirectory(scriptsDirectory);
            }
            return appManifest.CurrentDatabaseVersion;
        }
        private List<string> GetSortedScriptList(UpdateApplicationManifest appManifest, string scriptsDirectory,
                                                 Version existingDatabaseVersion)
        {
            LOG.Debug("GetSortedScriptList: Attempting to find valid script files for update");

            List<string> sortedList = new List<string>(Directory.GetFiles(scriptsDirectory, "Update_*.sql", SearchOption.TopDirectoryOnly));
            if (sortedList.Count == 0)
            {
                throw new InvalidDataException("The script update file did not contain any valid scripts");
            }
            sortedList.Sort();
            LOG.Debug("GetSortedScriptList: Extracted {0} script files from downloaded file", sortedList.Count);

            // We want to return just the list of updates to apply, so find the indexes of those files

            // Locate initial update script file
            string searchString = string.Format("UPDATE_{0}_{1}_{2}_TO_", existingDatabaseVersion.Major.ToString("D2"),
                                                existingDatabaseVersion.Minor.ToString("D2"),
                                                existingDatabaseVersion.Build.ToString("D2"));
            int startIndex = 0;
            foreach (string filePath in sortedList)
            {
                string fileName = Path.GetFileName(filePath).ToUpper();
                if (fileName.StartsWith(searchString))
                {
                    break;
                }
                ++startIndex;
            }
            if (startIndex == sortedList.Count)
            {
                throw new InvalidDataException("The script update file did not contain a valid script to update from database version " +
                                               existingDatabaseVersion.ToString());
            }

            // Locate last update file
            searchString = string.Format("_TO_{0}_{1}_{2}.SQL", appManifest.CurrentDatabaseVersion.Major.ToString("D2"),
                                         appManifest.CurrentDatabaseVersion.Minor.ToString("D2"),
                                         appManifest.CurrentDatabaseVersion.Build.ToString("D2"));
            int endIndex;
            for (endIndex = sortedList.Count - 1; endIndex >= 0; endIndex--)
            {
                string fileName = Path.GetFileName(sortedList[endIndex]).ToUpper();
                if (fileName.EndsWith(searchString))
                {
                    break;
                }
            }
            if ((endIndex < 0) || (startIndex > endIndex))
            {
                throw new InvalidDataException("The script update file did not contain a valid script to update to database version " +
                                               appManifest.CurrentDatabaseVersion.ToString());
            }
            if (endIndex < (sortedList.Count - 1))
            {
                sortedList.RemoveRange(endIndex + 1, sortedList.Count - endIndex - 1);
            }
            if (startIndex > 0)
            {
                sortedList.RemoveRange(0, startIndex);
            }
            LOG.Debug("GetSortedScriptList: Found {0} script file(s), starting with {1} and ending with {2}",
                      sortedList.Count, Path.GetFileName(sortedList[0]), Path.GetFileName(sortedList[sortedList.Count - 1]));
            return sortedList;
        }
        private void DeleteDatabaseFile(string mdfFilePath, bool throwException)
        {
            string logFilePath =
                FileUtils.ChangeFileNameWithoutExtension(mdfFilePath, Path.GetFileNameWithoutExtension(mdfFilePath) + "_log");
            logFilePath = Path.ChangeExtension(logFilePath, ".ldf");
            if (throwException)
            {
                if (File.Exists(mdfFilePath)) File.Delete(mdfFilePath);
                if (File.Exists(logFilePath)) File.Delete(logFilePath);
            }
            else
            {
                FileUtils.SafeDeleteFile(mdfFilePath);
                FileUtils.SafeDeleteFile(logFilePath);
            }
        }
        private Version GetDatabaseVersion(string connectionString)
        {
            LOG.Debug("GetDatabaseAction: Attempting to get database version from: {0}", connectionString);
            try
            {
                Version rtnVersion = null;
                using (IDbConnection dbConnection = GetDbConnection(connectionString))
                {
                    dbConnection.Open();
                    IDbCommand dbCommand = dbConnection.CreateCommand();
                    dbCommand.CommandType = CommandType.Text;
                    dbCommand.CommandText =
                        string.Format("SELECT TOP 1 {0} FROM {1} ORDER BY {2} DESC", _databaseVersionTableName,
                                      _databaseVersionColumnName, _databaseUpdateDateColumnName);

                    using (IDataReader reader = dbCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string versionString = reader.GetString(0);
                            rtnVersion = VersionFromString(versionString);
                        }
                    }
                }
                if (rtnVersion == null)
                {
                    throw new InvalidDataException("GetDatabaseAction: No version specified in database");
                }
                return rtnVersion;
            }
            catch (DbException e)
            {
                LOG.Debug("GetDatabaseAction: Failed to read version specified in database: {0}", e.Message);
                throw;
            }
        }
        private string GenerateDropDatabaseFile(string mdfFilePath)
        {
            LOG.Debug("GenerateDropDatabaseFile: Attempting to create \"drop database\" file for database: {0}",
                      mdfFilePath);
            string tempPath = MakeTempFilePath();
            StringBuilder cmdFile = new StringBuilder();

            cmdFile.AppendLine("use [master]");
            cmdFile.AppendLine("go");
            cmdFile.AppendFormat(@"drop database [{0}]", mdfFilePath);
            cmdFile.Append(Environment.NewLine);
            cmdFile.AppendLine("go");

            File.WriteAllText(tempPath, cmdFile.ToString());

            return tempPath;
        }
        private string GenerateDetachDatabaseFile(string mdfFilePath)
        {
            LOG.Debug("GenerateDetachDatabaseFile: Attempting to create \"detach database\" file for database: {0}",
                      mdfFilePath);
            string tempPath = MakeTempFilePath();
            StringBuilder cmdFile = new StringBuilder();

            cmdFile.AppendLine("use [master]");
            cmdFile.AppendLine("go");
            cmdFile.AppendFormat(@"exec sp_detach_db '{0}', 'true'", mdfFilePath);
            cmdFile.Append(Environment.NewLine);
            cmdFile.AppendLine("go");

            File.WriteAllText(tempPath, cmdFile.ToString());

            return tempPath;
        }
        private void GetVersionsFromScriptFileName(string fileName, out Version versionFrom, out Version versionTo)
        {
            fileName = fileName.ToUpper();

            if ((fileName.Length == 31) && fileName.StartsWith("UPDATE_") && fileName.EndsWith(".SQL"))
            {
                try
                {
                    int major = int.Parse(fileName.Substring(7, 2));
                    int minor = int.Parse(fileName.Substring(10, 2));
                    int build = int.Parse(fileName.Substring(13, 2));
                    versionFrom = new Version(major, minor, build, 0);
                    major = int.Parse(fileName.Substring(19, 2));
                    minor = int.Parse(fileName.Substring(22, 2));
                    build = int.Parse(fileName.Substring(25, 2));
                    versionTo = new Version(major, minor, build, 0);
                    return;
                }
                catch (Exception)
                {
                }
            }
            throw new ArgumentException("Input script file name is not in correct format: " + fileName);
        }
        private static void CreateDatabase(string connectionString)
        {
            SpringBaseDao dao = CreateDao(connectionString);
            dao.CreateDatabase();
        }
        private void DropDatabase(string connectionString)
        {
            SpringBaseDao dao = CreateDao(connectionString);
            dao.DropDatabase();
        }
        private bool DatabaseExists(string connectionString)
        {
            try
            {
                SpringBaseDao dao = CreateDao(connectionString);
                return dao.CheckIfDatabaseExists();
            }
            catch (Exception)
            {
                return false;
            }
        }
        private static SpringBaseDao CreateDao(string connectionString)
        {
            IDbProvider dbProvider = DbProviderFactory.GetDbProvider("System.Data.SqlClient");
            dbProvider.ConnectionString = connectionString;
            SpringBaseDao springBaseDao = new SpringBaseDao(dbProvider, typeof(NamedNullMappingDataReader));
            springBaseDao.AdoTemplate.CommandTimeout = 500;
            return springBaseDao;
        }
        private string _connectionString;
        private string _databaseVersionTableName;
        private string _databaseVersionColumnName = "Version";
        private string _databaseUpdateDateColumnName = "UpdateDate";
    }
}
