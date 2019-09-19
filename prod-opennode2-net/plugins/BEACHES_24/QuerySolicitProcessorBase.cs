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
using System.Text.RegularExpressions;
using Windsor.Commons.NodeDomain;
using System.Collections;

namespace Windsor.Node2008.WNOSPlugin.BEACHES_24
{
    [Serializable]
    public abstract class QuerySolicitProcessorBase : BaseWNOSPlugin, IQueryProcessor, ISolicitProcessor
    {
        protected const string SOURCE_PROVIDER_KEY = "Data Source";

        protected static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());

        protected IRequestManager _requestManager;
        protected ISerializationHelper _serializationHelper;
        protected ICompressionHelper _compressionHelper;
        protected IDocumentManager _documentManager;
        protected ISettingsProvider _settingsProvider;
        protected IObjectsFromDatabase _objectsFromDatabase;

        protected DataRequest _dataRequest;
        protected SpringBaseDao _baseDao;

        protected const string PARAM_VALIDATE_XML_KEY = "ValidateXml";

        public QuerySolicitProcessorBase()
        {
            DataProviders.Add(SOURCE_PROVIDER_KEY, null);
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

            _baseDao = ValidateDBProvider(SOURCE_PROVIDER_KEY);
        }
        protected virtual void ValidateRequest(string requestId)
        {
            AppendAuditLogEvent("Loading request with id \"{0}\"", requestId);

            _dataRequest = _requestManager.GetDataRequest(requestId);

            AppendAuditLogEvent("Validating request: {0}", _dataRequest);
        }
        public virtual void ProcessSolicit(string requestId)
        {
            LazyInit();

            ValidateRequest(requestId);

            CommonContentType contentType;
            var dataFilePath = DoProcessQuerySolicit(out contentType);
        }

        public virtual PaginatedContentResult ProcessQuery(string requestId)
        {
            LazyInit();

            ValidateRequest(requestId);

            CommonContentType contentType;
            var dataFilePath = DoProcessQuerySolicit(out contentType);

            PaginatedContentResult result =
                new PaginatedContentResult(_dataRequest.RowIndex, _dataRequest.MaxRowCount, true, contentType,
                                           File.ReadAllBytes(dataFilePath));

            return result;
        }

        protected virtual string GetQuerySolicitResultsString(BeachDataSubmissionDataType data)
        {
            StringBuilder sb = new StringBuilder();
            if (data == null)
            {
                sb.AppendFormat("Did not find any BEACHES data that matched the query parameters.");
            }
            else
            {
                sb.AppendFormat("Found the following BEACHES data that matched the query parameters: ");
                int i = 0;
                AppendCountString("Organization Details", data.OrganizationDetail, ++i == 1, sb);
                AppendCountString("Beach Details", data.BeachDetail, ++i == 1, sb);
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
        protected virtual string GenerateQuerySolicitFileAndAddToTransaction(BeachDataSubmissionDataType data)
        {
            string querySolicitFile = GenerateQuerySolicitFile(data);
            try
            {
                AppendAuditLogEvent("Attaching submission document to transaction \"{0}\"",
                                    _dataRequest.TransactionId);
                _documentManager.AddDocument(_dataRequest.TransactionId,
                                             CommonTransactionStatusCode.Completed,
                                             null, querySolicitFile);
            }
            catch (Exception e)
            {
                AppendAuditLogEvent("Failed to attach submission document \"{0}\" to transaction \"{1}\" with exception: {2}",
                                    querySolicitFile, _dataRequest.TransactionId, ExceptionUtils.ToShortString(e));
                FileUtils.SafeDeleteFile(querySolicitFile);
                throw;
            }
            return querySolicitFile;
        }
        protected virtual string GenerateQuerySolicitFile(BeachDataSubmissionDataType data)
        {
            string tempXmlFilePath = _settingsProvider.NewTempFilePath(".xml");
            string tempZipFilePath = _settingsProvider.NewTempFilePath(".zip");
            try
            {
                AppendAuditLogEvent("Generating submission file from results");
                _serializationHelper.Serialize(data, tempXmlFilePath);
                _compressionHelper.CompressFile(tempXmlFilePath, tempZipFilePath);
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
        protected abstract string DoProcessQuerySolicit(out CommonContentType contentType);
    }
}
