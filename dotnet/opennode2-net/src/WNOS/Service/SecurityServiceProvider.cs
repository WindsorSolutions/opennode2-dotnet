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
using System.Security.Authentication;


using Common.Logging;

using Windsor.Node2008.WNOSConnector.Service;
using Windsor.Node2008.WNOSDomain;

using Windsor.Node2008.WNOS.Logic;
using Windsor.Node2008.WNOSUtility;
using Windsor.Node2008.WNOSConnector.Provider;
using Windsor.Commons.Core;
using Windsor.Commons.NodeDomain;

namespace Windsor.Node2008.WNOS.Service
{
    public class SecurityServiceProvider : BaseEndpointService, ISecurityService
    {


        #region Init

        new public void Init()
        {
            base.Init();
        }

        #endregion



        #region ISecurityService Members

        /// <summary>
        /// Authenticate
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public string Authenticate(AuthEndpointVisit request)
        {

            //Create a visit from the request
            Activity activity = null;

            try
            {
                UserAccount userAccount;
                string token;
                AuthenticateEndpointActivity(request, ActivityType.ServiceAuth, NodeMethod.Authenticate,
                                             out userAccount, out token, out activity);

                return token;

            }
            catch (Exception ex)
            {
                if (activity != null)
                {
                    activity.Append(ExceptionUtils.ToShortString(ex));
                    activity.Type = ActivityType.Error;
                }
                if (ex is InvalidCredentialException)
                {
                    throw FaultProvider.GetFault(EndpointVersionType.EN20, ENExceptionCodeType.E_InvalidCredential,
                                                 ex.Message);
                }
                else
                {
                    throw FaultProvider.GetFault(request.Version, ex);
                }
            }
            finally
            {
                if (activity != null)
                {
                    ActivityManager.Log(activity);
                }
            }

        }

        /// <summary>
        /// Authenticate
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public AdminVisit Authenticate(AuthenticationCredentials credentials, string requestedFromIp)
        {
            try
            {
                bool isDemoUser;
                if (!AccountManager.IsValidDemoUser(credentials.UserName, credentials.Password, out isDemoUser))
                {
                    if (isDemoUser)
                    {
                        throw new ApplicationException("Invalid credentials");
                    }
                    //Get a token or fail trying
                    string token = AuthProvider.AuthenticateUser(credentials, requestedFromIp,
                                                                 "Password");
                }

                //Always returns an account
                bool wasCreated;
                UserAccount account = AccountManager.GetOrCreate(credentials.UserName, false,
                                                                 out wasCreated);

                AdminVisit visit = new AdminVisit(account, requestedFromIp);

                ActivityManager.LogAdminAuth(NodeMethod.None, null, visit, "Login success for user: \"{0}\"", credentials.UserName);

                return visit;
            }
            catch (Exception e)
            {
                ActivityManager.LogError(NodeMethod.None, null, e, null, "Login failure for user: \"{0}\"", credentials.UserName);
                throw;
            }
        }
        #endregion


        #region Properties 

        #endregion
    }
}
