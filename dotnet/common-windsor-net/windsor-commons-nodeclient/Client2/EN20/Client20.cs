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
using System.Net;
using Windsor.Node.Proxy11;
using System.IO;
using System.Xml;
using System.Reflection;

using Windsor.Commons.Core;
using Windsor.Commons.NodeDomain;
using Windsor.Commons.Compression;


//TODO: Document (each public method should be documented). Interface implementation only basic, the interface itself should have the real doc
//TODO: Format (MSDN styles by default at Windsor)
//TODO: There seems to be more helper methods than real implementors, may be an opportunity for refactoring

namespace Windsor.Commons.NodeClient
{
    /// <summary>
    /// Client20
    /// </summary>
    public class Client20 : DisposableBase, INodeEndpointClient
    {
        private ENClient20 _requestor;
        private AuthenticationCredentials _credentials;
        private string _tempPath;
        private DotNetZipHelper _compressionHelper;
        private string _cachedSecurityToken;

        public event NodeStatusMessageEventHandler StatusMessageEvent;

        public Client20(string targetEndpoint, AuthenticationCredentials credentials, string path,
                        IWebProxy proxy)
        {
            Configure(targetEndpoint, credentials, path, proxy);
        }
        public Client20(string targetEndpoint, string naasUserToken, string path,
                        IWebProxy proxy)
        {
            Configure(targetEndpoint, naasUserToken, path, proxy);
        }
        public Client20(string targetEndpoint, AuthenticationCredentials credentials, string path,
                IWebProxy proxy, bool compatibilityMode)
        {
            Configure(targetEndpoint, credentials, path, proxy, compatibilityMode);
        }
        public Client20(string targetEndpoint, string naasUserToken, string path,
                        IWebProxy proxy, bool compatibilityMode)
        {
            Configure(targetEndpoint, naasUserToken, path, proxy, compatibilityMode);
        }
        protected override void OnDispose(bool inIsDisposing)
        {
            if (inIsDisposing)
            {
                DisposableBase.SafeDispose(_requestor);
            }
        }
        /// <summary>
        /// Authenticate
        /// </summary>
        /// <returns></returns>
        public string Authenticate()
        {
            if (_requestor == null)
            {
                throw new ApplicationException("Client not configured. Please call Configure first");
            }
            if (_cachedSecurityToken == null)
            {
                if (_credentials == null)
                {
                    throw new ApplicationException("Client not configured. Please call Configure first");
                }

                Authenticate authRequest =
                    NewAuthenticateObject(_credentials.UserName,
                                          _credentials.Password,
                                          _credentials.Domain);

                AuthenticateResponse authResp = _requestor.Authenticate(authRequest);
                _cachedSecurityToken = authResp.securityToken;
            }
            return _cachedSecurityToken;

        }

        #region IENCommonClientHelper Members

        public EndpointVersionType Version
        {
            get
            {
                return EndpointVersionType.EN20;
            }
        }

        public string Url
        {
            get
            {
                return _requestor.Url;
            }
        }

        public string NaasToken
        {
            get
            {
                return _cachedSecurityToken;
            }
        }

        public int Timeout
        {
            get
            {
                return _requestor.Timeout;
            }
            set
            {
                _requestor.Timeout = value;
            }
        }

        /// <summary>
        /// Authenticate
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="credential"></param>
        /// <returns></returns>
        public string Authenticate(string userID, string credential)
        {

            Authenticate authRequest = NewAuthenticateObject(userID, credential);

            AuthenticateResponse authResp = _requestor.Authenticate(authRequest);
            _cachedSecurityToken = authResp.securityToken;
            return authResp.securityToken;
        }

        /// <summary>
        /// DownloadByName
        /// </summary>
        /// <param name="flow"></param>
        /// <param name="transactionId"></param>
        /// <param name="documentNames"></param>
        /// <returns></returns>
        public string[] DownloadByName(string flow, string transactionId,
                                       params string[] documentNames)
        {
            return Download(flow, transactionId, documentNames, false, null, null, null);
        }

        /// <summary>
        /// Download
        /// </summary>
        /// <param name="flow"></param>
        /// <param name="transactionId"></param>
        /// <param name="documentIds"></param>
        /// <returns></returns>
        public string[] DownloadById(string flow, string transactionId, params string[] documentIds)
        {
            return Download(flow, transactionId, documentIds, true, null, null, null);
        }

        /// <summary>
        /// Download
        /// </summary>
        /// <param name="flow"></param>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        public string[] Download(string flow, string transactionId)
        {
            return Download(flow, transactionId, null, false, null, null, null);
        }

        /// <summary>
        /// Download
        /// </summary>
        /// <param name="flow"></param>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        public string[] DownloadToDirectory(string flow, string transactionId, string directoryPath)
        {
            return Download(flow, transactionId, null, false, null, null, directoryPath);
        }

