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
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;

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


		public void SerializeToFile(string path)
		{

			TextWriter tw = null;
			try 
			{
				XmlSerializer saveXML = new XmlSerializer(typeof(FacilitySiteList));
				tw = new StreamWriter(path);
				saveXML.Serialize(tw, this);
			}
			catch (Exception ex) 
			{

				//If there is an exception cleanup so that next call may have a chance to work 
				Console.WriteLine(ex.Message);
				throw;
			}
			finally 
			{
				if (tw != null)
				{
					tw.Close();
				}
			}
		}



        [XmlAnyAttribute]
        public XmlAttribute[] XAttributes;
    
        [System.Xml.Serialization.XmlElementAttribute("FacilitySiteAllDetails")]
        public FacilitySiteAllDetails[] FacilitySiteAllDetails;

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
        public EnvironmentalInterest[] EnvironmentalInterestDetails;

        [System.Xml.Serialization.XmlElementAttribute("AlternativeNameInfo")]
        public AltNameDataType AlternativeNameInfo;

        [System.Xml.Serialization.XmlElementAttribute("MailingAddress")]
        public MailingAddressDataType MailingAddress;

        [System.Xml.Serialization.XmlElementAttribute("SICCodeDetails")]
        public SICCodeDetails[] SICCodeDetails;

        [System.Xml.Serialization.XmlElementAttribute("NAICSCodeDetails")]
        public NAICSCodeDetails[] NAICSCodeDetails;

		[System.Xml.Serialization.XmlElementAttribute("IndividualDetails")]
		public IndividualDetails[] IndividualDetails;

		[System.Xml.Serialization.XmlElementAttribute("OrganizationDetails")]
		public OrganizationDetails[] OrganizationDetails;

        [System.Xml.Serialization.XmlElementAttribute("GeographicCoordinates")]
        public GeographicCoordinateDataType GeographicCoordinates;

        [System.Xml.Serialization.XmlElementAttribute("SourceOfData")]
        public string SourceOfData;

        [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
        public System.DateTime LastReportedDate;

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
   
        [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
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
    
        
        public FederalStateIndicatorDataType FederalStateInterestIndicator;
    
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool FederalStateInterestIndicatorSpecified;
    
        
        [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
        public System.DateTime EnvironmentalInterestStartDate;

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EnvironmentalInterestStartDateSpecified;

        public string InterestStartDateQualifierText;
        
        [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
        public System.DateTime EnvironmentalInterestEndDate;
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EnvironmentalInterestEndDateSpecified;
        public string InterestEndDateQualifierText;

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
        public YesNoIndicatorDataType FederalFacilityIndicator;
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool FederalFacilityIndicatorSpecified;
        public YesNoIndicatorDataType TribalLandIndicator;
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TribalLandIndicatorSpecified;
        public string TribalLandName;
        public string CongressionalDistrictNumber;
        public string LegislativeDistrictNumber;
        public string HUCCode;

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string schemaVersion;
    }

    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.epa.gov/xml")]
    [System.Xml.Serialization.XmlRootAttribute("FederalFacilityIndicator", Namespace="http://www.epa.gov/xml", IsNullable=false)]
    public enum YesNoIndicatorDataType 
    {
        Y, N,
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
        public FederalStateIndicatorDataType FederalStateInterestIndicator;
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool FederalStateInterestIndicatorSpecified;
        [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
        public System.DateTime EnvironmentalInterestStartDate;
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EnvironmentalInterestStartDateSpecified;
        public string InterestStartDateQualifierText;
        [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
        public System.DateTime EnvironmentalInterestEndDate;
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EnvironmentalInterestEndDateSpecified;
        public string InterestEndDateQualifierText;
    }

    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.epa.gov/xml")]
    [System.Xml.Serialization.XmlRootAttribute("FederalStateInterestIndicator", Namespace="http://www.epa.gov/xml", IsNullable=false)]
    public enum FederalStateIndicatorDataType 
    {
        F, S,
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
    [System.Xml.Serialization.XmlRootAttribute("SICPrimaryIndicator", Namespace="http://www.epa.gov/xml", IsNullable=false)]
    public enum PrimaryIndicatorDataType 
    {
        PRIMARY, SECONDARY, UNKNOWN,
    }

    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.epa.gov/xml")]
    [System.Xml.Serialization.XmlRootAttribute("SICCodeList", Namespace="http://www.epa.gov/xml", IsNullable=false)]
    public class SICCodeList 
    {
        [System.Xml.Serialization.XmlElementAttribute("SICCodeDetails")]
        public SICCodeDetails[] SICCodeDetails;
    }

    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.epa.gov/xml")]
    [System.Xml.Serialization.XmlRootAttribute("SICCodeDetails", Namespace="http://www.epa.gov/xml", IsNullable=false)]
    public class SICCodeDetails 
    {
    
        public string InformationSystemAcronymName;
        public string InformationSystemIdentifier;
        public string EnvironmentalInterestTypeText;
        public string SICCode;
        public PrimaryIndicatorDataType SICPrimaryIndicator;
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SICPrimaryIndicatorSpecified;
        public string DataSourceName;
        [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
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
        public NAICSCodeDetails[] NAICSCodeDetails;
    }

    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.epa.gov/xml")]
    [System.Xml.Serialization.XmlRootAttribute("NAICSCodeDetails", Namespace="http://www.epa.gov/xml", IsNullable=false)]
    public class NAICSCodeDetails 
    {

        public string InformationSystemAcronymName;
        public string InformationSystemIdentifier;
        public string EnvironmentalInterestTypeText;
        public string NAICSCode;
        public PrimaryIndicatorDataType NAICSPrimaryIndicator;
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NAICSPrimaryIndicatorSpecified;
        public string DataSourceName;
        [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
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
        public IndividualDetails[] IndividualDetails;
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
        [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
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
        [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
        public System.DateTime AffiliationStartDate;
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AffiliationStartDateSpecified;
        [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
        public System.DateTime AffiliationEndDate;
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
        public OrganizationDetails[] OrganizationDetails;
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
        [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
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
        public System.Decimal LatitudeMeasure;
        public System.Decimal LongitudeMeasure;
        [System.Xml.Serialization.XmlElementAttribute(DataType="nonNegativeInteger")]
        public string HorizontalAccuracyMeasure;
        public HorizontalMethodDataType HorizontalCollectionMethodText;
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool HorizontalCollectionMethodTextSpecified;
        public HorizontalDatumDataType HorizontalReferenceDatumName;
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool HorizontalReferenceDatumNameSpecified;
        [System.Xml.Serialization.XmlElementAttribute(DataType="nonNegativeInteger")]
        public string SourceMapScaleNumber;
        public ReferencePointDataType ReferencePointText;
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ReferencePointTextSpecified;
        [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
        public System.DateTime DataCollectionDate;
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DataCollectionDateSpecified;
        public GeometricDataType GeometricTypeName;
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool GeometricTypeNameSpecified;
        public string LocationCommentsText;
        public VerticalMethodDataType VerticalCollectionMethodText;
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool VerticalCollectionMethodTextSpecified;
        public System.Decimal VerticalMeasure;
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool VerticalMeasureSpecified;
        [System.Xml.Serialization.XmlElementAttribute(DataType="nonNegativeInteger")]
        public string VerticalAccuracyMeasure;
        public VerticalDatumDataType VerticalReferenceDatumName;
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool VerticalReferenceDatumNameSpecified;
        public string DataSourceName;
        public string CoordinateDataSourceName;
        public string SubEntityIdentifier;
        public SubEntityDataType SubEntityTypeName;
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SubEntityTypeNameSpecified;

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string schemaVersion;
    }

    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.epa.gov/xml")]
    [System.Xml.Serialization.XmlRootAttribute("HorizontalCollectionMethodText", Namespace="http://www.epa.gov/xml", IsNullable=false)]
    public enum HorizontalMethodDataType 
    {
        [System.Xml.Serialization.XmlEnumAttribute("ADDRESS MATCHING-BLOCK FACE")]
        ADDRESSMATCHINGBLOCKFACE,
        [System.Xml.Serialization.XmlEnumAttribute("ADDRESS MATCHING-DIGITIZED")]
        ADDRESSMATCHINGDIGITIZED,
        [System.Xml.Serialization.XmlEnumAttribute("ADDRESS MATCHING-HOUSE NUMBER")]
        ADDRESSMATCHINGHOUSENUMBER,
        [System.Xml.Serialization.XmlEnumAttribute("ADDRESS MATCHING-NEAREST INTERSECTION")]
        ADDRESSMATCHINGNEARESTINTERSECTION,
        [System.Xml.Serialization.XmlEnumAttribute("ADDRESS MATCHING-OTHER")]
        ADDRESSMATCHINGOTHER,
        [System.Xml.Serialization.XmlEnumAttribute("ADDRESS MATCHING-PRIMARY NAME")]
        ADDRESSMATCHINGPRIMARYNAME,
        [System.Xml.Serialization.XmlEnumAttribute("ADDRESS MATCHING-STREET CENTERLINE")]
        ADDRESSMATCHINGSTREETCENTERLINE,
        [System.Xml.Serialization.XmlEnumAttribute("CENSUS BLOCK/GROUP-1990-CENTROID")]
        CENSUSBLOCKGROUP1990CENTROID,
        [System.Xml.Serialization.XmlEnumAttribute("CENSUS BLOCK/TRACT-1990-CENTROID")]
        CENSUSBLOCKTRACT1990CENTROID,
        [System.Xml.Serialization.XmlEnumAttribute("CENSUS BLOCK-1990-CENTROID")]
        CENSUSBLOCK1990CENTROID,
        [System.Xml.Serialization.XmlEnumAttribute("CENSUS-OTHER")]
        CENSUSOTHER,
        [System.Xml.Serialization.XmlEnumAttribute("CLASSICAL SURVEYING TECHNIQUES")]
        CLASSICALSURVEYINGTECHNIQUES,
        [System.Xml.Serialization.XmlEnumAttribute("GPS - UNSPECIFIED")]
        GPSUNSPECIFIED,
        [System.Xml.Serialization.XmlEnumAttribute("GPS CARRIER PHASE KINEMATIC RELATIVE POSITION")]
        GPSCARRIERPHASEKINEMATICRELATIVEPOSITION,
        [System.Xml.Serialization.XmlEnumAttribute("GPS CARRIER PHASE STATIC RELATIVE POSITION")]
        GPSCARRIERPHASESTATICRELATIVEPOSITION,
        [System.Xml.Serialization.XmlEnumAttribute("GPS CODE (PSEUDO RANGE) DIFFERENTIAL")]
        GPSCODEPSEUDORANGEDIFFERENTIAL,
        [System.Xml.Serialization.XmlEnumAttribute("GPS CODE (PSEUDO RANGE) PRECISE POSITION")]
        GPSCODEPSEUDORANGEPRECISEPOSITION,
        [System.Xml.Serialization.XmlEnumAttribute("GPS CODE (PSEUDO RANGE) STANDARD POSITION (SA OFF)")]
        GPSCODEPSEUDORANGESTANDARDPOSITIONSAOFF,
        [System.Xml.Serialization.XmlEnumAttribute("GPS CODE (PSEUDO RANGE) STANDARD POSITION (SA ON)")]
        GPSCODEPSEUDORANGESTANDARDPOSITIONSAON,
        [System.Xml.Serialization.XmlEnumAttribute("GPS, WITH CANADIAN ACTIVE CONTROL SYSTEM")]
        GPSWITHCANADIANACTIVECONTROLSYSTEM,
        [System.Xml.Serialization.XmlEnumAttribute("INTERPOLATION - DIGITAL MAP SRCE (TIGER)")]
        INTERPOLATIONDIGITALMAPSRCETIGER,
        [System.Xml.Serialization.XmlEnumAttribute("INTERPOLATION - SPOT")]
        INTERPOLATIONSPOT,
        [System.Xml.Serialization.XmlEnumAttribute("INTERPOLATION -MSS")]
        INTERPOLATIONMSS,
        [System.Xml.Serialization.XmlEnumAttribute("INTERPOLATION -TM")]
        INTERPOLATIONTM,
        [System.Xml.Serialization.XmlEnumAttribute("INTERPOLATION-MAP")]
        INTERPOLATIONMAP,
        [System.Xml.Serialization.XmlEnumAttribute("INTERPOLATION-OTHER")]
        INTERPOLATIONOTHER,
        [System.Xml.Serialization.XmlEnumAttribute("INTERPOLATION-PHOTO")]
        INTERPOLATIONPHOTO,
        [System.Xml.Serialization.XmlEnumAttribute("INTERPOLATION-SATELLITE")]
        INTERPOLATIONSATELLITE,
        [System.Xml.Serialization.XmlEnumAttribute("LORAN C")]
        LORANC,
        [System.Xml.Serialization.XmlEnumAttribute("PUBLIC LAND SURVEY - EIGHTH SECTION")]
        PUBLICLANDSURVEYEIGHTHSECTION,
        [System.Xml.Serialization.XmlEnumAttribute("PUBLIC LAND SURVEY - FOOTING")]
        PUBLICLANDSURVEYFOOTING,
        [System.Xml.Serialization.XmlEnumAttribute("PUBLIC LAND SURVEY - SIXTEENTH SECTION")]
        PUBLICLANDSURVEYSIXTEENTHSECTION,
        [System.Xml.Serialization.XmlEnumAttribute("PUBLIC LAND SURVEY-QUARTER SECTION")]
        PUBLICLANDSURVEYQUARTERSECTION,
        [System.Xml.Serialization.XmlEnumAttribute("PUBLIC LAND SURVEY-SECTION")]
        PUBLICLANDSURVEYSECTION,
        UNKNOWN,
        [System.Xml.Serialization.XmlEnumAttribute("ZIP CODE-CENTROID")]
        ZIPCODECENTROID,
        [System.Xml.Serialization.XmlEnumAttribute("ZIP+2 CENTROID")]
        ZIP2CENTROID,
        [System.Xml.Serialization.XmlEnumAttribute("ZIP+4 CENTROID")]
        ZIP4CENTROID,
    }

    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.epa.gov/xml")]
    [System.Xml.Serialization.XmlRootAttribute("HorizontalReferenceDatumName", Namespace="http://www.epa.gov/xml", IsNullable=false)]
    public enum HorizontalDatumDataType 
    {
        NAD27, NAD83, WGS84,
    }

    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.epa.gov/xml")]
    [System.Xml.Serialization.XmlRootAttribute("ReferencePointText", Namespace="http://www.epa.gov/xml", IsNullable=false)]
    public enum ReferencePointDataType 
    {

        UNKNOWN,
        [System.Xml.Serialization.XmlEnumAttribute("PLANT ENTRANCE (GENERAL)")]
        PLANTENTRANCEGENERAL,
        OTHER,
        [System.Xml.Serialization.XmlEnumAttribute("PLANT ENTRANCE (PERSONNEL)")]
        PLANTENTRANCEPERSONNEL,
        [System.Xml.Serialization.XmlEnumAttribute("PLANT ENTRANCE (FREIGHT)")]
        PLANTENTRANCEFREIGHT,
        [System.Xml.Serialization.XmlEnumAttribute("AIR RELEASE STACK")]
        AIRRELEASESTACK,
        [System.Xml.Serialization.XmlEnumAttribute("AIR RELEASE VENT")]
        AIRRELEASEVENT,
        [System.Xml.Serialization.XmlEnumAttribute("STORAGE TANK")]
        STORAGETANK,
        [System.Xml.Serialization.XmlEnumAttribute("WATER RELEASE PIPE")]
        WATERRELEASEPIPE,
        [System.Xml.Serialization.XmlEnumAttribute("LAGOON OR SETTLING POND")]
        LAGOONORSETTLINGPOND,
        [System.Xml.Serialization.XmlEnumAttribute("LIQUID WASTE TREATMENT UNIT")]
        LIQUIDWASTETREATMENTUNIT,
        [System.Xml.Serialization.XmlEnumAttribute("ATMOSPHERIC EMISSIONS TREATMENT UNIT")]
        ATMOSPHERICEMISSIONSTREATMENTUNIT,
        [System.Xml.Serialization.XmlEnumAttribute("SOLID WASTE TREATMENT/DISP. UNIT")]
        SOLIDWASTETREATMENTDISPUNIT,
        [System.Xml.Serialization.XmlEnumAttribute("SOLID WASTE STORAGE AREA")]
        SOLIDWASTESTORAGEAREA,
        [System.Xml.Serialization.XmlEnumAttribute("LOADING FACILITY")]
        LOADINGFACILITY,
        [System.Xml.Serialization.XmlEnumAttribute("LOADING AREA CENTROID")]
        LOADINGAREACENTROID,
        [System.Xml.Serialization.XmlEnumAttribute("PROCESS UNIT")]
        PROCESSUNIT,
        [System.Xml.Serialization.XmlEnumAttribute("PROCESS UNIT AREA CENTROID")]
        PROCESSUNITAREACENTROID,
        [System.Xml.Serialization.XmlEnumAttribute("ADMINISTRATIVE BUILDING")]
        ADMINISTRATIVEBUILDING,
        [System.Xml.Serialization.XmlEnumAttribute("FACILITY CENTROID")]
        FACILITYCENTROID,
        [System.Xml.Serialization.XmlEnumAttribute("NE CORNER OF LAND PARCEL")]
        NECORNEROFLANDPARCEL,
        [System.Xml.Serialization.XmlEnumAttribute("SE CORNER OF LAND PARCEL")]
        SECORNEROFLANDPARCEL,
        [System.Xml.Serialization.XmlEnumAttribute("NW CORNER OF LAND PARCEL")]
        NWCORNEROFLANDPARCEL,
        [System.Xml.Serialization.XmlEnumAttribute("SW CORNER OF LAND PARCEL")]
        SWCORNEROFLANDPARCEL,
        [System.Xml.Serialization.XmlEnumAttribute("CENTER OF FACILITY")]
        CENTEROFFACILITY,
        [System.Xml.Serialization.XmlEnumAttribute("WELLHEAD PROTECTION AREA")]
        WELLHEADPROTECTIONAREA,
        [System.Xml.Serialization.XmlEnumAttribute("WATER MONITORING STATION")]
        WATERMONITORINGSTATION,
        [System.Xml.Serialization.XmlEnumAttribute("INTAKE PIPE")]
        INTAKEPIPE,
        WELL,
        [System.Xml.Serialization.XmlEnumAttribute("AIR MONITORING STATION")]
        AIRMONITORINGSTATION,
        [System.Xml.Serialization.XmlEnumAttribute("WATER WELL")]
        WATERWELL,
        SPRING,
        [System.Xml.Serialization.XmlEnumAttribute("SOURCE WATER AREA")]
        SOURCEWATERAREA,
        [System.Xml.Serialization.XmlEnumAttribute("POTENTIAL CONTAMINANT SOURCE")]
        POTENTIALCONTAMINANTSOURCE,
        [System.Xml.Serialization.XmlEnumAttribute("SOURCE WATER PROTECTION AREA")]
        SOURCEWATERPROTECTIONAREA,
        [System.Xml.Serialization.XmlEnumAttribute("SLUDGE FIELD")]
        SLUDGEFIELD,
        INCINERATOR,
        [System.Xml.Serialization.XmlEnumAttribute("EMERGENCY OVERFLOW")]
        EMERGENCYOVERFLOW,
        [System.Xml.Serialization.XmlEnumAttribute("COMBINED ANIMAL FEED OPERATION (CAFO)")]
        COMBINEDANIMALFEEDOPERATIONCAFO,
    }

    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.epa.gov/xml")]
    [System.Xml.Serialization.XmlRootAttribute("GeometricTypeName", Namespace="http://www.epa.gov/xml", IsNullable=false)]
    public enum GeometricDataType 
    {
        POINT, LINE, AREA, REGION, ROUTE,
    }

    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.epa.gov/xml")]
    [System.Xml.Serialization.XmlRootAttribute("VerticalCollectionMethodText", Namespace="http://www.epa.gov/xml", IsNullable=false)]
    public enum VerticalMethodDataType 
    {
        [System.Xml.Serialization.XmlEnumAttribute("GPS CARRIER PHASE STATIC RELATIVE POSITION")]
        GPSCARRIERPHASESTATICRELATIVEPOSITION,
    
        
        [System.Xml.Serialization.XmlEnumAttribute("GPS CARRIER PHASE KINEMATIC RELATIVE POSITION")]
        GPSCARRIERPHASEKINEMATICRELATIVEPOSITION,
    
        
        [System.Xml.Serialization.XmlEnumAttribute("GPS CODE (PSEUDO RANGE) DIFFERENTIAL")]
        GPSCODEPSEUDORANGEDIFFERENTIAL,
    
        
        [System.Xml.Serialization.XmlEnumAttribute("GPS CODE (PSEUDO RANGE) PRECISE POSITION")]
        GPSCODEPSEUDORANGEPRECISEPOSITION,
    
        
        [System.Xml.Serialization.XmlEnumAttribute("GPS CODE (PSEUDO RANGE) STANDARD POSITION (SA OFF)")]
        GPSCODEPSEUDORANGESTANDARDPOSITIONSAOFF,
    
        
        [System.Xml.Serialization.XmlEnumAttribute("GPS CODE (PSEUDO RANGE) STANDARD POSITION (SA ON)")]
        GPSCODEPSEUDORANGESTANDARDPOSITIONSAON,
    
        
        [System.Xml.Serialization.XmlEnumAttribute("CLASSICAL SURVEYING TECHNIQUES")]
        CLASSICALSURVEYINGTECHNIQUES,
    
        
        OTHER,
    
        
        ALTIMETRY,
    
        
        [System.Xml.Serialization.XmlEnumAttribute("PRECISE LEVELING-BENCH MARK")]
        PRECISELEVELINGBENCHMARK,
    
        
        [System.Xml.Serialization.XmlEnumAttribute("LEVELING-NON BENCH MARK CONTROL POINTS")]
        LEVELINGNONBENCHMARKCONTROLPOINTS,
    
        
        [System.Xml.Serialization.XmlEnumAttribute("TRIGONOMETRIC LEVELING")]
        TRIGONOMETRICLEVELING,
    
        
        PHOTOGRAMMETRIC,
    
        
        [System.Xml.Serialization.XmlEnumAttribute("TOPOGRAPHIC MAP INTERPOLATION")]
        TOPOGRAPHICMAPINTERPOLATION,
    }

    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.epa.gov/xml")]
    [System.Xml.Serialization.XmlRootAttribute("VerticalReferenceDatumName", Namespace="http://www.epa.gov/xml", IsNullable=false)]
    public enum VerticalDatumDataType 
    {
    
        NAVD88,
        
        NGVD29,
        
        [System.Xml.Serialization.XmlEnumAttribute("MEAN SEA-LEVEL")]
        MEANSEALEVEL,
        
        [System.Xml.Serialization.XmlEnumAttribute("LOCAL TIDAL DATUM")]
        LOCALTIDALDATUM,
    }

    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.epa.gov/xml")]
    [System.Xml.Serialization.XmlRootAttribute("SubEntityTypeName", Namespace="http://www.epa.gov/xml", IsNullable=false)]
    public enum SubEntityDataType 
    {
    
        
        [System.Xml.Serialization.XmlEnumAttribute("POINT OF RECORD")]
        POINTOFRECORD,
    
        
        [System.Xml.Serialization.XmlEnumAttribute("BOUNDRY POINT")]
        BOUNDRYPOINT,
    
        
        [System.Xml.Serialization.XmlEnumAttribute("SAMPLING POINT")]
        SAMPLINGPOINT,
    
        
        [System.Xml.Serialization.XmlEnumAttribute("END OF DISCHARGE POINT")]
        ENDOFDISCHARGEPOINT,
    
        
        [System.Xml.Serialization.XmlEnumAttribute("WELL HEAD")]
        WELLHEAD,
    
        
        [System.Xml.Serialization.XmlEnumAttribute("TRANSECT ORIGIN")]
        TRANSECTORIGIN,
    
        
        [System.Xml.Serialization.XmlEnumAttribute("GRID ORIGIN")]
        GRIDORIGIN,
    
        
        STACK,
    
        
        SPILLS,
    
        
        SLUDGE,
    
        
        LANDFILL,
    
        
        [System.Xml.Serialization.XmlEnumAttribute("EMERGENCY OVERFLOW")]
        EMERGENCYOVERFLOW,
    
        
        INCINERATOR,
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
    
        
        public string DataSourceName;
    
        
        [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
        public System.DateTime LastReportedDate;
    
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LastReportedDateSpecified;
    
        
        public object StateFacilitySystemAcronymName;
    
        
        public object StateFacilityIdentifier;
    }










    



    #endregion

}
