
using System;
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
        public static XpoServerCollectionSource GetDataSourceForDatabaseView(DbConnection connection, string viewName)
        {
            DataTable table = GetTableSchema(connection, viewName);

            ReflectionDictionary reflectionDictionary;
            XPClassInfo classInfo = GetDynamicClassInfoFromTable(table, out reflectionDictionary);

            XpoServerCollectionSource xpSource = new XpoServerCollectionSource(connection, classInfo, reflectionDictionary);

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
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (origConnectionState != ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return table;
        }
        private static XPClassInfo GetDynamicClassInfoFromTable(DataTable table, out ReflectionDictionary reflectionDictionary)
        {
            reflectionDictionary = new ReflectionDictionary();
            XPClassInfo classInfo =
                new XPDataObjectClassInfo(reflectionDictionary.GetClassInfo(typeof(DynamicXpoObject)), table.TableName);
            bool isFirstColumn = true;
            foreach (DataColumn col in table.Columns)
            {
                if (isFirstColumn)
                {
                    classInfo.CreateMember(col.ColumnName, col.DataType, new KeyAttribute());
                    isFirstColumn = false;
                }
                else
                {
                    classInfo.CreateMember(col.ColumnName, col.DataType);
                }
            }

            return classInfo;
        }
    }
}