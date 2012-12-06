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

using Windsor.Node2008.WNOSConnector.Service;

using Windsor.Node2008.WNOS.Logic;

using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSConnector.Provider;
using Windsor.Node2008.WNOSUtility;
using Windsor.Node2008.WNOSConnector.Logic;
using Windsor.Node2008.WNOSProviders;
using Windsor.Node2008.WNOSConnector.Admin;
using Windsor.Commons.Core;

namespace Windsor.Node2008.WNOS.Service
{
    public abstract class BaseEndpointService : BaseService
    {

        private INAASManagerEx _authProvider;
        private IFaultProvider _faultProvider;
        private IIdProvider _idProvider;
        private IAccountManagerEx _accountManager;
        private ISerializationHelper _serializationHelper;
        private IFlowManagerEx _flowManager;

        #region Init

        new public void Init()
        {

            base.Init();

            FieldNotInitializedException.ThrowIfNull(this, ref _authProvider);
            FieldNotInitializedException.ThrowIfNull(this, ref _faultProvider);
            FieldNotInitializedException.ThrowIfNull(this, ref _idProvider);
            FieldNotInitializedException.ThrowIfNull(this, ref _accountManager);
            FieldNotInitializedException.ThrowIfNull(this, ref _serializationHelper);
            FieldNotInitializedException.ThrowIfNull(this, ref _flowManager);
            FieldNotInitializedException.ThrowIfNull(this, CompressionHelper, "CompressionHelper");
        }

        #endregion


        /// <summary>
        /// Make a generic Endpoint visit
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="visit"></param>
        /// <returns>Activity</returns>
        protected void MakeEndpointActivity(NamedEndpointVisit visit, ActivityType activityType,
                                            NodeMethod method, out NodeVisit nodeVisit,
                                            out Activity activity)
        {

            if (visit == null)
            {
                throw new ArgumentNullException("visit");
            }

            activity = new Activity(method, null, null, activityType, null, visit.IP, "Visit from endpoint version {0} for method {1}.",
                                    visit.Version, method.ToString());

            activity.AppendFormat("Attempting to validate user token {0} from IP {1}.",
                                  visit.Token, visit.IP);

            string username = AuthProvider.Validate(visit.Token, visit.IP);

            activity.AppendFormat("Successfully validated user token {0} with user name {1}.",
                                  visit.Token, username);

            bool wasCreated;
            UserAccount userAccount = AccountManager.GetOrCreate(username, true, out wasCreated);

            activity.ModifiedById = userAccount.Id;

            IDictionary<string, string> flowsIdToNameMap = _flowManager.GetAllFlowsIdToNameMap();
            nodeVisit = new NodeVisit(userAccount, visit.IP, flowsIdToNameMap);

            if (wasCreated)
            {
                activity.AppendFormat("Successfully created local user account for {0}.",
                                      username);
            }
            else
            {
                activity.AppendFormat("Successfully got local user account for {0}.",
                                      username);
            }
        }
        /// <summary>
        /// Make a generic Endpoint visit
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="visit"></param>
        /// <returns>Activity</returns>
        protected void AuthenticateEndpointActivity(AuthEndpointVisit visit, ActivityType activityType,
                                                    NodeMethod method, out NodeVisit nodeVisit,
                                                    out string userToken, out Activity activity)
        {
            if (visit == null)
            {
                throw new ArgumentNullException("visit");
            }

            activity = new Activity(method, null, null, activityType, null, visit.IP, "Visit from endpoint version {0} for method {1}.",
                                    visit.Version, method.ToString());

            activity.AppendFormat("Attempting to authenticate {0} from IP {1} using {2}.",
                                  visit.Credentials.UserName, visit.IP, visit.AuthMethod);

            // Get a token or fail trying
            userToken = AuthProvider.AuthenticateUser(visit.Credentials, visit.IP,
                                                      visit.AuthMethod);

            activity.AppendFormat("Successfully authenticated {0} with user token {1}.",
                                  visit.Credentials.UserName, userToken);

            //Always returns an account
            bool wasCreated;
            UserAccount userAccount =
                AccountManager.GetOrCreate(visit.Credentials.UserName, true, out wasCreated);

            //Update the activity to created by the current user
            activity.ModifiedById = userAccount.Id;

            IDictionary<string, string> flowsIdToNameMap = _flowManager.GetAllFlowsIdToNameMap();
            nodeVisit = new NodeVisit(userAccount, visit.IP, flowsIdToNameMap);

            if (wasCreated)
            {
                activity.AppendFormat("Successfully created local user account for {0}.",
                                      visit.Credentials.UserName);
            }
            else
            {
                activity.AppendFormat("Successfully got local user account for {0}.",
                                      visit.Credentials.UserName);
            }
        }

        protected void ValidateUserPermissions(NodeVisit nodeVisit, string flowName, string serviceName,
                                               NodeMethod webMethod, Activity activity)
        {
            bool hasPermission = nodeVisit.IsFlowPermittedByName(flowName, FlowRoleType.Endpoint);
            if (!hasPermission)
            {
                string message = string.Format("User \"{0}\" is not authorized to access the flow \"{1}\"",
                                               nodeVisit.Account.NaasAccount, flowName);
                activity.AppendFormat("Raising exception: " + message);
                throw new UnauthorizedAccessException(message);
            }
            if (string.IsNullOrEmpty(serviceName))
            {
                activity.AppendFormat("User {0} authorized for flow {1} and method {2}",
                                      nodeVisit.Account.NaasAccount, flowName, webMethod.ToString());
            }
            else
            {
                activity.AppendFormat("User {0} authorized for flow {1} and operation {2} and method {3}",
                                      nodeVisit.Account.NaasAccount, flowName, serviceName, webMethod.ToString());
            }
        }

        #region Properties
        public INAASManagerEx AuthProvider
        {
            get
            {
                return _authProvider;
            }
            set
            {
                _authProvider = value;
            }
        }

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

        public IFaultProvider FaultProvider
        {
            get
            {
                return _faultProvider;
            }
            set
            {
                _faultProvider = value;
            }
        }
        public IIdProvider IdProvider
        {
            get
            {
                return _idProvider;
            }
            set
            {
                _idProvider = value;
            }
        }

        public ISerializationHelper SerializationHelper
        {
            get
            {
                return _serializationHelper;
            }
            set
            {
                _serializationHelper = value;
            }
        }
        public IFlowManagerEx FlowManager
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
        public ICompressionHelper CompressionHelper
        {
            get;
            set;
        }

        #endregion

    }
}
