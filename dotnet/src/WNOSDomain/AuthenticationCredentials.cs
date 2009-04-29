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

using Windsor.Commons.Core;

namespace Windsor.Node2008.WNOSDomain
{
    [Serializable]
    public class AuthenticationCredentials
    {
        private string _username;
        private string _password;
        private string _domain;

		public AuthenticationCredentials()
		{
		}
		public AuthenticationCredentials(string userName, string password) :
										 this(userName, password, null)
		{
		}
		public AuthenticationCredentials(string userName, string password, string domain)
		{
			_username = userName;
			_password = password;
			_domain = domain;
		}
        public override string ToString()
        {
            return ReflectionUtils.GetPublicPropertiesString(this);
        }

        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }

        [ToStringQualifier(Ignore = true)]
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string Domain
        {
            get { return _domain; }
            set { _domain = value; }
        }
    }
}
