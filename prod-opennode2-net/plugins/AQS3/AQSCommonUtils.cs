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


using Windsor.Node2008.WNOSProviders;
using Windsor.Commons.Core;
using System;
using System.Xml;
using System.Collections.Generic;
using Windsor.Commons.NodeDomain;
using Windsor.Node2008.WNOSDomain;
using System.IO;

namespace Windsor.Node2008.WNOSPlugin.AQS3
{
    [Serializable]
    public abstract class AQSBaseHeaderPlugin : BaseWNOSPlugin
    {
        protected const string AQS_FLOW_NAME = "AQS";
        protected const char EMAIL_ADDRESS_SEPARATOR = ';';

        protected const string CONFIG_PARAM_ADD_HEADER = "Add Header (True or False)";
        protected const string CONFIG_PARAM_AUTHOR = "Author";
        protected const string CONFIG_PARAM_ORGANIZATION = "Organization";
        protected const string CONFIG_PARAM_AQS_USER_ID = "AQS User Id";
        protected const string CONFIG_PARAM_SENDER_ADDRESS = "Sender Address";
        protected const string CONFIG_PARAM_AQS_SCREENING_GROUP = "AQS Screening Group";
        protected const string CONFIG_PARAM_AQS_FINAL_PROCESSING_STEP = "AQS Final Processing Step (Stage, Load, or Post)";
        protected const string CONFIG_PARAM_AQS_STOP_ON_ERROR = "AQS Stop On Error (Yes or No)";
        
        protected const string PARAM_VALIDATE_XML_KEY = "ValidateXml";

        protected bool _addHeader;
        protected string _author;
        protected string _organization;
        protected string _aqsUserId;
        protected string _senderAddress;
        protected string _aqsScreeningGroup;
        protected string _aqsFinalProcessingStep;
        protected string _aqsStopOnError;
        protected bool _validateXml;

        protected IHeaderDocument2Helper _headerDocumentHelper;
        protected ISettingsProvider _settingsProvider;
        protected ICompressionHelper _compressionHelper;
        protected ISerializationHelper _serializationHelper;
        protected IDocumentManager _documentManager;

