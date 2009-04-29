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
using Windsor.Node2008.NAASUserMgr2;

namespace Windsor.Node2008.NAASClient
{
    public class UserMgr2Provider : UserMgr2, IUserMgr
    {
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
        public Windsor.Node2008.NAASUserMgr.AddUserResponse AddUser(Windsor.Node2008.NAASUserMgr.AddUser arg)
        {
            Windsor.Node2008.NAASUserMgr.AddUserResponse response = new Windsor.Node2008.NAASUserMgr.AddUserResponse();
            string stateId;
            try
            {
                stateId = Enum.Parse(typeof(StateId), arg.affiliate, true).ToString();
            }
            catch(Exception)
            {
                stateId = arg.affiliate;
            }
            response.@return =
                AddUser(arg.adminName, arg.credential, arg.userId, UserType.user, arg.userPassword, arg.passwordConfirmation,
                        stateId);
            return response;
        }
        public Windsor.Node2008.NAASUserMgr.ChangePasswordResponse ChangePassword(Windsor.Node2008.NAASUserMgr.ChangePassword arg)
        {
            Windsor.Node2008.NAASUserMgr.ChangePasswordResponse response = new Windsor.Node2008.NAASUserMgr.ChangePasswordResponse();
            response.@return = ChangePwd(arg.userId, arg.credential, arg.newPassword);
            return response;
        }
        public Windsor.Node2008.NAASUserMgr.DeleteUserResponse DeleteUser(Windsor.Node2008.NAASUserMgr.DeleteUser arg)
        {
            Windsor.Node2008.NAASUserMgr.DeleteUserResponse response = new Windsor.Node2008.NAASUserMgr.DeleteUserResponse();
            response.@return = DeleteUser(arg.adminName, arg.credential, arg.userId);
            return response;
        }
        public Windsor.Node2008.NAASUserMgr.GetUserListResponse GetUserList(Windsor.Node2008.NAASUserMgr.GetUserList arg)
        {
            Windsor.Node2008.NAASUserMgr.GetUserListResponse response = new Windsor.Node2008.NAASUserMgr.GetUserListResponse();
            UserInfo[] userInfoList =
                GetUserList(arg.adminName, arg.credential, arg.userId, arg.affiliate, arg.rowId, arg.maxRows);
            response.@return = new Windsor.Node2008.NAASUserMgr.UserAccountType[userInfoList.Length];
            for (int i = 0; i < userInfoList.Length; ++i)
            {
                UserInfo userInfo = userInfoList[i];
                Windsor.Node2008.NAASUserMgr.UserAccountType userAccount = new Windsor.Node2008.NAASUserMgr.UserAccountType();
                userAccount.affiliate = userInfo.Affiliate;
                userAccount.node = userInfo.Node;
                userAccount.owner = userInfo.Owner;
                userAccount.status = Windsor.Node2008.NAASUserMgr.AccountStatusCode.valid.ToString();
                userAccount.userGroup = userInfo.UserGroup;
                userAccount.userId = userInfo.UserId;
                response.@return[i] = userAccount;
            }
            return response;
        }
        public Windsor.Node2008.NAASUserMgr.UpdateUserResponse UpdateUser(Windsor.Node2008.NAASUserMgr.UpdateUser arg)
        {
            Windsor.Node2008.NAASUserMgr.UpdateUserResponse response = new Windsor.Node2008.NAASUserMgr.UpdateUserResponse();
            response.@return = UpdateUser(arg.adminName, arg.credential, arg.userId, UserType.user, arg.userPassword, 
                                          arg.owner, (StateId) Enum.Parse(typeof(StateId), arg.affiliate, true));
            return response;
        }
    }
}
