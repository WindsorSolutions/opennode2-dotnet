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
using System.Collections;
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
using System.Runtime.InteropServices;
using System.ComponentModel;
using Windsor.Commons.Core;
using Windsor.Commons.Logging;
using Windsor.Commons.Spring;
using Windsor.Commons.XsdOrm;
using Windsor.Commons.NodeDomain;
using Windsor.Commons.NodeClient;

namespace Windsor.Node2008.WNOSPlugin.ICISNPDES_20
{
    [Serializable]
    public class GenerateDMRSubmission : BaseWNOSPlugin, ISolicitProcessor
    {
        protected enum ICISNPDESDataSourceParams
        {
            None,
            [Description("Data Source")]
            DataSource,
        }
        protected enum EISServiceParams
        {
            None,
            [Description("UserId")]
            UserId,
            [Description("LastPayloadUpdateDate")]
            LastPayloadUpdateDate,
            [Description("UseSubmissionHistoryTable")]
            UseSubmissionHistoryTable,
            [Description("IgnorePreviousSubmissions")]
            IgnorePreviousSubmissions,
        }
        #region fields

        protected static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());

        protected IRequestManager _requestManager;
        protected ISerializationHelper _serializationHelper;
        protected ICompressionHelper _compressionHelper;
        protected IDocumentManager _documentManager;
        protected ISettingsProvider _settingsProvider;
        protected IObjectsFromDatabase _objectsFromDatabase;
        protected IObjectsToDatabase _objectsToDatabase;
        protected ITransactionManager _transactionManager;
        protected INodeEndpointClientFactory _nodeEndpointClientFactory;

        protected SpringBaseDao _baseDao;
        protected DataRequest _dataRequest;
        protected string _userId;
        protected DateTime _lastPayloadUpdateDate = new DateTime(1900, 1, 1);
        protected DateTime _submitDate = DateTime.Now;
        protected bool _ignorePreviousSubmissions = false;

        #endregion

        public GenerateDMRSubmission()
        {
            AppendDataProviders<ICISNPDESDataSourceParams>();
        }

        public virtual void ProcessSolicit(string requestId)
        {
            ProcessSolicitInit(requestId);

            GenerateSubmissionFileAndAddToTransaction();
            
            if (_useSubmissionHistoryTable)
            {
                AddTransactionToSubmissionHistoryTable();
            }
        }

