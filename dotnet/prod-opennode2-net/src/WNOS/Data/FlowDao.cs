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

using System.Data;
using System.Data.Common;
using System.Reflection;

using Spring.Data.Generic;
using Spring.Data.Common;

using Common.Logging;

using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSUtility;
using Windsor.Commons.Core;

using System.Linq;

namespace Windsor.Node2008.WNOS.Data
{
    /// <summary>
    /// Should be implementing interface but for now just use the raw object
    /// </summary>
    public class FlowDao : BaseDao, IFlowDao
    {
        private IAccountDao _accountDao;
        private IServiceDao _serviceDao;

        public IServiceDao ServiceDao
        {
            get
            {
                return _serviceDao;
            }
            set
            {
                _serviceDao = value;
            }
        }

        public IAccountDao AccountDao
        {
            get
            {
                return _accountDao;
            }
            set
            {
                _accountDao = value;
            }
        }
        public const string TABLE_NAME = "NFlow";

        #region Init

        new public void Init()
        {
            base.Init();

            FieldNotInitializedException.ThrowIfNull(this, ref _accountDao);
            FieldNotInitializedException.ThrowIfNull(this, ref _serviceDao);
        }

        #endregion

        #region Mappers

        private const string MAP_DATA_FLOW_COLUMNS = "Id;InfoUrl;Contact;IsProtected;ModifiedBy;ModifiedOn;Code;Description";
        private DataFlow MapDataFlow(IDataReader reader)
        {
            DataFlow flow = new DataFlow();
            int index = 0;
            flow.Id = reader.GetString(index++);
            flow.InfoUrl = reader.GetString(index++);
            flow.ContactUserId = reader.GetString(index++);
            flow.IsProtected = DbUtils.ToBool(reader.GetString(index++));
            flow.ModifiedById = reader.GetString(index++);
            flow.ModifiedOn = reader.GetDateTime(index++);
            flow.FlowName = reader.GetString(index++);
            flow.Description = reader.GetString(index++);
            return flow;
        }
        private void GetDataServicesForFlows(IList<DataFlow> flows, bool includeServiceParameters)
        {
            if (!CollectionUtils.IsNullOrEmpty(flows))
            {
                foreach (DataFlow flow in flows)
                {
                    flow.Services = GetDataServicesForFlow(flow.Id, includeServiceParameters);
                }
            }
        }
        #endregion

        #region Methods

        /// <summary>
        /// Get the data flow object for the flow with the specified flow id, or null
        /// if the id is not found.
        /// </summary>
        public DataFlow GetDataFlow(string flowId)
        {
            try
            {
                DataFlow dataFlow =
                    DoSimpleQueryForObjectDelegate<DataFlow>(
                        TABLE_NAME, "Id", flowId, MAP_DATA_FLOW_COLUMNS,
                        delegate(IDataReader reader, int rowNum)
                        {
                            return MapDataFlow(reader);
                        });
                dataFlow.Services = GetDataServicesForFlow(flowId, false);
                return dataFlow;
            }
            catch (Spring.Dao.IncorrectResultSizeDataAccessException)
            {
                return null; // Not found
            }
        }

        /// <summary>
        /// Key is the flow name, value is the flow id.
        /// </summary>
        public IDictionary<string, string> GetAllFlowsNameToIdMap()
        {
            Dictionary<string, string> dataFlows = new Dictionary<string, string>();
            DoSimpleQueryWithRowCallbackDelegate(
                TABLE_NAME, null, null, null, "Code;Id",
                delegate(IDataReader reader)
                {
                    dataFlows.Add(reader.GetString(0), reader.GetString(1));
                });
            return dataFlows;
        }
        /// <summary>
        /// Key is the flow name, value is the flow id.
        /// </summary>
        public IDictionary<string, string> GetAllFlowsIdToNameMap()
        {
            Dictionary<string, string> dataFlows = new Dictionary<string, string>();
            DoSimpleQueryWithRowCallbackDelegate(
                TABLE_NAME, null, null, null, "Id;Code",
                delegate(IDataReader reader)
                {
                    dataFlows.Add(reader.GetString(0), reader.GetString(1));
                });
            return dataFlows;
        }
        /// <summary>
        /// Key is the flow name, value is the flow id.
        /// </summary>
        public IDictionary<string, string> GetFlowsIdToNameMap(IEnumerable<string> flowNames)
        {
            Dictionary<string, string> dataFlows = new Dictionary<string, string>();
            if (CollectionUtils.IsNullOrEmpty(flowNames))
            {
                return dataFlows;
            }
            string whereClause = "UPPER(Code) IN (UPPER('" + StringUtils.Join("'),UPPER('", flowNames) + "'))";
            DoSimpleQueryWithRowCallbackDelegate(
                TABLE_NAME, whereClause, null, null, "Id;Code",
                delegate(IDataReader reader)
                {
                    dataFlows.Add(reader.GetString(0), reader.GetString(1));
                });
            return dataFlows;
        }

