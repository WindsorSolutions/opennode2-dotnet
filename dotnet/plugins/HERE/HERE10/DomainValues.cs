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

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/HERE")]
    [System.Xml.Serialization.XmlRootAttribute("DomainValueList", Namespace = "http://www.exchangenetwork.net/schema/HERE", IsNullable = true)]
    public partial class DomainValueListDataType
    {

        private DomainList[] domainListField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("DomainList")]
        public DomainList[] DomainList
        {
            get
            {
                return this.domainListField;
            }
            set
            {
                this.domainListField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.exchangenetwork.net/schema/HERE")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/HERE", IsNullable = false)]
    public partial class DomainList
    {

        private string domainListNameTextField;

        private string originatingPartnerNameField;

        private DomainValueItemDataType[] domainListItemField;

        /// <remarks/>
        public string DomainListNameText
        {
            get
            {
                return this.domainListNameTextField;
            }
            set
            {
                this.domainListNameTextField = value;
            }
        }

        /// <remarks/>
        public string OriginatingPartnerName
        {
            get
            {
                return this.originatingPartnerNameField;
            }
            set
            {
                this.originatingPartnerNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("DomainListItem")]
        public DomainValueItemDataType[] DomainListItem
        {
            get
            {
                return this.domainListItemField;
            }
            set
            {
                this.domainListItemField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/HERE")]
    [System.Xml.Serialization.XmlRootAttribute("DomainListItem", Namespace = "http://www.exchangenetwork.net/schema/HERE", IsNullable = false)]
    public partial class DomainValueItemDataType
    {

        private string itemCodeField;

        private string itemTextField;

        private string itemDescriptionTextField;

        /// <remarks/>
        public string ItemCode
        {
            get
            {
                return this.itemCodeField;
            }
            set
            {
                this.itemCodeField = value;
            }
        }

        /// <remarks/>
        public string ItemText
        {
            get
            {
                return this.itemTextField;
            }
            set
            {
                this.itemTextField = value;
            }
        }

        /// <remarks/>
        public string ItemDescriptionText
        {
            get
            {
                return this.itemDescriptionTextField;
            }
            set
            {
                this.itemDescriptionTextField = value;
            }
        }
    }

}