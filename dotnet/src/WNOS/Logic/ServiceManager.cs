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

using Common.Logging;

using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOS.Data;
using Windsor.Node2008.WNOS.Logic;
using Windsor.Node2008.WNOSUtility;
using Windsor.Node2008.WNOSConnector.Logic;
using Windsor.Commons.Core;

namespace Windsor.Node2008.WNOS.Logic
{
    /// <summary>
    /// Service manager implementation.  The service manager provides the business logic and access to all services 
    /// related to a data flow.
    /// </summary>
    public class ServiceManager : LogicAuditBaseManager, IServiceManager
    {
        // The service DAO provider
        private IServiceDao _serviceDao;

        #region Init

        /// <summary>
        /// IoC initializer.
        /// </summary>
        new public void Init()
        {
			base.Init();
			
			FieldNotInitializedException.ThrowIfNull(this, ref _serviceDao);
        }

        #endregion

        /// <summary>
        /// Return the data service instance associated with the input service id.  The visit instance 
        /// contains the security token of the caller.
        /// </summary>
        public DataService GetDataService(string serviceId, AdminVisit visit)
        {
            ValidateByRole(visit, SystemRoleType.Program);
            return GetDataService(serviceId);
        }

        /// <summary>
        /// Return the data service instance associated with the input service id.
        /// </summary>
        public DataService GetDataService(string serviceId)
        {
            return _serviceDao.GetDataService(serviceId);
        }

        /// <summary>
        /// Validate and return the data service instance associated with the input service id.
        /// </summary>
        public DataService ValidateDataService(string serviceId, ServiceType shouldBeServiceType)
        {
            DataService dataService = _serviceDao.GetDataService(serviceId);
            if (dataService == null)
            {
                throw new ArgumentException(string.Format("A valid data service could not be found with the id \"{0}\"",
                                                          serviceId));
            }
            if (!dataService.IsActive)
            {
                throw new ArgumentException(string.Format("Data service \"{0}\" is not active", dataService.Name));
            }
            if ((dataService.Type & shouldBeServiceType) == 0)
            {
                throw new ArgumentException(string.Format("Data service \"{0}\" does not have the service proper type: \"{1}\" vs. \"{2}\"",
                                                          dataService.Name, dataService.Type.ToString(),
                                                          shouldBeServiceType.ToString()));
            }
            return dataService;
        }

        /// <summary>
        /// Validate and return the data service instance associated with the input service id.
        /// </summary>
        public DataService ValidateDataService(string flowName, string serviceName, 
                                               ServiceType shouldBeServiceType)
        {
            DataService dataService = _serviceDao.GetDataServiceByFlowName(flowName, serviceName);
            if (dataService == null)
            {
                throw new ArgumentException(string.Format("A valid data service could not be found with the service name \"{0}\" and flow name \"{1}\"",
                                                          serviceName, flowName));
            }
            if (!dataService.IsActive)
            {
                throw new ArgumentException(string.Format("Data service \"{0}\" is not active", dataService.Name));
            }
            if ((dataService.Type & shouldBeServiceType) == 0)
            {
                throw new ArgumentException(string.Format("Data service \"{0}\" does not have the proper service type: \"{1}\" vs. \"{2}\"",
                                                          dataService.Name, dataService.Type.ToString(),
                                                          shouldBeServiceType.ToString()));
            }
            return dataService;
        }

        /// <summary>
        /// Return the data flow id that is associated with the input data service id.  The visit instance 
        /// contains the security token of the caller.
        /// </summary>
        public string GetFlowIdFromDataServiceId(string serviceId, AdminVisit visit)
        {
            ValidateByRole(visit, SystemRoleType.Program);
            return _serviceDao.GetFlowIdFromDataServiceId(serviceId);
        }

        /// <summary>
        /// Return all service arguments associated with the input service id, as key/value string pairs.
        /// Each data service can have 0 or more associated arguments.  The visit instance contains the 
        /// security token of the caller.
        /// </summary>
        public IDictionary<string, string> GetServiceArguments(string serviceId, AdminVisit visit)
        {
            ValidateByRole(visit, SystemRoleType.Program);
            return _serviceDao.GetServiceArguments(serviceId);
        }

        /// <summary>
        /// Return all database data sources associated with the input service id, as key/DataProviderInfo pairs.
        /// Each data service can have 0 or more associated data sources.  The visit instance contains the security 
        /// token of the caller.
        /// </summary>
        public IDictionary<string, DataProviderInfo> GetServiceDataSources(string serviceId, AdminVisit visit)
        {
            ValidateByRole(visit, SystemRoleType.Program);
            return _serviceDao.GetServiceDataSources(serviceId);
        }

        /// <summary>
        /// Return all data services associated with the input data flow id.  Each data flow can have 0 or more 
        /// associated data services.  The visit instance contains the security token of the caller.
        /// </summary>
        public IList<DataService> GetDataServicesForFlow(string flowId, AdminVisit visit)
        {
            ValidateByRole(visit, SystemRoleType.Program);
            return _serviceDao.GetDataServicesForFlow(flowId, false);
        }

        /// <summary>
        /// Return all data services associated with the input data flow id that match the specified 
        /// service type.  Each data flow can have 0 or more associated data services.  The visit instance 
        /// contains the security token of the caller.
        /// </summary>
        public IList<DataService> GetDataServicesForFlow(string flowId, ServiceType serviceTypes, AdminVisit visit)
        {
            ValidateByRole(visit, SystemRoleType.Program);
            return _serviceDao.GetDataServicesForFlow(flowId, serviceTypes);
        }

        /// <summary>
        /// Return a display list of all data services as key/value pairs.  The key is the data service id,
        /// and the value is a string that can be used to display the service in a list.  The visit instance 
        /// contains the security token of the caller.
        /// </summary>
        public IDictionary<string, string> GetDataServiceDisplayList(AdminVisit visit)
        {
            ValidateByRole(visit, SystemRoleType.Program);
            return _serviceDao.GetDataServiceDisplayList();
        }

        /// <summary>
        /// Return a display list of all data services as key/value pairs that match the specified 
        /// service type.  The key is the data service id, and the value is a string that can be used 
        /// to display the service in a list.  The visit instance contains the security token of the caller.
        /// </summary>
        public IDictionary<string, string> GetDataServiceDisplayList(ServiceType typesToReturn, AdminVisit visit)
        {
            ValidateByRole(visit, SystemRoleType.Program);
            return _serviceDao.GetDataServiceDisplayList(typesToReturn);
        }

        /// <summary>
        /// Return all data services associated with the input data flow id that match the specified 
        /// service type and have the specified service name.  Each data flow can have 0 or more 
        /// associated data services.  The visit instance contains the security token of the caller.
        /// </summary>
        public IList<DataService> GetDataServicesForFlow(string flowId, string serviceName,
                                                        ServiceType serviceTypes, AdminVisit visit)
        {
            ValidateByRole(visit, SystemRoleType.Program);
            return _serviceDao.GetDataServicesForFlow(flowId, serviceName, serviceTypes);
        }

        #region Properties
        public IServiceDao ServiceDao
        {
			get {
				return _serviceDao;
			}
			set {
				_serviceDao = value;
			}
		}
        #endregion
    }
}
