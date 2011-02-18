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

namespace Windsor.Node2008.WNOSPlugin.ICISNPDES_20
{
    [Serializable]
    public class SubmissionProcessor : BaseWNOSPlugin, ISubmitProcessor
    {
        protected enum ICISNPDESDataSourceParams
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
            AppendDataProviders<ICISNPDESDataSourceParams>();
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
            AppendAuditLogEvent("Initializing ICISNPDES plugin ...");

            GetServiceImplementation(out _serializationHelper);
            GetServiceImplementation(out _compressionHelper);
            GetServiceImplementation(out _documentManager);
            GetServiceImplementation(out _settingsProvider);
            GetServiceImplementation(out _transactionManager);
            GetServiceImplementation(out _objectsToDatabase);

            _baseDao = ValidateDBProvider(EnumUtils.ToDescription(ICISNPDESDataSourceParams.DataDestination), typeof(NamedNullMappingDataReader));
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

                AppendAuditLogEvent("Deserializing document data to ICIS-NPDES data");
                Windsor.Node2008.WNOSPlugin.ICISNPDES_20.Document data = 
                    _serializationHelper.Deserialize<Windsor.Node2008.WNOSPlugin.ICISNPDES_20.Document>(tempXmlFilePath);

                AppendAuditLogEvent("Storing ICIS-NPDES data into database");

                string userId;

                if (data.Header == null)
                {
                    throw new InvalidDataException("Deserialized ICIS-NPDES data does not contain a Header element");
                }
                if (string.IsNullOrEmpty(data.Header.Id))
                {
                    throw new InvalidDataException("Deserialized ICIS-NPDES does not contain a Header Id");
                }
                if (CollectionUtils.IsNullOrEmpty(data.Payload))
                {
                    throw new InvalidDataException("Deserialized ICIS-NPDES does not contain any Payload elements");
                }
                userId = data.Header.Id;
                AppendAuditLogEvent("ICIS-NPDES data contains {0} Payloads for User Id \"{1}\"",
                                    CollectionUtils.Count(data.Payload).ToString(),
                                    userId);

                AppendAuditLogEvent("Deleting existing ICIS-NPDES data from the data store for user id \"{0}\" ...", userId);

                _baseDao.TransactionTemplate.Execute(delegate
                {
                    string tableName = _objectsToDatabase.GetTableNameForType(data.Payload[0].GetType());

                    int numRowsDeleted = _baseDao.DoSimpleDelete(tableName, "USER_ID", userId);

                    if (numRowsDeleted > 0)
                    {
                        AppendAuditLogEvent("Deleted {0} existing ICIS-NPDES data rows from the data store for user id \"{1}\"",
                                            numRowsDeleted.ToString(), userId);
                    }
                    else
                    {
                        AppendAuditLogEvent("Did not find any existing ICIS-NPDES data to delete from the data store for user id \"{0}\"",
                                            userId);
                    }
                    CollectionUtils.ForEach(data.Payload, delegate(Payload payload)
                    {
                        payload.UserId = userId;
                        Dictionary<string, int> tableRowCounts = _objectsToDatabase.SaveToDatabase(payload, _baseDao);
                        AppendAuditLogEvent("Stored ICIS-NPDES data content with document primary key \"{0}\" into data store with the following table row counts: {1}",
                                            payload._PK, CreateTableRowCountsString(tableRowCounts));
                    });

                    return null;
                });
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
