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

using Spring.Data.Generic;
using Spring.Data.Common;


using Common.Logging;

using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSUtility;
using Windsor.Commons.Core;

namespace Windsor.Node2008.WNOS.Data
{
    public class ActivityDao : BaseDao, IActivityDao
    {
        public const string TABLE_NAME = "NActivity";
        public const string DETAIL_TABLE_NAME = "NActivityDetail";
        private IAccountDao _accountDao;
        private IFlowDao _flowDao;
        private ITransactionDao _transactionDao;
        private const int MAX_DETAIL_CHARS = 4000;

        #region Init

        new public void Init()
        {
            base.Init();

            FieldNotInitializedException.ThrowIfNull(this, ref _accountDao);
        }

        #endregion

        #region Mappers
        private const string OldAdminAuthType = "AdminAuth";
        private const string OldServiceAuthType = "ServiceAuth";

        private const string MAP_ACTIVITY_COLUMNS = "a.Id;a.Type;a.TransactionId;a.IP;a.WebMethod;a.FlowName;a.Operation;a.ModifiedBy;a.ModifiedOn";
        private Activity MapActivity(IDataReader reader)
        {
            int index = 0;
            string id = reader.GetString(index++);
            string activityTypeString = reader.GetString(index++);
            ActivityType type = EnumUtils.ParseEnum<ActivityType>(activityTypeString);
            string transactionId = reader.GetString(index++);
            string ip = reader.GetString(index++);
            string nodeMethodString = reader.GetString(index++);
            NodeMethod method = EnumUtils.ParseEnum<NodeMethod>(nodeMethodString);
            string flowName = reader.GetString(index++);
            string operation = reader.GetString(index++);
            Activity activity = new Activity(method, flowName, operation, type, transactionId, ip, null, null);
            activity.Id = id;
            activity.ModifiedById = reader.GetString(index++);
            activity.ModifiedOn = reader.GetDateTime(index++);
            if (activity.Method == NodeMethod.None)
            {
                if (activityTypeString == OldAdminAuthType)
                {
                    activity.Method = NodeMethod.AdminLogin;
                }
            }
            return activity;
        }
        private const string MAP_ACTIVITY_DETAIL_COLUMNS = "Detail;ModifiedOn";
        private ActivityEntry MapActivityDetail(IDataReader reader)
        {
            ActivityEntry activityEntry = new ActivityEntry();
            int index = 0;
            activityEntry.Message = reader.GetString(index++);
            activityEntry.TimeStamp = reader.GetDateTime(index++);
            return activityEntry;
        }
        private void PostMapActivityEntries(Activity activity)
        {
            activity.Entries = GetActivityEntries(activity.Id);
        }
        private void PostMapActivityEntries(IEnumerable<Activity> activities)
        {
            if (activities != null)
            {
                foreach (Activity activity in activities)
                {
                    PostMapActivityEntries(activity);
                }
            }
        }
        private void PostMapActivity(Activity activity)
        {
            /* Takes too long and not necessary
            if (!string.IsNullOrEmpty(activity.TransactionId))
            {
                if (string.IsNullOrEmpty(activity.FlowName) || string.IsNullOrEmpty(activity.Operation) || 
                   (activity.Method == NodeMethod.None))
                {
                    NodeMethod method;
                    string operation;
                    string flowName = _transactionDao.GetTransactionFlowName(activity.TransactionId, out method, out operation);
                    if (string.IsNullOrEmpty(activity.FlowName))
                    {
                        activity.FlowName = flowName;
                    }
                    if (string.IsNullOrEmpty(activity.Operation))
                    {
                        activity.Operation = operation;
                    }
                    if (activity.Method == NodeMethod.None)
                    {
                        activity.Method = method;
                    }
                }
            }
            */
        }
        private void PostMapActivities(IEnumerable<Activity> activities)
        {
            if (activities != null)
            {
                foreach (Activity activity in activities)
                {
                    PostMapActivity(activity);
                }
            }
        }
        #endregion

