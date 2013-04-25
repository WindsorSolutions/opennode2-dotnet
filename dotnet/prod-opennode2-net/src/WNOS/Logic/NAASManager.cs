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
using System.Net;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSConnector.Logic;
using Windsor.Node2008.WNOSUtility;
using Windsor.Node2008.WNOS.Data;
using System.Web.Services.Protocols;
using System.Security.Authentication;
using Windsor.Commons.Core;
using Wintellect.PowerCollections;
using Windsor.Commons.Logging;
using Windsor.Commons.NodeDomain;

using NAAS_CLIENT = Windsor.Commons.NAASClient;
using NAAS_USRMGR = Windsor.Commons.NAASClient.NAASUserMgr;

namespace Windsor.Node2008.WNOS.Logic
{
    public class NAASManager : LoggerBase, INAASManagerEx
    {
        private static readonly string DEFAULT_AUTH_METHOD = "password";
        private static readonly NAAS_CLIENT.DomainTypeCode DEFAULT_DOMAIN_TYPE =
            NAAS_CLIENT.DomainTypeCode.@default;
        private const string FLOW_PREFEX = "data_flow_";

        private TimeSpan _cacheNaasUsernamesDuration = TimeSpan.FromHours(24);
        private bool _bypassNaasAuthenticateFailures;
        private string _bypassNaasUserName = "naasAuthenticateFailed@whatsupnass.com";

        private readonly Windsor.Commons.NAASClient.NAASClient _naasClient;
        private readonly Windsor.Commons.NAASClient.NAASClient _testNaasClient;
        private readonly Windsor.Commons.NAASClient.NAASClient _prodNaasClient;
        private Windsor.Commons.NAASClient.IUserMgr _usermgrClient;

        private readonly AuthenticationCredentials _naasRuntimeCredential;
        private readonly NAAS_CLIENT.DomainTypeCode _naasRuntimeCredentialDomain;
        private readonly AuthenticationCredentials _usermgrRuntimeCredential;
        private readonly NAAS_USRMGR.DomainTypeCode _usermgrRuntimeCredentialDomain;
        private string _nodeId;
        private string _defaultRequestIp;
        private IObjectCacheDao _objectCacheDao;
        private const string CACHE_NAAS_USER_ACCOUNTS = "CACHE_NAAS_USERNAMES";

        /// <summary>
        /// NAASAccountAuthenticationProvider
        /// </summary>
        /// <param name="endpointUrl"></param>
        /// <param name="runtimeCredentials"></param>
        public NAASManager(string testUrl, string prodUrl, bool isProduction,
                           string defaultRequestIp,
                           AuthenticationCredentials naasRuntimeCredentials,
                           AuthenticationCredentials usermgrRuntimeCredentials)
        {

            if (string.IsNullOrEmpty(testUrl))
            {
                throw new ArgumentNullException("testUrl");
            }
            if (string.IsNullOrEmpty(prodUrl))
            {
                throw new ArgumentNullException("prodUrl");
            }
            if (string.IsNullOrEmpty(defaultRequestIp))
            {
                throw new ArgumentNullException("defaultRequestIp");
            }
            if (!testUrl.StartsWith("https://", StringComparison.InvariantCultureIgnoreCase))
            {
                throw new ArgumentException("Invalid protocol. Must be HTTPS: " + testUrl);
            }
            if (!prodUrl.StartsWith("https://", StringComparison.InvariantCultureIgnoreCase))
            {
                throw new ArgumentException("Invalid protocol. Must be HTTPS: " + prodUrl);
            }
            if (naasRuntimeCredentials == null ||
                string.IsNullOrEmpty(naasRuntimeCredentials.UserName) ||
                string.IsNullOrEmpty(naasRuntimeCredentials.Password))
            {
                throw new ArgumentException("Null naasRuntimeCredentials. Username and Password are required");
            }
            if (string.IsNullOrEmpty(naasRuntimeCredentials.Domain))
            {
                _naasRuntimeCredentialDomain = NAAS_CLIENT.DomainTypeCode.@default;
            }
            else
            {
                _naasRuntimeCredentialDomain = (NAAS_CLIENT.DomainTypeCode)
                    Enum.Parse(typeof(NAAS_CLIENT.DomainTypeCode),
                    naasRuntimeCredentials.Domain, true);
            }
            if (usermgrRuntimeCredentials == null ||
                string.IsNullOrEmpty(usermgrRuntimeCredentials.UserName) ||
                string.IsNullOrEmpty(usermgrRuntimeCredentials.Password))
            {
                throw new ArgumentException("Null usermgrRuntimeCredentials. Username and Password are required");
            }
            if (string.IsNullOrEmpty(usermgrRuntimeCredentials.Domain))
            {
                _usermgrRuntimeCredentialDomain = NAAS_USRMGR.DomainTypeCode.@default;
            }
            else
            {
                _usermgrRuntimeCredentialDomain = (NAAS_USRMGR.DomainTypeCode)
                    Enum.Parse(typeof(NAAS_USRMGR.DomainTypeCode),
                    usermgrRuntimeCredentials.Domain, true);
            }
            _testNaasClient = new Windsor.Commons.NAASClient.NAASClient(testUrl);
            _prodNaasClient = new Windsor.Commons.NAASClient.NAASClient(prodUrl);
            _naasClient = isProduction ? _prodNaasClient : _testNaasClient;
            _naasRuntimeCredential = naasRuntimeCredentials;
            _usermgrRuntimeCredential = usermgrRuntimeCredentials;
            _defaultRequestIp = defaultRequestIp;
        }

