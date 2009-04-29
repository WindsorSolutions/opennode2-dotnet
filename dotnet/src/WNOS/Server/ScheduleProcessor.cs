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
using System.ComponentModel;
using System.Reflection;
using System.IO;
using System.Xml;

using Windsor.Node2008.WNOS.Logic;
using Windsor.Node2008.WNOSUtility;
using Windsor.Node2008.WNOSConnector.Provider;
using Windsor.Node2008.WNOSConnector.Logic;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSPlugin;
using Spring.Transaction.Support;
using Windsor.Node2008.WNOSProviders;
using Windsor.Node2008.WNOSConnector.Server;
using Windsor.Node2008.Client2;
using Windsor.Node2008.WNOS.Utilities;
using Windsor.Commons.Core;

namespace Windsor.Node2008.WNOS.Server
{
    public class ScheduleProcessor : BaseNodeProcessor
    {
        private IRequestManagerEx _requestManager;
        private IDocumentManagerEx _documentManager;
        private IScheduleManager _scheduleManager;
        private IAccountManagerEx _accountManager;
        private ITransactionManagerEx _transactionManager;
        private IServiceManager _serviceManager;
        private IFlowManagerEx _flowManager;
        private ISchematronHelper _schematronHelper;
        private INotificationManager _notificationManager;
        private ICompressionHelper _compressionHelper;
        private IPartnerManager _partnerManager;
        private INodeEndpointClientFactory _nodeEndpointClientFactory;

        #region Init

        new public void Init()
        {
            base.Init();

            FieldNotInitializedException.ThrowIfNull(this, ref _requestManager);
            FieldNotInitializedException.ThrowIfNull(this, ref _documentManager);
            FieldNotInitializedException.ThrowIfNull(this, ref _scheduleManager);
            FieldNotInitializedException.ThrowIfNull(this, ref _accountManager);
            FieldNotInitializedException.ThrowIfNull(this, ref _transactionManager);
            FieldNotInitializedException.ThrowIfNull(this, ref _serviceManager);
            FieldNotInitializedException.ThrowIfNull(this, ref _notificationManager);
            FieldNotInitializedException.ThrowIfNull(this, ref _partnerManager);
            FieldNotInitializedException.ThrowIfNull(this, ref _compressionHelper);
            FieldNotInitializedException.ThrowIfNull(this, ref _schematronHelper);
            FieldNotInitializedException.ThrowIfNull(this, ref _nodeEndpointClientFactory);
        }

        #endregion

        public ScheduleProcessor()
        {
        }

        protected override void DoProcessing()
        {
            try
            {
                IList<string> scheduledItems = _scheduleManager.GetNextScheduledItemsToProcess();
                if (!CollectionUtils.IsNullOrEmpty(scheduledItems))
                {
                    LOG.Debug("Got {0} scheduled items to run", scheduledItems.Count.ToString());
                    List<IBlockingQueueServerWorker> workers = new List<IBlockingQueueServerWorker>();
                    foreach (string scheduledItemId in scheduledItems)
                    {
                        LOG.Debug("Queued {0} scheduled item", scheduledItemId.ToString());
                        workers.Add(new ScheduledItemProcessor(scheduledItemId, this));
                    }
                    // Enqueue the workers to process the documents in each transaction
                    ThreadQueueServer.Enqueue(workers);
                }
            }
            catch (Exception e)
            {
                LOG.Error("DoProcessing() threw an exception.", e);
            }
        }

