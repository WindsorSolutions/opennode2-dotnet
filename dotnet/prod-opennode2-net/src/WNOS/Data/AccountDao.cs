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
using System.Diagnostics;

using Spring.Data.Generic;
using Spring.Data.Common;


using Common.Logging;

using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSUtility;
using Windsor.Node2008.WNOSProviders;
using Windsor.Commons.Core;

namespace Windsor.Node2008.WNOS.Data
{
    public class AccountDao : BaseDao, IAccountDao
    {
        public const string TABLE_NAME = "NAccount";
        public const string POLICY_TABLE_NAME = "NAccountPolicy";
        private ICryptographyProvider _cryptographyProvider;
        private IFlowDao _flowDao;

        #region Init

        new public void Init()
        {
            base.Init();

            FieldNotInitializedException.ThrowIfNull(this, ref _cryptographyProvider);
            FieldNotInitializedException.ThrowIfNull(this, ref _flowDao);

            MAP_USER_ACCOUNT_COLUMNS = "Id;NAASAccount;IsActive;SystemRole;ModifiedBy;ModifiedOn";
            if (IsDemoNode)
            {
                MAP_USER_ACCOUNT_COLUMNS += ";IsDemoUser";
            }
        }

        #endregion

        #region Mappers

        public IFlowDao FlowDao
        {
          get { return _flowDao; }
          set { _flowDao = value; }
        }

        private string MAP_USER_ACCOUNT_COLUMNS;
        private UserAccount MapUserAccount(IDataReader reader)
        {
            UserAccount account = new UserAccount();
            int index = 0;
            account.Id = reader.GetString(index++);
            account.NaasAccount = reader.GetString(index++);
            account.IsActive = DbUtils.ToBool(reader.GetString(index++));
            account.Role = EnumUtils.ParseEnum<SystemRoleType>(reader.GetString(index++));
            account.ModifiedById = reader.GetString(index++);
            account.ModifiedOn = reader.GetDateTime(index++);
            if (IsDemoNode)
            {
                account.IsDemoUser = reader.IsDBNull(index) ? new bool?(false) : new bool?(DbUtils.ToBool(reader.GetString(index)));
                index++;
            }
            return account;
        }
        private const string MAP_USER_ACCOUNT_POLICY_COLUMNS = "Id;AccountId;Type;Qualifier;IsAllowed;ModifiedBy;ModifiedOn";
        private UserAccessPolicy MapUserAccountPolicy(IDataReader reader)
        {
            UserAccessPolicy policy = new UserAccessPolicy();
            int index = 0;
            policy.Id = reader.GetString(index++);
            policy.AccountId = reader.GetString(index++);
            policy.PolicyType = EnumUtils.ParseEnum<ServiceRequestAuthorizationType>(reader.GetString(index++));
            policy.TypeQualifier = reader.GetString(index++);
            string isAllowed = reader.GetString(index++);
            switch (isAllowed)
            {
                case "Y": policy.FlowRoleType = FlowRoleType.Endpoint; break;
                case "V": policy.FlowRoleType = FlowRoleType.View; break;
                case "M": policy.FlowRoleType = FlowRoleType.Modify; break;
                default: policy.FlowRoleType = FlowRoleType.None; break;
            }
            policy.ModifiedById = reader.GetString(index++);
            policy.ModifiedOn = reader.GetDateTime(index++);
            return policy;
        }
        private void PostMapUserAccount(UserAccount userAccount, ICollection<string> flowNames)
        {
            if (userAccount.Role != SystemRoleType.Admin)
            {
                userAccount.Policies = GetAccountPolicies(userAccount.Id, flowNames);
            }
        }
        private void PostMapUserAccounts(IEnumerable<UserAccount> userAccounts,
                                         ICollection<string> flowNames)
        {
            if (userAccounts != null)
            {
                foreach (UserAccount userAccount in userAccounts)
                {
                    PostMapUserAccount(userAccount, flowNames);
                }
            }
        }
        private IList<UserAccessPolicy> GetAccountPolicies(string accountId, ICollection<string> flowNames)
        {
            SortableCollection<UserAccessPolicy> policies = null;
            DoSimpleQueryWithRowCallbackDelegate(
                POLICY_TABLE_NAME, "AccountId", accountId, null,
                MAP_USER_ACCOUNT_POLICY_COLUMNS,
                delegate(IDataReader reader)
                {
                    if (policies == null)
                    {
                        policies = new SortableCollection<UserAccessPolicy>();
                    }
                    policies.Add(MapUserAccountPolicy(reader));
                    FilterPoliciesToCurrentFlows(policies, flowNames);
                });
            return policies;
        }
        #endregion