        #region Authenticate

        /// <summary>
        /// Authenticate user NAAS credentials
        /// </summary>
        /// <param name="credential">NAAS Credentials</param>
        /// <param name="clientHostIP">IP address of the orginal requestor</param>
        /// <returns>NAAS Token</returns>
        public string AuthenticateUser(AuthenticationCredentials credential, string clientHostIP,
                                       string authenticationMethod)
        {
            if (credential == null)
            {
                throw new ArgumentException("Null credential");
            }

            return AuthenticateUser(
                credential.UserName,
                credential.Password,
                clientHostIP,
                authenticationMethod);
        }

        /// <summary>
        /// Authenticate user NAAS credentials
        /// </summary>
        /// <param name="username">NAAS Username</param>
        /// <param name="password">NAAS Password</param>
        /// <param name="clientHostIp">IP address of the orginal requestor</param>
        /// <returns>NAAS Token</returns>
        public string AuthenticateUser(
            string username,
            string password,
            string clientHostIp)
        {

            return AuthenticateUser(
                username,
                password,
                clientHostIp,
                DEFAULT_AUTH_METHOD);
        }

        /// <summary>
        /// Authenticate user NAAS credentials
        /// </summary>
        /// <param name="username">NAAS Username</param>
        /// <param name="password">NAAS Password</param>
        /// <param name="clientHostIp">IP address of the orginal requestor</param>
        /// <param name="authenticationMethod">one of the authentication methods supported by naas [password]</param>
        /// <returns></returns>
        public string AuthenticateUser(
            string username,
            string password,
            string clientHostIP,
            string authenticationMethod)
        {

            return AuthenticateUser(username, password, clientHostIP, authenticationMethod, _naasClient);
        }

