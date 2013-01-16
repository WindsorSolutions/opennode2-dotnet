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

//#define REMOVE_EMPTY_OBJECTS
using System;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Reflection;
using Spring.Data.Common;
using System.Collections.Generic;
using System.Collections;
using Windsor.Commons.XsdOrm2;
using Windsor.Commons.Core;
using Windsor.Commons.Spring;
using Spring.Data;
using Spring.Data.Support;
using Spring.Dao;

namespace Windsor.Commons.XsdOrm2.Implementations
{
    public class ObjectsFromDatabase : ObjectsDatabaseBase, IObjectsFromDatabase
    {
        public new void Init()
        {
            base.Init();
        }

        public virtual string GetTableNameForType(Type objectType, Type mappingAttributesType)
        {
            MappingContext mappingContext = MappingContext.GetMappingContext(objectType, mappingAttributesType);

            return mappingContext.GetTableNameForType(objectType);
        }
        public virtual string GetPrimaryKeyNameForType(Type objectType, Type mappingAttributesType)
        {
            MappingContext mappingContext = MappingContext.GetMappingContext(objectType, mappingAttributesType);

            return mappingContext.GetPrimaryKeyNameForType(objectType);
        }
        public virtual List<T> LoadFromDatabase<T>(SpringBaseDao baseDao,
                                                   IDictionary<string, DbAppendSelectWhereClause> appendSelectWhereClauses,
                                                   Type mappingAttributesType)
        {
            IList objList = LoadFromDatabase(typeof(T), baseDao, appendSelectWhereClauses, mappingAttributesType);
            return CollectionUtils.ToList<T>(objList);
        }
        public virtual IList LoadFromDatabase(Type typeToLoad, SpringBaseDao baseDao,
                                              IDictionary<string, DbAppendSelectWhereClause> appendSelectWhereClauses,
                                              Type mappingAttributesType)
        {
            MappingContext mappingContext = MappingContext.GetMappingContext(typeToLoad, mappingAttributesType);

            BuildObjectSql(mappingContext, baseDao);

            Dictionary<object, IList> list = null;

            baseDao.AdoTemplate.ClassicAdoTemplate.Execute(delegate(IDbCommand command)
            {
                ColumnCachedValues cachedValues = new ColumnCachedValues();
                list =
                    LoadObjectInstancesToList(typeToLoad, null, null, appendSelectWhereClauses, cachedValues, mappingContext, command);
                return null;
            });
            if (list != null)
            {
                IList rtnList = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(typeToLoad));
                foreach (KeyValuePair<object, IList> pair in list)
                {
                    foreach (object listElement in pair.Value)
                    {
                        rtnList.Add(listElement);
                    }
                }
                foreach (object obj in rtnList)
                {
                    IAfterLoadFromDatabase afterLoadFromDatabase = obj as IAfterLoadFromDatabase;
                    if (afterLoadFromDatabase != null)
                    {
                        afterLoadFromDatabase.AfterLoadFromDatabase();
                    }
                }

                return rtnList;
            }
            else
            {
                return null;
            }
        }
        protected virtual Dictionary<object, IList> LoadObjectInstancesToList(Type objectTypeToLoad, Table objectTypeToLoadTable, Dictionary<object, object> parentPKToObjectMap,
                                                                              IDictionary<string, DbAppendSelectWhereClause> appendSelectWhereClauseMap,
                                                                              ColumnCachedValues cachedValues, MappingContext mappingContext, IDbCommand command)
        {
            if (objectTypeToLoadTable == null)
            {
                objectTypeToLoadTable = mappingContext.GetTableForType(objectTypeToLoad);
            }
            Dictionary<object, IList> list = null;

            if (!string.IsNullOrEmpty(objectTypeToLoadTable.SelectSql))
            {
                command.CommandText = objectTypeToLoadTable.SelectSql;
                command.CommandType = CommandType.Text;
                command.Parameters.Clear();

                AppendSelectWhereClause(objectTypeToLoadTable.TableName, command, appendSelectWhereClauseMap);

                list = LoadObjectInstancesToList(objectTypeToLoadTable, parentPKToObjectMap, appendSelectWhereClauseMap, cachedValues, mappingContext, command);
            }
            return list;
        }