        public IList<string> GetProtectedFlowNamesForUser(string username)
        {
            List<string> flowNames = null;

            UserAccount account = _accountDao.GetByName(username);
            if (account == null)
            {
                return null;
            }

            if (account.Role == SystemRoleType.Admin)
            {
                return GetAllProtectedDataFlowNames();
            }
            else
            {
                DoSimpleQueryWithRowCallbackDelegate(
                    string.Format("{0} a;{1} ap", Windsor.Node2008.WNOS.Data.AccountDao.TABLE_NAME, Windsor.Node2008.WNOS.Data.AccountDao.POLICY_TABLE_NAME),
                    "a.NAASAccount;ap.Type;a.Id=ap.AccountId", new object[] { username, ServiceRequestAuthorizationType.Flow.ToString() },
                    "ap.Qualifier", "ap.Qualifier",
                    delegate(IDataReader reader)
                    {
                        CollectionUtils.Add(reader.GetString(0), ref flowNames);
                    });
            }
            return flowNames;
        }

        /// <summary>
        /// Return all data flows in the DB.
        /// </summary>
        public IList<DataFlow> GetAllDataFlows(bool loadDataServices, bool includeServiceParameters)
        {
            return GetAllDataFlows(null, loadDataServices, includeServiceParameters);
        }

        /// <summary>
        /// Return all data flows in the DB.
        /// </summary>
        public IList<DataFlow> GetAllDataFlows(string username, bool loadDataServices, bool includeServiceParameters)
        {
            IList<string> protectedFlowNames = null;
            if (!string.IsNullOrEmpty(username))
            {
                protectedFlowNames = GetProtectedFlowNamesForUser(username);
            }
            List<DataFlow> dataFlows = new List<DataFlow>();
            DoSimpleQueryWithRowCallbackDelegate(
                TABLE_NAME, null, null, "Code",
                MAP_DATA_FLOW_COLUMNS,
                delegate(IDataReader reader)
                {
                    DataFlow dataFlow = MapDataFlow(reader);
                    if (!string.IsNullOrEmpty(username) && dataFlow.IsProtected)
                    {
                        if ((protectedFlowNames == null) || (protectedFlowNames.FirstOrDefault(f => f.Equals(dataFlow.FlowName, StringComparison.OrdinalIgnoreCase)) == null))
                        {
                            return; // User does not have access to this flow, do not add it to the list
                        }
                    }
                    dataFlows.Add(dataFlow);
                });
            if (loadDataServices)
            {
                GetDataServicesForFlows(dataFlows, includeServiceParameters);
            }
            return dataFlows;
        }

        /// <summary>
        /// Return all protected data flows in the DB.
        /// </summary>
        public IList<DataFlow> GetAllProtectedDataFlows(bool loadDataServices)
        {
            List<DataFlow> dataFlows = new List<DataFlow>();
            DoSimpleQueryWithRowCallbackDelegate(
                TABLE_NAME, "IsProtected", DbUtils.ToDbBool(true), "Code",
                MAP_DATA_FLOW_COLUMNS,
                delegate(IDataReader reader)
                {
                    dataFlows.Add(MapDataFlow(reader));
                });
            if (loadDataServices)
            {
                GetDataServicesForFlows(dataFlows, false);
            }
            return dataFlows;
        }