        /// <summary>
        /// Authenticate user NAAS credentials
        /// </summary>
        /// <param name="username">NAAS Username</param>
        /// <param name="password">NAAS Password</param>
        /// <param name="clientHostIp">IP address of the orginal requestor</param>
        /// <param name="authenticationMethod">one of the authentication methods supported by naas [password]</param>
        /// <returns></returns>
        protected string AuthenticateUser(
            string username,
            string password,
            string clientHostIP,
            string authenticationMethod,
            Windsor.Commons.NAASClient.NAASClient naasClient)
        {

            try
            {
                NAAS_CLIENT.CentralAuth req = new NAAS_CLIENT.CentralAuth();
                req.authenticationMethod = authenticationMethod;
                req.clientIp = clientHostIP;
                req.credential = password;
                //Once we see this being used we can refactor. For now just use the default.
                req.domain = DEFAULT_DOMAIN_TYPE;
                req.resourceURI = string.Empty;
                req.userId = username;

                NAAS_CLIENT.CentralAuthResponse resp = naasClient.CentralAuth(req);

                string token = resp.@return;

                if (string.IsNullOrEmpty(token))
                {
                    throw new ApplicationException("NAAS Returned an empty token");
                }

                return token;

            }
            catch (SoapException soapException)
            {
#if DEBUG
                if (BypassNaasAuthenticateFailures)
                {
                    return _bypassNaasUserName;
                }
#endif // DEBUG
                LOG.Error("NAAS authentication error", soapException);
                throw new InvalidCredentialException("NAAS authentication error: " + soapException.Message);
            }
            catch (Exception naasException)
            {
#if DEBUG
                if (BypassNaasAuthenticateFailures)
                {
                    return _bypassNaasUserName;
                }
#endif // DEBUG
                LOG.Error("NAAS connection error", naasException);
                throw new AuthenticationException("NAAS connection error: " + naasException.Message);
            }

        }
        public void ValidateUsernameAndPassword(string username, string password, bool isTestNAASUser)
        {

            AuthenticateUser(
                username,
                password,
                _defaultRequestIp,
                DEFAULT_AUTH_METHOD,
                isTestNAASUser ? _testNaasClient : _prodNaasClient);
        }
        #endregion


        #region Validate

        /// <summary>
        /// Validate NAAS token
        /// </summary>
        /// <param name="securityToken"></param>
        /// <param name="clientHostIP"></param>
        /// <returns></returns>
        public string Validate(
            string securityToken,
            string clientHostIP)
        {

            return Validate(securityToken, clientHostIP, NodeMethod.None, null, null);
        }
        /// <summary>
        /// Validate NAAS token
        /// </summary>
        /// <param name="securityToken"></param>
        /// <param name="clientHostIP"></param>
        /// <returns></returns>
        public string Validate(
            string securityToken,
            string clientHostIP,
            NodeMethod method,
            string flowCode)
        {

            return Validate(securityToken, clientHostIP, method, flowCode, null);
        }
        /// <summary>
        /// Validate NAAS token
        /// </summary>
        /// <param name="securityToken"></param>
        /// <param name="clientHostIP"></param>
        /// <returns></returns>
        public string Validate(
            string securityToken,
            string clientHostIP,
            NodeMethod method)
        {

            return Validate(securityToken, clientHostIP, method, null, null);
        }
        /// <summary>
        /// Validate NAAS token
        /// </summary>
        /// <param name="securityToken"></param>
        /// <param name="clientHostIP"></param>
        /// <returns></returns>
        public string Validate(
            string securityToken,
            string clientHostIP,
            NodeMethod method,
            string flowCode, string serviceName)
        {
            try
            {

                NAAS_CLIENT.Validate req = new NAAS_CLIENT.Validate();
                req.clientIp = clientHostIP;
                req.credential = _naasRuntimeCredential.Password;
                req.domain = _naasRuntimeCredentialDomain;
                req.securityToken = securityToken;
                req.userId = _naasRuntimeCredential.UserName;
                if (method == NodeMethod.None)
                {
                    req.resourceURI = string.Empty;
                }
                else
                {
                    // TODO: Need to format req.resourceURI based upon input flowCode and serviceName
                    req.resourceURI = string.Format(
                        "{0}?node={1}&method={2}&request={3}&params={4}",
                        "http://localhost/Node2008Endpoint/Service.asmx",
                        NodeId,
                        method.ToString().ToLower(),
                        string.IsNullOrEmpty(serviceName) ? "any" : serviceName.ToLower().Trim(),
                        string.IsNullOrEmpty(flowCode) ? "any" : MakeFlowPolicyArg(flowCode));
                    throw new NotImplementedException("TODO: Needs to be implemented");
                }
                NAAS_CLIENT.ValidateResponse resp = _naasClient.Validate(req);

                string account = resp.@return;

                if (string.IsNullOrEmpty(account))
                {
                    throw new ApplicationException("NAAS Returned an empty account");
                }

                return CleanUpNAASReturnedAccountName(account);

            }
            catch (Exception ex)
            {
#if DEBUG
                if (BypassNaasAuthenticateFailures)
                {
                    return _bypassNaasUserName;
                }
#endif // DEBUG
                throw new ApplicationException("Invalid token", ex);
            }

        }

