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
using Windsor.Node2008.WNOSConnector.Provider;
using Windsor.Node2008.WNOSConnector.Logic;
using Windsor.Node2008.WNOSPlugin;
using Windsor.Node2008.WNOSConnector.Admin;
using Windsor.Node2008.WNOSProviders;
using Windsor.Commons.Core;
using Windsor.Node2008.WNOS.Utilities;
using Windsor.Node2008.WNOSConnector.Server;

namespace Windsor.Node2008.WNOS.Logic
{
    public class TransactionManager : LogicAuditBaseManager, ITransactionManagerEx, ITransactionService, ISimpleLookupDataService
    {
        private ITransactionDao _transactionDao;
        private IDocumentManagerEx _documentManager;
        private INodeEndpointClientFactory _nodeEndpointClientFactory;
        private ICompressionHelper _compressionHelper;
        private INotificationManager _notificationManager;
        private IServiceManager _serviceManager;
        private IPluginLoader _pluginLoader;
        private IRequestManagerEx _requestManager;
        private IObjectCacheDao _objectCacheDao;

        #region Init

        new public void Init()
        {
			base.Init();
			
			FieldNotInitializedException.ThrowIfNull(this, ref _transactionDao);
			FieldNotInitializedException.ThrowIfNull(this, ref _documentManager);
            FieldNotInitializedException.ThrowIfNull(this, ref _nodeEndpointClientFactory);
            FieldNotInitializedException.ThrowIfNull(this, ref _settingsProvider);
            FieldNotInitializedException.ThrowIfNull(this, ref _compressionHelper);
            FieldNotInitializedException.ThrowIfNull(this, ref _serviceManager);
            FieldNotInitializedException.ThrowIfNull(this, ref _pluginLoader);
            FieldNotInitializedException.ThrowIfNull(this, ref _requestManager);
            FieldNotInitializedException.ThrowIfNull(this, ref _objectCacheDao);
        }

        #endregion

        public bool IsUnprocessed(string transactionId)
        {
            return _transactionDao.IsUnprocessed(transactionId);
        }
        public bool IsUnprocessed(string transactionId, out string userModifiedById)
        {
            return _transactionDao.IsUnprocessed(transactionId, out userModifiedById);
        }

