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
using System.Threading;
using Windsor.Node2008.WNOSPlugin;
using System.Diagnostics;
using System.Reflection;
using Windsor.Node2008.WNOSUtility;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSProviders;
using Spring.Data.Common;
using Windsor.Commons.Core;
using Windsor.Commons.Logging;

namespace Windsor.Node2008.WNOSPlugin.Security
{
    [Serializable]
    public class BulkAddUsers : BaseWNOSPlugin, ITaskProcessor
    {
        #region fields
        private static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());
        #endregion

        private IRequestManager _requestManager;
        private IFlowManager _flowManager;
        private IAccountManager _accountManager;
        private ITransactionManager _transactionManager;
        private string _transactionId;

        public void ProcessTask(string requestId)
        {

            GetServiceImplementation(out _requestManager);
            GetServiceImplementation(out _flowManager);
            GetServiceImplementation(out _accountManager);
            GetServiceImplementation(out _transactionManager);

            AppendAuditLogEvent("Loading request with id \"{0}\"", requestId);
            DataRequest dataRequest = _requestManager.GetDataRequest(requestId);
            
            AppendAuditLogEvent("Validating request parameters: {0}", dataRequest);

            _transactionId = dataRequest.TransactionId;
            bool createInNaas;
            string defaultPassword;
            SystemRoleType defaultRole;
            ICollection<string> accessFlowNames;
            ICollection<string> usernames = GetBulkAddUsersParams(dataRequest, _flowManager, out createInNaas,
                                                                  out defaultPassword, out defaultRole,
                                                                  out accessFlowNames);
            
            _transactionManager.ClearRealtimeTransactionDetails(_transactionId);

            if (CollectionUtils.IsNullOrEmpty(usernames))
            {
                AppendRealtimeDetail("No usernames were specified to add");
                return;
            }

            AppendRealtimeDetail("Got {0} username(s) to add: {1}", usernames.Count.ToString(),
                                 StringUtils.Join(", ", usernames));
            AppendRealtimeDetail("Parameters: createInNaas = {0}, defaultPassword = {1}, defaultRole = {2}, permittedFlows = {3}",
                                 createInNaas.ToString(), (defaultPassword == null) ? "NONE" :
                                 StringUtils.ReplaceAllChars(defaultPassword, "*"),
                                 defaultRole.ToString(), CollectionUtils.IsNullOrEmpty(accessFlowNames) ?
                                 "NONE" : StringUtils.Join(", ", accessFlowNames));
            
            UserAccount userAccount = _accountManager.GetById(dataRequest.ModifiedById);
            AdminVisit visit = new AdminVisit(userAccount, null);
            if (userAccount == null)
            {
                throw new ArgumentException("Could not locate the user with id: \"{0}\"", dataRequest.ModifiedById);
            }

            foreach (string username in usernames)
            {
                try
                {
//                    Thread.Sleep(8000);
                    _accountManager.BulkAddUser(username, createInNaas, defaultPassword,
                                                defaultRole, accessFlowNames, visit);
                    AppendRealtimeDetail(StatusActivityType.Success, "Added user {0}", username);
                }
                catch (Exception e)
                {
                    AppendRealtimeDetail(StatusActivityType.Error, "Failed to add user {0}: {1}", username, 
                                         ExceptionUtils.GetDeepExceptionMessage(e));
                }
            }
        }

        protected void AppendRealtimeDetail(string message, params string[] args)
        {
            AppendRealtimeDetail(StatusActivityType.Info, message, args);
        }
        protected void AppendRealtimeDetail(StatusActivityType statusType,
                                            string message, params string[] args)
        {
            if ( !CollectionUtils.IsNullOrEmpty(args) )
            {
                message = string.Format(message, args);
            }
            AppendAuditLogEvent(message);
            _transactionManager.AppendRealtimeTransactionDetail(_transactionId, message, statusType);
        }
        protected ICollection<string> GetBulkAddUsersParams(DataRequest dataRequest, IFlowManager flowManager,
                                                            out bool createInNaas, out string defaultPassword,
                                                            out SystemRoleType defaultRole,
                                                            out ICollection<string> accessFlowNames)
        {
            if (CollectionUtils.IsNullOrEmpty(dataRequest.Parameters))
            {
                throw new ArgumentException("No parameters were specified for the service");
            }
            if (!dataRequest.Parameters.IsByName)
            {
                throw new ArgumentException("The parameters for the service must be \"by-name\"");
            }
            IDictionary<string, string> flowsNameToIdMap = flowManager.GetAllFlowsNameToIdMap();

            createInNaas = true;
            defaultRole = SystemRoleType.Authed;
            defaultPassword = null;
            accessFlowNames = new List<string>();
            List<string> usernames = new List<string>();
            foreach (KeyValuePair<string, string> pair in dataRequest.Parameters.NameValuePairs)
            {
                string key = pair.Key.ToUpper();
                if (key.StartsWith(BulkAddUsersConstants.PARAM_USERNAME_PREFIX))
                {
                    if (!StringUtils.Contains(pair.Value, usernames, StringComparison.InvariantCultureIgnoreCase))
                    {
                        usernames.Add(pair.Value);
                    }
                }
                else if (key.StartsWith(BulkAddUsersConstants.PARAM_FLOW_NAME_PREFIX))
                {
                    string flowId;
                    if (!flowsNameToIdMap.TryGetValue(pair.Value, out flowId))
                    {
                        throw new ArgumentException(string.Format("A flow with the name \"{0}\" cannot be found",
                                                                  pair.Value));
                    }
                    accessFlowNames.Add(pair.Value);
                }
                else
                {
                    switch (key)
                    {
                        case BulkAddUsersConstants.PARAM_CREATE_IN_NAAS:
                            createInNaas = bool.Parse(pair.Value);
                            break;
                        case BulkAddUsersConstants.PARAM_DEFAULT_PASSWORD:
                            defaultPassword = pair.Value;
                            break;
                        case BulkAddUsersConstants.PARAM_DEFAULT_ROLE:
                            defaultRole = (SystemRoleType) Enum.Parse(typeof(SystemRoleType), pair.Value, true);
                            break;
                        default:
                            throw new ArgumentException(string.Format("An unrecognized key/value parameter was found: \"{0}\" = \"{1}\"",
                                                                      pair.Key, pair.Value));
                    }
                }
            }
            return usernames;
        }
    }
}
