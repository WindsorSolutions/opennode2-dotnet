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
using System.Diagnostics;

using Spring.Data.Generic;
using Spring.Data.Common;


using Common.Logging;

using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSUtility;
using Windsor.Node2008.WNOSConnector;
using Windsor.Node2008.WNOSConnector.Logic;
using Windsor.Commons.Core;
using Windsor.Commons.NodeDomain;

namespace Windsor.Node2008.WNOS.Data
{
    public class ScheduleDao : BaseDao, IScheduleDao
    {
        public const string TABLE_NAME = "NSchedule";
        public const string SOURCE_ARGS_TABLE_NAME = "NScheduleSourceArg";
        private const int cNumSignificantIndexDigits = 3;
        private static readonly string cIndexFormatString;
        private static readonly string cFirstIndexString;
        private IActivityDao _activityDao;
        private IServiceDao _serviceDao;
        private IAccountManagerEx _accountManager;

        static ScheduleDao()
        {
            cIndexFormatString = "D" + cNumSignificantIndexDigits.ToString();
            cFirstIndexString = 0.ToString(cIndexFormatString);
        }
        #region Init

        new public void Init()
        {
            base.Init();
            FieldNotInitializedException.ThrowIfNull(this, ref _activityDao);
            FieldNotInitializedException.ThrowIfNull(this, ref _serviceDao);
            FieldNotInitializedException.ThrowIfNull(this, ref _accountManager);
            FieldNotInitializedException.ThrowIfNull(this, AccountDao, "AccountDao");

            MAP_SCHEDULED_ITEM_COLUMNS = "Id;Name;FlowId;StartOn;EndOn;SourceType;SourceId;SourceFlow;SourceOperation;" +
                                         "TargetType;TargetId;TargetFlow;TargetOperation;LastExecuteActivityId;LastExecutedOn;" +
                                         "NextRun;FrequencyType;Frequency;ModifiedBy;ModifiedOn;IsActive;ExecuteStatus";
            if (AreEndpointUsersEnabled)
            {
                MAP_SCHEDULED_ITEM_COLUMNS += ";SourceEndpointUser;TargetEndpointUser";
            }
        }

