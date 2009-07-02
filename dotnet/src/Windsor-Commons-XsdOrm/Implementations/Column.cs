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
    public class Column : MemberInfoWrapper
    {
        public Column(Table table, MemberInfo member, string memberPath,
                      MemberInfo isSpecifiedMember, ColumnAttribute columnAttribute) :
            base(member, memberPath, isSpecifiedMember)
        {
            Init(table, columnAttribute);
        }
        // Virtual column member:
        public Column(Table table, string memberPath, Type memberType, 
                      ColumnAttribute columnAttribute) :
            base(memberPath, memberType)
        {
            Init(table, columnAttribute);
        }
        private void Init(Table table, ColumnAttribute columnAttribute)
        {
            ExceptionUtils.ThrowIfNull(table, "table");
            ExceptionUtils.ThrowIfNull(columnAttribute, "columnAttribute");
            ExceptionUtils.ThrowIfEmptyString(columnAttribute.TableName, "columnAttribute.TableName");
            if (!string.Equals(columnAttribute.TableName, table.TableName, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new ArgumentException(string.Format("table.TableName ({0}) != columnAttribute.TableName ({1})",
                                                          table.TableName, columnAttribute.TableName));
            }

            m_Table = table;
            m_ColumnName = columnAttribute.ColumnName;
            m_ColumnType = columnAttribute.ColumnType;
            m_ColumnSize = columnAttribute.ColumnSize;
            m_IsNullable = columnAttribute.IsNullable;
            m_IsIndexable = columnAttribute.IsIndexable;
            m_IndexName = columnAttribute.IndexName;
            if ((m_ColumnType != null) && Utils.IsStringColumnType(m_ColumnType.Value) && (m_ColumnSize == 1) &&
                (this.MemberType == typeof(bool)))
            {
                m_IsDbBoolString = true;
            }
        }

        public string ColumnName
        {
            get { return m_ColumnName; }
            set { m_ColumnName = value; }
        }
        public DbType? ColumnType
        {
            get { return m_ColumnType; }
            set { m_ColumnType = value; }
        }
        public int ColumnSize
        {
            get { return m_ColumnSize; }
            set { m_ColumnSize = value; }
        }
        public virtual bool IsNullable
        {
            get { return m_IsNullable; }
            set { m_IsNullable = value; }
        }
        public virtual bool IsPrimaryKey
        {
            get { return false; }
        }
        public virtual bool IsForeignKey
        {
            get { return false; }
        }
        public Table Table
        {
            get { return m_Table; }
            set { m_Table = value; }
        }
        public bool IsIndexable
        {
            get { return m_IsIndexable; }
            set { m_IsIndexable = value; }
        }
        public string IndexName
        {
            get { return m_IndexName; }
            set { m_IndexName = value; }
        }
        public string ColumnDescription
        {
            get { return m_ColumnDescription; }
            set { m_ColumnDescription = value; }
        }
        protected override void SetCachedValue(object primaryKey, object secondaryKey, object value)
        {
            m_Table.SetCachedValue(primaryKey, secondaryKey, value);
        }
        protected override bool GetCachedValue(object primaryKey, object secondaryKey, out object value)
        {
            return m_Table.GetCachedValue(primaryKey, secondaryKey, out value);
        }
        public virtual object GetInsertColumnValue<T>(T objectToSave,
                                                      Dictionary<string, object> previousInsertColumnValues)
        {
            object value = GetMemberValue(objectToSave);
            if (value == null)
            {
                if (this.IsNullable)
                {
                    value = DBNull.Value;
                }
                else
                {
                    throw new InvalidOperationException(string.Format("A column.MemberInfo has a null value, but the column is specified as non-null: {0}",
                                                                      this.ToString()));
                }
            }
            else if (m_IsDbBoolString)
            {
                value = ((bool)value) ? "Y" : "N";
            }
            return value;
        }
        public override void SetMemberValue<T>(T instance, object value)
        {
            if (value is DBNull)
            {
                value = null;
            }
            else if (m_IsDbBoolString)
            {
                if (string.Equals(value.ToString(), "N", StringComparison.InvariantCultureIgnoreCase))
                {
                    value = false;
                }
                else if (string.Equals(value.ToString(), "Y", StringComparison.InvariantCultureIgnoreCase))
                {
                    value = true;
                }
                else
                {
                    throw new MappingException("Invalid boolean string valid specified (\"{0}\") for column: {1}",
                                               value, this.ToString());
                }
            }
            base.SetMemberValue<T>(instance, value);
        }
        protected Table m_Table;
        protected string m_ColumnName;
        protected DbType? m_ColumnType;
        protected int m_ColumnSize;
        protected bool m_IsNullable;
        protected bool m_IsIndexable;
        protected string m_IndexName;
        protected string m_ColumnDescription;
        protected bool m_IsDbBoolString;
    }

    public class PrimaryKeyColumn : Column
    {
        public PrimaryKeyColumn(Table table, MemberInfo member, string memberPath,
                                PrimaryKeyAttribute columnAttribute) :
            base(table, member, memberPath, null, columnAttribute) { }
        // Virtual column member:
        public PrimaryKeyColumn(Table table, string memberPath, Type memberType,
                                ColumnAttribute columnAttribute) :
            base(table, memberPath, memberType, columnAttribute) { }

        public override bool IsPrimaryKey
        {
            get { return true; }
        }
        public override bool IsNullable
        {
            get { return m_IsNullable; }
            set
            {
                if (value == true)
                {
                    throw new InvalidOperationException(string.Format("PrimaryKeyColumn.IsNullable cannot be set to true for the column {0}.{1}",
                                                                      Table.TableName, ColumnName));
                }
            }
        }
    }

    public class GuidPrimaryKeyColumn : PrimaryKeyColumn
    {
        public GuidPrimaryKeyColumn(Table table, MemberInfo member, string memberPath,
                                    PrimaryKeyAttribute columnAttribute) :
            base(table, member, memberPath, columnAttribute) { }
        // Virtual column member:
        public GuidPrimaryKeyColumn(Table table, string memberPath,
                                    PrimaryKeyAttribute columnAttribute) :
            base(table, memberPath, typeof(string), columnAttribute) { }

        public override object GetInsertColumnValue<T>(T objectToSave,
                                                       Dictionary<string, object> previousInsertColumnValues)
        {
            object value = GetMemberValue(objectToSave);
            if (value == null)
            {
                value = Guid.NewGuid().ToString();
                SetMemberValue(objectToSave, value);
            }
            return value;
        }
    }

    public class UserPrimaryKeyColumn : PrimaryKeyColumn
    {
        public UserPrimaryKeyColumn(Table table, MemberInfo member, string memberPath,
                                    PrimaryKeyAttribute columnAttribute) :
            base(table, member, memberPath, columnAttribute) { }

        public override object GetInsertColumnValue<T>(T objectToSave,
                                                       Dictionary<string, object> previousInsertColumnValues)
        {
            object value = GetMemberValue(objectToSave);
            if (value == null)
            {
                throw new InvalidOperationException(string.Format("UserPrimaryKeyColumn has a null value: {0}",
                                                                  this.ToString()));
            }
            return value;
        }
    }

    public class ForeignKeyColumn : Column
    {
        public ForeignKeyColumn(Table table, MemberInfo member, string memberPath,
                                ForeignKeyAttribute columnAttribute) :
            base(table, member, memberPath, null, columnAttribute)
        {
            m_DeleteRule = columnAttribute.DeleteRule;
            m_ForeignTableName = columnAttribute.ForeignTableName;
            m_ForeignColumnName = columnAttribute.ForeignColumnName;
        }
        public ForeignKeyColumn(Table table, string memberPath, Type memberType,
                                ForeignKeyAttribute columnAttribute) :
            base(table, memberPath, memberType, columnAttribute)
        {
            m_DeleteRule = columnAttribute.DeleteRule;
            m_ForeignTableName = columnAttribute.ForeignTableName;
            m_ForeignColumnName = columnAttribute.ForeignColumnName;
        }

        public string ForeignTableName
        {
            get { return m_ForeignTableName; }
            set { m_ForeignTableName = value; }
        }
        public string ForeignColumnName
        {
            get { return m_ForeignColumnName; }
            set { m_ForeignColumnName = value; }
        }
        public override bool IsForeignKey
        {
            get { return true; }
        }
        public Table ForeignTable
        {
            get { return m_ForeignTable; }
            set { m_ForeignTable = value; }
        }
        public Column ForeignColumn
        {
            get { return m_ForeignColumn; }
            set { m_ForeignColumn = value; }
        }
        public DeleteRule DeleteRule
        {
            get { return m_DeleteRule; }
            set { m_DeleteRule = value; }
        }
        public override object GetInsertColumnValue<T>(T objectToSave,
                                                       Dictionary<string, object> previousInsertColumnValues)
        {
            object value = GetMemberValue(objectToSave);
            if (value == null)
            {
                string columnPath = Utils.ColumnPath(m_ForeignTable.TableName, m_ForeignColumnName);
                if (!previousInsertColumnValues.TryGetValue(columnPath, out value))
                {
                    throw new InvalidOperationException(string.Format("The foreign key value could not be located for the ForeignKeyColumn: {0}",
                                                                      this.ToString()));
                }
                SetMemberValue(objectToSave, value);
            }
            return value;
        }
        private string m_ForeignTableName;
        private string m_ForeignColumnName;
        private Table m_ForeignTable;
        private Column m_ForeignColumn;
        private DeleteRule m_DeleteRule;
    }
}