        public IList<string> GetAllProtectedDataFlowNames()
        {
            List<string> names = null;
            DoSimpleQueryWithRowCallbackDelegate(
                TABLE_NAME, "IsProtected", DbUtils.ToDbBool(true), "Code",
                "Code",
                delegate(IDataReader reader)
                {
                    if (names == null)
                    {
                        names = new List<string>();
                    }
                    names.Add(reader.GetString(0));
                });
            return names;
        }
        public IDictionary<string, string> GetAllProtectedUpperDataFlowNamesToIdMap()
        {
            Dictionary<string, string> map = null;
            DoSimpleQueryWithRowCallbackDelegate(
                TABLE_NAME, "IsProtected", DbUtils.ToDbBool(true), null,
                "Code;Id",
                delegate(IDataReader reader)
                {
                    if (map == null)
                    {
                        map = new Dictionary<string, string>();
                    }
                    map.Add(reader.GetString(0).ToUpper(), reader.GetString(1));
                });
            return map;
        }
        /// <summary>
        /// Return the data services for the flow with the specified flow id, or null
        /// if the id is not found.
        /// </summary>
        public IList<DataService> GetDataServicesForFlow(string flowId, bool includeServiceParameters)
        {
            return ServiceDao.GetDataServicesForFlow(flowId, includeServiceParameters);
        }
        /// <summary>
        /// Return the submit document data service for the flow with the specified flow id, or null
        /// if the data service is not found.
        /// </summary>
        public DataService GetSubmitDocumentServiceForFlow(string flowId, string operation)
        {
            if (string.IsNullOrEmpty(operation))
            {
                operation = DataService.DEFAULT_SERVICE_NAME;
            }
            return GetServiceForFlow(flowId, operation, ServiceType.Submit);
        }
        /// <summary>
        /// Return the notify document data service for the flow with the specified flow id, or null
        /// if the data service is not found.
        /// </summary>
        public DataService GetNotifyDocumentServiceForFlow(string flowId, string operation)
        {
            return GetServiceForFlow(flowId, operation, ServiceType.Notify);
        }
        public DataService GetServiceForFlow(string flowId, string request, ServiceType serviceType)
        {
            IList<DataService> services =
                ServiceDao.GetDataServicesForFlow(flowId, request, serviceType);
            return CollectionUtils.IsNullOrEmpty(services) ? null : services[0];	// TODO: Return first if more than one?
        }
        /// <summary>
        /// Return the request data service for the flow with the specified flow id and request name, 
        /// or null if the data service is not found.
        /// </summary>
        public DataService GetQueryServiceForFlow(string flowId, string request)
        {
            return GetServiceForFlow(flowId, request, ServiceType.Query);
        }
        /// <summary>
        /// Return the request data service for the flow with the specified flow id and request name, 
        /// or null if the data service is not found.
        /// </summary>
        public DataService GetSolicitServiceForFlow(string flowId, string request)
        {
            return GetServiceForFlow(flowId, request, ServiceType.Solicit);
        }
        /// <summary>
        /// Return the request data service for the flow with the specified flow id and request name, 
        /// or null if the data service is not found.
        /// </summary>
        public DataService GetExecuteServiceForFlow(string flowId, string methodName)
        {
            return GetServiceForFlow(flowId, methodName, ServiceType.Execute);
        }
        /// <summary>
        /// Return the request data service for the flow with the specified flow id and request name, 
        /// or null if the data service is not found.
        /// </summary>
        public DataService GetQueryOrSolicitServiceForFlow(string flowId, string request)
        {
            return GetServiceForFlow(flowId, request, ServiceType.QueryOrSolicit);
        }
        /// <summary>
        /// Return all flow names as a dictionary of key/value pairs.
        /// </summary>
        public IDictionary<string, string> GetAllFlowDisplayNames()
        {
            Dictionary<string, string> flowNames = new Dictionary<string, string>();
            DoSimpleQueryWithRowCallbackDelegate(
                TABLE_NAME, null, null, null,
                "Id,Code",
                delegate(IDataReader reader)
                {
                    flowNames.Add(reader.GetString(0), reader.GetString(1));
                });
            return flowNames;
        }
        /// <summary>
        /// Return all flow names as a dictionary of key/value pairs.
        /// </summary>
        public IList<string> GetAllDataFlowNames()
        {
            List<string> flowNames = new List<string>();
            DoSimpleQueryWithRowCallbackDelegate(
                TABLE_NAME, null, null, "Code",
                "DISTINCT Code",
                delegate(IDataReader reader)
                {
                    flowNames.Add(reader.GetString(0));
                });
            return flowNames;
        }

