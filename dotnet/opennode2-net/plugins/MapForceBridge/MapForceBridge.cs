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
using Windsor.Commons.NodeDomain;

namespace Windsor.Node.Flow.MapForceBridge
{
    /// <summary>
    /// Steps for implementing a MapForce mapping client:
    /// 
    /// 1) Create mappings in MapForce and generate .NET client code.  Input parameters must be limited to string values.
    /// 2) Compile .NET client code into a set of dlls and a "Mapping.exe" executable, and include the dlls and exe with this plugin
    ///     as an uploadable package for the flow that is implemented
    /// 3) The Mapping.exe executable must contain a class with a valid Run() method.
    /// 4) The Run() method will be called by this plugin, passing in any parameters specified in the request
    /// </summary>
    [Serializable]
    public class MapForceBridge : BaseWNOSPlugin, ITaskProcessor, IQueryProcessor, ISolicitProcessor, ISubmitProcessor
    {
        protected const string CONFIG_CONNECTION_STRING = "Database Connection String";

        protected IRequestManager _requestManager;
        protected IDocumentManager _documentManager;
        protected ISettingsProvider _settingsProvider;

        protected DataRequest _dataRequest;
        protected string _connectionString;

        public MapForceBridge()
        {
            ConfigurationArguments.Add(CONFIG_CONNECTION_STRING, null);
        }
        public void ProcessSubmit(string transactionId)
        {
            LazyInit();

            IList<string> docIds = _documentManager.GetDocumentIds(transactionId);
            if (CollectionUtils.IsNullOrEmpty(docIds))
            {
                throw new ArgumentException(string.Format("No documents found for transaction: {0}", transactionId));
            }

            Type runType = null;
            MethodInfo runMethod = null;
            ParameterInfo[] runParams = null;

            Assembly assembly = GetRunMethod(out runType, out runMethod, out runParams);
            if (runParams.Length != 2)
            {
                throw new InvalidOperationException("Did not find a valid Run() method that takes two parameters");
            }
            AppendAuditLogEvent("Found a class with a valid Run() method: \"{0}\" ...", runType.Name);

            AppendAuditLogEvent("Creating an instance of class \"{0}\" ...", runType.Name);

            object runObject = assembly.CreateInstance(runType.FullName);
            object[] invokeParams = new object[2] { null, _connectionString };

            foreach (string docId in docIds)
            {
                string tempFilePath = GetUncompressedDocument(transactionId, docId);
                try
                {
                    AppendAuditLogEvent("Calling Run() method to process input xml file ...");
                    invokeParams[0] = tempFilePath;
                    runMethod.Invoke(runObject, invokeParams);
                }
                finally
                {
                    FileUtils.SafeDeleteFile(tempFilePath);
                }
            }
        }
        public void ProcessTask(string requestId)
        {
            string filePath = DoRequest(requestId);
        }
        public PaginatedContentResult ProcessQuery(string requestId)
        {
            string filePath = DoRequest(requestId);

            byte[] content = File.ReadAllBytes(filePath);
            PaginatedContentResult result = new PaginatedContentResult(_dataRequest.RowIndex, _dataRequest.MaxRowCount,
                                                                       true, CommonContentType.XML, content);
            return result;
        }
        public void ProcessSolicit(string requestId)
        {
            string filePath = DoRequest(requestId);
        }
        protected string DoRequest(string requestId)
        {
            LazyInit();

            ValidateRequest(requestId);

            string filePath = RunMapForceQueryInstance();

            _documentManager.AddDocument(_dataRequest.TransactionId, CommonTransactionStatusCode.Completed,
                                         null, filePath);

            return filePath;
        }
        protected virtual void LazyInit()
        {
            AppendAuditLogEvent("Initializing {0} plugin ...", this.GetType().Name);

            GetServiceImplementation(out _requestManager);
            GetServiceImplementation(out _documentManager);
            GetServiceImplementation(out _settingsProvider);

            _connectionString = ValidateNonEmptyConfigParameter(CONFIG_CONNECTION_STRING);
        }
        protected virtual void ValidateRequest(string requestId)
        {
            AppendAuditLogEvent("Loading request with id \"{0}\"", requestId);
            _dataRequest = _requestManager.GetDataRequest(requestId);

            AppendAuditLogEvent("Validating request: {0}", _dataRequest);
        }

