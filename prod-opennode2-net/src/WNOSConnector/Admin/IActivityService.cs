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
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSUtility;
using Windsor.Commons.Core;

namespace Windsor.Node2008.WNOSConnector.Admin
{
    public interface IActivityService
    {
        /// <summary>
        /// Search
        /// </summary>
        SortableCollection<Activity> Search(ActivitySearchParams search, 
                                            NodeVisit visit,
                                            bool includeActivityEntries);
        /// <summary>
        /// Search
        /// </summary>
        IList<Activity> GetRecentActivities(int maxNumToReturn, bool returnUsernames,
                                            NodeVisit visit);
        /// <summary>
        /// GetActivityEntries
        /// </summary>
        Activity GetActivityEntries(Activity activity, NodeVisit visit);
        /// <summary>
        /// GetAllFlowNames
        /// </summary>
        IList<string> GetAllFlowNames(NodeVisit visit);
        /// <summary>
        /// GetAllOperationNames
        /// </summary>
        ICollection<string> GetAllOperationNames(NodeVisit visit);
        /// <summary>
        /// GetAllWebMethodNames
        /// </summary>
        ICollection<string> GetAllWebMethodNames(NodeVisit visit);
        /// <summary>
        /// GetDistinctFromIpList
        /// </summary>
        ICollection<string> GetDistinctFromIpList();
        /// <summary>
        /// GetAllUserNames
        /// </summary>
        ICollection<string> GetAllUserNames();
        /// <summary>
        /// GetAllUserNames
        /// </summary>
        IDictionary<string, string> GetUserIdToNameMap();

        int DeleteActivities(ActivitySearchParams search, NodeVisit visit);

        string GetTransactionIdFromActivityId(string activityId);
    }
}
