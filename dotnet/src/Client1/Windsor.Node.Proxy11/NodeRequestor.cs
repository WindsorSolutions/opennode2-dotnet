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

namespace Windsor.Node.Proxy11
{
    using Microsoft.Web.Services;
    using Microsoft.Web.Services.Configuration;
    using Microsoft.Web.Services.Dime;
    using System;
    using System.Collections;
    using System.IO;
    using System.Net;
    using System.Runtime.CompilerServices;
    using System.Xml;
    using Windsor.Node.Proxy11.WSDL;
    using Windsor.Commons.Core;

    public class NodeRequestor : INodeRequestor11
    {
        private NetworkNode requestor;

        public event NodeDownloadEventHandler AsyncDownloadCompletedEvent;

        public event NodeQueryEventHandler AsyncQueryCompletedEvent;

        public event NodeSubmitEventHandler AsyncSubmitCompletedEvent;

        public event RequestorEventHandler RequestorEvent;

        public NodeRequestor()
        {
            this.Init();
        }

        private void AddDocumentsToContext(NodeDocument[] documents)
        {
            this.SetMustUnderstand();
            SoapContext requestSoapContext = this.requestor.RequestSoapContext;
            Hashtable hashtable = new Hashtable();
            this.RaiseRequestorEvent("Parsing Documents");
            for (int i = 0; i < documents.Length; i++)
            {
                DimeAttachment attachment = new DimeAttachment();
                attachment.TypeFormat = TypeFormatEnum.MediaType;
                attachment.Type = "application/octet-stream";
                attachment.Id = string.Format("Document-{0}", i);
                attachment.Stream = new MemoryStream(documents[i].content);
                requestSoapContext.Attachments.Add(attachment);
                hashtable.Add(documents[i].name, attachment.Id);
                this.RaiseRequestorEvent("Document Parsed");
            }
            requestSoapContext.Add("hrefs", hashtable);
        }

        public string Authenticate(string userId, string password)
        {
            this.SetMustUnderstand();
            try
            {
                string token = this.requestor.Authenticate(userId, password, "password");
                this.RaiseRequestorEvent(string.Format("NodeRequestor.Authenticated: {0}",
                                                       token));
                return token;
            }
            catch (Exception e)
            {
                this.RaiseRequestorEvent(string.Format("NodeRequestor.Authenticate EXCEPTION: {0}",
                                                       ExceptionUtils.ToLongString(e)));

                throw;
            }
        }

        public void Configure(string url)
        {
            this.requestor.Url = url;
        }

        public void Configure(string url, IWebProxy httpProxy)
        {
            this.requestor.Url = url;
            this.requestor.Proxy = httpProxy;
        }

        public string[] Download(string securityToken, string transactionId, string dataflow, string directoryPath)
        {
            NodeDocument[] documents = new NodeDocument[0];
            this.Download(securityToken, transactionId, dataflow, ref documents);
            ArrayList list = new ArrayList();
            this.RaiseRequestorEvent("Saving Docments");
            foreach (NodeDocument document in documents)
            {
                string fileName = Path.Combine(directoryPath, document.name);
                Util.WriteFile(fileName, document.content);
                list.Add(fileName);
            }
            this.RaiseRequestorEvent("Document Saved");
            return (string[]) list.ToArray(typeof(string));
        }

        public void Download(string securityToken, string transactionId, string dataflow, ref NodeDocument[] documents)
        {
            this.SetMustUnderstand();
            this.RaiseRequestorEvent("Starting Download");
            this.requestor.Download(securityToken, transactionId, dataflow, ref documents);
            this.RaiseRequestorEvent("Documents Downloaded");
            this.LoadDocumentsFromContext(ref documents);
            this.RaiseRequestorEvent("Documents Parsed");
        }

        public void DownloadAsync(string securityToken, string transactionId, string dataflow, string directoryPath)
        {
            this.SetMustUnderstand();
            this.RaiseRequestorEvent("Starting Download");
            NodeDocument[] documents = new NodeDocument[0];
            this.requestor.BeginDownload(securityToken, transactionId, dataflow, documents, new AsyncCallback(this.DownloadAsyncCallback), directoryPath);
            this.RaiseRequestorEvent("Begin Download Executted");
        }