        #region Methods
        public void Log(Activity activity)
        {
            Save(activity);
        }
        public string GetTransactionIdFromActivityId(string activityId)
        {
            try
            {
                string transactionId =
                    DoSimpleQueryForObjectDelegate<string>(
                        TABLE_NAME, "Id", activityId, "TransactionId",
                        delegate(IDataReader reader, int rowNum)
                        {
                            return reader.GetString(0);
                        });
                return transactionId;
            }
            catch (Spring.Dao.IncorrectResultSizeDataAccessException)
            {
                return null; // Not found
            }
        }
        public string GetActivityIdFromTransactionId(string transactionId)
        {
            try
            {
                string activityId =
                    DoSimpleQueryForObjectDelegate<string>(
                        TABLE_NAME, "TransactionId", transactionId, "Id",
                        delegate(IDataReader reader, int rowNum)
                        {
                            return reader.GetString(0);
                        });
                return activityId;
            }
            catch (Spring.Dao.IncorrectResultSizeDataAccessException)
            {
                return null; // Not found
            }
        }

        public IList<string> GetActivityIdsFromTransactionId(string transactionId)
        {
            try
            {
                List<string> list = null;
                DoSimpleQueryWithRowCallbackDelegate(
                    TABLE_NAME, "TransactionId", transactionId, "ModifiedOn",
                    "Id",
                    delegate(IDataReader reader)
                    {
                        if (list == null)
                        {
                            list = new List<string>();
                        }
                        list.Add(reader.GetString(0));
                    });
                return list;
            }
            catch (Spring.Dao.IncorrectResultSizeDataAccessException)
            {
                return null; // Not found
            }
        }

