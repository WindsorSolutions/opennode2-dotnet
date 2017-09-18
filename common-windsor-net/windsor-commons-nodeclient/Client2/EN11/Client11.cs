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
using System.Net;
using Windsor.Node.Proxy11;
using System.IO;
using System.Xml;
using wsdl = Windsor.Node.Proxy11.WSDL;

using System.Reflection;
using Windsor.Commons.Core;
using Windsor.Commons.NodeDomain;

namespace Windsor.Commons.NodeClient
{
    /// <summary>
    /// Client11
    /// </summary>
    public class Client11 : DisposableBase, INodeEndpointClient
    {
        private const string DOWNGRADED_CALL_WARRNING = "2.0-specific method called on 1.1. client. Call downgraded: ";

        private INodeRequestor11 _requestor;
        private AuthenticationCredentials _credentials;
        private string _tempPath;
        private string _cachedSecurityToken;

        public event NodeStatusMessageEventHandler StatusMessageEvent;

        public Client11(string targetEndpoint, AuthenticationCredentials credentials, string path,
                        IWebProxy proxy)
        {
            Configure(targetEndpoint, credentials, path, proxy);
        }
        public Client11(string targetEndpoint, string naasUserToken, string path,
                        IWebProxy proxy)
        {
            Configure(targetEndpoint, naasUserToken, path, proxy);
        }

