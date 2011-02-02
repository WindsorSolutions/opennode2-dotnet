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
using System.Data;
using System.Collections;
using System.Collections.Generic;
using Windsor.Node2008.WNOSConnector.Service;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSConnector.Provider;

namespace Windsor.Node2008.Endpoint1
{
    public class ENService11Provider
    {

        #region Members
        private IContentService _contentService;
        private ISecurityService _securityService;
        private ITransactionService _transactionService;
        private IFaultProvider _faultProvider;
        private IVisitProvider _visitProvider;
        private string _defaultPingResponse = "Ready";
        private string[] getServicesResult = { "See 2.0 specification implementation for the list of flows currently supported by this Node" };
        #endregion


        public void Init()
        {

            if (_contentService == null)
            {
                throw new ArgumentException("ContentService property not set");
            }

            if (_securityService == null)
            {
                throw new ArgumentException("SecurityService property not set");
            }

            if (_transactionService == null)
            {
                throw new ArgumentException("TransactionService property not set");
            }

            if (_faultProvider == null)
            {
                throw new ArgumentException("FaultProvider property not set");
            }

            if (_visitProvider == null)
            {
                throw new ArgumentException("VisitProvider property not set");
            }
        }



        #region Properties

        public string DefaultPingResponse
        {
            get { return _defaultPingResponse; }
            set { _defaultPingResponse = value; }
        }

        public IVisitProvider VisitProvider
        {
            get { return _visitProvider; }
            set { _visitProvider = value; }
        }

        public IContentService ContentService
        {
            get { return _contentService; }
            set { _contentService = value; }
        }

        public ISecurityService SecurityService
        {
            get { return _securityService; }
            set { _securityService = value; }
        }

        public ITransactionService TransactionService
        {
            get { return _transactionService; }
            set { _transactionService = value; }
        }

        public IFaultProvider FaultProvider
        {
            get { return _faultProvider; }
            set { _faultProvider = value; }
        }
        public string[] GetServicesResult
        {
            get { return getServicesResult; }
            set { getServicesResult = value; }
        }

        #endregion



    }
}
