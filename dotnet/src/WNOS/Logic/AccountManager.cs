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
using System.Diagnostics;

using Common.Logging;

using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOS.Data;
using Windsor.Node2008.WNOSUtility;
using Windsor.Node2008.WNOSConnector.Logic;
using Windsor.Node2008.WNOSConnector.Admin;
using Windsor.Commons.Core;
using Windsor.Node2008.WNOSPlugin.Security;

namespace Windsor.Node2008.WNOS.Logic
{
    public class AccountManager : LogicAuditBaseManager, IAccountManagerEx, IAccountService
    {
        private IAccountDao _accountDao;
        private string _adminUserName;
        private UserAccount _adminAccount;
        private string _runtimeUserName;
        private UserAccount _runtimeAccount;
        private INAASManagerEx _naasManager;
        private INotificationManager _notificationManager;
        private ITransactionManagerEx _transactionManager;
        private IPolicyService _accountPolicyManager;
        private string _securityFlowName;
        private string _securityBulkAddUsersServiceName;

        #region Init

        public AccountManager()
        {
        }

        new public void Init()
        {
            base.Init();

            FieldNotInitializedException.ThrowIfNull(this, ref _accountDao);
            FieldNotInitializedException.ThrowIfNull(this, ref _naasManager);
            FieldNotInitializedException.ThrowIfEmptyString(this, ref _adminUserName);
            FieldNotInitializedException.ThrowIfEmptyString(this, ref _runtimeUserName);
            FieldNotInitializedException.ThrowIfNull(this, ref _notificationManager);
            FieldNotInitializedException.ThrowIfNull(this, ref _transactionManager);
            FieldNotInitializedException.ThrowIfEmptyString(this, ref _securityFlowName);
            FieldNotInitializedException.ThrowIfEmptyString(this, ref _securityBulkAddUsersServiceName);
            FieldNotInitializedException.ThrowIfNull(this, ref _accountPolicyManager);

            _adminAccount = _accountDao.GetByName(_adminUserName);

            if (_adminAccount == null)
            {
                throw new ArgumentException(
                    "Admin account not set in the database or its name is not: " +
                    _adminUserName);
            }
            _runtimeAccount = _accountDao.GetByName(_runtimeUserName);

            if (_runtimeAccount == null)
            {
                throw new ArgumentException(
                    "Runtime account not set in the database or its name is not: " +
                    _runtimeUserName);
            }
        }

        #endregion

        public bool IsValidDemoUser(string username, string password, out bool isDemoUser)
        {
            return _accountDao.IsValidDemoUser(username, password, out isDemoUser);
        }
        public string NodeId
        {
            get { return _naasManager.NodeId; }
        }

        public UserAccount BulkAddUser(string username, bool createInNaas, string defaultPassword,
                                       SystemRoleType defaultRole, ICollection<string> accessFlowNames,
                                       AdminVisit visit)
        {
            ValidateByRoleAndNotDemoAccount(visit, SystemRoleType.Admin);

            UserAccount usr = _accountDao.GetByName(username);
            if (usr != null)
            {
                throw new ArgumentException(string.Format("The user \"{0}\" already exists and was not created.", username));
            }
            usr = new UserAccount();
            usr.ModifiedById = visit.Account.Id;
            usr.IsActive = true;
            usr.NaasAccount = username;
            usr.Role = defaultRole;

            if ( !CollectionUtils.IsNullOrEmpty(accessFlowNames) )
            {
                List<UserAccessPolicy> policies = new List<UserAccessPolicy>(accessFlowNames.Count);
                foreach(string flowName in accessFlowNames)
                {
                    UserAccessPolicy policy = _accountPolicyManager.CreatePolicy(null, flowName, true);
                    policy.ModifiedById = visit.Account.Id;
                    policies.Add(policy);
                }
                usr.Policies = policies;
            }
            if (string.IsNullOrEmpty(defaultPassword))
            {
                defaultPassword = GenerateRandomPassword();
            }
            return Save(usr, createInNaas, defaultPassword, visit);
        }
        public UserAccount GetOrCreate(string username, bool alwaysCreateUserInDb,
                                       out bool wasCreated)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentException("Null username");
            }
#if DEBUG
            if (username.StartsWith("uid="))
            {
                DebugUtils.CheckDebuggerBreak();
            }
#endif // DEBUG
            UserAccount usr = _accountDao.GetByName(username);

            if (usr == null)
            {
                if (alwaysCreateUserInDb)
                {
                    usr = new UserAccount();
                    usr.ModifiedById = _adminAccount.Id;
                    usr.IsActive = true;
                    usr.NaasAccount = username;
                    usr.Role = SystemRoleType.Authed;

                    _accountDao.Save(usr);
                    wasCreated = true;
                }
                else
                {
                    throw new UnauthorizedAccessException(string.Format("The user \"{0}\" does not have an account on this node.",
                                                                        username));
                }
            }
            else
            {
                wasCreated = false;
            }

