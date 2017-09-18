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

namespace Windsor.Node2008.WNOSPlugin.AQS_EndpointProxy
{

    #region enums

    /// <summary>
    /// Plug-in configuration parameters
    /// </summary>
    public enum AqsEndpointProxyServiceParameterType
    {
        /// <summary>
        /// endpoint to relay data submission to
        /// </summary>
        SUBMIT_ENDPOINT_URI,
        /// <summary>
        /// Data flow that will be used and relay endpoint
        /// </summary>
        DATA_FLOW,
        /// <summary>
        /// Exchange Network User ID
        /// </summary>
        ENS_USER_ID,
        /// <summary>
        /// Exchange Network password
        /// </summary>
        ENS_PASSWORD,
        /// <summary>
        /// OpenNode email notification list
        /// </summary>
        NOTIFICATION_EMAILS
    }

    #endregion enums


    /// <summary>
    /// Plug-in interface handler to process data file endpoint relay submissions
    /// </summary>
    [Serializable]
    public class ProxySubmissionRelayProcessor : BaseWNOSPlugin, ISubmitProcessor
    {
        public const string FLOW_NAME = "AQS";
        public const string SERVICE_NAME = "ProxySubmissionRelayProcessor";
        private const string SUBMIT_ENDPOINT_URI = "https://testngn.epacdxnode.net/ngn-enws20/services/NetworkNode2Service";

        #region fields

        private static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());
        private INodeEndpointClientFactory _nodeEndpointClientFactory;
        private IDocumentManager _documentManager;
        private ISettingsProvider _settingsProvider;
        private ITransactionManager _transactionManager;
        protected INotificationManager _notificationManager;

        /// <summary>
        /// ENS User ID
        /// </summary>
        protected string _strSubmitEndpointUri;

        /// <summary>
        /// ENS User ID
        /// </summary>
        protected string _strDataFlow;

        /// <summary>
        /// ENS User ID
        /// </summary>
        protected string _strEnsUserId;

        /// <summary>
        /// ENS Password
        /// </summary>
        protected string _strEnsPassword;

        /// <summary>
        /// Notification email addresses
        /// </summary>
        protected string _strNotificationEmails;

        #endregion fields


        #region constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public ProxySubmissionRelayProcessor()
        {
            ConfigurationArguments.Add(AqsEndpointProxyServiceParameterType.SUBMIT_ENDPOINT_URI.ToString(), SUBMIT_ENDPOINT_URI);
            ConfigurationArguments.Add(AqsEndpointProxyServiceParameterType.DATA_FLOW.ToString(), FLOW_NAME);
            ConfigurationArguments.Add(AqsEndpointProxyServiceParameterType.ENS_USER_ID.ToString(), null);
            ConfigurationArguments.Add(AqsEndpointProxyServiceParameterType.ENS_PASSWORD.ToString(), null);
            ConfigurationArguments.Add(AqsEndpointProxyServiceParameterType.NOTIFICATION_EMAILS.ToString(), null);
        }

        #endregion constructor


        #region initializer

        /// <summary>
        /// Class initializer
        /// </summary>
        protected void LazyInit()
        {
            GetServiceImplementation(out _nodeEndpointClientFactory);
            GetServiceImplementation(out _documentManager);
            GetServiceImplementation(out _settingsProvider);
            GetServiceImplementation(out _transactionManager);
            GetServiceImplementation(out _notificationManager);

            TryGetConfigParameter(AqsEndpointProxyServiceParameterType.NOTIFICATION_EMAILS.ToString(), ref _strNotificationEmails);
            if (_strNotificationEmails != null)
            {
                _strNotificationEmails = _strNotificationEmails.Trim();
            }
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
            publishFlags = DataServicePublishFlags.PublishToEndpointVersion11And20;
            return null;
        }

