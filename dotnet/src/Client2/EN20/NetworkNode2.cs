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

﻿using System.Diagnostics;
using System.Web.Services;
using System.ComponentModel;
using System.Web.Services.Protocols;
using System;
using System.Xml;
using System.Net;
using System.Xml.Serialization;
using Windsor.Node.Proxy11;

namespace Windsor.Node2008.Client2
{


    [System.Web.Services.WebServiceBindingAttribute(Name = "NetworkNodeBinding2", Namespace = "http://www.exchangenetwork.net/wsdl/node/2")]
    public partial class ENClient20 : Microsoft.Web.Services3.WebServicesClientProtocol
    {
        protected override XmlReader GetReaderForMessage(SoapClientMessage message, int bufferSize)
        {
            // This is a bug fix for Java-based web services that respond with non-MTOM encoded responses
            try
            {
                return base.GetReaderForMessage(message, bufferSize);
            }
            catch (FormatException)
            {
                //if (this.RequireMtom && !string.IsNullOrEmpty(message.ContentType) &&
                //     (message.ContentType.IndexOf("application/soap+xml", StringComparison.InvariantCultureIgnoreCase) >= 0))
                //{
                    this.RequireMtom = false;
                    try
                    {
                        return base.GetReaderForMessage(message, bufferSize);
                    }
                    finally
                    {
                        this.RequireMtom = true;
                    }
                //}
                throw;
            }
        }
        private System.Threading.SendOrPostCallback AuthenticateOperationCompleted;

        private System.Threading.SendOrPostCallback SubmitOperationCompleted;

        private System.Threading.SendOrPostCallback GetStatusOperationCompleted;

        private System.Threading.SendOrPostCallback NotifyOperationCompleted;

        private System.Threading.SendOrPostCallback DownloadOperationCompleted;

        private System.Threading.SendOrPostCallback QueryOperationCompleted;

        private System.Threading.SendOrPostCallback SolicitOperationCompleted;

        private System.Threading.SendOrPostCallback ExecuteOperationCompleted;

        private System.Threading.SendOrPostCallback NodePingOperationCompleted;

        private System.Threading.SendOrPostCallback GetServicesOperationCompleted;

        /// <remarks/>
        public ENClient20() : this("http://localhost/xml/node_v20_draft.wsdl")
        {
        }

        public ENClient20(string url)
        {
            this.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
            this.Url = url;
            ServicePointManager.ServerCertificateValidationCallback = CertificatePolicy.RemoteCertificateValidationProc;
        }

