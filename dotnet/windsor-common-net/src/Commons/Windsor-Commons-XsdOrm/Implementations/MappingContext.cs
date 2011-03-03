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
using System.Collections;
using System.Reflection;
using System.Data;
using System.Text;
using System.Xml.Serialization;
using System.Diagnostics;
using System.ComponentModel;
using Windsor.Commons.Core;

namespace Windsor.Commons.XsdOrm.Implementations
{
    public class MappingContext
    {
        public static MappingContext GetMappingContext(Type rootType)
        {
            MappingContext mappingContext = null;
            lock (s_MappingContexts)
            {
                s_MappingContexts.TryGetValue(rootType, out mappingContext);
            }
            if (mappingContext == null)
            {
                mappingContext = new MappingContext(rootType);
                lock (s_MappingContexts)
                {
                    s_MappingContexts.Add(rootType, mappingContext);
                }
            }
            return mappingContext;
        }
        protected MappingContext(Type rootType)
        {
            ConstructTableMappings(rootType);
        }

        protected void ConstructTableMappings(Type objType, string objTypePath,
                                              TableAttribute classTableAttribute,
                                              string objParentTypePath,
                                              List<MemberInfo> parentToMemberChain,
                                              Dictionary<string, Table> tables,
                                              string defaultColumnDescription,
                                              bool canSetColumnsNotNull)
        {
            List<MappingAttribute> attributes = GetMappingAttributesForType(objType, objTypePath);
            List<MappingAttribute> unrecognizedAttributes = null;
            if (objParentTypePath == null)
            {
                objParentTypePath = objTypePath;
            }

            // Parse each mapping attribute associated with the class
            foreach (MappingAttribute mappingAttribute in attributes)
            {
                TableAttribute curTableAttribute = mappingAttribute as TableAttribute;
                if (curTableAttribute != null)
                {
                    if (classTableAttribute != null)
                    {
                        throw new MappingException("The class \"{0}\" has more than one TableAttribute applied to it (\"{1}\" and \"{2}\").  Each class can only have one TableAttribute applied to it.",
                                                   objType.FullName, classTableAttribute.TableName,
                                                   curTableAttribute.TableName);
                    }
                    if (string.IsNullOrEmpty(curTableAttribute.TableName))
                    {
                        curTableAttribute.TableName = GetDefaultTableName(objType);
                    }
                    classTableAttribute = curTableAttribute;
                    continue;
                }
                if (mappingAttribute is AbbreviationsAttribute)
                {
                    continue;   // Ignore, already taken care of on root element only
                }
                if (mappingAttribute is AdditionalAbbreviationsAttribute)
                {
                    continue;   // Ignore, already taken care of on root element only
                }
                if (mappingAttribute is DefaultStringDbValuesAttribute)
                {
                    continue;   // Ignore, already taken care of on root element only
                }
                if (mappingAttribute is DefaultElementNamePostfixLengthsAttribute)
                {
                    continue;   // Ignore, already taken care of on root element only
                }
                if (mappingAttribute is DefaultTableNamePrefixAttribute)
                {
                    continue;   // Ignore, already taken care of on root element only
                }
                if (mappingAttribute is AppliedAttribute)
                {
                    continue;   // Ignore, already taken care of on root element only
                }
                if (mappingAttribute is AppliedPathAttribute)
                {
                    continue;   // Ignore, already taken care of on root element only
                }
                if (mappingAttribute is NamePostfixAppliedAttribute)
                {
                    continue;   // Ignore, already taken care of on root element only
                }
                if (mappingAttribute is DefaultDecimalPrecision)
                {
                    continue;   // Ignore, already taken care of on root element only
                }
                if (mappingAttribute is DefaultFloatPrecisionAttribute)
                {
                    continue;   // Ignore, already taken care of on root element only
                }
                if (mappingAttribute is DefaultDoublePrecisionAttribute)
                {
                    continue;   // Ignore, already taken care of on root element only
                }
                if (mappingAttribute is ShortenNamesByRemovingVowelsFirstAttribute)
                {
                    continue;   // Ignore, already taken care of on root element only
                }
                if (mappingAttribute is FixShortenNameBreakBugAttribute)
                {
                    continue;   // Ignore, already taken care of on root element only
                }
                if (mappingAttribute is InheritAppliedAttributesAttribute)
                {
                    continue;
                }
                if (mappingAttribute is UseTableNameForDefaultPrimaryKeysAttribute)
                {
                    continue;   // Ignore, already taken care of on root element only
                }
                CollectionUtils.Add(mappingAttribute, ref unrecognizedAttributes);
            }
            if (unrecognizedAttributes != null)
            {
                throw new MappingException(Utils.GetShortDescriptionList(unrecognizedAttributes),
                                           "The class \"{0}\" has unrecognized mapping attribute(s).  Please correct the following attributes:",
                                           objType.FullName);
            }
            if (classTableAttribute == null)
            {
                // Defaults to class name if not specified
                string tableName = GetDefaultTableName(objType);
                classTableAttribute = new TableAttribute(tableName);
            }
            if (classTableAttribute.TableName.Length > Utils.MAX_TABLE_NAME_CHARS)
            {
                throw new MappingException("The class \"{0}\" has a TableAttribute applied to it (\"{1}\") that exceeds the maximum table name length of {2} characters",
                                           objType.FullName, classTableAttribute.TableName,
                                           Utils.MAX_TABLE_NAME_CHARS);
            }
            if (StringUtils.ContainsLowercaseChars(classTableAttribute.TableName))
            {
                throw new MappingException("The class \"{0}\" has a TableAttribute applied to it (\"{1}\") that contains lowercase characters.  Table names cannot contain lowercase characters.",
                                           objType.FullName, classTableAttribute.TableName);
            }

            List<MemberInfo> members = Utils.GetPublicMembersForType(objType);
            List<RelationInfo> relationMembers = null;
            List<SameTableElementInfo> sameTableAttributes = null;
            List<MemberInfo> staticParentToMemberChain = null;
            for (int memberIndex = 0; memberIndex < members.Count; ++memberIndex)
            {
                MemberInfo member = members[memberIndex];
                if (member == null)
                {
                    continue;
                }
                PropertyInfo propertyInfo = (member as PropertyInfo);
                FieldInfo fieldInfo = (member as FieldInfo);
                string valueTypePath = Utils.CombineTypePath(objTypePath, member.Name);
                Type valueType = (propertyInfo != null) ? propertyInfo.PropertyType : fieldInfo.FieldType;
                attributes = GetMappingAttributesForMember(member, valueTypePath);
                RelationAttribute lastRelationAttribute = null;

                if (GetAttributeByType<DbIgnoreAttribute>(attributes) != null)
                {
                    members[memberIndex] = null;
                    continue;
                }

                if (Utils.IsValidColumnType(valueType))
                {
                    if (valueType == typeof(bool))
                    {
                        if (member.Name.EndsWith(m_SpecifiedFieldPostfixName))
                        {
                            // Ignore
                        }
                        else
                        {
                            if (GetAttributeByType<ColumnAttribute>(attributes) == null)
                            {
                                attributes.Add(new ColumnAttribute());
                            }
                        }
                    }
                    else
                    {
                        if (GetAttributeByType<ColumnAttribute>(attributes) == null)
                        {
                            attributes.Add(new ColumnAttribute());
                        }
                    }
                }
                else
                {
                    if ((GetAttributeByType<RelationAttribute>(attributes) == null) &&
                        (GetAttributeByType<SameTableAttribute>(attributes) == null))
                    {
                        if (CollectionUtils.GetCollectionElementType(valueType) == null)
                        {
                            // Assume SameTableAttribute if no mapping provided and member is not an array
                            attributes.Add(new SameTableAttribute());
                        }
                        else
                        {
                            // Assume OneToMany
                            attributes.Add(new OneToManyAttribute());
                        }
                    }
                }

                // Parse each mapping attribute associated with this class member
                DbNotNullAttribute dbNotNullAttribute = null;
                DbIndexableAttribute dbIndexableAttribute = null;
                DbNoLoadAttribute dbNoLoadAttribute = null;
                DbMaxColumnSizeAttribute dbMaxColumnSizeAttribute = null;
                DbFixedColumnSizeAttribute dbFixedColumnSizeAttribute = null;
                DbColumnTypeAttribute dbColumnTypeAttribute = null;
                Column newColumn = null;
                Relation newRelation = null;
                SameTableElementInfo newSameTableElementInfo = null;
                foreach (MappingAttribute mappingAttribute in attributes)
                {
                    ColumnAttribute columnAttribute = mappingAttribute as ColumnAttribute;
                    if (columnAttribute != null)
                    {
                        ForeignKeyAttribute foreignKeyAttribute = mappingAttribute as ForeignKeyAttribute;
                        PrimaryKeyAttribute primaryKeyAttribute = mappingAttribute as PrimaryKeyAttribute;
                        if (string.IsNullOrEmpty(columnAttribute.TableName))
                        {
                            columnAttribute.TableName = classTableAttribute.TableName;
                        }
                        else if (columnAttribute.TableName != classTableAttribute.TableName)
                        {
                            throw new MappingException("The class \"{0}\" has more than one table mapped to it (\"{1}\" and \"{2}\").  This is not allowed in this version.",
                                                       objType.FullName, columnAttribute.TableName, classTableAttribute.TableName);
                        }
                        if (string.IsNullOrEmpty(columnAttribute.ColumnName))
                        {
                            string columnName = member.Name;
                            if (primaryKeyAttribute != null)
                            {
                                if (columnName == "_PK")
                                {
                                    if (m_UseTableNameForDefaultPrimaryKeys)
                                    {
                                        columnAttribute.ColumnName = classTableAttribute.TableName + "_ID";
                                        if (!string.IsNullOrEmpty(m_DefaultTableNamePrefix))
                                        {
                                            if (columnAttribute.ColumnName.IndexOf(m_DefaultTableNamePrefix, 0, 
                                                StringComparison.InvariantCultureIgnoreCase) == 0)
                                            {
                                                columnAttribute.ColumnName = columnAttribute.ColumnName.Substring(m_DefaultTableNamePrefix.Length);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        columnName = objType.Name;
                                        if (columnName.EndsWith("DataType"))
                                        {
                                            columnName = columnName.Substring(0, columnName.Length - "DataType".Length);
                                        }
                                        columnName += "Id";
                                        columnAttribute.ColumnName =
                                           Utils.ShortenDatabaseColumnName(Utils.CamelCaseToDatabaseName(columnName),
                                                                           m_ShortenNamesByRemovingVowelsFirst,
                                                                           m_FixShortenNameBreakBug,
                                                                           m_Abbreviations);
                                    }
                                }
                                else
                                {
                                    columnAttribute.ColumnName =
                                        Utils.ShortenDatabaseColumnName(Utils.CamelCaseToDatabaseName(columnName),
                                                                        m_ShortenNamesByRemovingVowelsFirst,
                                                                        m_FixShortenNameBreakBug,
                                                                        m_Abbreviations);
                                }
                            }
                            else
                            {
                                columnAttribute.ColumnName =
                                    Utils.ShortenDatabaseColumnName(Utils.CamelCaseToDatabaseName(columnName),
                                                                    m_ShortenNamesByRemovingVowelsFirst, m_FixShortenNameBreakBug,
                                                                    m_Abbreviations);
                            }
                        }
                        if ((foreignKeyAttribute != null) && (columnAttribute.ColumnType == null) && (columnAttribute.ColumnSize == 0))
                        {
                            // These values will be assigned in ValidateTables() to the type and size of the column that this
                            // foreign key references
                        }
                        else
                        {
                            if (columnAttribute.ColumnType == null)
                            {
                                if ((valueType == typeof(string)) || (valueType == typeof(bool)) || valueType.IsEnum)
                                {
                                    columnAttribute.ColumnType = m_DefaultStringDbValues.DefaultDbType;
                                }
                                else if (valueType == typeof(DateTime))
                                {
                                    columnAttribute.ColumnType = DbType.DateTime;
                                }
                                else if (valueType == typeof(decimal))
                                {
                                    columnAttribute.ColumnType = DbType.Decimal;
                                }
                                else if (valueType == typeof(float))
                                {
                                    columnAttribute.ColumnType = DbType.Single;
                                }
                                else if (valueType == typeof(int))
                                {
                                    columnAttribute.ColumnType = DbType.Int32;
                                }
                                else if (valueType == typeof(byte[]))
                                {
                                    columnAttribute.ColumnType = DbType.Binary;
                                }
                                else
                                {
                                    throw new MappingException("The member \"{0}\" of the class \"{1}\" has a ColumnAttribute without a ColumnType specified.",
                                                               member.Name, objType.FullName);
                                }
                            }
                            if ((columnAttribute.ColumnSize == 0) &&
                                ((columnAttribute.ColumnType != DbType.DateTime) && (columnAttribute.ColumnType != DbType.Decimal) &&
                                 (columnAttribute.ColumnType != DbType.Int32)))
                            {
                                if (valueType == typeof(string))
                                {
                                    columnAttribute.ColumnSize = GetElementDefaultStringLength(member.Name);
                                    if (columnAttribute.ColumnSize == 0)
                                    {
                                        columnAttribute.ColumnSize = m_DefaultStringDbValues.DefaultDbSize;
                                    }
                                }
                                else if (valueType == typeof(bool))
                                {
                                    columnAttribute.ColumnSize = 1;
                                }
                                else if (valueType.IsEnum)
                                {
                                    columnAttribute.ColumnSize = EnumUtils.GetLargestEnumStringSize(valueType);
                                }
                            }
                            if (!Utils.IsValidColumnSize(columnAttribute.ColumnType.Value, columnAttribute.ColumnSize, columnAttribute.ColumnScale))
                            {
                                throw new MappingException("The member \"{0}\" of the class \"{1}\" has a ColumnAttribute applied to it, but the database column size, \"{2},\" is not valid for the database column type \"{3}\".",
                                                           member.Name, objType.FullName, columnAttribute.ColumnSize.ToString(),
                                                           columnAttribute.ColumnType.ToString());
                            }
                            if (!Utils.IsValidColumnType(valueType))
                            {
                                throw new MappingException("The member \"{0}\" of the class \"{1}\" has a ColumnAttribute applied to it, but the member is not a valid data type for a column.",
                                                           member.Name, objType.FullName);
                            }
                        }
                        if (columnAttribute.ColumnName.Length > Utils.MAX_COLUMN_NAME_CHARS)
                        {
                            throw new MappingException("The member \"{0}\" of the class \"{1}\" has a ColumnAttribute applied to it (\"{2}\") that exceeds the maximum column name length of {3} characters",
                                                       member.Name, objType.FullName, columnAttribute.ColumnName,
                                                       Utils.MAX_COLUMN_NAME_CHARS);
                        }
                        if (StringUtils.ContainsLowercaseChars(columnAttribute.ColumnName))
                        {
                            throw new MappingException("The member \"{0}\" of the class \"{1}\" has a ColumnAttribute applied to it (\"{2}\") that contains lowercase characters.  Column names cannot contain lowercase characters.",
                                                      member.Name, objType.FullName, columnAttribute.ColumnName);
                        }
                        if (foreignKeyAttribute != null)
                        {
                            if (!string.IsNullOrEmpty(foreignKeyAttribute.ForeignTableName))
                            {
                                if (string.IsNullOrEmpty(foreignKeyAttribute.ForeignTableName))
                                {
                                    throw new MappingException("The member \"{0}\" of the class \"{1}\" has a ForeignKeyAttribute applied to it that does not have a ForeignTableName specified.  If a ForeignKeyAttribute is applied to a class member, it must have a ForeignTableName specified.",
                                                               member.Name, objType.FullName);
                                }
                                if (foreignKeyAttribute.ForeignTableName.Length > Utils.MAX_TABLE_NAME_CHARS)
                                {
                                    throw new MappingException("The member \"{0}\" of the class \"{1}\" has a ForeignKeyAttribute applied to it (\"{1}\") that exceeds the maximum table name length of {2} characters",
                                                               member.Name, objType.FullName, foreignKeyAttribute.ForeignTableName,
                                                               Utils.MAX_TABLE_NAME_CHARS);
                                }
                                if (StringUtils.ContainsLowercaseChars(foreignKeyAttribute.ForeignTableName))
                                {
                                    throw new MappingException("The member \"{0}\" of the class \"{1}\" has a ForeignKeyAttribute applied to it (\"{1}\") that contains lowercase characters.  Table names cannot contain lowercase characters.",
                                                               member.Name, objType.FullName, foreignKeyAttribute.ForeignTableName);
                                }
                            }
                            if (!string.IsNullOrEmpty(foreignKeyAttribute.ForeignColumnName))
                            {
                                if (foreignKeyAttribute.ForeignColumnName.Length > Utils.MAX_COLUMN_NAME_CHARS)
                                {
                                    throw new MappingException("The member \"{0}\" of the class \"{1}\" has a ForeignKeyAttribute applied to it (\"{2}\") that exceeds the maximum column name length of {3} characters",
                                                               member.Name, objType.FullName, foreignKeyAttribute.ForeignColumnName,
                                                               Utils.MAX_COLUMN_NAME_CHARS);
                                }
                                if (StringUtils.ContainsLowercaseChars(foreignKeyAttribute.ForeignColumnName))
                                {
                                    throw new MappingException("The member \"{0}\" of the class \"{1}\" has a ForeignKeyAttribute applied to it (\"{2}\") that contains lowercase characters.  Column names cannot contain lowercase characters.",
                                                              member.Name, objType.FullName, foreignKeyAttribute.ForeignColumnName);
                                }
                            }
                            if ((foreignKeyAttribute.ColumnType == null) && (foreignKeyAttribute.ColumnSize == 0))
                            {
                                // These values will be assigned in ValidateTables() to the type and size of the column that this
                                // foreign key references
                            }
                            else
                            {
                                if (foreignKeyAttribute.ColumnType == null)
                                {
                                    throw new MappingException("foreignKeyAttribute.ColumnType is null for element \"{0}\"", valueTypePath);
                                }
                                if (!Utils.IsValidForeignKeyColumnType(foreignKeyAttribute.ColumnType.Value))
                                {
                                    throw new MappingException("The member \"{0}\" of the class \"{1}\" has a ForeignKeyAttribute applied to it, but the database column type, \"{2},\" is not valid for a foreign key.",
                                                               member.Name, objType.FullName, foreignKeyAttribute.ColumnType.ToString());
                                }
                                if (!Utils.IsValidForeignKeyColumnSize(foreignKeyAttribute.ColumnType.Value, foreignKeyAttribute.ColumnSize))
                                {
                                    throw new MappingException("The member \"{0}\" of the class \"{1}\" has a ForeignKeyAttribute applied to it, but the database column size, \"{2},\" is not valid for this foreign key.",
                                                               member.Name, objType.FullName, foreignKeyAttribute.ColumnSize.ToString());
                                }
                            }
                        }
                        else if (primaryKeyAttribute != null)
                        {
                            if (primaryKeyAttribute.ColumnType == null)
                            {
                                throw new MappingException("primaryKeyAttribute.ColumnType is null for element \"{0}\"", valueTypePath);
                            }
                            if (!Utils.IsValidPrimaryKeyColumnType(primaryKeyAttribute.ColumnType.Value))
                            {
                                throw new MappingException("The member \"{0}\" of the class \"{1}\" has a PrimaryKeyAttribute applied to it, but the database column type, \"{2},\" is not valid for a primary key.",
                                                           member.Name, objType.FullName, primaryKeyAttribute.ColumnType.ToString());
                            }
                            if (!Utils.IsValidPrimaryKeyColumnSize(primaryKeyAttribute.ColumnType.Value, primaryKeyAttribute.ColumnSize))
                            {
                                throw new MappingException("The member \"{0}\" of the class \"{1}\" has a PrimaryKeyAttribute applied to it, but the database column size, \"{2},\" is not valid for this primary key.",
                                                           member.Name, objType.FullName, primaryKeyAttribute.ColumnSize.ToString());
                            }
                        }
                        MemberInfo isSpecifiedMember = null;
                        int isSpecifiedMemberIndex = -1;
                        if (columnAttribute.IsNullable)
                        {
                            if (!string.IsNullOrEmpty(columnAttribute.IsSpecifiedMemberName))
                            {
                                isSpecifiedMember = Utils.FindMemberByName(members, columnAttribute.IsSpecifiedMemberName, out isSpecifiedMemberIndex);
                                if (isSpecifiedMember == null)
                                {
                                    throw new MappingException("The member \"{0}\" of the class \"{1}\" has a ColumnAttribute with a IsSpecifiedMemberName value applied, but the property or field \"{2}\" is not a member of the class.",
                                                               member.Name, objType.FullName, columnAttribute.IsSpecifiedMemberName);
                                }
                                if (ReflectionUtils.GetFieldOrPropertyValueType(isSpecifiedMember) != typeof(bool))
                                {
                                    throw new MappingException("The member \"{0}\" of the class \"{1}\" has a ColumnAttribute with a IsSpecifiedMemberName value applied, but the property or field \"{2}\" is not a bool.",
                                                               member.Name, objType.FullName, columnAttribute.IsSpecifiedMemberName);
                                }
                            }
                            else
                            {
                                string isSpecifiedName = member.Name + m_SpecifiedFieldPostfixName;
                                isSpecifiedMember = Utils.FindMemberByName(members, isSpecifiedName, out isSpecifiedMemberIndex);
                                if (isSpecifiedMember != null)
                                {
                                    if (ReflectionUtils.GetFieldOrPropertyValueType(isSpecifiedMember) != typeof(bool))
                                    {
                                        isSpecifiedMember = null;
                                    }
                                }
                            }
                        }
                        if ((isSpecifiedMember != null) &&
                            ((foreignKeyAttribute != null) || (primaryKeyAttribute != null)))
                        {
                            throw new MappingException("The member \"{0}\" of the class \"{1}\" has a ForeignKeyAttribute or PrimaryKeyAttribute with a Specified member \"{3}.\"  ForeignKeyAttribute and PrimaryKeyAttribute cannot be applied to members that have associated Specified members.",
                                                      member.Name, objType.FullName, columnAttribute.IsSpecifiedMemberName);
                        }
                        newColumn = CreateColumn(columnAttribute, member, valueTypePath, isSpecifiedMember, objType, tables);
                        members[memberIndex] = null;
                        if (isSpecifiedMember != null)
                        {
                            members[isSpecifiedMemberIndex] = null;
                        }
                        newColumn.ColumnDescription = GetColumnDescription(member, defaultColumnDescription);
                        if (!newColumn.IsForeignKey && !newColumn.IsPrimaryKey)
                        {
                            newColumn.ParentToMemberChain =
                                GetStaticParentToMemberChain(parentToMemberChain, ref staticParentToMemberChain);
                            if (!CollectionUtils.IsNullOrEmpty(newColumn.ParentToMemberChain))
                            {
                                if (string.IsNullOrEmpty(objParentTypePath))
                                {
                                    throw new MappingException("objParentTypePath == null");
                                }
                                newColumn.ParentInfoPath = objParentTypePath;
                            }
                        }
                        continue;
                    }
                    SameTableAttribute sameTableAttribute = mappingAttribute as SameTableAttribute;
                    if (sameTableAttribute != null)
                    {
                        if (Utils.IsValidColumnType(valueType))
                        {
                            throw new MappingException("The member \"{0}\" of the class \"{1}\" has a SameTableAttribute applied to it, but the member is a primitive type.  SameTableAttributes can only be applied to non-primitive types.",
                                                       member.Name, objType.FullName);
                        }
                        newSameTableElementInfo = new SameTableElementInfo(valueTypePath, valueType, member, sameTableAttribute);
                        CollectionUtils.Add(newSameTableElementInfo, ref sameTableAttributes);
                        members[memberIndex] = null;
                        continue;
                    }
                    RelationAttribute relationAttribute = mappingAttribute as RelationAttribute;
                    if (relationAttribute != null)
                    {
                        if (lastRelationAttribute != null)
                        {
                            throw new MappingException("The member \"{0}\" of the class \"{1}\" has more than one relation attribute applied to it: \"{2}\" and \"{3}\"",
                                                       member.Name, objType.FullName, lastRelationAttribute.GetType().Name,
                                                       relationAttribute.GetType().Name);
                        }
                        if (string.IsNullOrEmpty(relationAttribute.ParentTableName))
                        {
                            relationAttribute.ParentTableName = classTableAttribute.TableName;
                        }
                        if (relationAttribute.ParentTableName.Length > Utils.MAX_TABLE_NAME_CHARS)
                        {
                            throw new MappingException("The member \"{0}\" of the class \"{1}\" has a {2} applied to it (\"{3}\") that exceeds the maximum parent table name length of {4} characters",
                                                       member.Name, objType.FullName, relationAttribute.GetType().Name,
                                                       relationAttribute.ParentTableName, Utils.MAX_TABLE_NAME_CHARS);
                        }
                        if (StringUtils.ContainsLowercaseChars(relationAttribute.ParentTableName))
                        {
                            throw new MappingException("The member \"{0}\" of the class \"{1}\" has a {2} applied to it (\"{3}\") that contains lowercase characters in the parent table name.  Table names cannot contain lowercase characters.",
                                                       member.Name, objType.FullName, relationAttribute.GetType().Name,
                                                       relationAttribute.ParentTableName);
                        }
                        if (!string.IsNullOrEmpty(relationAttribute.ChildTableName))
                        {
                            if (relationAttribute.ChildTableName.Length > Utils.MAX_TABLE_NAME_CHARS)
                            {
                                throw new MappingException("The member \"{0}\" of the class \"{1}\" has a {2} applied to it (\"{3}\") that exceeds the maximum parent table name length of {4} characters",
                                                           member.Name, objType.FullName, relationAttribute.GetType().Name,
                                                           relationAttribute.ChildTableName, Utils.MAX_TABLE_NAME_CHARS);
                            }
                            if (StringUtils.ContainsLowercaseChars(relationAttribute.ChildTableName))
                            {
                                throw new MappingException("The member \"{0}\" of the class \"{1}\" has a {2} applied to it (\"{3}\") that contains lowercase characters in the parent table name.  Table names cannot contain lowercase characters.",
                                                           member.Name, objType.FullName, relationAttribute.GetType().Name,
                                                           relationAttribute.ChildTableName);
                            }
                            if (!string.IsNullOrEmpty(relationAttribute.ChildForeignKeyColumnName))
                            {
                                if (relationAttribute.ChildForeignKeyColumnName.Length > Utils.MAX_COLUMN_NAME_CHARS)
                                {
                                    throw new MappingException("The member \"{0}\" of the class \"{1}\" has a {2} applied to it (\"{3}\") that exceeds the maximum column name length of {4} characters",
                                                               member.Name, objType.FullName, relationAttribute.GetType().Name,
                                                               relationAttribute.ChildForeignKeyColumnName,
                                                               Utils.MAX_COLUMN_NAME_CHARS);
                                }
                                if (StringUtils.ContainsLowercaseChars(relationAttribute.ChildForeignKeyColumnName))
                                {
                                    throw new MappingException("The member \"{0}\" of the class \"{1}\" has a {2} applied to it (\"{2}\") that contains lowercase characters.  Column names cannot contain lowercase characters.",
                                                              member.Name, objType.FullName, relationAttribute.GetType().Name,
                                                              relationAttribute.ChildForeignKeyColumnName);
                                }
                            }
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(relationAttribute.ChildForeignKeyColumnName))
                            {
                                throw new MappingException("If ChildTableName is null, ChildForeignKeyColumnName must also be null");
                            }
                        }
                        if (!string.IsNullOrEmpty(relationAttribute.ParentColumnName))
                        {
                            if (relationAttribute.ParentColumnName.Length > Utils.MAX_COLUMN_NAME_CHARS)
                            {
                                throw new MappingException("The member \"{0}\" of the class \"{1}\" has a {2} applied to it (\"{3}\") that exceeds the maximum column name length of {4} characters",
                                                           member.Name, objType.FullName, relationAttribute.GetType().Name,
                                                           relationAttribute.ParentColumnName,
                                                           Utils.MAX_COLUMN_NAME_CHARS);
                            }
                            if (StringUtils.ContainsLowercaseChars(relationAttribute.ParentColumnName))
                            {
                                throw new MappingException("The member \"{0}\" of the class \"{1}\" has a {2} applied to it (\"{2}\") that contains lowercase characters.  Column names cannot contain lowercase characters.",
                                                          member.Name, objType.FullName, relationAttribute.GetType().Name,
                                                          relationAttribute.ParentColumnName);
                            }
                        }
                        Type assignType = null;
                        if (relationAttribute is OneToManyAttribute)
                        {
                            assignType = CollectionUtils.GetCollectionElementType(valueType);
                            if (assignType == null)
                            {
                                throw new MappingException("The member \"{0}\" of the class \"{1}\" has a OneToManyAttribute applied to it, but the member does not implement ICollection.  If a OneToManyAttribute is applied to a class member, it must implement ICollection.",
                                                           member.Name, objType.FullName, relationAttribute.GetShortDescription(),
                                                           relationAttribute.GetShortDescription());
                            }
                        }
                        else if (relationAttribute is OneToOneAttribute)
                        {
                            if (Utils.IsValidColumnType(valueType) || !valueType.IsClass)
                            {
                                throw new MappingException("The member \"{0}\" of the class \"{1}\" has a OneToOneAttribute applied to it, but the member is not a valid class type.",
                                                           member.Name, objType.FullName);
                            }
                            assignType = valueType;
                        }
                        else if (Utils.IsValidColumnType(valueType))
                        {
                            assignType = valueType;
                        }
                        newRelation = CreateRelation(relationAttribute, member, valueTypePath, assignType, tables);
                        newRelation.ParentToMemberChain = GetStaticParentToMemberChain(parentToMemberChain, ref staticParentToMemberChain);
                        if (!CollectionUtils.IsNullOrEmpty(newRelation.ParentToMemberChain))
                        {
                            if (string.IsNullOrEmpty(objParentTypePath))
                            {
                                throw new MappingException("objParentTypePath == null");
                            }
                            newRelation.ParentInfoPath = objParentTypePath;
                        }
                        string description = ReflectionUtils.GetDescription(member);
                        CollectionUtils.Add(new RelationInfo(valueTypePath, assignType, description), ref relationMembers);
                        lastRelationAttribute = relationAttribute;
                        members[memberIndex] = null;
                        continue;
                    }
                    DbNotNullAttribute notNullAttribute = mappingAttribute as DbNotNullAttribute;
                    if (notNullAttribute != null)
                    {
                        dbNotNullAttribute = notNullAttribute;
                        continue;
                    }
                    DbMaxColumnSizeAttribute maxColumnSizeAttribute = mappingAttribute as DbMaxColumnSizeAttribute;
                    if (maxColumnSizeAttribute != null)
                    {
                        dbMaxColumnSizeAttribute = maxColumnSizeAttribute;
                        continue;
                    }
                    DbFixedColumnSizeAttribute fixedColumnSizeAttribute = mappingAttribute as DbFixedColumnSizeAttribute;
                    if (fixedColumnSizeAttribute != null)
                    {
                        dbFixedColumnSizeAttribute = fixedColumnSizeAttribute;
                        continue;
                    }
                    DbColumnTypeAttribute columnTypeAttribute = mappingAttribute as DbColumnTypeAttribute;
                    if (columnTypeAttribute != null)
                    {
                        dbColumnTypeAttribute = columnTypeAttribute;
                        continue;
                    }
                    DbIndexableAttribute indexableAttribute = mappingAttribute as DbIndexableAttribute;
                    if (indexableAttribute != null)
                    {
                        dbIndexableAttribute = indexableAttribute;
                        continue;
                    }
                    DbNoLoadAttribute noLoadAttribute = mappingAttribute as DbNoLoadAttribute;
                    if (noLoadAttribute != null)
                    {
                        dbNoLoadAttribute = noLoadAttribute;
                        continue;
                    }
                    CollectionUtils.Add(mappingAttribute, ref unrecognizedAttributes);
                }
                if (unrecognizedAttributes != null)
                {
                    throw new MappingException(Utils.GetShortDescriptionList(unrecognizedAttributes),
                                               "The member \"{0}\" of the class \"{1}\" has unrecognized mapping attribute(s).  Please correct the following attributes:",
                                               member.Name, objType.FullName);
                }
                if (dbNotNullAttribute != null)
                {
                    if (newSameTableElementInfo != null)
                    {
                        if (canSetColumnsNotNull)
                        {
                            newSameTableElementInfo.NotNull = true;
                        }
                    }
                    if (newColumn != null)
                    {
                        if (canSetColumnsNotNull)
                        {
                            newColumn.IsNullable = false;
                        }
                    }
                }
                if (dbMaxColumnSizeAttribute != null)
                {
                    if (newColumn != null)
                    {
                        newColumn.ColumnSize = dbMaxColumnSizeAttribute.Size;
                        if (newColumn.MemberType == typeof(string))
                        {
                            newColumn.ColumnType = DbType.AnsiString;
                        }
                    }
                }
                if (dbFixedColumnSizeAttribute != null)
                {
                    if (newColumn != null)
                    {
                        newColumn.ColumnSize = dbFixedColumnSizeAttribute.Size;
                        if (newColumn.MemberType == typeof(string))
                        {
                            newColumn.ColumnType = DbType.AnsiStringFixedLength;
                        }
                    }
                }
                if (dbColumnTypeAttribute != null)
                {
                    if (newColumn != null)
                    {
                        newColumn.ColumnType = dbColumnTypeAttribute.Type;
                    }
                }
                if (dbIndexableAttribute != null)
                {
                    if (newColumn != null)
                    {
                        newColumn.IsIndexable = true;
                    }
                    else
                    {
                        throw new MappingException("The member \"{0}\" of the class \"{1}\" has a DbIndexableAttribute attribute applied to it, but it is not a database column.",
                                                   member.Name, objType.FullName);
                    }
                }
                if (dbNoLoadAttribute != null)
                {
                    if (newColumn != null)
                    {
                        newColumn.NoLoad = true;
                    }
                    else
                    {
                        throw new MappingException("The member \"{0}\" of the class \"{1}\" has a DbNoLoadAttribute attribute applied to it, but it is not a database column.",
                                                   member.Name, objType.FullName);
                    }
                }
            }
            for (int memberIndex = 0; memberIndex < members.Count; ++memberIndex)
            {
                MemberInfo nullMember = members[memberIndex];
                if (nullMember != null)
                {
                    if (nullMember.ReflectedType != null)
                    {
                        throw new MappingException("The member \"{0}.{1}\" was not mapped", nullMember.ReflectedType.Name, nullMember.Name);
                    }
                    else
                    {
                        throw new MappingException("The member \"{0}\" was not mapped", nullMember.Name);
                    }
                }
            }
            if (sameTableAttributes != null)
            {
                foreach (SameTableElementInfo sameTableElementInfo in sameTableAttributes)
                {
                    string description = ReflectionUtils.GetDescription(sameTableElementInfo.Member);
                    if (string.IsNullOrEmpty(description))
                    {
                        description = defaultColumnDescription;
                    }
                    CollectionUtils.Add(sameTableElementInfo.Member, ref parentToMemberChain);
                    ConstructTableMappings(sameTableElementInfo.ValueType, sameTableElementInfo.ValueTypePath,
                                           classTableAttribute, objParentTypePath, parentToMemberChain,
                                           tables, description, sameTableElementInfo.NotNull);
                    parentToMemberChain.RemoveAt(parentToMemberChain.Count - 1);
                }
            }
            if (relationMembers != null)
            {
                foreach (RelationInfo relationInfo in relationMembers)
                {
                    string description = relationInfo.Description ?? defaultColumnDescription;
                    ConstructTableMappings(relationInfo.ValueType, relationInfo.ValueTypePath,
                                           null, null, null, tables, description, true);
                }
            }
        }
        protected T GetAttributeByType<T>(List<MappingAttribute> attributes) where T : MappingAttribute
        {
            if (attributes != null)
            {
                foreach (MappingAttribute attribute in attributes)
                {
                    Type attrType = attribute.GetType();
                    if (typeof(T).IsAssignableFrom(attrType))
                    {
                        return (T)attribute;
                    }
                }
            }
            return null;
        }
        protected string GetColumnDescription(MemberInfo member, string defaultColumnDescription)
        {
            string description = ReflectionUtils.GetDescription(member);
            if (string.IsNullOrEmpty(description))
            {
                if (string.IsNullOrEmpty(defaultColumnDescription))
                {
                    return null;
                }
                description = "Parent: " + defaultColumnDescription;
            }
            return string.Format("{0} ({1})", description, member.Name);
        }
        protected string GetDefaultTableName(Type objType)
        {
            // Defaults to class name if not specified
            string baseTableName = objType.Name;
            if (baseTableName.EndsWith("DataType"))
            {
                baseTableName = baseTableName.Substring(0, baseTableName.Length - "DataType".Length);
            }
            int maxChars = Utils.MAX_TABLE_NAME_CHARS;
            if (!string.IsNullOrEmpty(m_DefaultTableNamePrefix))
            {
                maxChars -= m_DefaultTableNamePrefix.Length;
            }
            string tableName =
                Utils.ShortenDatabaseTableName(Utils.CamelCaseToDatabaseName(baseTableName), maxChars,
                                               m_ShortenNamesByRemovingVowelsFirst, m_FixShortenNameBreakBug,
                                               m_Abbreviations);
            if (!string.IsNullOrEmpty(m_DefaultTableNamePrefix))
            {
                if (!tableName.StartsWith(m_DefaultTableNamePrefix))
                {
                    tableName = m_DefaultTableNamePrefix + tableName;
                }
            }
            return tableName;
        }
        protected List<MemberInfo> GetStaticParentToMemberChain(List<MemberInfo> parentToMemberChain,
                                                                ref List<MemberInfo> staticParentToMemberChain)
        {
            if (CollectionUtils.IsNullOrEmpty(parentToMemberChain))
            {
                return null;
            }
            if (staticParentToMemberChain == null)
            {
                staticParentToMemberChain = new List<MemberInfo>(parentToMemberChain);
            }
            return staticParentToMemberChain;
        }
        protected virtual void ValidateTables(Dictionary<string, Table> tables)
        {
            // Clean up any missing foreign key references
            foreach (Table table in tables.Values)
            {
                foreach (ForeignKeyColumn foreignKeyColumn in table.ForeignKeys)
                {
                    if (string.IsNullOrEmpty(foreignKeyColumn.ForeignTableName))
                    {
                        // Determine the foreign key table and column by looking for the single table that
                        // has a relation column (one-to-one, one-to-many) with a type that matches this 
                        // table's root type
                        if (foreignKeyColumn.ForeignTable != null)
                        {
                            throw new MappingException("The member \"{0}\" of the class \"{1}\" has an empty ForeignTableName, but ForeignTable != null.",
                                                       foreignKeyColumn.MemberInfo.Name, foreignKeyColumn.MemberInfo.ReflectedType.FullName);
                        }
                        Type tableRootType = foreignKeyColumn.Table.TableRootType;
                        if (tableRootType == null)
                        {
                            throw new MappingException("tableRootType == null for table \"{0}\"", foreignKeyColumn.Table.TableName);
                        }
                        Table foreignTable = null;
                        Column foreignColumn = null;
                        foreach (Table curTable in tables.Values)
                        {
                            foreach (Relation relation in curTable.Relations)
                            {
                                if (tableRootType == relation.MemberValueType)
                                {
                                    if (foreignTable != null)
                                    {
                                        throw new MappingException("More than one table is mapped to type \"{0}\"", tableRootType.FullName);
                                    }
                                    if (relation.ParentTable != curTable)
                                    {
                                        throw new MappingException("relation.ParentTable != curTable");
                                    }
                                    if (string.IsNullOrEmpty(relation.ParentColumnName))
                                    {
                                        // Means mapped to primary key of parent table
                                        if (relation.ParentColumn != null)
                                        {
                                            throw new MappingException("relation.ParentColumn != null");
                                        }
                                        relation.ParentColumn = relation.ParentTable.GetSinglePrimaryKey();
                                        relation.ParentColumnName = relation.ParentColumn.ColumnName;
                                    }
                                    else
                                    {
                                        if (relation.ParentColumn == null)
                                        {
                                            throw new MappingException("relation.ParentColumn == null");
                                        }
                                    }
                                    foreignTable = relation.ParentTable;
                                    foreignColumn = relation.ParentColumn;
                                }
                            }
                        }
                        if (foreignTable == null)
                        {
                            throw new MappingException("The member \"{0}\" of the class \"{1}\" has a ForeignKeyAttribute attribute applied to it (without a table name) that references a table that cannot be found.",
                                                       foreignKeyColumn.MemberInfo.Name, foreignKeyColumn.MemberInfo.ReflectedType.FullName);
                        }
                        foreignKeyColumn.ForeignTable = foreignTable;
                        foreignKeyColumn.ForeignTableName = foreignTable.TableName;
                        if (string.IsNullOrEmpty(foreignKeyColumn.ForeignColumnName))
                        {
                            if (foreignKeyColumn.ForeignColumn != null)
                            {
                                throw new MappingException("The member \"{0}\" of the class \"{1}\" has an empty ForeignColumnName, but ForeignColumn != null.",
                                                           foreignKeyColumn.MemberInfo.Name, foreignKeyColumn.MemberInfo.ReflectedType.FullName);
                            }
                            foreignKeyColumn.ForeignColumn = foreignColumn;
                            foreignKeyColumn.ForeignColumnName = foreignColumn.ColumnName;
                        }
                        else
                        {
                            if (foreignKeyColumn.ForeignColumnName != foreignColumn.ColumnName)
                            {
                                throw new MappingException("foreignKeyColumn.ForeignColumnName != foreignColumn.ColumnName");
                            }
                        }
                    }
                    if (foreignKeyColumn.MemberInfo.Name == "_FK")
                    {
                        foreignKeyColumn.ColumnName = foreignKeyColumn.ForeignColumnName;
                    }
                }
            }
            foreach (Table table in tables.Values)
            {
                if (table.Columns.Count == 0)
                {
                    throw new MappingException("A table was specified that doesn't have any mapped columns: {0}",
                                               table.TableName);
                }
                if (table.TableRootType == null)
                {
                    throw new MappingException("table.TableRootType == null for table: {0}", table.TableName);
                }
                if (CollectionUtils.IsNullOrEmpty(table.PrimaryKeys) || (table.PrimaryKeys.Count != 1))
                {
                    throw new MappingException("table.PrimaryKeys.Count is not equal to 1 for table: {0}", table.TableName);
                }
                table.ValidateUniqueColumnNames();
                foreach (Column column in table.Columns)
                {
                    if (column.Table != table)
                    {
                        throw new InvalidOperationException();
                    }
                    if (column.IsForeignKey)
                    {
                        // Check that we reference the correct parent table and field
                        ForeignKeyColumn foreignKeyColumn = (ForeignKeyColumn)column;
                        Table foreignTable;
                        if (!tables.TryGetValue(foreignKeyColumn.ForeignTableName, out foreignTable))
                        {
                            throw new MappingException("The member \"{0}\" of the class \"{1}\" has a ForeignKeyAttribute attribute applied to it that references a table that is not mapped: \"{2}\".",
                                                       column.MemberInfo.Name, column.MemberInfo.ReflectedType.FullName,
                                                       foreignKeyColumn.ForeignTableName);
                        }
                        Column foreignColumn = null;
                        if (string.IsNullOrEmpty(foreignKeyColumn.ForeignColumnName))
                        {
                            // Means mapped to primary key of foreign table
                            ICollection<PrimaryKeyColumn> primaryKeys = foreignTable.PrimaryKeys;
                            if (primaryKeys.Count == 0)
                            {
                                throw new MappingException("The member \"{0}\" of the class \"{1}\" has a foreign key attribute applied to it, but the foreign table does not have a primary key.",
                                                           foreignKeyColumn.MemberInfo.Name, foreignKeyColumn.MemberInfo.ReflectedType.FullName);
                            }
                            else if (primaryKeys.Count > 1)
                            {
                                throw new MappingException("The member \"{0}\" of the class \"{1}\" has a foreign key attribute applied to it, but the foreign table has more than one primary key.",
                                                          foreignKeyColumn.MemberInfo.Name, foreignKeyColumn.MemberInfo.ReflectedType.FullName);
                            }
                            foreach (PrimaryKeyColumn primaryKeyColumn in primaryKeys)
                            {
                                foreignColumn = primaryKeyColumn;
                                foreignKeyColumn.ForeignColumnName = foreignColumn.ColumnName;
                                break;  // Get the one and only element
                            }
                        }
                        else if (!foreignTable.TryGetColumn(foreignKeyColumn.ForeignColumnName, out foreignColumn))
                        {
                            throw new MappingException("The member \"{0}\" of the class \"{1}\" has a ForeignKeyAttribute attribute applied to it that references a table with a column that is not mapped: \"{2}.{3}\".",
                                                       column.MemberInfo.Name, column.MemberInfo.ReflectedType.FullName,
                                                       foreignKeyColumn.ForeignTableName, foreignKeyColumn.ForeignColumnName);
                        }
                        if ((column.ColumnType == null) && (column.ColumnSize == 0))
                        {
                            // If not specified, default is to assign to the foreign key reference values
                            column.ColumnType = foreignColumn.ColumnType;
                            column.ColumnSize = foreignColumn.ColumnSize;
                        }
                        else
                        {
                            if (foreignColumn.ColumnType != column.ColumnType)
                            {
                                throw new MappingException("The member \"{0}\" of the class \"{1}\" has a ForeignKeyAttribute attribute applied to it that references a table with a column, \"{2}.{3},\" that does not have the same database type: \"{4}\" vs. \"{5}.\"",
                                                           column.MemberInfo.Name, column.MemberInfo.ReflectedType.FullName,
                                                           foreignKeyColumn.ForeignTableName, foreignKeyColumn.ForeignColumnName,
                                                           foreignColumn.ColumnType.ToString(), column.ColumnType.ToString());
                            }
                            if (foreignColumn.ColumnSize != column.ColumnSize)
                            {
                                throw new MappingException("The member \"{0}\" of the class \"{1}\" has a ForeignKeyAttribute attribute applied to it that references a table with a column, \"{2}.{3},\" that does not have the same database size: \"{4}\" vs. \"{5}.\"",
                                                           column.MemberInfo.Name, column.MemberInfo.ReflectedType.FullName,
                                                           foreignKeyColumn.ForeignTableName, foreignKeyColumn.ForeignColumnName,
                                                           foreignColumn.ColumnSize.ToString(), column.ColumnSize.ToString());
                            }
                        }
                        foreignKeyColumn.ForeignTable = foreignTable;
                        foreignKeyColumn.ForeignColumn = foreignColumn;
                    }
                    if (column.ColumnType == null)
                    {
                        throw new MappingException("The member \"{0}\" of the class \"{1}\" has a null ColumnType",
                                                   column.MemberInfo.Name, column.MemberInfo.ReflectedType.FullName);
                    }
                }
                Dictionary<string, Relation> memberPathToRelation = new Dictionary<string, Relation>();
                foreach (Relation relation in table.Relations)
                {
                    if (relation.ParentTable != table)
                    {
                        throw new InvalidOperationException();
                    }
                    if (relation.ChildTable == null)
                    {
                        // Look for a table that has the relation object type as its root object
                        Table childTable = null;
                        foreach (Table relationTable in tables.Values)
                        {
                            if (relationTable.TableRootType == relation.MemberValueType)
                            {
                                if (childTable != null)
                                {
                                    throw new MappingException("Found more that one table with a root type if \"{0}\" applied to it.",
                                                               relation.MemberValueType.FullName);
                                }
                                childTable = relationTable;
                            }
                        }
                        if (childTable == null)
                        {
                            throw new MappingException("Could not find a table with a root type if \"{0}\" applied to it.",
                                                       relation.MemberValueType.FullName);
                        }
                        relation.ChildTable = childTable;
                    }
                    Column childColumn = null;
                    if (!string.IsNullOrEmpty(relation.ChildForeignKeyColumnName))
                    {
                        if (!relation.ChildTable.TryGetColumn(relation.ChildForeignKeyColumnName, out childColumn))
                        {
                            throw new MappingException("The member \"{0}\" of the class \"{1}\" has a relation attribute applied to it that references a table with a column that is not mapped: \"{2}.{3}\".",
                                                       relation.MemberInfo.Name, relation.MemberInfo.ReflectedType.FullName,
                                                       relation.ChildTable.TableName, relation.ChildForeignKeyColumnName);
                        }
                    }
                    else
                    {
                        if (!relation.ChildTable.TryGetForeignKeyColumn(relation.ParentTable.TableName, out childColumn))
                        {
                            throw new MappingException("The member \"{0}\" of the class \"{1}\" has a relation attribute applied to it that references a table with a missing foreign column: \"{2}\".",
                                                       relation.MemberInfo.Name, relation.MemberInfo.ReflectedType.FullName,
                                                       relation.ChildTable.TableName);
                        }
                    }
                    if (!childColumn.IsForeignKey)
                    {
                        throw new MappingException("The member \"{0}\" of the class \"{1}\" has a relation attribute applied to it that references a table with a column that is not a foreign key column: \"{2}.{3}\".",
                                                   relation.MemberInfo.Name, relation.MemberInfo.ReflectedType.FullName,
                                                   relation.ChildTable.TableName, relation.ChildForeignKeyColumnName);
                    }
                    relation.ChildForeignKeyColumn = childColumn as ForeignKeyColumn;
                    if (string.IsNullOrEmpty(relation.ChildForeignKeyColumnName))
                    {
                        if (string.IsNullOrEmpty(relation.ChildForeignKeyColumn.ColumnName))
                        {
                            throw new MappingException("string.IsNullOrEmpty(relation.ChildForeignKeyColumn.ColumnName)");
                        }
                        relation.ChildForeignKeyColumnName = relation.ChildForeignKeyColumn.ColumnName;
                    }
                    Column parentColumn = null;
                    if (string.IsNullOrEmpty(relation.ParentColumnName))
                    {
                        // Means mapped to primary key of parent table
                        parentColumn = relation.ParentTable.GetSinglePrimaryKey();
                        relation.ParentColumnName = parentColumn.ColumnName;
                    }
                    else
                    {
                        if (!relation.ParentTable.TryGetColumn(relation.ParentColumnName, out parentColumn))
                        {
                            throw new MappingException("The member \"{0}\" of the class \"{1}\" has a relation attribute applied to it with a ParentColumnName of \"{2}\" specified, but the parent table \"{3}\" does not define the column.",
                                                       relation.MemberInfo.Name, relation.MemberInfo.ReflectedType.FullName,
                                                       relation.ParentColumnName, relation.ParentTable.TableName);
                        }
                    }
                    relation.ParentColumn = parentColumn;
                    Relation existingRelation;
                    if (memberPathToRelation.TryGetValue(relation.MemberInfoPath, out existingRelation))
                    {
                        throw new MappingException("The member \"{0}\" of the class \"{1}\" has more than one relation attribute applied to it: \"{2}\" and \"{3}\"",
                                                   relation.MemberInfo.Name, relation.MemberInfo.ReflectedType.FullName,
                                                   existingRelation.ToString(), relation.ToString());
                    }
                    memberPathToRelation.Add(relation.MemberInfoPath, relation);
                }
            }
        }
        protected List<MappingAttribute> GetMappingAttributesForType(Type type, string typePath)
        {
            return AppendAppliedAttributes(type, string.Empty, typePath,
                                           Utils.GetMappingAttributesForType(type));
        }
        protected List<MappingAttribute> GetMappingAttributesForMember(MemberInfo member, string memberPath)
        {
            return AppendAppliedAttributes(member.ReflectedType, member.Name, memberPath,
                                           Utils.GetMappingAttributesForMember(member));
        }
        protected void AppendAppliedAttributes(Type type, string memberName, ref List<MappingAttribute> attributes)
        {
            Dictionary<string, List<MappingAttribute>> typeAttributes;
            List<MappingAttribute> mappingAttributes;
            if (m_AppliedAttributes.TryGetValue(type, out typeAttributes) &&
                typeAttributes.TryGetValue(memberName, out mappingAttributes))
            {
                foreach (MappingAttribute mappingAttribute in mappingAttributes)
                {
                    CollectionUtils.Add(mappingAttribute.ShallowCopy(), ref attributes);
                }
            }
            if (m_InheritAppliedAttributes && (type.BaseType != typeof(object)))
            {
                AppendAppliedAttributes(type.BaseType, memberName, ref attributes);
            }
        }
        protected List<MappingAttribute> AppendAppliedAttributes(Type type, string memberName, string objectPath,
                                                                 List<MappingAttribute> attributes)
        {
            if (m_AppliedAttributes != null)
            {
                AppendAppliedAttributes(type, memberName, ref attributes);
            }
            if (m_AppliedPathAttributes != null)
            {
                foreach (AppliedPathAttributeInfo appliedPathAttributeInfo in m_AppliedPathAttributes)
                {
                    if (objectPath.EndsWith(appliedPathAttributeInfo.RelativePath))
                    {
                        if ((objectPath.Length == appliedPathAttributeInfo.RelativePath.Length) ||
                             ((objectPath.Length > appliedPathAttributeInfo.RelativePath.Length) &&
                              (objectPath[objectPath.Length - appliedPathAttributeInfo.RelativePath.Length - 1] == '.')))
                        {
                            CollectionUtils.Add(appliedPathAttributeInfo.MappingAttribute.ShallowCopy(), ref attributes);
                        }
                    }
                }
            }
            if (m_NamePostfixAppliedAttributes != null)
            {
                foreach (KeyValuePair<string, MappingAttribute> pair in m_NamePostfixAppliedAttributes)
                {
                    if (memberName.EndsWith(pair.Key))
                    {
                        if (!CollectionUtils.ContainsElementOfType(attributes, pair.Value.GetType()))
                        {
                            CollectionUtils.Add(pair.Value.ShallowCopy(), ref attributes);
                        }
                    }
                }
            }
            return attributes;
        }
        protected Dictionary<string, ObjectPath> ConstructObjectPaths(Dictionary<string, Table> tables)
        {
            Dictionary<string, ObjectPath> objectPaths = new Dictionary<string, ObjectPath>();
            foreach (Table table in tables.Values)
            {
                foreach (Column column in table.Columns)
                {
                    ObjectPath objectPath;
                    if (!objectPaths.TryGetValue(column.ParentInfoPath, out objectPath))
                    {
                        objectPath = new ObjectPath(column.ParentInfoPath);
                        objectPaths.Add(column.ParentInfoPath, objectPath);
                    }
                    objectPath.AddColumn(column);
                }
                foreach (Relation relation in table.Relations)
                {
                    ObjectPath objectPath;
                    if (!objectPaths.TryGetValue(relation.ParentInfoPath, out objectPath))
                    {
                        objectPath = new ObjectPath(relation.ParentInfoPath);
                        objectPaths.Add(relation.ParentInfoPath, objectPath);
                    }
                    objectPath.AddRelation(relation);
                }
            }
            foreach (ObjectPath objectPath in objectPaths.Values)
            {
                foreach (Relation relation in objectPath.Relations)
                {
                    ObjectPath childElement;
                    if (!objectPaths.TryGetValue(relation.MemberInfoPath, out childElement))
                    {
                        throw new MappingException("The relation \"{0}\" cannot be resolved to an object path.",
                                                   relation.ToString());
                    }
                    if (childElement.TableInfo.TableName != relation.ChildTable.TableName)
                    {
                        throw new MappingException("The relation \"{0}\" cannot be resolved to a valid table.",
                                                   relation.ToString());
                    }
                }
            }
            return objectPaths;
        }
        protected virtual Column CreateColumn(ColumnAttribute columnAttribute,
                                              MemberInfo member, string memberPath,
                                              MemberInfo isSpecifiedMember,
                                              Type tableRootType, Dictionary<string, Table> tables)
        {
            Table table;
            Column sameNameColumn = null;
            if (!tables.TryGetValue(columnAttribute.TableName, out table))
            {
                table = new Table(columnAttribute.TableName, tableRootType);
                tables.Add(columnAttribute.TableName, table);
            }
            else
            {
                if (table.TableRootType == null)
                {
                    table.TableRootType = tableRootType;
                }
                if (table.TryGetColumn(columnAttribute.ColumnName, out sameNameColumn))
                {
                    if (sameNameColumn.IsForeignKey || sameNameColumn.IsPrimaryKey)
                    {
                        //??
                        //throw new MappingException("The table \"{0}\" has more than one column named \"{1}\"",
                        //                           table.TableName, columnAttribute.ColumnName);
                    }
                    string sameNameMemberPath = sameNameColumn.MemberInfoPath;
                    int startIndex = 0;
                    while (memberPath[startIndex] == sameNameMemberPath[startIndex])
                    {
                        ++startIndex;
                    }
                    int endIndex = memberPath.IndexOf('.', startIndex + 1);
                    if (endIndex < 0)
                    {
                        endIndex = memberPath.Length - 1;
                    }
                    if (memberPath[startIndex] != '.')
                    {
                        startIndex = memberPath.LastIndexOf('.', startIndex);
                        if (startIndex < 0)
                        {
                            startIndex = 0;
                        }
                        else
                        {
                            ++startIndex;
                        }
                    }
                    if (memberPath  == "Windsor.Node2008.WNOSPlugin.TRI_40.TRIDataType.Submission.Facility.GeographicLocationDescription.CoordinateDataSource.CoordinateDataSourceCodeListIdentifier.Value")
                    {
                    } //??
                    string memberPrefix =
                        Utils.ShortenDatabaseTableName(Utils.CamelCaseToDatabaseName(memberPath.Substring(startIndex, endIndex - startIndex)),
                                                       m_ShortenNamesByRemovingVowelsFirst, m_FixShortenNameBreakBug, m_Abbreviations);
                    if (memberPrefix != null)
                    {
                        columnAttribute.ColumnName = Utils.ShortenDatabaseTableName(memberPrefix + '_' + columnAttribute.ColumnName,
                                                                                    m_ShortenNamesByRemovingVowelsFirst, m_FixShortenNameBreakBug,
                                                                                    null);
                    }
                    while (table.TryGetColumn(columnAttribute.ColumnName, out sameNameColumn))
                    {
                        columnAttribute.ColumnName = Utils.ShortenDatabaseName(columnAttribute.ColumnName, columnAttribute.ColumnName.Length - 1,
                                                                               m_ShortenNamesByRemovingVowelsFirst, m_FixShortenNameBreakBug,
                                                                               null);
                    }
                }
            }
            return table.AddColumn(member, memberPath, isSpecifiedMember, columnAttribute);
        }
        protected virtual Relation CreateRelation(RelationAttribute relationAttribute,
                                                  MemberInfo member, string memberPath,
                                                  Type memberValueType, Dictionary<string, Table> tables)
        {
            Table parentTable;
            if (!tables.TryGetValue(relationAttribute.ParentTableName, out parentTable))
            {
                parentTable = new Table(relationAttribute.ParentTableName, null);
                tables.Add(relationAttribute.ParentTableName, parentTable);
            }
            Table childTable = null;
            if (!string.IsNullOrEmpty(relationAttribute.ChildTableName))
            {
                if (!tables.TryGetValue(relationAttribute.ChildTableName, out childTable))
                {
                    childTable = new Table(relationAttribute.ChildTableName, null);
                    tables.Add(relationAttribute.ChildTableName, childTable);
                }
            }
            return parentTable.AddRelation(childTable, member, memberPath, memberValueType,
                                           relationAttribute);
        }
        public Dictionary<string, Table> Tables
        {
            get { return m_Tables; }
        }
        public Dictionary<string, ObjectPath> ObjectPaths
        {
            get { return m_ObjectPaths; }
        }
        public override string ToString()
        {
            return ReflectionUtils.GetPublicPropertiesString(this);
        }
        public string DefaultDecimalCreateString
        {
            get { return m_DefaultDecimalCreateString; }
            set { m_DefaultDecimalCreateString = value; }
        }
        public string DefaultFloatCreateString
        {
            get { return m_DefaultFloatCreateString; }
            set { m_DefaultFloatCreateString = value; }
        }
        public string DefaultDoubleCreateString
        {
            get { return m_DefaultDoubleCreateString; }
            set { m_DefaultDoubleCreateString = value; }
        }
        public string DefaultTableNamePrefix
        {
            get { return m_DefaultTableNamePrefix; }
            set { m_DefaultTableNamePrefix = value; }
        }

        protected virtual void ConstructTableMappings(Type rootType)
        {
            m_InheritAppliedAttributes = GetInheritAppliedAttributes(rootType);
            m_Abbreviations = ConstructAbbreviations(rootType);
            m_DefaultStringDbValues = GetDefaultDbStringValues(rootType);
            m_ElementNamePostfixToLength = GetElementNamePostfixToLength(rootType);
            m_DefaultTableNamePrefix = GetDefaultTableNamePrefix(rootType);
            m_DefaultDecimalCreateString = GetDefaultDecimalPrecision(rootType);
            m_DefaultFloatCreateString = GetDefaultFloatPrecision(rootType);
            m_DefaultDoubleCreateString = GetDefaultDoublePrecision(rootType);
            m_AppliedAttributes = GetAppliedAttributes(rootType);
            m_AppliedPathAttributes = GetAppliedPathAttributes(rootType);
            m_NamePostfixAppliedAttributes = GetNamePostfixAppliedAttributes(rootType);
            m_ShortenNamesByRemovingVowelsFirst = GetShortenNamesByRemovingVowelsFirst(rootType);
            m_FixShortenNameBreakBug = GetFixShortenNameBreakBugAttribute(rootType);
            m_UseTableNameForDefaultPrimaryKeys =
                GetUseTableNameForDefaultPrimaryKeysAttribute(rootType);

            if (!string.IsNullOrEmpty(m_DefaultTableNamePrefix))
            {
                if (m_DefaultTableNamePrefix[m_DefaultTableNamePrefix.Length - 1] != '_')
                {
                    m_DefaultTableNamePrefix += '_';
                }
            }
            m_Tables = new Dictionary<string, Table>();
            ConstructTableMappings(rootType, rootType.FullName, null, null, null, m_Tables, null, true);
            ValidateTables(m_Tables);
            m_ObjectPaths = ConstructObjectPaths(m_Tables);
        }
        protected virtual Dictionary<string, string> ConstructAbbreviations(Type rootType)
        {
            AbbreviationsAttribute attr = GetGlobalAttribute<AbbreviationsAttribute>(rootType);
            if (attr == null)
            {
                attr = new AbbreviationsAttribute(
                    "APPORTIONMENT", "APPR",
                    "NAICSPRIMARY", "NAICS_PRI",
                    "SICPRIMARY", "SIC_PRI",
                    "SICCODE", "SIC_CODE",
                    "SUMMARY", "SUMM",
                    "EXCLUDED", "EXCL",
                    "PARAMETER", "PARAM",
                    "TRIBAL", "TRIB",
                    "DIMENSION", "DIM",
                    "DETAILS", "DTLS",
                    "MEASURE", "MEAS",
                    "ALTERNATIVE", "ALT",
                    "ELECTRONIC", "ELEC",
                    "TELEPHONE", "TELE",
                    "VERIFICATION", "VERF",
                    "COMMENTS", "COMM",
                    "STATUS", "STAT",
                    "QUALITY", "QLTY",
                    "UPDATED", "UPDT",
                    "EXTENSION", "EXT",
                    "DETERMINE", "DETR",
                    "QUALIFIER", "QUAL",
                    "QUALIFICATION", "QUAL",
                    "LOCALITY", "LOCA",
                    "AFFILIATION", "AFFL",
                    "AFFILIATE", "AFFL",
                    "SUPPLEMENTAL", "SUPP",
                    "MAILING", "MAIL",
                    "INTEREST", "INTR",
                    "INDIVIDUAL", "INDV",
                    "ORGANIZATION", "ORG",
                    "COUNTY", "CNTY",
                    "ENVIRONMENTAL", "ENVR",
                    "ENVIRONMENT", "ENVR",
                    "ORIGINATING", "ORIG",
                    "PARTNER", "PART",
                    "PRECISION", "PREC",
                    "RESULT", "RSLT",
                    "DEVIATIONS", "DEVI",
                    "ACCURACY", "ACC",
                    "ADDRESS", "ADDR",
                    "POSTAL", "POST",
                    "COLLECTION", "COLL",
                    "STATE", "STA",
                    "COUNTRY", "CTRY",
                    "ACRONYM", "ACRO",
                    "PRIMARY", "PRI",
                    "FEDERAL", "FED",
                    "AGENCY", "AGN",
                    "METHOD", "METH",
                    "INFORMATION", "INFO",
                    "DESCRIPTION", "DESC",
                    "DISTRICT", "DIST",
                    "CONGRESSIONAL", "CONG",
                    "LEGISLATIVE", "LEGI",
                    "HUCCODE", "HUC_CODE",
                    "IDENTIFICATION", "IDEN",
                    "CONTEXT", "CONT",
                    "URLTEXT", "URL_TEXT",
                    "VERTICAL", "VERT",
                    "VALUE", "VAL",
                    "VERSION", "VERS",
                    "REGISTRY", "REG",
                    "WEIGHT", "WGHT",
                    "QUANTITY", "QNTY",
                    "STRUCTURE", "STRU",
                    "CONSTRUCTION", "CONST",
                    "COMPARTMENT", "COMPART",
                    "INSTALLATION", "INSTALL",
                    "NUMBER", "NUM",
                    "SECONDARY", "SEC",
                    "CONTAINMENT", "CONT",
                    "INDICATOR", "IND",
                    "CHEMICAL", "CHEM",
                    "SUBSTANCE", "SUBS",
                    "IDENTITY", "IDEN",
                    "CONFIDENTIAL", "CONF",
                    "EPACHEMICAL", "EPA_CHEM",
                    "CASREGISTRY", "CAS_REG",
                    "FACILITY", "FAC",
                    "LOCATION", "LOC",
                    "POSITION", "POS",
                    "ACTIVITY", "ACT",
                    "IDENTIFIER", "IDEN",
                    "EXEMPTION", "EXEMP",
                    "INJECTION", "INJEC",
                    "AQUIFER", "AQUIF",
                    "HIGH", "HI",
                    "LOW", "LO",
                    "PRIORITY", "PRI",
                    "SOURCE", "SRC",
                    "TEXT", "TXT",
                    "OPERATING", "OPER",
                    "GEOGRAPHIC", "GEO",
                    "REFERENCE", "REF",
                    "POINT", "PT",
                    "HORIZONTAL", "HORZ",
                    "COORDINATE", "COORD",
                    "COORDINATES", "COORD",
                    "SYSTEM", "SYS",
                    "RETURN", "RTN",
                    "COMPLIANCE", "COMPL",
                    "INSPECTION", "INSP",
                    "MONITORING", "MONTR",
                    "MECHANICAL", "MECH",
                    "INTEGRITY", "INTEG",
                    "REASON", "RSN",
                    "ACTION", "ACT",
                    "REMEDIAL", "REM",
                    "ENGINEERING", "ENGR",
                    "PERIMETER", "PERM",
                    "MAXIMUM", "MAX",
                    "MINIMUM", "MIN",
                    "NUMERIC", "NUM",
                    "PERMITTED", "PERM",
                    "VOLUME", "VOL",
                    "INJECT", "INJ",
                    "GEOLOGY", "GEO",
                    "BOTTOM", "BOT",
                    "ZONE", "ZN",
                    "TEST", "TST",
                    "LITHOLOGIC", "LITH",
                    "INJECTIONE", "INJ",
                    "PERMEABILITY", "PERM",
                    "CONFINING", "CONF",
                    "POROSITY", "POR",
                    "PERCENT", "PCNT",
                    "NAICSCODE", "NAICS_CODE",
                    "ICISCOMPLIANCE", "ICIS_COMPL",
                    "ICISMOANAME", "ICIS_MOA_NAME",
                    "ICISREGIONAL", "ICIS_RGN",
                    "USDWDEPTH", "USDW_DEPTH",
                    "PERCENTOF", "PCNT",
                    "PRODUCING", "PROD",
                    "UNITOF", "UNT",
                    "WITHIN", "WTIN",
                    "ATTACHMENT", "ATCH",
                    "CONTENT", "CONT",
                    "EMISSIONS", "EMIS",
                    "EMISSION", "EMIS",
                    "DESIGN", "DSGN",
                    "CAPACITY", "CAP",
                    "CONTROL", "CTRL",
                    "APPROACH", "APCH",
                    "CAPTURE", "CAP",
                    "EFFICIENCY", "EFCY",
                    "EFFECTIVENESS", "EFCT",
                    "PENETRATION", "PEN",
                    "POLLUTANT", "POLT",
                    "MEASURES", "MEAS",
                    "REDUCTION", "REDC",
                    "PROCESS", "PROC",
                    "REPORTING", "RPT",
                    "PERIOD", "PRD",
                    "CALCULATION", "CALC",
                    "PARAM", "PARM",
                    "NUMERATOR", "NUM",
                    "DENOMINATOR", "DEN",
                    "FACTOR", "FAC",
                    "RELEASE", "REL",
                    "STACK", "STK",
                    "HEIGHT", "HGT",
                    "LENGTH", "LEN",
                    "WIDTH", "WID",
                    "DIAMETER", "DIA",
                    "VELOCITY", "VEL",
                    "TEMPERATURE", "TMP",
                    "DISTANCE", "DIST",
                    "FUGITIVE", "FGTV",
                    "CONSUMPTION", "CONS",
                    "AMOUNTOF", "AMT",
                    "CONSUMED", "CONS",
                    "THOUSAND", "THSD",
                    "MOISTURE", "MOIS",
                    "FINDING", "FIND",
                    "REGULATORY", "RGTRY",
                    "REGULATION", "RGLN",
                    "COMMENT", "CMNT",
                    "PROGRAM", "PROG",
                    "EFFECTIVE", "EFFC",
                    "CONSOLIDATION", "CONS",
                    "METHODOLOGY", "METH",
                    "AVERAGE", "AVE",
                    "ACTUAL", "ACTL",
                    "ALGORITHM", "ALGOR",
                    "ASSESSMENT", "ASMT",
                    "CONVERSION", "CONV",
                    "FORMULA", "FORM",
                    "MANAGER", "MGR",
                    "SELECTION", "SELC",
                    "RECURRENCE", "RECUR",
                    "IGNITION", "IGNIT",
                    "ORIENTATION", "ORIEN",
                    "GROUND", "GRND",
                    "CREATION", "CRTN",
                    "SUBMITTAL", "SUBM",
                    "CATEGORY", "CATG",
                    "SECTOR", "SECT",
                    "LATITUDE", "LAT",
                    "LONGITUDE", "LONG",
                    "GEOMETRIC", "GEOM",
                    "OWNERSHIP", "OWNER",
                    "INSIGNIFICANT", "INSIG",
                    "OPERATION", "OPER",
                    "COMMERCIAL", "COMMER",
                    "INVENTORY", "INVEN",
                    "SEQUENCE", "SEQ",
                    "COMMUNICATION", "COMMUN",
                    "PARAMETERS", "PARAMS",
                    "CONFIGURATION", "CONFIG",
                    "EXCEPTION", "EXCPT",
                    "EXCEPTIONS", "EXCPT",
                    "CLASSIFICATION", "CLASS",
                    "HAZARDOUS", "HAZRD",
                    "SUBMISSION", "SUBM",
                    "ENFORCEMENT", "ENFRC",
                    "TRANSACTION", "TRANS",
                    "ATTORNEY", "ATTRY",
                    "CORRECTIVE", "CORCT",
                    "COMPONENT", "COMPT",
                    "RESOLUTION", "RSLN",
                    "DISPOSITION", "DISP",
                    "RESPONSIBLE", "RESP",
                    "SUBORGANIZATION", "SUBORG",
                    "PENALTY", "PNLTY",
                    "PAYMENT", "PYMT",
                    "DEFAULTED", "DFLT",
                    "SCHEDULED", "SCHD",
                    "TECHNICAL", "TECH",
                    "INITIATED", "INIT",
                    "REQUIREMENT", "RQMT",
                    "COMPLETION", "COMP",
                    "DETERMINED", "DTRM",
                    "PROJECT", "PRJT",
                    "EXPENDITURE", "EXPND",
                    "AGREEMENT", "AGMT",
                    "EVALUATION", "EVAL",
                    "CITIZEN", "CTZN",
                    "COMPLAINT", "CPLT",
                    "SAMPLING", "SAMPL",
                    "SUBTITLE", "SUBTL",
                    "HANDLER", "HDLR",
                    "CONSENT", "CNST",
                    "REQUEST", "RQST",
                    "VIOLATION", "VIOL",
                    "RESPONSE", "RESP",
                    "RECEIVED", "RCVD",
                    "COMMITMENT", "COMMIT"
                    );
            }
            AdditionalAbbreviationsAttribute addAttr = GetGlobalAttribute<AdditionalAbbreviationsAttribute>(rootType);
            if ((addAttr != null) && (addAttr.Abbreviations != null))
            {
                foreach (KeyValuePair<string, string> pair in addAttr.Abbreviations)
                {
                    if (attr.Abbreviations == null)
                    {
                        attr.Abbreviations = new Dictionary<string, string>();
                    }
                    attr.Abbreviations.Add(pair.Key, pair.Value);
                }
            }
            return attr.Abbreviations;
        }
        protected virtual DefaultStringDbValuesAttribute GetDefaultDbStringValues(Type rootType)
        {
            DefaultStringDbValuesAttribute attr = GetGlobalAttribute<DefaultStringDbValuesAttribute>(rootType);
            if (attr == null)
            {
                attr = new DefaultStringDbValuesAttribute(DbType.AnsiString, 255);
            }
            return attr;
        }
        protected virtual List<KeyValuePair<string, int>> GetElementNamePostfixToLength(Type rootType)
        {
            DefaultElementNamePostfixLengthsAttribute attr = GetGlobalAttribute<DefaultElementNamePostfixLengthsAttribute>(rootType);
            if (attr == null)
            {
                attr = new DefaultElementNamePostfixLengthsAttribute(
                    "Text", "255",
                    "Name", "128",
                    "Code", "50",
                    "Value", "50",
                    "CodeContext", "50",
                    "Identifier", "50",
                    "UnitName", "50",
                    "PrecisionText", "50",
                    "Number", "20",
                    "Version", "20",
                    "NumberText", "20",
                    "Indicator", "50",
                    "IndividualFullName", "255",
                    "srsDimension", "10",
                    "srsName", "255");
            }
            return (attr == null) ? null : attr.ElementNamePostfixToLength;
        }
        protected virtual string GetDefaultTableNamePrefix(Type rootType)
        {
            DefaultTableNamePrefixAttribute attr = GetGlobalAttribute<DefaultTableNamePrefixAttribute>(rootType);
            return (attr == null) ? null : attr.Prefix;

        }
        protected virtual bool GetShortenNamesByRemovingVowelsFirst(Type rootType)
        {
            ShortenNamesByRemovingVowelsFirstAttribute attr = GetGlobalAttribute<ShortenNamesByRemovingVowelsFirstAttribute>(rootType);
            return (attr != null);
        }
        protected virtual bool GetInheritAppliedAttributes(Type rootType)
        {
            InheritAppliedAttributesAttribute attr = GetGlobalAttribute<InheritAppliedAttributesAttribute>(rootType);
            return (attr != null);
        }
        protected virtual bool GetUseTableNameForDefaultPrimaryKeysAttribute(Type rootType)
        {
            UseTableNameForDefaultPrimaryKeysAttribute attr = 
                GetGlobalAttribute<UseTableNameForDefaultPrimaryKeysAttribute>(rootType);
            return (attr != null);
        }
        protected virtual bool GetFixShortenNameBreakBugAttribute(Type rootType)
        {
            FixShortenNameBreakBugAttribute attr = GetGlobalAttribute<FixShortenNameBreakBugAttribute>(rootType);
            return (attr != null);
        }
        protected virtual string GetDefaultDecimalPrecision(Type rootType)
        {
            DefaultDecimalPrecision attr = GetGlobalAttribute<DefaultDecimalPrecision>(rootType);
            if (attr != null)
            {
                return string.Format("DECIMAL({0},{1})", attr.Precision.ToString(), attr.Scale.ToString());
            }
            else
            {
                return "DECIMAL(12,6)";
            }
        }
        protected virtual string GetDefaultFloatPrecision(Type rootType)
        {
            DefaultFloatPrecisionAttribute attr = GetGlobalAttribute<DefaultFloatPrecisionAttribute>(rootType);
            if (attr != null)
            {
                return string.Format("DECIMAL({0},{1})", attr.Precision.ToString(), attr.Scale.ToString());
            }
            else
            {
                return "FLOAT(24)";
            }
        }
        protected virtual string GetDefaultDoublePrecision(Type rootType)
        {
            DefaultDoublePrecisionAttribute attr = GetGlobalAttribute<DefaultDoublePrecisionAttribute>(rootType);
            if (attr != null)
            {
                return string.Format("DECIMAL({0},{1})", attr.Precision.ToString(), attr.Scale.ToString());
            }
            else
            {
                return "FLOAT(53)";
            }
        }
        protected static A GetGlobalAttribute<A>(Type rootType) where A : Attribute
        {
            object[] attributes = rootType.GetCustomAttributes(typeof(A), false);
            if (attributes.Length == 1)
            {
                return ((A)attributes[0]);
            }
            // Check for static GlobalAttributes class
            attributes = GetStaticClassGlobalAttributes<A>(rootType);
            if (attributes.Length == 1)
            {
                return ((A)attributes[0]);
            }
            attributes = rootType.Assembly.GetCustomAttributes(typeof(A), false);
            if (attributes.Length == 1)
            {
                return ((A)attributes[0]);
            }
            return null;
        }
        protected static object[] GetStaticClassGlobalAttributes<A>(Type rootType) where A : Attribute
        {
            string fullTypeName = rootType.Namespace + ".GlobalAttributes";
            Type globalAttributesType = rootType.Assembly.GetType(fullTypeName);
            if (globalAttributesType != null)
            {
                return globalAttributesType.GetCustomAttributes(typeof(A), false);
            }
            return null;
        }
        protected int GetElementDefaultStringLength(string elementName)
        {
            if (m_ElementNamePostfixToLength != null)
            {
                foreach (KeyValuePair<string, int> pair in m_ElementNamePostfixToLength)
                {
                    if (elementName.EndsWith(pair.Key))
                    {
                        return pair.Value;
                    }
                }
            }
            return 0;
        }
        private Dictionary<Type, Dictionary<string, List<MappingAttribute>>> GetAppliedAttributes(Type rootType)
        {
            Dictionary<Type, Dictionary<string, List<MappingAttribute>>> appliedAttributes = null;
            ConstructAppliedAttributes(rootType.Assembly.GetCustomAttributes(typeof(AppliedAttribute), false),
                                       ref appliedAttributes);
            ConstructAppliedAttributes(GetStaticClassGlobalAttributes<AppliedAttribute>(rootType),
                                       ref appliedAttributes);
            // Root attributes override asssembly-level attributes
            ConstructAppliedAttributes(rootType.GetCustomAttributes(typeof(AppliedAttribute), false),
                                       ref appliedAttributes);

            return appliedAttributes;
        }
        private static List<AppliedPathAttributeInfo> GetAppliedPathAttributes(Type rootType)
        {
            List<AppliedPathAttributeInfo> appliedPathAttributes = null;
            ConstructAppliedPathAttributes(rootType.Assembly.GetCustomAttributes(typeof(AppliedPathAttribute), false),
                                           ref appliedPathAttributes);
            ConstructAppliedPathAttributes(GetStaticClassGlobalAttributes<AppliedPathAttribute>(rootType),
                                           ref appliedPathAttributes);
            // Root attributes override asssembly-level attributes
            ConstructAppliedPathAttributes(rootType.GetCustomAttributes(typeof(AppliedPathAttribute), false),
                                           ref appliedPathAttributes);
            return appliedPathAttributes;
        }
        private static Dictionary<string, MappingAttribute> GetNamePostfixAppliedAttributes(Type rootType)
        {
            Dictionary<string, MappingAttribute> namePostfixAppliedAttributes = null;
            ConstructNamePostfixAppliedAttributes(rootType.Assembly.GetCustomAttributes(typeof(NamePostfixAppliedAttribute), false),
                                                  ref namePostfixAppliedAttributes);
            ConstructNamePostfixAppliedAttributes(GetStaticClassGlobalAttributes<NamePostfixAppliedAttribute>(rootType),
                                                  ref namePostfixAppliedAttributes);
            // Root attributes override asssembly-level attributes
            ConstructNamePostfixAppliedAttributes(rootType.GetCustomAttributes(typeof(NamePostfixAppliedAttribute), false),
                                                  ref namePostfixAppliedAttributes);
            return namePostfixAppliedAttributes;
        }
        protected static void ConstructAppliedAttributes(IList<object> attributes,
                                                         ref Dictionary<Type, Dictionary<string, List<MappingAttribute>>> appliedAttributes)
        {
            if (CollectionUtils.IsNullOrEmpty(attributes))
            {
                return;
            }
            if (appliedAttributes == null)
            {
                appliedAttributes = new Dictionary<Type, Dictionary<string, List<MappingAttribute>>>();
            }
            foreach (AppliedAttribute attribute in attributes)
            {
                if (!string.IsNullOrEmpty(attribute.AppliedToMemberName))
                {
                    if ((attribute.AppliedToType.GetField(attribute.AppliedToMemberName, BindingFlags.Instance | BindingFlags.Public) == null) &&
                        (attribute.AppliedToType.GetProperty(attribute.AppliedToMemberName, BindingFlags.Instance | BindingFlags.Public) == null))
                    {
                        throw new MappingException("Cannot find member \"{0}\" for AppliedAttribute on type \"{1}\"",
                                                   attribute.AppliedToMemberName, attribute.AppliedToType.FullName);
                    }
                }
                // Empty attribute.AppliedToMemberName string means that attribute is applied directly to attribute.AppliedToType instead
                // of one of its members
                Dictionary<string, List<MappingAttribute>> typeAttributes;
                if (!appliedAttributes.TryGetValue(attribute.AppliedToType, out typeAttributes))
                {
                    typeAttributes = new Dictionary<string, List<MappingAttribute>>();
                    appliedAttributes.Add(attribute.AppliedToType, typeAttributes);
                }

                MappingAttribute mappingAttribute = GetMappingAttributeFromAppliedAttribute(attribute);

                if (!typeAttributes.ContainsKey(attribute.AppliedToMemberName))
                {
                    typeAttributes[attribute.AppliedToMemberName] = new List<MappingAttribute>();
                }
                typeAttributes[attribute.AppliedToMemberName].Add(mappingAttribute);
            }
        }
        private static void ConstructAppliedPathAttributes(IList<object> attributes,
                                                           ref List<AppliedPathAttributeInfo> appliedPathAttributes)
        {
            if (CollectionUtils.IsNullOrEmpty(attributes))
            {
                return;
            }
            if (appliedPathAttributes == null)
            {
                appliedPathAttributes = new List<AppliedPathAttributeInfo>();
            }
            foreach (AppliedPathAttribute attribute in attributes)
            {
                MappingAttribute mappingAttribute = GetMappingAttributeFromAppliedAttribute(attribute);

                bool foundIt = false;
                for (int i = 0; i < appliedPathAttributes.Count; ++i)
                {
                    AppliedPathAttributeInfo appliedPathAttributeInfo = appliedPathAttributes[i];
                    if (appliedPathAttributeInfo.RelativePath == attribute.ObjectPath)
                    {
                        appliedPathAttributes[i].MappingAttribute = mappingAttribute;
                        foundIt = true;
                        break;
                    }
                }
                if (!foundIt)
                {
                    appliedPathAttributes.Add(new AppliedPathAttributeInfo(attribute.ObjectPath, mappingAttribute));
                }
            }
        }
        private static void ConstructNamePostfixAppliedAttributes(IList<object> attributes,
                                                                  ref Dictionary<string, MappingAttribute> namePostfixAppliedAttributes)
        {
            if (CollectionUtils.IsNullOrEmpty(attributes))
            {
                return;
            }
            if (namePostfixAppliedAttributes == null)
            {
                namePostfixAppliedAttributes = new Dictionary<string, MappingAttribute>();
            }
            foreach (NamePostfixAppliedAttribute attribute in attributes)
            {
                MappingAttribute mappingAttribute = GetMappingAttributeFromAppliedAttribute(attribute);
                namePostfixAppliedAttributes[attribute.AppliedToMemberNameThatEndsWith] = mappingAttribute;
            }
        }
        private static MappingAttribute GetMappingAttributeFromAppliedAttribute(BaseAppliedAttribute appliedAttribute)
        {
            MappingAttribute mappingAttribute = null;
            if (appliedAttribute.MappedAttributeType == typeof(DbIgnoreAttribute))
            {
                mappingAttribute = new DbIgnoreAttribute();
            }
            else if (appliedAttribute.MappedAttributeType == typeof(DbIndexableAttribute))
            {
                mappingAttribute = new DbIndexableAttribute();
            }
            else if (appliedAttribute.MappedAttributeType == typeof(TableAttribute))
            {
                TableAttribute tableAttribute = new TableAttribute();
                mappingAttribute = tableAttribute;
                if (!CollectionUtils.IsNullOrEmpty(appliedAttribute.Args))
                {
                    foreach (object arg in appliedAttribute.Args)
                    {
                        if (arg is string)
                        {
                            tableAttribute.TableName = arg.ToString();
                        }
                        else
                        {
                            throw new NotImplementedException(string.Format("TableAttribute arg is not implemented: {0}",
                                                                            arg.GetType().FullName));
                        }
                    }
                }
            }
            else if (appliedAttribute.MappedAttributeType == typeof(ColumnAttribute))
            {
                ColumnAttribute columnAttribute = new ColumnAttribute();
                mappingAttribute = columnAttribute;
                if (!CollectionUtils.IsNullOrEmpty(appliedAttribute.Args))
                {
                    foreach (object arg in appliedAttribute.Args)
                    {
                        if (arg is string)
                        {
                            columnAttribute.ColumnName = arg.ToString();
                        }
                        else if (arg is DbType)
                        {
                            columnAttribute.ColumnType = (DbType)arg;
                        }
                        else if (arg is int)
                        {
                            if (columnAttribute.ColumnSize == 0)
                            {
                                columnAttribute.ColumnSize = (int)arg;
                            }
                            else
                            {
                                // Second int is scale
                                columnAttribute.ColumnScale = (int)arg;
                            }
                        }
                        else if (arg is bool)
                        {
                            columnAttribute.IsNullable = (bool)arg;
                        }
                        else
                        {
                            throw new NotImplementedException(string.Format("ColumnAttribute arg is not implemented: {0}",
                                                                            arg.GetType().FullName));
                        }
                    }
                }
            }
            else if (appliedAttribute.MappedAttributeType == typeof(OneToOneAttribute))
            {
                mappingAttribute = new OneToOneAttribute();
            }
            else
            {
                throw new NotImplementedException(string.Format("attribute.MappedAttributeType arg is not implemented: {0}",
                                                                appliedAttribute.MappedAttributeType));
            }
            return mappingAttribute;
        }
        public string GetTableNameForType(Type objectType)
        {
            Table table = GetTableForType(objectType);
            return table.TableName;
        }
        public string GetPrimaryKeyNameForType(Type objectType)
        {
            Table table = GetTableForType(objectType);
            return table.GetSinglePrimaryKey().ColumnName;
        }
        protected Table GetTableForType(Type objectType)
        {
            if (m_Tables == null)
            {
                throw new MappingException("No tables are defined");
            }
            foreach (Table table in m_Tables.Values)
            {
                if (table.TableRootType == objectType)
                {
                    return table;
                }
            }
            throw new MappingException("Could not find table for type \"{0}\"", objectType.FullName);
        }
        private Dictionary<string, Table> m_Tables = new Dictionary<string, Table>();
        private Dictionary<string, ObjectPath> m_ObjectPaths = new Dictionary<string, ObjectPath>();
        private Dictionary<string, string> m_Abbreviations = null;
        private static Dictionary<Type, MappingContext> s_MappingContexts = new Dictionary<Type, MappingContext>();
        private DefaultStringDbValuesAttribute m_DefaultStringDbValues;
        private List<KeyValuePair<string, int>> m_ElementNamePostfixToLength;
        private Dictionary<Type, Dictionary<string, List<MappingAttribute>>> m_AppliedAttributes;
        private List<AppliedPathAttributeInfo> m_AppliedPathAttributes;
        private Dictionary<string, MappingAttribute> m_NamePostfixAppliedAttributes;
        private string m_SpecifiedFieldPostfixName = "Specified";
        private string m_DefaultTableNamePrefix;
        private string m_DefaultDecimalCreateString;
        private string m_DefaultFloatCreateString;
        private string m_DefaultDoubleCreateString;
        private bool m_ShortenNamesByRemovingVowelsFirst;
        private bool m_FixShortenNameBreakBug;
        private bool m_InheritAppliedAttributes;
        private bool m_UseTableNameForDefaultPrimaryKeys;

        public bool UseTableNameForDefaultPrimaryKeys
        {
            get { return m_UseTableNameForDefaultPrimaryKeys; }
            set { m_UseTableNameForDefaultPrimaryKeys = value; }
        }

        public bool FixShortenNameBreakBug
        {
            get { return m_FixShortenNameBreakBug; }
            set { m_FixShortenNameBreakBug = value; }
        }

        public bool ShortenNamesByRemovingVowelsFirst
        {
            get { return m_ShortenNamesByRemovingVowelsFirst; }
            set { m_ShortenNamesByRemovingVowelsFirst = value; }
        }

        private class SameTableElementInfo
        {
            public SameTableElementInfo(string valueTypePath, Type valueType,
                                        MemberInfo member, SameTableAttribute sameTable)
            {
                ValueTypePath = valueTypePath;
                ValueType = valueType;
                Member = member;
                SameTable = sameTable;
            }
            public string ValueTypePath;
            public Type ValueType;
            public SameTableAttribute SameTable;
            public MemberInfo Member;
            public bool NotNull = false;
        }
        private class RelationInfo
        {
            public RelationInfo(string valueTypePath, Type valueType, string description)
            {
                ValueTypePath = valueTypePath;
                ValueType = valueType;
                Description = description;
            }
            public string ValueTypePath;
            public Type ValueType;
            public string Description;
        }
        private class AppliedPathAttributeInfo
        {
            public AppliedPathAttributeInfo(string relativePath, MappingAttribute mappingAttribute)
            {
                RelativePath = relativePath;
                MappingAttribute = mappingAttribute;
            }
            public string RelativePath;
            public MappingAttribute MappingAttribute;
        }
    }
}
