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

namespace Windsor.Node2008.WNOSPlugin.BEACHES_21
{
    [Serializable]
    public class SubmissionProcessor : BaseWNOSPlugin, ISubmitProcessor
    {
        protected enum BeachesDataSourceParams
        {
            None,
            [Description("Data Destination")]
            DataDestination,
        }
        #region fields

        protected static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());

        protected ISerializationHelper _serializationHelper;
        protected ICompressionHelper _compressionHelper;
        protected IDocumentManager _documentManager;
        protected ISettingsProvider _settingsProvider;
        protected IObjectsToDatabase _objectsToDatabase;
        protected ITransactionManager _transactionManager;

        protected SpringBaseDao _baseDao;

        #endregion

        public SubmissionProcessor()
        {
            AppendDataProviders<BeachesDataSourceParams>();
        }

        public virtual void ProcessSubmit(string transactionId)
        {
            LazyInit();

            IList<string> documentIds = _documentManager.GetDocumentIds(transactionId);

            if (CollectionUtils.IsNullOrEmpty(documentIds))
            {
                AppendAuditLogEvent("Didn't find any submit documents to process.");
                return;
            }
            AppendAuditLogEvent("Found {0} submit documents to process.", documentIds.Count.ToString());

            foreach (string docId in documentIds)
            {
                ProcessSubmitDocument(transactionId, docId);
            }
        }

        protected virtual void LazyInit()
        {
            AppendAuditLogEvent("Initializing BEACHES plugin ...");

            GetServiceImplementation(out _serializationHelper);
            GetServiceImplementation(out _compressionHelper);
            GetServiceImplementation(out _documentManager);
            GetServiceImplementation(out _settingsProvider);
            GetServiceImplementation(out _transactionManager);
            GetServiceImplementation(out _objectsToDatabase);

            _baseDao = ValidateDBProvider(EnumUtils.ToDescription(BeachesDataSourceParams.DataDestination), typeof(NamedNullMappingDataReader));
        }
        protected void ProcessSubmitDocument(string transactionId, string docId)
        {
            string tempXmlFilePath = _settingsProvider.NewTempFilePath();
            try
            {
                AppendAuditLogEvent("Getting data for document with id \"{0}\"", docId);
                Windsor.Node2008.WNOSDomain.Document document = _documentManager.GetDocument(transactionId, docId, true);
                if (document.IsZipFile)
                {
                    AppendAuditLogEvent("Decompressing document to temporary file");
                    _compressionHelper.UncompressDeep(document.Content, tempXmlFilePath);
                }
                else
                {
                    AppendAuditLogEvent("Writing document data to temporary file");
                    File.WriteAllBytes(tempXmlFilePath, document.Content);
                }

                AppendAuditLogEvent("Deserializing document data to BEACHES data");
                Windsor.Node2008.WNOSPlugin.BEACHES_21.BeachDataSubmissionDataType data =
                    _serializationHelper.Deserialize<Windsor.Node2008.WNOSPlugin.BEACHES_21.BeachDataSubmissionDataType>(tempXmlFilePath);
                data.BeforeSaveToDatabase();

                AppendAuditLogEvent("Storing BEACHES data into database");

                AppendAuditLogEvent("BEACHES data contains {0} Organization Details, {0} Beach Details, and {0} Beach Procedure Details",
                                    CollectionUtils.Count(data.OrganizationDetail).ToString(),
                                    CollectionUtils.Count(data.BeachDetail).ToString(),
                                    CollectionUtils.Count(data.BeachProcedureDetail).ToString());

                AppendAuditLogEvent("Deleting existing BEACHES data from the data store ...");

                int numRowsDeleted = 0;
                Dictionary<string, int> tableRowCounts = null;

                _baseDao.TransactionTemplate.Execute(delegate
                {
                    _baseDao.AdoTemplate.ExecuteNonQuery(CommandType.Text, "DELETE FROM NOTIF_YEARCOMPLETION");
                    _baseDao.AdoTemplate.ExecuteNonQuery(CommandType.Text, "DELETE FROM NOTIF_PROCEDURE");
                    _baseDao.AdoTemplate.ExecuteNonQuery(CommandType.Text, "DELETE FROM NOTIF_BEACH");
                    _baseDao.AdoTemplate.ExecuteNonQuery(CommandType.Text, "DELETE FROM NOTIF_ORGANIZATION");

                    CollectionUtils.ForEach(data.OrganizationDetail, delegate(Windsor.Node2008.WNOSPlugin.BEACHES_21.OrganizationDetailDataType organizationDetailDataType)
                    {
                        Dictionary<string, int> tableRowCountsTemp = _objectsToDatabase.SaveToDatabase(organizationDetailDataType, _baseDao);
                        tableRowCounts = AddTableRowCounts(tableRowCountsTemp, tableRowCounts);
                    });
                    CollectionUtils.ForEach(data.BeachDetail, delegate(Windsor.Node2008.WNOSPlugin.BEACHES_21.BeachDetailDataType beachDetail)
                    {
                        Dictionary<string, int> tableRowCountsTemp = _objectsToDatabase.SaveToDatabase(beachDetail, _baseDao);
                        tableRowCounts = AddTableRowCounts(tableRowCountsTemp, tableRowCounts);
                    });
                    CollectionUtils.ForEach(data.BeachProcedureDetail, delegate(Windsor.Node2008.WNOSPlugin.BEACHES_21.BeachProcedureDetailDataType beachProcedureDetail)
                    {
                        Dictionary<string, int> tableRowCountsTemp = _objectsToDatabase.SaveToDatabase(beachProcedureDetail, _baseDao);
                        tableRowCounts = AddTableRowCounts(tableRowCountsTemp, tableRowCounts);
                    });
                    if (data.YearCompletionIndicators != null)
                    {
                        Dictionary<string, int> tableRowCountsTemp = _objectsToDatabase.SaveToDatabase(data.YearCompletionIndicators, _baseDao);
                        tableRowCounts = AddTableRowCounts(tableRowCountsTemp, tableRowCounts);
                    }

                    return null;
                });

                if (numRowsDeleted > 0)
                {
                    AppendAuditLogEvent("Deleted {0} existing BEACHES data rows from the data store",
                                        numRowsDeleted.ToString());
                }
                else
                {
                    AppendAuditLogEvent("Did not find any existing BEACHES data to delete from the data store");
                }
                AppendAuditLogEvent("Stored BEACHES data content into the data store with the following table row counts: {0}",
                                    CreateTableRowCountsString(tableRowCounts));
            }
            catch (Exception e)
            {
                AppendAuditLogEvent("Failed to process document with id \"{0}.\"  EXCEPTION: {1}",
                                    docId.ToString(), ExceptionUtils.ToShortString(e));
                throw;
            }
            finally
            {
                FileUtils.SafeDeleteFile(tempXmlFilePath);
            }
        }
        private Dictionary<string, int> AddTableRowCounts(Dictionary<string, int> srcRowCounts, Dictionary<string, int> dstRowCounts)
        {
            if (CollectionUtils.IsNullOrEmpty(srcRowCounts))
            {
                return dstRowCounts;
            }
            if (dstRowCounts == null)
            {
                dstRowCounts = new Dictionary<string, int>();
            }
            foreach (KeyValuePair<string, int> pair in srcRowCounts)
            {
                if (dstRowCounts.ContainsKey(pair.Key))
                {
                    dstRowCounts[pair.Key] = dstRowCounts[pair.Key] + pair.Value;
                }
                else
                {
                    dstRowCounts[pair.Key] = pair.Value;
                }
            }
            return dstRowCounts;
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
}
