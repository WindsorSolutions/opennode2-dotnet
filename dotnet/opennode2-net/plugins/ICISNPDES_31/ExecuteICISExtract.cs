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
using System.Data;
using System.Data.Common;
using System.Reflection;
using Spring.Data.Common;
using Windsor.Commons.Core;
using Windsor.Commons.Logging;
using Windsor.Commons.Spring;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSProviders;

namespace Windsor.Node2008.WNOSPlugin.ICISNPDES_31
{
    [Serializable]
    public class ExecuteICISExtract : BaseWNOSPlugin, ITaskProcessor
    {
        protected const string DATA_PARAM_ETL_SOURCE = "ETL Data Source";

        protected const string CONFIG_PARAM_ETL_NAME = "ETL Procedure Name";
        protected const string CONFIG_PARAM_ETL_TIMEOUT = "ETL Procedure Execute Timeout (in seconds)";

        protected static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());

        protected const string p_pk_param_name = "p_ics_subm_track_id";

        protected IRequestManager _requestManager;

        protected SpringBaseDao _etlDao;
        protected DataRequest _dataRequest;
        protected string _storedProcName;
        protected int _commandTimeout = 300;
        protected string _submissionTrackingDataTypePK;

        public ExecuteICISExtract()
        {
            DataProviders[DATA_PARAM_ETL_SOURCE] = null;

            ConfigurationArguments[CONFIG_PARAM_ETL_NAME] = null;
            ConfigurationArguments[CONFIG_PARAM_ETL_TIMEOUT] = null;
        }

        public virtual void ProcessTask(string requestId)
        {
            ProcessTaskInit(requestId);

            _submissionTrackingDataTypePK = DoExtract(this, _etlDao, _storedProcName, _commandTimeout);
        }
        public static string DoExtract(BaseWNOSPlugin plugin, SpringBaseDao etlDao, string storedProcName,
                                       int commandTimeout)
        {
            if (string.IsNullOrEmpty(storedProcName))
            {
                plugin.AppendAuditLogEvent("An ETL stored procedure was not specified, so none was executed");
                return null;
            }

            plugin.AppendAuditLogEvent("Executing ETL stored procedure \"{0}\" with timeout of {1} seconds ...",
                                       storedProcName, commandTimeout.ToString());

            string pk = null;

            try
            {
                IDbParameters parameters = etlDao.AdoTemplate.CreateDbParameters();
                IDbDataParameter pkParameter = parameters.AddOut(p_pk_param_name, DbType.String, 50);


                etlDao.AdoTemplate.Execute<int>(delegate(DbCommand command)
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = storedProcName;
                    command.CommandTimeout = commandTimeout;
                    Spring.Data.Support.ParameterUtils.CopyParameters(command, parameters);

                    try
                    {
                        SpringBaseDao.ExecuteCommandWithTimeout(command, commandTimeout, delegate(DbCommand commandToExecute)
                        {
                            commandToExecute.ExecuteNonQuery();

                            plugin.AppendAuditLogEvent("Successfully executed ETL stored procedure \"{0}\"", storedProcName);
                        });
                    }
                    catch (Exception spEx)
                    {
                        plugin.AppendAuditLogEvent("Failed to execute ETL stored procedure \"{0}\" with error: {1}",
                                                   storedProcName, ExceptionUtils.GetDeepExceptionMessage(spEx));
                        throw;
                    }
                    if (command.Parameters[pkParameter.ParameterName].Value == DBNull.Value)
                    {
                        // This indicates plugin processing should stop
                        plugin.AppendAuditLogEvent("The ETL stored procedure \"{0}\" returned NULL for the \"{1}\" out parameter",
                                                   storedProcName, p_pk_param_name);
                        return 0;
                    }
                    pk = command.Parameters[pkParameter.ParameterName].Value.ToString();
                    if (string.IsNullOrEmpty(pk))
                    {
                        throw new ArgException("The ETL stored procedure \"{0}\" returned an empty string value for the \"{1}\" out parameter",
                                               storedProcName, p_pk_param_name);
                    }

                    return 0;
                });
            }
            catch (Exception e)
            {
                plugin.AppendAuditLogEvent("Failed to perform extract with error: {0}", ExceptionUtils.GetDeepExceptionMessage(e));
                throw;
            }
            return pk;
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

            _etlDao = ValidateDBProvider(DATA_PARAM_ETL_SOURCE, typeof(NamedNullMappingDataReader));

            TryGetConfigParameter(CONFIG_PARAM_ETL_NAME, ref _storedProcName);

            TryGetConfigParameter(CONFIG_PARAM_ETL_TIMEOUT, ref _commandTimeout);
        }
        protected virtual void ValidateRequest(string requestId)
        {
            AppendAuditLogEvent("Loading request with id \"{0}\"", requestId);
            _dataRequest = _requestManager.GetDataRequest(requestId);
        }
    }
}
