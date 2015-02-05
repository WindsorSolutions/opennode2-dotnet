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
using Windsor.Commons.Core;
using Windsor.Commons.Logging;
using Windsor.Commons.Spring;
using Windsor.Commons.XsdOrm;
using Windsor.Commons.NodeDomain;

namespace Windsor.Node2008.WNOSPlugin.ENDS_2
{
    [Serializable]
    public abstract class EndsPluginBase : BaseWNOSPlugin
    {
        protected IRequestManager _requestManager;
        protected ISerializationHelper _serializationHelper;
        protected ICompressionHelper _compressionHelper;
        protected IDocumentManager _documentManager;
        protected ISettingsProvider _settingsProvider;
        protected IFlowManager _flowManager;
        protected ITransactionManager _transactionManager;

        protected DataRequest _dataRequest;
        protected string _xsltTransformName;

        public EndsPluginBase()
        {
        }

        public virtual void ProcessRequestInit(string requestId)
        {
            LazyInit();

            ValidateRequest(requestId);
        }
        protected virtual void LazyInit()
        {
            AppendAuditLogEvent("Initializing {0} plugin ...", this.GetType().Name);

            GetServiceImplementation(out _requestManager);
            GetServiceImplementation(out _serializationHelper);
            GetServiceImplementation(out _compressionHelper);
            GetServiceImplementation(out _documentManager);
            GetServiceImplementation(out _settingsProvider);
            GetServiceImplementation(out _flowManager);
            GetServiceImplementation(out _transactionManager);
        }
        protected virtual void ValidateRequest(string requestId)
        {
            AppendAuditLogEvent("Loading request with id \"{0}\"", requestId);
            _dataRequest = _requestManager.GetDataRequest(requestId);

            AppendAuditLogEvent("Validating request: {0}", _dataRequest);
        }
        protected byte[] GetServices(ServiceType returnServiceTypes, out int rowCount, out CommonContentType contentType)
        {
            NetworkNodeType networkNodeType = GetServices(returnServiceTypes);
            rowCount = networkNodeType.NodeServiceList.Length;

            NetworkNodeListType networkNodeListType = new NetworkNodeListType();
            networkNodeListType.NetworkNodeDetails = new NetworkNodeType[1] { networkNodeType };

            byte[] content = _serializationHelper.Serialize(networkNodeListType);

            contentType = CommonContentType.XML;
            content = CheckToXsltTransformContent(content, "xml_schema.XsltTransforms.zip",
                                                  _xsltTransformName, ref contentType);

            string docId =
                _documentManager.AddDocument(_dataRequest.TransactionId, CommonTransactionStatusCode.Completed,
                                             null, new Document(null, contentType, content));
            return content;
        }
        protected NetworkNodeType GetServices(ServiceType returnServiceTypes)
        {
            LatLongRectangle nodeBox = _settingsProvider.NodeBoundingBox;
            EndpointVersionType endpointVersionType =
                _transactionManager.GetTransactionEndpointVersionType(_dataRequest.TransactionId);
            if (endpointVersionType == EndpointVersionType.Undefined)
            {
                endpointVersionType = EndpointVersionType.EN20;
            }
            Dictionary<ServiceType, NodeMethodTypeCode> publishServiceTypeMap = new Dictionary<ServiceType, NodeMethodTypeCode>();
            if (EnumUtils.IsFlagSet(returnServiceTypes, ServiceType.Query))
            {
                publishServiceTypeMap.Add(ServiceType.Query, NodeMethodTypeCode.Query);
            }
            if (EnumUtils.IsFlagSet(returnServiceTypes, ServiceType.Solicit))
            {
                publishServiceTypeMap.Add(ServiceType.Solicit, NodeMethodTypeCode.Solicit);
            }
            if (EnumUtils.IsFlagSet(returnServiceTypes, ServiceType.Submit))
            {
                publishServiceTypeMap.Add(ServiceType.Submit, NodeMethodTypeCode.Submit);
            }
            if (EnumUtils.IsFlagSet(returnServiceTypes, ServiceType.Execute))
            {
                publishServiceTypeMap.Add(ServiceType.Execute, NodeMethodTypeCode.Execute);
            }
            if (publishServiceTypeMap.Count == 0)
            {
                throw new ArgumentException(string.Format("Invalid ServiceType specified: \"{0}\"", returnServiceTypes));
            }

            NetworkNodeType networkNodeType = new NetworkNodeType();
            networkNodeType.NodeServiceList = new ServiceDescriptionListTypeService[0];
            networkNodeType.BoundingBoxDetails = new NodeBoundingBoxType();
            networkNodeType.BoundingBoxDetails.BoundingCoordinateNorth = nodeBox.North;
            networkNodeType.BoundingBoxDetails.BoundingCoordinateEast = nodeBox.East;
            networkNodeType.BoundingBoxDetails.BoundingCoordinateSouth = nodeBox.South;
            networkNodeType.BoundingBoxDetails.BoundingCoordinateWest = nodeBox.West;
            if (endpointVersionType == EndpointVersionType.EN20)
            {
                networkNodeType.NodeAddress = _settingsProvider.Endpoint20Url;
                networkNodeType.NodeVersionIdentifier = NodeVersionCode.Item20;
            }
            else
            {
                networkNodeType.NodeAddress = _settingsProvider.Endpoint11Url;
                networkNodeType.NodeVersionIdentifier = NodeVersionCode.Item11;
            }
            networkNodeType.NodeContact = _settingsProvider.NodeAdminEmail;
            if (_settingsProvider.IsProductionNode)
            {
                networkNodeType.NodeDeploymentTypeCode = NodeStageCode.Production;
            }
            else
            {
                networkNodeType.NodeDeploymentTypeCode = NodeStageCode.Development;
            }
            networkNodeType.NodeIdentifier = _settingsProvider.NodeId + " - " + (_settingsProvider.IsProductionNode ? "Prod" : "Test");
            networkNodeType.NodeName = networkNodeType.NodeIdentifier;
            networkNodeType.OrganizationIdentifier = _settingsProvider.NodeOrganizationName;
            networkNodeType.NodeStatus = NodeStatusCode.Operational;

            string username = _transactionManager.GetTransactionUsername(_dataRequest.TransactionId);

            AppendAuditLogEvent("Loading information for all data flows for user: {0}", username);
            IList<DataFlow> dataFlows = _flowManager.GetAllDataFlows(true, true);


            if (!CollectionUtils.IsNullOrEmpty(dataFlows))
            {
                AppendAuditLogEvent("Loaded information for {0} data flows for user: {1}", dataFlows.Count.ToString(), username);

                DataServicePublishFlags validPublishFlags = (endpointVersionType == EndpointVersionType.EN20) ?
                    DataServicePublishFlags.PublishToEndpointVersion20 : DataServicePublishFlags.PublishToEndpointVersion11;
                List<ServiceDescriptionListTypeService> services = null;
                foreach (DataFlow dataFlow in dataFlows)
                {
                    if (!CollectionUtils.IsNullOrEmpty(dataFlow.Services))
                    {
                        foreach (DataService dataService in dataFlow.Services)
                        {
                            if (EnumUtils.IsFlagSet(dataService.PublishFlags, validPublishFlags) && dataService.IsActive &&
                                (dataService.PluginInfo != null) && !string.IsNullOrEmpty(dataService.PluginInfo.ImplementingClassName))
                            {
                                foreach (KeyValuePair<ServiceType, NodeMethodTypeCode> pair in publishServiceTypeMap)
                                {

                                    if (EnumUtils.IsFlagSet(dataService.Type, pair.Key))
                                    {
                                        ServiceDescriptionListTypeService nodeService = new ServiceDescriptionListTypeService();
                                        nodeService.Dataflow = dataFlow.FlowName;
                                        nodeService.MethodName = pair.Value;
                                        nodeService.ServiceDescription = string.Format("{0} - {1} Service", dataFlow.FlowName,
                                                                                       dataService.Name);
                                        nodeService.ServiceDocumentURL = dataFlow.InfoUrl;
                                        nodeService.ServiceIdentifier = dataService.Name;

                                        int publishParamCount = GetPublishParamCount(dataService.ServiceParameters);
                                        if (publishParamCount > 0)
                                        {
                                            nodeService.Parameter = new RequestParameterType[publishParamCount];
                                            for (int i = 0, index = 0; i < dataService.ServiceParameters.Count; ++i)
                                            {
                                                TypedParameter typedParameter = dataService.ServiceParameters[i];
                                                if (typedParameter.DoPublishParam)
                                                {
                                                    RequestParameterType requestParameter = new RequestParameterType();
                                                    requestParameter.ParameterName = typedParameter.Name;
                                                    requestParameter.ParameterSortIndex = index.ToString();
                                                    requestParameter.ParameterRequiredIndicator = typedParameter.IsRequired;
                                                    nodeService.Parameter[index++] = requestParameter;
                                                }
                                            }
                                        }

                                        CollectionUtils.Add(nodeService, ref services);
                                    }
                                }
                            }
                        }
                    }
                }
                if (!CollectionUtils.IsNullOrEmpty(services))
                {
                    services.Sort(delegate(ServiceDescriptionListTypeService s1, ServiceDescriptionListTypeService s2)
                    {
                        int result = string.Compare(s1.Dataflow, s2.Dataflow);
                        if (result != 0)
                            return result;
                        result = string.Compare(s1.ServiceIdentifier, s2.ServiceIdentifier);
                        if (result != 0)
                            return result;
                        return string.Compare(s1.MethodName.ToString(), s2.MethodName.ToString());
                    });
                    networkNodeType.NodeServiceList = services.ToArray();
                }
            }

            return networkNodeType;
        }
        protected int GetPublishParamCount(IList<TypedParameter> serviceParameters)
        {
            int count = 0;
            if (!CollectionUtils.IsNullOrEmpty(serviceParameters))
            {
                foreach (TypedParameter typedParameter in serviceParameters)
                {
                    if (typedParameter.DoPublishParam)
                    {
                        ++count;
                    }
                }
            }
            return count;
        }
    }
}
