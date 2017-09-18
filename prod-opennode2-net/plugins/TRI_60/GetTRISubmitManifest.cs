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
using Windsor.Commons.NodeDomain;

namespace Windsor.Node2008.WNOSPlugin.TRI6
{
    [Serializable]
    public class GetTRISubmitManifest : BaseWNOSPlugin, IQueryProcessor
    {
        protected const string SOURCE_PROVIDER_KEY = "Data Source";

        protected const string PARAM_SUBMISSION_DATE = "Submission Date";
        protected const string PARAM_TRANSACTION_STATUS = "Transaction Status";

        protected IRequestManager _requestManager;
        protected ISerializationHelper _serializationHelper;
        protected IFlowManager _flowManager;
        protected IDocumentManager _documentManager;

        protected DataRequest _dataRequest;
        protected SpringBaseDao _baseDao;

        protected DateTime _submissionDate = new DateTime(1900, 1, 1);
        protected CommonTransactionStatusCode _transactionStatus = CommonTransactionStatusCode.Unknown;

        public GetTRISubmitManifest()
        {
            DataProviders.Add(SOURCE_PROVIDER_KEY, null);
        }
        public PaginatedContentResult ProcessQuery(string requestId)
        {
            LazyInit();

            ValidateRequest(requestId);

            int rowCount;
            byte[] content = GetSubmittedDocumentList(out rowCount);

            PaginatedContentResult result = new PaginatedContentResult();
            result.Paging = new PaginationIndicator(0, rowCount, true);
            result.Content = new SimpleContent(CommonContentType.XML, content);

            string docId =
                    _documentManager.AddDocument(_dataRequest.TransactionId, CommonTransactionStatusCode.Completed,
                                                 null, new Document(null, CommonContentType.XML, content));

            return result;
        }
        protected virtual void LazyInit()
        {
            AppendAuditLogEvent("Initializing {0} plugin ...", this.GetType().Name);

            GetServiceImplementation(out _requestManager);
            GetServiceImplementation(out _serializationHelper);
            GetServiceImplementation(out _flowManager);
            GetServiceImplementation(out _documentManager);

            _baseDao = ValidateDBProvider(SOURCE_PROVIDER_KEY);
        }
        protected virtual void ValidateRequest(string requestId)
        {
            AppendAuditLogEvent("Loading request with id \"{0}\"", requestId);
            _dataRequest = _requestManager.GetDataRequest(requestId);

            AppendAuditLogEvent("Validating request: {0}", _dataRequest);

            GetParameter(_dataRequest, PARAM_SUBMISSION_DATE, 0, out _submissionDate);
            string statusParam = null;
            TryGetParameter(_dataRequest, PARAM_TRANSACTION_STATUS, 1, ref statusParam);
            if ( !string.IsNullOrEmpty(statusParam) )
            {
                _transactionStatus = (CommonTransactionStatusCode) Enum.Parse(typeof(CommonTransactionStatusCode), statusParam);
            }

            if (_transactionStatus == CommonTransactionStatusCode.Unknown)
            {
                AppendAuditLogEvent("Parameters: {0} ({1})", PARAM_SUBMISSION_DATE, _submissionDate.ToString());
            }
            else
            {
                AppendAuditLogEvent("Parameters: {0} ({1}), {2} ({3})", PARAM_SUBMISSION_DATE, 
                                          _submissionDate.ToString(), PARAM_TRANSACTION_STATUS,
                                          _transactionStatus.ToString());
            }
        }
        protected byte[] GetSubmittedDocumentList(out int rowCount)
        {
            SubmittedDocumentList list = GetSubmittedDocumentList();

            rowCount = list.SubmittedDocuments.Length;

            if (rowCount == 0)
            {
                AppendAuditLogEvent("Did not find any submitted documents");
            }
            else
            {
                AppendAuditLogEvent("Found {0} submitted documents", rowCount.ToString());
            }

            return _serializationHelper.Serialize(list);

        }
        protected SubmittedDocumentList GetSubmittedDocumentList()
        {
            SubmittedDocumentList list = new SubmittedDocumentList();

            List<SubmittedDocument> documents = new List<SubmittedDocument>();

            string triFlowId = _flowManager.GetDataFlowIdByName("TRI");

            string queryString;
            object[] queryParams;

            if (_transactionStatus == CommonTransactionStatusCode.Unknown)
            {
                queryString = "FlowId;WebMethod;ModifiedOn >=";
                queryParams = new object[] { triFlowId, NodeMethod.Submit.ToString(), _submissionDate };
            }
            else
            {
                queryString = "FlowId;WebMethod;Status;ModifiedOn >=";
                queryParams = new object[] { triFlowId, NodeMethod.Submit.ToString(), _transactionStatus.ToString(), _submissionDate };
            }

            _baseDao.DoSimpleQueryWithRowCallbackDelegate(
                "NTransaction", queryString, queryParams,
                "ModifiedOn DESC", "Id;ModifiedOn",
                delegate(IDataReader reader)
                {
                    SubmittedDocument doc = new SubmittedDocument();
                    doc.TransactionID = reader.GetString(0);
                    doc.ReceivedDate = reader.GetDateTime(1);
                    documents.Add(doc);
                });

            TrimListToRequestSize(_dataRequest, documents);

            list.SubmittedDocuments = documents.ToArray();

            return list;
        }
    }
}
