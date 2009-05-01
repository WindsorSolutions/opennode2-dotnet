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
using Windsor.Node2008.WNOSConnector.Provider;

namespace Windsor.Node2008.WNOSConnector.Admin
{
    public interface IFlowService : ISimpleListDataService
    {
        DataService SaveService(DataService instance, AdminVisit visit);

        void DeleteService(DataService instance, AdminVisit visit);

        DataFlow SaveFlow(DataFlow instance, AdminVisit visit);

        void DeleteFlow(DataFlow instance, AdminVisit visit);

        DataFlow GetFlow(string flowId, AdminVisit visit);
        string GetFlowNameFromId(string flowId, AdminVisit visit);

        DataService GetService(string serviceId, AdminVisit visit);

        IList<DataFlow> GetFlows(AdminVisit visit, bool loadDataServices);

        IList<DataFlow> GetProtectedFlows(AdminVisit visit, bool loadDataServices);

        /// <summary>
        /// Validate a base plugin without loading the instance.
        /// </summary>
        void ValidateBasePlugin(DataService inDataService);

        /// <summary>
        /// Return all possible data service implementers for the input flow.
        /// </summary>
        ICollection<SimpleDataService> GetDataServiceImplementersForFlow(string flowId);

        ICollection<string> GetGlobalArgs();

        ICollection<string> GetDataSourceNames();

        ICollection<string> GetDataFlowNames();

        DataProviderInfo GetDataSourceByName(string inDataSourceName);

        ICollection<string> GetFlowContactList();

        string GetUsernameById(string userId);

        string GetUserIdByName(string username);

        void InstallPluginForFlow(byte[] zipFileContent, string flowName, AdminVisit visit);
    }
}
