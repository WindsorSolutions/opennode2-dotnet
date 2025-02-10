namespace Windsor.Node2008.WNOSPlugin.ICISNPDES_514
{


    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class BiosolidsPermitContact
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Contact", Order = 0)]
        public Contact[] Contact;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class Contact
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string AffiliationTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string FirstName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string MiddleName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string LastName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string IndividualTitleText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string OrganizationFormalName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string StateCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string RegionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Telephone", Order = 8)]
        public Telephone[] Telephone;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public string ElectronicAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public string StartDateOfContactAssociation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        public string EndDateOfContactAssociation;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class Telephone
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string TelephoneNumberTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string TelephoneNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string TelephoneExtensionNumber;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class CAFOContact
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Contact", Order = 0)]
        public Contact[] Contact;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class EnforcementActionGovernmentContact
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string AffiliationTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string ElectronicAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string StartDateOfContactAssociation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string EndDateOfContactAssociation;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class FacilityContact
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Contact", Order = 0)]
        public Contact[] Contact;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class InspectionContact
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Contact", Order = 0)]
        public Contact[] Contact;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class InspectionGovernmentContact
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string AffiliationTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string ElectronicAddressText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class PermitContact
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Contact", Order = 0)]
        public Contact[] Contact;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class PretreatmentContact
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Contact", Order = 0)]
        public Contact[] Contact;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SiteOwnerContact
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Contact", Order = 0)]
        public Contact[] Contact;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class StormWaterContact
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Contact", Order = 0)]
        public Contact[] Contact;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AirGeographicCoordinateData))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class GeographicCoordinates
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string LatitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string LongitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string HorizontalAccuracyMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string GeometricTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string HorizontalCollectionMethodCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string HorizontalReferenceDatumCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string ReferencePointCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string SourceMapScaleNumber;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class AirGeographicCoordinateData : GeographicCoordinates
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string UTMCoordinate1;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string UTMCoordinate2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string UTMCoordinate3;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class NAICSCodeDetails
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string NAICSCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string NAICSPrimaryIndicatorCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SICCodeDetails
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string SICCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string SICPrimaryIndicatorCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class Facility
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string FacilitySiteName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string LocationAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string SupplementalLocationText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LocalityName", typeof(string), Order = 3)]
        [System.Xml.Serialization.XmlElementAttribute("LocationAddressCityCode", typeof(string), Order = 3)]
        [System.Xml.Serialization.XmlElementAttribute("LocationAddressCountyCode", typeof(string), Order = 3)]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        public string[] Items;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName", Order = 4)]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemsChoiceType[] ItemsElementName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string LocationStateCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string LocationZipCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string LocationCountryCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string OrganizationDUNSNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public string StateFacilityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public string StateRegionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        public string FacilityCongressionalDistrictNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FacilityClassification", Order = 12)]
        public string[] FacilityClassification;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PolicyCode", Order = 13)]
        public string[] PolicyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OriginatingProgramsCode", Order = 14)]
        public string[] OriginatingProgramsCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        public string FacilityTypeOfOwnershipCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        public string FederalFacilityIdentificationNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        public string FederalAgencyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        public string TribalLandCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        public string ConstructionProjectName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        public string ConstructionProjectLatitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        public string ConstructionProjectLongitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SICCodeDetails", Order = 22)]
        public SICCodeDetails[] SICCodeDetails;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NAICSCodeDetails", Order = 23)]
        public NAICSCodeDetails[] NAICSCodeDetails;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 24)]
        public string SectionTownshipRange;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 25)]
        public string FacilityComments;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 26)]
        public string FacilityUserDefinedField1;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 27)]
        public string FacilityUserDefinedField2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 28)]
        public string FacilityUserDefinedField3;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 29)]
        public string FacilityUserDefinedField4;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 30)]
        public string FacilityUserDefinedField5;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 31)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Contact[] FacilityContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 32)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Address[] FacilityAddress;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 33)]
        public GeographicCoordinates GeographicCoordinates;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IncludeInSchema = false)]
    public enum ItemsChoiceType
    {

        /// <remarks/>
        LocalityName,

        /// <remarks/>
        LocationAddressCityCode,

        /// <remarks/>
        LocationAddressCountyCode,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class Address
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string AffiliationTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string OrganizationFormalName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string OrganizationDUNSNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string MailingAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string SupplementalAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string MailingAddressCityName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string MailingAddressStateCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string MailingAddressZipCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string CountyName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public string MailingAddressCountryCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public string DivisionName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        public string LocationProvince;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Telephone", Order = 12)]
        public Telephone[] Telephone;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        public string ElectronicAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        public string StartDateOfAddressAssociation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        public string EndDateOfAddressAssociation;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class BiosolidsPermitAddress
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Address", Order = 0)]
        public Address[] Address;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class CAFOAddress
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Address", Order = 0)]
        public Address[] Address;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class EffluentTradePartnerAddress
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string OrganizationFormalName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string OrganizationDUNSNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string LocationName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string MailingAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string SupplementalAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string MailingAddressCityName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string MailingAddressCountryCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string LocationProvince;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string MailingAddressStateCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public string MailingAddressZipCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public string CountyName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        public string DivisionName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EffluentTradePartnerTelephone", Order = 12)]
        public Telephone[] EffluentTradePartnerTelephone;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        public string ElectronicAddressText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class FacilityAddress
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Address", Order = 0)]
        public Address[] Address;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class PermitAddress
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Address", Order = 0)]
        public Address[] Address;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class PretreatmentAddress
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Address", Order = 0)]
        public Address[] Address;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SiteOwnerAddress
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Address", Order = 0)]
        public Address[] Address;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class StormWaterAddress
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Address", Order = 0)]
        public Address[] Address;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute("ComplianceMonitoringActivityTypeCode", Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public enum ComplianceMonitoringActivityTypeCodeType
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute("ComplianceScheduleType", Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public enum ComplianceScheduleFlagType
    {

        /// <remarks/>
        A,

        /// <remarks/>
        J,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public enum LimitSetType
    {

        /// <remarks/>
        U,

        /// <remarks/>
        S,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute("NumericReportCode", Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public enum NumericReportTextType
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute("NumericReportViolationCode", Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public enum NumericReportViolationCodeType
    {

        /// <remarks/>
        D,

        /// <remarks/>
        E,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute("ScheduleViolationCode", Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public enum ScheduleViolationCodeType
    {

        /// <remarks/>
        C30,

        /// <remarks/>
        C40,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute("name", Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public enum nameType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("e-mail")]
        email,

        /// <remarks/>
        Source,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class Property
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public nameType name;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class TransactionHeader
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class AirComplianceMonitoringStrategyKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string AirFacilityIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class AirComplianceMonitoringStrategy : AirComplianceMonitoringStrategyKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string AirCMSSourceCategoryCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 1)]
        public string AirCMSMinimumFrequency;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string AirCMSStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string AirActiveCMSPlanIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string AirRemovedPlanDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string AirReasonChangingCMSComments;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AirDAInformalEnforcementAction))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AirDAFormalEnforcementAction))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AirDAEnforcementActionLinkage))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class AirDAEnforcementActionKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string AirDAEnforcementActionIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class AirDAInformalEnforcementAction : AirDAEnforcementActionKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AirFacilityIdentifier", Order = 0)]
        public string[] AirFacilityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string EnforcementActionTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string EnforcementActionName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string AchievedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProgramsViolatedCode", Order = 4)]
        public string[] ProgramsViolatedCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string OtherProgramDescriptionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string FileNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string ReasonDeletingRecord;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("InformalEACommentText", Order = 8)]
        public string[] InformalEACommentText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public string InformalEAUserDefinedField1;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public string InformalEAUserDefinedField2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        public string InformalEAUserDefinedField3;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        public string InformalEAUserDefinedField4;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        public string InformalEAUserDefinedField5;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        public string InformalEAUserDefinedField6;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        public string LeadAgencyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EnforcementAgencyTypeCode", Order = 16)]
        public string[] EnforcementAgencyTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        public string EnforcementAgencyName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EnforcementActionGovernmentContact", Order = 18)]
        public EnforcementActionGovernmentContact[] EnforcementActionGovernmentContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        public string OtherAgencyInitiativeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AirPollutantCode", Order = 20)]
        public string[] AirPollutantCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        public string StateSectionsViolatedText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SensitiveCommentText", Order = 22)]
        public string[] SensitiveCommentText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class AirDAFormalEnforcementAction : AirDAEnforcementActionKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AirFacilityIdentifier", Order = 0)]
        public string[] AirFacilityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string EnforcementActionName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public ForumType Forum;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ForumSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EnforcementActionTypeCode", Order = 3)]
        public string[] EnforcementActionTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProgramsViolatedCode", Order = 4)]
        public string[] ProgramsViolatedCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string OtherProgramDescriptionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string ResolutionTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string AirDACombinedSupersededEAID;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string ReasonDeletingRecord;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public string FormalEAUserDefinedField1;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public string FormalEAUserDefinedField2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        public string FormalEAUserDefinedField3;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        public string FormalEAUserDefinedField4;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        public string FormalEAUserDefinedField5;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        public string FormalEAUserDefinedField6;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AirDAFinalOrder", Order = 15)]
        public AirDAFinalOrder[] AirDAFinalOrder;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        public string LeadAgencyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EnforcementAgencyTypeCode", Order = 17)]
        public string[] EnforcementAgencyTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        public string EnforcementAgencyName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EnforcementActionGovernmentContact", Order = 19)]
        public EnforcementActionGovernmentContact[] EnforcementActionGovernmentContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        public string OtherAgencyInitiativeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AirPollutantCode", Order = 21)]
        public string[] AirPollutantCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EnforcementActionCommentText", Order = 22)]
        public string[] EnforcementActionCommentText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SensitiveCommentText", Order = 23)]
        public string[] SensitiveCommentText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute("Forum", Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public enum ForumType
    {

        /// <remarks/>
        AFR,

        /// <remarks/>
        JDC,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class AirDAFinalOrder
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string FinalOrderIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string FinalOrderTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FinalOrderAirFacilityIdentifier", Order = 2)]
        public string[] FinalOrderAirFacilityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string FinalOrderLodgedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string FinalOrderIssuedEnteredDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string AirResolvedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string CashCivilPenaltyRequiredAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string OtherComments;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("DemandStipulatedPenaltyData", Order = 8)]
        public DemandStipulatedPenaltyData[] DemandStipulatedPenaltyData;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class DemandStipulatedPenaltyData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string DemandStipulatedPenaltyAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string DemandStipulatedPenaltyPaidDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class AirDAEnforcementActionLinkage : AirDAEnforcementActionKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LinkageAirDAEnforcementAction", typeof(LinkageAirDAEnforcementAction), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("LinkageEnforcementAction", typeof(LinkageEnforcementAction), Order = 0)]
        public object Item;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class LinkageAirDAEnforcementAction
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string AirDAEnforcementActionIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class LinkageEnforcementAction
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string EnforcementActionIdentifier;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AirDAEnforcementActionMilestone))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class AirDAEnforcementActionMilestoneKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string AirDAEnforcementActionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string MilestoneTypeCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class AirDAEnforcementActionMilestone : AirDAEnforcementActionMilestoneKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string MilestonePlannedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string MilestoneActualDate;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AirFacility))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class AirFacilityKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string AirFacilityIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class AirFacility : AirFacilityKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string FacilitySiteName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string LocationAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string SupplementalLocationText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LocalityName", typeof(string), Order = 3)]
        [System.Xml.Serialization.XmlElementAttribute("LocationAddressCityCode", typeof(string), Order = 3)]
        [System.Xml.Serialization.XmlElementAttribute("LocationAddressCountyCode", typeof(string), Order = 3)]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        public string[] Items;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName", Order = 4)]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemsChoiceType1[] ItemsElementName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string LocationStateCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string LocationZipCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string LCONCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string TribalLandCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public string FacilityDescription;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public string FacilityTypeOfOwnershipCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        public string RegistrationNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        public YesNoIndicatorTypeBase SmallBusinessIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SmallBusinessIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        public string FederallyReportableIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        public string SourceUniformResourceLocatorURL;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        public string EnvironmentalJusticeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        public string FacilityCongressionalDistrictNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        public string FacilityUserDefinedField1;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        public string FacilityUserDefinedField2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        public string FacilityUserDefinedField3;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        public string FacilityUserDefinedField4;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        public string FacilityUserDefinedField5;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        public string FacilityComments;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("UniverseIndicatorCode", Order = 23)]
        public string[] UniverseIndicatorCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SICCodeDetails", Order = 24)]
        public SICCodeDetails[] SICCodeDetails;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NAICSCodeDetails", Order = 25)]
        public NAICSCodeDetails[] NAICSCodeDetails;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 26)]
        public AirGeographicCoordinateData AirGeographicCoordinateData;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 27)]
        public PortableSourceData PortableSourceData;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 28)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Contact[] FacilityContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 29)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Address[] FacilityAddress;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IncludeInSchema = false)]
    public enum ItemsChoiceType1
    {

        /// <remarks/>
        LocalityName,

        /// <remarks/>
        LocationAddressCityCode,

        /// <remarks/>
        LocationAddressCountyCode,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute("AcceptanceHauledDomesticWastes", Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public enum YesNoIndicatorTypeBase
    {

        /// <remarks/>
        Y,

        /// <remarks/>
        N,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class PortableSourceData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public YesNoIndicatorTypeBase PortableSourceIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PortableSource", Order = 1)]
        public PortableSource[] PortableSource;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class PortableSource
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PortableSourceSiteName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string PortableSourceStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string PortableSourceEndDate;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AirPollutants))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class AirPollutantsKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string AirFacilityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 1)]
        public string AirPollutantsCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class AirPollutants : AirPollutantsKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public ActiveInactiveType AirPollutantStatusIndicator;

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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute("DMRNonReceiptStatusIndicator", Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public enum ActiveInactiveType
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class AirPollutantEPAClassificationData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class AirPollutantDAClassificationData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class AirProgramsKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string AirFacilityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string AirProgramCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class AirPrograms : AirProgramsKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string OtherProgramDescriptionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public AirProgramOperatingStatusData AirProgramOperatingStatusData;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AirProgramSubpartData", Order = 2)]
        public AirProgramSubpartData[] AirProgramSubpartData;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class AirProgramOperatingStatusData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class AirProgramSubpartData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string AirProgramSubpartCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public ActiveInactiveType AirProgramSubpartStatusIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AirProgramSubpartStatusIndicatorSpecified;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(UnpermittedFacility))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SWMS4SmallPermit))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SWMS4LargePermit))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SWConstructionPermit))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PretreatmentPermit))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(POTWPermit))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PermitTermination))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PermitReissuance))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(MasterGeneralPermit))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(GeneralPermit))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CSOPermit))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CAFOPermit))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(BiosolidsPermit))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(BasicPermit))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SWIndustrialPermit))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PermitIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class UnpermittedFacility : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string FacilitySiteName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string LocationAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string SupplementalLocationText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LocalityName", typeof(string), Order = 3)]
        [System.Xml.Serialization.XmlElementAttribute("LocationAddressCityCode", typeof(string), Order = 3)]
        [System.Xml.Serialization.XmlElementAttribute("LocationAddressCountyCode", typeof(string), Order = 3)]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        public string[] Items;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName", Order = 4)]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemsChoiceType2[] ItemsElementName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string LocationStateCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string LocationZipCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string LocationCountryCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string OrganizationDUNSNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public string StateFacilityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public string StateRegionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        public string FacilityCongressionalDistrictNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FacilityClassification", Order = 12)]
        public string[] FacilityClassification;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PolicyCode", Order = 13)]
        public string[] PolicyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OriginatingProgramsCode", Order = 14)]
        public string[] OriginatingProgramsCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        public string FacilityTypeOfOwnershipCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        public string FederalFacilityIdentificationNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        public string FederalAgencyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        public string TribalLandCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        public string ConstructionProjectName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        public string ConstructionProjectLatitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        public string ConstructionProjectLongitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SICCodeDetails", Order = 22)]
        public SICCodeDetails[] SICCodeDetails;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NAICSCodeDetails", Order = 23)]
        public NAICSCodeDetails[] NAICSCodeDetails;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 24)]
        public string SectionTownshipRange;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 25)]
        public string FacilityComments;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 26)]
        public string FacilityUserDefinedField1;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 27)]
        public string FacilityUserDefinedField2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 28)]
        public string FacilityUserDefinedField3;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 29)]
        public string FacilityUserDefinedField4;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 30)]
        public string FacilityUserDefinedField5;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 31)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Contact[] FacilityContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 32)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Address[] FacilityAddress;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 33)]
        public GeographicCoordinates GeographicCoordinates;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PermitComponentTypeCode", Order = 34)]
        public string[] PermitComponentTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 35)]
        public string PermitCommentsText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IncludeInSchema = false)]
    public enum ItemsChoiceType2
    {

        /// <remarks/>
        LocalityName,

        /// <remarks/>
        LocationAddressCityCode,

        /// <remarks/>
        LocationAddressCountyCode,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SWMS4SmallPermit : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string StateWaterBodyName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string ReceivingMS4Name;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string ImpairedWaterIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string HistoricPropertyIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string HistoricPropertyCriterionMetCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string SpeciesCriticalHabitatIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string SpeciesCriterionMetCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string IndustrialActivitySize;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string LegalEntityTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public string MS4PermitClassCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public string MS4TypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        public string MS4AcreageCoveredNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        public string MS4PopulationServedNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        public string UrbanizedAreaIncorporatedPlaceName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        public string MS4AnnualExpenditureDollars;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        public string MS4AnnualExpenditureYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        public string MS4BudgetDollars;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        public string MS4BudgetYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        public string ProjectSourcesOfFundingCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        public EstimatedMeasuredType MajorOutfallEstimatedMeasureIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MajorOutfallEstimatedMeasureIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        public string MajorOutfallNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        public EstimatedMeasuredType MinorOutfallEstimatedMeasureIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MinorOutfallEstimatedMeasureIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        public string MinorOutfallNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 23)]
        public string QualifyingLocalProgramIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 24)]
        public string QualifyingLocalProgramDescriptionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 25)]
        public string SharedResponsibilitiesIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 26)]
        public string SharedResponsibilitiesDescriptionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 27)]
        public GPCFConstructionWaiver GPCFConstructionWaiver;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 28)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Contact[] StormWaterContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 29)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Address[] StormWaterAddress;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute("MajorOutfallEstimatedMeasureIndicator", Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public enum EstimatedMeasuredType
    {

        /// <remarks/>
        E,

        /// <remarks/>
        M,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("*")]
        Item,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class GPCFConstructionWaiver
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string ConstructionWaiverAuthorizationDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string ConstructionWaiverCriteriaMetIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string ConstructionWaiverEvaluationBasisCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string ConstructionWaiverEvaluationDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string ConstructionWaiverPostmarkDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string ProjectIsoerodentValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string ProjectEstimatedStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string ProjectEstimatedCompletedDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SWMS4LargePermit : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string StateWaterBodyName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string ReceivingMS4Name;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string ImpairedWaterIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string HistoricPropertyIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string HistoricPropertyCriterionMetCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string SpeciesCriticalHabitatIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string SpeciesCriterionMetCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string IndustrialActivitySize;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string LegalEntityTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public string MS4PermitClassCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public string MS4TypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        public string MS4AcreageCoveredNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        public string MS4PopulationServedNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        public string UrbanizedAreaIncorporatedPlaceName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        public string MS4AnnualExpenditureDollars;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        public string MS4AnnualExpenditureYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        public string MS4BudgetDollars;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        public string MS4BudgetYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        public string ProjectSourcesOfFundingCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        public EstimatedMeasuredType MajorOutfallEstimatedMeasureIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MajorOutfallEstimatedMeasureIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        public string MajorOutfallNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        public EstimatedMeasuredType MinorOutfallEstimatedMeasureIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MinorOutfallEstimatedMeasureIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        public string MinorOutfallNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 23)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Contact[] StormWaterContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 24)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Address[] StormWaterAddress;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SWConstructionPermit : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string StateWaterBodyName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string ReceivingMS4Name;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string ImpairedWaterIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string HistoricPropertyIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string HistoricPropertyCriterionMetCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string SpeciesCriticalHabitatIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string SpeciesCriterionMetCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string IndustrialActivitySize;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public HistoricPreservationData HistoricPreservationData;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public GPCFNoticeOfIntent GPCFNoticeOfIntent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public GPCFNoticeOfTermination GPCFNoticeOfTermination;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        public ConstructionSiteList ConstructionSiteList;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        public string ProjectTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        public string EstimatedStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        public string EstimatedCompleteDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        public string EstimatedAreaDisturbedAcresNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        public string ProjectPlanSizeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        public string StructureDemolishedIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        public string StructureDemolishedFloorSpaceIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        public string PredevelopmentLandUseIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        public string EarthDisturbingActivitiesIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        public string EarthDisturbingEmergencyIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        public string PreviousStormwaterDischargesIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 23)]
        public string OtherPermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 24)]
        public string CGPIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 25)]
        public string MS4DischargeIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 26)]
        public string WaterProximityIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 27)]
        public string AntidegradationIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 28)]
        public string TreatmentChemicalsIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 29)]
        public string CationicChemicalsIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 30)]
        public string CationicChemicalsAuthorizationIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 31)]
        [System.Xml.Serialization.XmlArrayItemAttribute("TreatmentChemicalName", IsNullable = false)]
        public string[] TreatmentChemicalsList;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 32)]
        public string SWPPPPreparedIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 33)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Contact[] StormWaterContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 34)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Address[] StormWaterAddress;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class HistoricPreservationData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string SubsurfaceEarthDisturbanceIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string PriorSurveysEvaluationsIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string SubsurfaceEarthDisturbanceControlIndicator;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class GPCFNoticeOfIntent
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string NOISignatureDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string NOIPostmarkDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string NOIReceivedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string CompleteNOIReceivedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SubsectorCodePlusDescription", Order = 4)]
        public string[] SubsectorCodePlusDescription;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string FederalCERCLADischargeIndicator;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class GPCFNoticeOfTermination
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string NOTTerminationDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string NOTSignatureDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string NOTPostmarkDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string NOTReceivedDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class ConstructionSiteList
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ConstructionSiteCode", Order = 0)]
        public string[] ConstructionSiteCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string ConstructionSiteOtherText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class PretreatmentPermit : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public PretreatmentProgramRequiredIndicatorType PretreatmentProgramRequiredIndicatorCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PretreatmentProgramRequiredIndicatorCodeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string ControlAuthorityStateAgencyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string ControlAuthorityRegionalAgencyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string ControlAuthorityNPDESIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string PretreatmentProgramApprovedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 5)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Contact[] PretreatmentContact;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute("PretreatmentProgramRequiredIndicatorCode", Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public enum PretreatmentProgramRequiredIndicatorType
    {

        /// <remarks/>
        C,

        /// <remarks/>
        E,

        /// <remarks/>
        R,

        /// <remarks/>
        S,

        /// <remarks/>
        Y,

        /// <remarks/>
        N,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class POTWPermit : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 0)]
        public string SSCSPopulationServedNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 1)]
        public string CombinedSSCSSystemLength;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SatelliteCollectionSystem", Order = 2)]
        public SatelliteCollectionSystem[] SatelliteCollectionSystem;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SatelliteCollectionSystem
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string SatelliteCollectionSystemIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string SatelliteCollectionSystemName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class PermitTermination : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 0)]
        public System.DateTime PermitTerminationDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class PermitReissuance : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 0)]
        public System.DateTime PermitIssueDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        public System.DateTime PermitEffectiveDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 2)]
        public System.DateTime PermitExpirationDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class MasterGeneralPermit : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PermitTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string AgencyTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 2)]
        public System.DateTime PermitIssueDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PermitIssueDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 3)]
        public System.DateTime PermitEffectiveDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PermitEffectiveDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 4)]
        public System.DateTime PermitExpirationDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PermitExpirationDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string ReissuancePriorityPermitIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string BacklogReasonText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string PermitIssuingOrganizationTypeName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OtherPermits", Order = 8)]
        public OtherPermits[] OtherPermits;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AssociatedPermit", Order = 9)]
        public AssociatedPermit[] AssociatedPermit;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public string PermitAppealedIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SICCodeDetails", Order = 11)]
        public SICCodeDetails[] SICCodeDetails;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NAICSCodeDetails", Order = 12)]
        public NAICSCodeDetails[] NAICSCodeDetails;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        public string PermitUserDefinedDataElement1Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        public string PermitUserDefinedDataElement2Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        public string PermitUserDefinedDataElement3Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        public string PermitUserDefinedDataElement4Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        public string PermitUserDefinedDataElement5Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        public string PermitCommentsText;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 19)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Contact[] PermitContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        public string GeneralPermitIndustrialCategory;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        public string PermitName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PermitComponentTypeCode", Order = 22)]
        public string[] PermitComponentTypeCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class OtherPermits
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string OtherPermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string OtherOrganizationName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string OtherPermitIdentifierContextName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class AssociatedPermit
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string AssociatedPermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string AssociatedPermitReasonCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class GeneralPermit : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string ElectronicSubmissionTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string AssociatedMasterGeneralPermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string PermitTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string AgencyTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public PermitStatusCodeType PermitStatusCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PermitStatusCodeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NPDESDataGroupNumberCode", Order = 5)]
        public string[] NPDESDataGroupNumberCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public ElectronicReportingWaiverData ElectronicReportingWaiverData;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 7)]
        public System.DateTime PermitIssueDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PermitIssueDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 8)]
        public System.DateTime PermitEffectiveDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PermitEffectiveDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 9)]
        public System.DateTime PermitExpirationDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PermitExpirationDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public string ReissuancePriorityPermitIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        public string BacklogReasonText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        public string PermitIssuingOrganizationTypeName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OtherPermits", Order = 13)]
        public OtherPermits[] OtherPermits;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AssociatedPermit", Order = 14)]
        public AssociatedPermit[] AssociatedPermit;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        public string PermitAppealedIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SICCodeDetails", Order = 16)]
        public SICCodeDetails[] SICCodeDetails;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NAICSCodeDetails", Order = 17)]
        public NAICSCodeDetails[] NAICSCodeDetails;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        public string PermitUserDefinedDataElement1Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        public string PermitUserDefinedDataElement2Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        public string PermitUserDefinedDataElement3Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        public string PermitUserDefinedDataElement4Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        public string PermitUserDefinedDataElement5Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 23)]
        public string PermitCommentsText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 24)]
        public string MajorMinorRatingCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 25)]
        public MajorMinorStatus MajorMinorStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 26)]
        public string TotalApplicationDesignFlowNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 27)]
        public string TotalApplicationAverageFlowNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 28)]
        public Facility Facility;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 29)]
        public string ApplicationReceivedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 30)]
        public string PermitApplicationCompletionDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 31)]
        public string NewSourceIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 32)]
        public ComplianceTrackingStatus ComplianceTrackingStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 33)]
        public DMRNonReceiptStatus DMRNonReceiptStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ReportableNonComplianceStatus", Order = 34)]
        public ReportableNonComplianceStatus[] ReportableNonComplianceStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EffluentGuidelineCode", Order = 35)]
        public string[] EffluentGuidelineCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 36)]
        public string PermitStateWaterBodyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 37)]
        public string PermitStateWaterBodyName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 38)]
        public string FederalGrantIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 39)]
        public string DMRCognizantOfficial;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 40)]
        public string DMRCognizantOfficialTelephoneNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 41)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Contact[] PermitContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 42)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Address[] PermitAddress;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute("PermitStatusCode", Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public enum PermitStatusCodeType
    {

        /// <remarks/>
        NON,

        /// <remarks/>
        DEN,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class ElectronicReportingWaiverData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string ElectronicReportingWaiverTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string ElectronicReportingWaiverEffectiveDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string ElectronicReportingWaiverExpirationDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class MajorMinorStatus
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public MajorMinorType MajorMinorStatusIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string MajorMinorStatusStartDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute("MajorMinorStatusIndicator", Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public enum MajorMinorType
    {

        /// <remarks/>
        N,

        /// <remarks/>
        M,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("*")]
        Item,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class ComplianceTrackingStatus
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public ActiveInactiveType StatusCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string StatusStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string StatusReason;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class DMRNonReceiptStatus
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public ActiveInactiveType DMRNonReceiptStatusIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string DMRNonReceiptStatusStartDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class ReportableNonComplianceStatus
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 0)]
        public string ReportableNonComplianceStatusCodeYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 1)]
        public string ReportableNonComplianceStatusCodeQuarter;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string ReportableNonComplianceManualStatusCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class CSOPermit : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 0)]
        public string CSSPopulationServedNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string CombinedSewerSystemLength;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 2)]
        public string CollectionSystemCombinedPercent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SatelliteCollectionSystem", Order = 3)]
        public SatelliteCollectionSystem[] SatelliteCollectionSystem;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class CAFOPermit : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string CAFOClassificationCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 1)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Contact[] CAFOContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 2)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Address[] CAFOAddress;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string IsAnimalFacilityTypeCAFOIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string CAFODesignationDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string CAFODesignationReasonText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AnimalType", Order = 6)]
        public AnimalType[] AnimalType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ManureLitterProcessedWastewaterStorage", Order = 7)]
        public ManureLitterProcessedWastewaterStorage[] ManureLitterProcessedWastewaterStorage;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Containment", Order = 8)]
        public Containment[] Containment;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public string NumberAcresContributingDrainage;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public string ApplicationMeasureAvailableLandNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        public string SolidManureLitterGeneratedAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        public string LiquidManureWastewaterGeneratedAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        public string SolidManureLitterTransferAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        public string LiquidManureWastewaterTransferAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        public string NMPDevelopedCertifiedPlannerApprovedIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        public string NMPDevelopedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        public string NMPLastUpdatedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        public string EnvironmentalManagementSystemIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        public string EMSDevelopedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        public string EMSLastUpdatedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LandApplicationBMP", Order = 21)]
        public LandApplicationBMP[] LandApplicationBMP;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        public string LivestockMaximumCapacityNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 23)]
        public string LivestockCapacityDeterminationBasedUponNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 24)]
        public string AuthorizedLivestockCapacityNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 25)]
        public string LegalDescriptionText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class AnimalType : ReportedAnimalType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string OpenConfinementCount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string HousedUnderRoofConfinementCount;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AnimalType))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class ReportedAnimalType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string AnimalTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string OtherAnimalTypeName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string TotalNumbersEachLivestock;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class ManureLitterProcessedWastewaterStorage
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string ManureLitterProcessedWastewaterStorageType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string OtherStorageTypeName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string StorageTotalCapacityMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string DaysOfStorage;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class Containment
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string ContainmentTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string OtherContainmentTypeName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string ContainmentCapacityNumber;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class LandApplicationBMP
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string LandApplicationBMPTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string OtherLandApplicationBMPTypeName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class BiosolidsPermit : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("BiosolidsTypeCode", Order = 0)]
        public string[] BiosolidsTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("BiosolidsEndUseDisposalTypeCode", Order = 1)]
        public string[] BiosolidsEndUseDisposalTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string EQProductDistributedMarketedAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string LandAppliedAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string IncineratedAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string CodisposedInMSWLandfillAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string SurfaceDisposalAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string ManagedOtherMethodsAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string ReceivedOffsiteSourcesAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public string TransferredAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public string DisposedOutOfStateAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        public string BeneficiallyUsedOutOfStateAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        public string ManagedOtherMethodsOutOfStateAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        public string TotalRemovedAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        public string AnnualDrySludgeProductionNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 15)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Contact[] BiosolidsPermitContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 16)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Address[] BiosolidsPermitAddress;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class BasicPermit : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PermitTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string AgencyTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public PermitStatusCodeType PermitStatusCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PermitStatusCodeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NPDESDataGroupNumberCode", Order = 3)]
        public string[] NPDESDataGroupNumberCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public ElectronicReportingWaiverData ElectronicReportingWaiverData;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 5)]
        public System.DateTime PermitIssueDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PermitIssueDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 6)]
        public System.DateTime PermitEffectiveDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PermitEffectiveDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 7)]
        public System.DateTime PermitExpirationDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PermitExpirationDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string ReissuancePriorityPermitIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public string BacklogReasonText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public string PermitIssuingOrganizationTypeName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OtherPermits", Order = 11)]
        public OtherPermits[] OtherPermits;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AssociatedPermit", Order = 12)]
        public AssociatedPermit[] AssociatedPermit;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        public string PermitAppealedIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SICCodeDetails", Order = 14)]
        public SICCodeDetails[] SICCodeDetails;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NAICSCodeDetails", Order = 15)]
        public NAICSCodeDetails[] NAICSCodeDetails;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        public string PermitUserDefinedDataElement1Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        public string PermitUserDefinedDataElement2Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        public string PermitUserDefinedDataElement3Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        public string PermitUserDefinedDataElement4Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        public string PermitUserDefinedDataElement5Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        public string PermitCommentsText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        public string MajorMinorRatingCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 23)]
        public MajorMinorStatus MajorMinorStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 24)]
        public string TotalApplicationDesignFlowNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 25)]
        public string TotalApplicationAverageFlowNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 26)]
        public Facility Facility;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 27)]
        public string ApplicationReceivedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 28)]
        public string PermitApplicationCompletionDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 29)]
        public string NewSourceIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 30)]
        public ComplianceTrackingStatus ComplianceTrackingStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 31)]
        public DMRNonReceiptStatus DMRNonReceiptStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ReportableNonComplianceStatus", Order = 32)]
        public ReportableNonComplianceStatus[] ReportableNonComplianceStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EffluentGuidelineCode", Order = 33)]
        public string[] EffluentGuidelineCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 34)]
        public string PermitStateWaterBodyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 35)]
        public string PermitStateWaterBodyName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 36)]
        public string FederalGrantIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 37)]
        public string DMRCognizantOfficial;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 38)]
        public string DMRCognizantOfficialTelephoneNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 39)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Contact[] PermitContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 40)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Address[] PermitAddress;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 41)]
        public string SignificantIUIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 42)]
        public string ReceivingPermitIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SWIndustrialPermit : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string StateWaterBodyName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string ReceivingMS4Name;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string ImpairedWaterIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string HistoricPropertyIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string HistoricPropertyCriterionMetCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string SpeciesCriticalHabitatIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string SpeciesCriterionMetCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string IndustrialActivitySize;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string WebAddressURL;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public string ActivitiesExposedSWText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public string AssociatedPollutantsText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        public string ControlMeasuresText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        public string ScheduleControlMeasuresText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        public string TierTwoIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        public string TierThreeIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        public GPCFNoticeOfIntent GPCFNoticeOfIntent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        public GPCFNoticeOfTermination GPCFNoticeOfTermination;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        public GPCFNoExposure GPCFNoExposure;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 18)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Contact[] StormWaterContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 19)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Address[] StormWaterAddress;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class GPCFNoExposure
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string NoExposureAuthorizationDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string NoExposurePostmarkDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string NoExposureEvaluationDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string NoExposureEvaluationBasisCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string NoExposureCriteriaMetIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string PavedRoofSize;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(BiosolidsAnnualProgramReport))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class BiosolidsAnnualProgramReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        public System.DateTime BiosolidsAnnualReportReceivedDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class BiosolidsAnnualProgramReport : BiosolidsAnnualProgramReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string ElectronicSubmissionTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ReportingObligationTypeCode", Order = 1)]
        public string[] ReportingObligationTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 2)]
        public System.DateTime ReportingPeriodStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ReportingPeriodStartDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 3)]
        public System.DateTime ReportingPeriodEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ReportingPeriodEndDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TreatmentProcessTypeCode", Order = 4)]
        public string[] TreatmentProcessTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string TreatmentProcessOtherText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public decimal TotalVolumeAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TotalVolumeAmountSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 7)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public AnalyticalMethodData[] AnalyticalMethods;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 8)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public ManagementPracticeData[] BiosolidsManagementPractices;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public string BiosolidsAdditionalInformationCommentText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public CertifierProgramReportContact CertifierProgramReportContact;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class AnalyticalMethodData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string AnalyticalMethodTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string AnalyticalMethodOtherTypeText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class ManagementPracticeData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string SSUIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string BiosolidsManagementPracticeTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string HandlerPreparerTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LandApplicationSubCategoryCode", typeof(string), Order = 3)]
        [System.Xml.Serialization.XmlElementAttribute("OtherSubCategoryCode", typeof(string), Order = 3)]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
        public string Item;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemChoiceType ItemElementName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string SubCategoryOtherText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string BiosolidsContainerTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public decimal VolumeAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string PathogenClassTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public YesNoUnknownIndicatorTypeBase PollutantConcentrationExceedanceIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PollutantConcentrationExceedanceIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public YesNoUnknownIndicatorTypeBase PollutantLoadingRatesExceedanceIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PollutantLoadingRatesExceedanceIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PathogenReductionTypeCode", Order = 11)]
        public string[] PathogenReductionTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("VectorAttractionReductionTypeCode", Order = 12)]
        public string[] VectorAttractionReductionTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        public YesNoUnknownIndicatorTypeBase ActiveDisposalSiteIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ActiveDisposalSiteIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        public YesNoUnknownIndicatorTypeBase SiteSpecificLimitIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SiteSpecificLimitIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        public YesNoUnknownIndicatorTypeBase MinimumBoundaryDistanceIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MinimumBoundaryDistanceIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        public string MinimumBoundaryDistanceTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        public string AssociatedPermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        public ThirdPartyProgramReportContact ThirdPartyProgramReportContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        public ThirdPartyProgramReportAddress ThirdPartyProgramReportAddress;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ManagementPracticeDeficiencyTypeCode", Order = 20)]
        public string[] ManagementPracticeDeficiencyTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        public string ManagementPracticeCommentText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IncludeInSchema = false)]
    public enum ItemChoiceType
    {

        /// <remarks/>
        LandApplicationSubCategoryCode,

        /// <remarks/>
        OtherSubCategoryCode,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute("ActiveDisposalSiteIndicator", Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public enum YesNoUnknownIndicatorTypeBase
    {

        /// <remarks/>
        Y,

        /// <remarks/>
        N,

        /// <remarks/>
        U,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class ThirdPartyProgramReportContact
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public Contact Contact;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class ThirdPartyProgramReportAddress
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public Address Address;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class CertifierProgramReportContact
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public Contact Contact;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(BiosolidsProgramReport))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class BiosolidsProgramReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        public System.DateTime ReportCoverageEndDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class BiosolidsProgramReport : BiosolidsProgramReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string NumberOfReportUnits;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string EQProductDistributedMarketedAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string LandAppliedAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string IncineratedAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string CodisposedInMSWLandfillAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string SurfaceDisposalAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string ManagedOtherMethodsAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string ReceivedOffsiteSourcesAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string TransferredAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public string DisposedOutOfStateAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public string BeneficiallyUsedOutOfStateAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        public string ManagedOtherMethodsOutOfStateAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        public string TotalRemovedAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        public string AnnualDrySludgeProductionNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        public string AnnualLoadingParameterDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        public string AnnualLoadingBiosolidGallons;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        public string AnnualLoadingBiosolidDMT;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        public string AnnualLoadingNutrientNitrogen;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        public string AnnualLoadingNutrientPhosphorous;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        public string TotalNumberLandApplicationViolations;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        public string TotalNumberIncineratorViolations;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        public string TotalNumberDistributionMarketingViolations;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        public string TotalNumberSludgeRelatedManagementPracticeViolations;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 23)]
        public string TotalNumberSurfaceDisposalViolations;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 24)]
        public string TotalNumberOtherSludgeViolations;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 25)]
        public string TotalNumberCodisposalViolations;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 26)]
        public string BiosolidsReportComments;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CAFOAnnualReport))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class CAFOAnnualProgramReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        public System.DateTime PermittingAuthorityReportReceivedDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class CAFOAnnualReport : CAFOAnnualProgramReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string DischargesDuringYearProductionAreaIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ReportedAnimalType", Order = 1)]
        public ReportedAnimalType[] ReportedAnimalType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string SolidManureLitterGeneratedAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string LiquidManureWastewaterGeneratedAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string SolidManureLitterTransferAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string LiquidManureWastewaterTransferAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string NMPDevelopedCertifiedPlannerApprovedIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string TotalNumberAcresNMPIdentified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string TotalNumberAcresUsedLandApplication;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CaseFileLinkage))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AirDACaseFile))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class CaseFileKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string CaseFileIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class CaseFileLinkage : CaseFileKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LinkageAirDAEnforcementAction", typeof(LinkageAirDAEnforcementAction), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("LinkageCaseFile", typeof(LinkageCaseFile), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("LinkageComplianceMonitoring", typeof(LinkageComplianceMonitoring), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("LinkageEnforcementAction", typeof(LinkageEnforcementAction), Order = 0)]
        public object Item;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class LinkageCaseFile
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string CaseFileIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class LinkageComplianceMonitoring
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string ComplianceMonitoringIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class AirDACaseFile : CaseFileKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string CaseFileName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string LeadAgencyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string AirFacilityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProgramCode", Order = 3)]
        public string[] ProgramCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string OtherProgramDescriptionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AirPollutantCode", Order = 5)]
        public string[] AirPollutantCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public YesNoIndicatorTypeBase SensitiveDataIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SensitiveDataIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OtherPathwayActivityData", Order = 7)]
        public OtherPathwayActivityData[] OtherPathwayActivityData;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string LeadAgencyChangeSupersededText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public string AdvisementMethodTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public string AdvisementMethodDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AirViolationData", Order = 11)]
        public AirViolationData[] AirViolationData;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        public string CaseFileUserDefinedField1;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        public string CaseFileUserDefinedField2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        public string CaseFileUserDefinedField3;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        public string CaseFileUserDefinedField4;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        public string CaseFileUserDefinedField5;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        public string CaseFileUserDefinedField6;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CaseFileCommentText", Order = 18)]
        public string[] CaseFileCommentText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SensitiveCommentText", Order = 19)]
        public string[] SensitiveCommentText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class OtherPathwayActivityData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string OtherPathwayCategoryCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string OtherPathwayTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string OtherPathwayDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class AirViolationData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string AirViolationTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string AirViolationProgramCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string AirViolationProgramDescriptionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string AirViolationPollutantCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string FRVDeterminationDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string HPVDayZeroDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string OccurrenceStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string OccurrenceEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string HPVDesignationRemovalTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public string HPVDesignationRemovalDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 10)]
        public string ClaimsNumber;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AirTVACC))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ComplianceMonitoringLinkage))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(FederalComplianceMonitoring))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AirDAComplianceMonitoring))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ComplianceMonitoring))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class ComplianceMonitoringKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string ComplianceMonitoringIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
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
        public string ComplianceMonitoringStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string ComplianceMonitoringActivityName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NationalPrioritiesCode", Order = 3)]
        public string[] NationalPrioritiesCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string MultimediaIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string ComplianceMonitoringPlannedStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string ComplianceMonitoringPlannedEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("RegionalPriorityCode", Order = 7)]
        public string[] RegionalPriorityCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string DeficienciesObservedIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public string AirFacilityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public string LeadAgencyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProgramCode", Order = 11)]
        public string[] ProgramCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        public string OtherProgramDescriptionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AirPollutantCode", Order = 13)]
        public string[] AirPollutantCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        public string OtherAgencyInitiativeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        public string InspectionUserDefinedField1;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        public string InspectionUserDefinedField2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        public string InspectionUserDefinedField3;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        public string InspectionUserDefinedField4;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        public string InspectionUserDefinedField5;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        public string InspectionUserDefinedField6;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        public string AirPermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        public string CertificationPeriodStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 23)]
        public string CertificationPeriodEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 24)]
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
        public string[] InspectionCommentText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SensitiveCommentText", Order = 29)]
        public string[] SensitiveCommentText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class TVACCReviewData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string TVACCReviewedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string FacilityReportDeviationsIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string PermitConditionsText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string ExceedanceExcursionIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string ReviewerAgencyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string TVACCReviewerName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string ReviewerComment;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class ComplianceMonitoringLinkage : ComplianceMonitoringKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LinkageAirDAEnforcementAction", typeof(LinkageAirDAEnforcementAction), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("LinkageBiosolidsReport", typeof(LinkageBiosolidsReport), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("LinkageCAFOAnnualReport", typeof(LinkageCAFOAnnualReport), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("LinkageCSOEventReport", typeof(LinkageCSOEventReport), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("LinkageComplianceMonitoring", typeof(LinkageComplianceMonitoring), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("LinkageEnforcementAction", typeof(LinkageEnforcementAction), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("LinkageLocalLimitsReport", typeof(LinkageLocalLimitsReport), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("LinkagePretreatmentPerformanceReport", typeof(LinkagePretreatmentPerformanceReport), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("LinkageSSOAnnualReport", typeof(LinkageSSOAnnualReport), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("LinkageSSOEventReport", typeof(LinkageSSOEventReport), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("LinkageSSOMonthlyEventReport", typeof(LinkageSSOMonthlyEventReport), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("LinkageSWEventReport", typeof(LinkageSWEventReport), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("LinkageSWMS4Report", typeof(LinkageSWMS4Report), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("LinkageSingleEvent", typeof(LinkageSingleEvent), Order = 0)]
        public object Item;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class LinkageBiosolidsReport
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        public System.DateTime ReportCoverageEndDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class LinkageCAFOAnnualReport
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        public System.DateTime PermittingAuthorityReportReceivedDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class LinkageCSOEventReport
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        public System.DateTime CSOEventDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 2)]
        public string CSOEventID;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class LinkageLocalLimitsReport
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        public System.DateTime LocalLimitsPermittingAuthorityReportReceivedDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class LinkagePretreatmentPerformanceReport
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        public System.DateTime PretreatmentPerformanceSummaryEndDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class LinkageSSOAnnualReport
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        public System.DateTime SSOAnnualReportReceivedDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class LinkageSSOEventReport
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        public System.DateTime SSOEventDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 2)]
        public string SSOEventID;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class LinkageSSOMonthlyEventReport
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        public System.DateTime SSOMonthlyReportReceivedDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class LinkageSWEventReport
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        public System.DateTime DateStormEventSampled;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 2)]
        public string StormWaterEventID;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class LinkageSWMS4Report
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        public System.DateTime StormWaterMS4ReportReceivedDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class LinkageSingleEvent
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string SingleEventViolationCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 2)]
        public System.DateTime SingleEventViolationDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class FederalComplianceMonitoring : ComplianceMonitoringKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string ProgramSystemAcronym;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string ProgramSystemIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string FederalStatuteCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public ComplianceMonitoringActivityTypeCodeType ComplianceMonitoringActivityTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ComplianceMonitoringActivityTypeCodeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string ComplianceMonitoringCategoryCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 5)]
        public System.DateTime ComplianceMonitoringDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ComplianceMonitoringDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string ComplianceMonitoringStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ComplianceInspectionTypeCode", Order = 7)]
        public string[] ComplianceInspectionTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string ComplianceMonitoringActivityName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public string BiomonitoringInspectionMethod;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ComplianceMonitoringActionReasonCode", Order = 10)]
        public string[] ComplianceMonitoringActionReasonCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ComplianceMonitoringAgencyTypeCode", Order = 11)]
        public string[] ComplianceMonitoringAgencyTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        public string ComplianceMonitoringAgencyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProgramCode", Order = 13)]
        public string[] ProgramCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProgramDeficiencyTypeCode", Order = 14)]
        public string[] ProgramDeficiencyTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        public string EPAAssistanceIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        public StateFederalJointType StateFederalJointIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StateFederalJointIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        public string JointInspectionReasonCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        public LeadPartyType LeadParty;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LeadPartySpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        public string NumberDaysPhysicallyConductingActivity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        public string NumberHoursPhysicallyConductingActivity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        public string ComplianceMonitoringActionOutcomeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        public string InspectionRatingCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NationalPrioritiesCode", Order = 23)]
        public string[] NationalPrioritiesCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 24)]
        public string MultimediaIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 25)]
        public string FederalFacilityIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 26)]
        public string FederalFacilityIndicatorComment;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 27)]
        public string InspectionUserDefinedField1;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 28)]
        public string InspectionUserDefinedField2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 29)]
        public string InspectionUserDefinedField3;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 30)]
        public string InspectionUserDefinedField4;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 31)]
        public string InspectionUserDefinedField5;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 32)]
        public string InspectionUserDefinedField6;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("InspectionCommentText", Order = 33)]
        public string[] InspectionCommentText;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 34)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Contact[] InspectionContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("InspectionGovernmentContact", Order = 35)]
        public InspectionGovernmentContact[] InspectionGovernmentContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 36)]
        public string ComplianceMonitoringPlannedStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 37)]
        public string ComplianceMonitoringPlannedEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 38)]
        public string EPARegion;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LawSectionCode", Order = 39)]
        public string[] LawSectionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 40)]
        public string ComplianceMonitoringMediaTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("RegionalPriorityCode", Order = 41)]
        public string[] RegionalPriorityCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SICCode", Order = 42)]
        public string[] SICCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NAICSCode", Order = 43)]
        public string[] NAICSCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 44)]
        public string OtherProgramDescriptionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 45)]
        public string LeadAgencyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 46)]
        public InspectionConclusionDataSheet InspectionConclusionDataSheet;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Subactivity", Order = 47)]
        public Subactivity[] Subactivity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Citation", Order = 48)]
        public Citation[] Citation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 49)]
        public CAFOInspection CAFOInspection;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 50)]
        public CSOInspection CSOInspection;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 51)]
        public PretreatmentInspection PretreatmentInspection;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 52)]
        public SSOInspection SSOInspection;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 53)]
        public StormWaterConstructionNonConstructionInspections StormWaterConstructionNonConstructionInspections;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 54)]
        public StormWaterMS4Inspection StormWaterMS4Inspection;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 55)]
        public FederalAirStackTestData FederalAirStackTestData;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute("StateFederalJointIndicator", Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public enum StateFederalJointType
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute("LeadParty", Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public enum LeadPartyType
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class InspectionConclusionDataSheet
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string DeficienciesObservedIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("DeficiencyObservedCode", Order = 1)]
        public string[] DeficiencyObservedCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string DeficiencyCommunicatedFacilityIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string FacilityActionObservedIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CorrectiveActionCode", Order = 4)]
        public string[] CorrectiveActionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AirPollutantCode", Order = 5)]
        public string[] AirPollutantCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("WaterPollutantCode", Order = 6)]
        public string[] WaterPollutantCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string NationalPolicyGeneralAssistanceIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string NationalPolicySiteSpecificAssistanceIndicator;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class Subactivity
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string SubactivityTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string SubactivityPlannedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string SubactivityDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class Citation
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string CitationTitle;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string CitationPart;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string CitationSection;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class CAFOInspection
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string CAFOClassificationCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string IsAnimalFacilityTypeCAFOIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string CAFODesignationDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string CAFODesignationReasonText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string DischargesDuringYearProductionAreaIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AnimalType", Order = 5)]
        public AnimalType[] AnimalType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ManureLitterProcessedWastewaterStorage", Order = 6)]
        public ManureLitterProcessedWastewaterStorage[] ManureLitterProcessedWastewaterStorage;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Containment", Order = 7)]
        public Containment[] Containment;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string NumberAcresContributingDrainage;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public string ApplicationMeasureAvailableLandNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public string SolidManureLitterGeneratedAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        public string LiquidManureWastewaterGeneratedAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        public string SolidManureLitterTransferAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        public string LiquidManureWastewaterTransferAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        public string NMPDevelopedCertifiedPlannerApprovedIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        public string NMPDevelopedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        public string NMPLastUpdatedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        public string EnvironmentalManagementSystemIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        public string EMSDevelopedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        public string EMSLastUpdatedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LandApplicationBMP", Order = 20)]
        public LandApplicationBMP[] LandApplicationBMP;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        public string LivestockMaximumCapacityNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        public string LivestockCapacityDeterminationBasedUponNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 23)]
        public string AuthorizedLivestockCapacityNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CAFOInspectionViolationTypeCode", Order = 24)]
        public string[] CAFOInspectionViolationTypeCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class CSOInspection
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 0)]
        public System.DateTime CSOEventDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CSOEventDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public WetDryType DryOrWetWeatherIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DryOrWetWeatherIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string PermittedFeatureIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string LatitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string LongitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string CSOOverflowLocationStreet;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string DurationCSOOverflowEvent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string DischargeVolumeTreated;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string DischargeVolumeUntreated;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public string CorrectiveActionTakenDescriptionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public string InchesPrecipitation;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute("DryOrWetWeatherIndicator", Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public enum WetDryType
    {

        /// <remarks/>
        W,

        /// <remarks/>
        D,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("*")]
        Item,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class PretreatmentInspection
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string SUOReference;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string SUODate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public YesNoIndicatorTypeBase AcceptanceHazardousWaste;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AcceptanceHazardousWasteSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public YesNoIndicatorTypeBase AcceptanceNonHazardousIndustrialWaste;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AcceptanceNonHazardousIndustrialWasteSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public YesNoIndicatorTypeBase AcceptanceHauledDomesticWastes;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AcceptanceHauledDomesticWastesSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string AnnualPretreatmentBudget;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public YesNoIndicatorTypeBase InadequacySamplingInspectionIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool InadequacySamplingInspectionIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public YesNoIndicatorTypeBase AdequacyPretreatmentResources;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AdequacyPretreatmentResourcesSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public YesNoIndicatorTypeBase DeficienciesIdentifiedDuringIUFileReview;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DeficienciesIdentifiedDuringIUFileReviewSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public YesNoIndicatorTypeBase ControlMechanismDeficiencies;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ControlMechanismDeficienciesSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public YesNoIndicatorTypeBase LegalAuthorityDeficiencies;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LegalAuthorityDeficienciesSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        public YesNoIndicatorTypeBase DeficienciesInterpretationApplicationPretreatmentStandards;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DeficienciesInterpretationApplicationPretreatmentStandardsSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        public YesNoIndicatorTypeBase DeficienciesDataManagementPublicParticipation;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DeficienciesDataManagementPublicParticipationSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        public YesNoIndicatorTypeBase ViolationIUScheduleRemedialMeasures;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ViolationIUScheduleRemedialMeasuresSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        public string FormalResponseViolationIUScheduleRemedialMeasures;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        public string AnnualFrequencyInfluentToxicantSampling;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        public string AnnualFrequencyEffluentToxicantSampling;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        public string AnnualFrequencySludgeToxicantSampling;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        public string NumberSIUs;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        public string SIUsWithoutControlMechanism;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        public string SIUsNotInspected;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        public string SIUsNotSampled;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        public string SIUsOnSchedule;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 23)]
        public string SIUsSNCWithPretreatmentStandards;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 24)]
        public string SIUsSNCWithReportingRequirements;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 25)]
        public string SIUsSNCWithPretreatmentSchedule;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 26)]
        public string SIUsSNCPublishedNewspaper;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 27)]
        public string ViolationNoticesIssuedSIUs;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 28)]
        public string AdministrativeOrdersIssuedSIUs;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 29)]
        public string CivilSuitsFiledAgainstSIUs;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 30)]
        public string CriminalSuitsFiledAgainstSIUs;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 31)]
        public string DollarAmountPenaltiesCollected;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 32)]
        public string IUsWhichPenaltiesHaveBeenCollected;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 33)]
        public string NumberCIUs;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 34)]
        public string CIUsInSNC;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 35)]
        public string PassThroughInterferenceIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 36)]
        public LocalLimits LocalLimits;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 37)]
        public RemovalCredits RemovalCredits;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class LocalLimits
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string MostRecentDateTechnicalEvaluationLocalLimits;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string MostRecentDateAdoptionTechnicallyBasedLocalLimits;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LocalLimitsPollutantCode", Order = 2)]
        public string[] LocalLimitsPollutantCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class RemovalCredits
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string MostRecentDateRemovalCreditsApproval;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string RemovalCreditsApplicationStatusCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("RemovalCreditsPollutantCode", Order = 2)]
        public string[] RemovalCreditsPollutantCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SSOInspection
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 0)]
        public System.DateTime SSOEventDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SSOEventDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string CauseSSOOverflowEvent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string LatitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string LongitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string SSOOverflowLocationStreet;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string DurationSSOOverflowEvent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string SSOVolume;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string NameReceivingWater;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ImpactSSOEvent", Order = 8)]
        public string[] ImpactSSOEvent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SSOSystemComponent", Order = 9)]
        public SSOSystemComponent[] SSOSystemComponent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SSOSteps", Order = 10)]
        public SSOSteps[] SSOSteps;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        public string DescriptionStepsTaken;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SSOSystemComponent
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string SystemComponent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string OtherSystemComponent;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SSOSteps
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string StepsReducePreventMitigate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string OtherStepsReducePreventMitigate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class StormWaterConstructionNonConstructionInspections
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public StormWaterUnpermittedConstructionInspection StormWaterUnpermittedConstructionInspection;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public StormWaterConstructionIndustrialInspection StormWaterConstructionIndustrialInspection;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class StormWaterUnpermittedConstructionInspection
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public ProjectType ProjectType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string EstimatedStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string EstimatedCompleteDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string EstimatedAreaDisturbedAcresNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string ProjectPlanSizeCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class ProjectType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string ProjectTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string ProjectTypeCodeOtherDescription;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class StormWaterConstructionIndustrialInspection
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string SWPPPEvaluationBasisCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string SWPPPEvaluationDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string SWPPPEvaluationDescriptionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string NoExposureAuthorizationDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class StormWaterMS4Inspection
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string MS4AnnualExpenditureDollars;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string MS4AnnualExpenditureYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string MS4BudgetDollars;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string MS4BudgetYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProjectedSourcesFundingCode", Order = 4)]
        public string[] ProjectedSourcesFundingCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public EstimatedMeasuredType MajorOutfallEstimatedMeasureIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MajorOutfallEstimatedMeasureIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string MajorOutfallNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public EstimatedMeasuredType MinorOutfallEstimatedMeasureIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MinorOutfallEstimatedMeasureIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string MinorOutfallNumber;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class FederalAirStackTestData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string StackTestStatusCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string StackTestConductorTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string StackIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string OtherStackTestPurposeName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("StackTestObservedAgencyTypeCode", Order = 4)]
        public string[] StackTestObservedAgencyTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string StackTestReportReceivedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string TestResultsReviewedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TestResultsData", Order = 7)]
        public TestResultsData[] TestResultsData;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class TestResultsData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string AirTestedPollutantCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string TestResultCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MethodCode", Order = 2)]
        public string[] MethodCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string AllowableValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string AllowableUnitCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string ActualResult;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string FailureReasonCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string OtherFailureReasonText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class AirDAComplianceMonitoring : ComplianceMonitoringKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public ComplianceMonitoringActivityTypeCodeType ComplianceMonitoringActivityTypeCode;

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
        public string ComplianceMonitoringStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ComplianceInspectionTypeCode", Order = 3)]
        public string[] ComplianceInspectionTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string ComplianceMonitoringActivityName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NationalPrioritiesCode", Order = 5)]
        public string[] NationalPrioritiesCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string MultimediaIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string ComplianceMonitoringPlannedStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string ComplianceMonitoringPlannedEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("RegionalPriorityCode", Order = 9)]
        public string[] RegionalPriorityCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public string DeficienciesObservedIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AirFacilityIdentifier", Order = 11)]
        public string[] AirFacilityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        public string LeadAgencyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProgramCode", Order = 13)]
        public string[] ProgramCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        public string OtherProgramDescriptionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AirPollutantCode", Order = 15)]
        public string[] AirPollutantCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        public string OtherAgencyInitiativeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        public string InspectionUserDefinedField1;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        public string InspectionUserDefinedField2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        public string InspectionUserDefinedField3;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        public string InspectionUserDefinedField4;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        public string InspectionUserDefinedField5;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
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
        public string[] InspectionCommentText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SensitiveCommentText", Order = 26)]
        public string[] SensitiveCommentText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 27)]
        public AirStackTestData AirStackTestData;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class AirStackTestData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string StackTestStatusCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string StackTestConductorTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string StackIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("StackTestPurposeCode", Order = 3)]
        public string[] StackTestPurposeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string OtherStackTestPurposeName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("StackTestObservedAgencyTypeCode", Order = 5)]
        public string[] StackTestObservedAgencyTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string StackTestReportReceivedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string TestResultsReviewedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TestResultsData", Order = 8)]
        public TestResultsData[] TestResultsData;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class ComplianceMonitoring : ComplianceMonitoringKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public ComplianceMonitoringActivityTypeCodeType ComplianceMonitoringActivityTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ComplianceMonitoringActivityTypeCodeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string ComplianceMonitoringCategoryCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 3)]
        public System.DateTime ComplianceMonitoringDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ComplianceMonitoringDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string ComplianceMonitoringStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ComplianceInspectionTypeCode", Order = 5)]
        public string[] ComplianceInspectionTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string ComplianceMonitoringActivityName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string BiomonitoringInspectionMethod;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ComplianceMonitoringActionReasonCode", Order = 8)]
        public string[] ComplianceMonitoringActionReasonCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ComplianceMonitoringAgencyTypeCode", Order = 9)]
        public string[] ComplianceMonitoringAgencyTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public string ComplianceMonitoringAgencyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProgramCode", Order = 11)]
        public string[] ProgramCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProgramDeficiencyTypeCode", Order = 12)]
        public string[] ProgramDeficiencyTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        public string StateStatuteViolatedName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        public string EPAAssistanceIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        public StateFederalJointType StateFederalJointIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StateFederalJointIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        public string JointInspectionReasonCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        public LeadPartyType LeadParty;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LeadPartySpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        public string NumberDaysPhysicallyConductingActivity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        public string NumberHoursPhysicallyConductingActivity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        public string ComplianceMonitoringActionOutcomeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        public string InspectionRatingCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NationalPrioritiesCode", Order = 22)]
        public string[] NationalPrioritiesCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 23)]
        public string MultimediaIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 24)]
        public string FederalFacilityIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 25)]
        public string FederalFacilityIndicatorComment;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 26)]
        public string InspectionUserDefinedField1;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 27)]
        public string InspectionUserDefinedField2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 28)]
        public string InspectionUserDefinedField3;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 29)]
        public string InspectionUserDefinedField4;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 30)]
        public string InspectionUserDefinedField5;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 31)]
        public string InspectionUserDefinedField6;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("InspectionCommentText", Order = 32)]
        public string[] InspectionCommentText;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 33)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Contact[] InspectionContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 34)]
        public string ComplianceMonitoringPlannedStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 35)]
        public string ComplianceMonitoringPlannedEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 36)]
        public CAFOInspection CAFOInspection;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 37)]
        public CSOInspection CSOInspection;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 38)]
        public PretreatmentInspection PretreatmentInspection;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 39)]
        public SSOInspection SSOInspection;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("StormWaterConstructionInspection", typeof(StormWaterConstructionInspection), Order = 40)]
        [System.Xml.Serialization.XmlElementAttribute("StormWaterConstructionNonConstructionInspections", typeof(StormWaterConstructionNonConstructionInspections), Order = 40)]
        [System.Xml.Serialization.XmlElementAttribute("StormWaterNonConstructionInspection", typeof(StormWaterNonConstructionInspection), Order = 40)]
        public object Item;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 41)]
        public StormWaterMS4Inspection StormWaterMS4Inspection;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class StormWaterConstructionInspection
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public StormWaterUnpermittedConstructionInspection StormWaterUnpermittedConstructionInspection;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public StormWaterConstructionIndustrialInspection StormWaterConstructionIndustrialInspection;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class StormWaterNonConstructionInspection
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public StormWaterUnpermittedConstructionInspection StormWaterUnpermittedConstructionInspection;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public StormWaterConstructionIndustrialInspection StormWaterConstructionIndustrialInspection;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ComplianceScheduleViolation))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ComplianceSchedule))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class ComplianceScheduleKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string EnforcementActionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string FinalOrderIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 3)]
        public string ComplianceScheduleNumber;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class ComplianceScheduleViolation : ComplianceScheduleKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string ScheduleEventCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        public System.DateTime ScheduleDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class ComplianceSchedule : ComplianceScheduleKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string ComplianceScheduleComments;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string ScheduleDescriptorCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ComplianceScheduleEvent", Order = 2)]
        public ComplianceScheduleEvent[] ComplianceScheduleEvent;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class ComplianceScheduleEvent : ComplianceScheduleEventKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string ScheduleReportReceivedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string ScheduleActualDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string ScheduleProjectedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string ScheduleUserDefinedDataElement1;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string ScheduleUserDefinedDataElement2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string ScheduleEventComments;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string ComplianceSchedulePenaltyAmount;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ComplianceScheduleEvent))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute("ComplianceScheduleEventIdentifier", Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class ComplianceScheduleEventKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string ScheduleEventCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        public System.DateTime ScheduleDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class ComplianceScheduleEventViolationKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string EnforcementActionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string FinalOrderIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 3)]
        public string ComplianceScheduleNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string ScheduleEventCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 5)]
        public System.DateTime ScheduleDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public ScheduleViolationCodeType ScheduleViolationCode;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CSOEventReport))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class CSOEventReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        public System.DateTime CSOEventDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 2)]
        public string CSOEventID;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class CSOEventReport : CSOEventReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public WetDryType DryOrWetWeatherIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DryOrWetWeatherIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string PermittedFeatureIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string LatitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string LongitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string CSOOverflowLocationStreet;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string DurationCSOOverflowEvent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string DischargeVolumeTreated;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string DischargeVolumeUntreated;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string CorrectiveActionTakenDescriptionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public string InchesPrecipitation;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(DischargeMonitoringReportParameterViolation))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(DischargeMonitoringReportViolation))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(DMRProgramReportLinkage))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(DischargeMonitoringReport))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class DischargeMonitoringReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string PermittedFeatureIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string LimitSetDesignator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 3)]
        public System.DateTime MonitoringPeriodEndDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class DischargeMonitoringReportParameterViolation : DischargeMonitoringReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string ParameterCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string MonitoringSiteDescriptionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 2)]
        public string LimitSeasonNumber;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class DischargeMonitoringReportViolation : DischargeMonitoringReportKeyElements
    {
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class DMRProgramReportLinkage : DischargeMonitoringReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LinkageBiosolidsReport", typeof(LinkageBiosolidsReport), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("LinkageSWEventReport", typeof(LinkageSWEventReport), Order = 0)]
        public object Item;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class DischargeMonitoringReport : DischargeMonitoringReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string ElectronicSubmissionTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string SignatureDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string PrincipalExecutiveOfficerFirstName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string PrincipalExecutiveOfficerLastName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string PrincipalExecutiveOfficerTitle;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string PrincipalExecutiveOfficerTelephone;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string SignatoryFirstName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string SignatoryLastName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string SignatoryTelephone;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public string ReportCommentText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("DMRNoDischargeIndicator", typeof(string), Order = 10)]
        [System.Xml.Serialization.XmlElementAttribute("DMRNoDischargeReceivedDate", typeof(string), Order = 10)]
        [System.Xml.Serialization.XmlElementAttribute("ReportParameter", typeof(ReportParameter), Order = 10)]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        public object[] Items;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName", Order = 11)]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemsChoiceType3[] ItemsElementName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        public LandApplicationSite LandApplicationSite;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        public SurfaceDisposalSite SurfaceDisposalSite;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        public Incinerator Incinerator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        public CoDisposalSite CoDisposalSite;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class ReportParameter : ParameterKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string ReportSampleTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string ReportingFrequencyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string ReportNumberOfExcursions;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string ConcentrationNumericReportUnitMeasureCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string QuantityNumericReportUnitMeasureCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NumericReport", Order = 5)]
        public NumericReport[] NumericReport;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class NumericReport
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public NumericReportTextType NumericReportCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string NumericReportReceivedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string NumericReportNoDischargeIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string NumericConditionQuantity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string NumericConditionAdjustedQuantity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string NumericConditionQualifier;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ReportParameter))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class ParameterKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string ParameterCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string MonitoringSiteDescriptionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 2)]
        public string LimitSeasonNumber;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IncludeInSchema = false)]
    public enum ItemsChoiceType3
    {

        /// <remarks/>
        DMRNoDischargeIndicator,

        /// <remarks/>
        DMRNoDischargeReceivedDate,

        /// <remarks/>
        ReportParameter,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class LandApplicationSite
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PollutantMetForLandApplication;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string PathogenReductionIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string VectorReductionIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string AgronomicGallonsRateForField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string AgronomicDMTRateForField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string ClassAAlternativeUsed;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string ClassAAlternativesText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string ClassBAlternativeUsed;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string ClassBAlternativesText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public string VARAlternativeUsed;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public string VARAlternativesText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CropTypesPlanted", Order = 11)]
        public string[] CropTypesPlanted;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CropTypesHarvested", Order = 12)]
        public string[] CropTypesHarvested;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SurfaceDisposalSite
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PathogenReductionIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string VectorReductionIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string ManagementPracticesIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string CertificationStatementIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string CertifierFirstName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string CertifierLastName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string ClassAAlternativeUsed;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string ClassAAlternativesText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string ClassBAlternativeUsed;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public string ClassBAlternativesText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public string VARAlternativeUsed;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        public string VARAlternativesText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class Incinerator
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string BerylliumComplianceIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string MercuryComplianceIndicator;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class CoDisposalSite
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string Part258ComplianceIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public PassFailIndicatorType PaintFilterTestResult;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PaintFilterTestResultSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public PassFailIndicatorType TCLPTestResult;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TCLPTestResultSpecified;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute("PaintFilterTestResult", Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public enum PassFailIndicatorType
    {

        /// <remarks/>
        P,

        /// <remarks/>
        F,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("*")]
        Item,
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(DMRViolation))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class DMRViolationKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string PermittedFeatureIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string LimitSetDesignator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 3)]
        public System.DateTime MonitoringPeriodEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string ParameterCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string MonitoringSiteDescriptionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 6)]
        public string LimitSeasonNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public NumericReportTextType NumericReportCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public NumericReportViolationCodeType NumericReportViolationCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class DMRViolation : DMRViolationKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string ReportableNonComplianceDetectionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string ReportableNonComplianceDetectionDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string ReportableNonComplianceResolutionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string ReportableNonComplianceResolutionDate;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(FinalOrderViolationLinkage))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(EnforcementActionViolationLinkage))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(InformalEnforcementAction))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(FormalEnforcementAction))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class EnforcementActionKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string EnforcementActionIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class FinalOrderViolationLinkage : EnforcementActionKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string FinalOrderIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ComplianceScheduleViolation", typeof(ComplianceScheduleViolation), Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute("DischargeMonitoringReportParameterViolation", typeof(DischargeMonitoringReportParameterViolation), Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute("DischargeMonitoringReportViolation", typeof(DischargeMonitoringReportViolation), Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute("PermitScheduleViolation", typeof(PermitScheduleViolation), Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute("SingleEventsViolation", typeof(SingleEventsViolation), Order = 1)]
        public object Item;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class PermitScheduleViolation : PermitScheduleKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string ScheduleEventCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        public System.DateTime ScheduleDate;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(NarrativeCondition))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PermitSchedule))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PermitScheduleViolation))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class PermitScheduleKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 1)]
        public string NarrativeConditionNumber;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class NarrativeCondition : PermitScheduleKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string NarrativeConditionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string Comments;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PermitScheduleEvent", Order = 2)]
        public PermitScheduleEvent[] PermitScheduleEvent;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class PermitScheduleEvent : PermitScheduleEventKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string ScheduleReportReceivedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string ScheduleActualDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string ScheduleProjectedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string ScheduleUserDefinedDataElement1;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string ScheduleUserDefinedDataElement2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string ScheduleEventComments;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PermitScheduleEvent))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class PermitScheduleEventKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string ScheduleEventCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        public System.DateTime ScheduleDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class PermitSchedule : PermitScheduleKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string NarrativeConditionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string PermitScheduleComments;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PermitScheduleEvent", Order = 2)]
        public PermitScheduleEvent[] PermitScheduleEvent;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SingleEventsViolation : SingleEventKeyElements
    {
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SingleEventViolation))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SingleEventsViolation))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SingleEventKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string SingleEventViolationCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 2)]
        public System.DateTime SingleEventViolationDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SingleEventViolation : SingleEventKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string SingleEventViolationEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string ReportableNonComplianceDetectionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string ReportableNonComplianceDetectionDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string ReportableNonComplianceResolutionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string ReportableNonComplianceResolutionDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string SingleEventUserDefinedField1;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string SingleEventUserDefinedField2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string SingleEventUserDefinedField3;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string SingleEventUserDefinedField4;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public string SingleEventUserDefinedField5;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public string SingleEventCommentText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class EnforcementActionViolationLinkage : EnforcementActionKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ComplianceScheduleViolation", typeof(ComplianceScheduleViolation), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("DischargeMonitoringReportParameterViolation", typeof(DischargeMonitoringReportParameterViolation), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("DischargeMonitoringReportViolation", typeof(DischargeMonitoringReportViolation), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("PermitScheduleViolation", typeof(PermitScheduleViolation), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("SingleEventsViolation", typeof(SingleEventsViolation), Order = 0)]
        public object Item;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class InformalEnforcementAction : EnforcementActionKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PermitIdentifier", Order = 0)]
        public string[] PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string EnforcementActionTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string EnforcementActionName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string AchievedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProgramsViolatedCode", Order = 4)]
        public string[] ProgramsViolatedCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string FileNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string ReasonDeletingRecord;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string InformalEACommentText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string InformalEAUserDefinedField1;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public string InformalEAUserDefinedField2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public string InformalEAUserDefinedField3;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        public string InformalEAUserDefinedField4;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        public string InformalEAUserDefinedField5;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        public string InformalEAUserDefinedField6;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EnforcementAgency", Order = 14)]
        public EnforcementAgency[] EnforcementAgency;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        public string EnforcementAgencyName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EnforcementActionGovernmentContact", Order = 16)]
        public EnforcementActionGovernmentContact[] EnforcementActionGovernmentContact;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class EnforcementAgency
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string EnforcementAgencyTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string AgencyLeadIndicator;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class FormalEnforcementAction : EnforcementActionKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PermitIdentifier", Order = 0)]
        public string[] PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string EnforcementActionName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public ForumType Forum;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ForumSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EnforcementActionTypeCode", Order = 3)]
        public string[] EnforcementActionTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProgramsViolatedCode", Order = 4)]
        public string[] ProgramsViolatedCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string ResolutionTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string CombinedOrSupersededByEAID;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string ReasonDeletingRecord;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string FormalEAUserDefinedField1;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public string FormalEAUserDefinedField2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public string FormalEAUserDefinedField3;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        public string FormalEAUserDefinedField4;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        public string FormalEAUserDefinedField5;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        public string FormalEAUserDefinedField6;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FinalOrder", Order = 14)]
        public FinalOrder[] FinalOrder;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EnforcementAgency", Order = 15)]
        public EnforcementAgency[] EnforcementAgency;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        public string EnforcementAgencyName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EnforcementActionGovernmentContact", Order = 17)]
        public EnforcementActionGovernmentContact[] EnforcementActionGovernmentContact;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class FinalOrder
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string FinalOrderIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string FinalOrderTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FinalOrderPermitIdentifier", Order = 2)]
        public string[] FinalOrderPermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string FinalOrderIssuedEnteredDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string NPDESClosedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string FinalOrderQNCRComments;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string CashCivilPenaltyRequiredAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string OtherComments;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SupplementalEnvironmentalProject", Order = 8)]
        public SupplementalEnvironmentalProject[] SupplementalEnvironmentalProject;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SupplementalEnvironmentalProject
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string SupplementalEnvironmentalProjectIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string SupplementalEnvironmentalProjectDescription;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string SupplementalEnvironmentalProjectPenaltyAssessmentAmount;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(Milestone))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class EnforcementActionMilestoneKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string EnforcementActionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string MilestoneTypeCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class Milestone : EnforcementActionMilestoneKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string MilestonePlannedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string MilestoneActualDate;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(HistoricalPermitScheduleEvents))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class HistoricalPermitScheduleKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        public System.DateTime PermitEffectiveDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 2)]
        public string NarrativeConditionNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string ScheduleEventCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 4)]
        public System.DateTime ScheduleDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class HistoricalPermitScheduleEvents : HistoricalPermitScheduleKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string ScheduleReportReceivedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string ScheduleActualDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string ScheduleProjectedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string ScheduleUserDefinedDataElement1;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string ScheduleUserDefinedDataElement2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string ScheduleEventComments;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(Limits))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class LimitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string PermittedFeatureIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string LimitSetDesignator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string ParameterCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string MonitoringSiteDescriptionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 5)]
        public string LimitSeasonNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 6)]
        public System.DateTime LimitStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 7)]
        public System.DateTime LimitEndDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class Limits : LimitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string LimitTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MonthLimitApplies", Order = 1)]
        public MonthTextType[] MonthLimitApplies;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string SampleTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string FrequencyOfAnalysisCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public YesNoIndicatorTypeBase EligibleForBurdenReduction;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EligibleForBurdenReductionSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string LimitStayTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string StayStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string StayEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string StayReasonText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public string CalculateViolationsIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public string EnforcementActionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        public string FinalOrderIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        public string BasisOfLimit;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        public string LimitModificationTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        public string LimitModificationEffectiveDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        public string LimitModificationTypeStayReasonText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        public string LimitsUserDefinedField1;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        public string LimitsUserDefinedField2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        public string LimitsUserDefinedField3;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        public string ConcentrationNumericConditionUnitMeasureCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        public string QuantityNumericConditionUnitMeasureCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NumericCondition", Order = 21)]
        public NumericCondition[] NumericCondition;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute("LimitSetMonthsApplicable", Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public enum MonthTextType
    {

        /// <remarks/>
        ALL,

        /// <remarks/>
        JAN,

        /// <remarks/>
        FEB,

        /// <remarks/>
        MAR,

        /// <remarks/>
        APR,

        /// <remarks/>
        MAY,

        /// <remarks/>
        JUN,

        /// <remarks/>
        JUL,

        /// <remarks/>
        AUG,

        /// <remarks/>
        SEP,

        /// <remarks/>
        OCT,

        /// <remarks/>
        NOV,

        /// <remarks/>
        DEC,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class NumericCondition
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public NumericReportTextType NumericConditionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string NumericConditionQuantity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string NumericConditionStatisticalBaseCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string NumericConditionQualifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string NumericConditionOptionalMonitoringIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string NumericConditionStayValue;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CopyMGPLimitSetIdentifier))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CopyMGPLimitSet))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LimitSet))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class LimitSetKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string PermittedFeatureIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string LimitSetDesignator;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class CopyMGPLimitSetIdentifier : LimitSetKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TargetGeneralPermitLimitSetKeyElements TargetGeneralPermitLimitSetKeyElements;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class TargetGeneralPermitLimitSetKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string PermittedFeatureIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string LimitSetDesignator;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class CopyMGPLimitSet : LimitSetKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TargetGeneralPermitLimitSetKeyElements TargetGeneralPermitLimitSetKeyElements;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public TargetPermittedFeatureGroup TargetPermittedFeatureGroup;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public TargetLimitSetGroup TargetLimitSetGroup;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class TargetPermittedFeatureGroup
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PermittedFeatureTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string PermittedFeatureDescription;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string PermittedFeatureStateWaterBodyName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string ImpairedWaterIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string TMDLCompletedIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string PermittedFeatureUserDefinedDataElement1;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string PermittedFeatureUserDefinedDataElement2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public GeographicCoordinates GeographicCoordinates;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class TargetLimitSetGroup
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string LimitSetNameText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string DMRPrePrintCommentsText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public LimitSetStatus LimitSetStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LimitSetSchedule", Order = 3)]
        public LimitSetSchedule[] LimitSetSchedule;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class LimitSetStatus
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public ActiveInactiveType LimitSetStatusIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string LimitSetStatusStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string LimitSetStatusReasonText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class LimitSetSchedule
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string NumberUnitsReportPeriodInteger;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string NumberSubmissionUnitsInteger;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 2)]
        public System.DateTime InitialMonitoringDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool InitialMonitoringDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 3)]
        public System.DateTime InitialDMRDueDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool InitialDMRDueDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string LimitSetModificationTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string LimitSetModificationEffectiveDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class LimitSet : LimitSetKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public LimitSetType LimitSetType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string LimitSetNameText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string DMRPrePrintCommentsText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string AgencyReviewer;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string LimitSetUserDefinedDataElement1Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string LimitSetUserDefinedDataElement2Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LimitSetMonthsApplicable", Order = 6)]
        public MonthTextType[] LimitSetMonthsApplicable;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public LimitSetStatus LimitSetStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LimitSetSchedule", Order = 8)]
        public LimitSetSchedule[] LimitSetSchedule;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LocalLimitsProgramReport))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class LocalLimitsProgramReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        public System.DateTime LocalLimitsPermittingAuthorityReportReceivedDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class LocalLimitsProgramReport : LocalLimitsProgramReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public LocalLimits LocalLimits;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public RemovalCredits RemovalCredits;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ParameterLimits))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class ParameterLimitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string PermittedFeatureIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string LimitSetDesignator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string ParameterCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string MonitoringSiteDescriptionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 5)]
        public string LimitSeasonNumber;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class ParameterLimits : ParameterLimitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Limit", Order = 0)]
        public Limit[] Limit;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class Limit
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 0)]
        public System.DateTime LimitStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        public System.DateTime LimitEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string LimitTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MonthLimitApplies", Order = 3)]
        public MonthTextType[] MonthLimitApplies;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string SampleTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string FrequencyOfAnalysisCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public YesNoIndicatorTypeBase EligibleForBurdenReduction;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EligibleForBurdenReductionSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string LimitStayTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string StayStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public string StayEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public string StayReasonText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        public string CalculateViolationsIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        public string EnforcementActionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        public string FinalOrderIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        public string BasisOfLimit;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        public string LimitModificationTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        public string LimitModificationEffectiveDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        public string LimitModificationTypeStayReasonText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        public string LimitsUserDefinedField1;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        public string LimitsUserDefinedField2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        public string LimitsUserDefinedField3;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        public string ConcentrationNumericConditionUnitMeasureCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        public string QuantityNumericConditionUnitMeasureCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NumericCondition", Order = 23)]
        public NumericCondition[] NumericCondition;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class PermitScheduleEventViolationKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 1)]
        public string NarrativeConditionNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string ScheduleEventCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 3)]
        public System.DateTime ScheduleDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public ScheduleViolationCodeType ScheduleViolationCode;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PermitTrackingEvent))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class PermitTrackingEventKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string PermitTrackingEventCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 2)]
        public System.DateTime PermitTrackingEventDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class PermitTrackingEvent : PermitTrackingEventKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PermitTrackingCommentsText;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PermittedFeature))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class PermittedFeatureKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string PermittedFeatureIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class PermittedFeature : PermittedFeatureKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PermittedFeatureTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PermittedFeatureCharacteristics", Order = 1)]
        public string[] PermittedFeatureCharacteristics;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string PermittedFeatureDescription;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PermittedFeatureTreatmentTypeCode", Order = 3)]
        public string[] PermittedFeatureTreatmentTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string PermittedFeatureDesignFlowNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string PermittedFeatureActualAverageFlowNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string PermittedFeatureStateWaterBodyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string PermittedFeatureStateWaterBodyName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public TierLevelType TierLevelName;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TierLevelNameSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public string ImpairedWaterIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public string TMDLCompletedIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        public PollutantList PollutantList;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        public string PermittedFeatureUserDefinedDataElement1;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        public string PermittedFeatureUserDefinedDataElement2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        public string FieldSize;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        public string IsSiteOwnByFacility;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        public string IsSystemLinedWithLeachate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        public string DoesUnitHaveDailyCover;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        public string PropertyBoundaryDistance;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        public string IsRequiredNitrateGroundWater;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        public string WellNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        public GeographicCoordinates GeographicCoordinates;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        public string SourcePermittedFeatureDetailText;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 23)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Contact[] SiteOwnerContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 24)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Address[] SiteOwnerAddress;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute("TierLevelName", Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public enum TierLevelType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("2")]
        Item2,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("2.5")]
        Item25,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("3")]
        Item3,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class PollutantList
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 0)]
        [System.Xml.Serialization.XmlArrayItemAttribute("ImpairedWaterPollutantCode", DataType = "nonNegativeInteger", IsNullable = false)]
        public string[] ImpairedWaterPollutants;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TMDLPollutants", Order = 1)]
        public TMDLPollutants[] TMDLPollutants;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class TMDLPollutants
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string TMDLIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string TMDLName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TMDLPollutantCode", DataType = "nonNegativeInteger", Order = 2)]
        public string[] TMDLPollutantCode;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PretreatmentPerformanceSummary))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class PretreatmentPerformanceSummaryReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        public System.DateTime PretreatmentPerformanceSummaryEndDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class PretreatmentPerformanceSummary : PretreatmentPerformanceSummaryReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PretreatmentPerformanceSummaryStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string SUOReference;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string SUODate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public YesNoIndicatorTypeBase AcceptanceHazardousWaste;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AcceptanceHazardousWasteSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public YesNoIndicatorTypeBase AcceptanceNonHazardousIndustrialWaste;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AcceptanceNonHazardousIndustrialWasteSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public YesNoIndicatorTypeBase AcceptanceHauledDomesticWastes;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AcceptanceHauledDomesticWastesSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string AnnualPretreatmentBudgetPPS;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public YesNoIndicatorTypeBase InadequacySamplingInspectionIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool InadequacySamplingInspectionIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public YesNoIndicatorTypeBase AdequacyPretreatmentResources;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AdequacyPretreatmentResourcesSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public YesNoIndicatorTypeBase DeficienciesIdentifiedDuringIUFileReview;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DeficienciesIdentifiedDuringIUFileReviewSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public YesNoIndicatorTypeBase ControlMechanismDeficiencies;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ControlMechanismDeficienciesSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        public YesNoIndicatorTypeBase LegalAuthorityDeficiencies;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LegalAuthorityDeficienciesSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        public YesNoIndicatorTypeBase DeficienciesInterpretationApplicationPretreatmentStandards;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DeficienciesInterpretationApplicationPretreatmentStandardsSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        public YesNoIndicatorTypeBase DeficienciesDataManagementPublicParticipation;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DeficienciesDataManagementPublicParticipationSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        public YesNoIndicatorTypeBase ViolationIUScheduleRemedialMeasures;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ViolationIUScheduleRemedialMeasuresSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        public string FormalResponseViolationIUScheduleRemedialMeasures;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        public string AnnualFrequencyInfluentToxicantSampling;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        public string AnnualFrequencyEffluentToxicantSampling;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        public string AnnualFrequencySludgeToxicantSampling;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        public string NumberSIUs;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        public string SIUsWithoutControlMechanism;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        public string SIUsNotInspected;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        public string SIUsNotSampled;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 23)]
        public string SIUsOnSchedule;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 24)]
        public string SIUsSNCWithPretreatmentStandards;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 25)]
        public string SIUsSNCWithReportingRequirements;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 26)]
        public string SIUsSNCWithPretreatmentSchedule;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 27)]
        public string SIUsSNCPublishedNewspaper;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 28)]
        public string ViolationNoticesIssuedSIUs;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 29)]
        public string AdministrativeOrdersIssuedSIUs;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 30)]
        public string CivilSuitsFiledAgainstSIUs;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 31)]
        public string CriminalSuitsFiledAgainstSIUs;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 32)]
        public string DollarAmountPenaltiesCollectedPPS;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 33)]
        public string IUsWhichPenaltiesHaveBeenCollectedPPS;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 34)]
        public string NumberCIUs;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 35)]
        public string CIUsInSNC;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 36)]
        public string PassThroughInterferenceIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 37)]
        public LocalLimits LocalLimits;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 38)]
        public RemovalCredits RemovalCredits;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class ProgramInspectionKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string ComplianceMonitoringCategoryCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 2)]
        public System.DateTime ComplianceMonitoringDate;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ScheduleEventViolation))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class ScheduleEventViolationKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ComplianceScheduleEventViolationKeyElements", typeof(ComplianceScheduleEventViolationKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("PermitScheduleEventViolationKeyElements", typeof(PermitScheduleEventViolationKeyElements), Order = 0)]
        public object Item;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class ScheduleEventViolation : ScheduleEventViolationKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string ReportableNonComplianceResolutionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string ReportableNonComplianceResolutionDate;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SSOAnnualReport))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SSOAnnualReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        public System.DateTime SSOAnnualReportReceivedDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SSOAnnualReport : SSOAnnualReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string SSOAnnualReportYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string NumberSSOEventsPerYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string VolumeSSOEventsPerYear;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SSOEventReport))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SSOEventReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        public System.DateTime SSOEventDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 2)]
        public string SSOEventID;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SSOEventReport : SSOEventReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string CauseSSOOverflowEvent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string LatitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string LongitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string SSOOverflowLocationStreet;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string DurationSSOOverflowEvent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string SSOVolume;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string NameReceivingWater;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ImpactSSOEvent", Order = 7)]
        public string[] ImpactSSOEvent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SSOSystemComponent", Order = 8)]
        public SSOSystemComponent[] SSOSystemComponent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SSOSteps", Order = 9)]
        public SSOSteps[] SSOSteps;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public string DescriptionStepsTaken;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SSOMonthlyEventReport))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SSOMonthlyEventReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        public System.DateTime SSOMonthlyReportReceivedDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SSOMonthlyEventReport : SSOMonthlyEventReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string SSOMonthlyEventMonth;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string SSOMonthlyEventYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string NumberSSOEventsReachUSWatersPerMonth;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string VolumeSSOEventsReachUSWatersPerMonth;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SWEventReport))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SWEventReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        public System.DateTime DateStormEventSampled;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 2)]
        public string StormWaterEventID;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SWEventReport : SWEventReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PermittedFeatureIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string RainfallStormEventSampledNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string DurationStormEventSampled;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string VolumeDischargeSample;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string DurationSinceLastStormEvent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public SamplingBasisType SamplingBasisIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SamplingBasisIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public PrecipitationFormType PrecipitationForm;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PrecipitationFormSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string SampleTakenWithinTimeframeIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string TimeExceedanceRationaleCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public string EssentiallyIdenticalOutfallNotification;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public string MonitoringExemptionRationaleIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        public string PollutantMonitoringBasisCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 12)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Contact[] StormWaterContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 13)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Address[] StormWaterAddress;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute("SamplingBasisIndicator", Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public enum SamplingBasisType
    {

        /// <remarks/>
        D,

        /// <remarks/>
        W,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("*")]
        Item,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute("PrecipitationForm", Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public enum PrecipitationFormType
    {

        /// <remarks/>
        R,

        /// <remarks/>
        S,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("*")]
        Item,
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SWIndustrialAnnualReport))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SWIndustrialAnnualReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        public System.DateTime IndustrialStormWaterAnnualReportReceivedDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SWIndustrialAnnualReport : SWIndustrialAnnualReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string FacilityInspectionSummaryText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string VisualAssessmentSummaryText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string NoFurtherReductionSummaryText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string CorrectiveActionSummaryText;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SWMS4ProgramReport))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SWMS4ProgramReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        public System.DateTime StormWaterMS4ReportReceivedDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SWMS4ProgramReport : SWMS4ProgramReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string MS4AnnualExpenditureDollars;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string MS4AnnualExpenditureYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string MS4BudgetDollars;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string MS4BudgetYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProjectedSourcesFundingCode", Order = 4)]
        public string[] ProjectedSourcesFundingCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public EstimatedMeasuredType MajorOutfallEstimatedMeasureIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MajorOutfallEstimatedMeasureIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string MajorOutfallNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public EstimatedMeasuredType MinorOutfallEstimatedMeasureIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MinorOutfallEstimatedMeasureIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string MinorOutfallNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 9)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Contact[] StormWaterContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 10)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Address[] StormWaterAddress;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class TreatmentChemicalsList
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TreatmentChemicalName", Order = 0)]
        public string[] TreatmentChemicalName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class AnalyticalMethods
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AnalyticalMethodData", Order = 0)]
        public AnalyticalMethodData[] AnalyticalMethodData;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class BiosolidsManagementPractices
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ManagementPracticeData", Order = 0)]
        public ManagementPracticeData[] ManagementPracticeData;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class ImpairedWaterPollutants
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ImpairedWaterPollutantCode", DataType = "nonNegativeInteger", Order = 0)]
        public string[] ImpairedWaterPollutantCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class EffluentTradePartner : EffluentTradePartnerKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string TradePartnerNPDESID;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string TradePartnerOtherID;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string TradePartnerType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public EffluentTradePartnerAddress EffluentTradePartnerAddress;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 4)]
        public System.DateTime TradePartnerStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TradePartnerStartDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string TradePartnerEndDate;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(EffluentTradePartner))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute("EffluentTradePartnerReportIdentifier", Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class EffluentTradePartnerKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string PermittedFeatureIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string LimitSetDesignator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string ParameterCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string MonitoringSiteDescriptionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 5)]
        public string LimitSeasonNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 6)]
        public System.DateTime LimitStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 7)]
        public System.DateTime LimitEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string LimitModificationEffectiveDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public string TradeID;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute("AcceptedReport", Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class AcceptedReportDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("An Service Provider (e.g., ICIS-NPDES) specific information or warning code that " +
            "uniquely identifies a type of error.")]
        public string InformationCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The type of information or warning that is being returned.")]
        public InformationTypeCodeDataType InformationTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("A human readable description on a information or warning.")]
        public string InformationDescription;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute("InformationTypeCode", Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public enum InformationTypeCodeDataType
    {

        /// <remarks/>
        Information,

        /// <remarks/>
        Warning,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute("ErrorReport", Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class ErrorReportDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("An Service Provider (e.g., ICIS-NPDES) specific error code that uniquely identifi" +
            "es a type of error.")]
        public string ErrorCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The type of error that is being returned.")]
        public ErrorTypeCodeDataType ErrorTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("A human readable description on an error.")]
        public string ErrorDescription;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute("ErrorTypeCode", Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public enum ErrorTypeCodeDataType
    {

        /// <remarks/>
        Error,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute("FileErrorReport", Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class FileErrorReportDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The type of error that is being returned.")]
        public ErrorTypeCodeDataType ErrorTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A human readable description on an error.")]
        public string ErrorDescription;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute("SubmissionTransactionTypeCode", Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public enum SubmissionTransactionTypeCodeDataType
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
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute("TransactionTypeTotals", Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class TransactionTypeTotalsDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The type of transaction that was sent in the submission.")]
        public SubmissionTransactionTypeCodeDataType SubmissionTransactionTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Unique number that identifies the total count of accepted records by transaction " +
            "type.")]
        public string TotalAcceptedTransactions;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Unique number that identifies the total count of rejected records by transaction " +
            "type.")]
        public string TotalRejectedTransactions;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute("SubmissionErrorKey", Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SubmissionErrorKeyDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies an Air Compliance Monitoring Strategy by including all the ap" +
            "propriate keys for it.")]
        public AirComplianceMonitoringStrategyKeyElements AirComplianceMonitoringStrategyIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies an Air DA Case File by including all the appropriate keys for" +
            " it.")]
        public CaseFileKeyElements AirDACaseFileIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies an Air DA compliance monitoring activity by including all the" +
            " appropriate keys for it.")]
        public ComplianceMonitoringKeyElements AirDAComplianceMonitoringIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies an Air DA enforcement action linkage by including all the app" +
            "ropriate keys for it. The type definition is found in the Air DA Enforcement Act" +
            "ion Linkage xsd file.")]
        public AirDAEnforcementActionLinkage AirDAEnforcementActionLinkageIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies an Air DA Enforcement Action Milestone by including all the a" +
            "ppropriate keys for it.")]
        public AirDAEnforcementActionMilestoneKeyElements AirDAEnforcementActionMilestoneIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies an Air DA Formal Enforcement Action by including all the appr" +
            "opriate keys for it.")]
        public AirDAEnforcementActionKeyElements AirDAFormalEnforcementActionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies an Air DA Informal Enforcement Action by including all the ap" +
            "propriate keys for it.")]
        public AirDAEnforcementActionKeyElements AirDAInformalEnforcementActionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies an Air Facility by including all the appropriate keys for it." +
            "")]
        public AirFacilityKeyElements AirFacilityReportIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies an Air Pollutants by including all the appropriate keys for i" +
            "t.")]
        public AirPollutantsKeyElements AirPollutantsIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies an Air program by including all the appropriate keys for it.")]
        public AirProgramsKeyElements AirProgramReportIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies an Air Title V Annual Compliance Certification compliance mon" +
            "itoring activity by including all the appropriate keys for it.")]
        public ComplianceMonitoringKeyElements AirTVACCIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a biosolids annual program report by including all the approp" +
            "riate keys for it.")]
        public BiosolidsAnnualProgramReportKeyElements BiosolidsAnnualProgramReportIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a biosolids program report by including all the appropriate k" +
            "eys for it.")]
        public BiosolidsProgramReportKeyElements BiosolidsProgramReportIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a CAFO annual program report by including all the appropriate" +
            " keys for it.")]
        public CAFOAnnualProgramReportKeyElements CAFOAnnualProgramReportIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a case file linkage by including all the appropriate keys for" +
            " it. The type definition is found in the Case File Linkage xsd file.")]
        public CaseFileLinkage CaseFileLinkageIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a compliance monitoring linkage by including all the appropri" +
            "ate keys for it. The type definition is found in the CMLinkage xsd file.")]
        public ComplianceMonitoringLinkage ComplianceMonitoringLinkageIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a compliance schedule by including all the appropriate keys f" +
            "or it.")]
        public ComplianceScheduleKeyElements ComplianceScheduleIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a compliance schedule event by including all the appropriate " +
            "keys for it.")]
        public ComplianceScheduleEventKeyElements ComplianceScheduleEventIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a Copy Master General Permit Limit Set by including all the a" +
            "ppropriate keys for it.")]
        public CopyMGPLimitSetIdentifier CopyMGPLimitSetIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a CSO Event by including all the appropriate keys for it.")]
        public CSOEventReportKeyElements CSOEventReportIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a DMR by including all the appropriate keys for it.")]
        public DischargeMonitoringReportKeyElements DischargeMonitoringReportIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a parameter within a specific DMR by including all the approp" +
            "riate keys for it. The type is defined in EAViolationLinkage xsd.")]
        public DischargeMonitoringReportParameterViolation DMRParameterIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a DMR Program Report Linkage by including all the appropriate" +
            " keys for it. The type definition is found in the DMRProgramReportLinkage xsd fi" +
            "le.")]
        public DMRProgramReportLinkage DMRProgramReportLinkageIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 23)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a DMR violation by including all the appropriate keys.")]
        public DMRViolationKeyElements DMRViolationIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 24)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies an Effluent Trade Partner by including all the appropriate ke" +
            "ys for it.")]
        public EffluentTradePartnerKeyElements EffluentTradePartnerReportIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 25)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies an Enforcement Action Milestone by including all the appropri" +
            "ate keys for it.")]
        public EnforcementActionMilestoneKeyElements EnforcementActionMilestoneReportIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 26)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies an Enforcement Action Violation Linkage by including all the " +
            "appropriate keys for it. The type is defined in EAViolationLinkage xsd.")]
        public EnforcementActionViolationLinkage EnforcementActionViolationLinkageIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 27)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a compliance monitoring inspection by including all the appro" +
            "priate keys for it.")]
        public ComplianceMonitoringKeyElements FederalComplianceMonitoringIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 28)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies an Enforcement Action Violation Linkage by including all the " +
            "appropriate keys for it. The type is defined in the FO ViolationLinkage xsd.")]
        public FinalOrderViolationLinkage FinalOrderViolationLinkageIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 29)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a Formal Enforcement Action by including all the appropriate " +
            "keys for it.")]
        public EnforcementActionKeyElements FormalEnforcementActionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 30)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a Historical Permit Schedule Event by including all the appro" +
            "priate keys for it.")]
        public HistoricalPermitScheduleKeyElements HistoricalPermitScheduleEventIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 31)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies an Informal Enforcement Action by including all the appropria" +
            "te keys for it.")]
        public EnforcementActionKeyElements InformalEnforcementActionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 32)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a limit segment by including all the appropriate keys for the" +
            " limit segment.")]
        public LimitKeyElements LimitSegmentIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 33)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a limit set by including all the appropriate keys for the lim" +
            "it set.")]
        public LimitSetKeyElements LimitSetIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 34)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a Local Limits Program Report by including all the appropriat" +
            "e keys for it.")]
        public LocalLimitsProgramReportKeyElements LocalLimitsProgramReportIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 35)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a narrative condition and its schedules by including all the " +
            "appropriate keys for the narrative condition.")]
        public PermitScheduleKeyElements NarrativeConditionScheduleIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 36)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a parameter limit by including all the appropriate keys for t" +
            "he parameter limit.")]
        public ParameterLimitKeyElements ParameterLimitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 37)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a permit by including the appropriate key for the it.")]
        public BasicPermitKeyElements PermitRecordIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 38)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a permit tracking event by including all the appropriate keys" +
            " for the permit tracking event.")]
        public PermitTrackingEventKeyElements PermitTrackingEventIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 39)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a permitted feature by including all the appropriate keys for" +
            " the permitted feature.")]
        public PermittedFeatureKeyElements PermittedFeatureRecordIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 40)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a Pretreatment Performance Summary by including all the appro" +
            "priate keys for it.")]
        public PretreatmentPerformanceSummaryReportKeyElements PretreatmentPerformanceSummaryIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 41)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a Schedule Event Violation by including all the appropriate k" +
            "eys for it.")]
        public ScheduleEventViolationKeyElements ScheduleEventViolationIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 42)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a Single Event Violation by including all the appropriate key" +
            "s for it.")]
        public SingleEventKeyElements SingleEventIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 43)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a state NPDES compliance monitoring activity by including all" +
            " the appropriate keys for it.")]
        public ComplianceMonitoringKeyElements StateNPDESComplianceMonitoringIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 44)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a SSO Annual Report by including all the appropriate keys for" +
            " it.")]
        public SSOAnnualReportKeyElements SSOAnnualReportIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 45)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a SSO Event Report by including all the appropriate keys for " +
            "it.")]
        public SSOEventReportKeyElements SSOEventReportIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 46)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a SSO Monthly Event Report by including all the appropriate k" +
            "eys for it.")]
        public SSOMonthlyEventReportKeyElements SSOMonthlyEventReportIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 47)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a Storm Water Event Report by including all the appropriate k" +
            "eys for it.")]
        public SWEventReportKeyElements SWEventReportIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 48)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a Storm Water Industrial Annual Report by including all the a" +
            "ppropriate keys for it.")]
        public SWIndustrialAnnualReportKeyElements SWIndustrialAnnualReportIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 49)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a Storm Water MS4 Program Report by including all the appropr" +
            "iate keys for it.")]
        public SWMS4ProgramReportKeyElements SWMS4ProgramReportIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 50)]
        [System.ComponentModel.DescriptionAttribute("The type of transaction that was sent in the submission.")]
        public SubmissionTransactionTypeCodeDataType SubmissionTransactionTypeCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute("SubmissionError", Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SubmissionErrorDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Provides the keys that uniquely identify the part of a submission that caused an " +
            "error.")]
        public SubmissionErrorKeyDataType SubmissionErrorKey;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ErrorReport", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Describes an error that was encountered.")]
        public ErrorReportDataType[] ErrorReport;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute("SubmissionErrors", Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SubmissionErrorsDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SubmissionError", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("One or more errors that occurred while processing a part of the submission.")]
        public SubmissionErrorDataType[] SubmissionError;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute("SubmissionAcceptedKey", Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SubmissionAcceptedKeyDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies an Air Compliance Monitoring Strategy by including all the ap" +
            "propriate keys for it.")]
        public AirComplianceMonitoringStrategyKeyElements AirComplianceMonitoringStrategyIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies an Air DA Case File by including all the appropriate keys for" +
            " it.")]
        public CaseFileKeyElements AirDACaseFileIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies an Air DA compliance monitoring activity by including all the" +
            " appropriate keys for it.")]
        public ComplianceMonitoringKeyElements AirDAComplianceMonitoringIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies an Air DA enforcement action linkage by including all the app" +
            "ropriate keys for it. The type definition is found in the Air DA Enforcement Act" +
            "ion Linkage xsd file.")]
        public AirDAEnforcementActionLinkage AirDAEnforcementActionLinkageIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies an Air DA Enforcement Action Milestone by including all the a" +
            "ppropriate keys for it.")]
        public AirDAEnforcementActionMilestoneKeyElements AirDAEnforcementActionMilestoneIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies an Air DA Formal Enforcement Action by including all the appr" +
            "opriate keys for it.")]
        public AirDAEnforcementActionKeyElements AirDAFormalEnforcementActionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies an Air DA Informal Enforcement Action by including all the ap" +
            "propriate keys for it.")]
        public AirDAEnforcementActionKeyElements AirDAInformalEnforcementActionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies an Air Facility by including all the appropriate keys for it." +
            "")]
        public AirFacilityKeyElements AirFacilityReportIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies an Air Pollutants by including all the appropriate keys for i" +
            "t.")]
        public AirPollutantsKeyElements AirPollutantsIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies an Air program by including all the appropriate keys for it.")]
        public AirProgramsKeyElements AirProgramReportIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies an Air Title V Annual Compliance Certification compliance mon" +
            "itoring activity by including all the appropriate keys for it.")]
        public ComplianceMonitoringKeyElements AirTVACCIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a biosolids annual program report by including all the approp" +
            "riate keys for it.")]
        public BiosolidsAnnualProgramReportKeyElements BiosolidsAnnualProgramReportIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a biosolids program report by including all the appropriate k" +
            "eys for it.")]
        public BiosolidsProgramReportKeyElements BiosolidsProgramReportIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a CAFO annual program report by including all the appropriate" +
            " keys for it.")]
        public CAFOAnnualProgramReportKeyElements CAFOAnnualProgramReportIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a case file linkage by including all the appropriate keys for" +
            " it. The type definition is found in the Case File Linkage xsd file.")]
        public CaseFileLinkage CaseFileLinkageIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a compliance monitoring linkage by including all the appropri" +
            "ate keys for it. The type definition is found in the CMLinkage xsd file.")]
        public ComplianceMonitoringLinkage ComplianceMonitoringLinkageIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a compliance schedule by including all the appropriate keys f" +
            "or it.")]
        public ComplianceScheduleKeyElements ComplianceScheduleIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a compliance schedule event by including all the appropriate " +
            "keys for it.")]
        public ComplianceScheduleEventKeyElements ComplianceScheduleEventIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a Copy Master General Permit Limit Set by including all the a" +
            "ppropriate keys for it.")]
        public CopyMGPLimitSetIdentifier CopyMGPLimitSetIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a CSO Event by including all the appropriate keys for it.")]
        public CSOEventReportKeyElements CSOEventReportIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a DMR by including all the appropriate keys for it.")]
        public DischargeMonitoringReportKeyElements DischargeMonitoringReportIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a parameter within a specific DMR by including all the approp" +
            "riate keys for it. The type is defined in EAViolationLinkage xsd.")]
        public DischargeMonitoringReportParameterViolation DMRParameterIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a DMR Program Report Linkage by including all the appropriate" +
            " keys for it. The type definition is found in the DMRProgramReportLinkage xsd fi" +
            "le.")]
        public DMRProgramReportLinkage DMRProgramReportLinkageIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 23)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a DMR violation by including all the appropriate keys.")]
        public DMRViolationKeyElements DMRViolationIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 24)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies an Effluent Trade Partner by including all the appropriate ke" +
            "ys for it.")]
        public EffluentTradePartnerKeyElements EffluentTradePartnerReportIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 25)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies an Enforcement Action Milestone by including all the appropri" +
            "ate keys for it.")]
        public EnforcementActionMilestoneKeyElements EnforcementActionMilestoneReportIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 26)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies an Enforcement Action Violation Linkage by including all the " +
            "appropriate keys for it. The type is defined in EAViolationLinkage xsd.")]
        public EnforcementActionViolationLinkage EnforcementActionViolationLinkageIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 27)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a compliance monitoring inspection by including all the appro" +
            "priate keys for it.")]
        public ComplianceMonitoringKeyElements FederalComplianceMonitoringIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 28)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies an Enforcement Action Violation Linkage by including all the " +
            "appropriate keys for it. The type is defined in the FO ViolationLinkage xsd.")]
        public FinalOrderViolationLinkage FinalOrderViolationLinkageIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 29)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a Formal Enforcement Action by including all the appropriate " +
            "keys for it.")]
        public EnforcementActionKeyElements FormalEnforcementActionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 30)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a Historical Permit Schedule Event by including all the appro" +
            "priate keys for it.")]
        public HistoricalPermitScheduleKeyElements HistoricalPermitScheduleEventIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 31)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies an Informal Enforcement Action by including all the appropria" +
            "te keys for it.")]
        public EnforcementActionKeyElements InformalEnforcementActionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 32)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a limit segment by including all the appropriate keys for the" +
            " limit segment.")]
        public LimitKeyElements LimitSegmentIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 33)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a limit set by including all the appropriate keys for the lim" +
            "it set.")]
        public LimitSetKeyElements LimitSetIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 34)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a Local Limits Program Report by including all the appropriat" +
            "e keys for it.")]
        public LocalLimitsProgramReportKeyElements LocalLimitsProgramReportIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 35)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a narrative condition and its schedules by including all the " +
            "appropriate keys for the narrative condition.")]
        public PermitScheduleKeyElements NarrativeConditionScheduleIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 36)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a parameter limit by including all the appropriate keys for t" +
            "he parameter limit.")]
        public ParameterLimitKeyElements ParameterLimitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 37)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a permit by including the appropriate key for the it.")]
        public BasicPermitKeyElements PermitRecordIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 38)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a permit tracking event by including all the appropriate keys" +
            " for the permit tracking event.")]
        public PermitTrackingEventKeyElements PermitTrackingEventIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 39)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a permitted feature by including all the appropriate keys for" +
            " the permitted feature.")]
        public PermittedFeatureKeyElements PermittedFeatureRecordIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 40)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a Pretreatment Performance Summary by including all the appro" +
            "priate keys for it.")]
        public PretreatmentPerformanceSummaryReportKeyElements PretreatmentPerformanceSummaryIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 41)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a Schedule Event Violation by including all the appropriate k" +
            "eys for it.")]
        public ScheduleEventViolationKeyElements ScheduleEventViolationIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 42)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a Single Event Violation by including all the appropriate key" +
            "s for it.")]
        public SingleEventKeyElements SingleEventIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 43)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a state NPDES compliance monitoring activity by including all" +
            " the appropriate keys for it.")]
        public ComplianceMonitoringKeyElements StateNPDESComplianceMonitoringIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 44)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a SSO Annual Report by including all the appropriate keys for" +
            " it.")]
        public SSOAnnualReportKeyElements SSOAnnualReportIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 45)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a SSO Event Report by including all the appropriate keys for " +
            "it.")]
        public SSOEventReportKeyElements SSOEventReportIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 46)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a SSO Monthly Event Report by including all the appropriate k" +
            "eys for it.")]
        public SSOMonthlyEventReportKeyElements SSOMonthlyEventReportIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 47)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a Storm Water Event Report by including all the appropriate k" +
            "eys for it.")]
        public SWEventReportKeyElements SWEventReportIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 48)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a Storm Water Industrial Annual Report by including all the a" +
            "ppropriate keys for it.")]
        public SWIndustrialAnnualReportKeyElements SWIndustrialAnnualReportIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 49)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a Storm Water MS4 Program Report by including all the appropr" +
            "iate keys for it.")]
        public SWMS4ProgramReportKeyElements SWMS4ProgramReportIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 50)]
        [System.ComponentModel.DescriptionAttribute("The type of transaction that was sent in the submission.")]
        public SubmissionTransactionTypeCodeDataType SubmissionTransactionTypeCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute("SubmissionAccepted", Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SubmissionAcceptedDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Provides the keys that uniquely identify the part of a submission that was accept" +
            "ed.")]
        public SubmissionAcceptedKeyDataType SubmissionAcceptedKey;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AcceptedReport", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Describes an error that was encountered.")]
        public AcceptedReportDataType[] AcceptedReport;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute("SubmissionsAccepted", Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SubmissionsAcceptedDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SubmissionAccepted", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("One or more records that were accepted while processing a part of the submission." +
            "")]
        public SubmissionAcceptedDataType[] SubmissionAccepted;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute("SubmissionSummary", Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SubmissionSummaryDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TransactionTypeTotals", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Counts of the accepted and rejected transactions for this transaction type.")]
        public TransactionTypeTotalsDataType[] TransactionTypeTotals;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The total amount of transactions that were accepted and rejected by ICIS for a gi" +
            "ven user within the same batch submission.")]
        public string TotalTransactions;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Percent of TotalTransactions that were accepted. The reports show 2 decimal place" +
            "s max.")]
        public decimal PercentTransactionsAccepted;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Unique number that identifies the total count of records for an entire submission" +
            ".")]
        public string TotalSubmissions;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute("FileSubmissionErrors", Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class FileSubmissionErrorsDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 0)]
        [System.Xml.Serialization.XmlArrayItemAttribute("FileErrorReport", typeof(FileErrorReportDataType), IsNullable = false)]
        public FileErrorReportDataType[][] FileSubmissionError;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute("FileSubmissionError", Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class FileSubmissionErrorDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FileErrorReport", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Describes an error that was encountered.")]
        public FileErrorReportDataType[] FileErrorReport;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute("SubmissionResponse", Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SubmissionResponseDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("An Exchange Network transaction ID issued by a Exchange Network Node.")]
        public string TransactionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The date something was submitted.")]
        public System.DateTime SubmissionDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The date something was created.")]
        public System.DateTime ProcessedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SubmittingParty", Order = 3)]
        public SubmittingPartyDataType[] SubmittingParty;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 4)]
        [System.Xml.Serialization.XmlArrayItemAttribute("FileSubmissionError", typeof(FileErrorReportDataType[]), IsNullable = false)]
        [System.Xml.Serialization.XmlArrayItemAttribute("FileErrorReport", typeof(FileErrorReportDataType), IsNullable = false, NestingLevel = 1)]
        public FileErrorReportDataType[][][] FileSubmissionErrors;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute("SubmittingParty", Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SubmittingPartyDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Counts of the accepted and rejected transactions for this transaction type.")]
        public string UserID;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SubmissionType", Order = 1)]
        public SubmissionTypeDataType[] SubmissionType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Unique number that identifies the total transaction of records for an entire batc" +
            "h.")]
        public string BatchTotalTransactions;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Unique number that identifies the total count of records for an entire submission" +
            ".")]
        public string BatchTotalSubmissions;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Unique number that identifies the total percent of transactions that were accepte" +
            "d.")]
        public decimal BatchTotalPercentTransactionsAccepted;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool BatchTotalPercentTransactionsAcceptedSpecified;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute("SubmissionType", Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SubmissionTypeDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The name of the submission type.")]
        public string SubmissionTypeName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SubmissionErrors", typeof(SubmissionErrorsDataType), Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute("SubmissionSummary", typeof(SubmissionSummaryDataType), Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute("SubmissionsAccepted", typeof(SubmissionsAcceptedDataType), Order = 1)]
        public object[] Items;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class Document
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public HeaderData Header;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Payload", Order = 1)]
        public PayloadData[] Payload;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class HeaderData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class PayloadData
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
        [System.Xml.Serialization.XmlElementAttribute("BasicPermitData", typeof(BasicPermitData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("BiosolidsAnnualProgramReportData", typeof(BiosolidsAnnualProgramReportData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("BiosolidsPermitData", typeof(BiosolidsPermitData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("BiosolidsProgramReportData", typeof(BiosolidsProgramReportData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("CAFOAnnualReportData", typeof(CAFOAnnualReportData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("CAFOPermitData", typeof(CAFOPermitData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("CSOEventReportData", typeof(CSOEventReportData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("CSOPermitData", typeof(CSOPermitData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("CaseFileLinkageData", typeof(CaseFileLinkageData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("ComplianceMonitoringData", typeof(ComplianceMonitoringData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("ComplianceMonitoringLinkageData", typeof(ComplianceMonitoringLinkageData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("ComplianceScheduleData", typeof(ComplianceScheduleData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("CopyMGPLimitSetData", typeof(CopyMGPLimitSetData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("DMRProgramReportLinkageData", typeof(DMRProgramReportLinkageData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("DMRViolationData", typeof(DMRViolationData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("DischargeMonitoringReportData", typeof(DischargeMonitoringReportData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("EffluentTradePartnerData", typeof(EffluentTradePartnerData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("EnforcementActionMilestoneData", typeof(EnforcementActionMilestoneData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("EnforcementActionViolationLinkageData", typeof(EnforcementActionViolationLinkageData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("FederalComplianceMonitoringData", typeof(FederalComplianceMonitoringData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("FinalOrderViolationLinkageData", typeof(FinalOrderViolationLinkageData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("FormalEnforcementActionData", typeof(FormalEnforcementActionData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("GeneralPermitData", typeof(GeneralPermitData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("HistoricalPermitScheduleEventsData", typeof(HistoricalPermitScheduleEventsData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("InformalEnforcementActionData", typeof(InformalEnforcementActionData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("LimitSetData", typeof(LimitSetData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("LimitsData", typeof(LimitsData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("LocalLimitsProgramReportData", typeof(LocalLimitsProgramReportData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("MasterGeneralPermitData", typeof(MasterGeneralPermitData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("NarrativeConditionScheduleData", typeof(NarrativeConditionScheduleData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("POTWPermitData", typeof(POTWPermitData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("ParameterLimitsData", typeof(ParameterLimitsData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("PermitReissuanceData", typeof(PermitReissuanceData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("PermitTerminationData", typeof(PermitTerminationData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("PermitTrackingEventData", typeof(PermitTrackingEventData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("PermittedFeatureData", typeof(PermittedFeatureData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("PretreatmentPerformanceSummaryData", typeof(PretreatmentPerformanceSummaryData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("PretreatmentPermitData", typeof(PretreatmentPermitData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("SSOAnnualReportData", typeof(SSOAnnualReportData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("SSOEventReportData", typeof(SSOEventReportData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("SSOMonthlyEventReportData", typeof(SSOMonthlyEventReportData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("SWConstructionPermitData", typeof(SWConstructionPermitData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("SWEventReportData", typeof(SWEventReportData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("SWIndustrialAnnualReportData", typeof(SWIndustrialAnnualReportData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("SWIndustrialPermitData", typeof(SWIndustrialPermitData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("SWMS4LargePermitData", typeof(SWMS4LargePermitData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("SWMS4ProgramReportData", typeof(SWMS4ProgramReportData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("SWMS4SmallPermitData", typeof(SWMS4SmallPermitData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("ScheduleEventViolationData", typeof(ScheduleEventViolationData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("SingleEventViolationData", typeof(SingleEventViolationData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("UnpermittedFacilityData", typeof(UnpermittedFacilityData), Order = 0)]
        public object[] Items;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public OperationType Operation;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class AirComplianceMonitoringStrategyData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public AirComplianceMonitoringStrategy AirComplianceMonitoringStrategy;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class AirDACaseFileData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public AirDACaseFile AirDACaseFile;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class AirDAComplianceMonitoringData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public AirDAComplianceMonitoring AirDAComplianceMonitoring;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class AirDAEnforcementActionLinkageData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public AirDAEnforcementActionLinkage AirDAEnforcementActionLinkage;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class AirDAEnforcementActionMilestoneData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public AirDAEnforcementActionMilestone AirDAEnforcementActionMilestone;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class AirDAFormalEnforcementActionData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public AirDAFormalEnforcementAction AirDAFormalEnforcementAction;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class AirDAInformalEnforcementActionData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public AirDAInformalEnforcementAction AirDAInformalEnforcementAction;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class AirFacilityData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public AirFacility AirFacility;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class AirPollutantsData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public AirPollutants AirPollutants;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class AirProgramsData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public AirPrograms AirPrograms;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class AirTVACCData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public AirTVACC AirTVACC;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class BasicPermitData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public BasicPermit BasicPermit;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class BiosolidsAnnualProgramReportData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public BiosolidsAnnualProgramReport BiosolidsAnnualProgramReport;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class BiosolidsPermitData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public BiosolidsPermit BiosolidsPermit;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class BiosolidsProgramReportData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public BiosolidsProgramReport BiosolidsProgramReport;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class CAFOAnnualReportData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public CAFOAnnualReport CAFOAnnualReport;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class CAFOPermitData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public CAFOPermit CAFOPermit;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class CSOEventReportData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public CSOEventReport CSOEventReport;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class CSOPermitData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public CSOPermit CSOPermit;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class CaseFileLinkageData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public CaseFileLinkage CaseFileLinkage;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class ComplianceMonitoringData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public ComplianceMonitoring ComplianceMonitoring;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class ComplianceMonitoringLinkageData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public ComplianceMonitoringLinkage ComplianceMonitoringLinkage;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class ComplianceScheduleData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public ComplianceSchedule ComplianceSchedule;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class CopyMGPLimitSetData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public CopyMGPLimitSet CopyMGPLimitSet;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class DMRProgramReportLinkageData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public DMRProgramReportLinkage DMRProgramReportLinkage;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class DMRViolationData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public DMRViolation DMRViolation;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class DischargeMonitoringReportData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public DischargeMonitoringReport DischargeMonitoringReport;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class EffluentTradePartnerData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public EffluentTradePartner EffluentTradePartner;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class EnforcementActionMilestoneData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public Milestone Milestone;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class EnforcementActionViolationLinkageData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public EnforcementActionViolationLinkage EnforcementActionViolationLinkage;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class FederalComplianceMonitoringData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public FederalComplianceMonitoring FederalComplianceMonitoring;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class FinalOrderViolationLinkageData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public FinalOrderViolationLinkage FinalOrderViolationLinkage;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class FormalEnforcementActionData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public FormalEnforcementAction FormalEnforcementAction;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class GeneralPermitData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public GeneralPermit GeneralPermit;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class HistoricalPermitScheduleEventsData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public HistoricalPermitScheduleEvents HistoricalPermitScheduleEvents;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class InformalEnforcementActionData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public InformalEnforcementAction InformalEnforcementAction;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class LimitSetData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public LimitSet LimitSet;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class LimitsData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public Limits Limits;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class LocalLimitsProgramReportData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public LocalLimitsProgramReport LocalLimitsProgramReport;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class MasterGeneralPermitData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public MasterGeneralPermit MasterGeneralPermit;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class NarrativeConditionScheduleData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public NarrativeCondition NarrativeCondition;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class POTWPermitData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public POTWPermit POTWPermit;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class ParameterLimitsData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public ParameterLimits ParameterLimits;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class PermitReissuanceData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public PermitReissuance PermitReissuance;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class PermitTerminationData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public PermitTermination PermitTermination;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class PermitTrackingEventData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public PermitTrackingEvent PermitTrackingEvent;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class PermittedFeatureData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public PermittedFeature PermittedFeature;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class PretreatmentPerformanceSummaryData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public PretreatmentPerformanceSummary PretreatmentPerformanceSummary;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class PretreatmentPermitData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public PretreatmentPermit PretreatmentPermit;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class SSOAnnualReportData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public SSOAnnualReport SSOAnnualReport;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class SSOEventReportData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public SSOEventReport SSOEventReport;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class SSOMonthlyEventReportData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public SSOMonthlyEventReport SSOMonthlyEventReport;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class SWConstructionPermitData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public SWConstructionPermit SWConstructionPermit;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class SWEventReportData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public SWEventReport SWEventReport;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class SWIndustrialAnnualReportData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public SWIndustrialAnnualReport SWIndustrialAnnualReport;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class SWIndustrialPermitData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public SWIndustrialPermit SWIndustrialPermit;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class SWMS4LargePermitData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public SWMS4LargePermit SWMS4LargePermit;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class SWMS4ProgramReportData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public SWMS4ProgramReport SWMS4ProgramReport;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class SWMS4SmallPermitData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public SWMS4SmallPermit SWMS4SmallPermit;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class ScheduleEventViolationData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public ScheduleEventViolation ScheduleEventViolation;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class SingleEventViolationData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public SingleEventViolation SingleEventViolation;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class UnpermittedFacilityData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public UnpermittedFacility UnpermittedFacility;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public enum OperationType
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
        BiosolidsAnnualProgramReportSubmission,

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
        SWIndustrialAnnualReportSubmission,

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
