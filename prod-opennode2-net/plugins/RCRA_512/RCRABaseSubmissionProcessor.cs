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

namespace Windsor.Node2008.WNOSPlugin.RCRA_512
{
    [Serializable]
    public abstract class RCRABaseSubmissionProcessor<T> : BaseWNOSPlugin, ISubmitProcessor where T : class
    {
        protected enum RCRADataDestinationParams
        {
            None,
            [Description("Data Destination")]
            DataDestination,
        }
        protected const string CONFIG_DELETE_DATA_BEFORE_INSERT = "Delete Data Before Insert (True or False)";
        #region fields

        protected static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());

        protected ISerializationHelper _serializationHelper;
        protected ICompressionHelper _compressionHelper;
        protected IDocumentManager _documentManager;
        protected ISettingsProvider _settingsProvider;
        protected IObjectsToDatabase _objectsToDatabase;
        protected ITransactionManager _transactionManager;
        protected bool _deleteExistingDataBeforeInsert = true;

        protected SpringBaseDao _baseDao;

        #endregion

        public RCRABaseSubmissionProcessor()
        {
            ConfigurationArguments.Add(CONFIG_DELETE_DATA_BEFORE_INSERT, null);

            AppendDataProviders<RCRADataDestinationParams>();
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
            AppendAuditLogEvent("Initializing {0} plugin ...", this.GetType().Name);

            GetServiceImplementation(out _serializationHelper);
            GetServiceImplementation(out _compressionHelper);
            GetServiceImplementation(out _documentManager);
            GetServiceImplementation(out _settingsProvider);
            GetServiceImplementation(out _transactionManager);
            GetServiceImplementation(out _objectsToDatabase);

            GetConfigParameter(CONFIG_DELETE_DATA_BEFORE_INSERT, out _deleteExistingDataBeforeInsert);

            _baseDao = ValidateDBProvider(EnumUtils.ToDescription(RCRADataDestinationParams.DataDestination), typeof(NamedNullMappingDataReader));
        }

