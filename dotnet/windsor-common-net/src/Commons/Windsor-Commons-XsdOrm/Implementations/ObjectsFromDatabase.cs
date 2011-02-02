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

#define DICT_LOAD
//#define REMOVE_EMPTY_OBJECTS
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
    public class ObjectsFromDatabase : ObjectsDatabaseBase, IObjectsFromDatabase
    {
        public new void Init()
        {
            base.Init();
        }

        public string GetTableNameForType(Type objectType)
        {
            MappingContext mappingContext = MappingContext.GetMappingContext(objectType);

            return mappingContext.GetTableNameForType(objectType);
        }
        public string GetPrimaryKeyNameForType(Type objectType)
        {
            MappingContext mappingContext = MappingContext.GetMappingContext(objectType);

            return mappingContext.GetPrimaryKeyNameForType(objectType);
        }
        public virtual List<T> LoadFromDatabase<T>(SpringBaseDao baseDao,
                                                   IDictionary<string, DbAppendSelectWhereClause> appendSelectWhereClauses)
        {
            IList objList = LoadFromDatabase(typeof(T), baseDao, appendSelectWhereClauses);
            return CollectionUtils.ToList<T>(objList);
        }
        public virtual IList LoadFromDatabase(Type typeToLoad, SpringBaseDao baseDao,
                                              IDictionary<string, DbAppendSelectWhereClause> appendSelectWhereClauses)
        {
            MappingContext mappingContext = MappingContext.GetMappingContext(typeToLoad);

            BuildObjectSql(mappingContext.ObjectPaths, baseDao);

            string objectPath = typeToLoad.FullName;

            IList rtnList = null;

            baseDao.AdoTemplate.ClassicAdoTemplate.Execute(delegate(IDbCommand command)
            {
                IList list =
                    LoadFromDatabase(typeToLoad, objectPath, appendSelectWhereClauses, 
                                     mappingContext, command);
                if (list != null)
                {
                    rtnList = list;
                    foreach (object obj in rtnList)
                    {
                        IAfterLoadFromDatabase afterLoadFromDatabase = obj as IAfterLoadFromDatabase;
                        if (afterLoadFromDatabase != null)
                        {
                            afterLoadFromDatabase.AfterLoadFromDatabase();
                        }
                    }

                }
                return null;
            });
            return rtnList;
        }
#if DICT_LOAD
        protected virtual IList LoadFromDatabase(Type objectType, string objectPath,
                                                 IDictionary<string, DbAppendSelectWhereClause> appendSelectWhereClauseMap,
                                                 MappingContext mappingContext, IDbCommand command)
        {
            ObjectPath objectPathInstance;
            if (!mappingContext.ObjectPaths.TryGetValue(objectPath, out objectPathInstance))
            {
                throw new InvalidOperationException(string.Format("Could not locate object path instance \"{0}\"",
                                                                  objectPath));
            }
            Dictionary<string, IList> list = null;
            if (!string.IsNullOrEmpty(objectPathInstance.SelectSql))
            {
                command.CommandText = objectPathInstance.SelectSql;
                command.CommandType = CommandType.Text;
                command.Parameters.Clear();

                AppendSelectWhereClause(objectPathInstance.TableInfo.TableName, command, appendSelectWhereClauseMap);

                list = LoadObjectInstancesToList(objectType, objectPath, objectPathInstance, null,
                                                 appendSelectWhereClauseMap, mappingContext, command);
            }
            if (list != null)
            {
                IList rtnList = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(objectType));
                foreach (KeyValuePair<string, IList> pair in list)
                {
                    foreach (object listElement in pair.Value)
                    {
                        rtnList.Add(listElement);
                    }
                }
                return rtnList;
            }
            else
            {
                return null;
            }
        }

        protected virtual Dictionary<string, IList> LoadFromDatabase(Type objectType, string objectPath,
                                                                     Dictionary<string, object> pkMap, Relation parentRelation,
                                                                     IDictionary<string, DbAppendSelectWhereClause> appendSelectWhereClauseMap,
                                                                     MappingContext mappingContext, IDbCommand command)
        {
            ObjectPath objectPathInstance;
            if (!mappingContext.ObjectPaths.TryGetValue(objectPath, out objectPathInstance))
            {
                throw new InvalidOperationException(string.Format("Could not locate object path instance \"{0}\"",
                                                                  objectPath));
            }
            Dictionary<string, IList> list = null;
            if (!string.IsNullOrEmpty(objectPathInstance.SelectSql))
            {
                command.CommandText = objectPathInstance.SelectSql;
                command.CommandType = CommandType.Text;
                command.Parameters.Clear();

                AppendSelectWhereClause(objectPathInstance.TableInfo.TableName, command, appendSelectWhereClauseMap);

                list = LoadObjectInstancesToList(objectType, objectPath, objectPathInstance, pkMap, 
                                                 appendSelectWhereClauseMap, mappingContext, command);
            }
            return list;
        }
        protected virtual Dictionary<string, IList> LoadObjectInstancesToList(Type objectType, string objectPath,
                                                                              ObjectPath objectPathInstance,
                                                                              Dictionary<string, object> pkParentMap,
                                                                              IDictionary<string, DbAppendSelectWhereClause> appendSelectWhereClauseMap,
                                                                              MappingContext mappingContext, IDbCommand command)
        {
            Dictionary<string, IList> list = null;
            Dictionary<string, object> pkMap = null;
            Dictionary<object, bool> anyInstanceFieldsWereSetMap = null;
            using (IDataReader reader = command.ExecuteReader())
            {
            
                object objectToSet = null;
                while (reader.Read())
                {
                    ObjectTableInfo tableInfo = objectPathInstance.TableInfo;
                    if (tableInfo != null)
                    {
                        if (objectToSet == null)
                        {
                            objectToSet = Activator.CreateInstance(objectType);
                        }
                        int i = 0;
                        string pk = null, fk = null;
                        bool skip = false;
                        bool anyInstanceFieldsWereSet = false;
                        foreach (Column column in tableInfo.Columns)
                        {
                            if (!column.NoLoad)
                            {
                                object value = reader.GetValue(i++);
                                column.SetMemberValue(objectToSet, value);
                                if (column.IsPrimaryKey)
                                {
                                    pk = value.ToString();
                                }
                                else if (column.IsForeignKey)
                                {
                                    fk = value.ToString();
                                    if ((pkParentMap != null) && !pkParentMap.ContainsKey(fk))
                                    {
                                        skip = true;
                                        break;
                                    }
                                }
                                else
                                {
                                    if ((value != null) && !(value is DBNull))
                                    {
                                        anyInstanceFieldsWereSet = true;
                                    }
                                }
                            }
                        }
                        if (skip) continue;
                        if (i != reader.FieldCount)
                        {
                            throw new IndexOutOfRangeException(string.Format("The number of selected column values ({0}) is less than the expected number ({1}) for the object \"{2}\" and sql \"{3}\".",
                                                                             reader.FieldCount.ToString(), i.ToString(),
                                                                             objectPath, objectPathInstance.SelectSql));
                        }
                        if (fk == null)
                        {
                            // Object does not have fk, so set fk to pk
                            fk = pk;
                        }
                        if (list == null)
                        {
                            list = new Dictionary<string, IList>();
                        }
                        IList listInstance;
                        if (!list.TryGetValue(fk, out listInstance))
                        {
                            listInstance = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(objectType));
                            list.Add(fk, listInstance);
                        }
                        if (pkMap == null)
                        {
                            pkMap = new Dictionary<string, object>();
                        }
                        if (anyInstanceFieldsWereSetMap == null)
                        {
                            anyInstanceFieldsWereSetMap = new Dictionary<object, bool>();
                        }
                        listInstance.Add(objectToSet);
                        pkMap.Add(pk, objectToSet);
                        anyInstanceFieldsWereSetMap.Add(objectToSet, anyInstanceFieldsWereSet);
                        objectToSet = null;
                    }
                }
            }
            if (list != null)
            {
                // Load children
                foreach (Relation relation in objectPathInstance.Relations)
                {
                    if (relation is OneToManyRelation)
                    {
                        Dictionary<string, IList> elementsMap =
                            LoadFromDatabase(relation.MemberValueType, relation.MemberInfoPath, pkMap,
                                             relation, appendSelectWhereClauseMap, mappingContext, command);
                        if (elementsMap != null)
                        {
                            foreach (KeyValuePair<string, IList> pair in elementsMap)
                            {
                                object objectToSet = pkMap[pair.Key];
                                relation.SetMemberValue(objectToSet, pair.Value);
                                if (!CollectionUtils.IsNullOrEmpty(pair.Value))
                                {
                                    anyInstanceFieldsWereSetMap[objectToSet] = true;
                                }
                            }
                        }
                    }
                    else if (relation is OneToOneRelation)
                    {
                        Dictionary<string, IList> elementsMap =
                            LoadFromDatabase(relation.MemberValueType, relation.MemberInfoPath, pkMap,
                                             relation, appendSelectWhereClauseMap, mappingContext, command);
                        if (elementsMap != null)
                        {
                            foreach (KeyValuePair<string, IList> pair in elementsMap)
                            {
                                if (pair.Value.Count != 1)
                                {
                                    throw new InvalidOperationException(string.Format("Relation is One-To-One but got more than one element: {0}",
                                                                                      relation.ToString()));
                                }
                                object itemToSet = CollectionUtils.FirstItem(pair.Value);
                                object objectToSet = pkMap[pair.Key];
                                relation.SetMemberValue(objectToSet, itemToSet);
                                if (itemToSet != null)
                                {
                                    anyInstanceFieldsWereSetMap[objectToSet] = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        throw new NotImplementedException(string.Format("Relationship not implemented: {0}",
                                                                        relation.ToString()));
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
#else // DICT_LOAD
        protected virtual IList LoadFromDatabase(Type objectType, string objectPath,
                                                 IDictionary<string, DbAppendSelectWhereClause> appendSelectWhereClauseMap,
                                                 MappingContext mappingContext, IDbCommand command)
        {
            ObjectPath objectPathInstance;
            if (!mappingContext.ObjectPaths.TryGetValue(objectPath, out objectPathInstance))
            {
                throw new InvalidOperationException(string.Format("Could not locate object path instance \"{0}\"",
                                                                  objectPath));
            }
            IList list = null;
            if (!string.IsNullOrEmpty(objectPathInstance.SelectSql))
            {
                command.CommandText = objectPathInstance.SelectSql;
                command.CommandType = CommandType.Text;
                command.Parameters.Clear();

                AppendSelectWhereClause(objectPath, command, appendSelectWhereClauseMap);

                list = LoadObjectInstancesToList(objectType, objectPath, objectPathInstance,
                                                 appendSelectWhereClauseMap, mappingContext, command);
            }
            return list;
        }
        protected virtual IList LoadFromDatabase(Type objectType, string objectPath,
                                                 object objectParent, Relation parentRelation,
                                                 IDictionary<string, DbAppendSelectWhereClause> appendSelectWhereClauseMap,
                                                 MappingContext mappingContext, IDbCommand command)
        {
            ObjectPath objectPathInstance;
            if (!mappingContext.ObjectPaths.TryGetValue(objectPath, out objectPathInstance))
            {
                throw new InvalidOperationException(string.Format("Could not locate object path instance \"{0}\"",
                                                                  objectPath));
            }
            IList list = null;
            if (!string.IsNullOrEmpty(objectPathInstance.SelectSql))
            {
                command.CommandText = objectPathInstance.SelectSql;
                command.CommandText += GetSelectWhereSql(objectPathInstance, objectParent, parentRelation);
                command.CommandType = CommandType.Text;
                command.Parameters.Clear();

                AppendSelectWhereClause(objectPath, command, appendSelectWhereClauseMap);

                list = LoadObjectInstancesToList(objectType, objectPath, objectPathInstance,
                                                 appendSelectWhereClauseMap, mappingContext, command);
            }
            return list;
        }
        protected virtual IList LoadObjectInstancesToList(Type objectType, string objectPath,
                                                          ObjectPath objectPathInstance,
                                                          IDictionary<string, DbAppendSelectWhereClause> appendSelectWhereClauseMap,
                                                          MappingContext mappingContext, IDbCommand command)
        {
            IList list = null;
            using (IDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    ObjectTableInfo tableInfo = objectPathInstance.TableInfo;
                    if (tableInfo != null)
                    {
                        if (tableInfo.Columns.Count > reader.FieldCount)
                        {
                            throw new IndexOutOfRangeException(string.Format("The number of selected column values ({0}) is less than the expected number ({1}) for the object \"{2}\" and sql \"{3}\".",
                                                                             reader.FieldCount.ToString(), tableInfo.Columns.Count.ToString(),
                                                                             objectPath, objectPathInstance.SelectSql));
                        }
                        object objectToSet = Activator.CreateInstance(objectType);
                        int i = 0;
                        foreach (Column column in tableInfo.Columns)
                        {
                            column.SetMemberValue(objectToSet, reader.GetValue(i++));
                        }
                        if (list == null)
                        {
                            list = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(objectType));
                        }
                        list.Add(objectToSet);
                    }
                }
            }
            if (list != null)
            {
                int elementCount = 0;
                foreach (object parent in list)
                {
                    // Load children
                    foreach (Relation relation in objectPathInstance.Relations)
                    {
                        if (relation is OneToManyRelation)
                        {
                            string elementTypePath =
                                Utils.CombineTypePath(objectPath, relation.MemberInfo.Name);
                            IList elements =
                                LoadFromDatabase(relation.MemberValueType, elementTypePath, parent,
                                                 relation, appendSelectWhereClauseMap, mappingContext, command);
                            if (elements != null)
                            {
                                relation.SetMemberValue(parent, elements);
                            }
                        }
                        else if (relation is OneToOneRelation)
                        {
                            string elementTypePath =
                               Utils.CombineTypePath(objectPath, relation.MemberInfo.Name);
                            IList elements =
                                LoadFromDatabase(relation.MemberValueType, elementTypePath, parent,
                                                 relation, appendSelectWhereClauseMap, mappingContext, command);
                            if (elements != null)
                            {
                                if (elements.Count != 1)
                                {
                                    throw new InvalidOperationException(string.Format("Relation is One-To-One but got more than one element: {0}",
                                                                                      relation.ToString()));
                                }
                                relation.SetMemberValue(parent, elements[0]);
                            }
                        }
                        else
                        {
                            throw new NotImplementedException(string.Format("Relationship not implemented: {0}",
                                                                            relation.ToString()));
                        }
                    }
                    ++elementCount;
                }
            }
            return list;
        }
#endif // DICT_LOAD
        protected string GetSelectWhereSql(ObjectPath objectPathInstance, object objectParent,
                                           Relation parentRelation)
        {
            if ((objectParent != null) && (parentRelation != null))
            {
                if (objectPathInstance.TableInfo.TableName != parentRelation.ChildTable.TableName)
                {
                    throw new InvalidOperationException(string.Format("Table names do not match (\"{0}\" vs. \"{1})\"",
                                                                      objectPathInstance.TableInfo.TableName,
                                                                      parentRelation.ChildTable.TableName));
                }
                ExceptionUtils.ThrowIfNull(parentRelation.ChildForeignKeyColumn, "parentRelation.ChildForeignKeyColumn");
                ExceptionUtils.ThrowIfNull(parentRelation.ParentColumn, "parentRelation.ParentColumn");
                object foreignKeyValue = parentRelation.ParentColumn.GetMemberValue(objectParent);
                return string.Format(" WHERE {0} = '{1}'", parentRelation.ChildForeignKeyColumnName,
                                     foreignKeyValue.ToString());
            }
            return string.Empty;
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
