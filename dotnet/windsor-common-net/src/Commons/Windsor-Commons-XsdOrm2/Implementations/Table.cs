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
using Windsor.Commons.Spring;

namespace Windsor.Commons.XsdOrm2.Implementations
{
    public class Table
    {
        public Table(string tableName, Type tableRootType)
        {
            ExceptionUtils.ThrowIfEmptyString(tableName, "tableName");
            ExceptionUtils.ThrowIfNull(tableRootType, "tableRootType");
            m_TableName = tableName;
            m_TableRootType = tableRootType;
            m_PrimaryKeyColumn = new GuidPrimaryKeyColumn(this);
        }

        public override string ToString()
        {
            string fks = "None";
            if (!CollectionUtils.IsNullOrEmpty(ForeignKeys))
            {
                List<string> strings = new List<string>(ForeignKeys.Count);
                foreach (ForeignKeyColumn column in ForeignKeys)
                {
                    strings.Add(column.ForeignTable.TableName);
                }
                fks = StringUtils.Join(",", strings);
            }
            return string.Format("{0}, {1}, FKs: {2}", m_TableName, m_TableRootType.Name, fks);
        }
        public string TableName
        {
            get
            {
                return m_TableName;
            }
            set
            {
                ExceptionUtils.ThrowIfEmptyString(value, "tableName");
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
        public bool IsVirtualTable
        {
            get
            {
                return Utils.IsValidColumnType(TableRootType);
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
        public bool FinishedFirstPassMapping
        {
            get;
            set;
        }
        public string SelectSql
        {
            get;
            set;
        }
        public string InsertSql
        {
            get;
            set;
        }
        public ICollection<ChildRelationInfo> ChildRelationMembers
        {
            get;
            set;
        }
        public ICollection<SameTableElementInfo> ChildSameTableElements
        {
            get
            {
                return m_ChildSameTableElements;
            }
            set
            {
                m_ChildSameTableElements = value;
                m_AllColumns = m_DirectColumns = null;
            }
        }
        public ICollection<Column> AllColumns
        {
            get
            {
                if (m_AllColumns == null)
                {
                    m_AllColumns = new List<Column>(DirectColumns);

                    if (m_ChildSameTableElements != null)
                    {
                        foreach (SameTableElementInfo sameTableElementInfo in m_ChildSameTableElements)
                        {
                            m_AllColumns.AddRange(sameTableElementInfo.AllColumns);
                        }
                    }
                }
                return m_AllColumns;
            }
        }
        public ICollection<Column> DirectColumns
        {
            get
            {
                if (m_DirectColumns == null)
                {
                    m_DirectColumns = new List<Column>(1 + m_ForeignKeyColumns.Count + m_DataColumns.Count);
                    m_DirectColumns.Add(m_PrimaryKeyColumn);
                    foreach (Column column in m_ForeignKeyColumns)
                    {
                        m_DirectColumns.Add(column);
                    }
                    foreach (Column column in m_DataColumns)
                    {
                        m_DirectColumns.Add(column);
                    }
                }
                return m_DirectColumns;
            }
        }
        public bool TryGetColumn(string columnName, out Column column)
        {
            foreach (Column checkColumn in AllColumns)
            {
                if (string.Equals(columnName, checkColumn.ColumnName, StringComparison.OrdinalIgnoreCase))
                {
                    column = checkColumn;
                    return true;
                }
            }
            column = null;
            return false;
        }
        public virtual void BuildObjectSql(SpringBaseDao baseDao)
        {
            List<string> columnNames = new List<string>(AllColumns.Count);
            List<string> columnParamNames = new List<string>(AllColumns.Count);

            foreach (Column column in AllColumns)
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
                InsertSql = string.Format("INSERT INTO {0} ({1}) VALUES ({2})",
                                                    TableName, columnNameStr,
                                                    columnParamNamesStr);
                SelectSql = string.Format("SELECT {0} FROM {1}", columnNameStr, TableName);
            }
            else
            {
                InsertSql = null;
                SelectSql = null;
            }
        }
        public virtual bool PopulateInsertValues(IDbCommand command, object parentOfObjectToSave, Table parentTableOfObjectToSave,
                                                 object objectToSave, ColumnCachedValues cachedValues)
        {
            bool anyPopulated = false;

            if (!string.IsNullOrEmpty(InsertSql))
            {
                command.CommandText = InsertSql;
                command.CommandType = CommandType.Text;
                command.Parameters.Clear();

                if (PopulateInsertValues(command, parentOfObjectToSave, parentTableOfObjectToSave, objectToSave, cachedValues, DirectColumns))
                {
                    anyPopulated = true;
                }
                if (PopulateInsertValues(command, parentOfObjectToSave, parentTableOfObjectToSave, objectToSave, cachedValues, m_ChildSameTableElements))
                {
                    anyPopulated = true;
                }
            }
            return anyPopulated;
        }
        protected virtual bool PopulateInsertValues(IDbCommand command, object parentOfObjectToSave, Table parentTableOfObjectToSave,
                                                    object objectToSave, ColumnCachedValues cachedValues, 
                                                    ICollection<SameTableElementInfo> sameTableElements)
        {
            bool anyPopulated = false;

            if (sameTableElements != null)
            {
                foreach (SameTableElementInfo sameTableElementInfo in sameTableElements)
                {
                    object objectInstance = sameTableElementInfo.GetMemberValue(objectToSave);

                    if (PopulateInsertValues(command, objectToSave, parentTableOfObjectToSave, objectInstance, cachedValues,
                                             sameTableElementInfo.DirectColumns))
                    {
                        anyPopulated = true;
                    }
                    if (PopulateInsertValues(command, objectToSave, parentTableOfObjectToSave, objectInstance, cachedValues,
                                             sameTableElementInfo.ChildSameTableElements))
                    {
                        anyPopulated = true;
                    }
                }
            }
            return anyPopulated;
        }
        protected virtual bool PopulateInsertValues(IDbCommand command, object parentOfObjectToSave, Table parentTableOfObjectToSave,
                                                    object objectToSave, ColumnCachedValues cachedValues, ICollection<Column> columns)
        {
            bool anyPopulated = false;

            if (columns != null)
            {
                foreach (Column column in columns)
                {
                    if (!column.NoLoad)
                    {
                        IDbDataParameter parameter = command.CreateParameter();
                        parameter.DbType = column.ColumnType.Value;
                        parameter.Direction = ParameterDirection.Input;
                        parameter.Size = column.ColumnSize;
                        parameter.ParameterName = column.ColumnName;
                        if (column.IsForeignKey)
                        {
                            Table foreignTable = ((ForeignKeyColumn)column).ForeignTable;
                            ExceptionUtils.ThrowIfNull(parentTableOfObjectToSave, "parentTableOfObjectToSave");
                            if (foreignTable == parentTableOfObjectToSave)
                            {
                                parameter.Value = column.GetInsertColumnValue(parentOfObjectToSave, objectToSave, cachedValues);
                            }
                            else
                            {
                                parameter.Value = DBNull.Value;
                            }
                        }
                        else
                        {
                            parameter.Value = column.GetInsertColumnValue(parentOfObjectToSave, objectToSave, cachedValues);
                        }
                        command.Parameters.Add(parameter);
                        anyPopulated = true;
                    }
                }
            }
            return anyPopulated;
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
                return m_DataColumns;
            }
        }
        public PrimaryKeyColumn PrimaryKey
        {
            get
            {
                return m_PrimaryKeyColumn;
            }
        }
        public ForeignKeyColumn AddFKTable(Table fkTable)
        {
            ExceptionUtils.ThrowIfTrue(fkTable == this, "fkTable == this");
            foreach (ForeignKeyColumn testFKColumn in m_ForeignKeyColumns)
            {
                if (testFKColumn.ForeignTable == fkTable)
                {
                    return testFKColumn;
                }
            }

            ForeignKeyColumn foreignKeyColumn =
                new ForeignKeyColumn(this, new GuidForeignKeyAttribute());
            foreignKeyColumn.ForeignTable = fkTable;
            CollectionUtils.Add(foreignKeyColumn, ref m_ForeignKeyColumns);
            m_AllColumns = m_DirectColumns = null;
            return foreignKeyColumn;
        }
        public Column AddDataColumn(MemberInfo member, MemberInfo isSpecifiedMember,
                                    ColumnAttribute columnAttribute)
        {
            Column column;
            if (columnAttribute is PrimaryKeyAttribute)
            {
                throw new MappingException("Table already has primary key");
            }
            else if (columnAttribute is ForeignKeyAttribute)
            {
                throw new MappingException("Use AddFKTable() instead");
            }
            else
            {
                column = new Column(this, member, isSpecifiedMember, columnAttribute);
                CollectionUtils.Add(column, ref m_DataColumns);
                m_AllColumns = m_DirectColumns = null;
            }
            return column;
        }
        private string m_TableName;
        private string m_TableNamePrefix;
        private Type m_TableRootType;
        private PrimaryKeyColumn m_PrimaryKeyColumn;
        private List<ForeignKeyColumn> m_ForeignKeyColumns = new List<ForeignKeyColumn>();
        private List<Column> m_DataColumns = new List<Column>();
        private List<Column> m_AllColumns = null;
        private List<Column> m_DirectColumns = null;
        private ICollection<SameTableElementInfo> m_ChildSameTableElements;
    }
}