        public static string MakeFlowPolicyArg(string flowName)
        {
            return string.Format("{0}{1}", FLOW_PREFEX, flowName).ToLower();
        }
        public static string CleanUpNAASReturnedAccountName(string naasAccount)
        {
            // Sometimes NAAS returns a string from Validate() that looks like:
            // uid=demo@windsorsolutions.com&auth=password&domain=default&ip=127.0.0.1&node=MO&group=u
            // If we get this type of returned account name, clean it up here to parse
            // out the correct email address
            if (!ValidationHelper.IsValidSingleEmailStrict(naasAccount))
            {
                int startIndex = naasAccount.IndexOf("uid=", StringComparison.InvariantCultureIgnoreCase);
                if (startIndex >= 0)
                {
                    startIndex += 4;
                    if (startIndex < naasAccount.Length)
                    {
                        int endIndex = naasAccount.IndexOf('&', startIndex);
                        if (endIndex < 0)
                        {
                            endIndex = naasAccount.Length - 1;
                        }
                        else
                        {
                            endIndex--;
                        }
                        if (startIndex < endIndex)
                        {
                            string emailAddress = naasAccount.Substring(startIndex, endIndex - startIndex + 1);
                            if (ValidationHelper.IsValidSingleEmailStrict(emailAddress) || (emailAddress == "cdx"))
                            {
                                return emailAddress;
                            }
                        }
                    }
                }
            }
            return naasAccount;
        }

