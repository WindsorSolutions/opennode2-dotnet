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
using System.Text;
using System.Data;
using System.Data.Common;
using System.Reflection;
using System.Threading;
using Spring.Data.Generic;
using Spring.Data.Common;
using Spring.Data;
using Spring.Dao;
using Spring.Data.Support;
using Spring.Context;
using Spring.Context.Support;
using Spring.Objects.Factory;
using Spring.Transaction.Support;
using Common.Logging;
using Windsor.Commons.Core;
using Wintellect.PowerCollections;
using Windsor.Commons.Logging;
using SpringCore = Spring.Data.Core;
using SpringDataCommon = Spring.Data.Common;
using System.Data.SqlClient;

namespace Windsor.Commons.Spring
{
    public delegate T ObjectMapperDelegate<T>(NamedNullMappingDataReader readerEx);
    public delegate void HandleMappedObjectArray<T>(T[] array, int listKeyFieldsIndex);

    /// <summary>
    /// Helper class for use with Spring.Data.
    /// </summary>
    public class SpringBaseDao : LoggerBase
    {
        private ITransactionOperations _transactionTemplate;
        private AdoDaoSupport _adoDaoSupport;
        protected const string WHERE_PARAM_NAME = "whrParam";
        protected const string DELETE_PARAM_NAME = "delParam";
        protected readonly char[] SPLIT_CHAR = new char[] { ';' };
        protected string SQL_CONCAT_STRING = string.Empty;

        public SpringBaseDao(IDbProvider dbProvider)
            : this(dbProvider, null)
        {
        }
        public SpringBaseDao(IDbProvider dbProvider, Type dataReaderWrapperType)
        {
            if (dbProvider == null)
            {
                throw new ArgumentNullException("dbProvider");
            }
            _adoDaoSupport = new AdoDaoSupport();
            _adoDaoSupport.AdoTemplate = new AdoTemplate(dbProvider);
            _adoDaoSupport.AdoTemplate.CommandTimeout = 300;    //??
            if (dataReaderWrapperType != null)
            {
                _adoDaoSupport.AdoTemplate.DataReaderWrapperType = dataReaderWrapperType;
            }
            else
            {
                _adoDaoSupport.AdoTemplate.DataReaderWrapperType = typeof(NullMappingDataReader);
            }
            _adoDaoSupport.AdoTemplate.AfterPropertiesSet();
            IAdoExceptionTranslator translator = _adoDaoSupport.AdoTemplate.ExceptionTranslator;
            SpringCore.AdoPlatformTransactionManager transactionManager =
                new SpringCore.AdoPlatformTransactionManager(dbProvider);
            TransactionTemplate transactionTemplate = new TransactionTemplate(transactionManager);
            transactionTemplate.TransactionIsolationLevel = IsolationLevel.ReadCommitted;
            _transactionTemplate = transactionTemplate;
            SQL_CONCAT_STRING = IsOracleDatabase ? "||" : "+";
        }
        public SpringBaseDao()
        {
        }

        #region Init

        public void Init()
        {
            FieldNotInitializedException.ThrowIfNull(this, ref _transactionTemplate);
            FieldNotInitializedException.ThrowIfNull(this, ref _adoDaoSupport);
            SQL_CONCAT_STRING = IsOracleDatabase ? "||" : "+";
        }
        public Exception CheckConnection()
        {
            try
            {
                using (System.Data.IDbConnection connection = this.DbProvider.CreateConnection())
                {
                    connection.Open();
                }
                return null;
            }
            catch (Exception e)
            {
                return e;
            }
        }

        #endregion

        #region Helper Methods

        public delegate void CommandNoReturnDelegate(DbCommand command);
        public static void ExecuteCommandWithTimeout(System.Data.Common.DbCommand command, int timeoutInSeconds,
                                                     CommandNoReturnDelegate del)
        {
            ExecuteCommandWithTimeout<int>(command, timeoutInSeconds, delegate(System.Data.Common.DbCommand commandToExecute)
            {
                del(commandToExecute);
                return 0;
            });
        }
        public static T ExecuteCommandWithTimeout<T>(System.Data.Common.DbCommand command, int timeoutInSeconds,
                                                     CommandDelegate<T> del)
        {
            command.CommandTimeout = timeoutInSeconds;
            if (command.CommandTimeout != timeoutInSeconds)
            {
                // Command does not support timeout, do a manual timeout here
                T rtnVal = default(T);
                ThreadUtils.RunWithTimeout<T, System.Data.Common.DbCommand>(timeoutInSeconds, command,
                    delegate(System.Data.Common.DbCommand commandToExecute)
                    {
                        rtnVal = del(commandToExecute);
                        return rtnVal;
                    });
                return rtnVal;
            }
            else
            {
                return del(command);
            }
        }

        public static readonly string[] SQL_INJECTION_BLACK_LIST = { "--", ";--", ";", "/*", "*/", "@@", "@", "'" };

