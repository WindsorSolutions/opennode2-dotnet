
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
                                                                             string primaryKeyName, IList<string> displayColumnNames)
        {
            DataTable table = GetTableSchema(connection, viewName);

            ReflectionDictionary reflectionDictionary;
            XPClassInfo classInfo = GetDynamicClassInfoFromTable(table, primaryKeyName, displayColumnNames, out reflectionDictionary);

            XpoServerCollectionSource xpSource = new XpoServerCollectionSource(connection, classInfo, reflectionDictionary,
                                                                               displayColumnNames);

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
        private static XPClassInfo GetDynamicClassInfoFromTable(DataTable table, string primaryKeyName, IList<string> displayColumnNames,
                                                                out ReflectionDictionary reflectionDictionary)
        {
            reflectionDictionary = new ReflectionDictionary();
            XPClassInfo classInfo =
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
                }
            }
            else
            {
                bool addedPrimaryKeyCol = false;
                foreach (string colName in displayColumnNames)
                {
                    DataColumn foundColumn = null;
                    foreach (DataColumn col in table.Columns)
                    {
                        if (string.Equals(col.ColumnName, colName, StringComparison.OrdinalIgnoreCase))
                        {
                            foundColumn = col;
                            break;
                        }
                    }
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
                }
                if (!addedPrimaryKeyCol)
                {
                    classInfo.CreateMember(primaryKeyColumn.ColumnName, primaryKeyColumn.DataType, new KeyAttribute());
                }
            }

            return classInfo;
        }
    }
}