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

namespace Windsor.Node2008.WNOSConnector.Logic
{
    /// <summary>
    /// Interface for the audit log activity manager.  The activity manager adds information to a persistent audit log
    /// for subsequent retrieval and reporting.
    /// </summary>
    public interface IActivityManager
    {
        /// <summary>
        /// Add the activity to the audit log
        /// </summary>
        string Log(Activity activity);

        /// <summary>
        /// Add the activity to the audit log
        /// </summary>
        string LogAudit(NodeMethod method, string flowName, AdminVisit visit, string messageFormat, params object[] args);

        /// <summary>
        /// Add the activity to the audit log
        /// </summary>
        string LogAudit(NodeMethod method, string flowName, string transactionId, AdminVisit visit, string messageFormat, params object[] args);

        /// <summary>
        /// Add the admin authentication activity to the audit log
        /// </summary>
        string LogAdminAuth(NodeMethod method, string flowName, AdminVisit visit, string messageFormat, params object[] args);

        /// <summary>
        /// Add the info activity to the audit log
        /// </summary>
        string LogInfo(NodeMethod method, string flowName, AdminVisit visit, string messageFormat, params object[] args);

        /// <summary>
        /// Add the error activity to the audit log
        /// </summary>
        string LogError(NodeMethod method, string flowName, Exception exception, AdminVisit visit, string messageFormat,
                        params object[] args);
    }
}
