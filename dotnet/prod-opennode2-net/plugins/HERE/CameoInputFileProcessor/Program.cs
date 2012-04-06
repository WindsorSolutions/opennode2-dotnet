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
using System.Reflection;
using System.Threading;
using System.Diagnostics;

using Windsor.Node2008.WNOSPlugin.Windsor;
using Windsor.Node2008.WNOSProviders;
using Windsor.Node2008.CameoInputFileProcessor.Properties;
using Windsor.Commons.Core;
using Windsor.Node2008.WNOSProviders.Implementation;
using Windsor.Commons.Spring;

namespace Windsor.Node2008.CameoInputFileProcessor
{
    public static class Program
    {
        public const string SERVICE_NAME = "CameoInputFileProcessor";
        public static void Main(string[] args)
        {
            while (ProcessNextInputFile())
            {
            }
        }
        public static bool ProcessNextInputFile()
        {
            StringBuilder message = new StringBuilder();
            bool success = false, foundFile = false;
            try
            {
                ProcessDBImportCSVFiles.OutputStatus(message, "Start CameoInputFileProcessor...");

                CreateApplicationEventLog();

                string importFolder = Settings.Default.ImportFolder;
                string importCSVFileSearchPattern = Settings.Default.ImportCSVFileSearchPattern;
                string importFileSearchToDBTableNamePattern = Settings.Default.ImportFileSearchToDBTableNamePattern;
                string tempFolderPath = Settings.Default.TempFolderPath;
                string dbProviderType = Settings.Default.DBProviderType;
                string dbConnectionString = Settings.Default.DBConnectionString;
                string archiveFolder = Settings.Default.ArchiveFolder;
                string errorFolder = Settings.Default.ErrorFolder;
                string cleanupTablesStoredProcName = Settings.Default.CleanupTablesStoredProcName;
                string endProcessingStoredProcName = Settings.Default.EndProcessingStoredProcName;
                ICompressionHelper compressionHelper = new CompressionHelper();

                Spring.Data.Common.IDbProvider dbProvider = Spring.Data.Common.DbProviderFactory.GetDbProvider(dbProviderType);
                dbProvider.ConnectionString = dbConnectionString;
                SpringBaseDao springBaseDao = new SpringBaseDao(dbProvider);

                ProcessDBImportCSVFiles.OutputStatus(message, "ImportFolder ({0}), ArchiveFolder ({1}), ErrorFolder ({2}), ImportCSVFileSearchPattern ({3}), ImportFileSearchToDBTableNamePattern ({4}), EndProcessingStoredProcName ({5}), TempFolderPath ({6}), DBProviderType ({7}), DBConnectionString ({8})",
                                                 importFolder, archiveFolder, errorFolder, importCSVFileSearchPattern,
                                                 importFileSearchToDBTableNamePattern, endProcessingStoredProcName, tempFolderPath,
                                                 dbProviderType, dbConnectionString);

                message.Append(ProcessDBImportCSVFiles.ProcessImportFile(importFolder, archiveFolder, errorFolder,
                                                                         importCSVFileSearchPattern, importFileSearchToDBTableNamePattern,
                                                                         cleanupTablesStoredProcName, endProcessingStoredProcName, 
                                                                         springBaseDao, tempFolderPath,
                                                                         compressionHelper, out success, out foundFile));
                ProcessDBImportCSVFiles.OutputStatus(message, "Stop CameoInputFileProcessor...");
            }
            catch (Exception ex)
            {
                DebugUtils.CheckDebuggerBreak();
                message.Append(string.Format("\n\n\nERROR *********************\n\n"
                                             + ex.Message
                                             + "\n\n***************************\n\n\n{0}",
                                             ExceptionUtils.ToLongString(ex)));
            }
            finally
            {
                string messageOut = message.ToString();
                if (success)
                {
                    LogInfo(messageOut);
                }
                else
                {
                    LogError(messageOut);
                }
                Console.WriteLine(messageOut);
            }
            return foundFile;
        }
        private static void LogInfo(string message)
        {
            try
            {
                EventLog.WriteEntry(SERVICE_NAME, message, EventLogEntryType.Information);
            }
            catch
            {
            }
        }
        private static void LogError(string message)
        {
            try
            {
                EventLog.WriteEntry(SERVICE_NAME, message, EventLogEntryType.Error);
            }
            catch
            {
            }
        }
        private static void CreateApplicationEventLog()
        {
            if (!EventLog.SourceExists(SERVICE_NAME))
            {
                //An event log source should not be created and immediately used.
                //There is a latency time to enable the source, it should be created
                //prior to executing the application that uses the source.
                //Execute this sample a second time to use the new source.
                EventLog.CreateEventSource(SERVICE_NAME, null);
                Thread.Sleep(5000);    // Let the source be created before logging
            }
        }
    }
}
