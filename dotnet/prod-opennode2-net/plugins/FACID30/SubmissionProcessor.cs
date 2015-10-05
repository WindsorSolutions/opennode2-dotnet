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
using Windsor.Commons.Core;
using Windsor.Commons.Logging;
using Windsor.Commons.Spring;
using Windsor.Commons.XsdOrm;
using System.Transactions;

namespace Windsor.Node2008.WNOSPlugin.FACID30
{
    [Serializable]
    public class SubmissionProcessor : FACIDPluginBase, ISubmitProcessor
    {
        protected const string CONFIG_DELETE_DATA_BEFORE_INSERT = "Delete Existing Data Before Insert (True or False)";
        protected const string CONFIG_PARAM_PROC_NAME = "Post-processing Stored Procedure Name";
        protected const string CONFIG_PARAM_PROC_TIMEOUT = "Post-processing Stored Procedure Timeout (in seconds)";

        protected bool _deleteExistingDataBeforeInsert = true;
        protected const string p_fac_dtls_id = "FAC_DTLS_ID";

        protected string _storedProcName = null;
        protected int _storedProcTimeout = 300;

        public SubmissionProcessor()
        {
            ConfigurationArguments.Add(CONFIG_DELETE_DATA_BEFORE_INSERT, null);
            ConfigurationArguments.Add(CONFIG_PARAM_PROC_NAME, null);
            ConfigurationArguments.Add(CONFIG_PARAM_PROC_TIMEOUT, null);
        }

        protected override void LazyInit()
        {
            base.LazyInit();
            
            GetConfigParameter(CONFIG_DELETE_DATA_BEFORE_INSERT, out _deleteExistingDataBeforeInsert);

            _storedProcName = ValidateNonEmptyConfigParameter(CONFIG_PARAM_PROC_NAME);

            TryGetConfigParameter(CONFIG_PARAM_PROC_TIMEOUT, ref _storedProcTimeout);
        }

        public void ProcessSubmit(string transactionId)
        {
            ProcessSubmitInit(transactionId);

            IList<string> documentIds = _documentManager.GetDocumentIds(transactionId);

            if (CollectionUtils.IsNullOrEmpty(documentIds))
            {
                AppendAuditLogEvent("Didn't find any submit documents to process.");
                return;
            }
            AppendAuditLogEvent("Found {0} submit document(s) to process.", documentIds.Count.ToString());

            if (_deleteExistingDataBeforeInsert)
            {
                AppendAuditLogEvent("Deleting existing FACID data from the data store ...");
                int numRowsDeleted = _baseDao.DoSimpleDelete("FACID_FAC_DTLS", null, null);

                if (numRowsDeleted > 0)
                {
                    AppendAuditLogEvent("Deleted {0} existing FACID data rows from the data store");
                }
                else
                {
                    AppendAuditLogEvent("Did not find any existing FACID data to delete from the data store");
                }
            }
            foreach (string docId in documentIds)
            {
                ProcessSubmitDocument(transactionId, docId);
            }
        }
        protected void ProcessSubmitDocument(string transactionId, string docId)
        {
            string operation;
            FacilityDetailsDataType data =
                 GetHeaderDocumentContent<FacilityDetailsDataType>(transactionId, docId, _settingsProvider,
                                                                   _serializationHelper, _compressionHelper,
                                                                   _documentManager, out operation);

            if (CollectionUtils.IsNullOrEmpty(data.FacilityList) &&
                CollectionUtils.IsNullOrEmpty(data.AffiliateList))
            {
                AppendAuditLogEvent("Input submission file with id \"{0}\" does not contain any data",
                                    docId.ToString());
                return;
            }

            AppendAuditLogEvent("Input submission file with id \"{0}\" contains {1} facilities and {2} affiliates.",
                docId.ToString(), (data.FacilityList == null) ? "0" : data.FacilityList.Length.ToString(),
                (data.AffiliateList == null) ? "0" : data.AffiliateList.Length.ToString());

            AppendAuditLogEvent("Loading facility details data into database ...");
            IObjectsToDatabase objectsToDatabase;
            GetServiceImplementation(out objectsToDatabase);

            Dictionary<string, int> insertCounts;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, TimeSpan.FromSeconds(_storedProcTimeout)))
            {
                insertCounts = objectsToDatabase.SaveToDatabase(data, _baseDao);

                CallPostprocessingStoredProc(data.FacilityDetailsId);
            }

            AppendAuditLogEvent(GetRowCountsAuditString(insertCounts));

            AppendAuditLogEvent("Success, added facility details with primary key: {0}!",
                                data.FacilityDetailsId);
        }
        protected virtual void CallPostprocessingStoredProc(string facDtlsId)
        {
            if (_storedProcName == null)
            {
                return;
            }
            IDbParameters parameters = _baseDao.AdoTemplate.CreateDbParameters();
            parameters.AddWithValue(p_fac_dtls_id, facDtlsId);

            ExecStoredProc(_baseDao, _storedProcName, _storedProcTimeout, parameters);
        }
    }
}
