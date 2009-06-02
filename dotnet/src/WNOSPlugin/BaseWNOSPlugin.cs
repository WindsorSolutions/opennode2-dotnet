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
using System.Text;
using System.Data;
using System.Data.Common;
using System.Reflection;
using System.IO;
using Spring.Data.Generic;
using Spring.Context;
using Spring.Context.Support;
using Spring.Objects.Factory;
using Common.Logging;
using Spring.Data.Common;
using Windsor.Node2008.WNOSUtility;
using Windsor.Node2008.WNOSProviders;
using Windsor.Node2008.WNOSDomain;
using Windsor.Commons.Core;
using Windsor.Commons.Logging;
using Windsor.Commons.Spring;
using System.Xml;

namespace Windsor.Node2008.WNOSPlugin
{

    public delegate void WNOSPluginAuditLogginHandler(string message);

    /// <summary>
    /// All plugin implementations must descend from this class, then implement one or more of the 
    /// relevant Node method interfaces contained within the WNOSPlugin namespace: IExecuteProcessor, 
    /// INotifyProcessor, IQueryProcessor, ISolicitProcessor, ISubmitProcessor, etc.
    /// 
    /// For example, if you want to handle submits for a flow, your class declaration would look
    /// something like:
    /// 
    ///     class MySubmitProcessor : WNOSPlugin, ISubmitProcessor
    ///     {
    ///     }
    ///     
    /// Your class would then implement the ISubmitProcessor.ProcessSubmit() method, which would
    /// handle Submit operations for the node for a given flow.  Your class would then be wrapped in
    /// its own namespace and assembly, and the assembly dll and pdb files would be uploaded to the 
    /// flow is associated with the plugin (using the Node Admin gui interface).
    /// 
    /// If you plugin requires data providers or config parameters at runtime, add items to the
    /// DataProviders and ConfigurationArguments properties in your plugin constructor.  These
    /// properties will be set at runtime when the plugin is instantiated and called by the node
    /// orchestration service.
    /// </summary>
    public abstract class BaseWNOSPlugin : MarshalByRefObjectIndefinite, IAppendAuditLogEvent
    {
        private static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());

        #region Members
        private readonly Dictionary<string, string> _configurationArguments;
        private readonly Dictionary<string, IDbProvider> _dataProviders;
        private IServiceFactory _serviceFactory;
        private IDbProviderFactory _dbConnectionFactory;
        private List<ActivityEntry> _auditLogEvents;
        protected static readonly DateTime MIN_VALID_DATE_TIME = new DateTime(1800, 1, 1);
        protected static readonly DateTime MAX_VALID_DATE_TIME = new DateTime(2999, 1, 1);
        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor of the base implemnentation
        /// </summary>
        protected BaseWNOSPlugin()
        {
            //Initialize base arguments
            _configurationArguments = new Dictionary<string, string>();
            _dataProviders = new Dictionary<string, IDbProvider>();
        }
        #endregion

        #region Validation

        /// <summary>
        /// Will be called by WNOS after the plugin is initialized and configure
        /// to assure that the business rules reuired by the plugin are met
        /// </summary>
        public virtual void ValidateConfiguration()
        {
            //No values to check on the default plugin but we 
            //do not want to force all the overrides to implement it
            //so no abstract indicator
        }

        #endregion

        #region Event Rase Util

        public void AppendAuditLogEvent(string message, params object[] args)
        {
            if (!CollectionUtils.IsNullOrEmpty(args))
            {
                message = string.Format(message, args);
            }
            if (_auditLogEvents == null)
            {
                _auditLogEvents = new List<ActivityEntry>();
            }
            _auditLogEvents.Add(new ActivityEntry(message));
        }
        #endregion

