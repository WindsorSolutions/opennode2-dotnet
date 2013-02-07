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

using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOS.Data;
using Windsor.Node2008.WNOSUtility;
using Windsor.Node2008.WNOSConnector.Logic;
using Windsor.Node2008.WNOSConnector.Admin;
using Windsor.Node2008.WNOSProviders;
using Windsor.Commons.Core;
using Windsor.Commons.NodeClient;

namespace Windsor.Node2008.WNOS.Logic
{
    public class EndpointUserManager : LogicAuditBaseManager, IEndpointUserManager, IEndpointUserService
    {
        new public void Init()
        {
            base.Init();

            FieldNotInitializedException.ThrowIfNull(this, EndpointUserDao, "EndpointUserDao");
            FieldNotInitializedException.ThrowIfNull(this, NAASManager, "NAASManager");
        }

        public bool AreEndpointUsersEnabled
        {
            get
            {
                return EndpointUserDao.AreEndpointUsersEnabled;
            }
        }

        public UserAccount GetByName(string username, NodeVisit visit)
        {
            try
            {
                ValidateByRole(visit, SystemRoleType.Admin);
                UserAccount account = EndpointUserDao.GetByName(username);
                ActivityManager.LogAudit(NodeMethod.None, null, visit, "{0} got user account: {1}.",
                                         visit.Account.NaasAccount, account.ToString());
                return account;
            }
            catch (Exception e)
            {
                ActivityManager.LogError(NodeMethod.None, null, e, visit, "{0} failed to get user account: {1}.",
                                         visit.Account.NaasAccount, username);
                throw;
            }
        }
        public IDictionary<string, SimpleListDisplayInfo> GetListInfo(params string[] args)
        {
            Dictionary<string, SimpleListDisplayInfo> dict = new Dictionary<string, SimpleListDisplayInfo>();

            IList<UserAccount> userAccounts = EndpointUserDao.Get();
            if (!CollectionUtils.IsNullOrEmpty(userAccounts))
            {
                foreach (UserAccount userAccount in userAccounts)
                {
                    string name = userAccount.NaasAccount;
                    dict.Add(userAccount.NaasAccount, new SimpleListDisplayInfo(name, string.Empty));
                }
            }

            return dict;
        }

        public UserAccount Save(UserAccount instance, string testNaasPassword, string prodNaasPassword, NodeVisit visit)
        {
            ValidateByRole(visit, SystemRoleType.Admin);

            if ((instance == null) || string.IsNullOrEmpty(instance.NaasAccount) ||
                string.IsNullOrEmpty(testNaasPassword) || string.IsNullOrEmpty(prodNaasPassword))
            {
                throw new ArgumentException("Input values are null.");
            }

            instance.ModifiedById = visit.Account.Id;
            TransactionTemplate.Execute(delegate
            {
                EndpointUserDao.Save(instance, testNaasPassword, prodNaasPassword);
                ActivityManager.LogAudit(NodeMethod.None, null, visit, "{0} saved endpoint user: {1}.",
                                         visit.Account.NaasAccount, instance.NaasAccount);
                return null;
            });
            return instance;
        }

        public void Remove(UserAccount instance, NodeVisit visit)
        {
            ValidateByRole(visit, SystemRoleType.Admin);

            if (instance == null)
            {
                throw new ArgumentException("Input values are null.");
            }

            instance.ModifiedById = visit.Account.Id;
            TransactionTemplate.Execute(delegate
            {
                EndpointUserDao.Remove(instance);
                ActivityManager.LogAudit(NodeMethod.None, null, visit, "{0} removed endpoint user: {1}.",
                                         visit.Account.NaasAccount, instance.NaasAccount);
                return null;
            });
        }

        public string CheckPasswords(UserAccount instance, string testNaasPassword, string prodNaasPassword, NodeVisit visit)
        {
            ValidateByRole(visit, SystemRoleType.Admin);

            if ((instance == null) || string.IsNullOrEmpty(instance.NaasAccount) ||
                string.IsNullOrEmpty(testNaasPassword) || string.IsNullOrEmpty(prodNaasPassword))
            {
                throw new ArgumentException("Input values are null.");
            }

            string testException = null;
            try
            {
                NAASManager.ValidateUsernameAndPassword(instance.NaasAccount, testNaasPassword, true);
            }
            catch (Exception e)
            {
                testException = ExceptionUtils.GetDeepExceptionMessageOnly(e);
            }
            string prodException = null;
            try
            {
                NAASManager.ValidateUsernameAndPassword(instance.NaasAccount, prodNaasPassword, false);
            }
            catch (Exception e)
            {
                prodException = ExceptionUtils.GetDeepExceptionMessageOnly(e);
            }

            string rtnMessage = string.Empty;
            if (!string.IsNullOrEmpty(testException))
            {
                rtnMessage = "The Test username and password failed to authenticate with message: " + testException;
            }
            if (!string.IsNullOrEmpty(prodException))
            {
                if (!string.IsNullOrEmpty(rtnMessage))
                {
                    rtnMessage += Environment.NewLine + Environment.NewLine;
                }
                rtnMessage += "The Prod username and password failed to authenticate with message: " + prodException;
            }
            return rtnMessage;
        }

        //public PartnerIdentity GetById(string id, NodeVisit visit)
        //{
        //    // TODO: Validate visit (4.1 doesn't)?
        //    return _partnerDao.GetById(id);
        //}

        //public PartnerIdentity GetByName(string name, NodeVisit visit)
        //{
        //    // TODO: Validate visit (4.1 doesn't)?
        //    return _partnerDao.GetByName(name);
        //}

        public IList<UserAccount> GetAllPossibleEndpointUsers(NodeVisit visit)
        {
            ValidateByRole(visit, SystemRoleType.Admin);
            return EndpointUserDao.GetAllPossibleEndpointUsers();
        }

        //public PartnerIdentity GetById(string id)
        //{
        //    return _partnerDao.GetById(id);
        //}

        //public PartnerIdentity GetByName(string name)
        //{
        //    return _partnerDao.GetByName(name);
        //}

        //public IList<PartnerIdentity> Get()
        //{
        //    return _partnerDao.Get();
        //}

        //public void Delete(PartnerIdentity instance, NodeVisit visit)
        //{
        //    ValidateByRole(visit, SystemRoleType.Admin);
        //    TransactionTemplate.Execute(delegate
        //    {
        //        _partnerDao.Delete(instance);
        //        ActivityManager.LogAudit(NodeMethod.None, null, visit, "{0} deleted partner identity: {1}.",
        //                                 visit.Account.NaasAccount, instance.ToString());
        //        return null;
        //    });
        //}
        ///// <summary>
        ///// GetAllPartnerNames
        ///// </summary>
        //public IDictionary<string, string> GetAllPartnerNames()
        //{
        //    return _partnerDao.GetAllPartnerNames();
        //}
        //public IDictionary<string, string> GetAllPartnersIdToNameMap()
        //{
        //    return _partnerDao.GetAllPartnersIdToNameMap();
        //}
        public IEndpointUserDao EndpointUserDao
        {
            get;
            set;
        }
        public INAASManagerEx NAASManager
        {
            get;
            set;
        }
    }
}
