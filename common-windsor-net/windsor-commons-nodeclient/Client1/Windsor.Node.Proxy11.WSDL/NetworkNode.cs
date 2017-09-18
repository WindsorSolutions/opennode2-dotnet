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

namespace Windsor.Node.Proxy11.WSDL
{
    using Microsoft.Web.Services;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Web.Services;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using Windsor.Commons.NodeClient;
    using Windsor.Commons.NodeDomain;

    [SoapInclude(typeof(NodeDocument)), DebuggerStepThrough, WebServiceBinding(Name = "NetworkNodeBinding", Namespace = "http://www.ExchangeNetwork.net/schema/v1.0/node.wsdl"), DesignerCategory("code")]
    public class NetworkNode : WebServicesClientProtocol
    {
        public NetworkNode()
        {
            base.Url = "https://epacdxnode.net/cdx/services/NetworkNodePortType_V10";
        }

        [return: SoapElement("return")]
        [SoapRpcMethod("", RequestNamespace = "http://www.ExchangeNetwork.net/schema/v1.0/node.xsd", ResponseNamespace = "http://www.ExchangeNetwork.net/schema/v1.0/node.xsd")]
        public string Authenticate(string userId, string credential, string authenticationMethod)
        {
            try
            {
                return (string)base.Invoke("Authenticate", new object[] { userId, credential, authenticationMethod })[0];
            }
            catch (SoapException soapException)
            {
                throw GetNodeClientException("Authenticate", soapException);
            }
        }

        public IAsyncResult BeginAuthenticate(string userId, string credential, string authenticationMethod, AsyncCallback callback, object asyncState)
        {
            return base.BeginInvoke("Authenticate", new object[] { userId, credential, authenticationMethod }, callback, asyncState);
        }

        public IAsyncResult BeginDownload(string securityToken, string transactionId, string dataflow, NodeDocument[] documents, AsyncCallback callback, object asyncState)
        {
            return base.BeginInvoke("Download", new object[] { securityToken, transactionId, dataflow, documents }, callback, asyncState);
        }

        public IAsyncResult BeginExecute(string securityToken, string request, string[] parameters, AsyncCallback callback, object asyncState)
        {
            return base.BeginInvoke("Execute", new object[] { securityToken, request, parameters }, callback, asyncState);
        }

        public IAsyncResult BeginGetServices(string securityToken, string serviceType, AsyncCallback callback, object asyncState)
        {
            return base.BeginInvoke("GetServices", new object[] { securityToken, serviceType }, callback, asyncState);
        }

        public IAsyncResult BeginGetStatus(string securityToken, string transactionId, AsyncCallback callback, object asyncState)
        {
            return base.BeginInvoke("GetStatus", new object[] { securityToken, transactionId }, callback, asyncState);
        }

        public IAsyncResult BeginNodePing(string Hello, AsyncCallback callback, object asyncState)
        {
            return base.BeginInvoke("NodePing", new object[] { Hello }, callback, asyncState);
        }

        public IAsyncResult BeginNotify(string securityToken, string nodeAddress, string dataflow, NodeDocument[] documents, AsyncCallback callback, object asyncState)
        {
            return base.BeginInvoke("Notify", new object[] { securityToken, nodeAddress, dataflow, documents }, callback, asyncState);
        }

        public IAsyncResult BeginQuery(string securityToken, string request, string rowId, string maxRows, string[] parameters, AsyncCallback callback, object asyncState)
        {
            return base.BeginInvoke("Query", new object[] { securityToken, request, rowId, maxRows, parameters }, callback, asyncState);
        }

        public IAsyncResult BeginSolicit(string securityToken, string returnURL, string request, string[] parameters, AsyncCallback callback, object asyncState)
        {
            return base.BeginInvoke("Solicit", new object[] { securityToken, returnURL, request, parameters }, callback, asyncState);
        }

        public IAsyncResult BeginSubmit(string securityToken, string transactionId, string dataflow, NodeDocument[] documents, AsyncCallback callback, object asyncState)
        {
            return base.BeginInvoke("Submit", new object[] { securityToken, transactionId, dataflow, documents }, callback, asyncState);
        }

        [SoapRpcMethod("", RequestNamespace = "http://www.ExchangeNetwork.net/schema/v1.0/node.xsd", ResponseNamespace = "http://www.ExchangeNetwork.net/schema/v1.0/node.xsd")]
        public void Download(string securityToken, string transactionId, string dataflow, ref NodeDocument[] documents)
        {
            try
            {
                object[] objArray = base.Invoke("Download", new object[] { securityToken, transactionId, dataflow, documents });
                documents = (NodeDocument[])objArray[0];
            }
            catch (SoapException soapException)
            {
                throw GetNodeClientException("Download", soapException);
            }
        }

        public string EndAuthenticate(IAsyncResult asyncResult)
        {
            return (string)base.EndInvoke(asyncResult)[0];
        }

        public void EndDownload(IAsyncResult asyncResult, out NodeDocument[] documents)
        {
            object[] objArray = base.EndInvoke(asyncResult);
            documents = (NodeDocument[])objArray[0];
        }

        public string EndExecute(IAsyncResult asyncResult)
        {
            return (string)base.EndInvoke(asyncResult)[0];
        }

        public string[] EndGetServices(IAsyncResult asyncResult)
        {
            return (string[])base.EndInvoke(asyncResult)[0];
        }

        public string EndGetStatus(IAsyncResult asyncResult)
        {
            return (string)base.EndInvoke(asyncResult)[0];
        }

