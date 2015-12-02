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
    public class FileProcessor : AQSBaseHeaderPlugin, ISubmitProcessor
    {
        protected const string CONFIG_PARAM_SUBMIT_ENDPOINT_URI = "Submission Endpoint Url";
        public const string SERVICE_NAME = "AQS FileProcessor";
        private const string SUBMIT_ENDPOINT_URI = "https://testngn.epacdxnode.net/ngn-enws20/services/NetworkNode2ServiceConditionalMTOM";

        #region fields

        private static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());
        private INodeEndpointClientFactory _nodeEndpointClientFactory;
        private ITransactionManager _transactionManager;

        /// <summary>
        /// ENS User ID
        /// </summary>
        protected string _strSubmitEndpointUri;

        #endregion fields


        #region constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public FileProcessor()
        {
            ConfigurationArguments.Add(CONFIG_PARAM_SUBMIT_ENDPOINT_URI, SUBMIT_ENDPOINT_URI);
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

        /// <summary>
        /// Plug-in service processor method
        /// </summary>
        /// <param name="transactionId">Transaction ID reference</param>
        public virtual void ProcessSubmit(string transactionId)
        {
            TransactionStatus status = new TransactionStatus(transactionId);
            try
            {
                LazyInit();

                WriteOut("Getting documents to submit:");
                IList<Document> documents = _documentManager.GetDocuments(transactionId, true);
                List<string> documentPaths = new List<string>();

                string tempDirPath = Path.Combine(_settingsProvider.TempFolderPath, Guid.NewGuid().ToString());
                WriteOut("Creating temp directory: " + tempDirPath);
                Directory.CreateDirectory(tempDirPath);

                foreach (Document doc in documents)
                {
                    WriteOut("Doc: {0} ({1}); ", doc.DocumentName, doc.Type);
                    string tempDocPath = Path.Combine(tempDirPath, doc.DocumentName);

                    WriteOut("Saving content to submit: " + tempDocPath);
                    File.WriteAllBytes(tempDocPath, doc.Content);
                    tempDocPath = AddExchangeDocumentHeader(tempDocPath, true, null);
                    var docName = Path.GetFileNameWithoutExtension(doc.DocumentName) + "_Submission" + Path.GetExtension(tempDocPath);
                    var newDocPath = Path.Combine(Path.GetDirectoryName(tempDocPath), docName);
                    File.Move(tempDocPath, newDocPath);
                    _documentManager.AddDocument(transactionId, CommonTransactionStatusCode.Completed, null, newDocPath);
                    documentPaths.Add(newDocPath);
                }

                WriteOut("Parsing argument values ...");

                _strSubmitEndpointUri = ConfigurationArguments[CONFIG_PARAM_SUBMIT_ENDPOINT_URI];
                WriteOut("endpointUrl: {0}; ", _strSubmitEndpointUri);

                if (!string.IsNullOrEmpty(_strSubmitEndpointUri))
                {
                    WriteOut("Creating endpoint client ...");

                    string resultTranId = null;

                    using (INodeEndpointClient nodeClient = _nodeEndpointClientFactory.Make(_strSubmitEndpointUri,
                        EndpointVersionType.EN20))
                    {
                        WriteOut("Submitting documents ...");
                        resultTranId = nodeClient.Submit(AQS_FLOW_NAME, null, documentPaths);

                        if (string.IsNullOrEmpty(resultTranId))
                        {
                            throw new ApplicationException("Node client did not return any transaction id!");
                        }

                        _transactionManager.SetTransactionStatus(transactionId, CommonTransactionStatusCode.Completed,
                        WriteOut("Remote transaction Id: {1}", _strSubmitEndpointUri, resultTranId), true);

                        _transactionManager.SetNetworkId(transactionId, resultTranId, nodeClient.Version, _strSubmitEndpointUri, AQS_FLOW_NAME, null);
                        WriteOut("Submission complete ...");
                    }

                    status.Description = string.Format("The AQS document was successfully submitted at {0} with a returned transaction id of {1}.",
                        DateTime.Now, 
                        resultTranId);
                    status.Status = CommonTransactionStatusCode.Completed;
                }
            }
            catch (Exception ex)
            {
                status.Description = string.Format("An error occurred running the {0} service:{1}{2}{3}",
                    SERVICE_NAME, 
                    Environment.NewLine, 
                    Environment.NewLine, 
                    ExceptionUtils.GetDeepExceptionMessage(ex));
                status.Status = CommonTransactionStatusCode.Failed;
                throw;
            }
            finally
            {
                if (status.Description != null)
                {
                    AppendAuditLogEvent(status.Description);
                }
            }
        }
    }
}
