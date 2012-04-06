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

﻿using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;
using System.Threading;
using NAAS_USRMGR = Windsor.Commons.NAASClient.NAASUserMgr;

namespace Windsor.Commons.NAASClient
{
    public static class NAASHelper
    {
        public static Exception AuthenticateUser(string username, string password, bool isProduction)
        {
            try
            {
                using (NAASClient client = new NAASClient(isProduction))
                {
                    client.Timeout = 15000;
                    CentralAuth req = new CentralAuth();
                    req.authenticationMethod = "password";
                    req.clientIp = string.Empty;
                    req.credential = password;
                    req.domain = DomainTypeCode.@default;
                    req.resourceURI = string.Empty;
                    req.userId = username;

                    CentralAuthResponse resp = client.CentralAuth(req);

                    string token = resp.@return;

                    if (string.IsNullOrEmpty(token))
                    {
                        throw new ArgumentException("NAAS returned an empty authentication token");
                    }

                    return null;
                }
            }
            catch (Exception e)
            {
                return e;
            }
        }
        public static Exception ChangePassword(string username, string currentPassword, string newPassword,
                                               bool isProduction)
        {
            try
            {
                IUserMgr userManager = new UserMgr2Provider(isProduction);
                NAAS_USRMGR.ChangePassword changePassword = new NAAS_USRMGR.ChangePassword();

                changePassword.userId = username;
                changePassword.credential = currentPassword;
                changePassword.domain = NAAS_USRMGR.DomainTypeCode.@default;
                changePassword.newPassword = newPassword;
                changePassword.passwordConfirmation = newPassword;

                NAAS_USRMGR.ChangePasswordResponse response = userManager.ChangePassword(changePassword);

                return null;
            }
            catch (Exception e)
            {
                return e;
            }
        }
    }
}