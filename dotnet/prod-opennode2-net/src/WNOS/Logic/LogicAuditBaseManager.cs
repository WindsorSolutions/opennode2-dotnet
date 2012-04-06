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
using Spring.Transaction.Support;

using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOS.Data;
using Windsor.Node2008.WNOSUtility;
using Windsor.Node2008.WNOSConnector.Logic;
using Windsor.Node2008.WNOSProviders;
using Windsor.Commons.Core;
using Windsor.Commons.Logging;
using Windsor.Node2008.WNOSConnector.Admin;

namespace Windsor.Node2008.WNOS.Logic
{
    /// <summary>
    /// Base business logic manager that includes auditing and validation-by-user-role capabilities.
    /// </summary>
    public class LogicAuditBaseManager : LogicBaseManager
    {
        protected IActivityManager _activityManager;
        protected ISettingsProvider _settingsProvider;
        protected IPolicyService _accountPolicyManager;
        protected const string InsuficientPrivilegesMessage = "The current user does not have sufficient permissions to perform this operation.";

        #region Init

        /// <summary>
        /// IoC initializer.
        /// </summary>
        new public void Init()
        {
            base.Init();
            FieldNotInitializedException.ThrowIfNull(this, ref _activityManager);
            FieldNotInitializedException.ThrowIfNull(this, ref _settingsProvider);
            FieldNotInitializedException.ThrowIfNull(this, ref _accountPolicyManager);
        }

        #endregion

        public static void ValidateCanEditFlowByName(NodeVisit visit, string flowName)
        {
            if (!visit.IsFlowPermittedByName(flowName, FlowRoleType.Modify))
            {
                ThrowInsuficientPrivileges();
            }
        }
        public static void ValidateCanEditFlowById(NodeVisit visit, string flowId)
        {
            if (!visit.IsFlowPermittedById(flowId, FlowRoleType.Modify))
            {
                ThrowInsuficientPrivileges();
            }
        }
        public static void ValidateCanViewFlowByName(NodeVisit visit, string flowName)
        {
            if (!visit.IsFlowPermittedByName(flowName, FlowRoleType.View))
            {
                ThrowInsuficientPrivileges();
            }
        }
        public static void ValidateCanViewFlowById(NodeVisit visit, string flowId)
        {
            if (!visit.IsFlowPermittedById(flowId, FlowRoleType.View))
            {
                ThrowInsuficientPrivileges();
            }
        }

        /// <summary>
        /// Validate that the input admin visitor has at least minimumRole permissions.  Throw an 
        /// UnauthorizedAccessException() if visitor is not validated.
        /// </summary>
        public static void ValidateByRole(NodeVisit visit, SystemRoleType minimumRole)
        {
            ValidateByRole(visit, minimumRole, false);
        }
 
        /// <summary>
        /// Validate that the input admin visitor has at least minimumRole permissions AND is not
        /// a demo visitor.  Throw an UnauthorizedAccessException() if visitor is not validated.
        /// </summary>
        public static void ValidateByRoleAndNotDemoAccount(NodeVisit visit, SystemRoleType minimumRole)
        {
            ValidateByRole(visit, minimumRole, true);
        }

        public static void ThrowInsuficientPrivileges()
        {
            throw new UnauthorizedAccessException(InsuficientPrivilegesMessage);
        }

        /// <summary>
        /// Internal validation method.  Throw an UnauthorizedAccessException() if visitor is not validated.
        /// </summary>
        private static void ValidateByRole(NodeVisit visit, SystemRoleType minimumRole, bool doValidateNotDemoAccount)
        {

            if (visit == null)
            {
                throw new ArgumentException("Input visit is null.");
            }

            if ((visit.Account == null) || string.IsNullOrEmpty(visit.Account.Id) ||
                ((visit.Account.Role != SystemRoleType.Admin) && ((Int32)visit.Account.Role) < ((Int32)minimumRole)))
            {
                ThrowInsuficientPrivileges();
            }

            if (doValidateNotDemoAccount && (visit.Account.IsDemoUser != null) && visit.Account.IsDemoUser.Value)
            {
                throw new UnauthorizedAccessException("The current demo user does not have sufficient permissions to perform this operation.");
            }
        }
        protected bool CanUserViewFlowByName(NodeVisit visit, string flowName)
        {
            return CanUserAccessFlowByName(visit, flowName, false);
        }
        protected bool CanUserEditFlowByName(NodeVisit visit, string flowName)
        {
            return CanUserAccessFlowByName(visit, flowName, true);
        }
        protected bool CanUserAccessFlowByName(NodeVisit visit, string flowName, bool checkCanEdit)
        {
            return visit.IsFlowPermittedByName(flowName, checkCanEdit ? 
                                               FlowRoleType.Modify : FlowRoleType.View);
        }
        protected bool CanUserViewFlowById(NodeVisit visit, string flowId)
        {
            return CanUserAccessFlowById(visit, flowId, false);
        }
        protected bool CanUserEditFlowById(NodeVisit visit, string flowId)
        {
            return CanUserAccessFlowById(visit, flowId, true);
        }
        protected bool CanUserAccessFlowById(NodeVisit visit, string flowId, bool checkCanEdit)
        {
            return visit.IsFlowPermittedById(flowId, checkCanEdit ?
                                             FlowRoleType.Modify : FlowRoleType.View);
        }

