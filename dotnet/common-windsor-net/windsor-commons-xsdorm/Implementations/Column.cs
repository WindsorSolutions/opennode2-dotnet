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
        public static readonly DateTime MIN_VALID_DB_DATETIME = new DateTime(1800, 1, 1);
        public static readonly DateTime MAX_VALID_DB_DATETIME = new DateTime(9999, 1, 1);

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
            m_ColumnScale = columnAttribute.ColumnScale;
            m_IsNullable = columnAttribute.IsNullable;
            m_IsIndexable = columnAttribute.IsIndexable;
            m_IndexName = columnAttribute.IndexName;
            if (m_ColumnType != null)
            {
                if (Utils.IsStringColumnType(m_ColumnType.Value) && (m_ColumnSize == 1) && (this.MemberType == typeof(bool)))
                {
                    m_IsDbBoolString = true;
                }
                else if (Utils.IsFloatingPointType(m_ColumnType.Value) && (this.MemberType == typeof(string)))
                {
                    m_IsDecimalString = true;
                }
                else if (Utils.IsIntegerColumnType(m_ColumnType.Value) && (this.MemberType == typeof(string)))
                {
                    if ((m_ColumnType.Value == DbType.Int64) || (m_ColumnType.Value == DbType.UInt64))
                    {
                        m_IsInt64String = true;
                    }
                    else
                    {
                        m_IsInt32String = true;
                    }
                }
                else if (Utils.IsStringColumnType(m_ColumnType.Value) && (m_ColumnSize == 10) && (this.MemberType == typeof(DateTime)))
                {
                    m_IsTenDigitDateString = true;
                }
                else if (m_ColumnType.Value == DbType.Time)
                {
                    m_IsTimeType = true;
                }
            }
        }

        public string ColumnName
        {
            get
            {
                return m_ColumnName;
            }
            set
            {
                m_ColumnName = value;
            }
        }
        public DbType? ColumnType
        {
            get
            {
                return m_ColumnType;
            }
            set
            {
                m_ColumnType = value;
            }
        }
        public int ColumnSize
        {
            get
            {
                return m_ColumnSize;
            }
            set
            {
                m_ColumnSize = value;
            }
        }
        public int ColumnScale
        {
            get
            {
                return m_ColumnScale;
            }
            set
            {
                m_ColumnScale = value;
            }
        }
        public virtual bool IsNullable
        {
            get
            {
                return m_IsNullable;
            }
            set
            {
                m_IsNullable = value;
            }
        }
        public virtual bool IsPrimaryKey
        {
            get
            {
                return false;
            }
        }
        public virtual bool IsForeignKey
        {
            get
            {
                return false;
            }
        }
        public Table Table
        {
            get
            {
                return m_Table;
            }
            set
            {
                m_Table = value;
            }
        }
        public bool IsIndexable
        {
            get
            {
                return m_IsIndexable;
            }
            set
            {
                m_IsIndexable = value;
            }
        }
        public bool NoLoad
        {
            get
            {
                return m_NoLoad;
            }
            set
            {
                m_NoLoad = value;
            }
        }
        public string IndexName
        {
            get
            {
                return m_IndexName;
            }
            set
            {
                m_IndexName = value;
            }
        }
        public string ColumnDescription
        {
            get
            {
                return m_ColumnDescription;
            }
            set
            {
                m_ColumnDescription = value;
            }
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
            else if (m_IsTenDigitDateString)
            {
                value = ((DateTime)value).ToString("yyyy-MM-dd");
            }
            else if (m_IsTimeType)
            {
                if (m_MemberType == typeof(string))
                {
                    TimeSpan timeSpan = TimeSpan.Parse(value.ToString());
                    value = new DateTime(1900, 1, 1, timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
                }
                else
                {
                    DateTime existingValue = (DateTime)value;
                    value = new DateTime(1900, 1, 1, existingValue.Hour, existingValue.Minute, existingValue.Second);
                }
            }
            else if (m_IsInt64String)
            {
                value = long.Parse(value.ToString());
            }
            else if (m_IsInt32String)
            {
                value = int.Parse(value.ToString());
            }
            else if (m_ColumnType == DbType.DateTime)
            {
                if (m_MemberType == typeof(string))
                {
                    DateTime dateTime = DateTime.Parse(value.ToString());
                    return MakeValidDbDateTime(dateTime);
                }
                else
                {
                    DateTime dateTime = (DateTime)value;
                    return MakeValidDbDateTime(dateTime);
                }
            }
            return value;
        }
        public static DateTime MakeValidDbDateTime(DateTime dateTime)
        {
            if (dateTime < MIN_VALID_DB_DATETIME)
            {
                return MIN_VALID_DB_DATETIME;
            }
            else if (dateTime > MAX_VALID_DB_DATETIME)
            {
                return MAX_VALID_DB_DATETIME;
            }
            return dateTime;
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
            else if (m_IsDecimalString)
            {
                if (value != null)
                {
                    string valueStr = value.ToString();
                    if (valueStr.IndexOf('.') > 0)
                    {
                        valueStr = valueStr.TrimEnd('0').TrimEnd('.');
                    }
                    value = valueStr;
                }
            }
            else if (m_IsTenDigitDateString)
            {
            }
            else if (m_IsTimeType)
            {
                if (m_MemberType == typeof(string))
                {
                    DateTime existingValue = (DateTime)value;
                    value = existingValue.ToString("HH:mm:ss");
                }
                else
                {
                    DateTime existingValue = (DateTime)value;
                    value = new DateTime(1900, 1, 1, existingValue.Hour, existingValue.Minute, existingValue.Second);
                }
            }
            else if (m_MemberType == typeof(string))
            {
                if (value != null)
                {
                    value = (value.ToString()).Trim();
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
        protected bool m_NoLoad;
        protected string m_IndexName;
        protected string m_ColumnDescription;
        protected bool m_IsDbBoolString;
        protected bool m_IsDecimalString;
        protected bool m_IsInt32String;
        protected bool m_IsInt64String;
        protected bool m_IsTenDigitDateString;
        protected bool m_IsTimeType;
        protected int m_ColumnScale;
    }

    public class PrimaryKeyColumn : Column
    {
        public PrimaryKeyColumn(Table table, MemberInfo member, string memberPath,
                                PrimaryKeyAttribute columnAttribute) :
            base(table, member, memberPath, null, columnAttribute)
        {
            m_IsNullable = false;
        }
        // Virtual column member:
        public PrimaryKeyColumn(Table table, string memberPath, Type memberType,
                                ColumnAttribute columnAttribute) :
            base(table, memberPath, memberType, columnAttribute)
        {
            m_IsNullable = false;
        }

        public override bool IsPrimaryKey
        {
            get
            {
                return true;
            }
        }
        public override bool IsNullable
        {
            get
            {
                return m_IsNullable;
            }
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
            base(table, member, memberPath, columnAttribute)
        {
        }
        // Virtual column member:
        public GuidPrimaryKeyColumn(Table table, string memberPath,
                                    PrimaryKeyAttribute columnAttribute) :
            base(table, memberPath, typeof(string), columnAttribute)
        {
        }

        public override object GetInsertColumnValue<T>(T objectToSave,
                                                       Dictionary<string, object> previousInsertColumnValues)
        {
            object value = GetMemberValue(objectToSave);
            if (value == null)
            {
                value = StringUtils.CreateSequentialGuid();
                SetMemberValue(objectToSave, value);
            }
            return value;
        }
    }

    public class UserPrimaryKeyColumn : PrimaryKeyColumn
    {
        public UserPrimaryKeyColumn(Table table, MemberInfo member, string memberPath,
                                    PrimaryKeyAttribute columnAttribute) :
            base(table, member, memberPath, columnAttribute)
        {
        }

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
            get
            {
                return m_ForeignTableName;
            }
            set
            {
                m_ForeignTableName = value;
            }
        }
        public string ForeignColumnName
        {
            get
            {
                return m_ForeignColumnName;
            }
            set
            {
                m_ForeignColumnName = value;
            }
        }
        public override bool IsForeignKey
        {
            get
            {
                return true;
            }
        }
        public Table ForeignTable
        {
            get
            {
                return m_ForeignTable;
            }
            set
            {
                m_ForeignTable = value;
            }
        }
        public Column ForeignColumn
        {
            get
            {
                return m_ForeignColumn;
            }
            set
            {
                m_ForeignColumn = value;
            }
        }
        public DeleteRule DeleteRule
        {
            get
            {
                return m_DeleteRule;
            }
            set
            {
                m_DeleteRule = value;
            }
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
    public class AdditionalForeignKeyColumn : ForeignKeyColumn
    {
        public AdditionalForeignKeyColumn(Table table, MemberInfo member, string memberPath,
                                          AdditionalForeignKeyAttribute columnAttribute) :
            base(table, member, memberPath, columnAttribute)
        {
        }
        public AdditionalForeignKeyColumn(Table table, string memberPath, Type memberType,
                                          AdditionalForeignKeyAttribute columnAttribute) :
            base(table, memberPath, memberType, columnAttribute)
        {
        }
    }
}
