#define SHORTEN_NAMES
using System;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;
using System.Data;
using System.Text;
using System.Xml.Serialization;
using System.Diagnostics;
using System.ComponentModel;
using System.IO;
using Windsor.Commons.Core;

namespace Windsor.Commons.XsdOrm3.Implementations
{
    public static class DatabaseNameShortener
    {
        public static IDictionary<string, Table> ShortenDatabaseNames(IDictionary<string, Table> tables, List<KeyValuePair<string, string>> nameReplacements,
                                                                      string dontUseDefaultTableNamePrefixForPKAndFKPrefix)
        {
#if SHORTEN_NAMES
            ReplaceDatabaseNames(tables, nameReplacements);

            // Get a listing of all table and column names
            Dictionary<Table, NameWrapper> tableNames;
            Dictionary<Column, NameWrapper> columnNames;
            CaseInsensitiveDictionary<StringWrapper> uniqueStrings = GetUniqueStrings(tables, nameReplacements, out tableNames, out columnNames);

            // Shorten the column names, as necessary
            ShortenNames(columnNames.Values, Utils.MAX_COLUMN_NAME_CHARS);

            // Shorten the table names, as necessary
            ShortenNames(tableNames.Values, Utils.MAX_TABLE_NAME_CHARS);

            //StringBuilder sb = new StringBuilder();
            //foreach (StringWrapper stringWrapper in uniqueStrings.Values.OrderBy(x => x.OriginalString))
            //{
            //    sb.AppendLine(string.Format("{0},{1}", stringWrapper.OriginalString, stringWrapper.ShortString));
            //}
            //File.WriteAllText(@"C:\Download\ICISNPDES_30_Unique.txt", sb.ToString());

            foreach (KeyValuePair<Table, NameWrapper> pair in tableNames)
            {
                pair.Key.TableName = pair.Value.ShortName;
            }
            foreach (KeyValuePair<Column, NameWrapper> pair in columnNames)
            {
                pair.Key.ColumnName = pair.Value.ShortName;
            }
#endif // SHORTEN_NAMES

            ResetPrimaryKeys(tables, dontUseDefaultTableNamePrefixForPKAndFKPrefix);

            SortedDictionary<string, Table> newTables = new SortedDictionary<string, Table>();
            foreach (Table table in tables.Values)
            {
                newTables.Add(table.TableName, table);
            }
            return newTables;
        }
        private static void ShortenNames(ICollection<NameWrapper> names, int maxNumChars)
        {
            if (CollectionUtils.IsNullOrEmpty(names))
            {
                return;
            }
            List<NameWrapper> nameList = new List<NameWrapper>(names);
            nameList.Sort((NameWrapper a, NameWrapper b) =>
            {
                return b.ShortNameLength - a.ShortNameLength;
            });
            while (nameList[0].ShortNameLength > maxNumChars)
            {
                nameList[0].Shorten(maxNumChars);

                nameList.Sort((NameWrapper a, NameWrapper b) =>
                {
                    return b.ShortNameLength - a.ShortNameLength;
                });
            }
        }
        private static CaseInsensitiveDictionary<StringWrapper> GetUniqueStrings(IDictionary<string, Table> tables, List<KeyValuePair<string, string>> nameReplacements,
                                                                                 out Dictionary<Table, NameWrapper> tableNames,
                                                                                 out Dictionary<Column, NameWrapper> columnNames)
        {
            Dictionary<string, string> dontShortenStrings;
            if (nameReplacements == null)
            {
                dontShortenStrings = new Dictionary<string, string>();
            }
            else
            {
                dontShortenStrings = new Dictionary<string, string>(nameReplacements.Count);
                foreach (KeyValuePair<string, string> pair in nameReplacements)
                {
                    dontShortenStrings[pair.Value] = pair.Value;
                }
            }

            CaseInsensitiveDictionary<StringWrapper> uniqueStrings = new CaseInsensitiveDictionary<StringWrapper>();
            tableNames = new Dictionary<Table, NameWrapper>();
            columnNames = new Dictionary<Column, NameWrapper>();

            foreach (Table table in tables.Values)
            {
                if (!string.IsNullOrEmpty(table.TableNamePrefix))
                {
                    List<string> nameStrings = StringUtils.SplitAndReallyRemoveEmptyEntries(table.TableNamePrefix, Utils.NAME_SEPARATOR,
                                                                                            StringComparison.OrdinalIgnoreCase);

                    foreach (string nameString in nameStrings)
                    {
                        dontShortenStrings[nameString] = nameString;
                    }
                }
            }
            foreach (Table table in tables.Values)
            {
                NameWrapper nameWrapper = AddNameToUniqueStrings(table.TableName, dontShortenStrings, uniqueStrings);
                tableNames.Add(table, nameWrapper);

                foreach (Column column in table.AllColumns)
                {
                    if (!(column.IsPrimaryKey && table.HasDefaultPrimaryKeyColumn) && !column.IsForeignKey)
                    {
                        nameWrapper = AddNameToUniqueStrings(column.ColumnName, dontShortenStrings, uniqueStrings);
                        columnNames.Add(column, nameWrapper);
                    }
                }
            }

            return uniqueStrings;
        }
        private static NameWrapper AddNameToUniqueStrings(string name, Dictionary<string, string> dontShortenStrings,
                                                          CaseInsensitiveDictionary<StringWrapper> uniqueStrings)
        {
            NameWrapper nameWrapper = new NameWrapper();

            List<string> nameStrings = StringUtils.SplitAndReallyRemoveEmptyEntries(name, Utils.NAME_SEPARATOR, StringComparison.OrdinalIgnoreCase);

            foreach (string nameString in nameStrings)
            {
                bool canShorten = !dontShortenStrings.ContainsKey(nameString);
                StringWrapper stringWrapper;
                if (uniqueStrings.TryGetValue(nameString, out stringWrapper))
                {
                    DebugUtils.AssertDebuggerBreak(stringWrapper.CanShorten == canShorten);
                }
                else
                {
                    stringWrapper = new StringWrapper(nameString, canShorten);
                    uniqueStrings.Add(nameString, stringWrapper);
                }
                nameWrapper.AddString(stringWrapper);
            }

            return nameWrapper;
        }
        private static void ReplaceDatabaseNames(IDictionary<string, Table> tables, List<KeyValuePair<string, string>> nameReplacements)
        {
            if (CollectionUtils.IsNullOrEmpty(nameReplacements))
            {
                return;
            }
            foreach (Table table in tables.Values)
            {
                table.TableName = ReplaceNames(table.TableName, nameReplacements);
                foreach (Column column in table.AllColumns)
                {
                    if (!(column.IsPrimaryKey && table.HasDefaultPrimaryKeyColumn) && !column.IsForeignKey)
                    {
                        column.ColumnName = ReplaceNames(column.ColumnName, nameReplacements);
                    }
                }
            }
        }
        private static void ResetPrimaryKeys(IDictionary<string, Table> tables, string dontUseDefaultTableNamePrefixForPKAndFKPrefix)
        {
            if (!string.IsNullOrEmpty(dontUseDefaultTableNamePrefixForPKAndFKPrefix))
            {
                dontUseDefaultTableNamePrefixForPKAndFKPrefix += Utils.NAME_SEPARATOR_CHAR.ToString();
            }
            foreach (Table table in tables.Values)
            {
                if (table.HasDefaultPrimaryKeyColumn)
                {
                    table.PrimaryKey.ColumnName = table.TableName + Utils.ID_NAME_POSTIFX;
                    if (!string.IsNullOrEmpty(dontUseDefaultTableNamePrefixForPKAndFKPrefix) &&
                        (table.PrimaryKey.ColumnName.IndexOf(dontUseDefaultTableNamePrefixForPKAndFKPrefix, StringComparison.OrdinalIgnoreCase) == 0))
                    {
                        table.PrimaryKey.ColumnName =
                            table.PrimaryKey.ColumnName.Substring(dontUseDefaultTableNamePrefixForPKAndFKPrefix.Length,
                                                                  table.PrimaryKey.ColumnName.Length - dontUseDefaultTableNamePrefixForPKAndFKPrefix.Length);
                    }
                }
                // TSM: Foreign keys already reference foreignKeyColumn.ForeignTable.PrimaryKey.ColumnType in their properties
                //foreach (ForeignKeyColumn foreignKeyColumn in table.ForeignKeys)
                //{
                //    foreignKeyColumn.ColumnName = foreignKeyColumn.ForeignTable.TableName + Utils.ID_NAME_POSTIFX;
                //}
            }
        }
        private static string ReplaceNames(string name, List<KeyValuePair<string, string>> nameReplacements)
        {
            foreach (KeyValuePair<string, string> pair in nameReplacements)
            {
                name = name.Replace(Utils.NAME_SEPARATOR + pair.Key + Utils.NAME_SEPARATOR,
                                    Utils.NAME_SEPARATOR + pair.Value + Utils.NAME_SEPARATOR);
                if (name.StartsWith(pair.Key + Utils.NAME_SEPARATOR))
                {
                    name = pair.Value + name.Substring(pair.Key.Length);
                }
                if (name.EndsWith(Utils.NAME_SEPARATOR + pair.Key))
                {
                    name = name.Substring(0, name.Length - pair.Key.Length) + pair.Value;
                }
                if (name == pair.Key)
                {
                    name = pair.Value;
                }
                if (name.StartsWith(Utils.NAME_SEPARATOR))
                {
                    name = name.Substring(Utils.NAME_SEPARATOR.Length);
                }
                if (name.EndsWith(Utils.NAME_SEPARATOR))
                {
                    name = name.Substring(0, name.Length - Utils.NAME_SEPARATOR.Length);
                }
            }
            return name;
        }
        private class StringWrapper
        {
            public StringWrapper(string value, bool canShorten)
            {
                OriginalString = ShortString = value;
                CanShorten = canShorten;
            }
            public string OriginalString
            {
                get;
                private set;
            }
            public string ShortString
            {
                get;
                set;
            }
            public bool CanShorten
            {
                get;
                private set;
            }
            public override string ToString()
            {
                return string.Format("{0},{1}", OriginalString, ShortString);
            }
        }
        private class NameWrapper
        {
            public string OriginalName
            {
                get
                {
                    List<string> strings = new List<string>(_nameStrings.Count);
                    foreach (StringWrapper wrapper in _nameStrings)
                    {
                        strings.Add(wrapper.OriginalString);
                    }
                    return StringUtils.Join(Utils.NAME_SEPARATOR, strings);
                }
                private set
                {
                    throw new NotImplementedException();
                }
            }
            public string ShortName
            {
                get
                {
                    List<string> strings = new List<string>(_nameStrings.Count);
                    foreach (StringWrapper wrapper in _nameStrings)
                    {
                        strings.Add(wrapper.ShortString);
                    }
                    return StringUtils.Join(Utils.NAME_SEPARATOR, strings);
                }
                private set
                {
                    throw new NotImplementedException();
                }
            }
            public int ShortNameLength
            {
                get
                {
                    int length = 0;
                    if (_nameStrings.Count > 0)
                    {
                        foreach (StringWrapper wrapper in _nameStrings)
                        {
                            length += wrapper.ShortString.Length + Utils.NAME_SEPARATOR.Length;
                        }
                        length -= Utils.NAME_SEPARATOR.Length;
                    }
                    return length;
                }
                private set
                {
                    throw new NotImplementedException();
                }
            }
            public void AddString(StringWrapper stringWrapper)
            {
                _nameStrings.Add(stringWrapper);
            }
            public override string ToString()
            {
                return string.Format("{0},{1},{2}", OriginalName, ShortName, ShortNameLength.ToString());
            }
            public void Shorten(int maxNumChars)
            {
                int numCharsToRemove = ShortNameLength - maxNumChars;
                if (numCharsToRemove < 0)
                {
                    return;
                }
                List<StringWrapper> stringsToShorten = new List<StringWrapper>();
                int totalCharsThatCanBeRemoved = 0;
                foreach (StringWrapper stringValue in _nameStrings)
                {
                    if (stringValue.CanShorten)
                    {
                        if (stringValue.ShortString.Length > 1)
                        {
                            stringsToShorten.Add(stringValue);
                            totalCharsThatCanBeRemoved += stringValue.ShortString.Length - 1;
                        }
                    }
                }
                if (totalCharsThatCanBeRemoved < numCharsToRemove)
                {
                    throw new MappingException("The database name cannot be shortened enough: {0}", OriginalName);
                }
                List<string> strings = new List<string>(stringsToShorten.Count);
                foreach (StringWrapper wrapper in stringsToShorten)
                {
                    strings.Add(wrapper.ShortString);
                }
                string nameToShorten = StringUtils.Join(Utils.NAME_SEPARATOR, strings);
                string shortenedName =
                    Utils.ShortenDatabaseName(nameToShorten, nameToShorten.Length - numCharsToRemove, true, true);
                if (shortenedName.Length > maxNumChars)
                {
                    throw new MappingException("The database name cannot be shortened enough: {0}", OriginalName);
                }
                string[] newStrings = shortenedName.Split(Utils.NAME_SEPARATOR_CHAR);
                if (newStrings.Length != stringsToShorten.Count)
                {
                    throw new MappingException("Error occurred shortening string: {0}", OriginalName);
                }
                for (int i = 0; i < stringsToShorten.Count; ++i)
                {
                    if (stringsToShorten[i].ShortString.Length > newStrings[i].Length)
                    {
                        stringsToShorten[i].ShortString = newStrings[i];
                    }
                }
                if (ShortNameLength > maxNumChars)
                {
                    throw new MappingException("The database name cannot be shortened enough: {0}", OriginalName);
                }
            }
            private List<StringWrapper> _nameStrings = new List<StringWrapper>();
        }
    }
}
