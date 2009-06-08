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
using System.Net.Mail;
using System.Reflection;
using System.IO;
using System.Web;
using Windsor.Node2008.WNOSUtility;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOS.Data;
using Windsor.Node2008.WNOSConnector.Logic;
using Windsor.Node2008.WNOSConnector.Admin;
using Windsor.Commons.Core;

namespace Windsor.Node2008.WNOS.Logic
{
    /// <summary>
    /// Handles notifications within the server.
    /// </summary>
    public class NotificationManager : LogicAuditBaseManager, INotificationManager, INotificationService
    {

        private IFlowDao _flowDao;
        private bool _throwOnNotificationFailure;
        private INotificationDao _notificationDao;
        private Dictionary<string, string> _messageBodyFilePaths;
        private string _smtpHost;
        private int _smtpPort;
        private bool _smtpEnableSsl;
        private SmtpDeliveryMethod _deliveryMethod;
        private string _fromEmailAddress;
        private string _serverName = Environment.MachineName;
        private string _submitSubjectLine = "Node 2008 Submission Notification";
        private string _downloadSubjectLine = "Node 2008 Download Notification";
        private string _querySubjectLine = "Node 2008 Query Notification";
        private string _solicitSubjectLine = "Node 2008 Solicit Notification";
        private string _notifySubjectLine = "Node 2008 Notify Notification";
        private string _executeSubjectLine = "Node 2008 Execute Notification";
        private string _scheduleSubjectLine = "Node 2008 Schedule Notification";
        private string _changePasswordSubjectLine = "Node 2008 Change Password Notification";
        private string _newNaasUserSubjectLine = "Node 2008 Account Creation Notification";
        private string _newNodeUserSubjectLine = "Node 2008 Account Creation Notification";
        private string _remoteTransactionStatusSubjectLine = "Node 2008 Remote Transaction Status Notification";

        private const string RemoteTransactionStatusKey = "RemoteTransactionStatus";

        private string _adminInterfaceUrl;

        new public void Init()
        {
            base.Init();

            FieldNotInitializedException.ThrowIfNull(this, ref _flowDao);
            FieldNotInitializedException.ThrowIfNull(this, ref _messageBodyFilePaths);
            FieldNotInitializedException.ThrowIfNull(this, ref _fromEmailAddress);
            FieldNotInitializedException.ThrowIfNull(this, ref _notificationDao);

            FieldNotInitializedException.ThrowIfEmptyString(this, ref _smtpHost);
            FieldNotInitializedException.ThrowIfZero(this, ref _smtpPort);
            FieldNotInitializedException.ThrowIfEmptyString(this, ref _adminInterfaceUrl);

            // Make sure all of the files are present
            foreach (KeyValuePair<string, string> pair in MessageBodyFilePaths)
            {
                FieldNotInitializedException.ThrowIfRelativeFileMissing(pair.Value);
            }
        }

        public IDictionary<string, SimpleListDisplayInfo> GetListInfo(params string[] args)
        {
            if (args.Length == 0)
            {
                throw new IndexOutOfRangeException("Must pass username to GetListInfo() method.");
            }
            string username = args[0];
            Dictionary<string, SimpleListDisplayInfo> dict =
                new Dictionary<string, SimpleListDisplayInfo>();
            IList<SimpleFlowNotification> flowNotifications =
                _notificationDao.GetAllSimpleFlowNotificationsForUsername(username);
            if (!CollectionUtils.IsNullOrEmpty(flowNotifications))
            {
                foreach (SimpleFlowNotification flowNotification in flowNotifications)
                {
                    dict.Add(flowNotification.FlowCode, new SimpleListDisplayInfo(flowNotification.FlowCode,
                                                                                  flowNotification.FlowDescription,
                                                                                  flowNotification.NotificationType));
                }
            }
            // Add in any missing flows
            IList<DataFlow> flows = _flowDao.GetAllDataFlows(false, false);
            if (!CollectionUtils.IsNullOrEmpty(flows))
            {
                foreach (DataFlow flow in flows)
                {
                    if (!dict.ContainsKey(flow.FlowName))
                    {
                        dict.Add(flow.FlowName, new SimpleListDisplayInfo(flow.FlowName, flow.Description,
                                                                          NotificationType.None));
                    }
                }
            }
            return dict;
        }

