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

using System.Diagnostics;
using System.Web.Services;
using System.ComponentModel;
using System.Web.Services.Protocols;
using System;
using System.Xml;
using System.Xml.Serialization;

namespace Windsor.Node2008.Endpoint2
{


    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.Web.Services.WebServiceBindingAttribute(
        Name = "NetworkNodeBinding2",
//??        Namespace = "http://www.exchangenetwork.net/wsdl/node/2")]
        Namespace = "http://www.exchangenetwork.net/schema/node/2")]
    public interface INetworkNodeBinding2
    {

        [System.Web.Services.WebMethodAttribute()]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("Authenticate",
            Use = System.Web.Services.Description.SoapBindingUse.Literal,
            ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("AuthenticateResponse",
            Namespace = "http://www.exchangenetwork.net/schema/node/2")]
        AuthenticateResponse Authenticate([System.Xml.Serialization.XmlElementAttribute("Authenticate",
            Namespace = "http://www.exchangenetwork.net/schema/node/2")] Authenticate Authenticate1);

        /// <remarks/>
        [System.Web.Services.WebMethodAttribute()]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("Submit",
            Use = System.Web.Services.Description.SoapBindingUse.Literal,
            ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("SubmitResponse",
            Namespace = "http://www.exchangenetwork.net/schema/node/2")]
        StatusResponseType Submit([System.Xml.Serialization.XmlElementAttribute("Submit",
            Namespace = "http://www.exchangenetwork.net/schema/node/2")] Submit Submit1);

        /// <remarks/>
        [System.Web.Services.WebMethodAttribute()]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("GetStatus",
            Use = System.Web.Services.Description.SoapBindingUse.Literal,
            ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("GetStatusResponse",
            Namespace = "http://www.exchangenetwork.net/schema/node/2")]
        StatusResponseType GetStatus([System.Xml.Serialization.XmlElementAttribute("GetStatus",
            Namespace = "http://www.exchangenetwork.net/schema/node/2")] GetStatus GetStatus1);

        /// <remarks/>
        [System.Web.Services.WebMethodAttribute()]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("Notify",
            Use = System.Web.Services.Description.SoapBindingUse.Literal,
            ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("NotifyResponse",
            Namespace = "http://www.exchangenetwork.net/schema/node/2")]
        StatusResponseType Notify([System.Xml.Serialization.XmlElementAttribute("Notify",
            Namespace = "http://www.exchangenetwork.net/schema/node/2")] Notify Notify1);

        /// <remarks/>
        [System.Web.Services.WebMethodAttribute()]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("Download",
            Use = System.Web.Services.Description.SoapBindingUse.Literal,
            ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlArrayAttribute("DownloadResponse",
            Namespace = "http://www.exchangenetwork.net/schema/node/2")]
        [return: System.Xml.Serialization.XmlArrayItemAttribute("documents", IsNullable = false)]
        NodeDocumentType[] Download([System.Xml.Serialization.XmlElementAttribute("Download",
            Namespace = "http://www.exchangenetwork.net/schema/node/2")] Download Download1);

        /// <remarks/>
        [System.Web.Services.WebMethodAttribute()]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("Query",
            Use = System.Web.Services.Description.SoapBindingUse.Literal,
            ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("QueryResponse",
            Namespace = "http://www.exchangenetwork.net/schema/node/2")]
        ResultSetType Query([System.Xml.Serialization.XmlElementAttribute("Query",
            Namespace = "http://www.exchangenetwork.net/schema/node/2")] Query Query1);

        /// <remarks/>
        [System.Web.Services.WebMethodAttribute()]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("Solicit",
            Use = System.Web.Services.Description.SoapBindingUse.Literal,
            ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("SolicitResponse",
            Namespace = "http://www.exchangenetwork.net/schema/node/2")]
        StatusResponseType Solicit([System.Xml.Serialization.XmlElementAttribute("Solicit",
            Namespace = "http://www.exchangenetwork.net/schema/node/2")] Solicit Solicit1);

        /// <remarks/>
        [System.Web.Services.WebMethodAttribute()]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("Execute",
            Use = System.Web.Services.Description.SoapBindingUse.Literal,
            ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("ExecuteResponse",
            Namespace = "http://www.exchangenetwork.net/schema/node/2")]
        ExecuteResponse Execute([System.Xml.Serialization.XmlElementAttribute("Execute",
            Namespace = "http://www.exchangenetwork.net/schema/node/2")] Execute Execute1);

        /// <remarks/>
        [System.Web.Services.WebMethodAttribute()]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("NodePing",
            Use = System.Web.Services.Description.SoapBindingUse.Literal,
            ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("NodePingResponse",
            Namespace = "http://www.exchangenetwork.net/schema/node/2")]
        NodePingResponse NodePing([System.Xml.Serialization.XmlElementAttribute("NodePing",
            Namespace = "http://www.exchangenetwork.net/schema/node/2")] NodePing NodePing1);

        /// <remarks/>
        [System.Web.Services.WebMethodAttribute()]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("GetServices",
            Use = System.Web.Services.Description.SoapBindingUse.Literal,
            ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("GetServicesResponse",
            Namespace = "http://www.exchangenetwork.net/schema/node/2")]
        GenericXmlType GetServices([System.Xml.Serialization.XmlElementAttribute("GetServices",
            Namespace = "http://www.exchangenetwork.net/schema/node/2")] GetServices GetServices1);
    }



    #region WSDL Classes

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

        //??private System.Xml.XmlQualifiedName parameterTypeField;

        private string parameterTypeField;

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
        public string parameterType
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
        
        /// <remarks/>
        None,
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

    #endregion
}