        public event AuthenticateCompletedEventHandler AuthenticateCompleted;
        public event SubmitCompletedEventHandler SubmitCompleted;
        public event GetStatusCompletedEventHandler GetStatusCompleted;
        public event NotifyCompletedEventHandler NotifyCompleted;
        public event DownloadCompletedEventHandler DownloadCompleted;
        public event QueryCompletedEventHandler QueryCompleted;
        public event SolicitCompletedEventHandler SolicitCompleted;
        public event ExecuteCompletedEventHandler ExecuteCompleted;
        public event NodePingCompletedEventHandler NodePingCompleted;
        public event GetServicesCompletedEventHandler GetServicesCompleted;

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("AuthenticateResponse", Namespace = "http://www.exchangenetwork.net/schema/node/2")]
        public AuthenticateResponse Authenticate([System.Xml.Serialization.XmlElementAttribute("Authenticate", Namespace = "http://www.exchangenetwork.net/schema/node/2")] Authenticate Authenticate1)
        {
            object[] results = this.Invoke("Authenticate", new object[] {
                        Authenticate1});
            return ((AuthenticateResponse)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginAuthenticate(Authenticate Authenticate1, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("Authenticate", new object[] {
                        Authenticate1}, callback, asyncState);
        }

        /// <remarks/>
        public AuthenticateResponse EndAuthenticate(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((AuthenticateResponse)(results[0]));
        }

        /// <remarks/>
        public void AuthenticateAsync(Authenticate Authenticate1)
        {
            this.AuthenticateAsync(Authenticate1, null);
        }

        /// <remarks/>
        public void AuthenticateAsync(Authenticate Authenticate1, object userState)
        {
            if ((this.AuthenticateOperationCompleted == null))
            {
                this.AuthenticateOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAuthenticateOperationCompleted);
            }
            this.InvokeAsync("Authenticate", new object[] {
                        Authenticate1}, this.AuthenticateOperationCompleted, userState);
        }

        private void OnAuthenticateOperationCompleted(object arg)
        {
            if ((this.AuthenticateCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.AuthenticateCompleted(this, new AuthenticateCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("SubmitResponse", Namespace = "http://www.exchangenetwork.net/schema/node/2")]
        public StatusResponseType Submit([System.Xml.Serialization.XmlElementAttribute("Submit", Namespace = "http://www.exchangenetwork.net/schema/node/2")] Submit Submit1)
        {
            object[] results = this.Invoke("Submit", new object[] {
                        Submit1});
            return ((StatusResponseType)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginSubmit(Submit Submit1, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("Submit", new object[] {
                        Submit1}, callback, asyncState);
        }

        /// <remarks/>
        public StatusResponseType EndSubmit(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((StatusResponseType)(results[0]));
        }

        /// <remarks/>
        public void SubmitAsync(Submit Submit1)
        {
            this.SubmitAsync(Submit1, null);
        }

        /// <remarks/>
        public void SubmitAsync(Submit Submit1, object userState)
        {
            if ((this.SubmitOperationCompleted == null))
            {
                this.SubmitOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSubmitOperationCompleted);
            }
            this.InvokeAsync("Submit", new object[] {
                        Submit1}, this.SubmitOperationCompleted, userState);
        }

        private void OnSubmitOperationCompleted(object arg)
        {
            if ((this.SubmitCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SubmitCompleted(this, new SubmitCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("GetStatusResponse", Namespace = "http://www.exchangenetwork.net/schema/node/2")]
        public StatusResponseType GetStatus([System.Xml.Serialization.XmlElementAttribute("GetStatus", Namespace = "http://www.exchangenetwork.net/schema/node/2")] GetStatus GetStatus1)
        {
            object[] results = this.Invoke("GetStatus", new object[] {
                        GetStatus1});
            return ((StatusResponseType)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginGetStatus(GetStatus GetStatus1, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("GetStatus", new object[] {
                        GetStatus1}, callback, asyncState);
        }

        /// <remarks/>
        public StatusResponseType EndGetStatus(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((StatusResponseType)(results[0]));
        }

        /// <remarks/>
        public void GetStatusAsync(GetStatus GetStatus1)
        {
            this.GetStatusAsync(GetStatus1, null);
        }

        /// <remarks/>
        public void GetStatusAsync(GetStatus GetStatus1, object userState)
        {
            if ((this.GetStatusOperationCompleted == null))
            {
                this.GetStatusOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetStatusOperationCompleted);
            }
            this.InvokeAsync("GetStatus", new object[] {
                        GetStatus1}, this.GetStatusOperationCompleted, userState);
        }

        private void OnGetStatusOperationCompleted(object arg)
        {
            if ((this.GetStatusCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetStatusCompleted(this, new GetStatusCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("NotifyResponse", Namespace = "http://www.exchangenetwork.net/schema/node/2")]
        public StatusResponseType Notify([System.Xml.Serialization.XmlElementAttribute("Notify", Namespace = "http://www.exchangenetwork.net/schema/node/2")] Notify Notify1)
        {
            object[] results = this.Invoke("Notify", new object[] {
                        Notify1});
            return ((StatusResponseType)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginNotify(Notify Notify1, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("Notify", new object[] {
                        Notify1}, callback, asyncState);
        }

        /// <remarks/>
        public StatusResponseType EndNotify(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((StatusResponseType)(results[0]));
        }

        /// <remarks/>
        public void NotifyAsync(Notify Notify1)
        {
            this.NotifyAsync(Notify1, null);
        }

        /// <remarks/>
        public void NotifyAsync(Notify Notify1, object userState)
        {
            if ((this.NotifyOperationCompleted == null))
            {
                this.NotifyOperationCompleted = new System.Threading.SendOrPostCallback(this.OnNotifyOperationCompleted);
            }
            this.InvokeAsync("Notify", new object[] {
                        Notify1}, this.NotifyOperationCompleted, userState);
        }

        private void OnNotifyOperationCompleted(object arg)
        {
            if ((this.NotifyCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.NotifyCompleted(this, new NotifyCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlArrayAttribute("DownloadResponse", Namespace = "http://www.exchangenetwork.net/schema/node/2")]
        [return: System.Xml.Serialization.XmlArrayItemAttribute("documents", IsNullable = false)]
        public NodeDocumentType[] Download([System.Xml.Serialization.XmlElementAttribute("Download", Namespace = "http://www.exchangenetwork.net/schema/node/2")] Download Download1)
        {
            object[] results = this.Invoke("Download", new object[] {
                        Download1});
            return ((NodeDocumentType[])(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginDownload(Download Download1, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("Download", new object[] {
                        Download1}, callback, asyncState);
        }

        /// <remarks/>
        public NodeDocumentType[] EndDownload(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((NodeDocumentType[])(results[0]));
        }

        /// <remarks/>
        public void DownloadAsync(Download Download1)
        {
            this.DownloadAsync(Download1, null);
        }

        /// <remarks/>
        public void DownloadAsync(Download Download1, object userState)
        {
            if ((this.DownloadOperationCompleted == null))
            {
                this.DownloadOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDownloadOperationCompleted);
            }
            this.InvokeAsync("Download", new object[] {
                        Download1}, this.DownloadOperationCompleted, userState);
        }

        private void OnDownloadOperationCompleted(object arg)
        {
            if ((this.DownloadCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DownloadCompleted(this, new DownloadCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("QueryResponse", Namespace = "http://www.exchangenetwork.net/schema/node/2")]
        public ResultSetType Query([System.Xml.Serialization.XmlElementAttribute("Query", Namespace = "http://www.exchangenetwork.net/schema/node/2")] Query Query1)
        {
            object[] results = this.Invoke("Query", new object[] {
                        Query1});
            return ((ResultSetType)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginQuery(Query Query1, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("Query", new object[] {
                        Query1}, callback, asyncState);
        }

        /// <remarks/>
        public ResultSetType EndQuery(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((ResultSetType)(results[0]));
        }

        /// <remarks/>
        public void QueryAsync(Query Query1)
        {
            this.QueryAsync(Query1, null);
        }

        /// <remarks/>
        public void QueryAsync(Query Query1, object userState)
        {
            if ((this.QueryOperationCompleted == null))
            {
                this.QueryOperationCompleted = new System.Threading.SendOrPostCallback(this.OnQueryOperationCompleted);
            }
            this.InvokeAsync("Query", new object[] {
                        Query1}, this.QueryOperationCompleted, userState);
        }

        private void OnQueryOperationCompleted(object arg)
        {
            if ((this.QueryCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.QueryCompleted(this, new QueryCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("SolicitResponse", Namespace = "http://www.exchangenetwork.net/schema/node/2")]
        public StatusResponseType Solicit([System.Xml.Serialization.XmlElementAttribute("Solicit", Namespace = "http://www.exchangenetwork.net/schema/node/2")] Solicit Solicit1)
        {
            object[] results = this.Invoke("Solicit", new object[] {
                        Solicit1});
            return ((StatusResponseType)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginSolicit(Solicit Solicit1, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("Solicit", new object[] {
                        Solicit1}, callback, asyncState);
        }

        /// <remarks/>
        public StatusResponseType EndSolicit(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((StatusResponseType)(results[0]));
        }

        /// <remarks/>
        public void SolicitAsync(Solicit Solicit1)
        {
            this.SolicitAsync(Solicit1, null);
        }

        /// <remarks/>
        public void SolicitAsync(Solicit Solicit1, object userState)
        {
            if ((this.SolicitOperationCompleted == null))
            {
                this.SolicitOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSolicitOperationCompleted);
            }
            this.InvokeAsync("Solicit", new object[] {
                        Solicit1}, this.SolicitOperationCompleted, userState);
        }

        private void OnSolicitOperationCompleted(object arg)
        {
            if ((this.SolicitCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SolicitCompleted(this, new SolicitCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("ExecuteResponse", Namespace = "http://www.exchangenetwork.net/schema/node/2")]
        public ExecuteResponse Execute([System.Xml.Serialization.XmlElementAttribute("Execute", Namespace = "http://www.exchangenetwork.net/schema/node/2")] Execute Execute1)
        {
            object[] results = this.Invoke("Execute", new object[] {
                        Execute1});
            return ((ExecuteResponse)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginExecute(Execute Execute1, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("Execute", new object[] {
                        Execute1}, callback, asyncState);
        }

        /// <remarks/>
        public ExecuteResponse EndExecute(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((ExecuteResponse)(results[0]));
        }

        /// <remarks/>
        public void ExecuteAsync(Execute Execute1)
        {
            this.ExecuteAsync(Execute1, null);
        }

        /// <remarks/>
        public void ExecuteAsync(Execute Execute1, object userState)
        {
            if ((this.ExecuteOperationCompleted == null))
            {
                this.ExecuteOperationCompleted = new System.Threading.SendOrPostCallback(this.OnExecuteOperationCompleted);
            }
            this.InvokeAsync("Execute", new object[] {
                        Execute1}, this.ExecuteOperationCompleted, userState);
        }

        private void OnExecuteOperationCompleted(object arg)
        {
            if ((this.ExecuteCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ExecuteCompleted(this, new ExecuteCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("NodePingResponse", Namespace = "http://www.exchangenetwork.net/schema/node/2")]
        public NodePingResponse NodePing([System.Xml.Serialization.XmlElementAttribute("NodePing", Namespace = "http://www.exchangenetwork.net/schema/node/2")] NodePing NodePing1)
        {
            object[] results = this.Invoke("NodePing", new object[] {
                        NodePing1});
            return ((NodePingResponse)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginNodePing(NodePing NodePing1, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("NodePing", new object[] {
                        NodePing1}, callback, asyncState);
        }

        /// <remarks/>
        public NodePingResponse EndNodePing(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((NodePingResponse)(results[0]));
        }

        /// <remarks/>
        public void NodePingAsync(NodePing NodePing1)
        {
            this.NodePingAsync(NodePing1, null);
        }

        /// <remarks/>
        public void NodePingAsync(NodePing NodePing1, object userState)
        {
            if ((this.NodePingOperationCompleted == null))
            {
                this.NodePingOperationCompleted = new System.Threading.SendOrPostCallback(this.OnNodePingOperationCompleted);
            }
            this.InvokeAsync("NodePing", new object[] {
                        NodePing1}, this.NodePingOperationCompleted, userState);
        }

        private void OnNodePingOperationCompleted(object arg)
        {
            if ((this.NodePingCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.NodePingCompleted(this, new NodePingCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("GetServicesResponse", Namespace = "http://www.exchangenetwork.net/schema/node/2")]
        public GenericXmlType GetServices([System.Xml.Serialization.XmlElementAttribute("GetServices", Namespace = "http://www.exchangenetwork.net/schema/node/2")] GetServices GetServices1)
        {
            object[] results = this.Invoke("GetServices", new object[] {
                        GetServices1});
            return ((GenericXmlType)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginGetServices(GetServices GetServices1, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("GetServices", new object[] {
                        GetServices1}, callback, asyncState);
        }

        /// <remarks/>
        public GenericXmlType EndGetServices(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((GenericXmlType)(results[0]));
        }

        /// <remarks/>
        public void GetServicesAsync(GetServices GetServices1)
        {
            this.GetServicesAsync(GetServices1, null);
        }

        /// <remarks/>
        public void GetServicesAsync(GetServices GetServices1, object userState)
        {
            if ((this.GetServicesOperationCompleted == null))
            {
                this.GetServicesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetServicesOperationCompleted);
            }
            this.InvokeAsync("GetServices", new object[] {
                        GetServices1}, this.GetServicesOperationCompleted, userState);
        }

        private void OnGetServicesOperationCompleted(object arg)
        {
            if ((this.GetServicesCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetServicesCompleted(this, new GetServicesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        public new void CancelAsync(object userState)
        {
            base.CancelAsync(userState);
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.exchangenetwork.net/schema/node/2")]
    public partial class Authenticate
    {

        private string userIdField;

        private string credentialField;

        private string domainField;

        private string authenticationMethodField;

        /// <remarks/>
        public string userId
        {
            get
            {
                return this.userIdField;
            }
            set
            {
                this.userIdField = value;
            }
        }

        /// <remarks/>
        public string credential
        {
            get
            {
                return this.credentialField;
            }
            set
            {
                this.credentialField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string domain
        {
            get
            {
                return this.domainField;
            }
            set
            {
                this.domainField = value;
            }
        }

        /// <remarks/>
        public string authenticationMethod
        {
            get
            {
                return this.authenticationMethodField;
            }
            set
            {
                this.authenticationMethodField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/node/2")]
    public partial class GenericXmlType
    {

        private XmlNode[] anyField;

        private DocumentFormatType formatField;

        public GenericXmlType()
        {
            this.formatField = DocumentFormatType.XML;
        }

        /// <remarks/>
        //[System.Xml.Serialization.XmlTextAttribute(DataType = "base64Binary")]
        [System.Xml.Serialization.XmlTextAttribute()]
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public XmlNode[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(DocumentFormatType.XML)]
        public DocumentFormatType format
        {
            get
            {
                return this.formatField;
            }
            set
            {
                this.formatField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/node/2")]
    public enum DocumentFormatType
    {

        /// <remarks/>
        XML,

        /// <remarks/>
        FLAT,

        /// <remarks/>
        BIN,

        /// <remarks/>
        ZIP,

        /// <remarks/>
        ODF,

        /// <remarks/>
        OTHER,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/node/2")]
    public partial class ResultSetType
    {

        private string rowIdField;

        private string rowCountField;

        private bool lastSetField;

        private GenericXmlType resultsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string rowId
        {
            get
            {
                return this.rowIdField;
            }
            set
            {
                this.rowIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string rowCount
        {
            get
            {
                return this.rowCountField;
            }
            set
            {
                this.rowCountField = value;
            }
        }

        /// <remarks/>
        public bool lastSet
        {
            get
            {
                return this.lastSetField;
            }
            set
            {
                this.lastSetField = value;
            }
        }

        /// <remarks/>
        public GenericXmlType results
        {
            get
            {
                return this.resultsField;
            }
            set
            {
                this.resultsField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/node/2")]
    public partial class ParameterType
    {

        private string parameterNameField;

        private System.Xml.XmlQualifiedName parameterTypeField;

        private EncodingType parameterEncodingField;

        private string valueField;

        public ParameterType()
        {
            this.parameterEncodingField = EncodingType.XML;
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string parameterName
        {
            get
            {
                return this.parameterNameField;
            }
            set
            {
                this.parameterNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.Xml.XmlQualifiedName parameterType
        {
            get
            {
                return this.parameterTypeField;
            }
            set
            {
                this.parameterTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(EncodingType.XML)]
        public EncodingType parameterEncoding
        {
            get
            {
                return this.parameterEncodingField;
            }
            set
            {
                this.parameterEncodingField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/node/2")]
    public enum EncodingType
    {

        /// <remarks/>
        Base64,

        /// <remarks/>
        ZIP,

        /// <remarks/>
        Encrypt,

        /// <remarks/>
        Digest,

        /// <remarks/>
        XML,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/node/2")]
    public partial class NotificationMessageType
    {

        private NotificationMessageCategoryType messageCategoryField;

        private string messageNameField;

        private TransactionStatusCode statusField;

        private string statusDetailField;

        private string objectIdField;

        /// <remarks/>
        public NotificationMessageCategoryType messageCategory
        {
            get
            {
                return this.messageCategoryField;
            }
            set
            {
                this.messageCategoryField = value;
            }
        }

        /// <remarks/>
        public string messageName
        {
            get
            {
                return this.messageNameField;
            }
            set
            {
                this.messageNameField = value;
            }
        }

        /// <remarks/>
        public TransactionStatusCode status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }

        /// <remarks/>
        public string statusDetail
        {
            get
            {
                return this.statusDetailField;
            }
            set
            {
                this.statusDetailField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "ID")]
        public string objectId
        {
            get
            {
                return this.objectIdField;
            }
            set
            {
                this.objectIdField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/node/2")]
    public enum NotificationMessageCategoryType
    {

        /// <remarks/>
        Event,

        /// <remarks/>
        Status,

        /// <remarks/>
        Document,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/node/2")]
    public enum TransactionStatusCode
    {

        /// <remarks/>
        Received,

        /// <remarks/>
        Processing,

        /// <remarks/>
        Pending,

        /// <remarks/>
        Failed,

        /// <remarks/>
        Cancelled,

        /// <remarks/>
        Approved,

        /// <remarks/>
        Processed,

        /// <remarks/>
        Completed,

        /// <remarks/>
        Unknown,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/node/2")]
    public partial class StatusResponseType
    {

        private string transactionIdField;

        private TransactionStatusCode statusField;

        private string statusDetailField;

        /// <remarks/>
        public string transactionId
        {
            get
            {
                return this.transactionIdField;
            }
            set
            {
                this.transactionIdField = value;
            }
        }

        /// <remarks/>
        public TransactionStatusCode status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }

        /// <remarks/>
        public string statusDetail
        {
            get
            {
                return this.statusDetailField;
            }
            set
            {
                this.statusDetailField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/node/2")]
    public partial class AttachmentType
    {

        private string contentTypeField;

        private byte[] valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/2005/05/xmlmime")]
        public string contentType
        {
            get
            {
                return this.contentTypeField;
            }
            set
            {
                this.contentTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute(DataType = "base64Binary")]
        public byte[] Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/node/2")]
    public partial class NodeDocumentType
    {

        private string documentNameField;

        private DocumentFormatType documentFormatField;

        private AttachmentType documentContentField;

        private string documentIdField;

        /// <remarks/>
        public string documentName
        {
            get
            {
                return this.documentNameField;
            }
            set
            {
                this.documentNameField = value;
            }
        }

        /// <remarks/>
        public DocumentFormatType documentFormat
        {
            get
            {
                return this.documentFormatField;
            }
            set
            {
                this.documentFormatField = value;
            }
        }

        /// <remarks/>
        public AttachmentType documentContent
        {
            get
            {
                return this.documentContentField;
            }
            set
            {
                this.documentContentField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "ID")]
        public string documentId
        {
            get
            {
                return this.documentIdField;
            }
            set
            {
                this.documentIdField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/node/2")]
    public partial class NotificationURIType
    {

        private NotificationTypeCode notificationTypeField;

        private bool notificationTypeFieldSpecified;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public NotificationTypeCode notificationType
        {
            get
            {
                return this.notificationTypeField;
            }
            set
            {
                this.notificationTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool notificationTypeSpecified
        {
            get
            {
                return this.notificationTypeFieldSpecified;
            }
            set
            {
                this.notificationTypeFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/node/2")]
    public enum NotificationTypeCode
    {

        /// <remarks/>
        Warning,

        /// <remarks/>
        Error,

        /// <remarks/>
        Status,

        /// <remarks/>
        All,

        /// <remarks/>
        None,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.exchangenetwork.net/schema/node/2")]
    public partial class AuthenticateResponse
    {

        private string securityTokenField;

        /// <remarks/>
        public string securityToken
        {
            get
            {
                return this.securityTokenField;
            }
            set
            {
                this.securityTokenField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.exchangenetwork.net/schema/node/2")]
    public partial class Submit
    {

        private string securityTokenField;

        private string transactionIdField;

        private string dataflowField;

        private string flowOperationField;

        private string[] recipientField;

        private NotificationURIType[] notificationURIField;

        private NodeDocumentType[] documentsField;

        /// <remarks/>
        public string securityToken
        {
            get
            {
                return this.securityTokenField;
            }
            set
            {
                this.securityTokenField = value;
            }
        }

        /// <remarks/>
        public string transactionId
        {
            get
            {
                return this.transactionIdField;
            }
            set
            {
                this.transactionIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "NCName")]
        public string dataflow
        {
            get
            {
                return this.dataflowField;
            }
            set
            {
                this.dataflowField = value;
            }
        }

        /// <remarks/>
        public string flowOperation
        {
            get
            {
                return this.flowOperationField;
            }
            set
            {
                this.flowOperationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("recipient")]
        public string[] recipient
        {
            get
            {
                return this.recipientField;
            }
            set
            {
                this.recipientField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("notificationURI")]
        public NotificationURIType[] notificationURI
        {
            get
            {
                return this.notificationURIField;
            }
            set
            {
                this.notificationURIField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("documents")]
        public NodeDocumentType[] documents
        {
            get
            {
                return this.documentsField;
            }
            set
            {
                this.documentsField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.exchangenetwork.net/schema/node/2")]
    public partial class GetStatus
    {

        private string securityTokenField;

        private string transactionIdField;

        /// <remarks/>
        public string securityToken
        {
            get
            {
                return this.securityTokenField;
            }
            set
            {
                this.securityTokenField = value;
            }
        }

        /// <remarks/>
        public string transactionId
        {
            get
            {
                return this.transactionIdField;
            }
            set
            {
                this.transactionIdField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.exchangenetwork.net/schema/node/2")]
    public partial class Notify
    {

        private string securityTokenField;

        private string nodeAddressField;

        private string dataflowField;

        private NotificationMessageType[] messagesField;

        /// <remarks/>
        public string securityToken
        {
            get
            {
                return this.securityTokenField;
            }
            set
            {
                this.securityTokenField = value;
            }
        }

        /// <remarks/>
        public string nodeAddress
        {
            get
            {
                return this.nodeAddressField;
            }
            set
            {
                this.nodeAddressField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "NCName")]
        public string dataflow
        {
            get
            {
                return this.dataflowField;
            }
            set
            {
                this.dataflowField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("messages")]
        public NotificationMessageType[] messages
        {
            get
            {
                return this.messagesField;
            }
            set
            {
                this.messagesField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.exchangenetwork.net/schema/node/2")]
    public partial class Download
    {

        private string securityTokenField;

        private string dataflowField;

        private string transactionIdField;

        private NodeDocumentType[] documentsField;

        /// <remarks/>
        public string securityToken
        {
            get
            {
                return this.securityTokenField;
            }
            set
            {
                this.securityTokenField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "NCName")]
        public string dataflow
        {
            get
            {
                return this.dataflowField;
            }
            set
            {
                this.dataflowField = value;
            }
        }

        /// <remarks/>
        public string transactionId
        {
            get
            {
                return this.transactionIdField;
            }
            set
            {
                this.transactionIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("documents")]
        public NodeDocumentType[] documents
        {
            get
            {
                return this.documentsField;
            }
            set
            {
                this.documentsField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.exchangenetwork.net/schema/node/2")]
    public partial class Query
    {

        private string securityTokenField;

        private string dataflowField;

        private string requestField;

        private string rowIdField;

        private string maxRowsField;

        private ParameterType[] parametersField;

        /// <remarks/>
        public string securityToken
        {
            get
            {
                return this.securityTokenField;
            }
            set
            {
                this.securityTokenField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "NCName")]
        public string dataflow
        {
            get
            {
                return this.dataflowField;
            }
            set
            {
                this.dataflowField = value;
            }
        }

        /// <remarks/>
        public string request
        {
            get
            {
                return this.requestField;
            }
            set
            {
                this.requestField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string rowId
        {
            get
            {
                return this.rowIdField;
            }
            set
            {
                this.rowIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string maxRows
        {
            get
            {
                return this.maxRowsField;
            }
            set
            {
                this.maxRowsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("parameters")]
        public ParameterType[] parameters
        {
            get
            {
                return this.parametersField;
            }
            set
            {
                this.parametersField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.exchangenetwork.net/schema/node/2")]
    public partial class Solicit
    {

        private string securityTokenField;

        private string dataflowField;

        private string requestField;

        private string[] recipientField;

        private NotificationURIType[] notificationURIField;

        private ParameterType[] parametersField;

        /// <remarks/>
        public string securityToken
        {
            get
            {
                return this.securityTokenField;
            }
            set
            {
                this.securityTokenField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "NCName")]
        public string dataflow
        {
            get
            {
                return this.dataflowField;
            }
            set
            {
                this.dataflowField = value;
            }
        }

        /// <remarks/>
        public string request
        {
            get
            {
                return this.requestField;
            }
            set
            {
                this.requestField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("recipient")]
        public string[] recipient
        {
            get
            {
                return this.recipientField;
            }
            set
            {
                this.recipientField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("notificationURI")]
        public NotificationURIType[] notificationURI
        {
            get
            {
                return this.notificationURIField;
            }
            set
            {
                this.notificationURIField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("parameters")]
        public ParameterType[] parameters
        {
            get
            {
                return this.parametersField;
            }
            set
            {
                this.parametersField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.exchangenetwork.net/schema/node/2")]
    public partial class Execute
    {

        private string securityTokenField;

        private string interfaceNameField;

        private string methodNameField;

        private ParameterType[] parametersField;

        /// <remarks/>
        public string securityToken
        {
            get
            {
                return this.securityTokenField;
            }
            set
            {
                this.securityTokenField = value;
            }
        }

        /// <remarks/>
        public string interfaceName
        {
            get
            {
                return this.interfaceNameField;
            }
            set
            {
                this.interfaceNameField = value;
            }
        }

        /// <remarks/>
        public string methodName
        {
            get
            {
                return this.methodNameField;
            }
            set
            {
                this.methodNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("parameters")]
        public ParameterType[] parameters
        {
            get
            {
                return this.parametersField;
            }
            set
            {
                this.parametersField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.exchangenetwork.net/schema/node/2")]
    public partial class ExecuteResponse
    {

        private string transactionIdField;

        private TransactionStatusCode statusField;

        private GenericXmlType resultsField;

        /// <remarks/>
        public string transactionId
        {
            get
            {
                return this.transactionIdField;
            }
            set
            {
                this.transactionIdField = value;
            }
        }

        /// <remarks/>
        public TransactionStatusCode status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }

        /// <remarks/>
        public GenericXmlType results
        {
            get
            {
                return this.resultsField;
            }
            set
            {
                this.resultsField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.exchangenetwork.net/schema/node/2")]
    public partial class NodePing
    {

        private string helloField;

        /// <remarks/>
        public string hello
        {
            get
            {
                return this.helloField;
            }
            set
            {
                this.helloField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.exchangenetwork.net/schema/node/2")]
    public partial class NodePingResponse
    {

        private NodeStatusCode nodeStatusField;

        private string statusDetailField;

        /// <remarks/>
        public NodeStatusCode nodeStatus
        {
            get
            {
                return this.nodeStatusField;
            }
            set
            {
                this.nodeStatusField = value;
            }
        }

        /// <remarks/>
        public string statusDetail
        {
            get
            {
                return this.statusDetailField;
            }
            set
            {
                this.statusDetailField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/node/2")]
    public enum NodeStatusCode
    {

        /// <remarks/>
        Ready,

        /// <remarks/>
        Offline,

        /// <remarks/>
        Busy,

        /// <remarks/>
        Unknown,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.exchangenetwork.net/schema/node/2")]
    public partial class GetServices
    {

        private string securityTokenField;

        private string serviceCategoryField;

        /// <remarks/>
        public string securityToken
        {
            get
            {
                return this.securityTokenField;
            }
            set
            {
                this.securityTokenField = value;
            }
        }

        /// <remarks/>
        public string serviceCategory
        {
            get
            {
                return this.serviceCategoryField;
            }
            set
            {
                this.serviceCategoryField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    public delegate void AuthenticateCompletedEventHandler(object sender, AuthenticateCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class AuthenticateCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal AuthenticateCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState)
            :
                base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public AuthenticateResponse Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((AuthenticateResponse)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    public delegate void SubmitCompletedEventHandler(object sender, SubmitCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SubmitCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal SubmitCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState)
            :
                base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public StatusResponseType Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((StatusResponseType)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    public delegate void GetStatusCompletedEventHandler(object sender, GetStatusCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetStatusCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal GetStatusCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState)
            :
                base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public StatusResponseType Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((StatusResponseType)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    public delegate void NotifyCompletedEventHandler(object sender, NotifyCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class NotifyCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal NotifyCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState)
            :
                base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public StatusResponseType Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((StatusResponseType)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    public delegate void DownloadCompletedEventHandler(object sender, DownloadCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class DownloadCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal DownloadCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState)
            :
                base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public NodeDocumentType[] Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((NodeDocumentType[])(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    public delegate void QueryCompletedEventHandler(object sender, QueryCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class QueryCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal QueryCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState)
            :
                base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public ResultSetType Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((ResultSetType)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    public delegate void SolicitCompletedEventHandler(object sender, SolicitCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SolicitCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal SolicitCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState)
            :
                base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public StatusResponseType Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((StatusResponseType)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    public delegate void ExecuteCompletedEventHandler(object sender, ExecuteCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ExecuteCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal ExecuteCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState)
            :
                base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public ExecuteResponse Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((ExecuteResponse)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    public delegate void NodePingCompletedEventHandler(object sender, NodePingCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class NodePingCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal NodePingCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState)
            :
                base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public NodePingResponse Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((NodePingResponse)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    public delegate void GetServicesCompletedEventHandler(object sender, GetServicesCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetServicesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal GetServicesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState)
            :
                base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public GenericXmlType Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((GenericXmlType)(this.results[0]));
            }
        }
    }
}
