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
using System.Threading;

using Windsor.Commons.NodeDomain;
using System.ComponentModel;
using Windsor.Commons.NodeClient;

namespace Windsor.Node2008.WNOSPlugin
{

    public delegate void WNOSPluginAuditLogginHandler(string message);

    public class PipedParameter<T>
    {
        public PipedParameter()
        {
        }
        public PipedParameter(T value)
        {
            Value = value;
            WasSpecified = true;
        }
        public bool WasSpecified { get; private set; }
        public T Value { get; private set; }
    }
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
        protected enum CDX_Processing_Status
        {
            None,
            [Description("Pending")]
            Pending,
            [Description("Failed")]
            Failed,
            [Description("Completed")]
            Completed,
        }
        private static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());

        #region Members
        private readonly Dictionary<string, string> _configurationArguments;
        private readonly Dictionary<string, IDbProvider> _dataProviders;
        private IServiceFactory _serviceFactory;
        private IDbProviderFactory _dbConnectionFactory;
        protected List<ActivityEntry> _auditLogEvents;
        protected bool _useSubmissionHistoryTable;
        protected string _submissionHistoryTableName;
        protected string _submissionHistoryTablePkName;
        protected string _submissionHistoryTableProcessingStatusName;
        protected string _submissionHistoryTableTransactionIdName;
        protected string _submissionHistoryTableRunDateName;

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
            LOG.Info(message);
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
        protected void GetConfigParameter<T>(string key, out T value)
        {
            GetConfigParameter<T>(key, true, out value);
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
                value = ConvertValue<T>(valueStr);
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
            SpringBaseDao baseDao = (dbProviderType == null) ? new SpringBaseDao(dbProvider) : new SpringBaseDao(dbProvider, dbProviderType);
            if (baseDao.DbProvider != null)
            {
                AppendAuditLogEvent("{0}: {1}", key, baseDao.DbProvider.ConnectionString);
            }
            return baseDao;
        }
        protected static void GetNonEmptyStringParameter(DataRequest dataRequest, string name, int index, out string value)
        {
            if (CollectionUtils.IsNullOrEmpty(dataRequest.Parameters))
            {
                throw new ArgumentException(string.Format("The service parameter \"{0}\" was not specified.", name));
            }
            if (dataRequest.Parameters.IsByName)
            {
                GetNonEmptyStringParameterByName(dataRequest, name, out value);
            }
            else
            {
                GetNonEmptyStringParameterByIndex(dataRequest, index, out value);
            }
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
        protected static List<PipedParameter<T>> TryGetPipedParameters<T>(DataRequest dataRequest, string name, int index)
        {
            if ((dataRequest == null) || (dataRequest.Parameters == null) || (dataRequest.Parameters.Count == 0))
            {
                return null;
            }
            string stringValue = null;
            if (!TryGetNonEmptyStringParameter(dataRequest, name, index, ref stringValue))
            {
                return null;
            }

            string[] values = stringValue.Split('|');
            if (CollectionUtils.IsNullOrEmpty(values))
            {
                return null;
            }
            List<PipedParameter<T>> parameters = new List<PipedParameter<T>>(values.Length);
            foreach (string value in values)
            {
                if (!string.IsNullOrEmpty(value))
                {
                    T typedValue = ConvertValue<T>(value);
                    parameters.Add(new PipedParameter<T>(typedValue));
                }
                else
                {
                    parameters.Add(new PipedParameter<T>());
                }
            }
            return parameters;
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
                value = ConvertValue<T>(valueStr);
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
        protected static T ConvertValue<T>(string valueStr)
        {
            Type type = typeof(T);
            if (type == typeof(string))
            {
                return (T)(object)valueStr;
            } 
            else if (typeof(T) == typeof(TimeSpan))
            {
                return (T)Convert.ChangeType(TimeSpan.Parse(valueStr), typeof(T));
            }
            else
            {
                return (T)Convert.ChangeType(valueStr, typeof(T));
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
                throw new ArgumentException(string.Format("The string parameter with the name \"{0}\" is empty",
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
        /// <summary>
        /// Return the paramter list sorted by name if parameters.IsByName == true, or just "as is"
        /// if parameters.IsByName == false.
        /// </summary>
        public List<string> GetParameterListSortedByName(ByIndexOrNameDictionary<string> parameters)
        {
            if (CollectionUtils.IsNullOrEmpty(parameters))
            {
                return null;
            }
            else if (parameters.IsByName)
            {
                SortedDictionary<string, string> dict = new SortedDictionary<string, string>();
                foreach (KeyValuePair<string, string> pair in parameters.NameValuePairs)
                {
                    dict.Add(pair.Key, pair.Value);
                }
                return new List<string>(dict.Values);
            }
            else
            {
                return new List<string>(parameters);
            }
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

        protected string SerializeDataAndAddToTransaction(object data, ISettingsProvider settingsProvider,
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
                    AppendAuditLogEvent("Adding document data to transaction as \"{0}\"", rtnPath);
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
                    using (StreamWriter objReader = new StreamWriter(rtnPath))
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
        protected void AppendConfigArguments<T>() where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException(typeof(T).ToString() + " is not an Enum");
            }
            ICollection<string> descriptions = EnumUtils.GetAllDescriptions<T>();
            CollectionUtils.ForEach(descriptions, delegate(string description)
                {
                    _configurationArguments[description] = null;
                });
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
        protected void AppendDataProviders<T>() where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException(typeof(T).ToString() + " is not an Enum");
            }
            ICollection<string> descriptions = EnumUtils.GetAllDescriptions<T>();
            CollectionUtils.ForEach(descriptions, delegate(string description)
            {
                _dataProviders[description] = null;
            });
        }
        public virtual ICollection<ActivityEntry> GetAuditLogEvents()
        {
            return _auditLogEvents;
        }
        /// <summary>
        /// Return the Query, Solicit, or Execute data service parameters for specified data service.
        /// This method should NOT call GetServiceImplementation().
        /// </summary>
        public virtual IList<TypedParameter> GetDataServiceParameters(string serviceName, out DataServicePublishFlags publishFlags)
        {
            publishFlags = DataServicePublishFlags.DoNotPublish;
            return null;
        }
        #endregion

        protected CommonTransactionStatusCode UpdateStatusOfNetworkTransaction(string localTransactionId, string endpointNetworkId,
                                                                               string endpointUrl, EndpointVersionType endpointVersion)
        {
            try
            {
                INodeEndpointClientFactory nodeEndpointClientFactory;
                GetServiceImplementation(out nodeEndpointClientFactory);

                ITransactionManager transactionManager;
                GetServiceImplementation(out transactionManager);

                CommonTransactionStatusCode statusCode;
                using (INodeEndpointClient endpointClient = nodeEndpointClientFactory.Make(endpointUrl, endpointVersion))
                {
                    statusCode = endpointClient.GetStatus(endpointNetworkId);
                    transactionManager.SetNetworkIdStatus(localTransactionId, statusCode);
                }
                AppendAuditLogEvent("Successfully got status of \"{0}\" from network url \"{1}\" for network transaction id \"{2}.\"",
                                    statusCode.ToString(), endpointUrl, endpointNetworkId);
                return statusCode;
            }
            catch (Exception e)
            {
                AppendAuditLogEvent("Failed to get status from network url \"{0}\" for network transaction id \"{1}.\"  Error: {2}",
                                    endpointUrl, endpointNetworkId, ExceptionUtils.GetDeepExceptionMessage(e));
                return CommonTransactionStatusCode.Unknown;
            }
        }
        protected CommonTransactionStatusCode UpdateStatusOfNetworkTransaction(string endpointNetworkId)
        {
            EndpointVersionType endpointVersion;
            string endpointUrl;
            string transactionId;
            try
            {
                ITransactionManager transactionManager;
                GetServiceImplementation(out transactionManager);

                CommonTransactionStatusCode status;
                transactionId =
                    transactionManager.GetNetworkTransactionStatusFromNetworkId(endpointNetworkId, out status, out endpointVersion,
                                                                                out endpointUrl);
                if (string.IsNullOrEmpty(transactionId))
                {
                    AppendAuditLogEvent("Could not find network transaction id \"{0}\" in database", endpointNetworkId);
                    return CommonTransactionStatusCode.Unknown;
                }
            }
            catch (Exception e)
            {
                AppendAuditLogEvent("Could not query network transaction id \"{0}\" in database.  Error: {1}",
                                    endpointNetworkId, ExceptionUtils.GetDeepExceptionMessage(e));
                return CommonTransactionStatusCode.Unknown;
            }
            return UpdateStatusOfNetworkTransaction(transactionId, endpointNetworkId, endpointUrl, endpointVersion);
        }
        protected virtual IList<string> GetPendingSubmissionTransactionIds(SpringBaseDao baseDao)
        {
            List<string> pendingSubmissions = null;
            if (_useSubmissionHistoryTable)
            {
                ExceptionUtils.ThrowIfEmptyString(_submissionHistoryTableName, "_submissionHistoryTableName");
                ExceptionUtils.ThrowIfEmptyString(_submissionHistoryTableProcessingStatusName, "_submissionHistoryTableProcessingStatusName");
                ExceptionUtils.ThrowIfEmptyString(_submissionHistoryTableTransactionIdName, "_submissionHistoryTableTransactionIdName");

                baseDao.DoSimpleQueryWithRowCallbackDelegate(
                    _submissionHistoryTableName,
                    _submissionHistoryTableProcessingStatusName,
                    new object[] { EnumUtils.ToDescription(CDX_Processing_Status.Pending) },
                    _submissionHistoryTableTransactionIdName,
                    delegate(IDataReader reader)
                    {
                        NamedNullMappingDataReader readerEx = (NamedNullMappingDataReader)reader;
                        if (pendingSubmissions == null) pendingSubmissions = new List<string>();
                        pendingSubmissions.Add(readerEx.GetString(0));
                    });
                if (pendingSubmissions != null)
                {
                    AppendAuditLogEvent("Found {0} pending submissions", pendingSubmissions.Count.ToString());
                }
                else
                {
                    AppendAuditLogEvent("Didn't find any pending submissions");
                }
            }
            return pendingSubmissions;
        }
        protected virtual List<string> GetPendingSubmissionList(SpringBaseDao baseDao)
        {
            if (_useSubmissionHistoryTable)
            {
                ExceptionUtils.ThrowIfEmptyString(_submissionHistoryTableName, "_submissionHistoryTableName");
                ExceptionUtils.ThrowIfEmptyString(_submissionHistoryTableProcessingStatusName, "_submissionHistoryTableProcessingStatusName");
                ExceptionUtils.ThrowIfEmptyString(_submissionHistoryTablePkName, "_submissionHistoryTableTransactionIdName");

                List<string> recordIdList = null;
                baseDao.DoSimpleQueryWithRowCallbackDelegate(
                    _submissionHistoryTableName,
                    _submissionHistoryTableProcessingStatusName,
                    new object[] { EnumUtils.ToDescription(CDX_Processing_Status.Pending) },
                    _submissionHistoryTablePkName,
                    delegate(IDataReader reader)
                    {
                        if (recordIdList == null) recordIdList = new List<string>();
                        recordIdList.Add(reader.GetString(0));
                    });
                return recordIdList;
            }
            return null;
        }
        protected virtual void CheckForPendingSubmissions(SpringBaseDao baseDao)
        {
            if (_useSubmissionHistoryTable)
            {
                AppendAuditLogEvent("Checking for pending submissions");

                UpdateStatusOfPendingTransactions(baseDao);

                List<string> recordIdList = GetPendingSubmissionList(baseDao);

                if (recordIdList != null)
                {
                    throw new InvalidOperationException(string.Format("There are pending submissions that have not completed: {0}",
                                                                      string.Join(", ", recordIdList.ToArray())));
                }
            }
        }
        protected virtual string SetPendingSubmission(SpringBaseDao baseDao, DateTime runDate)
        {
            if (_useSubmissionHistoryTable)
            {
                ExceptionUtils.ThrowIfEmptyString(_submissionHistoryTableName, "_submissionHistoryTableName");
                ExceptionUtils.ThrowIfEmptyString(_submissionHistoryTableProcessingStatusName, "_submissionHistoryTableProcessingStatusName");
                ExceptionUtils.ThrowIfEmptyString(_submissionHistoryTableRunDateName, "_submissionHistoryTableRunDateName");
                ExceptionUtils.ThrowIfEmptyString(_submissionHistoryTablePkName, "_submissionHistoryTablePkName");
                ExceptionUtils.ThrowIfEmptyString(_submissionHistoryTableTransactionIdName, "_submissionHistoryTableTransactionIdName");

                IdProvider idProvider;
                GetServiceImplementation(out idProvider);

                AppendAuditLogEvent("Adding pending submission to history table");
                string recordId = idProvider.Get();
                baseDao.DoInsert(
                    _submissionHistoryTableName,
                    _submissionHistoryTablePkName + ";" + _submissionHistoryTableRunDateName + ";" + 
                    _submissionHistoryTableTransactionIdName + ";" + _submissionHistoryTableProcessingStatusName,
                    new object[] { recordId, runDate, "PENDING",
                                   EnumUtils.ToDescription(CDX_Processing_Status.Pending) }
                                  );
                return recordId;
            }
            else
            {
                return string.Empty;
            }
        }
        protected virtual void SetSubmissionFailed(SpringBaseDao baseDao, string recordId)
        {
            if (_useSubmissionHistoryTable)
            {
                ExceptionUtils.ThrowIfEmptyString(_submissionHistoryTableName, "_submissionHistoryTableName");
                ExceptionUtils.ThrowIfEmptyString(_submissionHistoryTableProcessingStatusName, "_submissionHistoryTableProcessingStatusName");
                ExceptionUtils.ThrowIfEmptyString(_submissionHistoryTablePkName, "_submissionHistoryTablePkName");

                AppendAuditLogEvent("Setting pending submission \"{0}\" to failed in submission history table", recordId);
                baseDao.DoSimpleUpdateOne(
                    _submissionHistoryTableName,
                    _submissionHistoryTablePkName, new object[] { recordId },
                    _submissionHistoryTableProcessingStatusName, EnumUtils.ToDescription(CDX_Processing_Status.Failed)
                        );
            }
        }
        protected virtual void ClearAllPendingSubmissions(SpringBaseDao baseDao)
        {
            if (_useSubmissionHistoryTable)
            {
                ExceptionUtils.ThrowIfEmptyString(_submissionHistoryTableName, "_submissionHistoryTableName");
                ExceptionUtils.ThrowIfEmptyString(_submissionHistoryTableProcessingStatusName, "_submissionHistoryTableProcessingStatusName");

                AppendAuditLogEvent("Setting pending submissions to failed in submission history table");
                int count =
                    baseDao.DoSimpleUpdate(
                        _submissionHistoryTableName,
                        _submissionHistoryTableProcessingStatusName,
                        EnumUtils.ToDescription(CDX_Processing_Status.Pending),
                        _submissionHistoryTableProcessingStatusName, -1, EnumUtils.ToDescription(CDX_Processing_Status.Failed)
                            );
                if (count > 0)
                {
                    AppendAuditLogEvent("Updated {0} row(s)", count.ToString());
                }
                else
                {
                    AppendAuditLogEvent("Did not update any rows");
                }
            }
        }
        protected virtual void UpdatePendingSubmissionInfo(SpringBaseDao baseDao, string recordId, string transactionId)
        {
            if (_useSubmissionHistoryTable)
            {
                ExceptionUtils.ThrowIfEmptyString(_submissionHistoryTableName, "_submissionHistoryTableName");
                ExceptionUtils.ThrowIfEmptyString(_submissionHistoryTableTransactionIdName, "_submissionHistoryTableTransactionIdName");
                ExceptionUtils.ThrowIfEmptyString(_submissionHistoryTablePkName, "_submissionHistoryTablePkName");

                AppendAuditLogEvent("Updating pending submission \"{0}\" in submission history table with TRANSACTIONID = \"{1}\"",
                                    recordId, transactionId);
                baseDao.DoSimpleUpdateOne(
                    _submissionHistoryTableName,
                    _submissionHistoryTablePkName, new object[] { recordId },
                    _submissionHistoryTableTransactionIdName, transactionId
                        );
            }
        }
        protected virtual void UpdateSubmissionStatus(SpringBaseDao baseDao, string transactionId, CDX_Processing_Status status)
        {
            if (_useSubmissionHistoryTable)
            {
                ExceptionUtils.ThrowIfEmptyString(_submissionHistoryTableName, "_submissionHistoryTableName");
                ExceptionUtils.ThrowIfEmptyString(_submissionHistoryTableTransactionIdName, "_submissionHistoryTableTransactionIdName");
                ExceptionUtils.ThrowIfEmptyString(_submissionHistoryTableProcessingStatusName, "_submissionHistoryTableProcessingStatusName");

                string dbStatus = EnumUtils.ToDescription(status);
                AppendAuditLogEvent("Updating pending submission with transaction id \"{0}\" in submission history table with status = \"{1}\"",
                                          transactionId, dbStatus);
                baseDao.DoSimpleUpdateOne(
                    _submissionHistoryTableName,
                    _submissionHistoryTableTransactionIdName, new object[] { transactionId },
                    _submissionHistoryTableProcessingStatusName, dbStatus
                        );
            }
        }
        protected virtual void UpdateStatusOfPendingTransactions(SpringBaseDao baseDao)
        {
            IList<string> pendingTransactionIds = GetPendingSubmissionTransactionIds(baseDao);

            if (pendingTransactionIds != null)
            {
                foreach (string pendingTransactionId in pendingTransactionIds)
                {
                    UpdateTransactionStatus(baseDao, pendingTransactionId);
                }
            }
        }
        /// <summary>
        /// Attempts to validate an xml file against an xml schema resource.  If the file is invalid,
        /// the method returns a file path to a text file containing the schema validation errors.  If
        /// the file is valid, the method returns null.
        /// </summary>
        protected virtual string ValidateXmlFile(string xmlFilePath, string xmlSchemaResourceName, 
                                                 string xmlSchemaRootFileName)
        {
            AppendAuditLogEvent("Verifying xml schema validation source files ...");
            string xmlSchemaFolder = ExtractZippedResourceToTempFolder(xmlSchemaResourceName);

            if (string.IsNullOrEmpty(xmlSchemaRootFileName))
            {
                xmlSchemaRootFileName = "index.xsd";
            }
            string xmlSchemaRootFilePath = Path.Combine(xmlSchemaFolder, xmlSchemaRootFileName);
            try
            {
                if (!File.Exists(xmlSchemaRootFilePath))
                {
                    throw new FileNotFoundException(string.Format("The root xml schema file \"{0}\" was not found in the schema validation resource \"{1}\"",
                                                                  xmlSchemaRootFileName, xmlSchemaResourceName));
                }
                AppendAuditLogEvent("Xml schema validation source files verified");

                AppendAuditLogEvent("Validating xml document against the xml schema ...");

                ISettingsProvider settingsProvider;
                GetServiceImplementation(out settingsProvider);

                string errorsFileFolderPath = settingsProvider.NewTempFolderPath();
                string errorsFilePath = Path.Combine(errorsFileFolderPath, "Validation Errors.txt");

                XmlValidationUtils xmlValidator = new XmlValidationUtils(true);

                if (!xmlValidator.Validate(xmlFilePath, xmlSchemaRootFilePath, errorsFilePath))
                {
                    AppendAuditLogEvent("The xml document failed to validate against the xml schema");
                    return errorsFilePath;
                }
                else
                {
                    AppendAuditLogEvent("The xml document is valid according to the xml schema");
                    return null;
                }
            }
            catch (Exception)
            {
                FileUtils.SafeDeleteDirectory(xmlSchemaFolder);
                throw;
            }
        }
        protected virtual void ValidateXmlFileAndAttachErrorsAndFileToTransaction(string xmlFilePath, string xmlSchemaResourceName,
                                                                                  string xmlSchemaRootFileName, string transactionId)
        {
            ValidateXmlFileAndAttachFilesToTransaction(xmlFilePath, xmlSchemaResourceName, xmlSchemaRootFileName,
                                                       transactionId, true);
        }
        protected virtual void ValidateXmlFileAndAttachErrorsToTransaction(string xmlFilePath, string xmlSchemaResourceName,
                                                                           string xmlSchemaRootFileName, string transactionId)
        {
            ValidateXmlFileAndAttachFilesToTransaction(xmlFilePath, xmlSchemaResourceName, xmlSchemaRootFileName,
                                                       transactionId, false);
        }
        /// <summary>
        /// Attempts to validate an xml file against an xml schema resource.  If the file is invalid,
        /// the method returns false and attaches a text file containing the validation errors to the input
        /// transaction.  If the file is valid, the method returns true.
        /// </summary>
        protected virtual void ValidateXmlFileAndAttachFilesToTransaction(string xmlFilePath, string xmlSchemaResourceName,
                                                                          string xmlSchemaRootFileName, string transactionId,
                                                                          bool attachXmlFileToTransactionIfError)
        {
            string validationErrorsFile = ValidateXmlFile(xmlFilePath, xmlSchemaResourceName, xmlSchemaRootFileName);
            if (validationErrorsFile == null)
            {
                return; // File is valid
            }
            try
            {
                string errorsFileName = Path.GetFileName(validationErrorsFile);
                string xmlFileName = Path.GetFileName(xmlFilePath);
                IDocumentManager documentManager;
                GetServiceImplementation(out documentManager);
                if (attachXmlFileToTransactionIfError)
                {
                    try
                    {
                        AppendAuditLogEvent("Attaching xml file \"{0}\" to transaction \"{1}\"",
                                            xmlFileName, transactionId);
                        documentManager.AddDocument(transactionId, CommonTransactionStatusCode.Completed,
                                                    null, xmlFilePath);
                    }
                    catch (Exception e)
                    {
                        AppendAuditLogEvent("Failed to attach xml file \"{0}\" to transaction \"{1}\" with exception: {2}",
                                            xmlFileName, transactionId, ExceptionUtils.ToShortString(e));
                        throw;
                    }
                }
                try
                {
                    AppendAuditLogEvent("Attaching validation errors file \"{0}\" to transaction \"{1}\"",
                                        errorsFileName, transactionId);
                    documentManager.AddDocument(transactionId, CommonTransactionStatusCode.Completed,
                                                null, validationErrorsFile);
                }
                catch (Exception e)
                {
                    AppendAuditLogEvent("Failed to attach validation errors file \"{0}\" to transaction \"{1}\" with exception: {2}",
                                        errorsFileName, transactionId, ExceptionUtils.ToShortString(e));
                    throw;
                }
                throw new InvalidDataException(string.Format("The generated xml document is not valid according to the xml schema.  Review the \"{0}\" file for a summary of the validation errors",
                                                             Path.GetFileNameWithoutExtension(errorsFileName)));
            }
            catch (Exception)
            {
                FileUtils.SafeDeleteFile(transactionId);
                throw;
            }
        }
        protected virtual string ExtractZippedResourceToTempFolder(string resourceName)
        {
            string qualifiedResourceName = this.GetType().Namespace + "." + resourceName;
            Assembly assembly = this.GetType().Assembly;
            string folderName = qualifiedResourceName + "." + AssemblyUtils.GetAssemblyFileVersion(assembly);
            folderName = FileUtils.ReplaceInvalidFilenameChars(folderName, '_');

            ISettingsProvider settingsProvider;
            GetServiceImplementation(out settingsProvider);

            ICompressionHelper compressionHelper;
            GetServiceImplementation(out compressionHelper);

            string folderPath = Path.Combine(settingsProvider.TempFolderPath, folderName);

            using (Mutex mutex = AcquireMutex(folderName, 60))
            {
                if (Directory.Exists(folderPath) && !FileUtils.IsDirectoryEmpty(folderPath))
                {
                    return folderPath;
                }

                Stream resourceStream = assembly.GetManifestResourceStream(qualifiedResourceName);

                if (resourceStream == null)
                {
                    throw new ArgumentException(string.Format("Failed to load zipped resource \"{0}\" from the plugin",
                                                              resourceName));
                }
                using (resourceStream)
                {
                    compressionHelper.UncompressDirectory(resourceStream, folderPath);
                }
            }

            return folderPath;
        }
        protected virtual Mutex AcquireMutex(string uniqueName, int timeoutInSeconds)
        {
            bool isAcquired;
            Mutex mutex = new Mutex(true, uniqueName, out isAcquired);
            if (!isAcquired)
            {
                isAcquired = 
                    mutex.WaitOne((timeoutInSeconds == Timeout.Infinite) ? timeoutInSeconds : timeoutInSeconds * 1000);
                if (!isAcquired)
                {
                    mutex.Close();
                    throw new TimeoutException(string.Format("The mutex \"{0}\" could not be acquired after waiting for {1} seconds",
                                                             uniqueName, timeoutInSeconds.ToString()));
                }
            }
            return mutex;
        }
        protected bool UpdateTransactionStatus(SpringBaseDao baseDao, string transactionId)
        {
            string endpointNetworkId = string.Empty, endpointUrl = string.Empty;
            try
            {
                AppendAuditLogEvent("Attempting to get node endpoint information for transaction id \"{0}\"", transactionId);

                CommonTransactionStatusCode status;
                EndpointVersionType endpointVersion;

                INodeEndpointClientFactory nodeEndpointClientFactory;
                GetServiceImplementation(out nodeEndpointClientFactory);

                ITransactionManager transactionManager;
                GetServiceImplementation(out transactionManager);

                endpointNetworkId =
                     transactionManager.GetNetworkTransactionStatus(transactionId, out status, out endpointVersion, out endpointUrl);

                if (string.IsNullOrEmpty(endpointNetworkId) || string.IsNullOrEmpty(endpointUrl))
                {
                    AppendAuditLogEvent("Failed to get node endpoint information for transaction id \"{0}\", setting submission status to Failed ...",
                                        transactionId);
                    UpdateSubmissionStatus(baseDao, transactionId, CDX_Processing_Status.Failed);
                    return true;
                }

                AppendAuditLogEvent("Got node endpoint information: {0} ({1}) and endpoint transaction id \"{2}\" with current status of \"{3}\"",
                                    endpointUrl, EnumUtils.ToDescription(endpointVersion), endpointNetworkId,
                                    EnumUtils.ToDescription(status));

                CDX_Processing_Status pendingStatus = CDX_Processing_Status.None;

                if ((status == CommonTransactionStatusCode.Processed) ||
                     (status == CommonTransactionStatusCode.Completed) ||
                     (status == CommonTransactionStatusCode.Failed))
                {
                    pendingStatus = (status == CommonTransactionStatusCode.Failed) ?
                        CDX_Processing_Status.Failed : CDX_Processing_Status.Completed;
                    UpdateSubmissionStatus(baseDao, transactionId, pendingStatus);
                    return true;
                }

                CommonTransactionStatusCode statusCode = CommonTransactionStatusCode.Unknown;

                AppendAuditLogEvent("Attempting to get status for endpoint transaction id \"{0}\"", endpointNetworkId);

                using (INodeEndpointClient endpointClient = nodeEndpointClientFactory.Make(endpointUrl, endpointVersion))
                {
                    statusCode = endpointClient.GetStatus(endpointNetworkId);
                    if ((statusCode == CommonTransactionStatusCode.Processed) ||
                        (statusCode == CommonTransactionStatusCode.Completed))
                    {
                        pendingStatus = CDX_Processing_Status.Completed;
                    }
                    else if (statusCode == CommonTransactionStatusCode.Failed)
                    {
                        pendingStatus = CDX_Processing_Status.Failed;
                    }
                }
                AppendAuditLogEvent("Successfully got status of \"{0}\" for endpoint transaction id \"{1}\"",
                                    statusCode.ToString(), endpointNetworkId);
                if (pendingStatus != CDX_Processing_Status.None)
                {
                    UpdateSubmissionStatus(baseDao, transactionId, pendingStatus);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                string message = string.Format("Failed to get status from partner node \"{0}\" for transaction id \"{1}.\"  Exception: {2}",
                                               endpointUrl, endpointNetworkId, ExceptionUtils.ToShortString(e));
                AppendAuditLogEvent(message);
                // Don't throw
                return false;
            }
        }
        protected virtual string SubmitFileToPartner(string transactionId, PartnerIdentity partner, string flowName, string operationName,
                                                     string filePath)
        {
            string submitTransactionId;
            EndpointVersionType endpointVersion;
            string endpointUrl;

            ITransactionManager transactionManager;
            GetServiceImplementation(out transactionManager);

            string networkFlowName = null, networkFlowOperation = null;

            using (INodeEndpointClient client = GetNodeClient(partner))
            {
                try
                {
                    if (client.Version == EndpointVersionType.EN11)
                    {
                        AppendAuditLogEvent("Attempting to submit target documents to partner \"{0}\" for flow \"{1}\"",
                                            partner.Name, flowName);
                        submitTransactionId = client.Submit(flowName, string.Empty, new string[] { filePath });
                        networkFlowName = flowName;
                    }
                    else
                    {
                        AppendAuditLogEvent("Attempting to submit target documents to partner \"{0}\" for flow \"{1}\" and operation \"{2}\"",
                                            partner.Name, flowName, operationName ?? string.Empty);
                        submitTransactionId = client.Submit(flowName, operationName, string.Empty, new string[] { filePath });
                        networkFlowName = flowName;
                        networkFlowOperation = operationName;
                    }
                }
                catch (Exception e)
                {
                    AppendAuditLogEvent("Error returned from node endpoint: \"{0}\"", ExceptionUtils.GetDeepExceptionMessage(e));
                    throw;
                }
                endpointVersion = client.Version;
                endpointUrl = client.Url;
            }
            AppendAuditLogEvent("Submitted target documents to partner \"{0}\" at url \"{1}\" for flow \"{2}\" with returned transaction id \"{3}\"",
                                partner.Name, partner.Url, flowName, submitTransactionId);

            transactionManager.SetNetworkId(transactionId, submitTransactionId, endpointVersion, endpointUrl, 
                                            networkFlowName, networkFlowOperation);

            return submitTransactionId;
        }
        protected virtual INodeEndpointClient GetNodeClient(PartnerIdentity partner)
        {
            INodeEndpointClientFactory nodeEndpointClientFactory;
            GetServiceImplementation(out nodeEndpointClientFactory);
            AppendAuditLogEvent("Acquiring node endpoint client for partner \"{0}\" with version \"{1}\" at url \"{2}\" using NAAS user account \"{3}\"",
                                partner.Name, EnumUtils.ToDescription(partner.Version),
                                partner.Url, nodeEndpointClientFactory.DefaultAuthenticationCredentials.UserName);
            return nodeEndpointClientFactory.Make(partner.Url, partner.Version);
        }
    }
}