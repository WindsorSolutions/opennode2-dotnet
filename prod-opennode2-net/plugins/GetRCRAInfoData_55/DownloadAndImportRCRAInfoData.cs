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
using Windsor.Commons.Spring;
using Windsor.Commons.Core;
using Windsor.Commons.NodeDomain;
using Windsor.Commons.NodeClient;
using Windsor.Commons.XsdOrm;

namespace Windsor.Node2008.WNOSPlugin.GetRCRAInfoData_55
{
    [Serializable]
    public class DownloadAndImportRCRAInfoData : BaseGetRCRAInfoData, ITaskProcessor
    {
        protected const string COMPLETED_RESULTS_FILE_NAME = "DatabaseInsertResults.txt";
        protected const string CONFIG_MAX_CHECK_DAYS = "Max Check Status Days (default: 2 days)";
        protected const string CONFIG_STORED_PROC_NAME = "Postprocessing Stored Procedure Name";
        protected const string CONFIG_STORED_PROC_TIMEOUT = "Postprocessing Stored Procedure Execute Timeout (in seconds)";
        protected const string CONFIG_DELETE_DATA_BEFORE_INSERT = "Delete Existing Data Before Insert (True or False)";

        protected const string DATA_DESTINATION = "Data Destination";

        protected const int MAX_MAX_CHECK_DAYS = 14;
        protected const int MIN_MAX_CHECK_DAYS = 2;

        protected IFlowManager _flowManager;
        protected ISerializationHelper _serializationHelper;
        protected ICompressionHelper _compressionHelper;
        protected IDocumentManager _documentManager;
        protected ISettingsProvider _settingsProvider;
        protected IObjectsToDatabase _objectsToDatabase;

        protected string _storedProcName;
        protected int _storedProcTimeout = 300;
        protected SpringBaseDao _baseDao;

        protected string _dataRequestFlowName;
        protected bool _deleteExistingDataBeforeInsert = false;

        protected int _maxCheckDays = 2;

