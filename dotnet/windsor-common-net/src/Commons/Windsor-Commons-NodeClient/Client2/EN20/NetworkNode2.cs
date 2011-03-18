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
using Windsor.Commons.Core;

namespace Windsor.Commons.NodeClient
{
    [System.Web.Services.WebServiceBindingAttribute(Name = "NetworkNodeBinding2", Namespace = "http://www.exchangenetwork.net/wsdl/node/2", ConformsTo = WsiProfiles.BasicProfile1_1)]
    [Microsoft.Web.Services3.Messaging.SoapActor("*")]
    public partial class ENClient20 : Microsoft.Web.Services3.WebServicesClientProtocol
    {
        protected override WebRequest GetWebRequest(Uri uri)
        {
            WebRequest webRequest = base.GetWebRequest(uri);
            return webRequest;
        }
        protected override WebResponse GetWebResponse(WebRequest request)
        {
            WebResponse webResponse = base.GetWebResponse(request);
            return webResponse;
        }

        protected override XmlWriter GetWriterForMessage(SoapClientMessage message, int bufferSize)
        {
            return base.GetWriterForMessage(message, bufferSize);
        }

        protected override XmlReader GetReaderForMessage(SoapClientMessage message, int bufferSize)
        {
            // This is a bug fix for Java-based web services that respond with non-MTOM encoded responses
            try
            {
                return base.GetReaderForMessage(message, bufferSize);
            }
            catch (FormatException)
            {
                bool saveRequireMtom = this.RequireMtom;
                this.RequireMtom = !this.RequireMtom;
                try
                {
                    return base.GetReaderForMessage(message, bufferSize);
                }
                finally
                {
                    this.RequireMtom = saveRequireMtom;
                }
                throw;
            }
        }

        public ENClient20(string url)
        {
            this.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
            this.Url = url;
            ServicePointManager.ServerCertificateValidationCallback = CertificatePolicy.RemoteCertificateValidationProc;
            
            // Gets rid of soap wsa headers
            Microsoft.Web.Services3.Design.Policy policy = new Microsoft.Web.Services3.Design.Policy();
            policy.Assertions.Add(new MyAssertion());
            this.SetPolicy(policy);
        }

        private static bool IsWCFSoapActionException(SoapException e)
        {
            return e.Message.Contains("The message with Action") && e.Message.Contains("due to a ContractFilter mismatch at the EndpointDispatcher");
        }
        private static bool IsToggleMTOMException(Exception e)
        {
            if ((e is InvalidOperationException) ||
                e.Message.Contains("System.Web.Services.Protocols.SoapHeaderException"))
            {
                return true;
            }
            return false;
        }

        public AuthenticateResponse Authenticate(Authenticate Authenticate1)
        {
            try
            {
                return AuthenticateHeader(Authenticate1);
            }
            catch (SoapException e)
            {
                if (IsWCFSoapActionException(e))
                {
                    return AuthenticateNoHeader(Authenticate1);
                }
                else
                {
                    throw;
                }
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("AuthenticateResponse", Namespace = "http://www.exchangenetwork.net/schema/node/2")]
        public AuthenticateResponse AuthenticateHeader([System.Xml.Serialization.XmlElementAttribute("Authenticate", Namespace = "http://www.exchangenetwork.net/schema/node/2")] Authenticate Authenticate1)
        {
            this.RequireMtom = true;
            object[] results;
            try
            {
                results = this.Invoke("AuthenticateHeader", new object[] { Authenticate1 });
            }
            catch (Exception e)
            {
                if (IsToggleMTOMException(e))
                {
                    this.RequireMtom = !this.RequireMtom;
                    results = this.Invoke("AuthenticateHeader", new object[] { Authenticate1 });
                }
                else
                {
                    throw;
                }
            }
            return ((AuthenticateResponse)(results[0]));
        }
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("AuthenticateResponse", Namespace = "http://www.exchangenetwork.net/schema/node/2")]
        public AuthenticateResponse AuthenticateNoHeader([System.Xml.Serialization.XmlElementAttribute("Authenticate", Namespace = "http://www.exchangenetwork.net/schema/node/2")] Authenticate Authenticate1)
        {
            this.RequireMtom = true;
            object[] results;
            try
            {
                results = this.Invoke("AuthenticateNoHeader", new object[] { Authenticate1 });
            }
            catch (Exception e)
            {
                if (IsToggleMTOMException(e))
                {
                    this.RequireMtom = !this.RequireMtom;
                    results = this.Invoke("AuthenticateNoHeader", new object[] { Authenticate1 });
                }
                else
                {
                    throw;
                }
            }
            return ((AuthenticateResponse)(results[0]));
        }

