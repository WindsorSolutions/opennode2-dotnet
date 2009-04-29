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
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Net;
using System.IO;
using Windsor.Commons.Core;

using Windsor.Node2008.WNOSUtility;

namespace Windsor.Node2008.WNOSDomain
{
    /// <summary>
    /// Domain object representing an authorization request for access to one or more node flows.
    /// </summary>
    [Serializable]
    public class AccountAuthorizationRequest : BaseIdentity
    {
        private string _transactionId;

        public string TransactionId
        {
            get { return _transactionId; }
            set { _transactionId = value; }
        }
        private DateTime _requestGeneratedOn;

        public DateTime RequestGeneratedOn
        {
            get { return _requestGeneratedOn; }
            set { _requestGeneratedOn = value; }
        }
        private string _requestType;

        public string RequestType
        {
            get { return _requestType; }
            set { _requestType = value; }
        }
        
        private string _naasAccount;

        public string NaasAccount
        {
            get { return _naasAccount; }
            set { _naasAccount = value; }
        }
        private string _fullName;

        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }
        private string _organizationAffiliation;

        public string OrganizationAffiliation
        {
            get { return _organizationAffiliation; }
            set { _organizationAffiliation = value; }
        }
        private string _telephoneNumber;

        public string TelephoneNumber
        {
            get { return _telephoneNumber; }
            set { _telephoneNumber = value; }
        }
        private string _emailAddress;

        public string EmailAddress
        {
            get { return _emailAddress; }
            set { _emailAddress = value; }
        }
        private string _affiliatedNodeId;

        public string AffiliatedNodeId
        {
            get { return _affiliatedNodeId; }
            set { _affiliatedNodeId = value; }
        }
        private string _affiliatedCounty;

        public string AffiliatedCounty
        {
            get { return _affiliatedCounty; }
            set { _affiliatedCounty = value; }
        }
        private string _purposeDescription;

        public string PurposeDescription
        {
            get { return _purposeDescription; }
            set { _purposeDescription = value; }
        }
        private IList<string> _requestedNodeIds;

        public IList<string> RequestedNodeIds
        {
            get { return _requestedNodeIds; }
            set { _requestedNodeIds = value; }
        }
        private IList<AccountAuthorizationRequestFlow> _requestedFlows;

        public IList<AccountAuthorizationRequestFlow> RequestedFlows
        {
            get { return _requestedFlows; }
            set { _requestedFlows = value; }
        }
        
        public IList<string> GetAllRequestedFlowNames()
        {
            List<string> flowNames = new List<string>();
            if (!CollectionUtils.IsNullOrEmpty(_requestedFlows))
            {
                flowNames.Capacity = _requestedFlows.Count;
                foreach (AccountAuthorizationRequestFlow requestedFlow in _requestedFlows)
                {
                    flowNames.Add(requestedFlow.FlowName);
                }
            }
            return flowNames;
        }
        public IList<string> GetGrantedFlowNames()
        {
            List<string> flowNames = new List<string>();
            if (!CollectionUtils.IsNullOrEmpty(_requestedFlows))
            {
                flowNames.Capacity = _requestedFlows.Count;
                foreach (AccountAuthorizationRequestFlow requestedFlow in _requestedFlows)
                {
                    if (requestedFlow.AccessGranted)
                    {
                        flowNames.Add(requestedFlow.FlowName);
                    }
                }
            }
            return flowNames;
        }

        private AccountAuthorizationResponse _response;

        public AccountAuthorizationResponse Response
        {
            get { return _response; }
            set { _response = value; }
        }
    }

    [Serializable]
    public class AccountAuthorizationResponse
    {
        private string _authorizationAccountId;

        public string AuthorizationAccountId
        {
            get { return _authorizationAccountId; }
            set { _authorizationAccountId = value; }
        }
        private string _authorizationComments;

        public string AuthorizationComments
        {
            get { return _authorizationComments; }
            set { _authorizationComments = value; }
        }
        private DateTime _authorizationGeneratedOn;

        public DateTime AuthorizationGeneratedOn
        {
            get { return _authorizationGeneratedOn; }
            set { _authorizationGeneratedOn = value; }
        }
        private bool _didCreateInNaas;

        public bool DidCreateInNaas
        {
            get { return _didCreateInNaas; }
            set { _didCreateInNaas = value; }
        }

        public override string ToString()
        {
            return ReflectionUtils.GetPublicPropertiesString(this);
        }
    }

    [Serializable]
    public class AccountAuthorizationRequestFlow : BaseIdentity
    {
        public AccountAuthorizationRequestFlow() { }
        public AccountAuthorizationRequestFlow(string flowName)
        {
            _flowName = flowName;
        }
        private string _flowName;

        public string FlowName
        {
            get { return _flowName; }
            set { _flowName = value; }
        }
        private bool _accessGranted;

        public bool AccessGranted
        {
            get { return _accessGranted; }
            set { _accessGranted = value; }
        }
    }
}
