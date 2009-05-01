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
    public class NodeTransaction : AuditableIdentity
    {
        private DataFlow _flow;
        private string _networkId;
        private TransactionStatus _status;
        private IList<Document> _documents;
        private AsyncContentRequest _request;
        private string _operation;
        private EndpointVersionType _endpointVersion = EndpointVersionType.Undefined;
        private NodeMethod _nodeMethod;
        private string _networkEndpointUrl;
        private EndpointVersionType _networkEndpointVersion = EndpointVersionType.Undefined;
        private CommonTransactionStatusCode _networkEndpointStatus;

        public NodeTransaction()
        {
        }

        public TransactionStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public string NetworkId
        {
            get { return _networkId; }
            set { _networkId = value; }
        }

        public DataFlow Flow
        {
            get { return _flow; }
            set
            {
                _flow = value;
            }
        }

        public IList<Document> Documents
        {
            get { return _documents; }
            set { _documents = value; }
        }

        public AsyncContentRequest Request
        {
            get { return _request; }
            set { _request = value; }
        }
        public string Operation
        {
            get { return _operation; }
            set { _operation = value; }
        }
        public NodeMethod NodeMethod
        {
            get { return _nodeMethod; }
            set { _nodeMethod = value; }
        }
        public EndpointVersionType EndpointVersion
        {
            get { return _endpointVersion; }
            set { _endpointVersion = value; }
        }
        public string NetworkEndpointUrl
        {
            get { return _networkEndpointUrl; }
            set { _networkEndpointUrl = value; }
        }
        public EndpointVersionType NetworkEndpointVersion
        {
            get { return _networkEndpointVersion; }
            set { _networkEndpointVersion = value; }
        }
        public CommonTransactionStatusCode NetworkEndpointStatus
        {
            get { return _networkEndpointStatus; }
            set { _networkEndpointStatus = value; }
        }
    }
}
