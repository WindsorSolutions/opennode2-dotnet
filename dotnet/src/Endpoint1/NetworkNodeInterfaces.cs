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

﻿using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;

namespace Windsor.Node2008.Endpoint1
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.Web.Services.WebServiceBindingAttribute(Name = "NetworkNodeBinding", Namespace = "http://www.ExchangeNetwork.net/schema/v1.0/node.wsdl")]
    [System.Xml.Serialization.SoapIncludeAttribute(typeof(NodeDocument))]
    public interface INetworkNodeBinding
    {

        [System.Web.Services.WebMethodAttribute()]
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("", 
            RequestNamespace = "http://www.ExchangeNetwork.net/schema/v1.0/node.xsd", 
            ResponseNamespace = "http://www.ExchangeNetwork.net/schema/v1.0/node.xsd")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        string Authenticate(string userId, string credential, string authenticationMethod);

        [System.Web.Services.WebMethodAttribute()]
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("", 
            RequestNamespace = "http://www.ExchangeNetwork.net/schema/v1.0/node.xsd", 
            ResponseNamespace = "http://www.ExchangeNetwork.net/schema/v1.0/node.xsd")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        string Submit(string securityToken, string transactionId, string dataflow, NodeDocument[] documents);

        [System.Web.Services.WebMethodAttribute()]
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("",
            RequestNamespace = "http://www.ExchangeNetwork.net/schema/v1.0/node.xsd", 
            ResponseNamespace = "http://www.ExchangeNetwork.net/schema/v1.0/node.xsd")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        string GetStatus(string securityToken, string transactionId);

        [System.Web.Services.WebMethodAttribute()]
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("",
            RequestNamespace = "http://www.ExchangeNetwork.net/schema/v1.0/node.xsd", 
            ResponseNamespace = "http://www.ExchangeNetwork.net/schema/v1.0/node.xsd")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        string Notify(string securityToken, string nodeAddress, string dataflow, NodeDocument[] documents);

        [System.Web.Services.WebMethodAttribute()]
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("", 
            RequestNamespace = "http://www.ExchangeNetwork.net/schema/v1.0/node.xsd", 
            ResponseNamespace = "http://www.ExchangeNetwork.net/schema/v1.0/node.xsd")]
        void Download(string securityToken, string transactionId, string dataflow, ref NodeDocument[] documents);

        [System.Web.Services.WebMethodAttribute()]
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("",
            RequestNamespace = "http://www.ExchangeNetwork.net/schema/v1.0/node.xsd", 
            ResponseNamespace = "http://www.ExchangeNetwork.net/schema/v1.0/node.xsd")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        string Query(string securityToken, string request, [System.Xml.Serialization.SoapElementAttribute(DataType = "integer")] string rowId, [System.Xml.Serialization.SoapElementAttribute(DataType = "integer")] string maxRows, string[] parameters);

        [System.Web.Services.WebMethodAttribute()]
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("",
            RequestNamespace = "http://www.ExchangeNetwork.net/schema/v1.0/node.xsd", 
            ResponseNamespace = "http://www.ExchangeNetwork.net/schema/v1.0/node.xsd")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        string Solicit(string securityToken, string returnURL, string request, string[] parameters);

        [System.Web.Services.WebMethodAttribute()]
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("",
            RequestNamespace = "http://www.ExchangeNetwork.net/schema/v1.0/node.xsd", 
            ResponseNamespace = "http://www.ExchangeNetwork.net/schema/v1.0/node.xsd")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        string Execute(string securityToken, string request, string[] parameters);

        [System.Web.Services.WebMethodAttribute()]
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("",
            RequestNamespace = "http://www.ExchangeNetwork.net/schema/v1.0/node.xsd", 
            ResponseNamespace = "http://www.ExchangeNetwork.net/schema/v1.0/node.xsd")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        string NodePing(string Hello);

        [System.Web.Services.WebMethodAttribute()]
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("",
            RequestNamespace = "http://www.ExchangeNetwork.net/schema/v1.0/node.xsd", 
            ResponseNamespace = "http://www.ExchangeNetwork.net/schema/v1.0/node.xsd")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        string[] GetServices(string securityToken, string serviceType);
    }

    [System.SerializableAttribute()]
    [System.Xml.Serialization.SoapTypeAttribute(Namespace = "http://www.ExchangeNetwork.net/schema/v1.0/node.xsd")]
    public class NodeDocument
    {

        private string nameField;

        private string typeField;

        private byte[] contentField;

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        [System.Xml.Serialization.SoapIgnore]
        public byte[] content
        {
            get
            {
                return this.contentField;
            }
            set
            {
                this.contentField = value;
            }
        }
    }

}