        public Activity Get(string activityId, bool includeActivityEntries)
        {
            try
            {
                Activity activity =
                    DoSimpleQueryForObjectDelegate<Activity>(
                        TABLE_NAME + " a", "Id", activityId, MAP_ACTIVITY_COLUMNS,
                        delegate(IDataReader reader, int rowNum)
                        {
                            return MapActivity(reader);
                        });
                PostMapActivity(activity);
                if (includeActivityEntries)
                {
                    PostMapActivityEntries(activity);
                }
                return activity;
            }
            catch (Spring.Dao.IncorrectResultSizeDataAccessException)
            {
                return null; // Not found
            }
        }
        protected string ConstructSearchWhereValues(ActivitySearchParams searchParams, bool addFlowIsNullQuery,
                                                    out List<object> whereValues, out string tableNames)
        {
            // TODO:
            // TransactionStatus
            // NodeMethod

            if (searchParams == null)
            {
                throw new ArgumentException("searchParams");
            }
            tableNames = TABLE_NAME + " a";

            bool addedTransactionTable = false;
            StringBuilder whereColumns = new StringBuilder("(a.ModifiedOn >=;a.ModifiedOn <=");
            whereValues =
                new List<object>(new object[] { ActivitySearchParams.ConstrainDate(searchParams.CreatedFrom), 
                                                ActivitySearchParams.ConstrainDate(searchParams.CreatedTo) });

            if (!CollectionUtils.IsNullOrEmpty(searchParams.FlowNames))
            {
                StringBuilder flowNameColumns = new StringBuilder();
                foreach (string flowName in searchParams.FlowNames)
                {
                    if (flowNameColumns.Length > 0)
                    {
                        flowNameColumns.Append("; OR a.FlowName");
                    }
                    else
                    {
                        flowNameColumns.Append(";(a.FlowName");
                    }
                    whereValues.Add(flowName);
                }
                if (addFlowIsNullQuery)
                {
                    flowNameColumns.Append("; OR a.FlowName IS NULL)");
                }
                else
                {
                    flowNameColumns.Append(")");
                }
                whereColumns.Append(flowNameColumns.ToString());
            }
            if (!string.IsNullOrEmpty(searchParams.OperationName))
            {
                whereColumns.Append(";a.Operation");
                whereValues.Add(searchParams.OperationName);
            }
            if (!string.IsNullOrEmpty(searchParams.TransactionId))
            {
                if (!addedTransactionTable)
                {
                    tableNames += ", " + Windsor.Node2008.WNOS.Data.TransactionDao.TABLE_NAME + " t";
                    addedTransactionTable = true;
                }
                whereColumns.Append(";(a.TransactionId; OR t.NetworkId)");
                whereValues.Add(searchParams.TransactionId);
                whereValues.Add(searchParams.TransactionId);
            }
            if (!string.IsNullOrEmpty(searchParams.IP))
            {
                whereColumns.Append(";a.IP");
                whereValues.Add(searchParams.IP);
            }
            if (searchParams.Type != ActivityType.None)
            {
                whereColumns.Append(";a.Type");
                whereValues.Add(searchParams.Type.ToString());
            }
            if (searchParams.NodeMethod != NodeMethod.None)
            {
                whereColumns.Append(";a.WebMethod");
                whereValues.Add(searchParams.NodeMethod.ToString());
            }
            if (!string.IsNullOrEmpty(searchParams.CreatedByUsername))
            {
                string userId = _accountDao.GetUserIdByName(searchParams.CreatedByUsername);
                whereColumns.Append(";a.ModifiedBy");
                whereValues.Add(userId);
            }
            if (!string.IsNullOrEmpty(searchParams.DetailContains))
            {
                tableNames += ", " + DETAIL_TABLE_NAME + " d";
                whereColumns.Append(";d.Detail LIKE '%'p'%';d.ActivityId = a.Id");
                whereValues.Add(searchParams.DetailContains);
            }
            if (addedTransactionTable)
            {
                whereColumns.Append(";a.TransactionId = t.Id");
            }
            whereColumns.Append(")");
            return whereColumns.ToString();
        }
        protected string ConstructJDBCSearchSql(ActivitySearchParams searchParams, bool addFlowIsNullQuery,
                                                out List<object> whereValues)
        {
            // TODO:
            // TransactionStatus

            if (searchParams == null)
            {
                throw new ArgumentException("searchParams");
            }
            const string TABLE_NAMES_KEY = "___TABLE_NAMES___";
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("SELECT DISTINCT {0} FROM {1} WHERE a.ModifiedOn >= ? AND a.ModifiedOn <= ?",
                             MAP_ACTIVITY_COLUMNS.Replace(';', ','), TABLE_NAMES_KEY);

            whereValues =
                new List<object>(new object[] { ActivitySearchParams.ConstrainDate(searchParams.CreatedFrom), 
                                                ActivitySearchParams.ConstrainDate(searchParams.CreatedTo) });

            bool addedTransaction = false, addedDetail = false;

            if (!CollectionUtils.IsNullOrEmpty(searchParams.FlowNames))
            {
                StringBuilder flowNameColumns = new StringBuilder();
                foreach (string flowName in searchParams.FlowNames)
                {
                    if (flowNameColumns.Length > 0)
                    {
                        flowNameColumns.Append(" OR UPPER(a.FlowName) = UPPER(?)");
                    }
                    else
                    {
                        flowNameColumns.Append(" AND (UPPER(a.FlowName) = UPPER(?)");
                    }
                    whereValues.Add(flowName);
                }
                if (addFlowIsNullQuery)
                {
                    flowNameColumns.Append(" OR a.FlowName IS NULL)");
                }
                else
                {
                    flowNameColumns.Append(")");
                }
                sql.Append(flowNameColumns.ToString());
            }
            if (!string.IsNullOrEmpty(searchParams.OperationName))
            {
                sql.Append(" AND a.Operation = UPPER(?)");
                whereValues.Add(searchParams.OperationName);
            }
            if (!string.IsNullOrEmpty(searchParams.TransactionId))
            {
                sql.Append(" AND (UPPER(a.TransactionId) = UPPER(?) OR UPPER(t.NetworkId) = UPPER(?))");
                addedTransaction = true;
                whereValues.Add(searchParams.TransactionId);
                whereValues.Add(searchParams.TransactionId);
            }
            if (!string.IsNullOrEmpty(searchParams.IP))
            {
                sql.Append(" AND UPPER(a.IP) = UPPER(?)");
                whereValues.Add(searchParams.IP);
            }
            if (searchParams.Type != ActivityType.None)
            {
                sql.Append(" AND UPPER(a.Type) = UPPER(?)");
                whereValues.Add(searchParams.Type.ToString());
            }
            if (searchParams.NodeMethod != NodeMethod.None)
            {
                sql.Append(" AND UPPER(a.WebMethod) = UPPER(?)");
                whereValues.Add(searchParams.NodeMethod.ToString());
            }
            if (!string.IsNullOrEmpty(searchParams.CreatedByUsername))
            {
                string userId = _accountDao.GetUserIdByName(searchParams.CreatedByUsername);
                sql.Append(" AND UPPER(a.ModifiedBy) = UPPER(?)");
                whereValues.Add(userId);
            }
            if (!string.IsNullOrEmpty(searchParams.DetailContains))
            {
                if (this.IsSqlServerDatabase)
                {
                    sql.Append(" AND UPPER(d.Detail) LIKE '%' + UPPER(?) + '%'");
                }
                else
                {
                    sql.Append(" AND UPPER(d.Detail) LIKE CONCAT(CONCAT('%', UPPER(?)), '%')");
                }
                addedDetail = true;
                whereValues.Add(searchParams.DetailContains);
            }
            string tableNames = TABLE_NAME + " a";
            if (addedTransaction)
            {
                sql.Append(" AND t.Id = a.TransactionId");
                tableNames += ", " + Windsor.Node2008.WNOS.Data.TransactionDao.TABLE_NAME + " t";
            }
            if (addedDetail)
            {
                sql.Append(" AND d.ActivityId = a.Id");
                tableNames += ", " + DETAIL_TABLE_NAME + " d";
            }
            return sql.ToString().Replace(TABLE_NAMES_KEY, tableNames);
        }
        public int DeleteActivities(ActivitySearchParams searchParams, bool addFlowIsNullQuery)
        {
            List<object> whereValues;
            string tableNames;
            string whereColumns = ConstructSearchWhereValues(searchParams, addFlowIsNullQuery, out whereValues, out tableNames);

            string selectIdText = CreateSelectSqlParamText(tableNames, whereColumns,
                                                         (whereValues == null) ? 0 : whereValues.Count,
                                                         null, "DISTINCT a.Id");

            IDbParameters parameters = AppendDbParameters(null, whereValues);

            string deleteSqlCommand = string.Format("DELETE FROM {0} WHERE ID IN ({1})",
                                                    TABLE_NAME, selectIdText);
            string updateSqlCommand = string.Format("UPDATE {0} SET LastExecuteActivityId = NULL WHERE LastExecuteActivityId IN ({1})",
                                                    ScheduleDao.TABLE_NAME, selectIdText);

            int deleteCount = 0;
            TransactionTemplate.Execute(delegate
            {
                AdoTemplate.ExecuteNonQuery(CommandType.Text, updateSqlCommand, parameters);
                deleteCount = AdoTemplate.ExecuteNonQuery(CommandType.Text, deleteSqlCommand, parameters);
                return null;
            });
            return deleteCount;
        }
        // Chronological order, most recent last
        public ICollection<Activity> GetActivitiesForTransaction(string transactionId, bool getActivityEntries)
        {
            string tableNames = TABLE_NAME + " a";
            List<Activity> list = null;
            DoSimpleQueryWithRowCallbackDelegate(
                tableNames, "TransactionId", transactionId, "ModifiedOn ASC",
                MAP_ACTIVITY_COLUMNS,
                delegate(IDataReader reader)
                {
                    if (list == null)
                        list = new List<Activity>();
                    list.Add(MapActivity(reader));
                });
            PostMapActivities(list);
            if (getActivityEntries && !CollectionUtils.IsNullOrEmpty(list))
            {
                foreach (Activity activity in list)
                {
                    activity.Entries = GetActivityEntries(activity.Id);
                }
            }
            return list;
        }
        public ICollection<string> GetAllOperationNames(NodeVisit visit)
        {
            ICollection<string> operationNames = new List<string>();
            DoSimpleQueryWithRowCallbackDelegate(
                TABLE_NAME, null, null, "Operation",
                "DISTINCT FlowName;Operation",
                delegate(IDataReader reader)
                {
                    string flowName = reader.GetString(0);
                    string operation = reader.GetString(1);
                    if (!string.IsNullOrEmpty(operation))
                    {
                        if (string.IsNullOrEmpty(flowName) || visit.IsFlowPermittedByName(flowName, FlowRoleType.View))
                        {
                            operationNames.Add(operation);
                        }
                    }
                });
            return operationNames;
        }
        public ICollection<string> GetAllWebMethodNames(NodeVisit visit)
        {
            ICollection<string> webMethodNames = new List<string>();
            DoSimpleQueryWithRowCallbackDelegate(
                TABLE_NAME, null, null, "WebMethod",
                "DISTINCT FlowName;WebMethod",
                delegate(IDataReader reader)
                {
                    string flowName = reader.GetString(0);
                    string webMethod = reader.GetString(1);
                    if (!string.IsNullOrEmpty(webMethod))
                    {
                        if (string.IsNullOrEmpty(flowName) || visit.IsFlowPermittedByName(flowName, FlowRoleType.View))
                        {
                            webMethodNames.Add(webMethod);
                        }
                    }
                });
            return webMethodNames;
        }