        protected string GetConfigParameter(string key)
        {
            string value = null;
            ConfigurationArguments.TryGetValue(key, out value);
            return value;
        }
        protected bool TryGetConfigParameter<T>(string key, ref T value)
        {
            T getValue;
            if (GetConfigParameter<T>(key, false, out getValue))
            {
                value = getValue;
                return true;
            }
            return false;
        }
        protected bool GetConfigParameter<T>(string key, bool throwExceptionOnError, out T value)
        {
            value = default(T);
            string valueStr;
            if (!ConfigurationArguments.TryGetValue(key, out valueStr) || string.IsNullOrEmpty(valueStr))
            {
                if (throwExceptionOnError)
                {
                    throw new ArgumentNullException(string.Format("The service configuration value \"{0}\" was not specified", key));
                }
                return false;
            }
            try
            {
                if (typeof(T) == typeof(TimeSpan))
                {
                    value = (T)Convert.ChangeType(TimeSpan.Parse(valueStr), typeof(T));
                }
                else
                {
                    value = (T)Convert.ChangeType(valueStr, typeof(T));
                }
                return true;
            }
            catch (Exception e)
            {
                if (throwExceptionOnError)
                {
                    throw new ArgumentException(string.Format("The service configuration value \"{0}\" was specified as \"{1},\" but it cannot be converted to the type \"{2}\"",
                                                              key, valueStr, typeof(T).Name), e);
                }
                else
                {
                    AppendAuditLogEvent("Failed to convert service configuration value \"{0}\" to type \"{1}\": {2}", 
                                        valueStr, typeof(T).Name, ExceptionUtils.ToShortString(e));
                }
                return false;
            }
        }
        /// <summary>
        /// Return a non-empty string value for the config key.  If the value has not been specified as a config
        /// param, return null.  If the value has been specified but is empty, throw an exception.
        /// </summary>
        protected string ValidateNonEmptyConfigParameter(string key)
        {
            string value = null;
            if (ConfigurationArguments.TryGetValue(key, out value) && (string.IsNullOrEmpty(value)))
            {
                throw new ArgumentException(string.Format("Missing or invalid \"{0}\" configuration parameter specified for this service",
                                                          key));
            }
            return value;
        }
        protected string ValidateExistingFolderConfigParameter(string key)
        {
            string folderPath = ValidateNonEmptyConfigParameter(key);
            if (!Directory.Exists(folderPath))
            {
                throw new DirectoryNotFoundException(string.Format("The directory specified for this service, \"{0},\" does not exist",
                                                     folderPath));
            }
            return folderPath;
        }
        protected SpringBaseDao ValidateDBProvider(string key)
        {
            return ValidateDBProvider(key, null);
        }
        protected SpringBaseDao ValidateDBProvider(string key, Type dbProviderType)
        {
            IDbProvider dbProvider;
            if (!DataProviders.TryGetValue(key, out dbProvider) ||
                (dbProvider == null))
            {
                throw new ArgumentException(string.Format("Missing or invalid \"{0}\" data source specified for this service",
                                                          key));
            }
            return (dbProviderType == null) ? new SpringBaseDao(dbProvider) : new SpringBaseDao(dbProvider, dbProviderType);
        }
        protected static bool TryGetNonEmptyStringParameter(DataRequest dataRequest, string name, int index, ref string value)
        {
            string strValue = null;
            if (TryGetParameter(dataRequest, name, index, ref strValue))
            {
                if (!string.IsNullOrEmpty(strValue))
                {
                    value = strValue;
                    return true;
                }
            }
            return false;
        }
        protected static bool TryGetParameter<T>(DataRequest dataRequest, string name, int index, ref T value)
        {
            if ((dataRequest == null) || (dataRequest.Parameters == null) || (dataRequest.Parameters.Count == 0))
            {
                return false;
            }
            if (dataRequest.Parameters.IsByName)
            {
                return TryGetParameterByName<T>(dataRequest.Parameters, name, ref value);
            }
            else
            {
                return TryGetParameterByIndex<T>(dataRequest.Parameters, index, ref value);
            }
        }
        protected static void GetParameter<T>(DataRequest dataRequest, string name, int index, out T value)
        {
            if ((dataRequest == null) || (dataRequest.Parameters == null) || (dataRequest.Parameters.Count == 0))
            {
                throw new ArgumentException("No parameters were specified");
            }
            if (dataRequest.Parameters.IsByName)
            {
                GetParameterByName<T>(dataRequest.Parameters, name, true, out value);
            }
            else
            {
                GetParameterByIndex<T>(dataRequest.Parameters, index, true, out value);
            }
        }
        protected static void GetParameterByName<T>(DataRequest dataRequest, string name,
                                                    out T value)
        {
            GetParameterByName<T>(dataRequest.Parameters, name, true, out value);
        }
        protected static void GetParameterByName<T>(ByIndexOrNameDictionary<string> parameters, string name,
                                                    out T value)
        {
            GetParameterByName<T>(parameters, name, true, out value);
        }
        protected static bool TryGetParameterByName<T>(DataRequest dataRequest,
                                                       string name, ref T value)
        {
            return TryGetParameterByName(dataRequest.Parameters, name, ref value);
        }
        protected static bool TryGetParameterByName<T>(ByIndexOrNameDictionary<string> parameters,
                                                       string name, ref T value)
        {
            T foundValue;
            if (GetParameterByName<T>(parameters, name, false, out foundValue))
            {
                value = foundValue;
                return true;
            }
            return false;
        }
        protected static bool GetParameterByName<T>(DataRequest dataRequest, string name,
                                                    bool throwExceptionOnError, out T value)
        {
            return GetParameterByName<T>(dataRequest.Parameters, name, throwExceptionOnError, out value);
        }
        protected static bool GetParameterByName<T>(ByIndexOrNameDictionary<string> parameters, string name,
                                                    bool throwExceptionOnError, out T value)
        {
            value = default(T);
            string valueStr;
            if (CollectionUtils.IsNullOrEmpty(parameters) || !parameters.TryGetValue(name, out valueStr) ||
                string.IsNullOrEmpty(valueStr))
            {
                if (throwExceptionOnError)
                {
                    throw new ArgumentNullException(string.Format("The service parameter \"{0}\" was not specified",
                                                                  name));
                }
                return false;
            }
            try
            {
                if (typeof(T) == typeof(TimeSpan))
                {
                    value = (T)Convert.ChangeType(TimeSpan.Parse(valueStr), typeof(T));
                }
                else
                {
                    value = (T)Convert.ChangeType(valueStr, typeof(T));
                }
                return true;
            }
            catch (Exception e)
            {
                if (throwExceptionOnError)
                {
                    throw new ArgumentException(string.Format("The service parameter \"{0}\" was specified as \"{1},\" but it cannot be converted to the type \"{2}\"",
                                                              name, valueStr, typeof(T).Name), e);
                }
                return false;
            }
        }
        protected static void GetParameterByIndex<T>(DataRequest dataRequest, int index,
                                                    out T value)
        {
            GetParameterByIndex<T>(dataRequest.Parameters, index, true, out value);
        }
        protected static void GetParameterByIndex<T>(IList<string> parameters, int index,
                                                    out T value)
        {
            GetParameterByIndex<T>(parameters, index, true, out value);
        }
        protected static void GetNonEmptyStringParameterByIndex(IList<string> parameters, int index,
                                                                out string value)
        {
            GetParameterByIndex<string>(parameters, index, true, out value);
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(string.Format("The string parameter at index {0} is empty",
                                                          index.ToString()));
            }
        }
        protected static bool TryGetNonEmptyStringParameterByName(ByIndexOrNameDictionary<string> parameters,
                                                                  string name, ref string value)
        {
            if (TryGetParameterByName<string>(parameters, name, ref value))
            {
                if (!string.IsNullOrEmpty(value))
                {
                    return true;
                }
            }
            return false;
        }
        protected static bool TryGetNonEmptyStringParameterByName(DataRequest dataRequest,
                                                                  string name, ref string value)
        {
            return TryGetNonEmptyStringParameterByName(dataRequest.Parameters, name, ref value);
        }
        protected static void GetNonEmptyStringParameterByName(ByIndexOrNameDictionary<string> parameters,
                                                               string name, out string value)
        {
            GetParameterByName<string>(parameters, name, out value);
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(string.Format("The string parameter with the name {0} is empty",
                                                          name));
            }
        }
        protected static void GetNonEmptyStringParameterByName(DataRequest dataRequest,
                                                               string name, out string value)
        {
            GetNonEmptyStringParameterByName(dataRequest.Parameters, name, out value);
        }
        protected static void GetNonEmptyStringParameterByIndex(DataRequest dataRequest, int index,
                                                                out string value)
        {
            GetNonEmptyStringParameterByIndex(dataRequest.Parameters, index, out value);
        }
        protected static bool TryGetParameterByIndex<T>(DataRequest dataRequest,
                                                        int index, ref T value)
        {
            return TryGetParameterByIndex(dataRequest.Parameters, index, ref value);
        }
        protected static bool TryGetNonEmptyStringParameterByIndex(DataRequest dataRequest,
                                                                   int index, ref string value)
        {
            return TryGetNonEmptyStringParameterByIndex(dataRequest.Parameters, index, ref value);
        }
        protected static bool TryGetNonEmptyStringParameterByIndex(IList<string> parameters,
                                                                   int index, ref string value)
        {
            string strValue = null;
            if (TryGetParameterByIndex(parameters, index, ref strValue))
            {
                if (!string.IsNullOrEmpty(strValue))
                {
                    value = strValue;
                    return true;
                }
            }
            return false;
        }
        protected static bool TryGetParameterByIndex<T>(IList<string> parameters,
                                                        int index, ref T value)
        {
            T foundValue;
            if (GetParameterByIndex<T>(parameters, index, false, out foundValue))
            {
                value = foundValue;
                return true;
            }
            return false;
        }
        protected static bool GetParameterByIndex<T>(DataRequest dataRequest, int index,
                                                     bool throwExceptionOnError, out T value)
        {
            return GetParameterByIndex<T>(dataRequest.Parameters, index, throwExceptionOnError, out value);
        }
        protected static bool GetParameterByIndex<T>(IList<string> parameters, int index,
                                                    bool throwExceptionOnError, out T value)
        {
            value = default(T);
            if (CollectionUtils.IsNullOrEmpty(parameters) || (parameters.Count <= index) ||
                string.IsNullOrEmpty(parameters[index]))
            {
                if (throwExceptionOnError)
                {
                    throw new ArgumentNullException(string.Format("The service parameter at index \"{0}\" was not specified",
                                                                  index.ToString()));
                }
                return false;
            }
            try
            {
                value = (T)Convert.ChangeType(parameters[index], typeof(T));
                return true;
            }
            catch (Exception)
            {
                if (throwExceptionOnError)
                {
                    throw new ArgumentException(string.Format("The service parameter at index \"{0}\" was specified as \"{1},\" but cannot be converted to type \"{2}\"",
                                                              index.ToString(), parameters[index], typeof(T).Name));
                }
                return false;
            }
        }
        #region Service Providers

        private IServiceFactory ServiceFactory
        {
            get
            {
                if (_serviceFactory == null)
                {
                    _serviceFactory = SpringUtils.GetServiceImplementation<IServiceFactory>(ContextRegistry.GetContext());
                }
                return _serviceFactory;
            }
        }
        private IDbProviderFactory DbConnectionFactory
        {
            get
            {
                if (_dbConnectionFactory == null)
                {
                    GetServiceImplementation(out _dbConnectionFactory);
                }
                return _dbConnectionFactory;
            }
        }
        /// <summary>
        /// Fetches interface implementation from the application context
        /// </summary>
        /// <typeparam name="T">Type of the desired object. Most likelly a service interface</typeparam>
        /// <returns>Instance of the specfied type based on the Spring context defenition</returns>
        public void GetServiceImplementation<T>(out T implementation) where T : class
        {
            LOG.Debug("Getting service using default application context");
            implementation = ServiceFactory.GetServiceImplementation<T>();
        }
        /// <summary>
        /// Fetches interface implementation from the application context
        /// </summary>
        /// <typeparam name="T">Type of the desired object. Most likelly a service interface</typeparam>
        /// <returns>Instance of the specfied type based on the Spring context defenition</returns>
        public T GetServiceImplementation<T>() where T : class
        {
            LOG.Debug("Getting service using default application context");
            return ServiceFactory.GetServiceImplementation<T>();
        }

        protected PaginatedContentResult GetXmlPaginatedContentResult(byte[] content, int rowIndex,
                                                                      int maxRowCount, bool isLast)
        {
            PaginatedContentResult result = new PaginatedContentResult();
            result.Content = new SimpleContent();
            result.Content.Type = CommonContentType.XML;
            result.Content.Content = content;
            result.Paging = new PaginationIndicator();
            result.Paging.Start = rowIndex;
            result.Paging.Count = maxRowCount;
            result.Paging.IsLast = isLast;
            return result;
        }

        protected string SerializeDataAndAddToTransaction<T>(T data, ISettingsProvider settingsProvider,
                                                             ISerializationHelper serializationHelper,
                                                             ICompressionHelper compressionHelper,
                                                             IDocumentManager documentManager,
                                                             string transactionId)
        {
            string rtnPath = settingsProvider.NewTempFilePath(".xml");

            try
            {
                try
                {
                    serializationHelper.Serialize(data, rtnPath);
                }
                catch (Exception e)
                {
                    AppendAuditLogEvent("Failed to serialize xml results document \"{0}\" to transaction \"{1}\" with exception: {2}",
                                              rtnPath, transactionId, ExceptionUtils.ToShortString(e));
                    throw;
                }
                if (compressionHelper != null)
                {
                    string zipPath = settingsProvider.NewTempFilePath(".zip");
                    try
                    {
                        compressionHelper.CompressFile(rtnPath, zipPath);
                    }
                    catch (Exception e)
                    {
                        AppendAuditLogEvent("Failed to zip results document \"{0}\" to transaction \"{1}\" with exception: {2}",
                                                  rtnPath, transactionId, ExceptionUtils.ToShortString(e));
                        throw;
                    }
                    finally
                    {
                        FileUtils.SafeDeleteFile(rtnPath);
                        rtnPath = zipPath;
                    }
                }
                try
                {
                    documentManager.AddDocument(transactionId, CommonTransactionStatusCode.Completed,
                                                null, rtnPath);
                }
                catch (Exception e)
                {
                    AppendAuditLogEvent("Failed to attach xml results document \"{0}\" to transaction \"{1}\" with exception: {2}",
                                              rtnPath, transactionId, ExceptionUtils.ToShortString(e));
                    throw;
                }
            }
            catch (Exception)
            {
                FileUtils.SafeDeleteFile(rtnPath);
                throw;
            }

            return rtnPath;
        }
        protected string SaveXmlStringAndAddToTransaction(string xmlString, ISettingsProvider settingsProvider,
                                                          ICompressionHelper compressionHelper,
                                                          IDocumentManager documentManager,
                                                          string transactionId)
        {
            string rtnPath = settingsProvider.NewTempFilePath(".xml");

            try
            {
                try
                {
                    using (StreamWriter objReader = new StreamWriter(xmlString))
                    {
                        objReader.Write(xmlString);
                    }
                }
                catch (Exception e)
                {
                    AppendAuditLogEvent("Failed to save xml string document \"{0}\" to transaction \"{1}\" with exception: {2}",
                                              rtnPath, transactionId, ExceptionUtils.ToShortString(e));
                    throw;
                }
                if (compressionHelper != null)
                {
                    string zipPath = settingsProvider.NewTempFilePath(".zip");
                    try
                    {
                        compressionHelper.CompressFile(rtnPath, zipPath);
                    }
                    catch (Exception e)
                    {
                        AppendAuditLogEvent("Failed to zip results document \"{0}\" to transaction \"{1}\" with exception: {2}",
                                                  rtnPath, transactionId, ExceptionUtils.ToShortString(e));
                        throw;
                    }
                    finally
                    {
                        FileUtils.SafeDeleteFile(rtnPath);
                        rtnPath = zipPath;
                    }
                }
                try
                {
                    documentManager.AddDocument(transactionId, CommonTransactionStatusCode.Completed,
                                                null, rtnPath);
                }
                catch (Exception e)
                {
                    AppendAuditLogEvent("Failed to attach xml results document \"{0}\" to transaction \"{1}\" with exception: {2}",
                                              rtnPath, transactionId, ExceptionUtils.ToShortString(e));
                    throw;
                }
            }
            catch (Exception)
            {
                FileUtils.SafeDeleteFile(rtnPath);
                throw;
            }

            return rtnPath;
        }
        protected T GetHeaderDocumentContent<T>(string transactionId, string documentId,
                                                ISettingsProvider settingsProvider,
                                                ISerializationHelper serializationHelper,
                                                ICompressionHelper compressionHelper,
                                                IDocumentManager documentManager,
                                                out string operation)
        {
            Document document = documentManager.GetDocument(transactionId, documentId, true);
            return GetHeaderDocumentContent<T>(document, settingsProvider, serializationHelper,
                                               compressionHelper, out operation);
        }
        protected T GetHeaderDocumentContent<T>(Document document,
                                                ISettingsProvider settingsProvider,
                                                ISerializationHelper serializationHelper,
                                                ICompressionHelper compressionHelper,
                                                out string operation)
        {
            string tempXmlFilePath = settingsProvider.NewTempFilePath();
            try
            {
                if (compressionHelper.IsCompressed(document.Content))
                {
                    compressionHelper.UncompressDeep(document.Content, tempXmlFilePath);
                }
                else
                {
                    File.WriteAllBytes(tempXmlFilePath, document.Content);
                }

                IHeaderDocumentHelper headerDocumentHelper;
                GetServiceImplementation(out headerDocumentHelper);

                bool didLoadHeader = headerDocumentHelper.TryLoad(tempXmlFilePath);
                operation = null;
                T data;
                if (didLoadHeader)
                {
                    XmlElement xmlPayload = headerDocumentHelper.GetFirstPayload(out operation);
                    if (xmlPayload == null)
                    {
                        throw new ArgumentException("Submission document is missing a payload.");
                    }
                    data = serializationHelper.Deserialize<T>(xmlPayload);
                }
                else
                {
                    AppendAuditLogEvent("Submission document does not contain an exchange header, attempting to deserialize directly ...");
                    data = serializationHelper.Deserialize<T>(tempXmlFilePath);
                }

                return data;
            }
            catch (Exception e)
            {
                AppendAuditLogEvent("Failed to process document with id \"{0}.\"  EXCEPTION: {1}",
                                    document.Id.ToString(), ExceptionUtils.ToShortString(e));
                throw;
            }
            finally
            {
                FileUtils.SafeDeleteFile(tempXmlFilePath);
            }
        }
        protected void TrimListToRequestSize<T>(int rowIndex, int maxRowCount, List<T> list)
        {
            if (rowIndex > 0)
            {
                if (rowIndex >= list.Count)
                {
                    list.Clear();
                }
                else
                {
                    list.RemoveRange(0, rowIndex);
                }
            }
            if (maxRowCount > 0)
            {
                int rtnCount = Math.Min(maxRowCount, list.Count);
                if ((rtnCount > 0) && (rtnCount < list.Count))
                {
                    list.RemoveRange(rtnCount, list.Count - rtnCount);
                }
            }
        }
        protected void TrimListToRequestSize<T>(DataRequest dataRequest, List<T> list)
        {
            TrimListToRequestSize<T>(dataRequest.RowIndex, dataRequest.MaxRowCount, list);
        }
        #endregion

        #region Properties
        public Dictionary<string, string> ConfigurationArguments
        {
            get { return _configurationArguments; }
        }
        public void SetConfigurationArgument(string key, string value)
        {
            _configurationArguments[key] = value;
        }
        public Dictionary<string, IDbProvider> DataProviders
        {
            get { return _dataProviders; }
        }
        public void SetDataProvider(string key, DataProviderInfo provider)
        {
            IDbProvider dbProvider = DbConnectionFactory.GetDbProvider(provider.ProviderType);
            dbProvider.ConnectionString = provider.ConnectionString;

            _dataProviders[key] = dbProvider;
        }
        public virtual ICollection<ActivityEntry> GetAuditLogEvents()
        {
            return _auditLogEvents;
        }
        /// <summary>
        /// Return the Query, Solicit, or Execute data service parameters for this plugin.
        /// </summary>
        public virtual ICollection<TypedParameter> GetDataServiceParameters(string serviceName)
        {
            return null;
        }
        #endregion
    }
}
