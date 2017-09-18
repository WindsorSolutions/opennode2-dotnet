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

namespace Windsor.Node2008.WNOSConnector.Admin
{
    public interface IScheduleService : ISimpleListDataService
    {
        ScheduledItem Save(ScheduledItem instance, NodeVisit visit);

        void Delete(ScheduledItem instance, NodeVisit visit);

        ScheduledItem Get(string scheduleId, NodeVisit visit,
                          out string modifierUsername);

        IList<ScheduledItem> GetSchedules(NodeVisit visit);

        IList<ScheduledItemExecuteStatus> GetScheduledItemExecuteStatus(NodeVisit visit);

        /// <summary>
        /// Return all exchange names as a dictionary of key/value pairs,
        /// where key is id and value is name.
        /// </summary>
        IDictionary<string, string> GetExchangeList(NodeVisit visit, bool checkCanEditExchange);

        /// <summary>
        /// Return all local service names as a dictionary of key/value pairs.
        /// </summary>
        IDictionary<string, string> GetDataServiceDisplayList(NodeVisit visit);

        /// <summary>
        /// Return sorted list of valid flow codes that can be passed to Validate()
        /// </summary>
        IList<string> GetValidFlowCodes();

        /// <summary>
        /// Return all partner names as a dictionary of key/value pairs.
        /// </summary>
        IDictionary<string, string> GetPartnerList();

        ScheduledItem SaveAndRunNow(ScheduledItem instance, NodeVisit visit);
        ScheduledItem RunNow(string scheduleId, NodeVisit visit);
        ScheduledItem RunNow(ScheduledItem instance, NodeVisit visit);

        string GetFlowIdFromDataServiceId(string serviceId, NodeVisit visit);

        /// <summary>
        /// Return all local submit service names as a dictionary of key/value pairs.
        /// </summary>
        IDictionary<string, string> GetSubmitServiceDisplayList(NodeVisit visit);

        IDictionary<string, string> GetEndpointUserDisplayList(NodeVisit visit);

        string GetTransactionIdFromActivityId(string activityId);
        ScheduledItemExecuteInfo GetScheduleLastExecuteInfo(string activityId);
    }
}