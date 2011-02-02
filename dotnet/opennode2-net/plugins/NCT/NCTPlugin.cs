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
using System.Diagnostics;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Xml;
using System.Reflection;
using Windsor.Node2008.WNOSPlugin;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSProviders;
using Windsor.Commons.Core;
using Windsor.Commons.Logging;
using Windsor.Commons.NodeDomain;

namespace Windsor.Node2008.WNOSPlugin.NCT
{
    [Serializable]
    public class NCTPlugin : BaseWNOSPlugin, ISubmitProcessor, INotifyProcessor,
                             ISolicitProcessor, IQueryProcessor, IExecuteProcessor
    {
        #region fields
        private static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());
        private ISerializationHelper _serializationHelper;
        private ICompressionHelper _compressionHelper;
        private IDocumentManager _documentManager;
        private ITransactionManager _transactionManager;
        private IRequestManager _requestManager;
        #endregion

        public NCTPlugin()
        {
        }

        protected void LazyInit()
        {
            GetServiceImplementation(out _serializationHelper);
            GetServiceImplementation(out _compressionHelper);
            GetServiceImplementation(out _documentManager);
            GetServiceImplementation(out _transactionManager);
            GetServiceImplementation(out _requestManager);
        }
        public void ProcessSubmit(string transactionId)
        {
            LOG.Info("NCT.ProcessSubmit()");
            AppendAuditLogEvent("NCT ProcessSubmit() enter");

            LazyInit();

            IList<string> dbDocIds = _transactionManager.GetAllUnprocessedDocumentDbIds(transactionId);
            if (!CollectionUtils.IsNullOrEmpty(dbDocIds))
            {
                foreach (string dbDocId in dbDocIds)
                {
                    Document document = _documentManager.GetDocument(transactionId, dbDocId, true);
                    _documentManager.SetDocumentStatus(transactionId, dbDocId, CommonTransactionStatusCode.Processed,
                                                       "Processed " + dbDocId);
                    string statusDetail;
                    CommonTransactionStatusCode status = _documentManager.GetDocumentStatus(transactionId, dbDocId,
                                                                                            out statusDetail);
                }
            }
            AddReportDocumentToTransaction(transactionId, true);
            AppendAuditLogEvent("NCT ProcessSubmit() exit");
        }
        public void ProcessNotify(string transactionId)
        {
            AppendAuditLogEvent("NCT ProcessNotify() enter");

            LazyInit();

            ComplexNotification notification = _transactionManager.GetNotifyTransactionByTransactionId(transactionId);
            if (notification != null)
            {
            }
            AppendAuditLogEvent("NCT ProcessNotify() exit");
        }
        public void ProcessSolicit(string requestId)
        {
            AppendAuditLogEvent("NCT ProcessSolicit() enter");

            LazyInit();

            DataRequest dataRequest = _requestManager.GetDataRequest(requestId);
            PaginatedContentResult result = OnProcessQueryRequest(dataRequest);
            _documentManager.AddDocument(dataRequest.TransactionId, CommonTransactionStatusCode.Processed,
                                         string.Empty, new Document(string.Empty, string.Empty,
                                                                   result.Content.Type,
                                                                   result.Content.Content));
            AddReportDocumentToTransaction(dataRequest.TransactionId, true);
            AppendAuditLogEvent("NCT ProcessSolicit() exit");
        }
        public PaginatedContentResult ProcessQuery(string requestId)
        {
            AppendAuditLogEvent("NCT ProcessQuery() enter");

            LazyInit();

            PaginatedContentResult result = OnProcessQueryRequest(_requestManager.GetDataRequest(requestId));
            AppendAuditLogEvent("NCT ProcessQuery() exit");
            return result;
        }
        public ExecuteContentResult ProcessExecute(string requestId)
        {
            AppendAuditLogEvent("NCT ProcessExecute() enter");

            LazyInit();

            DataRequest dataRequest = _requestManager.GetDataRequest(requestId);
            ExecuteContentResult result = new ExecuteContentResult();
            result.Content = new SimpleContent();
            int actualCount;
            bool isLast;
            string documentName;
            result.Content.Type = CommonContentType.ZIP;
            result.Content.Content =
                CreateRandomXMLQueryResult(true, 0, -1, out actualCount, out isLast, out documentName);
            result.Status = CommonTransactionStatusCode.Processed;
            AddReportDocumentToTransaction(dataRequest.TransactionId, true);
            AppendAuditLogEvent("NCT ProcessExecute() exit");
            return result;
        }
        protected PaginatedContentResult OnProcessQueryRequest(DataRequest dataRequest)
        {
            if (dataRequest == null)
            {
                throw new ArgumentException(string.Format("Request not found"));
            }
            PaginatedContentResult result = new PaginatedContentResult();
            result.Content = new SimpleContent();
            bool doCompress = DoReturnCompressedResult(dataRequest.Parameters);
            result.Content.Type = doCompress ? CommonContentType.ZIP : CommonContentType.XML;

            int actualCount;
            bool isLast;
            string documentName;
            result.Content.Content =
                CreateRandomXMLQueryResult(doCompress, dataRequest.RowIndex, dataRequest.MaxRowCount,
                                           out actualCount, out isLast, out documentName);
            result.Paging = new PaginationIndicator();
            result.Paging.Start = dataRequest.RowIndex;
            result.Paging.Count = actualCount;
            result.Paging.IsLast = isLast;
            return result;
        }
        protected static bool DoReturnCompressedResult(ByIndexOrNameDictionary<string> parameters)
        {
            if (parameters != null)
            {
                bool doCompress = false;
                for (int i = 0; i < parameters.Count; ++i)
                {
                    if (parameters.IsByName)
                    {
                        switch (parameters.KeyAtIndex(i).ToLower())
                        {
                            case "stringparameter":
                                {
                                    if (parameters[i].ToLower() == "zipped")
                                    {
                                        doCompress = true;
                                    }
                                }
                                break;
                            case "xmlparameter":
                                {
                                    XmlDocument doc = new XmlDocument();
                                    doc.LoadXml(parameters[i]);
                                    if (doc.DocumentElement.InnerText.ToLower() == "zipped")
                                    {
                                        doCompress = true;
                                    }
                                }
                                break;
                        }
                    }
                    else
                    {
                        if (parameters[i] == "zipped")
                        {
                            doCompress = true;
                        }
                    }
                }
                return doCompress;
            }
            return false;
        }
        protected byte[] CreateRandomXMLQueryResult(bool doCompress)
        {
            int actualCount;
            bool isLast;
            string documentName;
            return CreateRandomXMLQueryResult(doCompress, 0, -1, out actualCount, out isLast, out documentName);
        }
        protected byte[] CreateRandomXMLQueryResult(bool doCompress, int start, int count,
                                                    out int actualCount, out bool isLast,
                                                    out string documentName)
        {
            string QUERY_XML_HEADER =
                "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                "<QueryResult:QueryResult xmlns:QueryResult=\"http://www.exchangenetwork.net/schema/NCT/1\" xmlns=\"http://www.exchangenetwork.net/schema/NCT/1\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">";
            string QUERY_XML_BODY_ROW =
                "<row>Row {0} text</row>";
            string QUERY_XML_FOOTER =
                "</QueryResult:QueryResult>";

            const int totalCount = 10;
            int endIndex;
            if (count == -1)
            {
                if (start != 0)
                {
                    throw new ArgumentException("Invalid Arguments", "Paging.Start");
                }
                endIndex = totalCount;
            }
            else
            {
                if (start < 0)
                {
                    throw new ArgumentException("Invalid Arguments", "Paging.Start");
                }
                if (count <= 0)
                {
                    throw new ArgumentException("Invalid Arguments", "Paging.Count");
                }
                endIndex = Math.Min(totalCount, start + count);
            }
            isLast = (endIndex == totalCount);

            StringBuilder sb = new StringBuilder();
            sb.Append(QUERY_XML_HEADER);
            actualCount = endIndex - start;
            for (int i = start + 1; i <= endIndex; ++i)
            {
                sb.AppendFormat(QUERY_XML_BODY_ROW, i.ToString());
            }
            sb.Append(QUERY_XML_FOOTER);
            byte[] rtnArray = StringUtils.UTF8.GetBytes(sb.ToString());
            documentName = Guid.NewGuid().ToString() + ".xml";
            if (doCompress)
            {
                rtnArray = _compressionHelper.Compress(documentName, rtnArray);
            }
            return rtnArray;
        }
        protected byte[] CreateReportDocumentContent(bool succeeded)
        {
            return StringUtils.UTF8.GetBytes(succeeded ? "Success" : "Failure");
        }
        protected void AddReportDocumentToTransaction(string transactionId, bool succeeded)
        {
            string documentName = succeeded ? "Node20.Report" : "Node20.Error";
            try {
                _documentManager.GetDocumentByName(transactionId, documentName, false);
            }
            catch {
                return; // Already there
            }
            _documentManager.AddDocument(transactionId, CommonTransactionStatusCode.Processed,
                                         string.Empty, new Document(string.Empty, documentName, CommonContentType.Flat,
                                                                    CreateReportDocumentContent(succeeded)));
            AppendAuditLogEvent("Added report document \"{0}\" to transaction.", documentName);
        }
    }
}