        public UserAccount Save(UserAccount userAccount, IList<SimpleFlowNotification> notifications,
                                AdminVisit visit)
        {
            try
            {
                ValidateByRoleAndNotDemoAccount(visit, SystemRoleType.Program);

                _notificationDao.SaveNotifications(userAccount.Id, visit.Account.Id, notifications);

                ActivityManager.LogAudit(NodeMethod.None, null, visit, "{0} saved notifications for user: {1}.",
                                         visit.Account.NaasAccount, userAccount.NaasAccount);
                return userAccount;
            }
            catch (Exception e)
            {
                ActivityManager.LogError(NodeMethod.None, null, e, visit, "{0} failed to save notifications for user: {1}.",
                                         visit.Account.NaasAccount, userAccount.NaasAccount);
                throw;
            }
        }

        /// <summary>
        /// Sends submit notifications
        /// </summary>
        /// <param name="tran"></param>
        public void DoSubmitNotifications(TransactionStatus status, string flowId, string flowName,
                                          string operation, string username)
        {
            SendNotificationsPriv(flowId, status.Id, NotificationType.OnSubmit, SubmitSubjectLine,
                              new string[] { _serverName, FromEmailAddress, DateTime.Now.ToString(),
                              username, flowName, status.Status.ToString(),
                              AdminInterfaceUrl, status.Id.ToString()});

        }

        /// <summary>
        /// Sends download notifications
        /// </summary>
        /// <param name="tran"></param>
        public void DoDownloadNotifications(string transactionId, string flowId, string flowName,
                                            string username)
        {
            SendNotificationsPriv(flowId, transactionId, NotificationType.OnDownload, DownloadSubjectLine,
                              new string[] { _serverName, FromEmailAddress, DateTime.Now.ToString(),
                              username, flowName,
                              AdminInterfaceUrl, transactionId.ToString()});

        }

        /// <summary>
        /// Sends query notifications
        /// </summary>
        /// <param name="tran"></param>
        public void DoQueryNotifications(string flowId, string transactionId, string flowName, string username, string serviceName,
                                         int startRow, int maxRows, ByIndexOrNameDictionary<string> parameters)
        {
            SendNotificationsPriv(flowId, transactionId, NotificationType.OnQuery, QuerySubjectLine,
                              new string[] { _serverName, FromEmailAddress, DateTime.Now.ToString(),
                              username, flowName, serviceName, StringUtils.Join(", ", parameters),
                              startRow.ToString(), maxRows.ToString() });
        }

        /// <summary>
        /// Sends solicit notifications
        /// </summary>
        /// <param name="tran"></param>
        public void DoSolicitNotifications(TransactionStatus status, string flowId, string flowName, string username,
                                           string serviceName, ByIndexOrNameDictionary<string> parameters)
        {
            SendNotificationsPriv(flowId, status.Id, NotificationType.OnSolicit, SolicitSubjectLine,
                              new string[] { _serverName, FromEmailAddress, DateTime.Now.ToString(),
                              username, flowName, serviceName, StringUtils.Join(", ", parameters),
                              AdminInterfaceUrl, status.Id.ToString()});
        }

        /// <summary>
        /// Sends query notifications
        /// </summary>
        /// <param name="tran"></param>
        public void DoExecuteNotifications(string transactionId, CommonTransactionStatusCode status,
                                           string flowId, string interfaceName,
                                           string username, string methodName, ByIndexOrNameDictionary<string> parameters)
        {
            SendNotificationsPriv(flowId, transactionId, NotificationType.OnExecute, ExecuteSubjectLine,
                              new string[] { _serverName, FromEmailAddress, DateTime.Now.ToString(),
                              username, interfaceName, methodName,
                              StringUtils.Join(", ", parameters),
                              status.ToString(), AdminInterfaceUrl,
                              transactionId.ToString()});
        }

        /// <summary>
        /// Sends notify notifications
        /// </summary>
        /// <param name="tran"></param>
        public void DoNotifyNotifications(TransactionStatus status, string flowId, string flowName,
                                          string username)
        {
            SendNotificationsPriv(flowId, status.Id, NotificationType.OnNotify, NotifySubjectLine,
                                  new string[] { _serverName, FromEmailAddress, DateTime.Now.ToString(),
                                                 username, flowName, status.Status.ToString(),
                                                 AdminInterfaceUrl, status.Id.ToString()});

        }