        /// <summary>
        /// Download
        /// </summary>
        /// <param name="flow"></param>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        public string[] DownloadToDirectory(string flow, string transactionId, string directoryPath,
                                            bool overwriteExistingFiles)
        {
            return Download(flow, transactionId, null, false, null, null, directoryPath, overwriteExistingFiles);
        }

        /// <summary>
        /// DownloadWithDocumentIds
        /// </summary>
        /// <param name="flow"></param>
        /// <param name="transactionId"></param>
        /// <param name="documentIds"></param>
        /// <returns></returns>
        public string[] DownloadWithDocumentIds(string flow, string transactionId,
                                                out IList<string> documentIds)
        {
            List<string> list = new List<string>();
            documentIds = list;
            return Download(flow, transactionId, null, false, list, null, null);
        }

        /// <summary>
        /// DownloadWithDocumentNames
        /// </summary>
        /// <param name="flow"></param>
        /// <param name="transactionId"></param>
        /// <param name="documentNames"></param>
        /// <returns></returns>
        public string[] DownloadWithDocumentNames(string flow, string transactionId,
                                                  out IList<string> documentNames)
        {
            List<string> list = new List<string>();
            documentNames = list;
            return Download(flow, transactionId, null, false, null, list, null);
        }

        /// <summary>
        /// GetServices
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public XmlDocument GetServices(string filter)
        {
            GetServices services = NewServicesObject(filter);
            GenericXmlType data = _requestor.GetServices(services);
            return GetXmlDoc(data);
        }

        /// <summary>
        /// NodePing
        /// </summary>
        /// <returns></returns>
        public string NodePing()
        {
            string pingDetail;
            return NodePing(out pingDetail);
        }
        /// <summary>
        /// NodePing
        /// </summary>
        /// <returns></returns>
        public string NodePing(out string pingDetail)
        {
            NodePing ping = new NodePing();
            ping.hello = string.Empty;
            NodePingResponse pingResp = _requestor.NodePing(ping);
            pingDetail = pingResp.statusDetail ?? string.Empty;
            return pingResp.nodeStatus.ToString();
        }

        /// <summary>
        /// GetStatus
        /// </summary>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        public CommonTransactionStatusCode GetStatus(string transactionId)
        {
            string statusDetail;
            return GetStatus(transactionId, out statusDetail);
        }

        /// <summary>
        /// GetStatus
        /// </summary>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        public CommonTransactionStatusCode GetStatus(string transactionId, out string statusDetail)
        {
            GetStatus status = NewStatusObject(transactionId);
            StatusResponseType statusResp = _requestor.GetStatus(status);
            statusDetail = statusResp.statusDetail;
            return EnumUtils.ParseEnum<CommonTransactionStatusCode>(statusResp.status.ToString());
        }

        /// <summary>
        /// NotifyEvent
        /// </summary>
        /// <returns></returns>
        public CommonTransactionStatusCode NotifyEvent20(string nodeEndpoint, string flow, string messageName,
                                                        CommonTransactionStatusCode status, string description,
                                                        string eventName)
        {
            Notify notify =
                NewEventNotifyObject(nodeEndpoint, flow, messageName, status, description, eventName);
            StatusResponseType statusResp = _requestor.Notify(notify);
            return CommonTransactionStatusCodeProvider.Convert(statusResp.status.ToString());
        }
        public CommonTransactionStatusCode NotifyEvent11(string nodeEndpoint, string eventName,
                                                         string eventType, string eventDescription)
        {
            throw new InvalidOperationException("NotifyEvent11() is not supported by a v2.0 client");
        }

