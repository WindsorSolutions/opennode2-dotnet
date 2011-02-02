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
using Windsor.Node2008.WNOSPlugin.WQX2XsdOrm;

namespace Windsor.Node2008.WNOSPlugin.WQX2
{
    [Serializable]
    public abstract class WQXExtractAndSubmission<T> : BasePerformWQXSubmission<T> where T : class
    {
        #region fields
        protected string _storedProcName;
        protected int _commandTimeout = 300;

        protected string _projectId;
        protected string _orgId;
        protected string _orgRecordId;
        #endregion

        public WQXExtractAndSubmission()
        {
            AppendConfigArguments<ExecuteWQXExtract.ConfigArgs>();
        }
        protected override void LazyInit()
        {
            base.LazyInit();

            TryGetConfigParameter(EnumUtils.ToDescription(ExecuteWQXExtract.ConfigArgs.StoredProcedureName), ref _storedProcName);
            TryGetConfigParameter(EnumUtils.ToDescription(ExecuteWQXExtract.ConfigArgs.ExecuteTimeout), ref _commandTimeout);
        }
        protected override void ValidateRequest(string requestId)
        {
            base.ValidateRequest(requestId);

            GetParameter(_dataRequest, EnumUtils.ToDescription(ExecuteWQXExtract.ScheduleParams.OrgId), 0,
                          out _orgId);
            TryGetParameter(_dataRequest, EnumUtils.ToDescription(ExecuteWQXExtract.ScheduleParams.ProjectId), 1,
                            ref _projectId);

            AppendAuditLogEvent("Schedule parameters: {0} ({1}), {2} ({3})", EnumUtils.ToDescription(ExecuteWQXExtract.ScheduleParams.OrgId),
                                _orgId, EnumUtils.ToDescription(ExecuteWQXExtract.ScheduleParams.ProjectId), _projectId);
        }