        private void DownloadAsyncCallback(IAsyncResult result)
        {
            this.RaiseRequestorEvent("DownloadAsyncCallback Invoked");
            if (!result.IsCompleted)
            {
                throw new ApplicationException("DownloadAsyncCallback invoked but the processed has not yet completed.");
            }
            NodeDownloadEventArgs args = new NodeDownloadEventArgs();
            string asyncState = (string) result.AsyncState;
            if (!Directory.Exists(asyncState))
            {
                args.IsSuccess = false;
                args.ErrorMessage = "The target directory does not exist: " + asyncState;
            }
            else
            {
                try
                {
                    this.RaiseRequestorEvent("Parsing Results");
                    NodeDocument[] documents = new NodeDocument[0];
                    this.requestor.EndDownload(result, out documents);
                    this.LoadDocumentsFromContext(ref documents);
                    foreach (NodeDocument document in documents)
                    {
                        string fileName = Path.Combine(asyncState, document.name);
                        Util.WriteFile(fileName, document.content);
                        args.Add(fileName);
                    }
                    args.IsSuccess = true;
                    this.RaiseRequestorEvent("Results Parsed");
                }
                catch (Exception innerException)
                {
                    args.ErrorMessage = innerException.Message;
                    while (innerException.InnerException != null)
                    {
                        innerException = innerException.InnerException;
                        args.ErrorMessage = args.ErrorMessage + innerException.Message;
                    }
                }
                if (this.AsyncDownloadCompletedEvent != null)
                {
                    this.AsyncDownloadCompletedEvent(this, args);
                }
            }
        }

        public string GetEndpointURL()
        {
            return this.requestor.Url;
        }

        public string[] GetServices(string securityToken, string serviceType)
        {
            this.SetMustUnderstand();
            this.RaiseRequestorEvent("Getting Services");
            return this.requestor.GetServices(securityToken, serviceType);
        }

        public string GetStatus(string securityToken, string transactionId)
        {
            this.SetMustUnderstand();
            this.RaiseRequestorEvent("Getting Status");
            return this.requestor.GetStatus(securityToken, transactionId);
        }

        private void Init()
        {
            this.RaiseRequestorEvent("Creating Proxy");
            this.requestor = new NetworkNode();
            this.RaiseRequestorEvent("Setting Filters");
            this.SetOutputFilter();
            this.RaiseRequestorEvent("Setting Context");
            this.requestor.RequestSoapContext.Timestamp.Ttl = 0L;
            this.requestor.Timeout = -1;
            ServicePointManager.MaxServicePointIdleTime = -1;
            ServicePointManager.ServerCertificateValidationCallback = CertificatePolicy.RemoteCertificateValidationProc;
            this.RaiseRequestorEvent("Setting Default Certificate Policy");
        }

        private void LoadDocumentsFromContext(ref NodeDocument[] documents)
        {
            SoapContext responseSoapContext = this.requestor.ResponseSoapContext;
            XmlElement documentElement = responseSoapContext.Envelope.DocumentElement;
            Hashtable hashtable = new Hashtable();
            XmlNodeList elementsByTagName = documentElement.GetElementsByTagName("content");
            this.RaiseRequestorEvent("Parsing Documents");
            foreach (XmlNode node in elementsByTagName)
            {
                XmlAttributeCollection attributes = node.Attributes;
                if (attributes["href"] == null)
                {
                    throw new ApplicationException("Unable to find the href attribute in the context. Most likely because the response is not DIME. Please read the Node functional spec 1.1");
                }
                string str = attributes["href"].Value;
                string innerText = node.ParentNode["name"].InnerText;
                hashtable.Add(innerText, str);
            }
            for (int i = 0; i < documents.Length; i++)
            {
                string str3 = (string) hashtable[documents[i].name];
                DimeAttachment attachment = responseSoapContext.Attachments[str3];
                byte[] buffer = new BinaryReader(attachment.Stream).ReadBytes((int) attachment.Stream.Length);
                documents[i].content = buffer;
            }
        }

        public static INodeRequestor11 Make()
        {
            return new NodeRequestor();
        }

        public static INodeRequestor11 Make(string url)
        {
            INodeRequestor11 requestor = new NodeRequestor();
            requestor.Configure(url);
            return requestor;
        }

