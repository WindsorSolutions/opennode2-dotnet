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
using System.Threading;
using System.Reflection;
using System.IO;
using System.Diagnostics;
using System.Web.Caching;
using System.Web;

using Windsor.Node2008.WNOSUtility;
using Windsor.Node2008.WNOSPlugin;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOS.Logic;
using Windsor.Node2008.WNOSProviders;
using Windsor.Node2008.WNOSConnector.Logic;
using Windsor.Commons.Core;
using Windsor.Commons.Logging;
using Windsor.Node2008.WNOS.Data;

using Spring.Core;
using Spring.Context.Support;
using Spring.Context;
using Spring.Data.Common;
using Spring.Transaction.Support;
using Wintellect.PowerCollections;

namespace Windsor.Node2008.WNOS.Utilities
{
    public interface IPluginDisposer : IDisposable
    {
    }
    public interface IPluginLoader
    {
        IPluginDisposer LoadSubmitProcessor(DataService inDataService, out ISubmitProcessor plugin);
        IPluginDisposer LoadSolicitProcessor(DataService inDataService, out ISolicitProcessor plugin);
        IPluginDisposer LoadQueryProcessor(DataService inDataService, out IQueryProcessor plugin);
        IPluginDisposer LoadNotifyProcessor(DataService inDataService, out INotifyProcessor plugin);
        IPluginDisposer LoadExecuteProcessor(DataService inDataService, out IExecuteProcessor plugin);
        IPluginDisposer LoadTaskProcessor(DataService inDataService, out ITaskProcessor plugin);

        /// <summary>
        /// Validate a processor without loading the instance.
        /// </summary>
        void ValidateSolicitProcessor(DataService inDataService);

        /// <summary>
        /// Validate a processor without loading the instance.
        /// </summary>
        void ValidateTaskProcessor(DataService inDataService);

        /// <summary>
        /// Validate a base plugin without loading the instance.
        /// </summary>
        void ValidateBasePlugin(DataService inDataService);

        /// <summary>
        /// Return all possible data service implementers for the input flow.
        /// </summary>
        ICollection<SimpleDataService> GetDataServiceImplementersForFlow(string flowId);

        string InstallPluginForFlow(byte[] zipFileContent, string modifiedById, string flowId);
    }

    public class PluginLoader : LoggerBase, IPluginLoader
    {
        private IConfigManager _configManager;
        private ICompressionHelper _compressionHelper;
        private IFlowDao _flowDao;
        private IPluginDao _pluginDao;

        private PluginDomainInstanceLoader _pluginDomainInstanceLoader;
        private string _pluginConfigFilePath;
        private string _pluginFolderPath;
        private bool _useSingleAppDomain;
        private bool _useAppDomains;

        private const string INSTALLING_DIRECTORY_PREFIX = "__INSTALLING__";

