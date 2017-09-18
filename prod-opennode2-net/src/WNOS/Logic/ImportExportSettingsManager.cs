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
using System.IO;

using Common.Logging;

using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOS.Data;
using Windsor.Node2008.WNOS.Logic;
using Windsor.Node2008.WNOSUtility;
using Windsor.Node2008.WNOSConnector.Logic;
using Windsor.Commons.Core;
using Windsor.Node2008.WNOSProviders;

namespace Windsor.Node2008.WNOS.Logic
{
    /// <summary>
    /// Service manager implementation.  The service manager provides the business logic and access to all services 
    /// related to a data flow.
    /// </summary>
    public class ImportExportSettingsManager : LogicAuditBaseManager, IImportExportSettingsManager
    {
        private IConfigManager _configManager;
        private IDataProviderManager _dataProviderManager;
        private IPartnerManager _partnerManager;
        private IFlowManager _flowManager;
        private IServiceManager _serviceManager;
        private IScheduleManager _scheduleManager;
        private ICompressionHelper _compressionHelper;
        private ISerializationHelper _serializationHelper;

        new public void Init()
        {
			base.Init();

            FieldNotInitializedException.ThrowIfNull(this, ref _configManager);
            FieldNotInitializedException.ThrowIfNull(this, ref _dataProviderManager);
            FieldNotInitializedException.ThrowIfNull(this, ref _partnerManager);
            FieldNotInitializedException.ThrowIfNull(this, ref _flowManager);
            FieldNotInitializedException.ThrowIfNull(this, ref _serviceManager);
            FieldNotInitializedException.ThrowIfNull(this, ref _compressionHelper);
            FieldNotInitializedException.ThrowIfNull(this, ref _serializationHelper);
        }
        public byte[] ExportSettingsAsZippedBytes(ImportExportSettings settingsToExport, NodeVisit visit)
        {
            ValidateByRole(visit, SystemRoleType.Admin);

            NodeSettings nodeSettings = new NodeSettings();

            string errorMessage = null;

            if (EnumUtils.IsFlagSet(settingsToExport, ImportExportSettings.GlobalArguments))
            {
                nodeSettings.SetGlobalArguments(ConfigManager.Get(ConfigurationType.All));
            }
            if (EnumUtils.IsFlagSet(settingsToExport, ImportExportSettings.DataSources))
            {
                nodeSettings.SetDataSources(DataProviderManager.Get());
            }
            if (EnumUtils.IsFlagSet(settingsToExport, ImportExportSettings.NetworkPartners))
            {
                nodeSettings.SetNetworkPartners(PartnerManager.Get());
            }
            bool exportExchanges = EnumUtils.IsFlagSet(settingsToExport, ImportExportSettings.Exchanges);
            bool exportServices = EnumUtils.IsFlagSet(settingsToExport, ImportExportSettings.Services);
            if (exportExchanges || exportServices)
            {
                IList<DataFlow> flows = FlowManager.GetAllDataFlows(exportServices, false);
                if (exportExchanges)
                {
                    nodeSettings.SetExchanges(flows);
                }
                if (exportServices)
                {
                    nodeSettings.SetServices(flows);
                }
            }
            if (EnumUtils.IsFlagSet(settingsToExport, ImportExportSettings.Schedules))
            {
                IDictionary<string, string> flowIdToNameMap = FlowManager.GetAllFlowsIdToNameMap();
                IDictionary<string, string> serviceIdToNameMap = ServiceManager.GetAllServicesIdToNameMap();
                IDictionary<string, string> partnerIdToNameMap = PartnerManager.GetAllPartnersIdToNameMap();

                nodeSettings.SetSchedules(ScheduleManager.GetSchedules(), flowIdToNameMap, serviceIdToNameMap,
                                          partnerIdToNameMap, out errorMessage);
            }

            string tempFilePath = SettingsProvider.NewTempFilePath();

            _compressionHelper.Compress("Settings.xml", _serializationHelper.SerializeWithLineBreaks(nodeSettings),
                                        tempFilePath);
            if (errorMessage != null)
            {
                _compressionHelper.Compress("Errors.txt", Encoding.UTF8.GetBytes(errorMessage), tempFilePath);
            }

            byte[] zippedData = File.ReadAllBytes(tempFilePath);

            ActivityManager.LogAudit(NodeMethod.None, null, visit, "{0} exported the following node settings: {1}.",
                                     visit.Account.NaasAccount, settingsToExport);
            return zippedData;
        }
        public string ImportSettings(byte[] settingsFileBytes, ImportExportSettings settingsToImport,
                                     ImportSettingsAction importAction, NodeVisit visit)
        {
            ValidateByRole(visit, SystemRoleType.Admin);

            if (settingsToImport == ImportExportSettings.None)
            {
                return null;
            }
            if (_compressionHelper.IsCompressed(settingsFileBytes))
            {
                try
                {
                    settingsFileBytes = _compressionHelper.UncompressDeep(settingsFileBytes);
                }
                catch (Exception e)
                {
                    throw new ArgException("Failed to uncompress zip file content: " + e.Message);
                }
            }
            NodeSettings nodeSettings;
            try
            {
                nodeSettings = _serializationHelper.Deserialize<NodeSettings>(settingsFileBytes);
            }
            catch (Exception e)
            {
                throw new ArgException("Failed to deserialize node settings content: " + e.Message);
            }
            string errorMessage = null;
            DateTime modifiedOn = DateTime.Now;
            string modifiedById = visit.Account.Id;

            if (EnumUtils.IsFlagSet(settingsToImport, ImportExportSettings.GlobalArguments))
            {
                IList<ConfigItem> list =
                    NodeSettings.GetGlobalArguments(nodeSettings.GlobalArguments, modifiedById,
                                                    modifiedOn);
                ConfigManager.Import(list, importAction);
            }
            return errorMessage;
        }
        public IConfigManager ConfigManager
        {
            get { return _configManager; }
            set { _configManager = value; }
        }
        public IDataProviderManager DataProviderManager
        {
            get { return _dataProviderManager; }
            set { _dataProviderManager = value; }
        }
        public IPartnerManager PartnerManager
        {
            get { return _partnerManager; }
            set { _partnerManager = value; }
        }
        public IFlowManager FlowManager
        {
            get { return _flowManager; }
            set { _flowManager = value; }
        }
        public IServiceManager ServiceManager
        {
            get { return _serviceManager; }
            set { _serviceManager = value; }
        }
        public IScheduleManager ScheduleManager
        {
            get { return _scheduleManager; }
            set { _scheduleManager = value; }
        }
        public ICompressionHelper CompressionHelper
        {
            get { return _compressionHelper; }
            set { _compressionHelper = value; }
        }
        public ISerializationHelper SerializationHelper
        {
            get { return _serializationHelper; }
            set { _serializationHelper = value; }
        }
    }
}
