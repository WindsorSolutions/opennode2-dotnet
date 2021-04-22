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
using Windsor.Node2008.WNOSProviders;

namespace Windsor.Node2008.WNOS.Logic
{
    public class AccountPolicyManager : LogicAuditBaseManager, IPolicyService
    {
        private IAccountManagerEx _accountManager;
        private IAccountService _accountService;
        private INAASManagerEx _naasManager;
        private IFlowManager _flowManager;

        #region Init

        new public void Init()
        {
            base.Init();

            FieldNotInitializedException.ThrowIfNull(this, ref _accountManager);
            FieldNotInitializedException.ThrowIfNull(this, ref _accountService);
            FieldNotInitializedException.ThrowIfNull(this, ref _naasManager);
            FieldNotInitializedException.ThrowIfNull(this, ref _flowManager);
        }

        #endregion

        public IDictionary<string, SimpleListDisplayInfo> GetListInfo(params string[] args)
        {
            //ICollection<string> usernames = GetNaasUsernameList(false, false);

            Dictionary<string, SimpleListDisplayInfo> dict = new Dictionary<string, SimpleListDisplayInfo>();

            //if (!CollectionUtils.IsNullOrEmpty(usernames))
            //{
            //    foreach (string username in usernames)
            //    {
            //        dict.Add(username, new SimpleListDisplayInfo(username, string.Empty));
            //    }
            //}

            return dict;
        }

        //public ICollection<string> GetNaasUsernameList(bool forceFreshFromNaas, bool appendAffiliation)
        //{
        //    return _naasManager.GetAllUsernames(forceFreshFromNaas, appendAffiliation);
        //}

        //public ICollection<string> GetNaasUsernameList(bool forceFreshFromNaas, bool appendAffiliation, NodeVisit visit)
        //{
        //    ValidateByRole(visit, SystemRoleType.Admin);

        //    return _naasManager.GetAllUsernames(forceFreshFromNaas, appendAffiliation);
        //}

        //public ICollection<KeyValuePair<string, string>> GetCachedNaasUsernameList(bool appendAffiliation, NodeVisit visit)
        //{
        //    ValidateByRole(visit, SystemRoleType.Admin);

        //    return _naasManager.GetAllCachedUsernames(appendAffiliation);
        //}

        public NaasUserInfo GetNaasUserInfo(string userName)
        {
            return _naasManager.GetNaasUserInfo(userName);
        }
        public UserAccount Get(string username, NodeVisit visit)
        {
            return _accountManager.Get(username, visit);
        }

        public UserAccount GetOrCreateUser(string username, NodeVisit visit,
                                           out NaasUserInfo naasUserInfo)
        {
            ValidateByRole(visit, SystemRoleType.Admin);

            bool wasCreated;
            UserAccount userAccount = _accountManager.GetOrCreate(username, true, out wasCreated);

            naasUserInfo = _naasManager.GetNaasUserInfo(username);

            return userAccount;
        }

        protected bool IsFlowRoleTypePermittedForUserRole(SystemRoleType userRole, FlowRoleType flowRole)
        {
            switch (userRole)
            {
                case SystemRoleType.Admin:
                    return true;
                case SystemRoleType.Program:
                    return (flowRole == FlowRoleType.Endpoint) || (flowRole == FlowRoleType.View) ||
                           (flowRole == FlowRoleType.Modify);
                case SystemRoleType.Authed:
                    return (flowRole == FlowRoleType.Endpoint);
                default:
                    return false;
            }
        }
        public UserAccessPolicy CreatePolicy(SystemRoleType userRole, string userId,
                                             string flowName, FlowRoleType flowRoleType)
        {
            if ((flowRoleType == FlowRoleType.None) ||
                !IsFlowRoleTypePermittedForUserRole(userRole, flowRoleType))
            {
                throw new ArgumentException(string.Format("Invalid user role (\"{0}\") specified for flow role (\"{0}\")",
                                                          EnumUtils.ToDescription(userRole), EnumUtils.ToDescription(flowRoleType)));
            }
            return new UserAccessPolicy(userId, ServiceRequestAuthorizationType.Flow,
                                        flowName, flowRoleType);
        }
        public IList<UserAccessPolicy> CleanseFlowPoliciesForUser(SystemRoleType userRole, IList<UserAccessPolicy> policies)
        {
            if (CollectionUtils.IsNullOrEmpty(policies))
            {
                return null;
            }
            if (userRole == SystemRoleType.Admin)
            {
                return null;    // Admin is allowed everything
            }
            List<UserAccessPolicy> cleansedPolicies = new List<UserAccessPolicy>(policies.Count);
            IList<string> protectedFlows = _flowManager.GetProtectedFlowNames();
            foreach (UserAccessPolicy policy in policies)
            {
                if (policy.PolicyType != ServiceRequestAuthorizationType.Flow)
                {
                    cleansedPolicies.Add(policy);
                }
                else
                {
                    if (!IsFlowRoleTypePermittedForUserRole(userRole, policy.FlowRoleType))
                    {
                        throw new ArgumentException(string.Format("Invalid user role (\"{0}\") specified for flow role (\"{0}\")",
                                                                  EnumUtils.ToDescription(userRole), EnumUtils.ToDescription(policy.FlowRoleType)));
                    }

                    bool isFlowProtected =
                        (CollectionUtils.IndexOf(protectedFlows, policy.TypeQualifier,
                                                 StringComparison.InvariantCultureIgnoreCase) >= 0);

                    if (userRole == SystemRoleType.Authed)
                    {
                        DebugUtils.AssertDebuggerBreak(policy.FlowRoleType == FlowRoleType.Endpoint);
                        if (isFlowProtected)
                        {
                            cleansedPolicies.Add(policy);
                        }
                        else
                        {
                            // Don't add, must be FlowRoleType.Endpoint and flow is not protected
                        }
                    }
                    else if (userRole == SystemRoleType.Program)
                    {
                        if (isFlowProtected)
                        {
                            cleansedPolicies.Add(policy);
                        }
                        else
                        {
                            if ((policy.FlowRoleType == FlowRoleType.Modify) ||
                                (policy.FlowRoleType == FlowRoleType.View))
                            {
                                // Only add in these cases, not if FlowRoleType == FlowRoleType.Endpoint
                                // since flow is not protected
                                cleansedPolicies.Add(policy);
                            }
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Unrecognized user role specified: \"(0)\"",
                                                    EnumUtils.ToDescription(userRole));
                    }
                }
            }
            return CollectionUtils.IsNullOrEmpty(cleansedPolicies) ? null : cleansedPolicies;
        }

        #region Properties
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
        public IAccountService AccountService
        {
            get
            {
                return _accountService;
            }
            set
            {
                _accountService = value;
            }
        }
        public INAASManagerEx NAASManager
        {
            get
            {
                return _naasManager;
            }
            set
            {
                _naasManager = value;
            }
        }
        public IFlowManager FlowManager
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
    }
}
