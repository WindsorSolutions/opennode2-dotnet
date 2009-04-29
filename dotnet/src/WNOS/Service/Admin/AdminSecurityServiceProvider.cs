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
using Windsor.Node2008.WNOSConnector.Admin;
using Windsor.Node2008.WNOSDomain;

using Windsor.Node2008.WNOS.Logic;
using Windsor.Node2008.WNOSUtility;

namespace Windsor.Node2008.WNOS.Service.Admin
{
    public class AdminSecurityServiceProvider : BaseAdminService, IAdminSecurityService
    {


        private static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());

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
        /// <param name="credentials"></param>
        /// <param name="requestedFromIp"></param>
        /// <returns></returns>
        public AdminVisit Authenticate(AuthenticationCredentials credentials, string requestedFromIp)
        {
            LOG.Debug("Authenticate");
            LOG.Debug("   credentials: " + credentials);
            LOG.Debug("   requestedFromIp: " + requestedFromIp);

            AdminVisit visit = new AdminVisit();
            
            visit.Account = new UserAccount();
            visit.Account.Id = Guid.NewGuid().ToString();
            visit.Account.IsActive = true;
            visit.Account.ModifiedById = visit.Account.Id;
            visit.Account.ModifiedOn = DateTime.Now;
            visit.Account.NaasAccount = credentials.UserName;
            visit.Account.Role = SystemRoleType.Admin;

            visit.CreatedOn = visit.Account.ModifiedOn;
            visit.IP = requestedFromIp;

            return visit;

        }

        #endregion


        #region Properties 

        #endregion
    }
}
