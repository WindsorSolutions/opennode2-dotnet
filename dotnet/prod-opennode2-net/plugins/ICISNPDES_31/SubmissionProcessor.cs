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
using Windsor.Commons.XsdOrm2;

namespace Windsor.Node2008.WNOSPlugin.ICISNPDES_31
{
    [Serializable]
    public class SubmissionProcessor : BaseWNOSPlugin, ISubmitProcessor
    {
        protected const string DATA_PARAM_DESTINATION = "Data Destination";

        protected const string CONFIG_PARAM_VALIDATE_XML = "Validate Xml (true or false)";
        protected const string CONFIG_PARAM_DELETE_EXISTING_DATA = "Delete Existing Data Before Insert (true or false)";

        protected static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());

        protected ISerializationHelper _serializationHelper;
        protected ICompressionHelper _compressionHelper;
        protected IDocumentManager _documentManager;
        protected ISettingsProvider _settingsProvider;
        protected IObjectsToDatabase _objectsToDatabase;
        protected ITransactionManager _transactionManager;
        protected bool _deleteExistingDataBeforeInsert;
        protected bool _validateXml;

        protected SpringBaseDao _baseDao;

        public SubmissionProcessor()
        {
            DataProviders[DATA_PARAM_DESTINATION] = null;

            ConfigurationArguments[CONFIG_PARAM_DELETE_EXISTING_DATA] = null;
            ConfigurationArguments[CONFIG_PARAM_VALIDATE_XML] = null;
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
            else if (documentIds.Count > 1)
            {
                throw new ArgException("More than one document was submitted to this service.  This service only supports one document submission at a time.");
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

            _baseDao = ValidateDBProvider(DATA_PARAM_DESTINATION, typeof(NamedNullMappingDataReader));

            TryGetConfigParameter(CONFIG_PARAM_DELETE_EXISTING_DATA, ref _deleteExistingDataBeforeInsert);
            TryGetConfigParameter(CONFIG_PARAM_VALIDATE_XML, ref _validateXml);
        }
        protected virtual void ProcessSubmitDocument(string transactionId, string docId)
        {
            string tempXmlFilePath = _settingsProvider.NewTempFilePath();
            try
            {
                AppendAuditLogEvent("Getting data for document with id \"{0}\"", docId);
                Windsor.Node2008.WNOSDomain.Document document = _documentManager.GetDocument(transactionId, docId, true);
                if (_compressionHelper.IsCompressed(document.Content))
                {
                    AppendAuditLogEvent("Decompressing document to temporary file");
                    _compressionHelper.UncompressDeep(document.Content, tempXmlFilePath);
                }
                else
                {
                    AppendAuditLogEvent("Writing document data to temporary file");
                    File.WriteAllBytes(tempXmlFilePath, document.Content);
                }

                if (_validateXml)
                {
                    ValidateXmlFileAndAttachErrorsAndFileToTransaction(tempXmlFilePath, "xml_schema.xml_schema.zip",
                                                                       null, transactionId);
                }

                AppendAuditLogEvent("Deserializing document data to ICIS data");
                XmlReader reader = new NamespaceSpecifiedXmlTextReader("http://www.exchangenetwork.net/schema/icis/3", tempXmlFilePath);
                Windsor.Node2008.WNOSPlugin.ICISNPDES_31.Document data = 
                    _serializationHelper.Deserialize<Windsor.Node2008.WNOSPlugin.ICISNPDES_31.Document>(reader);

                //Windsor.Node2008.WNOSPlugin.ICISNPDES_31.Document data =
                //    _serializationHelper.Deserialize<Windsor.Node2008.WNOSPlugin.ICISNPDES_31.Document>(tempXmlFilePath);

                if (CollectionUtils.IsNullOrEmpty(data.Payload))
                {
                    AppendAuditLogEvent("Deserialized ICIS does not contain any payload elements, exiting plugin");
                    return;
                }
                AppendAuditLogEvent("ICIS data contains {0} payloads", data.Payload.Length.ToString());

                Type mappingAttributesType = typeof(Windsor.Node2008.WNOSPlugin.ICISNPDES_31.MappingAttributes);

                _baseDao.TransactionTemplate.Execute(delegate
                {
                    if (_deleteExistingDataBeforeInsert)
                    {
                        AppendAuditLogEvent("Deleting all existing ICIS payload data from the data store");

                        int numRowsDeleted = _objectsToDatabase.DeleteAllFromDatabase(typeof(Windsor.Node2008.WNOSPlugin.ICISNPDES_31.PayloadData),
                                                                                      _baseDao, mappingAttributesType);
                        if (numRowsDeleted > 0)
                        {
                            AppendAuditLogEvent("Deleted {0} existing ICIS payload data rows from the data store",
                                                numRowsDeleted.ToString());
                        }
                        else
                        {
                            AppendAuditLogEvent("Did not find any existing ICIS payload data to delete from the data store");
                        }
                    }

                    AppendAuditLogEvent("Storing ICIS payload data into database");

                    foreach (Windsor.Node2008.WNOSPlugin.ICISNPDES_31.PayloadData payload in data.Payload)
                    {
                        Dictionary<string, int> tableRowCounts = _objectsToDatabase.SaveToDatabase(payload, _baseDao, mappingAttributesType);

                        AppendAuditLogEvent("Stored ICIS payload data for operation \"{0}\" into data store with the following table row counts: {1}",
                                            payload.Operation.ToString(), CreateTableRowCountsString(tableRowCounts));
                    }

                    return null;
                });
            }
            catch (Exception e)
            {
                AppendAuditLogEvent("Failed to process document with id \"{0}\" with error: {1}",
                                    docId.ToString(), ExceptionUtils.GetDeepExceptionMessage(e));
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
