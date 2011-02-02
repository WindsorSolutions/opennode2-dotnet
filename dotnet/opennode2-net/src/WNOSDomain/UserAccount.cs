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
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSUtility;
using Windsor.Commons.Core;

namespace Windsor.Node2008.WNOSDomain
{
    /// <summary>
    /// Domain object that represents a WNOS user.
    /// </summary>
    [Serializable]
    public class UserAccount : AuditableIdentity
    {
        private string _naasAccount;
        private bool _isActive;
        private SystemRoleType _role;
        private IList<UserAccessPolicy> _policies;
        private bool? _isDemoUser = null;

        public UserAccount() 
        {
            _role = SystemRoleType.None;
            _policies = new SortableCollection<UserAccessPolicy>();
        }

        /// <summary>
        /// Is this user active?
        /// </summary>
        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

        /// <summary>
        /// The NAAS account username for this user.
        /// </summary>
        public string NaasAccount
        {
            get { return _naasAccount; }
            set { _naasAccount = value; }
        }

        /// <summary>
        /// The system user role assigned to this user.
        /// </summary>
        public SystemRoleType Role
        {
            get { return _role; }
            set { _role = value; }
        }

        /// <summary>
        /// The user access policies assigned to this user.
        /// </summary>
        public IList<UserAccessPolicy> Policies
        {
            get { return _policies; }
            set { _policies = value; }
        }
        /// <summary>
        /// Is this a demo user?
        /// </summary>
        public bool? IsDemoUser
        {
            get { return _isDemoUser; }
            set { _isDemoUser = value; }
        }
    }
}
