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

namespace Windsor.Node2008.WNOSPlugin.FACID30
{


    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("EnvironmentalInterestActiveIndicator", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public enum YesNoIndicatorDataType
    {

        /// <remarks/>
        Y,

        /// <remarks/>
        N,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("FacilityNAICSPrimaryIndicator", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public enum FacilityNAICSPrimaryIndicatorDataType
    {

        /// <remarks/>
        Primary,

        /// <remarks/>
        Secondary,

        /// <remarks/>
        Unknown,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("DataSource", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public partial class DataSourceDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The name of the partner that originally provided the exchanged facility site or e" +
            "nvironmental interest data.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string OriginatingPartnerName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The abbreviated name that represents the name of an information management system" +
            " for an environmental program.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string InformationSystemAcronymName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("A value corresponding to the date the facility site or environmental interest was" +
            " added to the source system or the date the partner last recorded a change to th" +
            "e data.")]
        public System.DateTime LastUpdatedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LastUpdatedDateSpecified;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("FacilityNAICS", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public partial class FacilityNAICSDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The code that represents a subdivision of an industry that accommodates user need" +
            "s in the United States.")]
        public string FacilityNAICSCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The name that indicates whether the associated NAICS Code represents the primary " +
            "activity occurring at the facility site.")]
        public FacilityNAICSPrimaryIndicatorDataType FacilityNAICSPrimaryIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool FacilityNAICSPrimaryIndicatorSpecified;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("AddressPostalCode", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public partial class AddressPostalCodeDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string AddressPostalCodeContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("AffiliationStatusText", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public enum AffiliationStatusTextDataType
    {

        /// <remarks/>
        A,

        /// <remarks/>
        I,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("")]
        Item,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("AgencyTypeCodeListIdentifier", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public partial class AgencyTypeCodeListIdentifierDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionAgencyIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("CoordinateDataSourceCodeListIdentifier", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public partial class CoordinateDataSourceCodeListIdentifierDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionAgencyIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("CountryCodeListIdentifier", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public partial class CountryCodeListIdentifierDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionAgencyIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("CountyCodeListIdentifier", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public partial class CountyCodeListIdentifierDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionAgencyIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("ElectronicAddressTypeName", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public enum ElectronicAddressTypeNameDataType
    {

        /// <remarks/>
        Email,

        /// <remarks/>
        Internet,

        /// <remarks/>
        Intranet,

        /// <remarks/>
        HTTP,

        /// <remarks/>
        FTP,

        /// <remarks/>
        Telnet,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("")]
        Item,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("FacilitySiteIdentifier", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public partial class FacilitySiteIdentifierDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FacilitySiteIdentifierContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("FacilitySiteTypeCodeListIdentifier", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public partial class FacilitySiteTypeCodeListIdentifierDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionAgencyIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("FederalFacilityIndicator", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public enum FederalFacilityIndicatorDataType
    {

        /// <remarks/>
        Y,

        /// <remarks/>
        N,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("")]
        Item,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("IndividualIdentifier", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public partial class IndividualIdentifierDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string IndividualIdentifierContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("MeasureUnitCodeListIdentifier", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public partial class MeasureUnitCodeListIdentifierDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionAgencyIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("MethodIdentifierCodeListIdentifier", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public partial class MethodIdentifierCodeListIdentifierDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionAgencyIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("OrganizationIdentifier", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public partial class OrganizationIdentifierDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string OrganizationIdentifierContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("ReferencePointCodeListIdentifier", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public partial class ReferencePointCodeListIdentifierDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionAgencyIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("ResultQualifierCodeListIdentifier", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public partial class ResultQualifierCodeListIdentifierDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionAgencyIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("SICPrimaryIndicator", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public enum SICPrimaryIndicatorDataType
    {

        /// <remarks/>
        Primary,

        /// <remarks/>
        Secondary,

        /// <remarks/>
        Unknown,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("StateCodeListIdentifier", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public partial class StateCodeListIdentifierDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionAgencyIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("TribalLandIndicator", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public enum TribalLandIndicatorDataType
    {

        /// <remarks/>
        Y,

        /// <remarks/>
        N,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("")]
        Item,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("FacilitySIC", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public partial class FacilitySICDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the economic activity of a company.")]
        public string SICCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The name that indicates whether the associated SIC Code represents the primary ac" +
            "tivity occurring at the facility site.")]
        public SICPrimaryIndicatorDataType SICPrimaryIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SICPrimaryIndicatorSpecified;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("Affiliation", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public partial class AffiliationDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The name that describes the capacity or function that an organization or individu" +
            "al serves; or the relationship between an individual or organization and a proje" +
            "ct or action.")]
        public string AffiliationTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The date on which the affiliation between the organization or individual and the " +
            "facility, project, or action began.")]
        public System.DateTime AffiliationStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AffiliationStartDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The date on which the affiliation between the organization or individual and the " +
            "facility, project, or action ended.")]
        public System.DateTime AffiliationEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AffiliationEndDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The status of an affiliation between an individual or organization and a facility" +
            ", project, or action.")]
        public AffiliationStatusTextDataType AffiliationStatusText;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AffiliationStatusTextSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The date on which the status of an affiliation between an individual or organizat" +
            "ion and a facility, project, or action is determined.")]
        public System.DateTime AffiliationStatusDetermineDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AffiliationStatusDetermineDateSpecified;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("FacilityAffiliation", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public partial class FacilityAffiliationDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A number used to uniquely identify a Affiliate, which contains data for one indiv" +
            "idual or organization.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string AffiliateIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The relationship between an individual or organization and a facility, project, o" +
            "r actions.")]
        public AffiliationDataType Affiliation;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("AlternativeIdentification", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public partial class AlternativeIdentificationDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("An alternative, historic or program specific identifier for the facility site or " +
            "environmental interest.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string AlternativeIdentificationIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The type of the alternative, historical, or program-specific identifier for the f" +
            "acility site or environmental interest. ")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string AlternativeIdentificationTypeText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("ElectronicAddress", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public partial class ElectronicAddressDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A resource address, usually consisting of the access protocol, the domain name, a" +
            "nd optionally, the path to a file or location.")]
        public string ElectronicAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The name that describes the electronic address type.")]
        public ElectronicAddressTypeNameDataType ElectronicAddressTypeName;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ElectronicAddressTypeNameSpecified;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("AgencyType", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public partial class AgencyTypeDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The code that represents a type of federal, state, or local agency.")]
        public string AgencyTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A designator specifying the code set used to provide an agency type code. Can be " +
            "used to identify the URL of a source that defines the set of currently approved " +
            "permitted values.")]
        public AgencyTypeCodeListIdentifierDataType AgencyTypeCodeListIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("A description of the agency type code.")]
        public string AgencyTypeName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("EnvironmentalInterest", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public partial class EnvironmentalInterestDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A description of the partner who originally provided the information, the acronym" +
            " representing the source system and the date the information was last updated in" +
            " the source system.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public DataSourceDataType DataSource;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A designator, such as a permit number, assigned by an information management syst" +
            "em that is used to identify an environmental interest (e.g. permit, etc.) for a " +
            "partner.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string EnvironmentalInterestIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The environmental permit or regulatory program that applies to the facility site." +
            "")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string EnvironmentalInterestTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The date the agency became interested in the facility site for a particular envir" +
            "onmental interest type.")]
        public System.DateTime EnvironmentalInterestStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EnvironmentalInterestStartDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The qualifier that specifies the meaning of  the date being used as an approximat" +
            "ion for the environmental interest start date.")]
        public string EnvironmentalInterestStartDateQualifierText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The date the agency ceased to be interested in the facility site for a particular" +
            " environmental interest type.")]
        public System.DateTime EnvironmentalInterestEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EnvironmentalInterestEndDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("The qualifier that specifies the meaning of  the date being used as an approximat" +
            "ion for the environmental interest end date.")]
        public string EnvironmentalInterestEndDateQualifierText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("A designator that indicates whether the Environmental Interest is currently consi" +
            "dered to active.")]
        public YesNoIndicatorDataType EnvironmentalInterestActiveIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EnvironmentalInterestActiveIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("A designator and associated metadata used to identify the type of federal, state," +
            " or local agency.")]
        public AgencyTypeDataType AgencyType;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 9)]
        [System.Xml.Serialization.XmlArrayItemAttribute("FacilityNAICS", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("A container for one or more NAICS codes.")]
        //TSM: public FacilityNAICSDataType[] NAICSList;
        public EnvironmentalInterestFacilityNAICSDataType[] NAICSList;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 10)]
        [System.Xml.Serialization.XmlArrayItemAttribute("FacilitySIC", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("A container for one or more SIC Codes.")]
        //TSM: public FacilitySICDataType[] SICList;
        public EnvironmentalInterestFacilitySICDataType[] SICList;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 11)]
        [System.Xml.Serialization.XmlArrayItemAttribute("FacilityAffiliation", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("A container for one or more affiliations.")]
        //TSM: public FacilityAffiliationDataType[] AffiliationList;
        public EnvironmentalInterestFacilityAffiliationDataType[] AffiliationList;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 12)]
        [System.Xml.Serialization.XmlArrayItemAttribute("AlternativeIdentification", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("A container for one or more alternative identifiers.")]
        //TSM: public AlternativeIdentificationDataType[] AlternativeIdentificationList;
        public EnvironmentalInterestAlternativeIdentificationDataType[] AlternativeIdentificationList;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 13)]
        [System.Xml.Serialization.XmlArrayItemAttribute("ElectronicAddress", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("A container for one or more electronic addresses.")]
        //TSM: public ElectronicAddressDataType[] ElectronicAddressList;
        public EnvironmentalInterestElectronicAddressDataType[] ElectronicAddressList;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("AlternativeName", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public partial class AlternativeNameDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("An alternative, historic or program specific name for the facility site.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string AlternativeNameText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The type of the alternative, historical, or program-specific name for the facilit" +
            "y site (e.g., primary, legal, historical, local).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string AlternativeNameTypeText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("FacilitySiteType", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public partial class FacilitySiteDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the type of site a facility occupies.")]
        public string FacilitySiteTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A designator specifying the code set used to provide a facility site type code. C" +
            "an be used to identify the URL of a source that defines the set of currently app" +
            "roved permitted values.")]
        public FacilitySiteTypeCodeListIdentifierDataType FacilitySiteTypeCodeListIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The descriptive name for the type of site the facility occupies.")]
        public string FacilitySiteTypeName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("FacilitySiteIdentity", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public partial class FacilitySiteIdentityDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The unique identification number used by a governmental entity to identify a faci" +
            "lity site.")]
        public FacilitySiteIdentifierDataType FacilitySiteIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The public or commercial name of a facility site (i.e., the full name that common" +
            "ly appears on invoices, signs, or other business documents, or as assigned by th" +
            "e state when the name is ambiguous).")]
        public string FacilitySiteName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("A designator and associated metadata used to represents the type of site a facili" +
            "ty occupies.")]
        public FacilitySiteDataType FacilitySiteType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("An indicator identifying facilities owned or operated by a federal government uni" +
            "t.")]
        public FederalFacilityIndicatorDataType FederalFacilityIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool FederalFacilityIndicatorSpecified;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("StateIdentity", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public partial class StateIdentityDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A code designator used to identify a principal administrative subdivision of the " +
            "United States, Canada, or Mexico.")]
        public string StateCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A designator specifying the code set used to provide a state code. Can be used to" +
            " identify the URL of a source that defines the set of currently approved permitt" +
            "ed values.")]
        public StateCodeListIdentifierDataType StateCodeListIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("A name used to identify a principal administrative subdivision of the United Stat" +
            "es, Canada, or Mexico.")]
        public string StateName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("CountryIdentity", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public partial class CountryIdentityDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A code designator used to identify a primary geopolitical unit of the world.")]
        public string CountryCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A designator specifying the code set used to provide a country code. Can be used " +
            "to identify the URL of a source that defines the set of currently approved permi" +
            "tted values.")]
        public CountryCodeListIdentifierDataType CountryCodeListIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("A name used to identify a primary geopolitical unit of the world.")]
        public string CountryName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("CountyIdentity", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public partial class CountyIdentityDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the county.")]
        public string CountyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A designator specifying the code set used to provide a county code. Can be used t" +
            "o identify the URL of a source that defines the set of currently approved permit" +
            "ted values.")]
        public CountyCodeListIdentifierDataType CountyCodeListIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("A description of the county code.")]
        public string CountyName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("LocationAddress", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public partial class LocationAddressDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The address that describes the physical (geographic) location of the front door o" +
            "r main entrance of a facility site, including urban-style street address or rura" +
            "l address.")]
        public string LocationAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The text that provides additional information about a place, including a building" +
            " name with its secondary unit and number, an industrial park name, an installati" +
            "on name or descriptive text where no formal address is available.")]
        public string SupplementalLocationText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The name of a city, town, village or other locality.")]
        public string LocalityName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("A designator and associated metadata used to identify a principal administrative " +
            "subdivision of the United States, Canada, or Mexico.")]
        public StateIdentityDataType StateIdentity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute(@"The combination of the 5-digit Zone Improvement Plan (ZIP) code and the four-digit extension code (if available) that represents the geographic segment that is a subunit of the ZIP Code, assigned by the U.S. Postal Service to a geographic location to facilitate mail delivery; or the postal zone specific to the country, other than the U.S., where the mail is delivered.")]
        public AddressPostalCodeDataType AddressPostalCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("A designator and associated metadata used to identify a primary geopolitical unit" +
            " of the world.")]
        public CountryIdentityDataType CountryIdentity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("A designator and associated metadata used to identify a U.S. county or county equ" +
            "ivalent.")]
        public CountyIdentityDataType CountyIdentity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("The name of an American Indian or Alaskan native area where the location address " +
            "exists.")]
        public string TribalLandName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("An indicator denoting the location address is a tribal land")]
        public TribalLandIndicatorDataType TribalLandIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TribalLandIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("A brief explanation of a location, including navigational directions and/or more " +
            "descriptive information.")]
        public string LocationDescriptionText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("MailingAddress", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public partial class MailingAddressDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The exact address where a mail piece is intended to be delivered, including urban" +
            "-style street address, rural route, and PO Box.")]
        public string MailingAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The text that provides additional information to facilitate the delivery of a mai" +
            "l piece, including building name, secondary units, and mail stop or local box nu" +
            "mbers not serviced by the U.S. Postal Service.")]
        public string SupplementalAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The name of the city, town, or village where the mail is delivered.")]
        public string MailingAddressCityName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("A designator and associated metadata used to identify a principal administrative " +
            "subdivision of the United States, Canada, or Mexico.")]
        public StateIdentityDataType StateIdentity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute(@"The combination of the 5-digit Zone Improvement Plan (ZIP) code and the four-digit extension code (if available) that represents the geographic segment that is a subunit of the ZIP Code, assigned by the U.S. Postal Service to a geographic location to facilitate mail delivery; or the postal zone specific to the country, other than the U.S., where the mail is delivered.")]
        public AddressPostalCodeDataType AddressPostalCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("A designator and associated metadata used to identify a primary geopolitical unit" +
            " of the world.")]
        public CountryIdentityDataType CountryIdentity;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("MeasureUnit", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public partial class MeasureUnitDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the unit for measuring the item.")]
        public string MeasureUnitCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A designator specifying the code set used to provide a measurement unit code. Can" +
            " be used to identify the URL of a source that defines the set of currently appro" +
            "ved permitted values.")]
        public MeasureUnitCodeListIdentifierDataType MeasureUnitCodeListIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("A description of the unit of measure code.")]
        public string MeasureUnitName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("ResultQualifier", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public partial class ResultQualifierDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A code used to identify any qualifying issues that affect the results.")]
        public string ResultQualifierCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A designator specifying the code set used to provide a result qualifier code. Can" +
            " be used to identify the URL of a source that defines the set of currently appro" +
            "ved permitted values.")]
        public ResultQualifierCodeListIdentifierDataType ResultQualifierCodeListIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("A description of the result code of any qualifying issues that affect the results" +
            ".")]
        public string ResultQualifierName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("Measure", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public partial class MeasureDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The recorded dimension, capacity, quality, or amount of something ascertained by " +
            "measuring or observing.")]
        public string MeasureValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A designator and associated metadata used to identify a unit of measurement.")]
        public MeasureUnitDataType MeasureUnit;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The precision of the recorded value.")]
        public string MeasurePrecisionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("A designator and associated metadata used to identify any qualifying issues that " +
            "affect results.")]
        public ResultQualifierDataType ResultQualifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("ReferenceMethod", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public partial class ReferenceMethodDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The identification number or code assigned by the method publisher.")]
        public string MethodIdentifierCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A designator specifying the code set used to provide a reference method code. Can" +
            " be used to identify the URL of a source that defines the set of currently appro" +
            "ved permitted values.")]
        public MethodIdentifierCodeListIdentifierDataType MethodIdentifierCodeListIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The title of the method that appears on the method from the organization that pub" +
            "lished it.")]
        public string MethodName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("A brief summary that provides general information about the method.")]
        public string MethodDescriptionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Text that identifies any deviations from the published method reference.")]
        public string MethodDeviationsText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("GeographicReferencePoint", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public partial class GeographicReferencePointDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the place for which geographic coordinates were establis" +
            "hed.")]
        public string GeographicReferencePointCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A designator specifying the code set used to provide a geographic reference point" +
            " code. Can be used to identify the URL of a source that defines the set of curre" +
            "ntly approved permitted values.")]
        public ReferencePointCodeListIdentifierDataType ReferencePointCodeListIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The text that identifies the place for which geographic coordinates were establis" +
            "hed.")]
        public string GeographicReferencePointName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("CoordinateDataSource", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public partial class CoordinateDataSourceDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the party responsible for providing the latitude and lon" +
            "gitude coordinates.")]
        public string CoordinateDataSourceCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A designator specifying the code set used to provide a coordinate data source typ" +
            "e code. Can be used to identify the URL of a source that defines the set of curr" +
            "ently approved permitted values.")]
        public CoordinateDataSourceCodeListIdentifierDataType CoordinateDataSourceCodeListIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The name of the party responsible for providing the latitude and longitude coordi" +
            "nates.")]
        public string CoordinateDataSourceName;
    }

    //TSM:
    ///// <remarks/>
    //[System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    //[System.Xml.Serialization.XmlRootAttribute("FacilityGeographicLocationDescription", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    //public partial class FacilityGeographicLocationDescriptionDataType
    //{

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("Envelope", typeof(EnvelopeType), Namespace = "http://www.opengis.net/gml", Order = 0)]
    //    [System.Xml.Serialization.XmlElementAttribute("LineString", typeof(LineStringType), Namespace = "http://www.opengis.net/gml", Order = 0)]
    //    [System.Xml.Serialization.XmlElementAttribute("Point", typeof(PointType), Namespace = "http://www.opengis.net/gml", Order = 0)]
    //    [System.Xml.Serialization.XmlElementAttribute("Polygon", typeof(PolygonType), Namespace = "http://www.opengis.net/gml", Order = 0)]
    //    public object Item;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 1)]
    //    [System.ComponentModel.DescriptionAttribute("The number that represents the proportional distance on the ground for one unit o" +
    //        "f measure on the map or photo.")]
    //    public string SourceMapScaleNumber;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
    //    [System.ComponentModel.DescriptionAttribute("The measure of the accuracy of the latitude and longitude coordinates.")]
    //    public MeasureDataType HorizontalAccuracyMeasure;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
    //    [System.ComponentModel.DescriptionAttribute("Information that describes the method used to determine the latitude and longitud" +
    //        "e coordinates for a point on the earth.")]
    //    public ReferenceMethodDataType HorizontalCollectionMethod;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
    //    [System.ComponentModel.DescriptionAttribute("A designator and associated metadata used to identify a geographic reference poin" +
    //        "t.")]
    //    public GeographicReferencePointDataType GeographicReferencePoint;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 5)]
    //    [System.ComponentModel.DescriptionAttribute("The calendar date when data were collected.")]
    //    public System.DateTime DataCollectionDate;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlIgnoreAttribute()]
    //    public bool DataCollectionDateSpecified;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
    //    [System.ComponentModel.DescriptionAttribute("The text that provides additional information about the geographic coordinates.")]
    //    public string LocationCommentsText;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
    //    [System.ComponentModel.DescriptionAttribute("Information that describes the method used to collect the vertical measure(i.e., " +
    //        "the altitude) of a reference point.")]
    //    public ReferenceMethodDataType VerticalCollectionMethod;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
    //    [System.ComponentModel.DescriptionAttribute("Information that describes the method or process used to verify the latitude and " +
    //        "longitude coordinates.")]
    //    public ReferenceMethodDataType VerificationMethod;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
    //    [System.ComponentModel.DescriptionAttribute("A designator and associated metadata used to identify a data source of coordinate" +
    //        " data.")]
    //    public CoordinateDataSourceDataType CoordinateDataSource;
    //}

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml")]
    [System.Xml.Serialization.XmlRootAttribute("Envelope", Namespace = "http://www.opengis.net/gml", IsNullable = false)]
    public partial class EnvelopeType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("lowerCorner", typeof(DirectPositionType), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("upperCorner", typeof(DirectPositionType), Order = 0)]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        public DirectPositionType[] Items;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName", Order = 1)]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemsChoiceType[] ItemsElementName;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string srsName;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "positiveInteger")]
        public string srsDimension;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml")]
    [System.Xml.Serialization.XmlRootAttribute("pos", Namespace = "http://www.opengis.net/gml", IsNullable = false)]
    public partial class DirectPositionType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string srsName;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "positiveInteger")]
        public string srsDimension;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        //TSM: public double[] Text;
        public string Text;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml", IncludeInSchema = false)]
    public enum ItemsChoiceType
    {

        /// <remarks/>
        lowerCorner,

        /// <remarks/>
        upperCorner,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml")]
    [System.Xml.Serialization.XmlRootAttribute("LineString", Namespace = "http://www.opengis.net/gml", IsNullable = false)]
    public partial class LineStringType : AbstractCurveType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("posList", Order = 0)]
        public DirectPositionListType Item;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml")]
    [System.Xml.Serialization.XmlRootAttribute("posList", Namespace = "http://www.opengis.net/gml", IsNullable = false)]
    public partial class DirectPositionListType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string srsName;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "positiveInteger")]
        public string srsDimension;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "positiveInteger")]
        public string count;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        //TSM: public double[] Text;
        public string Text;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LineStringType))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml")]
    [System.Xml.Serialization.XmlRootAttribute("_Curve", Namespace = "http://www.opengis.net/gml", IsNullable = false)]
    public abstract partial class AbstractCurveType : AbstractGeometricPrimitiveType
    {
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractSurfaceType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PolygonType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractCurveType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LineStringType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PointType))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml")]
    [System.Xml.Serialization.XmlRootAttribute("_GeometricPrimitive", Namespace = "http://www.opengis.net/gml", IsNullable = false)]
    public abstract partial class AbstractGeometricPrimitiveType : AbstractGeometryType
    {
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractRingType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LinearRingType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractGeometricPrimitiveType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractSurfaceType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PolygonType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractCurveType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LineStringType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PointType))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml")]
    [System.Xml.Serialization.XmlRootAttribute("_Geometry", Namespace = "http://www.opengis.net/gml", IsNullable = false)]
    public abstract partial class AbstractGeometryType : AbstractGMLType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string srsName;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "positiveInteger")]
        public string srsDimension;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractGeometryType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractRingType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LinearRingType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractGeometricPrimitiveType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractSurfaceType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PolygonType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractCurveType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LineStringType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PointType))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml")]
    [System.Xml.Serialization.XmlRootAttribute("_GML", Namespace = "http://www.opengis.net/gml", IsNullable = false)]
    public abstract partial class AbstractGMLType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, DataType = "ID")]
        public string id;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LinearRingType))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml")]
    [System.Xml.Serialization.XmlRootAttribute("_Ring", Namespace = "http://www.opengis.net/gml", IsNullable = false)]
    public abstract partial class AbstractRingType : AbstractGeometryType
    {
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml")]
    [System.Xml.Serialization.XmlRootAttribute("LinearRing", Namespace = "http://www.opengis.net/gml", IsNullable = false)]
    public partial class LinearRingType : AbstractRingType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("posList", Order = 0)]
        public DirectPositionListType Item;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PolygonType))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml")]
    [System.Xml.Serialization.XmlRootAttribute("_Surface", Namespace = "http://www.opengis.net/gml", IsNullable = false)]
    public partial class AbstractSurfaceType : AbstractGeometricPrimitiveType
    {
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml")]
    [System.Xml.Serialization.XmlRootAttribute("Polygon", Namespace = "http://www.opengis.net/gml", IsNullable = false)]
    public partial class PolygonType : AbstractSurfaceType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute(@"A boundary of a surface consists of a number of rings. In the normal 2D case, one of these rings is distinguished as being the exterior boundary. In a general manifold this is not always possible, in which case all boundaries shall be listed as interior boundaries, and the exterior will be empty.")]
        public AbstractRingPropertyType exterior;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml")]
    [System.Xml.Serialization.XmlRootAttribute("exterior", Namespace = "http://www.opengis.net/gml", IsNullable = false)]
    public partial class AbstractRingPropertyType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LinearRing", Order = 0)]
        public LinearRingType Item;
    }

    //TSM:
    ///// <remarks/>
    //[System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml")]
    //[System.Xml.Serialization.XmlRootAttribute("Point", Namespace = "http://www.opengis.net/gml", IsNullable = false)]
    //public partial class PointType : AbstractGeometricPrimitiveType
    //{

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("pos", Order = 0)]
    //    public DirectPositionType Item;
    //}

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("FacilityPrimaryGeographicLocationDescription", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public partial class FacilityPrimaryGeographicLocationDescriptionDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.opengis.net/gml", Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public PointType Point;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The number that represents the proportional distance on the ground for one unit o" +
            "f measure on the map or photo.")]
        public string SourceMapScaleNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The measure of the accuracy of the latitude and longitude coordinates.")]
        public MeasureDataType HorizontalAccuracyMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Information that describes the method used to determine the latitude and longitud" +
            "e coordinates for a point on the earth.")]
        public ReferenceMethodDataType HorizontalCollectionMethod;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("A designator and associated metadata used to identify a geographic reference poin" +
            "t.")]
        public GeographicReferencePointDataType GeographicReferencePoint;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The calendar date when data were collected.")]
        public System.DateTime DataCollectionDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DataCollectionDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("The text that provides additional information about the geographic coordinates.")]
        public string LocationCommentsText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Information that describes the method used to collect the vertical measure(i.e., " +
            "the altitude) of a reference point.")]
        public ReferenceMethodDataType VerticalCollectionMethod;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Information that describes the method or process used to verify the latitude and " +
            "longitude coordinates.")]
        public ReferenceMethodDataType VerificationMethod;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("A designator and associated metadata used to identify a data source of coordinate" +
            " data.")]
        public CoordinateDataSourceDataType CoordinateDataSource;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("Facility", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public partial class FacilityDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Basic information used by an organization to identify a facility or site.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public FacilitySiteIdentityDataType FacilitySiteIdentity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The physical location of an individual or organization.")]
        public LocationAddressDataType LocationAddress;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The standard address used to send mail to an individual or organization.")]
        public MailingAddressDataType MailingAddress;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("A number representing an area within a state that a member of the House of Repres" +
            "entatives is elected.")]
        public string CongressionalDistrictNumberCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("A number representing an area from which senators and General Assembly members ar" +
            "e elected.")]
        public string LegislativeDistrictNumberCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The hydrologic unit code (HUC) that represents a geographic area representing par" +
            "t or all of a surface drainage basin, a combination of drainage basins, or a dis" +
            "tinct hydrologic feature.")]
        public string HUCCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Single geographic element for a facility, intended to refer to a single location " +
            "that defines the entire facility. Must be a location of type gml:Point.")]
        public FacilityPrimaryGeographicLocationDescriptionDataType FacilityPrimaryGeographicLocationDescription;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 7)]
        [System.Xml.Serialization.XmlArrayItemAttribute("FacilityGeographicLocationDescription", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("A container for one or more facility locations.")]
        public FacilityGeographicLocationDescriptionDataType[] FacilityGeographicLocationList;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 8)]
        [System.Xml.Serialization.XmlArrayItemAttribute("EnvironmentalInterest", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("A container for one or more environmental interests.")]
        public EnvironmentalInterestDataType[] EnvironmentalInterestList;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 9)]
        [System.Xml.Serialization.XmlArrayItemAttribute("ElectronicAddress", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("A container for one or more electronic addresses.")]
        //TSM: public ElectronicAddressDataType[] ElectronicAddressList;
        public FacilityElectronicAddressDataType[] ElectronicAddressList;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 10)]
        [System.Xml.Serialization.XmlArrayItemAttribute("AlternativeName", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("A container for one or more alternative names.")]
        public AlternativeNameDataType[] AlternativeNameList;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 11)]
        [System.Xml.Serialization.XmlArrayItemAttribute("AlternativeIdentification", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("A container for one or more alternative identifiers.")]
        //TSM: public AlternativeIdentificationDataType[] AlternativeIdentificationList;
        public FacilityAlternativeIdentificationDataType[] AlternativeIdentificationList;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 12)]
        [System.Xml.Serialization.XmlArrayItemAttribute("FacilitySIC", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("A container for one or more SIC Codes.")]
        //TSM: public FacilitySICDataType[] SICList;
        public FacilityFacilitySICDataType[] SICList;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 13)]
        [System.Xml.Serialization.XmlArrayItemAttribute("FacilityNAICS", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("A container for one or more NAICS codes.")]
        //TSM: public FacilityNAICSDataType[] NAICSList;
        public FacilityFacilityNAICSDataType[] NAICSList;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [System.ComponentModel.DescriptionAttribute("A description of the partner who originally provided the information, the acronym" +
            " representing the source system and the date the information was last updated in" +
            " the source system.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public DataSourceDataType DataSource;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 15)]
        [System.Xml.Serialization.XmlArrayItemAttribute("FacilityAffiliation", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("A container for one or more affiliations.")]
        //TSM: public FacilityAffiliationDataType[] AffiliationList;
        public FacilityFacilityAffiliationDataType[] AffiliationList;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("Telephonic", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public partial class TelephonicDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The number that identifies a particular telephone connection.")]
        public string TelephoneNumberText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The name that describes a telephone number type.")]
        public string TelephoneNumberTypeName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The number assigned within an organization to an individual telephone that extend" +
            "s the external telephone number.")]
        public string TelephoneExtensionNumberText;
    }

    //TSM:
    ///// <remarks/>
    //[System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    //[System.Xml.Serialization.XmlRootAttribute("IndividualIdentity", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    //public partial class IndividualIdentityDataType
    //{

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
    //    [System.ComponentModel.DescriptionAttribute("A designator used to uniquely identify an individual within a context.")]
    //    public IndividualIdentifierDataType IndividualIdentifier;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
    //    [System.ComponentModel.DescriptionAttribute("The title held by a person in an organization.")]
    //    public string IndividualTitleText;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
    //    [System.ComponentModel.DescriptionAttribute("The text that describes the title that precedes an individual\'s name.")]
    //    public string NamePrefixText;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("FirstName", typeof(string), Order = 3)]
    //    [System.Xml.Serialization.XmlElementAttribute("IndividualFullName", typeof(string), Order = 3)]
    //    [System.Xml.Serialization.XmlElementAttribute("LastName", typeof(string), Order = 3)]
    //    [System.Xml.Serialization.XmlElementAttribute("MiddleName", typeof(string), Order = 3)]
    //    [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
    //    public string[] Items;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("ItemsElementName", Order = 4)]
    //    [System.Xml.Serialization.XmlIgnoreAttribute()]
    //    public ItemsChoiceType1[] ItemsElementName;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
    //    [System.ComponentModel.DescriptionAttribute("Additional title that indicates lineage or professional title.")]
    //    public string NameSuffixText;
    //}

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IncludeInSchema = false)]
    public enum ItemsChoiceType1
    {

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("The given name of an individual.")]
        FirstName,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("The complete name of a person, potentially including first name, middle name or i" +
            "nitial, and or surname.")]
        IndividualFullName,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("The surname of an individual.")]
        LastName,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("The middle name or initial of an individual.")]
        MiddleName,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("OrganizationIdentity", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public partial class OrganizationIdentityDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A designator used to uniquely identify a unique business establishment within a c" +
            "ontext.")]
        public OrganizationIdentifierDataType OrganizationIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The legal designator (i.e. formal name) of an organization.")]
        public string OrganizationFormalName;
    }

    //TSM:
    ///// <remarks/>
    //[System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    //[System.Xml.Serialization.XmlRootAttribute("Affiliate", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    //public partial class AffiliateDataType
    //{

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
    //    [System.ComponentModel.DescriptionAttribute("A number used to uniquely identify a Affiliate, which contains data for one indiv" +
    //        "idual or organization.")]
    //    [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
    //    public string AffiliateIdentifier;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlArrayAttribute(Order = 1)]
    //    [System.Xml.Serialization.XmlArrayItemAttribute("Telephonic", IsNullable = false)]
    //    [System.ComponentModel.DescriptionAttribute("A container for one or more telephone numbers.")]
    //    public TelephonicDataType[] TelephonicList;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlArrayAttribute(Order = 2)]
    //    [System.Xml.Serialization.XmlArrayItemAttribute("ElectronicAddress", IsNullable = false)]
    //    [System.ComponentModel.DescriptionAttribute("A container for one or more electronic addresses.")]
    //    public ElectronicAddressDataType[] ElectronicAddressList;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("IndividualIdentity", typeof(IndividualIdentityDataType), Order = 3)]
    //    [System.Xml.Serialization.XmlElementAttribute("OrganizationIdentity", typeof(OrganizationIdentityDataType), Order = 3)]
    //    public object Item;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
    //    [System.ComponentModel.DescriptionAttribute("The standard address used to send mail to an individual or organization.")]
    //    public MailingAddressDataType MailingAddress;
    //}

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("FacilityDetails", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public partial class FacilityDetailsDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 1)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Affiliate", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("A container for one or more affiliate for a partner.")]
        //TSM: Move above FacilityDataType[] FacilityList to change insert order
        public AffiliateDataType[] AffiliateList;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 0)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Facility", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("A container for one or more facility sites for a partner.")]
        public FacilityDataType[] FacilityList;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        //TSM: public decimal schemaVersion;
        public string schemaVersion = "3.0";
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("FacilityLocationAddress", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public partial class FacilityLocationAddressDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The address that describes the physical (geographic) location of the front door o" +
            "r main entrance of a facility site, including urban-style street address or rura" +
            "l address.")]
        public string LocationAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The text that provides additional information about a place, including a building" +
            " name with its secondary unit and number, an industrial park name, an installati" +
            "on name or descriptive text where no formal address is available.")]
        public string SupplementalLocationText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The name of a city, town, village or other locality.")]
        public string LocalityName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("A designator and associated metadata used to identify a principal administrative " +
            "subdivision of the United States, Canada, or Mexico.")]
        public StateIdentityDataType StateIdentity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute(@"The combination of the 5-digit Zone Improvement Plan (ZIP) code and the four-digit extension code (if available) that represents the geographic segment that is a subunit of the ZIP Code, assigned by the U.S. Postal Service to a geographic location to facilitate mail delivery; or the postal zone specific to the country, other than the U.S., where the mail is delivered.")]
        public AddressPostalCodeDataType AddressPostalCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("A designator and associated metadata used to identify a primary geopolitical unit" +
            " of the world.")]
        public CountryIdentityDataType CountryIdentity;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("FacilitySummaryGeographicLocation", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public partial class FacilitySummaryGeographicLocationDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.opengis.net/gml", Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public PointType Point;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The measure of the accuracy of the latitude and longitude coordinates.")]
        public MeasureDataType HorizontalAccuracyMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Information that describes the method used to determine the latitude and longitud" +
            "e coordinates for a point on the earth.")]
        public ReferenceMethodDataType HorizontalCollectionMethod;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("EnvironmentalInterestSummary", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public partial class EnvironmentalInterestSummaryDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A description of the partner who originally provided the information, the acronym" +
            " representing the source system and the date the information was last updated in" +
            " the source system.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public DataSourceDataType DataSource;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A designator, such as a permit number, assigned by an information management syst" +
            "em that is used to identify an environmental interest (e.g. permit, etc.) for a " +
            "partner.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string EnvironmentalInterestIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The environmental permit or regulatory program that applies to the facility site." +
            "")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string EnvironmentalInterestTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The web address where a computer user can access information about the facility.")]
        public string EnvironmentalInterestURLText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("FacilityInterestSummary", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public partial class FacilityInterestSummaryDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A description of the partner who originally provided the information, the acronym" +
            " representing the source system and the date the information was last updated in" +
            " the source system.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public DataSourceDataType DataSource;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The physical location of an individual or organization.")]
        public FacilityLocationAddressDataType FacilityLocationAddress;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The unique identification number used by a governmental entity to identify a faci" +
            "lity site.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public FacilitySiteIdentifierDataType FacilitySiteIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The public or commercial name of a facility site (i.e., the full name that common" +
            "ly appears on invoices, signs, or other business documents, or as assigned by th" +
            "e state when the name is ambiguous).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string FacilitySiteName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Single coordinate pair, used to define the primary point location for a facility." +
            " Multiple facility points are defined within facid:FacilityGeographicLocationDes" +
            "cription.")]
        public FacilitySummaryGeographicLocationDataType FacilitySummaryGeographicLocation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The web address where a computer user can access information about the facility.")]
        public string FacilityURLText;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 6)]
        [System.Xml.Serialization.XmlArrayItemAttribute("EnvironmentalInterestSummary", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("A container for one or more environmental interests.")]
        public EnvironmentalInterestSummaryDataType[] EnvironmentalInterestSummaryList;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("FacilityInterest", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public partial class FacilityInterestDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 0)]
        [System.Xml.Serialization.XmlArrayItemAttribute("FacilityInterestSummary", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("A container for one or more facility sites for a partner.")]
        public FacilityInterestSummaryDataType[] FacilityInterestSummaryList;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        //TSM: public decimal schemaVersion;
        public string schemaVersion = "3.0";
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("FacilitySummary", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public partial class FacilitySummaryDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A description of the partner who originally provided the information, the acronym" +
            " representing the source system and the date the information was last updated in" +
            " the source system.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public DataSourceDataType DataSource;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The physical location of an individual or organization.")]
        public FacilityLocationAddressDataType FacilityLocationAddress;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The unique identification number used by a governmental entity to identify a faci" +
            "lity site.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public FacilitySiteIdentifierDataType FacilitySiteIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The public or commercial name of a facility site (i.e., the full name that common" +
            "ly appears on invoices, signs, or other business documents, or as assigned by th" +
            "e state when the name is ambiguous).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string FacilitySiteName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Single coordinate pair, used to define the primary point location for a facility." +
            " Multiple facility points are defined within facid:FacilityGeographicLocationDes" +
            "cription.")]
        public FacilitySummaryGeographicLocationDataType FacilitySummaryGeographicLocation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The web address where a computer user can access information about the facility.")]
        public string FacilityURLText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("FacilityIndex", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public partial class FacilityIndexDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 0)]
        [System.Xml.Serialization.XmlArrayItemAttribute("FacilitySummary", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("A container for one or more facility sites for a partner.")]
        public FacilitySummaryDataType[] FacilitySummaryList;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        //TSM: public decimal schemaVersion;
        public string schemaVersion = "3.0";
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/facilityid/3")]
    [System.Xml.Serialization.XmlRootAttribute("FacilityCount", Namespace = "http://www.exchangenetwork.net/schema/facilityid/3", IsNullable = false)]
    public partial class FacilityCountDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The count of facilities returned by a data service.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string FacilityCountMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        //TSM: public decimal schemaVersion;
        public string schemaVersion = "3.0";
    }
}
