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
using System.ComponentModel;
using System.Xml.Serialization;

using Windsor.Commons.Core;
using Windsor.Commons.NodeDomain;

namespace Windsor.Node2008.WNOSDomain
{

    [Flags]
    public enum ImportExportSettings
    {
        None = 0x00000000,
        [Description("Global Arguments")]
        GlobalArguments = 0x00000001,
        [Description("Data Sources")]
        DataSources = 0x00000002,
        [Description("Network Partners")]
        NetworkPartners = 0x00000004,
        [Description("Users")]
        Users = 0x00000008,
        [Description("Exchanges")]
        Exchanges = 0x00000010,
        [Description("Services")]
        Services = 0x00000020,
        [Description("Schedules")]
        Schedules = 0x00000040,
        All = (GlobalArguments | DataSources | NetworkPartners | Users | Exchanges | Services | Schedules),
    }
    public enum ImportSettingsAction
    {
        None,
        [Description("Add and Update")]
        AddAndUpdate,
        [Description("Replace")]
        Replace,
    }
    [Serializable]
    public class GlobalArgumentSetting
    {
        public string Name;
        public string Value;
        public string Description;
        public bool IsEditable;

        public GlobalArgumentSetting()
        {
        }
        public GlobalArgumentSetting(ConfigItem configItem)
        {
            Name = configItem.Id;
            Value = configItem.Value;
            Description = configItem.Description;
            IsEditable = configItem.IsEditable;
        }
        public ConfigItem ToConfigItem(string modifiedById, DateTime modifiedOn)
        {
            ConfigItem configItem = new ConfigItem(Name, Value, Description, IsEditable);
            configItem.ModifiedById = modifiedById;
            configItem.ModifiedOn = modifiedOn;
            return configItem;
        }
    }
    [Serializable]
    public class DataSourceSetting
    {
        public string Name;
        public string ProviderType;
        public string ConnectionString;

        public DataSourceSetting()
        {
        }
        public DataSourceSetting(DataProviderInfo dataSource)
        {
            Name = dataSource.Name;
            ProviderType = dataSource.ProviderType;
            ConnectionString = dataSource.ConnectionString;
        }
        public DataProviderInfo ToDataProviderInfo(string modifiedById, DateTime modifiedOn)
        {
            DataProviderInfo dataProviderInfo = new DataProviderInfo(Name, ProviderType, ConnectionString);
            dataProviderInfo.ModifiedById = modifiedById;
            dataProviderInfo.ModifiedOn = modifiedOn;
            return dataProviderInfo;
        }
    }
    [Serializable]
    public class KeyedDataSourceSetting : DataSourceSetting
    {
        public string Key;

        public KeyedDataSourceSetting()
        {
        }
        public KeyedDataSourceSetting(string key, DataProviderInfo dataSource)
            : base(dataSource)
        {
            Key = key;
        }
    }
    [Serializable]
    public class NetworkPartnerSetting
    {
        public string Name;
        public string Url;
        public EndpointVersionType Version;

        public NetworkPartnerSetting()
        {
        }
        public NetworkPartnerSetting(PartnerIdentity partnerIdentity)
        {
            Name = partnerIdentity.Name;
            Url = partnerIdentity.Url;
            Version = partnerIdentity.Version;
        }
        public PartnerIdentity ToPartnerIdentity(string modifiedById, DateTime modifiedOn)
        {
            PartnerIdentity partnerIdentity = new PartnerIdentity(Name, Url, Version);
            partnerIdentity.ModifiedById = modifiedById;
            partnerIdentity.ModifiedOn = modifiedOn;
            return partnerIdentity;
        }
    }
    [Serializable]
    public class ExchangeSetting
    {
        public string Name;
        public string InfoUrl;
        public string ContactUserId;
        public string Description;
        public bool IsProtected;

