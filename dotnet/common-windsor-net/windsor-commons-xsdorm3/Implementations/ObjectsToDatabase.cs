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
using System.Text;
using System.Data;
using System.Data.Common;
using System.Reflection;
using Spring.Data.Common;
using System.Collections.Generic;
using System.Collections;
using System.Threading;
using Windsor.Commons.XsdOrm3;
using Windsor.Commons.Core;
using Windsor.Commons.Spring;
using Spring.Data;
using Spring.Transaction;
using Spring.Data.Support;
using Spring.Dao;
using System.Data.SqlClient;

namespace Windsor.Commons.XsdOrm3.Implementations
{
    public class ObjectsToDatabase : ObjectsDatabaseBase, IObjectsToDatabase
    {

        //        ALTER TABLE table_name 
        //ADD CONSTRAINT  constraint_name 
        //UNIQUE  (column [ ASC | DESC ] [ ,...n ] )


        private const int CREATE_DATABASE_WAIT_SECONDS = 20;
        private const string SQL_SERVER_NOT_EXISTS_PK_FORMAT_STRING =
            "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_TYPE = 'PRIMARY KEY' AND TABLE_NAME = '{0}') {1}";
        private const string SQL_SERVER_NOT_EXISTS_FK_FORMAT_STRING =
            "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_TYPE = 'FOREIGN KEY' AND CONSTRAINT_NAME = '{0}' AND TABLE_NAME = '{1}') {2}";
        private const string SQL_SERVER_NOT_EXISTS_INDEX_FORMAT_STRING =
            "IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[{1}]') AND name = N'{0}') {2}";

        private const string ORA_SERVER_NOT_EXISTS_PK_FORMAT_STRING =
            "DECLARE l_exists INTEGER; " +
            "BEGIN SELECT COUNT(*) INTO l_exists FROM USER_CONSTRAINTS WHERE CONSTRAINT_TYPE = 'P' AND TABLE_NAME = '{0}' AND ROWNUM = 1 ; " +
            "IF l_exists = 0 THEN EXECUTE IMMEDIATE '{1}' ; END IF ; END ;";
        private const string ORA_SERVER_NOT_EXISTS_FK_FORMAT_STRING =
            "DECLARE l_exists INTEGER; " +
            "BEGIN SELECT COUNT(*) INTO l_exists FROM USER_CONSTRAINTS WHERE TABLE_NAME = '{1}' AND CONSTRAINT_NAME = '{0}' AND ROWNUM = 1 ; " +
            "IF l_exists = 0 THEN EXECUTE IMMEDIATE '{2}' ; END IF ; END ;";
        private const string ORA_SERVER_NOT_EXISTS_INDEX_FORMAT_STRING =
            "DECLARE l_exists INTEGER; " +
            "BEGIN SELECT COUNT(*) INTO l_exists FROM USER_INDEXES WHERE TABLE_NAME = '{1}' AND INDEX_NAME = '{0}' AND ROWNUM = 1 ; " +
            "IF l_exists = 0 THEN EXECUTE IMMEDIATE '{2}' ; END IF ; END ;";

