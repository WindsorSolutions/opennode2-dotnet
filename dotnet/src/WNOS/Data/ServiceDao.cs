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
using Windsor.Node2008.WNOS.Utilities;

namespace Windsor.Node2008.WNOS.Data
{
    /// <summary>
    /// Service DAO implementation.  The service DAO provides access to all services related to a data flow.
    /// </summary>
    public class ServiceDao : BaseDao, IServiceDao
    {
        public const string TABLE_NAME = "NService";
        public const string ARGS_TABLE_NAME = "NServiceArg";
        public const string SOURCES_TABLE_NAME = "NServiceConn";

        private IDataProviderDao _dataProviderDao;
        private IFlowDao _flowDao;
        private IPluginLoader _pluginLoader;

        #region Init

        /// <summary>
        /// IoC initializer
        /// </summary>
        new public void Init()
        {
            base.Init();

            FieldNotInitializedException.ThrowIfNull(this, ref _dataProviderDao);
            FieldNotInitializedException.ThrowIfNull(this, ref _flowDao);
            FieldNotInitializedException.ThrowIfNull(this, ref _pluginLoader);
        }

        #endregion

        #region Mappers
        private const string MAP_DATA_SERVICE_COLUMNS = "Id;Name;FlowId;IsActive;ServiceType;Implementor;AuthLevel;ModifiedBy;ModifiedOn;PublishFlags";
        /// <summary>
        /// Convert database column values to a DataService instance.
        /// </summary>
        private DataService MapDataService(IDataReader reader)
		{
			DataService service = new DataService();
            int index = 0;
			service.Id = reader.GetString(index++);
			service.Name = reader.GetString(index++);
			service.FlowId = reader.GetString(index++);
			service.IsActive = DbUtils.ToBool(reader.GetString(index++));
			service.Type = EnumUtils.ParseEnum<ServiceType>(reader.GetString(index++));
			string implementor = reader.GetString(index++);
			if ( implementor.Length > 0 ) {
				service.PluginInfo = new ExecutableInfo(implementor);
			}
			service.MinAuthLevel = 
				EnumUtils.ParseEnum<ServiceRequestAuthorizationType>(reader.GetString(index++));
			service.ModifiedById = reader.GetString(index++);
			service.ModifiedOn = reader.GetDateTime(index++);
            if ( !reader.IsDBNull(index) ) {
                service.PublishFlags =
                    EnumUtils.ParseEnum<DataServicePublishFlags>(reader.GetString(index++));
            }
			return service;
		}

        /// <summary>
        /// Post-map data service data sources and arguments to a single DataService instance.
        /// </summary>
        private void PostMapDataService(DataService dataService, bool includeServiceParameters)
		{
			dataService.Args = GetServiceArguments(dataService.Id);
			dataService.DataSources = GetServiceDataSources(dataService.Id);
            if (includeServiceParameters)
            {
                dataService.ServiceParameters = _pluginLoader.GetDataServiceParameters(dataService);
            }
		}

        /// <summary>
        /// Post-map data service data sources and arguments to a list of DataService instances.
        /// </summary>
        private void PostMapDataServices(IEnumerable<DataService> dataServices, bool includeServiceParameters)
		{
			if ( !CollectionUtils.IsNullOrEmpty(dataServices) ) {
				foreach (DataService service in dataServices)
				{
					PostMapDataService(service, false);
				}
                if (includeServiceParameters)
                {
                    _pluginLoader.GetDataServiceParameters(dataServices);
                }
			}
		}
		#endregion // Mappers
		
        #region Methods
        /// <summary>
        /// Return all service names that have the value "value" as an argument.
        /// </summary>
        public ICollection<string> GetServiceNamesWithArgValue(string value)
        {
            List<string> serviceNames = new List<string>();
            DoSimpleQueryWithRowCallbackDelegate(
                string.Format("{0} s, {1} sa", TABLE_NAME, ARGS_TABLE_NAME),
                "sa.Value; sa.ServiceId = s.Id", new object[] { value }, "s.Name",
                "DISTINCT s.Name",
                delegate(IDataReader reader)
                {
                    serviceNames.Add(reader.GetString(0));
                });
            return serviceNames;
        }

        /// <summary>
        /// Return all service names that are associated with the input connection id.
        /// </summary>
        public ICollection<string> GetServiceNamesWithDataSource(string connectionId)
        {
            List<string> serviceNames = new List<string>();
            DoSimpleQueryWithRowCallbackDelegate(
                string.Format("{0} s, {1} sc", TABLE_NAME, SOURCES_TABLE_NAME),
                "sc.ConnectionId; sc.ServiceId = s.Id", new object[] { connectionId }, "s.Name",
                "DISTINCT s.Name",
                delegate(IDataReader reader)
                {
                    serviceNames.Add(reader.GetString(0));
                });
            return serviceNames;
        }
        
