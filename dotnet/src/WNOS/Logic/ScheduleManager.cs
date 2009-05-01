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

using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOS.Data;
using Windsor.Node2008.WNOS.Logic;
using Windsor.Node2008.WNOSUtility;
using Windsor.Node2008.WNOSConnector.Provider;
using Windsor.Node2008.WNOSConnector.Logic;
using Windsor.Node2008.WNOSPlugin;
using Windsor.Node2008.WNOSConnector.Admin;
using Windsor.Node2008.WNOSProviders;
using Windsor.Commons.Core;

namespace Windsor.Node2008.WNOS.Logic
{
    public class ScheduleManager : LogicAuditBaseManager, IScheduleManager, IScheduleService
    {
        private IScheduleDao _scheduleDao;
        private IFlowManagerEx _flowManager;
        private IServiceManager _serviceManager;
        private IPartnerManager _partnerManager;
        private IAccountManagerEx _accountManager;
        private ISchematronHelper _schematronHelper;

        #region Init

        new public void Init()
        {
			base.Init();
			
			FieldNotInitializedException.ThrowIfNull(this, ref _scheduleDao);
            FieldNotInitializedException.ThrowIfNull(this, ref _flowManager);
            FieldNotInitializedException.ThrowIfNull(this, ref _serviceManager);
            FieldNotInitializedException.ThrowIfNull(this, ref _partnerManager);
            FieldNotInitializedException.ThrowIfNull(this, ref _accountManager);
            FieldNotInitializedException.ThrowIfNull(this, ref _schematronHelper);
        }

        #endregion
        
        /// <summary>
        /// Returns a list of Schedule ids that are ready to be processed
        /// </summary>
        public IList<string> GetNextScheduledItemsToProcess() {
			return ScheduleDao.GetNextScheduledItemsToProcess();
        }
        /// <summary>
        /// Returns the scheduled item, or null if not found.
        /// </summary>
        public ScheduledItem GetScheduledItem(string inScheduledItemId) {
			return ScheduleDao.GetScheduledItem(inScheduledItemId);
        }
        public ScheduledItem GetScheduledItem(string inScheduledItemId, out bool isRunNow)
        {
            return ScheduleDao.GetScheduledItem(inScheduledItemId, out isRunNow);
        }

        /// <summary>
        /// Update the scheduled item.
        /// </summary>
        public ScheduledItem Update(ScheduledItem scheduledItem)
        {
            ScheduleDao.Save(scheduledItem);
            return scheduledItem;
        }

        public ScheduledItem Update(ScheduledItem scheduledItem, bool isRunNow)
        {
            ScheduleDao.Save(scheduledItem, isRunNow);
            return scheduledItem;
        }
        public void UpdateScheduleStatus(string scheduleId, ScheduleExecuteStatus status)
        {
            ScheduleDao.UpdateScheduleStatus(scheduleId, status);
        }

        #region IScheduleService
        public IDictionary<string, SimpleListDisplayInfo> GetListInfo(params string[] args)
        {
            Dictionary<string, SimpleListDisplayInfo> dict =
                new Dictionary<string, SimpleListDisplayInfo>();

            IList<ScheduledItem> scheduledItems = _scheduleDao.Get();
            if (!CollectionUtils.IsNullOrEmpty(scheduledItems))
            {
                foreach (ScheduledItem item in scheduledItems)
                {
                    string name = item.Name;
                    if (!item.IsActive)
                    {
                        name += " [Inactive]";
                    }
                    string description = string.Format("Last Executed: {0}, Next Run: {1}", 
                                                       GetDateTimeString(item.LastExecutedOn), 
                                                       GetDateTimeString(item.NextRunOn));
                    dict.Add(item.Id, new SimpleListDisplayInfo(name, description, item));
                }
            }

            return dict;
        }
        private string GetDateTimeString(DateTime date)
        {
            if ((date == DateTime.MinValue) || (date > DateTime.Now.AddYears(100)))
            {
                return "Never";
            }
            else
            {
                return date.ToString();
            }
        }