        public static INodeRequestor11 Make(string url, IWebProxy httpProxy)
        {
            INodeRequestor11 requestor = new NodeRequestor();
            requestor.Configure(url, httpProxy);
            return requestor;
        }

        public string Notify(string securityToken, string nodeAddress, string dataflow, NodeDocument[] documents)
        {
            this.SetMustUnderstand();
            this.RaiseRequestorEvent("Submiting Document Notification");
            this.AddDocumentsToContext(documents);
            return this.requestor.Notify(securityToken, nodeAddress, dataflow, documents);
        }

        public string Notify(string securityToken, string nodeAddress, string dataflow, string name, string type, string message)
        {
            this.RaiseRequestorEvent("Parsing Documents");
            NodeDocument[] documents = new NodeDocument[] { new NodeDocument() };
            documents[0].name = name;
            documents[0].content = Util.ToBytes(message);
            documents[0].type = type;
            return this.Notify(securityToken, nodeAddress, dataflow, documents);
        }

        public string NotifyEvent(string securityToken, string nodeAddress, string eventName, string eventType, string eventDescription)
        {
            return this.Notify(securityToken, nodeAddress, "http://www.exchangenetwork.net/node/event", eventName, eventType, eventDescription);
        }

        public string NotifyStatus(string securityToken, string nodeAddress, string transactionId, string statusCode, string statusDescription)
        {
            return this.Notify(securityToken, nodeAddress, "http://www.exchangenetwork.net/node/status", transactionId, statusCode, statusDescription);
        }

        private NodeDocument[] ParseDocuments(string[] filePaths)
        {
            NodeDocument[] documentArray = new NodeDocument[filePaths.Length];
            for (int i = 0; i < filePaths.Length; i++)
            {
                documentArray[i] = new NodeDocument();
                documentArray[i].name = Util.GetFileName(filePaths[i]);
                documentArray[i].content = Util.GetBytes(filePaths[i]);
                documentArray[i].type = Util.GetFileExtentsion(filePaths[i]);
            }
            return documentArray;
        }

        public string Ping()
        {
            return this.Ping("hello");
        }

        public string Ping(string helloMessage)
        {
            this.SetMustUnderstand();
            this.RaiseRequestorEvent("Pinging");
            return this.requestor.NodePing(helloMessage);
        }

        public string Query(string securityToken, string request, string[] parameters)
        {
            return this.Query(securityToken, request, 0, -1, parameters);
        }

        public string Query(string securityToken, string request, int rowId, int maxRows, string[] parameters)
        {
            this.SetMustUnderstand();
            this.RaiseRequestorEvent("Quering String");
            return (string) this.requestor.Query(securityToken, request, Convert.ToString(rowId), Convert.ToString(maxRows), parameters);
        }

        public void Query(string securityToken, string request, int rowId, int maxRows, string[] parameters, string filePath)
        {
            Util.WriteFile(filePath, this.Query(securityToken, request, rowId, maxRows, parameters));
        }

        public void Query(string securityToken, string request, int rowId, int maxRows, string[] parameters, ref XmlDocument doc)
        {
            string queryResult = this.Query(securityToken, request, rowId, maxRows, parameters);
            doc.LoadXml(queryResult);
            this.RaiseRequestorEvent("XML Document Created");
        }

        public void QueryAsync(string securityToken, string request, int rowId, int maxRows, string[] parameters, string filePath)
        {
            this.SetMustUnderstand();
            this.RaiseRequestorEvent("Quering Async Initializing");
            this.requestor.BeginQuery(securityToken, request, Convert.ToString(rowId), Convert.ToString(maxRows), parameters, new AsyncCallback(this.QueryAsyncCallback), filePath);
        }

        private void QueryAsyncCallback(IAsyncResult result)
        {
            this.RaiseRequestorEvent("QueryAsyncCallback Invoked");
            if (!result.IsCompleted)
            {
                throw new ApplicationException("QueryAsyncCallback invoked but the processed has not yet completed.");
            }
            NodeQueryEventArgs args = new NodeQueryEventArgs((string) result.AsyncState);
            try
            {
                this.RaiseRequestorEvent("Saving Results");
                Util.WriteFile(args.ResultFilePath, (string) this.requestor.EndQuery(result));
                args.IsSuccess = true;
                this.RaiseRequestorEvent("Results Saved");
            }
            catch (Exception exception)
            {
                args.ErrorMessage = exception.Message;
            }
            if (this.AsyncQueryCompletedEvent != null)
            {
                this.AsyncQueryCompletedEvent(this, args);
            }
        }