        public StatusResponseType Submit(Submit Submit1)
        {
            try
            {
                return SubmitHeader(Submit1);
            }
            catch (SoapException e)
            {
                if (IsWCFSoapActionException(e))
                {
                    return SubmitNoHeader(Submit1);
                }
                else
                {
                    throw;
                }
            }
        }
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("SubmitResponse", Namespace = "http://www.exchangenetwork.net/schema/node/2")]
        public StatusResponseType SubmitHeader([System.Xml.Serialization.XmlElementAttribute("Submit", Namespace = "http://www.exchangenetwork.net/schema/node/2")] Submit Submit1)
        {
            this.RequireMtom = true;
            object[] results = this.Invoke("SubmitHeader", new object[] {
                        Submit1});
            return ((StatusResponseType)(results[0]));
        }
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("SubmitResponse", Namespace = "http://www.exchangenetwork.net/schema/node/2")]
        public StatusResponseType SubmitNoHeader([System.Xml.Serialization.XmlElementAttribute("Submit", Namespace = "http://www.exchangenetwork.net/schema/node/2")] Submit Submit1)
        {
            this.RequireMtom = true;
            object[] results = this.Invoke("SubmitNoHeader", new object[] {
                        Submit1});
            return ((StatusResponseType)(results[0]));
        }

        public StatusResponseType GetStatus(GetStatus GetStatus1)
        {
            try
            {
                return GetStatusHeader(GetStatus1);
            }
            catch (SoapException e)
            {
                if (IsWCFSoapActionException(e))
                {
                    return GetStatusNoHeader(GetStatus1);
                }
                else
                {
                    throw;
                }
            }
        }
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("GetStatusResponse", Namespace = "http://www.exchangenetwork.net/schema/node/2")]
        public StatusResponseType GetStatusHeader([System.Xml.Serialization.XmlElementAttribute("GetStatus", Namespace = "http://www.exchangenetwork.net/schema/node/2")] GetStatus GetStatus1)
        {
            this.RequireMtom = true;
            object[] results;
            try
            {
                results = this.Invoke("GetStatusHeader", new object[] { GetStatus1 });
            }
            catch (Exception e)
            {
                if (IsToggleMTOMException(e))
                {
                    this.RequireMtom = !this.RequireMtom;
                    results = this.Invoke("GetStatusHeader", new object[] { GetStatus1 });
                }
                else
                {
                    throw;
                }
            }
            return ((StatusResponseType)(results[0]));
        }
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("GetStatusResponse", Namespace = "http://www.exchangenetwork.net/schema/node/2")]
        public StatusResponseType GetStatusNoHeader([System.Xml.Serialization.XmlElementAttribute("GetStatus", Namespace = "http://www.exchangenetwork.net/schema/node/2")] GetStatus GetStatus1)
        {
            this.RequireMtom = true;
            object[] results;
            try
            {
                results = this.Invoke("GetStatusNoHeader", new object[] { GetStatus1 });
            }
            catch (Exception e)
            {
                if (IsToggleMTOMException(e))
                {
                    this.RequireMtom = !this.RequireMtom;
                    results = this.Invoke("GetStatusNoHeader", new object[] { GetStatus1 });
                }
                else
                {
                    throw;
                }
            }
            return ((StatusResponseType)(results[0]));
        }

        public StatusResponseType Notify(Notify Notify1)
        {
            try
            {
                return NotifyHeader(Notify1);
            }
            catch (SoapException e)
            {
                if (IsWCFSoapActionException(e))
                {
                    return NotifyNoHeader(Notify1);
                }
                else
                {
                    throw;
                }
            }
        }
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("NotifyResponse", Namespace = "http://www.exchangenetwork.net/schema/node/2")]
        public StatusResponseType NotifyHeader([System.Xml.Serialization.XmlElementAttribute("Notify", Namespace = "http://www.exchangenetwork.net/schema/node/2")] Notify Notify1)
        {
            this.RequireMtom = true;
            object[] results;
            try
            {
                results = this.Invoke("NotifyHeader", new object[] { Notify1 });
            }
            catch (Exception e)
            {
                if (IsToggleMTOMException(e))
                {
                    this.RequireMtom = !this.RequireMtom;
                    results = this.Invoke("NotifyHeader", new object[] { Notify1 });
                }
                else
                {
                    throw;
                }
            }
            return ((StatusResponseType)(results[0]));
        }
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("NotifyResponse", Namespace = "http://www.exchangenetwork.net/schema/node/2")]
        public StatusResponseType NotifyNoHeader([System.Xml.Serialization.XmlElementAttribute("Notify", Namespace = "http://www.exchangenetwork.net/schema/node/2")] Notify Notify1)
        {
            this.RequireMtom = true;
            object[] results;
            try
            {
                results = this.Invoke("NotifyNoHeader", new object[] { Notify1 });
            }
            catch (Exception e)
            {
                if (IsToggleMTOMException(e))
                {
                    this.RequireMtom = !this.RequireMtom;
                    results = this.Invoke("NotifyNoHeader", new object[] { Notify1 });
                }
                else
                {
                    throw;
                }
            }
            return ((StatusResponseType)(results[0]));
        }

        public NodeDocumentType[] Download(Download Download1)
        {
            try
            {
                return DownloadHeader(Download1);
            }
            catch (SoapException e)
            {
                if (IsWCFSoapActionException(e))
                {
                    return DownloadNoHeader(Download1);
                }
                else
                {
                    throw;
                }
            }
        }
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlArrayAttribute("DownloadResponse", Namespace = "http://www.exchangenetwork.net/schema/node/2")]
        [return: System.Xml.Serialization.XmlArrayItemAttribute("documents", IsNullable = false)]
        public NodeDocumentType[] DownloadHeader([System.Xml.Serialization.XmlElementAttribute("Download", Namespace = "http://www.exchangenetwork.net/schema/node/2")] Download Download1)
        {
            this.RequireMtom = true;
            object[] results = this.Invoke("DownloadHeader", new object[] {
                        Download1});
            return ((NodeDocumentType[])(results[0]));
        }
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlArrayAttribute("DownloadResponse", Namespace = "http://www.exchangenetwork.net/schema/node/2")]
        [return: System.Xml.Serialization.XmlArrayItemAttribute("documents", IsNullable = false)]
        public NodeDocumentType[] DownloadNoHeader([System.Xml.Serialization.XmlElementAttribute("Download", Namespace = "http://www.exchangenetwork.net/schema/node/2")] Download Download1)
        {
            this.RequireMtom = true;
            object[] results = this.Invoke("DownloadNoHeader", new object[] {
                        Download1});
            return ((NodeDocumentType[])(results[0]));
        }

        public ResultSetType Query(Query Query1)
        {
            try
            {
                return QueryHeader(Query1);
            }
            catch (SoapException e)
            {
                if (IsWCFSoapActionException(e))
                {
                    return QueryNoHeader(Query1);
                }
                else
                {
                    throw;
                }
            }
        }
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("QueryResponse", Namespace = "http://www.exchangenetwork.net/schema/node/2")]
        public ResultSetType QueryHeader([System.Xml.Serialization.XmlElementAttribute("Query", Namespace = "http://www.exchangenetwork.net/schema/node/2")] Query Query1)
        {
            this.RequireMtom = true;
            object[] results;
            try
            {
                results = this.Invoke("QueryHeader", new object[] { Query1 });
            }
            catch (Exception e)
            {
                if (IsToggleMTOMException(e))
                {
                    this.RequireMtom = !this.RequireMtom;
                    results = this.Invoke("QueryHeader", new object[] { Query1 });
                }
                else
                {
                    throw;
                }
            }
            return ((ResultSetType)(results[0]));
        }
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("QueryResponse", Namespace = "http://www.exchangenetwork.net/schema/node/2")]
        public ResultSetType QueryNoHeader([System.Xml.Serialization.XmlElementAttribute("Query", Namespace = "http://www.exchangenetwork.net/schema/node/2")] Query Query1)
        {
            this.RequireMtom = true;
            object[] results;
            try
            {
                results = this.Invoke("QueryNoHeader", new object[] { Query1 });
            }
            catch (Exception e)
            {
                if (IsToggleMTOMException(e))
                {
                    this.RequireMtom = !this.RequireMtom;
                    results = this.Invoke("QueryNoHeader", new object[] { Query1 });
                }
                else
                {
                    throw;
                }
            }
            return ((ResultSetType)(results[0]));
        }

        public StatusResponseType Solicit(Solicit Solicit1)
        {
            try
            {
                return SolicitHeader(Solicit1);
            }
            catch (SoapException e)
            {
                if (IsWCFSoapActionException(e))
                {
                    return SolicitNoHeader(Solicit1);
                }
                else
                {
                    throw;
                }
            }
        }
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("SolicitResponse", Namespace = "http://www.exchangenetwork.net/schema/node/2")]
        public StatusResponseType SolicitHeader([System.Xml.Serialization.XmlElementAttribute("Solicit", Namespace = "http://www.exchangenetwork.net/schema/node/2")] Solicit Solicit1)
        {
            this.RequireMtom = true;
            object[] results;
            try
            {
                results = this.Invoke("SolicitHeader", new object[] { Solicit1 });
            }
            catch (Exception e)
            {
                if (IsToggleMTOMException(e))
                {
                    this.RequireMtom = !this.RequireMtom;
                    results = this.Invoke("SolicitHeader", new object[] { Solicit1 });
                }
                else
                {
                    throw;
                }
            }
            return ((StatusResponseType)(results[0]));
        }
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("SolicitResponse", Namespace = "http://www.exchangenetwork.net/schema/node/2")]
        public StatusResponseType SolicitNoHeader([System.Xml.Serialization.XmlElementAttribute("Solicit", Namespace = "http://www.exchangenetwork.net/schema/node/2")] Solicit Solicit1)
        {
            this.RequireMtom = true;
            object[] results;
            try
            {
                results = this.Invoke("SolicitNoHeader", new object[] { Solicit1 });
            }
            catch (Exception e)
            {
                if (IsToggleMTOMException(e))
                {
                    this.RequireMtom = !this.RequireMtom;
                    results = this.Invoke("SolicitNoHeader", new object[] { Solicit1 });
                }
                else
                {
                    throw;
                }
            }
            return ((StatusResponseType)(results[0]));
        }

        public ExecuteResponse Execute(Execute Execute1)
        {
            try
            {
                return ExecuteHeader(Execute1);
            }
            catch (SoapException e)
            {
                if (IsWCFSoapActionException(e))
                {
                    return ExecuteNoHeader(Execute1);
                }
                else
                {
                    throw;
                }
            }
        }
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("ExecuteResponse", Namespace = "http://www.exchangenetwork.net/schema/node/2")]
        public ExecuteResponse ExecuteHeader([System.Xml.Serialization.XmlElementAttribute("Execute", Namespace = "http://www.exchangenetwork.net/schema/node/2")] Execute Execute1)
        {
            this.RequireMtom = true;
            object[] results;
            try
            {
                results = this.Invoke("ExecuteHeader", new object[] { Execute1 });
            }
            catch (Exception e)
            {
                if (IsToggleMTOMException(e))
                {
                    this.RequireMtom = !this.RequireMtom;
                    results = this.Invoke("ExecuteHeader", new object[] { Execute1 });
                }
                else
                {
                    throw;
                }
            }
            return ((ExecuteResponse)(results[0]));
        }
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("ExecuteResponse", Namespace = "http://www.exchangenetwork.net/schema/node/2")]
        public ExecuteResponse ExecuteNoHeader([System.Xml.Serialization.XmlElementAttribute("Execute", Namespace = "http://www.exchangenetwork.net/schema/node/2")] Execute Execute1)
        {
            this.RequireMtom = true;
            object[] results;
            try
            {
                results = this.Invoke("ExecuteNoHeader", new object[] { Execute1 });
            }
            catch (Exception e)
            {
                if (IsToggleMTOMException(e))
                {
                    this.RequireMtom = !this.RequireMtom;
                    results = this.Invoke("ExecuteNoHeader", new object[] { Execute1 });
                }
                else
                {
                    throw;
                }
            }
            return ((ExecuteResponse)(results[0]));
        }

        public NodePingResponse NodePing(NodePing NodePing1)
        {
            try
            {
                return NodePingHeader(NodePing1);
            }
            catch (SoapException e)
            {
                if (IsWCFSoapActionException(e))
                {
                    return NodePingNoHeader(NodePing1);
                }
                else
                {
                    throw;
                }
            }
        }
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("NodePingResponse", Namespace = "http://www.exchangenetwork.net/schema/node/2")]
        public NodePingResponse NodePingHeader([System.Xml.Serialization.XmlElementAttribute("NodePing", Namespace = "http://www.exchangenetwork.net/schema/node/2")] NodePing NodePing1)
        {
            this.RequireMtom = true;
            object[] results;
            try
            {
                results = this.Invoke("NodePingHeader", new object[] { NodePing1 });
            }
            catch (Exception e)
            {
                if (IsToggleMTOMException(e))
                {
                    this.RequireMtom = !this.RequireMtom;
                    results = this.Invoke("NodePingHeader", new object[] { NodePing1 });
                }
                else
                {
                    throw;
                }
            }
            return ((NodePingResponse)(results[0]));
        }
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("NodePingResponse", Namespace = "http://www.exchangenetwork.net/schema/node/2")]
        public NodePingResponse NodePingNoHeader([System.Xml.Serialization.XmlElementAttribute("NodePing", Namespace = "http://www.exchangenetwork.net/schema/node/2")] NodePing NodePing1)
        {
            this.RequireMtom = true;
            object[] results;
            try
            {
                results = this.Invoke("NodePingNoHeader", new object[] { NodePing1 });
            }
            catch (Exception e)
            {
                if (IsToggleMTOMException(e))
                {
                    this.RequireMtom = !this.RequireMtom;
                    results = this.Invoke("NodePingNoHeader", new object[] { NodePing1 });
                }
                else
                {
                    throw;
                }
            }
            return ((NodePingResponse)(results[0]));
        }

        public GenericXmlType GetServices(GetServices GetServices1)
        {
            try
            {
                return GetServicesHeader(GetServices1);
            }
            catch (SoapException e)
            {
                if (IsWCFSoapActionException(e))
                {
                    return GetServicesNoHeader(GetServices1);
                }
                else
                {
                    throw;
                }
            }
        }
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("GetServicesResponse", Namespace = "http://www.exchangenetwork.net/schema/node/2")]
        public GenericXmlType GetServicesHeader([System.Xml.Serialization.XmlElementAttribute("GetServices", Namespace = "http://www.exchangenetwork.net/schema/node/2")] GetServices GetServices1)
        {
            this.RequireMtom = true;
            object[] results;
            try
            {
                results = this.Invoke("GetServicesHeader", new object[] { GetServices1 });
            }
            catch (Exception e)
            {
                if (IsToggleMTOMException(e))
                {
                    this.RequireMtom = !this.RequireMtom;
                    results = this.Invoke("GetServicesHeader", new object[] { GetServices1 });
                }
                else
                {
                    throw;
                }
            }
            return ((GenericXmlType)(results[0]));
        }
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("GetServicesResponse", Namespace = "http://www.exchangenetwork.net/schema/node/2")]
        public GenericXmlType GetServicesNoHeader([System.Xml.Serialization.XmlElementAttribute("GetServices", Namespace = "http://www.exchangenetwork.net/schema/node/2")] GetServices GetServices1)
        {
            this.RequireMtom = true;
            object[] results;
            try
            {
                results = this.Invoke("GetServicesNoHeader", new object[] { GetServices1 });
            }
            catch (Exception e)
            {
                if (IsToggleMTOMException(e))
                {
                    this.RequireMtom = !this.RequireMtom;
                    results = this.Invoke("GetServicesNoHeader", new object[] { GetServices1 });
                }
                else
                {
                    throw;
                }
            }
            return ((GenericXmlType)(results[0]));
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
    public class MyPolicy : Microsoft.Web.Services3.SoapFilter
    {
        public override Microsoft.Web.Services3.SoapFilterResult ProcessMessage(Microsoft.Web.Services3.SoapEnvelope envelope)
        {
            // Remove all WS-Addressing and WS-Security header info
            envelope.Header.RemoveAll();
            return Microsoft.Web.Services3.SoapFilterResult.Continue;
        }
    }
    public class MyAssertion : Microsoft.Web.Services3.Design.PolicyAssertion
    {
        public override Microsoft.Web.Services3.SoapFilter CreateClientInputFilter(Microsoft.Web.Services3.Design.FilterCreationContext context)
        {
            return null;
        }

        public override Microsoft.Web.Services3.SoapFilter CreateClientOutputFilter(Microsoft.Web.Services3.Design.FilterCreationContext context)
        {
            return new MyPolicy();
        }

        public override Microsoft.Web.Services3.SoapFilter CreateServiceInputFilter(Microsoft.Web.Services3.Design.FilterCreationContext context)
        {
            return null;
        }

        public override Microsoft.Web.Services3.SoapFilter CreateServiceOutputFilter(Microsoft.Web.Services3.Design.FilterCreationContext context)
        {
            return null;
        }
    }

}
