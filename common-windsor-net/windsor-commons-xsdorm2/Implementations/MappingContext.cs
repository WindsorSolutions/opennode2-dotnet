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
using System.IO;

namespace Windsor.Commons.XsdOrm2.Implementations
{
    public class MappingContext
    {
        public static MappingContext GetMappingContext(Type rootType, Type mappingAttributesType)
        {
            return GetMappingContext(rootType, mappingAttributesType, false);
        }
        public static MappingContext GetMappingContext(Type rootType, Type mappingAttributesType, bool inheritMappingAttributes)
        {
            MappingContext mappingContext = null;
            lock (s_MappingContexts)
            {
                s_MappingContexts.TryGetValue(rootType, out mappingContext);
            }
            if (mappingContext == null)
            {
                mappingContext = new MappingContext(rootType, mappingAttributesType, inheritMappingAttributes);
                lock (s_MappingContexts)
                {
                    s_MappingContexts.Add(rootType, mappingContext);
                }
            }
            else
            {
            }
            return mappingContext;
        }
        internal MappingContext(Type rootType, Type mappingAttributesType, bool inheritMappingAttributes)
        {
            m_InheritMappingAttributes = inheritMappingAttributes;
            ConstructTableMappings(rootType, mappingAttributesType);
        }

        protected Table CreateValueTypeChildTable(Type objType, MemberInfo objMemberInfo, string objMemberName, IDictionary<string, Table> tables,
                                                  Table foreignKeyTable)
        {
            ExceptionUtils.ThrowIfNull(foreignKeyTable, "foreignKeyTable");
            ExceptionUtils.ThrowIfNull(objMemberInfo, "objMemberInfo");
            string tableName = string.IsNullOrEmpty(objMemberName) ? GetDefaultTableName(objMemberInfo.Name) : objMemberName;
            Table currentTable = null;
            if (!tables.TryGetValue(tableName, out currentTable))
            {
                currentTable = new Table(tableName, objType);
                currentTable.TableNamePrefix = m_DefaultTableNamePrefix;
                tables.Add(tableName, currentTable);
            }
            if (foreignKeyTable != currentTable)
            {
                currentTable.AddFKTable(foreignKeyTable);
            }
            ColumnAttribute columnAttribute = new ColumnAttribute(false);
            columnAttribute.TableName = tableName;
            ConfigureColumnAttributeNameTypeAndSize(columnAttribute, objType, objMemberInfo.Name);
            Column newColumn = CreateColumn(columnAttribute, null, null, tables);
            if (newColumn != null)
            {
                newColumn.ColumnDescription = GetColumnDescription(objMemberInfo);
                List<MappingAttribute> attributes = GetMappingAttributesForMember(objMemberInfo);
                ApplyMappingAttributesToColumn(newColumn, attributes);
            }
            currentTable.FinishedFirstPassMapping = true;
            return currentTable;
        }
        protected void ApplyMappingAttributesToColumn(Column newColumn, IList<MappingAttribute> attributes)
        {
            foreach (MappingAttribute mappingAttribute in attributes)
            {
                DbMaxColumnSizeAttribute maxColumnSizeAttribute = mappingAttribute as DbMaxColumnSizeAttribute;
                if (maxColumnSizeAttribute != null)
                {
                    newColumn.ColumnSize = maxColumnSizeAttribute.Size;
                    if (newColumn.MemberType == typeof(string))
                    {
                        newColumn.ColumnType = DbType.AnsiString;
                    }
                    continue;
                }
                DbFixedColumnSizeAttribute fixedColumnSizeAttribute = mappingAttribute as DbFixedColumnSizeAttribute;
                if (fixedColumnSizeAttribute != null)
                {
                    newColumn.ColumnSize = fixedColumnSizeAttribute.Size;
                    if (newColumn.MemberType == typeof(string))
                    {
                        newColumn.ColumnType = DbType.AnsiStringFixedLength;
                    }
                    continue;
                }
                DbColumnTypeAttribute columnTypeAttribute = mappingAttribute as DbColumnTypeAttribute;
                if (columnTypeAttribute != null)
                {
                    newColumn.ColumnType = columnTypeAttribute.Type;
                    continue;
                }
                DbColumnScaleAttribute columnScaleAttribute = mappingAttribute as DbColumnScaleAttribute;
                if (columnScaleAttribute != null)
                {
                    newColumn.ColumnSize = columnScaleAttribute.Size;
                    newColumn.ColumnScale = columnScaleAttribute.Scale;
                    continue;
                }
                DbIndexableAttribute indexableAttribute = mappingAttribute as DbIndexableAttribute;
                if (indexableAttribute != null)
                {
                    newColumn.IsIndexable = true;
                    continue;
                }
            }
        }
        protected Table ConstructTableMappings(Type objType, MemberInfo objMemberInfo, string objMemberName,
                                               Table currentTable, SameTableElementInfo sameTableElementInfo,
                                               IDictionary<string, Table> tables,
                                               bool canSetColumnsNotNull, Table foreignKeyTable)
        {
            if (Utils.IsValidColumnType(objType))
            {
                ExceptionUtils.ThrowIfFalse(currentTable == null, "currentTable == null");
                return CreateValueTypeChildTable(objType, objMemberInfo, objMemberName, tables, foreignKeyTable);
            }
            List<MappingAttribute> attributes = GetMappingAttributesForType(objType);
            foreach (MappingAttribute mappingAttribute in attributes)
            {
                if (mappingAttribute is AdditionalCreateIndexAttribute)
                {
                    m_AdditionalCreateIndexAttributes.Add((AdditionalCreateIndexAttribute)mappingAttribute);
                    continue;   // Ignore, already taken care of on root element only
                }
            }

            if (currentTable == null)
            {
                string tableName = GetDefaultTableName(objType);
                if (!tables.TryGetValue(tableName, out currentTable))
                {
                    currentTable = new Table(tableName, objType);
                    currentTable.TableNamePrefix = m_DefaultTableNamePrefix;
                    tables.Add(tableName, currentTable);
                }
            }
            if (foreignKeyTable != null)
            {
                if (foreignKeyTable != currentTable)
                {
                    currentTable.AddFKTable(foreignKeyTable);
                }
            }
            if (currentTable.FinishedFirstPassMapping)
            {
                return currentTable;
            }

            List<MemberInfo> members = Utils.GetPublicMembersForType(objType);
            List<ChildRelationInfo> relationMembers = null;
            List<SameTableElementInfo> childSameTableAttributes = null;
            for (int memberIndex = 0; memberIndex < members.Count; ++memberIndex)
            {
                MemberInfo member = members[memberIndex];
                if (member == null)
                {
                    continue;
                }

                Type valueType = GetMemberValueType(member);

                attributes = GetMappingAttributesForMember(member);
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
                    if ((valueType == typeof(object[])) || (valueType == typeof(object)))
                    {
                        bool isOneToMany = valueType == typeof(object[]);
                        List<XmlElementAttribute> elementAttributes = ReflectionUtils.GetAttributesOfTypeForMember<XmlElementAttribute>(member);
                        List<XmlChoiceIdentifierAttribute> choiceAttributes = ReflectionUtils.GetAttributesOfTypeForMember<XmlChoiceIdentifierAttribute>(member);
                        Dictionary<Type, string> childElements = new Dictionary<Type, string>(elementAttributes.Count);
                        foreach (XmlElementAttribute elementAttribute in elementAttributes)
                        {
                            if (elementAttribute.Type != null)
                            {
                                string elementName = string.IsNullOrEmpty(elementAttribute.ElementName) ? elementAttribute.Type.Name : elementAttribute.ElementName;
                                childElements.Add(elementAttribute.Type, elementName);
                            }
                        }
                        if (childElements.Count == 0)
                        {
                            throw new MappingException("No types found for object[] member: {0}", member.Name);
                        }
                        MemberInfo choiceMember = null;
                        if (!CollectionUtils.IsNullOrEmpty(choiceAttributes))
                        {
                            if (choiceAttributes.Count != 1)
                            {
                                throw new MappingException("More than on ChoiceIdentifier found for object[] member: {0}", member.Name);
                            }
                            int choiceMemberIndex;
                            choiceMember = Utils.FindMemberByName(members, choiceAttributes[0].MemberName, out choiceMemberIndex);
                            if (choiceMember == null)
                            {
                                throw new MappingException("Could not locate ChoiceIdentifier for object[] member: {0}", member.Name);
                            }
                            members[choiceMemberIndex] = null;
                        }
                        string description = ReflectionUtils.GetDescription(member);
                        foreach (KeyValuePair<Type, string> pair in childElements)
                        {
                            CollectionUtils.Add(new ChildRelationInfo(currentTable.TableRootType, pair.Key, member, pair.Value, choiceMember, description, isOneToMany,
                                                                      sameTableElementInfo),
                                                ref relationMembers);
                        }
                        members[memberIndex] = null;
                        continue;
                    }
                    else if ((GetAttributeByType<RelationAttribute>(attributes) == null) &&
                             (GetAttributeByType<SameTableAttribute>(attributes) == null))
                    {
                        if (CollectionUtils.GetCollectionElementType(valueType) == null)
                        {
                            attributes.Add(new OneToOneAttribute());
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
                DbNullAttribute dbNullAttribute = null;
                DbIndexableAttribute dbIndexableAttribute = null;
                DbNoLoadAttribute dbNoLoadAttribute = null;
                DbMaxColumnSizeAttribute dbMaxColumnSizeAttribute = null;
                DbFixedColumnSizeAttribute dbFixedColumnSizeAttribute = null;
                DbColumnTypeAttribute dbColumnTypeAttribute = null;
                DbColumnScaleAttribute dbColumnScaleAttribute = null;
                Column newColumn = null;
                SameTableElementInfo newSameTableElementInfo = null;
                foreach (MappingAttribute mappingAttribute in attributes)
                {
                    ColumnAttribute columnAttribute = mappingAttribute as ColumnAttribute;
                    if (columnAttribute != null)
                    {
                        if (mappingAttribute is PrimaryKeyAttribute)
                        {
                            throw new MappingException("PrimaryKeyAttribute not supported");
                        }
                        if (mappingAttribute is ForeignKeyAttribute)
                        {
                            throw new MappingException("ForeignKeyAttribute not supported");
                        }
                        columnAttribute.TableName = currentTable.TableName;
                        ConfigureColumnAttributeNameTypeAndSize(columnAttribute, valueType, member.Name);
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

                        if (sameTableElementInfo != null)
                        {
                            newColumn = sameTableElementInfo.AddDataColumn(member, isSpecifiedMember, columnAttribute);
                        }
                        else
                        {
                            newColumn = CreateColumn(columnAttribute, member, isSpecifiedMember, tables);
                        }

                        members[memberIndex] = null;
                        if (isSpecifiedMember != null)
                        {
                            members[isSpecifiedMemberIndex] = null;
                        }
                        if (newColumn != null)
                        {
                            newColumn.ColumnDescription = GetColumnDescription(member);
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
                        newSameTableElementInfo = new SameTableElementInfo(currentTable, valueType, member, sameTableElementInfo);
                        CollectionUtils.Add(newSameTableElementInfo, ref childSameTableAttributes);
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
                        Type assignType = null;
                        bool isOneToMany;
                        if (relationAttribute is OneToManyAttribute)
                        {
                            isOneToMany = true;
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
                            isOneToMany = false;
                            if (Utils.IsValidColumnType(valueType) || !valueType.IsClass)
                            {
                                throw new MappingException("The member \"{0}\" of the class \"{1}\" has a OneToOneAttribute applied to it, but the member is not a valid class type.",
                                                           member.Name, objType.FullName);
                            }
                            assignType = valueType;
                        }
                        else
                        {
                            throw new MappingException("Unsupported relationAttribute");
                        }
                        string description = ReflectionUtils.GetDescription(member);
                        CollectionUtils.Add(new ChildRelationInfo(currentTable.TableRootType, assignType, member, null, null, description, isOneToMany, sameTableElementInfo), 
                                            ref relationMembers);
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
                    DbNullAttribute nullAttribute = mappingAttribute as DbNullAttribute;
                    if (nullAttribute != null)
                    {
                        dbNullAttribute = nullAttribute;
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
                    DbColumnScaleAttribute columnScaleAttribute = mappingAttribute as DbColumnScaleAttribute;
                    if (columnScaleAttribute != null)
                    {
                        dbColumnScaleAttribute = columnScaleAttribute;
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
                }
                if (dbNotNullAttribute != null)
                {
                    if (newSameTableElementInfo != null)
                    {
                        if (canSetColumnsNotNull)
                        {
                            newSameTableElementInfo.CanSetColumnsNotNull = true;
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
                if (dbNullAttribute != null)
                {
                    if (newSameTableElementInfo != null)
                    {
                        newSameTableElementInfo.CanSetColumnsNotNull = false;
                    }
                    if (newColumn != null)
                    {
                        newColumn.IsNullable = true;
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
                if (dbColumnScaleAttribute != null)
                {
                    if (newColumn != null)
                    {
                        newColumn.ColumnSize = dbColumnScaleAttribute.Size;
                        newColumn.ColumnScale = dbColumnScaleAttribute.Scale;
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
            if (childSameTableAttributes != null)
            {
                if (sameTableElementInfo != null)
                {
                    if (sameTableElementInfo.ChildSameTableElements != null)
                    {
                        throw new MappingException("The same table element \"{0}\" already has same table elements specified", sameTableElementInfo.MemberName);
                    }
                    sameTableElementInfo.ChildSameTableElements = childSameTableAttributes;
                }
                else
                {
                    if (currentTable.ChildSameTableElements != null)
                    {
                        throw new MappingException("The table \"{0}\" already has same table elements specified", currentTable.TableName);
                    }
                    currentTable.ChildSameTableElements = childSameTableAttributes;
                }
                foreach (SameTableElementInfo childSameTableElementInfo in childSameTableAttributes)
                {
                    ConstructTableMappings(childSameTableElementInfo.ValueType, childSameTableElementInfo.MemberInfo, null,
                                           currentTable, childSameTableElementInfo,
                                           tables, childSameTableElementInfo.CanSetColumnsNotNull, currentTable);
                }
            }
            if (relationMembers != null)
            {
                if (currentTable.ChildRelationMembers != null)
                {
                    throw new MappingException("The table \"{0}\" already has relation members specified", currentTable.TableName);
                }

                currentTable.ChildRelationMembers = relationMembers;

                foreach (ChildRelationInfo relationInfo in relationMembers)
                {
                    relationInfo.ChildTable =
                        ConstructTableMappings(relationInfo.ValueType, relationInfo.MemberInfo, relationInfo.ElementMemberName,
                                               null, null, tables, true, currentTable);
                }
            }
            if (foreignKeyTable != currentTable)
            {
                currentTable.FinishedFirstPassMapping = true;
            }
            return currentTable;
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
        public void OutputNameReplacements(string filePath)
        {
            var sb = new StringBuilder();

            if (m_NameReplacements != null)
            {
                foreach (var pair in m_NameReplacements)
                {
                    sb.AppendLine($"\"{pair.Key}\", \"{pair.Value}\",");
                }
            }
            sb.Length = sb.Length - 1;
            File.WriteAllText(filePath, sb.ToString());
        }
        protected Type GetValueTypeFomCustomXmlStringFormatTypeBase(Type valueType)
        {
            Type rtnType;
            if ( m_CustomXmlStringFormatTypeBaseMap.TryGetValue(valueType, out rtnType)) 
            {
                return rtnType;
            }
            DebugUtils.AssertDebuggerBreak(valueType.IsSubclassOf(typeof(CustomXmlStringFormatTypeBase)));
            TypeCode typeCode = ((CustomXmlStringFormatTypeBase)Activator.CreateInstance(valueType)).GetTypeCode();

            switch(typeCode)
            {
                case TypeCode.Boolean:
                    rtnType = typeof(bool); break;
                case TypeCode.Char:
                case TypeCode.String:
                    rtnType = typeof(string); break;
                case TypeCode.Int16:
                case TypeCode.UInt16:
                case TypeCode.Int32:
                case TypeCode.UInt32:
                    rtnType = typeof(int); break;
                case TypeCode.DateTime:
                    rtnType = typeof(DateTime); break;
                case TypeCode.Int64:
                case TypeCode.UInt64:
                    rtnType = typeof(long); break;
                case TypeCode.Single:
                    rtnType = typeof(float); break;
                case TypeCode.Double:
                    rtnType = typeof(double); break;
                case TypeCode.Decimal:
                    rtnType = typeof(decimal); break;
                default:
                    throw new MappingException("Invalid CustomXmlStringFormatTypeBase.GetTypeCode(): {0}", typeCode.ToString());
            }

            m_CustomXmlStringFormatTypeBaseMap.Add(valueType, rtnType);

            return rtnType;
        }
        protected void ConfigureColumnAttributeNameTypeAndSize(ColumnAttribute columnAttribute, Type valueType, string baseName)
        {
            if (string.IsNullOrEmpty(columnAttribute.ColumnName))
            {
                string columnName = baseName;
                columnAttribute.ColumnName = Utils.CamelCaseToDatabaseName(columnName);
            }
            if (columnAttribute.ColumnType == null)
            {
                if (valueType.IsSubclassOf(typeof(CustomXmlStringFormatTypeBase)))
                {
                    valueType = GetValueTypeFomCustomXmlStringFormatTypeBase(valueType);
                }
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
                else if (valueType == typeof(double))
                {
                    columnAttribute.ColumnType = DbType.Double;
                }
                else if (valueType == typeof(float))
                {
                    columnAttribute.ColumnType = DbType.Single;
                }
                else if (valueType == typeof(int))
                {
                    columnAttribute.ColumnType = DbType.Int32;
                }
                else if (valueType == typeof(long))
                {
                    columnAttribute.ColumnType = DbType.Int64;
                }
                else if (valueType == typeof(byte[]))
                {
                    columnAttribute.ColumnType = DbType.Binary;
                }
                else
                {
                    throw new MappingException("Invalid column value type: {0}", valueType.ToString());
                }
            }
            if ((columnAttribute.ColumnSize == 0) &&
                ((columnAttribute.ColumnType != DbType.DateTime) && (columnAttribute.ColumnType != DbType.Decimal) &&
                 (columnAttribute.ColumnType != DbType.Int32)))
            {
                if (valueType == typeof(string))
                {
                    columnAttribute.ColumnSize = GetElementDefaultStringLength(baseName);
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
                throw new MappingException("Invalid column size: {0}", columnAttribute.ColumnSize.ToString());
            }
            if (!Utils.IsValidColumnType(valueType))
            {
                throw new MappingException("Invalid column value type: {0}", valueType.ToString());
            }
        }

        protected string GetColumnDescription(MemberInfo member)
        {
            string description = ReflectionUtils.GetDescription(member);
            if (string.IsNullOrEmpty(description))
            {
                return member.Name;
            }
            return string.Format("{0} ({1})", description, member.Name);
        }
        protected string RemoveAnyPostfixNames(string name)
        {
            if (name.EndsWith(DATA_TYPE_STR))
            {
                name = name.Substring(0, name.Length - DATA_TYPE_STR.Length);
            }
            else
            {
                CollectionUtils.ForEachBreak(m_RemovePostfixNamesFromTableAndColumnNames, delegate(string postfixName)
                {
                    if (name.EndsWith(postfixName))
                    {
                        name = name.Substring(0, name.Length - postfixName.Length);
                        return false;
                    }
                    return true;
                });
            }
            return name;
        }
        protected Type GetMemberValueType(MemberInfo memberInfo)
        {
            PropertyInfo propertyInfo = (memberInfo as PropertyInfo);
            FieldInfo fieldInfo = (memberInfo as FieldInfo);
            Type valueType = (propertyInfo != null) ? propertyInfo.PropertyType : fieldInfo.FieldType;
            if (valueType == typeof(DateTime?))
            {
                valueType = typeof(DateTime);
            }
            return valueType;
        }
        protected bool TypeContainsOnlyColumnTypes(Type type)
        {
            return false;
            //List<MemberInfo> members = Utils.GetPublicMembersForType(type);

            //for (int memberIndex = 0; memberIndex < members.Count; ++memberIndex)
            //{
            //    MemberInfo member = members[memberIndex];

            //    Type valueType = GetMemberValueType(member);

            //    if (!Utils.IsValidColumnType(valueType))
            //    {
            //        return false;
            //    }
            //}
            //return true;
        }
        protected string GetDefaultTableName(Type objType)
        {
            return GetDefaultTableName(objType.Name);
        }
        protected string GetDefaultTableName(string baseTableName)
        {
            baseTableName = RemoveAnyPostfixNames(baseTableName);
            string tableName = Utils.CamelCaseToDatabaseName(baseTableName);
            if (!string.IsNullOrEmpty(m_DefaultTableNamePrefix))
            {
                if (!tableName.StartsWith(m_DefaultTableNamePrefix))
                {
                    tableName = m_DefaultTableNamePrefix + Utils.NAME_SEPARATOR + tableName;
                }
            }
            return tableName;
        }
        protected virtual IDictionary<string, Table> ValidateTables(IDictionary<string, Table> tables)
        {
            // Clean up any missing foreign key references
            foreach (Table table in tables.Values)
            {
                bool setFKsNullable = (table.ForeignKeys.Count > 1);
                foreach (ForeignKeyColumn foreignKeyColumn in table.ForeignKeys)
                {
                    if (setFKsNullable)
                    {
                        foreignKeyColumn.IsNullable = true;
                        foreignKeyColumn.DeleteRule = DeleteRule.None;
                    }
                }
            }
            tables = DatabaseNameShortener.ShortenDatabaseNames(tables, m_NameReplacements, m_MaxColumnNameChars, m_MaxTableNameChars);

            CollectionUtils.ForEach(m_AdditionalCreateIndexAttributes, delegate(AdditionalCreateIndexAttribute attr)
            {
                Table table;
                if (!tables.TryGetValue(attr.ParentTable, out table))
                {
                    throw new MappingException("Could not find table for AdditionalCreateIndexAttribute \"{0}\"", attr.ParentTable);
                }
                IList<string> columnNames = StringUtils.SplitAndReallyRemoveEmptyEntries(attr.ColumnName, ',');
                CollectionUtils.ForEach(columnNames, delegate(string colName)
                {
                    Column column;
                    if (!table.TryGetColumn(colName, out column))
                    {
                        throw new MappingException("Could not find column in table for AdditionalCreateIndexAttribute \"{0}.{1}\"",
                                                   attr.ParentTable, colName);
                    }
                });
            });

            return tables;
        }
        protected virtual void ShortenDatabaseNames(Dictionary<string, Table> tables)
        {

        }

        protected List<MappingAttribute> GetMappingAttributesForType(Type type)
        {
            return AppendAppliedAttributes(type, string.Empty, null,
                                           Utils.GetMappingAttributesForType(type));
        }
        protected List<MappingAttribute> GetMappingAttributesForMember(MemberInfo member)
        {
            return AppendAppliedAttributes(member.ReflectedType, member.Name, GetMemberValueType(member),
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
            if ((type.BaseType != null) && (type.BaseType != typeof(object)))
            {
                AppendAppliedAttributes(type.BaseType, memberName, ref attributes);
            }
        }
        protected List<MappingAttribute> AppendAppliedAttributes(Type type, string memberName, Type memberValueType,
                                                                 List<MappingAttribute> attributes)
        {
            if (m_AppliedAttributes != null)
            {
                AppendAppliedAttributes(type, memberName, ref attributes);
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
            if (memberValueType != null)
            {
                List<MappingAttribute> mappingAttributes;
                if (m_MemberTypeAppliedAttributes.TryGetValue(memberValueType, out mappingAttributes))
                {
                    foreach (MappingAttribute mappingAttribute in mappingAttributes)
                    {
                        CollectionUtils.Add(mappingAttribute.ShallowCopy(), ref attributes);
                    }
                }
            }
            return attributes;
        }
        protected virtual Column CreateColumn(ColumnAttribute columnAttribute,
                                              MemberInfo member, MemberInfo isSpecifiedMember,
                                              IDictionary<string, Table> tables)
        {
            Table table;
            if (!tables.TryGetValue(columnAttribute.TableName, out table))
            {
                throw new MappingException("Could not find table for column \"{0}\"", columnAttribute.ColumnName);
            }
            else
            {
                if (table.TableRootType == null)
                {
                    throw new MappingException("TableRootType == null for table \"{0}\"", table.TableName);
                }
                if (table.FinishedFirstPassMapping)
                {
                    return null;
                }
            }
            Column column = table.AddDataColumn(member, isSpecifiedMember, columnAttribute);
            return column;
        }
        public IDictionary<string, Table> Tables
        {
            get
            {
                return m_Tables;
            }
        }
        public override string ToString()
        {
            return ReflectionUtils.GetPublicPropertiesString(this);
        }
        public string DefaultDecimalCreateString
        {
            get
            {
                return m_DefaultDecimalCreateString;
            }
            set
            {
                m_DefaultDecimalCreateString = value;
            }
        }
        public string DefaultFloatCreateString
        {
            get
            {
                return m_DefaultFloatCreateString;
            }
            set
            {
                m_DefaultFloatCreateString = value;
            }
        }
        public string DefaultDoubleCreateString
        {
            get
            {
                return m_DefaultDoubleCreateString;
            }
            set
            {
                m_DefaultDoubleCreateString = value;
            }
        }
        public string DefaultTableNamePrefix
        {
            get
            {
                return m_DefaultTableNamePrefix;
            }
            set
            {
                m_DefaultTableNamePrefix = value;
            }
        }

        protected virtual void ConstructTableMappings(Type rootType, Type mappingAttributesType)
        {
            if (mappingAttributesType == null)
            {
                mappingAttributesType = rootType;
            }

            m_NameReplacements = ConstructNameReplacements(mappingAttributesType, out m_MaxColumnNameChars, out m_MaxTableNameChars);
            m_DefaultStringDbValues = GetDefaultDbStringValues(mappingAttributesType);
            m_ElementNamePostfixToLength = GetElementNamePostfixToLength(mappingAttributesType);
            m_DefaultTableNamePrefix = GetDefaultTableNamePrefix(mappingAttributesType);
            m_DefaultDecimalCreateString = GetDefaultDecimalPrecision(mappingAttributesType);
            m_DefaultFloatCreateString = GetDefaultFloatPrecision(mappingAttributesType);
            m_DefaultDoubleCreateString = GetDefaultDoublePrecision(mappingAttributesType);
            m_AppliedAttributes = GetAppliedAttributes(mappingAttributesType);
            m_MemberTypeAppliedAttributes = GetMemberTypeAppliedAttributes(mappingAttributesType);
            m_NamePostfixAppliedAttributes = GetNamePostfixAppliedAttributes(mappingAttributesType);
            m_RemovePostfixNamesFromTableAndColumnNames = GetRemovePostfixNamesFromTableAndColumnNamesAttribute(mappingAttributesType);
            UseNewSameTableMapping = GetUseNewSameTableMappingAttribute(mappingAttributesType);
            AllowNestedSameTables = GetAllowNestedSameTablesAttribute(mappingAttributesType);

            List<MappingAttribute> attributes = GetMappingAttributesForType(mappingAttributesType);
            foreach (MappingAttribute mappingAttribute in attributes)
            {
                if (mappingAttribute is AdditionalCreateIndexAttribute)
                {
                    m_AdditionalCreateIndexAttributes.Add((AdditionalCreateIndexAttribute)mappingAttribute);
                }
            }
            m_Tables = new Dictionary<string, Table>();
            ConstructTableMappings(rootType, null, null, null, null, m_Tables, true, null);
            m_Tables = ValidateTables(m_Tables);
        }
        protected virtual List<KeyValuePair<string, string>> ConstructNameReplacements(Type rootType, out int? maxColumnNameChars, out int? maxTableNameChars)
        {
            NameReplacementsAttribute attr = GetGlobalAttribute<NameReplacementsAttribute>(rootType);
            if (attr != null)
            {
                maxColumnNameChars = attr.MaxColumnNameChars;
                maxTableNameChars = attr.MaxTableNameChars;
                return attr.Replacements;
            }
            else
            {
                maxColumnNameChars = null;
                maxTableNameChars = null;
            }
            return null;
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
        protected virtual bool GetUseNewSameTableMappingAttribute(Type rootType)
        {
            UseNewSameTableMappingAttribute attr = GetGlobalAttribute<UseNewSameTableMappingAttribute>(rootType);
            return (attr != null);
        }
        protected virtual bool GetAllowNestedSameTablesAttribute(Type rootType)
        {
            var attr = GetGlobalAttribute<AllowNestedSameTablesAttribute>(rootType);
            return (attr != null);
        }
        protected virtual IList<string> GetRemovePostfixNamesFromTableAndColumnNamesAttribute(Type rootType)
        {
            RemovePostfixNamesFromTableAndColumnNamesAttribute attr = GetGlobalAttribute<RemovePostfixNamesFromTableAndColumnNamesAttribute>(rootType);
            if ((attr != null) && !CollectionUtils.IsNullOrEmpty(attr.PostfixNames))
            {
                return new List<string>(attr.PostfixNames);
            }
            return null;
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
        protected virtual A GetGlobalAttribute<A>(Type rootType) where A : Attribute
        {
            object[] attributes = rootType.GetCustomAttributes(typeof(A), m_InheritMappingAttributes);
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
        protected bool m_InheritMappingAttributes = false;
        private static readonly object[] s_EmptyObjectArray = new object[0];
        protected static object[] GetStaticClassGlobalAttributes<A>(Type rootType) where A : Attribute
        {
            string fullTypeName = rootType.Namespace + ".GlobalAttributes";
            Type globalAttributesType = rootType.Assembly.GetType(fullTypeName);
            if (globalAttributesType != null)
            {
                return globalAttributesType.GetCustomAttributes(typeof(A), false);
            }
            return s_EmptyObjectArray;
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
            Dictionary<Type, Dictionary<string, List<MappingAttribute>>> appliedAttributes = new Dictionary<Type,Dictionary<string,List<MappingAttribute>>>();
            ConstructAppliedAttributes(rootType.Assembly.GetCustomAttributes(typeof(AppliedAttribute), false),
                                       ref appliedAttributes);
            ConstructAppliedAttributes(GetStaticClassGlobalAttributes<AppliedAttribute>(rootType),
                                       ref appliedAttributes);
            // Root attributes override asssembly-level attributes
            ConstructAppliedAttributes(rootType.GetCustomAttributes(typeof(AppliedAttribute), false),
                                       ref appliedAttributes);

            return appliedAttributes;
        }
        private Dictionary<Type, List<MappingAttribute>> GetMemberTypeAppliedAttributes(Type rootType)
        {
            Dictionary<Type, List<MappingAttribute>> memberTypeAppliedAttributes = new Dictionary<Type,List<MappingAttribute>>();
            ConstructMemberTypeAppliedAttributes(rootType.Assembly.GetCustomAttributes(typeof(MemberTypeAppliedAttribute), false),
                                                 ref memberTypeAppliedAttributes);
            ConstructMemberTypeAppliedAttributes(GetStaticClassGlobalAttributes<MemberTypeAppliedAttribute>(rootType),
                                                 ref memberTypeAppliedAttributes);
            // Root attributes override asssembly-level attributes
            ConstructMemberTypeAppliedAttributes(rootType.GetCustomAttributes(typeof(MemberTypeAppliedAttribute), false),
                                                 ref memberTypeAppliedAttributes);

            return memberTypeAppliedAttributes;
        }
        private static Dictionary<string, MappingAttribute> GetNamePostfixAppliedAttributes(Type rootType)
        {
            Dictionary<string, MappingAttribute> namePostfixAppliedAttributes = new Dictionary<string,MappingAttribute>();
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
        protected static void ConstructMemberTypeAppliedAttributes(IList<object> attributes,
                                                                   ref Dictionary<Type, List<MappingAttribute>> appliedAttributes)
        {
            if (CollectionUtils.IsNullOrEmpty(attributes))
            {
                return;
            }
            if (appliedAttributes == null)
            {
                appliedAttributes = new Dictionary<Type, List<MappingAttribute>>();
            }
            foreach (MemberTypeAppliedAttribute attribute in attributes)
            {
                List<MappingAttribute> typeAttributes;
                if (!appliedAttributes.TryGetValue(attribute.AppliedToMemberType, out typeAttributes))
                {
                    typeAttributes = new List<MappingAttribute>();
                    appliedAttributes.Add(attribute.AppliedToMemberType, typeAttributes);
                }

                MappingAttribute mappingAttribute = GetMappingAttributeFromAppliedAttribute(attribute);

                typeAttributes.Add(mappingAttribute);
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
            else if (appliedAttribute.MappedAttributeType == typeof(DbNullAttribute))
            {
                mappingAttribute = new DbNullAttribute();
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
            else if ((appliedAttribute.MappedAttributeType == typeof(ColumnAttribute)))
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
            else if (appliedAttribute.MappedAttributeType == typeof(SameTableAttribute))
            {
                mappingAttribute = new SameTableAttribute();
            }
            else if (appliedAttribute.MappedAttributeType == typeof(GuidPrimaryKeyAttribute))
            {
                mappingAttribute = new GuidPrimaryKeyAttribute();
            }
            else if (appliedAttribute.MappedAttributeType == typeof(GuidForeignKeyAttribute))
            {
                mappingAttribute = new GuidForeignKeyAttribute();
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
        public object GetPrimaryKeyValueForObject(object obj)
        {
            Table table = GetTableForType(obj.GetType());
            return table.PrimaryKey;
        }
        public string GetPrimaryKeyNameForType(Type objectType)
        {
            Table table = GetTableForType(objectType);
            return table.PrimaryKey.ColumnName;
        }
        public Table GetTableForType(Type objectType)
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
        private const string DATA_TYPE_STR = "DataType";
        private IDictionary<string, Table> m_Tables = new Dictionary<string, Table>();
        private List<KeyValuePair<string, string>> m_NameReplacements = null;
        public int? m_MaxColumnNameChars = null;
        public int? m_MaxTableNameChars = null;
        private static Dictionary<Type, MappingContext> s_MappingContexts = new Dictionary<Type, MappingContext>();
        private DefaultStringDbValuesAttribute m_DefaultStringDbValues;
        private List<KeyValuePair<string, int>> m_ElementNamePostfixToLength;
        private Dictionary<Type, Dictionary<string, List<MappingAttribute>>> m_AppliedAttributes;
        private Dictionary<Type, List<MappingAttribute>> m_MemberTypeAppliedAttributes;
        private Dictionary<string, MappingAttribute> m_NamePostfixAppliedAttributes;
        private string m_SpecifiedFieldPostfixName = "Specified";
        private string m_DefaultTableNamePrefix;
        private string m_DefaultDecimalCreateString;
        private string m_DefaultFloatCreateString;
        private string m_DefaultDoubleCreateString;
        private bool m_UseExactElementNameForTableName;
        private IList<string> m_RemovePostfixNamesFromTableAndColumnNames;
        private List<AdditionalCreateIndexAttribute> m_AdditionalCreateIndexAttributes = new List<AdditionalCreateIndexAttribute>();
        private Dictionary<Type, Type> m_CustomXmlStringFormatTypeBaseMap = new Dictionary<Type, Type>();

        public List<AdditionalCreateIndexAttribute> AdditionalCreateIndexAttributes
        {
            get
            {
                return m_AdditionalCreateIndexAttributes;
            }
        }

        public IList<string> RemovePostfixNamesFromTableAndColumnNames
        {
            get
            {
                return m_RemovePostfixNamesFromTableAndColumnNames;
            }
            set
            {
                m_RemovePostfixNamesFromTableAndColumnNames = value;
            }
        }
        public bool UseExactElementNameForTableName
        {
            get
            {
                return m_UseExactElementNameForTableName;
            }
            set
            {
                m_UseExactElementNameForTableName = value;
            }
        }

        public bool FixShortenNameBreakBug
        {
            get
            {
                return true;
            }
        }

        public bool ShortenNamesByRemovingVowelsFirst
        {
            get
            {
                return true;
            }
        }
        public bool UseNewSameTableMapping
        {
            get;
            set;
        }
        public bool AllowNestedSameTables
        {
            get;
            set;
        }
    }
}
