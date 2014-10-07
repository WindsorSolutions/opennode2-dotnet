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

namespace Windsor.Node2008.WNOSPlugin.EMTS_30
{
    [Serializable]
    public class GenerateEMTSSubmission : BaseWNOSPlugin, ISolicitProcessor
    {
        protected enum EMTSDataSourceParams
        {
            None,
            [Description("Data Source")]
            DataSource,
        }
        protected enum EMTSConfigParams
        {
            None,
            [Description("Author Name")]
            AuthorName,
        }
        #region fields

        protected static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());

        protected const string PARAM_ORGANIZATION_IDENTIFIER_KEY = "OrganizationIdentifier";

        protected const string EMTS_FLOW_NAME = "EMTS";

        protected IRequestManager _requestManager;
        protected ISerializationHelper _serializationHelper;
        protected ICompressionHelper _compressionHelper;
        protected IDocumentManager _documentManager;
        protected ISettingsProvider _settingsProvider;
        protected IObjectsFromDatabase _objectsFromDatabase;

        protected string _organizationIdentifier;
        protected SpringBaseDao _baseDao;
        protected DataRequest _dataRequest;
        protected string _authorName;

        #endregion

        public GenerateEMTSSubmission()
        {
            AppendConfigArguments<EMTSConfigParams>();

            AppendDataProviders<EMTSDataSourceParams>();
        }

        public virtual void ProcessSolicit(string requestId)
        {
            ProcessSolicitInit(requestId);

            GenerateSubmissionFileAndAddToTransaction();
        }

        public virtual void ProcessSolicitInit(string requestId)
        {
            LazyInit();

            ValidateRequest(requestId);
        }
        protected virtual void LazyInit()
        {
            AppendAuditLogEvent("Initializing {0} plugin ...", this.GetType().Name);

            GetServiceImplementation(out _requestManager);
            GetServiceImplementation(out _serializationHelper);
            GetServiceImplementation(out _compressionHelper);
            GetServiceImplementation(out _documentManager);
            GetServiceImplementation(out _settingsProvider);
            GetServiceImplementation(out _objectsFromDatabase);

            _authorName = ValidateNonEmptyConfigParameter(EnumUtils.ToDescription(EMTSConfigParams.AuthorName));

            _baseDao = ValidateDBProvider(EnumUtils.ToDescription(EMTSDataSourceParams.DataSource), 
                                          typeof(NamedNullMappingDataReader));
        }
        protected virtual void ValidateRequest(string requestId)
        {
            AppendAuditLogEvent("Loading request with id \"{0}\"", requestId);
            _dataRequest = _requestManager.GetDataRequest(requestId);

            AppendAuditLogEvent("Validating request: {0}", _dataRequest);
            GetNonEmptyStringParameter(_dataRequest, PARAM_ORGANIZATION_IDENTIFIER_KEY, 0, out _organizationIdentifier);
            
            AppendAuditLogEvent("Generating submission for organization \"{0}\"", _organizationIdentifier);
        }
        protected string GenerateSubmissionFileAndAddToTransaction()
        {
            Dictionary<string, DbAppendSelectWhereClause> selectClauses = new Dictionary<string, DbAppendSelectWhereClause>();
            selectClauses.Add("EMTS_EMTS",
                new DbAppendSelectWhereClause(_baseDao, "ORG_IDEN = ?", _organizationIdentifier));

            List<EMTSDataType> dataList = _objectsFromDatabase.LoadFromDatabase<EMTSDataType>(_baseDao, selectClauses);

            if (CollectionUtils.IsNullOrEmpty(dataList))
            {
                throw new ArgumentException(string.Format("No EMTS data was found to submit for organization \"{0}\"", _organizationIdentifier));
            }
            else if (dataList.Count > 1)
            {
                throw new ArgumentException(string.Format("More than one set of EMTS data was found for organization \"{0}\"", _organizationIdentifier));
            }
            else
            {
                EMTSDataType data = dataList[0];
                AppendAuditLogEvent(GetSubmissionResultsString(data));
                return GenerateSubmissionFileAndAddToTransaction(data);
            }
        }
        protected string GetSubmissionResultsString(EMTSDataType data)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Found the following EMTS submission data: ");
            int i = 0;
            AppendCountString("Generate Transaction Details", data.GenerateTransactionDetail, ++i == 1, sb);
            AppendCountString("Separate Transaction Details", data.SeparateTransactionDetail, ++i == 1, sb);
            AppendCountString("Sell Transaction Details", data.SellTransactionDetail, ++i == 1, sb);
            AppendCountString("Buy Transaction Details", data.BuyTransactionDetail, ++i == 1, sb);
            AppendCountString("Retire Transaction Details", data.RetireTransactionDetail, ++i == 1, sb);
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
        protected string GenerateSubmissionFile(EMTSDataType data)
        {
            string tempZipFilePath = _settingsProvider.NewTempFilePath(".zip");
            string tempXmlFilePath = _settingsProvider.NewTempFilePath(".xml");
            try
            {
                _serializationHelper.Serialize(data, tempXmlFilePath);

                AppendAuditLogEvent("Generating submission file (with an exchange header) from results");

                IHeaderDocument2Helper headerDocumentHelper;
                GetServiceImplementation(out headerDocumentHelper);
                // Configure the submission header helper
                headerDocumentHelper.Configure(_authorName, _settingsProvider.NodeOrganizationName, EMTS_FLOW_NAME,
                                               EMTS_FLOW_NAME, string.Empty, string.Empty, null);

                string tempXmlFilePath2 = _settingsProvider.NewTempFilePath(".xml");
                try
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(tempXmlFilePath);

                    headerDocumentHelper.AddPayload(string.Empty, doc.DocumentElement);

                    headerDocumentHelper.Serialize(tempXmlFilePath2);

                    _compressionHelper.CompressFile(tempXmlFilePath2, tempZipFilePath);
                }
                finally
                {
                    FileUtils.SafeDeleteFile(tempXmlFilePath2);
                }
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
        protected string GenerateSubmissionFileAndAddToTransaction(EMTSDataType data)
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
    }
}