        #endregion
        #region Mappers
        private const string MAP_SCHEDULED_ITEM_EXECUTE_STATUS_COLUMNS = "Id;FlowId;LastExecuteActivityId;LastExecutedOn;NextRun;ExecuteStatus";
        private ScheduledItemExecuteStatus MapScheduledItemExecuteStatus(IDataReader reader)
        {
            ScheduledItemExecuteStatus scheduledItem = new ScheduledItemExecuteStatus();
            int index = 0;
            scheduledItem.Id = reader.GetString(index++);
            scheduledItem.FlowId = reader.GetString(index++);
            scheduledItem.LastExecuteActivityId = reader.IsDBNull(index) ? null : reader.GetString(index);
            index++;
            scheduledItem.LastExecutedOn = DbUtils.ToDate(reader.GetDateTime(index++));
            scheduledItem.NextRunOn = DbUtils.ToDate(reader.GetDateTime(index++));
            scheduledItem.ExecuteStatus = EnumUtils.ParseEnum<ScheduleExecuteStatus>(reader.GetString(index++));
            return scheduledItem;
        }
        private string MAP_SCHEDULED_ITEM_COLUMNS;
        private ScheduledItem MapScheduledItem(IDataReader reader)
        {
            ScheduledItem scheduledItem = new ScheduledItem();
            int index = 0;
            scheduledItem.Id = reader.GetString(index++);
            scheduledItem.Name = reader.GetString(index++);
            scheduledItem.FlowId = reader.GetString(index++);
            scheduledItem.StartOn = DbUtils.ToDate(reader.GetDateTime(index++));
            scheduledItem.EndOn = DbUtils.ToDate(reader.GetDateTime(index++));
            scheduledItem.SourceType = EnumUtils.ParseEnum<ScheduledItemSourceType>(reader.GetString(index++));
            scheduledItem.SourceId = reader.GetString(index++);
            scheduledItem.SourceFlow = reader.GetString(index++);
            scheduledItem.SourceRequest = reader.GetString(index++);
            scheduledItem.TargetType = EnumUtils.ParseEnum<ScheduledItemTargetType>(reader.GetString(index++));
            scheduledItem.TargetId = reader.GetString(index++);
            scheduledItem.TargetFlow = reader.GetString(index++);
            scheduledItem.TargetRequest = reader.GetString(index++);
            scheduledItem.LastExecuteActivityId = reader.IsDBNull(index) ? null : reader.GetString(index);
            index++;
            scheduledItem.LastExecutedOn = DbUtils.ToDate(reader.GetDateTime(index++));
            scheduledItem.NextRunOn = DbUtils.ToDate(reader.GetDateTime(index++));
            scheduledItem.FrequencyType = EnumUtils.ParseEnum<ScheduledFrequencyType>(reader.GetString(index++));
            object freqNum = reader.GetValue(index++);
            scheduledItem.Frequency = (freqNum != null) ? int.Parse(freqNum.ToString()) : 0;
            scheduledItem.ModifiedById = reader.GetString(index++);
            scheduledItem.ModifiedOn = DbUtils.ToDate(reader.GetDateTime(index++));
            scheduledItem.IsActive = DbUtils.ToBool(reader.GetString(index++));
            scheduledItem.ExecuteStatus = EnumUtils.ParseEnum<ScheduleExecuteStatus>(reader.GetString(index++));
            if (AreEndpointUsersEnabled)
            {
                scheduledItem.SourceEndpointUser = reader.GetString(index++);
                scheduledItem.TargetEndpointUser = reader.GetString(index++);
                if (string.IsNullOrEmpty(scheduledItem.SourceEndpointUser))
                {
                    scheduledItem.SourceEndpointUser = null;
                }
                if (string.IsNullOrEmpty(scheduledItem.TargetEndpointUser))
                {
                    scheduledItem.TargetEndpointUser = null;
                }
            }
            return scheduledItem;
        }
        private void PostMapSchedule(ScheduledItem scheduledItem)
        {
            scheduledItem.SourceArgs = GetScheduleSourceArgs(scheduledItem.Id);
            scheduledItem.LastExecuteInfo = GetScheduleLastExecuteInfo(scheduledItem.LastExecuteActivityId);
        }
        private void PostMapSchedules(IEnumerable<ScheduledItem> scheduledItems)
        {
            if (scheduledItems != null)
            {
                foreach (ScheduledItem scheduledItem in scheduledItems)
                {
                    PostMapSchedule(scheduledItem);
                }
            }
        }
        #endregion // Mappers

        #region Methods

        /// <summary>
        /// Returns a list of Schedule ids that are ready to be processed
        /// </summary>
        public IList<string> GetNextScheduledItemsToProcess()
        {
            IList<string> scheduleList = null;
            DateTime now = DateTime.Now;
            DoSimpleQueryWithRowCallbackDelegate(TABLE_NAME,
                "(StartOn <=;EndOn >=;NextRun <=;IsActive;) OR (IsActive;IsRunNow;)",
                new object[] { now, now, now, DbUtils.ToDbBool(true), DbUtils.ToDbBool(true), DbUtils.ToDbBool(true) },
                null, "Id",
                delegate (IDataReader reader)
                {
                    if (scheduleList == null)
                    {
                        scheduleList = new List<string>();
                    }
                    scheduleList.Add(reader.GetString(0));
                });
            return scheduleList;
        }

        public IList<ScheduledItem> Get()
        {
            List<ScheduledItem> scheduledItems = new List<ScheduledItem>();
            DoSimpleQueryWithRowCallbackDelegate(
                TABLE_NAME, string.Empty, null, null, MAP_SCHEDULED_ITEM_COLUMNS,
                delegate(IDataReader reader)
                {
                    if (scheduledItems == null)
                    {
                        scheduledItems = new List<ScheduledItem>();
                    }
                    scheduledItems.Add(MapScheduledItem(reader));
                });
            return scheduledItems;
        }
        public IList<ScheduledItemExecuteStatus> GetScheduledItemExecuteStatus()
        {
            List<ScheduledItemExecuteStatus> scheduledItems = null;
            DoSimpleQueryWithRowCallbackDelegate(
                TABLE_NAME, string.Empty, null, null, MAP_SCHEDULED_ITEM_EXECUTE_STATUS_COLUMNS,
                delegate(IDataReader reader)
                {
                    CollectionUtils.Add(MapScheduledItemExecuteStatus(reader), ref scheduledItems);
                });
            return scheduledItems;
        }

