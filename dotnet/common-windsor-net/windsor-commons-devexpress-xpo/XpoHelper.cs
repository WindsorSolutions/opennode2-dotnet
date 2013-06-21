
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.Metadata;
using Windsor.Commons.Core;

namespace Windsor.Commons.DeveloperExpress.Xpo
{
    public static class XpoHelper
    {
        [NonPersistent, OptimisticLocking(false)]
        private class DynamicXpoObject : XPBaseObject
        {
            public DynamicXpoObject(Session session, XPClassInfo ci)
                : base(session, ci)
            {
            }
        }
        public static XpoServerCollectionSource GetDataSourceForDatabaseView(DbConnection connection, string viewName,
                                                                             string primaryKeyName, IList<string> displayColumnNames,
                                                                             CaseInsensitiveDictionary<string> filterColumnNamesAndValues)
        {
            DataTable table = GetTableSchema(connection, viewName);

            ReflectionDictionary reflectionDictionary;
            XPClassInfo classInfo;
            displayColumnNames = GetDynamicClassInfoFromTable(table, primaryKeyName, displayColumnNames,
                                                              filterColumnNamesAndValues, out classInfo,
                                                              out reflectionDictionary);

            XpoServerCollectionSource xpSource = new XpoServerCollectionSource(connection, classInfo, reflectionDictionary,
                                                                               displayColumnNames, filterColumnNamesAndValues);
            return xpSource;
        }
        private static DataTable GetTableSchema(DbConnection connection, string viewName)
        {
            DataTable table = null;
            ConnectionState origConnectionState = connection.State;
            try
            {
                if (origConnectionState != ConnectionState.Open)
                {
                    connection.Open();
                }
                DbCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM \"" + viewName + "\" WHERE 0 = 1";
                DbDataReader reader = command.ExecuteReader(CommandBehavior.KeyInfo);
                table = new DataTable(viewName);
                table.Load(reader);
            }
            catch (Exception ex)
            {
                throw new ArgException("An error occurred attempting to load the view \"{0}\" for display: {1}",
                                       viewName, ExceptionUtils.GetDeepExceptionMessage(ex));
            }
            finally
            {
                if (origConnectionState != ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            if (table.Columns.Count < 1)
            {
                throw new ArgException("The view \"{0}\" does not contain any data (columns) to display", viewName);
            }
            return table;
        }
        private static IList<string> GetDynamicClassInfoFromTable(DataTable table, string primaryKeyName, IList<string> displayColumnNames,
                                                                  CaseInsensitiveDictionary<string> filterColumnNamesAndValues, out XPClassInfo classInfo,
                                                                  out ReflectionDictionary reflectionDictionary)
        {
            reflectionDictionary = new ReflectionDictionary();
            classInfo =
                new XPDataObjectClassInfo(reflectionDictionary.GetClassInfo(typeof(DynamicXpoObject)), table.TableName);
            DataColumn primaryKeyColumn = null;
            if (string.IsNullOrEmpty(primaryKeyName))
            {
                primaryKeyColumn = table.Columns[0];
            }
            else
            {
                foreach (DataColumn col in table.Columns)
                {
                    if (string.Equals(col.ColumnName, primaryKeyName, StringComparison.OrdinalIgnoreCase))
                    {
                        primaryKeyColumn = col;
                        break;
                    }
                }
                if (primaryKeyColumn == null)
                {
                    throw new ArgException("The primary key column named \"{0}\" could not be found in the view \"{1}\"",
                                           primaryKeyName, table.TableName);
                }
            }
            if (CollectionUtils.IsNullOrEmpty(displayColumnNames))
            {
                // Add all columns from the view, ignoring filterColumnNames as displayable, if found
                if (!CollectionUtils.IsNullOrEmpty(filterColumnNamesAndValues))
                {
                    displayColumnNames = new List<string>(table.Columns.Count);
                }
                else
                {
                    displayColumnNames = null;
                }
                bool foundAnyFilterColumns = false;
                foreach (DataColumn col in table.Columns)
                {
                    if (col == primaryKeyColumn)
                    {
                        XPCustomMemberInfo pkMemberInfo = classInfo.CreateMember(col.ColumnName, col.DataType, new KeyAttribute());
                    }
                    else
                    {
                        classInfo.CreateMember(col.ColumnName, col.DataType);
                    }
                    if (displayColumnNames != null)
                    {
                        if (filterColumnNamesAndValues.ContainsKey(col.ColumnName))
                        {
                            foundAnyFilterColumns = true;
                        }
                        else
                        {
                            displayColumnNames.Add(col.ColumnName);
                        }
                    }
                }
                return foundAnyFilterColumns ? displayColumnNames : null;
            }
            else
            {
                bool addedPrimaryKeyCol = false;
                List<string> notFoundFilterColumnNames = null;

                if (!CollectionUtils.IsNullOrEmpty(filterColumnNamesAndValues))
                {
                    notFoundFilterColumnNames = new List<string>(filterColumnNamesAndValues.Keys);
                }

                foreach (string colName in displayColumnNames)
                {
                    DataColumn foundColumn = FindColumn(table, colName);
                    if (foundColumn == null)
                    {
                        throw new ArgException("The display column named \"{0}\" could not be found in the view \"{1}\"",
                                               colName, table.TableName);
                    }
                    if (foundColumn == primaryKeyColumn)
                    {
                        XPCustomMemberInfo pkMemberInfo = classInfo.CreateMember(foundColumn.ColumnName, foundColumn.DataType, new KeyAttribute());
                        addedPrimaryKeyCol = true;
                    }
                    else
                    {
                        classInfo.CreateMember(foundColumn.ColumnName, foundColumn.DataType);
                    }
                    RemoveNameFromList(notFoundFilterColumnNames, foundColumn.ColumnName);
                }
                if (!addedPrimaryKeyCol)
                {
                    classInfo.CreateMember(primaryKeyColumn.ColumnName, primaryKeyColumn.DataType, new KeyAttribute());
                    RemoveNameFromList(notFoundFilterColumnNames, primaryKeyColumn.ColumnName);
                }
                if (!CollectionUtils.IsNullOrEmpty(notFoundFilterColumnNames))
                {
                    for (int i = notFoundFilterColumnNames.Count - 1; i >= 0; --i)
                    {
                        string colName = notFoundFilterColumnNames[i];
                        DataColumn foundColumn = FindColumn(table, colName);
                        if (foundColumn != null)
                        {
                            classInfo.CreateMember(foundColumn.ColumnName, foundColumn.DataType);
                            notFoundFilterColumnNames.RemoveAt(i);
                        }
                    }
                }
                return displayColumnNames;
            }
        }
        private static void RemoveNameFromList(List<string> list, string name)
        {
            if (list != null)
            {
                int index = CollectionUtils.IndexOf(list, name, StringComparison.OrdinalIgnoreCase);
                if (index >= 0)
                {
                    list.RemoveAt(index);
                }
            }
        }
        private static DataColumn FindColumn(DataTable table, string name)
        {
            DataColumn foundColumn = null;
            foreach (DataColumn col in table.Columns)
            {
                if (string.Equals(col.ColumnName, name, StringComparison.OrdinalIgnoreCase))
                {
                    foundColumn = col;
                    break;
                }
            }
            return foundColumn;
        }
    }
}