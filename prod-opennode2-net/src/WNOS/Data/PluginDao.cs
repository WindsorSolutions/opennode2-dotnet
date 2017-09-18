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
using System.IO;

using Spring.Data.Generic;
using Spring.Data.Common;
using Spring.Transaction.Support;

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
    public class PluginDao : BaseDao, IPluginDao
    {
        public const string TABLE_NAME = "NPlugin";
        private string MAP_PLUGIN_COLUMNS = "Id;FlowId;BinaryVersion;ModifiedBy;ModifiedOn";

        #region Init

        new public void Init()
        {
            base.Init();
		}

        #endregion

        #region Methods
		/// <summary>
		/// Get the plugin zipped content from the DB.
		/// </summary>
        public byte[] GetPluginZippedBinary(string pluginId)
        {
            byte[] content =
                DoSimpleQueryForObjectDelegate<byte[]>(
                    TABLE_NAME, "Id", pluginId, "ZippedBinary",
                    delegate(IDataReader reader, int rowNum)
                    {
                        object value = reader.GetValue(0);
                        return (byte[])value;
                    });
            return content;
        }
        /// <summary>
        /// Get the plugin with the highest version for the given flow, or null if
        /// there aren't any plugins for the flow.
        /// </summary>
        public PluginItem GetHighestVersionPlugin(string flowId)
        {
            PluginItem item = null;
            DoSimpleTopQueryWithRowCallbackDelegate(TABLE_NAME,
                "FlowId", flowId, "BinaryVersion DESC", MAP_PLUGIN_COLUMNS, 1,
                delegate(IDataReader reader)
                {
                    item = new PluginItem();
                    int index = 0;
                    item.Id = reader.GetString(index++);
                    item.FlowId = reader.GetString(index++);
                    item.BinaryVersion = VersionInfo.FromSortableString(reader.GetString(index++));
                    item.ModifiedById = reader.GetString(index++);
                    item.ModifiedOn = reader.GetDateTime(index++);
                });
            return item;
        }
        public PluginItem SavePlugin(PluginItem item, byte[] zippedBinary)
        {
            ExceptionUtils.ThrowIfNull(item, "item");
            ExceptionUtils.ThrowIfNull(zippedBinary, "zippedBinary");

            string insertColumns = MAP_PLUGIN_COLUMNS + ";ZippedBinary";
            string binaryVersion = item.BinaryVersion.ToSortableString();
            DateTime now = DateTime.Now;
            string id = null;

            if (string.IsNullOrEmpty(item.Id))
            {
                id = IdProvider.Get();
                DoInsert(TABLE_NAME, insertColumns,
                         id, item.FlowId, binaryVersion, item.ModifiedById, now, zippedBinary);
            }
            else
            {
                DoSimpleUpdateOne(TABLE_NAME, "Id", item.Id.ToString(), insertColumns,
                                  item.Id, item.FlowId, binaryVersion, item.ModifiedById,
                                  now, zippedBinary);
            }
            if (id != null)
            {
                item.Id = id;
            }
            item.ModifiedOn = now;
            return item;
        }
        #endregion

        #region Properties

        #endregion
    }
}