        /// <summary>
        /// NotifyStatus
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="flow"></param>
        /// <param name="transactionId"></param>
        /// <param name="status"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public CommonTransactionStatusCode NotifyStatus20(string endpoint, string flow, string transactionId,
                                                          CommonTransactionStatusCode status, string description)
        {
            Notify notify = NewStatusNotifyObject(endpoint, flow, transactionId, status,
                                                  description);
            StatusResponseType statusResp = _requestor.Notify(notify);
            return CommonTransactionStatusCodeProvider.Convert(statusResp.status.ToString());
        }
        public CommonTransactionStatusCode NotifyStatus11(string endpoint, string transactionId,
                                                          CommonTransactionStatusCode status, string description)
        {
            throw new InvalidOperationException("NotifyStatus11() is not supported by a v2.0 client");
        }

        /// <summary>
        /// NotifyDocument
        /// </summary>
        /// <returns></returns>
        public string NotifyDocument20(string endpoint, string flow, CommonTransactionStatusCode status,
                                       string description, params string[] documentIds)
        {
            Notify notify = NewDocumentNotifyObject(endpoint, flow, status, description,
                                                    documentIds);
            StatusResponseType statusResp = _requestor.Notify(notify);
            return statusResp.transactionId;
        }
        public string NotifyDocument11(string nodeEndpoint, string flow, params string[] documentFilePaths)
        {
            throw new InvalidOperationException("NotifyDocument11() is not supported by a v2.0 client");
        }
        public string NotifyDocument11(string nodeEndpoint, string flow, string name, CommonContentType type,
                                       string content)
        {
            throw new InvalidOperationException("NotifyDocument11() is not supported by a v2.0 client");
        }

        /// <summary>
        /// Query
        /// </summary>
        /// <returns></returns>
        public XmlDocument Query(string request, ByIndexOrNameDictionary<string> arguments)
        {
            Query query = NewQueryObject(null, request, arguments, 0, -1);
            ResultSetType resultSet = _requestor.Query(query);
            return GetXmlDoc(resultSet.results);
        }
        public string QueryXmlString(string request, ByIndexOrNameDictionary<string> arguments)
        {
            Query query = NewQueryObject(null, request, arguments, 0, -1);
            ResultSetType resultSet = _requestor.Query(query);
            return GetXmlString(resultSet.results);
        }

        /// <summary>
        /// Query
        /// </summary>
        /// <returns></returns>
        public XmlDocument Query(string flow, string request, ByIndexOrNameDictionary<string> arguments)
        {
            Query query = NewQueryObject(flow, request, arguments, 0, -1);
            ResultSetType resultSet = _requestor.Query(query);
            return GetXmlDoc(resultSet.results);
        }
        public string QueryXmlString(string flow, string request, ByIndexOrNameDictionary<string> arguments)
        {
            Query query = NewQueryObject(flow, request, arguments, 0, -1);
            ResultSetType resultSet = _requestor.Query(query);
            return GetXmlString(resultSet.results);
        }

        /// <summary>
        /// Query
        /// </summary>
        /// <returns></returns>
        public XmlDocument Query(string flow, string request, ByIndexOrNameDictionary<string> arguments,
                                 Int32 startRow, Int32 pageSize)
        {
            Query query = NewQueryObject(flow, request, arguments, startRow, pageSize);
            ResultSetType resultSet = _requestor.Query(query);
            return GetXmlDoc(resultSet.results);
        }
        public string QueryXmlString(string flow, string request, ByIndexOrNameDictionary<string> arguments,
                                     Int32 startRow, Int32 pageSize)
        {
            Query query = NewQueryObject(flow, request, arguments, startRow, pageSize);
            ResultSetType resultSet = _requestor.Query(query);
            return GetXmlString(resultSet.results);
        }

        /// <summary>
        /// Query
        /// </summary>
        public CommonContentType Query(string flow, string request, ByIndexOrNameDictionary<string> arguments,
                                       Int32 startRow, Int32 pageSize, string targetPath)
        {
            Query query = NewQueryObject(flow, request, arguments, startRow, pageSize);
            ResultSetType resultSet = _requestor.Query(query);
            File.WriteAllBytes(targetPath, GetRawBytes(resultSet.results));
            return GetContentType(resultSet.results.format);
        }

        /// <summary>
        /// Query
        /// </summary>
        public CommonContentType QueryNoUncompress(string flow, string request, ByIndexOrNameDictionary<string> arguments,
                                                   Int32 startRow, Int32 pageSize, string targetPath)
        {
            Query query = NewQueryObject(flow, request, arguments, startRow, pageSize);
            ResultSetType resultSet = _requestor.Query(query);
            File.WriteAllBytes(targetPath, GetRawBytes(resultSet.results));
            return GetContentType(resultSet.results.format);
        }
        public static CommonContentType GetContentType(DocumentFormatType formatType)
        {
            switch (formatType)
            {
                case DocumentFormatType.BIN:
                    return CommonContentType.Bin;
                case DocumentFormatType.FLAT:
                    return CommonContentType.Flat;
                case DocumentFormatType.ODF:
                    return CommonContentType.ODF;
                case DocumentFormatType.XML:
                    return CommonContentType.XML;
                case DocumentFormatType.ZIP:
                    return CommonContentType.ZIP;
                default:
                    return CommonContentType.OTHER;
            }
        }

        /// <summary>
        /// Solicit
        /// </summary>
        /// <returns></returns>
        public string Solicit(string request, ByIndexOrNameDictionary<string> arguments)
        {
            return Solicit(null, request, arguments, null);
        }

        /// <summary>
        /// Solicit
        /// </summary>
        public string Solicit(string flow, string request, ByIndexOrNameDictionary<string> arguments)
        {
            return Solicit(flow, request, arguments, null);
        }

        /// <summary>
        /// Solicit
        /// </summary>
        /// <returns></returns>
        public string Solicit(string flow, string request, ByIndexOrNameDictionary<string> arguments,
                              IList<string> notificationURIs)
        {
            Solicit solicit = NewSolicitObject(flow, request, arguments, notificationURIs);
            StatusResponseType statusResp = _requestor.Solicit(solicit);
            return statusResp.transactionId.ToString();
        }

        /// <summary>
        /// Submit
        /// </summary>
        /// <param name="flow"></param>
        /// <param name="transactionId"></param>
        /// <param name="documentPaths"></param>
        /// <returns></returns>
        public string Submit(string flow, string transactionId, IList<string> documentPaths)
        {
            return Submit(flow, string.Empty, transactionId, documentPaths);
        }
        public string Submit(string flow, string transactionId, IList<EndpointDocument> documents)
        {
            return Submit(flow, string.Empty, transactionId, documents);
        }

        /// <summary>
        /// Submit
        /// </summary>
        /// <param name="flow"></param>
        /// <param name="operation"></param>
        /// <param name="transactionId"></param>
        /// <param name="documentPaths"></param>
        /// <returns></returns>
        public string Submit(string flow, string operation, string transactionId,
                             IList<string> documentPaths)
        {
            return Submit(flow, operation, transactionId, null, documentPaths);
        }
        public string Submit(string flow, string operation, string transactionId,
                             IList<EndpointDocument> documents)
        {
            return Submit(flow, operation, transactionId, null, documents);
        }

        /// <summary>
        /// Submit
        /// </summary>
        /// <param name="flow"></param>
        /// <param name="operation"></param>
        /// <param name="transactionId"></param>
        /// <param name="notificationURIs"></param>
        /// <param name="documentPaths"></param>
        /// <returns></returns>
        public string Submit(string flow, string operation, string transactionId,
                             IList<string> notificationURIs, IList<string> documentPaths)
        {

            return Submit(flow, operation, transactionId, notificationURIs, documentPaths, null);
        }
        public string Submit(string flow, string operation, string transactionId,
                             IList<string> notificationURIs, IList<EndpointDocument> documents)
        {

            return Submit(flow, operation, transactionId, notificationURIs, null, documents);
        }

        /// <summary>
        /// Submit
        /// </summary>
        /// <param name="flow"></param>
        /// <param name="operation"></param>
        /// <param name="transactionId"></param>
        /// <param name="notificationURIs"></param>
        /// <param name="documentPaths"></param>
        /// <returns></returns>
        private string Submit(string flow, string operation, string transactionId,
                              IList<string> notificationURIs, IList<string> documentPaths,
                              IList<EndpointDocument> documents)
        {

            Submit submit = NewSubmitObject(flow, operation, transactionId, notificationURIs,
                                            documentPaths, documents);
            StatusResponseType response = _requestor.Submit(submit);
            return response.transactionId;
        }

        /// <summary>
        /// Execute
        /// </summary>
        public XmlDocument Execute(string interfaceName, string methodName, ByIndexOrNameDictionary<string> arguments,
                                   out string transactionId)
        {
            Execute execute = NewExecuteObject(interfaceName, methodName, arguments);
            ExecuteResponse response = _requestor.Execute(execute);
            transactionId = response.transactionId;
            return GetXmlDoc(response.results);
        }

        /// <summary>
        /// Execute
        /// </summary>
        public string Execute(string interfaceName, string methodName, ByIndexOrNameDictionary<string> arguments,
                              string targetPath)
        {
            Execute execute = NewExecuteObject(interfaceName, methodName, arguments);
            ExecuteResponse response = _requestor.Execute(execute);
            File.WriteAllBytes(targetPath, GetRawBytes(response.results));
            return response.transactionId.ToString();
        }
        #endregion

        #region IENCommonClientConfigurationHelper Members

        public void Configure(string targetEndpoint, AuthenticationCredentials credentials, string path)
        {
            Configure(targetEndpoint, credentials, path, null);
        }

        public void Configure(string targetEndpoint, AuthenticationCredentials credentials, string path, IWebProxy proxy)
        {
            Configure(targetEndpoint, credentials, null, path, proxy, false);
        }

        public void Configure(string targetEndpoint, string naasUserToken, string path, IWebProxy proxy)
        {
            Configure(targetEndpoint, null, naasUserToken, path, proxy, false);
        }

        public void Configure(string targetEndpoint, AuthenticationCredentials credentials, string path, IWebProxy proxy, bool compatibilityMode)
        {
            Configure(targetEndpoint, credentials, null, path, proxy, compatibilityMode);
        }

        public void Configure(string targetEndpoint, string naasUserToken, string path, IWebProxy proxy, bool compatibilityMode)
        {
            Configure(targetEndpoint, null, naasUserToken, path, proxy, compatibilityMode);
        }

        private void Configure(string targetEndpoint, AuthenticationCredentials credentials, string naasUserToken,
                               string path, IWebProxy proxy, bool compatibilityMode)
        {
            if (string.IsNullOrEmpty(targetEndpoint))
            {
                throw new ArgumentException("Null targetEndpoint");
            }

            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("Null path");
            }

            if (!Directory.Exists(path))
            {
                throw new DirectoryNotFoundException(string.Format("Missing temp folder: \"{0}\"", path));
            }

            if ((credentials != null) && !string.IsNullOrEmpty(credentials.UserName) &&
                 !string.IsNullOrEmpty(credentials.Password))
            {
                _credentials = credentials;
                _cachedSecurityToken = null;
            }
            else if (!string.IsNullOrEmpty(naasUserToken))
            {
                _credentials = null;
                _cachedSecurityToken = naasUserToken;
            }
            else
            {
                throw new ArgumentException("No NAAS authentication credentials specified");
            }

            _requestor = new ENClient20(targetEndpoint, compatibilityMode);
            _requestor.UseDefaultCredentials = true;
            _requestor.Timeout = 300000;
            _requestor.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
            _requestor.AllowAutoRedirect = true;

            if (proxy != null)
            {
                _requestor.Proxy = proxy;
            }

            _tempPath = path;

            _compressionHelper = new DotNetZipHelper();
        }
        #endregion // IENCommonClientHelper Members

        #region Private Helper Methods


        private string[] SaveDownloadedDocuments(NodeDocumentType[] documents,
                                                 List<string> documentIDs,
                                                 List<string> documentNames,
                                                 string downloadDirectory)
        {
            return SaveDownloadedDocuments(documents, documentIDs, documentNames, downloadDirectory);
        }
        private string[] SaveDownloadedDocuments(NodeDocumentType[] documents,
                                                 List<string> documentIDs,
                                                 List<string> documentNames,
                                                 string downloadDirectory,
                                                 bool overwriteExistingFiles)
        {
            if ((documents != null) && (documents.Length > 0))
            {
                string downloadDir = downloadDirectory ?? Path.Combine(_tempPath, Guid.NewGuid().ToString());

                Directory.CreateDirectory(downloadDir);

                string[] newDocPaths = new string[documents.Length];
                for (int i = 0; i < documents.Length; ++i)
                {
                    NodeDocumentType newDoc = documents[i];
                    string docName;
                    if (!string.IsNullOrEmpty(newDoc.documentName))
                    {
                        docName = newDoc.documentName;
                    }
                    else if (!string.IsNullOrEmpty(newDoc.documentId))
                    {
                        docName = newDoc.documentId;
                    }
                    else
                    {
                        docName = Guid.NewGuid().ToString();
                    }
                    string newDocPath = Path.Combine(downloadDir, docName);
                    if (File.Exists(newDocPath) && !overwriteExistingFiles)
                    {
                        newDocPath = Path.Combine(downloadDir, Guid.NewGuid().ToString());
                    }
                    File.WriteAllBytes(newDocPath, newDoc.documentContent.Value);
                    newDocPaths[i] = newDocPath;
                    if (documentIDs != null)
                    {
                        documentIDs.Add(newDoc.documentId);
                    }
                    if (documentNames != null)
                    {
                        documentNames.Add(newDoc.documentName);
                    }
                }
                return newDocPaths;
            }
            else
            {
                return new string[0];
            }
        }

        private Download NewDownloadObject(string dataflow, string transactionId)
        {
            Download download = new Download();
            download.securityToken = Authenticate();
            download.dataflow = dataflow;
            download.transactionId = transactionId;
            return download;
        }


        private string[] Download(string flow, string transactionId, string[] documentIdsOrNames,
                                  bool areDocIds, List<string> documentIDs, List<string> documentNames,
                                  string downloadDirectory)
        {
            return Download(flow, transactionId, documentIdsOrNames, areDocIds, documentIDs, documentNames,
                            downloadDirectory, false);
        }
        private string[] Download(string flow, string transactionId, string[] documentIdsOrNames,
                                  bool areDocIds, List<string> documentIDs, List<string> documentNames,
                                  string downloadDirectory, bool overwriteExistingFiles)
        {
            Download download = NewDownloadObject(flow, transactionId);
            bool haveInputDocuments = (documentIdsOrNames != null) && (documentIdsOrNames.Length > 0);
            if (haveInputDocuments)
            {
                download.documents = new NodeDocumentType[documentIdsOrNames.Length];
                for (int i = 0; i < documentIdsOrNames.Length; ++i)
                {
                    NodeDocumentType newDoc = new NodeDocumentType();
                    if (areDocIds)
                    {
                        newDoc.documentId = documentIdsOrNames[i];
                    }
                    else
                    {
                        newDoc.documentName = documentIdsOrNames[i];
                    }
                    download.documents[i] = newDoc;
                }
            }
            else
            {
            }
            NodeDocumentType[] newDocuments = _requestor.Download(download);
            // TODO: Should an exception be thrown if newDocuments.Length != documentIdsOrNames.Length?
            if (areDocIds && haveInputDocuments)
            {
                if ((newDocuments == null) || (newDocuments.Length != documentIdsOrNames.Length))
                {
                    throw new ArgumentException("newDocuments.Length != documentIdsOrNames.Length");
                }
            }
            return SaveDownloadedDocuments(newDocuments, documentIDs, documentNames, downloadDirectory,
                                           overwriteExistingFiles);
        }
        private Submit NewSubmitObject(string flow, string operation, string transactionId,
                                       IList<string> notificationURIs, IList<string> documentPaths,
                                       IList<EndpointDocument> documents)
        {
            Submit submit = new Submit();
            submit.securityToken = Authenticate();
            submit.dataflow = flow;
            submit.flowOperation = operation;
            submit.transactionId = transactionId;
            submit.notificationURI = CreateNotificationURIList(notificationURIs);
            submit.documents = LoadDocumentsToSubmit(documentPaths, documents);
            return submit;
        }
        private NodeDocumentType[] LoadDocumentsToSubmit(IList<string> documentPaths, IList<EndpointDocument> documents)
        {
            if (CollectionUtils.IsNullOrEmpty(documentPaths) &&
                CollectionUtils.IsNullOrEmpty(documents))
            {
                throw new ArgumentException("Must have documents to submit.");
            }
            List<NodeDocumentType> docs = new List<NodeDocumentType>();
            if (!CollectionUtils.IsNullOrEmpty(documentPaths))
            {
                for (int i = 0; i < documentPaths.Count; ++i)
                {
                    NodeDocumentType doc = new NodeDocumentType();
                    string docPath = documentPaths[i];
                    doc.documentContent = new AttachmentType();
                    doc.documentContent.Value = File.ReadAllBytes(docPath);
                    doc.documentName = Path.GetFileName(docPath);
                    switch (Path.GetExtension(docPath).ToLower())
                    {
                        case ".zip":
                            doc.documentFormat = DocumentFormatType.ZIP;
                            doc.documentContent.contentType = "application/zip";
                            break;
                        case ".xml":
                            doc.documentFormat = DocumentFormatType.XML;
                            doc.documentContent.contentType = "text/xml";
                            break;
                        case ".txt":
                            doc.documentFormat = DocumentFormatType.FLAT;
                            doc.documentContent.contentType = "text/plain";
                            break;
                        case ".bin":
                            doc.documentFormat = DocumentFormatType.BIN;
                            doc.documentContent.contentType = "application/octet-stream";
                            break;
                        default:
                            doc.documentFormat = DocumentFormatType.OTHER;
                            doc.documentContent.contentType = "application/x";
                            break;
                    }
                    docs.Add(doc);
                }
            }
            if (!CollectionUtils.IsNullOrEmpty(documents))
            {
                for (int i = 0; i < documents.Count; ++i)
                {
                    NodeDocumentType doc = new NodeDocumentType();
                    EndpointDocument endpointDocument = documents[i];
                    doc.documentContent = new AttachmentType();
                    if (endpointDocument.ContentBytes != null)
                    {
                        doc.documentContent.Value = endpointDocument.ContentBytes;
                    }
                    else if (endpointDocument.ContentFilePath != null)
                    {
                        doc.documentContent.Value = File.ReadAllBytes(endpointDocument.ContentFilePath);
                    }
                    else
                    {
                        throw new ArgumentException("endpointDocument does not have content");
                    }
                    doc.documentName = endpointDocument.DocName;
                    switch (endpointDocument.DocType)
                    {
                        case CommonContentType.ZIP:
                            doc.documentFormat = DocumentFormatType.ZIP;
                            doc.documentContent.contentType = "application/zip";
                            break;
                        case CommonContentType.XML:
                            doc.documentFormat = DocumentFormatType.XML;
                            doc.documentContent.contentType = "text/xml";
                            break;
                        case CommonContentType.Flat:
                            doc.documentFormat = DocumentFormatType.FLAT;
                            doc.documentContent.contentType = "text/plain";
                            break;
                        case CommonContentType.Bin:
                            doc.documentFormat = DocumentFormatType.BIN;
                            doc.documentContent.contentType = "application/octet-stream";
                            break;
                        default:
                            doc.documentFormat = DocumentFormatType.OTHER;
                            doc.documentContent.contentType = "application/x";
                            break;
                    }
                    docs.Add(doc);
                }
            }
            return docs.ToArray();
        }
        private byte[] GetRawBytes(GenericXmlType data)
        {
            switch (data.format)
            {
                case DocumentFormatType.ZIP:
                    {
                        byte[] bytes = Convert.FromBase64String(data.Any[0].Value);
                        return bytes;
                    }
                default:
                    {
                        string xmlString = data.Any[0].OuterXml;
                        byte[] bytes = StringUtils.UTF8.GetBytes(xmlString);
                        return bytes;
                    }
            }
        }
        private NotificationURIType[] CreateNotificationURIList(IList<string> notificationURIs)
        {

            if ((notificationURIs != null) && (notificationURIs.Count > 0))
            {
                NotificationURIType[] rtnNotifications = new NotificationURIType[notificationURIs.Count];
                for (int i = 0; i < notificationURIs.Count; ++i)
                {
                    NotificationURIType notification = new NotificationURIType();
                    notification.notificationTypeSpecified = true;
                    notification.notificationType = NotificationTypeCode.All;
                    notification.Value = notificationURIs[i];
                    rtnNotifications[i] = notification;
                }
                return rtnNotifications;
            }
            else
            {
                return null;
            }
        }
        private Query NewQueryObject(string flow, string request, ByIndexOrNameDictionary<string> arguments,
                                     Int32 startRow, Int32 pageSize)
        {

            Query query = new Query();
            query.securityToken = Authenticate();
            query.dataflow = flow;
            query.request = request;
            query.rowId = startRow.ToString();
            query.maxRows = pageSize.ToString();
            query.parameters = ParameterTypeArrayFromArguments(arguments);
            return query;
        }
        private Execute NewExecuteObject(string interfaceName, string methodName,
                                         ByIndexOrNameDictionary<string> arguments)
        {
            Execute execute = new Execute();
            execute.securityToken = Authenticate();
            execute.interfaceName = interfaceName;
            execute.methodName = methodName;
            execute.parameters = ParameterTypeArrayFromArguments(arguments);
            return execute;
        }
        private byte[] GetUncompressedBytes(GenericXmlType data)
        {
            switch (data.format)
            {
                case DocumentFormatType.ZIP:
                    {
                        byte[] bytes = Convert.FromBase64String(data.Any[0].Value);
                        bytes = _compressionHelper.Uncompress(bytes);
                        return bytes;
                    }
                default:
                    {
                        string xmlString = data.Any[0].OuterXml;
                        byte[] bytes = StringUtils.UTF8.GetBytes(xmlString);
                        return bytes;
                        /*
                        byte[] bytes = StringUtils.UTF8.GetBytes(xmlString);
    #if DEBUG
                        try { File.WriteAllBytes(@"C:\Temp.xml", bytes); } catch(Exception) { }
    #endif // DEBUG
                        return bytes;
                        */
                    }
            }
        }
        private GetStatus NewStatusObject(string transactionId)
        {

            GetStatus status = new GetStatus();
            status.securityToken = Authenticate();
            status.transactionId = transactionId;
            return status;
        }
        private Notify NewNotifyObject(string endpoint, string flow)
        {
            Notify notify = new Notify();
            notify.securityToken = Authenticate();
            notify.nodeAddress = endpoint;
            notify.dataflow = flow;
            return notify;
        }
        private Notify NewSingleNotifyObject(string endpoint, string flow,
                                             NotificationMessageCategoryType notifType)
        {
            Notify notify = NewNotifyObject(endpoint, flow);
            notify.messages = new NotificationMessageType[1];
            notify.messages[0] = new NotificationMessageType();
            notify.messages[0].messageCategory = notifType;
            return notify;
        }
        private Notify NewEventNotifyObject(string endpoint, string flow, string messageName,
                                            CommonTransactionStatusCode status, string description,
                                            string eventName)
        {
            Notify notify =
                NewSingleNotifyObject(endpoint, flow, NotificationMessageCategoryType.Event);
            notify.messages[0].messageName = messageName;
            notify.messages[0].objectId = eventName;
            notify.messages[0].status = (TransactionStatusCode)
                Enum.Parse(typeof(TransactionStatusCode), status.ToString(), true);
            notify.messages[0].statusDetail = description;
            return notify;
        }
        private Notify NewStatusNotifyObject(string endpoint, string flow, string transactionId,
                                             CommonTransactionStatusCode status, string description)
        {
            Notify notify =
                NewSingleNotifyObject(endpoint, flow, NotificationMessageCategoryType.Status);
            notify.messages[0].messageName = string.Format("{0} Status", flow);
            notify.messages[0].objectId = transactionId;
            notify.messages[0].status = (TransactionStatusCode)
                Enum.Parse(typeof(TransactionStatusCode), status.ToString(), true);
            notify.messages[0].statusDetail = description;
            return notify;
        }
        private Notify NewDocumentNotifyObject(string endpoint, string flow, CommonTransactionStatusCode status,
                                               string description, string[] documentIds)
        {
            if (CollectionUtils.IsNullOrEmpty(documentIds))
            {
                throw new ArgumentNullException("Document ids cannot be null or empty");
            }
            Notify notify = NewNotifyObject(endpoint, flow);
            notify.messages = new NotificationMessageType[documentIds.Length];
            for (int i = 0; i < documentIds.Length; ++i)
            {
                NotificationMessageType notification = new NotificationMessageType();
                notification.messageCategory = NotificationMessageCategoryType.Document;
                notification.messageName = string.Format("{0} Document", flow);
                notification.objectId = documentIds[i];
                notification.status = (TransactionStatusCode)
                    Enum.Parse(typeof(TransactionStatusCode), status.ToString(), true);
                notification.statusDetail = description;
                notify.messages[i] = notification;
            }
            return notify;
        }
        private GetServices NewServicesObject(string filter)
        {
            GetServices services = new GetServices();
            services.securityToken = Authenticate();
            services.serviceCategory = filter;
            return services;
        }
        private XmlDocument GetXmlDoc(GenericXmlType data)
        {
            if ((data.Any != null) && (data.Any.Length > 0))
            {
                XmlTextReader reader = null;
                if (data.format == DocumentFormatType.ZIP)
                {
                    byte[] bytes = Convert.FromBase64String(data.Any[0].InnerText);
                    bytes = _compressionHelper.Uncompress(bytes);
                    reader = new XmlTextReader(new MemoryStream(bytes));
                }
                else
                {
                    reader = new XmlTextReader(new StringReader(data.Any[0].OuterXml));
                }
                XmlDocument xmlDoc = new XmlDocument();
                using (reader)
                {
                    xmlDoc.Load(reader);
                }
                return xmlDoc;
            }
            else
            {
                return null;
            }
        }
        private string GetXmlString(GenericXmlType data)
        {
            if ((data.Any != null) && (data.Any.Length > 0))
            {
                if (data.format == DocumentFormatType.ZIP)
                {
                    byte[] bytes = Convert.FromBase64String(data.Any[0].InnerText);
                    bytes = _compressionHelper.Uncompress(bytes);
                    return StringUtils.UTF8.GetString(bytes);
                }
                else
                {
                    return data.Any[0].OuterXml;
                }
            }
            else
            {
                return null;
            }
        }

        private string NewNodeId()
        {
            return "_" + Guid.NewGuid().ToString();
        }

        private Authenticate NewAuthenticateObject(string userId, string credential)
        {
            return NewAuthenticateObject(userId, credential, "default");
        }

        private Authenticate NewAuthenticateObject(string userId, string credential, string domain)
        {

            Authenticate authRequest = new Authenticate();
            authRequest.credential = credential;
            authRequest.userId = userId;
            authRequest.domain = string.IsNullOrEmpty(domain) ? "default" : domain;
            authRequest.authenticationMethod = "password";

            return authRequest;
        }

        private static ParameterType[] ParameterTypeArrayFromArguments(ByIndexOrNameDictionary<string> arguments)
        {
            if ((arguments != null) && (arguments.Count > 0))
            {
                if (!arguments.IsByName)
                {
                    throw new ArgumentException("Input arguments must be \"by name.\"");
                }
                ParameterType[] parameters = new ParameterType[arguments.Count];
                for (int i = 0; i < arguments.Count; ++i)
                {
                    ParameterType parameter = new ParameterType();
                    parameter.parameterName = arguments.KeyAtIndex(i);
                    parameter.Value = arguments[i];
                    parameters[i] = parameter;
                }
                return parameters;
            }
            else
            {
                return new ParameterType[0];
            }
        }

        private Solicit NewSolicitObject(string flow, string request,
                                         ByIndexOrNameDictionary<string> arguments,
                                         IList<string> notificationURIs)
        {
            Solicit solicit = new Solicit();
            solicit.securityToken = Authenticate();
            solicit.dataflow = flow;
            solicit.request = request;
            solicit.parameters = ParameterTypeArrayFromArguments(arguments);
            solicit.notificationURI = CreateNotificationURIList(notificationURIs);
            return solicit;
        }

        #endregion
        private void RaiseRequestorEvent(string message)
        {
            if (StatusMessageEvent != null)
            {
                StatusMessageEvent(this, new NodeStatusMessageEventArgs(message));
            }
        }
    }
}
