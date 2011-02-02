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

using Common.Logging;

using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOS.Data;
using Windsor.Node2008.WNOS.Logic;
using Windsor.Node2008.WNOSUtility;
using Windsor.Node2008.WNOSConnector.Logic;
using Windsor.Node2008.WNOSConnector.Admin;
using Windsor.Node2008.WNOS.Server;
using Windsor.Node2008.WNOS.Utilities;
using Windsor.Commons.Core;
using Wintellect.PowerCollections;

namespace Windsor.Node2008.WNOS.Logic
{
    public class FlowManager : LogicAuditBaseManager, IFlowManagerEx, IFlowService
    {
        private IFlowDao _flowDao;
        private IServiceDao _serviceDao;
        private IAccountDao _accountDao;
        private IPluginLoader _pluginLoader;
        private IConfigManager _configManager;
        private IDataProviderDao _dataProviderDao;

        #region Init

        new public void Init()
        {
			base.Init();
			
			FieldNotInitializedException.ThrowIfNull(this, ref _flowDao);
            FieldNotInitializedException.ThrowIfNull(this, ref _serviceDao);
            FieldNotInitializedException.ThrowIfNull(this, ref _accountDao);
            FieldNotInitializedException.ThrowIfNull(this, ref _pluginLoader);
            FieldNotInitializedException.ThrowIfNull(this, ref _configManager);
            FieldNotInitializedException.ThrowIfNull(this, ref _dataProviderDao);
        }

        #endregion

        public IDictionary<string, string> GetAllFlowDisplayNames()
        {
            return _flowDao.GetAllFlowDisplayNames();
        }

        public string GetDataFlowNameById(string flowId)
        {
			return _flowDao.GetDataFlowNameById(flowId);
        }
        public string GetDataFlowNameById(string flowId, out bool isProtected)
        {
			return _flowDao.GetDataFlowNameById(flowId, out isProtected);
        }
        public string GetDataFlowIdByName(string flowName)
        {
            return _flowDao.GetDataFlowIdByName(flowName);
        }
        public string GetDataFlowNameByServiceName(string serviceName, out bool moreThanOneFlowFound)
        {
            return _flowDao.GetDataFlowNameByServiceName(serviceName, out moreThanOneFlowFound);
        }
        public string GetDataFlowIdByName(string flowName, out bool isProtected)
        {
            return _flowDao.GetDataFlowIdByName(flowName, out isProtected);
        }
        public DataFlow GetDataFlow(string flowId)
        {
			return _flowDao.GetDataFlow(flowId);
        }
        public IList<string> GetProtectedFlowNamesForUser(string username)
        {
            return _flowDao.GetProtectedFlowNamesForUser(username);
        }
        public DataService GetSubmitDocumentServiceForFlow(string flowId, string operation)
        {
			return _flowDao.GetSubmitDocumentServiceForFlow(flowId, operation);
        }
        public DataService GetNotifyDocumentServiceForFlow(string flowId, string operation)
        {
			return _flowDao.GetNotifyDocumentServiceForFlow(flowId, operation);
        }
        public DataService GetQueryServiceForFlow(string flowId, string request) {
			return _flowDao.GetQueryServiceForFlow(flowId, request);
        }
        public DataService GetSolicitServiceForFlow(string flowId, string request) {
			return _flowDao.GetSolicitServiceForFlow(flowId, request);
        }
        public DataService GetExecuteServiceForFlow(string flowId, string methodName)
        {
            return _flowDao.GetExecuteServiceForFlow(flowId, methodName);
        }
        public IList<DataFlow> GetAllDataFlows(bool loadDataServices, bool includeServiceParameters)
        {
            return _flowDao.GetAllDataFlows(loadDataServices, includeServiceParameters);
        }
        public IDictionary<string, string> GetAllFlowsNameToIdMap()
        {
            return _flowDao.GetAllFlowsNameToIdMap();
        }

        public DataService SaveService(DataService instance, AdminVisit visit)
        {
            ValidateByRole(visit, SystemRoleType.Admin);

            if (instance == null)
            {
                throw new ArgumentException("Input values are null.");
            }

            instance.ModifiedById = visit.Account.Id;
            string flowName = GetDataFlowNameById(instance.FlowId);
            TransactionTemplate.Execute(delegate
            {
                _serviceDao.Save(instance);
                ActivityManager.LogAudit(NodeMethod.None, flowName, visit, "{0} saved data service: {1}.",
                                         visit.Account.NaasAccount, instance.ToString());
                return null;
            });
            return instance;
        }

        public void DeleteService(DataService instance, AdminVisit visit)
        {
            ValidateByRole(visit, SystemRoleType.Admin);

            string flowName = GetDataFlowNameById(instance.FlowId);
            TransactionTemplate.Execute(delegate
            {
                _serviceDao.Delete(instance);
                ActivityManager.LogAudit(NodeMethod.None, flowName, visit, "{0} deleted service item: {1}.",
                                         visit.Account.NaasAccount, instance.ToString());
                return null;
            });
        }

        public DataFlow SaveFlow(DataFlow instance, AdminVisit visit)
        {
            ValidateByRole(visit, SystemRoleType.Admin);

            if ((instance == null))
            {
                throw new ArgumentException("Input values are null.");
            }

            instance.ModifiedById = visit.Account.Id;
            TransactionTemplate.Execute(delegate
            {
                _flowDao.Save(instance);
                ActivityManager.LogAudit(NodeMethod.None, instance.FlowName, visit, "{0} saved flow: {1}.",
                                         visit.Account.NaasAccount, instance.ToString());
                return null;
            });
            return instance;
        }