        public AQSBaseHeaderPlugin()
        {
            ConfigurationArguments.Add(CONFIG_PARAM_ADD_HEADER, null);
            ConfigurationArguments.Add(CONFIG_PARAM_AUTHOR, null);
            ConfigurationArguments.Add(CONFIG_PARAM_ORGANIZATION, null);
            ConfigurationArguments.Add(CONFIG_PARAM_AQS_USER_ID, null);
            ConfigurationArguments.Add(CONFIG_PARAM_SENDER_ADDRESS, null);
            ConfigurationArguments.Add(CONFIG_PARAM_AQS_SCREENING_GROUP, null);
            ConfigurationArguments.Add(CONFIG_PARAM_AQS_FINAL_PROCESSING_STEP, null);
            ConfigurationArguments.Add(CONFIG_PARAM_AQS_STOP_ON_ERROR, null);
        }
        protected virtual void LazyInit()
        {
            AppendAuditLogEvent("Initializing {0} plugin ...", this.GetType().Name);

            GetServiceImplementation(out _headerDocumentHelper);
            GetServiceImplementation(out _settingsProvider);
            GetServiceImplementation(out _compressionHelper);
            GetServiceImplementation(out _serializationHelper);
            GetServiceImplementation(out _documentManager);

            GetConfigParameter(CONFIG_PARAM_ADD_HEADER, true, out _addHeader);

            if (_addHeader)
            {
                _aqsUserId = ValidateNonEmptyConfigParameter(CONFIG_PARAM_AQS_USER_ID);
                _aqsScreeningGroup = ValidateNonEmptyConfigParameter(CONFIG_PARAM_AQS_SCREENING_GROUP);
                TryGetConfigParameter(CONFIG_PARAM_AUTHOR, ref _author);
                TryGetConfigParameter(CONFIG_PARAM_ORGANIZATION, ref _organization);
                TryGetConfigParameter(CONFIG_PARAM_SENDER_ADDRESS, ref _senderAddress);
                TryGetConfigParameter(CONFIG_PARAM_AQS_FINAL_PROCESSING_STEP, ref _aqsFinalProcessingStep);
                TryGetConfigParameter(CONFIG_PARAM_AQS_STOP_ON_ERROR, ref _aqsStopOnError);

                AppendAuditLogEvent("An exchange header will be added to the document with the following values: {0} ({1}), {2} ({3}), {4} ({5}), {6} ({7}), {8} ({9}), {10} ({11}), {12} ({13}).",
                                    CONFIG_PARAM_AUTHOR, _author ?? string.Empty, 
                                    CONFIG_PARAM_ORGANIZATION, _organization ?? string.Empty,
                                    CONFIG_PARAM_SENDER_ADDRESS, _senderAddress ?? string.Empty, 
                                    CONFIG_PARAM_AQS_USER_ID, _aqsUserId ?? string.Empty,
                                    CONFIG_PARAM_AQS_SCREENING_GROUP, _aqsScreeningGroup ?? string.Empty,
                                    CONFIG_PARAM_AQS_FINAL_PROCESSING_STEP, _aqsFinalProcessingStep ?? string.Empty,
                                    CONFIG_PARAM_AQS_STOP_ON_ERROR, _aqsStopOnError ?? string.Empty);
            }
            else
            {
                AppendAuditLogEvent("An exchange header will not be added to the document since the \"{0}\" parameter is false.",
                                    CONFIG_PARAM_ADD_HEADER);
            }
        }
        protected virtual string AddExchangeDocumentHeader(object data, bool doCompress, string docTransactionId)
        {
            string tempXmlFilePath = _settingsProvider.NewTempFilePath(".xml");
            try
            {
                ExceptionUtils.ThrowIfNull(data, "data");

                _serializationHelper.Serialize(data, tempXmlFilePath);
            }
            catch (Exception ex)
            {
                AppendAuditLogEvent("Failed to serialized data of type \"{0}\" with exception: {1}",
                                    data.GetType().Name, ExceptionUtils.GetDeepExceptionMessage(ex));
                throw;
            }

            ValidateXmlFile(docTransactionId, tempXmlFilePath);

            return AddExchangeDocumentHeader(tempXmlFilePath, doCompress, docTransactionId);
        }
        protected virtual void ValidateXmlFile(string transactionId, string xmlFilePath)
        {
            if (_validateXml)
            {
                ValidateXmlFileAndAttachErrorsAndFileToTransaction(xmlFilePath, "xml_schema.xml_schema.zip",
                                                                   null, transactionId);
            }
        }
        protected virtual string AddExchangeDocumentHeader(string inputFile, bool doCompress, string docTransactionId)
        {
            string tempZipFilePath = _settingsProvider.NewTempFilePath(".zip");

            if (!_addHeader)
            {
                if (doCompress && !_compressionHelper.IsCompressed(inputFile))
                {
                    _compressionHelper.CompressFile(inputFile, tempZipFilePath);
                }
                else
                {
                    tempZipFilePath = inputFile;
                }
            }
            else
            {
                AppendAuditLogEvent("Adding an exchange header to the document ...");

                ExceptionUtils.ThrowIfFileNotFound(inputFile);

                string tempInputFilePath = _settingsProvider.NewTempFilePath(".xml");
                string tempXmlFilePath = _settingsProvider.NewTempFilePath(".xml");

                try
                {
                    if (_compressionHelper.IsCompressed(inputFile))
                    {
                        _compressionHelper.Uncompress(inputFile, tempInputFilePath);
                        inputFile = tempInputFilePath;
                    }

                    XmlDocument doc = new XmlDocument();
                    doc.Load(inputFile);

                    _headerDocumentHelper.Configure(_author, _organization, "AQS Data", AQS_FLOW_NAME, null, null, _aqsUserId, null);
                    if (!string.IsNullOrEmpty(_senderAddress))
                    {
                        List<string> emails = StringUtils.SplitAndReallyRemoveEmptyEntries(_senderAddress, EMAIL_ADDRESS_SEPARATOR);
                        if (!CollectionUtils.IsNullOrEmpty(emails))
                        {
                            _headerDocumentHelper.AddNotifications(emails);
                        }
                    }
                    if (!string.IsNullOrEmpty(_aqsScreeningGroup))
                    {
                        _headerDocumentHelper.AddPropery("AQS.ScreeningGroup", _aqsScreeningGroup);
                    }
                    if (!string.IsNullOrEmpty(_aqsFinalProcessingStep))
                    {
                        _headerDocumentHelper.AddPropery("AQS.FinalProcessingStep", _aqsFinalProcessingStep);
                    }
                    if (!string.IsNullOrEmpty(_aqsStopOnError))
                    {
                        _headerDocumentHelper.AddPropery("AQS.StopOnError", _aqsStopOnError);
                    }
                    _headerDocumentHelper.AddPropery("AQS.SchemaVersion", "3.0");

                    _headerDocumentHelper.AddPropery("AQS.PayloadType", "XML");

                    _headerDocumentHelper.AddPayload(null, doc.DocumentElement);

                    _headerDocumentHelper.Serialize(tempXmlFilePath);

                    if (doCompress)
                    {
                        _compressionHelper.CompressFile(tempXmlFilePath, tempZipFilePath);
                    }
                    else
                    {
                        tempZipFilePath = tempXmlFilePath;
                    }
                }
                catch (Exception ex)
                {
                    AppendAuditLogEvent("Failed to add an exchange header to the document with the following exception: {0}",
                                        ExceptionUtils.GetDeepExceptionMessage(ex));
                    FileUtils.SafeDeleteFile(tempZipFilePath);
                    throw;
                }
                finally
                {
                    FileUtils.SafeDeleteFile(tempInputFilePath);
                    FileUtils.SafeDeleteFile(tempXmlFilePath);
                }
            }
            if (!string.IsNullOrEmpty(docTransactionId))
            {
                _documentManager.AddDocument(docTransactionId, CommonTransactionStatusCode.Completed, null, tempZipFilePath);
            }
            return tempZipFilePath;
        }
    }
    [Serializable]
    public abstract class BaseGetAQSStatusAndDownloadReports : BaseWNOSPlugin, ITaskProcessor
    {
        protected const string CONFIG_MAX_CHECK_DAYS = "Max Check Status Days (default: 2 days)";
        protected const string CONFIG_PARAM_NOTIFY_EMAILS = "Notification Emails (semicolon separated)";
        protected const string CONFIG_PARAM_ATTACH_DOCS_TO_NOTIFY_EMAILS = "Attach Documents to Notification Emails (True or False)";
        protected const string CHECK_STATUS_COMPLETE_FILE_NAME = "CheckStatusComplete.xml";

