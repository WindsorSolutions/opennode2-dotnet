#region License
/*
Copyright (c) 2011, The Environmental Council of the States (ECOS)
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
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using Windsor.Commons.Core;
using Windsor.Commons.Logging;
using Windsor.Commons.Spring;
using Windsor.Commons.XsdOrm2;
using Windsor.Node2008.WNOSPlugin;
using Windsor.Node2008.WNOSProviders;

namespace Windsor.Node2008.WNOSPlugin.ATTAINS_10
{
    /// <summary>
    /// Allows an ATTAINS xml file submitted to the node to be deserialized directly into the database.
    /// </summary>
    [Serializable]
    public class SubmissionProcessor : BaseWNOSPlugin, ISubmitProcessor
    {
        protected enum DataSourceParams
        {
            None,
            [Description("Data Source")]
            DataSource,
        }
        protected enum ConfigParams
        {
            None,
            [Description("Delete Data Before Insert (True or False)")]
            DeleteBeforeInset,
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
        protected bool _deleteBeforeInsert;

        #endregion

        public SubmissionProcessor()
        {
            AppendConfigArguments<ConfigParams>();

            AppendDataProviders<DataSourceParams>();
        }

        public virtual void ProcessSubmit(string transactionId)
        {
            // Entry point for submission processor plugin
            
            LazyInit();

            IList<string> documentIds = _documentManager.GetDocumentIds(transactionId);

            if (CollectionUtils.IsNullOrEmpty(documentIds))
            {
                throw new InvalidOperationException("Didn't find any submit documents to process.");
            }
            else if (documentIds.Count > 1)
            {
                throw new InvalidOperationException("More than one document was submitted with the transaction.");
            }

            ProcessSubmitDocument(transactionId, documentIds[0]);
        }

        protected virtual void LazyInit()
        {
            AppendAuditLogEvent("Initializing {0} plugin ...", this.GetType().Name);

            GetServiceImplementation(out _serializationHelper);
            GetServiceImplementation(out _compressionHelper);
            GetServiceImplementation(out _documentManager);
            GetServiceImplementation(out _settingsProvider);
            GetServiceImplementation(out _transactionManager);
            GetServiceImplementation(out _objectsToDatabase);

            GetConfigParameter(EnumUtils.ToDescription(ConfigParams.DeleteBeforeInset), out _deleteBeforeInsert);

            _baseDao = ValidateDBProvider(EnumUtils.ToDescription(DataSourceParams.DataSource), 
                                          typeof(NamedNullMappingDataReader));
        }
        protected void ProcessSubmitDocument(string transactionId, string docId)
        {
            try
            {
                // Load the submission data from the xml file
                Organization data = GetSubmitDocumentData(transactionId, docId);

                int numRowsDeleted = 0;
                Dictionary<string, int> tableRowCounts = null;

                _baseDao.TransactionTemplate.Execute(delegate
                {
                    if (_deleteBeforeInsert)
                    {
                        // Delete existing data from the database
                        numRowsDeleted = _objectsToDatabase.DeleteAllFromDatabase(data.GetType(), _baseDao, typeof(MappingAttributes));
                    }

                    // Insert data into the database
                    tableRowCounts = _objectsToDatabase.SaveToDatabase(data, _baseDao, typeof(MappingAttributes));

                    return null;
                });

                if (numRowsDeleted > 0)
                {
                    AppendAuditLogEvent("Deleted {0} existing ATTAINS elements from the data store", 
                                        numRowsDeleted.ToString());
                }
                else
                {
                    AppendAuditLogEvent("Did not delete any existing ATTAINS data from the data store");
                }
                var pk = _objectsToDatabase.GetPrimaryKeyValueForObject(data, typeof(MappingAttributes));
                AppendAuditLogEvent("Stored ATTAINS data content with primary key \"{0}\" into data store with the following table row counts: {1}",
                                    pk, CreateTableRowCountsString(tableRowCounts));
            }
            catch (Exception e)
            {
                AppendAuditLogEvent("Failed to process document with id \"{0}.\"  EXCEPTION: {1}",
                                    docId.ToString(), ExceptionUtils.ToShortString(e));
                throw;
            }
        }
        protected virtual Organization GetSubmitDocumentData(string transactionId, string docId)
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

                IHeaderDocument2Helper headerDocumentHelper;
                GetServiceImplementation(out headerDocumentHelper);

                // Deserialize the xml file whether or not it has an exchange header
                XmlElement loadElement = null;
                try
                {
                    AppendAuditLogEvent("Attempting to load document with Exchange Header");
                    headerDocumentHelper.Load(tempXmlFilePath);
                    string operation;
                    loadElement = headerDocumentHelper.GetFirstPayload(out operation);
                    if (loadElement == null)
                    {
                        throw new ArgumentException("The submitted document does not contain an ATTAINS payload");
                    }
                }
                catch (Exception)
                {
                    AppendAuditLogEvent("Document does not contain an Exchange Header");
                    // Assume, for now, that document does not have a header
                }

                AppendAuditLogEvent("Deserializing document data to ATTAINS data");
                Organization data = null;
                if (loadElement != null)
                {
                    data = _serializationHelper.Deserialize<Organization>(loadElement);
                }
                else
                {
                    data = _serializationHelper.Deserialize<Organization>(tempXmlFilePath);
                }

                return data;
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
