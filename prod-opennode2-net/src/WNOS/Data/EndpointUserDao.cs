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

using System.Data;
using System.Data.Common;
using System.Reflection;

using Spring.Data.Generic;
using Spring.Data.Common;


using Common.Logging;

using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSConnector.Provider;
using Windsor.Node2008.WNOSUtility;
using Windsor.Commons.Core;
using Windsor.Commons.NodeDomain;

namespace Windsor.Node2008.WNOS.Data
{
    public class EndpointUserDao : BaseDao, IEndpointUserDao
    {
        new public void Init()
        {
            base.Init();

            FieldNotInitializedException.ThrowIfNull(this, AccountDao, "AccountDao");
            FieldNotInitializedException.ThrowIfNull(this, TransactionDao, "TransactionDao");
        }
        public IList<UserAccount> Get()
        {
            return AccountDao.GetEndpointUsers();
        }
        public IList<UserAccount> GetAllPossibleEndpointUsers()
        {
            return AccountDao.GetAllPossibleEndpointUsers();
        }
        public bool AreEndpointUsersEnabled
        {
            get
            {
                return AccountDao.AreEndpointUsersEnabled;
            }
        }
        public UserAccount GetByName(string username)
        {
            return AccountDao.GetEndpointUserByName(username);
        }
        public UserAccount GetById(string userId)
        {
            return AccountDao.GetEndpointUserById(userId);
        }
        public void Save(UserAccount item, string testNaasPassword, string prodNaasPassword)
        {
            AccountDao.SaveEndpointUser(item, testNaasPassword, prodNaasPassword);
        }
        public void Remove(UserAccount item)
        {
            AccountDao.RemoveEndpointUser(item);
        }
        public bool GetEnpointUserPasswordsByUsername(string username, out string testPassword, out string prodPassword)
        {
            return AccountDao.GetEnpointUserPasswordsByUsername(username, out testPassword, out prodPassword);
        }
        public bool GetEnpointUserPasswordsById(string userId, out string username, out string testPassword, out string prodPassword)
        {
            return AccountDao.GetEnpointUserPasswordsById(userId, out username, out testPassword, out prodPassword);
        }
        public IDictionary<string, string> GetEndpointUserDisplayList()
        {
            return AccountDao.GetEndpointUserDisplayList();
        }
        public void SetNetworkEndpointTransactionInfo(string transactionId, string networkId, EndpointVersionType networkEndpointVersion,
                                                      string networkEndpointUrl, string networkFlowName, string networkFlowOperation,
                                                      string endpointUsername)
        {
            TransactionDao.SetNetworkEndpointTransactionInfo(transactionId, networkId, networkEndpointVersion,
                                                             networkEndpointUrl, networkFlowName, networkFlowOperation,
                                                             endpointUsername);
        }
        public IAccountDao AccountDao
        {
            get;
            set;
        }
        public ITransactionDao TransactionDao
        {
            get;
            set;
        }
    }
}