        public DownloadAndImportRCRAInfoData()
        {
            ConfigurationArguments.Add(CONFIG_MAX_CHECK_DAYS, null);
            ConfigurationArguments.Add(CONFIG_STORED_PROC_NAME, null);
            ConfigurationArguments.Add(CONFIG_STORED_PROC_TIMEOUT, null);
            ConfigurationArguments.Add(CONFIG_DELETE_DATA_BEFORE_INSERT, null);

            DataProviders.Add(DATA_DESTINATION, null);
        }
        public virtual void ProcessTask(string requestId)
        {
            LazyInit();

            ValidateRequest(requestId);

            CheckToDeleteExistingData();

            DateTime newerThan = DateTime.Now.AddDays(-_maxCheckDays);
            CommonTransactionStatusCode[] dontGetStatusCodes =
                new CommonTransactionStatusCode[] { CommonTransactionStatusCode.Failed };
            AppendAuditLogEvent("Querying for RCRA solicit transactions that are newer than {0} ...", newerThan.ToString());
            IList<NodeTransaction> outstandingTransactions =
                _transactionManager.GetOutstandingNetworkTransactions(newerThan, new string[] { _dataRequestFlowName }, dontGetStatusCodes);

            if (CollectionUtils.IsNullOrEmpty(outstandingTransactions))
            {
                AppendAuditLogEvent("Did not find any RCRA solicit transactions that are newer than {0}.", newerThan.ToString());
                return;
            }

            bool anyDataInserted = false;
            CollectionUtils.ForEach(outstandingTransactions, delegate(NodeTransaction nodeTransaction)
            {
                if (ProcessOutstandingTransaction(nodeTransaction))
                {
                    anyDataInserted = true;
                }
            });
            if (anyDataInserted)
            {
                ExecuteStoredProc();
            }
        }
        protected virtual void CheckToDeleteExistingData()
        {
            if (_deleteExistingDataBeforeInsert)
            {
                AppendAuditLogEvent("Deleting existing RCRA data from the data store ...");
                int numRowsDeleted = _baseDao.DoSimpleDelete("RCRA_HD_SUBM", null, null);
                numRowsDeleted += _baseDao.DoSimpleDelete("RCRA_CME_SUBM", null, null);
                numRowsDeleted += _baseDao.DoSimpleDelete("RCRA_CA_SUBM", null, null);
                numRowsDeleted += _baseDao.DoSimpleDelete("RCRA_GIS_SUBM", null, null);
                numRowsDeleted += _baseDao.DoSimpleDelete("RCRA_PRM_SUBM", null, null);
                numRowsDeleted += _baseDao.DoSimpleDelete("RCRA_FA_SUBM", null, null);
                numRowsDeleted += _baseDao.DoSimpleDelete("RCRA_RU_SUBM", null, null);

                if (numRowsDeleted > 0)
                {
                    AppendAuditLogEvent("Deleted {0} existing RCRA data rows from the data store", numRowsDeleted.ToString());
                }
                else
                {
                    AppendAuditLogEvent("Did not find any existing RCRA data to delete from the data store");
                }
            }

        }
        protected virtual void ExecuteStoredProc()
        {
            if (string.IsNullOrEmpty(_storedProcName))
            {
                AppendAuditLogEvent("A value for \"{0}\" was not specified", CONFIG_STORED_PROC_NAME);
                return;
            }

            AppendAuditLogEvent("Executing the stored procedure \"{0}\" ...", _storedProcName);
            _baseDao.AdoTemplate.Execute<int>(delegate(DbCommand command)
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = _storedProcName;

                try
                {
                    SpringBaseDao.ExecuteCommandWithTimeout(command, _storedProcTimeout, delegate(DbCommand commandToExecute)
                    {
                        commandToExecute.ExecuteNonQuery();
                    });
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
        protected override void LazyInit()
        {
            base.LazyInit();

            GetServiceImplementation(out _flowManager);
            GetServiceImplementation(out _serializationHelper);
            GetServiceImplementation(out _compressionHelper);
            GetServiceImplementation(out _documentManager);
            GetServiceImplementation(out _settingsProvider);
            GetServiceImplementation(out _objectsToDatabase);

            if (HasDBProvider(DATA_DESTINATION))
            {
                _baseDao = ValidateDBProvider(DATA_DESTINATION, typeof(NamedNullMappingDataReader));
                TryGetConfigParameter(CONFIG_STORED_PROC_NAME, ref _storedProcName);
                TryGetConfigParameter(CONFIG_STORED_PROC_TIMEOUT, ref _storedProcTimeout);
                TryGetConfigParameter(CONFIG_DELETE_DATA_BEFORE_INSERT, ref _deleteExistingDataBeforeInsert);
            }

            TryGetConfigParameter(CONFIG_MAX_CHECK_DAYS, ref _maxCheckDays);
            _maxCheckDays = (_maxCheckDays > MAX_MAX_CHECK_DAYS) ? MAX_MAX_CHECK_DAYS :
                ((_maxCheckDays < MIN_MAX_CHECK_DAYS) ? MIN_MAX_CHECK_DAYS : _maxCheckDays);
        }
        protected override void ValidateRequest(string requestId)
        {
            base.ValidateRequest(requestId);

            _dataRequestFlowName = _flowManager.GetDataFlowNameById(_dataRequest.Service.FlowId);
        }
        protected bool ProcessOutstandingTransaction(NodeTransaction nodeTransaction)
        {
            if (string.IsNullOrEmpty(nodeTransaction.NetworkId) ||
                string.IsNullOrEmpty(nodeTransaction.NetworkEndpointUrl))
            {
                return false;
            }
            try
            {
                if (HasTransactionBeenProcessed(nodeTransaction))
                {
                    return false;
                }
                Type xmlDataType = GetServiceXmlType(nodeTransaction.NetworkOperationName);
                if (xmlDataType == null)
                {
                    throw new ArgumentException(string.Format("This service does not support the RCRA xml service \"{0}\"", nodeTransaction.NetworkOperationName));
                }
                AppendAuditLogEvent("*** Begin processing network solicit transaction \"{0}\" to {1} service \"{2}\" ...",
                                    nodeTransaction.NetworkId, nodeTransaction.NetworkFlowName, nodeTransaction.NetworkOperationName);

                AppendAuditLogEvent("Checking status of the network transaction \"{0}\" associated with the local transaction \"{1}\" ...",
                                    nodeTransaction.NetworkId, nodeTransaction.Id);

                TransactionStatus transactionStatus = _transactionManager.RefreshNetworkStatus(nodeTransaction.Id);
                CommonTransactionStatusCode currentStatus = transactionStatus.Status;

                AppendAuditLogEvent("The network transaction \"{0}\" associated with the local transaction \"{1}\" has a network status of \"{2}\" ...",
                                    nodeTransaction.NetworkId, nodeTransaction.Id, currentStatus.ToString());

                if (currentStatus == CommonTransactionStatusCode.Completed)
                {
                    AppendAuditLogEvent("Attempting to download documents for the network transaction \"{0}\" ...",
                                        nodeTransaction.NetworkId);

                    _transactionManager.DownloadNetworkDocumentsAndAddToTransaction(nodeTransaction.Id, out currentStatus);

                    AppendAuditLogEvent("Any documents associated with the network transaction \"{0}\" were downloaded and saved.",
                                        nodeTransaction.NetworkId);

                    Document document = GetRCRAXmlDocument(nodeTransaction);
                    if (document == null)
                    {
                        AppendAuditLogEvent("A RCRA xml document could not be found for the network transaction \"{0}\"",
                                            nodeTransaction.NetworkId);
                        return false;
                    }
                    else
                    {
                        AppendAuditLogEvent("A RCRA xml document, \"{0},\" was found for the network transaction \"{1}\"",
                                            document.DocumentName, nodeTransaction.NetworkId);
                    }

                    string successMessage = InsertDocumentIntoDatabase(xmlDataType, nodeTransaction, document);

                    SaveStringAndAddToTransaction(successMessage, COMPLETED_RESULTS_FILE_NAME, _settingsProvider,
                                                  null, _documentManager, nodeTransaction.Id, true);
                    return true;
                }
                else if (currentStatus == CommonTransactionStatusCode.Failed)
                {
                    AppendAuditLogEvent("RCRA data associated with solicit transaction \"{0}\" cannot be loading into the database since the status of the transaction is \"{1}\"",
                                        nodeTransaction.NetworkId, currentStatus.ToString());
                    return false;
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
                AppendAuditLogEvent("ERROR: Failed to process network solicit transaction \"{0}\" to {1} service \"{2}\" with exception: {3}.",
                                    nodeTransaction.NetworkId, nodeTransaction.NetworkFlowName, nodeTransaction.NetworkOperationName,
                                    ExceptionUtils.GetDeepExceptionMessage(ex));
                AppendAuditLogEvent("Another attempt to process the network transaction \"{0}\" will be made when the schedule runs again.",
                                    nodeTransaction.NetworkId);
                return false;
            }
        }
        protected virtual string InsertDocumentIntoDatabase(Type xmlDataType, NodeTransaction nodeTransaction, Document document)
        {
            if (_baseDao == null)
            {
                string noInsertMessage = "No data was inserted into the database since a data destination was not configured for the service";
                AppendAuditLogEvent(noInsertMessage);
                return noInsertMessage;
            }
            AppendAuditLogEvent("Loading RCRA content from transaction document \"{0}\" ...",
                                document.DocumentName);
            string operation;
            object xmlData = GetHeaderDocumentContent(xmlDataType, nodeTransaction.Id, document.Id, _settingsProvider,
                                                      _serializationHelper, _compressionHelper, _documentManager,
                                                      out operation);

            AppendAuditLogEvent("Inserting RCRA content into database for document \"{0}\" ...",
                                document.DocumentName);

            try
            {
                Dictionary<string, int> tableRowCounts = _objectsToDatabase.SaveToDatabase(xmlData, _baseDao);
                string tableCountsString = string.Format("Successfully inserted RCRA content into database for document \"{0}\" with table counts: {1}",
                                                         document.DocumentName, CreateTableRowCountsString(tableRowCounts));
                AppendAuditLogEvent(tableCountsString);

                return tableCountsString;
            }
            catch (Exception ex)
            {
                AppendAuditLogEvent("Failed to insert RCRA content into database for document \"{0}\" with exception: {1}",
                                    document.DocumentName, ExceptionUtils.GetDeepExceptionMessage(ex));
                throw;
            }
        }
        protected virtual bool HasTransactionBeenProcessed(NodeTransaction nodeTransaction)
        {
            if (nodeTransaction.NetworkEndpointStatus == CommonTransactionStatusCode.Completed)
            {
                IList<string> docNames = _documentManager.GetAllDocumentNames(nodeTransaction.Id);
                string zippedFileName = Path.ChangeExtension(COMPLETED_RESULTS_FILE_NAME, ".zip");
                return (CollectionUtils.Contains(docNames, COMPLETED_RESULTS_FILE_NAME, StringComparison.OrdinalIgnoreCase) ||
                        CollectionUtils.Contains(docNames, zippedFileName, StringComparison.OrdinalIgnoreCase));
            }
            return false;
        }
        protected virtual Document GetRCRAXmlDocument(NodeTransaction nodeTransaction)
        {
            IList<Document> documents = _documentManager.GetDocuments(nodeTransaction.Id, false);
            Document document = null;
            CollectionUtils.ForEach(documents, delegate(Document checkDocument)
            {
                string extension = Path.GetExtension(checkDocument.DocumentName).ToUpper();
                if ((extension == ".ZIP") || (extension == ".XML"))
                {
                    document = checkDocument;
                }
            });
            return document;
        }
        protected virtual string CreateTableRowCountsString(Dictionary<string, int> tableRowCounts)
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
}