        private void InvalidateCachedUserAccounts()
        {
            _objectCacheDao.RemoveObject(CACHE_NAAS_USER_ACCOUNTS);
        }
        public void ResetPassword(string username, string newPassword)
        {
            NAAS_USRMGR.UserAccountType userAccount = GetUserAccount(username);
            if (userAccount == null)
            {
                throw new ArgumentException("An account for the user \"{0}\" was not found.", username);
            }
            NAAS_USRMGR.UpdateUser updateUser = new NAAS_USRMGR.UpdateUser();
            updateUser.adminName = _usermgrRuntimeCredential.UserName;
            updateUser.credential = _usermgrRuntimeCredential.Password;
            updateUser.domain = _usermgrRuntimeCredentialDomain;
            updateUser.affiliate = userAccount.affiliate;
            updateUser.owner = userAccount.owner;
            updateUser.userId = userAccount.userId;
            updateUser.status = (NAAS_USRMGR.AccountStatusCode)
                Enum.Parse(typeof(NAAS_USRMGR.AccountStatusCode), userAccount.status);
            updateUser.userType = NAAS_USRMGR.UserTypeCode.user;
            updateUser.userPassword = newPassword;

            try
            {
                NAAS_USRMGR.UpdateUserResponse response = _usermgrClient.UpdateUser(updateUser);
            }
            catch (Exception e)
            {
                throw new ArgException("NAAS returned an error: {0}", e.Message);
            }
        }
        public bool RefreshNAASUsersIfExpired(out int numUsersRefreshed)
        {
            numUsersRefreshed = 0;
            if (_objectCacheDao.IsExpired(CACHE_NAAS_USER_ACCOUNTS))
            {
                OrderedSet<CachedUserAccountInfo> users = GetAllUserAccounts(true);
                numUsersRefreshed = users.Count;
                return true;
            }
            return false;
        }
        public void RefreshNAASUsersAlways(out int numUsersRefreshed)
        {
            OrderedSet<CachedUserAccountInfo> users = GetAllUserAccounts(true);
            numUsersRefreshed = users.Count;
        }
        private OrderedSet<CachedUserAccountInfo> GetAllCachedUserAccounts()
        {
            OrderedSet<CachedUserAccountInfo> userAccounts = null;
            _objectCacheDao.GetObject(CACHE_NAAS_USER_ACCOUNTS, true, out userAccounts);
            return userAccounts;
        }
        private OrderedSet<CachedUserAccountInfo> GetAllUserAccounts(bool forceFreshFromNaas)
        {
            OrderedSet<CachedUserAccountInfo> userAccounts = null;
            if (!forceFreshFromNaas)
            {
                if (_objectCacheDao.GetObject(CACHE_NAAS_USER_ACCOUNTS, false, out userAccounts))
                {
                    return userAccounts;
                }
            }
            const int getBatchCount = 1000;
            NAAS_USRMGR.GetUserList getUserList = new NAAS_USRMGR.GetUserList();
            getUserList.adminName = _usermgrRuntimeCredential.UserName;
            getUserList.credential = _usermgrRuntimeCredential.Password;
            getUserList.domain = _usermgrRuntimeCredentialDomain;
            getUserList.userId = string.Empty;
            getUserList.status = string.Empty;
            getUserList.affiliate = string.Empty;

            userAccounts = new OrderedSet<CachedUserAccountInfo>();
            for (int i = 0; ; )
            {
                int length = GetAllUserAccounts(getUserList, i, getBatchCount, userAccounts);
                if (length <= 0)
                {
                    break;
                }
                i += length;
            }
            _objectCacheDao.CacheObject(userAccounts, CACHE_NAAS_USER_ACCOUNTS, _cacheNaasUsernamesDuration);
            return userAccounts;
        }
        private int GetAllUserAccounts(NAAS_USRMGR.GetUserList getUserList, int startIndex, int count,
                                       OrderedSet<CachedUserAccountInfo> userAccounts)
        {
            getUserList.rowId = startIndex.ToString();
            getUserList.maxRows = count.ToString();
            NAAS_USRMGR.GetUserListResponse response = null;
            bool processedError = false;
            try
            {
                response = _usermgrClient.GetUserList(getUserList);
            }
            catch (Exception e)
            {
                processedError = true;
                if (IsNaasXmlErrorMessage(e.Message))
                {
                    if (count == 1)
                    {
                        // This is the error, skip it
                        return 1;
                    }
                    else
                    {
                        return GetAllUserAccountsXmlError(getUserList, startIndex, count, userAccounts);
                    }
                }
                else
                {
                    throw;
                }
            }

            if (!processedError)
            {
                if (response.@return.Length == 0)
                {
                    return 0;
                }
                foreach (NAAS_USRMGR.UserAccountType userAcct in response.@return)
                {
                    userAccounts.Add(new CachedUserAccountInfo(userAcct));
                }
                return response.@return.Length;
            }
            return 0;
        }
        private static bool IsNaasXmlErrorMessage(string exMessage)
        {
            return (exMessage.IndexOf("error in xml document", StringComparison.InvariantCultureIgnoreCase) >= 0);
        }
        private int GetAllUserAccountsXmlError(NAAS_USRMGR.GetUserList getUserList, int startIndex, int count,
                                               OrderedSet<CachedUserAccountInfo> userAccounts)
        {
            int firstHalfCount = (count + 1) / 2;
            if (firstHalfCount <= 0)
            {
                throw new ArgumentException("Invalid startIndex: " + startIndex.ToString());
            }
            int numAddedFirst = GetAllUserAccounts(getUserList, startIndex, firstHalfCount, userAccounts);
            if (numAddedFirst == 0)
            {
                return 0;
            }
            int secondHalfCount = count - firstHalfCount;
            if (secondHalfCount == 0)
            {
                return numAddedFirst;
            }
            int numAddedSecond = GetAllUserAccounts(getUserList, startIndex + firstHalfCount,
                                                    secondHalfCount, userAccounts);
            if (numAddedSecond == 0)
            {
                return 0;
            }
            return numAddedFirst + numAddedSecond;
        }
        public ICollection<string> GetAllUsernames(bool forceFreshFromNaas, bool appendAffiliation)
        {
            OrderedSet<CachedUserAccountInfo> userAccounts = GetAllUserAccounts(forceFreshFromNaas);
            return CreateUsernameList(userAccounts, appendAffiliation);
        }
        public ICollection<KeyValuePair<string, string>> GetAllCachedUsernames(bool appendAffiliation)
        {
            OrderedSet<CachedUserAccountInfo> userAccounts = GetAllCachedUserAccounts();
            return CreateUsernamePairList(userAccounts, appendAffiliation);
        }
        private ICollection<string> CreateUsernameList(OrderedSet<CachedUserAccountInfo> userAccounts,
                                                       bool appendAffiliation)
        {
            if (CollectionUtils.IsNullOrEmpty(userAccounts))
            {
                return new List<string>();
            }
            List<string> list = new List<string>(userAccounts.Count);
            if (appendAffiliation)
            {
                foreach (CachedUserAccountInfo info in userAccounts)
                {
                    list.Add(string.Format("{0}  ({1})", info.Username, info.Affiliate));
                }
            }
            else
            {
                foreach (CachedUserAccountInfo info in userAccounts)
                {
                    list.Add(info.Username);
                }
            }
            return list;
        }
        private ICollection<KeyValuePair<string, string>>
            CreateUsernamePairList(OrderedSet<CachedUserAccountInfo> userAccounts, bool appendAffiliation)
        {
            if (CollectionUtils.IsNullOrEmpty(userAccounts))
            {
                return new List<KeyValuePair<string, string>>();
            }
            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>(userAccounts.Count);
            if (appendAffiliation)
            {
                foreach (CachedUserAccountInfo info in userAccounts)
                {
                    list.Add(new KeyValuePair<string, string>(info.Username,
                                                              string.Format("{0}  ({1})",
                                                                            info.Username, info.Affiliate)));
                }
            }
            else
            {
                foreach (CachedUserAccountInfo info in userAccounts)
                {
                    list.Add(new KeyValuePair<string, string>(info.Username, info.Username));
                }
            }
            return list;
        }
        public void ChangePassword(string username, string currentPassword,
                                   string newPassword)
        {
            NAAS_USRMGR.ChangePassword changePassword = new NAAS_USRMGR.ChangePassword();

            changePassword.userId = username;
            changePassword.credential = currentPassword;
            changePassword.domain = _usermgrRuntimeCredentialDomain;
            changePassword.newPassword = newPassword;
            changePassword.passwordConfirmation = newPassword;

            try
            {
                NAAS_USRMGR.ChangePasswordResponse response = _usermgrClient.ChangePassword(changePassword);
            }
            catch (Exception e)
            {
                throw new ArgException("NAAS returned an error: {0}", e.Message);
            }
        }

