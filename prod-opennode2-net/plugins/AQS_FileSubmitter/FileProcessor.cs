using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Reflection;
using Windsor.Node2008.WNOSPlugin;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSProviders;
using Windsor.Commons.Core;
using Windsor.Commons.Logging;
using Windsor.Commons.NodeDomain;
using Windsor.Commons.NodeClient;
using Windsor.Node2008.WNOSPlugin.AQSCommon;

namespace Windsor.Node2008.WNOSPlugin.AQS_FileSubmitter
{

    /// <summary>
    /// Plug-in interface handler to process data file endpoint relay submissions
    /// </summary>
    [Serializable]
    public class FileProcessor : AQSBaseHeaderPlugin, ITaskProcessor
    {
        protected const string CONFIG_PARAM_SUBMIT_ENDPOINT_URI = "Submission Endpoint Url";
        protected const string CONFIG_PARAM_SUBMIT_USERNAME = "Submission NAAS Username";
        protected const string CONFIG_PARAM_SUBMIT_PASSWORD = "Submission NAAS Password";
        public const string SERVICE_NAME = "AQS FileProcessor";
        public const string INPUT_FILE_PATH_NAME = "Input File Path";
        public const string DELETE_INPUT_FILE_NAME = "Delete Input File (True or False)";
        private const string SUBMIT_ENDPOINT_URI = "https://testngn.epacdxnode.net/ngn-enws20/services/NetworkNode2ServiceConditionalMTOM";

        private static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());
        private INodeEndpointClientFactory _nodeEndpointClientFactory;
        private ITransactionManager _transactionManager;
        protected DataRequest _dataRequest;
        protected IRequestManager _requestManager;

        #region constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public FileProcessor()
        {
            ConfigurationArguments.Add(CONFIG_PARAM_SUBMIT_ENDPOINT_URI, SUBMIT_ENDPOINT_URI);
            ConfigurationArguments.Add(CONFIG_PARAM_SUBMIT_USERNAME, null);
            ConfigurationArguments.Add(CONFIG_PARAM_SUBMIT_PASSWORD, null);
            ConfigurationArguments.Add(DELETE_INPUT_FILE_NAME, null);
            ConfigurationArguments.Add(INPUT_FILE_PATH_NAME, null);
        }

        #endregion constructor


        #region initializer

        /// <summary>
        /// Class initializer
        /// </summary>
        protected override void LazyInit()
        {
            base.LazyInit();

            GetServiceImplementation(out _nodeEndpointClientFactory);
            GetServiceImplementation(out _transactionManager);
            GetServiceImplementation(out _requestManager);
        }

        #endregion initializer


        #region logging

        /// <summary>
        /// Write to node transaction log
        /// </summary>
        /// <param name="message">Event to write out to log</param>
        private void WriteOut(string strMessage)
        {
            LOG.Debug(strMessage);
            AppendAuditLogEvent(strMessage);
        }

        /// <summary>
        /// Write to node transaction log
        /// </summary>
        /// <param name="message">Event to write out to log</param>
        /// <param name="args">Addition information on event</param>
        /// <returns>Full message to write out to log</returns>
        private string WriteOut(string message, params object[] args)
        {
            string strParsedMesssage = string.Format(message, args);
            LOG.Debug(strParsedMesssage);
            AppendAuditLogEvent(strParsedMesssage);
            return strParsedMesssage;
        }

        #endregion logging


        /// <summary>
        /// Return the Query, Solicit, or Execute data service parameters for specified data service.
        /// This method should NOT call GetServiceImplementation().
        /// </summary>
        /// <param name="serviceName">Name of service</param>
        /// <param name="publishFlags"></param>
        /// <returns></returns>
       public override IList<TypedParameter> GetDataServiceParameters(string serviceName, out DataServicePublishFlags publishFlags)
        {
            publishFlags = DataServicePublishFlags.DoNotPublish;
            return null;
        }

        protected virtual void ValidateRequest(string requestId)
        {
            AppendAuditLogEvent("Loading request with id \"{0}\"", requestId);
            _dataRequest = _requestManager.GetDataRequest(requestId);
        }
       
