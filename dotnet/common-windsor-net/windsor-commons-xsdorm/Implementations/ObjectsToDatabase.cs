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
using Windsor.Commons.XsdOrm;
using Windsor.Commons.Core;
using Windsor.Commons.Spring;
using Spring.Data;
using Spring.Transaction;
using Spring.Data.Support;
using Spring.Dao;

namespace Windsor.Commons.XsdOrm.Implementations
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
        public virtual void BuildDatabaseForAllBaseDataTypes(Type referenceType)
        {
            BuildDatabaseForAllBaseDataTypes(referenceType, CheckBaseDao());
        }
        public virtual void BuildDatabaseForAllBaseDataTypes(Type referenceType, SpringBaseDao baseDao)
        {
            Type[] types = referenceType.Assembly.GetExportedTypes();
            List<Type> typesToBuild = new List<Type>();
            Type baseDataType = typeof(BaseDataType);
            Type baseChildDataType = typeof(BaseChildDataType);
            string namespacePrefix = referenceType.Namespace;
            foreach (Type type in types)
            {
                if (type.IsClass && !type.IsAbstract && type.Namespace.StartsWith(namespacePrefix) &&
                    baseDataType.IsAssignableFrom(type) && !baseChildDataType.IsAssignableFrom(type))
                {
                    typesToBuild.Add(type);
                }
            }
            foreach (Type typeToBuild in typesToBuild)
            {
                BuildDatabase(typeToBuild, baseDao);
            }
        }
        public virtual void BuildDatabase(Type objectToSaveType)
        {
            BuildDatabase(objectToSaveType, CheckBaseDao());
        }
        public virtual void BuildDatabase(Type objectToSaveType, SpringBaseDao baseDao)
        {
            MappingContext mappingContext = MappingContext.GetMappingContext(objectToSaveType);

            bool createdDatabase;
            Dictionary<string, DataTable> tableSchemas =
                BuildDatabase(mappingContext.Tables, baseDao, out createdDatabase);

            BuildTables(tableSchemas, mappingContext, baseDao, createdDatabase);
        }
        public string GetTableNameForType(Type objectType)
        {
            MappingContext mappingContext = MappingContext.GetMappingContext(objectType);

            return mappingContext.GetTableNameForType(objectType);
        }
        public string GetPrimaryKeyNameForType(Type objectType)
        {
            MappingContext mappingContext = MappingContext.GetMappingContext(objectType);

            return mappingContext.GetPrimaryKeyNameForType(objectType);
        }
        public object GetPrimaryKeyValueForObject(object obj)
        {
            MappingContext mappingContext = MappingContext.GetMappingContext(obj.GetType());

            return mappingContext.GetPrimaryKeyValueForObject(obj);
        }
        public virtual int DeleteAllFromDatabase(Type objectType)
        {
            return DeleteAllFromDatabase(objectType, CheckBaseDao());
        }
        public virtual int DeleteAllFromDatabase(Type objectType, SpringBaseDao baseDao)
        {
            return baseDao.DoSimpleDelete(GetTableNameForType(objectType), null, null);
        }
        public virtual Dictionary<string, int> SaveToDatabase(object objectToSave)
        {
            return SaveToDatabase(objectToSave, CheckBaseDao());
        }
        public virtual Dictionary<string, int> SaveToDatabase(object objectToSave, SpringBaseDao baseDao)
        {
            Type objectToSaveType = objectToSave.GetType();
            MappingContext mappingContext = MappingContext.GetMappingContext(objectToSaveType);

            BuildObjectSql(mappingContext.ObjectPaths, baseDao);

            IBeforeSaveToDatabase beforeSaveToDatabase = objectToSave as IBeforeSaveToDatabase;
            if (beforeSaveToDatabase != null)
            {
                beforeSaveToDatabase.BeforeSaveToDatabase();
            }

            string objectPath = objectToSaveType.FullName;
            Dictionary<string, int> insertRowCounts = new Dictionary<string, int>();

            baseDao.TransactionTemplate.Execute(delegate
            {
                baseDao.AdoTemplate.ClassicAdoTemplate.Execute(delegate(IDbCommand command)
                {
                    Dictionary<string, object> previousInsertColumnValues = new Dictionary<string, object>();
                    SaveToDatabase(objectToSave, objectPath, mappingContext,
                                   previousInsertColumnValues, insertRowCounts,
                                   command);
                    return null;
                });
                return null;
            });
            return insertRowCounts;
        }
        public virtual Dictionary<string, int> SaveToDatabase<T>(IEnumerable<T> objectsToSave, bool deleteAllBeforeSave)
        {
            return SaveToDatabase<T>(objectsToSave, CheckBaseDao(), deleteAllBeforeSave);
        }
        public virtual Dictionary<string, int> SaveToDatabase<T>(IEnumerable<T> objectsToSave, SpringBaseDao baseDao,
                                                                 bool deleteAllBeforeSave)
        {
            Type objectToSaveType = typeof(T);
            MappingContext mappingContext = MappingContext.GetMappingContext(objectToSaveType);

            BuildObjectSql(mappingContext.ObjectPaths, baseDao);

            Dictionary<string, int> insertRowCounts = new Dictionary<string, int>();

            baseDao.TransactionTemplate.Execute(delegate
            {
                baseDao.AdoTemplate.ClassicAdoTemplate.Execute(delegate(IDbCommand command)
                {
                    if (deleteAllBeforeSave)
                    {
                        DeleteAllFromDatabase(objectToSaveType, baseDao);
                    }
                    CollectionUtils.ForEach(objectsToSave, delegate(T objectToSave)
                    {
                        bool doSave = true;
                        ICanSaveToDatabase checkToSaveToDatabase = objectToSave as ICanSaveToDatabase;
                        if (checkToSaveToDatabase != null)
                        {
                            if (!checkToSaveToDatabase.CanSaveToDatabase(this, baseDao))
                            {
                                doSave = false;
                            }
                        }
                        if (doSave)
                        {
                            IBeforeSaveToDatabase beforeSaveToDatabase = objectToSave as IBeforeSaveToDatabase;
                            if (beforeSaveToDatabase != null)
                            {
                                beforeSaveToDatabase.BeforeSaveToDatabase();
                            }

                            string objectPath = objectToSaveType.FullName;

                            Dictionary<string, object> previousInsertColumnValues = new Dictionary<string, object>();
                            SaveToDatabase(objectToSave, objectPath, mappingContext,
                                           previousInsertColumnValues, insertRowCounts,
                                           command);
                        }
                    });
                    return null;
                });
                return null;
            });
            return insertRowCounts;
        }
        protected virtual Dictionary<string, DataTable>
            GetCurrentDatabaseTableSchemas(Dictionary<string, Table> tables, SpringBaseDao baseDao)
        {
            // TODO: Could optimize this to use a single connection for all tables
            if (CollectionUtils.IsNullOrEmpty(tables))
            {
                return null;
            }
            Dictionary<string, DataTable> rtnTables = new Dictionary<string, DataTable>(tables.Count);
            foreach (string tableName in tables.Keys)
            {
                string cmdText = string.Format("SELECT * FROM {0} WHERE 1 = 0", tableName);
                try
                {
                    DataTable dataTable = new DataTable();
                    baseDao.FillTable(dataTable, cmdText);
                    rtnTables.Add(tableName, dataTable);
                }
                catch (Exception)
                {
                    rtnTables.Add(tableName, null);
                }
            }
            return rtnTables;
        }
        protected virtual Dictionary<string, DataTable> BuildDatabase(Dictionary<string, Table> tables,
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
        protected virtual void BuildTables(Dictionary<string, DataTable> existingTableSchemas,
                                           MappingContext mappingContext,
                                           SpringBaseDao baseDao, bool createdDatabase)
        {
            Dictionary<string, Table> tables = mappingContext.Tables;
            if (CollectionUtils.IsNullOrEmpty(tables))
            {
                return;
            }
            string commandSeparator = "!!!";
            List<Column> descriptionColumns = new List<Column>();
            StringBuilder sqlString = new StringBuilder();
            List<string> primaryKeyCommands = new List<string>();
            List<string> postCommands = new List<string>();
            List<string> indexNames = new List<string>();
            List<Table> descriptionTables = new List<Table>();
            foreach (Table table in tables.Values)
            {
                bool hasTableAliasName = !string.IsNullOrEmpty(table.TableAliasName);
                if (!hasTableAliasName)
                {
                    List<Column> columns = new List<Column>(table.Columns);
                    // Check for any additional aliased tables
                    foreach (Table checkTable in tables.Values)
                    {
                        if ((checkTable != table) && !string.IsNullOrEmpty(checkTable.TableAliasName) && (checkTable.TableAliasName == table.TableName) &&
                            !CollectionUtils.IsNullOrEmpty(checkTable.ForeignKeys))
                        {
                            if (checkTable.ForeignKeys.Count != 1)
                            {
                                throw new ArgumentException("A table with a TableAliasName must have only one FK");
                            }
                            columns.Add(CollectionUtils.FirstItem(checkTable.ForeignKeys));
                        }
                    }
                    DataTable tableSchema = existingTableSchemas[table.TableName];
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
                            string addString = GetAddColumnString(column, mappingContext, baseDao, postCommands,
                                                                  primaryKeyCommands, descriptionColumns, indexNames);
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
                            DataColumn columnSchema = tableSchema.Columns[column.ColumnName];
                            if (columnSchema == null)
                            {
                                // Column does not exist
                                string addString = GetAddColumnString(column, mappingContext, baseDao, postCommands,
                                                                      primaryKeyCommands, descriptionColumns, indexNames);
                                sqlString.Append(string.Format("ALTER TABLE {0} ADD {1} {2} ", table.TableName, addString, commandSeparator));
                            }
                        }
                    }
                }
            }
            string pkFormat = baseDao.IsOracleDatabase ? ORA_SERVER_NOT_EXISTS_PK_FORMAT_STRING : SQL_SERVER_NOT_EXISTS_PK_FORMAT_STRING;
            string fkFormat = baseDao.IsOracleDatabase ? ORA_SERVER_NOT_EXISTS_FK_FORMAT_STRING : SQL_SERVER_NOT_EXISTS_FK_FORMAT_STRING;
            string idxFormat = baseDao.IsOracleDatabase ? ORA_SERVER_NOT_EXISTS_INDEX_FORMAT_STRING : SQL_SERVER_NOT_EXISTS_INDEX_FORMAT_STRING;
            CollectionUtils.ForEach(mappingContext.AdditionalCreatePrimaryKeyAttributes,
                delegate(AdditionalCreatePrimaryKeyAttribute pkAttribute)
                {
                    string pkName = string.Format("PK_{0}", Utils.RemoveTableNamePrefix(pkAttribute.ParentTable, pkAttribute.ParentTablePrefix, mappingContext.DefaultTableNamePrefix));
                    pkName = Utils.ShortenDatabaseName(pkName, Utils.MAX_CONSTRAINT_NAME_CHARS, mappingContext.ShortenNamesByRemovingVowelsFirst,
                                                       mappingContext.FixShortenNameBreakBug, null);
                    pkName = CheckDatabaseNameDoesNotExist(pkName, indexNames);
                    string cmd = string.Format("ALTER TABLE {0} ADD CONSTRAINT {1} PRIMARY KEY ({2})",
                                               pkAttribute.ParentTable, pkName, pkAttribute.ColumnName);
                    cmd = string.Format(pkFormat, pkAttribute.ParentTable, cmd);
                    primaryKeyCommands.Add(cmd);
                });
            CollectionUtils.ForEach(mappingContext.AdditionalCreateForeignKeyAttributes,
                delegate(AdditionalCreateForeignKeyAttribute fkAttribute)
                {
                    string fkName =
                        string.Format("FK_{0}_{1}", Utils.RemoveTableNamePrefix(fkAttribute.ParentTable, fkAttribute.ParentTablePrefix, mappingContext.DefaultTableNamePrefix),
                                                    Utils.RemoveTableNamePrefix(fkAttribute.ReferencedTable, fkAttribute.ReferencedTablePrefix, mappingContext.DefaultTableNamePrefix));
                    string indexColumnName = StringUtils.RemoveAllWhitespace(fkAttribute.ColumnName.Replace(",", "_"));
                    string idxName =
                        string.Format("IX_{0}_{1}", Utils.RemoveTableNamePrefix(fkAttribute.ParentTable, fkAttribute.ParentTablePrefix, mappingContext.DefaultTableNamePrefix),
                                                    indexColumnName);

                    fkName = Utils.ShortenDatabaseName(fkName, Utils.MAX_CONSTRAINT_NAME_CHARS, mappingContext.ShortenNamesByRemovingVowelsFirst,
                                                       mappingContext.FixShortenNameBreakBug, null);
                    fkName = CheckDatabaseNameDoesNotExist(fkName, indexNames);
                    string cmd = string.Format("ALTER TABLE {0} ADD CONSTRAINT {1} FOREIGN KEY ({2}) REFERENCES {3}({4})",
                                                fkAttribute.ParentTable, fkName, fkAttribute.ColumnName,
                                                fkAttribute.ReferencedTable, fkAttribute.ReferencedColumn);
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
                    cmd = string.Format(fkFormat, fkName, fkAttribute.ParentTable, cmd);

                    postCommands.Add(cmd);
                    Table parentTable = mappingContext.Tables[fkAttribute.ParentTable];
                    PrimaryKeyColumn pkColumn = CollectionUtils.FirstItem(parentTable.PrimaryKeys);
                    if ((pkColumn == null) || (pkColumn.ColumnName != fkAttribute.ColumnName))
                    {
                        idxName = Utils.ShortenDatabaseName(idxName, Utils.MAX_INDEX_NAME_CHARS, mappingContext.ShortenNamesByRemovingVowelsFirst,
                                                            mappingContext.FixShortenNameBreakBug, null);
                        idxName = CheckDatabaseNameDoesNotExist(idxName, indexNames);
                        cmd = string.Format("CREATE INDEX {0} ON {1}({2})", idxName, fkAttribute.ParentTable,
                                            fkAttribute.ColumnName);
                        cmd = string.Format(idxFormat, idxName, fkAttribute.ParentTable, cmd);
                        postCommands.Add(cmd);
                    }
                });
            CollectionUtils.ForEach(mappingContext.AdditionalCreateIndexAttributes,
                delegate(AdditionalCreateIndexAttribute indexAttribute)
                {
                    string indexColumnName = StringUtils.RemoveAllWhitespace(indexAttribute.ColumnName.Replace(",", "_"));
                    string idxName =
                        string.Format("IX_{0}_{1}", Utils.RemoveTableNamePrefix(indexAttribute.ParentTable, indexAttribute.ParentTablePrefix, mappingContext.DefaultTableNamePrefix),
                                                    indexColumnName);
                    idxName = Utils.ShortenDatabaseName(idxName, Utils.MAX_INDEX_NAME_CHARS, mappingContext.ShortenNamesByRemovingVowelsFirst,
                                                        mappingContext.FixShortenNameBreakBug, null);
                    idxName = CheckDatabaseNameDoesNotExist(idxName, indexNames);
                    string cmd = string.Format("CREATE {0} INDEX {1} ON {2}({3})", indexAttribute.IsUnique ? "UNIQUE" : "",
                                               idxName, indexAttribute.ParentTable,
                                               indexAttribute.ColumnName);
                    cmd = string.Format(idxFormat, idxName, indexAttribute.ParentTable, cmd);
                    postCommands.Add(cmd);
                });

            if (primaryKeyCommands.Count > 0)
            {
                sqlString.Append(StringUtils.Join(string.Format(" {0} ", commandSeparator), primaryKeyCommands));
            }
            if (postCommands.Count > 0)
            {
                sqlString.Append(StringUtils.Join(string.Format(" {0} ", commandSeparator), postCommands));
            }
            if (sqlString.Length > 0)
            {
                string[] commands = sqlString.ToString().Split(new string[] { commandSeparator }, StringSplitOptions.RemoveEmptyEntries);
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
                                foreach (string command in commands)
                                {
                                    dbCommand.CommandText = command;
                                    dbCommand.ExecuteNonQuery();
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
                            if (string.IsNullOrEmpty(table.TableAliasName))
                            {
                                string tableDescription = "Schema element: " + table.TableRootType.Name;
                                dbCommand.CommandType = CommandType.Text;
                                dbCommand.CommandText =
                                   string.Format("COMMENT ON TABLE {0} IS '{1}'", table.TableName, tableDescription);
                                dbCommand.ExecuteNonQuery();
                            }
                        }
                        return null;
                    });
            }
            else
            {
                foreach (Table table in tables)
                {
                    if (string.IsNullOrEmpty(table.TableAliasName))
                    {
                        string tableDescription = "Schema element: " + table.TableRootType.Name;
                        baseDao.DoStoredProc("sp_addextendedproperty", "name;value;level0type;level0name;level1type;level1name",
                                         "MS_Description", tableDescription, "SCHEMA", "dbo", "TABLE",
                                         table.TableName);
                    }
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
                                string tableName = string.IsNullOrEmpty(column.Table.TableAliasName) ?
                                    column.Table.TableName : column.Table.TableAliasName;
                                string description = column.ColumnDescription.Replace("'", "''");
                                dbCommand.CommandText =
                                    string.Format("COMMENT ON COLUMN {0}.{1} IS '{2}'", tableName, column.ColumnName,
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
                        string tableName = string.IsNullOrEmpty(column.Table.TableAliasName) ?
                            column.Table.TableName : column.Table.TableAliasName;
                        baseDao.DoStoredProc("sp_addextendedproperty", "name;value;level0type;level0name;level1type;level1name;level2type;level2name",
                                             "MS_Description", column.ColumnDescription, "SCHEMA", "dbo", "TABLE",
                                             tableName, "COLUMN", column.ColumnName);
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
                                                    SpringBaseDao baseDao, List<String> postCommands,
                                                    List<String> primaryKeyCommands,
                                                    List<Column> descriptionColumns, List<string> dbNames)
        {
            string rtnVal = string.Format("\"{0}\" {1}{2}",
                column.ColumnName,
                GetColumnSqlDataTypeCreateString(mappingContext, column, baseDao),
                column.IsNullable ? string.Empty : " NOT NULL");

            if (column.IsPrimaryKey)
            {
                PrimaryKeyColumn primaryKeyColumn = (PrimaryKeyColumn)column;
                string pkName = Utils.GetPrimaryKeyConstraintName(primaryKeyColumn, mappingContext.ShortenNamesByRemovingVowelsFirst,
                                                                  mappingContext.FixShortenNameBreakBug, mappingContext.DefaultTableNamePrefix);
                pkName = CheckDatabaseNameDoesNotExist(pkName, dbNames);
                string cmd = string.Format("ALTER TABLE {0} ADD CONSTRAINT {1} PRIMARY KEY ({2})",
                                           primaryKeyColumn.Table.TableName, pkName, primaryKeyColumn.ColumnName);
                primaryKeyCommands.Add(cmd);
            }
            else if (column.IsForeignKey)
            {
                ForeignKeyColumn foreignKeyColumn = (ForeignKeyColumn)column;
                string fkName = Utils.GetForeignKeyConstraintName(foreignKeyColumn, mappingContext.ShortenNamesByRemovingVowelsFirst,
                                                                  mappingContext.FixShortenNameBreakBug, mappingContext.DefaultTableNamePrefix);
                string tableName = string.IsNullOrEmpty(foreignKeyColumn.Table.TableAliasName) ?
                    foreignKeyColumn.Table.TableName : foreignKeyColumn.Table.TableAliasName;
                fkName = CheckDatabaseNameDoesNotExist(fkName, dbNames);
                string cmd = string.Format("ALTER TABLE {0} ADD CONSTRAINT {1} FOREIGN KEY ({2}) REFERENCES {3}({4})",
                                           tableName, fkName, foreignKeyColumn.ColumnName,
                                           foreignKeyColumn.ForeignTable.TableName, foreignKeyColumn.ForeignColumnName);
                if (foreignKeyColumn.DeleteRule != DeleteRule.None)
                {
                    cmd += (foreignKeyColumn.DeleteRule == DeleteRule.Cascade) ? " ON DELETE CASCADE" : " ON DELETE SET NULL";
                }

                postCommands.Add(cmd);
                string indexName = Utils.GetIndexName(foreignKeyColumn, mappingContext.ShortenNamesByRemovingVowelsFirst,
                                                      mappingContext.FixShortenNameBreakBug, mappingContext.DefaultTableNamePrefix);
                indexName = CheckDatabaseNameDoesNotExist(indexName, dbNames);
                cmd = string.Format("CREATE INDEX {0} ON {1}({2})", indexName,
                                    tableName, foreignKeyColumn.ColumnName);
                postCommands.Add(cmd);
            }
            else if (column.IsIndexable)
            {
                string indexName = Utils.GetIndexName(column, mappingContext.ShortenNamesByRemovingVowelsFirst,
                                                      mappingContext.FixShortenNameBreakBug, mappingContext.DefaultTableNamePrefix);
                indexName = CheckDatabaseNameDoesNotExist(indexName, dbNames);
                string cmd = string.Format("CREATE INDEX {0} ON {1}({2})", indexName, column.Table.TableName, column.ColumnName);
                postCommands.Add(cmd);
            }
            if (!string.IsNullOrEmpty(column.ColumnDescription))
            {
                descriptionColumns.Add(column);
            }
            return rtnVal;
        }
        protected virtual string GetColumnSqlDataTypeCreateString(MappingContext mappingContext, Column column,
                                                                  SpringBaseDao baseDao)
        {
            switch (column.ColumnType)
            {
                case DbType.AnsiString:
                    return string.Format("CHARACTER VARYING({0})", column.ColumnSize);
                case DbType.AnsiStringFixedLength:
                    return string.Format("CHARACTER({0})", column.ColumnSize);
                case DbType.String:
                    if ((column.ColumnSize > 0) && (column.ColumnSize < 2))
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
        protected virtual void SaveToDatabase(object objectToSave, string objectPath,
                                              MappingContext mappingContext,
                                              Dictionary<string, object> previousInsertColumnValues,
                                              Dictionary<string, int> insertRowCounts,
                                              IDbCommand command)
        {
            ObjectPath objectPathInstance;
            if (mappingContext.ObjectPaths.TryGetValue(objectPath, out objectPathInstance))
            {
                if (!string.IsNullOrEmpty(objectPathInstance.InsertSql))
                {
                    ObjectTableInfo tableInfo = objectPathInstance.TableInfo;
                    if (tableInfo != null)
                    {
                        command.CommandText = objectPathInstance.InsertSql;
                        command.CommandType = CommandType.Text;
                        command.Parameters.Clear();
                        foreach (Column column in tableInfo.Columns)
                        {
                            if (!column.NoLoad)
                            {
                                IDbDataParameter parameter = command.CreateParameter();
                                parameter.DbType = column.ColumnType.Value;
                                parameter.Direction = ParameterDirection.Input;
                                parameter.Size = column.ColumnSize;
                                parameter.ParameterName = column.ColumnName;
                                parameter.Value =
                                    column.GetInsertColumnValue(objectToSave,
                                                                previousInsertColumnValues);
                                command.Parameters.Add(parameter);
                                string columnPath = Utils.ColumnPath(tableInfo.TableName, column.ColumnName);
                                previousInsertColumnValues[columnPath] = parameter.Value;
                            }
                        }
                        try
                        {
                            command.ExecuteNonQuery();
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                        if (insertRowCounts != null)
                        {
                            int value;
                            if (insertRowCounts.TryGetValue(tableInfo.TableName, out value))
                            {
                                value++;
                            }
                            else
                            {
                                value = 1;
                            }
                            insertRowCounts[tableInfo.TableName] = value;
                        }
                    }
                }
            }
            // Save children
            foreach (Relation relation in objectPathInstance.Relations)
            {
                if (relation is OneToManyRelation)
                {
                    bool insertedAny = false;
                    foreach (object element in relation.GetMemberEnumerable(objectToSave))
                    {
                        if (element != null)
                        {
                            SaveToDatabase(element, relation.MemberInfoPath, mappingContext,
                                           previousInsertColumnValues, insertRowCounts,
                                           command);
                            insertedAny = true;
                        }
                    }
                    if (!insertedAny)
                    {
                    }
                }
                else if (relation is OneToOneRelation)
                {
                    object element = relation.GetMemberValue(objectToSave);
                    if (element != null)
                    {
                        SaveToDatabase(element, relation.MemberInfoPath, mappingContext,
                                       previousInsertColumnValues, insertRowCounts,
                                       command);
                    }
                }
                else
                {
                    throw new NotImplementedException(string.Format("Relationship not implemented: {0}",
                                                                    relation.ToString()));
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
    }
}
