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
    public class AQSExtractAndSubmission : AQSGetRawData, ITaskProcessor
    {
        protected const string CONFIG_EXTRACT_STORED_PROCEDURE_NAME = "Extract Stored Procedure Name";
        protected const string CONFIG_EXTRACT_TIMEOUT = "Execute Timeout (in seconds)";

        protected string _storedProcName = "EXTRACT_AQS_DATA.POPULATE_AQS_STAGING";
        protected int _commandTimeout = 300;

        const string p_facility_site_id = "p_facility_site_id";
        const string p_county_cd = "p_county_cd";
        const string p_monitor_start_date = "p_monitor_start_date";
        const string p_monitor_end_date = "p_monitor_end_date";
        const string p_runtime_txt = "p_runtime_txt";
        
        public AQSExtractAndSubmission()
        {
            ConfigurationArguments.Add(CONFIG_EXTRACT_STORED_PROCEDURE_NAME, null);
            ConfigurationArguments.Add(CONFIG_EXTRACT_TIMEOUT, null);
        }
        
        public virtual void ProcessTask(string requestId)
        {
            base.ProcessSolicit(requestId);
        }
        protected override void LazyInit()
        {
            base.LazyInit();

            TryGetConfigParameter(CONFIG_EXTRACT_STORED_PROCEDURE_NAME, ref _storedProcName);
            TryGetConfigParameter(CONFIG_EXTRACT_TIMEOUT, ref _commandTimeout);
        }
        protected override void ValidateRequest(string requestId)
        {
            base.ValidateRequest(requestId);
        }
        protected override void PrepareToGetData()
        {
            DoExtract();
        }
        public void DoExtract()
        {
            if (string.IsNullOrEmpty(_storedProcName))
            {
                AppendAuditLogEvent("An extract stored procedure was not specified.");
                return;
            }
            AppendAuditLogEvent("Executing stored procedure \"{0}\" with {1} ({2}), {3} ({4}), {5} ({6}), and {7} ({8}) ...",
                                _storedProcName, PARAM_START_DATE_KEY, _startDate, PARAM_END_DATE_KEY, _endDate,
                                PARAM_SITE_ID_KEY, _siteId, PARAM_COUNTY_CODE_KEY, _countyCode);

            try
            {

                IDbParameters parameters = _baseDao.AdoTemplate.CreateDbParameters();
                parameters.AddWithValue(p_facility_site_id, _siteId);
                parameters.AddWithValue(p_county_cd, _countyCode);
                parameters.AddWithValue(p_monitor_start_date, _startDate);
                parameters.AddWithValue(p_monitor_end_date, _endDate);
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




