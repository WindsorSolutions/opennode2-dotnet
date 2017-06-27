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

using System.Data;
using System.Data.Common;
using System.Reflection;
using System.Diagnostics;
using System.IO;

using Spring.Data.Generic;
using Spring.Data.Common;


using Common.Logging;

using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSUtility;
using Windsor.Node2008.WNOSConnector;
using Windsor.Node2008.WNOSConnector.Logic;
using Windsor.Commons.Core;
using Windsor.Commons.Spring;
using Windsor.Commons.NodeDomain;
using Windsor.Node2008.WNOSDomain.TransactionTracking;

namespace Windsor.Node2008.WNOS.Data
{
    /// <summary>
    /// Should be implementing interface but for now just use the raw object
    /// </summary>
    public class TransactionDao : BaseDao, ITransactionDao
    {
        public const string TABLE_NAME = "NTransaction";
        public const string NOTIFICATION_TABLE_NAME = "NTransactionNotification";
        public const string RECIPIENT_TABLE_NAME = "NTransactionRecipient";
        public const string REALTIME_DETAILS_TABLE_NAME = "NTransactionRealtimeDetails";
        private IFlowDao _flowDao;
        private IAccountDao _accountDao;
        private IDocumentManagerEx _documentManager;
        private IRequestDao _requestDao;
        private IActivityDao _activityDao;
        private INodeNotificationDao _nodeNotificationDao;
        private ITransactionStatusChangeNotifier _transactionStatusChangeNotifier;
        private const int MAX_DETAIL_CHARS = 4000;

        private const CommonTransactionStatusCode UNPROCESSED_STATUS = CommonTransactionStatusCode.Received |
                                                                       CommonTransactionStatusCode.Pending |
                                                                       CommonTransactionStatusCode.Processing;

        private string MAP_TRANSACTION_COLUMNS = "Id;FlowId;NetworkId;Status;ModifiedBy;ModifiedOn;StatusDetail;Operation;WebMethod;EndpointVersion;NetworkEndpointVersion;NetworkEndpointUrl;NetworkEndpointStatus;NetworkEndpointStatusDetail";