        protected virtual string DeleteBeforeInsert(T dataToInsert)
        {
            string tableName = _objectsToDatabase.GetTableNameForType(dataToInsert.GetType());
            int numRowsDeleted = _baseDao.AdoTemplate.ExecuteNonQuery(CommandType.Text, "DELETE FROM " + tableName);
            if (numRowsDeleted > 0)
            {
                return string.Format("Deleted {0} row(s) of existing RCRA data from table {1}",
                                     numRowsDeleted.ToString(), tableName);
            }
            else
            {
                return "Did not find any existing RCRA data to delete from the data store";
            }
        }
        protected virtual Dictionary<string, int> Insert(T dataToInsert)
        {
            Dictionary<string, int> tableRowCounts = null;
            if (dataToInsert != null)
            {
                tableRowCounts = _objectsToDatabase.SaveToDatabase(dataToInsert, _baseDao);
            }
            return tableRowCounts;
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

                IHeaderDocumentHelper headerDocumentHelper;
                GetServiceImplementation(out headerDocumentHelper);

                XmlElement loadElement = null;
                Type submissionType = null;
                try
                {
                    AppendAuditLogEvent("Attempting to load document with Exchange Header");
                    headerDocumentHelper.Load(tempXmlFilePath);
                    string operation;
                    loadElement = headerDocumentHelper.GetFirstPayload(out operation);
                    if (loadElement == null)
                    {
                        throw new ArgumentException("The submitted document does not contain a payload");
                    }
                    submissionType = GetSubmissionDataTypeFromHeaderOperation(operation);
                }
                catch (Exception)
                {
                    AppendAuditLogEvent("Document does not contain an Exchange Header");
                    // Assume, for now, that document does not have a header
                    submissionType = GetSubmissionDataTypeFromXmlFile(tempXmlFilePath);
                }

                if (typeof(T) == typeof(object))
                {
                    if (submissionType == null)
                    {
                        throw new ArgumentException("The RCRA submission data type cannot be determined from the Exchange Header nor xml content");
                    }
                }
                else if ( submissionType != null )
                {
                    if (submissionType != typeof(T))
                    {
                        throw new ArgumentException(string.Format("The RCRA submission data type ({0}) does not match the expected data type ({1})",
                                                                  submissionType.Name, typeof(T).Name));
                    }
                }
                AppendAuditLogEvent("Deserializing document data to RCRA data");
                T data = null;
                if (loadElement != null)
                {
                    if ((typeof(T) == typeof(object)))
                    {
                        data = (T)_serializationHelper.Deserialize(loadElement, submissionType);
                    }
                    else
                    {
                        data = _serializationHelper.Deserialize<T>(loadElement);
                    }
                }
                else
                {
                    if ((typeof(T) == typeof(object)))
                    {
                        data = (T)_serializationHelper.Deserialize(tempXmlFilePath, submissionType);
                    }
                    else
                    {
                        data = _serializationHelper.Deserialize<T>(tempXmlFilePath);
                    }
                }

                AppendAuditLogEvent("Submitted document is of type {0}", data.GetType().Name);

                Dictionary<string, int> tableRowCounts = null;

                string deleteMessage = null;
                _baseDao.TransactionTemplate.Execute(delegate
                {
                    if (_deleteExistingDataBeforeInsert)
                    {
                        deleteMessage = DeleteBeforeInsert(data);
                    }

                    tableRowCounts = Insert(data);

                    return null;
                });

                if (!string.IsNullOrEmpty(deleteMessage))
                {
                    AppendAuditLogEvent(deleteMessage);
                }
                AppendAuditLogEvent("Inserted RCRA content into the data store with the following table row counts: {0}",
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
        protected static Type GetSubmissionDataTypeFromHeaderOperation(string operation)
        {
            if (operation != null)
            {
                operation.Trim();
            }
            if (string.IsNullOrEmpty(operation))
            {
                return null;
            }
            operation = operation.ToUpper();
            if (operation.EndsWith("HD"))
            {
                return typeof(HazardousWasteHandlerSubmissionDataType);
            }
            if (operation.EndsWith("CE"))
            {
                return typeof(HazardousWasteCMESubmissionDataType);
            }
            if (operation.EndsWith("PM"))
            {
                return typeof(HazardousWastePermitDataType);
            }
            if (operation.EndsWith("CA"))
            {
                return typeof(HazardousWasteCorrectiveActionDataType);
            }
            if (operation.EndsWith("FA"))
            {
                return typeof(FinancialAssuranceSubmissionDataType);
            }
            if (operation.EndsWith("GS"))
            {
                return typeof(GeographicInformationSubmissionDataType);
            }
            if (operation.EndsWith("RU"))
            {
                return typeof(HazardousWasteReportUnivDataType);
            }
            if (operation.EndsWith("EM"))
            {
                return typeof(HazardousWasteEmanifestsDataType);
            }
            return null;
        }
        protected static Type GetSubmissionDataTypeFromXmlFile(string xmlFilePath)
        {
            try
            {
                using (var reader = new StreamReader(xmlFilePath))
                {
                    var buffer = new char[4096];
                    var charsRead = reader.ReadBlock(buffer, 0, buffer.Length);
                    var xmlString = new string(buffer, 0, charsRead).ToLower();
                    var index = xmlString.IndexOf("<?xml");
                    if (index < 0)
                    {
                        index = xmlString.IndexOf("<");
                    }
                    else
                    {
                        index = xmlString.IndexOf("<", index + 1);
                    }
                    if (index >= 0)
                    {
                        var endIndex = xmlString.IndexOf(" ", index + 1);
                        if (endIndex > 0)
                        {
                            var colonIndex = xmlString.IndexOf(":", index + 1);
                            var startIndex = index + 1;
                            if ((colonIndex > 0) && (colonIndex < endIndex))
                            {
                                startIndex = colonIndex + 1;
                            }
                            var elementName = xmlString.Substring(startIndex, endIndex - startIndex);
                            string operation = null;
                            switch (elementName)
                            {
                                case "hazardouswasteemanifests":
                                    operation = "EM";
                                    break;
                                case "hazardouswastehandlersubmission":
                                    operation = "HD";
                                    break;
                                case "hazardouswastepermitsubmission":
                                    operation = "PM";
                                    break;
                                case "geographicinformationsubmission":
                                    operation = "GS";
                                    break;
                                case "hazardouswastereportuniv":
                                    operation = "RU";
                                    break;
                                case "hazardouswastecorrectiveactionsubmission":
                                    operation = "CA";
                                    break;
                                case "hazardouswastecmesubmission":
                                    operation = "CE";
                                    break;
                                case "financialassurancesubmission":
                                    operation = "FA";
                                    break;
                            }
                            if (operation != null)
                            {
                                return GetSubmissionDataTypeFromHeaderOperation(operation);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            return null;
        }
        protected string CreateTableRowCountsString(Dictionary<string, int> tableRowCounts)
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
        protected Dictionary<string, int> CombineTableRowCounts(Dictionary<string, int> curCounts, Dictionary<string, int> newCounts)
        {
            if (curCounts == null)
            {
                return newCounts;
            }
            foreach (KeyValuePair<string, int> pair in newCounts)
            {
                if (curCounts.ContainsKey(pair.Key))
                {
                    curCounts[pair.Key] = curCounts[pair.Key] + pair.Value;
                }
                else
                {
                    curCounts[pair.Key] = pair.Value;
                }
            }
            return curCounts;
        }
    }
    public class RCRASubmissionProcessor : RCRABaseSubmissionProcessor<object>
    {
    }
    public class RCRAHazardousWasteHandlerSubmissionProcessor : RCRABaseSubmissionProcessor<HazardousWasteHandlerSubmissionDataType>
    {
    }
    public class RCRAHazardousWasteCMESubmissionProcessor : RCRABaseSubmissionProcessor<HazardousWasteCMESubmissionDataType>
    {
    }
    public class RCRAHazardousWasteCorrectiveActionSubmissionProcessor : RCRABaseSubmissionProcessor<HazardousWasteCorrectiveActionDataType>
    {
    }
    public class RCRAHazardousWastePermitSubmissionProcessor : RCRABaseSubmissionProcessor<HazardousWastePermitDataType>
    {
    }
    public class RCRAFinancialAssuranceSubmissionProcessor : RCRABaseSubmissionProcessor<FinancialAssuranceSubmissionDataType>
    {
    }
    public class RCRAGISSubmissionProcessor : RCRABaseSubmissionProcessor<GeographicInformationSubmissionDataType>
    {
    }
    public class RCRAEmanifestsSubmissionProcessor : RCRABaseSubmissionProcessor<HazardousWasteEmanifestsDataType>
    {
    }
}
