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
    public static class Utils
    {
        public static string ColumnPath(string tableName, string columnName)
        {
            return string.Format("{0}.{1}", tableName, columnName);
        }
        public static string CamelCaseToDatabaseName(string name)
        {
            return StringUtils.SplitCamelCaseName(name, '_').ToUpper();
        }
        public static string ShortenDatabaseColumnName(string name, bool shortenNamesByRemovingVowelsFirst,
                                                       bool fixBreakBug, Dictionary<string, string> abbreviations)
        {
            return ShortenDatabaseName(name, MAX_COLUMN_NAME_CHARS, shortenNamesByRemovingVowelsFirst,
                                       fixBreakBug, abbreviations);
        }
        public static string ShortenDatabaseTableName(string name, bool shortenNamesByRemovingVowelsFirst,
                                                      bool fixBreakBug, Dictionary<string, string> abbreviations)
        {
            return ShortenDatabaseName(name, MAX_TABLE_NAME_CHARS, shortenNamesByRemovingVowelsFirst,
                                       fixBreakBug, abbreviations);
        }
        public static string ShortenDatabaseTableName(string name, int maxChars, bool shortenNamesByRemovingVowelsFirst,
                                                      bool fixBreakBug, Dictionary<string, string> abbreviations)
        {
            return ShortenDatabaseName(name, maxChars, shortenNamesByRemovingVowelsFirst,
                                       fixBreakBug, abbreviations);
        }
        //static List<string> overList = new List<string>(); //??
        public static string ShortenDatabaseName(string name, int maxChars, bool shortenNamesByRemovingVowelsFirst,
                                                 bool fixBreakBug, Dictionary<string, string> abbreviations)
        {
            string value = StringAbbreviator.Abbreviate(name, abbreviations);
            //{
            //    string[] subnames = value.Split('_');
            //    foreach (string str in subnames)
            //    {
            //        if ((str.Length > 6) && !overList.Contains(str))
            //        {
            //            overList.Add(str);
            //            if (overList.Count > 1)
            //            {
            //                string overListStr = StringUtils.Join(",", overList);
            //                overList.Clear();
            //            }
            //        }
            //    }
            //}
            if (string.IsNullOrEmpty(value) || (value.Length <= maxChars))
            {
                return value;
            }
            //overList.Add(value);
            //if (overList.Count > 5)
            //{
            //    string overListStr = StringUtils.Join(",", overList);
            //    overList.Clear();
            //}
            value = ShortenDatabaseName(value, maxChars, shortenNamesByRemovingVowelsFirst, fixBreakBug);
            return value;
        }
        public static string ShortenDatabaseName(string name, int maxChars, bool shortenNamesByRemovingVowelsFirst,
                                                 bool fixBreakBug)
        {
            string[] subnames = name.Split('_');
            int charsToRemove = name.Length - maxChars;
            if (shortenNamesByRemovingVowelsFirst)
            {
                bool removedAny = false;
                do
                {
                    removedAny = false;
                    for (int i = subnames.Length - 1; i >= 0; --i)
                    {
                        string curString = subnames[i];
                        if (curString.Length > 2)
                        {
                            int index = StringUtils.LastIndexOf(curString, new string[] { "A", "E", "I", "O", "U" },
                                                                curString.Length - 2, curString.Length - 2, StringComparison.InvariantCultureIgnoreCase);
                            if (index > 0)
                            {
                                curString = curString.Remove(index, 1);
                                subnames[i] = curString;
                                removedAny = true;
                                if (--charsToRemove == 0)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    if (fixBreakBug)
                    {
                        if (charsToRemove == 0)
                        {
                            break;
                        }
                    }
                } while (removedAny);
            }
            if (charsToRemove > 0)
            {
                int minSubnameSize = 5;
                do
                {
                    bool removedAny = false;
                    for (int i = subnames.Length - 1; i >= 0; --i)
                    {
                        string curString = subnames[i];
                        if (curString.Length > minSubnameSize)
                        {
                            subnames[i] = curString.Remove(curString.Length - 1);
                            removedAny = true;
                            if (--charsToRemove == 0)
                            {
                                break;
                            }
                        }
                    }
                    if (!removedAny)
                    {
                        if (--minSubnameSize == 1)
                        {
                            break;
                        }
                    }
                } while (charsToRemove > 0);
                if (charsToRemove > 0)
                {
                    string curString = subnames[0];
                    int newLength = curString.Length - charsToRemove;
                    if (newLength < 3)
                    {
                        newLength = 3;
                    }
                    if (newLength < curString.Length)
                    {
                        subnames[0] = curString.Remove(curString.Length - charsToRemove);
                    }
                }
            }
            name = string.Join("_", subnames);
            if (name.Length <= maxChars)
            {
                return name;
            }
            charsToRemove = name.Length - maxChars;
            name = name.Remove(name.Length - charsToRemove, charsToRemove);
            if (name[name.Length - 1] == '_')
            {
                name = name.Substring(0, name.Length - 1);
            }
            return name;
        }
        public static string RemoveTableNamePrefix(string tableName, string defaultTableNamePrefix)
        {
            if (string.IsNullOrEmpty(defaultTableNamePrefix))
            {
                return tableName;
            }
            if (tableName.StartsWith(defaultTableNamePrefix + "_"))
            {
                tableName = tableName.Substring(defaultTableNamePrefix.Length + 1);
            }
            else if (tableName.StartsWith(defaultTableNamePrefix))
            {
                tableName = tableName.Substring(defaultTableNamePrefix.Length);
            }
            return tableName;
        }
        public static string GetForeignKeyConstraintName(ForeignKeyColumn foreignKeyColumn, bool shortenNamesByRemovingVowelsFirst,
                                                         bool fixBreakBug, string defaultTableNamePrefix)
        {
            if (!string.IsNullOrEmpty(foreignKeyColumn.IndexName))
            {
                return foreignKeyColumn.IndexName;
            }
            else
            {
                return ShortenDatabaseName("FK_" + RemoveTableNamePrefix(foreignKeyColumn.Table.TableName, defaultTableNamePrefix) +
                                           "_" + RemoveTableNamePrefix(foreignKeyColumn.ForeignTable.TableName, defaultTableNamePrefix),
                                           18, shortenNamesByRemovingVowelsFirst, fixBreakBug, null);
            }
        }
        public static string GetPrimaryKeyConstraintName(PrimaryKeyColumn primaryKeyColumn, bool shortenNamesByRemovingVowelsFirst,
                                                         bool fixBreakBug, string defaultTableNamePrefix)
        {
            if (!string.IsNullOrEmpty(primaryKeyColumn.IndexName))
            {
                return primaryKeyColumn.IndexName;
            }
            else
            {
                return ShortenDatabaseName("PK_" + RemoveTableNamePrefix(primaryKeyColumn.Table.TableName, defaultTableNamePrefix),
                                           18, shortenNamesByRemovingVowelsFirst, fixBreakBug, null);
            }
        }
        public static string GetIndexName(Column column, bool shortenNamesByRemovingVowelsFirst,
                                          bool fixBreakBug, string defaultTableNamePrefix)
        {
            if (!string.IsNullOrEmpty(column.IndexName))
            {
                return column.IndexName;
            }
            else
            {
                return ShortenDatabaseName("IX_" + RemoveTableNamePrefix(column.Table.TableName, defaultTableNamePrefix) +
                                           "_" + column.ColumnName, 18, shortenNamesByRemovingVowelsFirst, fixBreakBug, null);
            }
        }

        private static string GetForeignKeyName(ForeignKeyColumn foreignKeyColumn, string prefix)
        {
            int MIN_SUBNAME_CHARS = (MAX_CONSTRAINT_NAME_CHARS - prefix.Length - 3) / 4;
            string tableName = foreignKeyColumn.Table.TableName;
            string columnName = foreignKeyColumn.ColumnName;
            string foreignTableName = foreignKeyColumn.ForeignTable.TableName;
            string foreignColumnName = foreignKeyColumn.ForeignColumnName;
            int charsLeft = MAX_CONSTRAINT_NAME_CHARS - (6 + tableName.Length + columnName.Length +
                                                         foreignTableName.Length + foreignColumnName.Length);
            while (charsLeft > 0)
            {
                if (foreignColumnName.Length > MIN_SUBNAME_CHARS)
                {
                    foreignColumnName = foreignColumnName.Substring(0, foreignColumnName.Length - 1);
                    if (--charsLeft == 0) break;
                }
                if (foreignTableName.Length > MIN_SUBNAME_CHARS)
                {
                    foreignTableName = foreignTableName.Substring(0, foreignTableName.Length - 1);
                    if (--charsLeft == 0) break;
                }
                if (columnName.Length > MIN_SUBNAME_CHARS)
                {
                    columnName = columnName.Substring(0, columnName.Length - 1);
                    if (--charsLeft == 0) break;
                }
                if (tableName.Length > MIN_SUBNAME_CHARS)
                {
                    tableName = tableName.Substring(0, tableName.Length - 1);
                    if (--charsLeft == 0) break;
                }
            }
            return string.Format("{0}{1}_{2}_{3}_{4}", prefix, tableName, columnName,
                                 foreignTableName, foreignColumnName);
        }
        /// <summary>
        /// Return true if the input type can be assigned directly to a column value.
        /// </summary>
        public static bool IsValidColumnType(Type dataType)
        {
            return (dataType.IsPrimitive || dataType.IsEnum || (dataType == typeof(string)) || 
                   (dataType == typeof(decimal)) || (dataType == typeof(DateTime)) || 
                   (dataType == typeof(byte[])));
        }
        public static bool IsValidForeignKeyColumnType(DbType dbType)
        {
            return IsStringColumnType(dbType) || IsIntegerColumnType(dbType);
        }
        public static bool IsValidPrimaryKeyColumnType(DbType dbType)
        {
            return IsStringColumnType(dbType) || IsIntegerColumnType(dbType);
        }
        public static bool IsStringColumnType(DbType dbType)
        {
            switch (dbType)
            {
                case DbType.AnsiString:
                case DbType.AnsiStringFixedLength:
                case DbType.String:
                case DbType.StringFixedLength:
                    return true;
                default:
                    return false;
            }
        }
        public static bool IsIntegerColumnType(DbType dbType)
        {
            switch (dbType)
            {
                case DbType.Int16:
                case DbType.Int32:
                case DbType.Int64:
                case DbType.UInt16:
                case DbType.UInt32:
                case DbType.UInt64:
                    return true;
                default:
                    return false;
            }
        }
        public static bool IsValidColumnSize(DbType dbType, int dbSize)
        {
            switch (dbType)
            {
                case DbType.AnsiString:
                case DbType.AnsiStringFixedLength:
                case DbType.String:
                case DbType.StringFixedLength:
                    return (dbSize > 0);
                case DbType.Binary:
                    return ((dbSize == 0) || (dbSize == 8));    // dbSize == 8 is Timestamp
                default:
                    return (dbSize == 0);
            }
        }
        public static bool IsValidPrimaryKeyColumnSize(DbType dbType, int dbSize)
        {
            return IsValidColumnSize(dbType, dbSize);
        }
        public static bool IsValidForeignKeyColumnSize(DbType dbType, int dbSize)
        {
            return IsValidColumnSize(dbType, dbSize);
        }
        public static List<MappingAttribute> GetMappingAttributesForType(Type type)
        {
            return CollectionUtils.ToList<MappingAttribute, object>(type.GetCustomAttributes(typeof(MappingAttribute), false));
        }
        public static List<MappingAttribute> GetMappingAttributesForMember(MemberInfo member)
        {
            return CollectionUtils.ToList<MappingAttribute, object>(member.GetCustomAttributes(typeof(MappingAttribute), false));
        }
        public static string CombineTypePath(string root, string name)
        {
            return root + "." + name;
        }
        public static string GetTypePathParent(string path)
        {
            int index = path.LastIndexOf('.');
            if (index >= 0)
            {
                return path.Remove(index);
            }
            return path;
        }
        public static string GetTypePathName(string path)
        {
            int index = path.LastIndexOf('.');
            if (index >= 0)
            {
                return path.Substring(index + 1, path.Length - index - 1);
            }
            return path;
        }
        public static bool DatabaseNamesAreEqual(string name1, string name2)
        {
            return string.Equals(name1, name2, StringComparison.InvariantCultureIgnoreCase);
        }
        public static MemberInfo FindMemberByName(IList<MemberInfo> members, string memberName,
                                                  out int memberIndex)
        {
            for (memberIndex = 0; memberIndex < members.Count; ++memberIndex) {
                MemberInfo member = members[memberIndex];
                if (member == null)
                {
                    continue;
                }
                if (member.Name == memberName)
                {
                    return member;
                }
            }
            memberIndex = -1;
            return null;
        }
        public static List<string> GetShortDescriptionList(IEnumerable<MappingAttribute> attributes)
        {
            List<string> descriptions = new List<string>();
            if (!CollectionUtils.IsNullOrEmpty(attributes))
            {
                foreach (MappingAttribute attribute in attributes)
                {
                    descriptions.Add(attribute.GetShortDescription());
                }
            }
            return descriptions;
        }
        public static List<MemberInfo> GetPublicMembersForType(Type type)
        {
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public);
            int count = properties.Length + fields.Length;
            List<MemberInfo> members = new List<MemberInfo>(count);
            members.AddRange(properties);
            members.AddRange(fields);
            return members;
        }
        public const int MAX_COLUMN_NAME_CHARS = 30;
        public const int MAX_TABLE_NAME_CHARS = 30;
        public const int MAX_CONSTRAINT_NAME_CHARS = 30;
    }
}