        public TransactionStatus SetTransactionStatus(string transactionId, string userCreatorId,
													  CommonTransactionStatusCode statusCode, 
													  string statusDetail, bool sendStatusChangeNotifications)
        {
			return _transactionDao.SetTransactionStatus(transactionId, userCreatorId, statusCode, 
														statusDetail, sendStatusChangeNotifications);
        }
        public TransactionStatus SetTransactionStatus(string transactionId, CommonTransactionStatusCode statusCode, 
													  string statusDetail, bool sendStatusChangeNotifications)
        {
			return _transactionDao.SetTransactionStatus(transactionId, statusCode, statusDetail,
														sendStatusChangeNotifications);
        }
        public TransactionStatus SetTransactionStatusNoThrow(string transactionId, CommonTransactionStatusCode statusCode, 
															 string statusDetail, bool sendStatusChangeNotifications)
        {
			try {
				return SetTransactionStatus(transactionId, statusCode, statusDetail, 
											sendStatusChangeNotifications);
			}
			catch(Exception) {
			}
			return null;
        }
        protected TransactionStatus RefreshNetworkStatus(INodeEndpointClient client, NodeTransaction nodeTransaction)
        {
            string statusDetail = null;
            CommonTransactionStatusCode status;
            if (client.Version == EndpointVersionType.EN20)
            {
                // TODO: Could get status detail here too
                status = client.GetStatus(nodeTransaction.NetworkId);
            }
            else
            {
                status = client.GetStatus(nodeTransaction.NetworkId);
            }
            _transactionDao.SetNetworkIdStatus(nodeTransaction.Id, status, statusDetail);
            return new TransactionStatus(nodeTransaction.NetworkId, status, null);
        }
        public TransactionStatus RefreshNetworkStatus(string transactionID, AdminVisit visit)
        {
            NodeTransaction nodeTransaction;
            using (INodeEndpointClient client = GetNetworkTransactionNodeClient(transactionID, visit,
                                                                                out nodeTransaction))
            {
                return RefreshNetworkStatus(client, nodeTransaction);
            }
        }
        protected string GetCachedNetworkTransactionDocumentsName(string transactionID)
        {
            return "NetworkDocuments" + transactionID;
        }
        protected byte[] GetCachedNetworkTransactionDocuments(string transactionID, AdminVisit visit)
        {
            ValidateByRole(visit, SystemRoleType.Program);

            byte[] content = null;
            try
            {
                string cachedName = GetCachedNetworkTransactionDocumentsName(transactionID);
                if (_objectCacheDao.GetObject(cachedName, false, out content))
                {
                    return content;
                }
            }
            catch (Exception)
            {
            }
            return content;
        }
        protected void SaveCachedNetworkTransactionDocuments(string transactionID, byte[] content)
        {
            try
            {
                string cachedName = GetCachedNetworkTransactionDocumentsName(transactionID);
                _objectCacheDao.CacheObject(content, cachedName, TimeSpan.FromDays(365 * 10));
            }
            catch (Exception)
            {
            }
        }
        public byte[] DownloadNetworkDocumentsAsZipFile(string transactionID, AdminVisit visit)
        {
            byte[] content = GetCachedNetworkTransactionDocuments(transactionID, visit);
            if (content != null)
            {
                return content;
            }
            NodeTransaction nodeTransaction;
            string[] documents;
            TransactionStatus status;
            using (INodeEndpointClient client = GetNetworkTransactionNodeClient(transactionID, visit, 
                                                                                out nodeTransaction))
            {
                status = RefreshNetworkStatus(client, nodeTransaction);
                documents = client.Download(nodeTransaction.Flow.FlowName, nodeTransaction.NetworkId);
            }
            if (CollectionUtils.IsNullOrEmpty(documents))
            {
                return null;
            }
            string tempZipPath = _settingsProvider.NewTempFilePath(".zip");
            _compressionHelper.CompressFiles(tempZipPath, documents);
            content = File.ReadAllBytes(tempZipPath);
            if ((status.Status == CommonTransactionStatusCode.Completed) ||
                (status.Status == CommonTransactionStatusCode.Failed))
            {
                SaveCachedNetworkTransactionDocuments(transactionID, content);
            }
            return content;
        }
        protected INodeEndpointClient GetNetworkTransactionNodeClient(string transactionID, AdminVisit visit,
                                                                      out NodeTransaction nodeTransaction)
        {
            nodeTransaction = Get(transactionID, visit);

            if (nodeTransaction == null)
            {
                throw new ArgumentException(string.Format("Could not find transaction with id: {0}", transactionID));
            }
            if (string.IsNullOrEmpty(nodeTransaction.NetworkId) || string.IsNullOrEmpty(nodeTransaction.NetworkEndpointUrl))
            {
                throw new ArgumentException(string.Format("The transaction \"{0}\" does not have an associated network id or url", transactionID));
            }

            return _nodeEndpointClientFactory.Make(nodeTransaction.NetworkEndpointUrl, nodeTransaction.NetworkEndpointVersion);
        }
        public TransactionStatus SetTransactionStatusIfNotStatus(string transactionId, CommonTransactionStatusCode statusCodeToSet, 
																 string statusDetail, CommonTransactionStatusCode setIfNotStatusCodes,
																 bool sendStatusChangeNotifications)
        {
			return _transactionDao.SetTransactionStatusIfNotStatus(transactionId, statusCodeToSet, statusDetail,
																   setIfNotStatusCodes, sendStatusChangeNotifications);
        }
        public TransactionStatus GetTransactionStatus(string transactionID)
        {
			return _transactionDao.GetTransactionStatus(transactionID);
        }
        public TransactionStatus GetTransactionStatus(string transactionId, out string flowId,
													  out string operation, out NodeMethod webMethod)
        {
			return _transactionDao.GetTransactionStatus(transactionId, out flowId, out operation, out webMethod);
        }
        public TransactionStatus GetTransactionStatusByNetworkId(string networkId, out string flowId,
                                                      out string operation, out NodeMethod webMethod)
        {
            return _transactionDao.GetTransactionStatusByNetworkId(networkId, out flowId, out operation, out webMethod);
        }
        public TransactionStatus GetTransactionStatusAndFlowName(string transactionId, out string flowName,
													             out string operation, out NodeMethod webMethod,
                                                                 out EndpointVersionType endpointVersion)
        {
			return _transactionDao.GetTransactionStatusAndFlowName(transactionId, out flowName, out operation, 
                                                                   out webMethod, out endpointVersion);
        }
		public NodeTransaction GetTransaction(string transactionId, CommonTransactionStatusCode returnDocsWithStatus)
		{
			return _transactionDao.GetTransaction(transactionId, returnDocsWithStatus);
		}
        public NodeTransaction GetTransaction(string transactionId)
        {
            return _transactionDao.GetTransaction(transactionId);
        }
        public string CreateTransaction(NodeMethod webMethod, EndpointVersionType endpointVersion, string flowId, 
                                        string operation, string userCreatorId,
										CommonTransactionStatusCode statusCode, string statusDetail,
										IDictionary<string, TransactionNotificationType> notifications, 
                                        IList<string> recipients, bool sendStatusChangeNotifications) {
            return _transactionDao.CreateTransaction(webMethod, endpointVersion, flowId, operation, userCreatorId,
													 statusCode, statusDetail, notifications, recipients,
													 sendStatusChangeNotifications);
		}
        public string QueueTask(string flowName, string serviceName, string taskCreatorId,
                                ByIndexOrNameDictionary<string> taskParameters)
        {
            // Locate and validate the data service
            DataService dataService =
                ServiceManager.ValidateDataService(flowName, serviceName, ServiceType.Task);

            // Locate and validate the task plugin
            PluginLoader.ValidateTaskProcessor(dataService);

            // Create the transaction and request for the task
            string transactionId = CreateTransaction(NodeMethod.Task, EndpointVersionType.Undefined,
                                                     dataService.FlowId, serviceName, taskCreatorId,
                                                     CommonTransactionStatusCode.Unknown,
                                                     null, null, null, false);

            try
            {
                string requestId =
                    _requestManager.CreateDataRequest(transactionId, dataService.Id, 0, -1,
                                                      RequestType.Task, taskCreatorId,
                                                      taskParameters);
                SetTransactionStatus(transactionId, taskCreatorId, CommonTransactionStatusCode.Received,
                                     null, false);
            }
            catch (Exception e)
            {
                SetTransactionStatus(transactionId, CommonTransactionStatusCode.Failed, e.Message, false);
                throw;
            }

            return transactionId;
        }
        public IList<string> GetAllUnprocessedSubmitTransactionIds()
        {
			return _transactionDao.GetAllUnprocessedSubmitTransactionIds();
		}
        public IList<string> GetAllUnprocessedDocumentDbIds(string transactionId)
        {
            return _transactionDao.GetAllUnprocessedDocumentDbIds(transactionId);
		}
		public IList<string> GetAllUnprocessedNotifyTransactionIds()
		{
			return _transactionDao.GetAllUnprocessedNotifyTransactionIds();
		}
        public DataService GetSubmitDocumentServiceForTransaction(string transactionId, out string flowName,
                                                                  out string operation)
        {
            return _transactionDao.GetSubmitDocumentServiceForTransaction(transactionId, out flowName,
                                                                          out operation);
        }
        public DataService GetNotifyDocumentServiceForTransaction(string transactionId, out string flowName,
                                                                  out string operation)
		{
            return _transactionDao.GetNotifyDocumentServiceForTransaction(transactionId, out flowName,
                                                                          out operation);
		}
        public DataService GetQueryServiceForTransaction(string transactionId, out string flowName,
                                                         out string operation, out string requestId)
		{
			return _transactionDao.GetQueryServiceForTransaction(transactionId, out flowName,
                                                                 out operation, out requestId);
		}
		public DataService GetSolicitServiceForTransaction(string transactionId, out string flowName,
                                                           out string operation, out string requestId)
		{
			return _transactionDao.GetSolicitServiceForTransaction(transactionId, out flowName,
                                                                   out operation, out requestId);
		}
        public DataService GetTaskServiceForTransaction(string transactionId, out string flowName,
                                                        out string operation, out string requestId)
        {
            return _transactionDao.GetTaskServiceForTransaction(transactionId, out flowName,
                                                                out operation, out requestId);
        }
        public DataService GetExecuteServiceForTransaction(string transactionId, out string flowName,
                                                           out string operation, out string requestId)
        {
            return _transactionDao.GetExecuteServiceForTransaction(transactionId, out flowName,
                                                                   out operation, out requestId);
        }
        public IList<string> GetAllUnprocessedSolicitTransactionIds()
        {
            return _transactionDao.GetAllUnprocessedSolicitTransactionIds();
		}
        public IList<string> GetAllUnprocessedTaskTransactionIds()
        {
            return _transactionDao.GetAllUnprocessedTaskTransactionIds();
        }
        public IList<string> GetAllUnprocessedExecuteTransactionIds()
        {
            return _transactionDao.GetAllUnprocessedExecuteTransactionIds();
        }
        public void AddNotifications(string transactionId, IDictionary<string, TransactionNotificationType> notifications)
		{
			_transactionDao.AddNotifications(transactionId, notifications);
        }
        public void AddRecipients(string transactionId, IList<string> recipients) {
			_transactionDao.AddRecipients(transactionId, recipients);
        }
        public IDictionary<string, TransactionNotificationType> GetNotifications(string transactionId) {
			return _transactionDao.GetNotifications(transactionId);
        }
        public IList<string> GetRecipients(string transactionId) {
			return _transactionDao.GetRecipients(transactionId);
        }
        public string GetTransactionUsername(string transactionId)
        {
            return _transactionDao.GetTransactionUsername(transactionId);
        }
        protected virtual Stream GetZippedTransactionDocuments(string transactionId)
        {
            IList<Document> documents = _documentManager.GetDocuments(transactionId, false);
            if (CollectionUtils.IsNullOrEmpty(documents))
            {
                return null;
            }
            // If single document and already zipped, return single document
            if ((documents.Count == 1) && documents[0].IsZipFile)
            {
                return new MemoryStream(_documentManager.GetContent(transactionId, documents[0].Id), false);
            }

            // Zip up all documents to a temp file
            string tempFilePath = SettingsProvider.NewTempFilePath();
            foreach (Document doc in documents)
            {
                string fileName;
                if (!string.IsNullOrEmpty(doc.DocumentName))
                {
                    fileName = doc.DocumentName;
                }
                else if (!string.IsNullOrEmpty(doc.DocumentId))
                {
                    fileName =
                        Path.ChangeExtension(doc.DocumentId, CommonContentAndFormatProvider.GetFileExtension(doc.Type));
                }
                else
                {
                    fileName =
                        Path.ChangeExtension(doc.Id, CommonContentAndFormatProvider.GetFileExtension(doc.Type));
                }
                fileName = FileUtils.ReplaceInvalidFilenameChars(fileName, '_');
                _compressionHelper.Compress(fileName, _documentManager.GetContent(transactionId, doc.Id),
                                            tempFilePath);
            }
            return File.OpenRead(tempFilePath);
        }
        protected bool GetZippedTransactionDocuments(string transactionId, string saveFilePath)
        {
            using (Stream zippedContent = GetZippedTransactionDocuments(transactionId))
            {
                if (zippedContent != null)
                {
                    FileUtils.WriteAllBytes(zippedContent, saveFilePath);
                    return true;
                }
            }
            return false;
        }
        public bool GetZippedTransactionDocumentsAsFile(string transactionId, string filePath)
        {
            return GetZippedTransactionDocuments(transactionId, filePath);
        }
        public string GetZippedTransactionDocumentsAsTempFile(string transactionId)
        {
            string filePath = _settingsProvider.NewTempFilePath(".zip");
            if (GetZippedTransactionDocuments(transactionId, filePath))
            {
                return filePath;
            }
            else
            {
                return null;
            }
        }
        public string DoTransactionNotifications(string transactionId)
        {
            try
            {
                IDictionary<string, TransactionNotificationType> notifications = GetNotifications(transactionId);
                if (CollectionUtils.IsNullOrEmpty(notifications))
                {
                    return string.Format("No status notifications found for transaction \"{0}\"", transactionId);
                }
                string flowName, flowOperation;
                NodeMethod nodeMethod;
                EndpointVersionType endpointVersion;
                TransactionStatus transactionStatus =
                    GetTransactionStatusAndFlowName(transactionId, out flowName, out flowOperation,
                                                    out nodeMethod, out endpointVersion);

                if (transactionStatus == null)
                {
                    throw new ArgumentException("Could not find transaction id in DB: \"{0}\"", transactionId);
                }
                StringBuilder sb = new StringBuilder();
                if (endpointVersion == EndpointVersionType.EN11)
                {
                    string filePath = GetZippedTransactionDocumentsAsTempFile(transactionId);
                    if (filePath == null)
                    {
                        return string.Format("No notifications found for transaction \"{0}\"", transactionId);
                    }
                    try
                    {
                        foreach (KeyValuePair<string, TransactionNotificationType> pair in notifications)
                        {
                            string result =
                                DoTransactionNotificationSubmit(nodeMethod, filePath, transactionStatus, flowName, flowOperation,
                                                                pair.Key, endpointVersion);
                            sb.AppendLine(result);
                        }
                    }
                    finally
                    {
                        FileUtils.SafeDeleteFile(filePath);
                    }
                }
                else
                {
                    foreach (KeyValuePair<string, TransactionNotificationType> pair in notifications)
                    {
                        string result =
                            DoTransactionNotificationNotify(nodeMethod, transactionStatus, flowName, flowOperation,
                                                            pair.Key, endpointVersion);
                        sb.AppendLine(result);
                    }
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                return string.Format("An error occurred attempting to send status notifications for transaction \"{0}\": {1}",
                                     transactionId, ExceptionUtils.ToShortString(ex));
            }
        }
        protected string DoTransactionNotificationNotify(NodeMethod nodeMethod, TransactionStatus status,
                                                         string flowName, string flowOperation,
                                                         string notificationAddress,
                                                         EndpointVersionType endpointVersion)
        {
            bool isNodeAddress = notificationAddress.StartsWith("http", StringComparison.InvariantCultureIgnoreCase);
            if (isNodeAddress)
            {
                return TransactionNotificationNodeNotify(status, flowName, flowOperation,
                                                         notificationAddress, endpointVersion);
            }
            else
            {
                return TransactionNotificationEmailNotify(nodeMethod, status, flowName, flowOperation,
                                                          notificationAddress, endpointVersion);
            }
        }
        protected string DoTransactionNotificationSubmit(NodeMethod nodeMethod, string filePath, TransactionStatus transactionStatus,
                                                   string flowName, string flowOperation,
                                                   string notificationAddress, 
                                                   EndpointVersionType endpointVersion)
        {
            if ( string.IsNullOrEmpty(notificationAddress) ) {
                return string.Format("Got empty recipient address for transaction \"{0}\"",
                                     transactionStatus.Id);
            }
            bool isNodeAddress = notificationAddress.StartsWith("http", StringComparison.InvariantCultureIgnoreCase);
            if (isNodeAddress)
            {
                return TransactionNotificationNodeSubmit(filePath, transactionStatus, flowName, flowOperation,
                                                         notificationAddress, endpointVersion);
            }
            else
            {
                return TransactionNotificationEmailSubmit(nodeMethod, filePath, transactionStatus, flowName, flowOperation,
                                                          notificationAddress, endpointVersion);
            }
        }
        protected string TransactionNotificationNodeSubmit(string filePath,
                                                          TransactionStatus transactionStatus,
                                                          string flowName,
                                                          string flowOperation,
                                                          string recipientAddress,
                                                          EndpointVersionType endpointVersion)
        {

            try
            {
                string remoteTransactionId;
                using (INodeEndpointClient client = _nodeEndpointClientFactory.Make(recipientAddress, endpointVersion))
                {
                    if (client.Version == EndpointVersionType.EN11)
                    {
                        remoteTransactionId = client.Submit(flowName, transactionStatus.Id, new string[] { filePath });
                    }
                    else
                    {
                        remoteTransactionId = client.Submit(flowName, flowOperation,
                                                      transactionStatus.Id, new string[] { filePath });
                    }
                }
                return string.Format("Submitted transaction \"{0}\" documents to url \"{1}\" (\"{2}\") for flow \"{3}\" with remote network transaction id \"{4}.\"",
                                     transactionStatus.Id, recipientAddress, endpointVersion.ToString(), flowName,
                                     remoteTransactionId);
            }
            catch (Exception e)
            {
                return string.Format("Failed to submit transaction \"{0}\" documents to url \"{1}\" (\"{2}\") for flow \"{3}.\"  EXCEPTION: {4}",
                                     transactionStatus.Id, recipientAddress, endpointVersion.ToString(), flowName,
                                     ExceptionUtils.GetDeepExceptionMessage(e));
            }
        }
        protected string TransactionNotificationEmailSubmit(NodeMethod nodeMethod, string filePath,
                                                           TransactionStatus transactionStatus,
                                                           string flowName,
                                                           string flowOperation,
                                                           string recipientAddress,
                                                           EndpointVersionType endpointVersion)
        {
            try
            {
                _notificationManager.DoRemoteTransactionStatusNotifications(nodeMethod, filePath, transactionStatus, 
                                                                            flowName, flowOperation,
                                                                            recipientAddress);
                return string.Format("Attempted to email transaction \"{0}\" status to address \"{1}\"",
                                     transactionStatus.Id, recipientAddress);
            }
            catch (Exception e)
            {
                return string.Format("Failed to email transaction \"{0}\" status to address \"{1}\".  EXCEPTION: {2}",
                                     transactionStatus.Id, recipientAddress, ExceptionUtils.GetDeepExceptionMessage(e));
            }
        }
        protected string TransactionNotificationNodeNotify(TransactionStatus status,
                                                          string flowName,
                                                          string flowOperation,
                                                          string recipientAddress,
                                                          EndpointVersionType endpointVersion)
        {

            try
            {
                using (INodeEndpointClient client = _nodeEndpointClientFactory.Make(recipientAddress, endpointVersion))
                {
                    if (endpointVersion == EndpointVersionType.EN11)
                    {
                        client.NotifyStatus11(string.Empty, status.Id, status.Status, status.Description);
                    }
                    else
                    {
                        client.NotifyStatus20(string.Empty, flowName, status.Id, status.Status, status.Description);
                    }
                }
                return string.Format("Sent notification status for transaction \"{0}\" of \"{1}\" to url \"{2}\" (\"{3}\") for flow \"{4}.\"",
                                     status.Id.ToString(), status.Status.ToString(), recipientAddress, endpointVersion.ToString(), 
                                     flowName);
            }
            catch (Exception e)
            {
                return string.Format("Failed to send notification status for transaction \"{0}\" of \"{1}\" to url \"{2}\" (\"{3}\") for flow \"{4}.\"  EXCEPTION: {5}",
                                     status.Id.ToString(), status.Status.ToString(), recipientAddress, endpointVersion.ToString(),
                                     flowName, ExceptionUtils.GetDeepExceptionMessage(e));
            }
        }
        protected string TransactionNotificationEmailNotify(NodeMethod nodeMethod, TransactionStatus transactionStatus,
                                                           string flowName,
                                                           string flowOperation,
                                                           string recipientAddress,
                                                           EndpointVersionType endpointVersion)
        {
            try
            {
                _notificationManager.DoRemoteTransactionStatusNotifications(nodeMethod, null, transactionStatus,
                                                                            flowName, flowOperation,
                                                                            recipientAddress);
                return string.Format("Attempted to email transaction \"{0}\" status to address \"{1}\"",
                                     transactionStatus.Id, recipientAddress);
            }
            catch (Exception e)
            {
                return string.Format("Failed to email transaction \"{0}\" status to address \"{1}\".  EXCEPTION: {2}",
                                     transactionStatus.Id, recipientAddress, ExceptionUtils.GetDeepExceptionMessage(e));
            }
        }
        public ComplexNotification GetNotifyTransactionByTransactionId(string transactionID)
        {
            return _transactionDao.GetNotifyTransactionByTransactionId(transactionID);
        }
        public string CreateNotifyTransaction(string flowId, string operation, string userCreatorId,
                                              CommonTransactionStatusCode statusCode, string statusDetail,
                                              ComplexNotification notification, EndpointVersionType endpointVersion,
                                              bool sendStatusChangeNotifications)
        {
            return _transactionDao.CreateNotifyTransaction(flowId, operation, userCreatorId,
                                                           statusCode, statusDetail, notification,
                                                           endpointVersion, sendStatusChangeNotifications);
        }
        public void SetNetworkId(string transactionId, string networkId, EndpointVersionType networkEndpointVersion,
                                 string networkEndpointUrl)
        {
            _transactionDao.SetNetworkId(transactionId, networkId, networkEndpointVersion, networkEndpointUrl);
        }
        public string GetNetworkId(string transactionId)
        {
            return _transactionDao.GetNetworkId(transactionId);
        }
        public byte[] DownloadContent(string transactionID, string id, AdminVisit visit)
        {
            ValidateByRole(visit, SystemRoleType.Program);

            return _documentManager.GetContent(transactionID, id);
        }

        public NodeTransaction Get(string transactionID, AdminVisit visit)
        {
            ValidateByRole(visit, SystemRoleType.Program);

            if ((transactionID == null) || string.IsNullOrEmpty(transactionID) ||
                string.IsNullOrEmpty(transactionID))
            {
                throw new ArgumentException("Input values are null.");
            }

            return _transactionDao.GetTransaction(transactionID);
        }
        public IList<StatusActivityEntry> GetRealtimeTransactionDetails(string transactionId, AdminVisit visit)
        {
            ValidateByRole(visit, SystemRoleType.Program);
            return GetRealtimeTransactionDetails(transactionId);
        }
        public void AppendRealtimeTransactionDetail(string transactionId, string message,
                                                    StatusActivityType statusType)
        {
            _transactionDao.AppendRealtimeTransactionDetail(transactionId, message, statusType);
        }
        public IList<StatusActivityEntry> GetRealtimeTransactionDetails(string transactionId)
        {
            return _transactionDao.GetRealtimeTransactionDetails(transactionId);
        }
        public void ClearRealtimeTransactionDetails(string transactionId)
        {
            _transactionDao.GetRealtimeTransactionDetails(transactionId);
        }
        #region Properties
		public IDocumentManagerEx DocumentManager {
			get {
				return _documentManager;
			}
			set {
				_documentManager = value;
			}
		}

        public ITransactionDao TransactionDao
        {
			get {
				return _transactionDao;
			}
			set {
				_transactionDao = value;
			}
		}
        public INodeEndpointClientFactory NodeEndpointClientFactory
        {
            get { return _nodeEndpointClientFactory; }
            set { _nodeEndpointClientFactory = value; }
        }

        public ICompressionHelper CompressionHelper
        {
            get { return _compressionHelper; }
            set { _compressionHelper = value; }
        }

        public INotificationManager NotificationManager
        {
            get { return _notificationManager; }
            set { _notificationManager = value; }
        }
        public IServiceManager ServiceManager
        {
            get { return _serviceManager; }
            set { _serviceManager = value; }
        }

        public IPluginLoader PluginLoader
        {
            get { return _pluginLoader; }
            set { _pluginLoader = value; }
        }

        public IRequestManagerEx RequestManager
        {
            get { return _requestManager; }
            set { _requestManager = value; }
        }
        public IObjectCacheDao ObjectCacheDao
        {
            get { return _objectCacheDao; }
            set { _objectCacheDao = value; }
        }
        #endregion


        #region ISimpleLookupDataService Members

        public Dictionary<string, string> GetLookupData()
        {
            return _transactionDao.GetTransactionTypes();
        }

        #endregion
    }
}
