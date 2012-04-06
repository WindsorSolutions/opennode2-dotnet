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
using Windsor.Commons.Core;

namespace Windsor.Node2008.WNOSDomain
{
    /// <summary>
    /// Domain object that contains information about a visitor via the WNOS admin interface.
    /// </summary>
    [Serializable]
    public class NodeVisit : SimpleVisit
    {
        private UserAccount _account;
        private IDictionary<string, string> _flowIdToNameMap;

        public NodeVisit(UserAccount account, string requestedFromIp,
                          IDictionary<string, string> flowIdToNameMap) :
                          base(requestedFromIp)
        {
            ExceptionUtils.ThrowIfNull(account, "account");
            _account = account;
            _flowIdToNameMap = flowIdToNameMap;
        }

        /// <summary>
        /// The user account associated with this admin visitor.
        /// </summary>
        public UserAccount Account
        {
            get { return _account; }
        }
        public bool IsAdmin
        {
            get
            {
                return (Account.Role == SystemRoleType.Admin);
            }
        }

        public IDictionary<string, string> FlowIdToNameMap
        {
            get { return _flowIdToNameMap; }
            set { _flowIdToNameMap = value; }
        }

        public bool CanEditNewFlows()
        {
            return (Account.Role == SystemRoleType.Admin);
        }
        public bool CanEditAnyFlow()
        {
            switch (Account.Role)
            {
                case SystemRoleType.Admin:
                    return true;
                case SystemRoleType.Program:
                    if (!CollectionUtils.IsNullOrEmpty(Account.Policies))
                    {
                        foreach (UserAccessPolicy policy in Account.Policies)
                        {
                            if ((policy.PolicyType == ServiceRequestAuthorizationType.Flow) &&
                                (policy.FlowRoleType == FlowRoleType.Modify))
                            {
                                return true;
                            }
                        }
                    }
                    break;
            }
            return false;
        }
        public string GetFlowNameFromId(string flowId)
        {
            if (FlowIdToNameMap != null)
            {
                string flowName;
                FlowIdToNameMap.TryGetValue(flowId, out flowName);
                return flowName;
            }
            return null;
        }
        public bool IsFlowPermittedByName(string flowName, FlowRoleType flowRole)
        {
            return IsFlowPermitted(flowName, null, flowRole);
        }
        public bool IsFlowPermittedById(string flowId, FlowRoleType flowRole)
        {
            return IsFlowPermitted(null, flowId, flowRole);
        }
        private bool IsFlowPermitted(string flowName, string flowId, FlowRoleType flowRole)
        {
            switch (Account.Role)
            {
                case SystemRoleType.Admin:
                    return true;
                case SystemRoleType.Program:
                    break;  // Do IsFlowPermitted() check below
                case SystemRoleType.Authed:
                    if ((flowRole == FlowRoleType.View) || (flowRole == FlowRoleType.Modify))
                    {
                        return false;
                    }
                    break;  // Do IsFlowPermitted() check below
                default:
                    return false;
            }
            return IsFlowPermitted(Account.Policies, flowName, flowId, flowRole);
        }
        private bool IsFlowPermitted(IList<UserAccessPolicy> policies,
                                     string flowName, string flowId,
                                     FlowRoleType flowRole)
        {
            if ((flowRole != FlowRoleType.None) && !CollectionUtils.IsNullOrEmpty(policies))
            {
                if (string.IsNullOrEmpty(flowName))
                {
                    ExceptionUtils.ThrowIfEmptyString(flowId, "flowId");
                    flowName = GetFlowNameFromId(flowId);
                    if (flowName == null)
                    {
                        return false;
                    }
                }
                foreach (UserAccessPolicy policy in policies)
                {
                    if ((policy.PolicyType == ServiceRequestAuthorizationType.Flow) &&
                         string.Equals(policy.TypeQualifier, flowName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        switch (flowRole)
                        {
                            case FlowRoleType.Endpoint:
                                return ((policy.FlowRoleType == FlowRoleType.Endpoint) ||
                                        (policy.FlowRoleType == FlowRoleType.View) ||
                                        (policy.FlowRoleType == FlowRoleType.Modify));
                            case FlowRoleType.View:
                                return ((policy.FlowRoleType == FlowRoleType.View) ||
                                        (policy.FlowRoleType == FlowRoleType.Modify));
                            case FlowRoleType.Modify:
                                return ((policy.FlowRoleType == FlowRoleType.Modify));
                            default:
                                DebugUtils.CheckDebuggerBreak();
                                return false;
                        }
                    }
                }
            }
            return false;
        }
    }
}