        #region Methods

        protected void FilterPoliciesToCurrentFlows(SortableCollection<UserAccessPolicy> policies,
                                                    ICollection<string> flowNames)
        {
            if (CollectionUtils.IsNullOrEmpty(policies))
            {
                return;
            }
            for (int i = policies.Count - 1; i >= 0; --i)
            {
                UserAccessPolicy policy = policies[i];
                if (policy.PolicyType == ServiceRequestAuthorizationType.Flow)
                {
                    if ( !CollectionUtils.Contains(flowNames, policy.TypeQualifier, 
                                                   StringComparison.InvariantCultureIgnoreCase))
                    {
                        policies.RemoveAt(i);
                    }
                }
            }
        }
        public void Save(UserAccount item)
        {
            if (item == null)
            {
                throw new ArgumentException("Null item");
            }
            DateTime now = DateTime.Now;
            string id = null;
#if DEBUG
            if (item.NaasAccount.StartsWith("uid="))
            {
                DebugUtils.CheckDebuggerBreak();
            }
#endif // DEBUG
            // Check to see if this user already exists
            if (string.IsNullOrEmpty(item.Id))
            {
                string existingUserId = GetUserIdByName(item.NaasAccount);
                if (existingUserId != null)
                {
                    item.Id = existingUserId;
                }
            }

            TransactionTemplate.Execute(delegate
            {
                // Update user account table
                if (string.IsNullOrEmpty(item.Id))
                {
                    id = IdProvider.Get();
                    if (IsDemoNode && (item.IsDemoUser != null))
                    {
                        DoInsert(TABLE_NAME, "Id;NAASAccount;IsActive;SystemRole;ModifiedBy;ModifiedOn;IsDeleted;IsDemoUser",
                                 id, item.NaasAccount, DbUtils.ToDbBool(item.IsActive),
                                 item.Role.ToString(), item.ModifiedById, now, DbUtils.ToDbBool(false),
                                 DbUtils.ToDbBool(item.IsDemoUser.Value));
                    }
                    else
                    {
                        DoInsert(TABLE_NAME, "Id;NAASAccount;IsActive;SystemRole;ModifiedBy;ModifiedOn;IsDeleted",
                                 id, item.NaasAccount, DbUtils.ToDbBool(item.IsActive),
                                 item.Role.ToString(), item.ModifiedById, now, DbUtils.ToDbBool(false));
                    }
                }
                else
                {
                    id = item.Id;
                    if (IsDemoNode && (item.IsDemoUser != null))
                    {
                        DoSimpleUpdateOne(TABLE_NAME, "Id", item.Id.ToString(),
                                          "NAASAccount;IsActive;SystemRole;ModifiedBy;ModifiedOn;IsDemoUser",
                                          item.NaasAccount, DbUtils.ToDbBool(item.IsActive),
                                          item.Role.ToString(), item.ModifiedById, now,
                                          DbUtils.ToDbBool(item.IsDemoUser.Value));
                    }
                    else
                    {
                        DoSimpleUpdateOne(TABLE_NAME, "Id", item.Id.ToString(),
                                          "NAASAccount;IsActive;SystemRole;ModifiedBy;ModifiedOn",
                                          item.NaasAccount, DbUtils.ToDbBool(item.IsActive),
                                          item.Role.ToString(), item.ModifiedById, now);
                    }
                }
                // Update policies
                DeleteAllPoliciesForUser(id);
                if (item.Role != SystemRoleType.Admin)
                {
                    SavePoliciesForUser(id, item.Policies);
                }
                return null;
            });
            if (string.IsNullOrEmpty(item.Id))
            {
                item.Id = id;
            }
            item.ModifiedOn = now;
        }

