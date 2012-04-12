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
using System.Data.Common;
using Windsor.Node2008.WNOSPlugin;
using Spring.Data.Common;
using Spring.Transaction.Support;
using Spring.Data.Core;
using Windsor.Commons.Core;
using Windsor.Commons.Logging;
using Windsor.Commons.Spring;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSProviders;
using Microsoft.VisualBasic.FileIO;

namespace Windsor.Node2008.WNOSPlugin.AQS2
{
    public class ExecuteAQSRawDataImport : BaseWNOSPlugin, ITaskProcessor
    {
        protected const string SOURCE_PROVIDER_KEY = "Data Source";

        protected const string CONFIG_IMPORT_STORED_PROCEDURE_NAME = "Import Stored Procedure Name";
        protected const string CONFIG_IMPORT_TIMEOUT = "Execute Timeout (in seconds)";

        protected const string PARAM_RAW_DATA_FILE_NAME = "RawDataFile";
        protected const string PARAM_PRECISION_DATA_FILE_NAME = "PrecisionDataFile";
        protected const string PARAM_ACCURACY_DATA_FILE_NAME = "AccuracyDataFile";
        protected const string PARAM_BLANK_DATA_FILE_NAME = "BlankDataFile";

        protected IRequestManager _requestManager;

        protected SpringBaseDao _baseDao;
        protected DataRequest _dataRequest;

        protected string _storedProcName = "PROCESS_AQS_DATA_PKG.IMPORT_AQS_FLAT_FILE";
        protected int _commandTimeout = 300;

        protected string _rawDataFileName;
        protected string _precisionDataFileName;
        protected string _accuracyDataFileName;
        protected string _blankDataFileName;

        const string p_raw_file = "p_raw_file";
        const string p_precision_file = "p_precision_file";
        const string p_accuracy_file = "p_accuracy_file";
        const string p_blank_file = "p_blank_file";
        const string p_runtime_txt = "p_runtime_txt";

        public ExecuteAQSRawDataImport()
        {
            ConfigurationArguments.Add(CONFIG_IMPORT_STORED_PROCEDURE_NAME, null);
            ConfigurationArguments.Add(CONFIG_IMPORT_TIMEOUT, null);

            DataProviders.Add(SOURCE_PROVIDER_KEY, null);
        }
        
        public virtual void ProcessTask(string requestId)
        {
            LazyInit();

            ValidateRequest(requestId);

            DoImport();
        }
        protected virtual void LazyInit()
        {
            AppendAuditLogEvent("Initializing {0} plugin ...", this.GetType().Name);

            GetServiceImplementation(out _requestManager);

            _baseDao = ValidateDBProvider(SOURCE_PROVIDER_KEY, typeof(NamedNullMappingDataReader));
            
            _storedProcName = ValidateNonEmptyConfigParameter(CONFIG_IMPORT_STORED_PROCEDURE_NAME);

            TryGetConfigParameter(CONFIG_IMPORT_TIMEOUT, ref _commandTimeout);
        }
        protected virtual void ValidateRequest(string requestId)
        {
            AppendAuditLogEvent("Loading request with id \"{0}\"", requestId);
            _dataRequest = _requestManager.GetDataRequest(requestId);

            AppendAuditLogEvent("Validating request: {0}", _dataRequest);

            TryGetParameter(_dataRequest, PARAM_RAW_DATA_FILE_NAME, 0, ref _rawDataFileName);
            TryGetParameter(_dataRequest, PARAM_PRECISION_DATA_FILE_NAME, 1, ref _precisionDataFileName);
            TryGetParameter(_dataRequest, PARAM_ACCURACY_DATA_FILE_NAME, 2, ref _accuracyDataFileName);
            TryGetParameter(_dataRequest, PARAM_BLANK_DATA_FILE_NAME, 3, ref _blankDataFileName);

            AppendAuditLogEvent("Validated request with parameters: {0} = {1}, {2} = {3}, {4} = {5}, {6} = {7}",
                                      PARAM_RAW_DATA_FILE_NAME, _rawDataFileName, PARAM_PRECISION_DATA_FILE_NAME, _precisionDataFileName,
                                      PARAM_ACCURACY_DATA_FILE_NAME, _accuracyDataFileName, PARAM_BLANK_DATA_FILE_NAME, _blankDataFileName);

            if (string.IsNullOrEmpty(_rawDataFileName) && string.IsNullOrEmpty(_precisionDataFileName) &&
                string.IsNullOrEmpty(_accuracyDataFileName) && string.IsNullOrEmpty(_blankDataFileName))
            {
                throw new ArgumentException("At least one import flat file must be specified as a service parameter, but none was.");
            }
        }
        protected virtual void DoImport()
        {
            AppendAuditLogEvent("Executing stored procedure \"{0}\" with {1} ({2}), {3} ({4}), {5} ({6}), and {7} ({8}) ...",
                                _storedProcName, PARAM_RAW_DATA_FILE_NAME, _rawDataFileName, PARAM_PRECISION_DATA_FILE_NAME, _precisionDataFileName,
                                PARAM_ACCURACY_DATA_FILE_NAME, _accuracyDataFileName, PARAM_BLANK_DATA_FILE_NAME, _blankDataFileName);

            try
            {

                IDbParameters parameters = _baseDao.AdoTemplate.CreateDbParameters();
                parameters.AddWithValue(p_raw_file, _rawDataFileName);
                parameters.AddWithValue(p_precision_file, _precisionDataFileName);
                parameters.AddWithValue(p_accuracy_file, _accuracyDataFileName);
                parameters.AddWithValue(p_blank_file, _blankDataFileName);
                IDbDataParameter runtimeTextParameter = parameters.AddOut(p_runtime_txt, DbType.String, 2048);

                _baseDao.AdoTemplate.Execute<int>(delegate(DbCommand command)
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = _storedProcName;
                    command.CommandTimeout = _commandTimeout;
                    Spring.Data.Support.ParameterUtils.CopyParameters(command, parameters);

                    try
                    {
                        SpringBaseDao.ExecuteCommandWithTimeout(command, _commandTimeout, delegate(DbCommand commandToExecute)
                        {
                            commandToExecute.ExecuteNonQuery();
                        });
                    }
                    catch (Exception ex2)
                    {
                        AppendAuditLogEvent("Error returned from stored procedure: {0}", ExceptionUtils.GetDeepExceptionMessage(ex2));
                        throw;
                    }

                    if (command.Parameters[runtimeTextParameter.ParameterName].Value != DBNull.Value)
                    {
                        string procMessage = command.Parameters[runtimeTextParameter.ParameterName].Value.ToString();
                        procMessage = procMessage.Replace("\r\n", "\r");
                        procMessage = procMessage.Replace("\r", "\r\n");
                        AppendAuditLogEvent(procMessage);
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
    }
}