        /// <summary>
        /// Sends schedule notifications
        /// </summary>
        /// <param name="tran"></param>
        public void DoScheduleNotifications(TransactionStatus status, string emailAddresses,
                                            string scheduleName, string attachmentFile,
                                            string attachmentName)
        {
            using (Stream stream = File.OpenRead(attachmentFile))
            {
                SendNotificationsPriv(null, status.Id, emailAddresses, NotificationType.OnSchedule, ScheduleSubjectLine,
                                      stream, attachmentName, 
                                      new string[] { _serverName, FromEmailAddress, DateTime.Now.ToString(), scheduleName, 
                                                     AdminInterfaceUrl, status.Id.ToString()});
            }
        }

        /// <summary>
        /// Sends schedule notifications
        /// </summary>
        /// <param name="tran"></param>
        public void DoScheduleNotifications(TransactionStatus status, string emailAddresses,
                                            string scheduleName, Stream attachmentContent,
                                            string attachmentName)
        {

            SendNotificationsPriv(null, status.Id, emailAddresses, NotificationType.OnSchedule, ScheduleSubjectLine,
                                  attachmentContent, attachmentName, 
                                  new string[] { _serverName, FromEmailAddress, DateTime.Now.ToString(), 
                                  scheduleName, AdminInterfaceUrl, status.Id.ToString() });
        }

        /// <summary>
        /// Sends change password notifications
        /// </summary>
        /// <param name="tran"></param>
        public void DoChangePasswordNotifications(string username, string password)
        {
            SendNotificationsPriv(null, null, username, "OnChangePasswordNotification", ChangePasswordSubjectLine,
                                  null, null, new string[] { _serverName, username, password, AdminInterfaceUrl });
        }

        /// <summary>
        /// Sends new account notifications
        /// </summary>
        /// <param name="tran"></param>
        public void DoNewNaasAccountNotifications(string username, string password)
        {
            SendNotificationsPriv(null, null, username, "OnNewNaasUserNotification", NewNaasUserSubjectLine,
                                  null, null, new string[] { _serverName, username, password, AdminInterfaceUrl });
        }

        /// <summary>
        /// Sends new account notifications
        /// </summary>
        /// <param name="tran"></param>
        public void DoNewNodeAccountNotifications(string username)
        {
            SendNotificationsPriv(null, null, username, "OnNewNodeUserNotification", NewNodeUserSubjectLine,
                                  null, null, new string[] { _serverName, username, AdminInterfaceUrl });
        }

        /// <summary>
        /// Sends query notifications
        /// </summary>
        /// <param name="tran"></param>
        public void DoScheduleNotifications(TransactionStatus status, string flowId, string scheduleName)
        {
            SendNotificationsPriv(flowId, status.Id, NotificationType.OnSchedule, ScheduleSubjectLine,
                                  new string[] { _serverName, FromEmailAddress, DateTime.Now.ToString(),
                                  scheduleName, AdminInterfaceUrl, status.Id.ToString() });
        }

        public void DoRemoteTransactionStatusNotifications(NodeMethod transactionMethod, string filePath,
                                                    TransactionStatus status,
                                                    string flowName, string operation,
                                                    string emailAddresses)
        {
            SendNotificationsPriv(flowName, status.Id, emailAddresses, RemoteTransactionStatusKey, _remoteTransactionStatusSubjectLine,
                                  (Stream)null, (string)null, 
                                  new string[] { DateTime.Now.ToString(), status.Id.ToString(),
                                  status.Status.ToString(), AdminInterfaceUrl, status.Id.ToString() });
        }