            return usr;

        }
        public UserAccount GetById(string userId)
        {
            return _accountDao.GetById(userId);
        }

        public IDictionary<string, SimpleListDisplayInfo> GetListInfo(params string[] args)
        {
            Dictionary<string, SimpleListDisplayInfo> dict = new Dictionary<string, SimpleListDisplayInfo>();

            IList<UserAccount> userAccounts = _accountDao.Get();
            if (!CollectionUtils.IsNullOrEmpty(userAccounts))
            {
                foreach (UserAccount userAccount in userAccounts)
                {
                    string name = userAccount.NaasAccount;
                    string description;
                    if (userAccount.IsActive)
                    {
                        description = userAccount.Role.ToString();
                    }
                    else
                    {
                        description = "Inactive";
                    }
                    dict.Add(userAccount.NaasAccount, new SimpleListDisplayInfo(name, description));
                }
            }

            return dict;
        }

        public bool UserExistsInNAAS(string userName)
        {
            return _naasManager.UserExists(userName);
        }
        protected bool CanDeleteUser(string userName, AdminVisit visit)
        {
            return (!string.Equals(userName, _adminAccount.NaasAccount, StringComparison.InvariantCultureIgnoreCase) &&
                    !string.Equals(userName, _runtimeAccount.NaasAccount, StringComparison.InvariantCultureIgnoreCase) &&
                    !string.Equals(userName, visit.Account.NaasAccount, StringComparison.InvariantCultureIgnoreCase));
        }
        public bool UserExistsInNAAS(string userName, AdminVisit visit, out string affiliate, out bool canDelete)
        {
            if (_naasManager.UserExists(userName, out affiliate, out canDelete))
            {
                if (canDelete)
                {
                   canDelete = CanDeleteUser(userName, visit);
                }
                return true;
            }
            return false;
        }
        public bool UserPasswordExistsInDB(string userName)
        {
            return _accountDao.UserPasswordExistsInDB(userName);
        }
        private bool IsDemoUser(UserAccount instance)
        {
            return IsDemoNode && (instance.IsDemoUser != null) && instance.IsDemoUser.Value;
        }
        public UserAccount Save(UserAccount instance, string naasCreatePassword, AdminVisit visit)
        {
            ValidateByRoleAndNotDemoAccount(visit, SystemRoleType.Admin);

            return Save(instance, true, naasCreatePassword, visit);
        }
        public string BulkAddUsers(ICollection<string> usernames, bool createInNaas, string defaultPassword,
                                   SystemRoleType defaultRole, ICollection<string> accessFlowNames,
                                   AdminVisit visit)
        {
            ValidateByRoleAndNotDemoAccount(visit, SystemRoleType.Admin);
            
            if (CollectionUtils.IsNullOrEmpty(usernames))
            {
                throw new ArgumentException("usernames cannot be empty");
            }

            // Create the parameter list:
            ByIndexOrNameDictionary<string> parameters = new ByIndexOrNameDictionary<string>(true);

            int i = 0;
            foreach(string username in usernames)
            {
                string key = string.Format("{0}{1}", BulkAddUsersConstants.PARAM_USERNAME_PREFIX, i.ToString());
                parameters.Add(key, username);
                ++i;
            }
            parameters.Add(BulkAddUsersConstants.PARAM_CREATE_IN_NAAS, createInNaas.ToString());
            if (!string.IsNullOrEmpty(defaultPassword))
            {
                parameters.Add(BulkAddUsersConstants.PARAM_DEFAULT_PASSWORD, defaultPassword);
            }
            parameters.Add(BulkAddUsersConstants.PARAM_DEFAULT_ROLE, defaultRole.ToString());
            if (!CollectionUtils.IsNullOrEmpty(accessFlowNames))
            {
                i = 0;
                foreach (string flowName in accessFlowNames)
                {
                    string key = string.Format("{0}{1}", BulkAddUsersConstants.PARAM_FLOW_NAME_PREFIX, i.ToString());
                    parameters.Add(key, flowName);
                    ++i;
                }
            }
            // Create the task transaction and queue for running, the task will run asynchronously after
            // this method returns
            return _transactionManager.QueueTask(_securityFlowName, _securityBulkAddUsersServiceName,
                                                 visit.Account.Id, parameters);
        }
        protected UserAccount Save(UserAccount instance, bool allowCreateInNaasIfNecessary, string naasCreatePassword,
                                   AdminVisit visit)
        {
            try
            {
                if ((instance == null) || string.IsNullOrEmpty(instance.NaasAccount))
                {
                    throw new ArgumentException("Input values are null.");
                }

                bool isDemoUser = IsDemoUser(instance);
                bool createInDB = string.IsNullOrEmpty(instance.Id);
                bool needToCreateInNAAS = !isDemoUser && !_naasManager.UserExists(instance.NaasAccount);

                if (needToCreateInNAAS && string.IsNullOrEmpty(naasCreatePassword))
                {
                    throw new ArgumentException("Password cannot be empty.");
                }
                if (needToCreateInNAAS && !allowCreateInNaasIfNecessary)
                {
                    throw new ArgumentException(string.Format("The user \"{0}\" does not exist in NAAS", instance.NaasAccount));
                }

                string activityFormatString;
                if (createInDB)
                {
                    if (needToCreateInNAAS)
                    {
                        activityFormatString = "{0} created user account on this local node and within NAAS: {1}.";
                    }
                    else
                    {
                        activityFormatString = "{0} created user account on this local node: {1}.";
                    }
                }
                else
                {
                    if (needToCreateInNAAS)
                    {
                        activityFormatString = "{0} saved user account on this local node and created account within NAAS: {1}.";
                    }
                    else
                    {
                        activityFormatString = "{0} saved user account on this local node: {1}.";
                    }
                }

                string naasPassword = null;
                if (needToCreateInNAAS)
                {
                    // First, attempt to create the user in NAAS
                    naasPassword = _naasManager.CreateUser(instance.NaasAccount, naasCreatePassword,
                                                           instance.Role);
                }

                instance.ModifiedById = visit.Account.Id;
                TransactionTemplate.Execute(delegate
                {
                    _accountDao.Save(instance);
                    if (isDemoUser)
                    {
                        _accountDao.ResetPassword(instance.NaasAccount, naasCreatePassword);
                    }
                    ActivityManager.LogAudit(NodeMethod.None, null, visit, activityFormatString,
                                             visit.Account.NaasAccount, instance.ToString());
                    return null;
                });

                if (needToCreateInNAAS)
                {
                    _notificationManager.DoNewNaasAccountNotifications(instance.NaasAccount,
                                                                       naasCreatePassword);
                }
                else if (createInDB)
                {
                    _notificationManager.DoNewNodeAccountNotifications(instance.NaasAccount);
                }
                return instance;
            }
            catch (Exception e)
            {
                ActivityManager.LogError(NodeMethod.None, null, e, visit, "{0} failed to save user account: {1}.",
                                         visit.Account.NaasAccount, instance.ToString());
                throw;
            }
        }
        public bool IsDemoNode { get { return _settingsProvider.IsDemoNode; } }

        public string GenerateRandomPassword()
        {
            return "Password_" + Math.Abs(Guid.NewGuid().GetHashCode()).ToString();
        }
        public UserAccount ResetPassword(UserAccount instance, AdminVisit visit)
        {
            try
            {
                ValidateByRoleAndNotDemoAccount(visit, SystemRoleType.Admin);

                string newPassword = GenerateRandomPassword();

                bool isDemoUser = IsDemoUser(instance);
                if (!isDemoUser)
                {
                    _naasManager.ResetPassword(instance.NaasAccount, newPassword);
                }
                else
                {
                    _accountDao.ResetPassword(instance.NaasAccount, newPassword);
                }

                ActivityManager.LogAudit(NodeMethod.None, null, visit, "{0} reset password for user account: {1}.",
                                         visit.Account.NaasAccount, instance.ToString());

                _notificationManager.DoChangePasswordNotifications(instance.NaasAccount, newPassword);

                return instance;
            }
            catch (Exception e)
            {
                ActivityManager.LogError(NodeMethod.None, null, e, visit, "{0} failed to reset password for user account: {1}.",
                                         visit.Account.NaasAccount, instance.ToString());
                throw;
            }
        }

        public UserAccount ResetPassword(string currentPassword, string newPassword,
                                         UserAccount instance, AdminVisit visit)
        {
            try
            {
                ValidateByRole(visit, SystemRoleType.Program);

                bool isDemoUser = IsDemoUser(instance);
                if (!isDemoUser)
                {
                    _naasManager.ChangePassword(instance.NaasAccount, currentPassword,
                                                newPassword);
                }
                else
                {
                    _accountDao.ChangePassword(instance.NaasAccount, currentPassword, newPassword);
                }

                ActivityManager.LogAudit(NodeMethod.None, null, visit, "{0} reset password for user account: {1}.",
                                         visit.Account.NaasAccount, instance.ToString());

                return instance;
            }
            catch (Exception e)
            {
                ActivityManager.LogError(NodeMethod.None, null, e, visit, "{0} failed to reset password for user account: {1}.",
                                         visit.Account.NaasAccount, instance.ToString());
                throw;
            }
        }

        public UserAccount Get(string username, AdminVisit visit)
        {
            try
            {
                ValidateByRole(visit, SystemRoleType.Program);

                UserAccount account = _accountDao.GetByName(username);
                if (account == null)
                {
                    throw new ArgumentException(string.Format("The user \"{0}\" was not found in the database", username));
                }
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

        public UserAccount GetById(string id, AdminVisit visit)
        {
            try
            {
                ValidateByRole(visit, SystemRoleType.Program);
                UserAccount account = _accountDao.GetById(id);
                ActivityManager.LogAudit(NodeMethod.None, null, visit, "{0} got user account: {1}.",
                                         visit.Account.NaasAccount, account.ToString());
                return account;
            }
            catch (Exception e)
            {
                ActivityManager.LogError(NodeMethod.None, null, e, visit, "{0} failed to get user account: {1}.",
                                         visit.Account.NaasAccount, id);
                throw;
            }
        }

        public IList<UserAccount> Get(AdminVisit visit)
        {
            try
            {
                ValidateByRole(visit, SystemRoleType.Program);
                IList<UserAccount> accounts = _accountDao.Get();
                ActivityManager.LogAudit(NodeMethod.None, null, visit, "{0} got all user accounts.",
                                         visit.Account.NaasAccount);
                return accounts;
            }
            catch (Exception e)
            {
                ActivityManager.LogError(NodeMethod.None, null, e, visit, "{0} failed to get all user accounts.",
                                         visit.Account.NaasAccount);
                throw;
            }
        }

        public void Delete(UserAccount instance, AdminVisit visit)
        {
            try
            {
                ValidateByRoleAndNotDemoAccount(visit, SystemRoleType.Admin);
                if (!CanDeleteUser(instance.NaasAccount, visit))
                {
                    throw new InvalidOperationException(string.Format("The user \"{0}\" cannot be deleted from the node",
                                                                      instance.NaasAccount));
                }
                bool isDemoUser = IsDemoUser(instance);
                bool deleteFromNAAS = !isDemoUser && _naasManager.UserExists(instance.NaasAccount);
                if (deleteFromNAAS)
                {
                    _naasManager.DeleteUser(instance.NaasAccount);
                }
                TransactionTemplate.Execute(delegate
                {
                    _accountDao.Delete(instance);
                    ActivityManager.LogAudit(NodeMethod.None, null, visit, "{0} deleted account: {1}.",
                                             visit.Account.NaasAccount, instance.ToString());
                    return null;
                });
            }
            catch (Exception e)
            {
                ActivityManager.LogError(NodeMethod.None, null, e, visit, "{0} failed to delete user account: {1}.",
                                         visit.Account.NaasAccount, instance.ToString());
                throw;
            }
        }
        public string GetUsernameById(string userId)
        {
            return _accountDao.GetUsernameById(userId);
        }
        public void ValidateUserMinimumRole(AdminVisit visit, SystemRoleType minimumRole)
        {
            AccountManager.ValidateByRole(visit, minimumRole);
        }
        #region Properties
        public IAccountDao AccountDao
        {
            get { return _accountDao; }
            set { _accountDao = value; }
        }
        public UserAccount AdminAccount
        {
            get { return _adminAccount; }
            set { _adminAccount = value; }
        }
        public string AdminUserName
        {
            get { return _adminUserName; }
            set { _adminUserName = value; }
        }
        public UserAccount RuntimeAccount
        {
            get { return _runtimeAccount; }
            set { _runtimeAccount = value; }
        }
        public string RuntimeUserName
        {
            get { return _runtimeUserName; }
            set { _runtimeUserName = value; }
        }
        public INAASManagerEx NAASManager
        {
            get { return _naasManager; }
            set { _naasManager = value; }
        }
        public INotificationManager NotificationManager
        {
            get { return _notificationManager; }
            set { _notificationManager = value; }
        }
        protected ITransactionManagerEx TransactionManager
        {
            get { return _transactionManager; }
            set { _transactionManager = value; }
        }
        public string SecurityFlowName
        {
            get { return _securityFlowName; }
            set { _securityFlowName = value; }
        }
        public string SecurityBulkAddUsersServiceName
        {
            get { return _securityBulkAddUsersServiceName; }
            set { _securityBulkAddUsersServiceName = value; }
        }
        public IPolicyService AccountPolicyManager
        {
            get { return _accountPolicyManager; }
            set { _accountPolicyManager = value; }
        }
        #endregion
    }
}
