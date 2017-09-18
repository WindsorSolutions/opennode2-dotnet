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
using System.Reflection;

using Common.Logging;

using Windsor.Node2008.WNOS.Data;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOS.Logic;
using Windsor.Node2008.WNOSUtility;
using Windsor.Node2008.WNOSConnector.Logic;
using Windsor.Node2008.WNOSConnector.Admin;
using Windsor.Commons.Core;

using Windsor.Drawing.Chart;
using System.Drawing;
using System.IO;

namespace Windsor.Node2008.WNOS.Logic
{
    public class ActivityManager : LogicAuditBaseManager, IActivityManager, IActivityService, IImageSourceService
    {

        private IActivityDao _activityDao;
        private IAccountDao _accountDao;
        private IFlowDao _flowDao;
        private ITransactionDao _transactionDao;
        private IAccountManagerEx _accountManager;
        private const string DELETED_USERNAME_SUFFIX = " (Deleted)";

        #region Init

        new public void Init()
        {
            base.Init();

            FieldNotInitializedException.ThrowIfNull(this, ref _activityDao);
            FieldNotInitializedException.ThrowIfNull(this, ref _accountDao);
            FieldNotInitializedException.ThrowIfNull(this, ref _accountManager);
            FieldNotInitializedException.ThrowIfNull(this, ref _flowDao);
            FieldNotInitializedException.ThrowIfNull(this, ref _transactionDao);
        }

        #endregion

        public string Log(Activity activity)
        {
            try
            {
                if (string.IsNullOrEmpty(activity.ModifiedById))
                {
                    activity.ModifiedById = _accountManager.AdminAccount.Id;
                }
                _activityDao.Log(activity);
            }
            catch (Exception e)
            {
                LOG.Error("Error in ActivityManager.Log().", e);
                return string.Empty;
            }
            return activity.Id;
        }

        public int DeleteActivities(ActivitySearchParams search, NodeVisit visit)
        {
            LogicAuditBaseManager.ValidateByRole(visit, SystemRoleType.Admin);

            bool addFlowIsNullQuery;
            if (!FilterSearchParamsForVisit(search, visit, out addFlowIsNullQuery))
            {
                return 0;
            }

            return _activityDao.DeleteActivities(search, addFlowIsNullQuery);
        }
        protected bool FilterSearchParamsForVisit(ActivitySearchParams search, NodeVisit visit,
                                                  out bool addFlowIsNullQuery)
        {
            if (visit.IsAdmin)
            {
                addFlowIsNullQuery = false;
            }
            else
            {
                IList<string> flowNames = null;
                if (CollectionUtils.IsNullOrEmpty(search.FlowNames))
                {
                    addFlowIsNullQuery = true;
                    flowNames = GetAllFlowNames(visit);
                    if (CollectionUtils.IsNullOrEmpty(flowNames))
                    {
                        flowNames = new List<string>(1);
                        flowNames.Add("____BOGUS____FLOW____NAME____");
                    }
                }
                else
                {
                    addFlowIsNullQuery = false;
                    flowNames = new List<string>();
                    foreach (string flowName in search.FlowNames)
                    {
                        if (visit.IsFlowPermittedByName(flowName, FlowRoleType.View))
                        {
                            flowNames.Add(flowName);
                        }
                    }
                    if (flowNames.Count == 0)
                    {
                        // Flows were specified to search on, but none of the flows are allowed for the user,
                        // so return no results
                        return false;
                    }
                }
                search.FlowNames = flowNames;
            }
            return true;
        }

        public Activity GetActivityEntries(Activity activity, NodeVisit visit)
        {
            LogicAuditBaseManager.ValidateByRole(visit, SystemRoleType.Program);

            activity.Entries = _activityDao.GetActivityEntries(activity.Id);

            return activity;
        }

        public SortableCollection<Activity> Search(ActivitySearchParams search,
                                                   NodeVisit visit,
                                                   bool includeActivityEntries)
        {
            LogicAuditBaseManager.ValidateByRole(visit, SystemRoleType.Program);

            bool addFlowIsNullQuery;
            if (!FilterSearchParamsForVisit(search, visit, out addFlowIsNullQuery))
            {
                return null;
            }

            return _activityDao.Search(search, addFlowIsNullQuery, includeActivityEntries);
        }

        public IList<Activity> GetRecentActivities(int maxNumToReturn, bool returnUsernames,
                                                   NodeVisit visit)
        {
            LogicAuditBaseManager.ValidateByRole(visit, SystemRoleType.Program);

            ActivitySearchParams search = new ActivitySearchParams();

            bool addFlowIsNullQuery;
            if (!FilterSearchParamsForVisit(search, visit, out addFlowIsNullQuery))
            {
                return null;
            }

            IList<Activity> activities =
                _activityDao.GetRecentActivities(search, addFlowIsNullQuery,
                                                 maxNumToReturn, returnUsernames);

            return activities;
        }