        private NAAS_USRMGR.UserAccountType GetUserAccount(string userName)
        {
            NAAS_USRMGR.GetUserList getUserList = new NAAS_USRMGR.GetUserList();
            getUserList.adminName = _usermgrRuntimeCredential.UserName;
            getUserList.credential = _usermgrRuntimeCredential.Password;
            getUserList.domain = _usermgrRuntimeCredentialDomain;
            getUserList.rowId = "0";
            getUserList.maxRows = "-1";
            getUserList.userId = userName;
            getUserList.status = string.Empty;
            getUserList.affiliate = string.Empty;

            NAAS_USRMGR.GetUserListResponse response = _usermgrClient.GetUserList(getUserList);
            if (CollectionUtils.IsNullOrEmpty(response.@return))
            {
                return null;
            }
            foreach (NAAS_USRMGR.UserAccountType userAcct in response.@return)
            {
                if (string.Equals(userAcct.userId, userName, StringComparison.InvariantCultureIgnoreCase))
                {
                    return userAcct;
                }
            }
            return null;
        }

        public bool UserExists(string userName)
        {
            return (GetUserAccount(userName) != null);
        }
        public bool UserExists(string userName, out string affiliate, out bool canDelete)
        {
            NAAS_USRMGR.UserAccountType userAccount = GetUserAccount(userName);
            if (userAccount != null)
            {
                affiliate = userAccount.affiliate;
                canDelete = string.Equals(userAccount.affiliate, _nodeId, StringComparison.InvariantCultureIgnoreCase);
                if (canDelete)
                {
                    canDelete = CanDeleteUser(userName);
                }
            }
            else
            {
                affiliate = null;
                canDelete = false;
            }
            return (userAccount != null);
        }