        protected virtual void ProcessScheduledItem(string scheduleId)
        {
            using (INodeProcessorMutex mutex = GetMutex(scheduleId))
            {
                if (!mutex.IsAcquired)
                {
                    LOG.Debug("Exiting ProcessScheduleItem(), could not acquire mutex");
                    return;	// Another thread is already working on this transaction, get out of here
                }
                bool isRunNow;
                ScheduledItem scheduledItem = ScheduleManager.GetScheduledItem(scheduleId, out isRunNow);
                DateTime startTime = DateTime.Now;
                // Make sure the transaction has not been processed yet
                if ((scheduledItem.NextRunOn > startTime) && !isRunNow)
                {
                    LOG.Debug("Exiting ProcessScheduledItem(), schedule {0} has already run",
                              scheduledItem);
                    return;
                }

                string flowName = _flowManager.GetDataFlowNameById(scheduledItem.FlowId);
                Activity activity = new Activity(NodeMethod.Schedule, flowName, scheduledItem.Name, ActivityType.Info, 
                                                 null, NetworkUtils.GetLocalIp(), "Start processing schedule: \"{0}\"", 
                                                 scheduledItem.Name);
                string transactionId = null;
                try
                {
                    // Make sure the user that created the schedule is still active
                    UserAccount userAccount = _accountManager.GetById(scheduledItem.ModifiedById);
                    if ((userAccount == null) || !userAccount.IsActive)
                    {
                        activity.AppendFormat("The user account that created the scheduled item \"{0}\" is no longer active.  Scheduled item cannot execute.",
                                              scheduledItem.Name);
                        return;
                    }
                    activity.ModifiedById = userAccount.Id;

                    scheduledItem.ExecuteStatus = ScheduleExecuteStatus.Running;
                    ScheduleManager.UpdateScheduleStatus(scheduledItem.Id, scheduledItem.ExecuteStatus);

                    transactionId =
                        _transactionManager.CreateTransaction(NodeMethod.Schedule, EndpointVersionType.Undefined,
                                                             scheduledItem.FlowId, string.Empty, userAccount.Id,
                                                             CommonTransactionStatusCode.Processing,
                                                             null, null, null, false);
                    activity.TransactionId = transactionId;

                    switch (scheduledItem.SourceType)
                    {
                        case ScheduledItemSourceType.LocalService:
                            ProcessLocalServiceSource(scheduledItem, activity, transactionId);
                            break;
                        case ScheduledItemSourceType.File:
                            ProcessFileSource(scheduledItem, activity, transactionId);
                            break;
                        case ScheduledItemSourceType.WebServiceQuery:
                            ProcessWebServiceQuerySource(scheduledItem, activity, transactionId);
                            break;
                        case ScheduledItemSourceType.WebServiceSolicit:
                            ProcessWebServiceSolicitSource(scheduledItem, activity, transactionId);
                            break;
                        default:
                            throw new ArgumentException(string.Format("Unrecognized scheduledItem.SourceType: {0}",
                                                                      scheduledItem.SourceType));
                    }

                    TransactionStatus transactionStatus = null;
                    if (scheduledItem.TargetType != ScheduledItemTargetType.None)
                    {
                        transactionStatus =
                            _transactionManager.SetTransactionStatus(transactionId, CommonTransactionStatusCode.Processed,
                                                                    null, false);
                        switch (scheduledItem.TargetType)
                        {
                            case ScheduledItemTargetType.Email:
                                ProcessEmailTarget(transactionStatus, scheduledItem, activity);
                                break;
                            case ScheduledItemTargetType.File:
                                ProcessFileTarget(transactionStatus, scheduledItem, activity);
                                break;
                            case ScheduledItemTargetType.Partner:
                                ProcessPartnerTarget(transactionStatus, scheduledItem, activity);
                                break;
                            case ScheduledItemTargetType.Schematron:
                                ProcessSchematronTarget(transactionStatus, scheduledItem, activity);
                                break;
                            default:
                                throw new ArgumentException(string.Format("Unrecognized scheduledItem.TargetType: {0}",
                                                                          scheduledItem.TargetType));
                        }
                    }

                    transactionStatus =
                        _transactionManager.SetTransactionStatus(transactionId, CommonTransactionStatusCode.Completed,
                                                                null, true);

                    activity.AppendFormat("End processing schedule: \"{0}\", processing duration: {1}",
                                          scheduledItem.Name, TimeSpan.FromTicks(DateTime.Now.Ticks - startTime.Ticks).ToString());
                    activity.AppendFormat("Transaction \"{0}\" status set to \"{1}\"", transactionStatus.Id.ToString(),
                                          transactionStatus.Status.ToString());
                    _notificationManager.DoScheduleNotifications(transactionStatus, scheduledItem.FlowId,
                                                                 scheduledItem.Name);
                    scheduledItem.ExecuteStatus = ScheduleExecuteStatus.CompletedSuccess;
                }
                catch (Exception e)
                {
                    if (transactionId != null)
                    {
                        TransactionStatus transactionStatus =
                            _transactionManager.SetTransactionStatus(transactionId, CommonTransactionStatusCode.Failed,
                                                                     e.Message, true);
                        activity.AppendFormat("Transaction \"{0}\" status set to \"{1}\"", transactionStatus.Id.ToString(),
                                              transactionStatus.Status.ToString());
                    }
                    activity.Append(ExceptionUtils.ToShortString(e));
                    activity.Type = ActivityType.Error;
                    LOG.Error("ProcessTransactionRequest() threw an exception.", e);
                    scheduledItem.ExecuteStatus = ScheduleExecuteStatus.CompletedFailure;
                }
                finally
                {
                    ActivityManager.Log(activity);
                    UpdateScheduleRunInfo(scheduledItem, activity);
                }
            }
        }
        protected virtual void UpdateScheduleRunInfo(ScheduledItem scheduledItem, Activity activity)
        {
            if (scheduledItem != null)
            {
                try
                {
                    scheduledItem.LastExecutedOn = DateTime.Now;
                    scheduledItem.LastExecuteActivityId = activity.Id;
                    scheduledItem.NextRunOn =
                        ScheduledItem.CalcNextRunTime(scheduledItem.NextRunOn, scheduledItem.FrequencyType,
                                                      scheduledItem.Frequency, true);
                    scheduledItem = ScheduleManager.Update(scheduledItem, false);
                }
                catch (Exception e)
                {
                    LOG.Error("Error in UpdateScheduleRunInfo().", e);
                }
            }
        }