        protected override void PrepareForSubmission()
        {
            if (!string.IsNullOrEmpty(_storedProcName))
            {
                _scheduleRunDate =
                    ExecuteWQXExtract.DoExtract(this, _baseDao, _storedProcName, _commandTimeout, _orgId, _projectId);
            }
            else
            {
                _scheduleRunDate = DateTime.Now;
            }
        }
        protected override string SetPendingSubmission(SpringBaseDao baseDao, DateTime runDate)
        {
            if (_useSubmissionHistoryTable)
            {
                ExceptionUtils.ThrowIfEmptyString(_submissionHistoryTableName, "_submissionHistoryTableName");
                ExceptionUtils.ThrowIfEmptyString(_submissionHistoryTableProcessingStatusName, "_submissionHistoryTableProcessingStatusName");
                ExceptionUtils.ThrowIfEmptyString(_submissionHistoryTableRunDateName, "_submissionHistoryTableRunDateName");
                ExceptionUtils.ThrowIfEmptyString(_submissionHistoryTablePkName, "_submissionHistoryTablePkName");
                ExceptionUtils.ThrowIfEmptyString(_submissionHistoryTableTransactionIdName, "_submissionHistoryTableTransactionIdName");

                IdProvider idProvider;
                GetServiceImplementation(out idProvider);

                AppendAuditLogEvent("Adding pending submission to history table");
                string recordId = idProvider.Get();
                baseDao.DoInsert(
                    _submissionHistoryTableName,
                    _submissionHistoryTablePkName + ";PARENTID;" + _submissionHistoryTableRunDateName + ";WQXUPDATEDATE;SUBMISSIONTYPE;" +
                    _submissionHistoryTableTransactionIdName + ";" + _submissionHistoryTableProcessingStatusName + ";ORGID",
                    new object[] { recordId, "UNKNOWN", runDate, runDate, _payloadOperation.ToString(), "PENDING",
                                   EnumUtils.ToDescription(CDX_Processing_Status.Pending), _orgId }
                                  );
                return recordId;
            }
            else
            {
                return string.Empty;
            }
        }
        protected override void UpdatePendingSubmissionInfo(SpringBaseDao baseDao, string recordId, string transactionId)
        {
            if (_useSubmissionHistoryTable)
            {
                ExceptionUtils.ThrowIfEmptyString(_submissionHistoryTableName, "_submissionHistoryTableName");
                ExceptionUtils.ThrowIfEmptyString(_submissionHistoryTableTransactionIdName, "_submissionHistoryTableTransactionIdName");
                ExceptionUtils.ThrowIfEmptyString(_submissionHistoryTablePkName, "_submissionHistoryTablePkName");
                ExceptionUtils.ThrowIfEmptyString(_orgRecordId, "_orgRecordId");

                AppendAuditLogEvent("Updating pending submission \"{0}\" in submission history table with TRANSACTIONID = \"{1}\"",
                                    recordId, transactionId);
                baseDao.DoSimpleUpdateOne(
                    _submissionHistoryTableName,
                    _submissionHistoryTablePkName, new object[] { recordId },
                    _submissionHistoryTableTransactionIdName + ";PARENTID", transactionId, _orgRecordId
                        );
            }
        }
    }
    [Serializable]
    public class WQXUpdateInsertExtractAndSubmission : WQXExtractAndSubmission<WQXDataType>
    {
        public WQXUpdateInsertExtractAndSubmission()
        {
            _payloadOperation = EnumUtils.ToDescription(WQXPluginBase.Submission_Type.UpdateInsert);
        }
        protected override List<WQXDataType> GetSubmissionData()
        {
            Dictionary<string, DbAppendSelectWhereClause> selectClauses = new Dictionary<string, DbAppendSelectWhereClause>();

            selectClauses.Add("WQX_ORGANIZATION", new DbAppendSelectWhereClause(_baseDao, "ORGID = ?", _orgId));

            return _objectsFromDatabase.LoadFromDatabase<WQXDataType>(_baseDao, selectClauses);
        }
        protected override void AppendAuditLogCountsString(WQXDataType data)
        {
            _orgRecordId = data.RecordId;

            AppendAuditLogEvent("Found {0} Projects, {1} Activities, {2} Biological Habitat Indexes, {3} Monitoring Locations, {4} Activity Groups, and {5} Results to submit",
                                CollectionUtils.Count(data.Organization.Project).ToString(),
                                CollectionUtils.Count(data.Organization.Activity).ToString(),
                                CollectionUtils.Count(data.Organization.BiologicalHabitatIndex).ToString(),
                                CollectionUtils.Count(data.Organization.MonitoringLocation).ToString(),
                                CollectionUtils.Count(data.Organization.ActivityGroup).ToString(),
                                WQXPluginBase.TotalResultCount(data).ToString());
        }
        protected override string GenerateSubmissionFile(WQXDataType data)
        {
            string filePath = base.GenerateSubmissionFile(data);

            ISettingsProvider settingsProvider;
            GetServiceImplementation(out settingsProvider);

            string attachedBinaryObjectFolder = Path.Combine(settingsProvider.TempFolderPath, Guid.NewGuid().ToString());

            int attachedBinaryFileCount = data.WriteBinaryObjectDataToFolder(attachedBinaryObjectFolder);

            if (attachedBinaryFileCount > 0)
            {
                AppendAuditLogEvent("Found {0} attached binary objects (with content) to submit, building zip file for submission ...",
                                    attachedBinaryFileCount.ToString());
                string tempZipFilePath = settingsProvider.NewTempFilePath(".zip");
                try
                {
                    _compressionHelper.CompressFile(filePath, tempZipFilePath);
                    _compressionHelper.CompressDirectory(tempZipFilePath, attachedBinaryObjectFolder);
                    filePath = tempZipFilePath;
                }
                catch (Exception)
                {
                    FileUtils.SafeDeleteFile(tempZipFilePath);
                    throw;
                }
            }
            return filePath;
        }
    }
    [Serializable]
    public class WQXDeleteExtractAndSubmission : WQXExtractAndSubmission<WQXDeleteDataType>
    {
        public WQXDeleteExtractAndSubmission()
        {
            _payloadOperation = EnumUtils.ToDescription(WQXPluginBase.Submission_Type.Delete);
        }
        protected override List<WQXDeleteDataType> GetSubmissionData()
        {
            Dictionary<string, DbAppendSelectWhereClause> selectClauses = new Dictionary<string, DbAppendSelectWhereClause>();

            selectClauses.Add("WQX_ORGANIZATION", new DbAppendSelectWhereClause(_baseDao, "ORGID = ?", _orgId));

            return _objectsFromDatabase.LoadFromDatabase<WQXDeleteDataType>(_baseDao, selectClauses);
        }
        protected override void AppendAuditLogCountsString(WQXDeleteDataType data)
        {
            if (data.OrganizationDelete != null)
            {
                AppendAuditLogEvent("Found {0} Projects, {1} Activities, {2} Biological Habitat Indexes, {3} Monitoring Locations, {4} Activity Groups to submit",
                                    CollectionUtils.Count(data.OrganizationDelete.ProjectIdentifier).ToString(),
                                    CollectionUtils.Count(data.OrganizationDelete.ActivityIdentifier).ToString(),
                                    CollectionUtils.Count(data.OrganizationDelete.IndexIdentifier).ToString(),
                                    CollectionUtils.Count(data.OrganizationDelete.MonitoringLocationIdentifier).ToString(),
                                    CollectionUtils.Count(data.OrganizationDelete.ActivityGroupIdentifier).ToString());
            }
            else
            {
                AppendAuditLogEvent("Did not find any delete elements to submit");
            }
            _orgRecordId = data.RecordId;
        }
    }
}