        public NaasUserInfo GetNaasUserInfo(string userName)
        {
            NAAS_USRMGR.UserAccountType userAccount = GetUserAccount(userName);
            if (userAccount != null)
            {
                return new NaasUserInfo(userAccount.userGroup, userAccount.owner, userAccount.affiliate);
            }
            else
            {
                return new NaasUserInfo();
            }
        }

        public string CreateUser(string userName, string password, SystemRoleType role)
        {
            NAAS_USRMGR.AddUser addUser = new NAAS_USRMGR.AddUser();
            addUser.adminName = _usermgrRuntimeCredential.UserName;
            addUser.credential = _usermgrRuntimeCredential.Password;
            addUser.domain = _usermgrRuntimeCredentialDomain;
            addUser.userId = userName;
            addUser.userPassword = password;
            addUser.passwordConfirmation = password;
            addUser.affiliate = _nodeId;
            addUser.userType = SystemRoleToNAASUserType(role);
            addUser.status = NAAS_USRMGR.AccountStatusCode.valid;

            try
            {
                NAAS_USRMGR.AddUserResponse response = _usermgrClient.AddUser(addUser);
            }
            catch (Exception e)
            {
                throw new ArgException("NAAS returned an error: {0}", e.Message);
            }

            AddUserToCachedUsers(GetUserAccount(userName));

            return password;
        }
        protected bool CanDeleteUser(string userName)
        {
            return (!string.Equals(userName, _usermgrRuntimeCredential.UserName, StringComparison.InvariantCultureIgnoreCase) &&
                    !string.Equals(userName, _naasRuntimeCredential.UserName, StringComparison.InvariantCultureIgnoreCase));
        }
        public void DeleteUser(string userName)
        {
            if (!CanDeleteUser(userName))
            {
                throw new InvalidOperationException(string.Format("The user \"{0}\" cannot be deleted from the node",
                                                                  userName));
            }
            NAAS_USRMGR.DeleteUser deleteUser = new NAAS_USRMGR.DeleteUser();
            deleteUser.adminName = _usermgrRuntimeCredential.UserName;
            deleteUser.credential = _usermgrRuntimeCredential.Password;
            deleteUser.domain = _usermgrRuntimeCredentialDomain;
            deleteUser.userId = userName;

            try
            {
                NAAS_USRMGR.DeleteUserResponse response = _usermgrClient.DeleteUser(deleteUser);
            }
            catch (Exception e)
            {
                throw new ArgException("NAAS returned an error: {0}", e.Message);
            }

            RemoveUserFromCachedUsers(userName);
        }
        private void AddUserToCachedUsers(NAAS_USRMGR.UserAccountType userAccount)
        {
            try
            {
                OrderedSet<CachedUserAccountInfo> userAccounts = GetAllUserAccounts(false);
                CachedUserAccountInfo cachedInfo = new CachedUserAccountInfo(userAccount);
                userAccounts.Add(cachedInfo);
                _objectCacheDao.CacheObjectKeepExpiration(userAccounts, CACHE_NAAS_USER_ACCOUNTS);
            }
            catch (Exception)
            {
                InvalidateCachedUserAccounts();
            }
        }
        private void RemoveUserFromCachedUsers(string userName)
        {
            try
            {
                OrderedSet<CachedUserAccountInfo> userAccounts = GetAllUserAccounts(false);
                CachedUserAccountInfo cachedInfo = new CachedUserAccountInfo(userName);
                bool didRemove = userAccounts.Remove(cachedInfo);
                if (didRemove)
                {
                    _objectCacheDao.CacheObjectKeepExpiration(userAccounts, CACHE_NAAS_USER_ACCOUNTS);
                }
            }
            catch (Exception)
            {
                InvalidateCachedUserAccounts();
            }
        }