        /// <summary>
        /// Return all service names as a dictionary of key/value pairs, where the key is the id and the value
        /// is a display-friendly service name.
        /// </summary>
        public IDictionary<string, string> GetDataServiceDisplayList()
        {
            Dictionary<string, string> serviceNames = new Dictionary<string, string>();
            DoSimpleQueryWithRowCallbackDelegate(
                string.Format("{0} s;{1} f", TABLE_NAME, _flowDao.TableName),
                "s.IsActive;s.FlowId=f.Id", new object[] { DbUtils.ToDbBool(true) }, null,
                "s.Id,s.Name,f.Code",
                delegate(IDataReader reader)
                {
                    string displayName = string.Format("{0} - {1}", reader.GetString(2), reader.GetString(1));
                    serviceNames.Add(reader.GetString(0), displayName);
                });
            return serviceNames;
        }
        
        /// <summary>
        /// Return all service names (with the specified types) as a dictionary of key/value pairs.
        /// </summary>
        public IDictionary<string, string> GetDataServiceDisplayList(ServiceType typesToReturn)
        {
            Dictionary<string, string> serviceNames = new Dictionary<string, string>();
            string validServiceTypesGroup = GetDbInGroupFromFlagsEnum("s.ServiceType", typesToReturn);
            DoSimpleQueryWithRowCallbackDelegate(
                string.Format("{0} s;{1} f", TABLE_NAME, _flowDao.TableName),
                "s.IsActive;s.FlowId=f.Id;" + validServiceTypesGroup, new object[] { DbUtils.ToDbBool(true) }, null,
                "s.Id,s.Name,f.Code",
                delegate(IDataReader reader)
                {
                    string displayName = string.Format("{0} - {1}", reader.GetString(2), reader.GetString(1));
                    serviceNames.Add(reader.GetString(0), displayName);
                });
            return serviceNames;
        }
        
        /// <summary>
		/// Get the data service object for the service with the specified flow id, or null
		/// if the id is not found.
		/// </summary>
        public DataService GetDataService(string serviceId)
        {
			try {
				DataService dataService = 
					DoSimpleQueryForObjectDelegate<DataService>(
						TABLE_NAME, "Id", serviceId, MAP_DATA_SERVICE_COLUMNS, 
						delegate(IDataReader reader, int rowNum) 
						{
							return MapDataService(reader);
						});
					
				PostMapDataService(dataService, false);	
				return dataService;
			}
			catch(Spring.Dao.IncorrectResultSizeDataAccessException) {
				return null; // Not found
			}
        }

        /// <summary>
        /// Get the data service object for the service with the specified flow name, or null
        /// if the id is not found.
        /// </summary>
        public DataService GetDataServiceByFlowName(string flowName, string serviceName)
        {
            try
            {
                string columnNames = GiveTableAliasToColumnNames(MAP_DATA_SERVICE_COLUMNS, "s");
                DataService dataService =
                    DoSimpleQueryForObjectDelegate<DataService>(
                        string.Format("{0} s, {1} f", TABLE_NAME, Windsor.Node2008.WNOS.Data.FlowDao.TABLE_NAME),
                        "f.Code;s.Name;s.FlowId = f.Id", new object[] { flowName, serviceName },
                        columnNames,
                        delegate(IDataReader reader, int rowNum)
                        {
                            return MapDataService(reader);
                        });

                PostMapDataService(dataService, false);
                return dataService;
            }
            catch (Spring.Dao.IncorrectResultSizeDataAccessException)
            {
                return null; // Not found
            }
        }

        /// <summary>
        /// Get the flow id associated with the input data service.
        /// </summary>
        public string GetFlowIdFromDataServiceId(string serviceId)
        {
            string flowId =
                DoSimpleQueryForObjectDelegate<string>(
                    TABLE_NAME, "Id", serviceId, "FlowId",
                    delegate(IDataReader reader, int rowNum)
                    {
                        return reader.GetString(0);
                    });
            return flowId;
        }
        