        /// <summary>
        /// Sends a message based on the configured message templates
        /// Allows for body to be formatted with arguments.
        /// </summary>
        /// <param name="messageKey">key of the message configured during the setup</param>
        /// <param name="args">array of arguments (optional)</param>
        private void SendNotificationsPriv(string flowId, string transactionId, NotificationType notificationType,
                                           string subject, string[] args)
        {
            string flowName;
            string emails = NotificationDao.GetNotificationEmailsAsString(flowId, notificationType, out flowName);
            SendNotificationsPriv(flowName, transactionId, emails, notificationType, subject, null, null, args);
        }
        /// <summary>
        /// Sends a message based on the configured message templates
        /// Allows for body to be formatted with arguments.
        /// </summary>
        /// <param name="messageKey">key of the message configured during the setup</param>
        /// <param name="args">array of arguments (optional)</param>
        private void SendNotificationsPriv(string flowName, string transactionId, string toEmailAddresses, NotificationType notificationType,
                                              string subject, Stream attachmentContent, string attachmentName,
                                              string[] args)
        {
            SendNotificationsPriv(flowName, transactionId, toEmailAddresses, notificationType.ToString(), subject,
                                     attachmentContent, attachmentName, args);
        }
        /// <summary>
        /// Sends a message based on the configured message templates
        /// Allows for body to be formatted with arguments.
        /// </summary>
        /// <param name="messageKey">key of the message configured during the setup</param>
        /// <param name="args">array of arguments (optional)</param>
        private void SendNotificationsPriv(string flowName, string transactionId, string toEmailAddresses, string notificationKey,
                                           string subject, Stream attachmentContent, string attachmentName,
                                           string[] args)
        {
            if (string.IsNullOrEmpty(toEmailAddresses))
            {
                return;
            }
            Activity activity = 
                new Activity(NodeMethod.None, flowName, null, ActivityType.Info, transactionId, null, null);
            try
            {
                string messageBody = LoadNotificationBody(notificationKey);
                if (args != null)
                {
                    for (int i = 0; i < args.Length; ++i)
                    {
                        args[i] = HttpUtility.HtmlEncode(args[i]);
                    }
                    messageBody = string.Format(messageBody, args);
                }
                using (MailMessage msg = new MailMessage(FromEmailAddress,
														 toEmailAddresses,
                                                         subject, messageBody))
                {
                    msg.IsBodyHtml = true;
                    if (attachmentContent != null)
                    {
                        Attachment attachment = new Attachment(attachmentContent, attachmentName);
                        msg.Attachments.Add(attachment);
                    }
                    int retryCount = 3;
                    do {
                        try
                        {
                            SmtpClient smtpClient = new SmtpClient(SmtpHost, SmtpPort);
                            smtpClient.DeliveryMethod = DeliveryMethod;
                            smtpClient.EnableSsl = _smtpEnableSsl;
//If an exception is thrown, this setting causes max cpu usage on a background worker thread for no good reason, so I'm commenting it out:
                            //smtpClient.ServicePoint.MaxIdleTime = 1;
                            smtpClient.Send(msg);
                            retryCount = 1;
                        }
                        catch (Exception smtpException)
                        {
                            if ((retryCount > 1) && (smtpException.InnerException != null) &&
                                (smtpException.InnerException.Message != null) &&
                                (smtpException.InnerException.Message.IndexOf("net_io_connectionclosed") >= 0))
                            {
                                activity.AppendFormat("Failed to send email notification: From ({0}), To ({1}), Type ({2}), DeliveryMethod ({3}), EnableSsl ({4}), SmtpHost ({5}), SmtpPort ({6})",
                                                      FromEmailAddress, toEmailAddresses, notificationKey,
                                                      DeliveryMethod, _smtpEnableSsl, SmtpHost, SmtpPort);
                                activity.AppendFormat("EXCEPTION: {0}", ExceptionUtils.ToShortString(smtpException));
                                activity.AppendFormat("Retrying email send ...");
                            }
                            else
                            {
                                throw;
                            }
                        }
                    } while ( --retryCount > 0 );
                }
                activity.AppendFormat("Successfully sent \"{0}\" email notification to \"{1}\"",
                                      notificationKey, toEmailAddresses);
                ActivityManager.Log(activity);
            }
            catch (Exception ex)
            {
                string message =
                    string.Format("Failed to send email notification: From ({0}), To ({1}), Type ({2}), DeliveryMethod ({3}), EnableSsl ({4}), SmtpHost ({5}), SmtpPort ({6})",
                                  FromEmailAddress, toEmailAddresses, notificationKey,
                                  DeliveryMethod, _smtpEnableSsl, SmtpHost, SmtpPort);
                activity.AppendFormat(message);
                activity.AppendFormat("EXCEPTION: {0}", ExceptionUtils.ToShortString(ex));
                activity.Type = ActivityType.Error;
                ActivityManager.Log(activity);
                LOG.Error(message, ex);
                if (ThrowOnNotificationFailure)
                {
                    throw;
                }
            }
        }
        private string LoadNotificationBody(NotificationType messageKey)
        {
            return LoadNotificationBody(messageKey.ToString());
        }
        private string LoadNotificationBody(string messageKey)
        {
            if (!_messageBodyFilePaths.ContainsKey(messageKey))
            {
                throw new ArgumentException("Invalid message key: " + messageKey);
            }
            string path = FileUtils.PathFromExecutingAssemblyRelativePath(_messageBodyFilePaths[messageKey]);
            return File.ReadAllText(path);
        }
        public string ChangePasswordSubjectLine
        {
            get { return _changePasswordSubjectLine; }
            set { _changePasswordSubjectLine = value; }
        }
        public string ScheduleSubjectLine
        {
            get { return _scheduleSubjectLine; }
            set { _scheduleSubjectLine = value; }
        }

