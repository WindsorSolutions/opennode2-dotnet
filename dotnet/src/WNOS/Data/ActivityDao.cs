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
        private const int MAX_DETAIL_CHARS = 4096;

        #region Init

        new public void Init()
        {
            base.Init();

            FieldNotInitializedException.ThrowIfNull(this, ref _accountDao);
        }

        #endregion

        #region Mappers
        private const string MAP_ACTIVITY_COLUMNS = "a.Id;a.Type;a.TransactionId;a.IP;a.WebMethod;a.FlowName;a.Operation;a.ModifiedBy;a.ModifiedOn";
        private Activity MapActivity(IDataReader reader)
        {
            int index = 0;
            string id = reader.GetString(index++);
            ActivityType type = EnumUtils.ParseEnum<ActivityType>(reader.GetString(index++));
            string transactionId = reader.GetString(index++);
            string ip = reader.GetString(index++);
            NodeMethod method = EnumUtils.ParseEnum<NodeMethod>(reader.GetString(index++));
            string flowName = reader.GetString(index++);
            string operation = reader.GetString(index++);
            Activity activity = new Activity(method, flowName, operation, type, transactionId, ip, null, null);
            activity.Id = id;
            activity.ModifiedById = reader.GetString(index++);
            activity.ModifiedOn = reader.GetDateTime(index++);
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
        public SortableCollection<Activity> Search(ActivitySearchParams searchParams,
                                                   bool includeActivityEntries)
        {
            if (searchParams == null)
            {
                throw new ArgumentException("search");
            }

            string tableNames = TABLE_NAME + " a";

            StringBuilder whereColumns = new StringBuilder("(a.ModifiedOn >=;a.ModifiedOn <=");
            List<object> whereValues =
                new List<object>(new object[] { ActivitySearchParams.ConstrainDate(searchParams.CreatedFrom), 
                                                ActivitySearchParams.ConstrainDate(searchParams.CreatedTo) });

            if (!string.IsNullOrEmpty(searchParams.FlowName))
            {
                tableNames += ", " + Windsor.Node2008.WNOS.Data.TransactionDao.TABLE_NAME + " t";
                whereColumns.Append(";t.FlowId");
                whereValues.Add(_flowDao.GetDataFlowIdByName(searchParams.FlowName));
            }
            if (!string.IsNullOrEmpty(searchParams.TransactionId))
            {
                //whereColumns.Append(";a.TransactionId");
                //whereValues.Add(searchParams.TransactionId);
                if (!tableNames.Contains(Windsor.Node2008.WNOS.Data.TransactionDao.TABLE_NAME))
                {
                    tableNames += ", " + Windsor.Node2008.WNOS.Data.TransactionDao.TABLE_NAME + " t";
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
            if (tableNames.Contains(Windsor.Node2008.WNOS.Data.TransactionDao.TABLE_NAME))
            {
                whereColumns.Append(";a.TransactionId = t.Id");
            }
            whereColumns.Append(")");

            SortableCollection<Activity> list = null;
            DoSimpleQueryWithRowCallbackDelegate(
                tableNames, whereColumns.ToString(), whereValues, null,
                MAP_ACTIVITY_COLUMNS,
                delegate(IDataReader reader)
                {
                    if (list == null) list = new SortableCollection<Activity>();
                    list.Add(MapActivity(reader));
                });
            PostMapActivities(list);
            if (includeActivityEntries)
            {
                PostMapActivityEntries(list);
            }
            return list;
        }

        public ICollection<Activity> GetRecentActivities(int maxNumToReturn, bool returnUsernames)
        {
            string tableNames = TABLE_NAME + " a";
            List<Activity> list = null;
            DoSimpleQueryWithCancelableRowCallbackDelegate(
                tableNames, null, null, "ModifiedOn DESC",
                MAP_ACTIVITY_COLUMNS,
                delegate(IDataReader reader)
                {
                    if (list == null) list = new List<Activity>();
                    if (list.Count == maxNumToReturn)
                    {
                        return false;
                    }
                    list.Add(MapActivity(reader));
                    return true;
                });
            PostMapActivities(list);
            if (returnUsernames && (list != null))
            {
                foreach (Activity activity in list)
                {
                    activity.ModifiedById = _accountDao.GetUsernameById(activity.ModifiedById);
                }
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
                    if (list == null) list = new List<string>();
                    list.Add(reader.GetString(0));
                });
            return list;
        }
        public List<ActivityEntry> GetActivityEntries(string activityId)
        {
            List<ActivityEntry> entries = null;
            DoSimpleQueryWithRowCallbackDelegate(
                DETAIL_TABLE_NAME, "ActivityId", activityId, "ModifiedOn;OrderIndex",
                MAP_ACTIVITY_DETAIL_COLUMNS,
                delegate(IDataReader reader)
                {
                    if (entries == null)
                    {
                        entries = new List<ActivityEntry>();
                    }
                    entries.Add(MapActivityDetail(reader));
                });
            return entries;
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
            get { return _accountDao; }
            set { _accountDao = value; }
        }
        public IFlowDao FlowDao
        {
            get { return _flowDao; }
            set { _flowDao = value; }
        }
        public ITransactionDao TransactionDao
        {
            get { return _transactionDao; }
            set { _transactionDao = value; }
        }

        #endregion
    }
}