        /// <summary>
		/// Return the arguments for the service with the specified service id, or null
		/// if the id is not found.  The returned dictionary contains key/value pairs,
        /// where the key is the argument name, and the value is the argument value.
		/// </summary>
        public IDictionary<string, string> GetServiceArguments(string serviceId)
        {
			Dictionary<string, string> args = null;
			DoSimpleQueryWithRowCallbackDelegate(
				ARGS_TABLE_NAME, "ServiceId", serviceId, null,
				"ArgCode;Value",
				delegate(IDataReader reader) {
					if ( args == null ) {
						args = new Dictionary<string, string>();
					}
					args.Add(reader.GetString(0), reader.GetString(1));
				});
			return args;
        }
		
        /// <summary>
		/// Return the data sources for the service with the specified service id, or null
		/// if the id is not found.  The key is the data source id, and the value is the data
        /// source instance.
		/// </summary>
        public IDictionary<string, DataProviderInfo> GetServiceDataSources(string serviceId)
        {
            Dictionary<string, DataProviderInfo> sources = new Dictionary<string, DataProviderInfo>();
            string columnNames = GiveTableAliasToColumnNames(_dataProviderDao.MapDataProviderColumns, "c") + ";s.KeyName";
            DoSimpleQueryWithRowCallbackDelegate(
                string.Format("{0} s;{1} c", SOURCES_TABLE_NAME, _dataProviderDao.TableName),
                "s.ServiceId;s.ConnectionId = c.Id",
                new object[] { serviceId }, null, columnNames,
                delegate(IDataReader reader)
                {
                    DataProviderInfo dataProvider = _dataProviderDao.MapDataProvider(reader);
                    string keyName = reader.GetString(reader.FieldCount - 1);
                    sources.Add(keyName, dataProvider);
                });
			return sources;
        }
        
        /// <summary>
		/// Return all the data services for the flow with the specified flow id, or null
		/// if the id is not found.
		/// </summary>
        public IList<DataService> GetDataServicesForFlow(string flowId, bool includeServiceParameters)
        {
            List<DataService> services = null;
            DoSimpleQueryWithRowCallbackDelegate(
				TABLE_NAME, "FlowId", flowId, "Name",
				MAP_DATA_SERVICE_COLUMNS,
				delegate(IDataReader reader) {
					if ( services == null ) {
						services = new List<DataService>();
					}
					services.Add(MapDataService(reader));
				});
            PostMapDataServices(services, includeServiceParameters);
			return services;
        }
		
        /// <summary>
		/// Return all the data services for the flow with the specified flow id, or null
		/// if the id is not found.
		/// </summary>
        public IList<DataService> GetDataServicesForFlow(string flowId, ServiceType serviceTypes)
        {
            List<DataService> services = null;
			string validServiceTypesGroup = GetDbInGroupFromFlagsEnum("ServiceType", serviceTypes);
			DoSimpleQueryWithRowCallbackDelegate(
				TABLE_NAME, "FlowId;" + validServiceTypesGroup, new object[] { flowId }, null,
				MAP_DATA_SERVICE_COLUMNS,
				delegate(IDataReader reader) {
					if ( services == null ) {
						services = new List<DataService>();
					}
					services.Add(MapDataService(reader));
				});
			PostMapDataServices(services, false);
			return services;
        }
		
        /// <summary>
		/// Return all the data services for the flow with the specified flow id, or null
		/// if the id is not found.
		/// </summary>
        public IList<DataService> GetDataServicesForFlow(string flowId, string serviceName, 
														ServiceType serviceTypes)
        {
            List<DataService> services = null;
			string validServiceTypesGroup = GetDbInGroupFromFlagsEnum("ServiceType", serviceTypes);
			DoSimpleQueryWithRowCallbackDelegate(
				TABLE_NAME, "FlowId;Name;" + validServiceTypesGroup, new object[] { flowId, serviceName }, null,
				MAP_DATA_SERVICE_COLUMNS,
				delegate(IDataReader reader) {
					if ( services == null ) {
						services = new List<DataService>();
					}
					services.Add(MapDataService(reader));
				});
			PostMapDataServices(services, false);
			return services;
        }

