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

namespace Windsor.Node2008.WNOSDomain
{
    [Serializable]
    public class FlowNameAndRole
    {
        public FlowNameAndRole() { }
        public FlowNameAndRole(string flowName, FlowRoleType flowRole)
        {
            FlowName = flowName;
            FlowRole = flowRole;
        }
        public FlowRoleType FlowRole { get; set; }
        public string FlowName  { get; set; }
        public override string ToString()
        {
            return FlowName + " - " + FlowRole.ToString();
        }
    }

    [Serializable]
    public class UserAccessPolicy : AuditableIdentity
    {
        private string _accountId;
        private ServiceRequestAuthorizationType _policyType;
        private string _typeQualifier; //Null, Primitive Method Name, Flow Name, Service Name
        private FlowRoleType _flowRoleType;

        public UserAccessPolicy(string userAccountId, ServiceRequestAuthorizationType type,
                                string qualifier, FlowRoleType flowRoleType)
        {
            _accountId = userAccountId;
            _policyType = type;
            _typeQualifier = qualifier;
            _flowRoleType = flowRoleType;
        }
        public UserAccessPolicy()
        {
        }

        public string TypeQualifier
        {
            get { return _typeQualifier; }
            set { _typeQualifier = value; }
        }

        public ServiceRequestAuthorizationType PolicyType
        {
          get { return _policyType; }
          set { _policyType = value; }
        }

        public FlowRoleType FlowRoleType
        {
            get { return _flowRoleType; }
            set { _flowRoleType = value; }
        }

        public string AccountId
        {
            get { return _accountId; }
            set { _accountId = value; }
        }
    }
}
