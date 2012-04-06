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
using System.Diagnostics;
using Windsor.Node2008.WNOSUtility;
using Windsor.Commons.Core;
using System.ComponentModel;

namespace Windsor.Node2008.WNOSDomain
{
    [Flags]
    [Serializable]
    public enum DataServicePublishFlags
    {
        [Description("Do Not Publish")]
        DoNotPublish = 0x0000,
        [Description("Endpoint v1.1")]
        PublishToEndpointVersion11 = 0x0001,
        [Description("Endpoint v2.0")]
        PublishToEndpointVersion20 = 0x0002,
        [Description("Endpoint v1.1 and v2.0")]
        PublishToEndpointVersion11And20 = (PublishToEndpointVersion11 | PublishToEndpointVersion20),
    }

    /// <summary>
    /// Domain object representing a data flow data service instance.  A data serivce represents a single
    /// service action associated with a data flow, and is a many-to-one relationship with a data flow.
    /// </summary>
    [Serializable]
    public class DataService : AuditableIdentity
    {
        private string _name;
        private string _flowId;
        private bool _isActive;
		private ServiceType _type;
        private IDictionary<string, string> _args;
        private IDictionary<string, DataProviderInfo> _dataSources;
        private ExecutableInfo _pluginInfo;
        private DataServicePublishFlags _publishFlags = DataServicePublishFlags.PublishToEndpointVersion11And20;
        private IList<TypedParameter> _serviceParameters;

        public const string DEFAULT_SERVICE_NAME = "*";

        public DataService()
        {
            _args = new Dictionary<string, string>();
            _dataSources = new Dictionary<string, DataProviderInfo>();
        }
        public DataService(string name, string flowId, bool isActive, ServiceType serviceType, ExecutableInfo pluginInfo,
                           DataServicePublishFlags publishFlags)
        {
            _name = name;
            _flowId = flowId;
            _isActive = isActive;
            _type = serviceType;
            _pluginInfo = pluginInfo;
            _publishFlags = publishFlags;
            _args = new Dictionary<string, string>();
            _dataSources = new Dictionary<string, DataProviderInfo>();
        }

        /// <summary>
        /// The data sources (DataProviderInfo instances) associated with the data services, 
        /// as key/value pairs.  The key is the id of the data source.
        /// </summary>
        public IDictionary<string, DataProviderInfo> DataSources
        {
            get { return _dataSources; }
            set { _dataSources = value; }
        }

        /// <summary>
        /// The id of the data flow associated with the data service.
        /// </summary>
        public string FlowId
        {
            get { return _flowId; }
            set { _flowId = value; }
        }

        /// <summary>
        /// Is this data service currently active?
        /// </summary>
        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

        /// <summary>
        /// The name of the data service (e.g., GetFacilityByName)
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// The persistent configuration arguments associated with the data service.
        /// </summary>
        public IDictionary<string, string> Args
        {
            get { return _args; }
            set { _args = value; }
        }

        /// <summary>
        /// The service type (e.g., Solicit, Query, etc).
        /// </summary>
        public ServiceType Type
        {
			get { return _type; }
			set { _type = value; }
		}

        /// <summary>
        /// Information about the code plugin associated with this service.
        /// </summary>
        public ExecutableInfo PluginInfo
        {
            get { return _pluginInfo; }
            set { _pluginInfo = value; }
        }

        /// <summary>
        /// Is data service published via the node's GetServices()?
        /// </summary>
        public DataServicePublishFlags PublishFlags
        {
            get { return _publishFlags; }
            set { _publishFlags = value; }
        }

        public IList<TypedParameter> ServiceParameters
        {
            get { return _serviceParameters; }
            set { _serviceParameters = value; }
        }
    }
}
