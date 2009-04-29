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
using System.Xml;
using System.IO;
using System.Data;
using System.Data.Common;
using System.Data.ProviderBase;
using System.Threading;
using Windsor.Node2008.WNOSPlugin;
using System.Diagnostics;
using System.Reflection;
using Windsor.Node2008.WNOSUtility;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSProviders;
using Spring.Data.Common;
using Windsor.Commons.Core;
using Windsor.Commons.Logging;
using Windsor.HERE.CentralServer.Message;

namespace Windsor.Node2008.WNOSPlugin.Security
{
    [Serializable]
    public class UserAuthorizationRequestSubmitProcessor : BaseWNOSPlugin, ISubmitProcessor
    {
        #region fields
        private static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());
        #endregion

        private ITransactionManager _transactionManager;
        private IAccountAuthorizationRequestManager _accountAuthorizationRequestManager;
        protected ISerializationHelper _serializationHelper;
        protected IDocumentManager _documentManager;
        protected IXmlValidationHelper _xmlValidationHelper;

        public void ProcessSubmit(string transactionId)
        {
            GetServiceImplementation(out _transactionManager);
            GetServiceImplementation(out _accountAuthorizationRequestManager);
            GetServiceImplementation(out _serializationHelper);
            GetServiceImplementation(out _documentManager);
            GetServiceImplementation(out _xmlValidationHelper);

            IList<string> docIds = _transactionManager.GetAllUnprocessedDocumentDbIds(transactionId);
            if (CollectionUtils.IsNullOrEmpty(docIds))
            {
                throw new ArgumentException("No authorization requests specified for transaction \"{0}\"",
                                            transactionId);
            }
            if (docIds.Count > 1)
            {
                throw new ArgumentException("More than one authorization request was specified for transaction \"{0}\"",
                                            transactionId);
            }
            AppendAuditLogEvent("Received {0} user Authorization request(s)", docIds.Count);

            List<AccountAuthorizationRequest> requests = new List<AccountAuthorizationRequest>(docIds.Count);
            foreach (string docId in docIds)
            {
                AccountAuthorizationRequest accountRequest = GetAccountAuthorizationRequest(transactionId, docId);
                _accountAuthorizationRequestManager.Save(accountRequest);
                _documentManager.SetDocumentStatus(transactionId, docId, CommonTransactionStatusCode.Processed,
                                                   "Processed " + docId.ToString());
            }
        }
        protected AccountAuthorizationRequest GetAccountAuthorizationRequest(string transactionId, string docId)
        {
            byte[] content = _documentManager.GetUncompressedContent(transactionId, docId);

            ValidateAuthorizationRequestXml(content);

            AuthorizationRequest request;
            try
            {
                request = _serializationHelper.Deserialize<AuthorizationRequest>(content);
            }
            catch (Exception ex)
            {
                throw new InvalidDataException(string.Format("Could not deserialize authorization request document content for document id: \"{0}\"",
                                                             docId), ex);
            }
            if (_accountAuthorizationRequestManager.HasOpenRequestForUser(request.NaasUsername))
            {
                throw new ArgumentException(string.Format("There is already an open authorization request for the user: {0}", request.NaasUsername));
            }
            if ((request.GeneratedOn < DateTime.Now.AddYears(-2)) || (request.GeneratedOn > DateTime.Now.AddYears(1)))
            {
                throw new ArgumentException(string.Format("The request GeneratedOn date is invalid: {0}", request.GeneratedOn));
            }

            bool existsInNaas = 
                _accountAuthorizationRequestManager.ValidateUserExistance(request.NaasUsername, request.AffiliatedNodeId,
                                                                          request.RequestedDataSourceNames);
            
            AccountAuthorizationRequest accountRequest = new AccountAuthorizationRequest();
            accountRequest.AffiliatedCounty = request.AffiliatedCounty;
            accountRequest.AffiliatedNodeId = request.AffiliatedNodeId;
            accountRequest.EmailAddress = request.EmailAddress;
            accountRequest.FullName = request.FullName;
            accountRequest.NaasAccount = request.NaasUsername;
            accountRequest.OrganizationAffiliation = request.OrganizationAffiliation;
            accountRequest.PurposeDescription = request.PurposeDescription;
            accountRequest.RequestedNodeIds = request.RequestedNodeIds;
            accountRequest.RequestGeneratedOn = request.GeneratedOn;
            accountRequest.TelephoneNumber = request.TelephoneNumber;
            accountRequest.RequestType = request.RequestType;
            if (!CollectionUtils.IsNullOrEmpty(request.RequestedDataSourceNames))
            {
                List<AccountAuthorizationRequestFlow> flowList = 
                    new List<AccountAuthorizationRequestFlow>(request.RequestedDataSourceNames.Length);
                foreach (string flowName in request.RequestedDataSourceNames)
                {
                    flowList.Add(new AccountAuthorizationRequestFlow(flowName));
                }
                accountRequest.RequestedFlows = flowList;
            }
            accountRequest.TransactionId = transactionId;
            return accountRequest;
        }
        protected void ValidateAuthorizationRequestXml(byte[] content)
        {
            Stream xmlSchemaStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(this.GetType(), "AuthRequest.xsd");
            if (xmlSchemaStream == null)
            {
                throw new FileNotFoundException("The resource AuthRequest.xsd was not found");
            }
            IList<string> errors = _xmlValidationHelper.Validate(content, xmlSchemaStream);
            if (!CollectionUtils.IsNullOrEmpty(errors))
            {
                throw new InvalidDataException(string.Format("The input AuthorizationRequest could not be validated: {0}",
                                                             errors[0]));
            }
        }
    }
}
