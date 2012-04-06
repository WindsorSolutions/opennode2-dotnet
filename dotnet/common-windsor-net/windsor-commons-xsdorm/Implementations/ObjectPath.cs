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
using System.Reflection;
using System.Data;
using System.Xml.Serialization;
using System.ComponentModel;
using Windsor.Commons.Core;

namespace Windsor.Commons.XsdOrm.Implementations
{
    public class ObjectPath
    {
        public ObjectPath(string classPath)
        {
            m_ObjectPath = classPath;
        }

        public string Path
        {
            get { return m_ObjectPath; }
            set { m_ObjectPath = value; }
        }
        public ObjectTableInfo TableInfo
        {
            get { return m_TableInfo; }
        }
        public ICollection<Relation> Relations
        {
            get { return m_Relations.Values; }
        }
        public string InsertSql
        {
            get { return m_InsertSql; }
            set { m_InsertSql = value; }
        }
        public string SelectSql
        {
            get { return m_SelectSql; }
            set { m_SelectSql = value; }
        }
        public void AddColumn(Column column)
        {
            ExceptionUtils.ThrowIfNull(column, "column");
            ExceptionUtils.ThrowIfNull(column.Table, "column.Table");

            string tableName = string.IsNullOrEmpty(column.Table.TableAliasName) ?
                column.Table.TableName : column.Table.TableAliasName;

            ExceptionUtils.ThrowIfEmptyString(tableName, "tableName");

            if (m_TableInfo == null)
            {
                m_TableInfo = new ObjectTableInfo(tableName);
            }
            else if (m_TableInfo.TableName != tableName)
            {
                throw new MappingException("The class \"{0}\" has more than one table mapped to it (\"{1}\" and \"{2}\").  This is not allowed in this version.",
                                           m_ObjectPath, m_TableInfo.TableName, tableName);
            }
            m_TableInfo.AddColumn(column);
        }
        public bool ContainsRelation(Relation relation)
        {
            return m_Relations.ContainsKey(relation.MemberInfoPath);
        }
        public void AddRelation(Relation relation)
        {
            ExceptionUtils.ThrowIfNull(relation, "relation");
            ExceptionUtils.ThrowIfEmptyString(relation.MemberInfoPath, "relation.MemberInfoPath");

            if (!ContainsRelation(relation))
            {
                m_Relations.Add(relation.MemberInfoPath, relation);
            }
        }
        public void OrderRelationsByInsertOrder()
        {
            bool needToSort = false;
            CollectionUtils.ForEachBreak(m_Relations.Values, delegate(Relation relation)
            {
                if (relation.DatabaseInsertOrder != Relation.InvalidDatabaseInsertOrder)
                {
                    needToSort = true;
                    return false;
                }
                return true;
            });
            if (needToSort)
            {
                List<KeyValuePair<string, Relation>> sortList = new List<KeyValuePair<string, Relation>>(m_Relations);
                sortList.Sort(delegate(KeyValuePair<string, Relation> relation1, KeyValuePair<string, Relation> relation2)
                {
                    return relation1.Value.DatabaseInsertOrder - relation2.Value.DatabaseInsertOrder;
                });
                m_Relations.Clear();
                m_Relations.AddRange(sortList);
            }
        }
        public override string ToString()
        {
            return ReflectionUtils.GetPublicPropertiesString(this);
        }
        private string m_ObjectPath;
        private string m_InsertSql;
        private string m_SelectSql;
        private ObjectTableInfo m_TableInfo = null;
        private LinkedDictionary<string, Relation> m_Relations = new LinkedDictionary<string, Relation>();
    }
}