        public IList<Activity> GetRecentActivities(ActivitySearchParams searchParams,
                                                   bool addFlowIsNullQuery, int maxNumToReturn,
                                                   bool returnUsernames)
        {
            List<object> whereValues;
            List<Activity> list = null;

            string sql = ConstructJDBCSearchSql(searchParams, addFlowIsNullQuery, out whereValues);
            sql += " ORDER BY ModifiedOn DESC";
            DoJDBCQueryWithCancelableRowCallbackDelegate(sql, whereValues,
                delegate(IDataReader reader)
                {
                    if (list == null)
                        list = new List<Activity>();
                    if (list.Count == maxNumToReturn)
                    {
                        return false;
                    }
                    Activity activity = MapActivity(reader);
                    list.Add(activity);
                    return true;
                });

            if (list != null)
            {
                if (returnUsernames)
                {
                    foreach (Activity activity in list)
                    {
                        activity.ModifiedById = _accountDao.GetUsernameById(activity.ModifiedById);
                    }
                }
            }
            return list;
        }
        public SortableCollection<Activity> Search(ActivitySearchParams searchParams,
                                                   bool addFlowIsNullQuery, bool includeActivityEntries)
        {
            SortableCollection<Activity> list = null;
            List<object> whereValues;

            string sql = ConstructJDBCSearchSql(searchParams, addFlowIsNullQuery, out whereValues);
            DoJDBCQueryWithRowCallbackDelegate(sql, whereValues,
                delegate(IDataReader reader)
                {
                    if (list == null)
                        list = new SortableCollection<Activity>();
                    Activity activity = MapActivity(reader);
                    list.Add(activity);
                });

            if (includeActivityEntries)
            {
                PostMapActivityEntries(list);
            }
            return list;
        }

