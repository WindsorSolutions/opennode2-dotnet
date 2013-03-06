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
using System.Collections;
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
using System.Runtime.InteropServices;
using System.ComponentModel;
using Windsor.Commons.Core;
using Windsor.Commons.Logging;
using Windsor.Commons.Spring;
using Windsor.Commons.XsdOrm;

namespace Windsor.Node2008.WNOSPlugin.WQX2
{
    [Serializable]
    public class ExecuteWQXExtract : BaseWNOSPlugin, ITaskProcessor
    {
        public enum DataSourceArgs
        {
            None,
            [Description("Data Source")]
            DataSource,
        }
        public enum ConfigArgs
        {
            None,
            [Description("Extract Stored Procedure Name")]
            StoredProcedureName,
            [Description("Execute Timeout (in seconds)")]
            ExecuteTimeout,
        }
        public enum ScheduleParams
        {
            None,
            [Description("OrgId")]
            OrgId,
            [Description("ProjectId")]
            ProjectId,
            [Description("StartDate")]
            StartDate,
            [Description("EndDate")]
            EndDate,
        }

        protected const string p_project_id = "p_project_id";
        protected const string p_org_id = "p_org_id";
        protected const string p_runtime_txt = "p_runtime_txt";
        protected const string p_runtime = "p_runtime";
        protected const string p_start_date = "p_start_date";
        protected const string p_end_date = "p_end_date";

        protected string _projectId;
        protected string _orgId;

        #region fields

        protected static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());

        protected IRequestManager _requestManager;

        protected SpringBaseDao _baseDao;
        protected DataRequest _dataRequest;
        protected string _storedProcName = "LOAD_WQX_DATA_P";
        protected int _commandTimeout = 300;

        #endregion

        public ExecuteWQXExtract()
        {
            AppendConfigArguments<ConfigArgs>();

            AppendDataProviders<DataSourceArgs>();
        }

