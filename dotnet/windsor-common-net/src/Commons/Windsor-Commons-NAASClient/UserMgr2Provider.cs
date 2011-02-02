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

namespace Windsor.Commons.NAASClient
{
    public class UserMgr2Provider : Windsor.Commons.NAASClient.NAASUserMgr2.UserMgr2, IUserMgr
    {
        public UserMgr2Provider(bool isProduction)
            : this("https://naas.epacdxnode.net/xml/usermgr.wsdl", "https://cdxnodenaas.epa.gov/xml/usermgr.wsdl", 
                   isProduction)
        {
        }
        public UserMgr2Provider(string testUrl, string prodUrl, bool isProduction)
            : base()
        {
            if (string.IsNullOrEmpty(testUrl))
            {
                throw new ArgumentNullException("testUrl");
            }
            if (string.IsNullOrEmpty(prodUrl))
            {
                throw new ArgumentNullException("prodUrl");
            }
            this.Url = isProduction ? prodUrl : testUrl;
        }
        public Windsor.Commons.NAASClient.NAASUserMgr.AddUserResponse AddUser(Windsor.Commons.NAASClient.NAASUserMgr.AddUser arg)
        {
            Windsor.Commons.NAASClient.NAASUserMgr.AddUserResponse response = new Windsor.Commons.NAASClient.NAASUserMgr.AddUserResponse();
            string stateId;
            try
            {
                stateId = Enum.Parse(typeof(Windsor.Commons.NAASClient.NAASUserMgr2.StateId), arg.affiliate, true).ToString();
            }
            catch(Exception)
            {
                stateId = arg.affiliate;
            }
            response.@return =
                AddUser(arg.adminName, arg.credential, arg.userId, Windsor.Commons.NAASClient.NAASUserMgr2.UserType.user, arg.userPassword, arg.passwordConfirmation,
                        stateId);
            return response;
        }
        public Windsor.Commons.NAASClient.NAASUserMgr.ChangePasswordResponse ChangePassword(Windsor.Commons.NAASClient.NAASUserMgr.ChangePassword arg)
        {
            Windsor.Commons.NAASClient.NAASUserMgr.ChangePasswordResponse response = new Windsor.Commons.NAASClient.NAASUserMgr.ChangePasswordResponse();
            response.@return = ChangePwd(arg.userId, arg.credential, arg.newPassword);
            return response;
        }
        public Windsor.Commons.NAASClient.NAASUserMgr.DeleteUserResponse DeleteUser(Windsor.Commons.NAASClient.NAASUserMgr.DeleteUser arg)
        {
            Windsor.Commons.NAASClient.NAASUserMgr.DeleteUserResponse response = new Windsor.Commons.NAASClient.NAASUserMgr.DeleteUserResponse();
            response.@return = DeleteUser(arg.adminName, arg.credential, arg.userId);
            return response;
        }
        public Windsor.Commons.NAASClient.NAASUserMgr.GetUserListResponse GetUserList(Windsor.Commons.NAASClient.NAASUserMgr.GetUserList arg)
        {
            Windsor.Commons.NAASClient.NAASUserMgr.GetUserListResponse response = new Windsor.Commons.NAASClient.NAASUserMgr.GetUserListResponse();
            Windsor.Commons.NAASClient.NAASUserMgr2.UserInfo[] userInfoList =
                GetUserList(arg.adminName, arg.credential, arg.userId, arg.affiliate, arg.rowId, arg.maxRows);
            response.@return = new Windsor.Commons.NAASClient.NAASUserMgr.UserAccountType[userInfoList.Length];
            for (int i = 0; i < userInfoList.Length; ++i)
            {
                Windsor.Commons.NAASClient.NAASUserMgr2.UserInfo userInfo = userInfoList[i];
                Windsor.Commons.NAASClient.NAASUserMgr.UserAccountType userAccount = new Windsor.Commons.NAASClient.NAASUserMgr.UserAccountType();
                userAccount.affiliate = userInfo.Affiliate;
                userAccount.node = userInfo.Node;
                userAccount.owner = userInfo.Owner;
                userAccount.status = Windsor.Commons.NAASClient.NAASUserMgr.AccountStatusCode.valid.ToString();
                userAccount.userGroup = userInfo.UserGroup;
                userAccount.userId = userInfo.UserId;
                response.@return[i] = userAccount;
            }
            return response;
        }
        public Windsor.Commons.NAASClient.NAASUserMgr.UpdateUserResponse UpdateUser(Windsor.Commons.NAASClient.NAASUserMgr.UpdateUser arg)
        {
            Windsor.Commons.NAASClient.NAASUserMgr.UpdateUserResponse response = new Windsor.Commons.NAASClient.NAASUserMgr.UpdateUserResponse();
            response.@return = UpdateUser(arg.adminName, arg.credential, arg.userId, Windsor.Commons.NAASClient.NAASUserMgr2.UserType.user, arg.userPassword,
                                          arg.owner, (Windsor.Commons.NAASClient.NAASUserMgr2.StateId)Enum.Parse(typeof(Windsor.Commons.NAASClient.NAASUserMgr2.StateId), arg.affiliate, true));
            return response;
        }
    }
}