        public ExchangeSetting()
        {
        }
        public ExchangeSetting(DataFlow dataFlow)
        {
            Name = dataFlow.FlowName;
            InfoUrl = dataFlow.InfoUrl;
            ContactUserId = dataFlow.ContactUserId;
            Description = dataFlow.Description;
            IsProtected = dataFlow.IsProtected;
        }
        public DataFlow ToDataFlow(string modifiedById, DateTime modifiedOn)
        {
            DataFlow dataFlow = new DataFlow(Name, InfoUrl, ContactUserId, Description, IsProtected);
            dataFlow.ModifiedById = modifiedById;
            dataFlow.ModifiedOn = modifiedOn;
            return dataFlow;
        }
    }
    [Serializable]
    public class KeyValueSetting
    {
        public KeyValueSetting()
        {
        }
        public KeyValueSetting(string key, string value)
        {
            Key = key;
            Value = value;
        }
        public string Key;
        public string Value;
    }
    [Serializable]
    public class ServiceSetting
    {
        public string Name;
        public string FlowName;
        public bool IsActive;
        public string ServiceType;
        public string PluginImplementerString;
        public string PublishFlags;
        [XmlArrayItem(ElementName = "DataSource")]
        public KeyedDataSourceSetting[] DataSources;
        [XmlArrayItem(ElementName = "Arg")]
        public KeyValueSetting[] Args;

        public ServiceSetting()
        {
        }
        public ServiceSetting(DataService dataService, string flowName)
        {
            Name = dataService.Name;
            FlowName = flowName;
            IsActive = dataService.IsActive;
            ServiceType = dataService.Type.ToString();
            PublishFlags = dataService.PublishFlags.ToString();
            if (dataService.PluginInfo != null)
            {
                PluginImplementerString = dataService.PluginInfo.ImplementerString;
            }
            List<KeyedDataSourceSetting> dataSources = null;
            CollectionUtils.ForEach(dataService.DataSources, delegate(KeyValuePair<string, DataProviderInfo> pair)
            {
                CollectionUtils.Add(new KeyedDataSourceSetting(pair.Key, pair.Value), ref dataSources);
            });
            DataSources = (dataSources == null) ? null : dataSources.ToArray();
            List<KeyValueSetting> args = null;
            CollectionUtils.ForEach(dataService.Args, delegate(KeyValuePair<string, string> pair)
            {
                CollectionUtils.Add(new KeyValueSetting(pair.Key, pair.Value), ref args);
            });
            Args = (args == null) ? null : args.ToArray();
        }
        public DataService ToDataService(string flowId, string modifiedById, DateTime modifiedOn)
        {
            ExecutableInfo executableInfo = null;
            if (!string.IsNullOrEmpty(PluginImplementerString))
            {
                executableInfo = new ExecutableInfo(PluginImplementerString);
            }
            DataService dataService =
                new DataService(Name, flowId, IsActive, EnumUtils.ParseEnum<ServiceType>(ServiceType),
                                executableInfo, EnumUtils.ParseEnum<DataServicePublishFlags>(PublishFlags));
            dataService.ModifiedById = modifiedById;
            dataService.ModifiedOn = modifiedOn;
            Dictionary<string, DataProviderInfo> dataSources = null;
            CollectionUtils.ForEach(DataSources, delegate(KeyedDataSourceSetting dataSource)
            {
                DataProviderInfo dataProviderInfo = dataSource.ToDataProviderInfo(modifiedById, modifiedOn);
                CollectionUtils.Add(dataSource.Key, dataProviderInfo, ref dataSources);
            });
            dataService.DataSources = (dataSources == null) ? null : dataSources;
            Dictionary<string, string> args = null;
            CollectionUtils.ForEach(Args, delegate(KeyValueSetting setting)
            {
                CollectionUtils.Add(setting.Key, setting.Value, ref args);
            });
            dataService.Args = (args == null) ? null : args;
            return dataService;
        }
    }
    [Serializable]
    public class ScheduleSetting
    {
        public string Name;
        public string FlowName;
        public DateTime StartOn;
        public DateTime EndOn;
        public string SourceType;
        public string SourceId;
        public string SourceFlow;
        public string SourceRequest;
        public string TargetType;
        public string TargetId;
        public string TargetFlow;
        public string TargetRequest;
        public string FrequencyType;
        public int Frequency;
        public bool IsActive;
        public bool ArgsByName;
        public KeyValueSetting[] Args;
        