        protected virtual void ProcessLocalServiceSource(ScheduledItem scheduledItem, Activity activity,
                                                         string transactionId)
        {
            DataService dataService = 
                ServiceManager.ValidateDataService(scheduledItem.SourceId, ServiceType.QueryOrSolicitOrExecuteOrTask);

            // Load the service plugin
            ISolicitProcessor solicitPlugin = null;
            IQueryProcessor queryPlugin = null;
            IExecuteProcessor executePlugin = null;
            ITaskProcessor taskPlugin = null;
            IPluginDisposer disposer;
            string flowName = FlowManager.GetDataFlowNameById(dataService.FlowId);
            RequestType requestType;
            try
            {
                if ((dataService.Type & ServiceType.Task) == ServiceType.Task)
                {
                    disposer = PluginLoader.LoadTaskProcessor(dataService, out taskPlugin);
                    requestType = RequestType.Task;
                }
                else if ((dataService.Type & ServiceType.Execute) == ServiceType.Execute)
                {
                    disposer = PluginLoader.LoadExecuteProcessor(dataService, out executePlugin);
                    requestType = RequestType.Execute;
                }
                else if ((dataService.Type & ServiceType.Solicit) == ServiceType.Solicit)
                {
                    disposer = PluginLoader.LoadSolicitProcessor(dataService, out solicitPlugin);
                    requestType = RequestType.Solicit;
                }
                else
                {
                    disposer = PluginLoader.LoadQueryProcessor(dataService, out queryPlugin);
                    requestType = RequestType.Query;
                }
            }
            catch (Exception e)
            {
                throw new NotImplementedException(string.Format("Failed to load the service \"{0}\" for the scheduled item \"{1}\"",
                                                                dataService.Name, scheduledItem.Name), e);
            }
            using (disposer)
            {
                string requestId =
                    RequestManager.CreateDataRequest(transactionId, dataService.Id, 0, -1,
                                                     requestType, activity.ModifiedById,
                                                     scheduledItem.SourceArgs);

                if (taskPlugin != null)
                {
                    activity.Append("Calling ProcessTask()");
                    try
                    {
                        taskPlugin.ProcessTask(requestId);
                    }
                    finally
                    {
                        activity.Append(taskPlugin.GetAuditLogEvents());
                    }
                    activity.Append("Called ProcessTask()");
                }
                else if (executePlugin != null)
                {
                    activity.Append("Calling ProcessExecute()");
                    ExecuteContentResult result;
                    try
                    {
                        result = executePlugin.ProcessExecute(requestId);
                    }
                    finally
                    {
                        activity.Append(executePlugin.GetAuditLogEvents());
                    }
                    if (result.Content != null)
                    {
                        _documentManager.AddDocument(transactionId, result);
                    }
                    activity.Append("Called ProcessExecute()");
                }
                else if (solicitPlugin != null)
                {
                    activity.Append("Calling ProcessSolicit()");
                    try
                    {
                        solicitPlugin.ProcessSolicit(requestId);
                    }
                    finally
                    {
                        activity.Append(solicitPlugin.GetAuditLogEvents());
                    }
                    activity.Append("Called ProcessSolicit()");
                }
                else
                {
                    activity.Append("Calling ProcessQuery()");
                    PaginatedContentResult result;
                    try
                    {
                        result = queryPlugin.ProcessQuery(requestId);
                    }
                    finally
                    {
                        activity.Append(queryPlugin.GetAuditLogEvents());
                    }
                    activity.Append("Called ProcessQuery()");
                }
            }
        }
        protected virtual void ProcessFileSource(ScheduledItem scheduledItem, Activity activity,
                                                 string transactionId)
        {
            if (!File.Exists(scheduledItem.SourceId))
            {
                throw new FileNotFoundException(string.Format("Could not find source file \"{0}\"",
                                                              scheduledItem.SourceId));
            }

            DocumentManager.AddDocument(transactionId, CommonTransactionStatusCode.Processed,
                                        null, scheduledItem.SourceId);
            activity.Append(string.Format("Added document \"{0}\" to transaction.",
                            scheduledItem.SourceId));
        }
        protected virtual void ProcessWebServiceQuerySource(ScheduledItem scheduledItem, Activity activity,
                                                            string transactionId)
        {
            PartnerIdentity partner = _partnerManager.GetById(scheduledItem.SourceId);
            if (partner == null)
            {
                throw new ArgumentException(string.Format("Invalid partner id \"{0}.\"  Could not find partner for scheduled item \"{1}\".",
                                                          scheduledItem.TargetId, scheduledItem.Name));
            }

            string filePath = Path.Combine(SettingsProvider.TempFolderPath, GetResultFileName(scheduledItem));

            using (INodeEndpointClient client = GetNodeClient(partner))
            {
                CommonContentType type;
                if (client.Version == EndpointVersionType.EN11)
                {
                    type = client.Query(null, scheduledItem.SourceRequest, scheduledItem.SourceArgs,
                                        0, -1, filePath);
                }
                else
                {
                    type = client.Query(scheduledItem.SourceFlow, scheduledItem.SourceRequest,
                                        scheduledItem.SourceArgs, 0, -1, filePath);
                }
                filePath = FileUtils.ChangeFileExtension(filePath, CommonContentAndFormatProvider.GetFileExtension(type));
                DocumentManager.AddDocument(transactionId, CommonTransactionStatusCode.Processed, null, filePath);
            }
            activity.Append(string.Format("Performed Query of partner \"{0}\" at url \"{1}\"",
                                          partner.Name, partner.Url));
        }
        protected virtual void ProcessWebServiceSolicitSource(ScheduledItem scheduledItem, Activity activity,
                                                              string transactionId)
        {
            PartnerIdentity partner = _partnerManager.GetById(scheduledItem.SourceId);
            if (partner == null)
            {
                throw new ArgumentException(string.Format("Invalid partner id \"{0}.\"  Could not find partner for scheduled item \"{1}\".",
                                                          scheduledItem.TargetId, scheduledItem.Name));
            }

            string filePath = Path.Combine(SettingsProvider.TempFolderPath, GetResultFileName(scheduledItem));

            string networkTransactionId;
            EndpointVersionType endpointVersion;
            string endpointUrl;
            using (INodeEndpointClient client = GetNodeClient(partner))
            {
                if (client.Version == EndpointVersionType.EN11)
                {

                    networkTransactionId = client.Solicit(null, scheduledItem.SourceRequest, scheduledItem.SourceArgs,
                                                          new string[] { SettingsProvider.Endpoint11Url });
                }
                else
                {
                    networkTransactionId = client.Solicit(scheduledItem.SourceFlow, scheduledItem.SourceRequest,
                                                          scheduledItem.SourceArgs,
                                                          new string[] { SettingsProvider.Endpoint20Url });
                }
                endpointVersion = client.Version;
                endpointUrl = client.Url;
            }
            activity.Append(string.Format("Performed Solicit of partner \"{0}\" at url \"{1}\" with returned transaction id \"{2}\"",
                                          partner.Name, partner.Url, networkTransactionId));
            _transactionManager.SetNetworkId(transactionId, networkTransactionId,
                                             endpointVersion, endpointUrl);
        }
        protected virtual void ProcessPartnerTarget(TransactionStatus transactionStatus,
                                                    ScheduledItem scheduledItem,
                                                    Activity activity)
        {
            PartnerIdentity partner = _partnerManager.GetById(scheduledItem.TargetId);
            if (partner == null)
            {
                throw new ArgumentException(string.Format("Invalid partner id \"{0}.\"  Could not find partner for scheduled item \"{1}\".",
                                                          scheduledItem.TargetId, scheduledItem.Name));
            }

            string filePath = GetZippedTransactionDocumentsAsTempFile(transactionStatus, scheduledItem);
            if (filePath != null)
            {
                string transactionId;
                EndpointVersionType endpointVersion;
                string endpointUrl;
                using (INodeEndpointClient client = GetNodeClient(partner))
                {
                    if (client.Version == EndpointVersionType.EN11)
                    {
                        transactionId = client.Submit(scheduledItem.TargetFlow, string.Empty, new string[] { filePath });
                    }
                    else
                    {
                        transactionId = client.Submit(scheduledItem.TargetFlow, scheduledItem.TargetRequest,
                                                      string.Empty, new string[] { filePath });
                    }
                    endpointVersion = client.Version;
                    endpointUrl = client.Url;
                }
                activity.Append(string.Format("Submitted target documents to partner \"{0}\" at url \"{1}\" for flow \"{2}\" with returned transaction id \"{3}\"",
                                              partner.Name, partner.Url, scheduledItem.TargetFlow, transactionId));

                _transactionManager.SetNetworkId(transactionStatus.Id, transactionId, endpointVersion,
                                                 endpointUrl);
            }
            else
            {
                activity.Append(string.Format("No target documents found to submit to partner \"{0}\"",
                                              partner.Name));
            }
        }
        protected virtual void ProcessSchematronTarget(TransactionStatus transactionStatus,
                                                       ScheduledItem scheduledItem,
                                                       Activity activity)
        {
            string filePath = GetZippedTransactionDocumentsAsTempFile(transactionStatus, scheduledItem);
            if (filePath != null)
            {
                string flowCode = _flowManager.GetDataFlowNameById(scheduledItem.FlowId);
                string token = _schematronHelper.Validate(filePath, flowCode);
                activity.Append(string.Format("Submitted target document to schematron service: {0}",
                                              token));
            }
            else
            {
                activity.Append("No target documents found to submit to schematron service");
            }

        }
        protected virtual void ProcessFileTarget(TransactionStatus transactionStatus, ScheduledItem scheduledItem,
                                                 Activity activity)
        {
            string networkDirectory = scheduledItem.TargetId;
            if (!string.IsNullOrEmpty(networkDirectory))
            {
                if (!Directory.Exists(networkDirectory))
                {
                    throw new DirectoryNotFoundException(string.Format("Could not find target directory \"{0}\"",
                                                         networkDirectory));
                }
                string pathName = Path.Combine(networkDirectory, GetResultFileName(scheduledItem));
                if (_transactionManager.GetZippedTransactionDocumentsAsFile(transactionStatus.Id, pathName))
                {
                    activity.Append(string.Format("Copied target documents to \"{0}\"", pathName));
                }
                else
                {
                    activity.Append("No target documents found to copy");
                }
            }
        }
        protected virtual void ProcessEmailTarget(TransactionStatus transactionStatus, ScheduledItem scheduledItem,
                                                  Activity activity)
        {
            string emailAddresses = scheduledItem.TargetId;
            if (!string.IsNullOrEmpty(emailAddresses))
            {
                string pathName = _transactionManager.GetZippedTransactionDocumentsAsTempFile(transactionStatus.Id);
                if (!string.IsNullOrEmpty(pathName))
                {
                    try
                    {
                        string attachmentName = GetResultFileName(scheduledItem);
                        _notificationManager.DoScheduleNotifications(transactionStatus, emailAddresses,
                                                                     scheduledItem.Name, pathName,
                                                                     attachmentName);
                        activity.Append(string.Format("Emailed target documents for transaction \"{0}\" to \"{1}\"",
                                                      transactionStatus.Id, emailAddresses));
                    }
                    finally
                    {
                        FileUtils.SafeDeleteFile(pathName);
                    }
                }
                else
                {
                    activity.Append(string.Format("No documents found for transaction \"{0}\"",
                                                  transactionStatus.Id));
                }
            }
            else
            {
                activity.Append(string.Format("No email addresses found for scheduled item \"{0}\"",
                                              scheduledItem.Name));
            }
        }
        protected virtual INodeEndpointClient GetNodeClient(PartnerIdentity partner)
        {
            return _nodeEndpointClientFactory.Make(partner.Url, partner.Version);
        }