        /// <summary>
        /// Return the flow code (name) for the flow with the specified flow id, or null
        /// if the id is not found.
        /// </summary>
        public string GetDataFlowNameById(string flowId)
        {
            try
            {
                return DoSimpleQueryForObjectDelegate<string>(
                        TABLE_NAME, "Id", flowId, "Code",
                        delegate(IDataReader reader, int rowNum)
                        {
                            return reader.GetString(0);
                        });
            }
            catch (Spring.Dao.IncorrectResultSizeDataAccessException)
            {
                return null; // Not found
            }
        }
        /// <summary>
        /// Return the flow code (name) for the flow with the specified flow id, or null
        /// if the id is not found. Return true in isProtected if the flow is protected.
        /// </summary>
        public string GetDataFlowNameById(string flowId, out bool isProtected)
        {
            try
            {
                bool isProtectedPriv = false;
                string code =
                    DoSimpleQueryForObjectDelegate<string>(
                        TABLE_NAME, "Id", flowId, "IsProtected;Code",
                        delegate(IDataReader reader, int rowNum)
                        {
                            isProtectedPriv = DbUtils.ToBool(reader.GetString(0));
                            return reader.GetString(1);
                        });
                isProtected = isProtectedPriv;
                return code;
            }
            catch (Spring.Dao.IncorrectResultSizeDataAccessException)
            {
                isProtected = false;
                return null; // Not found
            }
        }
        /// <summary>
        /// Return the flow id for the flow with the specified flow code (name), or null
        /// if the id is not found.
        /// </summary>
        public string GetDataFlowIdByName(string flowName)
        {
            try
            {
                return DoSimpleQueryForObjectDelegate<string>(
                        TABLE_NAME, "Code", flowName, "Id",
                        delegate(IDataReader reader, int rowNum)
                        {
                            return reader.GetString(0);
                        });
            }
            catch (Spring.Dao.IncorrectResultSizeDataAccessException)
            {
                return null; // Not found
            }
        }
        /// <summary>
        /// Return the flow name for the flow that has a service associated with it
        /// matching serviceName, or null if the service name is not found OR there
        /// is more than one service with that name.
        /// </summary>
        public string GetDataFlowNameByServiceName(string serviceName, out bool moreThanOneFlowFound)
        {
            string flowName = null;
            bool moreThanOneFlowFoundPriv = false;
            DoSimpleQueryWithRowCallbackDelegate(
                string.Format("{0} f;{1} s", TABLE_NAME, Windsor.Node2008.WNOS.Data.ServiceDao.TABLE_NAME),
                "s.Name;s.FlowId=f.Id", serviceName, null, "f.Code",
                delegate(IDataReader reader)
                {
                    if (flowName != null)
                    {
                        moreThanOneFlowFoundPriv = true;
                    }
                    else
                    {
                        flowName = reader.GetString(0);
                    }
                });
            moreThanOneFlowFound = moreThanOneFlowFoundPriv;
            return moreThanOneFlowFound ? null : flowName;
        }

        /// <summary>
        /// Return the flow id for the flow with the specified flow code (name), or null
        /// if the id is not found.
        /// </summary>
        public string GetDataFlowIdByName(string flowName, out bool isProtected)
        {
            try
            {
                bool isProtectedPriv = false;
                string code =
                    DoSimpleQueryForObjectDelegate<string>(
                        TABLE_NAME, "Code", flowName, "IsProtected;Id",
                        delegate(IDataReader reader, int rowNum)
                        {
                            isProtectedPriv = DbUtils.ToBool(reader.GetString(0));
                            return reader.GetString(1);
                        });
                isProtected = isProtectedPriv;
                return code;
            }
            catch (Spring.Dao.IncorrectResultSizeDataAccessException)
            {
                isProtected = false;
                return null; // Not found
            }
        }
        public void Save(DataFlow item)
        {
            if (item == null)
            {
                throw new ArgumentException("Null item");
            }
            DateTime now = DateTime.Now;
            string id = null;
            if (string.IsNullOrEmpty(item.Id))
            {
                id = IdProvider.Get();
                DoInsert(TABLE_NAME, "Id;InfoUrl;Contact;IsProtected;ModifiedBy;ModifiedOn;Code;Description",
                         id, item.InfoUrl, item.ContactUserId, DbUtils.ToDbBool(item.IsProtected),
                         item.ModifiedById, now, item.FlowName, item.Description);
            }
            else
            {
                DoSimpleUpdateOne(TABLE_NAME, "Id", item.Id.ToString(),
                                  "InfoUrl;Contact;IsProtected;ModifiedBy;ModifiedOn;Code;Description",
                                  item.InfoUrl, item.ContactUserId, DbUtils.ToDbBool(item.IsProtected),
                                  item.ModifiedById, now, item.FlowName, item.Description);
            }
            if (id != null)
            {
                item.Id = id;
            }
            item.ModifiedOn = now;
        }
        public void Delete(DataFlow item)
        {
            TransactionTemplate.Execute(delegate
            {
                DoSimpleDelete(ScheduleDao.TABLE_NAME, "FlowId", new object[] { item.Id });
                DoSimpleDelete(TransactionDao.TABLE_NAME, "FlowId", new object[] { item.Id });
                DoSimpleDelete(TABLE_NAME, "Id", new object[] { item.Id });
                return null;
            });
        }
        #endregion

        #region Properties
        public string TableName
        {
            get
            {
                return TABLE_NAME;
            }
        }
        #endregion
    }
}
