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
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using System.Runtime.Serialization;

namespace Windsor.Node2008.WNOSPlugin.HERE.TIER2
{



    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TierII/1/0")]
    [System.Xml.Serialization.XmlRootAttribute("FacilityContact", Namespace = "http://www.exchangenetwork.net/schema/TierII/1/0", IsNullable = false)]
    public class FacilityContactDataType
    {

        private IndividualIdentityDataType individualIdentityField;

        private MailingAddressDataType mailingAddressField;

        private TelephonicDataType[] telephonicField;

        private string[] contactTypeField;

        private ElectronicAddressDataType[] electronicAddressField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
        public IndividualIdentityDataType IndividualIdentity
        {
            get
            {
                return this.individualIdentityField;
            }
            set
            {
                this.individualIdentityField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
        public MailingAddressDataType MailingAddress
        {
            get
            {
                return this.mailingAddressField;
            }
            set
            {
                this.mailingAddressField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Telephonic", Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
        public TelephonicDataType[] Telephonic
        {
            get
            {
                return this.telephonicField;
            }
            set
            {
                this.telephonicField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ContactType")]
        public string[] ContactType
        {
            get
            {
                return this.contactTypeField;
            }
            set
            {
                this.contactTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ElectronicAddress", Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
        public ElectronicAddressDataType[] ElectronicAddress
        {
            get
            {
                return this.electronicAddressField;
            }
            set
            {
                this.electronicAddressField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("Certifier", Namespace = "http://www.exchangenetwork.net/schema/TierII/1/0", IsNullable = false)]
    public class IndividualIdentityDataType
    {

        private IndividualIdentifierDataType individualIdentifierField;

        private string individualTitleTextField;

        private string namePrefixTextField;

        private string individualFullName;

        private string nameSuffixTextField;

        /// <remarks/>
        public IndividualIdentifierDataType IndividualIdentifier
        {
            get
            {
                return this.individualIdentifierField;
            }
            set
            {
                this.individualIdentifierField = value;
            }
        }

        /// <remarks/>
        public string IndividualTitleText
        {
            get
            {
                return this.individualTitleTextField;
            }
            set
            {
                this.individualTitleTextField = value;
            }
        }

        /// <remarks/>
        public string NamePrefixText
        {
            get
            {
                return this.namePrefixTextField;
            }
            set
            {
                this.namePrefixTextField = value;
            }
        }

        //[System.Xml.Serialization.XmlElementAttribute("FirstName", typeof(string))]
        //[System.Xml.Serialization.XmlElementAttribute("IndividualFullName", typeof(string))]
        //[System.Xml.Serialization.XmlElementAttribute("LastName", typeof(string))]
        //[System.Xml.Serialization.XmlElementAttribute("MiddleName", typeof(string))]
        public string IndividualFullName
        {
            get
            {
                return this.individualFullName;
            }
            set
            {
                this.individualFullName = value;
            }
        }

        /// <remarks/>
        public string NameSuffixText
        {
            get
            {
                return this.nameSuffixTextField;
            }
            set
            {
                this.nameSuffixTextField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("IndividualIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class IndividualIdentifierDataType
    {

        private string individualIdentifierContextField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string IndividualIdentifierContext
        {
            get
            {
                return this.individualIdentifierContextField;
            }
            set
            {
                this.individualIdentifierContextField = value;
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("ReportTypeCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class ReportTypeCodeListIdentifierDataType : CodeListIdentifierDataType
    {

    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("ReportType", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class ReportTypeDataType
    {

        private string reportTypeCodeField;

        private ReportTypeCodeListIdentifierDataType reportTypeCodeListIdentifierField;

        private string reportTypeNameField;

        /// <remarks/>
        public string ReportTypeCode
        {
            get
            {
                return this.reportTypeCodeField;
            }
            set
            {
                this.reportTypeCodeField = value;
            }
        }

        /// <remarks/>
        public ReportTypeCodeListIdentifierDataType ReportTypeCodeListIdentifier
        {
            get
            {
                return this.reportTypeCodeListIdentifierField;
            }
            set
            {
                this.reportTypeCodeListIdentifierField = value;
            }
        }

        /// <remarks/>
        public string ReportTypeName
        {
            get
            {
                return this.reportTypeNameField;
            }
            set
            {
                this.reportTypeNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("ReportIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class ReportIdentifierDataType
    {

        private string reportIdentifierContextField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ReportIdentifierContext
        {
            get
            {
                return this.reportIdentifierContextField;
            }
            set
            {
                this.reportIdentifierContextField = value;
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("ReportIdentity", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class ReportIdentityDataType
    {

        private ReportIdentifierDataType reportIdentifierField;

        private string reportDueDateField;

        private string reportReceivedDateField;

        private string reportRecipientNameField;

        private string reportingPeriodStartDateField;

        private string reportingPeriodEndDateField;

        private string revisionIndicatorField;

        private string replacedReportIdentifierField;

        private IndividualIdentityDataType reportCreateByNameField;

        private string reportCreateDateField;

        private string reportCreateTimeField;

        private ReportTypeDataType reportTypeField;

        /// <remarks/>
        public ReportIdentifierDataType ReportIdentifier
        {
            get
            {
                return this.reportIdentifierField;
            }
            set
            {
                this.reportIdentifierField = value;
            }
        }

        public string ReportDueDate
        {
            get
            {
                return this.reportDueDateField;
            }
            set
            {
                this.reportDueDateField = value;
            }
        }



        public string ReportReceivedDate
        {
            get
            {
                return this.reportReceivedDateField;
            }
            set
            {
                this.reportReceivedDateField = value;
            }
        }


        /// <remarks/>
        public string ReportRecipientName
        {
            get
            {
                return this.reportRecipientNameField;
            }
            set
            {
                this.reportRecipientNameField = value;
            }
        }


        public string ReportingPeriodStartDate
        {
            get
            {
                return this.reportingPeriodStartDateField;
            }
            set
            {
                this.reportingPeriodStartDateField = value;
            }
        }


        public string ReportingPeriodEndDate
        {
            get
            {
                return this.reportingPeriodEndDateField;
            }
            set
            {
                this.reportingPeriodEndDateField = value;
            }
        }


        /// <remarks/>
        public string RevisionIndicator
        {
            get
            {
                return this.revisionIndicatorField;
            }
            set
            {
                this.revisionIndicatorField = value;
            }
        }


        /// <remarks/>
        public string ReplacedReportIdentifier
        {
            get
            {
                return this.replacedReportIdentifierField;
            }
            set
            {
                this.replacedReportIdentifierField = value;
            }
        }

        /// <remarks/>
        public IndividualIdentityDataType ReportCreateByName
        {
            get
            {
                return this.reportCreateByNameField;
            }
            set
            {
                this.reportCreateByNameField = value;
            }
        }


        public string ReportCreateDate
        {
            get
            {
                return this.reportCreateDateField;
            }
            set
            {
                this.reportCreateDateField = value;
            }
        }



        public string ReportCreateTime
        {
            get
            {
                return this.reportCreateTimeField;
            }
            set
            {
                this.reportCreateTimeField = value;
            }
        }


        /// <remarks/>
        public ReportTypeDataType ReportType
        {
            get
            {
                return this.reportTypeField;
            }
            set
            {
                this.reportTypeField = value;
            }
        }
    }


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("NAICSIdentity", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class NAICSIdentityDataType
    {

        private string nAICSCodeField;

        private string nAICSIndustryCodeField;

        private string nAICSGroupCodeField;

        private string nAICSSubsectorCodeField;

        private string nAICSSectorCodeField;

        /// <remarks/>
        public string NAICSCode
        {
            get
            {
                return this.nAICSCodeField;
            }
            set
            {
                this.nAICSCodeField = value;
            }
        }

        /// <remarks/>
        public string NAICSIndustryCode
        {
            get
            {
                return this.nAICSIndustryCodeField;
            }
            set
            {
                this.nAICSIndustryCodeField = value;
            }
        }

        /// <remarks/>
        public string NAICSGroupCode
        {
            get
            {
                return this.nAICSGroupCodeField;
            }
            set
            {
                this.nAICSGroupCodeField = value;
            }
        }

        /// <remarks/>
        public string NAICSSubsectorCode
        {
            get
            {
                return this.nAICSSubsectorCodeField;
            }
            set
            {
                this.nAICSSubsectorCodeField = value;
            }
        }

        /// <remarks/>
        public string NAICSSectorCode
        {
            get
            {
                return this.nAICSSectorCodeField;
            }
            set
            {
                this.nAICSSectorCodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:TRI:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("FacilitySIC", Namespace = "urn:us:net:exchangenetwork:TRI:1:0", IsNullable = false)]
    public class FacilitySICDataType
    {

        private string sICCodeField;

        private string sICPrimaryIndicatorField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
        public string SICCode
        {
            get
            {
                return this.sICCodeField;
            }
            set
            {
                this.sICCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
        public string SICPrimaryIndicator
        {
            get
            {
                return this.sICPrimaryIndicatorField;
            }
            set
            {
                this.sICPrimaryIndicatorField = value;
            }
        }
    }



    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("TribalCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class TribalCodeListIdentifierDataType : CodeListIdentifierDataType
    {

    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("TribalIdentity", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class TribalIdentityCodeDataType
    {

        private string tribalCodeField;

        private TribalCodeListIdentifierDataType tribalCodeListIdentifierField;

        private string tribalNameField;

        /// <remarks/>
        public string TribalCode
        {
            get
            {
                return this.tribalCodeField;
            }
            set
            {
                this.tribalCodeField = value;
            }
        }

        /// <remarks/>
        public TribalCodeListIdentifierDataType TribalCodeListIdentifier
        {
            get
            {
                return this.tribalCodeListIdentifierField;
            }
            set
            {
                this.tribalCodeListIdentifierField = value;
            }
        }

        /// <remarks/>
        public string TribalName
        {
            get
            {
                return this.tribalNameField;
            }
            set
            {
                this.tribalNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("CountyCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class CountyCodeListIdentifierDataType : CodeListIdentifierDataType
    {

        
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("CountyIdentity", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class CountyIdentityDataType
    {

        private string countyCodeField;

        private CountyCodeListIdentifierDataType countyCodeListIdentifierField;

        private string countyNameField;

        /// <remarks/>
        public string CountyCode
        {
            get
            {
                return this.countyCodeField;
            }
            set
            {
                this.countyCodeField = value;
            }
        }

        /// <remarks/>
        public CountyCodeListIdentifierDataType CountyCodeListIdentifier
        {
            get
            {
                return this.countyCodeListIdentifierField;
            }
            set
            {
                this.countyCodeListIdentifierField = value;
            }
        }

        /// <remarks/>
        public string CountyName
        {
            get
            {
                return this.countyNameField;
            }
            set
            {
                this.countyNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("LocationAddress", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class LocationAddressDataType
    {

        private string locationAddressTextField;

        private string supplementalLocationTextField;

        private string localityNameField;

        private StateIdentityDataType stateIdentityField;

        private AddressPostalCodeDataType addressPostalCodeField;

        private CountryIdentityDataType countryIdentityField;

        private CountyIdentityDataType countyIdentityField;

        private TribalIdentityCodeDataType tribalIdentityField;

        private string tribalLandNameField;

        private string tribalLandIndicatorField;

        private bool tribalLandIndicatorFieldSpecified;

        private string locationDescriptionTextField;

        /// <remarks/>
        public string LocationAddressText
        {
            get
            {
                return this.locationAddressTextField;
            }
            set
            {
                this.locationAddressTextField = value;
            }
        }

        /// <remarks/>
        public string SupplementalLocationText
        {
            get
            {
                return this.supplementalLocationTextField;
            }
            set
            {
                this.supplementalLocationTextField = value;
            }
        }

        /// <remarks/>
        public string LocalityName
        {
            get
            {
                return this.localityNameField;
            }
            set
            {
                this.localityNameField = value;
            }
        }

        /// <remarks/>
        public StateIdentityDataType StateIdentity
        {
            get
            {
                return this.stateIdentityField;
            }
            set
            {
                this.stateIdentityField = value;
            }
        }

        /// <remarks/>
        public AddressPostalCodeDataType AddressPostalCode
        {
            get
            {
                return this.addressPostalCodeField;
            }
            set
            {
                this.addressPostalCodeField = value;
            }
        }

        /// <remarks/>
        public CountryIdentityDataType CountryIdentity
        {
            get
            {
                return this.countryIdentityField;
            }
            set
            {
                this.countryIdentityField = value;
            }
        }

        /// <remarks/>
        public CountyIdentityDataType CountyIdentity
        {
            get
            {
                return this.countyIdentityField;
            }
            set
            {
                this.countyIdentityField = value;
            }
        }

        /// <remarks/>
        public TribalIdentityCodeDataType TribalIdentity
        {
            get
            {
                return this.tribalIdentityField;
            }
            set
            {
                this.tribalIdentityField = value;
            }
        }

        /// <remarks/>
        public string TribalLandName
        {
            get
            {
                return this.tribalLandNameField;
            }
            set
            {
                this.tribalLandNameField = value;
            }
        }

        /// <remarks/>
        public string TribalLandIndicator
        {
            get
            {
                return this.tribalLandIndicatorField;
            }
            set
            {
                this.tribalLandIndicatorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TribalLandIndicatorSpecified
        {
            get
            {
                return this.tribalLandIndicatorFieldSpecified;
            }
            set
            {
                this.tribalLandIndicatorFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string LocationDescriptionText
        {
            get
            {
                return this.locationDescriptionTextField;
            }
            set
            {
                this.locationDescriptionTextField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("StateIdentity", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class StateIdentityDataType
    {

        private string stateCodeField;

        private StateCodeListIdentifierDataType stateCodeListIdentifierField;

        private string stateNameField;

        /// <remarks/>
        public string StateCode
        {
            get
            {
                return this.stateCodeField;
            }
            set
            {
                this.stateCodeField = value;
            }
        }

        /// <remarks/>
        public StateCodeListIdentifierDataType StateCodeListIdentifier
        {
            get
            {
                return this.stateCodeListIdentifierField;
            }
            set
            {
                this.stateCodeListIdentifierField = value;
            }
        }

        /// <remarks/>
        public string StateName
        {
            get
            {
                return this.stateNameField;
            }
            set
            {
                this.stateNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("StateCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class StateCodeListIdentifierDataType : CodeListIdentifierDataType
    {

    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("AddressPostalCode", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class AddressPostalCodeDataType
    {

        private string addressPostalCodeContextField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string AddressPostalCodeContext
        {
            get
            {
                return this.addressPostalCodeContextField;
            }
            set
            {
                this.addressPostalCodeContextField = value;
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("CountryIdentity", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class CountryIdentityDataType
    {

        private string countryCodeField;

        private CountryCodeListIdentifierDataType countryCodeListIdentifierField;

        private string countryNameField;

        /// <remarks/>
        public string CountryCode
        {
            get
            {
                return this.countryCodeField;
            }
            set
            {
                this.countryCodeField = value;
            }
        }

        /// <remarks/>
        public CountryCodeListIdentifierDataType CountryCodeListIdentifier
        {
            get
            {
                return this.countryCodeListIdentifierField;
            }
            set
            {
                this.countryCodeListIdentifierField = value;
            }
        }

        /// <remarks/>
        public string CountryName
        {
            get
            {
                return this.countryNameField;
            }
            set
            {
                this.countryNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("CountryCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class CountryCodeListIdentifierDataType : CodeListIdentifierDataType
    {

    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("FacilitySiteIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class FacilitySiteIdentifierDataType
    {

        private string facilitySiteIdentifierContextField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FacilitySiteIdentifierContext
        {
            get
            {
                return this.facilitySiteIdentifierContextField;
            }
            set
            {
                this.facilitySiteIdentifierContextField = value;
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("ElectronicAddress", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class ElectronicAddressDataType
    {

        private string electronicAddressTextField;

        private string electronicAddressTypeNameField;

        /// <remarks/>
        public string ElectronicAddressText
        {
            get
            {
                return this.electronicAddressTextField;
            }
            set
            {
                this.electronicAddressTextField = value;
            }
        }

        /// <remarks/>
        public string ElectronicAddressTypeName
        {
            get
            {
                return this.electronicAddressTypeNameField;
            }
            set
            {
                this.electronicAddressTypeNameField = value;
            }
        }

    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("Telephonic", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class TelephonicDataType
    {

        private string telephoneNumberTextField;

        private string telephoneNumberTypeNameField;

        private string telephoneExtensionNumberTextField;

        /// <remarks/>
        public string TelephoneNumberText
        {
            get
            {
                return this.telephoneNumberTextField;
            }
            set
            {
                this.telephoneNumberTextField = value;
            }
        }

        /// <remarks/>
        public string TelephoneNumberTypeName
        {
            get
            {
                return this.telephoneNumberTypeNameField;
            }
            set
            {
                this.telephoneNumberTypeNameField = value;
            }
        }

        /// <remarks/>
        public string TelephoneExtensionNumberText
        {
            get
            {
                return this.telephoneExtensionNumberTextField;
            }
            set
            {
                this.telephoneExtensionNumberTextField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(MailingAddressDataType1))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("MailingAddress", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class MailingAddressDataType
    {

        private string mailingAddressTextField;

        private string supplementalAddressTextField;

        private string mailingAddressCityNameField;

        private StateIdentityDataType stateIdentityField;

        private AddressPostalCodeDataType addressPostalCodeField;

        private CountryIdentityDataType countryIdentityField;

        /// <remarks/>
        public string MailingAddressText
        {
            get
            {
                return this.mailingAddressTextField;
            }
            set
            {
                this.mailingAddressTextField = value;
            }
        }

        /// <remarks/>
        public string SupplementalAddressText
        {
            get
            {
                return this.supplementalAddressTextField;
            }
            set
            {
                this.supplementalAddressTextField = value;
            }
        }

        /// <remarks/>
        public string MailingAddressCityName
        {
            get
            {
                return this.mailingAddressCityNameField;
            }
            set
            {
                this.mailingAddressCityNameField = value;
            }
        }

        /// <remarks/>
        public StateIdentityDataType StateIdentity
        {
            get
            {
                return this.stateIdentityField;
            }
            set
            {
                this.stateIdentityField = value;
            }
        }

        /// <remarks/>
        public AddressPostalCodeDataType AddressPostalCode
        {
            get
            {
                return this.addressPostalCodeField;
            }
            set
            {
                this.addressPostalCodeField = value;
            }
        }

        /// <remarks/>
        public CountryIdentityDataType CountryIdentity
        {
            get
            {
                return this.countryIdentityField;
            }
            set
            {
                this.countryIdentityField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "MailingAddressDataType", Namespace = "urn:us:net:exchangenetwork:TRI:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("MailingAddress", Namespace = "urn:us:net:exchangenetwork:TRI:1:0", IsNullable = false)]
    public class MailingAddressDataType1 : MailingAddressDataType
    {

        private string provinceNameTextField;

        /// <remarks/>
        public string ProvinceNameText
        {
            get
            {
                return this.provinceNameTextField;
            }
            set
            {
                this.provinceNameTextField = value;
            }
        }
    }


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TierII/1/0")]
    [System.Xml.Serialization.XmlRootAttribute("TierIIFacility", Namespace = "http://www.exchangenetwork.net/schema/TierII/1/0", IsNullable = false)]
    public class TierIIFacilityDataType
    {

        private FacilitySiteIdentifierDataType[] facilityIdentifierField;

        private string facilitySiteNameField;

        private string facilityStatusField;

        private LocationAddressDataType locationAddressField;

        private string mailingFacilitySiteNameField;

        private MailingAddressDataType1 mailingAddressField;

        private FacilitySICDataType[] facilitySICField;

        private NAICSIdentityDataType[] nAICSIdentityField;

        private GeographicLocationDescriptionDataType3 geographicLocationDescription;

        private string parentCompanyNameNAIndicatorField;

        private string parentCompanyNameTextField;

        private string parentDunBradstreetCodeField;

        // TSM:
        public string FireDistrictNameText;

        private string[] facilityDunBradstreetCodeField;

        private string[] rCRAIdentificationNumberField;

        private string[] nPDESIdentificationNumberField;

        private string[] uICIdentificationNumberField;

        private FacilityContactDataType[] facilityContactField;

        [System.Xml.Serialization.XmlElementAttribute("GeographicLocationDescription", Namespace = "urn:us:net:exchangenetwork:hls:1:0")]
        public GeographicLocationDescriptionDataType3 Geo
        {
            get { return geographicLocationDescription; }
            set { geographicLocationDescription = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FacilityIdentifier", Namespace = "urn:us:net:exchangenetwork:TRI:1:0")]
        public FacilitySiteIdentifierDataType[] FacilityIdentifier
        {
            get
            {
                return this.facilityIdentifierField;
            }
            set
            {
                this.facilityIdentifierField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
        public string FacilitySiteName
        {
            get
            {
                return this.facilitySiteNameField;
            }
            set
            {
                this.facilitySiteNameField = value;
            }
        }

        /// <remarks/>
        public string FacilityStatus
        {
            get
            {
                return this.facilityStatusField;
            }
            set
            {
                this.facilityStatusField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
        public LocationAddressDataType LocationAddress
        {
            get
            {
                return this.locationAddressField;
            }
            set
            {
                this.locationAddressField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:net:exchangenetwork:TRI:1:0")]
        public string MailingFacilitySiteName
        {
            get
            {
                return this.mailingFacilitySiteNameField;
            }
            set
            {
                this.mailingFacilitySiteNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:net:exchangenetwork:TRI:1:0")]
        public MailingAddressDataType1 MailingAddress
        {
            get
            {
                return this.mailingAddressField;
            }
            set
            {
                this.mailingAddressField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FacilitySIC", Namespace = "urn:us:net:exchangenetwork:TRI:1:0")]
        public FacilitySICDataType[] FacilitySIC
        {
            get
            {
                return this.facilitySICField;
            }
            set
            {
                this.facilitySICField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NAICSIdentity", Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
        public NAICSIdentityDataType[] NAICSIdentity
        {
            get
            {
                return this.nAICSIdentityField;
            }
            set
            {
                this.nAICSIdentityField = value;
            }
        }

        public string ParentCompanyNameNAIndicator
        {
            get
            {
                return this.parentCompanyNameNAIndicatorField;
            }
            set
            {
                this.parentCompanyNameNAIndicatorField = value;
            }
        }


        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:net:exchangenetwork:TRI:1:0")]
        public string ParentCompanyNameText
        {
            get
            {
                return this.parentCompanyNameTextField;
            }
            set
            {
                this.parentCompanyNameTextField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:net:exchangenetwork:TRI:1:0")]
        public string ParentDunBradstreetCode
        {
            get
            {
                return this.parentDunBradstreetCodeField;
            }
            set
            {
                this.parentDunBradstreetCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FacilityDunBradstreetCode", Namespace = "urn:us:net:exchangenetwork:TRI:1:0")]
        public string[] FacilityDunBradstreetCode
        {
            get
            {
                return this.facilityDunBradstreetCodeField;
            }
            set
            {
                this.facilityDunBradstreetCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("RCRAIdentificationNumber", Namespace = "urn:us:net:exchangenetwork:TRI:1:0")]
        public string[] RCRAIdentificationNumber
        {
            get
            {
                return this.rCRAIdentificationNumberField;
            }
            set
            {
                this.rCRAIdentificationNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NPDESIdentificationNumber", Namespace = "urn:us:net:exchangenetwork:TRI:1:0")]
        public string[] NPDESIdentificationNumber
        {
            get
            {
                return this.nPDESIdentificationNumberField;
            }
            set
            {
                this.nPDESIdentificationNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("UICIdentificationNumber", Namespace = "urn:us:net:exchangenetwork:TRI:1:0")]
        public string[] UICIdentificationNumber
        {
            get
            {
                return this.uICIdentificationNumberField;
            }
            set
            {
                this.uICIdentificationNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FacilityContact")]
        public FacilityContactDataType[] FacilityContact
        {
            get
            {
                return this.facilityContactField;
            }
            set
            {
                this.facilityContactField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TierII/1/0")]
    [System.Xml.Serialization.XmlRootAttribute("ChemicalInventory", Namespace = "http://www.exchangenetwork.net/schema/TierII/1/0", IsNullable = false)]
    public class ChemicalInventoryDataType
    {

        private ChemicalIndentificationDataType chemicalIdentificationField;

        private string[] chemicalPhysicalStateField;

        private string eHSIndicatorField;

        private string[] healthEffectsField;

        private string[] hazardTypeField;

        private string tradeSecretIndicatorField;

        private ChemicalInventoryDetailsDataType[] chemicalInventoryDetailsField;

        private ChemicalStorageLocationDataType[] chemicalStorageLocationsField;

        private MixtureComponentsDataType[] mixtureComponentsField;

        /// <remarks/>
        public ChemicalIndentificationDataType ChemicalIdentification
        {
            get
            {
                return this.chemicalIdentificationField;
            }
            set
            {
                this.chemicalIdentificationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ChemicalPhysicalState")]
        public string[] ChemicalPhysicalState
        {
            get
            {
                return this.chemicalPhysicalStateField;
            }
            set
            {
                this.chemicalPhysicalStateField = value;
            }
        }

        /// <remarks/>
        public string EHSIndicator
        {
            get
            {
                return this.eHSIndicatorField;
            }
            set
            {
                this.eHSIndicatorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("HealthEffects")]
        public string[] HealthEffects
        {
            get
            {
                return this.healthEffectsField;
            }
            set
            {
                this.healthEffectsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("HazardType")]
        public string[] HazardType
        {
            get
            {
                return this.hazardTypeField;
            }
            set
            {
                this.hazardTypeField = value;
            }
        }

        /// <remarks/>
        public string TradeSecretIndicator
        {
            get
            {
                return this.tradeSecretIndicatorField;
            }
            set
            {
                this.tradeSecretIndicatorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ChemicalInventoryDetails")]
        public ChemicalInventoryDetailsDataType[] ChemicalInventoryDetails
        {
            get
            {
                return this.chemicalInventoryDetailsField;
            }
            set
            {
                this.chemicalInventoryDetailsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ChemicalStorageLocations")]
        public ChemicalStorageLocationDataType[] ChemicalStorageLocations
        {
            get
            {
                return this.chemicalStorageLocationsField;
            }
            set
            {
                this.chemicalStorageLocationsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MixtureComponents")]
        public MixtureComponentsDataType[] MixtureComponents
        {
            get
            {
                return this.mixtureComponentsField;
            }
            set
            {
                this.mixtureComponentsField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TierII/1/0")]
    [System.Xml.Serialization.XmlRootAttribute("ChemicalIdentification", Namespace = "http://www.exchangenetwork.net/schema/TierII/1/0", IsNullable = false)]
    public class ChemicalIndentificationDataType
    {

        private string cASNumberField;

        private string chemicalSubstanceSystematicNameField;

        private string ePAChemicalRegistryNameField;

        private string ePAChemicalIdentifierField;

        private string chemicalNameContextField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
        public string CASNumber
        {
            get
            {
                return this.cASNumberField;
            }
            set
            {
                this.cASNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
        public string ChemicalSubstanceSystematicName
        {
            get
            {
                return this.chemicalSubstanceSystematicNameField;
            }
            set
            {
                this.chemicalSubstanceSystematicNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
        public string EPAChemicalRegistryName
        {
            get
            {
                return this.ePAChemicalRegistryNameField;
            }
            set
            {
                this.ePAChemicalRegistryNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
        public string EPAChemicalIdentifier
        {
            get
            {
                return this.ePAChemicalIdentifierField;
            }
            set
            {
                this.ePAChemicalIdentifierField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
        public string ChemicalNameContext
        {
            get
            {
                return this.chemicalNameContextField;
            }
            set
            {
                this.chemicalNameContextField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TierII/1/0")]
    [System.Xml.Serialization.XmlRootAttribute("ChemicalInventoryDetails", Namespace = "http://www.exchangenetwork.net/schema/TierII/1/0", IsNullable = false)]
    public class ChemicalInventoryDetailsDataType
    {

        private string numberOfDaysOnsiteField;

        private string maximumDailyAmountField;

        private string maximumCodeField;

        private string averageDailyAmountField;

        private string averageCodeField;

        /// <remarks/>
        public string NumberOfDaysOnsite
        {
            get
            {
                return this.numberOfDaysOnsiteField;
            }
            set
            {
                this.numberOfDaysOnsiteField = value;
            }
        }

        /// <remarks/>
        public string MaximumDailyAmount
        {
            get
            {
                return this.maximumDailyAmountField;
            }
            set
            {
                this.maximumDailyAmountField = value;
            }
        }

        /// <remarks/>
        public string MaximumCode
        {
            get
            {
                return this.maximumCodeField;
            }
            set
            {
                this.maximumCodeField = value;
            }
        }

        /// <remarks/>
        public string AverageDailyAmount
        {
            get
            {
                return this.averageDailyAmountField;
            }
            set
            {
                this.averageDailyAmountField = value;
            }
        }

        /// <remarks/>
        public string AverageCode
        {
            get
            {
                return this.averageCodeField;
            }
            set
            {
                this.averageCodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TierII/1/0")]
    [System.Xml.Serialization.XmlRootAttribute("ChemicalStorageLocations", Namespace = "http://www.exchangenetwork.net/schema/TierII/1/0", IsNullable = false)]
    public class ChemicalStorageLocationDataType
    {

        private string confidentialLocationIndicatorField;

        private string storageTypeCodeField;

        private string storageTypeDescriptionField;

        private string storageLocationTemperatureCodeField;

        private string storageLocationTemperatureDescriptionField;

        private string storageLocationPressureCodeField;

        private string storageLocationPressureDescriptionField;

        private string storageLocationDescriptionField;

        private string maximumAmountAtLocationField;

        private string measurementUnitField;

        /// <remarks/>
        public string ConfidentialLocationIndicator
        {
            get
            {
                return this.confidentialLocationIndicatorField;
            }
            set
            {
                this.confidentialLocationIndicatorField = value;
            }
        }

        /// <remarks/>
        public string StorageTypeCode
        {
            get
            {
                return this.storageTypeCodeField;
            }
            set
            {
                this.storageTypeCodeField = value;
            }
        }

        /// <remarks/>
        public string StorageTypeDescription
        {
            get
            {
                return this.storageTypeDescriptionField;
            }
            set
            {
                this.storageTypeDescriptionField = value;
            }
        }

        /// <remarks/>
        public string StorageLocationTemperatureCode
        {
            get
            {
                return this.storageLocationTemperatureCodeField;
            }
            set
            {
                this.storageLocationTemperatureCodeField = value;
            }
        }

        /// <remarks/>
        public string StorageLocationTemperatureDescription
        {
            get
            {
                return this.storageLocationTemperatureDescriptionField;
            }
            set
            {
                this.storageLocationTemperatureDescriptionField = value;
            }
        }

        /// <remarks/>
        public string StorageLocationPressureCode
        {
            get
            {
                return this.storageLocationPressureCodeField;
            }
            set
            {
                this.storageLocationPressureCodeField = value;
            }
        }

        /// <remarks/>
        public string StorageLocationPressureDescription
        {
            get
            {
                return this.storageLocationPressureDescriptionField;
            }
            set
            {
                this.storageLocationPressureDescriptionField = value;
            }
        }

        /// <remarks/>
        public string StorageLocationDescription
        {
            get
            {
                return this.storageLocationDescriptionField;
            }
            set
            {
                this.storageLocationDescriptionField = value;
            }
        }

        /// <remarks/>
        public string MaximumAmountAtLocation
        {
            get
            {
                return this.maximumAmountAtLocationField;
            }
            set
            {
                this.maximumAmountAtLocationField = value;
            }
        }

        /// <remarks/>
        public string MeasurementUnit
        {
            get
            {
                return this.measurementUnitField;
            }
            set
            {
                this.measurementUnitField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TierII/1/0")]
    [System.Xml.Serialization.XmlRootAttribute("MixtureComponents", Namespace = "http://www.exchangenetwork.net/schema/TierII/1/0", IsNullable = false)]
    public class MixtureComponentsDataType
    {

        private string cASNumberField;

        private string componentField;

        private string componentPercentageField;

        private string weightOrVolumeField;

        // TSM:
        public string EHSIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
        public string CASNumber
        {
            get
            {
                return this.cASNumberField;
            }
            set
            {
                this.cASNumberField = value;
            }
        }

        /// <remarks/>
        public string Component
        {
            get
            {
                return this.componentField;
            }
            set
            {
                this.componentField = value;
            }
        }

        /// <remarks/>
        public string ComponentPercentage
        {
            get
            {
                return this.componentPercentageField;
            }
            set
            {
                this.componentPercentageField = value;
            }
        }

        /// <remarks/>
        public string WeightOrVolume
        {
            get
            {
                return this.weightOrVolumeField;
            }
            set
            {
                this.weightOrVolumeField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TierII/1/0")]
    [System.Xml.Serialization.XmlRootAttribute("Attachment", Namespace = "http://www.exchangenetwork.net/schema/TierII/1/0", IsNullable = false)]
    public class AttachmentDataType
    {

        private string attachmentIdentifierField;

        private string requiredAttachmentNameField;

        private string requiredAttachmentTypeCodeField;

        private string maximumFileSizeField;

        private string additionalRequirementTextField;

        private string fileIncludedIndicatorField;

        private string submittedAttachmentField;

        private string submittedFileNameField;

        private string submittedDocumentTypeCodeField;

        private string submittedFileSizeField;

        private string fileSentMethodField;

        /// <remarks/>
        public string AttachmentIdentifier
        {
            get
            {
                return this.attachmentIdentifierField;
            }
            set
            {
                this.attachmentIdentifierField = value;
            }
        }

        /// <remarks/>
        public string RequiredAttachmentName
        {
            get
            {
                return this.requiredAttachmentNameField;
            }
            set
            {
                this.requiredAttachmentNameField = value;
            }
        }

        /// <remarks/>
        public string RequiredAttachmentTypeCode
        {
            get
            {
                return this.requiredAttachmentTypeCodeField;
            }
            set
            {
                this.requiredAttachmentTypeCodeField = value;
            }
        }

        /// <remarks/>
        public string MaximumFileSize
        {
            get
            {
                return this.maximumFileSizeField;
            }
            set
            {
                this.maximumFileSizeField = value;
            }
        }

        /// <remarks/>
        public string AdditionalRequirementText
        {
            get
            {
                return this.additionalRequirementTextField;
            }
            set
            {
                this.additionalRequirementTextField = value;
            }
        }

        /// <remarks/>
        public string FileIncludedIndicator
        {
            get
            {
                return this.fileIncludedIndicatorField;
            }
            set
            {
                this.fileIncludedIndicatorField = value;
            }
        }

        /// <remarks/>
        public string SubmittedAttachment
        {
            get
            {
                return this.submittedAttachmentField;
            }
            set
            {
                this.submittedAttachmentField = value;
            }
        }

        /// <remarks/>
        public string SubmittedFileName
        {
            get
            {
                return this.submittedFileNameField;
            }
            set
            {
                this.submittedFileNameField = value;
            }
        }

        /// <remarks/>
        public string SubmittedDocumentTypeCode
        {
            get
            {
                return this.submittedDocumentTypeCodeField;
            }
            set
            {
                this.submittedDocumentTypeCodeField = value;
            }
        }

        /// <remarks/>
        public string SubmittedFileSize
        {
            get
            {
                return this.submittedFileSizeField;
            }
            set
            {
                this.submittedFileSizeField = value;
            }
        }

        /// <remarks/>
        public string FileSentMethod
        {
            get
            {
                return this.fileSentMethodField;
            }
            set
            {
                this.fileSentMethodField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TierII/1/0")]
    [System.Xml.Serialization.XmlRootAttribute("TierIIReport", Namespace = "http://www.exchangenetwork.net/schema/TierII/1/0", IsNullable = false)]
    public class TierIIReportDataType
    {

        private ReportIdentityDataType reportIdentityField;

        private TierIIFacilityDataType tierIIFacilityField;

        private ChemicalInventoryDataType[] chemicalInventoryField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
        public ReportIdentityDataType ReportIdentity
        {
            get
            {
                return this.reportIdentityField;
            }
            set
            {
                this.reportIdentityField = value;
            }
        }

        /// <remarks/>
        public TierIIFacilityDataType TierIIFacility
        {
            get
            {
                return this.tierIIFacilityField;
            }
            set
            {
                this.tierIIFacilityField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ChemicalInventory")]
        public ChemicalInventoryDataType[] ChemicalInventory
        {
            get
            {
                return this.chemicalInventoryField;
            }
            set
            {
                this.chemicalInventoryField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TierII/1/0")]
    [System.Xml.Serialization.XmlRootAttribute("Certification", Namespace = "http://www.exchangenetwork.net/schema/TierII/1/0", IsNullable = false)]
    public class CertificationDataType
    {

        private string[] certificationStatementField;

        private IndividualIdentityDataType certifierField;

        private CertifierContactDataType certifierContactField;

        private System.DateTime certificationDateField;

        private bool certificationDateFieldSpecified;

        private string certifiedIndicatorField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CertificationStatement")]
        public string[] CertificationStatement
        {
            get
            {
                return this.certificationStatementField;
            }
            set
            {
                this.certificationStatementField = value;
            }
        }

        /// <remarks/>
        public IndividualIdentityDataType Certifier
        {
            get
            {
                return this.certifierField;
            }
            set
            {
                this.certifierField = value;
            }
        }

        /// <remarks/>
        public CertifierContactDataType CertifierContact
        {
            get
            {
                return this.certifierContactField;
            }
            set
            {
                this.certifierContactField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime CertificationDate
        {
            get
            {
                return this.certificationDateField;
            }
            set
            {
                this.certificationDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CertificationDateSpecified
        {
            get
            {
                return this.certificationDateFieldSpecified;
            }
            set
            {
                this.certificationDateFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string CertifiedIndicator
        {
            get
            {
                return this.certifiedIndicatorField;
            }
            set
            {
                this.certifiedIndicatorField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TierII/1/0")]
    [System.Xml.Serialization.XmlRootAttribute("CertifierContact", Namespace = "http://www.exchangenetwork.net/schema/TierII/1/0", IsNullable = false)]
    public class CertifierContactDataType
    {

        private IndividualIdentityDataType individualIdentityField;

        private ElectronicAddressDataType electronicAddressField;

        private MailingAddressDataType mailingAddressField;

        private TelephonicDataType telephonicField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
        public IndividualIdentityDataType IndividualIdentity
        {
            get
            {
                return this.individualIdentityField;
            }
            set
            {
                this.individualIdentityField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
        public ElectronicAddressDataType ElectronicAddress
        {
            get
            {
                return this.electronicAddressField;
            }
            set
            {
                this.electronicAddressField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
        public MailingAddressDataType MailingAddress
        {
            get
            {
                return this.mailingAddressField;
            }
            set
            {
                this.mailingAddressField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
        public TelephonicDataType Telephonic
        {
            get
            {
                return this.telephonicField;
            }
            set
            {
                this.telephonicField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TierII/1/0")]
    [System.Xml.Serialization.XmlRootAttribute("TierII", Namespace = "http://www.exchangenetwork.net/schema/TierII/1/0", IsNullable = false)]
    public class TierIIDataType
    {

        private SubmissionDataType[] submissionField;

        private decimal schemaVersionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Submission")]
        public SubmissionDataType[] Submission
        {
            get
            {
                return this.submissionField;
            }
            set
            {
                this.submissionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal schemaVersion
        {
            get
            {
                return this.schemaVersionField;
            }
            set
            {
                this.schemaVersionField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TierII/1/0")]
    [System.Xml.Serialization.XmlRootAttribute("Submission", Namespace = "http://www.exchangenetwork.net/schema/TierII/1/0", IsNullable = false)]
    public class SubmissionDataType
    {

        private string submissionIdentifierField;

        private string submissionDateField;

        private string submissionStatusField;

        private string submissionMethodField;

        private TierIIReportDataType[] tierIIReportField;

        /// <remarks/>
        public string SubmissionIdentifier
        {
            get
            {
                return this.submissionIdentifierField;
            }
            set
            {
                this.submissionIdentifierField = value;
            }
        }

        /// <remarks/>
        public string SubmissionDate
        {
            get
            {
                return this.submissionDateField;
            }
            set
            {
                this.submissionDateField = value;
            }
        }

        /// <remarks/>
        public string SubmissionStatus
        {
            get
            {
                return this.submissionStatusField;
            }
            set
            {
                this.submissionStatusField = value;
            }
        }

        /// <remarks/>
        public string SubmissionMethod
        {
            get
            {
                return this.submissionMethodField;
            }
            set
            {
                this.submissionMethodField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TierIIReport")]
        public TierIIReportDataType[] TierIIReport
        {
            get
            {
                return this.tierIIReportField;
            }
            set
            {
                this.tierIIReportField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.incident.com/EDXLDist/1.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.incident.com/EDXLDist/1.0", IsNullable = false)]
    public class EDXLDist
    {

        private string messageIDField;

        private string senderIDField;

        private System.DateTime dateTimeSentField;

        private string messageStatusField;

        private string messageTypeField;

        private string[] messageReferenceField;

        private string[] recipentAddressField;

        private string llconfidentiallityField;

        private EDXLDistTargetArea[] targetAreaField;

        private EDXLDistMessageElement[] messageElementField;

        /// <remarks/>
        public string messageID
        {
            get
            {
                return this.messageIDField;
            }
            set
            {
                this.messageIDField = value;
            }
        }

        /// <remarks/>
        public string senderID
        {
            get
            {
                return this.senderIDField;
            }
            set
            {
                this.senderIDField = value;
            }
        }

        /// <remarks/>
        public System.DateTime dateTimeSent
        {
            get
            {
                return this.dateTimeSentField;
            }
            set
            {
                this.dateTimeSentField = value;
            }
        }

        /// <remarks/>
        public string messageStatus
        {
            get
            {
                return this.messageStatusField;
            }
            set
            {
                this.messageStatusField = value;
            }
        }

        /// <remarks/>
        public string messageType
        {
            get
            {
                return this.messageTypeField;
            }
            set
            {
                this.messageTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("messageReference")]
        public string[] messageReference
        {
            get
            {
                return this.messageReferenceField;
            }
            set
            {
                this.messageReferenceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("recipentAddress")]
        public string[] recipentAddress
        {
            get
            {
                return this.recipentAddressField;
            }
            set
            {
                this.recipentAddressField = value;
            }
        }

        /// <remarks/>
        public string llconfidentiallity
        {
            get
            {
                return this.llconfidentiallityField;
            }
            set
            {
                this.llconfidentiallityField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("targetArea")]
        public EDXLDistTargetArea[] targetArea
        {
            get
            {
                return this.targetAreaField;
            }
            set
            {
                this.targetAreaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("messageElement")]
        public EDXLDistMessageElement[] messageElement
        {
            get
            {
                return this.messageElementField;
            }
            set
            {
                this.messageElementField = value;
            }
        }
    }




    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.incident.com/EDXLDist/1.0")]
    public class EDXLDistTargetArea
    {

        private string targetAreaDescField;

        private string[] circleField;

        private string[] polygonField;

        private object[] countryField;

        private string primaryJuristrictionField;

        private string secondaryJuristictionField;

        /// <remarks/>
        public string targetAreaDesc
        {
            get
            {
                return this.targetAreaDescField;
            }
            set
            {
                this.targetAreaDescField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("circle")]
        public string[] circle
        {
            get
            {
                return this.circleField;
            }
            set
            {
                this.circleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("polygon")]
        public string[] polygon
        {
            get
            {
                return this.polygonField;
            }
            set
            {
                this.polygonField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("country")]
        public object[] country
        {
            get
            {
                return this.countryField;
            }
            set
            {
                this.countryField = value;
            }
        }

        /// <remarks/>
        public string primaryJuristriction
        {
            get
            {
                return this.primaryJuristrictionField;
            }
            set
            {
                this.primaryJuristrictionField = value;
            }
        }

        /// <remarks/>
        public string secondaryJuristiction
        {
            get
            {
                return this.secondaryJuristictionField;
            }
            set
            {
                this.secondaryJuristictionField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.incident.com/EDXLDist/1.0")]
    public class EDXLDistMessageElement
    {

        private EDXLDistMessageElementKeyword[] keywordField;

        private EDXLDistMessageElementSenderRole senderRoleField;

        private EDXLDistMessageElementRecipentRole[] recipentRoleField;

        private EDXLDistMessageElementResponseType[] responseTypeField;

        private string confidentiallityField;

        private EDXLDistMessageElementKeyXmlContent keyXmlContentField;

        private EDXLDistMessageElementContentOject contentOjectField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("keyword")]
        public EDXLDistMessageElementKeyword[] keyword
        {
            get
            {
                return this.keywordField;
            }
            set
            {
                this.keywordField = value;
            }
        }

        /// <remarks/>
        public EDXLDistMessageElementSenderRole senderRole
        {
            get
            {
                return this.senderRoleField;
            }
            set
            {
                this.senderRoleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("recipentRole")]
        public EDXLDistMessageElementRecipentRole[] recipentRole
        {
            get
            {
                return this.recipentRoleField;
            }
            set
            {
                this.recipentRoleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("responseType")]
        public EDXLDistMessageElementResponseType[] responseType
        {
            get
            {
                return this.responseTypeField;
            }
            set
            {
                this.responseTypeField = value;
            }
        }

        /// <remarks/>
        public string confidentiallity
        {
            get
            {
                return this.confidentiallityField;
            }
            set
            {
                this.confidentiallityField = value;
            }
        }

        /// <remarks/>
        public EDXLDistMessageElementKeyXmlContent keyXmlContent
        {
            get
            {
                return this.keyXmlContentField;
            }
            set
            {
                this.keyXmlContentField = value;
            }
        }

        /// <remarks/>
        public EDXLDistMessageElementContentOject contentOject
        {
            get
            {
                return this.contentOjectField;
            }
            set
            {
                this.contentOjectField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.incident.com/EDXLDist/1.0")]
    public class EDXLDistMessageElementKeyword
    {

        private string valueListUrnField;

        private string valueField;

        /// <remarks/>
        public string valueListUrn
        {
            get
            {
                return this.valueListUrnField;
            }
            set
            {
                this.valueListUrnField = value;
            }
        }

        /// <remarks/>
        public string value
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.incident.com/EDXLDist/1.0")]
    public class EDXLDistMessageElementSenderRole
    {

        private string valueListUrnField;

        private string valueField;

        /// <remarks/>
        public string valueListUrn
        {
            get
            {
                return this.valueListUrnField;
            }
            set
            {
                this.valueListUrnField = value;
            }
        }

        /// <remarks/>
        public string value
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.incident.com/EDXLDist/1.0")]
    public class EDXLDistMessageElementRecipentRole
    {

        private string valueListUrnField;

        private string valueField;

        /// <remarks/>
        public string valueListUrn
        {
            get
            {
                return this.valueListUrnField;
            }
            set
            {
                this.valueListUrnField = value;
            }
        }

        /// <remarks/>
        public string value
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.incident.com/EDXLDist/1.0")]
    public class EDXLDistMessageElementResponseType
    {

        private string valueListUrnField;

        private string valueField;

        /// <remarks/>
        public string valueListUrn
        {
            get
            {
                return this.valueListUrnField;
            }
            set
            {
                this.valueListUrnField = value;
            }
        }

        /// <remarks/>
        public string value
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.incident.com/EDXLDist/1.0")]
    public class EDXLDistMessageElementKeyXmlContent
    {

        private System.Xml.XmlElement[] anyField;

        private System.Xml.XmlElement[] any1Field;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute(Order = 0)]
        public System.Xml.XmlElement[] Any
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
        [System.Xml.Serialization.XmlAnyElementAttribute(Order = 1)]
        public System.Xml.XmlElement[] Any1
        {
            get
            {
                return this.any1Field;
            }
            set
            {
                this.any1Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.incident.com/EDXLDist/1.0")]
    public class EDXLDistMessageElementContentOject
    {

        private object[] itemsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Payload", typeof(EDXLDistMessageElementContentOjectPayload))]
        [System.Xml.Serialization.XmlElementAttribute("Resource", typeof(EDXLDistMessageElementContentOjectResource))]
        public object[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.incident.com/EDXLDist/1.0")]
    public class EDXLDistMessageElementContentOjectPayload
    {

        private System.Xml.XmlElement[] anyField;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Any
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
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.incident.com/EDXLDist/1.0")]
    public class EDXLDistMessageElementContentOjectResource
    {

        private string resourceDescField;

        private string mimeTypeField;

        private string sizeField;

        private string uriField;

        private string derefUriField;

        private string digestField;

        /// <remarks/>
        public string resourceDesc
        {
            get
            {
                return this.resourceDescField;
            }
            set
            {
                this.resourceDescField = value;
            }
        }

        /// <remarks/>
        public string mimeType
        {
            get
            {
                return this.mimeTypeField;
            }
            set
            {
                this.mimeTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string size
        {
            get
            {
                return this.sizeField;
            }
            set
            {
                this.sizeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "anyURI")]
        public string uri
        {
            get
            {
                return this.uriField;
            }
            set
            {
                this.uriField = value;
            }
        }

        /// <remarks/>
        public string derefUri
        {
            get
            {
                return this.derefUriField;
            }
            set
            {
                this.derefUriField = value;
            }
        }

        /// <remarks/>
        public string digest
        {
            get
            {
                return this.digestField;
            }
            set
            {
                this.digestField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/EnvironmentalIncident/1/0")]
    [System.Xml.Serialization.XmlRootAttribute("Comment", Namespace = "http://www.exchangenetwork.net/schema/EnvironmentalIncident/1/0", IsNullable = false)]
    public class CommentDataType
    {

        private string commentTypeField;

        private string commentDetailsField;

        /// <remarks/>
        public string CommentType
        {
            get
            {
                return this.commentTypeField;
            }
            set
            {
                this.commentTypeField = value;
            }
        }

        /// <remarks/>
        public string CommentDetails
        {
            get
            {
                return this.commentDetailsField;
            }
            set
            {
                this.commentDetailsField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(MSDSResponsibleIndividualType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(NotificationRecipientsDataType))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/EnvironmentalIncident/1/0")]
    [System.Xml.Serialization.XmlRootAttribute("IncidentContact", Namespace = "http://www.exchangenetwork.net/schema/EnvironmentalIncident/1/0", IsNullable = false)]
    public class IncidentContactDataType
    {

        private string[] responsibilityField;

        private string[] contactTypeField;

        private IndividualIdentityDataType individualIdentityField;

        private MailingAddressDataType mailingAddressField;

        private TelephonicDataType[] telephonicField;

        private ElectronicAddressDataType[] electronicAddressField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Responsibility")]
        public string[] Responsibility
        {
            get
            {
                return this.responsibilityField;
            }
            set
            {
                this.responsibilityField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ContactType")]
        public string[] ContactType
        {
            get
            {
                return this.contactTypeField;
            }
            set
            {
                this.contactTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
        public IndividualIdentityDataType IndividualIdentity
        {
            get
            {
                return this.individualIdentityField;
            }
            set
            {
                this.individualIdentityField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
        public MailingAddressDataType MailingAddress
        {
            get
            {
                return this.mailingAddressField;
            }
            set
            {
                this.mailingAddressField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Telephonic", Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
        public TelephonicDataType[] Telephonic
        {
            get
            {
                return this.telephonicField;
            }
            set
            {
                this.telephonicField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ElectronicAddress", Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
        public ElectronicAddressDataType[] ElectronicAddress
        {
            get
            {
                return this.electronicAddressField;
            }
            set
            {
                this.electronicAddressField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/EnvironmentalIncident/1/0")]
    [System.Xml.Serialization.XmlRootAttribute("MSDSResponsibleIndividual", Namespace = "http://www.exchangenetwork.net/schema/EnvironmentalIncident/1/0", IsNullable = false)]
    public class MSDSResponsibleIndividualType : IncidentContactDataType
    {

        private OrganizationIdentityDataType organizationIdentityField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
        public OrganizationIdentityDataType OrganizationIdentity
        {
            get
            {
                return this.organizationIdentityField;
            }
            set
            {
                this.organizationIdentityField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("OrganizationIdentity", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class OrganizationIdentityDataType
    {

        private OrganizationIdentifierDataType organizationIdentifierField;

        private string organizationFormalNameField;

        /// <remarks/>
        public OrganizationIdentifierDataType OrganizationIdentifier
        {
            get
            {
                return this.organizationIdentifierField;
            }
            set
            {
                this.organizationIdentifierField = value;
            }
        }

        /// <remarks/>
        public string OrganizationFormalName
        {
            get
            {
                return this.organizationFormalNameField;
            }
            set
            {
                this.organizationFormalNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("OrganizationIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class OrganizationIdentifierDataType
    {

        private string organizationIdentifierContextField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string OrganizationIdentifierContext
        {
            get
            {
                return this.organizationIdentifierContextField;
            }
            set
            {
                this.organizationIdentifierContextField = value;
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/EnvironmentalIncident/1/0")]
    [System.Xml.Serialization.XmlRootAttribute("AlertNotification", Namespace = "http://www.exchangenetwork.net/schema/EnvironmentalIncident/1/0", IsNullable = false)]
    public class AlertNotificationDataType
    {

        private string notificationIdentifierField;

        private string notificationContentField;

        private string[] notificationSentMethodField;

        private string notificationStatusField;

        private string notificationEffectiveDateField;

        private string notificationExpirationDateField;

        private NotificationRecipientsDataType[] notificationRecipientsField;

        private string notificationTypeField;

        private string[] notificationReferenceField;

        private string notificationSentDateTimeField;

        private EDXLDist[] eDXLDistField;

        private CommentDataType[] commentField;

        /// <remarks/>
        public string NotificationIdentifier
        {
            get
            {
                return this.notificationIdentifierField;
            }
            set
            {
                this.notificationIdentifierField = value;
            }
        }

        /// <remarks/>
        public string NotificationContent
        {
            get
            {
                return this.notificationContentField;
            }
            set
            {
                this.notificationContentField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NotificationSentMethod")]
        public string[] NotificationSentMethod
        {
            get
            {
                return this.notificationSentMethodField;
            }
            set
            {
                this.notificationSentMethodField = value;
            }
        }

        /// <remarks/>
        public string NotificationStatus
        {
            get
            {
                return this.notificationStatusField;
            }
            set
            {
                this.notificationStatusField = value;
            }
        }

        /// <remarks/>
        public string NotificationEffectiveDate
        {
            get
            {
                return this.notificationEffectiveDateField;
            }
            set
            {
                this.notificationEffectiveDateField = value;
            }
        }

        /// <remarks/>
        public string NotificationExpirationDate
        {
            get
            {
                return this.notificationExpirationDateField;
            }
            set
            {
                this.notificationExpirationDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NotificationRecipients")]
        public NotificationRecipientsDataType[] NotificationRecipients
        {
            get
            {
                return this.notificationRecipientsField;
            }
            set
            {
                this.notificationRecipientsField = value;
            }
        }

        /// <remarks/>
        public string NotificationType
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
        [System.Xml.Serialization.XmlElementAttribute("NotificationReference")]
        public string[] NotificationReference
        {
            get
            {
                return this.notificationReferenceField;
            }
            set
            {
                this.notificationReferenceField = value;
            }
        }

        /// <remarks/>
        public string NotificationSentDateTime
        {
            get
            {
                return this.notificationSentDateTimeField;
            }
            set
            {
                this.notificationSentDateTimeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EDXLDist", Namespace = "http://www.incident.com/EDXLDist/1.0")]
        public EDXLDist[] EDXLDist
        {
            get
            {
                return this.eDXLDistField;
            }
            set
            {
                this.eDXLDistField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Comment")]
        public CommentDataType[] Comment
        {
            get
            {
                return this.commentField;
            }
            set
            {
                this.commentField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/EnvironmentalIncident/1/0")]
    [System.Xml.Serialization.XmlRootAttribute("NotificationRecipients", Namespace = "http://www.exchangenetwork.net/schema/EnvironmentalIncident/1/0", IsNullable = false)]
    public class NotificationRecipientsDataType : IncidentContactDataType
    {

        private OrganizationIdentityDataType organizationIdentityField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
        public OrganizationIdentityDataType OrganizationIdentity
        {
            get
            {
                return this.organizationIdentityField;
            }
            set
            {
                this.organizationIdentityField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/EnvironmentalIncident/1/0")]
    [System.Xml.Serialization.XmlRootAttribute("EmergencyAdvisory", Namespace = "http://www.exchangenetwork.net/schema/EnvironmentalIncident/1/0", IsNullable = false)]
    public class EmergencyAdvisoryDataType
    {

        private string mSDSObjectField;

        private string mSDSReceivedDateField;

        private System.DateTime mSDSSentDateField;

        private bool mSDSSentDateFieldSpecified;

        private MSDSResponsibleIndividualType mSDSResponsibleIndividualField;

        private string emergencyResponsePlanField;

        private AdvisoryDataType fireAdvisoryField;

        private AdvisoryDataType healthAdvisoryField;

        private AdvisoryDataType environmentalAdvisoryField;

        private IncidentContactDataType[] emergencyResponseTeamField;

        private CommentDataType[] commentField;

        private string mSDSSentMethodField;

        /// <remarks/>
        public string MSDSObject
        {
            get
            {
                return this.mSDSObjectField;
            }
            set
            {
                this.mSDSObjectField = value;
            }
        }

        /// <remarks/>
        public string MSDSReceivedDate
        {
            get
            {
                return this.mSDSReceivedDateField;
            }
            set
            {
                this.mSDSReceivedDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime MSDSSentDate
        {
            get
            {
                return this.mSDSSentDateField;
            }
            set
            {
                this.mSDSSentDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MSDSSentDateSpecified
        {
            get
            {
                return this.mSDSSentDateFieldSpecified;
            }
            set
            {
                this.mSDSSentDateFieldSpecified = value;
            }
        }

        /// <remarks/>
        public MSDSResponsibleIndividualType MSDSResponsibleIndividual
        {
            get
            {
                return this.mSDSResponsibleIndividualField;
            }
            set
            {
                this.mSDSResponsibleIndividualField = value;
            }
        }

        /// <remarks/>
        public string EmergencyResponsePlan
        {
            get
            {
                return this.emergencyResponsePlanField;
            }
            set
            {
                this.emergencyResponsePlanField = value;
            }
        }

        /// <remarks/>
        public AdvisoryDataType FireAdvisory
        {
            get
            {
                return this.fireAdvisoryField;
            }
            set
            {
                this.fireAdvisoryField = value;
            }
        }

        /// <remarks/>
        public AdvisoryDataType HealthAdvisory
        {
            get
            {
                return this.healthAdvisoryField;
            }
            set
            {
                this.healthAdvisoryField = value;
            }
        }

        /// <remarks/>
        public AdvisoryDataType EnvironmentalAdvisory
        {
            get
            {
                return this.environmentalAdvisoryField;
            }
            set
            {
                this.environmentalAdvisoryField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EmergencyResponseTeam")]
        public IncidentContactDataType[] EmergencyResponseTeam
        {
            get
            {
                return this.emergencyResponseTeamField;
            }
            set
            {
                this.emergencyResponseTeamField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Comment")]
        public CommentDataType[] Comment
        {
            get
            {
                return this.commentField;
            }
            set
            {
                this.commentField = value;
            }
        }

        /// <remarks/>
        public string MSDSSentMethod
        {
            get
            {
                return this.mSDSSentMethodField;
            }
            set
            {
                this.mSDSSentMethodField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/EnvironmentalIncident/1/0")]
    [System.Xml.Serialization.XmlRootAttribute("FireAdvisory", Namespace = "http://www.exchangenetwork.net/schema/EnvironmentalIncident/1/0", IsNullable = false)]
    public class AdvisoryDataType
    {

        private string advisoryIdentifierField;

        private string advisoryTypeField;

        private string preparednessField;

        private string responseProcedureField;

        private IncidentContactDataType[] emergencyContactsField;

        /// <remarks/>
        public string AdvisoryIdentifier
        {
            get
            {
                return this.advisoryIdentifierField;
            }
            set
            {
                this.advisoryIdentifierField = value;
            }
        }

        /// <remarks/>
        public string AdvisoryType
        {
            get
            {
                return this.advisoryTypeField;
            }
            set
            {
                this.advisoryTypeField = value;
            }
        }

        /// <remarks/>
        public string Preparedness
        {
            get
            {
                return this.preparednessField;
            }
            set
            {
                this.preparednessField = value;
            }
        }

        /// <remarks/>
        public string ResponseProcedure
        {
            get
            {
                return this.responseProcedureField;
            }
            set
            {
                this.responseProcedureField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EmergencyContacts")]
        public IncidentContactDataType[] EmergencyContacts
        {
            get
            {
                return this.emergencyContactsField;
            }
            set
            {
                this.emergencyContactsField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:hls:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("GeographicLocationDescription", Namespace = "urn:us:net:exchangenetwork:hls:1:0", IsNullable = false)]
    public class GeographicLocationDescriptionDataType
    {

        private string aMeasureField;

        private string bMeasureField;

        private string sourceMapScaleNumberField;

        private MeasureDataType horizontalAccuracyMeasureField;

        private ReferenceMethodDataType horizontalCollectionMethodField;

        private GeographicReferencePointDataType geographicReferencePointField;

        private GeographicReferenceDatumDataType horizontalReferenceDatumField;

        private System.DateTime dataCollectionDateField;

        private bool dataCollectionDateFieldSpecified;

        private string locationCommentsTextField;

        private MeasureDataType verticalMeasureField;

        private ReferenceMethodDataType verticalCollectionMethodField;

        private GeographicReferenceDatumDataType verticalReferenceDatumField;

        private ReferenceMethodDataType verificationMethodField;

        private CoordinateDataSourceDataType coordinateDataSourceField;

        private GeometricTypeDataType geometricTypeField;

        /// <remarks/>
        public string AMeasure
        {
            get
            {
                return this.aMeasureField;
            }
            set
            {
                this.aMeasureField = value;
            }
        }

        /// <remarks/>
        public string BMeasure
        {
            get
            {
                return this.bMeasureField;
            }
            set
            {
                this.bMeasureField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0", DataType = "nonNegativeInteger")]
        public string SourceMapScaleNumber
        {
            get
            {
                return this.sourceMapScaleNumberField;
            }
            set
            {
                this.sourceMapScaleNumberField = value;
            }
        }

        /// <remarks/>
        public MeasureDataType HorizontalAccuracyMeasure
        {
            get
            {
                return this.horizontalAccuracyMeasureField;
            }
            set
            {
                this.horizontalAccuracyMeasureField = value;
            }
        }

        /// <remarks/>
        public ReferenceMethodDataType HorizontalCollectionMethod
        {
            get
            {
                return this.horizontalCollectionMethodField;
            }
            set
            {
                this.horizontalCollectionMethodField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
        public GeographicReferencePointDataType GeographicReferencePoint
        {
            get
            {
                return this.geographicReferencePointField;
            }
            set
            {
                this.geographicReferencePointField = value;
            }
        }

        /// <remarks/>
        public GeographicReferenceDatumDataType HorizontalReferenceDatum
        {
            get
            {
                return this.horizontalReferenceDatumField;
            }
            set
            {
                this.horizontalReferenceDatumField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0", DataType = "date")]
        public System.DateTime DataCollectionDate
        {
            get
            {
                return this.dataCollectionDateField;
            }
            set
            {
                this.dataCollectionDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DataCollectionDateSpecified
        {
            get
            {
                return this.dataCollectionDateFieldSpecified;
            }
            set
            {
                this.dataCollectionDateFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
        public string LocationCommentsText
        {
            get
            {
                return this.locationCommentsTextField;
            }
            set
            {
                this.locationCommentsTextField = value;
            }
        }

        /// <remarks/>
        public MeasureDataType VerticalMeasure
        {
            get
            {
                return this.verticalMeasureField;
            }
            set
            {
                this.verticalMeasureField = value;
            }
        }

        /// <remarks/>
        public ReferenceMethodDataType VerticalCollectionMethod
        {
            get
            {
                return this.verticalCollectionMethodField;
            }
            set
            {
                this.verticalCollectionMethodField = value;
            }
        }

        /// <remarks/>
        public GeographicReferenceDatumDataType VerticalReferenceDatum
        {
            get
            {
                return this.verticalReferenceDatumField;
            }
            set
            {
                this.verticalReferenceDatumField = value;
            }
        }

        /// <remarks/>
        public ReferenceMethodDataType VerificationMethod
        {
            get
            {
                return this.verificationMethodField;
            }
            set
            {
                this.verificationMethodField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
        public CoordinateDataSourceDataType CoordinateDataSource
        {
            get
            {
                return this.coordinateDataSourceField;
            }
            set
            {
                this.coordinateDataSourceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
        public GeometricTypeDataType GeometricType
        {
            get
            {
                return this.geometricTypeField;
            }
            set
            {
                this.geometricTypeField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("HorizontalAccuracyMeasure", Namespace = "urn:us:net:exchangenetwork:hls:1:0", IsNullable = false)]
    public class MeasureDataType
    {

        private string measureValueField;

        private MeasureUnitDataType measureUnitField;

        private string measurePrecisionTextField;

        private ResultQualifierDataType resultQualifierField;

        /// <remarks/>
        public string MeasureValue
        {
            get
            {
                return this.measureValueField;
            }
            set
            {
                this.measureValueField = value;
            }
        }

        /// <remarks/>
        public MeasureUnitDataType MeasureUnit
        {
            get
            {
                return this.measureUnitField;
            }
            set
            {
                this.measureUnitField = value;
            }
        }

        /// <remarks/>
        public string MeasurePrecisionText
        {
            get
            {
                return this.measurePrecisionTextField;
            }
            set
            {
                this.measurePrecisionTextField = value;
            }
        }

        /// <remarks/>
        public ResultQualifierDataType ResultQualifier
        {
            get
            {
                return this.resultQualifierField;
            }
            set
            {
                this.resultQualifierField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("MeasureUnit", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class MeasureUnitDataType
    {

        private string measureUnitCodeField;

        private MeasureUnitCodeListIdentifierDataType measureUnitCodeListIdentifierField;

        private string measureUnitNameField;

        /// <remarks/>
        public string MeasureUnitCode
        {
            get
            {
                return this.measureUnitCodeField;
            }
            set
            {
                this.measureUnitCodeField = value;
            }
        }

        /// <remarks/>
        public MeasureUnitCodeListIdentifierDataType MeasureUnitCodeListIdentifier
        {
            get
            {
                return this.measureUnitCodeListIdentifierField;
            }
            set
            {
                this.measureUnitCodeListIdentifierField = value;
            }
        }

        /// <remarks/>
        public string MeasureUnitName
        {
            get
            {
                return this.measureUnitNameField;
            }
            set
            {
                this.measureUnitNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("MeasureUnitCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class MeasureUnitCodeListIdentifierDataType : CodeListIdentifierDataType
    {

    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("ResultQualifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class ResultQualifierDataType
    {

        private string resultQualifierCodeField;

        private ResultQualifierCodeListIdentifierDataType resultQualifierCodeListIdentifierField;

        private string resultQualifierNameField;

        /// <remarks/>
        public string ResultQualifierCode
        {
            get
            {
                return this.resultQualifierCodeField;
            }
            set
            {
                this.resultQualifierCodeField = value;
            }
        }

        /// <remarks/>
        public ResultQualifierCodeListIdentifierDataType ResultQualifierCodeListIdentifier
        {
            get
            {
                return this.resultQualifierCodeListIdentifierField;
            }
            set
            {
                this.resultQualifierCodeListIdentifierField = value;
            }
        }

        /// <remarks/>
        public string ResultQualifierName
        {
            get
            {
                return this.resultQualifierNameField;
            }
            set
            {
                this.resultQualifierNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("ResultQualifierCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class ResultQualifierCodeListIdentifierDataType : CodeListIdentifierDataType
    {

        
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("HorizontalCollectionMethod", Namespace = "urn:us:net:exchangenetwork:hls:1:0", IsNullable = false)]
    public class ReferenceMethodDataType
    {

        private string methodIdentifierCodeField;

        private MethodIdentifierCodeListIdentifierDataType methodIdentifierCodeListIdentifierField;

        private string methodNameField;

        private string methodDescriptionTextField;

        private string methodDeviationsTextField;

        /// <remarks/>
        public string MethodIdentifierCode
        {
            get
            {
                return this.methodIdentifierCodeField;
            }
            set
            {
                this.methodIdentifierCodeField = value;
            }
        }

        /// <remarks/>
        public MethodIdentifierCodeListIdentifierDataType MethodIdentifierCodeListIdentifier
        {
            get
            {
                return this.methodIdentifierCodeListIdentifierField;
            }
            set
            {
                this.methodIdentifierCodeListIdentifierField = value;
            }
        }

        /// <remarks/>
        public string MethodName
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
        public string MethodDescriptionText
        {
            get
            {
                return this.methodDescriptionTextField;
            }
            set
            {
                this.methodDescriptionTextField = value;
            }
        }

        /// <remarks/>
        public string MethodDeviationsText
        {
            get
            {
                return this.methodDeviationsTextField;
            }
            set
            {
                this.methodDeviationsTextField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("MethodIdentifierCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class MethodIdentifierCodeListIdentifierDataType : CodeListIdentifierDataType
    {

    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("GeographicReferencePoint", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class GeographicReferencePointDataType
    {

        private string geographicReferencePointCodeField;

        private ReferencePointCodeListIdentifierDataType referencePointCodeListIdentifierField;

        private string geographicReferencePointNameField;

        /// <remarks/>
        public string GeographicReferencePointCode
        {
            get
            {
                return this.geographicReferencePointCodeField;
            }
            set
            {
                this.geographicReferencePointCodeField = value;
            }
        }

        /// <remarks/>
        public ReferencePointCodeListIdentifierDataType ReferencePointCodeListIdentifier
        {
            get
            {
                return this.referencePointCodeListIdentifierField;
            }
            set
            {
                this.referencePointCodeListIdentifierField = value;
            }
        }

        /// <remarks/>
        public string GeographicReferencePointName
        {
            get
            {
                return this.geographicReferencePointNameField;
            }
            set
            {
                this.geographicReferencePointNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("ReferencePointCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class ReferencePointCodeListIdentifierDataType : CodeListIdentifierDataType
    {

    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("HorizontalReferenceDatum", Namespace = "urn:us:net:exchangenetwork:hls:1:0", IsNullable = false)]
    public class GeographicReferenceDatumDataType
    {

        private string geographicReferenceDatumCodeField;
        private GeographicReferenceDatumCodeListIdentifierDataType geographicReferenceDatumCodeListIdentifierField;
        private string geographicReferenceDatumNameField;

        /// <remarks/>
        public string GeographicReferenceDatumCode
        {
            get
            {
                return this.geographicReferenceDatumCodeField;
            }
            set
            {
                this.geographicReferenceDatumCodeField = value;
            }
        }

        /// <remarks/>
        public GeographicReferenceDatumCodeListIdentifierDataType GeographicReferenceDatumCodeListIdentifier
        {
            get
            {
                return this.geographicReferenceDatumCodeListIdentifierField;
            }
            set
            {
                this.geographicReferenceDatumCodeListIdentifierField = value;
            }
        }

        /// <remarks/>
        public string GeographicReferenceDatumName
        {
            get
            {
                return this.geographicReferenceDatumNameField;
            }
            set
            {
                this.geographicReferenceDatumNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("GeographicReferenceDatumCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class GeographicReferenceDatumCodeListIdentifierDataType : CodeListIdentifierDataType
    {

    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("CoordinateDataSource", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class CoordinateDataSourceDataType
    {

        private string coordinateDataSourceCodeField;

        private CoordinateDataSourceCodeListIdentifierDataType coordinateDataSourceCodeListIdentifierField;

        private string coordinateDataSourceNameField;

        /// <remarks/>
        public string CoordinateDataSourceCode
        {
            get
            {
                return this.coordinateDataSourceCodeField;
            }
            set
            {
                this.coordinateDataSourceCodeField = value;
            }
        }

        /// <remarks/>
        public CoordinateDataSourceCodeListIdentifierDataType CoordinateDataSourceCodeListIdentifier
        {
            get
            {
                return this.coordinateDataSourceCodeListIdentifierField;
            }
            set
            {
                this.coordinateDataSourceCodeListIdentifierField = value;
            }
        }

        /// <remarks/>
        public string CoordinateDataSourceName
        {
            get
            {
                return this.coordinateDataSourceNameField;
            }
            set
            {
                this.coordinateDataSourceNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("CoordinateDataSourceCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class CoordinateDataSourceCodeListIdentifierDataType : CodeListIdentifierDataType
    {

    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("GeometricType", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class GeometricTypeDataType
    {

        private string geometricTypeCodeField;

        private GeometricTypeCodeListIdentifierDataType geometricTypeCodeListIdentifierField;

        private string geometricTypeNameField;

        /// <remarks/>
        public string GeometricTypeCode
        {
            get
            {
                return this.geometricTypeCodeField;
            }
            set
            {
                this.geometricTypeCodeField = value;
            }
        }

        /// <remarks/>
        public GeometricTypeCodeListIdentifierDataType GeometricTypeCodeListIdentifier
        {
            get
            {
                return this.geometricTypeCodeListIdentifierField;
            }
            set
            {
                this.geometricTypeCodeListIdentifierField = value;
            }
        }

        /// <remarks/>
        public string GeometricTypeName
        {
            get
            {
                return this.geometricTypeNameField;
            }
            set
            {
                this.geometricTypeNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("GeometricTypeCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class GeometricTypeCodeListIdentifierDataType : CodeListIdentifierDataType
    {

    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("AccreditationAuthorityIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class AccreditationAuthorityIdentifierDataType
    {

        private string accreditationAuthorityIdentifierContextField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string AccreditationAuthorityIdentifierContext
        {
            get
            {
                return this.accreditationAuthorityIdentifierContextField;
            }
            set
            {
                this.accreditationAuthorityIdentifierContextField = value;
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("AgencyCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class AgencyCodeListIdentifierDataType : CodeListIdentifierDataType
    {

    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("AgencyTypeCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class AgencyTypeCodeListIdentifierDataType
    {

        private string codeListVersionIdentifierField;

        private string codeListVersionAgencyIdentifierField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionIdentifier
        {
            get
            {
                return this.codeListVersionIdentifierField;
            }
            set
            {
                this.codeListVersionIdentifierField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionAgencyIdentifier
        {
            get
            {
                return this.codeListVersionAgencyIdentifierField;
            }
            set
            {
                this.codeListVersionAgencyIdentifierField = value;
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("BiologicalGroupName", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class BiologicalGroupNameDataType
    {

        private string biologicalGroupNameContextField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string BiologicalGroupNameContext
        {
            get
            {
                return this.biologicalGroupNameContextField;
            }
            set
            {
                this.biologicalGroupNameContextField = value;
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("BiologicalSynonymName", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class BiologicalSynonymNameDataType
    {

        private string biologicalSynonymNameContextField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string BiologicalSynonymNameContext
        {
            get
            {
                return this.biologicalSynonymNameContextField;
            }
            set
            {
                this.biologicalSynonymNameContextField = value;
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("BiologicalSystematicName", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class BiologicalSystematicNameDataType
    {

        private string biologicalSystematicNameContextField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string BiologicalSystematicNameContext
        {
            get
            {
                return this.biologicalSystematicNameContextField;
            }
            set
            {
                this.biologicalSystematicNameContextField = value;
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("BiologicalVernacularName", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class BiologicalVernacularNameDataType
    {

        private string biologicalVernacularNameContextField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string BiologicalVernacularNameContext
        {
            get
            {
                return this.biologicalVernacularNameContextField;
            }
            set
            {
                this.biologicalVernacularNameContextField = value;
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("ComplianceMilestoneIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class ComplianceMilestoneIdentifierDataType
    {

        private string complianceMilestoneIdentifierContextField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ComplianceMilestoneIdentifierContext
        {
            get
            {
                return this.complianceMilestoneIdentifierContextField;
            }
            set
            {
                this.complianceMilestoneIdentifierContextField = value;
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("ComplianceMilestoneTypeCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class ComplianceMilestoneTypeCodeListIdentifierDataType : CodeListIdentifierDataType
    {

    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("ComplianceScheduleIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class ComplianceScheduleIdentifierDataType
    {

        private string complianceScheduleIdentifierContextField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ComplianceScheduleIdentifierContext
        {
            get
            {
                return this.complianceScheduleIdentifierContextField;
            }
            set
            {
                this.complianceScheduleIdentifierContextField = value;
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("ConditionIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class ConditionIdentifierDataType
    {

        private string conditionIdentifierContextField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ConditionIdentifierContext
        {
            get
            {
                return this.conditionIdentifierContextField;
            }
            set
            {
                this.conditionIdentifierContextField = value;
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("EnforcementActionIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class EnforcementActionIdentifierDataType
    {

        private string enforcementActionIdentifierContextField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string EnforcementActionIdentifierContext
        {
            get
            {
                return this.enforcementActionIdentifierContextField;
            }
            set
            {
                this.enforcementActionIdentifierContextField = value;
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("FacilityManagementTypeCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class FacilityManagementTypeCodeListIdentifierDataType : CodeListIdentifierDataType
    {

    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("FacilitySiteTypeCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class FacilitySiteTypeCodeListIdentifierDataType : CodeListIdentifierDataType
    {

    }


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("FormIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class FormIdentifierDataType
    {

        private string formIdentifierContextField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FormIdentifierContext
        {
            get
            {
                return this.formIdentifierContextField;
            }
            set
            {
                this.formIdentifierContextField = value;
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("InjunctiveReliefIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class InjunctiveReliefIdentifierDataType
    {

        private string injunctiveReliefIdentifierContextField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string InjunctiveReliefIdentifierContext
        {
            get
            {
                return this.injunctiveReliefIdentifierContextField;
            }
            set
            {
                this.injunctiveReliefIdentifierContextField = value;
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("LaboratoryIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class LaboratoryIdentifierDataType
    {

        private string laboratoryIdentifierContextField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string LaboratoryIdentifierContext
        {
            get
            {
                return this.laboratoryIdentifierContextField;
            }
            set
            {
                this.laboratoryIdentifierContextField = value;
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("MonitoringLocationIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class MonitoringLocationIdentifierDataType
    {

        private string monitoringLocationIdentifierContextField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string MonitoringLocationIdentifierContext
        {
            get
            {
                return this.monitoringLocationIdentifierContextField;
            }
            set
            {
                this.monitoringLocationIdentifierContextField = value;
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("OtherPermitIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class OtherPermitIdentifierDataType
    {

        private string otherPermitIdentifierContextField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string OtherPermitIdentifierContext
        {
            get
            {
                return this.otherPermitIdentifierContextField;
            }
            set
            {
                this.otherPermitIdentifierContextField = value;
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("PenaltyIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class PenaltyIdentifierDataType
    {

        private string penaltyIdentifierContextField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string PenaltyIdentifierContext
        {
            get
            {
                return this.penaltyIdentifierContextField;
            }
            set
            {
                this.penaltyIdentifierContextField = value;
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("PermitIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class PermitIdentifierDataType
    {

        private string permitIdentifierContextField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string PermitIdentifierContext
        {
            get
            {
                return this.permitIdentifierContextField;
            }
            set
            {
                this.permitIdentifierContextField = value;
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("PermittedFeatureIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class PermittedFeatureIdentifierDataType
    {

        private string permittedFeatureIdentifierContextField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string PermittedFeatureIdentifierContext
        {
            get
            {
                return this.permittedFeatureIdentifierContextField;
            }
            set
            {
                this.permittedFeatureIdentifierContextField = value;
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("PermitTypeCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class PermitTypeCodeListIdentifierDataType : CodeListIdentifierDataType
    {

    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("SubstanceIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class SubstanceIdentifierDataType
    {

        private string substanceIdentifierContextField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string SubstanceIdentifierContext
        {
            get
            {
                return this.substanceIdentifierContextField;
            }
            set
            {
                this.substanceIdentifierContextField = value;
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("SubstanceName", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class SubstanceNameDataType
    {

        private string substanceNameContextField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string SubstanceNameContext
        {
            get
            {
                return this.substanceNameContextField;
            }
            set
            {
                this.substanceNameContextField = value;
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("ViolationIdentifer", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class ViolationIdentiferDataType
    {

        private string violationIdentiferContextField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ViolationIdentiferContext
        {
            get
            {
                return this.violationIdentiferContextField;
            }
            set
            {
                this.violationIdentiferContextField = value;
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("ViolationTypeCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class ViolationTypeCodeListIdentifierDataType : CodeListIdentifierDataType
    {

    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("ChemicalSubstanceIdentity", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class ChemicalSubstanceIdentityDataType
    {

        private string ePAInternalTrackingNumberField;

        private string cASNumberField;

        private string chemicalSubstanceSystematicNameField;

        private string ePAChemicalRegistryNameField;

        private string ePAChemicalIdentifierField;

        private string chemicalNameContextField;

        private string ePAChemicalRegistryNameSourceTextField;

        private string ePAChemicalRegistryNameContextField;

        private string chemicalSubstanceDefinitionTextField;

        private string chemicalSubstanceCommentTextField;

        private string chemicalSubstanceSynonymField;

        private string chemicalSubstanceFormulaWeightQuantityField;

        private string chemicalSubstanceTypeNameField;

        private string chemicalSubstancesLinearStructureCodeField;

        private string chemicalStructureGraphicalDiagramField;

        private string chemicalSubstanceClassificationNameField;

        private string chemicalSynonymStatusNameField;

        private string chemicalSynonymSourceNameField;

        /// <remarks/>
        public string EPAInternalTrackingNumber
        {
            get
            {
                return this.ePAInternalTrackingNumberField;
            }
            set
            {
                this.ePAInternalTrackingNumberField = value;
            }
        }

        /// <remarks/>
        public string CASNumber
        {
            get
            {
                return this.cASNumberField;
            }
            set
            {
                this.cASNumberField = value;
            }
        }

        /// <remarks/>
        public string ChemicalSubstanceSystematicName
        {
            get
            {
                return this.chemicalSubstanceSystematicNameField;
            }
            set
            {
                this.chemicalSubstanceSystematicNameField = value;
            }
        }

        /// <remarks/>
        public string EPAChemicalRegistryName
        {
            get
            {
                return this.ePAChemicalRegistryNameField;
            }
            set
            {
                this.ePAChemicalRegistryNameField = value;
            }
        }

        /// <remarks/>
        public string EPAChemicalIdentifier
        {
            get
            {
                return this.ePAChemicalIdentifierField;
            }
            set
            {
                this.ePAChemicalIdentifierField = value;
            }
        }

        /// <remarks/>
        public string ChemicalNameContext
        {
            get
            {
                return this.chemicalNameContextField;
            }
            set
            {
                this.chemicalNameContextField = value;
            }
        }

        /// <remarks/>
        public string EPAChemicalRegistryNameSourceText
        {
            get
            {
                return this.ePAChemicalRegistryNameSourceTextField;
            }
            set
            {
                this.ePAChemicalRegistryNameSourceTextField = value;
            }
        }

        /// <remarks/>
        public string EPAChemicalRegistryNameContext
        {
            get
            {
                return this.ePAChemicalRegistryNameContextField;
            }
            set
            {
                this.ePAChemicalRegistryNameContextField = value;
            }
        }

        /// <remarks/>
        public string ChemicalSubstanceDefinitionText
        {
            get
            {
                return this.chemicalSubstanceDefinitionTextField;
            }
            set
            {
                this.chemicalSubstanceDefinitionTextField = value;
            }
        }

        /// <remarks/>
        public string ChemicalSubstanceCommentText
        {
            get
            {
                return this.chemicalSubstanceCommentTextField;
            }
            set
            {
                this.chemicalSubstanceCommentTextField = value;
            }
        }

        /// <remarks/>
        public string ChemicalSubstanceSynonym
        {
            get
            {
                return this.chemicalSubstanceSynonymField;
            }
            set
            {
                this.chemicalSubstanceSynonymField = value;
            }
        }

        /// <remarks/>
        public string ChemicalSubstanceFormulaWeightQuantity
        {
            get
            {
                return this.chemicalSubstanceFormulaWeightQuantityField;
            }
            set
            {
                this.chemicalSubstanceFormulaWeightQuantityField = value;
            }
        }

        /// <remarks/>
        public string ChemicalSubstanceTypeName
        {
            get
            {
                return this.chemicalSubstanceTypeNameField;
            }
            set
            {
                this.chemicalSubstanceTypeNameField = value;
            }
        }

        /// <remarks/>
        public string ChemicalSubstancesLinearStructureCode
        {
            get
            {
                return this.chemicalSubstancesLinearStructureCodeField;
            }
            set
            {
                this.chemicalSubstancesLinearStructureCodeField = value;
            }
        }

        /// <remarks/>
        public string ChemicalStructureGraphicalDiagram
        {
            get
            {
                return this.chemicalStructureGraphicalDiagramField;
            }
            set
            {
                this.chemicalStructureGraphicalDiagramField = value;
            }
        }

        /// <remarks/>
        public string ChemicalSubstanceClassificationName
        {
            get
            {
                return this.chemicalSubstanceClassificationNameField;
            }
            set
            {
                this.chemicalSubstanceClassificationNameField = value;
            }
        }

        /// <remarks/>
        public string ChemicalSynonymStatusName
        {
            get
            {
                return this.chemicalSynonymStatusNameField;
            }
            set
            {
                this.chemicalSynonymStatusNameField = value;
            }
        }

        /// <remarks/>
        public string ChemicalSynonymSourceName
        {
            get
            {
                return this.chemicalSynonymSourceNameField;
            }
            set
            {
                this.chemicalSynonymSourceNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(GeographicLocationDescriptionDataType2))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "GeographicLocationDescriptionDataType", Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("GeographicLocationDescription", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class GeographicLocationDescriptionDataType1
    {

        private string latitudeMeasureField;

        private string longitudeMeasureField;

        private string sourceMapScaleNumberField;

        private MeasureDataType horizontalAccuracyMeasureField;

        private ReferenceMethodDataType horizontalCollectionMethodField;

        private GeographicReferencePointDataType geographicReferencePointField;

        private GeographicReferenceDatumDataType horizontalReferenceDatumField;

        private System.DateTime dataCollectionDateField;

        private bool dataCollectionDateFieldSpecified;

        private string locationCommentsTextField;

        private MeasureDataType verticalMeasureField;

        private ReferenceMethodDataType verticalCollectionMethodField;

        private GeographicReferenceDatumDataType verticalReferenceDatumField;

        private ReferenceMethodDataType verificationMethodField;

        private CoordinateDataSourceDataType coordinateDataSourceField;

        private GeometricTypeDataType geometricTypeField;

        /// <remarks/>
        public string LatitudeMeasure
        {
            get
            {
                return this.latitudeMeasureField;
            }
            set
            {
                this.latitudeMeasureField = value;
            }
        }

        /// <remarks/>
        public string LongitudeMeasure
        {
            get
            {
                return this.longitudeMeasureField;
            }
            set
            {
                this.longitudeMeasureField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger")]
        public string SourceMapScaleNumber
        {
            get
            {
                return this.sourceMapScaleNumberField;
            }
            set
            {
                this.sourceMapScaleNumberField = value;
            }
        }

        /// <remarks/>
        public MeasureDataType HorizontalAccuracyMeasure
        {
            get
            {
                return this.horizontalAccuracyMeasureField;
            }
            set
            {
                this.horizontalAccuracyMeasureField = value;
            }
        }

        /// <remarks/>
        public ReferenceMethodDataType HorizontalCollectionMethod
        {
            get
            {
                return this.horizontalCollectionMethodField;
            }
            set
            {
                this.horizontalCollectionMethodField = value;
            }
        }

        /// <remarks/>
        public GeographicReferencePointDataType GeographicReferencePoint
        {
            get
            {
                return this.geographicReferencePointField;
            }
            set
            {
                this.geographicReferencePointField = value;
            }
        }

        /// <remarks/>
        public GeographicReferenceDatumDataType HorizontalReferenceDatum
        {
            get
            {
                return this.horizontalReferenceDatumField;
            }
            set
            {
                this.horizontalReferenceDatumField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime DataCollectionDate
        {
            get
            {
                return this.dataCollectionDateField;
            }
            set
            {
                this.dataCollectionDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DataCollectionDateSpecified
        {
            get
            {
                return this.dataCollectionDateFieldSpecified;
            }
            set
            {
                this.dataCollectionDateFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string LocationCommentsText
        {
            get
            {
                return this.locationCommentsTextField;
            }
            set
            {
                this.locationCommentsTextField = value;
            }
        }

        /// <remarks/>
        public MeasureDataType VerticalMeasure
        {
            get
            {
                return this.verticalMeasureField;
            }
            set
            {
                this.verticalMeasureField = value;
            }
        }

        /// <remarks/>
        public ReferenceMethodDataType VerticalCollectionMethod
        {
            get
            {
                return this.verticalCollectionMethodField;
            }
            set
            {
                this.verticalCollectionMethodField = value;
            }
        }

        /// <remarks/>
        public GeographicReferenceDatumDataType VerticalReferenceDatum
        {
            get
            {
                return this.verticalReferenceDatumField;
            }
            set
            {
                this.verticalReferenceDatumField = value;
            }
        }

        /// <remarks/>
        public ReferenceMethodDataType VerificationMethod
        {
            get
            {
                return this.verificationMethodField;
            }
            set
            {
                this.verificationMethodField = value;
            }
        }

        /// <remarks/>
        public CoordinateDataSourceDataType CoordinateDataSource
        {
            get
            {
                return this.coordinateDataSourceField;
            }
            set
            {
                this.coordinateDataSourceField = value;
            }
        }

        /// <remarks/>
        public GeometricTypeDataType GeometricType
        {
            get
            {
                return this.geometricTypeField;
            }
            set
            {
                this.geometricTypeField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "GeographicLocationDescriptionDataType", Namespace = "urn:us:net:exchangenetwork:TRI:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("GeographicLocationDescription", Namespace = "urn:us:net:exchangenetwork:TRI:1:0", IsNullable = false)]
    public class GeographicLocationDescriptionDataType2 : GeographicLocationDescriptionDataType1
    {

        private string latitudeDegreeMeasureField;

        private string latitudeMinuteMeasureField;

        private string latitudeSecondMeasureField;

        private string longitudeDegreeMeasureField;

        private string longitudeMinuteMeasureField;

        private string longitudeSecondMeasureField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string LatitudeDegreeMeasure
        {
            get
            {
                return this.latitudeDegreeMeasureField;
            }
            set
            {
                this.latitudeDegreeMeasureField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string LatitudeMinuteMeasure
        {
            get
            {
                return this.latitudeMinuteMeasureField;
            }
            set
            {
                this.latitudeMinuteMeasureField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string LatitudeSecondMeasure
        {
            get
            {
                return this.latitudeSecondMeasureField;
            }
            set
            {
                this.latitudeSecondMeasureField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string LongitudeDegreeMeasure
        {
            get
            {
                return this.longitudeDegreeMeasureField;
            }
            set
            {
                this.longitudeDegreeMeasureField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string LongitudeMinuteMeasure
        {
            get
            {
                return this.longitudeMinuteMeasureField;
            }
            set
            {
                this.longitudeMinuteMeasureField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string LongitudeSecondMeasure
        {
            get
            {
                return this.longitudeSecondMeasureField;
            }
            set
            {
                this.longitudeSecondMeasureField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("SubstanceIdentity", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public class SubstanceIdentityDataType
    {

        private SubstanceIdentifierDataType substanceIdentifierField;

        private SubstanceNameDataType substanceNameField;

        /// <remarks/>
        public SubstanceIdentifierDataType SubstanceIdentifier
        {
            get
            {
                return this.substanceIdentifierField;
            }
            set
            {
                this.substanceIdentifierField = value;
            }
        }

        /// <remarks/>
        public SubstanceNameDataType SubstanceName
        {
            get
            {
                return this.substanceNameField;
            }
            set
            {
                this.substanceNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:TRI:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("Facility", Namespace = "urn:us:net:exchangenetwork:TRI:1:0", IsNullable = false)]
    public class FacilityDataType
    {

        private FacilitySiteIdentifierDataType[] facilityIdentifierField;

        private string facilitySiteNameField;

        private LocationAddressDataType locationAddressField;

        private string mailingFacilitySiteNameField;

        private MailingAddressDataType1 mailingAddressField;

        private FacilitySICDataType[] facilitySICField;

        private GeographicLocationDescriptionDataType2 geographicLocationDescriptionField;

        private bool parentCompanyNameNAIndicatorField;

        private bool parentCompanyNameNAIndicatorFieldSpecified;

        private string parentCompanyNameTextField;

        private string parentDunBradstreetCodeField;

        private string[] facilityDunBradstreetCodeField;

        private string[] rCRAIdentificationNumberField;

        private string[] nPDESIdentificationNumberField;

        private string[] uICIdentificationNumberField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FacilityIdentifier")]
        public FacilitySiteIdentifierDataType[] FacilityIdentifier
        {
            get
            {
                return this.facilityIdentifierField;
            }
            set
            {
                this.facilityIdentifierField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
        public string FacilitySiteName
        {
            get
            {
                return this.facilitySiteNameField;
            }
            set
            {
                this.facilitySiteNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
        public LocationAddressDataType LocationAddress
        {
            get
            {
                return this.locationAddressField;
            }
            set
            {
                this.locationAddressField = value;
            }
        }

        /// <remarks/>
        public string MailingFacilitySiteName
        {
            get
            {
                return this.mailingFacilitySiteNameField;
            }
            set
            {
                this.mailingFacilitySiteNameField = value;
            }
        }

        /// <remarks/>
        public MailingAddressDataType1 MailingAddress
        {
            get
            {
                return this.mailingAddressField;
            }
            set
            {
                this.mailingAddressField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FacilitySIC")]
        public FacilitySICDataType[] FacilitySIC
        {
            get
            {
                return this.facilitySICField;
            }
            set
            {
                this.facilitySICField = value;
            }
        }

        /// <remarks/>
        public GeographicLocationDescriptionDataType2 GeographicLocationDescription
        {
            get
            {
                return this.geographicLocationDescriptionField;
            }
            set
            {
                this.geographicLocationDescriptionField = value;
            }
        }

        /// <remarks/>
        public bool ParentCompanyNameNAIndicator
        {
            get
            {
                return this.parentCompanyNameNAIndicatorField;
            }
            set
            {
                this.parentCompanyNameNAIndicatorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ParentCompanyNameNAIndicatorSpecified
        {
            get
            {
                return this.parentCompanyNameNAIndicatorFieldSpecified;
            }
            set
            {
                this.parentCompanyNameNAIndicatorFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string ParentCompanyNameText
        {
            get
            {
                return this.parentCompanyNameTextField;
            }
            set
            {
                this.parentCompanyNameTextField = value;
            }
        }

        /// <remarks/>
        public string ParentDunBradstreetCode
        {
            get
            {
                return this.parentDunBradstreetCodeField;
            }
            set
            {
                this.parentDunBradstreetCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FacilityDunBradstreetCode")]
        public string[] FacilityDunBradstreetCode
        {
            get
            {
                return this.facilityDunBradstreetCodeField;
            }
            set
            {
                this.facilityDunBradstreetCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("RCRAIdentificationNumber")]
        public string[] RCRAIdentificationNumber
        {
            get
            {
                return this.rCRAIdentificationNumberField;
            }
            set
            {
                this.rCRAIdentificationNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NPDESIdentificationNumber")]
        public string[] NPDESIdentificationNumber
        {
            get
            {
                return this.nPDESIdentificationNumberField;
            }
            set
            {
                this.nPDESIdentificationNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("UICIdentificationNumber")]
        public string[] UICIdentificationNumber
        {
            get
            {
                return this.uICIdentificationNumberField;
            }
            set
            {
                this.uICIdentificationNumberField = value;
            }
        }
    }










    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:hls:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("GeographicLocationDescription", Namespace = "urn:us:net:exchangenetwork:hls:1:0", IsNullable = false)]
    public class GeographicLocationDescriptionDataType3
    {

        private string aMeasureField;

        private string bMeasureField;

        private string sourceMapScaleNumberField;

        private MeasureDataType horizontalAccuracyMeasureField;

        private ReferenceMethodDataType horizontalCollectionMethodField;

        private GeographicReferencePointDataType geographicReferencePointField;

        private GeographicReferenceDatumDataType horizontalReferenceDatumField;

        private string dataCollectionDateField;

        private string locationCommentsTextField;

        private MeasureDataType verticalMeasureField;

        private ReferenceMethodDataType verticalCollectionMethodField;

        private GeographicReferenceDatumDataType verticalReferenceDatumField;

        private ReferenceMethodDataType verificationMethodField;

        private CoordinateDataSourceDataType coordinateDataSourceField;

        private GeometricTypeDataType geometricTypeField;

        /// <remarks/>
        public string AMeasure
        {
            get
            {
                return this.aMeasureField;
            }
            set
            {
                this.aMeasureField = value;
            }
        }

        /// <remarks/>
        public string BMeasure
        {
            get
            {
                return this.bMeasureField;
            }
            set
            {
                this.bMeasureField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0", DataType = "nonNegativeInteger")]
        public string SourceMapScaleNumber
        {
            get
            {
                return this.sourceMapScaleNumberField;
            }
            set
            {
                this.sourceMapScaleNumberField = value;
            }
        }

        /// <remarks/>
        public MeasureDataType HorizontalAccuracyMeasure
        {
            get
            {
                return this.horizontalAccuracyMeasureField;
            }
            set
            {
                this.horizontalAccuracyMeasureField = value;
            }
        }

        /// <remarks/>
        public ReferenceMethodDataType HorizontalCollectionMethod
        {
            get
            {
                return this.horizontalCollectionMethodField;
            }
            set
            {
                this.horizontalCollectionMethodField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
        public GeographicReferencePointDataType GeographicReferencePoint
        {
            get
            {
                return this.geographicReferencePointField;
            }
            set
            {
                this.geographicReferencePointField = value;
            }
        }

        /// <remarks/>
        public GeographicReferenceDatumDataType HorizontalReferenceDatum
        {
            get
            {
                return this.horizontalReferenceDatumField;
            }
            set
            {
                this.horizontalReferenceDatumField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
        public string DataCollectionDate
        {
            get
            {
                return this.dataCollectionDateField;
            }
            set
            {
                this.dataCollectionDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
        public string LocationCommentsText
        {
            get
            {
                return this.locationCommentsTextField;
            }
            set
            {
                this.locationCommentsTextField = value;
            }
        }

        /// <remarks/>
        public MeasureDataType VerticalMeasure
        {
            get
            {
                return this.verticalMeasureField;
            }
            set
            {
                this.verticalMeasureField = value;
            }
        }

        /// <remarks/>
        public ReferenceMethodDataType VerticalCollectionMethod
        {
            get
            {
                return this.verticalCollectionMethodField;
            }
            set
            {
                this.verticalCollectionMethodField = value;
            }
        }

        /// <remarks/>
        public GeographicReferenceDatumDataType VerticalReferenceDatum
        {
            get
            {
                return this.verticalReferenceDatumField;
            }
            set
            {
                this.verticalReferenceDatumField = value;
            }
        }

        /// <remarks/>
        public ReferenceMethodDataType VerificationMethod
        {
            get
            {
                return this.verificationMethodField;
            }
            set
            {
                this.verificationMethodField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
        public CoordinateDataSourceDataType CoordinateDataSource
        {
            get
            {
                return this.coordinateDataSourceField;
            }
            set
            {
                this.coordinateDataSourceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
        public GeometricTypeDataType GeometricType
        {
            get
            {
                return this.geometricTypeField;
            }
            set
            {
                this.geometricTypeField = value;
            }
        }
    }










    public class CodeListIdentifierDataType
    {

        private string codeListVersionIdentifierField;
        private string codeListVersionAgencyIdentifierField;
        private string valueField;

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionIdentifier
        {
            get { return this.codeListVersionIdentifierField; }
            set { this.codeListVersionIdentifierField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionAgencyIdentifier
        {
            get
            {
                return this.codeListVersionAgencyIdentifierField;
            }
            set
            {
                this.codeListVersionAgencyIdentifierField = value;
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




}