        /// <summary>
        /// Plug-in service processor method
        /// </summary>
        /// <param name="transactionId">Transaction ID reference</param>
        public virtual void ProcessTask(string requestId)
        {
            TransactionStatus status = null;
            string tempDirPath = null;
            try
            {
                LazyInit();

                ValidateRequest(requestId);

                var transactionId = _dataRequest.TransactionId;
                status = new TransactionStatus(transactionId);

                var inputFilePath = ConfigurationArguments[INPUT_FILE_PATH_NAME];
                if (string.IsNullOrEmpty(inputFilePath))
                {
                    throw new ArgException("The config parameter \"{0}\" was not specified", INPUT_FILE_PATH_NAME);
                }
                if (!File.Exists(inputFilePath))
                {
                    throw new ArgException("The input file \"{0}\" does not exist", inputFilePath);
                }
                bool deleteInputFile = false;
                var deleteFileStr = ConfigurationArguments[DELETE_INPUT_FILE_NAME];
                if (!string.IsNullOrEmpty(deleteFileStr))
                {
                    deleteInputFile = bool.Parse(deleteFileStr);
                }
                WriteOut("{0}: {1}", DELETE_INPUT_FILE_NAME, deleteInputFile.ToString());

                WriteOut("Loading document to submit \"{0}\" ...", inputFilePath);

                var fileContent = File.ReadAllBytes(inputFilePath);
                var fileName = Path.GetFileName(inputFilePath);

                tempDirPath = Path.Combine(_settingsProvider.TempFolderPath, Guid.NewGuid().ToString());
                WriteOut("Creating temp directory: " + tempDirPath);
                Directory.CreateDirectory(tempDirPath);

                string tempDocPath = Path.Combine(tempDirPath, fileName);

                WriteOut("Saving content to submit: " + tempDocPath);
                File.WriteAllBytes(tempDocPath, fileContent);
                tempDocPath = AddExchangeDocumentHeader(tempDocPath, true, null);
                var docName = Path.GetFileNameWithoutExtension(fileName) + "_Submission" + Path.GetExtension(tempDocPath);
                var newDocPath = Path.Combine(tempDirPath, docName);
                File.Move(tempDocPath, newDocPath);
                _documentManager.AddDocument(transactionId, CommonTransactionStatusCode.Completed, null, newDocPath);

                WriteOut("Parsing argument values ...");

                var endpointUri = ConfigurationArguments[CONFIG_PARAM_SUBMIT_ENDPOINT_URI];
                WriteOut("{0}: {1}", CONFIG_PARAM_SUBMIT_ENDPOINT_URI, endpointUri);

                if (!string.IsNullOrEmpty(endpointUri))
                {
                    var username = ConfigurationArguments[CONFIG_PARAM_SUBMIT_USERNAME];
                    WriteOut("{0}: {1}", CONFIG_PARAM_SUBMIT_USERNAME, username);

                    var password = ConfigurationArguments[CONFIG_PARAM_SUBMIT_PASSWORD];
                    WriteOut("{0}: {1}", CONFIG_PARAM_SUBMIT_PASSWORD, string.IsNullOrEmpty(password) ? "" : "*******");

                    WriteOut("Creating endpoint client ...");

                    string resultTranId = null;

                    INodeEndpointClient nodeClient;
                    if (string.IsNullOrEmpty(username))
                    {
                        nodeClient = _nodeEndpointClientFactory.Make(endpointUri, EndpointVersionType.EN20);
                    }
                    else
                    {
                        nodeClient = _nodeEndpointClientFactory.Make(endpointUri, EndpointVersionType.EN20,
                                                                     new AuthenticationCredentials(username, password));
                    }

                    using (nodeClient)
                    {
                        WriteOut("Submitting documents ...");
                        resultTranId = nodeClient.Submit(AQS_FLOW_NAME, null, new string[] { newDocPath });

                        if (string.IsNullOrEmpty(resultTranId))
                        {
                            throw new ApplicationException("Node client did not return any transaction id!");
                        }

                        _transactionManager.SetTransactionStatus(transactionId, CommonTransactionStatusCode.Completed,
                        WriteOut("Remote transaction Id: {1}", endpointUri, resultTranId), true);

                        _transactionManager.SetNetworkId(transactionId, resultTranId, nodeClient.Version, endpointUri, AQS_FLOW_NAME, null);
                        WriteOut("Submission complete ...");
                    }

                    status.Description = string.Format("The AQS document was successfully submitted at {0} with a returned transaction id of {1}.",
                        DateTime.Now, 
                        resultTranId);
                }
                if (deleteInputFile)
                {
                    File.Delete(inputFilePath);
                }
                status.Status = CommonTransactionStatusCode.Completed;
            }
            catch (Exception ex)
            {
                if (status != null)
                {
                    status.Description = string.Format("An error occurred running the {0} service:{1}{2}{3}",
                        SERVICE_NAME,
                        Environment.NewLine,
                        Environment.NewLine,
                        ExceptionUtils.GetDeepExceptionMessage(ex));
                    status.Status = CommonTransactionStatusCode.Failed;
                }
                throw;
            }
            finally
            {
                if (status.Description != null)
                {
                    AppendAuditLogEvent(status.Description);
                }
                if (tempDirPath != null)
                {
                    FileUtils.SafeDeleteDirectory(tempDirPath);
                }
            }
        }
    }
}