        protected Assembly GetRunMethod(out Type runType, out MethodInfo runMethod, out ParameterInfo[] runParams)
        {
            string assemblyPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Mapping.exe");
            if (!File.Exists(assemblyPath))
            {
                throw new FileNotFoundException(string.Format("File does not exist: {0}", assemblyPath));
            }

            Assembly assembly = Assembly.LoadFile(assemblyPath);

            Type[] assemblyTypes = assembly.GetExportedTypes();
            runType = null;
            runMethod = null;
            runParams = null;
            foreach (Type assemblyType in assemblyTypes)
            {
                MethodInfo[] typeMethods = assemblyType.GetMethods(BindingFlags.Instance | BindingFlags.Public |
                                                                   BindingFlags.DeclaredOnly | BindingFlags.InvokeMethod);
                MethodInfo runMethod2 = null;
                ParameterInfo[] runParams2 = null;
                foreach (MethodInfo typeMethod in typeMethods)
                {
                    if (string.Equals(typeMethod.Name, "Run"))
                    {
                        ParameterInfo[] methodParams = typeMethod.GetParameters();
                        if (methodParams.Length >= 2)
                        {
                            if ((methodParams[0].ParameterType == typeof(string)) &&
                                (methodParams[methodParams.Length - 1].ParameterType == typeof(string)))
                            {
                                if (runMethod2 != null)
                                {
                                    AppendAuditLogEvent("More than one valid Run() method found for the class \"{0}.\"  This class will be ignored.",
                                                        assemblyType.Name);
                                    runMethod2 = null;
                                    runParams2 = null;
                                    break;
                                }
                                runMethod2 = typeMethod;
                                runParams2 = methodParams;
                            }
                        }
                    }
                }
                if (runMethod2 != null)
                {
                    if (runType != null)
                    {
                        throw new InvalidOperationException(string.Format("Found more than one class that has a valid Run() method: \"{0}\" and \"{1}\"",
                                                                          runType.Name, assemblyType.Name));
                    }
                    runType = assemblyType;
                    runMethod = runMethod2;
                    runParams = runParams2;
                }
            }
            if (runType == null)
            {
                throw new InvalidOperationException("Did not find a class that has a valid Run() method");
            }
            return assembly;
        }
        protected static string ParamNameFromRunParamName(string runParamName)
        {
            const string postfixName = "SourceParameter";

            if (runParamName.EndsWith(postfixName) && (runParamName.Length > postfixName.Length))
            {
                return runParamName.Substring(0, runParamName.Length - postfixName.Length);
            }
            else
            {
                return runParamName;
            }
        }
        protected static void AppendRunParameters(ParameterInfo[] runParams, ByIndexOrNameDictionary<string> serviceParameters,
                                                  Type runType, List<object> runParameters)
        {
            if (!CollectionUtils.IsNullOrEmpty(serviceParameters))
            {
                if ((runParams.Length - 2) != serviceParameters.Count)
                {
                    throw new ArgumentException(string.Format("The number of request parameters ({0}) does not match the number of parameters specified by the Run() method ({1}) of class {2}.",
                                                              serviceParameters.Count, runParams.Length - 2, runType.Name));
                }
                if (serviceParameters.IsByName)
                {
                    for (int i = 1; i < runParams.Length - 1; ++i)
                    {
                        ParameterInfo runParam = runParams[i];
                        string paramName = ParamNameFromRunParamName(runParam.Name);
                        string requestParam;
                        if (!serviceParameters.TryGetValue(paramName, out requestParam))
                        {
                            throw new ArgumentNullException(string.Format("The service parameter \"{0}\" was not specified", paramName));
                        }
                        if (string.IsNullOrEmpty(requestParam))
                        {
                            runParameters.Add(null);
                        }
                        else
                        {
                            runParameters.Add(requestParam);
                        }
                    }
                }
                else
                {
                    foreach (string requestParam in serviceParameters)
                    {
                        if (string.IsNullOrEmpty(requestParam))
                        {
                            runParameters.Add(null);
                        }
                        else
                        {
                            runParameters.Add(requestParam);
                        }
                    }
                }
            }
            else
            {
                if ((runParams.Length - 2) > 0)
                {
                    throw new ArgumentException(string.Format("The number of request parameters (0) does not match the number of parameters specified by the Run() method ({0}) of class {1}.",
                                                              runParams.Length - 2, runType.Name));
                }
            }
        }
        protected virtual string RunMapForceQueryInstance()
        {
            Type runType = null;
            MethodInfo runMethod = null;
            ParameterInfo[] runParams = null;

            Assembly assembly = GetRunMethod(out runType, out runMethod, out runParams);

            List<object> runParameters = new List<object>();

            runParameters.Add(_connectionString);

            AppendRunParameters(runParams, _dataRequest.Parameters, runType, runParameters);

            AppendAuditLogEvent("Found a class with a valid Run() method: \"{0}\" ...", runType.Name);

            string tempXmlFilePath = _settingsProvider.NewTempFilePath(".xml");
            runParameters.Add(tempXmlFilePath);

            AppendAuditLogEvent("Creating an instance of class \"{0}\" ...", runType.Name);

            object rtnObject = assembly.CreateInstance(runType.FullName);

            AppendAuditLogEvent("Executing Run() method of instance \"{0}\" with parameters: {1}", runType.Name,
                                StringUtils.Join(", ", runParameters));

            runMethod.Invoke(rtnObject, runParameters.ToArray());

            return tempXmlFilePath;
        }
        /// <summary>
        /// Return the Query, Solicit, or Execute data service parameters for specified data service.
        /// This method should NOT call GetServiceImplementation().
        /// </summary>
        public override IList<TypedParameter> GetDataServiceParameters(string serviceName, out DataServicePublishFlags publishFlags)
        {
            Type runType = null;
            MethodInfo runMethod = null;
            ParameterInfo[] runParams = null;

            Assembly assembly = GetRunMethod(out runType, out runMethod, out runParams);

            List<TypedParameter> list = null;
            if (!CollectionUtils.IsNullOrEmpty(runParams) && (runParams.Length > 2))
            {
                list = new List<TypedParameter>(runParams.Length);
                for (int i = 1; i < runParams.Length - 1; ++i)
                {
                    ParameterInfo runParam = runParams[i];
                    string paramName = ParamNameFromRunParamName(runParam.Name);
                    list.Add(new TypedParameter(paramName, paramName, true, typeof(string), true));
                }
            }
            publishFlags = DataServicePublishFlags.PublishToEndpointVersion11And20;
            return list;
        }
        protected string GetUncompressedDocument(string transactionId, string docId)
        {
            string path = _settingsProvider.NewTempFilePath();
            File.WriteAllBytes(path, _documentManager.GetUncompressedContent(transactionId, docId));
            return path;
        }
    }
}