        public virtual void ProcessTask(string requestId)
        {
            ProcessTaskInit(requestId);

            DoExtract(this, _baseDao, _storedProcName, _commandTimeout, _orgId, _projectId);
        }
        public static DateTime DoExtract(BaseWNOSPlugin plugin, SpringBaseDao baseDao, string storedProcName,
                                         int commandTimeout, string orgId, string projectId)
        {
            plugin.AppendAuditLogEvent("Executing stored procedure \"{0}\" with timeout of {1} seconds ...",
                                       storedProcName, commandTimeout.ToString());

            DateTime runtime = DateTime.Now;
            try
            {
                IDbParameters parameters = baseDao.AdoTemplate.CreateDbParameters();
                parameters.AddWithValue(p_project_id, string.IsNullOrEmpty(projectId) ? (object)DBNull.Value :
                                                                                        (object)projectId);
                parameters.AddWithValue(p_org_id, orgId);
                IDbDataParameter runtimeTextParameter = parameters.AddOut(p_runtime_txt, DbType.String, 2048);
                IDbDataParameter runtimeParameter = parameters.AddOut(p_runtime, DbType.Date);

                baseDao.AdoTemplate.Execute<int>(delegate(DbCommand command)
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = storedProcName;
                    Spring.Data.Support.ParameterUtils.CopyParameters(command, parameters);

                    try
                    {
                        SpringBaseDao.ExecuteCommandWithTimeout(command, commandTimeout, delegate(DbCommand commandToExecute)
                        {
                            commandToExecute.ExecuteNonQuery();
                        });
                    }
                    catch (Exception ex2)
                    {
                        plugin.AppendAuditLogEvent("Error returned from stored procedure: {0}", ExceptionUtils.GetDeepExceptionMessage(ex2));
                        throw;
                    }

                    if (command.Parameters[runtimeTextParameter.ParameterName].Value != DBNull.Value)
                    {
                        string procMessage = command.Parameters[runtimeTextParameter.ParameterName].Value.ToString();
                        procMessage = procMessage.Replace("\r\n", "\r");
                        procMessage = procMessage.Replace("\r", "\r\n");
                        plugin.AppendAuditLogEvent(procMessage);
                    }

                    if (command.Parameters[runtimeParameter.ParameterName].Value != DBNull.Value)
                    {
                        runtime = DateTime.Parse(command.Parameters[runtimeParameter.ParameterName].Value.ToString());
                    }

                    return 0;
                });

                plugin.AppendAuditLogEvent("Successfully executed stored procedure \"{0}\"", storedProcName);
            }
            catch (Exception e)
            {
                plugin.AppendAuditLogEvent("Failed to execute stored procedure \"{0}\" with error: {1}",
                                           storedProcName, ExceptionUtils.GetDeepExceptionMessage(e));
                throw;
            }
            return runtime;
        }

        public static void DoExtract(BaseWNOSPlugin plugin, SpringBaseDao baseDao, string storedProcName,
                                     int commandTimeout, string orgId, DateTime? startDate, DateTime? endDate)
        {
            plugin.AppendAuditLogEvent("Executing stored procedure \"{0}\" with timeout of {1} seconds ...",
                                       storedProcName, commandTimeout.ToString());

            try
            {
                IDbParameters parameters = baseDao.AdoTemplate.CreateDbParameters();
                parameters.AddWithValue(p_org_id, orgId);
                parameters.AddWithValue(p_start_date, startDate.HasValue ? (object)startDate.Value : (object)DBNull.Value);
                parameters.AddWithValue(p_end_date, endDate.HasValue ? (object)endDate.Value : (object)DBNull.Value);

                baseDao.AdoTemplate.Execute<int>(delegate(DbCommand command)
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = storedProcName;
                    Spring.Data.Support.ParameterUtils.CopyParameters(command, parameters);

                    try
                    {
                        SpringBaseDao.ExecuteCommandWithTimeout(command, commandTimeout, delegate(DbCommand commandToExecute)
                        {
                            commandToExecute.ExecuteNonQuery();
                        });
                    }
                    catch (Exception ex2)
                    {
                        plugin.AppendAuditLogEvent("Error returned from stored procedure: {0}", ExceptionUtils.GetDeepExceptionMessage(ex2));
                        throw;
                    }

                    return 0;
                });

                plugin.AppendAuditLogEvent("Successfully executed stored procedure \"{0}\"", storedProcName);
            }
            catch (Exception e)
            {
                plugin.AppendAuditLogEvent("Failed to execute stored procedure \"{0}\" with error: {1}",
                                           storedProcName, ExceptionUtils.GetDeepExceptionMessage(e));
                throw;
            }
        }

        public virtual void ProcessTaskInit(string requestId)
        {
            LazyInit();

            ValidateRequest(requestId);
        }
        protected virtual void LazyInit()
        {
            AppendAuditLogEvent("Initializing {0} plugin ...", this.GetType().Name);

            GetServiceImplementation(out _requestManager);

            _baseDao = ValidateDBProvider(EnumUtils.ToDescription(DataSourceArgs.DataSource), typeof(NamedNullMappingDataReader));

            _storedProcName = ValidateNonEmptyConfigParameter(EnumUtils.ToDescription(ConfigArgs.StoredProcedureName));

            TryGetConfigParameter(EnumUtils.ToDescription(ConfigArgs.ExecuteTimeout), ref _commandTimeout);
        }
        protected virtual void ValidateRequest(string requestId)
        {
            AppendAuditLogEvent("Loading request with id \"{0}\"", requestId);
            _dataRequest = _requestManager.GetDataRequest(requestId);

            GetParameter(_dataRequest, EnumUtils.ToDescription(ScheduleParams.OrgId), 0,
                          out _orgId);
            TryGetParameter(_dataRequest, EnumUtils.ToDescription(ScheduleParams.ProjectId), 1,
                            ref _projectId);

            AppendAuditLogEvent("Schedule parameters: {0} ({1}), {2} ({3})", EnumUtils.ToDescription(ScheduleParams.OrgId),
                                _orgId, EnumUtils.ToDescription(ScheduleParams.ProjectId), _projectId ?? "Not specified");
        }
    }
}