        public static void ValidateAgainstSqlInjection(string sql)
        {
            if (StringUtils.Contains(sql, SQL_INJECTION_BLACK_LIST, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new ArgumentException(string.Format("Invalid SQL: {0}", sql));
            }
        }
        /// <summary>
        /// Creates parameter name based on index number
        /// </summary>
        /// <param name="index">Number</param>
        /// <returns>p + index</returns>
        public string MakeParameterName(int index)
        {
            return String.Format("p{0}", index);
        }

        /// <summary>
        /// Creates parameter name for that articular provider including all the necessary prefex
        /// </summary>
        /// <param name="name">Name</param>
        /// <returns>Parameter Name</returns>
        public string CreateParameterName(string name)
        {
            return AdoTemplate.DbProvider.CreateParameterName(name);
        }

        public void DoJDBCQueryWithCancelableRowCallbackDelegate(string sql, IList<object> parValues,
                                                                 CancelableRowCallbackDelegate rowCallbackDelegate)
        {
            IDbParameters parameters;
            string selectSql = LoadGenericParametersFromValueList(sql, out parameters, parValues);

            AdoTemplate.ClassicAdoTemplate.QueryWithResultSetExtractor(CommandType.Text, selectSql,
                                                                       new CancelableRowCallbackResultSetExtractor(rowCallbackDelegate),
                                                                       parameters);
        }
        public void DoJDBCQueryWithCancelableRowCallbackDelegate(string sql, CancelableRowCallbackDelegate rowCallbackDelegate,
                                                                 params object[] parValues)
        {
            IDbParameters parameters;
            string selectSql = LoadGenericParameters(sql, out parameters, parValues);

            AdoTemplate.ClassicAdoTemplate.QueryWithResultSetExtractor(CommandType.Text, selectSql,
                                                                       new CancelableRowCallbackResultSetExtractor(rowCallbackDelegate),
                                                                       parameters);
        }

        public void DoJDBCQueryWithRowCallbackDelegate(string sql, IList<object> parValues,
                                                       RowCallbackDelegate rowCallbackDelegate)
        {
            IDbParameters parameters;
            string selectSql = LoadGenericParametersFromValueList(sql, out parameters, parValues);

            AdoTemplate.QueryWithRowCallbackDelegate(CommandType.Text, selectSql, rowCallbackDelegate, parameters);
        }

        public void DoJDBCQueryWithRowCallbackDelegate(string sql, RowCallbackDelegate rowCallbackDelegate,
                                                       params object[] parValues)
        {
            IDbParameters parameters;
            string selectSql = LoadGenericParameters(sql, out parameters, parValues);

            AdoTemplate.QueryWithRowCallbackDelegate(CommandType.Text, selectSql, rowCallbackDelegate, parameters);
        }

        public int DoJDBCExecuteNonQuery(string sql, params object[] parValues)
        {
            IDbParameters parameters;
            string executeSql = LoadGenericParameters(sql, out parameters, parValues);

            return AdoTemplate.ExecuteNonQuery(CommandType.Text, executeSql, parameters);
        }

        /// <summary>
        /// Parses standard JDBC SQL and populates with all the provider specific params and loads them with values
        /// </summary>
        /// <param name="sql">JDBC-compatable SQL</param>
        /// <param name="pars">Collection of IDataParameter created in this method</param>
        /// <param name="parValues">Array of parameter values corresponding to the SQL params</param>
        /// <example>SELCT * FROM table WHERE column = ?</example>
        /// <returns>Parsed SQL</returns>
        public string LoadGenericParametersFromList(string sql, out ICollection<IDataParameter> pars, IList<object> parValues)
        {
            IDbParameters parameters;
            string rtnVal = LoadGenericParametersFromValueList(sql, out parameters, parValues);
            if ((parameters != null) && (parameters.Count > 0))
            {
                List<IDataParameter> list = new List<IDataParameter>(parameters.Count);
                for (int i = 0; i < parameters.Count; ++i)
                {
                    list.Add(parameters[i]);
                }
                pars = list;
                parameters.DataParameterCollection.Clear();
            }
            else
            {
                pars = null;
            }
            return rtnVal;
        }
        /// <summary>
        /// Parses standard JDBC SQL and populates with all the provider specific params and loads them with values
        /// </summary>
        /// <param name="sql">JDBC-compatable SQL</param>
        /// <param name="pars">Collection of IDataParameter created in this method</param>
        /// <param name="parValues">Array of parameter values corresponding to the SQL params</param>
        /// <example>SELCT * FROM table WHERE column = ?</example>
        /// <returns>Parsed SQL</returns>
        public string LoadGenericParameters(string sql, out ICollection<IDataParameter> pars, params object[] parValues)
        {
            return LoadGenericParametersFromList(sql, out pars, parValues);
        }
        public string LoadGenericParameters(string sql, out IDbParameters pars, params object[] parValues)
        {
            return LoadGenericParametersFromValueList(sql, out pars, parValues);
        }
        public void ExecuteSqlWithoutDatabaseConnection(string sqlToExecute)
        {
            string saveConnectionString = DbProvider.ConnectionString;
            string databaseName;
            string newConnectionString =
                SpringBaseDao.RemoveDatabaseFromConnectionString(DbProvider, out databaseName);
            DbProvider.ConnectionString = newConnectionString;
            ConnectionTxPair connectionTxPairToUse = null;
            try
            {
                connectionTxPairToUse = ConnectionUtils.GetConnectionTxPair(DbProvider);
                AdoTemplate.ExecuteNonQuery(CommandType.Text, sqlToExecute);
            }
            finally
            {
                if (connectionTxPairToUse != null)
                {
                    ConnectionUtils.DisposeConnection(connectionTxPairToUse.Connection, DbProvider);
                    connectionTxPairToUse = null;
                }
                DbProvider.ConnectionString = saveConnectionString;
            }
        }
        public string LoadGenericParametersFromValueList(string sql, out IDbParameters pars, IList<object> parValues)
        {
            if (String.IsNullOrEmpty(sql))
            {
                throw new ArgumentNullException("sql");
            }

            pars = AdoTemplate.CreateDbParameters();

            if (sql.Contains("?"))
            {
                int parameterIndex = 0;
                StringBuilder sb = new StringBuilder();
                foreach (char c in sql.ToCharArray())
                {
                    if (c != '?')
                    {
                        sb.Append(c);
                    }
                    else
                    {

                        if (parValues == null || parValues.Count < parameterIndex + 1)
                        {
                            throw new ArgumentException(
                                "Number of parameters in SQL ('?') is greater then the "
                              + "number of values passed to set it with. Parameter #"
                              + parameterIndex + " does not have a value");
                        }

                        string paramName = MakeParameterName(parameterIndex);
                        string providerParamName = CreateParameterName(paramName);

                        LOG.Debug("{0} = {1}", providerParamName, parValues[parameterIndex]);

                        sb.Append(providerParamName);
                        pars.AddWithValue(paramName, parValues[parameterIndex]);

                        parameterIndex++;

                    }
                }

                sql = sb.ToString();

            }

            return sql;

        }
        /// <summary>
        /// Same as LoadGenericParameters() which returns a IDbParameters object, but in this case, returns a
        /// reuable list of parameters.
        /// </summary>
        public string LoadGenericParameters(string sql, out IList<IDataParameter> pars, params object[] parValues)
        {
            return LoadGenericParametersFromValueList(sql, out pars, parValues);
        }
        public string LoadGenericParametersFromValueList(string sql, out IList<IDataParameter> pars, IList<object> parValues)
        {
            IDbParameters parsInt;
            string rtnSql = LoadGenericParametersFromValueList(sql, out parsInt, parValues);
            if ((parsInt != null) && (parsInt.Count > 0))
            {
                pars = new List<IDataParameter>(parsInt.Count);
                for (int i = 0; i < parsInt.Count; ++i)
                {
                    IDataParameter p1 = parsInt[i];
                    pars.Add(parsInt[i]);
                }
                parsInt.DataParameterCollection.Clear();
            }
            else
            {
                pars = null;
            }
            return rtnSql;
        }
        public static string RemoveDatabaseFromConnectionString(IDbProvider dbProvider, out string databaseName)
        {
            databaseName = null;
            if (IsSqlServerProvider(dbProvider))
            {
                List<string> elements = new List<string>(dbProvider.ConnectionString.Split(';'));
                for (int i = elements.Count - 1; i >= 0; --i)
                {
                    string testString = elements[i].Trim().ToUpper();
                    if (testString.StartsWith("DATABASE") || testString.StartsWith("INITIAL CATALOG"))
                    {
                        int index = testString.IndexOf('=');
                        if (index > 0)
                        {
                            databaseName = testString.Substring(index + 1).Trim();
                            elements.RemoveAt(i);
                        }
                    }
                }
                return StringUtils.Join(";", elements);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
        public static string GetDatabaseNameFromConnectionString(IDbProvider dbProvider)
        {
            if (IsSqlServerProvider(dbProvider))
            {
                SqlConnection connection = new SqlConnection(dbProvider.ConnectionString);
                return connection.Database;
            }
            else
            {
                throw new NotImplementedException();
            }
        }
        public static string GetServerNameFromConnectionString(IDbProvider dbProvider)
        {
            if (IsSqlServerProvider(dbProvider))
            {
                SqlConnection connection = new SqlConnection(dbProvider.ConnectionString);
                return connection.DataSource;
            }
            else
            {
                throw new NotImplementedException();
            }
        }
        public string GetServerNameFromConnectionString()
        {
            return GetServerNameFromConnectionString(this.DbProvider);
        }

        /// <summary>
        /// Make sure 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public string ParseParamName(string name)
        {
            return DbProvider.CreateParameterName(name);
        }
        protected string CreateInsertSqlParamText(string tableName, string semicolonSeparatedColumnNames,
                                                  out string[] columnNames)
        {
            if (string.IsNullOrEmpty(tableName))
            {
                throw new ArgumentException("tableName is empty");
            }
            if (string.IsNullOrEmpty(semicolonSeparatedColumnNames))
            {
                throw new ArgumentException("columnNames is empty");
            }
            columnNames = semicolonSeparatedColumnNames.Split(SPLIT_CHAR, StringSplitOptions.RemoveEmptyEntries);
            if (columnNames.Length == 0)
            {
                throw new ArgumentException("columnNames is empty");
            }
            StringBuilder sb;
            if (IsOracleDatabase)
            {
                sb = new StringBuilder("INSERT INTO ");
                sb.Append(tableName);
                sb.Append(" (");
                sb.Append(string.Join(",", columnNames));
                sb.Append(") VALUES (");
            }
            else
            {
                sb = new StringBuilder("INSERT INTO \"");
                sb.Append(tableName);
                sb.Append("\" (\"");
                sb.Append(string.Join("\",\"", columnNames));
                sb.Append("\") VALUES (");
            }
            bool addedFirst = false;
            foreach (string columnName in columnNames)
            {
                if (addedFirst) sb.Append(','); else addedFirst = true;
                sb.Append(ParseParamName(columnName));
            }
            sb.Append(")");
            return sb.ToString();
        }
        protected string CreateInsertSqlParamText(string tableName, string semicolonSeparatedColumnNames)
        {
            string[] columnNames;
            return CreateInsertSqlParamText(tableName, semicolonSeparatedColumnNames,
                                            out columnNames);
        }
        public bool IsOracleDatabase
        {
            get { return IsOracleDatabaseProvider(DbProvider); }
        }
        public bool IsSqlServerDatabase
        {
            get { return IsSqlServerDatabaseProvider(DbProvider); }
        }
        public static bool IsOracleDatabaseProvider(IDbProvider dbProvider)
        {
            // This works for both System.Data.OracleClient.OracleParameter and Oracle.DataAccess.Client.OracleParameter
            return (dbProvider.DbMetadata.ParameterType.Name == "OracleParameter");
        }
        public static bool IsSqlServerDatabaseProvider(IDbProvider dbProvider)
        {
            return (dbProvider.DbMetadata.ParameterType == typeof(System.Data.SqlClient.SqlParameter));
        }
        public static bool IsSqlServerProvider(IDbProvider dbProvider)
        {
            return (dbProvider.DbMetadata.ParameterType == typeof(System.Data.SqlClient.SqlParameter));
        }
        protected IDbParameters MakeStoredProcReaderDbParameters(string semicolonSeparatedArgNames, object[] args)
        {
            IDbParameters parameters = MakeStoredProcDbParameters(semicolonSeparatedArgNames, args);
            if (IsOracleDatabase)
            {
                if (parameters == null)
                {
                    parameters = AdoTemplate.CreateDbParameters();
                }
                parameters.Add("cur_out", System.Data.OracleClient.OracleType.Cursor).Direction = ParameterDirection.Output;
            }
            return parameters;
        }
        protected IDbParameters MakeStoredProcDbParameters(string semicolonSeparatedArgNames,
                                                           IList<object> args)
        {
            if (CollectionUtils.IsNullOrEmpty(args))
            {
                if (!string.IsNullOrEmpty(semicolonSeparatedArgNames))
                {
                    throw new ArgumentException(string.Format("args is null or empty, but semicolonSeparatedArgNames({0}) is not",
                                                              semicolonSeparatedArgNames));
                }
                return null;
            }
            IDbParameters parameters = AdoTemplate.CreateDbParameters();
            if (string.IsNullOrEmpty(semicolonSeparatedArgNames))
            {
                foreach (object param in args)
                {
                    parameters.Add(param);
                }
            }
            else
            {
                string[] columnNames = semicolonSeparatedArgNames.Split(SPLIT_CHAR, StringSplitOptions.RemoveEmptyEntries);
                if (columnNames.Length != args.Count)
                {
                    throw new ArgumentException(string.Format("columnNames.Length({0}) != args.Length({1}), semicolonSeparatedColumnNames({2})",
                                                              columnNames.Length, args.Count, semicolonSeparatedArgNames));
                }
                for (int i = 0; i < columnNames.Length; ++i)
                {
                    parameters.AddWithValue(columnNames[i], args[i]);
                }
            }
            return parameters;
        }
        public void DoStoredProcWithRowCallbackDelegate(string procName, string semicolonSeparatedArgNames,
                                                        object[] args, RowCallbackDelegate callback)
        {
            IDbParameters parameters = MakeStoredProcReaderDbParameters(semicolonSeparatedArgNames, args);
            if (parameters == null)
            {
                QueryWithRowCallbackDelegate(CommandType.StoredProcedure, procName, callback);
            }
            else
            {
                QueryWithRowCallbackDelegate(CommandType.StoredProcedure, procName, callback, parameters);
            }
        }
        public int DoStoredProc(string procName)
        {
            return DoStoredProcWithArgs(procName, (string)null, (object[])null);
        }
        public int DoStoredProc(string procName, string semicolonSeparatedArgNames,
                                        params object[] args)
        {
            return DoStoredProcWithArgs(procName, semicolonSeparatedArgNames, args);
        }
        public int DoStoredProcWithArgs(string procName, string semicolonSeparatedArgNames,
                                        IList<object> args)
        {
            IDbParameters parameters = MakeStoredProcDbParameters(semicolonSeparatedArgNames, args);
            if (parameters == null)
            {
                return AdoTemplate.ExecuteNonQuery(CommandType.StoredProcedure, procName);
            }
            else
            {
                return AdoTemplate.ExecuteNonQuery(CommandType.StoredProcedure, procName, parameters);
            }
        }
        public int FillTableFromStoredProc(DataTable table, string procName, string semicolonSeparatedArgNames,
                                           params object[] args)
        {
            IDbParameters parameters = MakeStoredProcReaderDbParameters(semicolonSeparatedArgNames, args);
            if (parameters == null)
            {
                return AdoTemplate.ClassicAdoTemplate.DataTableFill(table, CommandType.StoredProcedure, procName);
            }
            else
            {
                return AdoTemplate.ClassicAdoTemplate.DataTableFillWithParams(table, CommandType.StoredProcedure,
                                                                              procName, parameters);
            }
        }
        public int FillTable(DataTable table, string selectStatement)
        {
            return AdoTemplate.ClassicAdoTemplate.DataTableFill(table, CommandType.Text, selectStatement);
        }
        public DataTable FillTable(string selectStatement)
        {
            DataTable table = new DataTable();
            return (FillTable(table, selectStatement) > 0) ? table : null;
        }
        public string GetSemicolonSeparatedColumnNames(DataTable table)
        {
            if ((table == null) || (table.Columns == null) || (table.Columns.Count == 0))
            {
                return string.Empty;
            }
            StringBuilder sb = new StringBuilder();
            foreach (DataColumn column in table.Columns)
            {
                if (sb.Length > 0)
                {
                    sb.Append(';');
                }
                sb.Append(column.ColumnName);
            }
            return sb.ToString();
        }
        public void DoInsert(string tableName, string semicolonSeparatedColumnNames, params object[] values)
        {
            DoInsertWithValues(tableName, semicolonSeparatedColumnNames, values);
        }
        public void DoInsertWithValues(string tableName, string semicolonSeparatedColumnNames,
                                       IList<object> values)
        {
            string[] columnNames;
            string insertText = CreateInsertSqlParamText(tableName, semicolonSeparatedColumnNames,
                                                         out columnNames);

            if (CollectionUtils.IsNullOrEmpty(values) || (values.Count != columnNames.Length))
            {
                throw new ArgumentException("Invalid values specified.");
            }

            IDbParameters parameters = AdoTemplate.CreateDbParameters();
            for (int i = 0; i < values.Count; ++i)
            {
                if (values[i] == null)
                {
                    parameters.AddWithValue(columnNames[i], DBNull.Value);
                }
                else
                {
                    byte[] byteArray = values[i] as byte[];
                    if (byteArray != null)
                    {
                        // Fix bug in spring for null byte[]
                        IDbDataParameter param;
                        if (byteArray.Length == 0)
                        {
                            param = parameters.AddWithValue(columnNames[i], DBNull.Value);
                        }
                        else
                        {
                            param = parameters.AddWithValue(columnNames[i], values[i]);
                        }
                        param.DbType = DbType.Binary;
                    }
                    else
                    {
                        parameters.AddWithValue(columnNames[i], values[i]);
                    }
                }
            }

            LOG.DebugArguments("AdoTemplate.ExecuteNonQuery()", "CommandType.Text", CommandType.Text);

            int result = AdoTemplate.ExecuteNonQuery(CommandType.Text, insertText, parameters);

            if (result < 1)
            {
                throw new UncategorizedAdoException(string.Format("Failed to insert: \"{0}\".",
                                                                  insertText));
            }
        }
        public delegate IList<object> GetInsertValuesDelegate(int currentInsertIndex);
        public void DoBulkInsert(string tableName, string semicolonSeparatedColumnNames,
                                 GetInsertValuesDelegate del)
        {
            AdoTemplate.Execute<object>(delegate(IDbCommand command)
            {
                string[] columnNames;
                command.CommandText =
                    CreateInsertSqlParamText(tableName, semicolonSeparatedColumnNames,
                                             out columnNames);
                command.CommandType = CommandType.Text;
                IDbParameters parameters = AdoTemplate.CreateDbParameters();
                for (int i = 0; i < columnNames.Length; ++i)
                {
                    parameters.AddWithValue(columnNames[i], DBNull.Value);
                }
                int currentRow = 0;
                for (; ; )
                {
                    IList<object> insertValues = del(currentRow++);
                    if (insertValues == null)
                    {
                        break;	// Finished!
                    }
                    if (insertValues.Count != columnNames.Length)
                    {
                        throw new IndexOutOfRangeException(
                            string.Format("Incorrect # of insert values returned: {0} vs. {1}",
                                          insertValues.Count.ToString(), columnNames.Length.ToString()));
                    }
                    for (int i = 0; i < columnNames.Length; ++i)
                    {
                        if (insertValues[i] == null)
                        {
                            parameters[i].Value = DBNull.Value;
                        }
                        else
                        {
                            parameters[i].Value = insertValues[i];
                        }
                    }
                    command.Parameters.Clear();
                    ParameterUtils.CopyParameters(command, parameters);
                    if (command.ExecuteNonQuery() != 1)
                    {
                        throw new EmptyResultDataAccessException("Failed to INSERT row into table " + tableName);
                    }
                }
                return null;
            });
        }
        protected string CreateUpdateSqlParamText(string tableName, string semicolonSeparatedWhereColumns,
                                                  int maxWhereParamCount, string semicolonSeparatedColumnNames)
        {
            string[] columnNames;
            return CreateUpdateSqlParamText(tableName, semicolonSeparatedWhereColumns, maxWhereParamCount,
                                            semicolonSeparatedColumnNames, out columnNames);
        }
        protected string CreateUpdateSqlParamText(string tableName, string whereColumn,
                                                  string semicolonSeparatedColumnNames)
        {
            string[] columnNames;
            return CreateUpdateSqlParamText(tableName, whereColumn, 1, semicolonSeparatedColumnNames,
                                            out columnNames);
        }
        protected void AppendWhereString(string semicolonSeparatedWhereColumns, int maxWhereParamCount,
                                         StringBuilder sb)
        {
            if (!string.IsNullOrEmpty(semicolonSeparatedWhereColumns))
            {
                string[] whereColumnNames = semicolonSeparatedWhereColumns.Split(SPLIT_CHAR, StringSplitOptions.RemoveEmptyEntries);
                sb.Append(" WHERE ");
                for (int i = 1; i <= whereColumnNames.Length; ++i)
                {
                    string whereParamName = WHERE_PARAM_NAME;
                    if (i > 1)
                    {
                        if (!whereColumnNames[i - 1].StartsWith(")") &&
                            !whereColumnNames[i - 1].StartsWith(" OR "))
                        {
                            sb.Append(" AND ");
                        }
                        whereParamName += i.ToString();
                    }
                    if (maxWhereParamCount >= i)
                    {
                        string whereColumnName = whereColumnNames[i - 1].TrimEnd();
                        bool appendParen = whereColumnName.EndsWith(")");
                        if (appendParen)
                        {
                            whereColumnName = whereColumnName.Substring(0, whereColumnName.Length - 1).TrimEnd();
                        }
                        if (whereColumnName.EndsWith("=") ||
                             whereColumnName.EndsWith("<") ||
                             whereColumnName.EndsWith(">"))
                        {
                            sb.AppendFormat("{0} {1}", whereColumnName,
                                                       ParseParamName(whereParamName));
                        }
                        else if (whereColumnName.EndsWith(" LIKE '%'p'%'", StringComparison.InvariantCultureIgnoreCase))
                        {
                            sb.AppendFormat("{0} LIKE '%' {1} {2} {3} '%'", whereColumnName.Substring(0, whereColumnName.Length - 13),
                                            SQL_CONCAT_STRING, ParseParamName(whereParamName), SQL_CONCAT_STRING);
                        }
                        else if (whereColumnName.EndsWith(" LIKE p'%'", StringComparison.InvariantCultureIgnoreCase))
                        {
                            sb.AppendFormat("{0} LIKE {1} {2} '%'", whereColumnName.Substring(0, whereColumnName.Length - 10),
                                            ParseParamName(whereParamName), SQL_CONCAT_STRING);
                        }
                        else if (whereColumnName.EndsWith(" LIKE '%'p", StringComparison.InvariantCultureIgnoreCase))
                        {
                            sb.AppendFormat("{0} LIKE '%' {1} {2}", whereColumnName.Substring(0, whereColumnName.Length - 10),
                                            SQL_CONCAT_STRING, ParseParamName(whereParamName));
                        }
                        else
                        {
                            //?? TODO: Does this work
                            if (whereColumnName.Contains(" ") ||
                                whereColumnName.StartsWith(")") ||
                                whereColumnName.StartsWith("("))
                            {
                                sb.AppendFormat("{0} = {1}", whereColumnName,
                                                ParseParamName(whereParamName));
                            }
                            else
                            {
                                sb.AppendFormat("UPPER({0}) = UPPER({1})", whereColumnName,
                                                             ParseParamName(whereParamName));
                            }
                        }
                        if (appendParen)
                        {
                            sb.Append(")");
                        }
                    }
                    else
                    {
                        sb.Append(whereColumnNames[i - 1]);
                    }
                }
            }
        }
        protected string CreateUpdateSqlParamText(string tableName, string semicolonSeparatedWhereColumns,
                                                  int maxWhereParamCount, string semicolonSeparatedColumnNames,
                                                  out string[] columnNames)
        {
            if (string.IsNullOrEmpty(tableName))
            {
                throw new ArgumentException("tableName is empty");
            }
            if (string.IsNullOrEmpty(semicolonSeparatedColumnNames))
            {
                throw new ArgumentException("columnNames is empty");
            }
            columnNames = semicolonSeparatedColumnNames.Split(SPLIT_CHAR, StringSplitOptions.RemoveEmptyEntries);
            if (columnNames.Length == 0)
            {
                throw new ArgumentException("columnNames is empty");
            }
            StringBuilder sb = new StringBuilder("UPDATE ");
            sb.Append(tableName);
            sb.Append(" SET ");
            bool addedFirst = false;
            foreach (string columnName in columnNames)
            {
                if (addedFirst) sb.Append(','); else addedFirst = true;
                sb.AppendFormat("{0} = {1}", columnName, ParseParamName(columnName));
            }
            AppendWhereString(semicolonSeparatedWhereColumns, maxWhereParamCount, sb);
            return sb.ToString();
        }
        public void DoSimpleUpdateOne(string tableName, string semicolonSeparatedWhereColumns, IList<object> whereValues,
                                         string semicolonSeparatedColumnNames, params object[] values)
        {
            DoSimpleUpdate(tableName, semicolonSeparatedWhereColumns, null, whereValues, semicolonSeparatedColumnNames, 1, values);
        }
        public bool DoSimpleInsertOrUpdateOne(string tableName, string semicolonSeparatedWhereColumns,
                                              IList<object> whereValues, string semicolonSeparatedColumnNames,
                                              params object[] values)
        {
            try
            {
                DoInsert(tableName, semicolonSeparatedColumnNames, values);
                return true;
            }
            catch (DataIntegrityViolationException)
            {
                DoSimpleUpdateOne(tableName, semicolonSeparatedWhereColumns, whereValues,
                                  semicolonSeparatedColumnNames, values);
                return false;
            }
        }
        public int DoSimpleUpdateAny(string tableName, string semicolonSeparatedWhereColumns, IList<object> whereValues,
                                  string semicolonSeparatedColumnNames, params object[] values)
        {
            return DoSimpleUpdate(tableName, semicolonSeparatedWhereColumns, null, whereValues, semicolonSeparatedColumnNames, -1, values);
        }
        public int DoSimpleUpdate(string tableName, string semicolonSeparatedWhereColumns, IList<object> whereValues,
                               string semicolonSeparatedColumnNames, int expectedUpdateCount,
                               params object[] values)
        {
            return DoSimpleUpdate(tableName, semicolonSeparatedWhereColumns, null, whereValues,
                                  semicolonSeparatedColumnNames, expectedUpdateCount,
                                  values);
        }
        public void DoSimpleUpdateOne(string tableName, string whereColumn, object whereValue,
                                   string semicolonSeparatedColumnNames, params object[] values)
        {
            DoSimpleUpdate(tableName, whereColumn, whereValue, null, semicolonSeparatedColumnNames, 1, values);
        }
        public bool DoSimpleInsertOrUpdateOne(string tableName, string whereColumn, object whereValue,
                                              string semicolonSeparatedColumnNames, params object[] values)
        {
            try
            {
                DoInsert(tableName, semicolonSeparatedColumnNames, values);
                return true;
            }
            catch (DataIntegrityViolationException)
            {
                DoSimpleUpdateOne(tableName, whereColumn, whereValue, semicolonSeparatedColumnNames, values);
                return false;
            }
        }
        public int DoSimpleUpdateAny(string tableName, string whereColumn, object whereValue,
                                  string semicolonSeparatedColumnNames, params object[] values)
        {
            return DoSimpleUpdate(tableName, whereColumn, whereValue, null, semicolonSeparatedColumnNames, -1, values);
        }
        public int DoSimpleUpdate(string tableName, string whereColumn, object whereValue,
                               string semicolonSeparatedColumnNames, int expectedUpdateCount,
                               params object[] values)
        {
            return DoSimpleUpdate(tableName, whereColumn, whereValue, null,
                                  semicolonSeparatedColumnNames, expectedUpdateCount,
                                  values);
        }
        public int DoSimpleUpdate(string tableName, string whereColumns, object whereValue,
                                     IList<object> whereValues, string semicolonSeparatedColumnNames,
                                     int expectedUpdateCount, params object[] values)
        {
            string[] columnNames;
            string updateText = CreateUpdateSqlParamText(tableName, whereColumns, (whereValues == null) ?
                                                         1 : whereValues.Count, semicolonSeparatedColumnNames,
                                                         out columnNames);

            if (CollectionUtils.IsNullOrEmpty(values) || (values.Length != columnNames.Length))
            {
                throw new ArgumentException("Invalid values specified.");
            }
            IDbParameters parameters = AdoTemplate.CreateDbParameters();
            for (int i = 0; i < values.Length; ++i)
            {
                if (values[i] == null)
                {
                    parameters.AddWithValue(columnNames[i], DBNull.Value);
                }
                else
                {
                    parameters.AddWithValue(columnNames[i], values[i]);
                }
            }
            if (whereValues == null)
            {
                parameters.AddWithValue(WHERE_PARAM_NAME, whereValue);
            }
            else
            {
                parameters = AppendDbParameters(parameters, whereValues);
            }

            LOG.DebugArguments("AdoTemplate.ExecuteNonQuery()", "CommandType.Text", CommandType.Text);

            int result = AdoTemplate.ExecuteNonQuery(CommandType.Text, updateText, parameters);

            if (expectedUpdateCount >= 0)
            {
                if (result != expectedUpdateCount)
                {
                    throw new UncategorizedAdoException(string.Format("Failed to update: \"{0}\".",
                                                                      updateText));
                }
            }
            return result;
        }
        protected string CreateSelectSqlParamText(string semicolonSeparatedTableNames,
                                                  string semicolonSeparatedWhereColumns, int maxWhereParamCount,
                                                  string semicolonSeparatedOrderByColumns, string semicolonSeparatedColumnNames)
        {
            if (string.IsNullOrEmpty(semicolonSeparatedTableNames))
            {
                throw new ArgumentException("tableName is empty");
            }
            if (string.IsNullOrEmpty(semicolonSeparatedColumnNames))
            {
                throw new ArgumentException("columnNames is empty");
            }
            string[] columnNames = semicolonSeparatedColumnNames.Split(SPLIT_CHAR, StringSplitOptions.RemoveEmptyEntries);
            if (columnNames.Length == 0)
            {
                throw new ArgumentException("columnNames is empty");
            }
            string[] tableNames = semicolonSeparatedTableNames.Split(SPLIT_CHAR, StringSplitOptions.RemoveEmptyEntries);
            if (tableNames.Length == 0)
            {
                throw new ArgumentException("tableNames is empty");
            }
            StringBuilder sb = new StringBuilder("SELECT ");
            sb.Append(string.Join(",", columnNames));
            sb.Append(" FROM ");
            sb.Append(string.Join(",", tableNames));
            AppendWhereString(semicolonSeparatedWhereColumns, maxWhereParamCount, sb);
            if (!string.IsNullOrEmpty(semicolonSeparatedOrderByColumns))
            {
                sb.AppendFormat(" ORDER BY {0}", semicolonSeparatedOrderByColumns.Replace(';', ','));
            }
            return sb.ToString();
        }
        public bool RowExistsSimple(string semicolonSeparatedTableNames,
                              string semicolonSeparatedWhereColumnNames,
                              params object[] whereValues)
        {
            return RowExists(semicolonSeparatedTableNames, "*", semicolonSeparatedWhereColumnNames,
                             whereValues);
        }
        public bool RowExists(string semicolonSeparatedTableNames,
                                 string semicolonSeparatedColumnNames,
                                 string semicolonSeparatedWhereColumnNames,
                                 params object[] whereValues)
        {

            try
            {
                string selectText =
                    CreateSelectSqlParamText(semicolonSeparatedTableNames, semicolonSeparatedWhereColumnNames,
                                             (whereValues == null) ? 0 : whereValues.Length, null,
                                             semicolonSeparatedColumnNames);
                IDbParameters parameters = AppendDbParameters(null, whereValues);
                bool exists = false;
                AdoTemplate.QueryForObjectDelegate<object>(
                        CommandType.Text, selectText,
                        delegate(IDataReader reader, int rowNum)
                        {
                            exists = true;
                            return null;
                        },
                        parameters);
                return exists;
            }
            catch (IncorrectResultSizeDataAccessException)
            {
                return false; // Not found
            }
        }
        public string GetRowPrimaryKey(string semicolonSeparatedTableNames,
                                       string primaryKeyName,
                                       string semicolonSeparatedWhereColumnNames,
                                       params object[] whereValues)
        {

            try
            {
                string selectText =
                    CreateSelectSqlParamText(semicolonSeparatedTableNames, semicolonSeparatedWhereColumnNames,
                                             (whereValues == null) ? 0 : whereValues.Length, null,
                                             primaryKeyName);
                IDbParameters parameters = AppendDbParameters(null, whereValues);
                return AdoTemplate.QueryForObjectDelegate<string>(
                    CommandType.Text, selectText,
                    delegate(IDataReader reader, int rowNum)
                    {
                        return reader.GetString(0);
                    },
                    parameters);
            }
            catch (IncorrectResultSizeDataAccessException)
            {
                return null; // Not found
            }
        }

        public T DoSimpleQueryForObjectDelegate<T>(string semicolonSeparatedTableNames,
                                                      string whereColumn, object whereValue,
                                                      string semicolonSeparatedColumnNames,
                                                      RowMapperDelegate<T> callback)
        {
            string selectText =
                CreateSelectSqlParamText(semicolonSeparatedTableNames, whereColumn, 1, null,
                                         semicolonSeparatedColumnNames);
            IDbParameters parameters = AdoTemplate.CreateDbParameters();
            parameters.AddWithValue(WHERE_PARAM_NAME, whereValue);
            return AdoTemplate.QueryForObjectDelegate<T>(
                    CommandType.Text, selectText, callback, parameters);
        }
        public T DoSimpleQueryForObjectDelegate<T>(string semicolonSeparatedTableNames,
                                                      string semicolonSeparatedWhereColumnNames,
                                                      IList<object> whereValues,
                                                      string semicolonSeparatedColumnNames,
                                                      RowMapperDelegate<T> callback)
        {
            string selectText =
                CreateSelectSqlParamText(semicolonSeparatedTableNames, semicolonSeparatedWhereColumnNames,
                                         (whereValues == null) ? 0 : whereValues.Count, null,
                                         semicolonSeparatedColumnNames);
            IDbParameters parameters = AppendDbParameters(null, whereValues);
            return AdoTemplate.QueryForObjectDelegate<T>(
                    CommandType.Text, selectText, callback, parameters);
        }
        public void DoSimpleQueryWithRowCallbackDelegate(string semicolonSeparatedTableNames, string whereColumn,
                                                            object whereValue, string semicolonSeparatedOrderByColumns,
                                                            string semicolonSeparatedColumnNames,
                                                            RowCallbackDelegate callback)
        {
            string selectText =
                CreateSelectSqlParamText(semicolonSeparatedTableNames, whereColumn, 1, semicolonSeparatedOrderByColumns,
                                         semicolonSeparatedColumnNames);
            IDbParameters parameters = AdoTemplate.CreateDbParameters();
            parameters.AddWithValue(WHERE_PARAM_NAME, whereValue);
            QueryWithRowCallbackDelegate(CommandType.Text, selectText, callback, parameters);
        }
        public void DoSimpleTopQueryWithRowCallbackDelegate(string semicolonSeparatedTableNames, string whereColumn,
                                                            object whereValue, string semicolonSeparatedOrderByColumns,
                                                            string semicolonSeparatedColumnNames, int numRows,
                                                            RowCallbackDelegate callback)
        {
            if (IsOracleDatabase)
            {
            }
            else if (IsSqlServerDatabase)
            {
                semicolonSeparatedColumnNames = string.Format("TOP {0} {1}", numRows.ToString(),
                    (semicolonSeparatedColumnNames == null) ? string.Empty :
                    semicolonSeparatedColumnNames);
            }
            else
            {
                throw new NotSupportedException();
            }
            string selectText =
                CreateSelectSqlParamText(semicolonSeparatedTableNames, whereColumn, 1, semicolonSeparatedOrderByColumns,
                                         semicolonSeparatedColumnNames);
            if (IsOracleDatabase)
            {
                selectText += " AND ROWNUM <= " + numRows.ToString();
            }
            IDbParameters parameters = AdoTemplate.CreateDbParameters();
            parameters.AddWithValue(WHERE_PARAM_NAME, whereValue);
            QueryWithRowCallbackDelegate(CommandType.Text, selectText, callback, parameters);
        }
        public void QueryWithRowCallbackDelegate(CommandType cmdType, string sql, RowCallbackDelegate rowCallbackDelegate)
        {
            QueryWithRowCallbackDelegate(cmdType, sql, rowCallbackDelegate, null);
        }
        public void QueryWithRowCallbackDelegate(CommandType cmdType, string sql, RowCallbackDelegate rowCallbackDelegate, IDbParameters parameters)
        {
            int deadlockRetriesLeft = 2;
            for (; ; )
            {
                try
                {
                    if (parameters == null)
                    {
                        AdoTemplate.QueryWithRowCallbackDelegate(cmdType, sql, rowCallbackDelegate);
                    }
                    else
                    {
                        AdoTemplate.QueryWithRowCallbackDelegate(cmdType, sql, rowCallbackDelegate, parameters);
                    }
                    return;
                }
                catch (DeadlockLoserDataAccessException)
                {
                    if (--deadlockRetriesLeft < 0)
                    {
                        throw;
                    }
                    Thread.Sleep(50);
                }
            }
        }
        public void DoSimpleQueryWithRowCallbackDelegate(string semicolonSeparatedTableNames, string whereColumn,
                                                            object whereValue, RowCallbackDelegate callback)
        {
            DoSimpleQueryWithRowCallbackDelegate(semicolonSeparatedTableNames, whereColumn, whereValue, null,
                                                 "*", callback);
        }
        public void DoSimpleQueryWithRowCallbackDelegate(string semicolonSeparatedTableNames, string whereColumn,
                                                            object whereValue, string semicolonSeparatedColumnNames,
                                                            RowCallbackDelegate callback)
        {
            DoSimpleQueryWithRowCallbackDelegate(semicolonSeparatedTableNames, whereColumn, whereValue, null,
                                                 semicolonSeparatedColumnNames, callback);
        }
        public int GetCounts(string semicolonSeparatedTableNames, string semicolonSeparatedWhereColumnNames,
                             IList<object> whereValues)
        {

            string selectText =
                CreateSelectSqlParamText(semicolonSeparatedTableNames, semicolonSeparatedWhereColumnNames,
                                         (whereValues == null) ? 0 : whereValues.Count, null,
                                         "COUNT(*)");
            IDbParameters parameters = AppendDbParameters(null, whereValues);
            object countValue = AdoTemplate.ExecuteScalar(CommandType.Text, selectText, parameters);
            return (countValue == null) ? 0 : int.Parse(countValue.ToString());
        }
        public void DoSimpleQueryWithRowCallbackDelegate(string semicolonSeparatedTableNames,
                                                            string semicolonSeparatedWhereColumnNames,
                                                            IList<object> whereValues,
                                                            string semicolonSeparatedOrderByColumns,
                                                            string semicolonSeparatedColumnNames,
                                                            RowCallbackDelegate callback)
        {

            string selectText =
                CreateSelectSqlParamText(semicolonSeparatedTableNames, semicolonSeparatedWhereColumnNames,
                                         (whereValues == null) ? 0 : whereValues.Count, semicolonSeparatedOrderByColumns,
                                         semicolonSeparatedColumnNames);
            IDbParameters parameters = AppendDbParameters(null, whereValues);
            QueryWithRowCallbackDelegate(CommandType.Text, selectText, callback, parameters);
        }
        public IList<IDataParameter> CreateSelectSqlParamText(string semicolonSeparatedWhereColumnNames,
                                                              IList<object> whereValues, out string whereClauseText)
        {
            StringBuilder sb = new StringBuilder();
            AppendWhereString(semicolonSeparatedWhereColumnNames, (whereValues == null) ? 0 : whereValues.Count, sb);
            whereClauseText = sb.ToString();
            IDbParameters parameters = AppendDbParameters(null, whereValues);
            List<IDataParameter> parameterList = new List<IDataParameter>();
            for (int i = 0; i < parameters.Count; ++i)
            {
                IDataParameter p1 = parameters[i];
                parameterList.Add(parameters[i]);
            }
            parameters.DataParameterCollection.Clear();
            return parameterList;
        }
        public void DoSimpleQueryWithRowCallbackDelegate(string semicolonSeparatedTableNames,
                                                            string semicolonSeparatedWhereColumnNames,
                                                            IList<object> whereValues,
                                                            string semicolonSeparatedColumnNames,
                                                            RowCallbackDelegate callback)
        {
            DoSimpleQueryWithRowCallbackDelegate(semicolonSeparatedTableNames, semicolonSeparatedWhereColumnNames,
                                                 whereValues, null, semicolonSeparatedColumnNames, callback);
        }
        public void DoSimpleQueryWithRowCallbackDelegate(string semicolonSeparatedTableNames,
                                                            string semicolonSeparatedWhereColumnNames,
                                                            IList<object> whereValues,
                                                            RowCallbackDelegate callback)
        {
            DoSimpleQueryWithRowCallbackDelegate(semicolonSeparatedTableNames, semicolonSeparatedWhereColumnNames,
                                                 whereValues, null, "*", callback);
        }
        public delegate bool CancelableRowCallbackDelegate(IDataReader dataReader);
        private class CancelableRowCallbackResultSetExtractor : IResultSetExtractor
        {
            private CancelableRowCallbackDelegate rowCallbackDelegate;
            public CancelableRowCallbackResultSetExtractor(CancelableRowCallbackDelegate rowCallbackDelegate)
            {
                this.rowCallbackDelegate = rowCallbackDelegate;
            }
            public object ExtractData(IDataReader reader)
            {
                while (reader.Read())
                {
                    if (!rowCallbackDelegate(reader))
                    {
                        return null;
                    }
                }
                return null;
            }
        }
        public void DoSimpleQueryWithCancelableRowCallbackDelegate(string semicolonSeparatedTableNames,
                                                                      string semicolonSeparatedWhereColumnNames,
                                                                      IList<object> whereValues,
                                                                      string semicolonSeparatedOrderByColumns,
                                                                      string semicolonSeparatedColumnNames,
                                                                      CancelableRowCallbackDelegate callback)
        {

            string selectText =
                CreateSelectSqlParamText(semicolonSeparatedTableNames, semicolonSeparatedWhereColumnNames,
                                         (whereValues == null) ? 0 : whereValues.Count, semicolonSeparatedOrderByColumns,
                                         semicolonSeparatedColumnNames);
            IDbParameters parameters = AppendDbParameters(null, whereValues);
            AdoTemplate.ClassicAdoTemplate.QueryWithResultSetExtractor(CommandType.Text, selectText,
                                                                       new CancelableRowCallbackResultSetExtractor(callback),
                                                                       parameters);
        }
        public IDbParameters AppendDbParameters(IDbParameters parameters, IList<object> whereValues)
        {
            if (whereValues != null)
            {
                if (parameters == null)
                {
                    parameters = AdoTemplate.CreateDbParameters();
                }
                for (int i = 1; i <= whereValues.Count; ++i)
                {
                    string whereParamName = WHERE_PARAM_NAME;
                    if (i > 1)
                    {
                        whereParamName += i.ToString();
                    }
                    parameters.AddWithValue(whereParamName, whereValues[i - 1]);
                }
            }
            return parameters;
        }
        protected string CreateDeleteWhereInSqlParamText(string tableName, string whereColumn,
                                                         int whereValueCount)
        {
            if (string.IsNullOrEmpty(tableName))
            {
                throw new ArgumentException("tableName is empty");
            }
            if (string.IsNullOrEmpty(whereColumn))
            {
                throw new ArgumentException("whereColumn is empty");
            }
            if (whereValueCount < 1)
            {
                throw new ArgumentException("whereValueCount < 1");
            }
            StringBuilder sb = new StringBuilder("DELETE FROM ");
            sb.Append(tableName);
            //?? TODO:
            sb.AppendFormat(" WHERE UPPER({0}) IN (", whereColumn);
            for (int i = 0; i < whereValueCount; ++i)
            {
                if (i > 0)
                {
                    sb.Append(',');
                }
                string paramName =
                    string.Format("UPPER({0})", ParseParamName(DELETE_PARAM_NAME + i.ToString()));
                sb.Append(paramName);
            }
            sb.Append(')');
            return sb.ToString();
        }
        protected string CreateDeleteSqlParamText(string tableName,
                                                  string semicolonSeparatedWhereColumns,
                                                  int maxWhereParamCount)
        {
            if (string.IsNullOrEmpty(tableName))
            {
                throw new ArgumentException("tableName is empty");
            }
            //if (string.IsNullOrEmpty(semicolonSeparatedWhereColumns))
            //{
            //    throw new ArgumentException("columnNames is empty");
            //}
            StringBuilder sb = new StringBuilder("DELETE FROM ");
            sb.Append(tableName);
            AppendWhereString(semicolonSeparatedWhereColumns, maxWhereParamCount, sb);
            return sb.ToString();
        }
        public int DoDeleteWhereIn<T>(string tableName, string whereColumn, IList<T> whereValues) where T : class
        {
            if (CollectionUtils.IsNullOrEmpty(whereValues))
            {
                throw new ArgumentException("whereValues is empty");
            }
            string deleteText =
                CreateDeleteWhereInSqlParamText(tableName, whereColumn, whereValues.Count);
            IDbParameters parameters = AdoTemplate.CreateDbParameters();
            for (int i = 0; i < whereValues.Count; ++i)
            {
                parameters.AddWithValue(DELETE_PARAM_NAME + i.ToString(), whereValues[i]);
            }
            return AdoTemplate.ExecuteNonQuery(CommandType.Text, deleteText, parameters);
        }
        public int DoSimpleDelete(string tableName, string semicolonSeparatedWhereColumnNames,
                                  params object[] whereValues)
        {

            string deleteText =
                CreateDeleteSqlParamText(tableName, semicolonSeparatedWhereColumnNames,
                                         (whereValues == null) ? 0 : whereValues.Length);
            IDbParameters parameters = AppendDbParameters(null, whereValues);
            return AdoTemplate.ExecuteNonQuery(CommandType.Text, deleteText, parameters);
        }
        public string GetDbInGroupFromFlagsEnum<T>(string fieldName, T flagsEnumValue) where T : struct, IConvertible
        {
            StringBuilder sb = new StringBuilder(fieldName + " IN (");
            IList<T> enumValues = EnumUtils.GetEnumFlagsArray<T>(flagsEnumValue);
            for (int i = 0; i < enumValues.Count; ++i)
            {
                if (i > 0)
                {
                    sb.Append(',');
                }
                sb.Append('\'');
                sb.Append(enumValues[i].ToString());
                sb.Append('\'');
            }
            sb.Append(")");
            return sb.ToString();
        }
        public static string MakeWhereInClause<T>(IEnumerable<T> values)
        {
            StringBuilder sb = new StringBuilder("IN (");
            int count = 0;
            foreach (T value in values)
            {
                if (count++ > 0)
                {
                    sb.Append(',');
                }
                sb.Append('\'');
                sb.Append(value.ToString());
                sb.Append('\'');
            }
            sb.Append(")");
            return sb.ToString();
        }
        public string GiveTableAliasToColumnNames(string semicolonSeparatedColumnNames,
                                                     string tableAlias)
        {
            return tableAlias + "." + semicolonSeparatedColumnNames.Replace(";", ";" + tableAlias + ".");
        }
        public void MapArrayObjects<T>(string keyField, IEnumerable<string> listKeyFields,
                                       string selectText, ObjectMapperDelegate<T> mapperDelegate,
                                       HandleMappedObjectArray<T> handleMappedObjectsDelete)
        {
            MapArrayObjects<T>(keyField, listKeyFields, selectText, mapperDelegate, null, handleMappedObjectsDelete);
        }
        public string SqlConcatString
        {
            get { return SQL_CONCAT_STRING; }
        }

        public Dictionary<string, T> MapArrayObjects<T>(string keyField, IEnumerable<string> listKeyFields,
                                                        string selectText, ObjectMapperDelegate<T> mapperDelegate,
                                                        string idMapField, HandleMappedObjectArray<T> handleMappedObjectsDelete)
        {
            if (CollectionUtils.IsNullOrEmpty(listKeyFields))
            {
                return null;
            }
            Dictionary<string, T> idMap = null;
            MultiDictionary<string, T> dict = new MultiDictionary<string, T>(true);
            QueryWithRowCallbackDelegate(CommandType.Text, selectText,
                    delegate(IDataReader reader)
                    {
                        NamedNullMappingDataReader readerEx = (NamedNullMappingDataReader)reader;
                        T mappedObject = mapperDelegate(readerEx);
                        dict.Add(readerEx.GetString(keyField), mappedObject);
                        if (idMapField != null)
                        {
                            if (idMap == null)
                            {
                                idMap = new Dictionary<string, T>();
                            }
                            idMap.Add(readerEx.GetString(idMapField), mappedObject);
                        }
                    });
            if (dict.Count > 0)
            {
                int i = 0;
                foreach (string value in listKeyFields)
                {
                    ICollection<T> mappedObjects = dict[value];
                    if (!CollectionUtils.IsNullOrEmpty(mappedObjects))
                    {
                        T[] array = new T[mappedObjects.Count];
                        mappedObjects.CopyTo(array, 0);
                        handleMappedObjectsDelete(array, i);
                    }
                    ++i;
                }
            }
            return idMap;
        }
        #endregion

        public ITransactionOperations TransactionTemplate
        {
            get
            {
                return _transactionTemplate;
            }
            set
            {
                _transactionTemplate = value;
            }
        }
        public IDbProvider DbProvider
        {
            get { return _adoDaoSupport.DbProvider; }
        }
        public AdoTemplate AdoTemplate
        {
            get { return _adoDaoSupport.AdoTemplate; }
        }
        public AdoDaoSupport AdoDaoSupport
        {
            get { return _adoDaoSupport; }
            set { _adoDaoSupport = value; }
        }
        protected string LimitDbText(string text, int maxChars)
        {
            if (text == null)
            {
                return string.Empty;
            }
            if (text.Length >= maxChars)
            {
                return text.Substring(0, maxChars - 1);
            }
            return text;
        }
    }
}
