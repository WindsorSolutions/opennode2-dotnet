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
using System.Diagnostics;

using Common.Logging;

using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOS.Data;
using Windsor.Node2008.WNOSUtility;
using Windsor.Node2008.WNOSConnector.Logic;
using Windsor.Node2008.WNOSConnector.Admin;
using Windsor.Commons.Core;
using Windsor.Node2008.WNOSPlugin.Security;
using Windsor.Node2008.WNOSProviders;

namespace Windsor.Node2008.WNOS.Logic
{
    public class AccountAuthorizationRequestManager : LogicAuditBaseManager, IAccountAuthorizationRequestManager, 
                                                      IAccountAuthorizationRequestService
    {
        private IAccountAuthorizationRequestDao _accountAuthorizationRequestDao;
        private IAccountManagerEx _accountManager;
        private INAASManagerEx _naasManager;
        private IFlowManagerEx _flowManager;
        private IPolicyService _accountPolicyManager;
        private IAccountDao _accountDao;
        #region Init

        public AccountAuthorizationRequestManager()
        {
        }

        new public void Init()
        {
            base.Init();

            FieldNotInitializedException.ThrowIfNull(this, ref _accountAuthorizationRequestDao);
            FieldNotInitializedException.ThrowIfNull(this, ref _accountManager);
            FieldNotInitializedException.ThrowIfNull(this, ref _naasManager);
            FieldNotInitializedException.ThrowIfNull(this, ref _flowManager);
            FieldNotInitializedException.ThrowIfNull(this, ref _accountPolicyManager);
            FieldNotInitializedException.ThrowIfNull(this, ref _accountDao);
        }

        #endregion

        public void Save(AccountAuthorizationRequest item)
        {
            _accountAuthorizationRequestDao.Save(item);
            // If the user already exists in the node and has all requested permissions,
            // bypass notifying the node admin.
            try
            {
                CheckForAlreadyValidAuthorizationRequest(item);
            }
            catch (Exception)
            {
            }
        }

        public bool HasOpenRequestForUser(string naasUsername)
        {
            return _accountAuthorizationRequestDao.HasOpenRequestForUser(naasUsername);
        }
        public bool ValidateUserExistance(string naasUsername, string affiliatedNode,
                                          IEnumerable<string> requestedFlowNames)
        {
            IDictionary<string, string> upperFlowNameToIdMap = _flowManager.GetAllProtectedUpperDataFlowNamesToIdMap();
            return ValidateUserExistance(naasUsername, affiliatedNode, requestedFlowNames, upperFlowNameToIdMap);
        }
        /// <summary>
        /// Check to see if the input request is already valid (user exists in NAAS and the node and already has access to
        /// the requested flows.  If so, automatically set the request to Accepted, thereby bypassing the need for
        /// the node Admin to formally accept the request.
        /// </summary>
        protected void CheckForAlreadyValidAuthorizationRequest(AccountAuthorizationRequest item)
        {
            UserAccount userAccount = null;
            try
            {
                userAccount = _accountManager.GetByName(item.NaasAccount);
            }
            catch (Exception)
            {
            }
            if ((userAccount != null) && userAccount.IsActive)
            {
                IList<string> protectedFlows = _flowManager.GetProtectedFlowNames();
                bool hasAccessToAllRequestedFlows = true;
                IList<AccountAuthorizationRequestFlow> requestedFlows = null;
                if (!CollectionUtils.IsNullOrEmpty(protectedFlows))
                {
                    if (CollectionUtils.IsNullOrEmpty(item.RequestedFlows))
                    {
                        // If item.RequestedFlows == null, this is a request to grant access to all protected flows
                        requestedFlows = new List<AccountAuthorizationRequestFlow>(protectedFlows.Count);
                        foreach (string flowName in protectedFlows)
                        {
                            requestedFlows.Add(new AccountAuthorizationRequestFlow(flowName));
                        }
                    }
                    else
                    {
                        // Deep copy the list so that we can update element without affecting the "real" request 
                        // until we are sure we will accept the user
                        requestedFlows = new List<AccountAuthorizationRequestFlow>(item.RequestedFlows.Count);
                        foreach (AccountAuthorizationRequestFlow requestedFlow in item.RequestedFlows)
                        {
                            requestedFlows.Add(new AccountAuthorizationRequestFlow(requestedFlow.FlowName));
                        }
                    }
                    // Check that the user has access to all the requested flows:
                    IDictionary<string, string> upperFlowNameToIdMap = _flowManager.GetAllProtectedUpperDataFlowNamesToIdMap();
                    foreach (AccountAuthorizationRequestFlow requestedFlow in requestedFlows)
                    {
                        if (upperFlowNameToIdMap.ContainsKey(requestedFlow.FlowName.ToUpper()))
                        {
                            if (!HasPolicyForFlow(requestedFlow.FlowName, userAccount.Policies))
                            {
                                hasAccessToAllRequestedFlows = false;
                                break;
                            }
                            else
                            {
                                requestedFlow.AccessGranted = true;
                            }
                        }
                    }
                }
                if (hasAccessToAllRequestedFlows)
                {
                    // Validate that the user is actually in NAAS
                    if (_naasManager.UserExists(userAccount.NaasAccount))
                    {
                        // Accept this user automatically
                        item.RequestedFlows = requestedFlows;
                        item.Response = new AccountAuthorizationResponse();
                        item.Response.AuthorizationAccountId = _accountManager.AdminAccount.Id;
                        item.Response.AuthorizationComments = "The node admin automatically accepted the request since all requested policies are currently active";
                        item.Response.DidCreateInNaas = false;
                        _accountAuthorizationRequestDao.DoRequestUpdate(item, _accountManager.AdminAccount.NaasAccount, true);

                        string statusDetail = string.Format("Automatically accepted authorization request from user \"{0} ({1})\" since all requested policies are currently active: {2}",
                                                            item.FullName, item.NaasAccount, item.ToString());
                        ActivityManager.LogAudit(NodeMethod.None, null, item.TransactionId, null, statusDetail);
                    }
                }
            }
        }
        protected bool ValidateUserExistance(string naasUsername, string affiliatedNode, 
                                             IEnumerable<string> requestedFlowNames,
                                             IDictionary<string, string> upperFlowNameToIdMap)
        {
            string affiliate;
            bool canDelete;
            bool userExists = _naasManager.UserExists(naasUsername, out affiliate, out canDelete);
            if (userExists)
            {
                if (!string.Equals(affiliatedNode, affiliate, StringComparison.InvariantCultureIgnoreCase))
                {
                    throw new ArgumentException(string.Format("The requested user's ({0}) node affiliation of \"{1}\" and the user's node affiliation returned from NAAS \"{2}\" do not match",
                                                              naasUsername, affiliatedNode, affiliate));
                }
            }
            else
            {
                string nodeId = _naasManager.NodeId;
                if (!string.Equals(affiliatedNode, nodeId, StringComparison.InvariantCultureIgnoreCase))
                {
                    throw new UnauthorizedAccessException(string.Format("The requested user ({0}) has a node affiliation of \"{1}\" and does not currently exist in NAAS, but this node's affiliation is \"{2}\".  The user cannot be created in NAAS by this node",
                                                                        naasUsername, affiliatedNode, nodeId));
                }
            }
            if (CollectionUtils.IsNullOrEmpty(upperFlowNameToIdMap))
            {
                throw new ArgumentException("This node does not publish any protected flows");
            }
            if (!CollectionUtils.IsNullOrEmpty(requestedFlowNames)) 
            {
                bool foundMatchingFlow = false;
                foreach (string requestedFlowName in requestedFlowNames)
                {
                    foundMatchingFlow = upperFlowNameToIdMap.ContainsKey(requestedFlowName.ToUpper());
                    if ( foundMatchingFlow )
                    {
                        break;
                    }
                }
                if ( !foundMatchingFlow )
                {
                    throw new ArgumentException("The node does not contain any protected flows to which the user is requesting access");
                }
            }
            return userExists;
        }
        protected UserAccessPolicy GetPolicyForFlow(string flowName, IList<UserAccessPolicy> policies)
        {
            if (!CollectionUtils.IsNullOrEmpty(policies))
            {
                foreach (UserAccessPolicy curPolicy in policies)
                {
                    if ((curPolicy.PolicyType == ServiceRequestAuthorizationType.Flow) &&
                         string.Equals(curPolicy.TypeQualifier, flowName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        return curPolicy;
                    }
                }
            }
            return null;
        }
        protected bool HasPolicyForFlow(string flowName, IList<UserAccessPolicy> policies)
        {
            return (GetPolicyForFlow(flowName, policies) != null);
        }

        public IList<AccountAuthorizationRequest> GetOpenUserRequests(AdminVisit visit)
        {
            ValidateByRole(visit, SystemRoleType.Program);

            return _accountAuthorizationRequestDao.GetOpenUserRequests();
        }

        public IList<string> GetProtectedFlowNamesForUser(AdminVisit visit, string username)
        {
            ValidateByRole(visit, SystemRoleType.Program);

            return _accountAuthorizationRequestDao.GetProtectedFlowNamesForUser(username);
        }

        public AccountAuthorizationRequest AcceptRequest(AccountAuthorizationRequest request, AdminVisit visit)
        {
            ValidateByRole(visit, SystemRoleType.Admin);

            ExceptionUtils.ThrowIfNull(request.Response, "request.Response");

            IDictionary<string, string> upperFlowNameToIdMap = _flowManager.GetAllProtectedUpperDataFlowNamesToIdMap();

            bool userExists = ValidateUserExistance(request.NaasAccount, request.AffiliatedNodeId,
                                                    null, upperFlowNameToIdMap);

            string password = _accountManager.GenerateRandomPassword();
            UserAccount userAccount = _accountDao.GetByName(request.NaasAccount);

            List<UserAccessPolicy> policies = null;
            if (userAccount == null)
            {
                userAccount = new UserAccount();
                userAccount.ModifiedById = visit.Account.Id;
                userAccount.NaasAccount = request.NaasAccount;
                userAccount.Role = SystemRoleType.Authed;
            }
            else
            {
                if (!CollectionUtils.IsNullOrEmpty(userAccount.Policies))
                {
                    policies = new List<UserAccessPolicy>(userAccount.Policies);
                }
            }
            userAccount.IsActive = true;
            if (!CollectionUtils.IsNullOrEmpty(request.RequestedFlows))
            {
                foreach (AccountAuthorizationRequestFlow requestedFlow in request.RequestedFlows)
                {
                    UserAccessPolicy curPolicy = GetPolicyForFlow(requestedFlow.FlowName, policies);
                    bool foundFlow = (curPolicy != null);
                    if (foundFlow && !requestedFlow.AccessGranted)
                    {
                        policies.Remove(curPolicy);
                    }
                    else if (!foundFlow && requestedFlow.AccessGranted)
                    {
                        UserAccessPolicy policy = _accountPolicyManager.CreatePolicy(null, requestedFlow.FlowName, true);
                        policy.ModifiedById = visit.Account.Id;
                        CollectionUtils.Add(policy, ref policies);
                    }
                }
                userAccount.Policies = policies;
            }
 
            _accountManager.Save(userAccount, password, visit);

            request.Response.AuthorizationAccountId = visit.Account.Id;
            request.Response.DidCreateInNaas = !userExists;
            _accountAuthorizationRequestDao.DoRequestUpdate(request, visit.Account.NaasAccount, true);

            string statusDetail = string.Format("{0} accepted authorization request from user \"{1} ({2})\": {3}",
                                                visit.Account.NaasAccount, request.FullName, request.NaasAccount,
                                                request.ToString());
            ActivityManager.LogAudit(NodeMethod.None, null, request.TransactionId, visit, statusDetail);
            return request;
        }
        public AccountAuthorizationRequest RejectRequest(AccountAuthorizationRequest request, AdminVisit visit)
        {
            ValidateByRole(visit, SystemRoleType.Admin);

            ExceptionUtils.ThrowIfNull(request.Response, "request.Response");

            if (!CollectionUtils.IsNullOrEmpty(request.RequestedFlows))
            {
                foreach (AccountAuthorizationRequestFlow flow in request.RequestedFlows)
                {
                    flow.AccessGranted = false;
                }
            }

            request.Response.AuthorizationAccountId = visit.Account.Id;
            request.Response.DidCreateInNaas = false;
            _accountAuthorizationRequestDao.DoRequestUpdate(request, visit.Account.NaasAccount, false);

            string statusDetail = string.Format("{0} rejected authorization request from user \"{1} ({2})\": {3}",
                                                visit.Account.NaasAccount, request.FullName, request.NaasAccount,
                                                request.ToString());
            ActivityManager.LogAudit(NodeMethod.None, null, request.TransactionId, visit, statusDetail);

            return request;
        }

        #region Properties
        public IAccountAuthorizationRequestDao AccountAuthorizationRequestDao
        {
            get { return _accountAuthorizationRequestDao; }
            set { _accountAuthorizationRequestDao = value; }
        }
        public IAccountManagerEx AccountManager
        {
            get { return _accountManager; }
            set { _accountManager = value; }
        }

        public INAASManagerEx NAASManager
        {
            get { return _naasManager; }
            set { _naasManager = value; }
        }

        public IFlowManagerEx FlowManager
        {
            get { return _flowManager; }
            set { _flowManager = value; }
        }
        public IPolicyService AccountPolicyManager
        {
            get { return _accountPolicyManager; }
            set { _accountPolicyManager = value; }
        }
        public IAccountDao AccountDao
        {
            get { return _accountDao; }
            set { _accountDao = value; }
        }
        #endregion
    }
}
