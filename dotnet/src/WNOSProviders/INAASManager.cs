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
using System.Net;
using System.Collections.Generic;
using Windsor.Node2008.WNOSDomain;

namespace Windsor.Node2008.WNOSProviders
{
    public interface INAASManager
    {
        /// <summary>
        /// RefreshNAASUsersIfExpired
        /// </summary>
        bool RefreshNAASUsersIfExpired(out int numUsersRefreshed);
        /// <summary>
        /// RefreshNAASUsersAlways
        /// </summary>
        void RefreshNAASUsersAlways(out int numUsersRefreshed);

        /// <summary>
        /// Checks if the user already exists in NAAS
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        bool UserExists(string userName);

        /// <summary>
        /// Checks if the user already exists in NAAS, and, if so, returns the affiliate of the user and
        /// whether or not the user can be deleted from NAAS.
        /// </summary>
        bool UserExists(string userName, out string affiliate, out bool canDelete);

        /// <summary>
        /// Get the NAAS affiliate for the current node.
        /// </summary>
        string NodeId { get; }
    }
}
