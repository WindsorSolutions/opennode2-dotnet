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

namespace Windsor.Commons.XsdOrm3.Implementations
{
    public class ColumnCachedValues
    {
        public Dictionary<object, object> ObjectToPrimaryKeyMap = new Dictionary<object, object>();
    }

    public enum IndexableType
    {
        None,
        Indexable,
        UniqueIndexable
    }

    public class Column : MemberInfoWrapper
    {
        public static readonly DateTime MIN_VALID_DB_DATETIME = new DateTime(1800, 1, 1);
        public static readonly DateTime MAX_VALID_DB_DATETIME = new DateTime(9999, 1, 1);

        public Column(Table table, MemberInfo member, MemberInfo isSpecifiedMember, ColumnAttribute columnAttribute, List<KeyValuePair<Type, MemberInfo>> objectHierarchy) :
            base(member, isSpecifiedMember)
        {
            Init(table, columnAttribute, objectHierarchy);
        }
        protected Column(Table table, ColumnAttribute columnAttribute, List<KeyValuePair<Type, MemberInfo>> objectHierarchy)
        {
            Init(table, columnAttribute, objectHierarchy);
        }
        private void Init(Table table, ColumnAttribute columnAttribute, List<KeyValuePair<Type, MemberInfo>> objectHierarchy)
        {
            ExceptionUtils.ThrowIfNull(table, "table");
            ExceptionUtils.ThrowIfNull(columnAttribute, "columnAttribute");
            m_ObjectHierarchy = objectHierarchy.ToArray();
            m_Table = table;
            m_ColumnName = columnAttribute.ColumnName;
            m_ColumnType = columnAttribute.ColumnType;
            m_ColumnSize = columnAttribute.ColumnSize;
            m_ColumnScale = columnAttribute.ColumnScale;
            m_IsNullable = columnAttribute.IsNullable;
            m_IsIndexable = columnAttribute.IsIndexable ? IndexableType.Indexable : IndexableType.None;
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
                else if (Utils.IsStringColumnType(m_ColumnType.Value) && (m_ColumnSize == 10) && (this.MemberType == typeof(DateTime)))
                {
                    m_IsTenDigitDateString = true;
                }
                else if (m_ColumnType.Value == DbType.Time)
                {
                    m_IsTimeType = true;
                }
            }
            if ((m_MemberType != null) && m_MemberType.IsSubclassOf(typeof(CustomXmlStringFormatTypeBase)))
            {
                m_IsCustomXmlStringFormatType = true;
            }
            if ((MemberInfo == null) && table.IsVirtualTable)
            {
                m_MemberType = table.TableRootType;
            }
        }

