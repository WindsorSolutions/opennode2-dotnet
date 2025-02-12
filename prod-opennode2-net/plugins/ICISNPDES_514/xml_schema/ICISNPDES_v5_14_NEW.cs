namespace Windsor.Node2008.WNOSPlugin.ICISNPDES_514
{

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
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class CAFOContact
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Contact", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
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
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate StartDateOfContactAssociation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate EndDateOfContactAssociation;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
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
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate StartDateOfContactAssociation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate EndDateOfContactAssociation;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class FacilityContact
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Contact", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
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
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class PermitContact
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Contact", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
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
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
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
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
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
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public Contact[] Contact;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class ThirdPartyContact
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Contact", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public Contact[] Contact;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class GeographicCoordinates
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("9", "7")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal LatitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("10", "6")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal LongitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
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
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 SourceMapScaleNumber;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
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
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(2)]
        public string LocationStateCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(14)]
        public string LocationZipCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string LocationCountryCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string OrganizationDUNSNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(12)]
        public string StateFacilityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
        public string StateRegionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32OrNullIfParseError FacilityCongressionalDistrictNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FacilityClassification", Order = 12)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] FacilityClassification;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PolicyCode", Order = 13)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] PolicyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OriginatingProgramsCode", Order = 14)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(9)]
        public string[] OriginatingProgramsCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string FacilityTypeOfOwnershipCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(12)]
        public string FederalFacilityIdentificationNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
        public string FederalAgencyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(9)]
        public string TribalLandCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string ConstructionProjectName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("9", "7")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal ConstructionProjectLatitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("10", "6")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal ConstructionProjectLongitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SICCodeDetails", Order = 22)]
        public SICCodeDetails[] SICCodeDetails;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NAICSCodeDetails", Order = 23)]
        public NAICSCodeDetails[] NAICSCodeDetails;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 24)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string SectionTownshipRange;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 25)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string FacilityComments;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 26)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string FacilityUserDefinedField1;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 27)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string FacilityUserDefinedField2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 28)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string FacilityUserDefinedField3;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 29)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string FacilityUserDefinedField4;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 30)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
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
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(60)]
        LocalityName,

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(12)]
        LocationAddressCityCode,

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(5)]
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
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string AffiliationTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(80)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public string OrganizationFormalName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string OrganizationDUNSNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public string MailingAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string SupplementalAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public string MailingAddressCityName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(2)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public string MailingAddressStateCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(14)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
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
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate StartDateOfAddressAssociation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate EndDateOfAddressAssociation;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class CAFOAddress
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Address", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
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
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class FacilityAddress
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Address", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
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
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
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
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
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
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
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
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public Address[] Address;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class ThirdPartyAddress
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Address", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public Address[] Address;
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
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(6)]
        public nameType name;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
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
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
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
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(UnpermittedFacility))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SWMS4Permit))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SWConstructionPermit))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PretreatmentPermit))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(POTWTreatmentTechnologyPermit))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(POTWPermit))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PermitTermination))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PermitReissuance))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(MasterGeneralPermit))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(GeneralPermit))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LTCPPermit))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SWIndustrialPermit))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CAFOPermit))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(BiosolidsPermit))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(BasicPermit))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
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
        [System.Xml.Serialization.XmlElementAttribute("LocalityName", typeof(string), Order = 3)]
        [System.Xml.Serialization.XmlElementAttribute("LocationAddressCityCode", typeof(string), Order = 3)]
        [System.Xml.Serialization.XmlElementAttribute("LocationAddressCountyCode", typeof(string), Order = 3)]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        [Windsor.Commons.XsdOrm2.DbIgnore()]
        public string[] Items;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName", Order = 4)]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [Windsor.Commons.XsdOrm2.DbIgnore()]
        public ItemsChoiceType1[] ItemsElementName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(2)]
        public string LocationStateCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(14)]
        public string LocationZipCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string LocationCountryCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string OrganizationDUNSNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(12)]
        public string StateFacilityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
        public string StateRegionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32OrNullIfParseError FacilityCongressionalDistrictNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FacilityClassification", Order = 12)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] FacilityClassification;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PolicyCode", Order = 13)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] PolicyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OriginatingProgramsCode", Order = 14)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(9)]
        public string[] OriginatingProgramsCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string FacilityTypeOfOwnershipCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(12)]
        public string FederalFacilityIdentificationNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
        public string FederalAgencyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(9)]
        public string TribalLandCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string ConstructionProjectName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("9", "7")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal ConstructionProjectLatitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("10", "6")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal ConstructionProjectLongitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SICCodeDetails", Order = 22)]
        public SICCodeDetails[] SICCodeDetails;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NAICSCodeDetails", Order = 23)]
        public NAICSCodeDetails[] NAICSCodeDetails;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 24)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string SectionTownshipRange;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 25)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string FacilityComments;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 26)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string FacilityUserDefinedField1;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 27)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string FacilityUserDefinedField2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 28)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string FacilityUserDefinedField3;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 29)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string FacilityUserDefinedField4;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 30)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
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
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] PermitComponentTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 35)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string PermitCommentsText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IncludeInSchema = false)]
    public enum ItemsChoiceType1
    {

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(60)]
        LocalityName,

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(12)]
        LocationAddressCityCode,

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(5)]
        LocationAddressCountyCode,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SWMS4Permit : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string MS4PermitPhaseCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(500)]
        public string MS4PermitPhaseText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MS4RegulatedEntity", Order = 2)]
        public MS4RegulatedEntity[] MS4RegulatedEntity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MS4RegulatedEntityArea", Order = 3)]
        public MS4RegulatedEntityArea[] MS4RegulatedEntityArea;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MS4PublicEducationRequirements", Order = 4)]
        public MS4PublicEducationRequirements[] MS4PublicEducationRequirements;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MS4PublicInvolvementRequirements", Order = 5)]
        public MS4PublicInvolvementRequirements[] MS4PublicInvolvementRequirements;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MS4IllicitDetectionRequirements", Order = 6)]
        public MS4IllicitDetectionRequirements[] MS4IllicitDetectionRequirements;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MS4ConstructionStormwaterRequirements", Order = 7)]
        public MS4ConstructionStormwaterRequirements[] MS4ConstructionStormwaterRequirements;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MS4PostConstructionStormwaterRequirements", Order = 8)]
        public MS4PostConstructionStormwaterRequirements[] MS4PostConstructionStormwaterRequirements;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MS4PollutionPreventionRequirements", Order = 9)]
        public MS4PollutionPreventionRequirements[] MS4PollutionPreventionRequirements;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MS4IndustrialStormwaterRequirements", Order = 10)]
        public MS4IndustrialStormwaterRequirements[] MS4IndustrialStormwaterRequirements;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MS4OtherApplicableRequirements", Order = 11)]
        public MS4OtherApplicableRequirements[] MS4OtherApplicableRequirements;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class MS4RegulatedEntity
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(40)]
        public string MS4RegulatedEntityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(200)]
        public string MS4RegulatedEntityName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public MS4RegulatedEntityOwnershipLevel MS4RegulatedEntityOwnershipLevel;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public MS4RegulatedEntityCategory MS4RegulatedEntityCategory;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class MS4RegulatedEntityOwnershipLevel
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string MS4RegulatedEntityOwnershipLevelCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(200)]
        public string MS4RegulatedEntityOwnershipLevelOtherText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class MS4RegulatedEntityCategory
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string MS4RegulatedEntityCategoryCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(200)]
        public string MS4RegulatedEntityCategoryCodeOtherText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class MS4RegulatedEntityArea
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 MS4RegulatedEntityAreaNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(40)]
        public string MS4RegulatedEntityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string MS4RegulatedEntityAreaStatusCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string MS4RegulatedEntityAreaText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MS4RegulatedEntityAreaCoordinates", Order = 4)]
        public MS4RegulatedEntityAreaCoordinates[] MS4RegulatedEntityAreaCoordinates;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class MS4RegulatedEntityAreaCoordinates
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(10)]
        public string LatitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(11)]
        public string LongitudeMeasure;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class MS4PublicEducationRequirements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(40)]
        public string MS4ActivityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MS4RegulatedEntityIdentifier", Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(40)]
        public string[] MS4RegulatedEntityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public MS4PublicEducationDelivery MS4PublicEducationDelivery;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public MS4PublicEducationSubject MS4PublicEducationSubject;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public MS4PublicEducationAudience MS4PublicEducationAudience;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string MS4PublicEducationRequirementsText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string MS4PublicEducationScheduleText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class MS4PublicEducationDelivery
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string MS4PublicEducationDeliveryOption;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(500)]
        public string MS4PublicEducationDeliveryOptionOtherText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class MS4PublicEducationSubject
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string MS4PublicEducationSubjectOption;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(500)]
        public string MS4PublicEducationSubjectOptionOtherText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class MS4PublicEducationAudience
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string MS4PublicEducationAudienceOption;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(500)]
        public string MS4PublicEducationAudienceOptionOtherText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class MS4PublicInvolvementRequirements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(40)]
        public string MS4ActivityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MS4RegulatedEntityIdentifier", Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(40)]
        public string[] MS4RegulatedEntityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public MS4PublicInvolvementDelivery MS4PublicInvolvementDelivery;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public MS4PublicInvolvementSubject MS4PublicInvolvementSubject;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public MS4PublicInvolvementParticipant MS4PublicInvolvementParticipant;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string MS4PublicInvolvementRequirementsText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string MS4PublicInvolvementScheduleText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class MS4PublicInvolvementDelivery
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string MS4PublicInvolvementDeliveryOption;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(500)]
        public string MS4PublicInvolvementDeliveryOptionOtherText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class MS4PublicInvolvementSubject
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string MS4PublicInvolvementSubjectOption;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(500)]
        public string MS4PublicInvolvementSubjectOptionOtherText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class MS4PublicInvolvementParticipant
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string MS4PublicInvolvementParticipantOption;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(500)]
        public string MS4PublicInvolvementParticipantOptionOtherText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class MS4IllicitDetectionRequirements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MS4IllicitDetectionRegulatedEntityInformation", Order = 0)]
        public MS4IllicitDetectionRegulatedEntityInformation[] MS4IllicitDetectionRegulatedEntityInformation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MS4IllicitDetectionProcedures", Order = 1)]
        public MS4IllicitDetectionProcedures[] MS4IllicitDetectionProcedures;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class MS4IllicitDetectionRegulatedEntityInformation
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(40)]
        public string MS4ActivityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(40)]
        public string MS4RegulatedEntityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate MS4PermitIllicitDetectionOutfallMappingDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string MS4IllicitDetectionOutfallMappingStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 MS4PermitIllicitDetectionOutfallTotalNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 MS4PermitIllicitDetectionOutfallMappedNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string MS4IllicitDetectionProhibitionOrdinanceStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(500)]
        public string MS4IllicitDetectionProhibitionOrdinanceStatusText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class MS4IllicitDetectionProcedures
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(40)]
        public string MS4ActivityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MS4RegulatedEntityIdentifier", Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(40)]
        public string[] MS4RegulatedEntityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string MS4IllicitDetectionProcedureType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string MS4IllicitDetectionProcedureText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string MS4IllicitDetectionProcedureScheduleText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class MS4ConstructionStormwaterRequirements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MS4ConstructionStormwaterRegulatedEntityInformation", Order = 0)]
        public MS4ConstructionStormwaterRegulatedEntityInformation[] MS4ConstructionStormwaterRegulatedEntityInformation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MS4ConstructionStormwaterProcedures", Order = 1)]
        public MS4ConstructionStormwaterProcedures[] MS4ConstructionStormwaterProcedures;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class MS4ConstructionStormwaterRegulatedEntityInformation
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(40)]
        public string MS4ActivityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(40)]
        public string MS4RegulatedEntityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string MS4ConstructionStormwaterErosionOrdinanceStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(500)]
        public string MS4ConstructionStormwaterErosionOrdinanceStatusText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string MS4ConstructionStormwaterErosionPlanReviewStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(500)]
        public string MS4ConstructionStormwaterErosionPlanReviewStatusText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string MS4ConstructionStormwaterSiteInspectionStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(500)]
        public string MS4ConstructionStormwaterSiteInspectionStatusText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class MS4ConstructionStormwaterProcedures
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(40)]
        public string MS4ActivityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MS4RegulatedEntityIdentifier", Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(40)]
        public string[] MS4RegulatedEntityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string MS4ConstructionStormwaterProcedureType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string MS4ConstructionStormwaterProcedureText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string MS4ConstructionStormwaterProcedureScheduleText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class MS4PostConstructionStormwaterRequirements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MS4PostConstructionStormwaterRegulatedEntityInformation", Order = 0)]
        public MS4PostConstructionStormwaterRegulatedEntityInformation[] MS4PostConstructionStormwaterRegulatedEntityInformation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MS4PostConstructionStormwaterProcedures", Order = 1)]
        public MS4PostConstructionStormwaterProcedures[] MS4PostConstructionStormwaterProcedures;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class MS4PostConstructionStormwaterRegulatedEntityInformation
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(40)]
        public string MS4ActivityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(40)]
        public string MS4RegulatedEntityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string MS4PostConstructionStormwaterRunoffOrdinanceStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(500)]
        public string MS4PostConstructionStormwaterRunoffOrdinanceStatusText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string MS4PostConstructionStormwaterRunoffProgramStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(500)]
        public string MS4PostConstructionStormwaterRunoffProgramStatusText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string MS4PostConstructionStormwaterRunoffBMPStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(500)]
        public string MS4PostConstructionStormwaterRunoffBMPStatusText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class MS4PostConstructionStormwaterProcedures
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(40)]
        public string MS4ActivityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MS4RegulatedEntityIdentifier", Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(40)]
        public string[] MS4RegulatedEntityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string MS4PostConstructionStormwaterProcedureType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string MS4PostConstructionStormwaterProcedureText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string MS4PostConstructionStormwaterProcedureScheduleText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class MS4PollutionPreventionRequirements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(40)]
        public string MS4ActivityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MS4RegulatedEntityIdentifier", Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(40)]
        public string[] MS4RegulatedEntityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string MS4PollutionPreventionRequirementsText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string MS4PollutionPreventionScheduleText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class MS4IndustrialStormwaterRequirements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MS4IndustrialStormwaterRegulatedEntityInformation", Order = 0)]
        public MS4IndustrialStormwaterRegulatedEntityInformation[] MS4IndustrialStormwaterRegulatedEntityInformation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MS4IndustrialStormwaterProcedures", Order = 1)]
        public MS4IndustrialStormwaterProcedures[] MS4IndustrialStormwaterProcedures;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class MS4IndustrialStormwaterRegulatedEntityInformation
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(40)]
        public string MS4ActivityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(40)]
        public string MS4RegulatedEntityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string MS4IndustrialStormwaterOrdinanceStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(500)]
        public string MS4IndustrialStormwaterOrdinanceStatusText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string MS4IndustrialStormwaterIndustrialInventoryStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(500)]
        public string MS4IndustrialStormwaterIndustrialInventoryStatusText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string MS4IndustrialStormwaterMonitoringStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(500)]
        public string MS4IndustrialStormwaterMonitoringStatusText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class MS4IndustrialStormwaterProcedures
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(40)]
        public string MS4ActivityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MS4RegulatedEntityIdentifier", Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(40)]
        public string[] MS4RegulatedEntityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string MS4IndustrialStormwaterProcedureType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string MS4IndustrialStormwaterProcedureText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string MS4IndustrialStormwaterProcedureScheduleText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class MS4OtherApplicableRequirements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(40)]
        public string MS4ActivityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MS4RegulatedEntityIdentifier", Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(40)]
        public string[] MS4RegulatedEntityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string MS4OtherApplicableRequirementsText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string MS4OtherApplicableRequirementsScheduleText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SWConstructionPermit : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string StateWaterBodyName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string ReceivingMS4Name;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string ImpairedWaterIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string HistoricPropertyIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string HistoricPropertyCriterionMetCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string SpeciesCriticalHabitatIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string SpeciesCriterionMetCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("10", "2")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal IndustrialActivitySize;

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
        public GPCFLowErosivityWaiver GPCFLowErosivityWaiver;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        public ConstructionSiteList ConstructionSiteList;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string ProjectTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate EstimatedStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate EstimatedCompleteDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("10", "2")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal EstimatedAreaDisturbedAcresNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string ProjectPlanSizeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string StructureDemolishedIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string StructureDemolishedFloorSpaceIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string PredevelopmentLandUseIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string EarthDisturbingActivitiesIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string EarthDisturbingEmergencyIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 23)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string PreviousStormwaterDischargesIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 24)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string OtherPermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 25)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string CGPIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 26)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string MS4DischargeIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 27)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string WaterProximityIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 28)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string AntidegradationIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 29)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string TreatmentChemicalsIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 30)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string CationicChemicalsIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 31)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string CationicChemicalsAuthorizationIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 32)]
        [System.Xml.Serialization.XmlArrayItemAttribute("TreatmentChemicalName", IsNullable = false)]
        public string[] TreatmentChemicalsList;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 33)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string SWPPPPreparedIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 34)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("10", "2")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal ConstructionSiteTotalArea;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 35)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("10", "2")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal PostConstructionTotalImperviousArea;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 36)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string SoilFillMaterialDescriptionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 37)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("3", "2")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal RunoffCoefficientPostConstruction;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProposedConstructionStormwaterBMPs", Order = 38)]
        public ProposedConstructionStormwaterBMPs[] ProposedConstructionStormwaterBMPs;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProposedPostConstructionStormwaterBMPs", Order = 39)]
        public ProposedPostConstructionStormwaterBMPs[] ProposedPostConstructionStormwaterBMPs;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 40)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Contact[] StormWaterContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 41)]
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
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string SubsurfaceEarthDisturbanceIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string PriorSurveysEvaluationsIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
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
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate NOISignatureDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate NOIPostmarkDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate NOIReceivedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate CompleteNOIReceivedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SubsectorCodePlusDescription", Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(304)]
        public string[] SubsectorCodePlusDescription;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
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
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate NOTTerminationDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate NOTSignatureDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate NOTPostmarkDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate NOTReceivedDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class GPCFLowErosivityWaiver
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate LEWAuthorizationDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class ConstructionSiteList
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ConstructionSiteCode", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] ConstructionSiteCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string ConstructionSiteOtherText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class ProposedConstructionStormwaterBMPs
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string ProposedConstructionStormwaterBMPCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(1000)]
        public string ProposedConstructionStormwaterBMPOtherText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class ProposedPostConstructionStormwaterBMPs
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string ProposedPostConstructionStormwaterBMPCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(1000)]
        public string ProposedPostConstructionStormwaterBMPOtherText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class PretreatmentPermit : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string PretreatmentProgramRequiredIndicatorCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(2)]
        public string ControlAuthorityStateAgencyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(2)]
        public string ControlAuthorityRegionalAgencyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string ControlAuthorityNPDESIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate PretreatmentProgramApprovedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 5)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Contact[] PretreatmentContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PretreatmentProgramModification", Order = 6)]
        public PretreatmentProgramModification[] PretreatmentProgramModification;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string ReceivingRCRAWasteIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string ReceivingRemediationWasteIndicator;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class PretreatmentProgramModification
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string PretreatmentProgramModificationType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate PretreatmentProgramModificationDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(500)]
        public string PretreatmentProgramModificationText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class POTWTreatmentTechnologyPermit : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public WastewaterFlowTreatmentTechnology WastewaterFlowTreatmentTechnology;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class WastewaterFlowTreatmentTechnology
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("POTWTreatmentLevel", typeof(POTWTreatmentLevel), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("POTWWastewaterDisinfectionTechnology", typeof(POTWWastewaterDisinfectionTechnology), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("POTWWastewaterTreatmentTechnologyUnitOperations", typeof(POTWWastewaterTreatmentTechnologyUnitOperations), Order = 0)]
        public object[] Items;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class POTWTreatmentLevel
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string POTWTreatmentLevelCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string POTWTreatmentLevelOtherText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class POTWWastewaterDisinfectionTechnology
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string POTWWastewaterDisinfectionTechnologyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string POTWWastewaterDisinfectionTechnologyOtherText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class POTWWastewaterTreatmentTechnologyUnitOperations
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string POTWWastewaterTreatmentTechnologyUnitOperationCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string POTWWastewaterTreatmentTechnologyUnitOperationOtherText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class POTWPermit : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 SSCSPopulationServedNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 CombinedSSCSSystemLength;

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
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(9)]
        public string SatelliteCollectionSystemIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
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
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string PermitTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
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
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string ReissuancePriorityPermitIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(2000)]
        public string BacklogReasonText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string PermitIssuingOrganizationTypeName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OtherPermits", Order = 8)]
        public OtherPermits[] OtherPermits;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AssociatedPermit", Order = 9)]
        public AssociatedPermit[] AssociatedPermit;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string PermitAppealedIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SICCodeDetails", Order = 11)]
        public SICCodeDetails[] SICCodeDetails;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NAICSCodeDetails", Order = 12)]
        public NAICSCodeDetails[] NAICSCodeDetails;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string PermitUserDefinedDataElement1Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string PermitUserDefinedDataElement2Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string PermitUserDefinedDataElement3Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string PermitUserDefinedDataElement4Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string PermitUserDefinedDataElement5Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string PermitCommentsText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ResidualDesignationDetermination", Order = 19)]
        public ResidualDesignationDetermination[] ResidualDesignationDetermination;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 20)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Contact[] PermitContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string GeneralPermitIndustrialCategory;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(120)]
        public string PermitName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PermitComponentTypeCode", Order = 23)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
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
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string OtherPermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(80)]
        public string OtherOrganizationName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
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
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string AssociatedPermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string AssociatedPermitReasonCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class ResidualDesignationDetermination
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string ResidualDesignationDeterminationCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(1000)]
        public string ResidualDesignationDeterminationOtherText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class GeneralPermit : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string ElectronicSubmissionTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string AssociatedMasterGeneralPermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string PermitTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string AgencyTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(3)]
        public PermitStatusCodeType PermitStatusCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PermitStatusCodeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NPDESDataGroupNumberCode", Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
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
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string ReissuancePriorityPermitIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(2000)]
        public string BacklogReasonText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string PermitIssuingOrganizationTypeName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OtherPermits", Order = 13)]
        public OtherPermits[] OtherPermits;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AssociatedPermit", Order = 14)]
        public AssociatedPermit[] AssociatedPermit;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string PermitAppealedIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SICCodeDetails", Order = 16)]
        public SICCodeDetails[] SICCodeDetails;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NAICSCodeDetails", Order = 17)]
        public NAICSCodeDetails[] NAICSCodeDetails;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string PermitUserDefinedDataElement1Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string PermitUserDefinedDataElement2Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string PermitUserDefinedDataElement3Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string PermitUserDefinedDataElement4Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string PermitUserDefinedDataElement5Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 23)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string PermitCommentsText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ResidualDesignationDetermination", Order = 24)]
        public ResidualDesignationDetermination[] ResidualDesignationDetermination;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 25)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 MajorMinorRatingCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 26)]
        public MajorMinorStatus MajorMinorStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 27)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("15", "7")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal TotalApplicationDesignFlowNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 28)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("15", "7")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal TotalApplicationAverageFlowNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 29)]
        public Facility Facility;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 30)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ApplicationReceivedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 31)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate PermitApplicationCompletionDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 32)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string NewSourceIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 33)]
        public ComplianceTrackingStatus ComplianceTrackingStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 34)]
        public DMRNonReceiptStatus DMRNonReceiptStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ReportableNonComplianceStatus", Order = 35)]
        public ReportableNonComplianceStatus[] ReportableNonComplianceStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EffluentGuidelineCode", Order = 36)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] EffluentGuidelineCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 37)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(12)]
        public string PermitStateWaterBodyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 38)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string PermitStateWaterBodyName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 39)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string FederalGrantIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 40)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string DMRCognizantOfficial;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 41)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(15)]
        public string DMRCognizantOfficialTelephoneNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 42)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Contact[] PermitContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 43)]
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
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string ElectronicReportingWaiverTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ElectronicReportingWaiverEffectiveDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ElectronicReportingWaiverExpirationDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class MajorMinorStatus
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public MajorMinorType MajorMinorStatusIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate MajorMinorStatusStartDate;
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
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public ActiveInactiveType StatusCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate StatusStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(200)]
        public string StatusReason;
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
    public partial class DMRNonReceiptStatus
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public ActiveInactiveType DMRNonReceiptStatusIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate DMRNonReceiptStatusStartDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class ReportableNonComplianceStatus
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 ReportableNonComplianceStatusCodeYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 ReportableNonComplianceStatusCodeQuarter;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string ReportableNonComplianceManualStatusCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class LTCPPermit : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public LTCPSummary LTCPSummary;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public LTCPMostRecentRevisionDetail LTCPMostRecentRevisionDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CSOControlMeasureDetail", Order = 2)]
        public CSOControlMeasureDetail[] CSOControlMeasureDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LTCPEnforceableMechanismDetail", Order = 3)]
        public LTCPEnforceableMechanismDetail[] LTCPEnforceableMechanismDetail;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class LTCPSummary
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string LTCPRequiredIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string LTCPInComplianceIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate LTCPApprovalDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate LTCPAndCSOControlsCompleteDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string CSOPostConstructionComplianceMonitoringProgram;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string CSOControlsOtherThanLTCP;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class LTCPMostRecentRevisionDetail
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate LTCPMostRecentRevisionDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string LTCPMostRecentRevisionStatus;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class CSOControlMeasureDetail
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string CSOControlMeasureCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string CSOControlMeasureCodeOtherText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string CSOControlMeasureDevImpStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string CSOControlMeasureComplianceStatus;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class LTCPEnforceableMechanismDetail
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string LTCPEnforceableMechanismCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string LTCPEnforceableMechanismCodeOtherText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SWIndustrialPermit : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string StateWaterBodyName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string ReceivingMS4Name;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string ImpairedWaterIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string HistoricPropertyIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string HistoricPropertyCriterionMetCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string SpeciesCriticalHabitatIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string SpeciesCriterionMetCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("10", "2")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal IndustrialActivitySize;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string WebAddressURL;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string ActivitiesExposedSWText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string AssociatedPollutantsText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string ControlMeasuresText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string ScheduleControlMeasuresText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("10", "2")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal IndustrialTotalImperviousSurfaceArea;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string TierTwoIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string TierThreeIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        public GPCFNoticeOfIntent GPCFNoticeOfIntent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        public GPCFNoticeOfTermination GPCFNoticeOfTermination;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        public GPCFNoExposure GPCFNoExposure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProposedIndustrialStormwaterBMPs", Order = 19)]
        public ProposedIndustrialStormwaterBMPs[] ProposedIndustrialStormwaterBMPs;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 20)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Contact[] StormWaterContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 21)]
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
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate NoExposureAuthorizationDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate NoExposurePostmarkDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate NoExposureEvaluationDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string NoExposureEvaluationBasisCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string NoExposureCriteriaMetIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 PavedRoofSize;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class ProposedIndustrialStormwaterBMPs
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string ProposedIndustrialStormwaterBMPCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(1000)]
        public string ProposedIndustrialStormwaterBMPOtherText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class CAFOPermit : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
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
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string IsAnimalFacilityTypeCAFOIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate CAFODesignationDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(500)]
        public string CAFODesignationReasonText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AnimalType", Order = 6)]
        public AnimalType[] AnimalType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CAFOMLPWTotalAmounts", Order = 7)]
        public CAFOMLPWTotalAmounts[] CAFOMLPWTotalAmounts;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ManureLitterProcessedWastewaterStorage", Order = 8)]
        public ManureLitterProcessedWastewaterStorage[] ManureLitterProcessedWastewaterStorage;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Containment", Order = 9)]
        public Containment[] Containment;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 NumberAcresContributingDrainage;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 ApplicationMeasureAvailableLandNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 SolidManureLitterGeneratedAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 LiquidManureWastewaterGeneratedAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 SolidManureLitterTransferAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 LiquidManureWastewaterTransferAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string NMPDevelopedCertifiedPlannerApprovedIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate NMPDevelopedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate NMPLastUpdatedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string EnvironmentalManagementSystemIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate EMSDevelopedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate EMSLastUpdatedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LandApplicationBMP", Order = 22)]
        public LandApplicationBMP[] LandApplicationBMP;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 23)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 LivestockMaximumCapacityNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 24)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 LivestockCapacityDeterminationBasedUponNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 25)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 AuthorizedLivestockCapacityNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 26)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
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
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 OpenConfinementCount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 HousedUnderRoofConfinementCount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string LiquidManureHandlingSystem;
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
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string AnimalTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string OtherAnimalTypeName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 TotalNumbersEachLivestock;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class CAFOMLPWTotalAmounts
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string CAFOMLPWCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("14", "2")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal CAFOMLPWAmountGenerated;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("14", "2")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal CAFOMLPWAmountTransferred;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string CAFOMLPWUnit;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class ManureLitterProcessedWastewaterStorage
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string ManureLitterProcessedWastewaterStorageType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string OtherStorageTypeName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 StorageTotalCapacityMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 DaysOfStorage;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string CAFOMLPWUnit;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string CAFOMLPWStorageWithinDesignCapacity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(500)]
        public string CAFOMLPWStorageWithinDesignCapacityText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class Containment
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string ContainmentTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string OtherContainmentTypeName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 ContainmentCapacityNumber;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class LandApplicationBMP
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string LandApplicationBMPTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string OtherLandApplicationBMPTypeName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class BiosolidsPermit : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("BiosolidsFacilityTypeCode", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] BiosolidsFacilityTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(250)]
        public string BiosolidsFacilityTypeOtherText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("15", "7")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal BiosolidsFacilityTotalVolumeAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("BiosolidsFacilityTreatmentCode", Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] BiosolidsFacilityTreatmentCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string BiosolidsFacilityTreatmentOtherText;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 5)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public PermitBiosolidsManagementPracticeData[] PermitBiosolidsManagementPractice;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class PermitBiosolidsManagementPracticeData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(20)]
        public string SSUIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string BiosolidsManagementPracticeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string BiosolidsManagementPracticeSubCategoryCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(250)]
        public string BiosolidsManagementPracticeSubCategoryText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string BiosolidsOperatorTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string BiosolidsContainerTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("15", "7")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal SSUIDVolumeAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string PathogenClassTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string PollutantLoadingRatesExceedanceIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PathogenReductionTypeCode", Order = 9)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] PathogenReductionTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("VectorAttractionReductionTypeCode", Order = 10)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] VectorAttractionReductionTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string SurfaceDisposalWithoutLinerIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string SurfaceDisposalSiteSpecificLimitIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string SurfaceDisposalMinimumBoundaryDistanceCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string BiosolidsOffSiteFacilityPermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("BiosolidsOffSiteHandlerApplierPreparer", Order = 15)]
        public BiosolidsOffSiteHandlerApplierPreparer[] BiosolidsOffSiteHandlerApplierPreparer;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class BiosolidsOffSiteHandlerApplierPreparer
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("15", "7")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal BiosolidsOffSiteHandlerApplierVolumeAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("BiosolidsOffSiteFacilityContact", Order = 1)]
        public Contact[] BiosolidsOffSiteFacilityContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public Address BiosolidsOffSiteFacilityAddress;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class BasicPermit : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string PermitTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string AgencyTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(3)]
        public PermitStatusCodeType PermitStatusCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PermitStatusCodeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NPDESDataGroupNumberCode", Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
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
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string ReissuancePriorityPermitIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(2000)]
        public string BacklogReasonText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string PermitIssuingOrganizationTypeName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OtherPermits", Order = 11)]
        public OtherPermits[] OtherPermits;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AssociatedPermit", Order = 12)]
        public AssociatedPermit[] AssociatedPermit;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string PermitAppealedIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SICCodeDetails", Order = 14)]
        public SICCodeDetails[] SICCodeDetails;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NAICSCodeDetails", Order = 15)]
        public NAICSCodeDetails[] NAICSCodeDetails;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string PermitUserDefinedDataElement1Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string PermitUserDefinedDataElement2Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string PermitUserDefinedDataElement3Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string PermitUserDefinedDataElement4Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string PermitUserDefinedDataElement5Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string PermitCommentsText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ResidualDesignationDetermination", Order = 22)]
        public ResidualDesignationDetermination[] ResidualDesignationDetermination;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 23)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 MajorMinorRatingCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 24)]
        public MajorMinorStatus MajorMinorStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 25)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("15", "7")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal TotalApplicationDesignFlowNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 26)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("15", "7")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal TotalApplicationAverageFlowNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 27)]
        public Facility Facility;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 28)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ApplicationReceivedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 29)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate PermitApplicationCompletionDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 30)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string NewSourceIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 31)]
        public ComplianceTrackingStatus ComplianceTrackingStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 32)]
        public DMRNonReceiptStatus DMRNonReceiptStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ReportableNonComplianceStatus", Order = 33)]
        public ReportableNonComplianceStatus[] ReportableNonComplianceStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EffluentGuidelineCode", Order = 34)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] EffluentGuidelineCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 35)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(12)]
        public string PermitStateWaterBodyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 36)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string PermitStateWaterBodyName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 37)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string FederalGrantIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 38)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string DMRCognizantOfficial;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 39)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(15)]
        public string DMRCognizantOfficialTelephoneNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 40)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Contact[] PermitContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 41)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Address[] PermitAddress;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 42)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string SignificantIUIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 43)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string ReceivingPermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 44)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string IndustrialUserTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SIUDesignationType", Order = 45)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] SIUDesignationType;
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
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string ProgramReportFormSetID;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class BiosolidsAnnualProgramReport : BiosolidsAnnualProgramReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 ProgramReportFormID;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ProgramReportReceivedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ProgramReportStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ProgramReportEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string ElectronicSubmissionTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string ProgramReportNPDESDataGroupNumberCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("BiosolidsFacilityTypeCode", Order = 6)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] BiosolidsFacilityTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(250)]
        public string BiosolidsFacilityTypeOtherText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("15", "7")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal BiosolidsFacilityTotalVolumeAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("BiosolidsFacilityTreatmentCode", Order = 9)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] BiosolidsFacilityTreatmentCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string BiosolidsFacilityTreatmentOtherText;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 11)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public AnalyticalMethodData[] AnalyticalMethods;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 12)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public BiosolidsManagementPracticeData[] BiosolidsManagementPractice;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string BiosolidsAnnualProgramReportCommentText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class AnalyticalMethodData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string AnalyticalMethodTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(500)]
        public string AnalyticalMethodOtherTypeText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class BiosolidsManagementPracticeData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(20)]
        public string SSUIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string BiosolidsManagementPracticeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string BiosolidsManagementPracticeSubCategoryCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(250)]
        public string BiosolidsManagementPracticeSubCategoryText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string BiosolidsOperatorTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string BiosolidsContainerTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("15", "7")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal SSUIDVolumeAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string PathogenClassTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string PollutantLoadingRatesExceedanceIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PathogenReductionTypeCode", Order = 9)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] PathogenReductionTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("VectorAttractionReductionTypeCode", Order = 10)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] VectorAttractionReductionTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string BiosolidsManagementPracticeViolationTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(2000)]
        public string BiosolidsManagementPracticeViolationText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string BiosolidsOffSiteFacilityPermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string SurfaceDisposalWithoutLinerIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string SurfaceDisposalSiteSpecificLimitIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string SurfaceDisposalMinimumBoundaryDistanceCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ComplianceMonitoringEventData", Order = 17)]
        public ComplianceMonitoringEventData[] ComplianceMonitoringEventData;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 18)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public BiosolidsSewageSludgeParameter[] BiosolidsSewageSludgeMaximumPollutantLimit;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        public BiosolidsOffSiteHandlerApplierPreparer BiosolidsOffSiteHandlerApplierPreparer;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("BiosolidsIncinerationData", Order = 20)]
        public BiosolidsIncinerationData[] BiosolidsIncinerationData;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class ComplianceMonitoringEventData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 ComplianceMonitoringEventIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ComplianceMonitoringEventStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ComplianceMonitoringEventEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 3)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public BiosolidsSewageSludgeParameter[] BiosolidsSewageSludgeMaximumPollutantConcentrations;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 4)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public BiosolidsSewageSludgeParameter[] BiosolidsSewageSludgeAveragePollutantConcentrations;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 5)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public BiosolidsSewageSludgeParameter[] BiosolidsSewageSludgePathogenMonitoring;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 6)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public BiosolidsSewageSludgeParameter[] BiosolidsSewageSludgeVARMonitoring;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class BiosolidsSewageSludgeParameter
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 BiosolidsSewageSludgeParameterCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 BiosolidsSewageSludgeParameterLimit;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string ParameterValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string ValueQualifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string NoDataIndicatorCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string PassFailIndicatorCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string PathogenReductionTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate BiosolidsSampleStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate BiosolidsSampleEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(7)]
        public string BiosolidsSampleMonth;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class BiosolidsIncinerationData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(20)]
        public string BiosolidsIncineratorIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string BiosolidsIncineratorTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(250)]
        public string BiosolidsIncineratorOtherText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate BiosolidsIncineratorLastSignificantChangeDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string BiosolidsIncineratorNewPollutantLimitsIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 5)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public BiosolidsIncineratorEmissionsControlType[] BiosolidsIncineratorEmissionsControlTechnology;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 6)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public BiosolidsSewageSludgeParameter[] BiosolidsAirEmissionsPollutantMonitoring;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 7)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public BiosolidsSewageSludgeParameter[] BiosolidsIncinerationProcessControlMonitoring;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 8)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public BiosolidsSewageSludgeParameter[] BiosolidsIncinerationFeedMonitoring;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 9)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public BiosolidsSewageSludgeParameter[] BiosolidsIncinerationFeedLimits;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class BiosolidsIncineratorEmissionsControlType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string BiosolidsEmissionsControlCategory;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string BiosolidsEmissionsControlTechnologyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(250)]
        public string BiosolidsEmissionsControlOtherText;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CAFOAnnualProgramReport))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class CAFOAnnualProgramReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string ProgramReportFormSetID;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class CAFOAnnualProgramReport : CAFOAnnualProgramReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 ProgramReportFormID;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ProgramReportReceivedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ProgramReportStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ProgramReportEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string ElectronicSubmissionTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string ProgramReportNPDESDataGroupNumberCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("8", "2")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal NutrientManagementPlanAcreageNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("8", "2")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal ActualLandApplicationAcreageNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string NMPCertifiedPlannerIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AnimalType", Order = 9)]
        public AnimalType[] AnimalType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CAFOMLPWTotalAmounts", Order = 10)]
        public CAFOMLPWTotalAmounts[] CAFOMLPWTotalAmounts;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CAFOMLPWNutrientMonitoring", Order = 11)]
        public CAFOMLPWNutrientMonitoring[] CAFOMLPWNutrientMonitoring;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CAFOProductionAreaDischarge", Order = 12)]
        public CAFOProductionAreaDischarge[] CAFOProductionAreaDischarge;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CAFOLandApplicationFieldInformation", Order = 13)]
        public CAFOLandApplicationFieldInformation[] CAFOLandApplicationFieldInformation;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class CAFOMLPWNutrientMonitoring
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string CAFOMLPWCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string CAFOMLPWNutrientForm;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("5", "2")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal CAFOMLPWNutrientValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string CAFOMLPWNutrientValueUnit;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class CAFOProductionAreaDischarge
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate CAFOProductionAreaDischargeDiscoveryDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string CAFOProductionAreaDischarge24hrRainEventIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("5", "2")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal CAFOProductionAreaDischargeDurationHours;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 CAFOProductionAreaDischargeVolumeGallons;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class CAFOLandApplicationFieldInformation
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(20)]
        public string CAFOLandApplicationFieldIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("8", "2")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal CAFOLandApplicationFieldAcreage;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string CAFOMLPWMaximumAmountMethod;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public CAFOLandApplicationFieldCropInformation CAFOLandApplicationFieldCropInformation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public CAFOMLPWFieldAmounts CAFOMLPWFieldAmounts;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public CAFONarrativeRateApproachSoilMonitoring CAFONarrativeRateApproachSoilMonitoring;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public CAFONarrativeRateApproachSupplementalFertilizer CAFONarrativeRateApproachSupplementalFertilizer;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class CAFOLandApplicationFieldCropInformation
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(20)]
        public string CAFOLandApplicationFieldCropIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4)]
        public string CAFOLandApplicationFieldCropCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("8", "2")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal CAFOLandApplicationFieldCropYield;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string CAFOLandApplicationFieldCropYieldUnit;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string CAFOLandApplicationFieldCropSeeded;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class CAFOMLPWFieldAmounts
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string CAFOMLPWCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("11", "2")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal CAFOMLPWFieldMaxAllowableAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("11", "2")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal CAFOMLPWFieldActualAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string CAFOMLPWLandApplicationUnit;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class CAFONarrativeRateApproachSoilMonitoring
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string CAFOSoilMonitoringMeasurementForm;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("5", "2")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal CAFOSoilMonitoringMeasurementValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string CAFOSoilMonitoringMeasurementValueUnit;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string CAFOSoilMonitoringAnalyticalMethod;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("3", "1")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal CAFOSoilMonitoringSampleDepthInches;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate CAFOSoilMonitoringSampleDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class CAFONarrativeRateApproachSupplementalFertilizer
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string CAFOSupplementalFertilizerMeasurementForm;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("5", "2")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal CAFOSupplementalFertilizerMeasurementValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string CAFOSupplementalFertilizerMeasurementValueUnit;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CaseFileLinkage))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class CaseFileKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(25)]
        public string CaseFileIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class CaseFileLinkage : CaseFileKeyElements
    {

        /// <remarks/>
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
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(25)]
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
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(25)]
        public string ComplianceMonitoringIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class LinkageEnforcementAction
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(20)]
        public string EnforcementActionIdentifier;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ComplianceMonitoring))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ComplianceMonitoringLinkage))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class ComplianceMonitoringKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(25)]
        public string ComplianceMonitoringIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class ComplianceMonitoring : ComplianceMonitoringKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(3)]
        public ComplianceMonitoringActivityTypeCodeType ComplianceMonitoringActivityTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ComplianceMonitoringActivityTypeCodeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string ComplianceMonitoringCategoryCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 3)]
        public System.DateTime ComplianceMonitoringDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ComplianceMonitoringDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ComplianceMonitoringStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ComplianceInspectionTypeCode", Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] ComplianceInspectionTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string ComplianceMonitoringActivityName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string BiomonitoringInspectionMethod;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ComplianceMonitoringActionReasonCode", Order = 8)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] ComplianceMonitoringActionReasonCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ComplianceMonitoringAgencyTypeCode", Order = 9)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] ComplianceMonitoringAgencyTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 ComplianceMonitoringAgencyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProgramCode", Order = 11)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(9)]
        public string[] ProgramCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProgramDeficiencyTypeCode", Order = 12)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] ProgramDeficiencyTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string StateStatuteViolatedName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string EPAAssistanceIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public StateFederalJointType StateFederalJointIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StateFederalJointIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string JointInspectionReasonCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public LeadPartyType LeadParty;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LeadPartySpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 NumberDaysPhysicallyConductingActivity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 NumberHoursPhysicallyConductingActivity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 ComplianceMonitoringActionOutcomeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string InspectionRatingCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NationalPrioritiesCode", Order = 22)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32[] NationalPrioritiesCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 23)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string MultimediaIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 24)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string FederalFacilityIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 25)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string FederalFacilityIndicatorComment;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 26)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string InspectionUserDefinedField1;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 27)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string InspectionUserDefinedField2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 28)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string InspectionUserDefinedField3;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 29)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate InspectionUserDefinedField4;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 30)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate InspectionUserDefinedField5;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 31)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string InspectionUserDefinedField6;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("InspectionCommentText", Order = 32)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string[] InspectionCommentText;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 33)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Contact[] InspectionContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("InspectionGovernmentContact", Order = 34)]
        public InspectionGovernmentContact[] InspectionGovernmentContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 35)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ComplianceMonitoringPlannedStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 36)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ComplianceMonitoringPlannedEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 37)]
        public CAFOInspection CAFOInspection;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 38)]
        public CSOInspection CSOInspection;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 39)]
        public PretreatmentInspection PretreatmentInspection;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 40)]
        public SSOInspection SSOInspection;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("StormWaterConstructionInspection", typeof(StormWaterConstructionInspection), Order = 41)]
        [System.Xml.Serialization.XmlElementAttribute("StormWaterConstructionNonConstructionInspections", typeof(StormWaterConstructionNonConstructionInspections), Order = 41)]
        [System.Xml.Serialization.XmlElementAttribute("StormWaterNonConstructionInspection", typeof(StormWaterNonConstructionInspection), Order = 41)]
        public object Item;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 42)]
        public StormWaterMS4Inspection StormWaterMS4Inspection;
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
    public partial class CAFOInspection
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string CAFOClassificationCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string IsAnimalFacilityTypeCAFOIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate CAFODesignationDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(500)]
        public string CAFODesignationReasonText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string DischargesDuringYearProductionAreaIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string DischargesDuringYearLandApplicationAreaIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(500)]
        public string CAFODischargesDuringYearText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AnimalType", Order = 7)]
        public AnimalType[] AnimalType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ManureLitterProcessedWastewaterStorage", Order = 8)]
        public ManureLitterProcessedWastewaterStorage[] ManureLitterProcessedWastewaterStorage;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Containment", Order = 9)]
        public Containment[] Containment;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 NumberAcresContributingDrainage;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 ApplicationMeasureAvailableLandNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 SolidManureLitterGeneratedAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 LiquidManureWastewaterGeneratedAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 SolidManureLitterTransferAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 LiquidManureWastewaterTransferAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string NMPDevelopedCertifiedPlannerApprovedIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate NMPDevelopedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate NMPLastUpdatedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string EnvironmentalManagementSystemIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate EMSDevelopedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate EMSLastUpdatedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LandApplicationBMP", Order = 22)]
        public LandApplicationBMP[] LandApplicationBMP;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 23)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 LivestockMaximumCapacityNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 24)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 LivestockCapacityDeterminationBasedUponNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 25)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 AuthorizedLivestockCapacityNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CAFOInspectionViolationTypeCode", Order = 26)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
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
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public WetDryType DryOrWetWeatherIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DryOrWetWeatherIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4)]
        public string PermittedFeatureIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(10)]
        public string LatitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(11)]
        public string LongitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string CSOOverflowLocationStreet;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("6", "2")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal DurationCSOOverflowEvent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 DischargeVolumeTreated;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 DischargeVolumeUntreated;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string CorrectiveActionTakenDescriptionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("5", "2")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal InchesPrecipitation;
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
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(15)]
        public string SUOReference;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate SUODate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public YesNoIndicatorTypeBase AcceptanceHazardousWaste;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AcceptanceHazardousWasteSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public YesNoIndicatorTypeBase AcceptanceNonHazardousIndustrialWaste;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AcceptanceNonHazardousIndustrialWasteSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public YesNoIndicatorTypeBase AcceptanceHauledDomesticWastes;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AcceptanceHauledDomesticWastesSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(7)]
        public string AnnualPretreatmentBudget;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public YesNoIndicatorTypeBase InadequacySamplingInspectionIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool InadequacySamplingInspectionIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public YesNoIndicatorTypeBase AdequacyPretreatmentResources;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AdequacyPretreatmentResourcesSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public YesNoIndicatorTypeBase DeficienciesIdentifiedDuringIUFileReview;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DeficienciesIdentifiedDuringIUFileReviewSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public YesNoIndicatorTypeBase ControlMechanismDeficiencies;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ControlMechanismDeficienciesSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public YesNoIndicatorTypeBase LegalAuthorityDeficiencies;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LegalAuthorityDeficienciesSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public YesNoIndicatorTypeBase DeficienciesInterpretationApplicationPretreatmentStandards;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DeficienciesInterpretationApplicationPretreatmentStandardsSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public YesNoIndicatorTypeBase DeficienciesDataManagementPublicParticipation;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DeficienciesDataManagementPublicParticipationSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public YesNoIndicatorTypeBase ViolationIUScheduleRemedialMeasures;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ViolationIUScheduleRemedialMeasuresSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string FormalResponseViolationIUScheduleRemedialMeasures;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 AnnualFrequencyInfluentToxicantSampling;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 AnnualFrequencyEffluentToxicantSampling;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 AnnualFrequencySludgeToxicantSampling;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 NumberSIUs;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 SIUsWithoutControlMechanism;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 SIUsNotInspected;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 SIUsNotSampled;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 SIUsOnSchedule;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 23)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 SIUsSNCWithPretreatmentStandards;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 24)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 SIUsSNCWithReportingRequirements;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 25)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 SIUsSNCWithPretreatmentSchedule;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 26)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 SIUsSNCPublishedNewspaper;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 27)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 ViolationNoticesIssuedSIUs;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 28)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 AdministrativeOrdersIssuedSIUs;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 29)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 CivilSuitsFiledAgainstSIUs;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 30)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 CriminalSuitsFiledAgainstSIUs;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 31)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("6", "2")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal DollarAmountPenaltiesCollected;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 32)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4)]
        public string IUsWhichPenaltiesHaveBeenCollected;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 33)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 NumberCIUs;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 34)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 CIUsInSNC;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 35)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string PassThroughInterferenceIndicator;
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
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(1000)]
        public string CauseSSOOverflowEvent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(10)]
        public string LatitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(11)]
        public string LongitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string SSOOverflowLocationStreet;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("6", "2")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal DurationSSOOverflowEvent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 SSOVolume;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(1000)]
        public string NameReceivingWater;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ImpactSSOEvent", Order = 8)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] ImpactSSOEvent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SSOSystemComponent", Order = 9)]
        public SSOSystemComponent[] SSOSystemComponent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SSOSteps", Order = 10)]
        public SSOSteps[] SSOSteps;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
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
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string SystemComponent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
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
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string StepsReducePreventMitigate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string OtherStepsReducePreventMitigate;
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
    public partial class StormWaterUnpermittedConstructionInspection
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public ProjectType ProjectType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate EstimatedStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate EstimatedCompleteDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("10", "2")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal EstimatedAreaDisturbedAcresNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
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
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string ProjectTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
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
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string SWPPPEvaluationBasisCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate SWPPPEvaluationDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string SWPPPEvaluationDescriptionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate NoExposureAuthorizationDate;
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
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class StormWaterMS4Inspection
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 MS4AnnualExpenditureDollars;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 MS4AnnualExpenditureYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 MS4BudgetDollars;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 MS4BudgetYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProjectedSourcesFundingCode", Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] ProjectedSourcesFundingCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public EstimatedMeasuredType MajorOutfallEstimatedMeasureIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MajorOutfallEstimatedMeasureIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 MajorOutfallNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public EstimatedMeasuredType MinorOutfallEstimatedMeasureIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MinorOutfallEstimatedMeasureIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 MinorOutfallNumber;
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
    public partial class ComplianceMonitoringLinkage : ComplianceMonitoringKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LinkageComplianceMonitoring", typeof(LinkageComplianceMonitoring), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("LinkageEnforcementAction", typeof(LinkageEnforcementAction), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("LinkageSingleEvent", typeof(LinkageSingleEvent), Order = 0)]
        public object Item;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class LinkageSingleEvent
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
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
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ComplianceScheduleViolation))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ComplianceSchedule))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class ComplianceScheduleKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(20)]
        public string EnforcementActionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 FinalOrderIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 3)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 ComplianceScheduleNumber;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class ComplianceScheduleViolation : ComplianceScheduleKeyElements
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class ComplianceSchedule : ComplianceScheduleKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string ComplianceScheduleComments;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
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
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ScheduleReportReceivedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ScheduleActualDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ScheduleProjectedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string ScheduleUserDefinedDataElement1;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string ScheduleUserDefinedDataElement2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string ScheduleEventComments;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("14", "2")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal ComplianceSchedulePenaltyAmount;
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
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
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
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(20)]
        public string EnforcementActionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 FinalOrderIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 3)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
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
        public ScheduleViolationCodeType ScheduleViolationCode;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(DischargeMonitoringReportParameterViolation))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(DischargeMonitoringReportViolation))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(DischargeMonitoringReport))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class DischargeMonitoringReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class DischargeMonitoringReportParameterViolation : DischargeMonitoringReportKeyElements
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
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 LimitSeasonNumber;
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
    public partial class DischargeMonitoringReport : DischargeMonitoringReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string ElectronicSubmissionTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate SignatureDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string PrincipalExecutiveOfficerFirstName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string PrincipalExecutiveOfficerLastName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(40)]
        public string PrincipalExecutiveOfficerTitle;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(10)]
        public string PrincipalExecutiveOfficerTelephone;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string SignatoryFirstName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string SignatoryLastName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(10)]
        public string SignatoryTelephone;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
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
        public ItemsChoiceType2[] ItemsElementName;

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
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string ReportSampleTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
        public string ReportingFrequencyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 ReportNumberOfExcursions;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(2)]
        public string ConcentrationNumericReportUnitMeasureCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(2)]
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
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(2)]
        public NumericReportTextType NumericReportCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate NumericReportReceivedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string NumericReportNoDischargeIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string NumericConditionQuantity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string NumericConditionAdjustedQuantity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
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
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
        public string ParameterCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string MonitoringSiteDescriptionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 LimitSeasonNumber;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IncludeInSchema = false)]
    public enum ItemsChoiceType2
    {

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        DMRNoDischargeIndicator,

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
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
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 PollutantMetForLandApplication;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string PathogenReductionIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string VectorReductionIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 AgronomicGallonsRateForField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 AgronomicDMTRateForField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string ClassAAlternativeUsed;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string ClassAAlternativesText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string ClassBAlternativeUsed;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string ClassBAlternativesText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string VARAlternativeUsed;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string VARAlternativesText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CropTypesPlanted", Order = 11)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] CropTypesPlanted;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CropTypesHarvested", Order = 12)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
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
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string PathogenReductionIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string VectorReductionIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string ManagementPracticesIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string CertificationStatementIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string CertifierFirstName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string CertifierLastName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string ClassAAlternativeUsed;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string ClassAAlternativesText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string ClassBAlternativeUsed;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string ClassBAlternativesText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string VARAlternativeUsed;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
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
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string BerylliumComplianceIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
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
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string Part258ComplianceIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public PassFailIndicatorType PaintFilterTestResult;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PaintFilterTestResultSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
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
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
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
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 LimitSeasonNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(2)]
        public NumericReportTextType NumericReportCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
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
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string ReportableNonComplianceDetectionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ReportableNonComplianceDetectionDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string ReportableNonComplianceResolutionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ReportableNonComplianceResolutionDate;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(InformalEnforcementAction))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(FormalEnforcementAction))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(FinalOrderViolationLinkage))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(EnforcementActionViolationLinkage))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class EnforcementActionKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(20)]
        public string EnforcementActionIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class InformalEnforcementAction : EnforcementActionKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PermitIdentifier", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
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
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate InformalEAUserDefinedField4;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class FormalEnforcementAction : EnforcementActionKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PermitIdentifier", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string[] PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string EnforcementActionName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(3)]
        public ForumType Forum;

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
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate FormalEAUserDefinedField4;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
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
    public partial class FinalOrder
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
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
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate FinalOrderIssuedEnteredDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate NPDESClosedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(2000)]
        public string FinalOrderQNCRComments;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("14", "2")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal CashCivilPenaltyRequiredAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("14", "2")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal CashCivilPenaltyCollectedAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string OtherComments;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SupplementalEnvironmentalProject", Order = 9)]
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
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 SupplementalEnvironmentalProjectIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string SupplementalEnvironmentalProjectDescription;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("14", "2")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal SupplementalEnvironmentalProjectPenaltyAssessmentAmount;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class FinalOrderViolationLinkage : EnforcementActionKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 FinalOrderIdentifier;

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
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
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
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 NarrativeConditionNumber;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class NarrativeCondition : PermitScheduleKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(3)]
        public string NarrativeConditionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
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
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ScheduleReportReceivedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ScheduleActualDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ScheduleProjectedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string ScheduleUserDefinedDataElement1;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string ScheduleUserDefinedDataElement2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
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
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
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
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(3)]
        public string NarrativeConditionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
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
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SingleEventViolation : SingleEventKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate SingleEventViolationEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ReportableNonComplianceDetectionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ReportableNonComplianceDetectionDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string ReportableNonComplianceResolutionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ReportableNonComplianceResolutionDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string SingleEventUserDefinedField1;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string SingleEventUserDefinedField2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string SingleEventUserDefinedField3;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string SingleEventUserDefinedField4;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string SingleEventUserDefinedField5;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
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
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(Milestone))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class EnforcementActionMilestoneKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(20)]
        public string EnforcementActionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
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
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate MilestonePlannedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate MilestoneActualDate;
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
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        public System.DateTime PermitEffectiveDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class HistoricalPermitScheduleEvents : HistoricalPermitScheduleKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ScheduleReportReceivedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ScheduleActualDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ScheduleProjectedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string ScheduleUserDefinedDataElement1;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string ScheduleUserDefinedDataElement2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
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
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
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
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 LimitSeasonNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 6)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public System.DateTime LimitStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 7)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
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
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string LimitTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MonthLimitApplies", Order = 1)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(3)]
        public MonthTextType[] MonthLimitApplies;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string SampleTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
        public string FrequencyOfAnalysisCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public YesNoIndicatorTypeBase EligibleForBurdenReduction;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EligibleForBurdenReductionSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string LimitStayTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate StayStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate StayEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(500)]
        public string StayReasonText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string CalculateViolationsIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(20)]
        public string EnforcementActionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 FinalOrderIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string BasisOfLimit;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string LimitModificationTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate LimitModificationEffectiveDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(500)]
        public string LimitModificationTypeStayReasonText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string LimitsUserDefinedField1;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string LimitsUserDefinedField2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(150)]
        public string LimitsUserDefinedField3;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(2)]
        public string ConcentrationNumericConditionUnitMeasureCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(2)]
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
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(2)]
        public NumericReportTextType NumericConditionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string NumericConditionQuantity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string NumericConditionStatisticalBaseCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string NumericConditionQualifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
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
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
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
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
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
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string PermittedFeatureTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string PermittedFeatureDescription;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string PermittedFeatureStateWaterBodyName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string ImpairedWaterIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string TMDLCompletedIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string PermittedFeatureUserDefinedDataElement1;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
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
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string LimitSetNameText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(315)]
        public string DMRPrePrintCommentsText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public LimitSetStatus LimitSetStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LimitSetSchedule", Order = 3)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
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
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public ActiveInactiveType LimitSetStatusIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate LimitSetStatusStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
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
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 NumberUnitsReportPeriodInteger;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 NumberSubmissionUnitsInteger;

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
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string LimitSetModificationTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate LimitSetModificationEffectiveDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class LimitSet : LimitSetKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public LimitSetType LimitSetType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string LimitSetNameText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(315)]
        public string DMRPrePrintCommentsText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
        public string AgencyReviewer;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 LimitSetUserDefinedDataElement1Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(150)]
        public string LimitSetUserDefinedDataElement2Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LimitSetMonthsApplicable", Order = 6)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(3)]
        public MonthTextType[] LimitSetMonthsApplicable;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public LimitSetStatus LimitSetStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LimitSetSchedule", Order = 8)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public LimitSetSchedule[] LimitSetSchedule;
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
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
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
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 LimitSeasonNumber;
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
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public System.DateTime LimitStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public System.DateTime LimitEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string LimitTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MonthLimitApplies", Order = 3)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(3)]
        public MonthTextType[] MonthLimitApplies;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string SampleTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
        public string FrequencyOfAnalysisCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public YesNoIndicatorTypeBase EligibleForBurdenReduction;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EligibleForBurdenReductionSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string LimitStayTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate StayStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate StayEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(500)]
        public string StayReasonText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string CalculateViolationsIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(20)]
        public string EnforcementActionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 FinalOrderIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string BasisOfLimit;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string LimitModificationTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate LimitModificationEffectiveDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(500)]
        public string LimitModificationTypeStayReasonText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string LimitsUserDefinedField1;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string LimitsUserDefinedField2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(150)]
        public string LimitsUserDefinedField3;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(2)]
        public string ConcentrationNumericConditionUnitMeasureCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(2)]
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
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
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
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class PermitTrackingEvent : PermitTrackingEventKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
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
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4)]
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
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string PermittedFeatureTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PermittedFeatureCharacteristics", Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] PermittedFeatureCharacteristics;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string PermittedFeatureDescription;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PermittedFeatureTreatmentTypeCode", Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] PermittedFeatureTreatmentTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("15", "7")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal PermittedFeatureDesignFlowNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("15", "7")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal PermittedFeatureActualAverageFlowNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(12)]
        public string PermittedFeatureStateWaterBodyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string PermittedFeatureStateWaterBodyName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public TierLevelType TierLevelName;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TierLevelNameSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string ImpairedWaterIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string TMDLCompletedIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        public PollutantList PollutantList;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string PermittedFeatureUserDefinedDataElement1;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string PermittedFeatureUserDefinedDataElement2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 FieldSize;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string IsSiteOwnByFacility;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string IsSystemLinedWithLeachate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string DoesUnitHaveDailyCover;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 PropertyBoundaryDistance;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string IsRequiredNitrateGroundWater;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 WellNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        public GeographicCoordinates GeographicCoordinates;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(200)]
        public string SourcePermittedFeatureDetailText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 23)]
        public CoolingWaterIntakeStructureInformation CoolingWaterIntakeStructureInformation;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 24)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Contact[] SiteOwnerContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 25)]
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
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(6)]
        public string TMDLIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string TMDLName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TMDLPollutantCode", DataType = "nonNegativeInteger", Order = 2)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32[] TMDLPollutantCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class CoolingWaterIntakeStructureInformation
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 CoolingWaterIntakeStructureApplicableSubpart;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CoolingWaterIntakeStructureComplianceMethod", Order = 1)]
        public CoolingWaterIntakeStructureComplianceMethod[] CoolingWaterIntakeStructureComplianceMethod;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public CoolingWaterIntakeStructureLocation CoolingWaterIntakeStructureLocation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public CoolingWaterIntakeStructureSourceWater CoolingWaterIntakeStructureSourceWater;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("15", "7")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal CoolingWaterIntakeStructureDesignIntakeFlow;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("15", "7")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal CoolingWaterIntakeStructureActualIntakeFlow;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("6", "2")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal CoolingWaterActualIntakeStructureVelocity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(8000)]
        public string SourceWaterBaselineBiologicalCharacterization;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class CoolingWaterIntakeStructureComplianceMethod
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string CoolingWaterIntakeStructureComplianceMethodCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(500)]
        public string CoolingWaterIntakeStructureComplianceMethodText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class CoolingWaterIntakeStructureLocation
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string CoolingWaterIntakeStructureLocationCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(500)]
        public string CoolingWaterIntakeStructureLocationText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class CoolingWaterIntakeStructureSourceWater
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string CoolingWaterIntakeStructureSourceWaterCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(500)]
        public string CoolingWaterIntakeStructureSourceWaterText;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CollectionSystemPermit))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class CollectionSystemKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(20)]
        public string CollectionSystemIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class CollectionSystemPermit : CollectionSystemKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string CollectionSystemName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string CollectionSystemOwnerTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 CollectionSystemPopulation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("4", "1")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal PercentCollectionSystemCSS;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class ProgramInspectionKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
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
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string ReportableNonComplianceResolutionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ReportableNonComplianceResolutionDate;
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
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
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
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string FacilityInspectionSummaryText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string VisualAssessmentSummaryText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string NoFurtherReductionSummaryText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string CorrectiveActionSummaryText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class AnalyticalMethods
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AnalyticalMethodData", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public AnalyticalMethodData[] AnalyticalMethodData;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class BiosolidsManagementPractice
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("BiosolidsManagementPracticeData", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public BiosolidsManagementPracticeData[] BiosolidsManagementPracticeData;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class BiosolidsSewageSludgeMaximumPollutantLimit
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("BiosolidsSewageSludgeParameter", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public BiosolidsSewageSludgeParameter[] BiosolidsSewageSludgeParameter;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class BiosolidsSewageSludgeMaximumPollutantConcentrations
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("BiosolidsSewageSludgeParameter", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public BiosolidsSewageSludgeParameter[] BiosolidsSewageSludgeParameter;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class BiosolidsSewageSludgeAveragePollutantConcentrations
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("BiosolidsSewageSludgeParameter", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public BiosolidsSewageSludgeParameter[] BiosolidsSewageSludgeParameter;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class BiosolidsSewageSludgePathogenMonitoring
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("BiosolidsSewageSludgeParameter", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public BiosolidsSewageSludgeParameter[] BiosolidsSewageSludgeParameter;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class BiosolidsSewageSludgeVARMonitoring
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("BiosolidsSewageSludgeParameter", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public BiosolidsSewageSludgeParameter[] BiosolidsSewageSludgeParameter;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class BiosolidsIncineratorEmissionsControlTechnology
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("BiosolidsIncineratorEmissionsControlType", Order = 0)]
        public BiosolidsIncineratorEmissionsControlType[] BiosolidsIncineratorEmissionsControlType;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class BiosolidsAirEmissionsPollutantMonitoring
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("BiosolidsSewageSludgeParameter", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public BiosolidsSewageSludgeParameter[] BiosolidsSewageSludgeParameter;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class BiosolidsIncinerationProcessControlMonitoring
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("BiosolidsSewageSludgeParameter", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public BiosolidsSewageSludgeParameter[] BiosolidsSewageSludgeParameter;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class BiosolidsIncinerationFeedMonitoring
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("BiosolidsSewageSludgeParameter", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public BiosolidsSewageSludgeParameter[] BiosolidsSewageSludgeParameter;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class BiosolidsIncinerationFeedLimits
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("BiosolidsSewageSludgeParameter", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public BiosolidsSewageSludgeParameter[] BiosolidsSewageSludgeParameter;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class PermitBiosolidsManagementPractice
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PermitBiosolidsManagementPracticeData", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public PermitBiosolidsManagementPracticeData[] PermitBiosolidsManagementPracticeData;
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
    public partial class LinkageCAFOAnnualReport
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        public System.DateTime PermittingAuthorityReportReceivedDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class MS4IllicitDetectionRegulatedEntityInformationProgramReport
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(40)]
        public string MS4ActivityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate MS4ProgramReportIllicitDetectionOutfallMappingDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 MS4ProgramReportIllicitDetectionOutfallTotalNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 MS4ProgramReportIllicitDetectionOutfallMappedNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string MS4RegulatedEntityComplianceStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(2000)]
        public string MS4RegulatedEntityComplianceStatusText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(8000)]
        public string MS4ProgramReportRequirementsActivities;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class MS4ProgramReportAnalysis
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MS4RegulatedEntityIdentifier", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(40)]
        public string[] MS4RegulatedEntityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(8000)]
        public string MS4ProgramReportAnalysisText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class MS4ProgramReportRequirementsRegulatedEntity
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(40)]
        public string MS4ActivityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MS4RegulatedEntityIdentifier", Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(40)]
        public string[] MS4RegulatedEntityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string MS4RegulatedEntityComplianceStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(2000)]
        public string MS4RegulatedEntityComplianceStatusText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(8000)]
        public string MS4ProgramReportRequirementsActivities;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class MS4RegulatedEntityEnforcement
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(40)]
        public string MS4RegulatedEntityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MS4RegulatedEntityEnforcementActions", Order = 1)]
        public MS4RegulatedEntityEnforcementActions[] MS4RegulatedEntityEnforcementActions;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class MS4RegulatedEntityEnforcementActions
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string MS4RegulatedEntityEnforcementActionTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(500)]
        public string MS4RegulatedEntityEnforcementActionTypeCodeOtherText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class MS4SWMPChanges
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(40)]
        public string MS4RegulatedEntityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string MS4SWMPChangeIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string MS4SWMPChangeIndicatorText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class TreatmentChemicalsList
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TreatmentChemicalName", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(2000)]
        public string[] TreatmentChemicalName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class ImpairedWaterPollutants
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ImpairedWaterPollutantCode", DataType = "nonNegativeInteger", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32[] ImpairedWaterPollutantCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class CopyMGPMS4Requirement
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public MasterGeneralPermitMS4Requirement MasterGeneralPermitMS4Requirement;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("GeneralPermitCoverageMS4Requirement", Order = 1)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public GeneralPermitCoverageMS4Requirement[] GeneralPermitCoverageMS4Requirement;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class MasterGeneralPermitMS4Requirement
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MS4ActivityIdentifier", Order = 1)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(40)]
        public string[] MS4ActivityIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class GeneralPermitCoverageMS4Requirement
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MS4RegulatedEntityIdentifier", Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(40)]
        public string[] MS4RegulatedEntityIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class CWA316bProgramReport : CWA316bProgramReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 ProgramReportFormID;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ProgramReportReceivedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ProgramReportStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ProgramReportEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string ElectronicSubmissionTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string ProgramReportNPDESDataGroupNumberCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(8000)]
        public string CWA316bCriticalHabitatProtectionMeasures;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(8000)]
        public string CWA316bOtherMonitoringInformation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public CWA316bTakeInformation CWA316bTakeInformation;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class CWA316bTakeInformation
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(20)]
        public string CWA316bTakeIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string CWA316bSpeciesName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string CWA316bSpeciesCommonName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string CWA316bFederalStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string CWA316bLifestageCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string CWA316bTakeMethodCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(500)]
        public string CWA316bTakeMethodOtherText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string CWA316bTakeTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(500)]
        public string CWA316bTakeTypeOtherText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 CWA316bSpeciesNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 CWA316bSpeciesNumberImpingedEntrained;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate CWA316bSpeciesNumberImpingedEntrainedDate;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CWA316bProgramReport))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class CWA316bProgramReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string ProgramReportFormSetID;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class EffluentTradePartner : EffluentTradePartnerKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string TradePartnerNPDESID;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string TradePartnerOtherID;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
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
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate TradePartnerEndDate;
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
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
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
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 LimitSeasonNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 6)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public System.DateTime LimitStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 7)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public System.DateTime LimitEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate LimitModificationEffectiveDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string TradeID;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class NPDESVariancePermit : NPDESVariancePermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(3)]
        public string NPDESVarianceVersionType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(3)]
        public string NPDESVarianceStatusCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate NPDESVarianceActionDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string ThermalVarianceRequestPublicNoticeIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(500)]
        public string NPDESVarianceCommentText;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(NPDESVariancePermit))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class NPDESVariancePermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string NPDESVarianceTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate NPDESVarianceSubmissionDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class PretreatmentProgramReport : PretreatmentProgramReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 ProgramReportFormID;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ProgramReportReceivedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ProgramReportStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ProgramReportEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string ElectronicSubmissionTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string ProgramReportNPDESDataGroupNumberCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public ControlAuthorityProgramInformation ControlAuthorityProgramInformation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public IndustrialUserInventory IndustrialUserInventory;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class ControlAuthorityProgramInformation
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate LocalLimitsAdoptionDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate LocalLimitsEvaluationDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 2)]
        [System.Xml.Serialization.XmlArrayItemAttribute("LocalLimitsParameterCode", IsNullable = false)]
        public string[] LocalLimitsParameters;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public POTWDischargeContamination POTWDischargeContamination;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public POTWBiosolidsContamination POTWBiosolidsContamination;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class POTWDischargeContamination
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string POTWDischargeContaminationIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(500)]
        public string POTWDischargeContaminationText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class POTWBiosolidsContamination
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string POTWBiosolidsContaminationIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(500)]
        public string POTWBiosolidsContaminationText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class IndustrialUserInventory
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string IndustrialUserIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("IndustrialUserInformation", Order = 1)]
        public IndustrialUserInformation[] IndustrialUserInformation;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class IndustrialUserInformation
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 IUAverageDailyWastewaterFlowRateGPD;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 IUAverageDailyProcessWastewaterFlowRateGPD;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string IUSubjectLocalLimitsIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string IUSubjectLocalLimitsMoreStringentCatStdIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string MTCIUSubjectReducedReportingIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public IUComplianceMonitoring IUComplianceMonitoring;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public IUViolationInformation IUViolationInformation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public IUEnforcementActionInformation IUEnforcementActionInformation;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class IUComplianceMonitoring
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 NumberIUInspectionsByCA;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 NumberIUSamplingEventsByCA;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 NumberReqdIUSelfMonEventsMaximum;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string IUComplyReqSelfMonRptingIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(500)]
        public string IUComplyReqSelfMonRptingText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string NSCIUCertSubmToCAIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string ChangedDischSubmIndicator;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class IUViolationInformation
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string SNCPretrStndLimitsIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 1)]
        [System.Xml.Serialization.XmlArrayItemAttribute("SNCPretrStndLimitsParameterCode", IsNullable = false)]
        public string[] SNCPretrStndLimitsParameters;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string SNCRptRqmtIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string SNCOthCtrlMechRqmtIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string SNCRelPOTWDischOperIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string SNCRelPOTWDischOperText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string SNCRelPOTWBioOperSewgSludMgmtIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string SNCRelPOTWBioOperSewgSludMgmtText;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 8)]
        [System.Xml.Serialization.XmlArrayItemAttribute("SNCListingMonthYear", IsNullable = false)]
        public string[] SNCListingMonths;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string SNCPublishedIndicator;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class IUEnforcementActionInformation
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("IUEnfActionTypes", Order = 0)]
        public IUEnfActionTypes[] IUEnfActionTypes;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string SNCPretrEnfCmplSchedStatusIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("14", "2")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal IUCashCivilPenaltyAmountAssessed;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("14", "2")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal IUCashCivilPenaltyAmountCollected;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class IUEnfActionTypes
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string IUEnfActionTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(500)]
        public string IUEnfActionTypeOtherText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 NumIUEnfActions;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PretreatmentProgramReport))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class PretreatmentProgramReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string ProgramReportFormSetID;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class LocalLimitsParameters
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LocalLimitsParameterCode", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
        public string[] LocalLimitsParameterCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SNCListingMonths
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SNCListingMonthYear", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(7)]
        public string[] SNCListingMonthYear;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SNCPretrStndLimitsParameters
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SNCPretrStndLimitsParameterCode", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
        public string[] SNCPretrStndLimitsParameterCode;
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
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(6)]
        public string InformationCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The type of information or warning that is being returned.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(11)]
        public InformationTypeCodeDataType InformationTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("A human readable description on a information or warning.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
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
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(7)]
        public string ErrorCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The type of error that is being returned.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(5)]
        public ErrorTypeCodeDataType ErrorTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("A human readable description on an error.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
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
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(5)]
        public ErrorTypeCodeDataType ErrorTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A human readable description on an error.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
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
    [System.Xml.Serialization.XmlRootAttribute("CAFOAnnualProgramReportIdentifier", Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class CAFOAnnualReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        public System.DateTime PermittingAuthorityReportReceivedDate;
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
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public SubmissionTransactionTypeCodeDataType SubmissionTransactionTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Unique number that identifies the total count of accepted records by transaction " +
            "type.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 TotalAcceptedTransactions;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Unique number that identifies the total count of rejected records by transaction " +
            "type.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 TotalRejectedTransactions;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute("SubmissionErrorKey", Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SubmissionErrorKeyDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a biosolids annual program report by including all the approp" +
            "riate keys for it.")]
        public BiosolidsAnnualProgramReportKeyElements BiosolidsAnnualProgramReportIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a CAFO annual program report by including all the appropriate" +
            " keys for it.")]
        public CAFOAnnualReportKeyElements CAFOAnnualProgramReportIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a case file linkage by including all the appropriate keys for" +
            " it. The type definition is found in the Case File Linkage xsd file.")]
        public CaseFileLinkage CaseFileLinkageIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a compliance monitoring linkage by including all the appropri" +
            "ate keys for it. The type definition is found in the CMLinkage xsd file.")]
        public ComplianceMonitoringLinkage ComplianceMonitoringLinkageIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a compliance schedule by including all the appropriate keys f" +
            "or it.")]
        public ComplianceScheduleKeyElements ComplianceScheduleIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a compliance schedule event by including all the appropriate " +
            "keys for it.")]
        public ComplianceScheduleEventKeyElements ComplianceScheduleEventIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a Copy Master General Permit Limit Set by including all the a" +
            "ppropriate keys for it.")]
        public CopyMGPLimitSetIdentifier CopyMGPLimitSetIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a DMR by including all the appropriate keys for it.")]
        public DischargeMonitoringReportKeyElements DischargeMonitoringReportIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a parameter within a specific DMR by including all the approp" +
            "riate keys for it. The type is defined in EAViolationLinkage xsd.")]
        public DischargeMonitoringReportParameterViolation DMRParameterIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a DMR violation by including all the appropriate keys.")]
        public DMRViolationKeyElements DMRViolationIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies an Effluent Trade Partner by including all the appropriate ke" +
            "ys for it.")]
        public EffluentTradePartnerKeyElements EffluentTradePartnerReportIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies an Enforcement Action Milestone by including all the appropri" +
            "ate keys for it.")]
        public EnforcementActionMilestoneKeyElements EnforcementActionMilestoneReportIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies an Enforcement Action Violation Linkage by including all the " +
            "appropriate keys for it. The type is defined in EAViolationLinkage xsd.")]
        public EnforcementActionViolationLinkage EnforcementActionViolationLinkageIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies an Enforcement Action Violation Linkage by including all the " +
            "appropriate keys for it. The type is defined in the FO ViolationLinkage xsd.")]
        public FinalOrderViolationLinkage FinalOrderViolationLinkageIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a Formal Enforcement Action by including all the appropriate " +
            "keys for it.")]
        public EnforcementActionKeyElements FormalEnforcementActionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a Historical Permit Schedule Event by including all the appro" +
            "priate keys for it.")]
        public HistoricalPermitScheduleKeyElements HistoricalPermitScheduleEventIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies an Informal Enforcement Action by including all the appropria" +
            "te keys for it.")]
        public EnforcementActionKeyElements InformalEnforcementActionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a limit segment by including all the appropriate keys for the" +
            " limit segment.")]
        public LimitKeyElements LimitSegmentIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a limit set by including all the appropriate keys for the lim" +
            "it set.")]
        public LimitSetKeyElements LimitSetIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a narrative condition and its schedules by including all the " +
            "appropriate keys for the narrative condition.")]
        public PermitScheduleKeyElements NarrativeConditionScheduleIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a parameter limit by including all the appropriate keys for t" +
            "he parameter limit.")]
        public ParameterLimitKeyElements ParameterLimitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a permit by including the appropriate key for the it.")]
        public BasicPermitKeyElements PermitRecordIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a permit tracking event by including all the appropriate keys" +
            " for the permit tracking event.")]
        public PermitTrackingEventKeyElements PermitTrackingEventIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 23)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a permitted feature by including all the appropriate keys for" +
            " the permitted feature.")]
        public PermittedFeatureKeyElements PermittedFeatureRecordIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 24)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a Schedule Event Violation by including all the appropriate k" +
            "eys for it.")]
        public ScheduleEventViolationKeyElements ScheduleEventViolationIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 25)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a Single Event Violation by including all the appropriate key" +
            "s for it.")]
        public SingleEventKeyElements SingleEventIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 26)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a state NPDES compliance monitoring activity by including all" +
            " the appropriate keys for it.")]
        public ComplianceMonitoringKeyElements StateNPDESComplianceMonitoringIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 27)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a Storm Water Industrial Annual Report by including all the a" +
            "ppropriate keys for it.")]
        public SWIndustrialAnnualReportKeyElements SWIndustrialAnnualReportIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 28)]
        [System.ComponentModel.DescriptionAttribute("The type of transaction that was sent in the submission.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
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
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
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
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a biosolids annual program report by including all the approp" +
            "riate keys for it.")]
        public BiosolidsAnnualProgramReportKeyElements BiosolidsAnnualProgramReportIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a CAFO annual program report by including all the appropriate" +
            " keys for it.")]
        public CAFOAnnualReportKeyElements CAFOAnnualProgramReportIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a case file linkage by including all the appropriate keys for" +
            " it. The type definition is found in the Case File Linkage xsd file.")]
        public CaseFileLinkage CaseFileLinkageIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a compliance monitoring linkage by including all the appropri" +
            "ate keys for it. The type definition is found in the CMLinkage xsd file.")]
        public ComplianceMonitoringLinkage ComplianceMonitoringLinkageIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a compliance schedule by including all the appropriate keys f" +
            "or it.")]
        public ComplianceScheduleKeyElements ComplianceScheduleIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a compliance schedule event by including all the appropriate " +
            "keys for it.")]
        public ComplianceScheduleEventKeyElements ComplianceScheduleEventIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a Copy Master General Permit Limit Set by including all the a" +
            "ppropriate keys for it.")]
        public CopyMGPLimitSetIdentifier CopyMGPLimitSetIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a DMR by including all the appropriate keys for it.")]
        public DischargeMonitoringReportKeyElements DischargeMonitoringReportIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a parameter within a specific DMR by including all the approp" +
            "riate keys for it. The type is defined in EAViolationLinkage xsd.")]
        public DischargeMonitoringReportParameterViolation DMRParameterIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a DMR violation by including all the appropriate keys.")]
        public DMRViolationKeyElements DMRViolationIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies an Effluent Trade Partner by including all the appropriate ke" +
            "ys for it.")]
        public EffluentTradePartnerKeyElements EffluentTradePartnerReportIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies an Enforcement Action Milestone by including all the appropri" +
            "ate keys for it.")]
        public EnforcementActionMilestoneKeyElements EnforcementActionMilestoneReportIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies an Enforcement Action Violation Linkage by including all the " +
            "appropriate keys for it. The type is defined in EAViolationLinkage xsd.")]
        public EnforcementActionViolationLinkage EnforcementActionViolationLinkageIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies an Enforcement Action Violation Linkage by including all the " +
            "appropriate keys for it. The type is defined in the FO ViolationLinkage xsd.")]
        public FinalOrderViolationLinkage FinalOrderViolationLinkageIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a Formal Enforcement Action by including all the appropriate " +
            "keys for it.")]
        public EnforcementActionKeyElements FormalEnforcementActionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a Historical Permit Schedule Event by including all the appro" +
            "priate keys for it.")]
        public HistoricalPermitScheduleKeyElements HistoricalPermitScheduleEventIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies an Informal Enforcement Action by including all the appropria" +
            "te keys for it.")]
        public EnforcementActionKeyElements InformalEnforcementActionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a limit segment by including all the appropriate keys for the" +
            " limit segment.")]
        public LimitKeyElements LimitSegmentIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a limit set by including all the appropriate keys for the lim" +
            "it set.")]
        public LimitSetKeyElements LimitSetIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a narrative condition and its schedules by including all the " +
            "appropriate keys for the narrative condition.")]
        public PermitScheduleKeyElements NarrativeConditionScheduleIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a parameter limit by including all the appropriate keys for t" +
            "he parameter limit.")]
        public ParameterLimitKeyElements ParameterLimitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a permit by including the appropriate key for the it.")]
        public BasicPermitKeyElements PermitRecordIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a permit tracking event by including all the appropriate keys" +
            " for the permit tracking event.")]
        public PermitTrackingEventKeyElements PermitTrackingEventIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 23)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a permitted feature by including all the appropriate keys for" +
            " the permitted feature.")]
        public PermittedFeatureKeyElements PermittedFeatureRecordIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 24)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a Schedule Event Violation by including all the appropriate k" +
            "eys for it.")]
        public ScheduleEventViolationKeyElements ScheduleEventViolationIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 25)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a Single Event Violation by including all the appropriate key" +
            "s for it.")]
        public SingleEventKeyElements SingleEventIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 26)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a state NPDES compliance monitoring activity by including all" +
            " the appropriate keys for it.")]
        public ComplianceMonitoringKeyElements StateNPDESComplianceMonitoringIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 27)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a Storm Water Industrial Annual Report by including all the a" +
            "ppropriate keys for it.")]
        public SWIndustrialAnnualReportKeyElements SWIndustrialAnnualReportIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 28)]
        [System.ComponentModel.DescriptionAttribute("The type of transaction that was sent in the submission.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
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
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public TransactionTypeTotalsDataType[] TransactionTypeTotals;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The total amount of transactions that were accepted and rejected by ICIS for a gi" +
            "ven user within the same batch submission.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 TotalTransactions;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Percent of TotalTransactions that were accepted. The reports show 2 decimal place" +
            "s max.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("5", "2")]
        public decimal PercentTransactionsAccepted;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Unique number that identifies the total count of records for an entire submission" +
            ".")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 TotalSubmissions;
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
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(40)]
        public string TransactionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The date something was submitted.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public System.DateTime SubmissionDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The date something was created.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
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
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string UserID;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SubmissionType", Order = 1)]
        public SubmissionTypeDataType[] SubmissionType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Unique number that identifies the total transaction of records for an entire batc" +
            "h.")]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 BatchTotalTransactions;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Unique number that identifies the total count of records for an entire submission" +
            ".")]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 BatchTotalSubmissions;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Unique number that identifies the total percent of transactions that were accepte" +
            "d.")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("5", "2")]
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
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string SubmissionTypeName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SubmissionErrors", typeof(SubmissionErrorsDataType), Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute("SubmissionSummary", typeof(SubmissionSummaryDataType), Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute("SubmissionsAccepted", typeof(SubmissionsAcceptedDataType), Order = 1)]
        public object[] Items;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SewerOverflowBypassEventReportData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public SewerOverflowBypassReport SewerOverflowBypassReport;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SewerOverflowBypassReport
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string ProgramReportFormSetID;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 ProgramReportFormID;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ProgramReportReceivedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ProgramReportStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ProgramReportEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string ElectronicSubmissionTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string ProgramReportNPDESDataGroupNumberCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SewerOverflowBypassReportEvent", Order = 8)]
        public SewerOverflowBypassReportEvent[] SewerOverflowBypassReportEvent;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SewerOverflowBypassReportEvent
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 SewerOverflowBypassEventID;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(1000)]
        public string SewerOverflowBypassDescriptionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 SewerOverflowBypassReportingRequirementCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SewerOverflowBypassTypeCode", Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] SewerOverflowBypassTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string WetWeatherOccuranceIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string SewerOverflowStructureTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string SewerOverflowStructureTypeCodeOtherText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SewerOverflowBypassReceivingWater", Order = 7)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(1000)]
        public string[] SewerOverflowBypassReceivingWater;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(20)]
        public string CollectionSystemIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SewerOverflowTreatmentCode", Order = 9)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] SewerOverflowTreatmentCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("BypassTreatmentPlantEquipmentCode", Order = 10)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] BypassTreatmentPlantEquipmentCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(1000)]
        public string AnticipatedBypassText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string AnticipatedBypassExpectLimitViolation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(1000)]
        public string AnticipatedBypassExpectLimitViolationText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        public SewerOverflowLocationDetail SewerOverflowLocationDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        public SewerOverflowBypassDurationDetail SewerOverflowBypassDurationDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        public SewerOverflowBypassVolumeDetail SewerOverflowBypassVolumeDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SewerOverflowBypassCause", Order = 17)]
        public SewerOverflowBypassCause[] SewerOverflowBypassCause;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SewerOverflowBypassCorrectiveAction", Order = 18)]
        public SewerOverflowBypassCorrectiveAction[] SewerOverflowBypassCorrectiveAction;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SewerOverflowBypassImpact", Order = 19)]
        public SewerOverflowBypassImpact[] SewerOverflowBypassImpact;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SewerOverflowLocationDetail
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LatitudeMeasure", typeof(string), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("LongitudeMeasure", typeof(string), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("PermittedFeatureIdentifier", typeof(string), Order = 0)]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        public string[] Items;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName", Order = 1)]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemsChoiceType3[] ItemsElementName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IncludeInSchema = false)]
    public enum ItemsChoiceType3
    {

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(10)]
        LatitudeMeasure,

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(11)]
        LongitudeMeasure,

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4)]
        PermittedFeatureIdentifier,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SewerOverflowBypassDurationDetail
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("7", "2")]
        public decimal SewerOverflowBypassDurationHours;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public SewerOverflowBypassDurationDateTime SewerOverflowBypassDurationDateTime;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SewerOverflowBypassDurationDateTime
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public System.DateTime SewerOverflowBypassStartDateTime;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public System.DateTime SewerOverflowBypassEndDateTime;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SewerOverflowBypassEndDateTimeSpecified;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SewerOverflowBypassVolumeDetail
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string DischargeQuantificationMethodCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SewerOverflowBypassDischargeRateGPH", typeof(decimal), Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute("SewerOverflowBypassDischargeVolumeGallons", typeof(decimal), Order = 1)]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
        public decimal Item;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemChoiceType ItemElementName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IncludeInSchema = false)]
    public enum ItemChoiceType
    {

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("9", "1")]
        SewerOverflowBypassDischargeRateGPH,

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("13", "1")]
        SewerOverflowBypassDischargeVolumeGallons,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SewerOverflowBypassCause
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string SewerOverflowBypassCauseCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string SewerOverflowBypassCauseOtherText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SewerOverflowBypassCorrectiveAction
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string SewerOverflowBypassCorrectiveActionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string SewerOverflowBypassCorrectiveActionOtherText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SewerOverflowBypassImpact
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string SewerOverflowBypassImpactCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string SewerOverflowBypassImpactOtherText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SWMS4AnnualProgramReport : SWMS4AnnualProgramReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 ProgramReportFormID;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ProgramReportReceivedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ProgramReportStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ProgramReportEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string ElectronicSubmissionTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string ProgramReportNPDESDataGroupNumberCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MS4IllicitDetectionRegulatedEntityInformationProgramReport", Order = 6)]
        public MS4IllicitDetectionRegulatedEntityInformationProgramReport[] MS4IllicitDetectionRegulatedEntityInformationProgramReport;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MS4ProgramReportRequirementsRegulatedEntity", Order = 7)]
        public MS4ProgramReportRequirementsRegulatedEntity[] MS4ProgramReportRequirementsRegulatedEntity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MS4SWMPChanges", Order = 8)]
        public MS4SWMPChanges[] MS4SWMPChanges;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MS4RegulatedEntityEnforcement", Order = 9)]
        public MS4RegulatedEntityEnforcement[] MS4RegulatedEntityEnforcement;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MS4ProgramReportAnalysis", Order = 10)]
        public MS4ProgramReportAnalysis[] MS4ProgramReportAnalysis;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SWMS4AnnualProgramReport))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class SWMS4AnnualProgramReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string ProgramReportFormSetID;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class Document
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public HeaderData Header;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Payload", Order = 1)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public PayloadData[] Payload;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class HeaderData
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class PayloadData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("BasicPermitData", typeof(BasicPermitData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("BiosolidsAnnualProgramReportData", typeof(BiosolidsAnnualProgramReportData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("BiosolidsPermitData", typeof(BiosolidsPermitData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("CAFOAnnualProgramReportData", typeof(CAFOAnnualProgramReportData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("CAFOPermitData", typeof(CAFOPermitData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("CSOLongTermControlPlanData", typeof(CSOLongTermControlPlanData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("CWA316bProgramReportData", typeof(CWA316bProgramReportData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("CaseFileLinkageData", typeof(CaseFileLinkageData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("CollectionSystemPermitData", typeof(CollectionSystemPermitData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("ComplianceMonitoringData", typeof(ComplianceMonitoringData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("ComplianceMonitoringLinkageData", typeof(ComplianceMonitoringLinkageData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("ComplianceScheduleData", typeof(ComplianceScheduleData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("CopyMGPLimitSetData", typeof(CopyMGPLimitSetData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("CopyMGPMS4RequirementData", typeof(CopyMGPMS4RequirementData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("DMRViolationData", typeof(DMRViolationData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("DischargeMonitoringReportData", typeof(DischargeMonitoringReportData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("EffluentTradePartnerData", typeof(EffluentTradePartnerData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("EnforcementActionMilestoneData", typeof(EnforcementActionMilestoneData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("EnforcementActionViolationLinkageData", typeof(EnforcementActionViolationLinkageData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("FinalOrderViolationLinkageData", typeof(FinalOrderViolationLinkageData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("FormalEnforcementActionData", typeof(FormalEnforcementActionData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("GeneralPermitData", typeof(GeneralPermitData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("HistoricalPermitScheduleEventsData", typeof(HistoricalPermitScheduleEventsData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("InformalEnforcementActionData", typeof(InformalEnforcementActionData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("LimitSetData", typeof(LimitSetData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("LimitsData", typeof(LimitsData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("MasterGeneralPermitData", typeof(MasterGeneralPermitData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("NPDESVariancePermitData", typeof(NPDESVariancePermitData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("NarrativeConditionScheduleData", typeof(NarrativeConditionScheduleData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("POTWPermitData", typeof(POTWPermitData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("POTWTreatmentTechnologyPermitData", typeof(POTWTreatmentTechnologyPermitData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("ParameterLimitsData", typeof(ParameterLimitsData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("PermitReissuanceData", typeof(PermitReissuanceData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("PermitTerminationData", typeof(PermitTerminationData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("PermitTrackingEventData", typeof(PermitTrackingEventData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("PermittedFeatureData", typeof(PermittedFeatureData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("PretreatmentPermitData", typeof(PretreatmentPermitData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("PretreatmentProgramReportData", typeof(PretreatmentProgramReportData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("SWConstructionPermitData", typeof(SWConstructionPermitData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("SWIndustrialAnnualReportData", typeof(SWIndustrialAnnualReportData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("SWIndustrialPermitData", typeof(SWIndustrialPermitData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("SWMS4AnnualProgramReportData", typeof(SWMS4AnnualProgramReportData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("SWMS4PermitData", typeof(SWMS4PermitData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("ScheduleEventViolationData", typeof(ScheduleEventViolationData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("SewerOverflowBypassEventReportData", typeof(SewerOverflowBypassEventReportData), Order = 0)]
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
    public partial class BasicPermitData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
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
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
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
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public BiosolidsPermit BiosolidsPermit;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class CAFOAnnualProgramReportData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public CAFOAnnualProgramReport CAFOAnnualProgramReport;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class CAFOPermitData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public CAFOPermit CAFOPermit;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class CSOLongTermControlPlanData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public LTCPPermit LTCPPermit;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class CWA316bProgramReportData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public CWA316bProgramReport CWA316bProgramReport;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class CaseFileLinkageData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public CaseFileLinkage CaseFileLinkage;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class CollectionSystemPermitData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public CollectionSystemPermit CollectionSystemPermit;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class ComplianceMonitoringData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
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
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
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
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
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
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public CopyMGPLimitSet CopyMGPLimitSet;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class CopyMGPMS4RequirementData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public CopyMGPMS4Requirement CopyMGPMS4Requirement;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class DMRViolationData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
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
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
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
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
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
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
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
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public EnforcementActionViolationLinkage EnforcementActionViolationLinkage;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class FinalOrderViolationLinkageData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
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
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
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
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
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
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
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
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
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
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
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
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public Limits Limits;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class MasterGeneralPermitData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public MasterGeneralPermit MasterGeneralPermit;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class NPDESVariancePermitData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public NPDESVariancePermit NPDESVariancePermit;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class NarrativeConditionScheduleData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
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
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public POTWPermit POTWPermit;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class POTWTreatmentTechnologyPermitData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public POTWTreatmentTechnologyPermit POTWTreatmentTechnologyPermit;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class ParameterLimitsData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
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
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
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
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
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
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
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
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public PermittedFeature PermittedFeature;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class PretreatmentPermitData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public PretreatmentPermit PretreatmentPermit;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class PretreatmentProgramReportData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public PretreatmentProgramReport PretreatmentProgramReport;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class SWConstructionPermitData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public SWConstructionPermit SWConstructionPermit;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class SWIndustrialAnnualReportData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
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
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public SWIndustrialPermit SWIndustrialPermit;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class SWMS4AnnualProgramReportData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public SWMS4AnnualProgramReport SWMS4AnnualProgramReport;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class SWMS4PermitData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public SWMS4Permit SWMS4Permit;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class ScheduleEventViolationData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
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
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
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
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public UnpermittedFacility UnpermittedFacility;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public enum OperationType
    {

        /// <remarks/>
        BasicPermitSubmission,

        /// <remarks/>
        BiosolidsAnnualProgramReportSubmission,

        /// <remarks/>
        BiosolidsPermitSubmission,

        /// <remarks/>
        CaseFileLinkageSubmission,

        /// <remarks/>
        CAFOPermitSubmission,

        /// <remarks/>
        CollectionSystemPermitSubmission,

        /// <remarks/>
        ComplianceMonitoringLinkageSubmission,

        /// <remarks/>
        ComplianceMonitoringSubmission,

        /// <remarks/>
        ComplianceScheduleSubmission,

        /// <remarks/>
        CopyMGPLimitSetSubmission,

        /// <remarks/>
        CopyMGPMS4RequirementSubmission,

        /// <remarks/>
        CSOLongTermControlPlanSubmission,

        /// <remarks/>
        CWA316bProgramReportSubmission,

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
        MasterGeneralPermitSubmission,

        /// <remarks/>
        NarrativeConditionScheduleSubmission,

        /// <remarks/>
        NPDESVariancePermitSubmission,

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
        POTWTreatmentTechnologyPermitSubmission,

        /// <remarks/>
        PretreatmentPermitSubmission,

        /// <remarks/>
        PretreatmentProgramReportSubmission,

        /// <remarks/>
        ScheduleEventViolationSubmission,

        /// <remarks/>
        SewerOverflowBypassEventReportSubmission,

        /// <remarks/>
        SingleEventViolationSubmission,

        /// <remarks/>
        SWConstructionPermitSubmission,

        /// <remarks/>
        SWIndustrialAnnualReportSubmission,

        /// <remarks/>
        SWIndustrialPermitSubmission,

        /// <remarks/>
        SWMS4PermitSubmission,

        /// <remarks/>
        SWMS4AnnualProgramReportSubmission,

        /// <remarks/>
        UnpermittedFacilitySubmission,
    }
}