        public NAAS_USRMGR.UserTypeCode SystemRoleToNAASUserType(SystemRoleType role)
        {
            return NAAS_USRMGR.UserTypeCode.user;  // Per Mark
        }

        #endregion

        #region Init

        public void Init()
        {
            FieldNotInitializedException.ThrowIfEmptyString(this, ref _nodeId);
            FieldNotInitializedException.ThrowIfNull(this, ref _usermgrClient);
        }

        #endregion // Init

        public bool BypassNaasAuthenticateFailures
        {
            get
            {
                return _bypassNaasAuthenticateFailures;
            }
            set
            {
                _bypassNaasAuthenticateFailures = value;
            }
        }
        public string BypassNaasUserName
        {
            get
            {
                return _bypassNaasUserName;
            }
            set
            {
                _bypassNaasUserName = value;
            }
        }
        public string NodeId
        {
            get
            {
                return _nodeId;
            }
            set
            {
                _nodeId = value;
            }
        }
        public TimeSpan CacheNaasUsernamesDuration
        {
            get
            {
                return _cacheNaasUsernamesDuration;
            }
            set
            {
                _cacheNaasUsernamesDuration = value;
            }
        }
        public AuthenticationCredentials RuntimeCredentials
        {
            get
            {
                return _usermgrRuntimeCredential;
            }
        }
        public Windsor.Commons.NAASClient.IUserMgr UsermgrClient
        {
            get
            {
                return _usermgrClient;
            }
            set
            {
                _usermgrClient = value;
                //TestGetUserInfo();
            }
        }
        public IObjectCacheDao ObjectCacheDao
        {
            get
            {
                return _objectCacheDao;
            }
            set
            {
                _objectCacheDao = value;
            }
        }
        private void TestGetUserInfo()
        {
            NAAS_USRMGR.GetUserList getUserList = new NAAS_USRMGR.GetUserList();
            getUserList.adminName = "lsuydam@svt.org";
            getUserList.credential = "CDXwqxls11";
            getUserList.domain = _usermgrRuntimeCredentialDomain;
            getUserList.rowId = "0";
            getUserList.maxRows = "-1";
            getUserList.userId = "NDEQ.DEQNODE@NEBRASKA.GOV".ToLower();
            //getUserList.userId = "ted@windsorsolutions.com";
            getUserList.userId = "Ndeq.Deqnode@NEBRASKA.GOV";
            getUserList.status = string.Empty;
            getUserList.affiliate = string.Empty;

            getUserList.userId = "Morgan.leibrandt@nebraska.gov";
            getUserList.userId = "Morgan.leibrandt@nebraska.gov".ToLower();

            NAAS_USRMGR.GetUserListResponse response = _usermgrClient.GetUserList(getUserList);
            if (CollectionUtils.IsNullOrEmpty(response.@return))
            {
                return;
            }
            foreach (NAAS_USRMGR.UserAccountType userAcct in response.@return)
            {
                if (string.Equals(userAcct.userId, getUserList.userId, StringComparison.InvariantCultureIgnoreCase))
                {
                    return;
                }
            }
        }
    }
    [Serializable]
    public class CachedUserAccountInfo : IComparable<CachedUserAccountInfo>
    {
        private string _username;
        private string _affiliate;
        public CachedUserAccountInfo(NAAS_USRMGR.UserAccountType userAcct)
        {
            _username = NAASManager.CleanUpNAASReturnedAccountName(userAcct.userId);
            _affiliate = string.IsNullOrEmpty(userAcct.node) ? userAcct.affiliate : userAcct.node;
        }
        public CachedUserAccountInfo(string username)
        {
            _username = username;
            _affiliate = string.Empty;
        }

        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
            }
        }
        public string Affiliate
        {
            get
            {
                return _affiliate;
            }
            set
            {
                _affiliate = value;
            }
        }
        public int CompareTo(CachedUserAccountInfo other)
        {
            return string.Compare(_username, other.Username, true);
        }
    }
}
