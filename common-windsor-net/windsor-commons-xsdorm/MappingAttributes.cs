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

namespace Windsor.Commons.XsdOrm
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

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Assembly, AllowMultiple = true)]
    public class AdditionalCreateForeignKeyAttribute : MappingAttribute
    {
        public AdditionalCreateForeignKeyAttribute(string parentTable, string columnName,
                                                   string referencedTable, string referencedColumn,
                                                   DeleteRule deleteRule)
        {
            m_ParentTable = parentTable;
            m_ColumnName = columnName;
            m_ReferencedTable = referencedTable;
            m_ReferencedColumn = referencedColumn;
            m_DeleteRule = deleteRule;
        }
        public AdditionalCreateForeignKeyAttribute(string parentTable, string columnName,
                                                   string referencedTable, string referencedColumn,
                                                   UpdateRule updateRule)
        {
            m_ParentTable = parentTable;
            m_ColumnName = columnName;
            m_ReferencedTable = referencedTable;
            m_ReferencedColumn = referencedColumn;
            m_UpdateRule = updateRule;
        }
        public override string GetShortDescription()
        {
            return string.Format("{0}.{1} references {2}.{3} {4}", m_ParentTable, m_ColumnName,
                                 m_ReferencedTable, m_ReferencedColumn, m_DeleteRule.ToString());
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
            set
            {
                m_ParentTablePrefix = value;
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
        private string m_ReferencedTablePrefix;

        public string ReferencedTablePrefix
        {
            get
            {
                return m_ReferencedTablePrefix;
            }
            set
            {
                m_ReferencedTablePrefix = value;
            }
        }
        private string m_ReferencedTable;

        public string ReferencedTable
        {
            get
            {
                return m_ReferencedTable;
            }
        }
        private string m_ReferencedColumn;

        public string ReferencedColumn
        {
            get
            {
                return m_ReferencedColumn;
            }
        }
        private DeleteRule m_DeleteRule;

        public DeleteRule DeleteRule
        {
            get
            {
                return m_DeleteRule;
            }
        }
        private UpdateRule m_UpdateRule;

        public UpdateRule UpdateRule
        {
            get
            {
                return m_UpdateRule;
            }
            set
            {
                m_UpdateRule = value;
            }
        }
    }
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Assembly, AllowMultiple = true)]
    public class AdditionalCreatePrimaryKeyAttribute : MappingAttribute
    {
        public AdditionalCreatePrimaryKeyAttribute(string parentTable, string columnName)
            : this(parentTable, null, columnName)
        {
        }
        public AdditionalCreatePrimaryKeyAttribute(string parentTable, string parentTablePrefix, string columnName)
        {
            m_ParentTable = parentTable;
            m_ParentTablePrefix = parentTablePrefix;
            m_ColumnName = columnName;
        }
        public override string GetShortDescription()
        {
            return string.Format("{0}.{1}", m_ParentTable, m_ColumnName);
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
    }
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Assembly, AllowMultiple = true)]
    public class AdditionalCreateIndexAttribute : MappingAttribute
    {
        public AdditionalCreateIndexAttribute(string parentTable, string columnName)
            : this(parentTable, columnName, false)
        {
        }
        public AdditionalCreateIndexAttribute(string parentTable, string columnName, bool isUnique)
            : this(parentTable, null, columnName, false)
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
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Assembly, AllowMultiple = true)]
    public class AdditionalCreateUniqueConstraintAttribute : MappingAttribute
    {
        public AdditionalCreateUniqueConstraintAttribute(string parentTable, string columnName)
        {
            m_ParentTable = parentTable;
            m_ColumnName = columnName;
        }
        public override string GetShortDescription()
        {
            return string.Format("{0}.{1}", m_ParentTable, m_ColumnName);
        }
        private string m_ParentTable;

        public string ParentTable
        {
            get
            {
                return m_ParentTable;
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
    }
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Assembly)]
    public class AbbreviationsAttribute : MappingAttribute
    {
        public AbbreviationsAttribute(params string[] abbreviationPairs)
        {
            m_Abbreviations = CollectionUtils.CreateDictionaryFromPairs(abbreviationPairs);
        }
        public Dictionary<string, string> Abbreviations
        {
            get
            {
                return m_Abbreviations;
            }
            set
            {
                m_Abbreviations = value;
            }
        }
        public override string GetShortDescription()
        {
            return string.Format("{0} abbreviation(s)", m_Abbreviations.Count.ToString());
        }
        private Dictionary<string, string> m_Abbreviations;
    }
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Assembly)]
    public class AdditionalAbbreviationsAttribute : MappingAttribute
    {
        public AdditionalAbbreviationsAttribute(params string[] abbreviationPairs)
        {
            m_Abbreviations = CollectionUtils.CreateDictionaryFromPairs(abbreviationPairs);
        }
        public Dictionary<string, string> Abbreviations
        {
            get
            {
                return m_Abbreviations;
            }
            set
            {
                m_Abbreviations = value;
            }
        }
        public override string GetShortDescription()
        {
            return string.Format("{0} additional abbreviation(s)", m_Abbreviations.Count.ToString());
        }
        private Dictionary<string, string> m_Abbreviations;
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
    [AttributeUsage(AttributeTargets.Class)]
    public class DefaultTableNameAdditionPrefixAttribute : MappingAttribute
    {
        public DefaultTableNameAdditionPrefixAttribute(string prefix)
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
    public class AppliedPathAttribute : BaseAppliedAttribute
    {
        public AppliedPathAttribute(string objectPath, Type mappedAttributeType,
                                    params object[] args)
            : base(mappedAttributeType, args)
        {
            m_ObjectPath = objectPath;
        }
        public override string GetShortDescription()
        {
            return string.Format("{0},{1}", m_ObjectPath, MappedAttributeType.Name);
        }
        public string ObjectPath
        {
            get
            {
                return m_ObjectPath;
            }
            set
            {
                m_ObjectPath = value;
            }
        }
        private string m_ObjectPath;
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
        public override string GetShortDescription()
        {
            return string.Format("{0}: TableName = {1}", this.GetType().Name, m_TableName);
        }
        private string m_TableName;
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class TableAliasAttribute : MappingAttribute
    {
        public TableAliasAttribute()
        {
        }

        public TableAliasAttribute(string tableName)
        {
            m_TableAliasName = tableName;
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
        public override string GetShortDescription()
        {
            return string.Format("{0}: TableAliasName = {1}", this.GetType().Name, m_TableAliasName);
        }
        private string m_TableAliasName;
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
        public ColumnAttribute(string columnName, DbType columnType) :
            this(columnName, columnType, 0, true)
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
            base(null, DbType.AnsiString, 40)
        {
        }
        public GuidPrimaryKeyAttribute(string columnName) :
            base(columnName, DbType.AnsiString, 40)
        {
        }
        public GuidPrimaryKeyAttribute(string columnName, DbType columnType, int columnSize) :
            base(columnName, columnType, columnSize)
        {
        }
        public GuidPrimaryKeyAttribute(string columnName, int columnSize) :
            base(columnName, DbType.AnsiString, columnSize)
        {
        }
    }

    /// <summary>
    /// User-specified primary key attribute.  Indicates that this column or field is a primary key for the
    /// enclosing table.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class UserPrimaryKeyAttribute : PrimaryKeyAttribute
    {
        internal UserPrimaryKeyAttribute()
        {
            m_IsNullable = false;
        }
        public UserPrimaryKeyAttribute(DbType columnType, int columnSize) :
            base(null, columnType, columnSize)
        {
        }
        public UserPrimaryKeyAttribute(string columnName, DbType columnType, int columnSize) :
            base(columnName, columnType, columnSize)
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
    /// Additional foreign key attribute.  Indicates that this column or field is a foreign key 
    /// to another table.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class AdditionalForeignKeyAttribute : ForeignKeyAttribute
    {
        public AdditionalForeignKeyAttribute()
        {
            DeleteRule = DeleteRule.SetNull;
        }
        public AdditionalForeignKeyAttribute(string columnName, DbType columnType, int columnSize,
                                             DeleteRule deleteRule) :
            base(columnName, columnType, columnSize, deleteRule)
        {
        }
        public AdditionalForeignKeyAttribute(string columnName, DbType columnType, int columnSize) :
            base(columnName, columnType, columnSize)
        {
        }
        public AdditionalForeignKeyAttribute(string columnName, DbType columnType, int columnSize,
                                   bool isNullable) :
            base(columnName, columnType, columnSize, isNullable)
        {
        }
        public AdditionalForeignKeyAttribute(string columnName, DbType columnType, int columnSize,
                                   bool isNullable, DeleteRule deleteRule) :
            base(columnName, columnType, columnSize, isNullable, deleteRule)
        {
        }
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
            base(columnName, DbType.AnsiString, 40, isNullable)
        {
        }
        public GuidForeignKeyAttribute(string columnName) :
            base(columnName, DbType.AnsiString, 40)
        {
        }
        public GuidForeignKeyAttribute(string columnName, DbType columnType, int columnSize) :
            base(columnName, columnType, columnSize)
        {
        }
        public GuidForeignKeyAttribute(string columnName, int columnSize) :
            base(columnName, DbType.AnsiString, columnSize)
        {
        }
        public GuidForeignKeyAttribute(string columnName, DbType columnType, int columnSize,
                                       bool isNullable) :
            base(columnName, columnType, columnSize, isNullable)
        {
        }
        public GuidForeignKeyAttribute(string columnName, bool isNullable, DeleteRule deleteRule) :
            base(columnName, DbType.AnsiString, 40, isNullable, deleteRule)
        {
        }
        public GuidForeignKeyAttribute(string columnName, DbType columnType, int columnSize,
                                       DeleteRule deleteRule) :
            base(columnName, columnType, columnSize, deleteRule)
        {
        }
        public GuidForeignKeyAttribute(string columnName, DbType columnType, int columnSize,
                                       bool isNullable, DeleteRule deleteRule) :
            base(columnName, columnType, columnSize, isNullable, deleteRule)
        {
        }
    }

    /// <summary>
    /// Additional guid foreign key attribute.  Indicates that this column or field is a foreign key 
    /// to another table.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class AdditionalGuidForeignKeyAttribute : AdditionalForeignKeyAttribute
    {
        public AdditionalGuidForeignKeyAttribute()
            : base()
        {
        }
        public AdditionalGuidForeignKeyAttribute(string columnName, bool isNullable) :
            base(columnName, DbType.AnsiString, 40, isNullable)
        {
        }
        public AdditionalGuidForeignKeyAttribute(string columnName) :
            base(columnName, DbType.AnsiString, 40)
        {
        }
        public AdditionalGuidForeignKeyAttribute(string columnName, DbType columnType, int columnSize) :
            base(columnName, columnType, columnSize)
        {
        }
        public AdditionalGuidForeignKeyAttribute(string columnName, int columnSize) :
            base(columnName, DbType.AnsiString, columnSize)
        {
        }
        public AdditionalGuidForeignKeyAttribute(string columnName, DbType columnType, int columnSize,
                                       bool isNullable) :
            base(columnName, columnType, columnSize, isNullable)
        {
        }
        public AdditionalGuidForeignKeyAttribute(string columnName, bool isNullable, DeleteRule deleteRule) :
            base(columnName, DbType.AnsiString, 40, isNullable, deleteRule)
        {
        }
        public AdditionalGuidForeignKeyAttribute(string columnName, DbType columnType, int columnSize,
                                       DeleteRule deleteRule) :
            base(columnName, columnType, columnSize, deleteRule)
        {
        }
        public AdditionalGuidForeignKeyAttribute(string columnName, DbType columnType, int columnSize,
                                       bool isNullable, DeleteRule deleteRule) :
            base(columnName, columnType, columnSize, isNullable, deleteRule)
        {
        }
    }

    /// <summary>
    /// Guid foreign key attribute.  Indicates that this column or field is a foreign key 
    /// to another table.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class UserForeignKeyAttribute : ForeignKeyAttribute
    {
        public UserForeignKeyAttribute()
            : base()
        {
        }
        public UserForeignKeyAttribute(string columnName, DbType columnType, int columnSize) :
            base(columnName, columnType, columnSize)
        {
        }
        public UserForeignKeyAttribute(DbType columnType, int columnSize, bool isNullable) :
            base(null, columnType, columnSize, isNullable)
        {
        }
        public UserForeignKeyAttribute(string columnName, DbType columnType, int columnSize,
                                       bool isNullable) :
            base(columnName, columnType, columnSize, isNullable)
        {
        }
        public UserForeignKeyAttribute(string columnName, DbType columnType, int columnSize,
                                       DeleteRule deleteRule) :
            base(columnName, columnType, columnSize, deleteRule)
        {
        }
        public UserForeignKeyAttribute(DbType columnType, int columnSize, bool isNullable,
                                       DeleteRule deleteRule) :
            base(null, columnType, columnSize, isNullable, deleteRule)
        {
        }
        public UserForeignKeyAttribute(string columnName, DbType columnType, int columnSize,
                                       bool isNullable, DeleteRule deleteRule) :
            base(columnName, columnType, columnSize, isNullable, deleteRule)
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

        public SameTableAttribute(string columnNamePrefix)
        {
            m_ColumnNamePrefix = columnNamePrefix;
        }

        public string ColumnNamePrefix
        {
            get
            {
                return m_ColumnNamePrefix;
            }
            set
            {
                m_ColumnNamePrefix = value;
            }
        }

        public override string GetShortDescription()
        {
            if (string.IsNullOrEmpty(m_ColumnNamePrefix))
            {
                return "SameTable";
            }
            else
            {
                return string.Format("SameTable: {0}", m_ColumnNamePrefix);
            }
        }

        private string m_ColumnNamePrefix;
    }

    /// <summary>
    /// Relational (One-to-one, one-to-many, many-to-many) mapping attribute base class.  See subclasses 
    /// for possible attributes that can be instantiated.
    /// </summary>
    public abstract class RelationAttribute : MappingAttribute
    {
        public RelationAttribute(string childTableName, string childForeignKeyColumnName) :
            this(null, childTableName, childForeignKeyColumnName)
        {
        }
        public RelationAttribute(string parentColumnName, string childTableName,
                                 string childForeignKeyColumnName) :
            this(null, parentColumnName, childTableName, childForeignKeyColumnName)
        {
        }
        public RelationAttribute(string parentTableName, string parentColumnName,
                                 string childTableName, string childForeignKeyColumnName)
        {
            m_ParentTableName = parentTableName;
            m_ParentColumnName = parentColumnName;
            m_ChildTableName = childTableName;
            m_ChildForeignKeyColumnName = childForeignKeyColumnName;
        }
        public string ParentTableName
        {
            get
            {
                return m_ParentTableName;
            }
            set
            {
                m_ParentTableName = value;
            }
        }
        public string ParentColumnName
        {
            get
            {
                return m_ParentColumnName;
            }
            set
            {
                m_ParentColumnName = value;
            }
        }
        public string ChildTableName
        {
            get
            {
                return m_ChildTableName;
            }
            set
            {
                m_ChildTableName = value;
            }
        }
        public string ChildForeignKeyColumnName
        {
            get
            {
                return m_ChildForeignKeyColumnName;
            }
            set
            {
                m_ChildForeignKeyColumnName = value;
            }
        }
        public override string GetShortDescription()
        {
            return string.Format("{0}: ParentTableName = {1}, ParentColumnName = {2}, ChildTableName = {3}, ChildForeignKeyColumnName = {4}",
                                 this.GetType().Name, m_ParentTableName, m_ParentColumnName, m_ChildTableName,
                                 m_ChildForeignKeyColumnName);
        }
        private string m_ParentTableName;
        private string m_ParentColumnName;
        private string m_ChildTableName;
        private string m_ChildForeignKeyColumnName;
    }

    /// <summary>
    /// Used to specify the order that children are inserted into the database
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class DatabaseInsertOrderAttribute : MappingAttribute
    {
        public DatabaseInsertOrderAttribute(int insertOrder)
        {
            m_InsertOrder = insertOrder;
        }
        public override string GetShortDescription()
        {
            return string.Format("{0}: InsertOrder = {1}", m_InsertOrder.ToString());
        }
        public int InsertOrder
        {
            get
            {
                return m_InsertOrder;
            }
            set
            {
                m_InsertOrder = value;
            }
        }
        private int m_InsertOrder;
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
        public OneToManyAttribute() :
            base(null, null)
        {
        }
        public OneToManyAttribute(string childTableName) :
            base(childTableName, null)
        {
        }
        public OneToManyAttribute(string childTableName, string childForeignKeyColumnName) :
            base(childTableName, childForeignKeyColumnName)
        {
        }
        public OneToManyAttribute(string parentColumnName, string childTableName,
                                  string childForeignKeyColumnName) :
            base(parentColumnName, childTableName, childForeignKeyColumnName)
        {
        }
        public OneToManyAttribute(string parentTableName, string parentColumnName,
                                  string childTableName, string childForeignKeyColumnName) :
            base(parentTableName, parentColumnName, childTableName, childForeignKeyColumnName)
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
        public OneToOneAttribute() :
            base(null, null)
        {
        }
        public OneToOneAttribute(string childTableName) :
            base(childTableName, null)
        {
        }
        public OneToOneAttribute(string childTableName, string childForeignKeyColumnName) :
            base(childTableName, childForeignKeyColumnName)
        {
        }
        public OneToOneAttribute(string parentColumnName, string childTableName,
                                 string childForeignKeyColumnName) :
            base(parentColumnName, childTableName, childForeignKeyColumnName)
        {
        }
        public OneToOneAttribute(string parentTableName, string parentColumnName,
                                 string childTableName, string childForeignKeyColumnName) :
            base(parentTableName, parentColumnName, childTableName, childForeignKeyColumnName)
        {
        }
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class ManyToManyAttribute : RelationAttribute
    {
        public ManyToManyAttribute(string childTableName, string childForeignKeyColumnName) :
            base(childTableName, childForeignKeyColumnName)
        {
        }
        public ManyToManyAttribute(string parentColumnName, string childTableName,
                                   string childForeignKeyColumnName) :
            base(parentColumnName, childTableName, childForeignKeyColumnName)
        {
        }
        public ManyToManyAttribute(string parentTableName, string parentColumnName,
                                   string childTableName, string childForeignKeyColumnName) :
            base(parentTableName, parentColumnName, childTableName, childForeignKeyColumnName)
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
    public class ShortenNamesByRemovingVowelsFirstAttribute : MappingAttribute
    {
        public override string GetShortDescription()
        {
            return "ShortenNamesByRemovingVowelsFirst";
        }
    }
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Assembly)]
    public class FixShortenNameBreakBugAttribute : MappingAttribute
    {
        public override string GetShortDescription()
        {
            return "FixShortenNameBreakBug";
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
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Assembly)]
    public class UseTableNameForDefaultPrimaryKeysAttribute : MappingAttribute
    {
        public override string GetShortDescription()
        {
            return "UseTableNameForDefaultPrimaryKeys";
        }
    }
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Assembly)]
    public class InheritAppliedAttributesAttribute : MappingAttribute
    {
        public override string GetShortDescription()
        {
            return "InheritAppliedAttributes";
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
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Assembly)]
    public class NewSameColumnNameResolutionAttribute : MappingAttribute
    {
        public override string GetShortDescription()
        {
            return "NewSameColumnNameResolutionAttribute";
        }
    }
}
