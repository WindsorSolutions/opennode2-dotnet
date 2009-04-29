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
using Windsor.Node2008.WNOSConnector.Provider;
using Windsor.Node2008.WNOSUtility;
using Windsor.Commons.Core;

namespace Windsor.Node2008.WNOS.Data
{
    /// <summary>
    /// Should be implementing interface but for now just use the raw object
    /// </summary>
    public class DataProviderDao : BaseDao, IDataProviderDao
    {
        public const string TABLE_NAME = "NConnection";
        private IServiceDao _serviceDao;

        #region Init

        new public void Init()
        {
            base.Init();

            FieldNotInitializedException.ThrowIfNull(this, ref _serviceDao);
        }

        #endregion

        #region Mappers
        internal const string MAP_DATA_PROVIDER_COLUMNS = "Id;Code;Provider;ConnectionString;ModifiedBy;ModifiedOn";
        public DataProviderInfo MapDataProvider(IDataReader reader)
        {
            DataProviderInfo dataProvider = new DataProviderInfo();
            int index = 0;
            dataProvider.Id = reader.GetString(index++);
            dataProvider.Name = reader.GetString(index++);
            dataProvider.ProviderType = reader.GetString(index++);
            dataProvider.ConnectionString = reader.GetString(index++);
            dataProvider.ModifiedById = reader.GetString(index++);
            dataProvider.ModifiedOn = reader.GetDateTime(index++);
            return dataProvider;
        }
        #endregion // Mappers
		
        #region Methods
        /// <summary>
        /// Save()
        /// </summary>
        public void Save(DataProviderInfo item)
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
                DoInsert(TABLE_NAME, "Id;Code;Provider;ConnectionString;ModifiedBy;ModifiedOn",
                         id, item.Name, item.ProviderType, item.ConnectionString, item.ModifiedById,
                         now);
            }
            else
            {
                DoSimpleUpdateOne(TABLE_NAME, "Id", item.Id.ToString(),
                                  "Code;Provider;ConnectionString;ModifiedBy;ModifiedOn",
                                  item.Name, item.ProviderType, item.ConnectionString, item.ModifiedById,
                                  now);
            }
            if (id != null)
            {
                item.Id = id;
            }
            item.ModifiedOn = now;
        }
        
        /// <summary>
        /// GetById()
		/// </summary>
        public DataProviderInfo GetById(string id)
        {
			try {
                DataProviderInfo dataProvider =
                    DoSimpleQueryForObjectDelegate<DataProviderInfo>(
                        TABLE_NAME, "Id", id, MAP_DATA_PROVIDER_COLUMNS, 
						delegate(IDataReader reader, int rowNum) 
						{
                            return MapDataProvider(reader);
						});

                return dataProvider;
			}
			catch(Spring.Dao.IncorrectResultSizeDataAccessException) {
				return null; // Not found
			}
        }

        /// <summary>
        /// GetByCode()
        /// </summary>
        public DataProviderInfo GetByName(string code)
        {
            try
            {
                DataProviderInfo dataProvider =
                    DoSimpleQueryForObjectDelegate<DataProviderInfo>(
                        TABLE_NAME, "Code", code, MAP_DATA_PROVIDER_COLUMNS,
                        delegate(IDataReader reader, int rowNum)
                        {
                            return MapDataProvider(reader);
                        });

                return dataProvider;
            }
            catch (Spring.Dao.IncorrectResultSizeDataAccessException)
            {
                return null; // Not found
            }
        }

        /// <summary>
        /// Get()
        /// </summary>
        public ICollection<DataProviderInfo> Get()
        {
            List<DataProviderInfo> dataProviders = new List<DataProviderInfo>();
            DoSimpleQueryWithRowCallbackDelegate(
                TABLE_NAME, null, null, null,
                MAP_DATA_PROVIDER_COLUMNS,
                delegate(IDataReader reader)
                {
                    dataProviders.Add(MapDataProvider(reader));
                });

            return dataProviders;
        }

        /// <summary>
        /// Get()
        /// </summary>
        public ICollection<string> GetAllDataSourceNames()
        {
            List<string> dataSources = new List<string>();
            DoSimpleQueryWithRowCallbackDelegate(
                TABLE_NAME, null, null, "Code", "Code",
                delegate(IDataReader reader)
                {
                    dataSources.Add(reader.GetString(0));
                });

            return dataSources;
        }

        public void Delete(DataProviderInfo item)
        {
            // Make sure that the provider is not being used
            ICollection<string> services = _serviceDao.GetServiceNamesWithDataSource(item.Id);
            if (!CollectionUtils.IsNullOrEmpty(services))
            {
                throw new ArgumentException(string.Format("Cannot delete data source \"{0}\" because it is used by the following service(s): {1}",
                                                          item.Name, StringUtils.Join(", ", services)));
            }
            DoDeleteWhereIn(TABLE_NAME, "Id", new object[] { item.Id });
        }
        #endregion

        #region Properties
        public IServiceDao ServiceDao
        {
            get { return _serviceDao; }
            set { _serviceDao = value; }
        }
        public string TableName { get { return TABLE_NAME; } }

        public string MapDataProviderColumns { get { return MAP_DATA_PROVIDER_COLUMNS; } }

        #endregion
    }
}