        private NodeTransaction MapTransaction(IDataReader reader)
        {
            NodeTransaction transaction = new NodeTransaction();
            int index = 0;
            transaction.Id = reader.GetString(index++);
            string flowId = reader.GetString(index++);
            transaction.Status = new TransactionStatus(transaction.Id);
            transaction.NetworkId = reader.GetString(index++);
            transaction.Status.Status = EnumUtils.ParseEnum<CommonTransactionStatusCode>(reader.GetString(index++));
            transaction.ModifiedById = reader.GetString(index++);
            transaction.ModifiedOn = reader.GetDateTime(index++);
            transaction.Status.Description = reader.GetString(index++);
            transaction.Operation = reader.GetString(index++);
            transaction.NodeMethod = EnumUtils.ParseEnum<NodeMethod>(reader.GetString(index++));
            transaction.EndpointVersion = EnumUtils.ParseEnum<EndpointVersionType>(reader.GetString(index++));
            transaction.NetworkEndpointVersion = EnumUtils.ParseEnum<EndpointVersionType>(reader.GetString(index++));
            transaction.NetworkEndpointUrl = reader.GetString(index++);
            transaction.NetworkEndpointStatus = EnumUtils.ParseEnum<CommonTransactionStatusCode>(reader.GetString(index++));
            string networkStatusDetailText = reader.GetString(index++);
            string networkFlowName, networkOperationName, networkStatusDetail;
            GetNetworkStatusDetails(networkStatusDetailText, out networkFlowName, out networkOperationName, out networkStatusDetail);
            transaction.NetworkEndpointStatusDetail = networkStatusDetail;
            transaction.NetworkFlowName = networkFlowName;
            transaction.NetworkOperationName = networkOperationName;
            if (AreEndpointUsersEnabled)
            {
                transaction.NetworkEndpointUserId = reader.GetString(index++);
            }
            transaction.Flow = FlowDao.GetDataFlow(flowId);
            return transaction;
        }
        public ITransactionStatusChangeNotifier TransactionStatusChangeNotifier
        {
            get
            {
                return _transactionStatusChangeNotifier;
            }
            set
            {
                _transactionStatusChangeNotifier = value;
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

        public IRequestDao RequestDao
        {
            get
            {
                return _requestDao;
            }
            set
            {
                _requestDao = value;
            }
        }
        public INodeNotificationDao NodeNotificationDao
        {
            get
            {
                return _nodeNotificationDao;
            }
            set
            {
                _nodeNotificationDao = value;
            }
        }
        public IAccountDao AccountDao
        {
            get
            {
                return _accountDao;
            }
            set
            {
                _accountDao = value;
            }
        }
        public IActivityDao ActivityDao
        {
            get
            {
                return _activityDao;
            }
            set
            {
                _activityDao = value;
            }
        }
        #region Init

        new public void Init()
        {
            base.Init();

            FieldNotInitializedException.ThrowIfNull(this, ref _flowDao);
            FieldNotInitializedException.ThrowIfNull(this, ref _documentManager);
            FieldNotInitializedException.ThrowIfNull(this, ref _requestDao);
            FieldNotInitializedException.ThrowIfNull(this, ref _transactionStatusChangeNotifier);
            FieldNotInitializedException.ThrowIfNull(this, ref _nodeNotificationDao);
            FieldNotInitializedException.ThrowIfNull(this, ref _accountDao);
            FieldNotInitializedException.ThrowIfNull(this, ref _activityDao);

            if (AreEndpointUsersEnabled)
            {
                MAP_TRANSACTION_COLUMNS += ";NetworkEndpointUser";
            }
        }

        #endregion

        #region Methods

        public bool AreEndpointUsersEnabled
        {
            get
            {
                return AccountDao.AreEndpointUsersEnabled;
            }
        }
        /// <summary>
        /// Set the status of the specified transaction and return current status.
        /// </summary>
        public TransactionStatus SetTransactionStatus(string transactionId, CommonTransactionStatusCode statusCode,
                                                      string statusDetail, bool sendStatusChangeNotifications)
        {
            DoSimpleUpdateOne(TABLE_NAME, "Id", transactionId,
                        "Id;Status;ModifiedOn;StatusDetail",
                        transactionId, statusCode.ToString(), DateTime.Now,
                        LimitDbText(statusDetail, MAX_DETAIL_CHARS));
            TransactionStatus status = new TransactionStatus(transactionId, statusCode, statusDetail);

            if (sendStatusChangeNotifications)
            {
                SendStatusChangeNotifications(status);
            }
            return status;
        }

        /// <summary>
        /// Set the status of the specified transaction and return current status.
        /// </summary>
        public TransactionStatus SetTransactionStatus(string transactionId, string userCreatorId,
                                                      CommonTransactionStatusCode statusCode,
                                                      string statusDetail, bool sendStatusChangeNotifications)
        {
            DoSimpleUpdateOne(TABLE_NAME, "Id", transactionId,
                        "Id;Status;ModifiedBy;ModifiedOn;StatusDetail",
                        transactionId, statusCode.ToString(), userCreatorId, DateTime.Now,
                        LimitDbText(statusDetail, MAX_DETAIL_CHARS));
            TransactionStatus status = new TransactionStatus(transactionId, statusCode, statusDetail);
            if (sendStatusChangeNotifications)
            {
                SendStatusChangeNotifications(status);
            }
            return status;
        }

        /// <summary>
        /// Set the status of the specified transaction (iff the current transaction status is not setIfNotStatusCodes),
        /// and return current status.
        /// </summary>
        public TransactionStatus SetTransactionStatusIfNotStatus(string transactionId, CommonTransactionStatusCode statusCodeToSet,
                                                                 string statusDetail, CommonTransactionStatusCode setIfNotStatusCodes,
                                                                 bool sendStatusChangeNotifications)
        {
            int count = DoSimpleUpdateAny(TABLE_NAME, "Id;NOT " + GetDbInGroupFromFlagsEnum("Status", setIfNotStatusCodes),
                                new object[] { transactionId },
                                "Id;Status;ModifiedOn;StatusDetail",
                                transactionId, statusCodeToSet.ToString(), DateTime.Now,
                                LimitDbText(statusDetail, MAX_DETAIL_CHARS));
            if (count == 1)
            {
                TransactionStatus status = new TransactionStatus(transactionId, statusCodeToSet, statusDetail);
                if (sendStatusChangeNotifications)
                {
                    SendStatusChangeNotifications(status);
                }
                return status;
            }
            else
            {
                DebugUtils.AssertDebuggerBreak(count == 0);
                return GetTransactionStatus(transactionId);
            }
        }

        /// <summary>
        /// Return the status of the transaction with the input transaction id, or null
        /// if the id is not found.
        /// </summary>
        public TransactionStatus GetTransactionStatus(string transactionId)
        {
            try
            {
                TransactionStatus transactionStatus =
                    DoSimpleQueryForObjectDelegate<TransactionStatus>(
                        TABLE_NAME, "Id", transactionId, "Status;StatusDetail",
                        delegate(IDataReader reader, int rowNum)
                        {
                            TransactionStatus status = new TransactionStatus(transactionId);
                            status.Status = EnumUtils.ParseEnum<CommonTransactionStatusCode>(reader.GetString(0));
                            status.Description = reader.GetString(1);
                            return status;
                        });
                return transactionStatus;
            }
            catch (Spring.Dao.IncorrectResultSizeDataAccessException)
            {
                return null; // Not found
            }
        }
        /// <summary>
        /// Return true if the input transaction has an unprocessed status (see GetAllUnprocessedTransactionIds()).
        /// </summary>
        public bool IsUnprocessed(string transactionId)
        {
            string modifiedBy;
            return IsUnprocessed(transactionId, out modifiedBy);
        }
        /// <summary>
        /// Return true if the input transaction has an unprocessed status (see GetAllUnprocessedTransactionIds()).
        /// </summary>
        public bool IsUnprocessed(string transactionId, out string userModifiedById)
        {
            string validTransactionStatusGroup = GetDbInGroupFromFlagsEnum("Status", UNPROCESSED_STATUS);
            bool isUnprocessed = false;
            string modifiedBy = null;
            DoSimpleQueryWithRowCallbackDelegate(
                TABLE_NAME, "Id;" + validTransactionStatusGroup, transactionId, null,
                "ModifiedBy",
                delegate(IDataReader reader)
                {
                    isUnprocessed = true;
                    modifiedBy = reader.GetString(0);
                });
            userModifiedById = modifiedBy;
            return isUnprocessed;
        }
        public ComplexNotification GetNotifyTransactionByTransactionId(string transactionID)
        {
            return _nodeNotificationDao.GetNotificationByTransactionId(transactionID);
        }
        public string CreateNotifyTransaction(string flowId, string operation, string userCreatorId,
                                              CommonTransactionStatusCode statusCode, string statusDetail,
                                              ComplexNotification notification, EndpointVersionType endpointVersion,
                                              bool sendStatusChangeNotifications)
        {
            string transactionId;
            if ((notification != null) && (notification.Notifications != null) &&
                 (notification.Notifications.Count == 1))
            {
                // If this is a single notification and it refers to a remote transaction id,
                // store the notification with that transaction id
                transactionId = GetSingleTransactionWithNetworkId(notification.Notifications[0].Id);
                if (!string.IsNullOrEmpty(transactionId))
                {
                    _nodeNotificationDao.CreateNotification(transactionId, notification);
                    if (sendStatusChangeNotifications)
                    {
                        SendStatusChangeNotifications(transactionId);
                    }
                    return transactionId;
                }
            }
            transactionId = IdProvider.Get();
            TransactionTemplate.Execute(delegate
            {
                DoInsert(TABLE_NAME,
                         "Id;FlowId;NetworkId;Status;ModifiedBy;ModifiedOn;StatusDetail;Operation;WebMethod;EndpointVersion",
                         transactionId, flowId, transactionId, statusCode.ToString(),
                         userCreatorId, DateTime.Now, LimitDbText(statusDetail, MAX_DETAIL_CHARS), operation ?? string.Empty,
                         NodeMethod.Notify.ToString(), endpointVersion.ToString());
                _nodeNotificationDao.CreateNotification(transactionId, notification);
                return null;
            });
            if (sendStatusChangeNotifications)
            {
                SendStatusChangeNotifications(transactionId);
            }
            return transactionId;
        }
        /// <summary>
        /// Return the flow id associated with this transaction.
        /// </summary>
        public string GetTransactionFlowId(string transactionId)
        {
            return DoSimpleQueryForObjectDelegate<string>(
                    TABLE_NAME, "Id", transactionId, "FlowId",
                    delegate(IDataReader reader, int rowNum)
                    {
                        return reader.GetString(0);
                    });
        }
        public IList<string> GetAllDocumentNames(string transactionId)
        {
            return _documentManager.GetAllDocumentNames(transactionId);
        }
        /// <summary>
        /// Return the username associated with this transaction.
        /// </summary>
        public string GetTransactionUsername(string transactionId)
        {
            return DoSimpleQueryForObjectDelegate<string>(
                        string.Format("{0} t, {1} a", TABLE_NAME, Windsor.Node2008.WNOS.Data.AccountDao.TABLE_NAME),
                        "t.Id; t.ModifiedBy = a.Id", transactionId, "a.NAASAccount",
                        delegate(IDataReader reader, int rowNum)
                        {
                            return reader.GetString(0);
                        });
        }
        /// <summary>
        /// Return the flow id and operation associated with this transaction.
        /// </summary>
        public string GetTransactionFlowId(string transactionId, out string flowName,
                                           out string operation, out bool isProtected)
        {
            string operationPriv = string.Empty;
            string flowNamePriv = string.Empty;
            bool isProtectedPriv = true;
            string flowId =
                DoSimpleQueryForObjectDelegate<string>(
                    string.Format("{0} t, {1} f", TABLE_NAME, Windsor.Node2008.WNOS.Data.FlowDao.TABLE_NAME),
                    "t.Id; t.FlowId = f.Id", transactionId, "t.Operation;f.Code;f.IsProtected;t.FlowId",
                    delegate(IDataReader reader, int rowNum)
                    {
                        operationPriv = reader.GetString(0);
                        flowNamePriv = reader.GetString(1);
                        isProtectedPriv = DbUtils.ToBool(reader.GetString(2));
                        return reader.GetString(3);
                    });
            operation = operationPriv;
            flowName = flowNamePriv;
            isProtected = isProtectedPriv;
            return flowId;
        }
        /// <summary>
        /// Return the flow id and operation associated with this transaction.
        /// </summary>
        public string GetTransactionFlowId(string transactionId, out string flowName,
                                           out string operation)
        {
            bool isProtected;
            return GetTransactionFlowId(transactionId, out flowName, out operation, out isProtected);
        }
        /// <summary>
        /// Return the flow id and operation associated with this transaction.
        /// </summary>
        public string GetTransactionFlowId(string transactionId, out string flowName, out string operation,
                                           out EndpointVersionType endpointVersion)
        {
            string operationPriv = string.Empty;
            string flowNamePriv = string.Empty;
            EndpointVersionType endpointVersionPriv = EndpointVersionType.Undefined;
            string flowId =
                DoSimpleQueryForObjectDelegate<string>(
                    string.Format("{0} t, {1} f", TABLE_NAME, Windsor.Node2008.WNOS.Data.FlowDao.TABLE_NAME),
                    "t.Id; t.FlowId = f.Id", transactionId, "t.Operation;f.Code;t.EndpointVersion;t.FlowId",
                    delegate(IDataReader reader, int rowNum)
                    {
                        operationPriv = reader.GetString(0);
                        flowNamePriv = reader.GetString(1);
                        endpointVersionPriv = EnumUtils.ParseEnum<EndpointVersionType>(reader.GetString(2));
                        return reader.GetString(3);
                    });
            operation = operationPriv;
            flowName = flowNamePriv;
            endpointVersion = endpointVersionPriv;
            return flowId;
        }
        /// <summary>
        /// Return the flow id and operation associated with this transaction.
        /// </summary>
        public string GetTransactionFlowId(string transactionId, out string operation)
        {
            string operationPriv = string.Empty;
            string flowId =
                DoSimpleQueryForObjectDelegate<string>(
                    TABLE_NAME, "Id", transactionId, "Operation;FlowId",
                    delegate(IDataReader reader, int rowNum)
                    {
                        operationPriv = reader.GetString(0);
                        return reader.GetString(1);
                    });
            operation = operationPriv;
            return flowId;
        }
        /// <summary>
        /// Get the document associated with the transaction, or return null if
        /// the document cannot be found.
        /// </summary>
        public Document GetTransactionDocument(string transactionID, string dbDocId)
        {
            return _documentManager.GetDocument(transactionID, dbDocId, false);
        }

        /// <summary>
        /// Return the status of the transaction with the input transaction id, or null
        /// if the id is not found, and return the flow associated with the transaction
        /// in flowId.
        /// </summary>
        public TransactionStatus GetTransactionStatus(string transactionId, out string flowId,
                                                      out string operation, out NodeMethod webMethod)
        {
            try
            {
                string flowIdPriv = string.Empty;
                string operationPriv = string.Empty;
                NodeMethod webMethodPriv = NodeMethod.None;
                TransactionStatus transactionStatus =
                    DoSimpleQueryForObjectDelegate<TransactionStatus>(
                        TABLE_NAME, "Id", transactionId, "FlowId;Status;StatusDetail;Operation;WebMethod",
                        delegate(IDataReader reader, int rowNum)
                        {
                            TransactionStatus status = new TransactionStatus(transactionId);
                            flowIdPriv = reader.GetString(0);
                            status.Status = EnumUtils.ParseEnum<CommonTransactionStatusCode>(reader.GetString(1));
                            status.Description = reader.GetString(2);
                            operationPriv = reader.GetString(3);
                            webMethodPriv = EnumUtils.ParseEnum<NodeMethod>(reader.GetString(4));
                            return status;
                        });
                flowId = flowIdPriv;
                operation = operationPriv;
                webMethod = webMethodPriv;
                return transactionStatus;
            }
            catch (Spring.Dao.IncorrectResultSizeDataAccessException)
            {
                flowId = operation = string.Empty;
                webMethod = NodeMethod.None;
                return null; // Not found
            }
        }

        /// <summary>
        /// Return the status of the transaction with the input transaction id, or null
        /// if the id is not found, and return the flow associated with the transaction
        /// in flowId.
        /// </summary>
        public TransactionStatus GetTransactionStatusByNetworkId(string networkId, out string flowId,
                                                                 out string operation, out NodeMethod webMethod)
        {
            try
            {
                string flowIdPriv = string.Empty;
                string operationPriv = string.Empty;
                NodeMethod webMethodPriv = NodeMethod.None;
                TransactionStatus transactionStatus =
                    DoSimpleQueryForObjectDelegate<TransactionStatus>(
                        TABLE_NAME, "NetworkId", networkId, "Id;FlowId;Status;StatusDetail;Operation;WebMethod",
                        delegate(IDataReader reader, int rowNum)
                        {
                            TransactionStatus status = new TransactionStatus(reader.GetString(0));
                            flowIdPriv = reader.GetString(1);
                            status.Status = EnumUtils.ParseEnum<CommonTransactionStatusCode>(reader.GetString(2));
                            status.Description = reader.GetString(3);
                            operationPriv = reader.GetString(4);
                            webMethodPriv = EnumUtils.ParseEnum<NodeMethod>(reader.GetString(5));
                            return status;
                        });
                flowId = flowIdPriv;
                operation = operationPriv;
                webMethod = webMethodPriv;
                return transactionStatus;
            }
            catch (Spring.Dao.IncorrectResultSizeDataAccessException)
            {
                flowId = operation = string.Empty;
                webMethod = NodeMethod.None;
                return null; // Not found
            }
        }

        public string GetTransactionFlowName(string transactionId, out NodeMethod webMethod, out string flowOperation)
        {
            NodeMethod webMethodPriv = NodeMethod.None;
            string flowOperationPriv = string.Empty;
            string flowName =
                DoSimpleQueryForObjectDelegate<string>(
                    string.Format("{0} t, {1} f", TABLE_NAME, Windsor.Node2008.WNOS.Data.FlowDao.TABLE_NAME),
                    "t.Id;t.FlowId = f.Id", transactionId, "t.Operation;t.WebMethod;f.Code",
                    delegate(IDataReader reader, int rowNum)
                    {
                        flowOperationPriv = reader.GetString(0);
                        webMethodPriv = EnumUtils.ParseEnum<NodeMethod>(reader.GetString(1));
                        return reader.GetString(2);
                    });
            webMethod = webMethodPriv;
            flowOperation = flowOperationPriv;
            return flowName;
        }
        public string GetTransactionFlowName(string transactionId, out NodeMethod webMethod)
        {
            string flowOperation;
            return GetTransactionFlowName(transactionId, out webMethod, out flowOperation);
        }
        public string GetTransactionFlowName(string transactionId)
        {
            NodeMethod webMethod;
            return GetTransactionFlowName(transactionId, out webMethod);
        }
        public EndpointVersionType GetTransactionEndpointVersionType(string transactionId)
        {
            EndpointVersionType version =
                DoSimpleQueryForObjectDelegate<EndpointVersionType>(TABLE_NAME, "Id", transactionId, "EndpointVersion",
                    delegate(IDataReader reader, int rowNum)
                    {
                        return EnumUtils.ParseEnum<EndpointVersionType>(reader.GetString(0));
                    });
            return version;
        }

        public TransactionStatus GetTransactionStatusAndFlowName(string transactionId, out string flowName,
                                                                 out string operation, out NodeMethod webMethod,
                                                                 out EndpointVersionType endpointVersion)
        {
            NodeMethod webMethodPriv = NodeMethod.None;
            string operationPriv = string.Empty;
            EndpointVersionType endpointVersionPriv = EndpointVersionType.Undefined;
            string flowNamePriv = string.Empty;
            TransactionStatus transactionStatus =
                DoSimpleQueryForObjectDelegate<TransactionStatus>(
                    string.Format("{0} t, {1} f", TABLE_NAME, Windsor.Node2008.WNOS.Data.FlowDao.TABLE_NAME),
                    "t.Id;t.FlowId = f.Id", transactionId,
                    "f.Code;t.Operation;t.EndpointVersion;t.WebMethod;t.Status;t.StatusDetail",
                    delegate(IDataReader reader, int rowNum)
                    {
                        flowNamePriv = reader.GetString(0);
                        operationPriv = reader.GetString(1);
                        endpointVersionPriv = EnumUtils.ParseEnum<EndpointVersionType>(reader.GetString(2));
                        webMethodPriv = EnumUtils.ParseEnum<NodeMethod>(reader.GetString(3));
                        TransactionStatus status = new TransactionStatus(transactionId);
                        status.Status = EnumUtils.ParseEnum<CommonTransactionStatusCode>(reader.GetString(4));
                        status.Description = reader.GetString(5);
                        return status;
                    });
            flowName = flowNamePriv;
            operation = operationPriv;
            endpointVersion = endpointVersionPriv;
            webMethod = webMethodPriv;
            return transactionStatus;
        }

        /// <summary>
        /// Get the transaction object for the transaction with the specified transaction id, 
        /// or null if the id is not found.  If doReturnDocuments is true, return a list of 
        /// documents associated with the transaction.
        /// </summary>
        public NodeTransaction GetTransaction(string transactionId, CommonTransactionStatusCode returnDocsWithStatus)
        {
            return GetTransaction(transactionId, new CommonTransactionStatusCode?(returnDocsWithStatus));
        }
        public NodeTransaction GetTransaction(string transactionId)
        {
            return GetTransaction(transactionId, null);
        }
        /// <summary>
        /// Get the transaction object for the transaction with the specified transaction id, 
        /// or null if the id is not found.  If doReturnDocuments is true, return a list of 
        /// documents associated with the transaction.
        /// </summary>
        private NodeTransaction GetTransaction(string transactionId, CommonTransactionStatusCode? returnDocsWithStatus)
        {
            try
            {
                NodeTransaction nodeTransaction =
                    DoSimpleQueryForObjectDelegate<NodeTransaction>(
                        TABLE_NAME, "Id", transactionId,
                        MAP_TRANSACTION_COLUMNS,
                        delegate(IDataReader reader, int rowNum)
                        {
                            return MapTransaction(reader);
                        });
                if (nodeTransaction != null)
                {
                    if (returnDocsWithStatus == null)
                    {
                        nodeTransaction.Documents = _documentManager.GetAllDocuments(transactionId);
                    }
                    else
                    {
                        nodeTransaction.Documents = _documentManager.GetDocumentsByStatus(transactionId, returnDocsWithStatus.Value);
                    }
                }
                return nodeTransaction;
            }
            catch (Spring.Dao.IncorrectResultSizeDataAccessException)
            {
                return null; // Not found
            }
        }
        /// <summary>
        /// Create a new transaction according to the input parameters and return the
        /// transaction id.
        /// </summary>
        public string CreateTransaction(NodeMethod webMethod, EndpointVersionType endpointVersion,
                                        string flowId, string operation, string userCreatorId,
                                        CommonTransactionStatusCode statusCode, string statusDetail,
                                        IDictionary<string, TransactionNotificationType> notifications,
                                        IList<string> recipients, bool sendStatusChangeNotifications)
        {
            string transactionId = IdProvider.Get();
            TransactionTemplate.Execute(delegate
            {
                DoInsert(TABLE_NAME,
                         "Id;FlowId;NetworkId;Status;ModifiedBy;ModifiedOn;StatusDetail;Operation;WebMethod;EndpointVersion",
                         transactionId, flowId, transactionId, statusCode.ToString(),
                         userCreatorId, DateTime.Now, LimitDbText(statusDetail, MAX_DETAIL_CHARS), operation ?? string.Empty,
                         webMethod.ToString(), endpointVersion.ToString());
                AddNotifications(transactionId, notifications);
                AddRecipients(transactionId, recipients);
                return null;
            });
            if (sendStatusChangeNotifications)
            {
                SendStatusChangeNotifications(transactionId);
            }
            return transactionId;
        }
        /// <summary>
        /// Set the network id for the specified transaction.
        /// </summary>

        private readonly string[] NetworkStatusDetailSeparator = new string[] { ";;;" };
        public void GetNetworkStatusDetailsById(string transactionId, out string networkFlowName, out string networkFlowOperation, out string networkStatusDetail)
        {
            string networkStatusDetailText =
                DoSimpleQueryForObjectDelegate<string>(
                    TABLE_NAME, "Id", transactionId, "NetworkEndpointStatusDetail",
                    delegate(IDataReader reader, int rowNum)
                    {
                        return reader.GetString(0);
                    });
            GetNetworkStatusDetails(networkStatusDetailText, out networkFlowName, out networkFlowOperation, out networkStatusDetail);
        }
        private void GetNetworkStatusDetails(string networkStatusDetailText, out string networkFlowName, out string networkFlowOperation, out string networkStatusDetail)
        {
            networkFlowName = networkFlowOperation = networkStatusDetail = null;
            if (!string.IsNullOrEmpty(networkStatusDetailText))
            {
                string[] values = networkStatusDetailText.Split(NetworkStatusDetailSeparator, StringSplitOptions.None);
                if (values.Length > 0)
                {
                    networkFlowName = values[0].Trim();
                    if (networkFlowName.Length == 0)
                    {
                        networkFlowName = null;
                    }
                }
                if (values.Length > 1)
                {
                    networkFlowOperation = values[1].Trim();
                    if (networkFlowOperation.Length == 0)
                    {
                        networkFlowOperation = null;
                    }
                }
                if (values.Length > 2)
                {
                    networkStatusDetail = values[2].Trim();
                    if (networkStatusDetail.Length == 0)
                    {
                        networkStatusDetail = null;
                    }
                }
            }
        }
        private string MakeNetworkStatusDetail(string networkFlowName, string networkFlowOperation, string networkStatusDetail)
        {
            string detailText = string.Format("{0}{1}{2}{3}{4}", networkFlowName ?? string.Empty, NetworkStatusDetailSeparator[0],
                                              networkFlowOperation ?? string.Empty, NetworkStatusDetailSeparator[0], networkStatusDetail ?? string.Empty);
            detailText = LimitDbText(detailText, MAX_DETAIL_CHARS);
            return detailText;
        }
        public void SetNetworkId(string transactionId, string networkId, EndpointVersionType networkEndpointVersion,
                                 string networkEndpointUrl, string networkFlowName, string networkFlowOperation)
        {
            SetNetworkId(transactionId, networkId, networkEndpointVersion, networkEndpointUrl, networkFlowName,
                         networkFlowOperation, null);
        }
        public void SetNetworkId(string transactionId, string networkId, EndpointVersionType networkEndpointVersion,
                                 string networkEndpointUrl, string networkFlowName, string networkFlowOperation, string networkStatusDetail)
        {
            SetNetworkEndpointTransactionInfo(transactionId, networkId, networkEndpointVersion,
                                              networkEndpointUrl, networkFlowName, networkFlowOperation,
                                              networkStatusDetail, null);
        }
        public void SetNetworkIdAndEndpointUserId(string transactionId, string networkId, EndpointVersionType networkEndpointVersion,
                                                  string networkEndpointUrl, string networkFlowName, string networkFlowOperation,
                                                  string networkStatusDetail, string targetEndpointUserId)
        {
            SetNetworkEndpointTransactionInfo(transactionId, networkId, networkEndpointVersion,
                                              networkEndpointUrl, networkFlowName, networkFlowOperation,
                                              networkStatusDetail, null, targetEndpointUserId);
        }
        public void SetNetworkEndpointTransactionInfo(string transactionId, string networkId, EndpointVersionType networkEndpointVersion,
                                                      string networkEndpointUrl, string networkFlowName, string networkFlowOperation,
                                                      string endpointUsername)
        {
            SetNetworkEndpointTransactionInfo(transactionId, networkId, networkEndpointVersion, networkEndpointUrl, networkFlowName,
                                              networkFlowOperation, null, endpointUsername);
        }
        protected void SetNetworkEndpointTransactionInfo(string transactionId, string networkId, EndpointVersionType networkEndpointVersion,
                                                         string networkEndpointUrl, string networkFlowName, string networkFlowOperation,
                                                         string networkStatusDetail, string endpointUsername, string targetEndpointUserId = null)
        {
            object version =
                (networkEndpointVersion == EndpointVersionType.Undefined) ? (object)null : (object)networkEndpointVersion.ToString();
            if (!string.IsNullOrEmpty(endpointUsername) || !string.IsNullOrEmpty(targetEndpointUserId))
            {
                if (!AccountDao.AreEndpointUsersEnabled)
                {
                    throw new ArgException("Internal error: the node is trying to save endpoint user info, but the node metadata database has not been upgraded to support this feature.  Please upgrade your node metadata database to the latest version.");
                }
                if (string.IsNullOrEmpty(targetEndpointUserId))
                {
                    UserAccount userAccount = AccountDao.GetEndpointUserByName(endpointUsername);
                    if (userAccount == null)
                    {
                        throw new ArgException("The node could not find the endpoint user \"{0}\", so information related to the network transaction could not be saved.");
                    }
                    targetEndpointUserId = userAccount.Id;
                }
                DoSimpleUpdateOne(TABLE_NAME, "Id", transactionId,
                                  "NetworkId;NetworkEndpointVersion;NetworkEndpointUrl;NetworkEndpointStatusDetail;NetworkEndpointUser", networkId,
                                  version, networkEndpointUrl, MakeNetworkStatusDetail(networkFlowName, networkFlowOperation,
                                  networkStatusDetail), targetEndpointUserId);
            }
            else
            {
                DoSimpleUpdateOne(TABLE_NAME, "Id", transactionId,
                                  "NetworkId;NetworkEndpointVersion;NetworkEndpointUrl;NetworkEndpointStatusDetail", networkId,
                                  version, networkEndpointUrl, MakeNetworkStatusDetail(networkFlowName, networkFlowOperation,
                                  networkStatusDetail));
            }
        }
        /// <summary>
        /// Set the network status and status details for the specified transaction.
        /// </summary>
        public void SetNetworkIdStatus(string transactionId, CommonTransactionStatusCode networkStatus)
        {
            DoSimpleUpdateOne(TABLE_NAME, "Id", transactionId,
                              "NetworkEndpointStatus", networkStatus.ToString());
        }
        /// <summary>
        /// Set the network status and status details for the specified transaction.
        /// </summary>
        public void SetNetworkIdStatus(string transactionId, CommonTransactionStatusCode networkStatus, string statusDetail)
        {
            string networkFlowName, networkFlowOperation, networkStatusDetail;
            GetNetworkStatusDetailsById(transactionId, out networkFlowName, out networkFlowOperation, out networkStatusDetail);
            DoSimpleUpdateOne(TABLE_NAME, "Id", transactionId,
                              "NetworkEndpointStatus;NetworkEndpointStatusDetail", networkStatus.ToString(),
                              MakeNetworkStatusDetail(networkFlowName, networkFlowOperation, statusDetail));
        }
        public void AppendRealtimeTransactionDetail(string transactionId, string message,
                                                    StatusActivityType statusType)
        {
            string id = IdProvider.Get();
            DoInsert(REALTIME_DETAILS_TABLE_NAME,
                     "Id;TransactionId;StatusType;Detail;ModifiedOn",
                     id, transactionId, statusType.ToString(), message, DateTime.Now);
        }
        public IList<StatusActivityEntry> GetRealtimeTransactionDetails(string transactionId)
        {
            List<StatusActivityEntry> details = null;
            DoSimpleQueryWithRowCallbackDelegate(REALTIME_DETAILS_TABLE_NAME,
                "TransactionId", transactionId, "OrderIndex ASC", "StatusType;Detail;ModifiedOn",
                delegate(IDataReader reader)
                {
                    if (details == null)
                    {
                        details = new List<StatusActivityEntry>();
                    }
                    details.Add(new StatusActivityEntry(EnumUtils.ParseEnum<StatusActivityType>(reader.GetString(0)),
                                                        reader.GetString(1), reader.GetDateTime(2)));
                });
            return details;
        }
        public void ClearRealtimeTransactionDetails(string transactionId)
        {
            DoSimpleDelete(REALTIME_DETAILS_TABLE_NAME, "TransactionId", transactionId);
        }
        /// <summary>
        /// Get the network id of the specified transaction, null if the tranaction is not valid, or an empty
        /// string if there isn't a network id associated with this transaction.
        /// </summary>
        public string GetNetworkId(string transactionId)
        {
            try
            {
                string networkId =
                    DoSimpleQueryForObjectDelegate<string>(
                        TABLE_NAME, "Id", transactionId, "NetworkId",
                        delegate(IDataReader reader, int rowNum)
                        {
                            return reader.GetString(0);
                        });
                return networkId;
            }
            catch (Spring.Dao.IncorrectResultSizeDataAccessException)
            {
                return null; // Not found
            }
        }
        /// <summary>
        /// GetSingleTransactionWithNetworkId
        /// </summary>
        public string GetSingleTransactionWithNetworkId(string networkId)
        {
            try
            {
                string transactionId =
                    DoSimpleQueryForObjectDelegate<string>(
                        TABLE_NAME, "NetworkId", networkId, "Id",
                        delegate(IDataReader reader, int rowNum)
                        {
                            return reader.GetString(0);
                        });
                return transactionId;
            }
            catch (Spring.Dao.IncorrectResultSizeDataAccessException)
            {
                return null; // Not found
            }
        }
        public NodeTransaction GetLastTransaction(string flowName, string flowOperation, IEnumerable<NodeMethod> allowedNodeMethods,
                                                  IEnumerable<CommonTransactionStatusCode> allowedTransactionStatus,
                                                  IEnumerable<CommonTransactionStatusCode> notAllowedTransactionStatus,
                                                  bool loadDocuments, bool loadDocumentsContent)
        {
            try
            {
                List<object> whereValues = new List<object>();
                string whereColumns = string.Empty;
                if (!string.IsNullOrEmpty(flowName))
                {
                    if (whereColumns.Length > 0)
                    {
                        whereColumns += ";";
                    }
                    whereColumns += "f.Code";
                    whereValues.Add(flowName);
                }
                if (!string.IsNullOrEmpty(flowOperation))
                {
                    if (whereColumns.Length > 0)
                    {
                        whereColumns += ";";
                    }
                    whereColumns += "t.Operation";
                    whereValues.Add(flowOperation);
                }
                if (!CollectionUtils.IsNullOrEmpty(allowedNodeMethods))
                {
                    if (whereColumns.Length > 0)
                    {
                        whereColumns += ";";
                    }
                    var list = CollectionUtils.CreateStringListFromEnumerable(allowedNodeMethods);
                    whereColumns += "UPPER(t.WebMethod) IN (UPPER('" + StringUtils.Join("'),UPPER('", list) + "'))";
                }
                if (!CollectionUtils.IsNullOrEmpty(allowedTransactionStatus))
                {
                    if (whereColumns.Length > 0)
                    {
                        whereColumns += ";";
                    }
                    var list = CollectionUtils.CreateStringListFromEnumerable(allowedTransactionStatus);
                    whereColumns += "UPPER(t.Status) IN (UPPER('" + StringUtils.Join("'),UPPER('", list) + "'))";
                }
                if (!CollectionUtils.IsNullOrEmpty(notAllowedTransactionStatus))
                {
                    if (whereColumns.Length > 0)
                    {
                        whereColumns += ";";
                    }
                    var list = CollectionUtils.CreateStringListFromEnumerable(notAllowedTransactionStatus);
                    whereColumns += "UPPER(t.Status) NOT IN (UPPER('" + StringUtils.Join("'),UPPER('", list) + "'))";
                }
                if (whereColumns.Length > 0)
                {
                    whereColumns += ";";
                }
                whereColumns += "t.FlowId = f.Id";

                string mapColumns = "t." + MAP_TRANSACTION_COLUMNS.Replace(";", ";t.");
                NodeTransaction nodeTransaction = null;
                DoSimpleQueryWithTypedCancelableRowCallbackDelegate<NodeTransaction>(
                    string.Format("{0} t, {1} f", TABLE_NAME, Windsor.Node2008.WNOS.Data.FlowDao.TABLE_NAME),
                    whereColumns, whereValues, "t.ModifiedOn DESC", mapColumns,
                    delegate(IDataReader reader)
                    {
                        nodeTransaction = MapTransaction(reader);
                        return false;
                    });

                if (nodeTransaction != null)
                {
                    if (loadDocuments)
                    {
                        nodeTransaction.Documents = _documentManager.GetDocuments(nodeTransaction.Id, loadDocumentsContent);
                    }
                }
                return nodeTransaction;
            }
            catch (Spring.Dao.IncorrectResultSizeDataAccessException)
            {
                return null; // Not found
            }
        }
        /// <summary>
        /// Return a list of ids for all unprocessed Submit transactions.
        /// </summary>
        public IList<string> GetAllUnprocessedSubmitTransactionIds()
        {
            return GetAllUnprocessedTransactionIds(NodeMethod.Submit);
        }
        public IList<NodeTransaction> GetOutstandingNetworkTransactions(DateTime newerThan, IEnumerable<string> getFlowNames,
                                                                        IEnumerable<CommonTransactionStatusCode> notOutstandingCodes)
        {
            if (CollectionUtils.IsNullOrEmpty(notOutstandingCodes))
            {
                notOutstandingCodes = new CommonTransactionStatusCode[] { CommonTransactionStatusCode.Failed, CommonTransactionStatusCode.Processed,
                                                                          CommonTransactionStatusCode.Completed };
            }

            string tableNames = TABLE_NAME + " t";
            string mapColumns = "t." + MAP_TRANSACTION_COLUMNS.Replace(";", ";t.");
            string queryColumns =
                string.Format("t.ModifiedOn >;t.FlowId = f.Id;UPPER(t.Id) <> UPPER(t.NetworkId);t.NetworkEndpointVersion IS NOT NULL;t.NetworkEndpointUrl IS NOT NULL;((t.NetworkEndpointStatus IS NULL) OR (t.NetworkEndpointStatus NOT {0}))",
                              SpringBaseDao.MakeWhereInClause(notOutstandingCodes));
            if (!CollectionUtils.IsNullOrEmpty(getFlowNames))
            {
                string whereClause = "UPPER(f.Code) IN (UPPER('" + StringUtils.Join("'),UPPER('", getFlowNames) + "'))";
                queryColumns += ";" + whereClause;
                tableNames += ";" + FlowDao.TableName + " f";
            }
            List<NodeTransaction> transactions = null;
            DoSimpleQueryWithRowCallbackDelegate(tableNames, queryColumns,
                new object[] { newerThan }, null, mapColumns,
                delegate(IDataReader reader)
                {
                    if (transactions == null)
                    {
                        transactions = new List<NodeTransaction>();
                    }
                    transactions.Add(MapTransaction(reader));
                });
            return transactions;
        }
        public CommonTransactionStatusCode GetNetworkTransactionStatus(string localTransactionId)
        {
            CommonTransactionStatusCode status;
            EndpointVersionType endpointVersion;
            string endpointUrl;
            GetNetworkTransactionStatus(localTransactionId, out status, out endpointVersion, out endpointUrl);
            return status;
        }
        public string GetNetworkTransactionStatus(string localTransactionId, out CommonTransactionStatusCode status,
                                                  out EndpointVersionType endpointVersion, out string endpointUrl)
        {
            status = CommonTransactionStatusCode.Unknown;
            endpointVersion = EndpointVersionType.Undefined;
            endpointUrl = null;
            try
            {
                CommonTransactionStatusCode statusPriv = CommonTransactionStatusCode.Unknown;
                EndpointVersionType endpointVersionPriv = EndpointVersionType.Undefined;
                string endpointUrlPriv = null;
                string endpointNetworkId =
                    DoSimpleQueryForObjectDelegate<string>(
                        TABLE_NAME, "Id", localTransactionId, "NetworkId;NetworkEndpointVersion;NetworkEndpointUrl;NetworkEndpointStatus",
                        delegate(IDataReader reader, int rowNum)
                        {
                            string networkId = reader.GetString(0);
                            endpointVersionPriv = EnumUtils.ParseEnum<EndpointVersionType>(reader.GetString(1));
                            endpointUrlPriv = reader.GetString(2);
                            statusPriv = EnumUtils.ParseEnum<CommonTransactionStatusCode>(reader.GetString(3));
                            return networkId;
                        });
                status = statusPriv;
                endpointVersion = endpointVersionPriv;
                endpointUrl = endpointUrlPriv;
                return endpointNetworkId;
            }
            catch (Spring.Dao.IncorrectResultSizeDataAccessException)
            {
                return null; // Not found
            }
        }
        public string GetNetworkTransactionStatusFromNetworkId(string networkTransactionId, out CommonTransactionStatusCode status,
                                                               out EndpointVersionType endpointVersion, out string endpointUrl)
        {
            status = CommonTransactionStatusCode.Unknown;
            endpointVersion = EndpointVersionType.Undefined;
            endpointUrl = null;
            try
            {
                CommonTransactionStatusCode statusPriv = CommonTransactionStatusCode.Unknown;
                EndpointVersionType endpointVersionPriv = EndpointVersionType.Undefined;
                string endpointUrlPriv = null;
                string transactionId =
                    DoSimpleQueryForObjectDelegate<string>(
                        TABLE_NAME, "NetworkId;UPPER(Id) <> UPPER(NetworkId);NetworkEndpointUrl IS NOT NULL", networkTransactionId,
                        "Id;NetworkEndpointVersion;NetworkEndpointUrl;NetworkEndpointStatus",
                        delegate(IDataReader reader, int rowNum)
                        {
                            string id = reader.GetString(0);
                            endpointVersionPriv = EnumUtils.ParseEnum<EndpointVersionType>(reader.GetString(1));
                            endpointUrlPriv = reader.GetString(2);
                            statusPriv = EnumUtils.ParseEnum<CommonTransactionStatusCode>(reader.GetString(3));
                            return id;
                        });
                status = statusPriv;
                endpointVersion = endpointVersionPriv;
                endpointUrl = endpointUrlPriv;
                return transactionId;
            }
            catch (Spring.Dao.IncorrectResultSizeDataAccessException)
            {
                return null; // Not found
            }
        }
        /// <summary>
        /// Return all distinct operation names.
        /// </summary>
        public ICollection<string> GetAllOperationNames()
        {
            ICollection<string> operationNames = new List<string>();
            DoSimpleQueryWithRowCallbackDelegate(
                TABLE_NAME, null, null, "Operation",
                "DISTINCT Operation",
                delegate(IDataReader reader)
                {
                    string name = reader.GetString(0);
                    if (!string.IsNullOrEmpty(name))
                    {
                        operationNames.Add(reader.GetString(0));
                    }
                });
            return operationNames;
        }

        /// <summary>
        /// Return all distinct operation names.
        /// </summary>
        public ICollection<string> GetAllWebMethodNames()
        {
            ICollection<string> webMethodNames = new List<string>();
            DoSimpleQueryWithRowCallbackDelegate(
                TABLE_NAME, null, null, "WebMethod",
                "DISTINCT WebMethod",
                delegate(IDataReader reader)
                {
                    string name = reader.GetString(0);
                    if (!string.IsNullOrEmpty(name))
                    {
                        webMethodNames.Add(reader.GetString(0));
                    }
                });
            return webMethodNames;
        }
        /// <summary>
        /// Return a list of ids for all unprocessed Notify transactions.
        /// </summary>
        public IList<string> GetAllUnprocessedNotifyTransactionIds()
        {
            return GetAllUnprocessedTransactionIds(NodeMethod.Notify);
        }
        /// <summary>
        /// Return a list of ids for all unprocessed Solicit transactions.
        /// </summary>
        public IList<string> GetAllUnprocessedSolicitTransactionIds()
        {
            return GetAllUnprocessedTransactionIds(NodeMethod.Solicit);
        }
        /// <summary>
        /// Return a list of ids for all unprocessed Task transactions.
        /// </summary>
        public IList<string> GetAllUnprocessedTaskTransactionIds()
        {
            return GetAllUnprocessedTransactionIds(NodeMethod.Task);
        }
        /// <summary>
        /// Return a list of ids for all unprocessed Execute transactions.
        /// </summary>
        public IList<string> GetAllUnprocessedExecuteTransactionIds()
        {
            return GetAllUnprocessedTransactionIds(NodeMethod.Execute);
        }
        /// <summary>
        /// Return a list of ids for all unprocessed transactions.
        /// </summary>
        protected IList<string> GetAllUnprocessedTransactionIds(NodeMethod inWebMethod)
        {
            List<string> transactions = null;
            string validTransactionStatusGroup = GetDbInGroupFromFlagsEnum("Status", UNPROCESSED_STATUS);
            DoSimpleQueryWithRowCallbackDelegate(TABLE_NAME,
                string.Format("WebMethod = '{0}';{1}",
                              inWebMethod.ToString(), validTransactionStatusGroup),
                null, null, "Id",
                delegate(IDataReader reader)
                {
                    if (transactions == null)
                    {
                        transactions = new List<string>();
                    }
                    transactions.Add(reader.GetString(0));
                });
            return transactions;
        }
        /// <summary>
        /// Return a list of ids for all unprocessed documents that are associated with the specified transaction.
        /// </summary>
        public IList<string> GetAllUnprocessedDocumentDbIds(string transactionId)
        {
            return GetAllUnprocessedDocumentIds(transactionId, NodeMethod.Any);
        }
        /// <summary>
        /// Return a list of ids for all unprocessed documents that are associated with the specified transaction.
        /// </summary>
        protected IList<string> GetAllUnprocessedDocumentIds(string transactionId, NodeMethod inWebMethod)
        {
            List<string> ids = null;
            string validDocumentStatusGroup = GetDbInGroupFromFlagsEnum("d.Status", UNPROCESSED_STATUS);
            string whereColumnNames;
            if (inWebMethod == NodeMethod.Any)
            {
                whereColumnNames = string.Format("t.Id;t.Id = d.TransactionId;{0}",
                                                 validDocumentStatusGroup);
            }
            else
            {
                whereColumnNames = string.Format("t.Id;t.WebMethod = '{0}';t.Id = d.TransactionId;{1}",
                                                 inWebMethod.ToString(), validDocumentStatusGroup);
            }
            DoSimpleQueryWithRowCallbackDelegate(
                string.Format("{0} t;{1} d", TABLE_NAME, Windsor.Node2008.WNOS.Data.DocumentDao.TABLE_NAME),
                whereColumnNames,
                new object[] { transactionId }, null, "d.Id",
                delegate(IDataReader reader)
                {
                    if (ids == null)
                    {
                        ids = new List<string>();
                    }
                    ids.Add(reader.GetString(0));
                });
            return ids;
        }
        public DataService GetSubmitDocumentServiceForTransaction(string transactionId, out string flowName,
                                                                  out string operation)
        {
            string flowId = GetTransactionFlowId(transactionId, out flowName, out operation);
            if (flowId == null)
            {
                throw new ArgumentException(string.Format("Could not find a valid flow for the transaction \"{0}\"",
                                                          transactionId));
            }
            return FlowDao.GetSubmitDocumentServiceForFlow(flowId, operation);
        }
        public DataService GetNotifyDocumentServiceForTransaction(string transactionId, out string flowName,
                                                                  out string operation)
        {
            string flowId = GetTransactionFlowId(transactionId, out flowName, out operation);
            if (flowId == null)
            {
                throw new ArgumentException(string.Format("Could not find a valid flow for the transaction \"{0}\"",
                                                          transactionId));
            }
            return FlowDao.GetNotifyDocumentServiceForFlow(flowId, operation);
        }
        public DataService GetQueryServiceForTransaction(string transactionId, out string flowName,
                                                         out string operation, out string requestId)
        {
            return GetDataServiceForTransaction(transactionId, ServiceType.Query, out flowName, out operation,
                                                out requestId);
        }
        public DataService GetSolicitServiceForTransaction(string transactionId, out string flowName,
                                                           out string operation, out string requestId)
        {
            return GetDataServiceForTransaction(transactionId, ServiceType.Solicit, out flowName,
                                                out operation, out requestId);
        }
        public DataService GetTaskServiceForTransaction(string transactionId, out string flowName,
                                                        out string operation, out string requestId)
        {
            return GetDataServiceForTransaction(transactionId, ServiceType.Task, out flowName,
                                                out operation, out requestId);
        }
        public DataService GetExecuteServiceForTransaction(string transactionId, out string flowName,
                                                           out string operation, out string requestId)
        {
            return GetDataServiceForTransaction(transactionId, ServiceType.Execute, out flowName,
                                                out operation, out requestId);
        }
        private DataService GetDataServiceForTransaction(string transactionId, ServiceType serviceType,
                                                         out string flowName, out string operation,
                                                         out string requestId)
        {
            requestId = RequestDao.GetRequestIdFromTransaction(transactionId);
            if (requestId == null)
            {
                throw new ArgumentException(string.Format("Could not find a valid request for the transaction \"{0}\"",
                                                          transactionId));
            }
            string flowId = GetTransactionFlowId(transactionId, out flowName, out operation);
            if (flowId == null)
            {
                throw new ArgumentException(string.Format("Could not find a valid flow for the transaction \"{0}\"",
                                                          transactionId));
            }
            return FlowDao.GetServiceForFlow(flowId, operation, serviceType);
        }
        public void AddNotifications(string transactionId, IDictionary<string, TransactionNotificationType> notifications)
        {
            if (!CollectionUtils.IsNullOrEmpty(notifications))
            {
                foreach (KeyValuePair<string, TransactionNotificationType> pair in notifications)
                {
                    if (RowExists(NOTIFICATION_TABLE_NAME, "Id", "TransactionId;Uri",
                                   transactionId, pair.Key))
                    {
                        DoSimpleUpdateOne(NOTIFICATION_TABLE_NAME, "TransactionId;Uri",
                                          new object[] { transactionId, pair.Key },
                                          "Type", pair.Value.ToString());
                    }
                    else
                    {
                        DoInsert(NOTIFICATION_TABLE_NAME, "Id;TransactionId;Uri;Type",
                                 IdProvider.Get(), transactionId, pair.Key, pair.Value.ToString());
                    }
                }
            }
        }
        public void AddRecipients(string transactionId, IList<string> recipients)
        {
            if (!CollectionUtils.IsNullOrEmpty(recipients))
            {
                foreach (string recipient in recipients)
                {
                    if (RowExists(RECIPIENT_TABLE_NAME, "Id", "TransactionId;Uri",
                                   transactionId, recipient))
                    {
                        // Don't do anything, already there
                    }
                    else
                    {
                        DoInsert(RECIPIENT_TABLE_NAME, "Id;TransactionId;Uri",
                                 IdProvider.Get(), transactionId, recipient);
                    }
                }
            }
        }
        public IDictionary<string, TransactionNotificationType> GetNotifications(string transactionId)
        {
            IDictionary<string, TransactionNotificationType> notifications = null;
            DoSimpleQueryWithRowCallbackDelegate(
                NOTIFICATION_TABLE_NAME, "TransactionId", transactionId,
                null, "Uri;Type",
                delegate(IDataReader reader)
                {
                    if (notifications == null)
                    {
                        notifications = new Dictionary<string, TransactionNotificationType>();
                    }
                    notifications.Add(reader.GetString(0),
                                      EnumUtils.ParseEnum<TransactionNotificationType>(reader.GetString(1)));
                });
            return notifications;
        }
        public IList<string> GetRecipients(string transactionId)
        {
            List<string> recipients = null;
            DoSimpleQueryWithRowCallbackDelegate(
                RECIPIENT_TABLE_NAME, "TransactionId", transactionId,
                null, "Uri",
                delegate(IDataReader reader)
                {
                    if (recipients == null)
                    {
                        recipients = new List<string>();
                    }
                    recipients.Add(reader.GetString(0));
                });
            return recipients;
        }
        public void SendStatusChangeNotifications(string transactionId)
        {
            TransactionStatus status = this.GetTransactionStatus(transactionId);
            SendStatusChangeNotifications(status);
        }
        public void SendStatusChangeNotifications(TransactionStatus status)
        {
            IDictionary<string, TransactionNotificationType> notifications = GetNotifications(status.Id);
            SendStatusChangeNotifications(status, notifications);
        }
        public void SendStatusChangeNotifications(TransactionStatus status,
                                                  IDictionary<string, TransactionNotificationType> notifications)
        {
            TransactionStatusChangeNotifier.Notify(status, notifications);
        }
        #endregion

        #region Properties

        #endregion

        #region ITransactionDao Members

        private const string SQL_TRANSACTION_TYPES =
              "SELECT WebMethod, COUNT(*) AS MethodCount "
            + "FROM NActivity "
            + "WHERE WebMethod IN ('Submit','Download','Query','Solicit','Notify','Execute','GetStatus','GetServices','Schedule') "
            + "GROUP BY WebMethod "
            + "ORDER BY MethodCount DESC";

        /// <summary>
        /// Gets the most active users as recorded in the activity table
        /// </summary>
        /// <param name="maxCount"></param>
        /// <returns></returns>
        public Dictionary<string, string> GetTransactionTypes()
        {
            Dictionary<string, string> rtnList = new Dictionary<string, string>(20);
            try
            {
                Dictionary<string, string> list = new Dictionary<string, string>();
                double totalCount = 0;

                AdoTemplate.QueryWithRowCallbackDelegate(CommandType.Text, SQL_TRANSACTION_TYPES,
                    delegate(IDataReader reader)
                    {
                        //Yes, we could do it all in SQL but there is no clean way to do it in a db-agnostic way
                        object intValue = reader.GetValue(1);
                        int numOfRecords = int.Parse(intValue.ToString());
                        totalCount += numOfRecords;
                        string label = reader.GetString(0);
                        list.Add(string.Format("{0} ({1})", label, numOfRecords), numOfRecords.ToString());
                    }
                );
                // Convert values to percentages
                foreach (KeyValuePair<string, string> pair in list)
                {
                    int value = int.Parse(pair.Value);
                    int percent = (int)Math.Round(((double)value * 100.0) / totalCount);
                    if ((percent == 0) && (value > 0))
                    {
                        percent = 1;
                    }
                    rtnList.Add(pair.Key, percent.ToString());
                }
            }
            catch (Exception)
            {
                throw;
            }

            return rtnList;
        }
        /// <summary>
        /// Return all distinct operation names.
        /// </summary>
        private const string MAP_TRANSACTION_TRACKING_COLUMNS =
            "t.Id;t.FlowId;t.Status;t.ModifiedBy;t.ModifiedOn;t.WebMethod";
        private TransactionType MapTransactionTracking(IDataReader reader,
                                                       IDictionary<string, string> flowIdToNameMap,
                                                       IDictionary<string, string> userIdToNameMap)
        {
            TransactionType transaction = new TransactionType();
            int index = 0;
            transaction.TransactionId = StringUtils.GetStringOrNull(reader.GetString(index++));
            string flowId = StringUtils.GetStringOrNull(reader.GetString(index++));
            string flowName;
            flowIdToNameMap.TryGetValue(flowId, out flowName);
            transaction.DataflowName = StringUtils.GetStringOrNull(flowName);
            transaction.TransactionStatus = StringUtils.GetStringOrNull(reader.GetString(index++));
            if (transaction.TransactionStatus == null)
            {
                transaction.TransactionStatus = CommonTransactionStatusCode.Unknown.ToString();
            }
            transaction.StatusDescription = transaction.TransactionStatus;
            string userId = StringUtils.GetStringOrNull(reader.GetString(index++));
            string userName;
            userIdToNameMap.TryGetValue(userId, out userName);
            transaction.UserId = StringUtils.GetStringOrNull(userName);
            transaction.CreationDateTime = reader.GetDateTime(index++);
            transaction.TransactionType1 = StringUtils.GetStringOrNull(reader.GetString(index++));
            return transaction;
        }
        public TransactionListType1
            DoTransactionTrackingQuery(ICollection<KeyValuePair<TransactionTrackingQueryParameter, object>> queryParameters)
        {
            List<object> whereValues;
            string tableNames;
            string whereColumns =
                ConstructTransactionTrackingWhereValues(queryParameters, out whereValues, out tableNames);
            List<TransactionType> list = null;

            if (!string.IsNullOrEmpty(whereColumns))
            {
                IDictionary<string, string> flowIdToNameMap = _flowDao.GetAllFlowDisplayNames();
                IDictionary<string, string> userIdToNameMap = _accountDao.GetUserIdToNameMap(true, string.Empty);
                DoSimpleQueryWithRowCallbackDelegate(
                    tableNames, whereColumns.ToString(), whereValues, "t.ModifiedOn DESC",
                    "DISTINCT " + MAP_TRANSACTION_TRACKING_COLUMNS,
                    delegate(IDataReader reader)
                    {
                        if (list == null)
                            list = new List<TransactionType>();
                        TransactionType transaction = MapTransactionTracking(reader, flowIdToNameMap, userIdToNameMap);
                        if (transaction != null)
                        {
                            list.Add(transaction);
                        }
                    });
            }
            TransactionListType1 rtnList = new TransactionListType1();
            rtnList.Transaction = (list == null) ? null : list.ToArray();
            return rtnList;
        }
        public TransactionCount
            GetTransactionTrackingQueryCount(ICollection<KeyValuePair<TransactionTrackingQueryParameter, object>> queryParameters)
        {
            List<object> whereValues;
            string tableNames;
            string whereColumns =
                ConstructTransactionTrackingWhereValues(queryParameters, out whereValues, out tableNames);

            int count = GetCounts(tableNames, whereColumns, whereValues);

            TransactionCount transactionCount = new TransactionCount();
            transactionCount.Value = count;
            return transactionCount;
        }
        public TransactionDetailType DoTransactionTrackingDetail(string transactionId)
        {
            KeyValuePair<TransactionTrackingQueryParameter, object>[] queryParameters =
                new KeyValuePair<TransactionTrackingQueryParameter, object>[] 
                {
                    new KeyValuePair<TransactionTrackingQueryParameter, object>(TransactionTrackingQueryParameter.TransactionId,
                                                                                transactionId)
                };
            TransactionListType1 list = DoTransactionTrackingQuery(queryParameters);
            if (CollectionUtils.IsNullOrEmpty(list.Transaction))
            {
                throw new ArgumentException(string.Format("The transaction id \"{0}\" was not found.",
                                                          transactionId));
            }
            TransactionType transaction = list.Transaction[0];
            TransactionDetailType detail = new TransactionDetailType();
            detail.TransactionId = transaction.TransactionId;
            detail.DataflowName = transaction.DataflowName;
            detail.TransactionStatus = transaction.TransactionStatus;
            detail.StatusDescription = transaction.StatusDescription;
            detail.UserId = transaction.UserId;
            detail.CreationDateTime = transaction.CreationDateTime;
            detail.TransactionType1 = transaction.TransactionType1;
            detail.ActivityList = GetTransactionTrackingActivities(transactionId);
            detail.DocumentList = GetTransactionTrackingDocuments(transactionId);
            return detail;
        }
        protected Windsor.Node2008.WNOSDomain.TransactionTracking.ActivityType[]
            GetTransactionTrackingActivities(string transactionId)
        {
            ICollection<Activity> activities = _activityDao.GetActivitiesForTransaction(transactionId, true);
            if (CollectionUtils.IsNullOrEmpty(activities))
            {
                return null;
            }
            List<Windsor.Node2008.WNOSDomain.TransactionTracking.ActivityType> activityTypes =
                new List<Windsor.Node2008.WNOSDomain.TransactionTracking.ActivityType>(20);
            foreach (Activity activity in activities)
            {
                string activityName = GetTransactionTrackingActivityName(activity);
                foreach (ActivityEntry activityEntry in activity.Entries)
                {
                    Windsor.Node2008.WNOSDomain.TransactionTracking.ActivityType activityType =
                        new Windsor.Node2008.WNOSDomain.TransactionTracking.ActivityType();
                    activityType.ActivityName = activityName;
                    activityType.Message = activityEntry.Message;
                    activityType.Timestamp = activityEntry.TimeStamp;
                    activityTypes.Add(activityType);
                }
            }
            return activityTypes.ToArray();
        }
        protected string GetTransactionTrackingActivityName(Activity activity)
        {
            bool emptyFlow = string.IsNullOrEmpty(activity.FlowName);
            bool emptyOperation = string.IsNullOrEmpty(activity.Operation);
            if (!emptyFlow && !emptyOperation)
            {
                return string.Format("{0} - {1} - {2}", activity.Method.ToString(), activity.FlowName,
                                                        activity.Operation);
            }
            else if (!emptyFlow)
            {
                return string.Format("{0} - {1}", activity.Method.ToString(), activity.FlowName);
            }
            else if (!emptyOperation)
            {
                return string.Format("{0} - {1}", activity.Method.ToString(), activity.Operation);
            }
            else
            {
                return activity.Method.ToString();
            }
        }
        protected Windsor.Node2008.WNOSDomain.TransactionTracking.DocumentType[]
            GetTransactionTrackingDocuments(string transactionId)
        {
            IList<Document> documents = _documentManager.GetAllDocuments(transactionId);
            if (CollectionUtils.IsNullOrEmpty(documents))
            {
                return null;
            }
            List<Windsor.Node2008.WNOSDomain.TransactionTracking.DocumentType> documentTypes =
                new List<Windsor.Node2008.WNOSDomain.TransactionTracking.DocumentType>(documents.Count);
            foreach (Document document in documents)
            {
                Windsor.Node2008.WNOSDomain.TransactionTracking.DocumentType documentType =
                    new Windsor.Node2008.WNOSDomain.TransactionTracking.DocumentType();
                documentType.DocumentId = document.Id;
                documentType.DocumentName = document.DocumentName;
                documentType.FileName = document.DocumentName;
                documentType.DocumentType1 = document.Type.ToString();
                documentTypes.Add(documentType);
            }
            return documentTypes.ToArray();
        }
        protected string ConstructTransactionTrackingWhereValues(ICollection<KeyValuePair<TransactionTrackingQueryParameter, object>> queryParameters,
                                                                 out List<object> whereValues, out string tableNames)
        {
            DateTime toDate = DateTime.MaxValue, fromDate = DateTime.MinValue;
            tableNames = TABLE_NAME + " t";
            StringBuilder whereColumns = new StringBuilder("t.ModifiedOn >=;t.ModifiedOn <=");
            whereValues = new List<object>();

            if (!CollectionUtils.IsNullOrEmpty(queryParameters))
            {
                foreach (KeyValuePair<TransactionTrackingQueryParameter, object> pair in queryParameters)
                {
                    switch (pair.Key)
                    {
                        case TransactionTrackingQueryParameter.Dataflow:
                            {
                                string flowId = _flowDao.GetDataFlowIdByName((string)pair.Value);
                                if (string.IsNullOrEmpty(flowId))
                                {
                                    return null;
                                }
                                whereColumns.Append(";t.FlowId");
                                whereValues.Add(flowId);
                            }
                            break;
                        case TransactionTrackingQueryParameter.Status:
                            whereColumns.Append(";t.Status");
                            whereValues.Add(((CommonTransactionStatusCode)pair.Value).ToString());
                            break;
                        case TransactionTrackingQueryParameter.fromDate:
                            fromDate = (DateTime)pair.Value;
                            break;
                        case TransactionTrackingQueryParameter.toDate:
                            toDate = (DateTime)pair.Value;
                            break;
                        case TransactionTrackingQueryParameter.TransactionId:
                            whereColumns.Append(";t.Id");
                            whereValues.Add((string)pair.Value);
                            break;
                        case TransactionTrackingQueryParameter.Type:
                            whereColumns.Append(";t.WebMethod");
                            whereValues.Add(((NodeMethod)pair.Value).ToString());
                            break;
                        case TransactionTrackingQueryParameter.Userid:
                            {
                                string userId = _accountDao.GetUserIdByName((string)pair.Value);
                                if (string.IsNullOrEmpty(userId))
                                {
                                    return null;
                                }
                                whereColumns.Append(";t.ModifiedBy");
                                whereValues.Add(userId);
                            }
                            break;
                        case TransactionTrackingQueryParameter.Organization:
                        case TransactionTrackingQueryParameter.Recipients:
                            // Not implemented yet
                            break;
                    }
                }
            }
            if (toDate == DateTime.MaxValue)
            {
                toDate = DateTime.Now + TimeSpan.FromDays(1);
            }
            else
            {
                toDate = DbUtils.ConstrainDate(toDate);
            }
            if (fromDate == DateTime.MinValue)
            {
                // Default to one year's worth of data
                fromDate = toDate.AddDays(-365);
            }
            else
            {
                fromDate = DbUtils.ConstrainDate(fromDate);
            }
            whereValues.Insert(0, toDate);
            whereValues.Insert(0, fromDate);
            whereColumns.Append(";t.WebMethod IN ('Submit','Download','Query','Solicit','Notify','Execute','GetStatus','GetServices')");
            return whereColumns.ToString();
        }
        #endregion
    }
}