        public void Init()
        {
            FieldNotInitializedException.ThrowIfNull(this, ref _configManager);
            FieldNotInitializedException.ThrowIfNull(this, ref _compressionHelper);
            FieldNotInitializedException.ThrowIfNull(this, ref _flowDao);
            // If set, use doa, if not, don't:
            // FieldNotInitializedException.ThrowIfNull(this, ref _pluginDao);
            FieldNotInitializedException.ThrowIfNull(this, ref _compressionHelper);
            FieldNotInitializedException.ThrowIfEmptyString(this, ref _pluginConfigFilePath);
            FieldNotInitializedException.ThrowIfEmptyString(this, ref _pluginFolderPath);
            _pluginConfigFilePath = Path.GetFullPath(_pluginConfigFilePath);
            if (!File.Exists(_pluginConfigFilePath))
            {
                throw new FileNotFoundException(string.Format("The plugin config file does not exist: \"{0}\"",
                                                              _pluginConfigFilePath), _pluginConfigFilePath);
            }
            _pluginFolderPath = Path.GetFullPath(_pluginFolderPath);
            if (!Directory.Exists(_pluginFolderPath))
            {
                throw new DirectoryNotFoundException(string.Format("The plugin folder does not exist: \"{0}\"",
                                                                   _pluginFolderPath));
            }
            if (_useSingleAppDomain)
            {
                _pluginDomainInstanceLoader = new PluginDomainInstanceLoader(_pluginConfigFilePath);
            }
        }
        public virtual IPluginDisposer LoadSubmitProcessor(DataService inDataService, out ISubmitProcessor plugin)
        {
            return LoadPluginInterface<ISubmitProcessor>(inDataService, out plugin);
        }
        public virtual IPluginDisposer LoadSolicitProcessor(DataService inDataService, out ISolicitProcessor plugin)
        {
            return LoadPluginInterface<ISolicitProcessor>(inDataService, out plugin);
        }
        public virtual IPluginDisposer LoadQueryProcessor(DataService inDataService, out IQueryProcessor plugin)
        {
            return LoadPluginInterface<IQueryProcessor>(inDataService, out plugin);
        }
        public virtual IPluginDisposer LoadNotifyProcessor(DataService inDataService, out INotifyProcessor plugin)
        {
            return LoadPluginInterface<INotifyProcessor>(inDataService, out plugin);
        }
        public virtual IPluginDisposer LoadExecuteProcessor(DataService inDataService, out IExecuteProcessor plugin)
        {
            return LoadPluginInterface<IExecuteProcessor>(inDataService, out plugin);
        }
        public virtual IPluginDisposer LoadTaskProcessor(DataService inDataService, out ITaskProcessor plugin)
        {
            return LoadPluginInterface<ITaskProcessor>(inDataService, out plugin);
        }
        public virtual void ValidateSolicitProcessor(DataService inDataService)
        {
            ValidatePluginInterface<ISolicitProcessor>(inDataService);
        }
        public virtual void ValidateTaskProcessor(DataService inDataService)
        {
            ValidatePluginInterface<ITaskProcessor>(inDataService);
        }
        public virtual void ValidateBasePlugin(DataService inDataService)
        {
            ValidatePluginInterface<BaseWNOSPlugin>(inDataService);
        }
        public static ServiceType GetServiceType(BaseWNOSPlugin plugin)
        {
            ServiceType type = ServiceType.None;
            if (plugin is ISubmitProcessor)
            {
                type |= ServiceType.Submit;
            }
            if (plugin is ISolicitProcessor)
            {
                type |= ServiceType.Solicit;
            }
            if (plugin is IQueryProcessor)
            {
                type |= ServiceType.Query;
            }
            if (plugin is INotifyProcessor)
            {
                type |= ServiceType.Notify;
            }
            if (plugin is IExecuteProcessor)
            {
                type |= ServiceType.Execute;
            }
            if (plugin is ITaskProcessor)
            {
                type |= ServiceType.Task;
            }
            return type;
        }
        public virtual ICollection<SimpleDataService> GetDataServiceImplementersForFlow(string flowId)
        {
            const string CACHED_IMPLEMENTERS = "_CACHED_IMPLEMENTERS";
            string searchDirectory = VerifyPluginSubFolderWithHighestVersion(flowId);
            string parentDirPath = Path.GetDirectoryName(searchDirectory);
            string parentDirName = Path.GetFileName(parentDirPath);
            string cacheName = CACHED_IMPLEMENTERS + "_" + parentDirName;
            ICollection<SimpleDataService> implementers = HttpRuntime.Cache[cacheName] as ICollection<SimpleDataService>;
            if (implementers == null)
            {
                implementers = GetDataServiceImplementersInDirectory(searchDirectory, true);
                if (implementers == null)
                {
                    implementers = new List<SimpleDataService>();
                }
                HttpRuntime.Cache.Add(cacheName, implementers, new CacheDependency(parentDirPath),
                          DateTime.Now + TimeSpan.FromMinutes(20), Cache.NoSlidingExpiration,
                          CacheItemPriority.Default, null);
            }
            return implementers;
        }
        protected string GetPluginSubFolderWithHighestVersion(string flowId, out VersionInfo rtnVersion)
        {
            string parentFolderPath = GetPluginRootFolderForFlow(flowId);
            string rtnPath = null;
            rtnVersion = null;
            if (Directory.Exists(parentFolderPath))
            {
                foreach (string folderPath in Directory.GetDirectories(parentFolderPath, "*", SearchOption.TopDirectoryOnly))
                {
                    VersionInfo versionInfo;
                    if (VersionInfo.TryParse(Path.GetFileName(folderPath), out versionInfo))
                    {
                        bool test1 = rtnVersion < versionInfo;
                        bool test2 = rtnVersion > versionInfo;
                        bool test3 = rtnVersion <= versionInfo;
                        bool test4 = rtnVersion >= versionInfo;
                        if ((rtnVersion == null) || (rtnVersion < versionInfo))
                        {
                            rtnVersion = versionInfo;
                            rtnPath = folderPath;
                        }
                    }
                }
            }
            return rtnPath;
        }
        protected string VerifyPluginSubFolderWithHighestVersion(string flowId)
        {
            VersionInfo rtnVersion;
            string rtnPath = GetPluginSubFolderWithHighestVersion(flowId, out rtnVersion);
            // Now, check db for any plugins
            if (_pluginDao != null)
            {
                PluginItem pluginItem = _pluginDao.GetHighestVersionPlugin(flowId);
                if (pluginItem != null)
                {
                    bool installDbPlugin = (rtnVersion == null);
                    if (!installDbPlugin)
                    {
                        installDbPlugin = (rtnVersion < pluginItem.BinaryVersion);
                    }
                    if (installDbPlugin)
                    {
                        byte[] zipFileContent = _pluginDao.GetPluginZippedBinary(pluginItem.Id);
                        InstallPluginForFlow(zipFileContent, flowId, null, false, out rtnPath);
                    }
                }
            }
            if (rtnPath == null)
            {
                throw new InvalidOperationException(string.Format("A valid plugin has not been installed for the flow \"{0}\"",
                                                                  flowId));
            }
            return rtnPath;
        }
        protected virtual ICollection<SimpleDataService> GetDataServiceImplementersInDirectory(string inDirectoryPath,
                                                                                               bool ignoreInstallingAssemblies)
        {
            OrderedSet<SimpleDataService> implementers = new OrderedSet<SimpleDataService>();
            if (Directory.Exists(inDirectoryPath))
            {
                OrderedSet<string> processedAssemblies = new OrderedSet<string>();
                PluginDomainInstanceLoader loader = null;
                try
                {
                    PluginInstanceFinder pluginFinder = null;
                    foreach (string dllPath in Directory.GetFiles(inDirectoryPath, "*.dll", SearchOption.AllDirectories))
                    {
                        if (!ignoreInstallingAssemblies || !IsInstallingPluginAssemblyPath(dllPath))
                        {
                            string assemblyName = Path.GetFileName(dllPath);
                            if (!processedAssemblies.Contains(assemblyName))
                            {
                                string assemblyPath = GetPluginFilePathInDirectory(assemblyName, inDirectoryPath,
                                                                                   ignoreInstallingAssemblies);
                                if (assemblyPath != null)
                                {
                                    if (loader == null)
                                    {
                                        loader = new PluginDomainInstanceLoader(_pluginConfigFilePath);
                                        pluginFinder = loader.GetInstance<PluginInstanceFinder>();
                                    }
                                    GetDataServiceImplementers(pluginFinder, assemblyPath, ref implementers);
                                }
                                processedAssemblies.Add(assemblyName);
                            }
                        }
                    }
                }
                finally
                {
                    DisposableBase.SafeDispose(ref loader);
                }
            }
            return implementers;
        }
        protected SimpleDataService GetPrimaryImplementer(ICollection<SimpleDataService> implementers)
        {
            if (CollectionUtils.IsNullOrEmpty(implementers))
            {
                return null;
            }
            if (implementers.Count == 1)
            {
                return CollectionUtils.NthItem(implementers, 0);
            }
            SimpleDataService primaryImplementer = null;
            foreach (SimpleDataService implementer in implementers)
            {
                if (primaryImplementer == null)
                {
                    primaryImplementer = implementer;
                }
                else
                {
                    if (primaryImplementer.Version < implementer.Version)
                    {
                        primaryImplementer = implementer;
                    }
                }
            }
            return primaryImplementer;
        }
        public string InstallPluginForFlow(byte[] zipFileContent, string modifiedById, string flowId)
        {
            string pluginFolderPath;
            return InstallPluginForFlow(zipFileContent, flowId, modifiedById, true, out pluginFolderPath);
        }
        private string InstallPluginForFlow(byte[] zipFileContent, string flowId, string modifiedById,
                                            bool validateAgainstDbVersion, out string pluginFolderPath)
        {
            string parentFolderPath = GetPluginRootFolderForFlow(flowId);
            string tempDirPath = 
                Path.Combine(parentFolderPath, INSTALLING_DIRECTORY_PREFIX + Guid.NewGuid().ToString());
            try
            {
                // Extract files to installing directory
                _compressionHelper.UncompressDirectory(zipFileContent, tempDirPath);

                // Locate a valid base plugin and version #
                ICollection<SimpleDataService> implementers =
                    GetDataServiceImplementersInDirectory(tempDirPath, false);

                SimpleDataService primaryImplementer = GetPrimaryImplementer(implementers);
                if (primaryImplementer == null)
                {
                    throw new FileNotFoundException("A valid plugin implementer was not found in the zip file");
                }

                string installFolderPath = Path.Combine(parentFolderPath, primaryImplementer.Version.ToString());

                // Check that the incoming version is greater than any existing installed version
                VersionInfo curVersion;
                string rtnPath = GetPluginSubFolderWithHighestVersion(flowId, out curVersion);

                if (validateAgainstDbVersion && (_pluginDao != null))
                {
                    PluginItem pluginItem = _pluginDao.GetHighestVersionPlugin(flowId);
                    if (pluginItem != null)
                    {
                        if (curVersion != null)
                        {
                            if (pluginItem.BinaryVersion > curVersion)
                            {
                                curVersion = pluginItem.BinaryVersion;
                            }
                        }
                        else
                        {
                            curVersion = pluginItem.BinaryVersion;
                        }
                    }
                }
                
                if (curVersion != null)
                {
                    if (primaryImplementer.Version <= curVersion)
                    {
                        throw new InvalidOperationException(string.Format("A plugin with a newer or same version \"{0}\" is already installed for the flow \"{1}\"",
                                                                          curVersion.ToString(), _flowDao.GetDataFlowNameById(flowId)));
                    }
                }

                if ((_pluginDao != null) && !string.IsNullOrEmpty(modifiedById))
                {
                    PluginItem pluginItem = new PluginItem();
                    pluginItem.FlowId = flowId;
                    pluginItem.BinaryVersion = primaryImplementer.Version;
                    pluginItem.ModifiedById = modifiedById;
                    ITransactionOperations transactionTemplate = _pluginDao.GetTransactionTemplate();
                    transactionTemplate.Execute(delegate
                    {
                        _pluginDao.SavePlugin(pluginItem, zipFileContent);
                        // Rename the plugin directory with the version name
                        Directory.Move(tempDirPath, installFolderPath);
                        return null;
                    });
                }
                else
                {
                    // Rename the plugin directory with the version name
                    Directory.Move(tempDirPath, installFolderPath);
                }

                pluginFolderPath = installFolderPath;
                return string.Format("Successfully installed the plugin: \"{0}\"", primaryImplementer.ToString());
            }
            catch (Exception)
            {
                FileUtils.SafeDeleteDirectory(tempDirPath);
                throw;
            }
        }
        public virtual IPluginDisposer LoadPluginInterface<T>(DataService inDataService, out T plugin) where T : class
        {
            IPluginDisposer disposer =
                LoadPluginInterfaceInstance<T>(inDataService, true, out plugin);
            try
            {
                ConfigurePlugin<T>(inDataService, plugin);
            }
            catch (Exception)
            {
                DisposableBase.SafeDispose(ref disposer);
                throw;
            }
            return disposer;
        }
        protected virtual IPluginDisposer LoadPluginInterfaceInstance<T>(DataService inDataService,
                                                                         bool ignoreInstallingAssemblies,
                                                                         out T plugin) where T : class
        {
            return LoadPluginInterfaceInstance<T>(inDataService, ignoreInstallingAssemblies, 
                                                  _pluginConfigFilePath, out plugin);
        }
        protected virtual IPluginDisposer LoadPluginInterfaceInstance<T>(DataService inDataService,
                                                                         bool ignoreInstallingAssemblies,
                                                                         string pluginConfigFilePath,
                                                                         out T plugin) where T : class
        {
            string pluginFilePath = GetPluginFilePath(inDataService, ignoreInstallingAssemblies);
            string implementingClassName = inDataService.PluginInfo.ImplementingClassName;
            if (_useAppDomains)
            {
                if (_useSingleAppDomain)
                {
                    plugin = _pluginDomainInstanceLoader.GetInstance<T>(pluginFilePath,
                                                                        implementingClassName);
                    return null;
                }
                else
                {
                    PluginDomainInstanceLoader loader = new PluginDomainInstanceLoader(pluginConfigFilePath);
                    PluginDisposer disposer = new PluginDisposer(loader);
                    try
                    {
                        plugin = loader.GetInstance<T>(pluginFilePath, implementingClassName);
                    }
                    catch (Exception)
                    {
                        DisposableBase.SafeDispose(ref disposer);
                        throw;
                    }
                    return disposer;
                }
            }
            else
            {
                Assembly assembly;
                try
                {
                    assembly = Assembly.LoadFile(pluginFilePath);
                }
                catch (Exception e)
                {
                    throw new ArgumentException(string.Format("Could not load the assembly specified by inDataService.PluginInfo: \"{0}\"",
                                                              inDataService.PluginInfo.ToString()), e);
                }
                Type implementingType = assembly.GetType(implementingClassName, false, true);
                if (implementingType == null)
                {
                    throw new ArgumentException(string.Format("inDataService.PluginInfo (\"{0}\") does not specifiy a valid type that can be loaded from the assembly.",
                                                              inDataService.PluginInfo));
                }
                if (!typeof(T).IsAssignableFrom(implementingType))
                {
                    throw new ArgumentException(string.Format("inDataService.PluginInfo (\"{0}\") does not specifiy a type that is assignable to : \"{1}\"",
                                                              inDataService.PluginInfo.ToString(), typeof(T).ToString()));
                }
                try
                {
                    plugin = (T)assembly.CreateInstance(implementingType.FullName);
                }
                catch (Exception e)
                {
                    throw new ArgumentException(string.Format("Could not load an instance of the type specified by inDataService.PluginInfo: \"{0}\"",
                                                              inDataService.PluginInfo.ToString()), e);
                }
                return null;
            }
        }
        protected bool GetDataServiceImplementers(PluginInstanceFinder pluginFinder, string inAssemblyPath,
                                                  ref OrderedSet<SimpleDataService> ioImplementers)
        {
            try
            {
                return pluginFinder.FindPluginInstances(inAssemblyPath, ref ioImplementers);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public string GetPluginRootFolder()
        {
            return _pluginFolderPath;
        }
        public string GetPluginRootFolderForFlow(string flowId)
        {
            string flowName = _flowDao.GetDataFlowNameById(flowId);
            string parentFolderPath = Path.Combine(_pluginFolderPath, flowName);
            if (!Directory.Exists(parentFolderPath))
            {
                Directory.CreateDirectory(parentFolderPath);
            }
            return parentFolderPath;
        }
        protected string GetPluginFilePath(DataService inDataService, bool ignoreInstallingAssemblies)
        {
            if (inDataService == null)
            {
                throw new ArgumentException("inDataService is null");
            }
            if (inDataService.PluginInfo == null)
            {
                throw new ArgumentException("inDataService.PluginInfo is null");
            }
            if (string.IsNullOrEmpty(inDataService.PluginInfo.AssemblyName))
            {
                throw new ArgumentException("inDataService.PluginInfo.AssemblyName in null");
            }
            if (string.IsNullOrEmpty(inDataService.PluginInfo.ImplementingClassName))
            {
                throw new ArgumentException("inDataService.PluginInfo.ImplementingClassName");
            }
            string pluginFilePath = GetPluginFilePath(inDataService.PluginInfo.AssemblyName,
                                                      inDataService.FlowId, ignoreInstallingAssemblies);
            if (string.IsNullOrEmpty(pluginFilePath))
            {
                throw new ArgumentException(string.Format("Could not find plugin for data service \"{0}\"",
                                                          inDataService.Name));
            }
            return pluginFilePath;
        }
        protected bool IsInstallingPluginAssemblyPath(string assemblyPath)
        {
            return assemblyPath.Contains(INSTALLING_DIRECTORY_PREFIX);
        }
        protected string GetPluginFilePathInDirectory(string inAssemblyName, string inDirectoryPath,
                                                      bool ignoreInstallingAssemblies)
        {
            string assemblyFileName = inAssemblyName;
            if (Path.GetExtension(assemblyFileName).ToLower() != ".dll")
            {
                assemblyFileName += ".dll";
            }
            string[] paths = Directory.GetFiles(inDirectoryPath, assemblyFileName, SearchOption.AllDirectories);
            if (paths.Length == 1)
            {
                if (!ignoreInstallingAssemblies || !IsInstallingPluginAssemblyPath(paths[0]))
                {
                    return paths[0];
                }
            }
            // If more than one possible plugin, return highest version
            string rtnPath = null;
            FileVersionInfo rtnVersionInfo = null;
            foreach (string filePath in paths)
            {
                if (!ignoreInstallingAssemblies || !IsInstallingPluginAssemblyPath(filePath))
                {
                    FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(filePath);
                    if (rtnPath == null)
                    {
                        rtnVersionInfo = versionInfo;
                        rtnPath = filePath;
                    }
                    else
                    {
                        if (FileUtils.CompareFileVersions(rtnVersionInfo, versionInfo) < 0)
                        {
                            rtnVersionInfo = versionInfo;
                            rtnPath = filePath;
                        }
                    }
                }
            }
            return rtnPath;
        }
        protected string GetPluginFilePath(string inAssemblyName, string flowId,
                                           bool ignoreInstallingAssemblies)
        {
            string searchDirectory = VerifyPluginSubFolderWithHighestVersion(flowId);
            return GetPluginFilePathInDirectory(inAssemblyName, searchDirectory, ignoreInstallingAssemblies);
        }
        protected virtual void ConfigurePlugin<T>(DataService inDataService, T ioPlugin) where T : class
        {

            BaseWNOSPlugin basePlugin = ioPlugin as BaseWNOSPlugin;
            if (basePlugin == null)
            {
                return;
            }
            if (!CollectionUtils.KeysMatch(inDataService.Args, basePlugin.ConfigurationArguments))
            {
                throw new ArgumentException(string.Format("The user-defined arguments for the service \"{0}\" do not match the arguments required by the service plugin \"{1}\".",
                                                          inDataService.Name, inDataService.PluginInfo.ImplementingClassName));
            }
            if (!CollectionUtils.IsNullOrEmpty(inDataService.Args))
            {
                foreach (KeyValuePair<string, string> arg in inDataService.Args)
                {
                    string val = arg.Value;

                    if ((val != null) && val.StartsWith(ConfigItem.GLOBAL_ARG_INDICATOR))
                    {
                        string globalKeyName = val.Replace(ConfigItem.GLOBAL_ARG_INDICATOR, string.Empty);

                        ConfigItem configItem = _configManager.Get(globalKeyName);

                        if (configItem == null)
                        {
                            throw new ArgumentException("Invalid global key argument: " + configItem);
                        }
                        else
                        {
                            val = configItem.Value;
                        }
                    }

                    basePlugin.SetConfigurationArgument(arg.Key, val);
                }
            }
            if (!CollectionUtils.KeysMatch(inDataService.DataSources, basePlugin.DataProviders))
            {
                throw new ArgumentException(string.Format("The user-defined data sources for the service \"{0}\" do not match the data sources required by the service plugin \"{1}\".",
                                                          inDataService.Name, inDataService.PluginInfo.ImplementingClassName));
            }
            if (!CollectionUtils.IsNullOrEmpty(inDataService.DataSources))
            {
                foreach (KeyValuePair<string, DataProviderInfo> arg in inDataService.DataSources)
                {
                    DataProviderInfo provider = arg.Value;
                    basePlugin.SetDataProvider(arg.Key, provider);
                }
            }

            basePlugin.ValidateConfiguration();
        }

        void basePlugin_OnWNOSPluginAuditLogginEvent(string message)
        {
        }
        protected void ValidatePluginInterface<T>(DataService inDataService) where T : class
        {

            T plugin;
            using (IPluginDisposer disposer = LoadPluginInterfaceInstance<T>(inDataService, true, null, out plugin)) { }
        }
        public IConfigManager ConfigManager
        {
            get
            {
                return _configManager;
            }
            set
            {
                _configManager = value;
            }
        }
        public ICompressionHelper CompressionHelper
        {
            get { return _compressionHelper; }
            set { _compressionHelper = value; }
        }
        public IFlowDao FlowDao
        {
            get { return _flowDao; }
            set { _flowDao = value; }
        }
        public IPluginDao PluginDao
        {
            get { return _pluginDao; }
            set { _pluginDao = value; }
        }
        public string PluginConfigFilePath
        {
            get { return _pluginConfigFilePath; }
            set { _pluginConfigFilePath = value; }
        }
        public string PluginFolderPath
        {
            get { return _pluginFolderPath; }
            set { _pluginFolderPath = value; }
        }
        public bool UseSingleAppDomain
        {
            get { return _useSingleAppDomain; }
            set { _useSingleAppDomain = value; }
        }
        public bool UseAppDomains
        {
            get { return _useAppDomains; }
            set { _useAppDomains = value; }
        }
        private class PluginDisposer : DisposableBase, IPluginDisposer
        {
            AppDomainInstanceLoader _loader;
            public PluginDisposer(AppDomainInstanceLoader loader)
            {
                _loader = loader;
            }
            protected override void OnDispose(bool inIsDisposing)
            {
                if (inIsDisposing)
                {
                    DisposableBase.SafeDispose(ref _loader);
                }
            }
        }
        protected class PluginDomainInstanceLoader : AppDomainInstanceLoader
        {
            string _springConfigFilePath;
            public PluginDomainInstanceLoader(string springConfigFilePath)
            {
                _springConfigFilePath = springConfigFilePath;
            }
            protected override AppDomain CreateAppDomain()
            {
                AppDomain appDomain = base.CreateAppDomain();

                if (_springConfigFilePath != null)
                {
                    // Initialize the main Spring ApplicationContext for the domain
                    string assemblyPath = Assembly.GetExecutingAssembly().FullName;
                    string fullName = typeof(SpringContextInitializer).FullName;
                    SpringContextInitializer initer = (SpringContextInitializer)
                        appDomain.CreateInstanceAndUnwrap(assemblyPath, fullName);
                    initer.InitSpring(_springConfigFilePath);
                }

                return appDomain;
            }
            private class SpringContextInitializer : MarshalByRefObjectIndefinite
            {
                public void InitSpring(string configFilePath)
                {
                    // Setup this context as the main ApplicationContext
                    IApplicationContext context = new XmlApplicationContext(configFilePath);
                    ContextRegistry.RegisterContext(context);
                }
            }
        }
        protected class PluginInstanceFinder : MarshalByRefObjectIndefinite
        {
            public bool FindPluginInstances(string inAssemblyPath, ref OrderedSet<SimpleDataService> ioImplementers)
            {
                FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(inAssemblyPath);
                Assembly assembly = Assembly.LoadFile(inAssemblyPath);
                Type[] exportedTypes = assembly.GetExportedTypes();
                Type findType = typeof(BaseWNOSPlugin);
                bool addedAny = false;
                foreach (Type exportedType in exportedTypes)
                {
                    if (exportedType.IsClass && !exportedType.IsAbstract && findType.IsAssignableFrom(exportedType))
                    {
                        ExecutableInfo executableInfo =
                                new ExecutableInfo(exportedType.Assembly.ManifestModule.Name,
                                                   exportedType.FullName);

                        BaseWNOSPlugin plugin;
                        try
                        {
                            plugin =
                                AppDomainInstanceLoader.GetInstance<BaseWNOSPlugin>(AppDomain.CurrentDomain, inAssemblyPath,
                                                                                    exportedType.FullName);
                        }
                        catch(Exception)
                        {
                            continue;
                        }
                        SimpleDataService dataService = new SimpleDataService();
                        if (!CollectionUtils.IsNullOrEmpty(plugin.ConfigurationArguments))
                        {
                            dataService.Args = new List<string>(plugin.ConfigurationArguments.Keys);
                        }
                        if (!CollectionUtils.IsNullOrEmpty(plugin.DataProviders))
                        {
                            dataService.DataSources = new List<string>(plugin.DataProviders.Keys);
                        }
                        dataService.Type = PluginLoader.GetServiceType(plugin);
                        if (dataService.Type != ServiceType.None)
                        {
                            dataService.PluginInfo = executableInfo;
                            dataService.Version = new VersionInfo(fileVersionInfo);
                            ioImplementers.Add(dataService);
                            addedAny = true;
                        }
                    }
                }
                return addedAny;
            }
        }
    }
}