        public virtual void ProcessSolicitInit(string requestId)
        {
            LazyInit();

            ValidateRequest(requestId);
        }
        protected virtual void LazyInit()
        {
            AppendAuditLogEvent("Initializing ICISNPDES plugin ...");

            GetServiceImplementation(out _requestManager);
            GetServiceImplementation(out _transactionManager);
            GetServiceImplementation(out _serializationHelper);
            GetServiceImplementation(out _compressionHelper);
            GetServiceImplementation(out _documentManager);
            GetServiceImplementation(out _settingsProvider);
            GetServiceImplementation(out _objectsFromDatabase);
            GetServiceImplementation(out _objectsToDatabase);
            GetServiceImplementation(out _nodeEndpointClientFactory);

            _baseDao = ValidateDBProvider(EnumUtils.ToDescription(ICISNPDESDataSourceParams.DataSource), typeof(NamedNullMappingDataReader));
            AppendAuditLogEvent("{0} ({1})", EnumUtils.ToDescription(ICISNPDESDataSourceParams.DataSource), _baseDao.DbProvider.ConnectionString);
        }
        protected virtual void ValidateRequest(string requestId)
        {
            AppendAuditLogEvent("Loading request with id \"{0}\"", requestId);
            _dataRequest = _requestManager.GetDataRequest(requestId);

            AppendAuditLogEvent("Validating request: {0}", _dataRequest);

            GetNonEmptyStringParameter(_dataRequest, EnumUtils.ToDescription(EISServiceParams.UserId), 0, out _userId);

            TryGetParameter(_dataRequest, EnumUtils.ToDescription(EISServiceParams.UseSubmissionHistoryTable), 2, 
                            ref _useSubmissionHistoryTable);
            TryGetParameter(_dataRequest, EnumUtils.ToDescription(EISServiceParams.IgnorePreviousSubmissions), 3,
                            ref _ignorePreviousSubmissions);

            if (!TryGetParameter(_dataRequest, EnumUtils.ToDescription(EISServiceParams.LastPayloadUpdateDate), 1,
                                 ref _lastPayloadUpdateDate) && _useSubmissionHistoryTable && !_ignorePreviousSubmissions)
            {
                AppendAuditLogEvent("No value specified for \"{0}\", attempting to get last date from submission history table ...",
                                    EnumUtils.ToDescription(EISServiceParams.LastPayloadUpdateDate));
                if (TryGetLastPayloadUpdateDate())
                {
                    AppendAuditLogEvent("Found value specified for \"{0}\" of \"{1}\" in the submission history table",
                                        EnumUtils.ToDescription(EISServiceParams.LastPayloadUpdateDate),
                                        _lastPayloadUpdateDate.ToString());
                }
            }
            AppendAuditLogEvent("Running with the following service parameters: {0}: {1}, {2}: {3}, {4}: {5}, {6}: {7}",
                                EnumUtils.ToDescription(EISServiceParams.UserId), _userId,
                                EnumUtils.ToDescription(EISServiceParams.LastPayloadUpdateDate), _lastPayloadUpdateDate,
                                EnumUtils.ToDescription(EISServiceParams.UseSubmissionHistoryTable), _useSubmissionHistoryTable,
                                EnumUtils.ToDescription(EISServiceParams.IgnorePreviousSubmissions), _ignorePreviousSubmissions);
        }
        protected bool TryGetLastPayloadUpdateDate()
        {
            Dictionary<string, DbAppendSelectWhereClause> selectClauses = new Dictionary<string, DbAppendSelectWhereClause>();
            selectClauses.Add("ICIS_SUBM_HISTORY",
                new DbAppendSelectWhereClause(_baseDao, "DOCUMENT_HEADER_ID = ?", _userId));

            List<SubmissionHistoryDataType> submissionList = 
                _objectsFromDatabase.LoadFromDatabase<SubmissionHistoryDataType>(_baseDao, selectClauses);
            
            if ( !CollectionUtils.IsNullOrEmpty(submissionList) ) {
                submissionList.Sort(delegate(SubmissionHistoryDataType x, SubmissionHistoryDataType y)
                {
                    return DateTime.Compare(y.SubmitDate, x.SubmitDate);    // DESC
                });
                foreach (SubmissionHistoryDataType submission in submissionList)
                {
                    CommonTransactionStatusCode statusCode;
                    EndpointVersionType endpointVersion;
                    string endpointUrl;

                    string endpointNetworkId =
                        _transactionManager.GetNetworkTransactionStatus(submission.LocalTransactionId, out statusCode,
                                                                        out endpointVersion, out endpointUrl);

                    if ( !string.IsNullOrEmpty(endpointNetworkId) && !string.Equals(endpointNetworkId, submission.LocalTransactionId) )
                    {
                        if ((statusCode != CommonTransactionStatusCode.Processed) && (statusCode != CommonTransactionStatusCode.Completed) &&
                            (statusCode != CommonTransactionStatusCode.Failed))
                        {
                            AppendAuditLogEvent("Found previous submit transaction \"{0}\" for user \"{1}\" that has not completed (current status: {2})",
                                                submission.LocalTransactionId, _userId, statusCode.ToString());
                            AppendAuditLogEvent("Attempting to get status of previous submit transaction \"{0}\" for user \"{1}\"",
                                                submission.LocalTransactionId, _userId);
                            statusCode = UpdateStatusOfNetworkTransaction(submission.LocalTransactionId, endpointNetworkId,
                                                                          endpointUrl, endpointVersion);
                        }
                        if ((statusCode == CommonTransactionStatusCode.Processed) || (statusCode == CommonTransactionStatusCode.Completed))
                        {
                            _lastPayloadUpdateDate = submission.SubmitDate;
                            return true;
                        }
                        else if (statusCode == CommonTransactionStatusCode.Failed)
                        {
                            _lastPayloadUpdateDate = submission.LastPayloadUpdateDate;
                            return true;
                        }
                        else
                        {
                            throw new InvalidOperationException(string.Format("There is a previous submit transaction \"{0}\" for user \"{1}\" that has not completed (current status: {2})",
                                                                              submission.LocalTransactionId, _userId, statusCode.ToString()));
                        }
                    } 
                    else
                    {
                        // What is this, failed submission?  Continue on ...
                    }
                }
            }
            return false;
        }
        protected void AddTransactionToSubmissionHistoryTable()
        {
            SubmissionHistoryDataType submission = new SubmissionHistoryDataType();
            submission.UserId = _userId;
            submission.LastPayloadUpdateDate = _lastPayloadUpdateDate;
            submission.LocalTransactionId = _dataRequest.TransactionId;
            submission.SubmitDate = _submitDate;
            _objectsToDatabase.SaveToDatabase(submission, _baseDao);
        }
        protected string GenerateSubmissionFile(Document data)
        {
            string tempZipFilePath = _settingsProvider.NewTempFilePath(".zip");
            string tempXmlFilePath = _settingsProvider.NewTempFilePath(".xml");
            try
            {
                _serializationHelper.Serialize(data, tempXmlFilePath);
                AppendAuditLogEvent("Generating submission file from results");
                _compressionHelper.CompressFile(tempXmlFilePath, tempZipFilePath);
            }
            catch (Exception)
            {
                FileUtils.SafeDeleteFile(tempZipFilePath);
                throw;
            }
            finally
            {
                FileUtils.SafeDeleteFile(tempXmlFilePath);
            }
            return tempZipFilePath;
        }
        protected string GenerateSubmissionFileAndAddToTransaction(Document data)
        {
            string submitFile = GenerateSubmissionFile(data);
            try
            {
                AppendAuditLogEvent("Attaching submission document to transaction \"{0}\"",
                                    _dataRequest.TransactionId);
                _documentManager.AddDocument(_dataRequest.TransactionId,
                                             CommonTransactionStatusCode.Completed,
                                             null, submitFile);
            }
            catch (Exception e)
            {
                AppendAuditLogEvent("Failed to attach submission document \"{0}\" to transaction \"{1}\" with exception: {2}",
                                    submitFile, _dataRequest.TransactionId, ExceptionUtils.ToShortString(e));
                FileUtils.SafeDeleteFile(submitFile);
                throw;
            }
            return submitFile;
        }
        protected string GenerateSubmissionFileAndAddToTransaction()
        {
            Dictionary<string, DbAppendSelectWhereClause> selectClauses = new Dictionary<string, DbAppendSelectWhereClause>();

            selectClauses.Add("ICIS_DOCUMENT", new DbAppendSelectWhereClause(_baseDao, "ID = ?", _userId));
            selectClauses.Add("ICIS_HEADER_PROPERTY", new DbAppendSelectWhereClause(_baseDao, "DOCUMENT_ID IN (SELECT DOCUMENT_ID FROM ICIS_DOCUMENT WHERE ID = ?)", _userId));
            string payloadSelectString = "(LAST_PAYLOAD_UPDATE_DATE > ?) AND (DOCUMENT_ID IN (SELECT DOCUMENT_ID FROM ICIS_DOCUMENT WHERE ID = ?))";
            selectClauses.Add("ICIS_PAYLOAD_DATA",
                new DbAppendSelectWhereClause(_baseDao, payloadSelectString, _lastPayloadUpdateDate, _userId));
            string dischargeSelectString = string.Format("PAYLOAD_DATA_ID IN (SELECT PAYLOAD_DATA_ID FROM ICIS_PAYLOAD_DATA WHERE {0})", 
                                                         payloadSelectString);
            selectClauses.Add("ICIS_DISCHRG_MONTR_RPT_DATA",
                new DbAppendSelectWhereClause(_baseDao, dischargeSelectString, _lastPayloadUpdateDate, _userId));
            string dischargeChildSelectString = string.Format("DISCHRG_MONTR_RPT_DATA_ID IN (SELECT DISCHRG_MONTR_RPT_DATA_ID FROM ICIS_DISCHRG_MONTR_RPT_DATA WHERE {0})",
                                                              dischargeSelectString);
            selectClauses.Add("ICIS_RPT_PARM",
                new DbAppendSelectWhereClause(_baseDao, dischargeChildSelectString, _lastPayloadUpdateDate, _userId));
            selectClauses.Add("ICIS_CROP_TYPES_HARVESTED",
                new DbAppendSelectWhereClause(_baseDao, dischargeChildSelectString, _lastPayloadUpdateDate, _userId));
            selectClauses.Add("ICIS_CROP_TYPES_PLANTED",
                new DbAppendSelectWhereClause(_baseDao, dischargeChildSelectString, _lastPayloadUpdateDate, _userId));

            AppendAuditLogEvent("Querying database for ICIS-NPDES data for User Id \"{0}\"", _userId);
            List<Document> dataList = _objectsFromDatabase.LoadFromDatabase<Document>(_baseDao, selectClauses);

            if (CollectionUtils.IsNullOrEmpty(dataList))
            {
                throw new ArgumentException(string.Format("No ICIS-NPDES data was found to submit for User Id \"{0}\"", _userId));
            }
            else if (dataList.Count > 1)
            {
                throw new ArgumentException(string.Format("More than one set of ICIS-NPDES data was found to submit for User Id \"{0}\"", _userId));
            }
            else
            {
                Document data = dataList[0];
                if (CollectionUtils.IsNullOrEmpty(data.Payload))
                {
                    AppendAuditLogEvent("No ICIS-NPDES data was found to submit for User Id \"{0}\" that was modified after \"{1}\"",
                                        _userId, _lastPayloadUpdateDate);
                    return null;
                }
                else
                {
                    AppendAuditLogEvent("Found ICIS-NPDES data that contains {0} Payload(s) for User Id \"{1}\"",
                                        CollectionUtils.Count(data.Payload).ToString(), _userId);
                }
                return GenerateSubmissionFileAndAddToTransaction(data);
            }
        }
        protected string GetSubmissionResultsString(Document data)
        {
            StringBuilder sb = new StringBuilder();
            if (data == null)
            {
                sb.AppendFormat("Did not find any ICIS-NPDES submission data.");
            }
            else
            {
                sb.AppendFormat("Found the following ICIS-NPDES submission data: ");
                int i = 0;
                AppendCountString("Payloads", data.Payload, ++i == 1, sb);
            }
            return sb.ToString();
        }
        protected void AppendCountString(string collectionName, ICollection collection, bool isFirst,
                                         StringBuilder sb)
        {
            if (!isFirst)
            {
                sb.Append(", ");
            }
            int count = CollectionUtils.IsNullOrEmpty(collection) ? 0 : collection.Count;
            sb.AppendFormat("{0} {1}", count.ToString(), collectionName);
        }
    }
}
