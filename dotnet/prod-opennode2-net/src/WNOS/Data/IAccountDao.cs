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
using Windsor.Node2008.WNOSDomain;
using System.Collections.Generic;
using Windsor.Commons.NodeDomain;

namespace Windsor.Node2008.WNOS.Data
{
    public interface IAccountDao
    {
        void Delete(UserAccount account);
        IList<UserAccount> Get();
        ICollection<string> GetAllUserNames();
        UserAccount GetById(string id);
        UserAccount GetByName(string username);
        string GetUserIdByName(string username);
        IDictionary<string, string> GetUserIdToNameMap(bool includeDeletedUsers, string deletedNameSuffix);
        string GetUsernameById(string id);
        void Save(UserAccount item);
        Dictionary<string, string> GetMostActiveUsers(int maxCount);
        bool UserPasswordExistsInDB(string userName);
        void ResetPassword(string userName, string newPassword);
        void ChangePassword(string userName, string currentPassword, string newPassword);
        IList<string> GetAuthorizedUsernamesForFlow(string flowName, FlowRoleType roleType);
        bool AreEndpointUsersEnabled
        {
            get;
        }
        IList<UserAccount> GetEndpointUsers();
        UserAccount GetEndpointUserByName(string username);
        IList<UserAccount> GetAllPossibleEndpointUsers();
        void SaveEndpointUser(UserAccount item, string testNaasPassword, string prodNaasPassword);
        void RemoveEndpointUser(UserAccount item);
        bool GetEnpointUserPasswordsByUsername(string username, out string testPassword, out string prodPassword);
        bool GetEnpointUserPasswordsById(string userId, out string username, out string testPassword, out string prodPassword);
        IDictionary<string, string> GetEndpointUserDisplayList();
    }
}