        public ScheduleSetting()
        {
        }
        public ScheduleSetting(ScheduledItem scheduledItem, IDictionary<string, string> flowIdToNameMap,
                               IDictionary<string, string> serviceIdToNameMap, 
                               IDictionary<string, string> partnerIdToNameMap,
                               out string errorMessage)
        {
            Name = scheduledItem.Name;
            FlowName = flowIdToNameMap[scheduledItem.FlowId];
            StartOn = scheduledItem.StartOn;
            EndOn = scheduledItem.EndOn;
            SourceType = scheduledItem.SourceType.ToString();
            if (scheduledItem.SourceType == ScheduledItemSourceType.LocalService)
            {
                if ((serviceIdToNameMap == null) ||
                    !serviceIdToNameMap.TryGetValue(scheduledItem.SourceId, out SourceId))
                {
                    errorMessage = string.Format("Could not find source local service with id \"{0}\"",
                                                 scheduledItem.SourceId);
                    return;
                }
            }
            else if ((scheduledItem.SourceType == ScheduledItemSourceType.WebServiceQuery) ||
                     (scheduledItem.SourceType == ScheduledItemSourceType.WebServiceSolicit))
            {
                if ((partnerIdToNameMap == null) || 
                    !partnerIdToNameMap.TryGetValue(scheduledItem.SourceId, out SourceId))
                {
                    errorMessage = string.Format("Could not find source partner service with id \"{0}\"",
                                                 scheduledItem.SourceId);
                    return;
                }
            }
            else
            {
                SourceId = scheduledItem.SourceId;
            }
            SourceFlow = scheduledItem.SourceFlow;
            SourceRequest = scheduledItem.SourceRequest;
            TargetType = scheduledItem.TargetType.ToString();
            if (scheduledItem.TargetType == ScheduledItemTargetType.LocalService)
            {
                if ((serviceIdToNameMap == null) || 
                    !serviceIdToNameMap.TryGetValue(scheduledItem.TargetId, out TargetId))
                {
                    errorMessage = string.Format("Could not find target local service with id \"{0}\"",
                                                 scheduledItem.SourceId);
                    return;
                }
            }
            else if (scheduledItem.TargetType == ScheduledItemTargetType.Partner)
            {
                if ((partnerIdToNameMap == null) || 
                    !partnerIdToNameMap.TryGetValue(scheduledItem.TargetId, out TargetId))
                {
                    errorMessage = string.Format("Could not find target partner service with id \"{0}\"",
                                                 scheduledItem.SourceId);
                    return;
                }
            }
            else
            {
                TargetId = scheduledItem.TargetId;
            }
            TargetFlow = scheduledItem.TargetFlow;
            TargetRequest = scheduledItem.TargetRequest;
            FrequencyType = scheduledItem.FrequencyType.ToString();
            Frequency = scheduledItem.Frequency;
            IsActive = scheduledItem.IsActive;
            if (scheduledItem.SourceArgs != null)
            {
                ArgsByName = scheduledItem.SourceArgs.IsByName;
                List<KeyValueSetting> args = null;
                CollectionUtils.ForEach(scheduledItem.SourceArgs.NameValuePairs, delegate(KeyValuePair<string, string> pair)
                {
                    CollectionUtils.Add(new KeyValueSetting(pair.Key, pair.Value), ref args);
                });
                Args = (args == null) ? null : args.ToArray();
            }
            errorMessage = null;
        }
    }
    [Serializable]
    public class NodeSettings
    {
        [XmlArrayItem(ElementName = "GlobalArgument")]
        public GlobalArgumentSetting[] GlobalArguments;
        [XmlArrayItem(ElementName = "DataSource")]
        public DataSourceSetting[] DataSources;
        [XmlArrayItem(ElementName = "NetworkPartner")]
        public NetworkPartnerSetting[] NetworkPartners;
        [XmlArrayItem(ElementName = "Exchange")]
        public ExchangeSetting[] Exchanges;
        [XmlArrayItem(ElementName = "Service")]
        public ServiceSetting[] Services;
        [XmlArrayItem(ElementName = "Schedule")]
        public ScheduleSetting[] Schedules;