        /// <summary>
        /// Plug-in service processor method
        /// </summary>
        /// <param name="transactionId">Transaction ID reference</param>
        public void ProcessSubmit(string transactionId)
        {
            TransactionStatus status = new TransactionStatus(transactionId);
            try
            {
                LazyInit();

                WriteOut("Runtime arguments:");
                foreach (string param in Enum.GetNames(typeof(AqsEndpointProxyServiceParameterType)))
                {
                    WriteOut("{0} = {1}; ", param, ConfigurationArguments[param]);
                }

                WriteOut("Getting documents:");
                IList<Document> documents = _documentManager.GetDocuments(transactionId, true);
                List<string> documentPaths = new List<string>();

                string tempDirPath = Path.Combine(_settingsProvider.TempFolderPath, Guid.NewGuid().ToString());
                WriteOut("Creating temp. directory: " + tempDirPath);
                Directory.CreateDirectory(tempDirPath);

                foreach (Document doc in documents)
                {
                    WriteOut("Doc: {0} ({1}); ", doc.DocumentName, doc.Type);
                    string tempDocPath = Path.Combine(tempDirPath, doc.DocumentName);

                    WriteOut("Saving content: " + tempDocPath);
                    File.WriteAllBytes(tempDocPath, doc.Content);
                    documentPaths.Add(tempDocPath);
                }

                WriteOut("Parsing argument values...");
                
                _strSubmitEndpointUri = ConfigurationArguments[AqsEndpointProxyServiceParameterType.SUBMIT_ENDPOINT_URI.ToString()];
                WriteOut("endpointUrl: {0}; ", _strSubmitEndpointUri);

                if (!string.IsNullOrEmpty(_strSubmitEndpointUri))
                {

                    _strEnsUserId = GetConfigParameter(AqsEndpointProxyServiceParameterType.ENS_USER_ID.ToString());
                    WriteOut(" submit user: {0}", _strEnsUserId);

                    _strEnsPassword = GetConfigParameter(AqsEndpointProxyServiceParameterType.ENS_PASSWORD.ToString());
                    WriteOut(" submit password: *********", _strEnsPassword);

                    WriteOut("Creating endpoint client...");

                    _strDataFlow = ConfigurationArguments[AqsEndpointProxyServiceParameterType.DATA_FLOW.ToString()];
                    if (String.IsNullOrEmpty(_strDataFlow))
                    {
                        _strDataFlow = FLOW_NAME;
                    }

                    string resultTranId = null;

                    if (!String.IsNullOrEmpty(_strEnsUserId) && !String.IsNullOrEmpty(_strEnsPassword))
                    {

                        WriteOut("Using custom credentials");
                        using (INodeEndpointClient nodeClient = _nodeEndpointClientFactory.Make(_strSubmitEndpointUri,
                            EndpointVersionType.EN20,
                            new AuthenticationCredentials(_strEnsUserId, _strEnsPassword)))
                        {
                            WriteOut("Submitting documents...");
                            resultTranId = nodeClient.Submit(_strDataFlow, null, documentPaths);

                            if (string.IsNullOrEmpty(resultTranId))
                            {
                                throw new ApplicationException("Node client did not return any transaction!");
                            }

                            _transactionManager.SetTransactionStatus(transactionId, CommonTransactionStatusCode.Completed,
                            WriteOut("Remote transaction Id: {1}", _strSubmitEndpointUri, resultTranId), true);

                            _transactionManager.SetNetworkId(transactionId, resultTranId, EndpointVersionType.EN20, _strSubmitEndpointUri, _strDataFlow, null);
                            WriteOut("Submission done...");
                        }

                    }
                    else
                    {
                        WriteOut("Using default credentials");
                        using (INodeEndpointClient nodeClient = _nodeEndpointClientFactory.Make(_strSubmitEndpointUri,
                            EndpointVersionType.EN20))
                        {
                            WriteOut("Submitting documents...");
                            resultTranId = nodeClient.Submit(_strDataFlow, null, documentPaths);

                            if (string.IsNullOrEmpty(resultTranId))
                            {
                                throw new ApplicationException("Node client did not return any transaction!");
                            }

                            _transactionManager.SetTransactionStatus(transactionId, CommonTransactionStatusCode.Completed,
                            WriteOut("Remote transaction Id: {1}", _strSubmitEndpointUri, resultTranId), true);

                            _transactionManager.SetNetworkId(transactionId, resultTranId, nodeClient.Version, _strSubmitEndpointUri, _strDataFlow, null);
                            WriteOut("Submission done...");
                        }
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

                if ((_notificationManager != null) && !string.IsNullOrEmpty(_strNotificationEmails))
                {
                    string strMessage;
                    if (status.Status == CommonTransactionStatusCode.Completed)
                    {
                        strMessage = "Submitted AQS Document";
                    }
                    else
                    {
                        strMessage = "Failed to Submit AQS Document";
                    }

                    _notificationManager.DoScheduleNotifications(status, 
                        _strNotificationEmails,
                        strMessage, 
                        SERVICE_NAME,
                        null, 
                        null, 
                        status.Description);
                }
            }
        }

    }

}
