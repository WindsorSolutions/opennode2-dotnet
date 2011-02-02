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

﻿using System.Xml.Serialization;

namespace Windsor.Node2008.WNOSPlugin.HERE.HERE10
{



    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/HERE/1")]
    [System.Xml.Serialization.XmlRootAttribute("HEREManifest", Namespace = "http://www.exchangenetwork.net/schema/HERE/1", IsNullable = true)]
    public partial class HEREManifestDataType
    {

        private HEREManifestItemDataType[] hEREManifestDetailsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("HEREManifestItem")]
        public HEREManifestItemDataType[] HEREManifestDetails
        {
            get
            {
                return this.hEREManifestDetailsField;
            }
            set
            {
                this.hEREManifestDetailsField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/HERE/1")]
    [System.Xml.Serialization.XmlRootAttribute("HEREManifestItem", Namespace = "http://www.exchangenetwork.net/schema/HERE/1", IsNullable = true)]
    public partial class HEREManifestItemDataType
    {

        private string transactionIdentifierField;

        private string endpointURLIdentifierField;

        private string dataExchangeNameTextField;

        private SourceInfoDataType sourceInfoField;

        private bool fullReplaceIndicatorField;

        private System.DateTime createdDateField;

        /// <remarks/>
        public string TransactionIdentifier
        {
            get
            {
                return this.transactionIdentifierField;
            }
            set
            {
                this.transactionIdentifierField = value;
            }
        }

        /// <remarks/>
        public string EndpointURLIdentifier
        {
            get
            {
                return this.endpointURLIdentifierField;
            }
            set
            {
                this.endpointURLIdentifierField = value;
            }
        }

        /// <remarks/>
        public string DataExchangeNameText
        {
            get
            {
                return this.dataExchangeNameTextField;
            }
            set
            {
                this.dataExchangeNameTextField = value;
            }
        }

        /// <remarks/>
        public SourceInfoDataType SourceInfo
        {
            get
            {
                return this.sourceInfoField;
            }
            set
            {
                this.sourceInfoField = value;
            }
        }

        /// <remarks/>
        public bool FullReplaceIndicator
        {
            get
            {
                return this.fullReplaceIndicatorField;
            }
            set
            {
                this.fullReplaceIndicatorField = value;
            }
        }

        /// <remarks/>
        public System.DateTime CreatedDate
        {
            get
            {
                return this.createdDateField;
            }
            set
            {
                this.createdDateField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/HERE/1")]
    [System.Xml.Serialization.XmlRootAttribute("SourceInfo", Namespace = "http://www.exchangenetwork.net/schema/HERE/1", IsNullable = false)]
    public partial class SourceInfoDataType
    {

        private bool isFacilitySourceIndicatorField;

        private string sourceSystemNameField;

        /// <remarks/>
        public bool IsFacilitySourceIndicator
        {
            get
            {
                return this.isFacilitySourceIndicatorField;
            }
            set
            {
                this.isFacilitySourceIndicatorField = value;
            }
        }

        /// <remarks/>
        public string SourceSystemName
        {
            get
            {
                return this.sourceSystemNameField;
            }
            set
            {
                this.sourceSystemNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/HERE/1")]
    [System.Xml.Serialization.XmlRootAttribute("HEREManifestDetails", Namespace = "http://www.exchangenetwork.net/schema/HERE/1", IsNullable = false)]
    public partial class HEREManifestDetailsDataType
    {

        private HEREManifestItemDataType[] hEREManifestItemField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("HEREManifestItem", IsNullable = true)]
        public HEREManifestItemDataType[] HEREManifestItem
        {
            get
            {
                return this.hEREManifestItemField;
            }
            set
            {
                this.hEREManifestItemField = value;
            }
        }
    }


}