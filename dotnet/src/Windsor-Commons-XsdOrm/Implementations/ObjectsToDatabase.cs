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
using Spring.Data.Support;
using Spring.Dao;

namespace Windsor.Commons.XsdOrm.Implementations
{
    public class ObjectsToDatabase : ObjectsDatabaseBase, IObjectsToDatabase
    {
        public new void Init()
        {
            base.Init();
        }
        public virtual void BuildDatabase(Type objectToSaveType, SpringBaseDao baseDao)
        {
            MappingContext mappingContext = MappingContext.GetMappingContext(objectToSaveType);

            Dictionary<string, DataTable> tableSchemas = BuildDatabase(mappingContext.Tables, baseDao);

            BuildTables(tableSchemas, mappingContext, baseDao);
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
                catch (DbException)
                {
                    rtnTables.Add(tableName, null);
                }
            }
            return rtnTables;
        }
        protected virtual Dictionary<string, DataTable> BuildDatabase(Dictionary<string, Table> tables,
                                                                      SpringBaseDao baseDao)
        {
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
            long timeoutTicks = DateTime.Now.Ticks + TimeSpan.FromSeconds(20).Ticks;
            do
            {
                try
                {
                    return GetCurrentDatabaseTableSchemas(tables, baseDao);
                }
                catch (CannotGetAdoConnectionException)
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
                                           SpringBaseDao baseDao)
        {
            Dictionary<string, Table> tables = mappingContext.Tables;
            if (CollectionUtils.IsNullOrEmpty(tables))
            {
                return;
            }
            string commandSeparator = baseDao.IsOracleDatabase ? ";" : ";";
            List<Column> descriptionColumns = new List<Column>(); ;
            StringBuilder sqlString = new StringBuilder();
            List<string> postCommands = new List<string>();
            List<string> indexNames = new List<string>();
            foreach (Table table in tables.Values)
            {
                ICollection<Column> columns = table.Columns;
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
                                                              descriptionColumns, indexNames);
                        sqlString.Append(addString);
                    }
                    sqlString.AppendFormat(") {0} ", commandSeparator);
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
                                                                  descriptionColumns, indexNames);
                            sqlString.Append(string.Format("ALTER TABLE {0} ADD {1} {2} ", table.TableName, addString, commandSeparator));
                        }
                    }
                }
            }
            if (postCommands.Count > 0)
            {
                sqlString.Append(StringUtils.Join(string.Format(" {0} ", commandSeparator), postCommands));
            }

            if (sqlString.Length > 0)
            {
                string[] commands = sqlString.ToString().Split(new string[] { commandSeparator }, StringSplitOptions.RemoveEmptyEntries);
                baseDao.TransactionTemplate.Execute(delegate
                {
                    baseDao.AdoTemplate.ClassicAdoTemplate.Execute(delegate(IDbCommand dbCommand)
                    {
                        dbCommand.CommandType = CommandType.Text;
                        foreach (string command in commands)
                        {
                            dbCommand.CommandText = command;
                            dbCommand.ExecuteNonQuery();
                        }
                        return null;
                    });
                    AddColumnDescriptions(descriptionColumns, mappingContext, baseDao);
                    return null;
                });
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
                dbName = dbName.Remove(dbName.Length - 2) + count.ToString("00");
                ++count;
            }
            dbNames.Add(dbName);
            return dbName;
        }
        protected virtual string GetAddColumnString(Column column, MappingContext mappingContext,
                                                    SpringBaseDao baseDao, List<String> postCommands,
                                                    List<Column> descriptionColumns, List<string> dbNames)
        {
            string rtnVal = string.Format("{0} {1}{2}",
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
                postCommands.Add(cmd);
            }
            else if (column.IsForeignKey)
            {
                ForeignKeyColumn foreignKeyColumn = (ForeignKeyColumn)column;
                string fkName = Utils.GetForeignKeyConstraintName(foreignKeyColumn, mappingContext.ShortenNamesByRemovingVowelsFirst,
                                                                  mappingContext.FixShortenNameBreakBug, mappingContext.DefaultTableNamePrefix);
                fkName = CheckDatabaseNameDoesNotExist(fkName, dbNames);
                string cmd = string.Format("ALTER TABLE {0} ADD CONSTRAINT {1} FOREIGN KEY ({2}) REFERENCES {3}({4})",
                                           foreignKeyColumn.Table.TableName, fkName, foreignKeyColumn.ColumnName,
                                           foreignKeyColumn.ForeignTable.TableName, foreignKeyColumn.ForeignColumnName);
                if (foreignKeyColumn.DeleteRule != DeleteRule.None)
                {
                    cmd += " ON DELETE CASCADE";
                }

                postCommands.Add(cmd);
                string indexName = Utils.GetIndexName(foreignKeyColumn, mappingContext.ShortenNamesByRemovingVowelsFirst,
                                                      mappingContext.FixShortenNameBreakBug, mappingContext.DefaultTableNamePrefix);
                indexName = CheckDatabaseNameDoesNotExist(indexName, dbNames);
                cmd = string.Format("CREATE INDEX {0} ON {1}({2})", indexName,
                                    foreignKeyColumn.Table.TableName, foreignKeyColumn.ColumnName);
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
                    return string.Format("NATIONAL CHARACTER VARYING({0})", column.ColumnSize);
                case DbType.StringFixedLength:
                    return string.Format("NATIONAL CHARACTER({0})", column.ColumnSize);
                case DbType.DateTime:
                    return baseDao.IsOracleDatabase ? "TIMESTAMP(6)" : "DATETIME";
                case DbType.DateTime2:
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
                    return mappingContext.DefaultDecimalCreateString;
                case DbType.Binary:
                    if (column.ColumnSize == 8)
                    {
                        // Timestamp
                        return "TIMESTAMP";
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
                            IDbDataParameter parameter = command.CreateParameter();
                            parameter.DbType = column.ColumnType.Value;
                            parameter.Direction = ParameterDirection.Input;
                            parameter.Size = column.ColumnSize;
                            parameter.ParameterName = column.ColumnName;
#if DEBUG
                            if (column.ColumnType.Value == DbType.DateTime)
                            {
                            }
#endif // DEBUG
                            parameter.Value =
                                column.GetInsertColumnValue(objectToSave,
                                                            previousInsertColumnValues);
                            command.Parameters.Add(parameter);
                            string columnPath = Utils.ColumnPath(tableInfo.TableName, column.ColumnName);
                            previousInsertColumnValues[columnPath] = parameter.Value;
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
    }
}