        public override string ToString()
        {
            string text = string.Format("{0}, {1} for field {2}", ColumnName, (ColumnType == null) ? "null" : ColumnType.ToString(), FieldFullClassPath);
            if (ColumnSize != 0)
            {
                text += ", " + ColumnSize.ToString();
            }
            return text;
        }
        public string FieldFullClassPath
        {
            get
            {
                if (MemberInfo == null)
                {
                    return string.Empty;
                }
                var classPath = string.Empty;
                if (m_ObjectHierarchy != null)
                {
                    foreach (var pair in m_ObjectHierarchy)
                    {
                        if (classPath.Length == 0)
                        {
                            classPath = pair.Value == null ? pair.Key.Name : pair.Value.Name;
                        }
                        else
                        {
                            classPath = classPath + "." + (pair.Value == null ? pair.Key.Name : pair.Value.Name);
                        }
                    }
                }
                if (classPath.Length == 0)
                {
                    return MemberInfo.Name;
                }
                return classPath + "." + MemberInfo.Name;
            }
        }
        protected virtual IList<string> ColumnParentInstanceFieldHierarchy
        {
            get;
            set;
        }
        public virtual IList<string> ValidateColumnParentInstanceFieldHierarchy(SameTableElementInfo sameTableElementInfo)
        {
            if (ColumnParentInstanceFieldHierarchy == null)
            {
                var currentSameTableElementInfo = sameTableElementInfo;
                var list = new List<string>();
                do
                {
                    list.Add(currentSameTableElementInfo.MemberName);
                    currentSameTableElementInfo = currentSameTableElementInfo.ParentSameTableElementInfo;
                }
                while (currentSameTableElementInfo != null);
                list.Reverse();
                ColumnParentInstanceFieldHierarchy = list;
            }
            return ColumnParentInstanceFieldHierarchy;
        }
        public virtual string ColumnName
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
        public virtual DbType? ColumnType
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
        public virtual int ColumnSize
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
        public virtual int ColumnScale
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
        public IndexableType IsIndexable
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
        public object DefaultValue
        {
            get;
            set;
        }
        public virtual object GetInsertColumnValue(object parentOfObjectToSave, object objectToSave, ColumnCachedValues cachedValues)
        {
            object value = null;
            if (MemberInfo == null)
            {
                if (objectToSave != null)
                {
                    // This would be string, int, double, etc. virtual table
                    DebugUtils.AssertDebuggerBreak(Utils.IsValidColumnType(objectToSave.GetType()));
                    value = objectToSave;
                }
            }
            else
            {
                value = GetMemberValue(objectToSave);
            }
            if (value == null)
            {
                if (this.IsNullable)
                {
                    value = DBNull.Value;
                }
                else
                {
                    throw new MappingException("A column.MemberInfo has a null value, but the column is specified as non-null: {0}",
                                               this.ToString());
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
            else if ((m_ColumnType == DbType.DateTime) || (m_ColumnType == DbType.Date))
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
        public virtual void SetSelectColumnValue<T>(T objectToSet, object value, ColumnCachedValues cachedValues)
        {
            base.SetMemberValue<T>(objectToSet, value);
        }
        public override object GetSetMemberValue(object value)
        {
            // Bug workaround for Spring:
            if ((value != null) && ((value is string) || (value is char)))
            {
                string valueString = value.ToString();
                if ((valueString.Length == 0) || (valueString == "\0"))
                {
                    value = null;
                }
            }
            if (value is DBNull)
            {
                value = null;
            }
            else if (m_IsDbBoolString)
            {
                if (((value == null) && (m_IsSpecifiedMemberInfo == null)) || string.Equals(value.ToString(), "N", StringComparison.InvariantCultureIgnoreCase))
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
                    ;
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
                if (value != null)
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
            }
            else if (m_IsCustomXmlStringFormatType)
            {
                if (value != null)
                {
                    CustomXmlStringFormatTypeBase newValue = (CustomXmlStringFormatTypeBase)Activator.CreateInstance(m_MemberType);
                    try
                    {
                        newValue.SetValue(value);
                    }
                    catch (Exception ex)
                    {
                        throw new ArgException("Failed to convert the database value \"{0}\" of type \"{1}\" to type \"{2}\" for column \"{3}.{4}\" with exception: {5}",
                                               value, value.GetType().Name, m_MemberType.Name, this.Table.TableName,
                                               this.ColumnName, ExceptionUtils.GetDeepExceptionMessage(ex));
                    }
                    value = newValue;
                }
            }
            return base.GetSetMemberValue(value);
        }
        protected Table m_Table;
        protected string m_ColumnName;
        protected DbType? m_ColumnType;
        protected int m_ColumnSize;
        protected bool m_IsNullable;
        protected IndexableType m_IsIndexable;
        protected bool m_NoLoad;
        protected string m_IndexName;
        protected string m_ColumnDescription;
        protected bool m_IsDbBoolString;
        protected bool m_IsDecimalString;
        protected bool m_IsTenDigitDateString;
        protected bool m_IsTimeType;
        protected bool m_IsCustomXmlStringFormatType;
        protected int m_ColumnScale;
        protected KeyValuePair<Type, MemberInfo>[] m_ObjectHierarchy = null;
    }

    public class PrimaryKeyColumn : Column
    {
        public PrimaryKeyColumn(Table table, PrimaryKeyAttribute columnAttribute, List<KeyValuePair<Type, MemberInfo>> objectHierarchy) :
            base(table, columnAttribute, objectHierarchy)
        {
            m_IsNullable = false;
        }
        public PrimaryKeyColumn(Table table, MemberInfo member, ColumnAttribute columnAttribute, List<KeyValuePair<Type, MemberInfo>> objectHierarchy) :
            base(table, member, null, columnAttribute, objectHierarchy)
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
                    throw new MappingException("PrimaryKeyColumn.IsNullable cannot be set to true for the column {0}.{1}",
                                               Table.TableName, ColumnName);
                }
            }
        }
        protected override object GetActualMemberValue(object instance)
        {
            object value = base.GetActualMemberValue(instance);
            if (value == null)
            {
                if ((ColumnSize >= 36) && (ColumnType.HasValue && (ColumnType.Value == DbType.AnsiString)))
                {
                    value = StringUtils.CreateSequentialGuid().ToUpper();
                }
            }
            return value;
        }
        public override object GetInsertColumnValue(object parentOfObjectToSave, object objectToSave, ColumnCachedValues cachedValues)
        {
            object pkGuid = base.GetInsertColumnValue(parentOfObjectToSave, objectToSave, cachedValues);
            ExceptionUtils.ThrowIfNull(pkGuid, "pkGuid");
            if (cachedValues != null)
            {
                cachedValues.ObjectToPrimaryKeyMap[objectToSave] = pkGuid;
            }
            return pkGuid;
        }
        public override void SetSelectColumnValue<T>(T objectToSet, object value, ColumnCachedValues cachedValues)
        {
            base.SetSelectColumnValue(objectToSet, value, cachedValues);
            if (cachedValues != null)
            {
                cachedValues.ObjectToPrimaryKeyMap[objectToSet] = value;
            }
        }
    }

    public class GuidPrimaryKeyColumn : PrimaryKeyColumn
    {
        public GuidPrimaryKeyColumn(Table table, List<KeyValuePair<Type, MemberInfo>> objectHierarchy) :
            base(table, new GuidPrimaryKeyAttribute(table.TableName + Utils.ID_NAME_POSTIFX), objectHierarchy)
        {
        }
        public GuidPrimaryKeyColumn(Table table, MemberInfo member, ColumnAttribute columnAttribute, List<KeyValuePair<Type, MemberInfo>> objectHierarchy) :
            base(table, member, columnAttribute, objectHierarchy)
        {
        }

        public override object GetInsertColumnValue(object parentOfObjectToSave, object objectToSave, ColumnCachedValues cachedValues)
        {
            object pkGuid;
            if (Utils.IsValidColumnType(objectToSave.GetType()))
            {
                // This is a virtual table for string[], int[], enum[], etc.
                pkGuid = StringUtils.CreateSequentialGuid().ToUpper();
            }
            else
            {
                ExceptionUtils.ThrowIfNull(cachedValues, "cachedValues");
                if (!cachedValues.ObjectToPrimaryKeyMap.TryGetValue(objectToSave, out pkGuid))
                {
                    pkGuid = StringUtils.CreateSequentialGuid().ToUpper();
                    cachedValues.ObjectToPrimaryKeyMap[objectToSave] = pkGuid;
                }
                else
                {
                    DebugUtils.CheckDebuggerBreak();
                }
            }
            return pkGuid;
        }
        public override void SetSelectColumnValue<T>(T objectToSet, object value, ColumnCachedValues cachedValues)
        {
            DebugUtils.AssertDebuggerBreak(cachedValues != null);
            cachedValues.ObjectToPrimaryKeyMap[objectToSet] = value;
        }
    }

    public class ForeignKeyColumn : Column
    {
        public ForeignKeyColumn(Table table, ForeignKeyAttribute columnAttribute, List<KeyValuePair<Type, MemberInfo>> objectHierarchy) :
            base(table, columnAttribute, objectHierarchy)
        {
            m_DeleteRule = columnAttribute.DeleteRule;
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
        public override string ColumnName
        {
            get
            {
                return m_ForeignTable.PrimaryKey.ColumnName;
            }
            set
            {
                throw new NotSupportedException();
            }
        }
        public override DbType? ColumnType
        {
            get
            {
                return m_ForeignTable.PrimaryKey.ColumnType;
            }
            set
            {
                throw new NotSupportedException();
            }
        }
        public override int ColumnSize
        {
            get
            {
                return m_ForeignTable.PrimaryKey.ColumnSize;
            }
            set
            {
                throw new NotSupportedException();
            }
        }
        public override int ColumnScale
        {
            get
            {
                return m_ForeignTable.PrimaryKey.ColumnScale;
            }
            set
            {
                throw new NotSupportedException();
            }
        }
        public override object GetInsertColumnValue(object parentOfObjectToSet, object objectToSave, ColumnCachedValues cachedValues)
        {
            ExceptionUtils.ThrowIfNull(parentOfObjectToSet, "parentOfObjectToSave");

            object pkGuid;
            ExceptionUtils.ThrowIfFalse(cachedValues.ObjectToPrimaryKeyMap.TryGetValue(parentOfObjectToSet, out pkGuid), "Missing FK value");
            return pkGuid;
        }
        public override void SetSelectColumnValue<T>(T objectToSet, object value, ColumnCachedValues cachedValues)
        {
        }
        private Table m_ForeignTable;
        private DeleteRule m_DeleteRule;
    }
}