        public IList<UserAccount> Get()
        {
            List<UserAccount> userAccounts = new List<UserAccount>();
            DoSimpleQueryWithRowCallbackDelegate(
                TABLE_NAME, "IsDeleted", DbUtils.ToDbBool(false), null,
                MAP_USER_ACCOUNT_COLUMNS,
                delegate(IDataReader reader)
                {
                    userAccounts.Add(MapUserAccount(reader));
                });
            PostMapUserAccounts(userAccounts, FlowDao.GetAllDataFlowNames());
            return userAccounts;
        }

        public ICollection<string> GetAllUserNames()
        {
            List<string> userNames = new List<string>();
            DoSimpleQueryWithRowCallbackDelegate(
                TABLE_NAME, "IsDeleted", DbUtils.ToDbBool(false), "NAASAccount",
                "NAASAccount",
                delegate(IDataReader reader)
                {
                    userNames.Add(reader.GetString(0));
                });
            return userNames;
        }
        public IList<string> GetAuthorizedUsernamesForFlow(string flowName, FlowRoleType roleType)
        {
            if ( roleType == FlowRoleType.None )
            {
                return null;
            }
            List<string> usernames = null;
            DoSimpleQueryWithRowCallbackDelegate(
                TABLE_NAME, "SystemRole;IsActive;IsDeleted",
                new object[] { SystemRoleType.Admin.ToString(), DbUtils.ToDbBool(true), DbUtils.ToDbBool(false) }, 
                null, "NAASAccount",
                delegate(IDataReader reader)
                {
                    CollectionUtils.Add(reader.GetString(0), ref usernames);
                });
            string isAllowedQuery;
            switch(roleType)
            {
                case FlowRoleType.Modify: isAllowedQuery = "(p.IsAllowed = 'M')"; break;
                case FlowRoleType.View: isAllowedQuery = "(p.IsAllowed = 'M' OR p.IsAllowed = 'V')"; break;
                default: isAllowedQuery = "(p.IsAllowed = 'M' OR p.IsAllowed = 'V' OR p.IsAllowed = 'Y')"; break;
            }
            isAllowedQuery = string.Format("(UPPER(a.SystemRole) != UPPER('{0}') AND {1})", SystemRoleType.Admin.ToString(), isAllowedQuery);
            DoSimpleQueryWithRowCallbackDelegate(
                POLICY_TABLE_NAME + " p;" + TABLE_NAME + " a", "p.Qualifier;a.IsActive;a.IsDeleted;" + isAllowedQuery + ";p.Type = 'Flow';p.AccountId = a.Id",
                new object[] { flowName, DbUtils.ToDbBool(true), DbUtils.ToDbBool(false) }, null, "DISTINCT a.NAASAccount",
                delegate(IDataReader reader)
                {
                    CollectionUtils.Add(reader.GetString(0), ref usernames);
                });
            return usernames;
        }
        public IDictionary<string, string> GetUserIdToNameMap(bool includeDeletedUsers,
                                                              string deletedNameSuffix)
        {
            Dictionary<string, string> map = new Dictionary<string, string>();
            if (includeDeletedUsers)
            {
                DoSimpleQueryWithRowCallbackDelegate(
                    TABLE_NAME, null, null, null,
                    "IsDeleted,NAASAccount,Id",
                    delegate(IDataReader reader)
                    {
                        bool isDeleted = DbUtils.ToBool(reader.GetString(0));
                        string username = reader.GetString(1);
                        if (isDeleted)
                        {
                            username = CleanDeletedName(username);
                            if (!string.IsNullOrEmpty(deletedNameSuffix))
                            {
                                username += deletedNameSuffix;
                            }
                        }
                        map.Add(reader.GetString(2), username);
                    });
            }
            else
            {
                DoSimpleQueryWithRowCallbackDelegate(
                    TABLE_NAME, "IsDeleted", DbUtils.ToDbBool(false), null,
                    "Id,NAASAccount",
                    delegate(IDataReader reader)
                    {
                        map.Add(reader.GetString(0), reader.GetString(1));
                    });
            }
            return map;
        }

