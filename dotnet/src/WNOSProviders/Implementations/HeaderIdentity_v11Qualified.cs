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
using System.Collections.Generic;
using System.Text;

namespace Windsor.Node2008.WNOSProviders.Implementation.Docs.Qualified
{
    using System.Xml.Serialization;


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/v1.0/ExchangeNetworkDocument.xsd")]
    [System.Xml.Serialization.XmlRootAttribute("Document", Namespace = "http://www.exchangenetwork.net/schema/v1.0/ExchangeNetworkDocument.xsd", IsNullable = false)]
    public partial class ExchangeNetworkDocument
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute()]
        public DocHeader Header;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Payload")]
        public Payload[] Payload;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "ID")]
        public string Id;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/v1.0/ExchangeNetworkDocument.xsd")]
    public partial class DocHeader
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute()]
        public string Author;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute()]
        public string Organization;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute()]
        public string Title;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute()]
        public System.DateTime CreationTime;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute()]
        public string Comment;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute()]
        public string DataService;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute()]
        public string ContactInfo;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Notification", DataType = "anyURI")]
        public string[] Notification;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute()]
        public string Sensitivity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Property")]
        public NameValuePair[] Property;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/v1.0/ExchangeNetworkDocument.xsd")]
    public partial class NameValuePair
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute()]
        public string name;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute()]
        public string value;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/v1.0/ExchangeNetworkDocument.xsd")]
    public partial class Payload
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement Any;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Operation;
    }
}
