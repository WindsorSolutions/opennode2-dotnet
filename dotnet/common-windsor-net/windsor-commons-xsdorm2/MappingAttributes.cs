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
using Windsor.Commons.XsdOrm2.Implementations;

namespace Windsor.Commons.XsdOrm2
{
    public enum DeleteRule
    {
        None = 0,
        Cascade = 1,
        SetNull = 2,
        SetDefault = 3,
    }
    public enum UpdateRule
    {
        None = 0,
        Cascade = 1,
        SetNull = 2,
        SetDefault = 3,
    }
    public abstract class MappingAttribute : Attribute
    {
        public MappingAttribute()
        {
        }

        public abstract string GetShortDescription();

        public MappingAttribute ShallowCopy()
        {
            return (MappingAttribute)this.MemberwiseClone();
        }

        public override string ToString()
        {
            return ReflectionUtils.GetPublicPropertiesString(this);
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Assembly)]
    public class NameReplacementsAttribute : MappingAttribute
    {
        public NameReplacementsAttribute(params string[] abbreviationPairs)
        {
            m_Replacements = CollectionUtils.CreateListFromPairs(abbreviationPairs);
        }
        public List<KeyValuePair<string, string>> Replacements
        {
            get
            {
                return m_Replacements;
            }
            set
            {
                m_Replacements = value;
            }
        }
        public override string GetShortDescription()
        {
            return string.Format("{0} replacements(s)", m_Replacements.Count.ToString());
        }
        private List<KeyValuePair<string, string>> m_Replacements;
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Assembly)]
    public class DefaultDecimalPrecision : MappingAttribute
    {
        public DefaultDecimalPrecision(int precision, int scale)
        {
            m_Precision = precision;
            m_Scale = scale;
        }
        public override string GetShortDescription()
        {
            return string.Format("DECIMAL({0},{1})", m_Precision.ToString(), m_Scale.ToString());
        }
        public int Scale
        {
            get
            {
                return m_Scale;
            }
            set
            {
                m_Scale = value;
            }
        }
        public int Precision
        {
            get
            {
                return m_Precision;
            }
            set
            {
                m_Precision = value;
            }
        }
        private int m_Precision;
        private int m_Scale;
    }
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Assembly)]
    public class DefaultFloatPrecisionAttribute : MappingAttribute
    {
        public DefaultFloatPrecisionAttribute(int precision, int scale)
        {
            m_Precision = precision;
            m_Scale = scale;
        }
        public override string GetShortDescription()
        {
            return string.Format("DECIMAL({0},{1})", m_Precision.ToString(), m_Scale.ToString());
        }
        public int Scale
        {
            get
            {
                return m_Scale;
            }
            set
            {
                m_Scale = value;
            }
        }
        public int Precision
        {
            get
            {
                return m_Precision;
            }
            set
            {
                m_Precision = value;
            }
        }
        private int m_Precision;
        private int m_Scale;
    }
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Assembly)]
    public class DefaultDoublePrecisionAttribute : MappingAttribute
    {
        public DefaultDoublePrecisionAttribute(int precision, int scale)
        {
            m_Precision = precision;
            m_Scale = scale;
        }
        public override string GetShortDescription()
        {
            return string.Format("DECIMAL({0},{1})", m_Precision.ToString(), m_Scale.ToString());
        }
        public int Scale
        {
            get
            {
                return m_Scale;
            }
            set
            {
                m_Scale = value;
            }
        }
        public int Precision
        {
            get
            {
                return m_Precision;
            }
            set
            {
                m_Precision = value;
            }
        }
        private int m_Precision;
        private int m_Scale;
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Assembly)]
    public class DefaultStringDbValuesAttribute : MappingAttribute
    {
        public DefaultStringDbValuesAttribute(DbType defaultDbType, int defaultDbSize)
        {
            m_DefaultDbType = defaultDbType;
            m_DefaultDbSize = defaultDbSize;
        }
        public int DefaultDbSize
        {
            get
            {
                return m_DefaultDbSize;
            }
            set
            {
                m_DefaultDbSize = value;
            }
        }
        public DbType DefaultDbType
        {
            get
            {
                return m_DefaultDbType;
            }
            set
            {
                m_DefaultDbType = value;
            }
        }
        public override string GetShortDescription()
        {
            return string.Format("DefaultDbType: {0}, DefaultDbSize: {1}", m_DefaultDbType.ToString(),
                                 m_DefaultDbSize.ToString());
        }
        private DbType m_DefaultDbType;
        private int m_DefaultDbSize;
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Assembly)]
    public class DefaultElementNamePostfixLengthsAttribute : MappingAttribute
    {
        public DefaultElementNamePostfixLengthsAttribute(params string[] abbreviationPairs)
        {
            if (MathUtils.IsOdd(abbreviationPairs.Length))
            {
                throw new ArgumentException("pairs.Length is odd");
            }
            m_ElementNamePostfixToLength = new List<KeyValuePair<string, int>>(abbreviationPairs.Length);
            for (int i = 0; i < abbreviationPairs.Length; i += 2)
            {
                KeyValuePair<string, int> pair =
                    new KeyValuePair<string, int>(abbreviationPairs[i], int.Parse(abbreviationPairs[i + 1]));
                m_ElementNamePostfixToLength.Add(pair);
            }
            m_ElementNamePostfixToLength.Sort(delegate(KeyValuePair<string, int> a, KeyValuePair<string, int> b)
                                                        {
                                                            // Sort longest string to shortest string
                                                            return b.Key.Length - a.Key.Length;
                                                        });
        }
        public List<KeyValuePair<string, int>> ElementNamePostfixToLength
        {
            get
            {
                return m_ElementNamePostfixToLength;
            }
            set
            {
                m_ElementNamePostfixToLength = value;
            }
        }
        public override string GetShortDescription()
        {
            return string.Format("{0} lengths(s)", m_ElementNamePostfixToLength.Count.ToString());
        }
        private List<KeyValuePair<string, int>> m_ElementNamePostfixToLength;
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Assembly)]
    public class DefaultTableNamePrefixAttribute : MappingAttribute
    {
        public DefaultTableNamePrefixAttribute(string prefix)
        {
            m_Prefix = prefix;
        }
        public string Prefix
        {
            get
            {
                return m_Prefix;
            }
            set
            {
                m_Prefix = value;
            }
        }
        public override string GetShortDescription()
        {
            return m_Prefix;
        }
        private string m_Prefix;
    }
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Assembly)]
    public class DontUseDefaultTableNamePrefixForPKAndFKAttribute : MappingAttribute
    {
        public override string GetShortDescription()
        {
            return "DontUseDefaultTableNamePrefixForPKAndFK";
        }
    }
    public abstract class BaseAppliedAttribute : MappingAttribute
    {
        public BaseAppliedAttribute(Type mappedAttributeType, params object[] args)
        {
            m_MappedAttributeType = mappedAttributeType;
            m_Args = args;
        }
        public Type MappedAttributeType
        {
            get
            {
                return m_MappedAttributeType;
            }
            set
            {
                m_MappedAttributeType = value;
            }
        }
        public object[] Args
        {
            get
            {
                return m_Args;
            }
            set
            {
                m_Args = value;
            }
        }
        private Type m_MappedAttributeType;
        private object[] m_Args;
    }
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Assembly, AllowMultiple = true)]
    public class AppliedAttribute : BaseAppliedAttribute
    {
        public AppliedAttribute(Type appliedToType, string appliedToMemberName, Type mappedAttributeType,
                                params object[] args)
            : base(mappedAttributeType, args)
        {
            m_AppliedToType = appliedToType;
            m_AppliedToMemberName = appliedToMemberName;
        }
        public override string GetShortDescription()
        {
            return string.Format("{0},{1},{2}", m_AppliedToType.Name, m_AppliedToMemberName,
                                 MappedAttributeType.Name);
        }
        public Type AppliedToType
        {
            get
            {
                return m_AppliedToType;
            }
            set
            {
                m_AppliedToType = value;
            }
        }
        public string AppliedToMemberName
        {
            get
            {
                return m_AppliedToMemberName;
            }
            set
            {
                m_AppliedToMemberName = value;
            }
        }
        private Type m_AppliedToType;
        private string m_AppliedToMemberName;
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Assembly, AllowMultiple = true)]
    public class MemberTypeAppliedAttribute : BaseAppliedAttribute
    {
        public MemberTypeAppliedAttribute(Type appliedToMemberType, Type mappedAttributeType, params object[] args)
            : base(mappedAttributeType, args)
        {
            m_AppliedToMemberType = appliedToMemberType;
        }
        public override string GetShortDescription()
        {
            return string.Format("{0},{1}", m_AppliedToMemberType.Name,
                                 MappedAttributeType.Name);
        }
        public Type AppliedToMemberType
        {
            get
            {
                return m_AppliedToMemberType;
            }
            set
            {
                m_AppliedToMemberType = value;
            }
        }
        private Type m_AppliedToMemberType;
    }
    [AttributeUsage(AttributeTargets.Class)]
    public class TableAttribute : MappingAttribute
    {
        public TableAttribute()
        {
        }

        public TableAttribute(string tableName)
        {
            m_TableName = tableName;
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
        internal Type TableType
        {
            get;
            set;
        }
        public override string GetShortDescription()
        {
            return string.Format("{0}: TableName = {1}", this.GetType().Name, m_TableName);
        }
        private string m_TableName;
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class ColumnAttribute : MappingAttribute
    {
        public const bool NotNull = false;

        public ColumnAttribute() :
            this(null, 0, true)
        {
        }
        public ColumnAttribute(bool isNullable) :
            this(null, 0, isNullable)
        {
        }
        public ColumnAttribute(string columnName) :
            this(columnName, 0, true)
        {
        }
        public ColumnAttribute(int columnSize) :
            this(null, columnSize, true)
        {
        }
        public ColumnAttribute(int columnSize, bool isNullable) :
            this(null, columnSize, isNullable)
        {
        }
        public ColumnAttribute(string columnName, int columnSize) :
            this(columnName, columnSize, true)
        {
        }
        public ColumnAttribute(string columnName, bool isNullable) :
            this(columnName, 0, isNullable)
        {
        }
        public ColumnAttribute(DbType columnType) :
            this(null, columnType, 0, true)
        {
        }
        public ColumnAttribute(DbType columnType, int columnSize) :
            this(null, columnType, columnSize, true)
        {
        }
        public ColumnAttribute(string columnName, DbType columnType, int columnSize) :
            this(columnName, columnType, columnSize, true)
        {
        }
        public ColumnAttribute(DbType columnType, int columnSize, bool isNullable) :
            this(null, columnType, columnSize, isNullable)
        {
        }
        public ColumnAttribute(DbType columnType, bool isNullable) :
            this(null, columnType, 0, isNullable)
        {
        }
        public ColumnAttribute(string columnName, int columnSize, bool isNullable)
        {
            m_ColumnName = columnName;
            m_ColumnType = null;
            m_ColumnSize = columnSize;
            m_IsNullable = isNullable;
        }
        public ColumnAttribute(string columnName, DbType columnType, int columnSize,
                               bool isNullable)
        {
            m_ColumnName = columnName;
            m_ColumnType = columnType;
            m_ColumnSize = columnSize;
            m_IsNullable = isNullable;
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
        public string IsSpecifiedMemberName
        {
            get
            {
                return m_IsSpecifiedMemberName;
            }
            set
            {
                m_IsSpecifiedMemberName = value;
            }
        }
        public override string GetShortDescription()
        {
            return string.Format("{0}: TableName = {1}, ColumnName = {1}", this.GetType().Name,
                                 m_TableName, m_ColumnName);
        }
        protected string m_TableName;
        protected string m_ColumnName;
        protected DbType? m_ColumnType;
        protected int m_ColumnSize;
        protected bool m_IsNullable = true;
        protected string m_IsSpecifiedMemberName;
        private bool m_IsIndexable;
        private string m_IndexName;
        protected int m_ColumnScale;
    }

    /// <summary>
    /// Primary key attribute.  Indicates that this column or field is a primary key for the
    /// enclosing table.  See subclasses for possible attributes that can be instantiated.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public abstract class PrimaryKeyAttribute : ColumnAttribute
    {
        internal PrimaryKeyAttribute()
        {
        }
        public PrimaryKeyAttribute(string columnName, DbType columnType, int columnSize) :
            base(columnName, columnType, columnSize, false)
        {
        }
        public override string GetShortDescription()
        {
            return string.Format("{0}", this.GetType().Name);
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
                    throw new InvalidOperationException(string.Format("PrimaryKeyAttribute.IsNullable cannot be set to true for the column {0}.{1}",
                                                                      m_TableName, m_ColumnName));
                }
            }
        }
    }

    /// <summary>
    /// Guid primary key attribute.  Indicates that this column or field is a primary key for the
    /// enclosing table.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class GuidPrimaryKeyAttribute : PrimaryKeyAttribute
    {
        public GuidPrimaryKeyAttribute() :
            base(null, DbType.AnsiString, Utils.GUID_NUM_CHARS)
        {
        }
        public GuidPrimaryKeyAttribute(string columnName) :
            base(columnName, DbType.AnsiString, Utils.GUID_NUM_CHARS)
        {
        }
    }

    /// <summary>
    /// Foreign key attribute.  Indicates that this column or field is a foreign key 
    /// to another table.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class ForeignKeyAttribute : ColumnAttribute
    {
        public ForeignKeyAttribute() :
            base(null, 0, false)
        {
        }
        public ForeignKeyAttribute(string columnName, DbType columnType, int columnSize,
                                   DeleteRule deleteRule) :
            base(columnName, columnType, columnSize, false)
        {
            m_DeleteRule = deleteRule;
        }
        public ForeignKeyAttribute(string columnName, DbType columnType, int columnSize) :
            base(columnName, columnType, columnSize, false)
        {
        }
        public ForeignKeyAttribute(string columnName, DbType columnType, int columnSize,
                                   bool isNullable) :
            base(columnName, columnType, columnSize, isNullable)
        {
        }
        public ForeignKeyAttribute(string columnName, DbType columnType, int columnSize,
                                   bool isNullable, DeleteRule deleteRule) :
            base(columnName, columnType, columnSize, isNullable)
        {
            m_DeleteRule = deleteRule;
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

        public override string GetShortDescription()
        {
            return string.Format("{0}: ForeignTableName = {1}, ForeignColumnName = {2}", this.GetType().Name,
                                 m_ForeignTableName, m_ForeignColumnName);
        }

        private string m_ForeignTableName;
        private string m_ForeignColumnName;
        private DeleteRule m_DeleteRule = DeleteRule.Cascade;
    }
    /// <summary>
    /// Guid foreign key attribute.  Indicates that this column or field is a foreign key 
    /// to another table.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class GuidForeignKeyAttribute : ForeignKeyAttribute
    {
        public GuidForeignKeyAttribute()
            : base()
        {
        }
        public GuidForeignKeyAttribute(string columnName, bool isNullable) :
            base(columnName, DbType.Guid, 0, isNullable)
        {
        }
        public GuidForeignKeyAttribute(string columnName) :
            base(columnName, DbType.Guid, 0)
        {
        }
        public GuidForeignKeyAttribute(string columnName, bool isNullable, DeleteRule deleteRule) :
            base(columnName, DbType.Guid, 0, isNullable, deleteRule)
        {
        }
    }

    /// <summary>
    /// Indicates the the property or field must be non-primitive type, and that the members of the class will be 
    /// mapped to the same table to which the property or field's class is mapped.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class SameTableAttribute : MappingAttribute
    {
        public SameTableAttribute()
        {
        }
        public override string GetShortDescription()
        {
            return string.Format("{0}", this.GetType().Name);
        }
    }

    /// <summary>
    /// Relational (One-to-one, one-to-many, many-to-many) mapping attribute base class.  See subclasses 
    /// for possible attributes that can be instantiated.
    /// </summary>
    public abstract class RelationAttribute : MappingAttribute
    {
        public RelationAttribute()
        {
        }
        public override string GetShortDescription()
        {
            return string.Format("{0}", this.GetType().Name);
        }
    }
    /// <summary>
    /// One-to-many mapping relationship.  The property or field MUST implement
    /// ICollection (or subclass).  If a parentColumnName is not specified, this
    /// attribute assumes the parentColumnName is the primary key for the parent
    /// table (and the parent table must implement a primary key property or field).
    /// childTableName represents the child table where the elements of the ICollection 
    /// are populated from, and childForeignKeyColumnName is the foreign key in the child 
    /// table that maps the children to this parent.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class OneToManyAttribute : RelationAttribute
    {
        public OneToManyAttribute()
        {
        }
    }

    /// <summary>
    /// One-to-one mapping relationship.  The property or field MUST NOT implement
    /// ICollection (or subclass).  If a parentColumnName is not specified, this
    /// attribute assumes the parentColumnName is the primary key for the parent
    /// table (and the parent table must implement a primary key property or field).
    /// childTableName represents the child table where the property instance 
    /// is populated from, and childForeignKeyColumnName is the foreign key in the child 
    /// table that maps the property instance to this parent.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class OneToOneAttribute : RelationAttribute
    {
        public OneToOneAttribute()
        {
        }
    }
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class DbIgnoreAttribute : MappingAttribute
    {
        public override string GetShortDescription()
        {
            return "DbIgnore";
        }
    }
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class DbNotNullAttribute : MappingAttribute
    {
        public override string GetShortDescription()
        {
            return "NotNull";
        }
    }
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class DbNullAttribute : MappingAttribute
    {
        public override string GetShortDescription()
        {
            return "Null";
        }
    }
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class DbMaxColumnSizeAttribute : MappingAttribute
    {
        public DbMaxColumnSizeAttribute(int size)
        {
            Size = size;
        }
        public override string GetShortDescription()
        {
            return "MaxColumnSize";
        }
        public int Size
        {
            get;
            set;
        }
    }
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class DbFixedColumnSizeAttribute : MappingAttribute
    {
        public DbFixedColumnSizeAttribute(int size)
        {
            Size = size;
        }
        public override string GetShortDescription()
        {
            return "FixedColumnSize";
        }
        public int Size
        {
            get;
            set;
        }
    }
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class DbColumnTypeAttribute : MappingAttribute
    {
        public DbColumnTypeAttribute(string type)
        {
            Type = EnumUtils.ParseEnum<DbType>(type);
        }
        public DbColumnTypeAttribute(DbType type)
        {
            Type = type;
        }
        public override string GetShortDescription()
        {
            return "ColumnType";
        }
        public DbType Type
        {
            get;
            set;
        }
    }
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class DbColumnScaleAttribute : MappingAttribute
    {
        public DbColumnScaleAttribute(string size, string scale)
        {
            Size = int.Parse(size);
            Scale = int.Parse(scale);
        }
        public DbColumnScaleAttribute(int size, int scale)
        {
            Size = size;
            Scale = scale;
        }
        public override string GetShortDescription()
        {
            return "ColumnScale";
        }
        public int Size
        {
            get;
            set;
        }
        public int Scale
        {
            get;
            set;
        }
    }
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class DbIndexableAttribute : MappingAttribute
    {
        public override string GetShortDescription()
        {
            return "Indexable";
        }
    }
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class DbNoLoadAttribute : MappingAttribute
    {
        public override string GetShortDescription()
        {
            return "NoLoad";
        }
    }
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Assembly)]
    public class RemovePostfixNamesFromTableAndColumnNamesAttribute : MappingAttribute
    {
        public RemovePostfixNamesFromTableAndColumnNamesAttribute(params string[] postfixNames)
        {
            m_PostfixNames = postfixNames;
        }
        public override string GetShortDescription()
        {
            return "RemoveDataPostfixFromTableAndColumnNamesAttribute";
        }
        private IList<string> m_PostfixNames;

        public IList<string> PostfixNames
        {
            get
            {
                return m_PostfixNames;
            }
        }
    }
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Assembly, AllowMultiple = true)]
    public class NamePostfixAppliedAttribute : BaseAppliedAttribute
    {
        public NamePostfixAppliedAttribute(string appliedToMemberNameThatEndsWith, Type mappedAttributeType,
                                           params object[] args)
            : base(mappedAttributeType, args)
        {
            m_AppliedToMemberNameThatEndsWith = appliedToMemberNameThatEndsWith;
        }
        public override string GetShortDescription()
        {
            return string.Format("{0},{1}", m_AppliedToMemberNameThatEndsWith,
                                 MappedAttributeType.Name);
        }
        public string AppliedToMemberNameThatEndsWith
        {
            get
            {
                return m_AppliedToMemberNameThatEndsWith;
            }
            set
            {
                m_AppliedToMemberNameThatEndsWith = value;
            }
        }
        private string m_AppliedToMemberNameThatEndsWith;
    }
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Assembly, AllowMultiple = true)]
    public class AdditionalCreateIndexAttribute : MappingAttribute
    {
        public AdditionalCreateIndexAttribute(string parentTable, string columnName)
            : this(parentTable, columnName, false)
        {
        }
        public AdditionalCreateIndexAttribute(string parentTable, string columnName, bool isUnique)
            : this(parentTable, null, columnName, isUnique)
        {
        }
        public AdditionalCreateIndexAttribute(string parentTable, string parentTablePrefix, string columnName, bool isUnique)
        {
            m_ParentTable = parentTable;
            m_ParentTablePrefix = parentTablePrefix;
            m_ColumnName = columnName;
            m_IsUnique = isUnique;
        }
        public override string GetShortDescription()
        {
            return string.Format("{0}.{1} ({2})", m_ParentTable, m_ColumnName, m_IsUnique);
        }
        private string m_ParentTable;

        public string ParentTable
        {
            get
            {
                return m_ParentTable;
            }
        }
        private string m_ParentTablePrefix;

        public string ParentTablePrefix
        {
            get
            {
                return m_ParentTablePrefix;
            }
        }
        private string m_ColumnName;

        public string ColumnName
        {
            get
            {
                return m_ColumnName;
            }
        }
        private bool m_IsUnique;

        public bool IsUnique
        {
            get
            {
                return m_IsUnique;
            }
        }
    }
}
