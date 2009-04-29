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

        static ScheduleDao()
        {
            cIndexFormatString = "D" + cNumSignificantIndexDigits.ToString();
            cFirstIndexString = 0.ToString(cIndexFormatString);
        }
        #region Init

        new public void Init()
        {
            base.Init();
		}

        #endregion
        #region Mappers
        private const string MAP_SCHEDULED_ITEM_COLUMNS = "Id;Name;FlowId;StartOn;EndOn;SourceType;SourceId;SourceFlow;SourceOperation;" +
                                                          "TargetType;TargetId;TargetFlow;TargetOperation;LastExecuteActivityId;LastExecutedOn;" +
                                                          "NextRun;FrequencyType;Frequency;ModifiedBy;ModifiedOn;IsActive;ExecuteStatus";
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
			scheduledItem.Frequency = reader.GetInt32(index++);
			scheduledItem.ModifiedById = reader.GetString(index++);
			scheduledItem.ModifiedOn = DbUtils.ToDate(reader.GetDateTime(index++));
			scheduledItem.IsActive = DbUtils.ToBool(reader.GetString(index++));
            scheduledItem.ExecuteStatus = EnumUtils.ParseEnum<ScheduleExecuteStatus>(reader.GetString(index++));
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
        public IList<string> GetNextScheduledItemsToProcess() {
			IList<string> scheduleList = null;
            DateTime now = DateTime.Now;
			DoSimpleQueryWithRowCallbackDelegate(TABLE_NAME,
                "(StartOn <=;EndOn >=;NextRun <=;IsActive;) OR (IsActive;IsRunNow;)",
                new object[] { now, now, now, DbUtils.ToDbBool(true), DbUtils.ToDbBool(true), DbUtils.ToDbBool(true) }, 
                null, "Id",
				delegate(IDataReader reader) {
					if ( scheduleList == null ) {
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
            PostMapSchedules(scheduledItems);
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
        protected string GetLastExecutionInfo(Activity activity)
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
                    sb.AppendFormat("{0}: {1}", entry.ToDisplayTimeStamp(), entry.Message);
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
			try {
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
			catch(Spring.Dao.IncorrectResultSizeDataAccessException) {
                isRunNow = false;
				return null; // Not found
			}
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
        private void SaveAndRun(ScheduledItem item, bool? runNow)
        {
            if (item == null)
            {
                throw new ArgumentException("Null item");
            }
            DateTime now = DateTime.Now;
            string id = null;
            TransactionTemplate.Execute(delegate
            {
                if (string.IsNullOrEmpty(item.Id))
                {
                    id = IdProvider.Get();
                    bool isRunNow = (runNow != null) ? runNow.Value : false;
                    DoInsert(TABLE_NAME,
                             "Id;Name;FlowId;StartOn;EndOn;SourceType;SourceId;SourceFlow;SourceOperation;TargetType;" +
                             "TargetId;TargetFlow;TargetOperation;LastExecuteActivityId;LastExecutedOn;NextRun;" +
                             "FrequencyType;Frequency;ModifiedBy;ModifiedOn;IsActive;IsRunNow;ExecuteStatus",
                             id, item.Name, item.FlowId, DbUtils.ToDbDate(item.StartOn),
                             DbUtils.ToDbDate(item.EndOn),
                             item.SourceType.ToString(), item.SourceId, item.SourceFlow ?? string.Empty,
                             item.SourceRequest ?? string.Empty, item.TargetType.ToString(), item.TargetId,
                             item.TargetFlow ?? string.Empty, item.TargetRequest ?? string.Empty, item.LastExecuteActivityId,
                             DbUtils.ToDbDate(item.LastExecutedOn),
                             DbUtils.ToDbDate(item.NextRunOn), item.FrequencyType.ToString(),
                             item.Frequency, item.ModifiedById, now, DbUtils.ToDbBool(item.IsActive),
                             DbUtils.ToDbBool(isRunNow), item.ExecuteStatus.ToString());
                }
                else
                {
                    if (runNow != null)
                    {
                        DoSimpleUpdateOne(TABLE_NAME, "Id", item.Id.ToString(),
                                          "Name;FlowId;StartOn;EndOn;SourceType;SourceId;SourceFlow;SourceOperation;TargetType;" +
                                          "TargetId;TargetFlow;TargetOperation;LastExecuteActivityId;LastExecutedOn;NextRun;" +
                                          "FrequencyType;Frequency;ModifiedBy;ModifiedOn;IsActive;IsRunNow;ExecuteStatus",
                                          item.Name, item.FlowId, DbUtils.ToDbDate(item.StartOn),
                                          DbUtils.ToDbDate(item.EndOn),
                                          item.SourceType.ToString(), item.SourceId, item.SourceFlow ?? string.Empty,
                                          item.SourceRequest ?? string.Empty, item.TargetType.ToString(), item.TargetId,
                                          item.TargetFlow ?? string.Empty, item.TargetRequest ?? string.Empty, item.LastExecuteActivityId,
                                          DbUtils.ToDbDate(item.LastExecutedOn),
                                          DbUtils.ToDbDate(item.NextRunOn), item.FrequencyType.ToString(),
                                          item.Frequency, item.ModifiedById, now, DbUtils.ToDbBool(item.IsActive),
                                          DbUtils.ToDbBool(runNow.Value), item.ExecuteStatus.ToString());
                    }
                    else
                    {
                        DoSimpleUpdateOne(TABLE_NAME, "Id", item.Id.ToString(),
                                         "Name;FlowId;StartOn;EndOn;SourceType;SourceId;SourceFlow;SourceOperation;TargetType;" +
                                          "TargetId;TargetFlow;TargetOperation;LastExecuteActivityId;LastExecutedOn;NextRun;" +
                                          "FrequencyType;Frequency;ModifiedBy;ModifiedOn;IsActive;ExecuteStatus",
                                          item.Name, item.FlowId, DbUtils.ToDbDate(item.StartOn),
                                          DbUtils.ToDbDate(item.EndOn),
                                          item.SourceType.ToString(), item.SourceId, item.SourceFlow ?? string.Empty,
                                          item.SourceRequest ?? string.Empty, item.TargetType.ToString(), item.TargetId,
                                          item.TargetFlow ?? string.Empty, item.TargetRequest ?? string.Empty, item.LastExecuteActivityId,
                                          DbUtils.ToDbDate(item.LastExecutedOn),
                                          DbUtils.ToDbDate(item.NextRunOn), item.FrequencyType.ToString(),
                                          item.Frequency, item.ModifiedById, now, DbUtils.ToDbBool(item.IsActive),
                                          item.ExecuteStatus.ToString());
                    }
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
                             insertValues[3] = string.IsNullOrEmpty(args[currentInsertIndex]) ? (object) DBNull.Value : (object) args[currentInsertIndex];
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
        #endregion

        #region Properties
        public IActivityDao ActivityDao
        {
            get { return _activityDao; }
            set { _activityDao = value; }
        }
        #endregion
    }
}