        public UserAccount GetById(string id)
        {
            try
            {
                UserAccount userAccount =
                    DoSimpleQueryForObjectDelegate<UserAccount>(
                        TABLE_NAME, "Id;IsDeleted", new object[] { id, DbUtils.ToDbBool(false) },
                        MAP_USER_ACCOUNT_COLUMNS,
                        delegate(IDataReader reader, int rowNum)
                        {
                            return MapUserAccount(reader);
                        });
                PostMapUserAccount(userAccount, FlowDao.GetAllDataFlowNames());
                return userAccount;
            }
            catch (Spring.Dao.IncorrectResultSizeDataAccessException)
            {
                return null; // Not found
            }
        }
        public bool IsValidDemoUser(string username, string password, out bool isDemoUser)
        {
            isDemoUser = false;
            if (!IsDemoNode)
            {
                return false;
            }
            try
            {
                string passwordHash =
                    DoSimpleQueryForObjectDelegate<string>(
                        TABLE_NAME, "NAASAccount;IsDeleted;IsDemoUser",
                        new object[] { username, DbUtils.ToDbBool(false), DbUtils.ToDbBool(true) },
                        "PasswordHash",
                        delegate(IDataReader reader, int rowNum)
                        {
                            return reader.GetString(0);
                        });
                isDemoUser = true;
                if (string.IsNullOrEmpty(passwordHash))
                {
                    return false;
                }
                return _cryptographyProvider.IsValueCorrect(password, passwordHash);
            }
            catch (Spring.Dao.IncorrectResultSizeDataAccessException)
            {
                return false; // Not found
            }
        }
        public void ResetPassword(string userName, string newPassword)
        {
            string passwordHash = _cryptographyProvider.CreateValueHash(newPassword);
            DoSimpleUpdateOne(TABLE_NAME, "NAASAccount", userName,
                              "PasswordHash", passwordHash);
        }
        public void ChangePassword(string userName, string currentPassword, string newPassword)
        {
            string currentHash = GetUserPasswordHash(userName);
            if (!_cryptographyProvider.IsValueCorrect(currentPassword, currentHash))
            {
                throw new ArgumentException("Current password is not valid");
            }
            ResetPassword(userName, newPassword);
        }

        protected string GetUserPasswordHash(string username)
        {
            try
            {
                string passwordHash =
                    DoSimpleQueryForObjectDelegate<string>(
                        TABLE_NAME, "NAASAccount;IsDeleted", new object[] { username, DbUtils.ToDbBool(false) },
                        "PasswordHash",
                        delegate(IDataReader reader, int rowNum)
                        {
                            return reader.GetString(0);
                        });
                return !string.IsNullOrEmpty(passwordHash) ? passwordHash : null;
            }
            catch (Spring.Dao.IncorrectResultSizeDataAccessException)
            {
                return null; // Not found
            }
        }
        public bool UserPasswordExistsInDB(string username)
        {
            return (GetUserPasswordHash(username) != null);
        }
        public string GetUsernameById(string id)
        {
            try
            {
                string username =
                    DoSimpleQueryForObjectDelegate<string>(
                        TABLE_NAME, "Id;IsDeleted", new object[] { id, DbUtils.ToDbBool(false) },
                        "NAASAccount",
                        delegate(IDataReader reader, int rowNum)
                        {
                            return reader.GetString(0);
                        });
                return username;
            }
            catch (Spring.Dao.IncorrectResultSizeDataAccessException)
            {
                return null; // Not found
            }
        }
        public string GetUserIdByName(string username)
        {
            try
            {
                string id =
                    DoSimpleQueryForObjectDelegate<string>(
                        TABLE_NAME, "NAASAccount;IsDeleted", new object[] { username, DbUtils.ToDbBool(false) },
                        "Id",
                        delegate(IDataReader reader, int rowNum)
                        {
                            return reader.GetString(0);
                        });
                return id;
            }
            catch (Spring.Dao.IncorrectResultSizeDataAccessException)
            {
                return null; // Not found
            }
        }

