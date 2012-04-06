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

namespace Windsor.Node2008.WNOSPlugin.BEACHES_21
{
    [Serializable]
    public abstract class BasePerformBeachesSubmission : BaseBeachesSubmissionPlugin
    {
        #region fields

        protected ISerializationHelper _serializationHelper;
        protected ICompressionHelper _compressionHelper;
        protected IDocumentManager _documentManager;
        protected IObjectsFromDatabase _objectsFromDatabase;
        protected IObjectsToDatabase _objectsToDatabase;

        protected bool _updateSentToEpaFlag = true;

        protected const string PARAM_UPDATE_SENT_TO_EPA_FLAG = "UpdateSentToEPAFlag";

        #endregion

        public BasePerformBeachesSubmission()
        {
            _useSubmissionHistoryTable = true; // By default
        }

        public override void ProcessTask(string requestId)
        {
            base.ProcessTask(requestId);

            CheckForPendingSubmissions(_baseDao);

            PrepareForSubmission();

            string recordId = SetPendingSubmission(_baseDao, _scheduleRunDate);

            try
            {
                PerformSubmission();

                UpdatePendingSubmissionInfo(_baseDao, recordId, _dataRequest.TransactionId);
            }
            catch (Exception)
            {
                SetSubmissionFailed(_baseDao, recordId);
                throw;
            }
        }
        protected override void LazyInit()
        {
            base.LazyInit();

            GetServiceImplementation(out _serializationHelper);
            GetServiceImplementation(out _compressionHelper);
            GetServiceImplementation(out _documentManager);
            GetServiceImplementation(out _objectsFromDatabase);
            GetServiceImplementation(out _objectsToDatabase);
        }
        protected override void ValidateRequest(string requestId)
        {
            base.ValidateRequest(requestId);

            TryGetParameter(_dataRequest, PARAM_UPDATE_SENT_TO_EPA_FLAG, 0, ref _updateSentToEpaFlag);
            TryGetParameter(_dataRequest, PARAM_USE_SUBMISSION_HISTORY_TABLE_KEY, 1, ref _useSubmissionHistoryTable);
        }
        protected virtual string GenerateSubmissionFile(BeachDataSubmissionDataType data)
        {
            ISettingsProvider settingsProvider;
            GetServiceImplementation(out settingsProvider);

            string tempXmlFilePath = settingsProvider.NewTempFilePath(".xml");
            try
            {
                AppendAuditLogEvent("Generating submission file from results");
                _serializationHelper.Serialize(data, tempXmlFilePath);
            }
            catch (Exception)
            {
                FileUtils.SafeDeleteFile(tempXmlFilePath);
                throw;
            }
            return tempXmlFilePath;
        }
        protected virtual string GenerateSubmissionFileAndAddToTransaction(BeachDataSubmissionDataType data)
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
        protected virtual void PerformSubmission()
        {
            const string BEACH_ACTIVITY_SELECT = "SENTTOEPA IS NULL OR SENTTOEPA <> 'Y'";

            Dictionary<string, DbAppendSelectWhereClause> selectClauses = new Dictionary<string, DbAppendSelectWhereClause>();

            selectClauses.Add("NOTIF_BEACHACTIVITY", new DbAppendSelectWhereClause(_baseDao, BEACH_ACTIVITY_SELECT));

            AppendAuditLogEvent("Querying database for BEACHES data ...");
            List<OrganizationDetailDataType> organizationDetails = _objectsFromDatabase.LoadFromDatabase<OrganizationDetailDataType>(_baseDao, null);
            List<BeachDetailDataType> beachDetails = _objectsFromDatabase.LoadFromDatabase<BeachDetailDataType>(_baseDao, selectClauses);
            List<BeachProcedureDetailDataType> beachProcedureDetails = _objectsFromDatabase.LoadFromDatabase<BeachProcedureDetailDataType>(_baseDao, null);
            List<YearCompletionIndicatorDataType> yearCompletionIndicators = _objectsFromDatabase.LoadFromDatabase<YearCompletionIndicatorDataType>(_baseDao, null);

            if (!CollectionUtils.IsNullOrEmpty(yearCompletionIndicators) && (yearCompletionIndicators.Count > 1))
            {
                throw new ArgumentException(string.Format("More than one \"Year Completion Indicator\" was found to submit"));
            }

            BeachDataSubmissionDataType data = new BeachDataSubmissionDataType();
            data.YearCompletionIndicators = CollectionUtils.IsNullOrEmpty(yearCompletionIndicators) ? null : yearCompletionIndicators[0];
            data.BeachDetail = CollectionUtils.IsNullOrEmpty(beachDetails) ? null : beachDetails.ToArray();
            data.BeachProcedureDetail = CollectionUtils.IsNullOrEmpty(beachProcedureDetails) ? null : beachProcedureDetails.ToArray();
            data.OrganizationDetail = CollectionUtils.IsNullOrEmpty(organizationDetails) ? null : organizationDetails.ToArray();

            AppendAuditLogEvent(GetSubmissionResultsString(data));
            data.AfterLoadFromDatabase();

            string submissionFile = GenerateSubmissionFileAndAddToTransaction(data);

            ProcessSubmissionFile(submissionFile);

            if (_updateSentToEpaFlag)
            {
                int rowsSet = _baseDao.AdoTemplate.ExecuteNonQuery(CommandType.Text, "UPDATE NOTIF_BEACHACTIVITY SET SENTTOEPA = 'Y' WHERE " + BEACH_ACTIVITY_SELECT);

                AppendAuditLogEvent("Set {0} NOTIF_BEACHACTIVITY.SENTTOEPA columns to 'Y'", rowsSet.ToString());
            }
            else
            {
                AppendAuditLogEvent("{0} param is false, did not update any NOTIF_BEACHACTIVITY.SENTTOEPA columns", PARAM_UPDATE_SENT_TO_EPA_FLAG);
            }
        }
        protected virtual void PrepareForSubmission()
        {
        }
        protected virtual void ProcessSubmissionFile(string submissionFile)
        {
        }
        protected virtual string GetSubmissionResultsString(BeachDataSubmissionDataType data)
        {
            StringBuilder sb = new StringBuilder();
            if (data == null)
            {
                sb.AppendFormat("Did not find any BEACHES submission data.");
            }
            else
            {
                sb.AppendFormat("Found the following BEACHES submission data: ");
                int i = 0;
                AppendCountString("Organization Details", data.OrganizationDetail, ++i == 1, sb);
                AppendCountString("Beach Details", data.BeachDetail, ++i == 1, sb);
                AppendCountString("Beach Procedure Details", data.BeachProcedureDetail, ++i == 1, sb);
                int beachActivityCount = 0;
                CollectionUtils.ForEach(data.BeachDetail, delegate(BeachDetailDataType beachDetailDataType)
                {
                    if (beachDetailDataType.BeachActivityDetail != null)
                    {
                        beachActivityCount += beachDetailDataType.BeachActivityDetail.Length;
                    }
                });
                sb.AppendFormat(", {0} {1}", beachActivityCount.ToString(), "Beach Activities");
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
