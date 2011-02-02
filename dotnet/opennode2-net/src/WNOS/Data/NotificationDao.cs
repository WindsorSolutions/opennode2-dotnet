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
using Windsor.Node2008.WNOSConnector.Provider;
using Windsor.Node2008.WNOSUtility;
using Windsor.Commons.Core;

namespace Windsor.Node2008.WNOS.Data
{
    /// <summary>
    /// Should be implementing interface but for now just use the raw object
    /// </summary>
    public class NotificationDao : BaseDao, INotificationDao
    {
        private IFlowDao _flowDao;
        public const string TABLE_NAME = "NNotification";

        #region Init

        new public void Init()
        {
            base.Init();

            FieldNotInitializedException.ThrowIfNull(this, ref _flowDao);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get all the To email addresses associated with the input flow and notification type.
        /// </summary>
        public IList<string> GetNotificationEmails(string flowId, NotificationType notificationType)
        {
            List<string> emails = null;
            DoSimpleQueryWithRowCallbackDelegate(
                string.Format("{0} a;{1} n", AccountDao.TABLE_NAME, TABLE_NAME),
                "n.FlowId;a.IsActive;a.IsDeleted;n." + GetNotificationColumnNameFromType(notificationType) + ";a.Id = n.AccountID",
                new object[] { flowId, DbUtils.ToDbBool(true), DbUtils.ToDbBool(false), DbUtils.ToDbBool(true) },
                null, "a.NAASAccount",
                delegate(IDataReader reader)
                {
                    if (emails == null)
                    {
                        emails = new List<string>();
                    }
                    emails.Add(reader.GetString(0));
                });
            return emails;
        }
        /// <summary>
		/// Get all the To email addresses associated with the input flow and notification type.
		/// </summary>
        public IList<string> GetNotificationEmails(string flowId, NotificationType notificationType,
                                                   out string flowName)
        {
            IList<string> emails = GetNotificationEmails(flowId, notificationType);
            flowName = _flowDao.GetDataFlowNameById(flowId);
			return emails;
        }
		/// <summary>
		/// Get all the To email addresses associated with the input flow and notification type.
		/// </summary>
        public string GetNotificationEmailsAsString(string flowId, NotificationType notificationType)
        {
            IList<string> addresses = GetNotificationEmails(flowId, notificationType);
			return !CollectionUtils.IsNullOrEmpty(addresses) ? StringUtils.Join(",", addresses) : 
															   string.Empty;
        }
        public string GetNotificationEmailsAsString(string flowId, NotificationType notificationType, out string flowName)
        {
            IList<string> addresses = GetNotificationEmails(flowId, notificationType, out flowName);
            return !CollectionUtils.IsNullOrEmpty(addresses) ? StringUtils.Join(",", addresses) :
                                                               string.Empty;
        }
        public IList<SimpleFlowNotification> GetAllSimpleFlowNotificationsForUsername(string username)
        {
            List<SimpleFlowNotification> flowNotifications = new List<SimpleFlowNotification>();
            DoSimpleQueryWithRowCallbackDelegate(
                string.Format("{0} f;{1} a;{2} n", Windsor.Node2008.WNOS.Data.FlowDao.TABLE_NAME, 
                              AccountDao.TABLE_NAME, TABLE_NAME),
                "a.NAASAccount;n.FlowId=f.Id;n.AccountId=a.Id",
                new object[] { username }, null,
                "n.OnSolicit;n.OnQuery;n.OnSubmit;n.OnNotify;n.OnSchedule;n.OnDownload;n.OnExecute;f.Code;f.Description",
                delegate(IDataReader reader)
                {
                    int index = 0;
                    NotificationType notificationType = NotificationType.None;
                    if (DbUtils.ToBool(reader.GetString(index++))) notificationType |= NotificationType.OnSolicit;
                    if (DbUtils.ToBool(reader.GetString(index++))) notificationType |= NotificationType.OnQuery;
                    if (DbUtils.ToBool(reader.GetString(index++))) notificationType |= NotificationType.OnSubmit;
                    if (DbUtils.ToBool(reader.GetString(index++))) notificationType |= NotificationType.OnNotify;
                    if (DbUtils.ToBool(reader.GetString(index++))) notificationType |= NotificationType.OnSchedule;
                    if (DbUtils.ToBool(reader.GetString(index++))) notificationType |= NotificationType.OnDownload;
                    if (DbUtils.ToBool(reader.GetString(index++))) notificationType |= NotificationType.OnExecute;
                    string name = reader.GetString(index++);
                    string description = reader.GetString(index++);
                    flowNotifications.Add(new SimpleFlowNotification(name, description, notificationType));
                });
            return flowNotifications;
        }
        public void SaveNotifications(string userId, string modifiedByUserId, 
                                      IList<SimpleFlowNotification> notifications)
        {
            // Convert flow names to ids
            List<KeyValuePair<string, NotificationType>> notificationArray = null;
            if (!CollectionUtils.IsNullOrEmpty(notifications))
            {
                notificationArray = new List<KeyValuePair<string, NotificationType>>(notifications.Count);
                foreach (SimpleFlowNotification notification in notifications)
                {
                    KeyValuePair<string, NotificationType> pair =
                        new KeyValuePair<string, NotificationType>(_flowDao.GetDataFlowIdByName(notification.FlowCode),
                                                           notification.NotificationType);
                    notificationArray.Add(pair);
                }
            }
            // Do the work
            TransactionTemplate.Execute(delegate
            {
                DeleteAllNotificationsForUser(userId);
                SaveNotificationsForUser(userId, modifiedByUserId, notificationArray);
                return null;
            });
        }
        private void DeleteAllNotificationsForUser(string userId)
        {
            DoSimpleDelete(TABLE_NAME, "AccountId", new object[] { userId });
        }
        private void SaveNotificationsForUser(string userId, string modifiedByUserId,
                                              IList<KeyValuePair<string, NotificationType>> notifications)
        {
            if (CollectionUtils.IsNullOrEmpty(notifications))
            {
                return;
            }
            DateTime now = DateTime.Now;
            object[] insertValues = new object[12];
            DoBulkInsert(TABLE_NAME, "Id;FlowId;AccountId;OnSolicit;OnQuery;OnSubmit;OnNotify;OnSchedule;OnDownload;OnExecute;ModifiedBy;ModifiedOn",
                 delegate(int currentInsertIndex)
                 {
                     if (currentInsertIndex < notifications.Count)
                     {
                         KeyValuePair<string, NotificationType> notification = notifications[currentInsertIndex];
                         NotificationType type = notification.Value;
                         insertValues[0] = IdProvider.Get();
                         insertValues[1] = notification.Key;
                         insertValues[2] = userId;
                         insertValues[3] = DbUtils.ToDbBool((type & NotificationType.OnSolicit) != 0);
                         insertValues[4] = DbUtils.ToDbBool((type & NotificationType.OnQuery) != 0);
                         insertValues[5] = DbUtils.ToDbBool((type & NotificationType.OnSubmit) != 0);
                         insertValues[6] = DbUtils.ToDbBool((type & NotificationType.OnNotify) != 0);
                         insertValues[7] = DbUtils.ToDbBool((type & NotificationType.OnSchedule) != 0);
                         insertValues[8] = DbUtils.ToDbBool((type & NotificationType.OnDownload) != 0);
                         insertValues[9] = DbUtils.ToDbBool((type & NotificationType.OnExecute) != 0);
                         insertValues[10] = modifiedByUserId;
                         insertValues[11] = now;
                         return insertValues;
                     }
                     else
                     {
                         return null;
                     }
                 });
        }
        private static string GetNotificationColumnNameFromType(NotificationType notificationType)
        {
			switch ( notificationType ) {
				case NotificationType.OnSolicit: return "OnSolicit";
				case NotificationType.OnQuery: return "OnQuery";
				case NotificationType.OnSubmit: return "OnSubmit";
				case NotificationType.OnDownload: return "OnDownload";
				case NotificationType.OnNotify: return "OnNotify";
				case NotificationType.OnSchedule: return "OnSchedule";
                case NotificationType.OnExecute: return "OnExecute";
                default: throw new ArgumentException(string.Format("Invalid NotificationType: \"{0}\"",
																   notificationType));
			}
        }
        #endregion

        #region Properties
        public IFlowDao FlowDao
        {
            get { return _flowDao; }
            set { _flowDao = value; }
        }

        #endregion
    }
}