        public ScheduledItemExecuteInfo GetScheduleLastExecuteInfo(string activityId)
        {
            if (string.IsNullOrEmpty(activityId))
            {
                return null;
            }
            try
            {
                Activity activity = _activityDao.Get(activityId, true);
                if (activity == null)
                {
                    return null;
                }
                return new ScheduledItemExecuteInfo(activity.TransactionId, GetLastExecutionInfo(activity));
            }
            catch (Spring.Dao.IncorrectResultSizeDataAccessException)
            {
                return null; // Not found
            }
        }
        public ScheduledItemExecuteInfo GetScheduleLastExecuteInfo(IList<string> activityIds)
        {
            if (CollectionUtils.IsNullOrEmpty(activityIds))
            {
                return null;
            }
            try
            {
                string transactionId = null;
                StringBuilder sb = new StringBuilder();
                foreach (string activityId in activityIds)
                {
                    Activity activity = _activityDao.Get(activityId, true);
                    if (activity != null)
                    {
                        if (sb.Length > 0)
                        {
                            sb.AppendLine();
                            sb.AppendLine();
                        }
                        transactionId = activity.TransactionId;
                        sb.AppendLine(GetLastExecutionInfo(activity));
                    }
                }
                if (transactionId != null)
                {
                    return new ScheduledItemExecuteInfo(transactionId, sb.ToString());
                }
                else
                {
                    return null;
                }
            }
            catch (Spring.Dao.IncorrectResultSizeDataAccessException)
            {
                return null; // Not found
            }
        }
        public ScheduledItemExecuteInfo GetTransactionLastExecuteInfo(string transactionId)
        {
            return GetScheduleLastExecuteInfo(_activityDao.GetActivityIdFromTransactionId(transactionId));
        }
        public ScheduledItemExecuteInfo GetTransactionCompleteLastExecuteInfo(string transactionId)
        {
            return GetScheduleLastExecuteInfo(_activityDao.GetActivityIdsFromTransactionId(transactionId));
        }
        public string GetLastExecutionInfo(Activity activity)
        {
            return GetLastExecutionInfo(activity, false);
        }