        protected const int MAX_MAX_CHECK_DAYS = 14;
        protected const int MIN_MAX_CHECK_DAYS = 2;

        protected IFlowManager _flowManager;
        protected ISerializationHelper _serializationHelper;
        protected ICompressionHelper _compressionHelper;
        protected IDocumentManager _documentManager;
        protected ISettingsProvider _settingsProvider;
        protected ITransactionManager _transactionManager;
        protected IRequestManager _requestManager;
        protected INotificationManager _notificationManager;

        protected string _dataRequestFlowName;
        protected DataRequest _dataRequest;
        protected IList<string> _notificationEmails;
        protected bool _attachDocsToNotificationEmails;

        protected int _maxCheckDays = 2;

        public BaseGetAQSStatusAndDownloadReports()
        {
            ConfigurationArguments.Add(CONFIG_MAX_CHECK_DAYS, null);
            ConfigurationArguments.Add(CONFIG_PARAM_NOTIFY_EMAILS, null);
            ConfigurationArguments.Add(CONFIG_PARAM_ATTACH_DOCS_TO_NOTIFY_EMAILS, null);
        }
        public virtual void ProcessTask(string requestId)
        {
            LazyInit();

            ValidateRequest(requestId);

            DateTime newerThan = DateTime.Now.AddDays(-_maxCheckDays);
            AppendAuditLogEvent("Querying for AQS submission transactions that are newer than {0} ...", newerThan.ToString());

            CommonTransactionStatusCode[] dontGetStatusCodes =
                new CommonTransactionStatusCode[] { CommonTransactionStatusCode.ReceivedUnprocessed };  // Get all
            IList<NodeTransaction> outstandingTransactions =
                _transactionManager.GetOutstandingNetworkTransactions(newerThan, new string[] { _dataRequestFlowName }, dontGetStatusCodes);

            if (CollectionUtils.IsNullOrEmpty(outstandingTransactions))
            {
                AppendAuditLogEvent("Did not find any AQS submission transactions that are newer than {0}.", newerThan.ToString());
                return;
            }

            CollectionUtils.ForEach(outstandingTransactions, delegate(NodeTransaction nodeTransaction)
            {
                ProcessOutstandingTransaction(nodeTransaction);
            });
        }
        protected virtual void LazyInit()
        {
            GetServiceImplementation(out _flowManager);
            GetServiceImplementation(out _serializationHelper);
            GetServiceImplementation(out _compressionHelper);
            GetServiceImplementation(out _documentManager);
            GetServiceImplementation(out _settingsProvider);
            GetServiceImplementation(out _transactionManager);
            GetServiceImplementation(out _requestManager);
            GetServiceImplementation(out _notificationManager);

            TryGetConfigParameter(CONFIG_MAX_CHECK_DAYS, ref _maxCheckDays);
            _maxCheckDays = (_maxCheckDays > MAX_MAX_CHECK_DAYS) ? MAX_MAX_CHECK_DAYS :
                ((_maxCheckDays < MIN_MAX_CHECK_DAYS) ? MIN_MAX_CHECK_DAYS : _maxCheckDays);

            string notificationEmails = null;
            if (TryGetConfigParameter(CONFIG_PARAM_NOTIFY_EMAILS, ref notificationEmails))
            {
                _notificationEmails = StringUtils.SplitAndReallyRemoveEmptyEntries(notificationEmails, ';');

                TryGetConfigParameter(CONFIG_PARAM_ATTACH_DOCS_TO_NOTIFY_EMAILS, ref _attachDocsToNotificationEmails);
            }
        }
        protected virtual void ValidateRequest(string requestId)
        {
            AppendAuditLogEvent("Loading request with id \"{0}\"", requestId);
            _dataRequest = _requestManager.GetDataRequest(requestId);

            _dataRequestFlowName = _flowManager.GetDataFlowNameById(_dataRequest.Service.FlowId);
        }
        protected virtual bool ProcessOutstandingTransaction(NodeTransaction nodeTransaction)
        {
            try
            {
                if (HasTransactionBeenProcessed(nodeTransaction))
                {
                    return false;
                }
                AppendAuditLogEvent("*** Begin processing network submission transaction \"{0}\" to {1} service \"{2}\" ...",
                                    nodeTransaction.NetworkId, nodeTransaction.NetworkFlowName, nodeTransaction.NetworkOperationName);

                AppendAuditLogEvent("Checking status of the network transaction \"{0}\" associated with the local transaction \"{1}\" ...",
                                    nodeTransaction.NetworkId, nodeTransaction.Id);

                TransactionStatus transactionStatus = _transactionManager.RefreshNetworkStatus(nodeTransaction.Id);
                CommonTransactionStatusCode currentStatus = transactionStatus.Status;

                AppendAuditLogEvent("The network transaction \"{0}\" associated with the local transaction \"{1}\" has a network status of \"{2}\" ...",
                                    nodeTransaction.NetworkId, nodeTransaction.Id, currentStatus.ToString());

                if ((currentStatus == CommonTransactionStatusCode.Completed) || (currentStatus == CommonTransactionStatusCode.Failed))
                {
                    AppendAuditLogEvent("Attempting to download documents for the network transaction \"{0}\" ...",
                                        nodeTransaction.NetworkId);

                    nodeTransaction.NetworkEndpointStatus = currentStatus;
                    _transactionManager.DownloadNetworkDocumentsAndAddToTransaction(nodeTransaction.Id, out currentStatus);

                    AppendAuditLogEvent("Any documents associated with the network transaction \"{0}\" were downloaded and saved.",
                                        nodeTransaction.NetworkId);

                    DoEmailNotifications(nodeTransaction);

                    CheckStatusComplete checkStatusComplete = new CheckStatusComplete(DateTime.Now);
                    SaveCheckStatusComplete(nodeTransaction.Id, checkStatusComplete);
                    return true;
                }
                else
                {
                    AppendAuditLogEvent("Another attempt to process the network transaction \"{0}\" will be made when the schedule runs again.",
                                        nodeTransaction.NetworkId);
                    return false;
                }
            }
            catch (Exception ex)
            {
                AppendAuditLogEvent("ERROR: Failed to process network submission transaction \"{0}\" to {1} service \"{2}\" with exception: {3}.",
                                    nodeTransaction.NetworkId, nodeTransaction.NetworkFlowName, nodeTransaction.NetworkOperationName,
                                    ExceptionUtils.GetDeepExceptionMessage(ex));
                AppendAuditLogEvent("Another attempt to process the network transaction \"{0}\" will be made when the schedule runs again.",
                                    nodeTransaction.NetworkId);
                return false;
            }
        }
        protected virtual void SaveCheckStatusComplete(string localTransactionId, CheckStatusComplete info)
        {
            if (!_documentManager.HasDocumentByName(localTransactionId, CHECK_STATUS_COMPLETE_FILE_NAME))
            {
                byte[] content = _serializationHelper.SerializeWithLineBreaks(info);
                Document saveDoc = new Document(CHECK_STATUS_COMPLETE_FILE_NAME, CommonContentType.XML, content);
                saveDoc.DontAutoCompress = true;
                _documentManager.AddDocument(localTransactionId, CommonTransactionStatusCode.Completed, string.Empty, saveDoc);
            }
        }
        protected virtual void DoEmailNotifications(NodeTransaction nodeTransaction)
        {
            if (!CollectionUtils.IsNullOrEmpty(_notificationEmails))
            {
                string tempFilePath = null;
                try
                {
                    string notificationEmails = StringUtils.Join(";", _notificationEmails);

                    AppendAuditLogEvent("Sending email notifications to {0} ...", StringUtils.JoinCommaEnglish(_notificationEmails));

                    TransactionStatus transactionStatus = new TransactionStatus();
                    transactionStatus.Id = nodeTransaction.Id;
                    transactionStatus.Status = nodeTransaction.NetworkEndpointStatus;

                    string attachmentPath = null, attachmentName = null;

                    string message = "This email is to notify you that OpenNode2 has downloaded results for a recent AQS submission.";

                    if (_attachDocsToNotificationEmails)
                    {
                        tempFilePath = _transactionManager.GetZippedTransactionDocumentsAsTempFile(nodeTransaction.Id);

                        attachmentPath = tempFilePath;
                        attachmentName = "AQS Transaction Documents.zip";
                        message += Environment.NewLine + Environment.NewLine +
                            "The attached documents were returned from the AQS system for the submission.";
                    }

                    string subject = string.Format("AQS Submission Report");

                    _notificationManager.DoScheduleNotifications(transactionStatus, notificationEmails, subject, _dataRequest.Service.Name,
                                                                 attachmentPath, attachmentName, message);

                    AppendAuditLogEvent("Sent email notifications");
                }
                catch (Exception ex)
                {
                    AppendAuditLogEvent("Failed to send email notifications: {0}", ExceptionUtils.GetDeepExceptionMessage(ex));
                }
                finally
                {
                    FileUtils.SafeDeleteFile(tempFilePath);
                }
            }
        }
        protected virtual bool HasTransactionBeenProcessed(NodeTransaction nodeTransaction)
        {
            if ((nodeTransaction.NetworkEndpointStatus == CommonTransactionStatusCode.Completed) ||
                (nodeTransaction.NetworkEndpointStatus == CommonTransactionStatusCode.Failed))
            {
                IList<string> docNames = _documentManager.GetAllDocumentNames(nodeTransaction.Id);
                return (CollectionUtils.Contains(docNames, CHECK_STATUS_COMPLETE_FILE_NAME, StringComparison.OrdinalIgnoreCase));
            }
             return false;
        }
        [Serializable]
        public class CheckStatusComplete
        {
            public CheckStatusComplete()
            {
            }
            public CheckStatusComplete(DateTime time)
            {
                CheckStatusCompleteTime = time;
            }
            public DateTime CheckStatusCompleteTime;
        }
    }
}




