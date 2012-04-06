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

using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSProviders;

namespace Windsor.Node2008.WNOSConnector.Logic
{
    public interface IAccountManagerEx : IAccountManager
    {
        /// <summary>
        /// Return true if the input username and password represent a valid user account.
        /// </summary>
        bool IsValidDemoUser(string username, string password, out bool isDemoUser);
        /// <summary>
		/// Get or create the user account with the specified username.
		/// </summary>
        UserAccount GetOrCreate(string username, bool alwaysCreateUserInDb, out bool wasCreated);
		/// <summary>
		/// Get AdminAccount
		/// </summary>
		UserAccount AdminAccount { get; }
		/// <summary>
		/// Get RuntimeAccount
		/// </summary>
		UserAccount RuntimeAccount { get; }

        UserAccount Get(string username, NodeVisit visit);

        UserAccount Save(UserAccount instance, bool allowCreateInNaasIfNecessary, 
                         string naasCreatePassword, NodeVisit visit);

        string GenerateRandomPassword();

        bool UserExistsInNAAS(string userName, NodeVisit visit, out string affiliate, out bool canDelete);

        string NodeId { get; }
    }
}
