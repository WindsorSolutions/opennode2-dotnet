namespace Windsor.Node2008.WNOSPlugin.ICISAIR_50
{


    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class BiosolidsPermitContact
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Contact", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public Contact[] Contact;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class Contact
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string AffiliationTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string FirstName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(10)]
        public string MiddleName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string LastName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(40)]
        public string IndividualTitleText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(80)]
        public string OrganizationFormalName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(2)]
        public string StateCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(2)]
        public string RegionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Telephone", Order = 8)]
        public Telephone[] Telephone;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string ElectronicAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate StartDateOfContactAssociation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate EndDateOfContactAssociation;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class Telephone
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string TelephoneNumberTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(10)]
        public string TelephoneNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4)]
        public string TelephoneExtensionNumber;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class CAFOContact
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Contact", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public Contact[] Contact;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class EnforcementActionGovernmentContact
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string AffiliationTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string ElectronicAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate StartDateOfContactAssociation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate EndDateOfContactAssociation;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class FacilityContact
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Contact", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public Contact[] Contact;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class InspectionContact
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Contact", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public Contact[] Contact;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class InspectionGovernmentContact
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string AffiliationTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string ElectronicAddressText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class PermitContact
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Contact", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public Contact[] Contact;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class PretreatmentContact
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Contact", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public Contact[] Contact;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class SiteOwnerContact
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Contact", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public Contact[] Contact;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class StormWaterContact
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Contact", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public Contact[] Contact;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AirGeographicCoordinateData))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class GeographicCoordinates
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(10)]
        public string LatitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(11)]
        public string LongitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 HorizontalAccuracyMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string GeometricTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string HorizontalCollectionMethodCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string HorizontalReferenceDatumCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string ReferencePointCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 SourceMapScaleNumber;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class AirGeographicCoordinateData : GeographicCoordinates
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(20)]
        public string UTMCoordinate1;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(20)]
        public string UTMCoordinate2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(20)]
        public string UTMCoordinate3;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class NAICSCodeDetails
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(6)]
        public string NAICSCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string NAICSPrimaryIndicatorCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class SICCodeDetails
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(4)]
        public string SICCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string SICPrimaryIndicatorCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class Facility
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(80)]
        public string FacilitySiteName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string LocationAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string SupplementalLocationText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(60)]
        public string LocalityName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(2)]
        public string LocationStateCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(14)]
        public string LocationZipCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string LocationCountryCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string OrganizationDUNSNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(12)]
        public string StateFacilityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
        public string StateRegionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 FacilityCongressionalDistrictNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FacilityClassification", Order = 11)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] FacilityClassification;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PolicyCode", Order = 12)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] PolicyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OriginatingProgramsCode", Order = 13)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(9)]
        public string[] OriginatingProgramsCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string FacilityTypeOfOwnershipCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(12)]
        public string FederalFacilityIdentificationNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
        public string FederalAgencyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4)]
        public string TribalLandCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string ConstructionProjectName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(10)]
        public string ConstructionProjectLatitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(11)]
        public string ConstructionProjectLongitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SICCodeDetails", Order = 21)]
        public SICCodeDetails[] SICCodeDetails;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NAICSCodeDetails", Order = 22)]
        public NAICSCodeDetails[] NAICSCodeDetails;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 23)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string SectionTownshipRange;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 24)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string FacilityComments;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 25)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string FacilityUserDefinedField1;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 26)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string FacilityUserDefinedField2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 27)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string FacilityUserDefinedField3;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 28)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string FacilityUserDefinedField4;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 29)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string FacilityUserDefinedField5;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 30)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Contact[] FacilityContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 31)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public FacilityAddress[] FacilityAddress;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 32)]
        public GeographicCoordinates GeographicCoordinates;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class FacilityAddress
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string AffiliationTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(80)]
        public string OrganizationFormalName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string OrganizationDUNSNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string MailingAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string SupplementalAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string MailingAddressCityName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(2)]
        public string MailingAddressStateCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(14)]
        public string MailingAddressZipCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(35)]
        public string CountyName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string MailingAddressCountryCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string DivisionName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(35)]
        public string LocationProvince;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Telephone", Order = 12)]
        public Telephone[] Telephone;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string ElectronicAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate StartDateOfAddressAssociation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate EndDateOfAddressAssociation;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class BiosolidsPermitAddress
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Address", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public FacilityAddress[] Address;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class CAFOAddress
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Address", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public FacilityAddress[] Address;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class EffluentTradePartnerAddress
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(80)]
        public string OrganizationFormalName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string OrganizationDUNSNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(60)]
        public string LocationName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string MailingAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string SupplementalAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string MailingAddressCityName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string MailingAddressCountryCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(35)]
        public string LocationProvince;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(2)]
        public string MailingAddressStateCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(14)]
        public string MailingAddressZipCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(35)]
        public string CountyName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string DivisionName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EffluentTradePartnerTelephone", Order = 12)]
        public Telephone[] EffluentTradePartnerTelephone;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string ElectronicAddressText;
    }

    /// <remarks/>
    //TSM
    //[System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    //[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    //public partial class FacilityAddress
    //{

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("Address", Order = 0)]
    //    [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
    //    public FacilityAddress[] Address;
    //}

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class PermitAddress
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Address", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public FacilityAddress[] Address;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class PretreatmentAddress
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Address", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public FacilityAddress[] Address;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class SiteOwnerAddress
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Address", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public FacilityAddress[] Address;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class StormWaterAddress
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Address", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public FacilityAddress[] Address;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute("ComplianceMonitoringActivityTypeCode", Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public enum ComplianceMonitoringActivityTypeCode
    {

        /// <remarks/>
        INF,

        /// <remarks/>
        INS,

        /// <remarks/>
        INV,

        /// <remarks/>
        OSR,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public enum LimitSetType
    {

        /// <remarks/>
        U,

        /// <remarks/>
        S,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute("NumericReportCode", Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public enum NumericReportCode
    {

        /// <remarks/>
        Q1,

        /// <remarks/>
        Q2,

        /// <remarks/>
        C1,

        /// <remarks/>
        C2,

        /// <remarks/>
        C3,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute("NumericReportViolationCode", Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public enum NumericReportViolationCode
    {

        /// <remarks/>
        D,

        /// <remarks/>
        E,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute("ScheduleViolationCode", Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public enum ScheduleViolationCode
    {

        /// <remarks/>
        C30,

        /// <remarks/>
        C40,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute("name", Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public enum name
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("e-mail")]
        email,

        /// <remarks/>
        Source,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class Property
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(6)]
        public name name;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public string value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class TransactionHeader
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        // TSM [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public TransactionType TransactionType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public System.DateTime TransactionTimestamp;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TransactionTimestampSpecified;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public enum TransactionType
    {

        /// <remarks/>
        C,

        /// <remarks/>
        D,

        /// <remarks/>
        N,

        /// <remarks/>
        R,

        /// <remarks/>
        X,
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AirComplianceMonitoringStrategy))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class AirComplianceMonitoringStrategyKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(18)]
        [Windsor.Commons.XsdOrm2.DbNotNull] // TSM
        public string AirFacilityIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class AirComplianceMonitoringStrategy : AirComplianceMonitoringStrategyKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string AirCMSSourceCategoryCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 AirCMSMinimumFrequency;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 2)]
        public System.DateTime AirCMSStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AirCMSStartDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public AirActiveCMSPlanIndicator AirActiveCMSPlanIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AirActiveCMSPlanIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 4)]
        public System.DateTime AirRemovedPlanDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AirRemovedPlanDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(200)]
        public string AirReasonChangingCMSComments;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute("AirActiveCMSPlanIndicator", Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public enum AirActiveCMSPlanIndicator
    {

        /// <remarks/>
        Y,

        /// <remarks/>
        N,
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CaseFileLinkage))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AirDACaseFile))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class CaseFileKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(25)]
        [Windsor.Commons.XsdOrm2.DbNotNull] // TSM
        public string CaseFileIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class CaseFileLinkage : CaseFileKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LinkageAirDAEnforcementAction", typeof(LinkageAirDAEnforcementAction), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("LinkageCaseFile", typeof(LinkageCaseFile), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("LinkageComplianceMonitoring", typeof(LinkageComplianceMonitoring), Order = 0)]
        public object Item;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class LinkageAirDAEnforcementAction
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(25)]
        [Windsor.Commons.XsdOrm2.DbNotNull] // TSM
        public string AirDAEnforcementActionIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class LinkageCaseFile
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(25)]
        [Windsor.Commons.XsdOrm2.DbNotNull] // TSM
        public string CaseFileIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class LinkageComplianceMonitoring
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(25)]
        [Windsor.Commons.XsdOrm2.DbNotNull] // TSM
        public string ComplianceMonitoringIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class AirDACaseFile : CaseFileKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string CaseFileName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string LeadAgencyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(18)]
        [Windsor.Commons.XsdOrm2.DbNotNull] // TSM
        public string AirFacilityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProgramCode", Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(9)]
        public string[] ProgramCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string OtherProgramDescriptionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AirPollutantCode", Order = 5)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32[] AirPollutantCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public AirActiveCMSPlanIndicator SensitiveDataIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SensitiveDataIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OtherPathwayActivityData", Order = 7)]
        public OtherPathwayActivityData[] OtherPathwayActivityData;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string LeadAgencyChangeSupersededText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string AdvisementMethodTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate AdvisementMethodDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AirViolationData", Order = 11)]
        public AirViolationData[] AirViolationData;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string CaseFileUserDefinedField1;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string CaseFileUserDefinedField2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string CaseFileUserDefinedField3;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate CaseFileUserDefinedField4;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate CaseFileUserDefinedField5;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string CaseFileUserDefinedField6;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CaseFileCommentText", Order = 18)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string[] CaseFileCommentText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SensitiveCommentText", Order = 19)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string[] SensitiveCommentText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class OtherPathwayActivityData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(6)]
        public string OtherPathwayCategoryCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string OtherPathwayTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate OtherPathwayDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class AirViolationData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
        public string AirViolationTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(9)]
        public string AirViolationProgramCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(1000)]
        public string AirViolationProgramDescriptionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 AirViolationPollutantCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate FRVDeterminationDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate HPVDayZeroDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate OccurrenceStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate OccurrenceEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string HPVDesignationRemovalTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate HPVDesignationRemovalDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 ClaimsNumber;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AirDAInformalEnforcementAction))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AirDAFormalEnforcementAction))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AirDAEnforcementActionLinkage))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class AirDAEnforcementActionKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(25)]
        [Windsor.Commons.XsdOrm2.DbNotNull] // TSM
        public string AirDAEnforcementActionIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class AirDAInformalEnforcementAction : AirDAEnforcementActionKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AirFacilityIdentifier", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(18)]
        public string[] AirFacilityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(7)]
        public string EnforcementActionTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string EnforcementActionName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate AchievedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProgramsViolatedCode", Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(9)]
        public string[] ProgramsViolatedCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string FileNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(500)]
        public string ReasonDeletingRecord;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("InformalEACommentText", Order = 7)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string[] InformalEACommentText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string InformalEAUserDefinedField1;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string InformalEAUserDefinedField2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string InformalEAUserDefinedField3;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate InformalEAUserDefinedField4;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate InformalEAUserDefinedField5;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string InformalEAUserDefinedField6;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string LeadAgencyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EnforcementAgencyTypeCode", Order = 15)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] EnforcementAgencyTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string EnforcementAgencyName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EnforcementActionGovernmentContact", Order = 17)]
        public EnforcementActionGovernmentContact[] EnforcementActionGovernmentContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(200)]
        public string OtherAgencyInitiativeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AirPollutantCode", Order = 19)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32[] AirPollutantCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string StateSectionsViolatedText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SensitiveCommentText", Order = 21)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string[] SensitiveCommentText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class AirDAFormalEnforcementAction : AirDAEnforcementActionKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AirFacilityIdentifier", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(18)]
        public string[] AirFacilityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string EnforcementActionName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(3)]
        public Forum Forum;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ForumSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EnforcementActionTypeCode", Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(7)]
        public string[] EnforcementActionTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProgramsViolatedCode", Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(9)]
        public string[] ProgramsViolatedCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string ResolutionTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(25)]
        public string AirDACombinedSupersededEAID;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(500)]
        public string ReasonDeletingRecord;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string FormalEAUserDefinedField1;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string FormalEAUserDefinedField2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string FormalEAUserDefinedField3;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate FormalEAUserDefinedField4;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate FormalEAUserDefinedField5;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string FormalEAUserDefinedField6;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AirDAFinalOrder", Order = 14)]
        public AirDAFinalOrder[] AirDAFinalOrder;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string LeadAgencyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EnforcementAgencyTypeCode", Order = 16)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] EnforcementAgencyTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string EnforcementAgencyName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EnforcementActionGovernmentContact", Order = 18)]
        public EnforcementActionGovernmentContact[] EnforcementActionGovernmentContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(200)]
        public string OtherAgencyInitiativeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AirPollutantCode", Order = 20)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32[] AirPollutantCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EnforcementActionCommentText", Order = 21)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string[] EnforcementActionCommentText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SensitiveCommentText", Order = 22)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string[] SensitiveCommentText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute("Forum", Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public enum Forum
    {

        /// <remarks/>
        AFR,

        /// <remarks/>
        JDC,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class AirDAFinalOrder
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 FinalOrderIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string FinalOrderTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FinalOrderAirFacilityIdentifier", Order = 2)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(18)]
        public string[] FinalOrderAirFacilityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate FinalOrderIssuedEnteredDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate AirResolvedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("17", "2")]
        // TSM
        public Windsor.Node2008.WNOSPlugin.ICISAIR_50.RemoveTrailingZerosDecimal CashCivilPenaltyRequiredAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string OtherComments;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class AirDAEnforcementActionLinkage : AirDAEnforcementActionKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public LinkageAirDAEnforcementAction LinkageAirDAEnforcementAction;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AirDAEnforcementActionMilestone))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class AirDAEnforcementActionMilestoneKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(25)]
        [Windsor.Commons.XsdOrm2.DbNotNull] // TSM
        public string AirDAEnforcementActionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
        [Windsor.Commons.XsdOrm2.DbNotNull] // TSM
        public string MilestoneTypeCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class AirDAEnforcementActionMilestone : AirDAEnforcementActionMilestoneKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate MilestonePlannedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate MilestoneActualDate;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AirFacility))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class AirFacilityKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(18)]
        [Windsor.Commons.XsdOrm2.DbNotNull] // TSM
        public string AirFacilityIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class AirFacility : AirFacilityKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(80)]
        public string FacilitySiteName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string LocationAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string SupplementalLocationText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(12)]
        public string LocationAddressCityCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(2)]
        public string LocationStateCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(14)]
        public string LocationZipCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string LCONCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4)]
        public string TribalLandCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(250)]
        public string FacilityDescription;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string FacilityTypeOfOwnershipCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(15)]
        public string RegistrationNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public AirActiveCMSPlanIndicator SmallBusinessIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SmallBusinessIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string FederallyReportableIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string SourceUniformResourceLocatorURL;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string EnvironmentalJusticeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 FacilityCongressionalDistrictNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string FacilityUserDefinedField1;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string FacilityUserDefinedField2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string FacilityUserDefinedField3;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string FacilityUserDefinedField4;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string FacilityUserDefinedField5;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string FacilityComments;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("UniverseIndicatorCode", Order = 22)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(10)]
        public string[] UniverseIndicatorCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SICCodeDetails", Order = 23)]
        public SICCodeDetails[] SICCodeDetails;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NAICSCodeDetails", Order = 24)]
        public NAICSCodeDetails[] NAICSCodeDetails;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 25)]
        public AirGeographicCoordinateData AirGeographicCoordinateData;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 26)]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()] // TSM
        public PortableSourceData PortableSourceData;

        // TSM
        [System.Xml.Serialization.XmlIgnore]
        public PortableSource[] PortableSource;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 27)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Contact[] FacilityContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 28)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public FacilityAddress[] FacilityAddress;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class PortableSourceData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        // TSM [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public AirActiveCMSPlanIndicator PortableSourceIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PortableSource", Order = 1)]
        [Windsor.Commons.XsdOrm2.DbIgnore] // TSM
        public PortableSource[] PortableSource;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class PortableSource
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(80)]
        public string PortableSourceSiteName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate PortableSourceStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate PortableSourceEndDate;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AirPollutants))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class AirPollutantsKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(18)]
        [Windsor.Commons.XsdOrm2.DbNotNull] // TSM
        public string AirFacilityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 AirPollutantsCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class AirPollutants : AirPollutantsKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public AirPollutantStatusIndicator AirPollutantStatusIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AirPollutantStatusIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public AirPollutantEPAClassificationData AirPollutantEPAClassificationData;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public AirPollutantDAClassificationData AirPollutantDAClassificationData;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute("AirProgramSubpartStatusIndicator", Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public enum AirPollutantStatusIndicator
    {

        /// <remarks/>
        A,

        /// <remarks/>
        I,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("*")]
        Item,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class AirPollutantEPAClassificationData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string AirPollutantEPAClassificationCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        public System.DateTime AirPollutantEPAClassificationStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AirPollutantEPAClassificationStartDateSpecified;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class AirPollutantDAClassificationData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string AirPollutantDAClassificationCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        public System.DateTime AirPollutantDAClassificationStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AirPollutantDAClassificationStartDateSpecified;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AirPrograms))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class AirProgramsKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(18)]
        [Windsor.Commons.XsdOrm2.DbNotNull] // TSM
        public string AirFacilityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(9)]
        [Windsor.Commons.XsdOrm2.DbNotNull] // TSM
        public string AirProgramCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class AirPrograms : AirProgramsKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string OtherProgramDescriptionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()] // TSM
        public AirProgramOperatingStatusData AirProgramOperatingStatusData;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AirProgramSubpartData", Order = 2)]
        public AirProgramSubpartData[] AirProgramSubpartData;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class AirProgramOperatingStatusData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
        public string AirProgramOperatingStatusCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        public System.DateTime AirProgramOperatingStatusStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AirProgramOperatingStatusStartDateSpecified;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class AirProgramSubpartData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(20)]
        public string AirProgramSubpartCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public AirPollutantStatusIndicator AirProgramSubpartStatusIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AirProgramSubpartStatusIndicatorSpecified;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string PermitIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class BiosolidsProgramReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        public System.DateTime ReportCoverageEndDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class CAFOAnnualProgramReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        public System.DateTime PermittingAuthorityReportReceivedDate;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AirTVACC))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ComplianceMonitoringLinkage))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(FederalComplianceMonitoring))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AirDAComplianceMonitoring))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ComplianceMonitoring))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class ComplianceMonitoringKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(25)]
        [Windsor.Commons.XsdOrm2.DbNotNull] // TSM
        public string ComplianceMonitoringIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class AirTVACC : ComplianceMonitoringKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 0)]
        public System.DateTime ComplianceMonitoringDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ComplianceMonitoringDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ComplianceMonitoringStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string ComplianceMonitoringActivityName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NationalPrioritiesCode", Order = 3)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32[] NationalPrioritiesCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public AirActiveCMSPlanIndicator MultimediaIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MultimediaIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ComplianceMonitoringPlannedStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ComplianceMonitoringPlannedEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("RegionalPriorityCode", Order = 7)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32[] RegionalPriorityCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string DeficienciesObservedIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(18)]
        [Windsor.Commons.XsdOrm2.DbNotNull] // TSM
        public string AirFacilityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string LeadAgencyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProgramCode", Order = 11)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(9)]
        public string[] ProgramCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string OtherProgramDescriptionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AirPollutantCode", Order = 13)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32[] AirPollutantCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(200)]
        public string OtherAgencyInitiativeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public AirActiveCMSPlanIndicator InspectionUserDefinedField1;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool InspectionUserDefinedField1Specified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string InspectionUserDefinedField2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string InspectionUserDefinedField3;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate InspectionUserDefinedField4;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate InspectionUserDefinedField5;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string InspectionUserDefinedField6;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string AirPermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate CertificationPeriodStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 23)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate CertificationPeriodEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 24)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string FacilityReportedComplianceStatusCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TVACCReviewData", Order = 25)]
        public TVACCReviewData[] TVACCReviewData;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 26)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Contact[] InspectionContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("InspectionGovernmentContact", Order = 27)]
        public InspectionGovernmentContact[] InspectionGovernmentContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("InspectionCommentText", Order = 28)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string[] InspectionCommentText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SensitiveCommentText", Order = 29)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string[] SensitiveCommentText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class TVACCReviewData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate TVACCReviewedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public AirActiveCMSPlanIndicator FacilityReportDeviationsIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool FacilityReportDeviationsIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string PermitConditionsText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public AirActiveCMSPlanIndicator ExceedanceExcursionIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ExceedanceExcursionIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string ReviewerAgencyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string TVACCReviewerName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string ReviewerComment;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class ComplianceMonitoringLinkage : ComplianceMonitoringKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LinkageAirDAEnforcementAction", typeof(LinkageAirDAEnforcementAction), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("LinkageComplianceMonitoring", typeof(LinkageComplianceMonitoring), Order = 0)]
        public object Item;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class FederalComplianceMonitoring : ComplianceMonitoringKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(20)]
        public string ProgramSystemAcronym;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string ProgramSystemIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(6)]
        public string FederalStatuteCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(3)]
        public ComplianceMonitoringActivityTypeCode ComplianceMonitoringActivityTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ComplianceMonitoringActivityTypeCodeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string ComplianceMonitoringCategoryCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 5)]
        public System.DateTime ComplianceMonitoringDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ComplianceMonitoringDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ComplianceMonitoringStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ComplianceInspectionTypeCode", Order = 7)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] ComplianceInspectionTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string ComplianceMonitoringActivityName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ComplianceMonitoringActionReasonCode", Order = 9)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] ComplianceMonitoringActionReasonCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ComplianceMonitoringAgencyTypeCode", Order = 10)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] ComplianceMonitoringAgencyTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 ComplianceMonitoringAgencyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProgramCode", Order = 12)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(9)]
        public string[] ProgramCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string EPAAssistanceIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public StateFederalJointIndicator StateFederalJointIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StateFederalJointIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string JointInspectionReasonCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public LeadParty LeadParty;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LeadPartySpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 NumberDaysPhysicallyConductingActivity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 NumberHoursPhysicallyConductingActivity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 ComplianceMonitoringActionOutcomeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string InspectionRatingCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NationalPrioritiesCode", Order = 21)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32[] NationalPrioritiesCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public AirActiveCMSPlanIndicator MultimediaIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MultimediaIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 23)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string FederalFacilityIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 24)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string FederalFacilityIndicatorComment;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 25)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public AirActiveCMSPlanIndicator InspectionUserDefinedField1;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool InspectionUserDefinedField1Specified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 26)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string InspectionUserDefinedField2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 27)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string InspectionUserDefinedField3;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 28)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate InspectionUserDefinedField4;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 29)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate InspectionUserDefinedField5;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 30)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string InspectionUserDefinedField6;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 31)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string InspectionCommentText;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 32)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Contact[] InspectionContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("InspectionGovernmentContact", Order = 33)]
        public InspectionGovernmentContact[] InspectionGovernmentContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 34)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ComplianceMonitoringPlannedStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 35)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ComplianceMonitoringPlannedEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 36)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(2)]
        public string EPARegion;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LawSectionCode", Order = 37)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(15)]
        public string[] LawSectionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 38)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string ComplianceMonitoringMediaTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("RegionalPriorityCode", Order = 39)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32[] RegionalPriorityCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SICCode", Order = 40)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(4)]
        public string[] SICCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NAICSCode", Order = 41)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(6)]
        public string[] NAICSCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 42)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string OtherProgramDescriptionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 43)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string LeadAgencyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 44)]
        public InspectionConclusionDataSheet InspectionConclusionDataSheet;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Subactivity", Order = 45)]
        public Subactivity[] Subactivity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Citation", Order = 46)]
        public Citation[] Citation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 47)]
        public FederalAirStackTestData FederalAirStackTestData;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute("StateFederalJointIndicator", Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public enum StateFederalJointIndicator
    {

        /// <remarks/>
        S,

        /// <remarks/>
        E,

        /// <remarks/>
        J,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("*")]
        Item,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute("LeadParty", Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public enum LeadParty
    {

        /// <remarks/>
        E,

        /// <remarks/>
        S,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("*")]
        Item,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class InspectionConclusionDataSheet
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string DeficienciesObservedIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("DeficiencyObservedCode", Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] DeficiencyObservedCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string DeficiencyCommunicatedFacilityIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string FacilityActionObservedIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CorrectiveActionCode", Order = 4)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32[] CorrectiveActionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AirPollutantCode", Order = 5)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32[] AirPollutantCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("WaterPollutantCode", Order = 6)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32[] WaterPollutantCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string NationalPolicyGeneralAssistanceIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string NationalPolicySiteSpecificAssistanceIndicator;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class Subactivity
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
        public string SubactivityTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate SubactivityPlannedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate SubactivityDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class Citation
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(40)]
        public string CitationTitle;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(40)]
        public string CitationPart;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string CitationSection;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class FederalAirStackTestData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string StackTestStatusCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string StackTestConductorTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string StackIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string OtherStackTestPurposeName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate StackTestReportReceivedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate TestResultsReviewedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TestResultsData", Order = 6)]
        public TestResultsData[] TestResultsData;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class TestResultsData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 AirTestedPollutantCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string TestResultCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MethodCode", Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] MethodCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 AllowableValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(7)]
        public string AllowableUnitCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 ActualResult;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string FailureReasonCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string OtherFailureReasonText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class AirDAComplianceMonitoring : ComplianceMonitoringKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(3)]
        public ComplianceMonitoringActivityTypeCode ComplianceMonitoringActivityTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ComplianceMonitoringActivityTypeCodeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        public System.DateTime ComplianceMonitoringDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ComplianceMonitoringDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ComplianceMonitoringStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ComplianceInspectionTypeCode", Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] ComplianceInspectionTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string ComplianceMonitoringActivityName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NationalPrioritiesCode", Order = 5)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32[] NationalPrioritiesCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public AirActiveCMSPlanIndicator MultimediaIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MultimediaIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ComplianceMonitoringPlannedStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ComplianceMonitoringPlannedEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("RegionalPriorityCode", Order = 9)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32[] RegionalPriorityCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string DeficienciesObservedIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AirFacilityIdentifier", Order = 11)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(18)]
        public string[] AirFacilityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string LeadAgencyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProgramCode", Order = 13)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(9)]
        public string[] ProgramCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string OtherProgramDescriptionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AirPollutantCode", Order = 15)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32[] AirPollutantCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(200)]
        public string OtherAgencyInitiativeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public AirActiveCMSPlanIndicator InspectionUserDefinedField1;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool InspectionUserDefinedField1Specified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string InspectionUserDefinedField2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string InspectionUserDefinedField3;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate InspectionUserDefinedField4;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate InspectionUserDefinedField5;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string InspectionUserDefinedField6;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 23)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Contact[] InspectionContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("InspectionGovernmentContact", Order = 24)]
        public InspectionGovernmentContact[] InspectionGovernmentContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("InspectionCommentText", Order = 25)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string[] InspectionCommentText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SensitiveCommentText", Order = 26)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string[] SensitiveCommentText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 27)]
        public AirStackTestData AirStackTestData;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class AirStackTestData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string StackTestStatusCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string StackTestConductorTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string StackIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("StackTestPurposeCode", Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] StackTestPurposeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string OtherStackTestPurposeName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("StackTestObservedAgencyTypeCode", Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] StackTestObservedAgencyTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate StackTestReportReceivedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate TestResultsReviewedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TestResultsData", Order = 8)]
        public TestResultsData[] TestResultsData;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class ComplianceMonitoring : ComplianceMonitoringKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string ComplianceMonitoringCategoryCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 2)]
        public System.DateTime ComplianceMonitoringDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ComplianceMonitoringDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ComplianceMonitoringStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ComplianceInspectionTypeCode", Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] ComplianceInspectionTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string ComplianceMonitoringActivityName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ComplianceMonitoringActionReasonCode", Order = 6)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] ComplianceMonitoringActionReasonCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ComplianceMonitoringAgencyTypeCode", Order = 7)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] ComplianceMonitoringAgencyTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 ComplianceMonitoringAgencyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProgramCode", Order = 9)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(9)]
        public string[] ProgramCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string StateStatuteViolatedName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string EPAAssistanceIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public StateFederalJointIndicator StateFederalJointIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StateFederalJointIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string JointInspectionReasonCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public LeadParty LeadParty;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LeadPartySpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 NumberDaysPhysicallyConductingActivity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 NumberHoursPhysicallyConductingActivity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 ComplianceMonitoringActionOutcomeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string InspectionRatingCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NationalPrioritiesCode", Order = 19)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32[] NationalPrioritiesCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public AirActiveCMSPlanIndicator MultimediaIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MultimediaIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string FederalFacilityIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string FederalFacilityIndicatorComment;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 23)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public AirActiveCMSPlanIndicator InspectionUserDefinedField1;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool InspectionUserDefinedField1Specified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 24)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string InspectionUserDefinedField2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 25)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string InspectionUserDefinedField3;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 26)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate InspectionUserDefinedField4;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 27)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate InspectionUserDefinedField5;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 28)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string InspectionUserDefinedField6;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 29)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string InspectionCommentText;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 30)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Contact[] InspectionContact;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class ComplianceScheduleKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(20)]
        public string EnforcementActionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 FinalOrderIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 ComplianceScheduleNumber;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class ComplianceScheduleEventViolationKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(20)]
        public string EnforcementActionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 FinalOrderIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 ComplianceScheduleNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
        public string ScheduleEventCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 5)]
        public System.DateTime ScheduleDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(3)]
        public ScheduleViolationCode ScheduleViolationCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class CSOEventReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        public System.DateTime CSOEventDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 CSOEventID;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class DischargeMonitoringReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4)]
        public string PermittedFeatureIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(2)]
        public string LimitSetDesignator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 3)]
        public System.DateTime MonitoringPeriodEndDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class DMRViolationKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4)]
        public string PermittedFeatureIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(2)]
        public string LimitSetDesignator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 3)]
        public System.DateTime MonitoringPeriodEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
        public string ParameterCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string MonitoringSiteDescriptionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 6)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 LimitSeasonNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(2)]
        public NumericReportCode NumericReportCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public NumericReportViolationCode NumericReportViolationCode;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(InformalEnforcementAction))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(FormalEnforcementAction))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class EnforcementActionKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(20)]
        public string EnforcementActionIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class InformalEnforcementAction : EnforcementActionKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PermitIdentifier", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string[] PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(7)]
        public string EnforcementActionTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string EnforcementActionName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate AchievedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProgramsViolatedCode", Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(9)]
        public string[] ProgramsViolatedCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string FileNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(500)]
        public string ReasonDeletingRecord;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string InformalEACommentText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string InformalEAUserDefinedField1;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string InformalEAUserDefinedField2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string InformalEAUserDefinedField3;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate InformalEAUserDefinedField4;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate InformalEAUserDefinedField5;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string InformalEAUserDefinedField6;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EnforcementAgency", Order = 14)]
        public EnforcementAgency[] EnforcementAgency;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string EnforcementAgencyName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EnforcementActionGovernmentContact", Order = 16)]
        public EnforcementActionGovernmentContact[] EnforcementActionGovernmentContact;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class EnforcementAgency
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string EnforcementAgencyTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string AgencyLeadIndicator;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class FormalEnforcementAction : EnforcementActionKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PermitIdentifier", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string[] PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string EnforcementActionName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(3)]
        public Forum Forum;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ForumSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EnforcementActionTypeCode", Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(7)]
        public string[] EnforcementActionTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProgramsViolatedCode", Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(9)]
        public string[] ProgramsViolatedCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string ResolutionTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(20)]
        public string CombinedOrSupersededByEAID;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(500)]
        public string ReasonDeletingRecord;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string FormalEAUserDefinedField1;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string FormalEAUserDefinedField2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string FormalEAUserDefinedField3;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate FormalEAUserDefinedField4;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate FormalEAUserDefinedField5;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string FormalEAUserDefinedField6;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FinalOrder", Order = 14)]
        public FinalOrder[] FinalOrder;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EnforcementAgency", Order = 15)]
        public EnforcementAgency[] EnforcementAgency;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string EnforcementAgencyName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EnforcementActionGovernmentContact", Order = 17)]
        public EnforcementActionGovernmentContact[] EnforcementActionGovernmentContact;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class FinalOrder
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 FinalOrderIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string FinalOrderTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FinalOrderPermitIdentifier", Order = 2)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string[] FinalOrderPermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate FinalOrderIssuedEnteredDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate NPDESClosedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(2000)]
        public string FinalOrderQNCRComments;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("17", "2")]
        // TSM
        public Windsor.Node2008.WNOSPlugin.ICISAIR_50.RemoveTrailingZerosDecimal CashCivilPenaltyRequiredAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string OtherComments;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(Milestone))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class EnforcementActionMilestoneKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(20)]
        public string EnforcementActionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
        [Windsor.Commons.XsdOrm2.DbNotNull] // TSM
        public string MilestoneTypeCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class Milestone : EnforcementActionMilestoneKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate MilestonePlannedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate MilestoneActualDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class HistoricalPermitScheduleKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        public System.DateTime PermitEffectiveDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 NarrativeConditionNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
        public string ScheduleEventCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 4)]
        public System.DateTime ScheduleDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class LimitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4)]
        public string PermittedFeatureIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(2)]
        public string LimitSetDesignator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
        public string ParameterCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string MonitoringSiteDescriptionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 5)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 LimitSeasonNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 6)]
        public System.DateTime LimitStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 7)]
        public System.DateTime LimitEndDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class LimitSetKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4)]
        public string PermittedFeatureIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(2)]
        public string LimitSetDesignator;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class LocalLimitsProgramReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        public System.DateTime LocalLimitsPermittingAuthorityReportReceivedDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class ParameterLimitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4)]
        public string PermittedFeatureIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(2)]
        public string LimitSetDesignator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
        public string ParameterCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string MonitoringSiteDescriptionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 5)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 LimitSeasonNumber;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class ParameterKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
        public string ParameterCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string MonitoringSiteDescriptionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 LimitSeasonNumber;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class PermitScheduleKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 NarrativeConditionNumber;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class PermitScheduleEventKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
        public string ScheduleEventCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        public System.DateTime ScheduleDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class PermitScheduleEventViolationKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 NarrativeConditionNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
        public string ScheduleEventCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 3)]
        public System.DateTime ScheduleDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(3)]
        public ScheduleViolationCode ScheduleViolationCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class PermitTrackingEventKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string PermitTrackingEventCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 2)]
        public System.DateTime PermitTrackingEventDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class PermittedFeatureKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4)]
        public string PermittedFeatureIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class PretreatmentPerformanceSummaryReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        public System.DateTime PretreatmentPerformanceSummaryEndDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class ProgramInspectionKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string ComplianceMonitoringCategoryCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 2)]
        public System.DateTime ComplianceMonitoringDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class ScheduleEventViolationKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ComplianceScheduleEventViolationKeyElements", typeof(ComplianceScheduleEventViolationKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("PermitScheduleEventViolationKeyElements", typeof(PermitScheduleEventViolationKeyElements), Order = 0)]
        public object Item;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class SingleEventKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
        public string SingleEventViolationCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 2)]
        public System.DateTime SingleEventViolationDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class SSOAnnualReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        public System.DateTime SSOAnnualReportReceivedDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class SSOEventReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        public System.DateTime SSOEventDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 SSOEventID;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class SSOMonthlyEventReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        public System.DateTime SSOMonthlyReportReceivedDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class SWEventReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        public System.DateTime DateStormEventSampled;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        // TSM
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 StormWaterEventID;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class SWMS4ProgramReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        public System.DateTime StormWaterMS4ReportReceivedDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class LinkageEnforcementAction
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(20)]
        public string EnforcementActionIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class AirPollutantsData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()] // TSM
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()] // TSM
        public AirPollutants AirPollutants;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4", IsNullable = false)]
    public partial class Document
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public Header Header;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Payload", Order = 1)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public Payload[] Payload;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    public partial class Header
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string Id;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string Author;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string Organization;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string Title;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public System.DateTime CreationTime;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CreationTimeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string Comment;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string DataService;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string ContactInfo;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Property", Order = 8)]
        public Property[] Property;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    public partial class Payload
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AirComplianceMonitoringStrategyData", typeof(AirComplianceMonitoringStrategyData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("AirDACaseFileData", typeof(AirDACaseFileData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("AirDAComplianceMonitoringData", typeof(AirDAComplianceMonitoringData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("AirDAEnforcementActionLinkageData", typeof(AirDAEnforcementActionLinkageData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("AirDAEnforcementActionMilestoneData", typeof(AirDAEnforcementActionMilestoneData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("AirDAFormalEnforcementActionData", typeof(AirDAFormalEnforcementActionData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("AirDAInformalEnforcementActionData", typeof(AirDAInformalEnforcementActionData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("AirFacilityData", typeof(AirFacilityData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("AirPollutantsData", typeof(AirPollutantsData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("AirProgramsData", typeof(AirProgramsData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("AirTVACCData", typeof(AirTVACCData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("CaseFileLinkageData", typeof(CaseFileLinkageData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("ComplianceMonitoringLinkageData", typeof(ComplianceMonitoringLinkageData), Order = 0)]
        public object[] Items;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public Operation Operation;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    public partial class AirComplianceMonitoringStrategyData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()] // TSM
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()] // TSM
        public AirComplianceMonitoringStrategy AirComplianceMonitoringStrategy;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    public partial class AirDACaseFileData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()] // TSM
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()] // TSM
        public AirDACaseFile AirDACaseFile;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    public partial class AirDAComplianceMonitoringData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()] // TSM
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()] // TSM
        public AirDAComplianceMonitoring AirDAComplianceMonitoring;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    public partial class AirDAEnforcementActionLinkageData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()] // TSM
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()] // TSM
        public AirDAEnforcementActionLinkage AirDAEnforcementActionLinkage;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    public partial class AirDAEnforcementActionMilestoneData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()] // TSM
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()] // TSM
        public AirDAEnforcementActionMilestone AirDAEnforcementActionMilestone;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    public partial class AirDAFormalEnforcementActionData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()] // TSM
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()] // TSM
        public AirDAFormalEnforcementAction AirDAFormalEnforcementAction;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    public partial class AirDAInformalEnforcementActionData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()] // TSM
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()] // TSM
        public AirDAInformalEnforcementAction AirDAInformalEnforcementAction;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    public partial class AirFacilityData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()] // TSM
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()] // TSM
        public AirFacility AirFacility;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    public partial class AirProgramsData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()] // TSM
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()] // TSM
        public AirPrograms AirPrograms;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    public partial class AirTVACCData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()] // TSM
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()] // TSM
        public AirTVACC AirTVACC;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    public partial class CaseFileLinkageData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()] // TSM
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()] // TSM
        public CaseFileLinkage CaseFileLinkage;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    public partial class ComplianceMonitoringLinkageData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()] // TSM
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()] // TSM
        public ComplianceMonitoringLinkage ComplianceMonitoringLinkage;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/4")]
    public enum Operation
    {

        /// <remarks/>
        AirComplianceMonitoringStrategySubmission,

        /// <remarks/>
        AirDACaseFileSubmission,

        /// <remarks/>
        AirDAComplianceMonitoringSubmission,

        /// <remarks/>
        AirDAEnforcementActionLinkageSubmission,

        /// <remarks/>
        AirDAEnforcementActionMilestoneSubmission,

        /// <remarks/>
        AirDAFormalEnforcementActionSubmission,

        /// <remarks/>
        AirDAInformalEnforcementActionSubmission,

        /// <remarks/>
        AirFacilitySubmission,

        /// <remarks/>
        AirPollutantsSubmission,

        /// <remarks/>
        AirProgramsSubmission,

        /// <remarks/>
        AirTVACCSubmission,

        /// <remarks/>
        BasicPermitSubmission,

        /// <remarks/>
        BiosolidsPermitSubmission,

        /// <remarks/>
        BiosolidsProgramReportSubmission,

        /// <remarks/>
        CaseFileLinkageSubmission,

        /// <remarks/>
        CAFOAnnualReportSubmission,

        /// <remarks/>
        CAFOPermitSubmission,

        /// <remarks/>
        ComplianceMonitoringLinkageSubmission,

        /// <remarks/>
        ComplianceMonitoringSubmission,

        /// <remarks/>
        ComplianceScheduleSubmission,

        /// <remarks/>
        CopyMGPLimitSetSubmission,

        /// <remarks/>
        CSOEventReportSubmission,

        /// <remarks/>
        CSOPermitSubmission,

        /// <remarks/>
        DischargeMonitoringReportSubmission,

        /// <remarks/>
        DMRProgramReportLinkageSubmission,

        /// <remarks/>
        DMRViolationSubmission,

        /// <remarks/>
        EffluentTradePartnerSubmission,

        /// <remarks/>
        EnforcementActionMilestoneSubmission,

        /// <remarks/>
        EnforcementActionViolationLinkageSubmission,

        /// <remarks/>
        FederalComplianceMonitoringSubmission,

        /// <remarks/>
        FinalOrderViolationLinkageSubmission,

        /// <remarks/>
        FormalEnforcementActionSubmission,

        /// <remarks/>
        GeneralPermitSubmission,

        /// <remarks/>
        HistoricalPermitScheduleEventsSubmission,

        /// <remarks/>
        InformalEnforcementActionSubmission,

        /// <remarks/>
        LimitSetSubmission,

        /// <remarks/>
        LimitsSubmission,

        /// <remarks/>
        LocalLimitsProgramReportSubmission,

        /// <remarks/>
        MasterGeneralPermitSubmission,

        /// <remarks/>
        NarrativeConditionScheduleSubmission,

        /// <remarks/>
        ParameterLimitsSubmission,

        /// <remarks/>
        PermitReissuanceSubmission,

        /// <remarks/>
        PermittedFeatureSubmission,

        /// <remarks/>
        PermitTerminationSubmission,

        /// <remarks/>
        PermitTrackingEventSubmission,

        /// <remarks/>
        POTWPermitSubmission,

        /// <remarks/>
        PretreatmentPerformanceSummarySubmission,

        /// <remarks/>
        PretreatmentPermitSubmission,

        /// <remarks/>
        ScheduleEventViolationSubmission,

        /// <remarks/>
        SingleEventViolationSubmission,

        /// <remarks/>
        SSOAnnualReportSubmission,

        /// <remarks/>
        SSOEventReportSubmission,

        /// <remarks/>
        SSOMonthlyEventReportSubmission,

        /// <remarks/>
        SWConstructionPermitSubmission,

        /// <remarks/>
        SWEventReportSubmission,

        /// <remarks/>
        SWIndustrialPermitSubmission,

        /// <remarks/>
        SWMS4LargePermitSubmission,

        /// <remarks/>
        SWMS4ProgramReportSubmission,

        /// <remarks/>
        SWMS4SmallPermitSubmission,

        /// <remarks/>
        UnpermittedFacilitySubmission,
    }
}
