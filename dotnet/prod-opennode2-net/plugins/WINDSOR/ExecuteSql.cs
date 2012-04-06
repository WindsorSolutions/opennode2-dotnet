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
using Windsor.Commons.Spring;

namespace Windsor.Node2008.WNOSPlugin.Windsor
{
    [Serializable]
    public class ExecuteSql : BaseWNOSPlugin, ITaskProcessor
    {
        protected const string SOURCE_PROVIDER_KEY = "Data Source";

        protected const string CONFIG_COMMAND_TIMEOUT_KEY = "Command Timeout (in seconds)";

        protected int _commandTimeout = 300;
        protected DataRequest _dataRequest;
        protected SpringBaseDao _baseDao;

        /// <summary>
        /// Responsible for processing all FRS services
        /// </summary>
        public ExecuteSql()
        {
            DataProviders.Add(SOURCE_PROVIDER_KEY, null);

            ConfigurationArguments.Add(CONFIG_COMMAND_TIMEOUT_KEY, null);
        }

        protected virtual void LazyInit(string requestId)
        {
            IRequestManager requestManager;

            GetServiceImplementation(out requestManager);

            TryGetConfigParameter(CONFIG_COMMAND_TIMEOUT_KEY, ref _commandTimeout);

            _dataRequest = requestManager.GetDataRequest(requestId);

            _baseDao = ValidateDBProvider(SOURCE_PROVIDER_KEY);
            _baseDao.AdoTemplate.CommandTimeout = _commandTimeout;
        }

        /// <summary>
        /// ProcessTask
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns></returns>
        public virtual void ProcessTask(string requestId)
        {
            LazyInit(requestId);

            if (CollectionUtils.IsNullOrEmpty(_dataRequest.Parameters))
            {
                throw new ArgumentException("No sql statements were specified");
            }
            if (_dataRequest.Parameters.IsByName)
            {
                throw new ArgumentException("Parameters must be \"by-index\" not \"by-name\"");
            }

            if (_dataRequest.Parameters.Count > 1)
            {
                _baseDao.TransactionTemplate.Execute(delegate
                {
                    foreach (string sqlStatement in _dataRequest.Parameters)
                    {
                        ExecuteSqlStatement(_baseDao, sqlStatement);
                    }
                    return null;
                });
            }
            else
            {
                ExecuteSqlStatement(_baseDao, _dataRequest.Parameters[0]);
            }
        }
        private void ExecuteSqlStatement(SpringBaseDao baseDao, string sqlStatement)
        {
            AppendAuditLogEvent("Executing: {0}", sqlStatement);
            baseDao.AdoTemplate.ClassicAdoTemplate.ExecuteNonQuery(CommandType.Text, sqlStatement);
        }
    }
    [Serializable]
    public class ExecuteStoredProcedure : ExecuteSql
    {
        /// <summary>
        /// ProcessTask
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns></returns>
        public override void ProcessTask(string requestId)
        {
            LazyInit(requestId);

            if (CollectionUtils.IsNullOrEmpty(_dataRequest.Parameters))
            {
                throw new ArgumentException("A stored procedure name was not specified");
            }
            if (!_dataRequest.Parameters.IsByName)
            {
                throw new ArgumentException("Parameters must be \"by-name\" not \"by-index\"");
            }

            Dictionary<string, string> storedProcParams = null;
            string storedProcName = null;
            for (int i = 0; i < _dataRequest.Parameters.Count; ++i)
            {
                string paramName = _dataRequest.Parameters.KeyAtIndex(i).Trim();
                if (string.IsNullOrEmpty(paramName))
                {
                    throw new ArgumentException(string.Format("The parameter name at index {0} is empty", (i + 1).ToString()));
                }
                string paramValue = _dataRequest.Parameters[i].Trim();
                if (paramName.Equals("Name", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (string.IsNullOrEmpty(paramValue))
                    {
                        throw new ArgumentException("The stored procedure Name is empty");
                    }
                    if (storedProcName != null)
                    {
                        throw new ArgumentException("More than one stored procedure Name was specified");
                    }
                    storedProcName = paramValue;
                }
                else
                {
                    if (storedProcParams == null)
                    {
                        storedProcParams = new Dictionary<string, string>();
                    }
                    else if (storedProcParams.ContainsKey(paramName))
                    {
                        throw new ArgumentException(string.Format("There is more than one stored procedure parameter named \"{0}\"", paramName));
                    }
                    storedProcParams[paramName] = paramValue;
                }
            }
            if (string.IsNullOrEmpty(storedProcName))
            {
                throw new ArgumentException("The stored procedure Name was not included with the service parameters");
            }
            if (storedProcParams != null)
            {
                IDbParameters parameters = _baseDao.AdoTemplate.CreateDbParameters();
                foreach (KeyValuePair<string, string> pair in storedProcParams)
                {
                    if (string.IsNullOrEmpty(pair.Value))
                    {
                        parameters.AddWithValue(pair.Key, DBNull.Value);
                    }
                    else
                    {
                        parameters.AddWithValue(pair.Key, pair.Value);
                    }
                }
                _baseDao.AdoTemplate.ExecuteNonQuery(CommandType.StoredProcedure, storedProcName, parameters);
            }
            else
            {
                _baseDao.DoStoredProc(storedProcName);
            }
        }
        private void ExecuteSqlStatement(SpringBaseDao baseDao, string sqlStatement)
        {
            AppendAuditLogEvent("Executing: {0}", sqlStatement);
            baseDao.AdoTemplate.ClassicAdoTemplate.ExecuteNonQuery(CommandType.Text, sqlStatement);
        }
    }
}