        public ScheduledItem Save(ScheduledItem instance, AdminVisit visit)
        {
            ValidateByRole(visit, SystemRoleType.Program);

            if ((instance == null))
            {
                throw new ArgumentException("Input values are null.");
            }

            instance.ModifiedById = visit.Account.Id;
            string flowName = _flowManager.GetDataFlowNameById(instance.FlowId);
            TransactionTemplate.Execute(delegate
            {
                _scheduleDao.Save(instance);
                ActivityManager.LogAudit(NodeMethod.None, flowName, visit, "{0} saved scheduled item: {1}.",
                                         visit.Account.NaasAccount, instance.ToString());
                return null;
            });
            return instance;
        }
        public ScheduledItem Get(string scheduleId, AdminVisit visit,
                                 out string modifierUsername)
        {
            ValidateByRole(visit, SystemRoleType.Program);
            ScheduledItem item = _scheduleDao.GetScheduledItem(scheduleId);
            UserAccount modifierAcount = _accountManager.GetById(item.ModifiedById);
            modifierUsername = modifierAcount.NaasAccount;
            return item;
        }

        public IList<ScheduledItem> Get(AdminVisit visit)
        {
            ValidateByRole(visit, SystemRoleType.Program);
            return _scheduleDao.Get();
        }

        public IDictionary<string, string> GetExchangeList()
        {
            return _flowManager.GetAllFlowDisplayNames();
        }
        public IDictionary<string, string> GetDataServiceDisplayList(AdminVisit visit)
        {
            return _serviceManager.GetDataServiceDisplayList(ServiceType.QueryOrSolicitOrExecuteOrTask,
                                                             visit);
        }
        public IList<string> GetValidFlowCodes()
        {
            return _schematronHelper.GetValidFlowCodes();
        }
        public IDictionary<string, string> GetPartnerList()
        {
            return _partnerManager.GetAllPartnerNames();
        }
        public void Delete(ScheduledItem instance, AdminVisit visit)
        {
            ValidateByRole(visit, SystemRoleType.Program);
            string flowName = _flowManager.GetDataFlowNameById(instance.FlowId);
            TransactionTemplate.Execute(delegate
            {
                _scheduleDao.Delete(instance.Id);
                ActivityManager.LogAudit(NodeMethod.None, flowName, visit, "{0} deleted scheduled item: {1}.",
                                         visit.Account.NaasAccount, instance.ToString());
                return null;
            });
        }
        public ScheduledItem SaveAndRunNow(ScheduledItem instance, AdminVisit visit)
        {
            ValidateByRole(visit, SystemRoleType.Program);

            if ((instance == null))
            {
                throw new ArgumentException("Input values are null.");
            }

            instance.ModifiedById = visit.Account.Id;
            string flowName = _flowManager.GetDataFlowNameById(instance.FlowId);
            TransactionTemplate.Execute(delegate
            {
                _scheduleDao.SaveAndRunNow(instance);
                ActivityManager.LogAudit(NodeMethod.None, flowName, visit, "{0} saved and ran scheduled item: {1}.",
                                         visit.Account.NaasAccount, instance.ToString());
                return null;
            });
            return instance;
        }
        public string GetFlowIdFromDataServiceId(string serviceId, AdminVisit visit)
        {
            return _serviceManager.GetFlowIdFromDataServiceId(serviceId, visit);
        }
        #endregion // IScheduleService

        #region Properties
        public IScheduleDao ScheduleDao
        {
			get {
				return _scheduleDao;
			}
			set {
				_scheduleDao = value;
			}
		}
        public IFlowManagerEx FlowManager
        {
            get
            {
                return _flowManager;
            }
            set
            {
                _flowManager = value;
            }
        }
        #endregion
        public IServiceManager ServiceManager
        {
            get
            {
                return _serviceManager;
            }
            set
            {
                _serviceManager = value;
            }
        }
        public IPartnerManager PartnerManager
        {
            get
            {
                return _partnerManager;
            }
            set
            {
                _partnerManager = value;
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
        public ISchematronHelper SchematronHelper
        {
            get { return _schematronHelper; }
            set { _schematronHelper = value; }
        }

    }
}
