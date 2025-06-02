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
//#define INCLUDE_TEST_SUBMIT_PROCESSOR

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using Windsor.Commons.Core;
using Windsor.Commons.NodeDomain;
using Windsor.Commons.Spring;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSProviders;
using Windsor.Commons.NodeClient;
using System.IO;
using Windsor.Commons.XsdOrm2;
using Spring.Data.Common;
using System.Runtime.Serialization;

namespace Windsor.Node2008.WNOSPlugin.ICISNPDES_514
{
    [Serializable]
#if INCLUDE_TEST_SUBMIT_PROCESSOR
    public class GetICISStatusAndProcessReports : BaseWNOSPlugin, ITaskProcessor, ISubmitProcessor
#else // INCLUDE_TEST_SUBMIT_PROCESSOR
    public class GetICISStatusAndProcessReports : BaseWNOSPlugin, ITaskProcessor
#endif // INCLUDE_TEST_SUBMIT_PROCESSOR
    {
        protected const string CONFIG_PARAM_STORED_PROC_NAME = "Postprocessing Procedure Name";
        protected const string CONFIG_PARAM_STORED_PROC_TIMEOUT = "Postprocessing Procedure Execute Timeout (in seconds)";
        protected const string CONFIG_PARAM_NOTIFY_EMAILS = "Notification Emails (semicolon separated)";

        protected const string DATA_PARAM_DESTINATION = "Data Destination";

        protected IRequestManager _requestManager;
        protected IFlowManager _flowManager;
        protected ICompressionHelper _compressionHelper;
        protected ISettingsProvider _settingsProvider;
        protected INodeEndpointClientFactory _nodeEndpointClientFactory;
        protected ITransactionManager _transactionManager;
        protected ISerializationHelper _serializationHelper;
        protected IDocumentManager _documentManager;
        protected IObjectsToDatabase _objectsToDatabase;
        protected INotificationManager _notificationManager;

        protected string _storedProcName;
        protected int _storedProcTimeout = 300;
        protected SpringBaseDao _baseDao;
        protected IList<string> _notificationEmails;

        protected DataRequest _dataRequest;

        protected string _submissionTrackingDataTypePK;
        protected SubmissionTrackingDataType _submissionTrackingDataType;

        protected const string p_transaction_id_param_name = "p_transaction_id";

        public GetICISStatusAndProcessReports()
        {
            ConfigurationArguments[CONFIG_PARAM_STORED_PROC_NAME] = null;
            ConfigurationArguments[CONFIG_PARAM_STORED_PROC_TIMEOUT] = null;
            ConfigurationArguments[CONFIG_PARAM_NOTIFY_EMAILS] = null;

            DataProviders[DATA_PARAM_DESTINATION] = null;
        }
        // TSM: The following method is for testing purposes only, to enable, have this class implement ISubmitProcessor above
        public virtual void ProcessSubmit(string transactionId)
        {
            LazyInit();

            IList<string> docNames = _documentManager.GetAllDocumentNames(transactionId);

            _submissionTrackingDataType = new SubmissionTrackingDataType();
            _submissionTrackingDataType.SubmissionTransactionId = transactionId;
            _submissionTrackingDataTypePK = Guid.NewGuid().ToString();

            Windsor.Node2008.WNOSDomain.Document zipResponseFile;
            DoProcessResponseDocuments(transactionId, docNames, out zipResponseFile);
        }
        public virtual void ProcessTaskInit(string requestId)
        {
            LazyInit();

            ValidateRequest(requestId);
        }
        public virtual void ProcessTask(string requestId)
        {
            ProcessTaskInit(requestId);

            _submissionTrackingDataType = SubmissionTrackingTableHelper.GetActiveSubmissionTrackingElement(_baseDao, out _submissionTrackingDataTypePK);
            if (_submissionTrackingDataType == null)
            {
                AppendAuditLogEvent("There are no pending submissions in the submission tracking table, existing plugin ...");
                return;
            }
            DebugUtils.AssertDebuggerBreak(_submissionTrackingDataTypePK != null);
            if (!_submissionTrackingDataType.SubmissionDateTimeSpecified)
            {
                AppendAuditLogEvent("There is a pending row in the submission tracking table, \"{0},\" but it does not have a submission date/time yet, existing plugin ...",
                                    _submissionTrackingDataTypePK);
                return;
            }
            try
            {
                if (string.IsNullOrEmpty(_submissionTrackingDataType.SubmissionTransactionId))
                {
                    throw new ArgumentException("There is a pending row in the submission tracking table, \"{0},\" with a submission date/time, but the submission transaction id is missing",
                                                _submissionTrackingDataTypePK);
                }

                // Attempt to get status of the active submission and download the response documents
                IList<string> documentNames;
                string localTransactionId;

                if (!DoGetStatusAndDownloadDocuments(out localTransactionId, out documentNames))
                {
                    return;
                }

                Windsor.Node2008.WNOSDomain.Document zipResponseFile;
                if (!DoProcessResponseDocuments(localTransactionId, documentNames, out zipResponseFile))
                {
                    return;
                }

                _submissionTrackingDataType.WorkflowStatus = TransactionStatusCode.Completed;
                _submissionTrackingDataType.WorkflowStatusMessage = string.Format("Successfully downloaded response data and inserted into database");
                SubmissionTrackingTableHelper.Update(_baseDao, _submissionTrackingDataTypePK, _submissionTrackingDataType);

                DoEmailNotifications(zipResponseFile, localTransactionId);
            }
            catch (WorkflowStatusFailedException workflowStatusFailedException)
            {
                string errorMessage =
                    string.Format("An error occurred during processing: {0}",
                                  ExceptionUtils.GetDeepExceptionMessage(workflowStatusFailedException));
                if (_submissionTrackingDataTypePK != null)
                {
                    _submissionTrackingDataType.WorkflowStatus = TransactionStatusCode.Failed;
                    _submissionTrackingDataType.WorkflowStatusMessage = errorMessage;
                    SubmissionTrackingTableHelper.Update(_baseDao, _submissionTrackingDataTypePK, _submissionTrackingDataType);
                }
                throw new ArgException(errorMessage);
            }
            catch (Exception)
            {
                // Continue on, do not set workflow status to failed, per Bill
                throw;
            }
        }
        protected virtual bool DoProcessResponseDocuments(string localTransactionId, IList<string> documentNames, out Windsor.Node2008.WNOSDomain.Document zipResponseFile)
        {
            AppendAuditLogEvent("Attempting to process response documents for ICIS submission with transaction id \"{0}\"", _submissionTrackingDataType.SubmissionTransactionId);

            string responseZipFileName = FindResponseZipFileName(documentNames);

            AppendAuditLogEvent("Extracting response document content ...");

            //zipResponseFile = new Windsor.Node2008.WNOSDomain.Document()
            //{
            //    Content = File.ReadAllBytes(@"D:\PROJECTS\opennode2-dotnet-git\prod-opennode2-net\BUILD\Repository\_c570b73f-c854-412f-923d-889b8d11c25e\_92891d4a-cbc4-4bd2-9647-a58fe8170f19.windsor"),
            //};
            zipResponseFile = _documentManager.GetDocumentByName(localTransactionId, responseZipFileName, true);

            string tempFolder = _settingsProvider.CreateNewTempFolderPath();
            _compressionHelper.UncompressDirectory(zipResponseFile.Content, tempFolder);

            string[] responseFiles = Directory.GetFiles(tempFolder);

            string responseAcceptedFilePath = FindResponseAcceptedFilePath(responseFiles);
            string responseRejectedFilePath = FindResponseRejectedFilePath(responseFiles);

            AppendAuditLogEvent("Loading response document content ...");

            AppendAuditLogEvent("Transforming accepted response file ...");
            string responseAcceptedTransformedFilePath = TransformResponseFile50(responseAcceptedFilePath);
            SubmissionResultList acceptedList = _serializationHelper.Deserialize<SubmissionResultList>(responseAcceptedTransformedFilePath);
#if INCLUDE_TEST_SUBMIT_PROCESSOR
            if (DebugUtils.IsDebugging)
            {
                foreach (var submissionResultsDataType in acceptedList.SubmissionResult)
                {
                    if (string.IsNullOrEmpty(submissionResultsDataType.SubmissionTransactionId))
                    {
                        throw new ArgException("submissionResultsDataType.SubmissionTransactionId is null");
                    }
                }
            }
#endif // INCLUDE_TEST_SUBMIT_PROCESSOR

            AppendAuditLogEvent("Transforming rejected response file ...");
            string responseRejectedTransformedFilePath = TransformResponseFile50(responseRejectedFilePath);
            SubmissionResultList rejectedList = _serializationHelper.Deserialize<SubmissionResultList>(responseRejectedTransformedFilePath);
#if INCLUDE_TEST_SUBMIT_PROCESSOR
            if (DebugUtils.IsDebugging)
            {
                foreach (var submissionResultsDataType in rejectedList.SubmissionResult)
                {
                    if (string.IsNullOrEmpty(submissionResultsDataType.SubmissionTransactionId))
                    {
                        throw new ArgException("submissionResultsDataType.SubmissionTransactionId is null");
                    }
                }
            }
#endif // INCLUDE_TEST_SUBMIT_PROCESSOR

            List<SubmissionResultsDataType> saveList = new List<SubmissionResultsDataType>(CollectionUtils.Count(acceptedList.SubmissionResult) +
                                                                                           CollectionUtils.Count(rejectedList.SubmissionResult));

            DateTime now = DateTime.Now;
            CollectionUtils.ForEach(acceptedList.SubmissionResult, delegate(SubmissionResultsDataType result)
            {
                //DebugUtils.AssertDebuggerBreak(result.SubmissionTransactionId == _submissionTrackingDataType.SubmissionTransactionId);
                result.CreatedDateTime = now;
                saveList.Add(result);
            });
            CollectionUtils.ForEach(rejectedList.SubmissionResult, delegate(SubmissionResultsDataType result)
            {
                //DebugUtils.AssertDebuggerBreak(result.SubmissionTransactionId == _submissionTrackingDataType.SubmissionTransactionId);
                //if (String.IsNullOrEmpty(result.SubmissionTransactionId))
                //{
                    
                //}
                result.CreatedDateTime = now;
                saveList.Add(result);
            });


            _baseDao.TransactionTemplate.Execute(delegate(Spring.Transaction.ITransactionStatus status)
            {
                try
                {
                    AppendAuditLogEvent("Saving response data to database ...");
                    Type mappingAttributesType = typeof(Windsor.Node2008.WNOSPlugin.ICISNPDES_514.MappingAttributes);

                    Dictionary<string, int> tableRowCounts = _objectsToDatabase.SaveToDatabase(saveList, _baseDao, false, mappingAttributesType);

                    AppendAuditLogEvent("Response data saved to database with the following insert row counts: {0}", CreateTableRowCountsString(tableRowCounts));
                }
                catch (Exception ex1)
                {
                    AppendAuditLogEvent("Failed to save response data to database, rolling back transaction: {0}", ExceptionUtils.GetDeepExceptionMessage(ex1));
                    throw;
                }

                ExecuteStoredProc();

                return null;
            });

            return true;
        }
        protected virtual string TransformResponseFile50(string responseFilePath)
        {
            return TransformXmlFile(responseFilePath, "xml_schema.MappingMapToSubmissionResults50.zip", "MappingMapToSubmissionResults.xslt");
        }
        protected virtual void DoEmailNotifications(Windsor.Node2008.WNOSDomain.Document zipResponseDocument, string localTransactionId)
        {
            if (!CollectionUtils.IsNullOrEmpty(_notificationEmails))
            {
                string tempFilePath = null;
                try
                {
                    string notificationEmails = StringUtils.Join(",", _notificationEmails);

                    AppendAuditLogEvent("Sending email notifications to {0} ...", StringUtils.JoinCommaEnglish(_notificationEmails));

                    TransactionStatus transactionStatus = new TransactionStatus();
                    transactionStatus.Id = localTransactionId;
                    transactionStatus.Status = CommonTransactionStatusCode.Completed;

                    tempFilePath = _settingsProvider.NewTempFilePath();
                    File.WriteAllBytes(tempFilePath, zipResponseDocument.Content);

                    string attachmentPath = tempFilePath;
                    string attachmentName = zipResponseDocument.DocumentName;

                    string subject = string.Format("ICIS-NPDES Submission Processing Report");
                    string message =
                        string.Format("This email is to notify you that OpenNode2 has received and successfully processed submission results data from ICIS-NPDES.{0}{0}" +
                                      "The attached documents were returned from ICIS-NPDES in connection with the most recent submission.", Environment.NewLine);

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
        protected virtual bool DoGetStatusAndDownloadDocuments(out string localTransactionId, out IList<string> documentNames)
        {
            documentNames = null;
            localTransactionId = null;

            AppendAuditLogEvent("Checking status of the ICIS submission with transaction id \"{0}\"", _submissionTrackingDataType.SubmissionTransactionId);

            CommonTransactionStatusCode statusCode = UpdateStatusOfNetworkTransaction(_submissionTrackingDataType.SubmissionTransactionId,
                                                                                      out localTransactionId);

            _submissionTrackingDataType.SubmissionStatusDateTimeSpecified = true;
            _submissionTrackingDataType.SubmissionStatusDateTime = DateTime.Now;
            _submissionTrackingDataType.SubmissionTransactionStatusSpecified = true;
            _submissionTrackingDataType.SubmissionTransactionStatus = EnumUtils.ParseEnum<TransactionStatusCode>(statusCode.ToString());

            if (statusCode == CommonTransactionStatusCode.Failed)
            {
                _submissionTrackingDataType.WorkflowStatus = TransactionStatusCode.Failed;
            }
            else
            {
                _submissionTrackingDataType.WorkflowStatus = TransactionStatusCode.Pending;
            }

            SubmissionTrackingTableHelper.Update(_baseDao, _submissionTrackingDataTypePK, _submissionTrackingDataType);

            if ((statusCode != CommonTransactionStatusCode.Completed) && (statusCode != CommonTransactionStatusCode.Failed))
            {
                AppendAuditLogEvent("Another attempt to process the ICIS submission with transaction id \"{0}\" will be made when the service runs again.",
                                    _submissionTrackingDataType.SubmissionTransactionId);
                return false;
            }
            else if (statusCode == CommonTransactionStatusCode.Failed)
            {
                return false;
            }

            AppendAuditLogEvent("Attempting to download response documents for ICIS submission with transaction id \"{0}\"",
                                 _submissionTrackingDataType.SubmissionTransactionId);

            try
            {
                _transactionManager.DownloadNetworkDocumentsAndAddToTransaction(localTransactionId, out statusCode);
            }
            catch (Exception ex)
            {
                AppendAuditLogEvent("Failed to download response documents for ICIS submission with transaction id \"{0}\" with error: {1}",
                                     _submissionTrackingDataType.SubmissionTransactionId, ExceptionUtils.GetDeepExceptionMessage(ex));
                AppendAuditLogEvent("Another attempt to process the ICIS submission with transaction id \"{0}\" will be made when the service runs again.",
                                    _submissionTrackingDataType.SubmissionTransactionId);
                return false;
            }

            documentNames = _documentManager.GetAllDocumentNames(localTransactionId);

            return true;
        }
        protected virtual void ExecuteStoredProc()
        {
            if (string.IsNullOrEmpty(_storedProcName))
            {
                AppendAuditLogEvent("A value for \"{0}\" was not specified", CONFIG_PARAM_STORED_PROC_NAME);
                return;
            }

            AppendAuditLogEvent("Executing the stored procedure \"{0}\" ...", _storedProcName);

            IDbParameters parameters = _baseDao.AdoTemplate.CreateDbParameters();
            parameters.AddWithValue(p_transaction_id_param_name, _submissionTrackingDataType.SubmissionTransactionId);

            _baseDao.AdoTemplate.Execute<int>(delegate(DbCommand command)
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = _storedProcName;
                command.CommandTimeout = _storedProcTimeout;
                Spring.Data.Support.ParameterUtils.CopyParameters(command, parameters);

                try
                {
                    SpringBaseDao.ExecuteCommandWithTimeout(command, _storedProcTimeout, delegate(DbCommand commandToExecute)
                    {
                        commandToExecute.ExecuteNonQuery();
                    });

                    _submissionTrackingDataType.ResponseParseDateTime = DateTime.Now;
                    _submissionTrackingDataType.ResponseParseDateTimeSpecified = true;

                    AppendAuditLogEvent("The stored procedure executed successfully");
                }
                catch (Exception ex2)
                {
                    AppendAuditLogEvent("An error was returned from the stored procedure: {0}", ExceptionUtils.GetDeepExceptionMessage(ex2));
                    throw;
                }

                return 0;
            });
        }
        protected virtual void LazyInit()
        {
            GetServiceImplementation(out _requestManager);
            GetServiceImplementation(out _flowManager);
            GetServiceImplementation(out _serializationHelper);
            GetServiceImplementation(out _compressionHelper);
            GetServiceImplementation(out _documentManager);
            GetServiceImplementation(out _settingsProvider);
            GetServiceImplementation(out _nodeEndpointClientFactory);
            GetServiceImplementation(out _transactionManager);
            GetServiceImplementation(out _objectsToDatabase);
            GetServiceImplementation(out _notificationManager);

            _baseDao = ValidateDBProvider(DATA_PARAM_DESTINATION, typeof(NamedNullMappingDataReader));
            TryGetConfigParameter(CONFIG_PARAM_STORED_PROC_NAME, ref _storedProcName);
            TryGetConfigParameter(CONFIG_PARAM_STORED_PROC_TIMEOUT, ref _storedProcTimeout);
            string notificationEmails = null;
            if (TryGetConfigParameter(CONFIG_PARAM_NOTIFY_EMAILS, ref notificationEmails))
            {
                _notificationEmails = StringUtils.SplitAndReallyRemoveEmptyEntries(notificationEmails, ';');
            }
        }
        protected virtual void ValidateRequest(string requestId)
        {
            AppendAuditLogEvent("Loading request with id \"{0}\"", requestId);
            _dataRequest = _requestManager.GetDataRequest(requestId);
        }
        protected virtual string FindResponseZipFileName(IList<string> documentNames)
        {
            string responseFileName = null;
            CollectionUtils.ForEachBreak(documentNames, delegate(string fileName)
            {
                if (fileName.EndsWith("_Response.zip", StringComparison.OrdinalIgnoreCase))
                {
                    if (responseFileName != null)
                    {
                        AppendAuditLogEvent("Warning: more than one response document was found for the submission transaction ...");
                        return false;
                    }
                    responseFileName = fileName;
                }
                return true;
            });
            if (responseFileName == null)
            {
                throw new WorkflowStatusFailedException("A response document was not found for the submission transaction");
            }
            return responseFileName;
        }
        protected virtual string FindResponseAcceptedFilePath(IList<string> filePaths)
        {
            string responseFilePath = null;
            CollectionUtils.ForEachBreak(filePaths, delegate(string filePath)
            {
                if (filePath.EndsWith("Accepted_Response.xml", StringComparison.OrdinalIgnoreCase))
                {
                    if (responseFilePath != null)
                    {
                        AppendAuditLogEvent("Warning: more than one accepted response document was found for the submission transaction ...");
                        return false;
                    }
                    responseFilePath = filePath;
                }
                return true;
            });
            if (responseFilePath == null)
            {
                throw new ArgException("An accepted response document was not found for the submission transaction");
            }
            return responseFilePath;
        }
        protected virtual string FindResponseRejectedFilePath(IList<string> filePaths)
        {
            string responseFilePath = null;
            CollectionUtils.ForEachBreak(filePaths, delegate(string filePath)
            {
                if (filePath.EndsWith("Rejected_Response.xml", StringComparison.OrdinalIgnoreCase))
                {
                    if (responseFilePath != null)
                    {
                        AppendAuditLogEvent("Warning: more than one rejected response document was found for the submission transaction ...");
                        return false;
                    }
                    responseFilePath = filePath;
                }
                return true;
            });
            if (responseFilePath == null)
            {
                throw new ArgException("A rejected response document was not found for the submission transaction");
            }
            return responseFilePath;
        }
        private string CreateTableRowCountsString(Dictionary<string, int> tableRowCounts)
        {
            if (CollectionUtils.IsNullOrEmpty(tableRowCounts))
            {
                return "None";
            }
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, int> pair in tableRowCounts)
            {
                if (sb.Length > 0)
                {
                    sb.Append(", ");
                }
                sb.AppendFormat("{0} ({1})", pair.Key, pair.Value.ToString());
            }
            return sb.ToString();
        }
    }

    /// <summary>
    /// An exception that, if thrown, indicates the workflow status should be set to failed.
    /// </summary>
    [Serializable]
    public class WorkflowStatusFailedException : ArgException
    {
        public WorkflowStatusFailedException(string format, params object[] args) :
            base(string.Format(format, args))
        {
            DebugUtils.CheckDebuggerBreak();
        }
        public WorkflowStatusFailedException(Exception innerException, string format, params object[] args) :
            base(string.Format(format, args), innerException)
        {
            DebugUtils.CheckDebuggerBreak();
        }
        protected WorkflowStatusFailedException(SerializationInfo info, StreamingContext context) :
            base(info, context)
        {
        }
    }
}