        public ICollection<string> GetDistinctFromIpList()
        {
            return _activityDao.GetDistinctFromIpList();
        }
        public IList<string> GetAllFlowNames(NodeVisit visit)
        {
            IList<string> flowNames = _flowDao.GetAllDataFlowNames();
            return FilterFlowsForUser(visit, flowNames);
        }
        public ICollection<string> GetAllOperationNames(NodeVisit visit)
        {
            return _activityDao.GetAllOperationNames(visit);
        }
        public ICollection<string> GetAllWebMethodNames(NodeVisit visit)
        {
            return _activityDao.GetAllWebMethodNames(visit);
        }
        public ICollection<string> GetAllUserNames()
        {
            return _accountDao.GetAllUserNames();
        }
        public IDictionary<string, string> GetUserIdToNameMap()
        {
            return _accountDao.GetUserIdToNameMap(true, DELETED_USERNAME_SUFFIX);
        }
        public string GetTransactionIdFromActivityId(string activityId)
        {
            return _activityDao.GetTransactionIdFromActivityId(activityId);
        }

        public string LogAudit(NodeMethod method, string flowName, string operation, string transactionId,
                               NodeVisit visit, string messageFormat, params object[] args)
        {
            Activity activity = new Activity(method, flowName, operation, ActivityType.Audit, transactionId,
                                            (visit == null) ? string.Empty : visit.IP, messageFormat, args);
            activity.ModifiedById = (visit == null) ? AccountManager.AdminAccount.Id : visit.Account.Id;
            return Log(activity);
        }
        public string LogAudit(NodeMethod method, string flowName, NodeVisit visit, string messageFormat, params object[] args)
        {
            return LogAudit(method, flowName, null, null, visit, messageFormat, args);
        }
        public string LogAudit(NodeMethod method, string flowName, string transactionId, NodeVisit visit,
                               string messageFormat, params object[] args)
        {
            return LogAudit(method, flowName, null, transactionId, visit, messageFormat, args);
        }
        public string LogError(NodeMethod method, string flowName, string operation, ActivityType type, Exception exception,
                               NodeVisit visit, string messageFormat, params object[] args)
        {
            Activity activity = new Activity(method, flowName, operation, type, null, (visit == null) ? string.Empty : visit.IP,
                                             messageFormat, args);

            activity.ModifiedById = (visit == null) ? AccountManager.AdminAccount.Id : visit.Account.Id;
            activity.AppendFormat("EXCEPTION: {0}", ExceptionUtils.GetDeepExceptionMessage(exception));
            return Log(activity);
        }
        public string LogError(NodeMethod method, string flowName, ActivityType type, Exception exception,
                               NodeVisit visit, string messageFormat, params object[] args)
        {
            return LogError(method, flowName, null, type, exception, visit, messageFormat, args);
        }
        public string LogError(NodeMethod method, string flowName, string operation, Exception exception, NodeVisit visit,
                               string messageFormat, params object[] args)
        {
            return LogError(method, flowName, operation, ActivityType.None, exception, visit, messageFormat, args);
        }
        public string LogError(NodeMethod method, string flowName, Exception exception, NodeVisit visit, string messageFormat,
                               params object[] args)
        {
            return LogError(method, flowName, ActivityType.Error, exception, visit, messageFormat, args);
        }
        public string LogInfo(NodeMethod method, string flowName, NodeVisit visit, string messageFormat, params object[] args)
        {
            return LogMessage(method, flowName, ActivityType.Info, visit, messageFormat, args);
        }
        private string LogMessage(NodeMethod method, string flowName, ActivityType type, NodeVisit visit, string messageFormat,
                                params object[] args)
        {
            Activity activity = new Activity(method, flowName, null, type, null, (visit == null) ? string.Empty : visit.IP,
                                             messageFormat, args);
            activity.ModifiedById = (visit == null) ? AccountManager.AdminAccount.Id : visit.Account.Id;
            return Log(activity);
        }
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


        #region IImageSourceService Members

        public byte[] GetImage(Size size)
        {
            //TODO: Externalize the count
            Dictionary<string, string> data = _accountDao.GetMostActiveUsers(5);


            List<string> dataArray = new List<string>();
            List<string> labelArray = new List<string>();

            dataArray.AddRange(data.Values);
            labelArray.AddRange(data.Keys);

            BarGraph c = new BarGraph(Color.White);

            c.VerticalTickCount = 2;
            c.ShowLegend = false;
            c.ShowData = false;
            c.Height = size.Height;
            c.Width = size.Width;
            c.TopBuffer = 10;
            c.BottomBuffer = 20;
            c.FontColor = Color.Black;
            c.CollectDataPoints(labelArray.ToArray(), dataArray.ToArray());

            Bitmap image = c.Draw();
            //TODO: Externalize the temp filepath or do it in memory
            string tempFileName = Path.GetTempFileName();
            image.Save(tempFileName);

            return File.ReadAllBytes(tempFileName);
        }

        #endregion
    }
}
