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
using System.Text;
using System.Data;
using System.Data.Common;
using System.Reflection;
using Spring.Data.Common;
using System.Collections.Generic;
using System.Collections;
using Windsor.Commons.XsdOrm;
using Windsor.Commons.Core;
using Windsor.Commons.Spring;
using Spring.Data;
using Spring.Data.Support;
using Spring.Dao;

namespace Windsor.Commons.XsdOrm.Implementations
{
    public abstract class ObjectsDatabaseBase
    {
        public void Init()
        {
        }

        protected virtual void BuildObjectSql(Dictionary<string, ObjectPath> objectPaths,
                                              SpringBaseDao baseDao)
        {
            List<string> columnNames = new List<string>();
            List<string> columnParamNames = new List<string>();

            foreach (ObjectPath objectPath in objectPaths.Values)
            {
                ObjectTableInfo tableInfo = objectPath.TableInfo;
                if (tableInfo != null)
                {
                    columnNames.Clear(); columnNames.Capacity = tableInfo.Columns.Count;
                    columnParamNames.Clear(); columnParamNames.Capacity = tableInfo.Columns.Count;
                    foreach (Column column in tableInfo.Columns)
                    {
                        if (!column.NoLoad)
                        {
                            columnNames.Add(column.ColumnName);
                            columnParamNames.Add(baseDao.DbProvider.CreateParameterName(column.ColumnName));
                        }
                    }
                    if (columnNames.Count > 0)
                    {
                        string columnNameStr = StringUtils.Join(",", columnNames);
                        string columnParamNamesStr = StringUtils.Join(",", columnParamNames);
                        objectPath.InsertSql = string.Format("INSERT INTO {0} ({1}) VALUES ({2})",
                                                            tableInfo.TableName, columnNameStr,
                                                            columnParamNamesStr);
                        objectPath.SelectSql = string.Format("SELECT {0} FROM {1}", columnNameStr, tableInfo.TableName);
                    }
                    else
                    {
                        objectPath.InsertSql = null;
                        objectPath.SelectSql = null;
                    }
                }
            }
        }
    }
}
