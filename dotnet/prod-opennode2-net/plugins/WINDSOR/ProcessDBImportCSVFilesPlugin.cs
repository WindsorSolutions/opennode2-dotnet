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
using Windsor.Node2008.WNOSProviders;
using Windsor.Commons.Logging;
using Windsor.Commons.Spring;

namespace Windsor.Node2008.WNOSPlugin.Windsor
{

    [Serializable]
    public class ProcessDBImportCSVFilesPlugin : BaseWNOSPlugin, ITaskProcessor
    {
        #region fields
        private static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());
        // Config arguments:
        protected const string CONFIG_IMPORT_CSV_FOLDER_PATH = "Import CSV Folder Path";
        protected const string CONFIG_IMPORT_CSV_FILE_SEARCH_PATTERN = "Import CSV File Search Pattern";
        protected const string CONFIG_CSV_FILE_SEARCH_TO_DB_TABLE_NAME_PATTERN = "CSV File Search To DB Table Name Pattern";
        // DB providers:
        protected const string SOURCE_IMPORT_DB_PROVIDER = "Import DB Provider";
        #endregion

        /// <summary>
        /// Responsible for processing all FRS services
        /// </summary>
        public ProcessDBImportCSVFilesPlugin()
        {
            ConfigurationArguments.Add(CONFIG_IMPORT_CSV_FOLDER_PATH, null);
            ConfigurationArguments.Add(CONFIG_IMPORT_CSV_FILE_SEARCH_PATTERN, null);
            ConfigurationArguments.Add(CONFIG_CSV_FILE_SEARCH_TO_DB_TABLE_NAME_PATTERN, null);

            DataProviders.Add(SOURCE_IMPORT_DB_PROVIDER, null);
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
            ITransactionManager transactionManager;
            ICompressionHelper compressionHelper;

            GetServiceImplementation(out requestManager);
            GetServiceImplementation(out settingsProvider);

            string tempFolderPath = settingsProvider.TempFolderPath;
            string importFolder = ValidateExistingFolderConfigParameter(CONFIG_IMPORT_CSV_FOLDER_PATH);
            string importFileSearchPattern = ValidateNonEmptyConfigParameter(CONFIG_IMPORT_CSV_FILE_SEARCH_PATTERN);
            string importFileSearchToDBTableNamePattern = ValidateNonEmptyConfigParameter(CONFIG_CSV_FILE_SEARCH_TO_DB_TABLE_NAME_PATTERN);

            SpringBaseDao baseDao = ValidateDBProvider(SOURCE_IMPORT_DB_PROVIDER);
            GetServiceImplementation(out compressionHelper);
            bool success, foundFile;

            ProcessDBImportCSVFiles.ProcessImportFile(importFolder, null, null, importFileSearchPattern, 
                                                      importFileSearchToDBTableNamePattern, null, null, baseDao,
                                                      tempFolderPath, compressionHelper, out success, out foundFile);

            GetServiceImplementation(out transactionManager);
        }
    }
}
