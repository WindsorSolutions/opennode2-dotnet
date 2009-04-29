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

using System.Data;
using System.Data.Common;

using Spring.Data.Generic;
using Spring.Data.Common;


using Common.Logging;

using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSUtility;
using Windsor.Commons.Core;

namespace Windsor.Node2008.WNOS.Data
{
    public class ConfigDao : BaseDao, IConfigDao
    {
        public const string TABLE_NAME = "NConfig";
        private IServiceDao _serviceDao;

        new public void Init()
        {
            base.Init();

            FieldNotInitializedException.ThrowIfNull(this, ref _serviceDao);
        }

        #region Mappers

        private const string MAP_CONFIG_ITEM_COLUMNS = "Id;Value;Description;ModifiedBy;ModifiedOn;IsEditable";
		private ConfigItem MapConfigItem(IDataReader reader)
		{
			ConfigItem configItem = new ConfigItem();
            configItem.Id = reader.GetString(0);
            configItem.Value = reader.GetString(1);
            configItem.Description = reader.GetString(2);
            configItem.ModifiedById = reader.GetString(3); 
            configItem.ModifiedOn = reader.GetDateTime(4);
            configItem.IsEditable = DbUtils.ToBool(reader.GetString(5));
			return configItem;
		}
        #endregion // Mappers

        #region Methods

        public void Save(string curItemId, ConfigItem item)
        {
            DateTime now = DateTime.Now;
            if (string.IsNullOrEmpty(curItemId))
            {
                DoInsert(TABLE_NAME, "Id;Value;Description;ModifiedBy;ModifiedOn;IsEditable",
                         item.Id, item.Value ?? string.Empty, item.Description ?? string.Empty,
                         item.ModifiedById, now, DbUtils.ToDbBool(item.IsEditable));
            }
            else
            {
                DoSimpleUpdateOne(TABLE_NAME, "Id", curItemId, "Id;Value;Description;ModifiedBy;ModifiedOn;IsEditable",
                                  item.Id, item.Value ?? string.Empty, item.Description ?? string.Empty,
                                  item.ModifiedById, now, DbUtils.ToDbBool(item.IsEditable));
            }
            item.ModifiedOn = now;
        }

        public IList<ConfigItem> GetConfigItems()
        {
            List<ConfigItem> configItems = new List<ConfigItem>();
			DoSimpleQueryWithRowCallbackDelegate(
				TABLE_NAME, string.Empty, null, null, MAP_CONFIG_ITEM_COLUMNS,
				delegate(IDataReader reader) {
					if ( configItems == null ) {
						configItems = new List<ConfigItem>();
					}
					configItems.Add(MapConfigItem(reader));
				});
			return configItems;
        }

        public ConfigItem GetConfig(string id)
        {
			try {
				ConfigItem configItem = 
					DoSimpleQueryForObjectDelegate<ConfigItem>(
						TABLE_NAME, "Id", id, MAP_CONFIG_ITEM_COLUMNS, 
						delegate(IDataReader reader, int rowNum) 
						{
							return MapConfigItem(reader);
						});
					
				return configItem;
			}
			catch(Spring.Dao.IncorrectResultSizeDataAccessException) {
				return null; // Not found
			}
        }

        public void Delete(string id)
        {
            string valueName = ConfigItem.GLOBAL_ARG_INDICATOR + id;
            ICollection<string> services = _serviceDao.GetServiceNamesWithArgValue(valueName);
            if (!CollectionUtils.IsNullOrEmpty(services))
            {
                throw new ArgumentException(string.Format("Cannot delete config value \"{0}\" because it is used by the following service(s): {1}",
                                                          id, StringUtils.Join(", ", services)));
            }
            DoDeleteWhereIn(TABLE_NAME, "Id", new object[] { id });
        }
        #endregion
        public IServiceDao ServiceDao
        {
            get { return _serviceDao; }
            set { _serviceDao = value; }
        }

    }
}