        public void DeleteFlow(DataFlow instance, AdminVisit visit)
        {
            ValidateByRole(visit, SystemRoleType.Admin);

            TransactionTemplate.Execute(delegate
            {
                _flowDao.Delete(instance);
                ActivityManager.LogAudit(NodeMethod.None, instance.FlowName, visit, "{0} deleted data flow: {1}.",
                                         visit.Account.NaasAccount, instance.ToString());
                return null;
            });
        }

        public DataFlow GetFlow(string flowId, AdminVisit visit)
        {
            ValidateByRole(visit, SystemRoleType.Program);
            return _flowDao.GetDataFlow(flowId);
        }

        public DataService GetService(string serviceId, AdminVisit visit)
        {
            ValidateByRole(visit, SystemRoleType.Program);
            return _serviceDao.GetDataService(serviceId);
        }
        public void ValidateBasePlugin(DataService inDataService)
        {
            _pluginLoader.ValidateBasePlugin(inDataService);
        }

        public IList<DataFlow> GetFlows(AdminVisit visit, bool loadDataServices)
        {
            ValidateByRole(visit, SystemRoleType.Program);
            return GetAllDataFlows(loadDataServices, false);
        }
        public IList<DataFlow> GetProtectedFlows(AdminVisit visit, bool loadDataServices)
        {
            ValidateByRole(visit, SystemRoleType.Program);
            return _flowDao.GetAllProtectedDataFlows(loadDataServices);
        }
        public IList<string> GetProtectedFlowNames()
        {
            return _flowDao.GetAllProtectedDataFlowNames();
        }
        public IDictionary<string, string> GetAllProtectedUpperDataFlowNamesToIdMap()
        {
            return _flowDao.GetAllProtectedUpperDataFlowNamesToIdMap();
        }
        public string GetFlowNameFromId(string flowId, AdminVisit visit)
        {
            return _flowDao.GetDataFlowNameById(flowId);
        }
        public ICollection<SimpleDataService> GetDataServiceImplementersForFlow(string flowId)
        {
            return _pluginLoader.GetDataServiceImplementersForFlow(flowId);
        }
        public void InstallPluginForFlow(byte[] zipFileContent, string flowName, AdminVisit visit)
        {
            ValidateByRoleAndNotDemoAccount(visit, SystemRoleType.Admin);

            string flowId = GetDataFlowIdByName(flowName);
            if (flowId == null)
            {
                throw new ArgumentException(string.Format("Unrecognized flow name: \"{0}\"",
                                                          flowName));
            }
            string auditMessage = _pluginLoader.InstallPluginForFlow(zipFileContent, visit.Account.Id, flowId);
            ActivityManager.LogAudit(NodeMethod.None, flowName, visit, "{0} installed plugin for flow: {1}. Message: {2}",
                                     visit.Account.NaasAccount, flowName, auditMessage);
        }
        public ICollection<string> GetGlobalArgs()
        {
            ICollection<ConfigItem> configItems = _configManager.Get(ConfigurationType.Global);
            OrderedSet<string> list = new OrderedSet<string>();
            if (!CollectionUtils.IsNullOrEmpty(configItems))
            {
                foreach (ConfigItem configItem in configItems)
                {
                    list.Add(configItem.Id);
                }
            }
            return list;
        }
        public ICollection<string> GetDataSourceNames()
        {
            return _dataProviderDao.GetAllDataSourceNames();
        }
        public ICollection<string> GetDataFlowNames()
        {
            return _flowDao.GetAllDataFlowNames();
        }
        public DataProviderInfo GetDataSourceByName(string inDataSourceName)
        {
            return _dataProviderDao.GetByName(inDataSourceName);
        }
        public ICollection<string> GetFlowContactList()
        {
            return _accountDao.GetAllUserNames();
        }
        public string GetUsernameById(string userId)
        {
            return _accountDao.GetUsernameById(userId);
        }
        public string GetUserIdByName(string username)
        {
            return _accountDao.GetUserIdByName(username);
        }
        public IDictionary<string, SimpleListDisplayInfo> GetListInfo(params string[] args)
        {
            Dictionary<string, SimpleListDisplayInfo> dict = new Dictionary<string, SimpleListDisplayInfo>();
            IList<DataFlow> flows = GetAllDataFlows(false, false);
            if (!CollectionUtils.IsNullOrEmpty(flows))
            {
                foreach (DataFlow flow in flows)
                {
                    string name = flow.FlowName;
                    if ( flow.IsProtected )
                    {
                        name += " (Protected)";
                    }
                    dict.Add(flow.Id, new SimpleListDisplayInfo(name, string.Empty, flow));
                }
            }
            return dict;
        }
            
        #region Properties
        public IServiceDao ServiceDao
        {
            get { return _serviceDao; }
            set { _serviceDao = value; }
        }

        public IFlowDao FlowDao
        {
            get
            {
                return _flowDao;
            }
            set
            {
                _flowDao = value;
            }
        }
        public IPluginLoader PluginLoader
        {
            get { return _pluginLoader; }
            set { _pluginLoader = value; }
        }
        public IConfigManager ConfigManager
        {
            get { return _configManager; }
            set { _configManager = value; }
        }
        public IDataProviderDao DataProviderDao
        {
            get { return _dataProviderDao; }
            set { _dataProviderDao = value; }
        }
        public IAccountDao AccountDao
        {
            get { return _accountDao; }
            set { _accountDao = value; }
        }

        #endregion
    }
}
