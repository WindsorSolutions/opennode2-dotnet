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
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSConnector.Provider;
using Windsor.Node2008.WNOSUtility;

namespace Windsor.Node2008.WNOSConnector.Admin
{
    public interface IAccountService : ISimpleListDataService
    {

        bool UserExistsInNAAS(string userName);
        bool UserExistsInNAAS(string userName, AdminVisit visit, out string affiliate, out bool canDelete);
        bool UserPasswordExistsInDB(string userName);

        UserAccount Save(UserAccount instance, string naasCreatePassword, AdminVisit visit);

        UserAccount ResetPassword(UserAccount instance, AdminVisit visit);

        UserAccount ResetPassword(string currentPassword, string newPassword,
                                  UserAccount instance, AdminVisit visit);

        UserAccount Get(string username, AdminVisit visit);

        UserAccount GetById(string id, AdminVisit visit);

        IList<UserAccount> Get(AdminVisit visit);

        void Delete(UserAccount instance, AdminVisit visit);

        void ValidateUserMinimumRole(AdminVisit visit, SystemRoleType minimumRole);

        string GetUsernameById(string userId);
        /// <summary>
        /// Return true if the node is setup in Demo mode
        /// </summary>
        bool IsDemoNode { get; }

        string GenerateRandomPassword();

        string BulkAddUsers(ICollection<string> usernames, bool createInNaas, string defaultPassword,
                            SystemRoleType defaultRole, ICollection<string> accessFlowNames, 
                            AdminVisit visit);
    }
}