        protected override void OnDispose(bool inIsDisposing)
        {
            if (inIsDisposing)
            {
                DisposableBase.SafeDispose(_requestor);
            }
        }
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
                if (string.IsNullOrEmpty(_credentials.Domain))
                {
                    _cachedSecurityToken = _requestor.Authenticate(_credentials.UserName, _credentials.Password);
                }
                else
                {
                    _cachedSecurityToken = _requestor.Authenticate(_credentials.UserName, _credentials.Password);
                }
            }
            return _cachedSecurityToken;

        }

        #region IENCommonClientHelper Members

        public EndpointVersionType Version
        {
            get
            {
                return EndpointVersionType.EN11;
            }
        }

        public string Url
        {
            get
            {
                return _requestor.GetEndpointURL();
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

        public string Authenticate(string userID, string c)
        {
            string authResp = _requestor.Authenticate(userID, c);
            _cachedSecurityToken = authResp;
            return authResp;
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
            return Download(flow, transactionId);
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
            documentIds = null;
            return Download(flow, transactionId);
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
            documentNames = null;
            return Download(flow, transactionId);
        }
        /// <summary>
        /// Download
        /// </summary>
        /// <param name="flow"></param>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        public string[] Download(string flow, string transactionId)
        {
            string downloadDir = Path.Combine(_tempPath, Guid.NewGuid().ToString());
            return DownloadToDirectory(flow, transactionId, downloadDir);
        }

        /// <summary>
        /// DownloadToDirectory
        /// </summary>
        /// <param name="flow"></param>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        public string[] DownloadToDirectory(string flow, string transactionId, string directoryPath)
        {
            return DownloadToDirectory(flow, transactionId, directoryPath, false);
        }
        public string[] DownloadToDirectory(string flow, string transactionId, string directoryPath,
                                            bool overwriteExistingFiles)
        {
            Directory.CreateDirectory(directoryPath);
            _requestor.Download(Authenticate(), transactionId, flow, directoryPath, overwriteExistingFiles);
            return Directory.GetFiles(directoryPath);
        }

        public string[] DownloadByName(string flow, string transactionId, params string[] documentNames)
        {
            if (CollectionUtils.IsNullOrEmpty(documentNames))
            {
                throw new ArgumentException("documentNames cannot be empty");
            }
            Windsor.Node.Proxy11.WSDL.NodeDocument[] documents = new Windsor.Node.Proxy11.WSDL.NodeDocument[documentNames.Length];

            for (int i = 0; i < documentNames.Length; ++i)
            {
                Windsor.Node.Proxy11.WSDL.NodeDocument document = new Windsor.Node.Proxy11.WSDL.NodeDocument();
                document.name = documentNames[i];
                CommonContentType type = CommonContentAndFormatProvider.GetFileTypeFromName(document.name);
                if (type == CommonContentType.OTHER)
                {
                    type = CommonContentType.XML;   // Assume XML
                }
                document.type = type.ToString();
                documents[i] = document;
            }
            _requestor.Download(Authenticate(), transactionId, flow, ref documents);
            return SaveDownloadedDocuments(documents, null);
            //throw new InvalidOperationException("DownloadByName() is not a valid method call for Client11");
        }
        private string[] SaveDownloadedDocuments(Windsor.Node.Proxy11.WSDL.NodeDocument[] documents,
                                                 string downloadDirectory)
        {
            if ((documents != null) && (documents.Length > 0))
            {
                string downloadDir = downloadDirectory ?? Path.Combine(_tempPath, Guid.NewGuid().ToString());

                Directory.CreateDirectory(downloadDir);

                string[] newDocPaths = new string[documents.Length];
                for (int i = 0; i < documents.Length; ++i)
                {
                    Windsor.Node.Proxy11.WSDL.NodeDocument newDoc = documents[i];
                    string docName;
                    if (!string.IsNullOrEmpty(newDoc.name))
                    {
                        docName = newDoc.name;
                    }
                    else
                    {
                        docName = Guid.NewGuid().ToString();
                    }
                    string newDocPath = Path.Combine(downloadDir, docName);
                    if (File.Exists(newDocPath))
                    {
                        newDocPath = Path.Combine(downloadDir, Guid.NewGuid().ToString());
                    }
                    File.WriteAllBytes(newDocPath, newDoc.content);
                    newDocPaths[i] = newDocPath;
                }
                return newDocPaths;
            }
            else
            {
                return new string[0];
            }
        }
        /// <summary>
        /// GetServices
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public XmlDocument GetServices(string filter)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<?xml version=\"1.0\"?>");
            sb.Append("<services>");
            foreach (string service in _requestor.GetServices(Authenticate(), filter))
            {
                sb.AppendFormat("<service>{0}</service>", service);
            }

            sb.Append("</services>");


            string xml = sb.ToString();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            return doc;
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
            pingDetail = string.Empty;
            string pingResp = _requestor.Ping(string.Empty);
            return pingResp;
        }
        /// <summary>
        /// GetStatus
        /// </summary>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        public CommonTransactionStatusCode GetStatus(string transactionId)
        {
            string status = _requestor.GetStatus(Authenticate(), transactionId);
            return EnumUtils.ParseEnum<CommonTransactionStatusCode>(status);
        }

        /// <summary>
        /// GetStatus
        /// </summary>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        public CommonTransactionStatusCode GetStatus(string transactionId, out string statusDetail)
        {
            statusDetail = null;
            return GetStatus(transactionId);
        }

        /// <summary>
        /// NotifyEvent
        /// </summary>
        /// <returns></returns>
        public CommonTransactionStatusCode NotifyEvent11(string nodeEndpoint, string eventName,
                                                         string eventType, string eventDescription)
        {
            string rtnStatus =
                _requestor.NotifyEvent(Authenticate(), nodeEndpoint, eventName,
                                       eventType, eventDescription);
            return CommonTransactionStatusCodeProvider.Convert(rtnStatus);
        }

        /// <summary>
        /// NotifyStatus
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="transactionId"></param>
        /// <param name="status"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public CommonTransactionStatusCode NotifyStatus11(string endpoint, string transactionId,
                                                          CommonTransactionStatusCode status, string description)
        {
            string rtnStatus =
                _requestor.NotifyStatus(Authenticate(), endpoint, transactionId,
                                        CommonTransactionStatusCodeProvider.ConvertTo11Enum(status),
                                        description);
            return CommonTransactionStatusCodeProvider.Convert(rtnStatus);
        }
        public CommonTransactionStatusCode NotifyStatus20(string nodeEndpoint, string flow, string transactionId,
                                                          CommonTransactionStatusCode status, string description)
        {
            throw new InvalidOperationException("NotifyStatus20() is not supported by a v1.1 client");
        }

        public string NotifyDocument20(string endpoint, string flow, CommonTransactionStatusCode status,
                                       string description, params string[] documentIds)
        {
            throw new InvalidOperationException("NotifyDocument20() is not supported by a v1.1 client");
        }
        public CommonTransactionStatusCode NotifyEvent20(string nodeEndpoint, string flow, string messageName,
                                                        CommonTransactionStatusCode status, string description,
                                                        string eventName)
        {
            throw new InvalidOperationException("NotifyEvent20() is not supported by a v1.1 client");
        }
        /// <summary>
        /// NotifyDocument11
        /// </summary>
        /// <returns></returns>
        public string NotifyDocument11(string nodeEndpoint, string flow, params string[] documentFilePaths)
        {
            List<wsdl.NodeDocument> wsdlDocs = new List<wsdl.NodeDocument>();

            if (documentFilePaths != null)
            {
                foreach (string doc in documentFilePaths)
                {
                    if (!File.Exists(doc))
                    {
                        throw new IOException("Specified file does not exists: " + doc);
                    }

                    wsdl.NodeDocument wsdlDoc = new wsdl.NodeDocument();
                    wsdlDoc.content = File.ReadAllBytes(doc);
                    wsdlDoc.name = Path.GetFileName(doc);

                    switch (Path.GetExtension(doc).ToUpper())
                    {
                        case ".XML":
                            wsdlDoc.type = "XML";
                            break;

                        case ".ZIP":
                            wsdlDoc.type = "ZIP";
                            break;

                        case ".TXT":
                            wsdlDoc.type = "Flat";
                            break;

                        case ".BIN":
                            wsdlDoc.type = "Bin";
                            break;

                        default:
                            wsdlDoc.type = "OTHER";
                            break;

                    }

                    wsdlDocs.Add(wsdlDoc);

                }
            }

            string transactionId =
                _requestor.Notify(Authenticate(), nodeEndpoint, flow, wsdlDocs.ToArray());
            return transactionId;
        }

        /// <summary>
        /// NotifyDocument11
        /// </summary>
        /// <returns></returns>
        public string NotifyDocument11(string nodeEndpoint, string flow, string name, CommonContentType type, string content)
        {
            string transactionId =
                _requestor.Notify(Authenticate(), nodeEndpoint, flow, name,
                                  CommonContentAndFormatProvider.ConvertTo11Enum(type),
                                  content);
            return transactionId;
        }

        /// <summary>
        /// Query
        /// </summary>
        /// <returns></returns>
        public XmlDocument Query(string service, ByIndexOrNameDictionary<string> arguments)
        {
            string docPath = Path.Combine(_tempPath, Guid.NewGuid().ToString());
            Query(null, service, arguments, 0, -1, docPath);
            XmlDocument doc = new XmlDocument();
            doc.Load(docPath);
            return doc;
        }
        /// <summary>
        /// Query
        /// </summary>
        /// <returns></returns>
        public string QueryXmlString(string service, ByIndexOrNameDictionary<string> arguments)
        {
            string docPath = Path.Combine(_tempPath, Guid.NewGuid().ToString());
            Query(null, service, arguments, 0, -1, docPath);
            return File.ReadAllText(docPath);
        }

        /// <summary>
        /// Query
        /// </summary>
        /// <param name="flow"></param>
        /// <param name="service"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public XmlDocument Query(string flow, string service, ByIndexOrNameDictionary<string> arguments)
        {
            return Query(flow, service, arguments, 0, -1);
        }
        public string QueryXmlString(string flow, string service, ByIndexOrNameDictionary<string> arguments)
        {
            string docPath = Path.Combine(_tempPath, Guid.NewGuid().ToString());
            Query(flow, service, arguments, 0, -1, docPath);
            return File.ReadAllText(docPath);
        }

        public XmlDocument Query(string flow, string service, ByIndexOrNameDictionary<string> arguments,
                                 Int32 startRow, Int32 pageSize)
        {

            string docPath = Path.Combine(_tempPath, Guid.NewGuid().ToString());
            Query(flow, service, arguments, startRow, pageSize, docPath);
            XmlDocument doc = new XmlDocument();
            doc.Load(docPath);
            return doc;
        }
        public string QueryXmlString(string flow, string service, ByIndexOrNameDictionary<string> arguments,
                                     Int32 startRow, Int32 pageSize)
        {

            return QueryXmlString(flow, service, arguments);
        }
        /// <summary>
        /// Query
        /// </summary>
        /// <param name="flow"></param>
        /// <param name="service"></param>
        /// <param name="arguments"></param>
        /// <param name="targetPath"></param>
        /// <param name="startRow"></param>
        /// <param name="pageSize"></param>
        public CommonContentType Query(string flow, string service, ByIndexOrNameDictionary<string> arguments,
                                       Int32 startRow, Int32 pageSize, string targetPath)
        {
            List<String> queryArgs = new List<string>();

            if (arguments != null)
            {
                if (arguments.IsByName)
                {
                    throw new ArgumentException("Input arguments must be \"by value.\"");
                }
                foreach (string arg in arguments)
                {
                    queryArgs.Add(arg);
                }
            }

            _requestor.Query(Authenticate(), service, startRow, pageSize, queryArgs.ToArray(), targetPath);
            return CommonContentType.XML;
        }


        public CommonContentType QueryNoUncompress(string flow, string request, ByIndexOrNameDictionary<string> arguments,
                                                   Int32 startRow, Int32 pageSize, string targetPath)
        {
            return Query(flow, request, arguments, startRow, pageSize, targetPath);
        }

        /// <summary>
        /// Solicit
        /// </summary>
        public string Solicit(string service, ByIndexOrNameDictionary<string> arguments)
        {
            return Solicit(null, service, arguments, null);
        }

        /// <summary>
        /// Solicit
        /// </summary>
        public string Solicit(string flow, string service, ByIndexOrNameDictionary<string> arguments)
        {
            return Solicit(flow, service, arguments, null);
        }

        /// <summary>
        /// Solicit
        /// </summary>
        /// <param name="flow"></param>
        /// <param name="service"></param>
        /// <param name="arguments"></param>
        public string Solicit(string flow, string service, ByIndexOrNameDictionary<string> arguments,
                              IList<string> notificationURIs)
        {
            List<String> queryArgs = new List<string>();

            if (arguments != null)
            {
                if (arguments.IsByName)
                {
                    throw new ArgumentException("Input arguments must be \"by value.\"");
                }
                foreach (string arg in arguments)
                {
                    queryArgs.Add(arg);
                }
            }

            if ((notificationURIs != null) && (notificationURIs.Count > 0))
            {
                return _requestor.Solicit(Authenticate(), notificationURIs[0], service, queryArgs.ToArray());
            }
            else
            {
                return _requestor.Solicit(Authenticate(), service, queryArgs.ToArray());
            }
        }
        private Windsor.Node.Proxy11.WSDL.NodeDocument[] GetNodeDocumentArray(IList<EndpointDocument> documents)
        {
            List<Windsor.Node.Proxy11.WSDL.NodeDocument> list = new List<Windsor.Node.Proxy11.WSDL.NodeDocument>();
            foreach (EndpointDocument endpointDocument in documents)
            {
                Windsor.Node.Proxy11.WSDL.NodeDocument doc = new Windsor.Node.Proxy11.WSDL.NodeDocument();
                if (endpointDocument.ContentBytes != null)
                {
                    doc.content = endpointDocument.ContentBytes;
                }
                else if (endpointDocument.ContentFilePath != null)
                {
                    doc.content = File.ReadAllBytes(endpointDocument.ContentFilePath);
                }
                else
                {
                    throw new ArgumentException("endpointDocument does not have content");
                }
                doc.name = endpointDocument.DocName;
                switch (endpointDocument.DocType)
                {
                    case CommonContentType.ZIP:
                        doc.type = "ZIP";
                        break;
                    case CommonContentType.XML:
                        doc.type = "XML";
                        break;
                    case CommonContentType.Flat:
                        doc.type = "Flat";
                        break;
                    case CommonContentType.Bin:
                        doc.type = "Bin";
                        break;
                    default:
                        doc.type = "OTHER";
                        break;
                }
                list.Add(doc);
            }
            return list.ToArray();
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
            return _requestor.Submit(Authenticate(), transactionId, flow, CollectionUtils.ToArray(documentPaths));
        }
        public string Submit(string flow, string transactionId, IList<EndpointDocument> documents)
        {
            return _requestor.Submit(Authenticate(), transactionId, flow, GetNodeDocumentArray(documents));
        }

        /// <summary>
        /// Submit
        /// </summary>
        /// <param name="flow"></param>
        /// <param name="operation"></param>
        /// <param name="transactionId"></param>
        /// <param name="documentPaths"></param>
        /// <returns></returns>
        public string Submit(string flow, string operation, string transactionId, IList<string> documentPaths)
        {
            return Submit(flow, transactionId, documentPaths);
        }
        public string Submit(string flow, string operation, string transactionId, IList<EndpointDocument> documents)
        {
            return Submit(flow, transactionId, documents);
        }

        public string Submit(string flow, string operation, string transactionId,
                             IList<string> notificationURIs, IList<string> documentPaths)
        {
            return Submit(flow, transactionId, documentPaths);
        }
        public string Submit(string flow, string operation, string transactionId,
                             IList<string> notificationURIs, IList<EndpointDocument> documents)
        {
            return Submit(flow, transactionId, documents);
        }

        public XmlDocument Execute(string interfaceName, string methodName, ByIndexOrNameDictionary<string> arguments,
                                   out string transactionId)
        {
            throw new NotImplementedException();
        }
        public string Execute(string interfaceName, string methodName, ByIndexOrNameDictionary<string> arguments, string targetPath)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region IENCommonClientConfigurationHelper Members

        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="targetEndpoint"></param>
        /// <param name="credentials"></param>
        /// <param name="path"></param>
        public void Configure(string targetEndpoint, AuthenticationCredentials credentials, string path)
        {
            Configure(targetEndpoint, credentials, path, null);
        }

        public void Configure(string targetEndpoint, AuthenticationCredentials credentials, string path, IWebProxy proxy)
        {
            Configure(targetEndpoint, credentials, null, path, proxy);
        }

        public void Configure(string targetEndpoint, string naasUserToken, string path, IWebProxy proxy)
        {
            Configure(targetEndpoint, null, naasUserToken, path, proxy);
        }
        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="targetEndpoint"></param>
        /// <param name="credentials"></param>
        /// <param name="path"></param>
        /// <param name="proxy"></param>
        private void Configure(string targetEndpoint, AuthenticationCredentials credentials, string naasUserToken, string path,
                              IWebProxy proxy)
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
                Directory.CreateDirectory(path);
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

            _requestor = new NodeRequestor();
            _requestor.RequestorEvent += new RequestorEventHandler(_requestor_RequestorEvent);

            if (proxy == null)
            {
                _requestor.Configure(targetEndpoint);
            }
            else
            {
                _requestor.Configure(targetEndpoint, proxy);
            }

            _credentials = credentials;
            _tempPath = path;
        }

        private void _requestor_RequestorEvent(NodeRequestor sender, NodeRequestorEventArgs args)
        {
            if (args != null)
            {
                RaiseRequestorEvent(args.Message);
            }
        }
        private void RaiseRequestorEvent(string message)
        {
            if (StatusMessageEvent != null)
            {
                StatusMessageEvent(this, new NodeStatusMessageEventArgs(message));
            }
        }

        #endregion

    }
}