        public void SetGlobalArguments(IEnumerable<ConfigItem> configItems)
        {
            List<GlobalArgumentSetting> list = null;
            CollectionUtils.ForEach(configItems, delegate(ConfigItem configItem)
            {
                CollectionUtils.Add(new GlobalArgumentSetting(configItem), ref list);
            });
            GlobalArguments = (list == null) ? null : list.ToArray();
        }
        public static IList<ConfigItem> GetGlobalArguments(IEnumerable<GlobalArgumentSetting> globalArguments,
                                                           string modifiedById, DateTime modifiedOn)
        {
            List<ConfigItem> list = null;
            CollectionUtils.ForEach(globalArguments, delegate(GlobalArgumentSetting globalArgument)
            {
                CollectionUtils.Add(globalArgument.ToConfigItem(modifiedById, modifiedOn), ref list);
            });
            return list;
        }
        public void SetDataSources(IEnumerable<DataProviderInfo> dataSources)
        {
            List<DataSourceSetting> list = null;
            CollectionUtils.ForEach(dataSources, delegate(DataProviderInfo dataSource)
            {
                CollectionUtils.Add(new DataSourceSetting(dataSource), ref list);
            });
            DataSources = (list == null) ? null : list.ToArray();
        }
        public void SetNetworkPartners(IEnumerable<PartnerIdentity> partners)
        {
            List<NetworkPartnerSetting> list = null;
            CollectionUtils.ForEach(partners, delegate(PartnerIdentity partnerIdentity)
            {
                CollectionUtils.Add(new NetworkPartnerSetting(partnerIdentity), ref list);
            });
            NetworkPartners = (list == null) ? null : list.ToArray();
        }
        public void SetExchanges(IEnumerable<DataFlow> flows)
        {
            List<ExchangeSetting> list = null;
            CollectionUtils.ForEach(flows, delegate(DataFlow dataFlow)
            {
                CollectionUtils.Add(new ExchangeSetting(dataFlow), ref list);
            });
            Exchanges = (list == null) ? null : list.ToArray();
        }
        public void SetServices(IEnumerable<DataFlow> flows)
        {
            List<ServiceSetting> list = null;
            CollectionUtils.ForEach(flows, delegate(DataFlow dataFlow)
            {
                CollectionUtils.ForEach(dataFlow.Services, delegate(DataService dataService)
                {
                    CollectionUtils.Add(new ServiceSetting(dataService, dataFlow.FlowName), ref list);
                });
            });
            Services = (list == null) ? null : list.ToArray();
        }
        public void SetSchedules(IEnumerable<ScheduledItem> schedules, IDictionary<string, string> flowIdToNameMap,
                                 IDictionary<string, string> serviceIdToNameMap,
                                 IDictionary<string, string> partnerIdToNameMap,
                                 out string errorMessage)
        {
            List<ScheduleSetting> list = null;
            StringBuilder errors = new StringBuilder();
            CollectionUtils.ForEach(schedules, delegate(ScheduledItem scheduledItem)
            {
                string itemErrorMessage;
                ScheduleSetting scheduleSetting =
                    new ScheduleSetting(scheduledItem, flowIdToNameMap, serviceIdToNameMap,
                                        partnerIdToNameMap, out itemErrorMessage);
                if (itemErrorMessage == null)
                {
                    CollectionUtils.Add(scheduleSetting, ref list);
                }
                else
                {
                    errors.AppendFormat("The schedule \"{0}\" could not be exported: {1}",
                                        scheduledItem.Name, itemErrorMessage);
                    errors.AppendLine();
                }
            });
            Schedules = (list == null) ? null : list.ToArray();
            errorMessage = (errors.Length == 0) ? null : errors.ToString();
        }
    }
}