        /// <summary>
        /// This must allow for null results thus we can't use the QueryForObject
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public UserAccount GetByName(string username)
        {
            try
            {
                UserAccount userAccount =
                    DoSimpleQueryForObjectDelegate<UserAccount>(
                        TABLE_NAME, "NAASAccount;IsDeleted", new object[] { username, DbUtils.ToDbBool(false) },
                        MAP_USER_ACCOUNT_COLUMNS,
                        delegate(IDataReader reader, int rowNum)
                        {
                            return MapUserAccount(reader);
                        });
                PostMapUserAccount(userAccount, FlowDao.GetAllDataFlowNames());
                return userAccount;
            }
            catch (Spring.Dao.IncorrectResultSizeDataAccessException)
            {
                return null; // Not found
            }
        }
        private static string MakeDeletedName(string username)
        {
            return username + "__" + Guid.NewGuid().ToString();
        }
        private static string CleanDeletedName(string username)
        {
            int index = username.LastIndexOf("__");
            if (index > 0)
            {
                return username.Substring(0, index);
            }
            return username;
        }
        public void Delete(UserAccount account)
        {
            string deletedName = MakeDeletedName(account.NaasAccount);
            DoSimpleUpdateOne(TABLE_NAME, "Id", account.Id,
                              "NAASAccount;ModifiedBy;ModifiedOn;IsDeleted",
                              deletedName, account.ModifiedById, DateTime.Now,
                              DbUtils.ToDbBool(true));
        }
        private void DeleteAllPoliciesForUser(string accountId)
        {
            DoSimpleDelete(POLICY_TABLE_NAME, "AccountId", new object[] { accountId });
        }
        private void SavePoliciesForUser(string accountId, IList<UserAccessPolicy> policies)
        {
            if (CollectionUtils.IsNullOrEmpty(policies))
            {
                return;
            }
            DateTime now = DateTime.Now;
            object[] insertValues = new object[7];
            DoBulkInsert(POLICY_TABLE_NAME, "Id;AccountId;Type;Qualifier;IsAllowed;ModifiedBy;ModifiedOn",
                 delegate(int currentInsertIndex)
                 {
                     if (currentInsertIndex < policies.Count)
                     {
                         UserAccessPolicy policy = policies[currentInsertIndex];
                         if (string.IsNullOrEmpty(policy.Id))
                         {
                             policy.Id = IdProvider.Get();
                             policy.ModifiedOn = now;
                         }
                         else if (policy.ModifiedOn == default(DateTime))
                         {
                             policy.ModifiedOn = now;
                         }
                         policy.AccountId = accountId;
                         insertValues[0] = policy.Id;
                         insertValues[1] = policy.AccountId;
                         insertValues[2] = policy.PolicyType.ToString();
                         insertValues[3] = policy.TypeQualifier;
                         switch (policy.FlowRoleType)
                         {
                             case FlowRoleType.Endpoint: insertValues[4] = "Y"; break;
                             case FlowRoleType.View: insertValues[4] = "V"; break;
                             case FlowRoleType.Modify: insertValues[4] = "M"; break;
                             default: insertValues[4] = "N"; break;
                         }
                         insertValues[5] = policy.ModifiedById;
                         insertValues[6] = policy.ModifiedOn;
                         return insertValues;
                     }
                     else
                     {
                         return null;
                     }
                 });
        }

        public bool IsDemoNode { get { return SettingsProvider.IsDemoNode; } }
        #endregion

        #region Properties

        public ICryptographyProvider CryptographyProvider
        {
            get { return _cryptographyProvider; }
            set { _cryptographyProvider = value; }
        }

        #endregion

        #region IAccountDao Members


        private const string SQL_ACIVE_USERS =
              "SELECT a.NAASAccount, COUNT(*) AS ActivityCount "
            + "FROM   NActivity l "
            + "INNER JOIN NAccount a ON l.ModifiedBy = a.Id AND a.IsDeleted = 'N' "
            + "GROUP BY a.NAASAccount "
            + "ORDER BY 2 DESC";


        /// <summary>
        /// Gets the most active users as recorded in the activity table
        /// </summary>
        /// <param name="maxCount"></param>
        /// <returns></returns>
        public Dictionary<string, string> GetMostActiveUsers(int maxCount)
        {
            Dictionary<string, string> list = new Dictionary<string, string>();
            int recordCount = 0;

            AdoTemplate.QueryWithRowCallbackDelegate(CommandType.Text, SQL_ACIVE_USERS,
                delegate(IDataReader reader)
                {
                    //Yes, we could do it all in SQL but there is no clean way to do it in a db-agnostic way
                    //We are talking max of 10-20 users here
                    if (recordCount < maxCount)
                    {
                        list.Add(reader.GetString(0), reader.GetInt32(1).ToString());
                        recordCount++;
                    }
                }
            );

            return list;


        }

        #endregion
    }
}