        internal void RaiseRequestorEvent(string message)
        {
            if (this.RequestorEvent != null)
            {
                this.RequestorEvent(this, new NodeRequestorEventArgs(message));
            }
        }

        public void SetEndpointURL(string url)
        {
            this.requestor.Url = url;
            this.RaiseRequestorEvent("Tetting Endpoint");
        }

        private void SetMustUnderstand()
        {
            this.RaiseRequestorEvent("Getting SOAP Context");
            SoapContext requestSoapContext = this.requestor.RequestSoapContext;
            requestSoapContext.Path.EncodedMustUnderstand = "false";
            requestSoapContext.Attachments.Clear();
            this.RaiseRequestorEvent("Clearing Attachments");
            requestSoapContext.Clear();
        }

        private void SetOutputFilter()
        {
            WebServicesConfiguration.FilterConfiguration.OutputFilters.Add(new NodeRequestorOutputFilter());
            SoapInputFilterCollection inputFilters = WebServicesConfiguration.FilterConfiguration.InputFilters;
        }

        public string Solicit(string securityToken, string request, string[] parameters)
        {
            return this.Solicit(securityToken, string.Empty, request, parameters);
        }

        public string Solicit(string securityToken, string returnURL, string request, string[] parameters)
        {
            this.SetMustUnderstand();
            this.RaiseRequestorEvent("Soliciting");
            return this.requestor.Solicit(securityToken, returnURL, request, parameters);
        }

        public string Submit(string securityToken, string dataflow, string[] filePaths)
        {
            return this.Submit(securityToken, string.Empty, dataflow, filePaths);
        }

        public string Submit(string securityToken, string dataflow, NodeDocument[] documents)
        {
            return this.Submit(securityToken, string.Empty, dataflow, documents);
        }

        public string Submit(string securityToken, string transactionId, string dataflow, string[] filePaths)
        {
            this.RaiseRequestorEvent("Parsing Documents");
            NodeDocument[] documents = this.ParseDocuments(filePaths);
            return this.Submit(securityToken, transactionId, dataflow, documents);
        }

        public string Submit(string securityToken, string transactionId, string dataflow, NodeDocument[] documents)
        {
            this.AddDocumentsToContext(documents);
            this.RaiseRequestorEvent("Submiting Documents");
            return this.requestor.Submit(securityToken, transactionId, dataflow, documents);
        }

        public void SubmitAsync(string securityToken, string transactionId, string dataflow, string[] filePaths)
        {
            this.RaiseRequestorEvent("Parsing File Paths");
            NodeDocument[] documents = this.ParseDocuments(filePaths);
            this.AddDocumentsToContext(documents);
            this.RaiseRequestorEvent("Submiting Documents");
            this.requestor.BeginSubmit(securityToken, transactionId, dataflow, documents, new AsyncCallback(this.SubmitAsyncCallback), securityToken);
        }

        private void SubmitAsyncCallback(IAsyncResult result)
        {
            this.RaiseRequestorEvent("SubmitAsyncCallback Invoked");
            if (!result.IsCompleted)
            {
                throw new ApplicationException("SubmitAsyncCallback invoked but the processed has not yet completed.");
            }
            NodeSubmitEventArgs args = null;
            try
            {
                this.RaiseRequestorEvent("Parsing Results");
                args = new NodeSubmitEventArgs(this.requestor.EndSubmit(result));
                args.IsSuccess = true;
                this.RaiseRequestorEvent("Results Parsed");
            }
            catch (Exception exception)
            {
                args.ErrorMessage = exception.Message;
            }
            if (this.AsyncSubmitCompletedEvent != null)
            {
                this.AsyncSubmitCompletedEvent(this, args);
            }
        }

        public override string ToString()
        {
            string str = (this.requestor == null) ? "NULL" : this.requestor.Url;
            return ("Node Client Proxy (" + str + ")");
        }
    }
}

