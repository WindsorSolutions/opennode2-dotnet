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
using Windsor.Commons.NodeDomain;

namespace Windsor.Node2008.WNOSPlugin.Security
{
    [Serializable]
    public class GetAuthorizedUsers : BaseWNOSPlugin, IQueryProcessor
    {
        #region fields
        private static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());
        #endregion

        private IRequestManager _requestManager;
        protected ISerializationHelper _serializationHelper;
        protected IDocumentManager _documentManager;
        protected IAccountManager _accountManager;
        protected IFlowManager _flowManager;

        public PaginatedContentResult ProcessQuery(string requestId)
        {
            GetServiceImplementation(out _requestManager);
            GetServiceImplementation(out _serializationHelper);
            GetServiceImplementation(out _documentManager);
            GetServiceImplementation(out _accountManager);
            GetServiceImplementation(out _flowManager);

            AppendAuditLogEvent("Validating requestId ...");
            DataRequest dataRequest = _requestManager.GetDataRequest(requestId);

            GetAuthorizedUsersResponse response = GetAuthorizedUsersResponseData();

            byte[] content = _serializationHelper.Serialize(response);

            if (response.AuthorizedUserList.Length == 0)
            {
                AppendAuditLogEvent("Did not find authorization information for any users");
            }
            else
            {
                AppendAuditLogEvent("Returning authorization information for {0} users ...", response.AuthorizedUserList.Length);
            }

            string docId =
                    _documentManager.AddDocument(dataRequest.TransactionId, CommonTransactionStatusCode.Completed,
                                                 null, new Document(null, CommonContentType.XML, content));

            PaginatedContentResult result = new PaginatedContentResult(0, response.AuthorizedUserList.Length, true,
                                                                       CommonContentType.XML, content);
            return result;
        }
        protected GetAuthorizedUsersResponse GetAuthorizedUsersResponseData()
        {
            IList<UserAccount> nodeUsers = _accountManager.GetAllUsers();
            GetAuthorizedUsersResponse response = new GetAuthorizedUsersResponse();
            List<AuthorizedUser> responseUsers = new List<AuthorizedUser>();
            if (!CollectionUtils.IsNullOrEmpty(nodeUsers))
            {
                // Get list of unprotected flows:
                List<AuthorizedFlow> unprotectedFlows = GetUnprotectedFlows();
                List<AuthorizedFlow> allFlows = GetAllFlows();

                // Loop through each user to add them to the response list
                foreach (UserAccount nodeUser in nodeUsers)
                {
                    AuthorizedUser responseUser = new AuthorizedUser();
                    responseUser.NAASUserName = nodeUser.NaasAccount;
                    List<AuthorizedFlow> userAllowedFlows;
                    if (nodeUser.Role == SystemRoleType.Admin)
                    {
                        userAllowedFlows = new List<AuthorizedFlow>(allFlows);
                    }
                    else
                    {
                        userAllowedFlows = new List<AuthorizedFlow>(unprotectedFlows);
                        if (!CollectionUtils.IsNullOrEmpty(nodeUser.Policies))
                        {
                            foreach (UserAccessPolicy userAccessPolicy in nodeUser.Policies)
                            {
                                if ((userAccessPolicy.PolicyType == ServiceRequestAuthorizationType.Flow) &&
                                    (userAccessPolicy.FlowRoleType != FlowRoleType.None))
                                {
                                    AuthorizedFlow authorizedFlow = new AuthorizedFlow();
                                    authorizedFlow.FlowName = userAccessPolicy.TypeQualifier;
                                    userAllowedFlows.Add(authorizedFlow);
                                }
                            }
                        }
                    }
                    responseUser.AuthorizedFlowList = userAllowedFlows.ToArray();
                    responseUsers.Add(responseUser);
                }
            }
            response.AuthorizedUserList = responseUsers.ToArray();
            return response;
        }
        protected List<AuthorizedFlow> GetUnprotectedFlows()
        {
            List<AuthorizedFlow> unprotectedFlows = new List<AuthorizedFlow>();
            IList<DataFlow> nodeFlows = _flowManager.GetAllDataFlows(false, false);
            if (!CollectionUtils.IsNullOrEmpty(nodeFlows))
            {
                foreach (DataFlow nodeFlow in nodeFlows)
                {
                    if (!nodeFlow.IsProtected)
                    {
                        AuthorizedFlow authorizedFlow = new AuthorizedFlow();
                        authorizedFlow.FlowName = nodeFlow.FlowName;
                        unprotectedFlows.Add(authorizedFlow);
                    }
                }
            }
            return unprotectedFlows;
        }
        protected List<AuthorizedFlow> GetAllFlows()
        {
            List<AuthorizedFlow> unprotectedFlows = new List<AuthorizedFlow>();
            IList<DataFlow> nodeFlows = _flowManager.GetAllDataFlows(false, false);
            if (!CollectionUtils.IsNullOrEmpty(nodeFlows))
            {
                foreach (DataFlow nodeFlow in nodeFlows)
                {
                    AuthorizedFlow authorizedFlow = new AuthorizedFlow();
                    authorizedFlow.FlowName = nodeFlow.FlowName;
                    unprotectedFlows.Add(authorizedFlow);
                }
            }
            return unprotectedFlows;
        }
    }
}