        public ICollection<string> GetDistinctFromIpList()
        {
            List<string> list = null;
            DoSimpleQueryWithRowCallbackDelegate(
                TABLE_NAME, null, null, "IP",
                "DISTINCT IP",
                delegate(IDataReader reader)
                {
                    string value = reader.GetString(0);
                    if (!string.IsNullOrEmpty(value))
                    {
                        if (list == null)
                            list = new List<string>();
                        list.Add(value);
                    }
                });
            return list;
        }
        public List<ActivityEntry> GetActivityEntries(string activityId)
        {
            List<ActivityEntry> entries = null;
            DoSimpleQueryWithRowCallbackDelegate(
                DETAIL_TABLE_NAME, "ActivityId = ", activityId, "ModifiedOn;OrderIndex",
                MAP_ACTIVITY_DETAIL_COLUMNS,
                delegate(IDataReader reader)
                {
                    if (entries == null)
                    {
                        entries = new List<ActivityEntry>();
                    }
                    entries.Add(MapActivityDetail(reader));
                });

            ObfuscateActivityEntries(entries);

            return entries;
        }
        protected void ObfuscateActivityEntries(IList<ActivityEntry> entries)
        {
            CollectionUtils.ForEach(entries, delegate(ActivityEntry entry)
            {
                entry.Message = StringUtils.ObfuscateActivityMessage(entry.Message);
            });
        }