        protected virtual string GetResultFileName(ScheduledItem scheduledItem)
        {
            string fileName = string.Format("{0}.zip", Guid.NewGuid().ToString());
            fileName = FileUtils.ReplaceInvalidFilenameChars(fileName, '_');
            return fileName;
        }
        protected virtual string GetZippedTransactionDocumentsAsTempFile(TransactionStatus transactionStatus,
                                                                         ScheduledItem scheduledItem)
        {
            string filePath = Path.Combine(SettingsProvider.TempFolderPath, GetResultFileName(scheduledItem));
            if (_transactionManager.GetZippedTransactionDocumentsAsFile(transactionStatus.Id, filePath))
            {
                return filePath;
            }
            else
            {
                return null;
            }
        }
        private class ScheduledItemProcessor : IBlockingQueueServerWorker
        {
            private string _scheduleId;
            private ScheduleProcessor _scheduleProcessor;

            public ScheduledItemProcessor(string scheduleId, ScheduleProcessor scheduleProcessor)
            {
                _scheduleId = scheduleId;
                _scheduleProcessor = scheduleProcessor;
            }
            public bool IsHighPriority
            {
                get
                {
                    return true;
                }
            }
            public void DoWork()
            {
                _scheduleProcessor.ProcessScheduledItem(_scheduleId);
            }
        }
        public IRequestManagerEx RequestManager
        {
            get
            {
                return _requestManager;
            }
            set
            {
                _requestManager = value;
            }
        }
        public IDocumentManagerEx DocumentManager
        {
            get
            {
                return _documentManager;
            }
            set
            {
                _documentManager = value;
            }
        }
        public IScheduleManager ScheduleManager
        {
            get
            {
                return _scheduleManager;
            }
            set
            {
                _scheduleManager = value;
            }
        }
        public IAccountManagerEx AccountManager
        {
            get { return _accountManager; }
            set { _accountManager = value; }
        }
        public ITransactionManagerEx TransactionManager
        {
            get
            {
                return _transactionManager;
            }
            set
            {
                _transactionManager = value;
            }
        }
        public IServiceManager ServiceManager
        {
            get
            {
                return _serviceManager;
            }
            set
            {
                _serviceManager = value;
            }
        }
        public IFlowManagerEx FlowManager
        {
            get { return _flowManager; }
            set { _flowManager = value; }
        }
        public ISchematronHelper SchematronHelper
        {
            get { return _schematronHelper; }
            set { _schematronHelper = value; }
        }
        public INotificationManager NotificationManager
        {
            get { return _notificationManager; }
            set { _notificationManager = value; }
        }
        public ICompressionHelper CompressionHelper
        {
            get { return _compressionHelper; }
            set { _compressionHelper = value; }
        }
        public IPartnerManager PartnerManager
        {
            get { return _partnerManager; }
            set { _partnerManager = value; }
        }
        public INodeEndpointClientFactory NodeEndpointClientFactory
        {
            get { return _nodeEndpointClientFactory; }
            set { _nodeEndpointClientFactory = value; }
        }
        protected override string MutexPrefix
        {
            get { return "ProcessScheduledItem_"; }
        }
    }
}
