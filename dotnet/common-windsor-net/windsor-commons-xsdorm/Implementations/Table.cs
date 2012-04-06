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
    public class Table
    {
        public Table(string tableName, Type tableRootType)
        {
            m_TableName = tableName;
            m_TableRootType = tableRootType;
        }

        public override string ToString()
        {
            return ReflectionUtils.GetPublicPropertiesString(this);
        }
        public string TableName
        {
            get
            {
                return m_TableName;
            }
            set
            {
                m_TableName = value;
            }
        }
        public string TableNamePrefix
        {
            get
            {
                return m_TableNamePrefix;
            }
            set
            {
                m_TableNamePrefix = value;
            }
        }
        public Type TableRootType
        {
            get
            {
                return m_TableRootType;
            }
            set
            {
                m_TableRootType = value;
            }
        }
        public string TableAliasName
        {
            get
            {
                return m_TableAliasName;
            }
            set
            {
                m_TableAliasName = value;
            }
        }
        public ICollection<Column> Columns
        {
            get
            {
                List<Column> rtnList = new List<Column>(m_PrimaryKeyColumns.Count +
                                                        m_ForeignKeyColumns.Count +
                                                        m_OtherColumns.Count);
                foreach (Column column in m_PrimaryKeyColumns)
                    rtnList.Add(column);
                foreach (Column column in m_ForeignKeyColumns)
                    rtnList.Add(column);
                foreach (Column column in m_OtherColumns)
                    rtnList.Add(column);
                return rtnList;
            }
        }
        public ICollection<PrimaryKeyColumn> PrimaryKeys
        {
            get
            {
                return m_PrimaryKeyColumns;
            }
        }
        public ICollection<ForeignKeyColumn> ForeignKeys
        {
            get
            {
                return m_ForeignKeyColumns;
            }
        }
        public IList<Column> DataColumns
        {
            get
            {
                return m_OtherColumns;
            }
        }
        public ICollection<Relation> Relations
        {
            get
            {
                return m_AllRelations;
            }
        }
        public PrimaryKeyColumn GetSinglePrimaryKey()
        {
            if (m_PrimaryKeyColumns.Count == 0)
            {
                throw new MappingException("The table \"{0}\" doesn't have any primary keys", TableName);
            }
            else if (m_PrimaryKeyColumns.Count > 1)
            {
                throw new MappingException("The table \"{0}\" has more than one primary key", TableName);
            }
            return m_PrimaryKeyColumns[0];
        }
        public Column AddColumn(MemberInfo member, string memberPath,
                                MemberInfo isSpecifiedMember,
                                ColumnAttribute columnAttribute, 
                                bool validateUniqueColumnName)
        {
            if (validateUniqueColumnName && ContainsColumn(columnAttribute.ColumnName))
            {
                throw new MappingException("This table already contains a column with the same name: \"{0}\"",
                                           columnAttribute.ColumnName);
            }
            Column column;
            if (columnAttribute is PrimaryKeyAttribute)
            {
                PrimaryKeyColumn primaryKeyColumn;
                if (columnAttribute is GuidPrimaryKeyAttribute)
                {
                    primaryKeyColumn =
                        new GuidPrimaryKeyColumn(this, member, memberPath, (PrimaryKeyAttribute)columnAttribute);
                }
                else if (columnAttribute is UserPrimaryKeyAttribute)
                {
                    primaryKeyColumn =
                        new UserPrimaryKeyColumn(this, member, memberPath, (PrimaryKeyAttribute)columnAttribute);
                }
                else
                {
                    throw new ArgumentException(string.Format("columnAttribute on table \"{0}\" is unrecognized: \"{1}\"",
                                                              this.TableName, columnAttribute.ToString()));
                }
                CollectionUtils.Add(primaryKeyColumn, ref m_PrimaryKeyColumns);
                column = primaryKeyColumn;
            }
            else if (columnAttribute is ForeignKeyAttribute)
            {
                ForeignKeyColumn foreignKeyColumn =
                    new ForeignKeyColumn(this, member, memberPath, (ForeignKeyAttribute)columnAttribute);
                CollectionUtils.Add(foreignKeyColumn, ref m_ForeignKeyColumns);
                column = foreignKeyColumn;
            }
            else
            {
                column = new Column(this, member, memberPath, isSpecifiedMember, columnAttribute);
                CollectionUtils.Add(column, ref m_OtherColumns);
            }
            return column;
        }
        public void AddColumn(Column column)
        {
            if (ContainsColumn(column.ColumnName))
            {
                throw new MappingException("This table already contains a column with the same name: \"{0}\"",
                                           column.ColumnName);
            }
            if (column.IsPrimaryKey)
            {
                PrimaryKeyColumn primaryKeyColumn = (PrimaryKeyColumn)column;
                CollectionUtils.Add(primaryKeyColumn, ref m_PrimaryKeyColumns);
            }
            else if (column.IsForeignKey)
            {
                ForeignKeyColumn foreignKeyColumn = (ForeignKeyColumn)column;
                CollectionUtils.Add(foreignKeyColumn, ref m_ForeignKeyColumns);
            }
            else
            {
                CollectionUtils.Add(column, ref m_OtherColumns);
            }
            column.Table = this;
        }
        public bool TryGetColumn(string columnName, out Column column)
        {
            column = null;
            foreach (Column testColumn in m_PrimaryKeyColumns)
            {
                if (testColumn.ColumnName == columnName)
                {
                    column = testColumn;
                    return true;
                }
            }
            foreach (Column testColumn in m_ForeignKeyColumns)
            {
                if (testColumn.ColumnName == columnName)
                {
                    column = testColumn;
                    return true;
                }
            }
            foreach (Column testColumn in m_OtherColumns)
            {
                if (testColumn.ColumnName == columnName)
                {
                    column = testColumn;
                    return true;
                }
            }
            return false;
        }
        public bool TryGetForeignKeyColumn(string foreignTableName, out Column column)
        {
            column = null;
            foreach (ForeignKeyColumn testColumn in m_ForeignKeyColumns)
            {
                if (testColumn.ForeignTableName == foreignTableName)
                {
                    if (column == null)
                    {
                        column = testColumn;
                    }
                    else
                    {
                        return false;   // Cannot be more than one column that references the foreign table
                    }
                }
            }
            return (column != null);
        }
        public bool ContainsColumn(string columnName)
        {
            Column column;
            return TryGetColumn(columnName, out column);
        }
        public bool TryGetRelation(string columnName, out Relation relation)
        {
            foreach (Relation curRelation in m_AllRelations)
            {
                if (curRelation.ParentColumnName == columnName)
                {
                    relation = curRelation;
                    return true;
                }
            }
            relation = null;
            return false;
        }
        public Relation AddRelation(Table childTable, MemberInfo member, string memberPath,
                                    Type memberValueType, RelationAttribute relationAttribute)
        {
            Relation relation;
            if (relationAttribute is OneToManyAttribute)
            {
                OneToManyRelation oneToManyRelation =
                    new OneToManyRelation(this, childTable, member, memberPath, memberValueType,
                                          (OneToManyAttribute)relationAttribute);
                CollectionUtils.Add(oneToManyRelation, ref m_OneToManyRelations);
                relation = oneToManyRelation;
            }
            else if (relationAttribute is OneToOneAttribute)
            {
                OneToOneRelation oneToOneRelation =
                    new OneToOneRelation(this, childTable, member, memberPath, memberValueType,
                                         (OneToOneAttribute)relationAttribute);
                CollectionUtils.Add(oneToOneRelation, ref m_OneToOneRelations);
                relation = oneToOneRelation;
            }
            else if (relationAttribute is ManyToManyAttribute)
            {
                ManyToManyRelation manyToManyRelation =
                    new ManyToManyRelation(this, childTable, member, memberPath, memberValueType,
                                           (ManyToManyAttribute)relationAttribute);
                CollectionUtils.Add(manyToManyRelation, ref m_ManyToManyRelations);
                relation = manyToManyRelation;
            }
            else
            {
                throw new ArgumentException(string.Format("Unreconized RelationAttribute: {0}", relationAttribute.ToString()));
            }
            CollectionUtils.Add(relation, ref m_AllRelations);
            return relation;
        }
        public void SetCachedValue(object primaryKey, object secondaryKey, object value)
        {
            m_Cache[primaryKey.GetHashCode()] = new KeyValuePair<int, object>(secondaryKey.GetHashCode(), value);
        }
        public bool GetCachedValue(object primaryKey, object secondaryKey, out object value)
        {
            value = null;
            KeyValuePair<int, object> pair;
            if (m_Cache.TryGetValue(primaryKey.GetHashCode(), out pair))
            {
                if (pair.Key == secondaryKey.GetHashCode())
                {
                    value = pair.Value;
                    return true;
                }
            }
            return false;
        }
        private string m_TableName;
        private string m_TableAliasName;
        private string m_TableNamePrefix;
        private Type m_TableRootType;
        private List<PrimaryKeyColumn> m_PrimaryKeyColumns = new List<PrimaryKeyColumn>();
        private List<ForeignKeyColumn> m_ForeignKeyColumns = new List<ForeignKeyColumn>();
        private List<Column> m_OtherColumns = new List<Column>();
        private List<Relation> m_AllRelations = new List<Relation>();
        private List<OneToManyRelation> m_OneToManyRelations = new List<OneToManyRelation>();
        private List<OneToOneRelation> m_OneToOneRelations = new List<OneToOneRelation>();
        private List<ManyToManyRelation> m_ManyToManyRelations = new List<ManyToManyRelation>();
        private Dictionary<int, KeyValuePair<int, object>> m_Cache = new Dictionary<int, KeyValuePair<int, object>>();
    }
}