        public string EndNodePing(IAsyncResult asyncResult)
        {
            return (string)base.EndInvoke(asyncResult)[0];
        }

        public string EndNotify(IAsyncResult asyncResult)
        {
            return (string)base.EndInvoke(asyncResult)[0];
        }

        public object EndQuery(IAsyncResult asyncResult)
        {
            return base.EndInvoke(asyncResult)[0];
        }

        public string EndSolicit(IAsyncResult asyncResult)
        {
            return (string)base.EndInvoke(asyncResult)[0];
        }

        public string EndSubmit(IAsyncResult asyncResult)
        {
            return (string)base.EndInvoke(asyncResult)[0];
        }

        [return: SoapElement("return")]
        [SoapRpcMethod("", RequestNamespace = "http://www.ExchangeNetwork.net/schema/v1.0/node.xsd", ResponseNamespace = "http://www.ExchangeNetwork.net/schema/v1.0/node.xsd")]
        public string Execute(string securityToken, string request, string[] parameters)
        {
            try
            {
                return (string)base.Invoke("Execute", new object[] { securityToken, request, parameters })[0];
            }
            catch (SoapException soapException)
            {
                throw GetNodeClientException("Execute", soapException);
            }
        }

        [return: SoapElement("return")]
        [SoapRpcMethod("", RequestNamespace = "http://www.ExchangeNetwork.net/schema/v1.0/node.xsd", ResponseNamespace = "http://www.ExchangeNetwork.net/schema/v1.0/node.xsd")]
        public string[] GetServices(string securityToken, string serviceType)
        {
            try
            {
                return (string[])base.Invoke("GetServices", new object[] { securityToken, serviceType })[0];
            }
            catch (SoapException soapException)
            {
                throw GetNodeClientException("GetServices", soapException);
            }
        }

        [return: SoapElement("return")]
        [SoapRpcMethod("", RequestNamespace = "http://www.ExchangeNetwork.net/schema/v1.0/node.xsd", ResponseNamespace = "http://www.ExchangeNetwork.net/schema/v1.0/node.xsd")]
        public string GetStatus(string securityToken, string transactionId)
        {
            try
            {
                return (string)base.Invoke("GetStatus", new object[] { securityToken, transactionId })[0];
            }
            catch (SoapException soapException)
            {
                throw GetNodeClientException("GetStatus", soapException);
            }
        }

        [return: SoapElement("return")]
        [SoapRpcMethod("", RequestNamespace = "http://www.ExchangeNetwork.net/schema/v1.0/node.xsd", ResponseNamespace = "http://www.ExchangeNetwork.net/schema/v1.0/node.xsd")]
        public string NodePing(string Hello)
        {
            try
            {
                return (string)base.Invoke("NodePing", new object[] { Hello })[0];
            }
            catch (SoapException soapException)
            {
                throw GetNodeClientException("NodePing", soapException);
            }
        }

        [return: SoapElement("return")]
        [SoapRpcMethod("", RequestNamespace = "http://www.ExchangeNetwork.net/schema/v1.0/node.xsd", ResponseNamespace = "http://www.ExchangeNetwork.net/schema/v1.0/node.xsd")]
        public string Notify(string securityToken, string nodeAddress, string dataflow, NodeDocument[] documents)
        {
            try
            {
                return (string)base.Invoke("Notify", new object[] { securityToken, nodeAddress, dataflow, documents })[0];
            }
            catch (SoapException soapException)
            {
                throw GetNodeClientException("Notify", soapException);
            }
        }

        [return: SoapElement("return")]
        [SoapRpcMethod("", RequestNamespace = "http://www.ExchangeNetwork.net/schema/v1.0/node.xsd", ResponseNamespace = "http://www.ExchangeNetwork.net/schema/v1.0/node.xsd")]
        public object Query(string securityToken, string request, [SoapElement(DataType = "integer")] string rowId, [SoapElement(DataType = "integer")] string maxRows, string[] parameters)
        {
            try
            {
                return base.Invoke("Query", new object[] { securityToken, request, rowId, maxRows, parameters })[0];
            }
            catch (SoapException soapException)
            {
                throw GetNodeClientException("Query", soapException);
            }
        }

        [return: SoapElement("return")]
        [SoapRpcMethod("", RequestNamespace = "http://www.ExchangeNetwork.net/schema/v1.0/node.xsd", ResponseNamespace = "http://www.ExchangeNetwork.net/schema/v1.0/node.xsd")]
        public string Solicit(string securityToken, string returnURL, string request, string[] parameters)
        {
            try
            {
                return (string)base.Invoke("Solicit", new object[] { securityToken, returnURL, request, parameters })[0];
            }
            catch (SoapException soapException)
            {
                throw GetNodeClientException("Solicit", soapException);
            }
        }

        [return: SoapElement("return")]
        [SoapRpcMethod("", RequestNamespace = "http://www.ExchangeNetwork.net/schema/v1.0/node.xsd", ResponseNamespace = "http://www.ExchangeNetwork.net/schema/v1.0/node.xsd")]
        public string Submit(string securityToken, string transactionId, string dataflow, NodeDocument[] documents)
        {
            try
            {
                return (string)base.Invoke("Submit", new object[] { securityToken, transactionId, dataflow, documents })[0];
            }
            catch (SoapException soapException)
            {
                throw GetNodeClientException("Submit", soapException);
            }
        }
        protected virtual SoapException GetNodeClientException(string endpointMethod, SoapException soapException)
        {
            return new NodeClientException(this.Url, EndpointVersionType.EN11, endpointMethod, soapException);
        }
    }
}