        public void Save(Activity item)
        {
            if (item == null)
            {
                throw new ArgumentException("Null item");
            }
            DateTime now = DateTime.Now;
            string id = null;
#if DEBUG
            if (CollectionUtils.IsNullOrEmpty(item.Entries))
            {
                DebugUtils.CheckDebuggerBreak();
            }
#endif // DEBUG
            if (!string.IsNullOrEmpty(item.TransactionId))
            {
                if (string.IsNullOrEmpty(item.FlowName) || string.IsNullOrEmpty(item.Operation) ||
                   (item.Method == NodeMethod.None))
                {
                    NodeMethod method;
                    string operation;
                    string flowName = _transactionDao.GetTransactionFlowName(item.TransactionId, out method, out operation);
                    if (string.IsNullOrEmpty(item.FlowName))
                    {
                        item.FlowName = flowName;
                    }
                    if (string.IsNullOrEmpty(item.Operation))
                    {
                        item.Operation = operation;
                    }
                    if (item.Method == NodeMethod.None)
                    {
                        item.Method = method;
                    }
                }
            }
            TransactionTemplate.Execute(delegate
            {
                // Update user account table
                if (string.IsNullOrEmpty(item.Id))
                {
                    id = IdProvider.Get();
                    DoInsert(TABLE_NAME, "Id;Type;TransactionId;IP;ModifiedBy;ModifiedOn;WebMethod;FlowName;Operation",
                             id, item.Type.ToString(), item.TransactionId, item.IP, item.ModifiedById, now,
                             item.Method.ToString(), item.FlowName, item.Operation);
                }
                else
                {
                    id = item.Id;
                    DoSimpleUpdateOne(TABLE_NAME, "Id", item.Id.ToString(),
                                      "Type;TransactionId;IP;ModifiedBy;ModifiedOn;WebMethod;FlowName;Operation",
                                      item.Type.ToString(), item.TransactionId, item.IP, item.ModifiedById, now,
                                      item.Method.ToString(), item.FlowName, item.Operation);
                    DeleteAllEntriesForActivity(id);
                }
                // Update policies
                SaveEntriesForActivity(id, item.Entries);
                return null;
            });
            if (string.IsNullOrEmpty(item.Id))
            {
                item.Id = id;
            }
            item.ModifiedOn = now;
        }

        private void DeleteAllEntriesForActivity(string activityId)
        {
            DoSimpleDelete(DETAIL_TABLE_NAME, "activityId", new object[] { activityId });
        }
        private void SaveEntriesForActivity(string activityId, IList<ActivityEntry> entries)
        {
            if (CollectionUtils.IsNullOrEmpty(entries))
            {
                return;
            }
            object[] insertValues = new object[5];
            DoBulkInsert(DETAIL_TABLE_NAME, "Id;ActivityId;Detail;ModifiedOn;OrderIndex",
                 delegate(int currentInsertIndex)
                 {
                     if (currentInsertIndex < entries.Count)
                     {
                         ActivityEntry entry = entries[currentInsertIndex];
                         insertValues[0] = IdProvider.Get();
                         insertValues[1] = activityId;
                         insertValues[2] = LimitDbText(entry.Message, MAX_DETAIL_CHARS);
                         insertValues[3] = entry.TimeStamp;
                         insertValues[4] = currentInsertIndex;
                         return insertValues;
                     }
                     else
                     {
                         return null;
                     }
                 });
        }
        #endregion

        #region Properties
        public IAccountDao AccountDao
        {
            get
            {
                return _accountDao;
            }
            set
            {
                _accountDao = value;
            }
        }
        public IFlowDao FlowDao
        {
            get
            {
                return _flowDao;
            }
            set
            {
                _flowDao = value;
            }
        }
        public ITransactionDao TransactionDao
        {
            get
            {
                return _transactionDao;
            }
            set
            {
                _transactionDao = value;
            }
        }

        #endregion
    }
}
