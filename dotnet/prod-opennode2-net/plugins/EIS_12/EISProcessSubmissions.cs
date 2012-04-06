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
using Windsor.Node2008.WNOSPlugin.CERS_12;

namespace Windsor.Node2008.WNOSPlugin.EIS_12
{
    [Serializable]
    public abstract class EISProcessSubmission : EISPluginBase, ISubmitProcessor
    {
        protected DataCategory _headerDataCategory;

        protected abstract DataCategory DataCategory
        {
            get;
        }

        public EISProcessSubmission()
        {
        }

        /// <summary>
        /// ProcessSubmit
        /// </summary>
        public virtual void ProcessSubmit(string transactionId)
        {
            ProcessSubmitInit();

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

        /// <summary>
        /// ProcessSolicit
        /// </summary>
        protected virtual void ProcessSubmitInit()
        {
            LazyInit();
        }
        protected override void LazyInit()
        {
            AppendAuditLogEvent("Initializing {0} plugin ...", this.GetType().Name);

            base.LazyInit();
        }

        protected abstract void ProcessSubmitDocument(string transactionId, string docId);

        protected virtual CERSDataType GetSubmitDocumentData(string transactionId, string docId)
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

                XmlElement loadElement = null;
                try
                {
                    AppendAuditLogEvent("Attempting to load document with Exchange Header");
                    headerDocumentHelper.Load(tempXmlFilePath);
                    string operation;
                    loadElement = headerDocumentHelper.GetFirstPayload(out operation);
                    if (loadElement == null)
                    {
                        throw new ArgumentException("The submitted document does not contain an EIS payload");
                    }
                    string dataCategoryString =
                        headerDocumentHelper.GetHeaderPropery(DATA_CATEGORY_HEADER_KEY);
                    _headerDataCategory = EnumUtils.ParseEnum<DataCategory>(dataCategoryString);

                    AppendAuditLogEvent("The Exchange Header contains a \"{0}\" property value of \"{1}\"",
                                        DATA_CATEGORY_HEADER_KEY, dataCategoryString ?? "None");
                }
                catch (Exception)
                {
                    AppendAuditLogEvent("Document does not contain an Exchange Header");
                    // Assume, for now, that document does not have a header
                }

                AppendAuditLogEvent("Deserializing document data to CERS data");
                CERSDataType data = null;
                if (loadElement != null)
                {
                    data = _serializationHelper.Deserialize<CERSDataType>(loadElement);
                }
                else
                {
                    data = _serializationHelper.Deserialize<CERSDataType>(tempXmlFilePath);
                }
                data.DataCategory = this.DataCategory;

                AppendAuditLogEvent("Submitted document contains data for data category \"{0}\" and emissions year \"{1}\"",
                                    data.DataCategory, data.EmissionsYear);

                return data;
            }
            finally
            {
                FileUtils.SafeDeleteFile(tempXmlFilePath);
            }
        }
    }
    [Serializable]
    public class EISSubmissionProcessor : EISProcessSubmission
    {
        protected IObjectsToDatabase _objectsToDatabase;

        protected SpringBaseDao _baseDao;

        protected enum EISDataSourceParams
        {
            None,
            [Description("Data Destination")]
            DataDestination,
        }

        public EISSubmissionProcessor()
        {
            AppendDataProviders<EISDataSourceParams>();
        }

        protected override void LazyInit()
        {
            base.LazyInit();

            GetServiceImplementation(out _objectsToDatabase);

            _baseDao = ValidateDBProvider(EnumUtils.ToDescription(EISDataSourceParams.DataDestination), typeof(NamedNullMappingDataReader));
        }
        protected override void ProcessSubmitDocument(string transactionId, string docId)
        {
            try {
                CERSDataType data = GetSubmitDocumentData(transactionId, docId);

                int numRowsDeleted = 0;
                Dictionary<string, int> tableRowCounts = null;

                _baseDao.TransactionTemplate.Execute(delegate
                {
                    numRowsDeleted = _baseDao.DoSimpleDelete("CERS_CERS", "DATA_CATEGORY;EMIS_YEAR", data.DataCategory.ToString(),
                                                             data.EmissionsYear);

                    tableRowCounts = _objectsToDatabase.SaveToDatabase(data, _baseDao);

                    return null;
                });

                if (numRowsDeleted > 0)
                {
                    AppendAuditLogEvent("Deleted {0} existing CERS data from the data store for data category \"{1}\" and emissions year \"{2}\"",
                                        numRowsDeleted.ToString(), data.DataCategory, data.EmissionsYear);
                }
                else
                {
                    AppendAuditLogEvent("Did not delete any existing CERS data from the data store");
                }
                AppendAuditLogEvent("Stored CERS data content with primary key \"{0}\" into data store with the following table row counts: {1}",
                                    data._PK, CreateTableRowCountsString(tableRowCounts));
            }
            catch (Exception e)
            {
                AppendAuditLogEvent("Failed to process document with id \"{0}.\"  EXCEPTION: {1}",
                                    docId.ToString(), ExceptionUtils.ToShortString(e));
                throw;
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
        protected override CERSDataType GetSubmitDocumentData(string transactionId, string docId)
        {
            CERSDataType data = base.GetSubmitDocumentData(transactionId, docId);

            if (_headerDataCategory == DataCategory.None)
            {
                throw new ArgumentException("The DataCategory for the submission document could not be determined");
            }

            return data;
        }
        protected override DataCategory DataCategory
        {
            get { return _headerDataCategory; }
        }
    }
    [Serializable]
    public class EISFacilityInventorySubmissionProcessor : EISSubmissionProcessor
    {
        protected override DataCategory DataCategory
        {
            get
            {
                return DataCategory.FacilityInventory;
            }
        }
    }
    [Serializable]
    public class EISEventSubmissionProcessor : EISSubmissionProcessor
    {
        protected override DataCategory DataCategory
        {
            get
            {
                return DataCategory.Event;
            }
        }
    }
    [Serializable]
    public class EISOnroadSubmissionProcessor : EISSubmissionProcessor
    {
        protected override DataCategory DataCategory
        {
            get
            {
                return DataCategory.Onroad;
            }
        }
    }
    [Serializable]
    public class EISNonroadSubmissionProcessor : EISSubmissionProcessor
    {
        protected override DataCategory DataCategory
        {
            get
            {
                return DataCategory.Nonroad;
            }
        }
    }
    [Serializable]
    public class EISPointSubmissionProcessor : EISSubmissionProcessor
    {
        protected override DataCategory DataCategory
        {
            get
            {
                return DataCategory.Point;
            }
        }
    }
    [Serializable]
    public class EISNonpointSubmissionProcessor : EISSubmissionProcessor
    {
        protected override DataCategory DataCategory
        {
            get
            {
                return DataCategory.Nonpoint;
            }
        }
    }
    [Serializable]
    public class EISOnroadNonroadActivitySubmissionProcessor : EISSubmissionProcessor
    {
        protected override DataCategory DataCategory
        {
            get
            {
                return DataCategory.OnroadNonroadActivity;
            }
        }
    }
}