        /// <summary>
        /// Persist the input data service instance.  If the data service already exists, it is updated; otherwise,
        /// it is created.
        /// </summary>
        public void Save(DataService item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            DateTime now = DateTime.Now;
            string id = null;
            TransactionTemplate.Execute(delegate
            {
                try
                {
                    string implementerString = (item.PluginInfo != null) ? item.PluginInfo.ImplementerString : string.Empty;
                    if (string.IsNullOrEmpty(item.Id))
                    {
                        id = IdProvider.Get();
                        DoInsert(TABLE_NAME, "Id;Name;FlowId;IsActive;ServiceType;Implementor;AuthLevel;ModifiedBy;ModifiedOn;PublishFlags",
                                 id, item.Name, item.FlowId, DbUtils.ToDbBool(item.IsActive),
                                 item.Type.ToString(), implementerString, item.MinAuthLevel.ToString(),
                                 item.ModifiedById, now, item.PublishFlags);
                        item.Id = id;
                    }
                    else
                    {
                        DoSimpleUpdateOne(TABLE_NAME, "Id", item.Id.ToString(),
                                          "Name;FlowId;IsActive;ServiceType;Implementor;AuthLevel;ModifiedBy;ModifiedOn;PublishFlags",
                                          item.Name, item.FlowId, DbUtils.ToDbBool(item.IsActive),
                                          item.Type.ToString(), implementerString, item.MinAuthLevel.ToString(),
                                          item.ModifiedById, now, item.PublishFlags);
                    }
                    SaveServiceArgs(item);
                    SaveServiceDataSources(item);
                    return null;
                }
                catch (Exception)
                {
                    if (id != null)
                    {
                        item.Id = string.Empty;
                    }
                    throw;
                }
            });
            if (id != null)
            {
                item.Id = id;
            }
            item.ModifiedOn = now;
        }
        private void SaveServiceArgs(DataService item)
        {
            TransactionTemplate.Execute(delegate
            {
                DoSimpleDelete(ARGS_TABLE_NAME, "ServiceId", new object[] { item.Id });
                if (CollectionUtils.IsNullOrEmpty(item.Args))
                {
                    return null;
                }
                using (IEnumerator<KeyValuePair<string, string>> enumeratorObj = item.Args.GetEnumerator())
                {
                    object[] insertValues = new object[4];
                    object enumeratorObject = enumeratorObj;   // NOTE: Boxing here so that value-type enumerator works 
                                                               // in anonymous delegate
                    DoBulkInsert(ARGS_TABLE_NAME, "Id;ServiceId;ArgCode;Value",
                         delegate(int currentInsertIndex)
                         {
                             IEnumerator<KeyValuePair<string, string>> enumerator =
                                 (IEnumerator<KeyValuePair<string, string>>)enumeratorObject;
                             if (enumerator.MoveNext())
                             {
                                 insertValues[0] = IdProvider.Get();
                                 insertValues[1] = item.Id;
                                 insertValues[2] = enumerator.Current.Key;
                                 insertValues[3] = enumerator.Current.Value;
                                 enumeratorObject = enumerator;
                                 return insertValues;
                             }
                             else
                             {
                                 return null;
                             }
                         });
                }
                return null;
            });
        }
        private void SaveServiceDataSources(DataService item)
        {
            TransactionTemplate.Execute(delegate
            {
                DoSimpleDelete(SOURCES_TABLE_NAME, "ServiceId", new object[] { item.Id });
                if (CollectionUtils.IsNullOrEmpty(item.DataSources))
                {
                    return null;
                }
                using (IEnumerator<KeyValuePair<string, DataProviderInfo>> enumeratorObj = item.DataSources.GetEnumerator())
                {
                    object[] insertValues = new object[4];
                    object enumeratorObject = enumeratorObj;   // NOTE: Boxing here so that value-type enumerator works 
                                                               // in anonymous delegate
                    DoBulkInsert(SOURCES_TABLE_NAME, "Id;ServiceId;ConnectionId;KeyName",
                         delegate(int currentInsertIndex)
                         {
                             IEnumerator<KeyValuePair<string, DataProviderInfo>> enumerator =
                                 (IEnumerator<KeyValuePair<string, DataProviderInfo>>)enumeratorObject;
                             if (enumerator.MoveNext())
                             {
                                 insertValues[0] = IdProvider.Get();
                                 insertValues[1] = item.Id;
                                 insertValues[2] = enumerator.Current.Value.Id;
                                 insertValues[3] = enumerator.Current.Key;
                                 enumeratorObject = enumerator;
                                 return insertValues;
                             }
                             else
                             {
                                 return null;
                             }
                         });
                }
                return null;
            });
        }

        /// <summary>
        /// Delete the input data service instance.  After calling this method, the data service instance is no longer valid.
        /// </summary>
        public void Delete(DataService item)
        {
            DoSimpleDelete(TABLE_NAME, "Id", new object[] { item.Id });
        }
        #endregion

        #region Properties
        public IDataProviderDao DataProviderDao
        {
            get { return _dataProviderDao; }
            set { _dataProviderDao = value; }
        }
        public IFlowDao FlowDao
        {
            get { return _flowDao; }
            set { _flowDao = value; }
        }
        public IPluginLoader PluginLoader
        {
            get { return _pluginLoader; }
            set { _pluginLoader = value; }
        }
        #endregion
    }
}