        protected IList<DataFlow> FilterFlowsForUser(NodeVisit visit, IList<DataFlow> flows)
        {
            if (!CollectionUtils.IsNullOrEmpty(flows))
            {
                for (int i = flows.Count - 1; i >= 0; --i)
                {
                    DataFlow dataFlow = flows[i];
                    if (!CanUserViewFlowByName(visit, dataFlow.FlowName))
                    {
                        flows.RemoveAt(i);
                    }
                }
            }
            return flows;
        }
        protected IList<string> FilterFlowsForUser(NodeVisit visit, IList<string> flowNames)
        {
            if (!CollectionUtils.IsNullOrEmpty(flowNames))
            {
                for (int i = flowNames.Count - 1; i >= 0; --i)
                {
                    string flowName = flowNames[i];
                    if (!CanUserViewFlowByName(visit, flowName))
                    {
                        flowNames.RemoveAt(i);
                    }
                }
            }
            return flowNames;
        }
        protected IList<SimpleFlowNotification> 
            FilterFlowsForUser(NodeVisit visit, IList<SimpleFlowNotification> flowNotifications)
        {
            if (!CollectionUtils.IsNullOrEmpty(flowNotifications))
            {
                for (int i = flowNotifications.Count - 1; i >= 0; --i)
                {
                    SimpleFlowNotification notification = flowNotifications[i];
                    if (!CanUserViewFlowByName(visit, notification.FlowCode))
                    {
                        flowNotifications.RemoveAt(i);
                    }
                }
            }
            return flowNotifications;
        }
        protected Dictionary<string, SimpleListDisplayInfo>
            FilterFlowsForUser(NodeVisit visit, Dictionary<string, SimpleListDisplayInfo> flowNameMap)
        {
            if (!CollectionUtils.IsNullOrEmpty(flowNameMap))
            {
                List<string> removeKeys = null;
                foreach (string key in flowNameMap.Keys)
                {
                    if (!CanUserViewFlowByName(visit, key))
                    {
                        CollectionUtils.Add(key, ref removeKeys);
                    }
                }
                CollectionUtils.RemoveKeys(flowNameMap, removeKeys);
            }
            return flowNameMap;
        }
        protected IList<ScheduledItem> FilterSchedulesForUser(NodeVisit visit, IList<ScheduledItem> schedules)
        {
            if (!CollectionUtils.IsNullOrEmpty(schedules))
            {
                for (int i = schedules.Count - 1; i >= 0; --i)
                {
                    ScheduledItem schedule = schedules[i];
                    if (!CanUserViewFlowById(visit, schedule.FlowId))
                    {
                        schedules.RemoveAt(i);
                    }
                }
            }
            return schedules;
        }
        protected IList<ScheduledItemExecuteStatus> FilterSchedulesForUser(NodeVisit visit, IList<ScheduledItemExecuteStatus> schedules)
        {
            if (!CollectionUtils.IsNullOrEmpty(schedules))
            {
                for (int i = schedules.Count - 1; i >= 0; --i)
                {
                    ScheduledItemExecuteStatus schedule = schedules[i];
                    if (!CanUserViewFlowById(visit, schedule.FlowId))
                    {
                        schedules.RemoveAt(i);
                    }
                }
            }
            return schedules;
        }

        #region Properties
        /// <summary>
        /// Activity manager is used for activity audit logging.
        /// </summary>
        public IActivityManager ActivityManager
        {
            get { return _activityManager; }
            set { _activityManager = value; }
        }

        /// <summary>
        /// Settings provider allows access to application settings.
        /// </summary>
        public ISettingsProvider SettingsProvider
        {
            get { return _settingsProvider; }
            set { _settingsProvider = value; }
        }
        protected IPolicyService AccountPolicyManager
        {
            get { return _accountPolicyManager; }
            set { _accountPolicyManager = value; }
        }

        #endregion
    }
}
