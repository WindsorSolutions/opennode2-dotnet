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

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using System.Runtime.Serialization;

namespace Windsor.Node2008.WNOSPlugin.FRS23
{

    [Serializable]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.epa.gov/xml")]
    [System.Xml.Serialization.XmlRootAttribute("FacilitySiteList", Namespace="http://www.epa.gov/xml", IsNullable=false)]
    public class FacilitySiteList
    {


        /// <summary>
        /// FacilitySiteList Constractor
        /// </summary>
        public FacilitySiteList() 
        {
            XmlDocument d = new XmlDocument();
            XmlAttribute xsi = d.CreateAttribute("xsi", "schemaLocation", XmlSchema.InstanceNamespace);
            xsi.Value = @"http://www.epa.gov/xml http://www.epa.gov/enviro/html/frs_demo/presentations/version2.3/FACID_FacilitySiteAll_v2.3.xsd";
            this.XAttributes = new XmlAttribute[] {xsi};
        }


        [XmlAnyAttribute]
        public XmlAttribute[] XAttributes;
    
        [System.Xml.Serialization.XmlElementAttribute("FacilitySiteAllDetails")]
        public List<FacilitySiteAllDetails> FacilitySiteAllDetails;

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string schemaVersion = "2.3";

    }

    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.epa.gov/xml")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://www.epa.gov/xml", IsNullable=false)]
    public class FacilitySiteAllDetails 
    {

		[System.Xml.Serialization.XmlElementAttribute("FacilitySite")]
		public FacilitySiteDataType FacilitySite;

		[System.Xml.Serialization.XmlElementAttribute("LocationAddress")]
		public LocationAddressDataType LocationAddress;

		[System.Xml.Serialization.XmlElementAttribute("EnvironmentalInterestDetails")]
		public List<EnvironmentalInterest> EnvironmentalInterestDetails;

		[System.Xml.Serialization.XmlElementAttribute("AlternativeNameInfo")]
		public AltNameDataType AlternativeNameInfo;

		[System.Xml.Serialization.XmlElementAttribute("MailingAddress")]
		public MailingAddressDataType MailingAddress;

		[System.Xml.Serialization.XmlElementAttribute("SICCodeDetails")]
		public List<SICCodeDetails> SICCodeDetails;

		[System.Xml.Serialization.XmlElementAttribute("NAICSCodeDetails")]
		public List<NAICSCodeDetails> NAICSCodeDetails;

		[System.Xml.Serialization.XmlElementAttribute("IndividualDetails")]
		public List<IndividualDetails> IndividualDetails;

		[System.Xml.Serialization.XmlElementAttribute("OrganizationDetails")]
		public List<OrganizationDetails> OrganizationDetails;

		[System.Xml.Serialization.XmlElementAttribute("GeographicCoordinates")]
		public GeographicCoordinateDataType GeographicCoordinates;

		[System.Xml.Serialization.XmlElementAttribute("SourceOfData")]
		public string SourceOfData;

		public string LastReportedDate;

		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool LastReportedDateSpecified;

		[System.Xml.Serialization.XmlElementAttribute("StateFacilitySystemAcronymName")]
		public string StateFacilitySystemAcronymName;

		[System.Xml.Serialization.XmlElementAttribute("StateFacilityIdentifier")]
		public string StateFacilityIdentifier;

		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string schemaVersion;

    }


    #region Schema Classes

    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.epa.gov/xml")]
    [System.Xml.Serialization.XmlRootAttribute("EnvironmentalInterestList", Namespace="http://www.epa.gov/xml", IsNullable=false)]
    public class EnvironmentalInterestList 
    {
    
        
        [System.Xml.Serialization.XmlElementAttribute("EnvironmentalInterestDetails")]
        public EnvironmentalInterestDetails[] EnvironmentalInterestDetails;
    }

    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.epa.gov/xml")]
    [System.Xml.Serialization.XmlRootAttribute("EnvironmentalInterestDetails", Namespace="http://www.epa.gov/xml", IsNullable=false)]
    public class EnvironmentalInterestDetails 
    {
    
        public EnvironmentalInterest EnvironmentalInterest;
   
        public string DataSourceName;
   
        public System.DateTime LastReportedDate;
    
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LastReportedDateSpecified;
    
        public string StateFacilitySystemAcronymName;
    
        public string StateFacilityIdentifier;
    }

    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.epa.gov/xml")]
    [System.Xml.Serialization.XmlRootAttribute("EnvironmentalInterest", Namespace="http://www.epa.gov/xml", IsNullable=false)]
    public class EnvironmentalInterest 
    {
    
        public string InformationSystemAcronymName;
    
        
        public string InformationSystemIdentifier;
    
        
        public string EnvironmentalInterestTypeText;
    
        
        public string FederalStateInterestIndicator;
    
        public string EnvironmentalInterestStartDate;
    
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EnvironmentalInterestStartDateSpecified;

        public string InterestStartDateQualifierText;
        
        public string EnvironmentalInterestEndDate;

		[System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EnvironmentalInterestEndDateSpecified;

		public string InterestEndDateQualifierText;

        [System.Xml.Serialization.XmlElementAttribute("SICCodeDetails")]
        public List<SICCodeDetails> SICCodeDetails;

        [System.Xml.Serialization.XmlElementAttribute("NAICSCodeDetails")]
        public List<NAICSCodeDetails> NAICSCodeDetails;

        [System.Xml.Serialization.XmlElementAttribute("IndividualDetails")]
        public List<IndividualDetails> IndividualDetails;

        [System.Xml.Serialization.XmlElementAttribute("OrganizationDetails")]
        public List<OrganizationDetails> OrganizationDetails;

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string schemaVersion;
    }

    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.epa.gov/xml")]
    [System.Xml.Serialization.XmlRootAttribute("FacilitySite", Namespace="http://www.epa.gov/xml", IsNullable=false)]
    public class FacilitySiteDataType 
    {
    
        public string FacilityRegistryIdentifier;
        public string FacilitySiteName;
        public string FacilitySiteTypeName;
        public string FederalFacilityIndicator;
        public string TribalLandIndicator;
        public string TribalLandName;
        public string CongressionalDistrictNumber;
        public string LegislativeDistrictNumber;
        public string HUCCode;

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string schemaVersion;
    }

   

    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.epa.gov/xml")]
    [System.Xml.Serialization.XmlRootAttribute("LocationAddress", Namespace="http://www.epa.gov/xml", IsNullable=false)]
    public class LocationAddressDataType 
    {
    
        public string LocationAddressText;
        public string SupplementalLocationText;
        public string LocalityName;
        public string CountyStateFIPSCode;
        public string CountyName;
        public string StateUSPSCode;
        public string StateName;
        public string CountryName;
        public string LocationZIPCode;
        public string LocationDescriptionText;
    }

    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.epa.gov/xml")]
    [System.Xml.Serialization.XmlRootAttribute("AlternativeNameInfo", Namespace="http://www.epa.gov/xml", IsNullable=false)]
    public class AltNameDataType 
    {
    
        public string AlternativeName;
        public string AlternativeNameTypeText;

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string schemaVersion;
    }

    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.epa.gov/xml")]
    [System.Xml.Serialization.XmlRootAttribute("EnvironmentalInterestDetails", Namespace="http://www.epa.gov/xml", IsNullable=false)]
    public class EnvironmentalInterestDetail 
    {

        public string InformationSystemAcronymName;
        public string InformationSystemIdentifier;
        public string EnvironmentalInterestTypeText;
        public string FederalStateInterestIndicator;
        public System.DateTime EnvironmentalInterestStartDate;
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EnvironmentalInterestStartDateSpecified;
        public string InterestStartDateQualifierText;
        public System.DateTime EnvironmentalInterestEndDate;
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EnvironmentalInterestEndDateSpecified;
        public string InterestEndDateQualifierText;
    }

   

    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.epa.gov/xml")]
    [System.Xml.Serialization.XmlRootAttribute("MailingAddress", Namespace="http://www.epa.gov/xml", IsNullable=false)]
    public class MailingAddressDataType 
    {
    
        public string MailingAddressText;
        public string SupplementalAddressText;
        public string MailingAddressCityName;
        public string MailingAddressStateUSPSCode;
        public string MailingAddressStateName;
        public string MailingAddressCountryName;
        public string MailingAddressZIPCode;

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string schemaVersion;

    }



    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.epa.gov/xml")]
    [System.Xml.Serialization.XmlRootAttribute("SICCodeList", Namespace="http://www.epa.gov/xml", IsNullable=false)]
    public class SICCodeList 
    {
        [System.Xml.Serialization.XmlElementAttribute("SICCodeDetails")]
        public List<SICCodeDetails> SICCodeDetails;
    }

    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.epa.gov/xml")]
    [System.Xml.Serialization.XmlRootAttribute("SICCodeDetails", Namespace="http://www.epa.gov/xml", IsNullable=false)]
    public class SICCodeDetails 
    {
    
        public string InformationSystemAcronymName;
        public string InformationSystemIdentifier;
        public string EnvironmentalInterestTypeText;
        public string SICCode;
        public string SICPrimaryIndicator;
        public string DataSourceName;
        public System.DateTime LastReportedDate;
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LastReportedDateSpecified;
        public string StateFacilitySystemAcronymName;
        public string StateFacilityIdentifier;

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string schemaVersion;
    }

    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.epa.gov/xml")]
    [System.Xml.Serialization.XmlRootAttribute("NAICSCodeList", Namespace="http://www.epa.gov/xml", IsNullable=false)]
    public class NAICSCodeList 
    {
    
        [System.Xml.Serialization.XmlElementAttribute("NAICSCodeDetails")]
        public List<NAICSCodeDetails> NAICSCodeDetails;
    }

    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.epa.gov/xml")]
    [System.Xml.Serialization.XmlRootAttribute("NAICSCodeDetails", Namespace="http://www.epa.gov/xml", IsNullable=false)]
    public class NAICSCodeDetails 
    {

        public string InformationSystemAcronymName;
        public string InformationSystemIdentifier;
        public string EnvironmentalInterestTypeText;
        public string NAICSCode;
        public string NAICSPrimaryIndicator;
        public string DataSourceName;
        public System.DateTime LastReportedDate;
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LastReportedDateSpecified;
        public string StateFacilitySystemAcronymName;
        public string StateFacilityIdentifier;

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string schemaVersion;
    }

    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.epa.gov/xml")]
    [System.Xml.Serialization.XmlRootAttribute("IndividualList", Namespace="http://www.epa.gov/xml", IsNullable=false)]
    public class IndividualList 
    {
        [System.Xml.Serialization.XmlElementAttribute("IndividualDetails")]
        public List<IndividualDetails> IndividualDetails;
    }

    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.epa.gov/xml")]
    [System.Xml.Serialization.XmlRootAttribute("IndividualDetails", Namespace="http://www.epa.gov/xml", IsNullable=false)]
    public class IndividualDetails 
    {
    
        public string InformationSystemAcronymName;
        public string InformationSystemIdentifier;
        public string EnvironmentalInterestTypeText;
        public AffiliationDataType Affiliation;
        public PhoneFaxEmailDataType PhoneFaxEmail;
        public IndividualDataType Individual;
        public MailingAddressDataType MailingAddress;
        public string DataSourceName;
        public System.DateTime LastReportedDate;
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LastReportedDateSpecified;
        public string StateFacilitySystemAcronymName;
        public string StateFacilityIdentifier;

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string schemaVersion;
    }

    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.epa.gov/xml")]
    [System.Xml.Serialization.XmlRootAttribute("Affiliation", Namespace="http://www.epa.gov/xml", IsNullable=false)]
    public class AffiliationDataType 
    {
    
        public string AffiliationTypeText;
        public string AffiliationStartDate;
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AffiliationStartDateSpecified;
        public string AffiliationEndDate;
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AffiliationEndDateSpecified;
    }

    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.epa.gov/xml")]
    [System.Xml.Serialization.XmlRootAttribute("Individual", Namespace="http://www.epa.gov/xml", IsNullable=false)]
    public class IndividualDataType 
    {
        public string IndividualFullName;
        public string IndividualTitleText;
    }

    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.epa.gov/xml")]
    [System.Xml.Serialization.XmlRootAttribute("PhoneFaxEmail", Namespace="http://www.epa.gov/xml", IsNullable=false)]
    public class PhoneFaxEmailDataType 
    {
        public string EmailAddressText;
        public string TelephoneNumber;
        public string PhoneExtension;
        public string FaxNumber;
        public string AlternateTelephoneNumber;
    }

    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.epa.gov/xml")]
    [System.Xml.Serialization.XmlRootAttribute("OrganizationList", Namespace="http://www.epa.gov/xml", IsNullable=false)]
    public class OrganizationList 
    {
        [System.Xml.Serialization.XmlElementAttribute("OrganizationDetails")]
        public List<OrganizationDetails> OrganizationDetails;
    }

    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.epa.gov/xml")]
    [System.Xml.Serialization.XmlRootAttribute("OrganizationDetails", Namespace="http://www.epa.gov/xml", IsNullable=false)]
    public class OrganizationDetails 
    {
        public string InformationSystemAcronymName;
        public string InformationSystemIdentifier;
        public string EnvironmentalInterestTypeText;
        public AffiliationDataType Affiliation;
        public PhoneFaxEmailDataType PhoneFaxEmail;
        public OrganizationDataType Organization;
        public MailingAddressDataType MailingAddress;
        public string DataSourceName;
        public System.DateTime LastReportedDate;
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LastReportedDateSpecified;
        public string StateFacilitySystemAcronymName;
        public string StateFacilityIdentifier;

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string schemaVersion;
    }

    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.epa.gov/xml")]
    [System.Xml.Serialization.XmlRootAttribute("Organization", Namespace="http://www.epa.gov/xml", IsNullable=false)]
    public class OrganizationDataType 
    {
        public string OrganizationFormalName;
        public string OrganizationDUNSNumber;
        public string OrganizationTypeText;
        public string EmployerIdentifier;
        public string StateBusinessIdentifier;
        public string UltimateParentName;
        public string UltimateParentDUNSNumber;
    }

    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.epa.gov/xml")]
    [System.Xml.Serialization.XmlRootAttribute("GeographicCoordinatesList", Namespace="http://www.epa.gov/xml", IsNullable=false)]
    public class GeographicCoordinatesList 
    {
        [System.Xml.Serialization.XmlElementAttribute("GeographicCoordinateDetails")]
        public GeographicCoordinateDetails[] GeographicCoordinateDetails;
    }

    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.epa.gov/xml")]
    [System.Xml.Serialization.XmlRootAttribute("GeographicCoordinateDetails", Namespace="http://www.epa.gov/xml", IsNullable=false)]
    public class GeographicCoordinateDetails 
    {
        public GeographicCoordinateDataType GeographicCoordinates;
        public string StateFacilitySystemAcronymName;
        public string StateFacilityIdentifier;
    }

    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.epa.gov/xml")]
    [System.Xml.Serialization.XmlRootAttribute("GeographicCoordinates", Namespace="http://www.epa.gov/xml", IsNullable=false)]
    public class GeographicCoordinateDataType 
    {
        public string LatitudeMeasure;
        public string LongitudeMeasure;
        [System.Xml.Serialization.XmlElementAttribute(DataType="nonNegativeInteger")]
        public string HorizontalAccuracyMeasure;
        public string HorizontalCollectionMethodText;
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool HorizontalCollectionMethodTextSpecified;
        public string HorizontalReferenceDatumName;
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool HorizontalReferenceDatumNameSpecified;
        [System.Xml.Serialization.XmlElementAttribute(DataType="nonNegativeInteger")]
        public string SourceMapScaleNumber;
        public string ReferencePointText;
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ReferencePointTextSpecified;
        public string DataCollectionDate;
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DataCollectionDateSpecified;
        public string GeometricTypeName;
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool GeometricTypeNameSpecified;
        public string LocationCommentsText;
        public string VerticalCollectionMethodText;
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool VerticalCollectionMethodTextSpecified;
        public string VerticalMeasure;
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool VerticalMeasureSpecified;
        [System.Xml.Serialization.XmlElementAttribute(DataType="nonNegativeInteger")]
        public string VerticalAccuracyMeasure;
        public string VerticalReferenceDatumName;
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool VerticalReferenceDatumNameSpecified;
        public string DataSourceName;
        public string CoordinateDataSourceName;
        public string SubEntityIdentifier;
        public string SubEntityTypeName;
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SubEntityTypeNameSpecified;
    }

   
  
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.epa.gov/xml")]
    [System.Xml.Serialization.XmlRootAttribute("AlternativeNameList", Namespace="http://www.epa.gov/xml", IsNullable=false)]
    public class AlternativeNameList 
    {
    
        
        [System.Xml.Serialization.XmlElementAttribute("AlternativeNameDetails")]
        public AlternativeNameDetails[] AlternativeNameDetails;
    }

    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.epa.gov/xml")]
    [System.Xml.Serialization.XmlRootAttribute("AlternativeNameDetails", Namespace="http://www.epa.gov/xml", IsNullable=false)]
    public class AlternativeNameDetails 
    {    
        public AltNameDataType AlternativeNameInfo;
        
        public object StateFacilitySystemAcronymName;
        
        public object StateFacilityIdentifier;
    }










    



    #endregion

}
