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
using Windsor.Node2008.WNOSUtility;
using Windsor.Node2008.WNOSConnector.Logic;
using Windsor.Node2008.WNOSConnector.Admin;
using Windsor.Commons.Core;

namespace Windsor.Node2008.WNOS.Logic
{
    public class AccountPolicyManager : LogicAuditBaseManager, IPolicyService
    {
        private IAccountManagerEx _accountManager;
        private IAccountService _accountService;
        private INAASManagerEx _naasManager;

        #region Init

        new public void Init()
        {
			base.Init();

            FieldNotInitializedException.ThrowIfNull(this, ref _accountManager);
            FieldNotInitializedException.ThrowIfNull(this, ref _accountService);
            FieldNotInitializedException.ThrowIfNull(this, ref _naasManager);
        }

        #endregion

        public bool IsDemoNode { get { return _settingsProvider.IsDemoNode; } }
        public IDictionary<string, SimpleListDisplayInfo> GetListInfo(params string[] args)
        {
            ICollection<string> usernames = GetNaasUsernameList(false, false);

            Dictionary<string, SimpleListDisplayInfo> dict = new Dictionary<string, SimpleListDisplayInfo>();

            if (!CollectionUtils.IsNullOrEmpty(usernames))
            {
                foreach (string username in usernames)
                {
                    dict.Add(username, new SimpleListDisplayInfo(username, string.Empty));
                }
            }

            return dict;
        }

        public ICollection<string> GetNaasUsernameList(bool forceFreshFromNaas, bool appendAffiliation)
        {
            return _naasManager.GetAllUsernames(forceFreshFromNaas, appendAffiliation);
        }

        public ICollection<string> GetNaasUsernameList(bool forceFreshFromNaas, bool appendAffiliation, AdminVisit visit)
        {
            ValidateByRole(visit, SystemRoleType.Admin);

            return _naasManager.GetAllUsernames(forceFreshFromNaas, appendAffiliation);
        }

        public NaasUserInfo GetNaasUserInfo(string userName)
        {
            return _naasManager.GetNaasUserInfo(userName);
        }
        public UserAccount Get(string username, AdminVisit visit)
        {
            return _accountManager.Get(username, visit);
        }

        public UserAccount GetOrCreateUser(string username, AdminVisit visit, 
                                           out NaasUserInfo naasUserInfo)
        {
            ValidateByRole(visit, SystemRoleType.Admin);

            bool wasCreated;
            UserAccount userAccount = _accountManager.GetOrCreate(username, true, out wasCreated);

            naasUserInfo = _naasManager.GetNaasUserInfo(username);

            return userAccount;
        }

        public UserAccount Save(UserAccount user, AdminVisit visit)
        {
            return _accountService.Save(user, null, visit);
        }

        public bool IsFlowPermitted(IList<UserAccessPolicy> policies, string flowName)
        {
            if (!CollectionUtils.IsNullOrEmpty(policies))
            {
                bool positivePolicy = false, negativePolicy = false;
                foreach (UserAccessPolicy policy in policies)
                {
                    if ((policy.PolicyType == ServiceRequestAuthorizationType.Flow) &&
                         (string.Equals(policy.TypeQualifier, "*") ||
                          string.Equals(policy.TypeQualifier, flowName, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        if (policy.Allowed)
                        {
                            positivePolicy = true;
                        }
                        else
                        {
                            negativePolicy = true;
                        }
                    }
                }
                return (positivePolicy && !negativePolicy);
            }
            return false;
        }
        public UserAccessPolicy CreatePolicy(string userId, string flowName, bool isAllowed)
        {
            return new UserAccessPolicy(userId, ServiceRequestAuthorizationType.Flow,
                                        flowName, isAllowed);
        }

        #region Properties
        public IAccountManagerEx AccountManager
        {
            get { return _accountManager; }
            set { _accountManager = value; }
        }
        public IAccountService AccountService
        {
            get { return _accountService; }
            set { _accountService = value; }
        }
        public INAASManagerEx NAASManager
        {
            get { return _naasManager; }
            set { _naasManager = value; }
        }
        #endregion
    }
}