        public ObjectsToDatabase()
        {
        }
        public ObjectsToDatabase(SpringBaseDao baseDao)
        {
            _baseDao = baseDao;
        }
        public new void Init()
        {
            base.Init();
        }
        public virtual void BuildDatabase(Type objectToSaveType, Type mappingAttributesType)
        {
            BuildDatabase(objectToSaveType, CheckBaseDao(), mappingAttributesType);
        }
        public virtual void BuildDatabase(Type objectToSaveType, SpringBaseDao baseDao, Type mappingAttributesType)
        {
            MappingContext mappingContext = MappingContext.GetMappingContext(objectToSaveType, mappingAttributesType);

            BuildDatabase(objectToSaveType, baseDao, mappingContext);
        }
        public virtual void BuildDatabase(Type objectToSaveType, SpringBaseDao baseDao, MappingContext mappingContext)
        {
            bool createdDatabase;
            IDictionary<string, DataTableSchema> tableSchemas =
                BuildDatabase(mappingContext.Tables, baseDao, out createdDatabase);

            BuildTables(tableSchemas, mappingContext, baseDao, createdDatabase);

            foreach (Type buildDatabaseInitValueProviderType in mappingContext.BuildDatabaseInitValueProviderTypes)
            {
                IBuildDatabaseInitValueProvider buildDatabaseInitValueProvider =
                    ((IBuildDatabaseInitValueProvider)Activator.CreateInstance(buildDatabaseInitValueProviderType));
                bool deleteAllBeforeInit;
                IList<object> buildInitValues =
                    buildDatabaseInitValueProvider.GetBuildInitValues(baseDao, mappingContext, out deleteAllBeforeInit);
                if (!CollectionUtils.IsNullOrEmpty(buildInitValues))
                {
                    SaveToDatabase(buildInitValues, baseDao, deleteAllBeforeInit, mappingContext);
                }
            }
        }
        public virtual string GetTableNameForType(Type objectType, Type mappingAttributesType)
        {
            MappingContext mappingContext = MappingContext.GetMappingContext(objectType, mappingAttributesType);

            return mappingContext.GetTableNameForType(objectType);
        }
        public virtual string GetPrimaryKeyNameForType(Type objectType, Type mappingAttributesType)
        {
            MappingContext mappingContext = MappingContext.GetMappingContext(objectType, mappingAttributesType);

            return mappingContext.GetPrimaryKeyNameForType(objectType);
        }
        public virtual object GetPrimaryKeyValueForObject(object obj, Type mappingAttributesType)
        {
            MappingContext mappingContext = MappingContext.GetMappingContext(obj.GetType(), mappingAttributesType);

            return mappingContext.GetPrimaryKeyValueForObject(obj);
        }
        public virtual int DeleteAllFromDatabase(Type objectType, Type mappingAttributesType)
        {
            return DeleteAllFromDatabase(objectType, CheckBaseDao(), mappingAttributesType);
        }
        public virtual int DeleteAllFromDatabase(Type objectToDeleteType, SpringBaseDao baseDao, Type mappingAttributesType)
        {
            MappingContext mappingContext = MappingContext.GetMappingContext(objectToDeleteType, mappingAttributesType);

            return DeleteAllFromDatabase(objectToDeleteType, baseDao, mappingContext);
        }
        public virtual int DeleteAllFromDatabase(Type objectToDeleteType, SpringBaseDao baseDao, MappingContext mappingContext)
        {
            List<Table> deleteFirstFromTables = null;
            foreach (Table table in mappingContext.Tables.Values)
            {
                if (table.ForeignKeys.Count > 1)
                {
                    CollectionUtils.Add(table, ref deleteFirstFromTables);
                }
            }
            if (deleteFirstFromTables != null)
            {
                // Need to order tables in dependency deletion order
                bool didSwapAny;
                int maxIterationCount = 20;
                do
                {
                    didSwapAny = false;
                    for (int i = deleteFirstFromTables.Count - 1; i >= 0; --i)
                    {
                        Table checkPossibleSwapTable = deleteFirstFromTables[i];
                        int swapBeforeIndex = -1;
                        for (int j = i - 1; j >= 0; --j)
                        {
                            Table checkPossibleParentTable = deleteFirstFromTables[j];
                            foreach (ForeignKeyColumn foreignKeyColumn in checkPossibleSwapTable.ForeignKeys)
                            {
                                if (foreignKeyColumn.ForeignTable == checkPossibleParentTable)
                                {
                                    swapBeforeIndex = j;
                                }
                            }
                        }
                        if (swapBeforeIndex != -1)
                        {
                            didSwapAny = true;
                            deleteFirstFromTables.RemoveAt(i);
                            deleteFirstFromTables.Insert(swapBeforeIndex, checkPossibleSwapTable);
                        }
                    }
                } while ((--maxIterationCount > 0) && didSwapAny);
                if (maxIterationCount == 0)
                {
                    throw new MappingException("Failed to order tables in dependency deletion order");
                }
            }
            int deleteCount = 0;
            baseDao.TransactionTemplate.Execute(delegate
            {
                if (deleteFirstFromTables != null)
                {
                    foreach (Table table in deleteFirstFromTables)
                    {
                        baseDao.DoSimpleDelete(table.TableName, null, null);
                    }
                }
                deleteCount = baseDao.DoSimpleDelete(mappingContext.GetTableNameForType(objectToDeleteType), null, null);
                return null;
            });
            return deleteCount;
        }
        public virtual Dictionary<string, int> SaveToDatabase(object objectToSave, Type mappingAttributesType)
        {
            return SaveToDatabase(objectToSave, CheckBaseDao(), mappingAttributesType);
        }
        public virtual Dictionary<string, int> SaveToDatabase(object objectToSave, bool deleteAllBeforeSave,
                                                              Type mappingAttributesType)
        {
            return SaveToDatabase(objectToSave, CheckBaseDao(), deleteAllBeforeSave, mappingAttributesType);
        }
        public virtual Dictionary<string, int> SaveToDatabase(object objectToSave, SpringBaseDao baseDao,
                                                              bool deleteAllBeforeSave, Type mappingAttributesType)
        {
            Dictionary<string, int> updateRowCounts;
            return SaveToDatabase(objectToSave, baseDao, deleteAllBeforeSave, mappingAttributesType, out updateRowCounts);
        }
        public virtual Dictionary<string, int> SaveToDatabase(object objectToSave, SpringBaseDao baseDao, Type mappingAttributesType)
        {
            Dictionary<string, int> updateRowCounts;
            return SaveToDatabase(objectToSave, baseDao, mappingAttributesType, out updateRowCounts);
        }
        public virtual Dictionary<string, int> SaveToDatabase(object objectToSave, SpringBaseDao baseDao, Type mappingAttributesType,
                                                              out Dictionary<string, int> updateRowCounts)
        {
            return SaveToDatabase(objectToSave, baseDao, false, mappingAttributesType, out updateRowCounts);
        }
        public virtual Dictionary<string, int> SaveToDatabase(object objectToSave, SpringBaseDao baseDao, bool deleteAllBeforeSave,
                                                              Type mappingAttributesType, out Dictionary<string, int> updateRowCounts)
        {
            Type objectToSaveType = objectToSave.GetType();
            MappingContext mappingContext = MappingContext.GetMappingContext(objectToSaveType, mappingAttributesType);

            BuildObjectSql(mappingContext, baseDao);

            IBeforeSaveToDatabase beforeSaveToDatabase = objectToSave as IBeforeSaveToDatabase;
            if (beforeSaveToDatabase != null)
            {
                beforeSaveToDatabase.BeforeSaveToDatabase(this, baseDao, mappingContext);
            }

            Dictionary<string, int> insertRowCounts = new Dictionary<string, int>();
            Dictionary<string, int> updateRowCountsLocal = new Dictionary<string, int>();

            baseDao.TransactionTemplate.Execute(delegate
            {
                baseDao.AdoTemplate.ClassicAdoTemplate.Execute(delegate(IDbCommand command)
                {
                    if (deleteAllBeforeSave)
                    {
                        Type type = objectToSave.GetType();
                        DeleteAllFromDatabase(type, baseDao, mappingContext);
                    }
                    ColumnCachedValues cachedValues = new ColumnCachedValues();
                    SaveToDatabase(null, objectToSave, null, cachedValues, mappingContext,
                                   insertRowCounts, command, baseDao, updateRowCountsLocal);
                    return null;
                });
                return null;
            });
            updateRowCounts = updateRowCountsLocal;
            return insertRowCounts;
        }
        public virtual Dictionary<string, int> SaveToDatabase<T>(IEnumerable<T> objectsToSave, bool deleteAllBeforeSave, Type mappingAttributesType)
        {
            return SaveToDatabase<T>(objectsToSave, CheckBaseDao(), deleteAllBeforeSave, mappingAttributesType);
        }
        public virtual Dictionary<string, int> SaveToDatabase<T>(IEnumerable<T> objectsToSave, SpringBaseDao baseDao,
                                                                 bool deleteAllBeforeSave, Type mappingAttributesType)
        {
            return SaveToDatabase<T>(objectsToSave, baseDao, deleteAllBeforeSave, mappingAttributesType, false);
        }
        public virtual Dictionary<string, int> BuildAndSaveToDatabase<T>(IEnumerable<T> objectsToSave, SpringBaseDao baseDao,
                                                                         bool deleteAllBeforeSave, Type mappingAttributesType)
        {
            return SaveToDatabase<T>(objectsToSave, baseDao, deleteAllBeforeSave, mappingAttributesType, true);
        }
        public virtual Dictionary<string, int> SaveToDatabase<T>(IEnumerable<T> objectsToSave, SpringBaseDao baseDao,
                                                                 bool deleteAllBeforeSave, Type mappingAttributesType,
                                                                 bool checkToBuildDatabase)
        {
            Type objectToSaveType = typeof(T);
            MappingContext mappingContext = MappingContext.GetMappingContext(objectToSaveType, mappingAttributesType);

            return SaveToDatabase<T>(objectsToSave, baseDao, deleteAllBeforeSave, mappingContext, checkToBuildDatabase);
        }
        public virtual Dictionary<string, int> SaveToDatabase<T>(IEnumerable<T> objectsToSave, SpringBaseDao baseDao,
                                                                 bool deleteAllBeforeSave, IMappingContext mappingContext,
                                                                 bool checkToBuildDatabase)
        {
            MappingContext mappingContextSupported = mappingContext as MappingContext;
            if (mappingContextSupported == null)
            {
                throw new ArgException("Custom IMappingContexts are not allow for this method call");
            }

            Type objectToSaveType = typeof(T);

            if (checkToBuildDatabase)
            {
                BuildDatabase(objectToSaveType, baseDao, mappingContextSupported);
            }

            return SaveToDatabase(objectsToSave, baseDao, deleteAllBeforeSave, mappingContextSupported);
        }

