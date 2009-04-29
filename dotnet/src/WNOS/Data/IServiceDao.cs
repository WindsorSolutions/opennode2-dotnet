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
    /// Service DAO interface.  The service DAO provides database access to all services related to a data flow.
    /// </summary>
    public interface IServiceDao
    {
        /// <summary>
        /// Return a collection of all service names that have the specified data service argument value.
        /// </summary>
        ICollection<string> GetServiceNamesWithArgValue(string value);

        /// <summary>
        /// Return a collection of all service names that are associated with the specified data source id.
        /// </summary>
        ICollection<string> GetServiceNamesWithDataSource(string connectionId);

        /// <summary>
        /// Return a display list of all data services as key/value pairs.  The key is the data service id,
        /// and the value is a string that can be used to display the service in a list.
        /// </summary>
        IDictionary<string, string> GetDataServiceDisplayList();

        /// <summary>
        /// Return a display list of all data services as key/value pairs that match the specified 
        /// service type.  The key is the data service id, and the value is a string that can be used 
        /// to display the service in a list.
        /// </summary>
        IDictionary<string, string> GetDataServiceDisplayList(ServiceType typesToReturn);

        /// <summary>
        /// Return the data service instance associated with the input service id.
        /// </summary>
        DataService GetDataService(string serviceId);

        /// <summary>
        /// Return the data service instance associated with the input flow name and service name.
        /// </summary>
        DataService GetDataServiceByFlowName(string flowName, string serviceName);

        /// <summary>
        /// Return the data flow id that is associated with the input data service id.
        /// </summary>
        string GetFlowIdFromDataServiceId(string serviceId);

        /// <summary>
        /// Return all data services associated with the input data flow id.  Each data flow can have 0 or more 
        /// associated data services.
        /// </summary>
        IList<DataService> GetDataServicesForFlow(string flowId);

        /// <summary>
        /// Return all data services associated with the input data flow id that match the specified 
        /// service type.  Each data flow can have 0 or more associated data services.
        /// </summary>
        IList<DataService> GetDataServicesForFlow(string flowId, ServiceType serviceTypes);

        /// <summary>
        /// Return all data services associated with the input data flow id that match the specified 
        /// service type and have the specified service name.  Each data flow can have 0 or more 
        /// associated data services.
        /// </summary>
        IList<DataService> GetDataServicesForFlow(string flowId, string serviceName, ServiceType serviceTypes);

        /// <summary>
        /// Return all service arguments associated with the input service id, as key/value string pairs.
        /// Each data service can have 0 or more associated arguments.
        /// </summary>
        IDictionary<string, string> GetServiceArguments(string serviceId);

        /// <summary>
        /// Return all database data sources associated with the input service id, as key/DataProviderInfo pairs.
        /// The key represents the id of the data source.  Each data service can have 0 or more associated data sources.
        /// </summary>
        IDictionary<string, DataProviderInfo> GetServiceDataSources(string serviceId);

        /// <summary>
        /// Persist the input data service instance.  If the data service already exists, it is updated; otherwise,
        /// it is created.
        /// </summary>
        void Save(DataService item);

        /// <summary>
        /// Delete the input data service instance.  After calling this method, the data service instance is no longer valid.
        /// </summary>
        void Delete(DataService item);
    }
}