        protected virtual Dictionary<object, IList> LoadObjectInstancesToList(Table tableOfObjectsToLoad, Dictionary<object, object> parentPKToObjectMap,
                                                                              IDictionary<string, DbAppendSelectWhereClause> appendSelectWhereClauseMap,
                                                                              ColumnCachedValues cachedValues, MappingContext mappingContext,
                                                                              IDbCommand command)
        {
            Dictionary<object, IList> list = null;
            Dictionary<object, bool> anyInstanceFieldsWereSetMap = null;
            Dictionary<object, object> pkToObjectMap = null;

            bool isVirtualObjectTable = tableOfObjectsToLoad.IsVirtualTable;
            bool isCustomXmlStringFormatTypeTable = false;
            if (isVirtualObjectTable)
            {
                isCustomXmlStringFormatTypeTable = tableOfObjectsToLoad.TableRootType.IsSubclassOf(typeof(CustomXmlStringFormatTypeBase));
            }

            using (IDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int readerIndex = 0;
                    object pk = null, fk = null;
                    bool skip = false;
                    bool anyObjectToSetFieldsWereSet = false;
                    Column pkColumn = null, fkColumn = null;
                    object objectToSet = null;
                    // isVirtualObjectTable == true if this table represents a string[], int[], etc. member
                    foreach (Column column in tableOfObjectsToLoad.DirectColumns)
                    {
                        if (!column.NoLoad)
                        {
                            object value = reader.GetValue(readerIndex++);

                            if (value == DBNull.Value)
                            {
                                value = null;
                            }

                            if (column.IsPrimaryKey)
                            {
                                pkColumn = column;
                                pk = value;
                            }
                            else if (column.IsForeignKey)
                            {
                                if (value != null)
                                {
                                    if (fkColumn != null)
                                    {
                                        if (pk != null)
                                        {
                                            throw new ArgException("The table \"{0}\" has a row with a primary key of \"{1}\" that has more than one foreign key specified.  Please specify only one foreign key per row for this table.",
                                                                   column.Table.TableName, pk.ToString());
                                        }
                                        else
                                        {
                                            throw new ArgException("The table \"{0}\" has a row that has more than one foreign key specified.  Please specify only one foreign key per row for this table.",
                                                                   column.Table.TableName);
                                        }
                                    }
                                    if (!parentPKToObjectMap.ContainsKey(value))
                                    {
                                        // This object has no parent, assume we skip it
                                        skip = true;
                                        break;
                                    }
                                    fkColumn = column;
                                    fk = value;
                                }
                            }
                            else
                            {
                                if (value != null)
                                {
                                    if (isVirtualObjectTable)
                                    {
                                        if (isCustomXmlStringFormatTypeTable)
                                        {
                                            CustomXmlStringFormatTypeBase newObjectToSet = (CustomXmlStringFormatTypeBase)Activator.CreateInstance(tableOfObjectsToLoad.TableRootType);
                                            newObjectToSet.SetValue(value);
                                            objectToSet = newObjectToSet;
                                        }
                                        else
                                        {
                                            objectToSet = column.GetSetMemberValue(value);
                                        }
                                    }
                                    else
                                    {

                                        if (objectToSet == null)
                                        {
                                            objectToSet = Activator.CreateInstance(tableOfObjectsToLoad.TableRootType);
                                        }
                                        column.SetSelectColumnValue(objectToSet, value, cachedValues);
                                        anyObjectToSetFieldsWereSet = true;
                                    }
                                }
                            }
                        }
                    }
                    if (skip)
                    {
                        continue;
                    }

                    if (objectToSet == null)
                    {
                        objectToSet = Activator.CreateInstance(tableOfObjectsToLoad.TableRootType);
                    }
                    ExceptionUtils.ThrowIfNull(pkColumn, "pkColumn");
                    ExceptionUtils.ThrowIfNull(pk, "pk");
                    if (!isVirtualObjectTable)
                    {
                        pkColumn.SetSelectColumnValue(objectToSet, pk, cachedValues);

                        if (fkColumn != null)
                        {
                            fkColumn.SetSelectColumnValue(objectToSet, fk, cachedValues);
                        }
                        else
                        {
                            if (parentPKToObjectMap != null)
                            {
                                throw new ArgException("The table \"{0}\" has a row with a primary key of \"{1}\" that does not have a foreign key specified.",
                                                       pkColumn.Table.TableName, pk.ToString());
                            }
                            fk = pk;
                        }
                        LoadSameTableInstances(objectToSet, tableOfObjectsToLoad.ChildSameTableElements, cachedValues, reader,
                                               ref readerIndex, ref anyObjectToSetFieldsWereSet);
                    }

                    int fieldCount = reader.FieldCount;
                    if (readerIndex != fieldCount)
                    {
                        throw new IndexOutOfRangeException(string.Format("The number of selected column values ({0}) is less than the expected number ({1}) for the object \"{2}\" and sql \"{3}\".",
                                                                         reader.FieldCount.ToString(), readerIndex.ToString(),
                                                                         tableOfObjectsToLoad.TableRootType.Name, tableOfObjectsToLoad.SelectSql));
                    }
                    if (list == null)
                    {
                        list = new Dictionary<object, IList>();
                        pkToObjectMap = new Dictionary<object, object>();
                        anyInstanceFieldsWereSetMap = new Dictionary<object, bool>();
                    }
                    IList listInstance;
                    if (!list.TryGetValue(fk, out listInstance))
                    {
                        listInstance = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(tableOfObjectsToLoad.TableRootType));
                        list.Add(fk, listInstance);
                    }
                    try
                    {
                        listInstance.Add(objectToSet);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    if (!isVirtualObjectTable)
                    {
                        pkToObjectMap.Add(pk, objectToSet);
                        anyInstanceFieldsWereSetMap.Add(objectToSet, anyObjectToSetFieldsWereSet);
                    }
                }
            }
            if (!isVirtualObjectTable)
            {
                if (list != null)
                {
                    // Load children
                    if (tableOfObjectsToLoad.ChildRelationMembers != null)
                    {
                        foreach (ChildRelationInfo childRelation in tableOfObjectsToLoad.ChildRelationMembers)
                        {
                            Table elementTable = null;
                            if (Utils.IsValidColumnType(childRelation.ValueType))
                            {
                                elementTable = childRelation.ChildTable;
                            }
                            if (childRelation.IsOneToMany)
                            {
                                Dictionary<object, IList> fkMap =
                                    LoadObjectInstancesToList(childRelation.ValueType, elementTable, pkToObjectMap, appendSelectWhereClauseMap, cachedValues,
                                                              mappingContext, command);
                                if (fkMap != null)
                                {
                                    foreach (KeyValuePair<object, IList> pair in fkMap)
                                    {
                                        object objectToSet = pkToObjectMap[pair.Key];
                                        if (childRelation.ParentToMemberChain != null)
                                        {
                                            foreach (SameTableElementInfo sameTableElementInfo in childRelation.ParentToMemberChain)
                                            {
                                                object childObjectToSet = sameTableElementInfo.GetMemberValue(objectToSet);
                                                if (childObjectToSet == null)
                                                {
                                                    childObjectToSet = Activator.CreateInstance(sameTableElementInfo.MemberType);
                                                }
                                                objectToSet = childObjectToSet;
                                            }
                                        }
                                        DebugUtils.AssertDebuggerBreak(pair.Value != null);
                                        childRelation.SetMemberValue(objectToSet, pair.Value);
                                        anyInstanceFieldsWereSetMap[objectToSet] = true;
                                    }
                                }
                            }
                            else // One to one
                            {
                                Dictionary<object, IList> fkMap =
                                    LoadObjectInstancesToList(childRelation.ValueType, elementTable, pkToObjectMap, appendSelectWhereClauseMap, cachedValues,
                                                              mappingContext, command);
                                if (fkMap != null)
                                {
                                    foreach (KeyValuePair<object, IList> pair in fkMap)
                                    {
                                        if (pair.Value.Count != 1)
                                        {
                                            throw new InvalidOperationException(string.Format("Relation is One-To-One but got more than one element: {0}",
                                                                                              childRelation.ToString()));
                                        }
                                        object itemToSet = CollectionUtils.FirstItem(pair.Value);
                                        DebugUtils.AssertDebuggerBreak(itemToSet != null);
                                        object objectToSet = pkToObjectMap[pair.Key];
                                        if (childRelation.ParentToMemberChain != null)
                                        {
                                            foreach (SameTableElementInfo sameTableElementInfo in childRelation.ParentToMemberChain)
                                            {
                                                object childObjectToSet = sameTableElementInfo.GetMemberValue(objectToSet);
                                                if (childObjectToSet == null)
                                                {
                                                    childObjectToSet = Activator.CreateInstance(sameTableElementInfo.MemberType);
                                                }
                                                objectToSet = childObjectToSet;
                                            }
                                        }
                                        childRelation.SetMemberValue(objectToSet, itemToSet);
                                        anyInstanceFieldsWereSetMap[objectToSet] = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
#if REMOVE_EMPTY_OBJECTS
                        if (list != null)
                        {
                            List<string> removeKeys = new List<string>();
                            foreach (KeyValuePair<string, IList> pair in list)
                            {
                                if (pair.Value != null)
                                {
                                    for (int i = pair.Value.Count - 1; i >= 0; --i)
                                    {
                                        object checkObject = pair.Value[i];
                                        if (!anyInstanceFieldsWereSetMap[checkObject])
                                        {
                                            pair.Value.RemoveAt(i);
                                        }
                                    }
                                }
                                if (CollectionUtils.IsNullOrEmpty(pair.Value))
                                {
                                    removeKeys.Add(pair.Key);
                                }
                            }
                            foreach (string removeKey in removeKeys)
                            {
                                list.Remove(removeKey);
                            }
                        }
#endif // REMOVE_EMPTY_OBJECTS

            return CollectionUtils.IsNullOrEmpty(list) ? null : list;
        }
        protected virtual void LoadSameTableInstances(object objectToSet, ICollection<SameTableElementInfo> sameTableElements,
                                                      ColumnCachedValues cachedValues, IDataReader reader,
                                                      ref int readerIndex, ref bool anyObjectToSetFieldsWereSet)
        {
            if (sameTableElements != null)
            {
                foreach (SameTableElementInfo sameTableElementInfo in sameTableElements)
                {
                    object sameTableElementObjectToSet = null;
                    foreach (Column column in sameTableElementInfo.DirectColumns)
                    {
                        if (!column.NoLoad)
                        {
                            object value = reader.GetValue(readerIndex++);

                            if (value == DBNull.Value)
                            {
                                value = null;
                            }

                            if (value != null)
                            {
                                if (sameTableElementObjectToSet == null)
                                {
                                    sameTableElementObjectToSet = Activator.CreateInstance(sameTableElementInfo.MemberType);
                                }
                                column.SetSelectColumnValue(sameTableElementObjectToSet, value, cachedValues);
                            }
                        }
                    }
                    if (sameTableElementObjectToSet != null)
                    {
                        sameTableElementInfo.SetMemberValue(objectToSet, sameTableElementObjectToSet);
                        anyObjectToSetFieldsWereSet = true;
                    }

                    LoadSameTableInstances(objectToSet, sameTableElementInfo.ChildSameTableElements,
                                           cachedValues, reader, ref readerIndex, ref anyObjectToSetFieldsWereSet);
                }
            }
        }


        protected virtual void AppendSelectWhereClause(string tableName, IDbCommand command,
                                                       IDictionary<string, DbAppendSelectWhereClause> appendSelectWhereClauseMap)
        {
            if (appendSelectWhereClauseMap != null)
            {
                DbAppendSelectWhereClause appendSelectWhereClause;
                if (appendSelectWhereClauseMap.TryGetValue(tableName, out appendSelectWhereClause))
                {
                    if (string.IsNullOrEmpty(appendSelectWhereClause.SelectWhereQuery))
                    {
                        throw new ArgumentException(string.Format("appendSelectWhereClause.SelectWhereQuery is empty for object path: {0}",
                                                                  tableName));
                    }
                    command.CommandText += " WHERE " + appendSelectWhereClause.SelectWhereQuery;
                    CollectionUtils.ForEach(appendSelectWhereClause.SelectWhereParameters,
                                            delegate(IDataParameter parameter)
                                            {
                                                command.Parameters.Add(parameter);
                                            });
                }
            }
        }
    }
}