        public string GetLastExecutionInfo(Activity activity, bool obfuscateActivityMessage)
        {
            if (!CollectionUtils.IsNullOrEmpty(activity.Entries))
            {
                StringBuilder sb = new StringBuilder();
                foreach (ActivityEntry entry in activity.Entries)
                {
                    if (sb.Length > 0)
                    {
                        sb.AppendLine();
                    }
                    sb.AppendFormat("{0}: {1}", entry.ToDisplayTimeStamp(), obfuscateActivityMessage ?
                        StringUtils.ObfuscateActivityMessage(entry.Message) : entry.Message);
                }
                return sb.ToString();
            }
            return string.Empty;
        }
        /// <summary>
        /// Return the source arguments for the schedule with the specified service id, or null
        /// if the id is not found.
        /// </summary>
        public ByIndexOrNameDictionary<string> GetScheduleSourceArgs(string scheduleId)
        {
            ByIndexOrNameDictionary<string> args = null;
            bool isByName = false;
            DoSimpleQueryWithRowCallbackDelegate(
                SOURCE_ARGS_TABLE_NAME, "ScheduleId", scheduleId, "Name",
                "Name;Value",
                delegate(IDataReader reader)
                {
                    string name = reader.GetString(0);
                    if (args == null)
                    {
                        isByName = (name != cFirstIndexString);
                        args = new ByIndexOrNameDictionary<string>(isByName);
                    }
                    if (isByName)
                    {
                        args.Add(name.Substring(cNumSignificantIndexDigits), reader.GetString(1));
                    }
                    else
                    {
                        args.Add(reader.GetString(1));
                    }
                });
            return args;
        }
        /// <summary>
        /// Returns a scheduled item by Id, or null if the item does not exist.
        /// </summary>
        public ScheduledItem GetScheduledItem(string inScheduledItemId)
        {
            bool isRunNow;
            return GetScheduledItem(inScheduledItemId, out isRunNow);
        }
        /// <summary>
        /// Returns a scheduled item by Id, or null if the item does not exist.
        /// </summary>
        public ScheduledItem GetScheduledItem(string inScheduledItemId, out bool isRunNow)
        {
            try
            {
                bool isRunNowPriv = false;
                ScheduledItem scheduledItem =
                    DoSimpleQueryForObjectDelegate<ScheduledItem>(
                        TABLE_NAME, "Id", inScheduledItemId, MAP_SCHEDULED_ITEM_COLUMNS + ";IsRunNow",
                        delegate(IDataReader reader, int rowNum)
                        {
                            ScheduledItem item = MapScheduledItem(reader);
                            isRunNowPriv = DbUtils.ToBool(reader.GetString(reader.FieldCount - 1));
                            return item;
                        });
                isRunNow = isRunNowPriv;
                if (scheduledItem != null)
                {
                    PostMapSchedule(scheduledItem);
                }
                return scheduledItem;
            }
            catch (Spring.Dao.IncorrectResultSizeDataAccessException)
            {
                isRunNow = false;
                return null; // Not found
            }
        }
        /// <summary>
        /// Returns a scheduled item Id, or null if the item does not exist.
        /// </summary>
        public string GetScheduledItemIdByName(string inScheduledItemName)
        {
            try
            {
                string id =
                    DoSimpleQueryForObjectDelegate<string>(
                        TABLE_NAME, "Name", inScheduledItemName, "Id",
                        delegate(IDataReader reader, int rowNum)
                        {
                            return reader.GetString(0);
                        });
                return id;
            }
            catch (Spring.Dao.IncorrectResultSizeDataAccessException)
            {
                return null; // Not found
            }
        }
        /// <summary>
        /// Returns a scheduled item by Id, or null if the item does not exist.
        /// </summary>
        public ScheduledItem GetScheduledItemByName(string inScheduledItemName, out bool isRunNow)
        {
            try
            {
                bool isRunNowPriv = false;
                ScheduledItem scheduledItem =
                    DoSimpleQueryForObjectDelegate<ScheduledItem>(
                        TABLE_NAME, "Name", inScheduledItemName, MAP_SCHEDULED_ITEM_COLUMNS + ";IsRunNow",
                        delegate(IDataReader reader, int rowNum)
                        {
                            ScheduledItem item = MapScheduledItem(reader);
                            isRunNowPriv = DbUtils.ToBool(reader.GetString(reader.FieldCount - 1));
                            return item;
                        });
                isRunNow = isRunNowPriv;
                if (scheduledItem != null)
                {
                    PostMapSchedule(scheduledItem);
                }
                return scheduledItem;
            }
            catch (Spring.Dao.IncorrectResultSizeDataAccessException)
            {
                isRunNow = false;
                return null; // Not found
            }
        }
        public void SetScheduleRuntime(string scheduleName, DateTime nextRuntime, ByIndexOrNameDictionary<string> parameters)
        {
            bool runNow;
            ScheduledItem item = GetScheduledItemByName(scheduleName, out runNow);
            if (item == null)
            {
                throw new ArgumentException(string.Format("Could not locate a schedule with the name \"{0}\"", scheduleName));
            }
            if (!item.IsActive)
            {
                throw new ArgumentException(string.Format("The schedule \"{0}\" is inactive and could not be scheduled.  Please active the schedule and try again.",
                                                          scheduleName));
            }
            if ((item.StartOn > nextRuntime) || (item.EndOn < nextRuntime))
            {
                throw new ArgumentException(string.Format("The schedule \"{0}\" could not be scheduled to run at {1} since it has an execution range of {2} to {3}",
                                                          scheduleName, nextRuntime.ToString(), item.StartOn.ToString(),
                                                          item.EndOn.ToString()));
            }

            item.NextRunOn = nextRuntime;
            item.SourceArgs = parameters;

            Save(item);
        }
        public void UpdateScheduleStatus(string scheduleId, ScheduleExecuteStatus status)
        {
            DoSimpleUpdateOne(TABLE_NAME, "Id", scheduleId.ToString(),
                              "ExecuteStatus", status.ToString());
        }
        public void Save(ScheduledItem item)
        {
            SaveAndRun(item, null);
        }
        public void Save(ScheduledItem item, bool isRunNow)
        {
            SaveAndRun(item, new bool?(isRunNow));
        }
        public void SaveAndRunNow(ScheduledItem item)
        {
            SaveAndRun(item, new bool?(true));
        }
        public void RunNow(ScheduledItem item)
        {
            SaveAndRun(item, new bool?(true));
        }
        public bool AreEndpointUsersEnabled
        {
            get
            {
                return AccountDao.AreEndpointUsersEnabled;
            }
        }
        private void SaveAndRun(ScheduledItem item, bool? runNow)
        {
            if (item == null)
            {
                throw new ArgumentException("Null item");
            }
            DateTime now = DateTime.Now;
            string id = null;
            bool isRunNow = runNow.HasValue ? runNow.Value : false;
            string columnNames = "Name;FlowId;StartOn;EndOn;SourceType;SourceId;SourceFlow;SourceOperation;TargetType;" +
                                 "TargetId;TargetFlow;TargetOperation;LastExecuteActivityId;LastExecutedOn;NextRun;" +
                                 "FrequencyType;Frequency;ModifiedBy;ModifiedOn;IsActive;IsRunNow;ExecuteStatus";
            List<object> columnValues =
                CollectionUtils.CreateList<object>(item.Name, item.FlowId, DbUtils.ToDbDate(item.StartOn),
                                                   DbUtils.ToDbDate(item.EndOn),
                                                   item.SourceType.ToString(), item.SourceId, item.SourceFlow ?? string.Empty,
                                                   item.SourceRequest ?? string.Empty, item.TargetType.ToString(), item.TargetId,
                                                   item.TargetFlow ?? string.Empty, item.TargetRequest ?? string.Empty, item.LastExecuteActivityId,
                                                   DbUtils.ToDbDate(item.LastExecutedOn),
                                                   DbUtils.ToDbDate(item.NextRunOn), item.FrequencyType.ToString(),
                                                   item.Frequency, item.ModifiedById, now, DbUtils.ToDbBool(item.IsActive),
                                                   DbUtils.ToDbBool(isRunNow), item.ExecuteStatus.ToString());
            if (AreEndpointUsersEnabled)
            {
                columnNames += ";SourceEndpointUser;TargetEndpointUser";
                columnValues.AddRange(new object[] { item.SourceEndpointUser, item.TargetEndpointUser });
            }
            TransactionTemplate.Execute(delegate
            {
                if (string.IsNullOrEmpty(item.Id))
                {
                    id = IdProvider.Get();
                    columnNames = "Id;" + columnNames;
                    columnValues.Insert(0, id);
                    DoInsertWithValues(TABLE_NAME, columnNames, columnValues);
                }
                else
                {
                    DoSimpleUpdateOneWithValues(TABLE_NAME, "Id", item.Id, columnNames, columnValues);
                }
                SaveScheduleSourceArgs(id ?? item.Id, item.SourceArgs);
                return null;
            });
            if (id != null)
            {
                item.Id = id;
            }
            item.ModifiedOn = now;
        }
        public void SaveAndRun(string scheduleId, IDictionary<string, string> updateScheduleParameters)
        {
            if (scheduleId == null)
            {
                throw new ArgumentException("Null item");
            }
            string columnNames = "IsRunNow";
            List<object> columnValues =
                CollectionUtils.CreateList<object>(DbUtils.ToDbBool(true));
            TransactionTemplate.Execute(delegate
            {
                DoSimpleUpdateOneWithValues(TABLE_NAME, "Id", scheduleId, columnNames, columnValues);
                bool isRunNow;
                if (!CollectionUtils.IsNullOrEmpty(updateScheduleParameters))
                {
                    UpdateScheduleSourceArgs(scheduleId, updateScheduleParameters);
                }
                return null;
            });
        }
        public void UpdateScheduleSourceArgs(string scheduleId, IDictionary<string, string> updateScheduleParams)
        {
            if (CollectionUtils.IsNullOrEmpty(updateScheduleParams))
            {
                return;
            }
            TransactionTemplate.Execute(delegate
            {
                foreach (var pair in updateScheduleParams)
                {
                    int count = DoSimpleUpdate(SOURCE_ARGS_TABLE_NAME, "ScheduleId;Name LIKE '%'p", new object[] { scheduleId, pair.Key },
                                               "Value", 1, pair.Value);
                    if (count == 0)
                    {
                        throw new ArgumentException(string.Format("The schedule with id \"{0}\" does not have any schedule parameters matching the name \"{0}\"", pair.Key));
                    } 
                    else if (count > 1)
                    {
                        throw new ArgumentException(string.Format("The schedule with id \"{0}\" has more than one schedule parameter matching the name \"{0}\"", pair.Key));
                    }
                }
                return null;
            });
        }
        private void SaveScheduleSourceArgs(string scheduleId, ByIndexOrNameDictionary<string> args)
        {
            TransactionTemplate.Execute(delegate
            {
                DoSimpleDelete(SOURCE_ARGS_TABLE_NAME, "ScheduleId", new object[] { scheduleId });
                if (CollectionUtils.IsNullOrEmpty(args))
                {
                    return null;
                }
                object[] insertValues = new object[4];
                DoBulkInsert(SOURCE_ARGS_TABLE_NAME, "Id;ScheduleId;Name;Value",
                     delegate(int currentInsertIndex)
                     {
                         if (currentInsertIndex < args.Count)
                         {
                             insertValues[0] = IdProvider.Get();
                             insertValues[1] = scheduleId;
                             if (args.IsByName)
                             {
                                 insertValues[2] = currentInsertIndex.ToString(cIndexFormatString) + args.KeyAtIndex(currentInsertIndex);
                             }
                             else
                             {
                                 insertValues[2] = currentInsertIndex.ToString(cIndexFormatString);
                             }
                             insertValues[3] = string.IsNullOrEmpty(args[currentInsertIndex]) ? (object)DBNull.Value : (object)args[currentInsertIndex];
                             return insertValues;
                         }
                         else
                         {
                             return null;
                         }
                     });
                return null;
            });
        }
        public void Delete(string id)
        {
            DoSimpleDelete(TABLE_NAME, "Id", new object[] { id });
        }
        public void DeleteByName(string scheduleName)
        {
            DoSimpleDelete(TABLE_NAME, "Name", new object[] { scheduleName });
        }
        public ScheduledItem CreateRunOnceLocalServiceSchedule(string scheduleName, string serviceName, DateTime nextRuntime,
                                                               ByIndexOrNameDictionary<string> parameters)
        {
            if (string.IsNullOrEmpty(scheduleName))
            {
                throw new ArgumentException("scheduleName is null");
            }
            if (string.IsNullOrEmpty(serviceName))
            {
                throw new ArgumentException("serviceName is null");
            }
            DataService dataService = _serviceDao.GetDataServiceByName(serviceName);
            if (dataService == null)
            {
                throw new ArgumentException(string.Format("The service \"{0}\" could not be found", serviceName));
            }
            ScheduledItem scheduledItem = new ScheduledItem();
            scheduledItem.SourceId = dataService.Id;
            scheduledItem.SourceType = ScheduledItemSourceType.LocalService;
            scheduledItem.FlowId = dataService.FlowId;
            scheduledItem.TargetType = ScheduledItemTargetType.None;
            scheduledItem.Name = scheduleName;
            scheduledItem.Frequency = 1;
            scheduledItem.FrequencyType = ScheduledFrequencyType.OnceThenDelete;
            scheduledItem.IsActive = true;
            scheduledItem.StartOn = nextRuntime;
            scheduledItem.NextRunOn = nextRuntime;
            scheduledItem.EndOn = nextRuntime + TimeSpan.FromDays(365);
            scheduledItem.SourceArgs = parameters;
            scheduledItem.ModifiedById = _accountManager.RuntimeAccount.Id;
            Save(scheduledItem);
            return scheduledItem;
        }
        #endregion

        #region Properties
        public IActivityDao ActivityDao
        {
            get
            {
                return _activityDao;
            }
            set
            {
                _activityDao = value;
            }
        }
        public IServiceDao ServiceDao
        {
            get
            {
                return _serviceDao;
            }
            set
            {
                _serviceDao = value;
            }
        }
        public IAccountManagerEx AccountManager
        {
            get
            {
                return _accountManager;
            }
            set
            {
                _accountManager = value;
            }
        }
        public IAccountDao AccountDao
        {
            get;
            set;
        }
        #endregion
    }
}
