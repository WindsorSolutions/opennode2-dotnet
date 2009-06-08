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
using Windsor.Node2008.WNOSDomain;
using System.Collections.Generic;
using Windsor.Node2008.WNOSUtility;
namespace Windsor.Node2008.WNOS.Data
{
    /// <summary>
    /// Data flow DAO interface.  The data flow DAO provides database access to all data flows associated with WNOS.
    /// </summary>
    public interface IFlowDao
    {
        /// <summary>
        /// Get a list of all data flow names.
        /// </summary>
        ICollection<string> GetAllDataFlowNames();

        /// <summary>
        /// Get a list of all data flows.  If loadDataServices is true, all data services associated with each flow
        /// are loaded from persistent storage and populated into the DataFlow.Services collection.  If includeServiceParameters
        /// is true, load service parameters for each data service, as well.
        /// </summary>
        IList<DataFlow> GetAllDataFlows(bool loadDataServices, bool includeServiceParameters);
        
        /// <summary>
        /// Get a list of all protected data flows.  If loadDataServices is true, all data services associated with each flow
        /// are loaded from persistent storage and populated into the DataFlow.Services collection.
        /// </summary>
        IList<DataFlow> GetAllProtectedDataFlows(bool loadDataServices);

        /// <summary>
        /// Get a list of all protected data flow names.
        /// </summary>
        IList<string> GetAllProtectedDataFlowNames();

        /// <summary>
        /// Get a map of all protected data flow name (key) to their ids (value).
        /// </summary>
        IDictionary<string, string> GetAllProtectedUpperDataFlowNamesToIdMap();
        
        /// <summary>
        /// Get a list of key/value pairs for all data flows, where the key is the data flow id and the value is
        /// the data flow name.
        /// </summary>
        IDictionary<string, string> GetAllFlowDisplayNames();

        /// <summary>
        /// Get the instance of the data flow with the specified id.
        /// </summary>
        DataFlow GetDataFlow(string flowId);

        /// <summary>
        /// Get the id of the data flow with the specified name.
        /// </summary>
        string GetDataFlowIdByName(string flowName);

        /// <summary>
        /// Get the id of the data flow with the specified name, and return if the flow is protected.
        /// </summary>
        string GetDataFlowIdByName(string flowName, out bool isProtected);

        /// <summary>
        /// Get the name of the data flow with the specified flow id.
        /// </summary>
        string GetDataFlowNameById(string flowId);

        /// <summary>
        /// Get the name of the data flow with the specified flow id, and return if the flow is protected.
        /// </summary>
        string GetDataFlowNameById(string flowId, out bool isProtected);

        /// <summary>
        /// Get the first data flow that is associated with the input data service name, and return
        /// true in moreThanOneFlowFound if there is more than one data flow that has a data service 
        /// with the specified name.
        /// </summary>
        string GetDataFlowNameByServiceName(string serviceName, out bool moreThanOneFlowFound);

        /// <summary>
        /// Get a list of all data services associated with the data flow with the specified flow id.
        /// </summary>
        IList<DataService> GetDataServicesForFlow(string flowId, bool includeServiceParameters);

        /// <summary>
        /// Get the Execute data service associated with the data flow with the specified flow id and execute method name.
        /// </summary>
        DataService GetExecuteServiceForFlow(string flowId, string methodName);

        /// <summary>
        /// Get the Notify data service associated with the data flow with the specified flow id and operation name.
        /// </summary>
        DataService GetNotifyDocumentServiceForFlow(string flowId, string operation);

        /// <summary>
        /// Get the Query or Solicit data service associated with the data flow with the specified flow id and request name.
        /// </summary>
        DataService GetQueryOrSolicitServiceForFlow(string flowId, string request);

        /// <summary>
        /// Get the Query data service associated with the data flow with the specified flow id and request name.
        /// </summary>
        DataService GetQueryServiceForFlow(string flowId, string request);

        /// <summary>
        /// Get the data service associated with the data flow with the specified flow id, request name,
        /// and service type.
        /// </summary>
        DataService GetServiceForFlow(string flowId, string request, ServiceType serviceType);

        /// <summary>
        /// Get the Solicit data service associated with the data flow with the specified flow id and request name.
        /// </summary>
        DataService GetSolicitServiceForFlow(string flowId, string request);

        /// <summary>
        /// Get the Submit data service associated with the data flow with the specified flow id and operation name.
        /// </summary>
        DataService GetSubmitDocumentServiceForFlow(string flowId, string operation);

        /// <summary>
        /// Save the data flow to persistent storage (and any associated data services).
        /// </summary>
        void Save(DataFlow item);

        /// <summary>
        /// Delete the data flow from persistent storage (and any associated data services).
        /// </summary>
        void Delete(DataFlow item);

        /// <summary>
        /// Get the name of the root table where data flows are persisted.
        /// </summary>
        string TableName { get; }

        /// <summary>
        /// Key is the flow name, value is the flow id.
        /// </summary>
        IDictionary<string, string> GetAllFlowsNameToIdMap();

        IList<string> GetProtectedFlowNamesForUser(string username);
    }
}
