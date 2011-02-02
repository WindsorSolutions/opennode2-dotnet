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
using System.Collections;
using System.Collections.Specialized;
using System.Text;

using Windsor.Node2008.WNOSDomain;

namespace Windsor.Node2008.WNOSConnector.Logic
{
    /// <summary>
    /// Service manager interface.  The service manager provides the business logic and access to all services 
    /// related to a data flow.
    /// </summary>
    public interface IServiceManager
    {
        /// <summary>
        /// Return the data service instance associated with the input service id.  The visit instance 
        /// contains the security token of the caller.
        /// </summary>
        DataService GetDataService(string serviceId, AdminVisit visit);

        /// <summary>
        /// Return the data service instance associated with the input service id.
        /// </summary>
        DataService GetDataService(string serviceId);

        /// <summary>
        /// Return all service arguments associated with the input service id, as key/value string pairs.
        /// Each data service can have 0 or more associated arguments.  The visit instance 
        /// contains the security token of the caller.
        /// </summary>
        IDictionary<string, string> GetServiceArguments(string serviceId, AdminVisit visit);

        /// <summary>
        /// Return all database data sources associated with the input service id, as key/DataProviderInfo pairs.
        /// The key represents the id of the data source.  Each data service can have 0 or more associated data sources.
        /// The visit instance contains the security token of the caller.
        /// </summary>
        IDictionary<string, DataProviderInfo> GetServiceDataSources(string serviceId, AdminVisit visit);
        
        /// <summary>
        /// Return all data services associated with the input data flow id.  Each data flow can have 0 or more 
        /// associated data services.  The visit instance contains the security token of the caller.
        /// </summary>
        IList<DataService> GetDataServicesForFlow(string flowId, AdminVisit visit);
        
        /// <summary>
        /// Return all data services associated with the input data flow id that match the specified 
        /// service type.  Each data flow can have 0 or more associated data services.  The visit instance 
        /// contains the security token of the caller.
        /// </summary>
        IList<DataService> GetDataServicesForFlow(string flowId, ServiceType serviceTypes, AdminVisit visit);
        
        /// <summary>
        /// Return all data services associated with the input data flow id that match the specified 
        /// service type and have the specified service name.  Each data flow can have 0 or more 
        /// associated data services.  The visit instance contains the security token of the caller.
        /// </summary>
        IList<DataService> GetDataServicesForFlow(string flowId, string serviceName,
                                                 ServiceType serviceTypes, AdminVisit visit);
        /// <summary>
        /// Return a display list of all data services as key/value pairs.  The key is the data service id,
        /// and the value is a string that can be used to display the service in a list.  The visit instance 
        /// contains the security token of the caller.
        /// </summary>
        IDictionary<string, string> GetDataServiceDisplayList(AdminVisit visit);
        
        /// <summary>
        /// Return a display list of all data services as key/value pairs that match the specified 
        /// service type.  The key is the data service id, and the value is a string that can be used 
        /// to display the service in a list.  The visit instance contains the security token of the
        /// caller.
        /// </summary>
        IDictionary<string, string> GetDataServiceDisplayList(ServiceType typesToReturn, AdminVisit visit);

        /// <summary>
        /// Return the data flow id that is associated with the input data service id.  The visit instance 
        /// contains the security token of the caller.
        /// </summary>
        string GetFlowIdFromDataServiceId(string serviceId, AdminVisit visit);

        /// <summary>
        /// Validate that the requested service is active and is of the specified service type.
        /// </summary>
        DataService ValidateDataService(string serviceId, ServiceType shouldBeServiceType);

        /// <summary>
        /// Validate that the requested service is active and is of the specified service type.
        /// </summary>
        DataService ValidateDataService(string flowName, string serviceName, 
                                        ServiceType shouldBeServiceType);
    }
}
