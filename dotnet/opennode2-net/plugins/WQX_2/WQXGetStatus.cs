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
using System.Xml;
using System.IO;
using System.Data;
using System.Data.Common;
using System.Data.ProviderBase;
using Windsor.Node2008.WNOSPlugin;
using System.Diagnostics;
using System.Reflection;
using Windsor.Node2008.WNOSUtility;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSProviders;
using Spring.Data.Common;
using Spring.Transaction.Support;
using Spring.Data.Core;
using System.ComponentModel;

namespace Windsor.Node2008.WNOSPlugin.WQX2
{
    [Serializable]
    public class WQXGetStatus : WQXPluginBase, ITaskProcessor
    {
        #region fields
        #endregion

        #region ISolicitProcessor Interface Implementation

        public WQXGetStatus()
        {
            ConfigurationArguments.Clear();
            ConfigurationArguments.Add(CONFIG_EPA_PARTNER_NAME_KEY, null);
        }
        /// <summary>
        /// ProcessSolicit
        /// </summary>
        /// <param name="requestId"></param>
        public virtual void ProcessTask(string requestId)
        {
            ProcessQuerySolicitInit(requestId, true);

            IList<PendingSubmissionInfo> pendingSubmissions = GetPendingSubmissions();

            if (pendingSubmissions != null)
            {
                foreach (PendingSubmissionInfo pendingSubmission in pendingSubmissions)
                {
                    UpdateTransactionStatus(pendingSubmission.RecordId, 
                                            pendingSubmission.LocalTransactionId);
                }
            }
        }

        #endregion
    }
}