        public virtual Dictionary<string, int> SaveToDatabase(IEnumerable objectsToSave, SpringBaseDao baseDao,
                                                              bool deleteAllBeforeSave, MappingContext mappingContext)
        {
            BuildObjectSql(mappingContext, baseDao);

            Dictionary<string, int> insertRowCounts = new Dictionary<string, int>();
            Dictionary<string, int> updateRowCounts = new Dictionary<string, int>();

            baseDao.TransactionTemplate.Execute(delegate
            {
                baseDao.AdoTemplate.ClassicAdoTemplate.Execute(delegate(IDbCommand command)
                {
                    if (deleteAllBeforeSave)
                    {
                        Dictionary<Type, bool> deletedTypes = new Dictionary<Type, bool>();
                        CollectionUtils.ForEach(objectsToSave, delegate(object objectToSave)
                        {
                            Type type = objectToSave.GetType();
                            if (!deletedTypes.ContainsKey(type))
                            {
                                DeleteAllFromDatabase(type, baseDao, mappingContext);
                                deletedTypes[type] = true;
                            }
                        });
                    }
                    CollectionUtils.ForEach(objectsToSave, delegate(object objectToSave)
                    {
                        IBeforeSaveToDatabase beforeSaveToDatabase = objectToSave as IBeforeSaveToDatabase;
                        if (beforeSaveToDatabase != null)
                        {
                            beforeSaveToDatabase.BeforeSaveToDatabase(this, baseDao, mappingContext);
                        }

                        ColumnCachedValues cachedValues = new ColumnCachedValues();
                        SaveToDatabase(null, objectToSave, null, cachedValues, mappingContext, insertRowCounts,
                                       command, baseDao, updateRowCounts);
                    });
                    return null;
                });
                return null;
            });
            return insertRowCounts;
        }
        protected virtual Dictionary<string, DataTableSchema>
            GetCurrentDatabaseTableSchemas(IDictionary<string, Table> tables, SpringBaseDao baseDao)
        {
            // TODO: Could optimize this to use a single connection for all tables
            if (CollectionUtils.IsNullOrEmpty(tables))
            {
                return null;
            }
            Dictionary<string, DataTableSchema> rtnTables = new Dictionary<string, DataTableSchema>(tables.Count);
            ////if (baseDao.IsSqlServerDatabase)
            ////{
            using (var connection = baseDao.DbProvider.CreateConnection())
            {
                connection.Open();
                using (var command = baseDao.DbProvider.CreateCommand())
                {
                    command.Connection = connection;
                    foreach (string tableName in tables.Keys)
                    {
                        string cmdText = string.Format("SELECT * FROM {0} WHERE 1 = 0", tableName);
                        try
                        {
                            command.CommandText = cmdText;
                            using (var reader = command.ExecuteReader(CommandBehavior.KeyInfo))
                            {
                                DataTable schemaTable = reader.GetSchemaTable();
                                if (schemaTable != null)
                                {
                                    rtnTables.Add(tableName, new DataTableSchema(schemaTable));
                                }
                                else
                                {
                                    rtnTables.Add(tableName, new DataTableSchema(schemaTable));
                                }
                            }
                        }
                        catch (Exception)
                        {
                            if (!baseDao.IsSqlServerDatabase)
                            {
                                DebugUtils.CheckDebuggerBreak();    // Not sure if GetSchemaTable() works on ORA, need to check here
                            }
                            rtnTables.Add(tableName, null);
                        }
                    }
                }
            }
            ////}
            ////else
            ////{
            ////    foreach (string tableName in tables.Keys)
            ////    {
            ////        string cmdText = string.Format("SELECT * FROM {0} WHERE 1 = 0", tableName);
            ////        try
            ////        {
            ////            DataTable dataTable = new DataTable();
            ////            baseDao.FillTable(dataTable, cmdText);
            ////            rtnTables.Add(tableName, dataTable);
            ////        }
            ////        catch (Exception)
            ////        {
            ////            rtnTables.Add(tableName, null);
            ////        }
            ////    }
            ////}
            return rtnTables;
        }
        protected virtual Dictionary<string, DataTableSchema> BuildDatabase(IDictionary<string, Table> tables,
                                                                            SpringBaseDao baseDao, out bool createdDatabase)
        {
            createdDatabase = false;
            ConnectionTxPair connectionTxPairToUse = null;
            try
            {
                connectionTxPairToUse = ConnectionUtils.GetConnectionTxPair(baseDao.DbProvider);
                ConnectionUtils.DisposeConnection(connectionTxPairToUse.Connection, baseDao.DbProvider);
                connectionTxPairToUse = null;
                return GetCurrentDatabaseTableSchemas(tables, baseDao);
            }
            catch (CannotGetAdoConnectionException)
            {
                // Database probably does not exist, so attempt to create it below
            }
            finally
            {
                if (connectionTxPairToUse != null)
                {
                    ConnectionUtils.DisposeConnection(connectionTxPairToUse.Connection, baseDao.DbProvider);
                    connectionTxPairToUse = null;
                }
            }
            string saveConnectionString = baseDao.DbProvider.ConnectionString;
            string databaseName;
            string newConnectionString =
                SpringBaseDao.RemoveDatabaseFromConnectionString(baseDao.DbProvider, out databaseName);
            if (string.IsNullOrEmpty(databaseName))
            {
                throw new ArgumentException(string.Format("Could not locate database name in connection string: \"{0}\"",
                                                          baseDao.DbProvider.ConnectionString));
            }
            baseDao.DbProvider.ConnectionString = newConnectionString;
            try
            {
                connectionTxPairToUse = ConnectionUtils.GetConnectionTxPair(baseDao.DbProvider);
                string sql = string.Format("CREATE DATABASE {0}", databaseName);
                baseDao.AdoTemplate.ExecuteNonQuery(CommandType.Text, sql);
                createdDatabase = true;
            }
            finally
            {
                if (connectionTxPairToUse != null)
                {
                    ConnectionUtils.DisposeConnection(connectionTxPairToUse.Connection, baseDao.DbProvider);
                    connectionTxPairToUse = null;
                }
                baseDao.DbProvider.ConnectionString = saveConnectionString;
            }
            // Wait for database to be fully created
            long timeoutTicks = DateTime.Now.Ticks + TimeSpan.FromSeconds(CREATE_DATABASE_WAIT_SECONDS).Ticks;
            do
            {
                try
                {
                    return GetCurrentDatabaseTableSchemas(tables, baseDao);
                }
                catch (DataAccessException)
                {
                }
                Thread.Sleep(300);
            }
            while (timeoutTicks > DateTime.Now.Ticks);
            throw new CannotGetAdoConnectionException();
        }
        protected virtual bool TestDbConnection(string connectionString)
        {
            try
            {
                const string cDatabaseConnectTimeoutParamName = "Connect Timeout";
                if (connectionString.IndexOf(cDatabaseConnectTimeoutParamName, StringComparison.InvariantCultureIgnoreCase) < 0)
                {
                    connectionString += ";" + cDatabaseConnectTimeoutParamName + "=10";
                }
                IDbProvider dbProvider =
                    global::Spring.Data.Common.DbProviderFactory.GetDbProvider("System.Data.SqlClient");
                dbProvider.ConnectionString = connectionString;
                using (System.Data.IDbConnection connection = dbProvider.CreateConnection())
                {
                    connection.Open();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        protected virtual void BuildTables(IDictionary<string, DataTableSchema> existingTableSchemas,
                                           MappingContext mappingContext,
                                           SpringBaseDao baseDao, bool createdDatabase)
        {
            IDictionary<string, Table> tables = mappingContext.Tables;
            if (CollectionUtils.IsNullOrEmpty(tables))
            {
                return;
            }
            string commandSeparator = "!!!";
            List<Column> descriptionColumns = new List<Column>();
            StringBuilder sqlString = new StringBuilder();
            List<string> postCommands = new List<string>();
            List<string> primaryKeyCommands = new List<string>();
            List<string> indexNames = new List<string>();
            List<Table> descriptionTables = new List<Table>();
            foreach (Table table in tables.Values)
            {
                ICollection<Column> columns = table.AllColumns;
                DataTableSchema tableSchema = existingTableSchemas[table.TableName];
                if (tableSchema == null)
                {
                    bool firstColumn = true;
                    // This table is not in the database
                    sqlString.AppendFormat("CREATE TABLE {0} (", table.TableName);
                    foreach (Column column in columns)
                    {
                        if (!firstColumn)
                        {
                            sqlString.Append(',');
                        }
                        firstColumn = false;
                        string addString = GetAddColumnString(column, mappingContext, baseDao, primaryKeyCommands, postCommands,
                                                              descriptionColumns, indexNames);
                        sqlString.Append(addString);
                    }
                    sqlString.AppendFormat(") {0} ", commandSeparator);
                    descriptionTables.Add(table);
                }
                else
                {
                    // This table is in the database, check columns
                    foreach (Column column in columns)
                    {
                        DataTableSchema.IDataColumnSchema columnSchema = tableSchema.TryGetColumn(column.ColumnName);
                        if (columnSchema == null)
                        {
                            // Column does not exist
                            string addString = GetAddColumnString(column, mappingContext, baseDao, primaryKeyCommands, postCommands,
                                                                  descriptionColumns, indexNames);
                            sqlString.Append(string.Format("ALTER TABLE {0} ADD {1} {2} ", table.TableName, addString, commandSeparator));
                        }
                        else if (!column.IsPrimaryKey && !column.IsForeignKey)
                        {
                            if ((columnSchema.DataType == typeof(string)) && column.ColumnType.HasValue &&
                                 Utils.IsStringColumnType(column.ColumnType.Value))
                            {
                                if ((columnSchema.ColumnSize > 0) && (column.ColumnSize > 0) && (column.ColumnSize > columnSchema.ColumnSize))
                                {
                                    string addString = GetAddColumnString(column, mappingContext, baseDao, null, null, null, null);
                                    sqlString.Append(string.Format("ALTER TABLE {0} ALTER COLUMN {1} {2} ", table.TableName, addString, commandSeparator));
                                }
                            }
                        }
                    }
                }
            }
            string pkFormat = baseDao.IsOracleDatabase ? ORA_SERVER_NOT_EXISTS_PK_FORMAT_STRING : SQL_SERVER_NOT_EXISTS_PK_FORMAT_STRING;
            string fkFormat = baseDao.IsOracleDatabase ? ORA_SERVER_NOT_EXISTS_FK_FORMAT_STRING : SQL_SERVER_NOT_EXISTS_FK_FORMAT_STRING;
            string idxFormat = baseDao.IsOracleDatabase ? ORA_SERVER_NOT_EXISTS_INDEX_FORMAT_STRING : SQL_SERVER_NOT_EXISTS_INDEX_FORMAT_STRING;

            CollectionUtils.ForEach(mappingContext.AdditionalCreateIndexAttributes,
                delegate(AdditionalCreateIndexAttribute indexAttribute)
                {
                    string idxName = Utils.GetIndexName(indexAttribute.ParentTable, indexAttribute.ParentTablePrefix, indexAttribute.ColumnName,
                                                        mappingContext.ShortenNamesByRemovingVowelsFirst, mappingContext.FixShortenNameBreakBug,
                                                        mappingContext.DefaultTableNamePrefix);
                    idxName = CheckDatabaseNameDoesNotExist(idxName, indexNames);
                    string cmd = string.Format("CREATE {0} INDEX {1} ON {2}({3})", indexAttribute.IsUnique ? "UNIQUE" : "",
                                               idxName, indexAttribute.ParentTable,
                                               indexAttribute.ColumnName);
                    cmd = string.Format(idxFormat, idxName, indexAttribute.ParentTable, cmd);
                    postCommands.Add(cmd);
                });

            CollectionUtils.ForEach(mappingContext.AdditionalForeignKeyAttributes,
                delegate(AdditionalForeignKeyAttributeEx fkAttribute)
                {
                    CollectionUtils.ForEach(fkAttribute.ChildTableColumnPairs,
                        delegate(KeyValuePair<string, string> childTableColumnPair)
                        {
                            string parentIndexColumnName = fkAttribute.ParentColumnName.Replace(" ", "").Replace(',', Utils.NAME_SEPARATOR_CHAR);
                            string fkName =
                                string.Format("FK_{0}_{1}_{2}_{3}", Utils.RemoveTableNamePrefix(childTableColumnPair.Key, null,
                                                                                                mappingContext.DefaultTableNamePrefix),
                                                            childTableColumnPair.Value,
                                                            Utils.RemoveTableNamePrefix(fkAttribute.ParentTableName, null,
                                                                                        mappingContext.DefaultTableNamePrefix),
                                                            parentIndexColumnName);
                            fkName = Utils.ShortenDatabaseName(fkName, Utils.MAX_CONSTRAINT_NAME_CHARS, mappingContext.ShortenNamesByRemovingVowelsFirst,
                                                               mappingContext.FixShortenNameBreakBug, null);
                            fkName = CheckDatabaseNameDoesNotExist(fkName, indexNames);
                            string cmd = string.Format("ALTER TABLE {0} ADD CONSTRAINT {1} FOREIGN KEY ({2}) REFERENCES {3}({4})",
                                                        childTableColumnPair.Key, fkName, childTableColumnPair.Value,
                                                        fkAttribute.ParentTableName, fkAttribute.ParentColumnName);
                            if (fkAttribute.DeleteRule != DeleteRule.None)
                            {
                                cmd += (fkAttribute.DeleteRule == DeleteRule.Cascade) ? " ON DELETE CASCADE" : " ON DELETE SET NULL";
                            }
                            if (fkAttribute.UpdateRule != UpdateRule.None)
                            {
                                if (baseDao.IsSqlServerDatabase)
                                {
                                    // UPDATE only supported on Sql Server
                                    cmd += (fkAttribute.UpdateRule == UpdateRule.Cascade) ? " ON UPDATE CASCADE" : " ON UPDATE SET NULL";
                                }
                            }
                            cmd = string.Format(fkFormat, fkName, childTableColumnPair.Key, cmd);

                            postCommands.Add(cmd);
                            Table parentTable = mappingContext.Tables[childTableColumnPair.Key];
                            PrimaryKeyColumn pkColumn = parentTable.PrimaryKey;
                            if ((pkColumn == null) || (pkColumn.ColumnName != childTableColumnPair.Value))
                            {
                                string indexColumnName = childTableColumnPair.Value.Replace(" ", "").Replace(',', Utils.NAME_SEPARATOR_CHAR);
                                string idxName =
                                    string.Format("IX_{0}_{1}", Utils.RemoveTableNamePrefix(childTableColumnPair.Key, null,
                                                                                            mappingContext.DefaultTableNamePrefix),
                                                                indexColumnName);

                                idxName = Utils.ShortenDatabaseName(idxName, Utils.MAX_INDEX_NAME_CHARS, mappingContext.ShortenNamesByRemovingVowelsFirst,
                                                                    mappingContext.FixShortenNameBreakBug, null);
                                idxName = CheckDatabaseNameDoesNotExist(idxName, indexNames);
                                cmd = string.Format("CREATE INDEX {0} ON {1}({2})", idxName, childTableColumnPair.Key,
                                                    childTableColumnPair.Value);
                                cmd = string.Format(idxFormat, idxName, childTableColumnPair.Key, cmd);
                                postCommands.Add(cmd);
                            }
                        });
                });

            if (primaryKeyCommands.Count > 0)
            {
                sqlString.Append(string.Format(" {0} ", commandSeparator));
                sqlString.Append(StringUtils.Join(string.Format(" {0} ", commandSeparator), primaryKeyCommands));
            }
            if (postCommands.Count > 0)
            {
                sqlString.Append(string.Format(" {0} ", commandSeparator));
                sqlString.Append(StringUtils.Join(string.Format(" {0} ", commandSeparator), postCommands));
            }
            if (sqlString.Length > 0)
            {
                string sqlStringText = sqlString.ToString();
                List<string> commands = StringUtils.SplitAndReallyRemoveEmptyEntries(sqlStringText, commandSeparator, StringComparison.Ordinal);
                long timeoutTicks = DateTime.Now.Ticks + TimeSpan.FromSeconds(CREATE_DATABASE_WAIT_SECONDS).Ticks;
                bool isFirstCommand = true;
                // Database still may not be ready to create tables if we just created the database, 
                // so give it some time
                for (; ; )
                {
                    try
                    {
                        baseDao.TransactionTemplate.Execute(delegate
                        {
                            baseDao.AdoTemplate.ClassicAdoTemplate.Execute(delegate(IDbCommand dbCommand)
                            {
                                dbCommand.CommandType = CommandType.Text;
                                int curIndex = 0;
                                foreach (string command in commands)
                                {
                                    dbCommand.CommandText = command;
                                    try
                                    {
                                        dbCommand.ExecuteNonQuery();
                                        ++curIndex;
                                    }
                                    catch (Exception)
                                    {
                                        DebugUtils.CheckDebuggerBreak();
                                        throw;
                                    }
                                    if (isFirstCommand)
                                    {
                                        isFirstCommand = false;
                                    }
                                }
                                return null;
                            });
                            AddTableDescriptions(descriptionTables, baseDao);
                            AddColumnDescriptions(descriptionColumns, mappingContext, baseDao);
                            return null;
                        });
                        break;
                    }
                    catch (DataAccessException)
                    {
                        if (!isFirstCommand || (timeoutTicks < DateTime.Now.Ticks))
                        {
                            throw;
                        }
                    }
                    catch (TransactionException)
                    {
                        if (!isFirstCommand || (timeoutTicks < DateTime.Now.Ticks))
                        {
                            throw;
                        }
                    }
                    Thread.Sleep(300);
                }
            }
        }
        protected virtual void AddTableDescriptions(IEnumerable<Table> tables, SpringBaseDao baseDao)
        {
            if (baseDao.IsOracleDatabase)
            {
                baseDao.AdoTemplate.ClassicAdoTemplate.Execute(delegate(IDbCommand dbCommand)
                    {
                        foreach (Table table in tables)
                        {
                            string tableDescription = "Schema element: " + table.TableRootType.Name;
                            dbCommand.CommandType = CommandType.Text;
                            dbCommand.CommandText =
                               string.Format("COMMENT ON TABLE {0} IS '{1}'", table.TableName, tableDescription);
                            dbCommand.ExecuteNonQuery();
                        }
                        return null;
                    });
            }
            else
            {
                foreach (Table table in tables)
                {
                    string tableDescription = "Schema element: " + table.TableRootType.Name;
                    baseDao.DoStoredProc("sp_addextendedproperty", "name;value;level0type;level0name;level1type;level1name",
                                     "MS_Description", tableDescription, "SCHEMA", "dbo", "TABLE",
                                     table.TableName);
                }
            }
        }
        protected virtual void AddColumnDescriptions(IList<Column> columns, MappingContext mappingContext,
                                                     SpringBaseDao baseDao)
        {
            if (CollectionUtils.IsNullOrEmpty(columns))
            {
                return;
            }
            if (baseDao.IsOracleDatabase)
            {
                baseDao.AdoTemplate.ClassicAdoTemplate.Execute(delegate(IDbCommand dbCommand)
                    {
                        dbCommand.CommandType = CommandType.Text;
                        foreach (Column column in columns)
                        {
                            if (!string.IsNullOrEmpty(column.ColumnDescription))
                            {
                                string description = column.ColumnDescription.Replace("'", "''");
                                dbCommand.CommandText =
                                    string.Format("COMMENT ON COLUMN {0}.{1} IS '{2}'", column.Table.TableName, column.ColumnName,
                                                  description);
                                dbCommand.ExecuteNonQuery();
                            }
                        }
                        return null;
                    });
            }
            else
            {
                foreach (Column column in columns)
                {
                    if (!string.IsNullOrEmpty(column.ColumnDescription))
                    {
                        baseDao.DoStoredProc("sp_addextendedproperty", "name;value;level0type;level0name;level1type;level1name;level2type;level2name",
                                             "MS_Description", column.ColumnDescription, "SCHEMA", "dbo", "TABLE",
                                             column.Table.TableName, "COLUMN", column.ColumnName);
                    }
                }
            }
        }

        protected virtual string CheckDatabaseNameDoesNotExist(string dbName, List<string> dbNames)
        {
            int count = 2;
            while (dbNames.Contains(dbName))
            {
                dbName = dbName.Remove(dbName.Length - 3) + count.ToString("000");
                ++count;
            }
            dbNames.Add(dbName);
            return dbName;
        }
        protected virtual string GetAddColumnString(Column column, MappingContext mappingContext,
                                                    SpringBaseDao baseDao, List<string> primaryKeyCommands,
                                                    List<String> postCommands, List<Column> descriptionColumns,
                                                    List<string> dbNames)
        {
            string rtnVal = string.Format("\"{0}\" {1}{2}",
                column.ColumnName,
                GetColumnSqlDataTypeCreateString(mappingContext, column, baseDao),
                column.IsNullable ? string.Empty : " NOT NULL");

            if (column.IsPrimaryKey && (column == column.Table.PrimaryKey))
            {
                if (primaryKeyCommands != null)
                {
                    PrimaryKeyColumn primaryKeyColumn = (PrimaryKeyColumn)column;
                    string pkName = Utils.GetPrimaryKeyConstraintName(primaryKeyColumn, mappingContext.ShortenNamesByRemovingVowelsFirst,
                                                                      mappingContext.FixShortenNameBreakBug, mappingContext.DefaultTableNamePrefix);
                    pkName = CheckDatabaseNameDoesNotExist(pkName, dbNames);
                    string pkColumnNames = primaryKeyColumn.ColumnName;
                    CollectionUtils.ForEach(column.Table.AdditionalPrimaryKeyColumns, delegate(PrimaryKeyColumn addPkColumn)
                    {
                        pkColumnNames += "," + addPkColumn.ColumnName;
                    });
                    string cmd = string.Format("ALTER TABLE {0} ADD CONSTRAINT {1} PRIMARY KEY ({2})",
                                               primaryKeyColumn.Table.TableName, pkName, pkColumnNames);
                    primaryKeyCommands.Add(cmd);
                }
            }
            else if (column.IsForeignKey)
            {
                if (postCommands != null)
                {
                    ForeignKeyColumn foreignKeyColumn = (ForeignKeyColumn)column;
                    string fkName = Utils.GetForeignKeyConstraintName(foreignKeyColumn, mappingContext.ShortenNamesByRemovingVowelsFirst,
                                                                      mappingContext.FixShortenNameBreakBug, mappingContext.DefaultTableNamePrefix);
                    fkName = CheckDatabaseNameDoesNotExist(fkName, dbNames);
                    string cmd = string.Format("ALTER TABLE {0} ADD CONSTRAINT {1} FOREIGN KEY ({2}) REFERENCES {3}({4})",
                                               foreignKeyColumn.Table.TableName, fkName, foreignKeyColumn.ColumnName,
                                               foreignKeyColumn.ForeignTable.TableName, foreignKeyColumn.ForeignTable.PrimaryKey.ColumnName);
                    if (foreignKeyColumn.DeleteRule != DeleteRule.None)
                    {
                        cmd += (foreignKeyColumn.DeleteRule == DeleteRule.Cascade) ? " ON DELETE CASCADE" : " ON DELETE SET NULL";
                    }

                    postCommands.Add(cmd);
                    string indexName = Utils.GetIndexName(foreignKeyColumn, mappingContext.ShortenNamesByRemovingVowelsFirst,
                                                          mappingContext.FixShortenNameBreakBug, mappingContext.DefaultTableNamePrefix);
                    indexName = CheckDatabaseNameDoesNotExist(indexName, dbNames);
                    cmd = string.Format("CREATE INDEX {0} ON {1}({2})", indexName,
                                        foreignKeyColumn.Table.TableName, foreignKeyColumn.ColumnName);
                    postCommands.Add(cmd);
                }
            }
            else if (column.IsIndexable != IndexableType.None)
            {
                if (postCommands != null)
                {
                    string indexName = Utils.GetIndexName(column, mappingContext.ShortenNamesByRemovingVowelsFirst,
                                                          mappingContext.FixShortenNameBreakBug, mappingContext.DefaultTableNamePrefix);
                    indexName = CheckDatabaseNameDoesNotExist(indexName, dbNames);
                    string uniqueString = (column.IsIndexable == IndexableType.UniqueIndexable) ? "UNIQUE" : "";
                    string cmd = string.Format("CREATE {0} INDEX {1} ON {2}({3})", uniqueString, indexName,
                                               column.Table.TableName, column.ColumnName);
                    postCommands.Add(cmd);
                }
            }
            if (!string.IsNullOrEmpty(column.ColumnDescription))
            {
                if (descriptionColumns != null)
                {
                    descriptionColumns.Add(column);
                }
            }
            return rtnVal;
        }
        protected virtual string GetColumnSqlDataTypeCreateString(MappingContext mappingContext, Column column,
                                                                  SpringBaseDao baseDao)
        {
            switch (column.ColumnType)
            {
                case DbType.AnsiString:
                    if ((column.ColumnSize > 0) && (column.ColumnSize < 2))
                    {
                        return string.Format("CHARACTER({0})", column.ColumnSize);
                    }
                    else
                    {
                        return string.Format("CHARACTER VARYING({0})", column.ColumnSize);
                    }
                case DbType.AnsiStringFixedLength:
                    return string.Format("CHARACTER({0})", column.ColumnSize);
                case DbType.Guid:
                    return string.Format("CHARACTER VARYING({0})", Utils.GUID_NUM_CHARS);
                case DbType.String:
                    if ((column.ColumnSize > 0) && (column.ColumnSize < 3))
                    {
                        return string.Format("NATIONAL CHARACTER({0})", column.ColumnSize);
                    }
                    else
                    {
                        return string.Format("NATIONAL CHARACTER VARYING({0})", column.ColumnSize);
                    }
                case DbType.StringFixedLength:
                    return string.Format("NATIONAL CHARACTER({0})", column.ColumnSize);
                case DbType.DateTime:
                    return baseDao.IsOracleDatabase ? "TIMESTAMP(6)" : "DATETIME";
                case DbType.Date:
                case DbType.Time:
                    return baseDao.IsOracleDatabase ? "DATE" : "DATETIME";
                case DbType.Int16:
                case DbType.UInt16:
                case DbType.Int32:
                case DbType.UInt32:
                    return baseDao.IsOracleDatabase ? "NUMBER(10)" : "INTEGER";
                case DbType.Int64:
                case DbType.UInt64:
                    return baseDao.IsOracleDatabase ? "NUMBER(20)" : "BIGINT";
                case DbType.Boolean:
                    return baseDao.IsOracleDatabase ? "NUMBER(1)" : "BIT";
                case DbType.Decimal:
                    if ((column.ColumnSize > 0) && (column.ColumnScale > 0))
                    {
                        return string.Format("DECIMAL({0},{1})", column.ColumnSize.ToString(), column.ColumnScale.ToString());
                    }
                    else
                    {
                        return mappingContext.DefaultDecimalCreateString;
                    }
                case DbType.Single:
                    if ((column.ColumnSize > 0) && (column.ColumnScale > 0))
                    {
                        return string.Format("DECIMAL({0},{1})", column.ColumnSize.ToString(), column.ColumnScale.ToString());
                    }
                    else
                    {
                        return mappingContext.DefaultFloatCreateString;
                    }
                case DbType.Double:
                    if ((column.ColumnSize > 0) && (column.ColumnScale > 0))
                    {
                        return string.Format("DECIMAL({0},{1})", column.ColumnSize.ToString(), column.ColumnScale.ToString());
                    }
                    else
                    {
                        return mappingContext.DefaultDoubleCreateString;
                    }
                case DbType.Binary:
                    if (column.ColumnSize == 8)
                    {
                        // Timestamp
                        return "TIMESTAMP";
                    }
                    else if (column.ColumnSize == 0)
                    {
                        return baseDao.IsOracleDatabase ? "BLOB" : "VARBINARY(MAX)";
                    }
                    else
                    {
                        throw new MappingException("Column \"{0}\" of table \"{1}\" has an invalid database data type: \"{2}\"",
                                                   column.ColumnName, column.Table.TableName, column.ColumnType.ToString());
                    }
                default:
                    throw new MappingException("Column \"{0}\" of table \"{1}\" has an invalid database data type: \"{2}\"",
                                               column.ColumnName, column.Table.TableName, column.ColumnType.ToString());
            }
        }
        protected static int CreateColumnsSortComparison(Column column1, Column column2)
        {
            if (column1.IsPrimaryKey && !column2.IsPrimaryKey)
            {
                return -1;
            }
            else if (!column1.IsPrimaryKey && column2.IsPrimaryKey)
            {
                return 1;
            }
            else if (column1.IsPrimaryKey && column2.IsPrimaryKey)
            {
                return string.Compare(column1.ColumnName, column2.ColumnName);
            }
            else
            {
                if (column1.IsForeignKey && !column2.IsForeignKey)
                {
                    return -1;
                }
                else if (!column1.IsForeignKey && column2.IsForeignKey)
                {
                    return 1;
                }
                else if (column1.IsForeignKey && column2.IsForeignKey)
                {
                    return string.Compare(column1.ColumnName, column2.ColumnName);
                }
                else
                {
                    return string.Compare(column1.ColumnName, column2.ColumnName);
                }
            }
        }
        protected virtual void SaveToDatabase(object parentOfObjectToSave, object objectToSave,
                                              Table tableOfObjectToSave, ColumnCachedValues cachedValues, MappingContext mappingContext,
                                              Dictionary<string, int> insertRowCounts, IDbCommand command, SpringBaseDao baseDao,
                                              Dictionary<string, int> updateRowCounts)
        {
            if (objectToSave == null)
            {
                return;
            }

            Type objectToSaveType = objectToSave.GetType();
            if (tableOfObjectToSave == null)
            {
                tableOfObjectToSave = mappingContext.GetTableForType(objectToSaveType);
            }

            Table parentTable = null;
            if (parentOfObjectToSave != null)
            {
                parentTable = mappingContext.GetTableForType(parentOfObjectToSave.GetType());
            }

            bool isUpdate = false;
            ISaveInfoProvider saveInfoProvider = objectToSave as ISaveInfoProvider;
            if (saveInfoProvider != null)
            {
                isUpdate = saveInfoProvider.IsUpdateSave(baseDao, mappingContext);
            }
            if (tableOfObjectToSave.PopulateSaveValues(command, isUpdate, parentOfObjectToSave, parentTable, objectToSave,
                                                       cachedValues))
            {
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    DebugUtils.CheckDebuggerBreak();
                    throw;
                }
                Dictionary<string, int> rowCounts = isUpdate ? updateRowCounts : insertRowCounts;
                if (rowCounts != null)
                {
                    int value;
                    if (rowCounts.TryGetValue(tableOfObjectToSave.TableName, out value))
                    {
                        value++;
                    }
                    else
                    {
                        value = 1;
                    }
                    rowCounts[tableOfObjectToSave.TableName] = value;
                }
            }
            // Save children
            if (tableOfObjectToSave.ChildRelationMembers != null)
            {
                try
                {
                    Dictionary<object, bool> alreadyProcessedMemberValues = new Dictionary<object, bool>(tableOfObjectToSave.ChildRelationMembers.Count);

                    foreach (ChildRelationInfo childRelation in tableOfObjectToSave.ChildRelationMembers)
                    {
                        object relationMember = objectToSave;
                        if (childRelation.ParentToMemberChain != null)
                        {
                            foreach (SameTableElementInfo sameTableElementInfo in childRelation.ParentToMemberChain)
                            {
                                relationMember = sameTableElementInfo.GetMemberValue(relationMember);
                                if (relationMember == null)
                                {
                                    break;
                                }
                            }
                        }

                        if (relationMember != null)
                        {
                            if (childRelation.IsOneToMany)
                            {
                                IEnumerable memberEnumerable = childRelation.GetMemberEnumerable(relationMember);
                                if (memberEnumerable != null)
                                {
                                    if (alreadyProcessedMemberValues.ContainsKey(memberEnumerable))
                                    {
                                        // This is for object[] members that may be mapped to multiple types
                                    }
                                    else
                                    {
                                        bool insertedAny = false;
                                        alreadyProcessedMemberValues[memberEnumerable] = true;
                                        Table elementTable = null;
                                        if (Utils.IsValidColumnType(childRelation.ValueType))
                                        {
                                            elementTable = childRelation.ChildTable;
                                        }
                                        foreach (object element in memberEnumerable)
                                        {
                                            if (element != null)
                                            {
                                                SaveToDatabase(objectToSave, element, elementTable, cachedValues, mappingContext,
                                                               insertRowCounts, command, baseDao, updateRowCounts);
                                                insertedAny = true;
                                            }
                                        }
                                        if (!insertedAny)
                                        {
                                        }
                                    }
                                }
                            }
                            else // One to one
                            {
                                object element = childRelation.GetMemberValue(relationMember);
                                if (element != null)
                                {
                                    if (alreadyProcessedMemberValues.ContainsKey(element))
                                    {
                                        // This is for object members that may be mapped to multiple types
                                    }
                                    else
                                    {
                                        alreadyProcessedMemberValues[element] = true;
                                        Table elementTable = null;
                                        if (Utils.IsValidColumnType(childRelation.ValueType))
                                        {
                                            elementTable = childRelation.ChildTable;
                                        }
                                        if (element != null)
                                        {
                                            SaveToDatabase(objectToSave, element, elementTable, cachedValues, mappingContext,
                                                           insertRowCounts, command, baseDao, updateRowCounts);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    DebugUtils.CheckDebuggerBreak();
                    throw;
                }
            }
        }
        protected SpringBaseDao CheckBaseDao()
        {
            if (_baseDao == null)
            {
                throw new InvalidOperationException("baseDao has not been set");
            }
            return _baseDao;
        }
        private SpringBaseDao _baseDao;

        protected class DataTableSchema
        {
            public interface IDataColumnSchema
            {
                Type DataType
                {
                    get;
                }
                int ColumnSize
                {
                    get;
                }
            }
            public DataTableSchema(DataTable tableSchema)
            {
                _tableSchema = tableSchema;
            }
            public IDataColumnSchema TryGetColumn(string columnName)
            {
                // See http://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqldatareader.getschematable%28v=VS.100%29.aspx
                foreach (DataRow row in _tableSchema.Rows)
                {
                    if (string.Equals((string)row["ColumnName"], columnName, StringComparison.OrdinalIgnoreCase))
                    {
                        return new DataColumnSchema(row);
                    }
                }
                return null;
            }

            private DataTable _tableSchema;

            protected class DataColumnSchema : IDataColumnSchema
            {
                public DataColumnSchema(DataRow dataRow)
                {
                    _dataRow = dataRow;
                }
                public Type DataType
                {
                    get
                    {
                        return (Type)_dataRow["DataType"];
                    }
                }
                public int ColumnSize
                {
                    get
                    {
                        return (int)_dataRow["ColumnSize"];
                    }
                }
                private DataRow _dataRow;
            }
        }
    }
}