        public string ExecuteSubjectLine
        {
            get { return _executeSubjectLine; }
            set { _executeSubjectLine = value; }
        }

        public string NotifySubjectLine
        {
            get { return _notifySubjectLine; }
            set { _notifySubjectLine = value; }
        }

        public string SolicitSubjectLine
        {
            get
            {
                return _solicitSubjectLine;
            }
            set
            {
                _solicitSubjectLine = value;
            }
        }

        public string QuerySubjectLine
        {
            get
            {
                return _querySubjectLine;
            }
            set
            {
                _querySubjectLine = value;
            }
        }

        public string DownloadSubjectLine
        {
            get
            {
                return _downloadSubjectLine;
            }
            set
            {
                _downloadSubjectLine = value;
            }
        }

        public INotificationDao NotificationDao
        {
            get
            {
                return _notificationDao;
            }
            set
            {
                _notificationDao = value;
            }
        }

        public bool ThrowOnNotificationFailure
        {
            get
            {
                return _throwOnNotificationFailure;
            }
            set
            {
                _throwOnNotificationFailure = value;
            }
        }

        public string SubmitSubjectLine
        {
            get
            {
                return _submitSubjectLine;
            }
            set
            {
                _submitSubjectLine = value;
            }
        }
        public string NewNaasUserSubjectLine
        {
            get { return _newNaasUserSubjectLine; }
            set { _newNaasUserSubjectLine = value; }
        }
        public string NewNodeUserSubjectLine
        {
            get { return _newNodeUserSubjectLine; }
            set { _newNodeUserSubjectLine = value; }
        }
        public string RemoteTransactionStatusSubjectLine
        {
            get { return _remoteTransactionStatusSubjectLine; }
            set { _remoteTransactionStatusSubjectLine = value; }
        }


        public string ServerName
        {
            get
            {
                return _serverName;
            }
            set
            {
                _serverName = value;
            }
        }

        public string FromEmailAddress
        {
            get
            {
                return _fromEmailAddress;
            }
            set
            {
                _fromEmailAddress = value;
            }
        }

        public Dictionary<string, string> MessageBodyFilePaths
        {
            get
            {
                return _messageBodyFilePaths;
            }
            set
            {
                _messageBodyFilePaths = value;
            }
        }

        public int SmtpPort
        {
            get { return _smtpPort; }
            set { _smtpPort = value; }
        }
        public string SmtpHost
        {
            get { return _smtpHost; }
            set { _smtpHost = value; }
        }
        public SmtpDeliveryMethod DeliveryMethod
        {
            get { return _deliveryMethod; }
            set { _deliveryMethod = value; }
        }
        public bool SmtpEnableSsl
        {
            get { return _smtpEnableSsl; }
            set { _smtpEnableSsl = value; }
        }
        public IFlowDao FlowDao
        {
            get
            {
                return _flowDao;
            }
            set
            {
                _flowDao = value;
            }
        }
        public string AdminInterfaceUrl
        {
            get { return _adminInterfaceUrl; }
            set { _adminInterfaceUrl = value; }
        }

        public NotificationManager()
        {
        }

    }
}
