//#define ONLY_NV_TYPES
namespace Windsor.Node2008.WNOSPlugin.ICISNPDES_56
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
        public Contact[] Contact;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class GovernmentContact
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string ElectronicAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string AffiliationTypeText;
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
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SWMS4SmallPermit))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SWConstructionPermit))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SWMS4LargePermit))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PretreatmentPermit))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(POTWPermit))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PermitTermination))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PermitReissuance))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(MasterGeneralPermit))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(GeneralPermit))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CSOPermit))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SWIndustrialPermit))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CAFOPermit))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(BiosolidsPermit))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(BasicPermit))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ProgramInspectionKeyElements))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PermitTrackingEventKeyElements))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PermitTrackingEvent))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PermittedFeatureKeyElements))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PermittedFeature))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PermitScheduleEventViolationKeyElements))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ParameterLimitKeyElements))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ParameterLimits))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LimitSetKeyElements))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LimitSet))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LimitKeyElements))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(Limits))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(HistoricalPermitScheduleKeyElements))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(HistoricalPermitScheduleEvents))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(EffluentTradePartnerKeyElements))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(EffluentTradePartner))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(DMRViolationKeyElements))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(DMRViolation))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SWMS4ProgramReportKeyElements))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LinkageSWMS4Report))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SWMS4ProgramReport))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SSOMonthlyEventReportKeyElements))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SSOMonthlyEventReport))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LinkageSSOMonthlyEventReport))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SSOEventReportKeyElements))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SSOEventReport))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LinkageSSOEventReport))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SSOAnnualReportKeyElements))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SSOAnnualReport))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LinkageSSOAnnualReport))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PretreatmentPerformanceSummaryReportKeyElements))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LinkagePretreatmentPerformanceReport))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PretreatmentPerformanceSummary))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LocalLimitsProgramReportKeyElements))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LinkageLocalLimitsReport))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LocalLimitsProgramReport))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CSOEventReportKeyElements))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CSOEventReport))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LinkageCSOEventReport))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SWEventReportKeyElements))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LinkageSWEventReport))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SWEventReport))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(DischargeMonitoringReportKeyElements))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(DischargeMonitoringReportParameterViolation))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(DischargeMonitoringReportViolation))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(DMRProgramReportLinkage))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(DischargeMonitoringReport))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PermitScheduleKeyElements))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(NarrativeCondition))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PermitSchedule))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PermitScheduleViolation))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SingleEventKeyElements))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SingleEventViolation))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SingleEventsViolation))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LinkageSingleEvent))]
    //I don't think these are needed because ComplianceMonitoring and ComplianceMonitoringLinkage no longer use PermitIdentifier as part of their key
    //[System.Xml.Serialization.XmlIncludeAttribute(typeof(ComplianceMonitoringKeyElements))]
    //[System.Xml.Serialization.XmlIncludeAttribute(typeof(ComplianceMonitoring))]
    //[System.Xml.Serialization.XmlIncludeAttribute(typeof(LinkageStateComplianceMonitoring))]
    //[System.Xml.Serialization.XmlIncludeAttribute(typeof(ComplianceMonitoringLinkage))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CAFOAnnualProgramReportKeyElements))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LinkageCAFOAnnualReport))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CAFOAnnualReport))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(BiosolidsProgramReportKeyElements))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LinkageBiosolidsReport))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(BiosolidsProgramReport))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SWIndustrialAnnualReport))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        // TSM: Fix for NV permit identifiers that are larger than 9 chars
        //[Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
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
        public Windsor.Commons.XsdOrm2.SingleLeadingZeroInt32 FacilityCongressionalDistrictNumber;

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
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("9", "7")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_56.RemoveTrailingZerosDecimal ConstructionProjectLatitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("10", "6")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_56.RemoveTrailingZerosDecimal ConstructionProjectLongitudeMeasure;

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
        public Address[] FacilityAddress;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 32)]
        public GeographicCoordinates GeographicCoordinates;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 33)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string PermitCommentsText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PermitComponentTypeCode", Order = 34)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] PermitComponentTypeCode;
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
    public partial class GeographicCoordinates
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("9", "7")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_56.RemoveTrailingZerosDecimal LatitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("10", "6")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_56.RemoveTrailingZerosDecimal LongitudeMeasure;

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
    public partial class SWMS4SmallPermit : BasicPermitKeyElements
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
        public YesNoIndicatorTypeBase ImpairedWaterIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ImpairedWaterIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public YesNoIndicatorTypeBase HistoricPropertyIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool HistoricPropertyIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string HistoricPropertyCriterionMetCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public YesNoIndicatorTypeBase SpeciesCriticalHabitatIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SpeciesCriticalHabitatIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string SpeciesCriterionMetCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("10", "2")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_56.RemoveTrailingZerosDecimal IndustrialActivitySize;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string LegalEntityTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string MS4PermitClassCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string MS4TypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 MS4AcreageCoveredNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 MS4PopulationServedNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string UrbanizedAreaIncorporatedPlaceName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 MS4AnnualExpenditureDollars;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 MS4AnnualExpenditureYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 MS4BudgetDollars;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 MS4BudgetYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string ProjectSourcesOfFundingCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public EstimatedMeasuredType MajorOutfallEstimatedMeasureIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MajorOutfallEstimatedMeasureIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 MajorOutfallNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public EstimatedMeasuredType MinorOutfallEstimatedMeasureIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MinorOutfallEstimatedMeasureIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 MinorOutfallNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 23)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string QualifyingLocalProgramIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 24)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(1000)]
        public string QualifyingLocalProgramDescriptionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 25)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string SharedResponsibilitiesIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 26)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(1000)]
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
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class GPCFConstructionWaiver
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ConstructionWaiverAuthorizationDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string ConstructionWaiverCriteriaMetIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string ConstructionWaiverEvaluationBasisCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ConstructionWaiverEvaluationDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ConstructionWaiverPostmarkDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("6", "1")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_56.RemoveTrailingZerosDecimal ProjectIsoerodentValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ProjectEstimatedStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ProjectEstimatedCompletedDate;
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
        public YesNoIndicatorTypeBase ImpairedWaterIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ImpairedWaterIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public YesNoIndicatorTypeBase HistoricPropertyIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool HistoricPropertyIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string HistoricPropertyCriterionMetCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public YesNoIndicatorTypeBase SpeciesCriticalHabitatIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SpeciesCriticalHabitatIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string SpeciesCriterionMetCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("10", "2")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_56.RemoveTrailingZerosDecimal IndustrialActivitySize;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public GPCFNoticeOfIntent GPCFNoticeOfIntent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public GPCFNoticeOfTermination GPCFNoticeOfTermination;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string ProjectTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate EstimatedStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate EstimatedCompleteDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 EstimatedAreaDisturbedAcresNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string ProjectPlanSizeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 15)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Contact[] StormWaterContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 16)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Address[] StormWaterAddress;
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

        /// <remarks>Added in ICIS v5.0</remarks>
        [System.Xml.Serialization.XmlElementAttribute("SubsectorCodePlusDescription", Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(304)]
        public string[] SubsectorCodePlusDescription;

        /// <remarks>Added in ICIS v5.0</remarks>
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
    public partial class SWMS4LargePermit : BasicPermitKeyElements
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
        public YesNoIndicatorTypeBase ImpairedWaterIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ImpairedWaterIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public YesNoIndicatorTypeBase HistoricPropertyIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool HistoricPropertyIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string HistoricPropertyCriterionMetCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public YesNoIndicatorTypeBase SpeciesCriticalHabitatIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SpeciesCriticalHabitatIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string SpeciesCriterionMetCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("10", "2")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_56.RemoveTrailingZerosDecimal IndustrialActivitySize;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string LegalEntityTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string MS4PermitClassCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string MS4TypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 MS4AcreageCoveredNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 MS4PopulationServedNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string UrbanizedAreaIncorporatedPlaceName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 MS4AnnualExpenditureDollars;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 MS4AnnualExpenditureYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 MS4BudgetDollars;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 MS4BudgetYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string ProjectSourcesOfFundingCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public EstimatedMeasuredType MajorOutfallEstimatedMeasureIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MajorOutfallEstimatedMeasureIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 MajorOutfallNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public EstimatedMeasuredType MinorOutfallEstimatedMeasureIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MinorOutfallEstimatedMeasureIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 MinorOutfallNumber;

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
    public partial class PretreatmentPermit : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public PretreatmentProgramRequiredIndicatorType PretreatmentProgramRequiredIndicatorCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PretreatmentProgramRequiredIndicatorCodeSpecified;

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
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class POTWPermit : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 SSCSPopulationServedNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
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
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
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
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public System.DateTime PermitIssueDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public System.DateTime PermitEffectiveDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 2)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
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
        [System.Xml.Serialization.XmlArrayAttribute(Order = 19)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Contact[] PermitContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string GeneralPermitIndustrialCategory;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(120)]
        public string PermitName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PermitComponentTypeCode", Order = 22)]
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
    public partial class GeneralPermit : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string AssociatedMasterGeneralPermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string PermitTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string AgencyTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(3)]
        public PermitStatusCodeType PermitStatusCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PermitStatusCodeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 4)]
        public System.DateTime PermitIssueDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PermitIssueDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 5)]
        public System.DateTime PermitEffectiveDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PermitEffectiveDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 6)]
        public System.DateTime PermitExpirationDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PermitExpirationDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string ReissuancePriorityPermitIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(2000)]
        public string BacklogReasonText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string PermitIssuingOrganizationTypeName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OtherPermits", Order = 10)]
        public OtherPermits[] OtherPermits;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AssociatedPermit", Order = 11)]
        public AssociatedPermit[] AssociatedPermit;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string PermitAppealedIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SICCodeDetails", Order = 13)]
        public SICCodeDetails[] SICCodeDetails;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NAICSCodeDetails", Order = 14)]
        public NAICSCodeDetails[] NAICSCodeDetails;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string PermitUserDefinedDataElement1Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string PermitUserDefinedDataElement2Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string PermitUserDefinedDataElement3Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string PermitUserDefinedDataElement4Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string PermitUserDefinedDataElement5Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string PermitCommentsText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 MajorMinorRatingCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)] //5.6
        [Windsor.Commons.XsdOrm2.DbIgnore()]
        public MajorMinorStatus MajorMinorStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public MajorMinorStatusIndicatorType MajorMinorStatusIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MajorMinorStatusIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate MajorMinorStatusStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MajorMinorStatusStartDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 23)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("15", "7")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_56.RemoveTrailingZerosDecimal TotalApplicationDesignFlowNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 24)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("15", "7")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_56.RemoveTrailingZerosDecimal TotalApplicationAverageFlowNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 25)]
        public Facility Facility;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 26)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ApplicationReceivedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 27)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate PermitApplicationCompletionDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 28)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string NewSourceIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 29)]
        public ComplianceTrackingStatus ComplianceTrackingStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 30)] //5.6
        [Windsor.Commons.XsdOrm2.DbIgnoreAttribute()]
        public DMRNonReceiptStatus DMRNonReceiptStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public ActiveInactiveType DMRNonReceiptStatusIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DMRNonReceiptStatusIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate DMRNonReceiptStatusStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DMRNonReceiptStatusStartDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ReportableNonComplianceStatus", Order = 31)] //5.6
        public ReportableNonComplianceStatus[] ReportableNonComplianceStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EffluentGuidelineCode", Order = 32)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] EffluentGuidelineCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 33)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(12)]
        public string PermitStateWaterBodyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 34)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string PermitStateWaterBodyName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 35)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string FederalGrantIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 36)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string DMRCognizantOfficial;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 37)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(15)]
        public string DMRCognizantOfficialTelephoneNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 38)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Contact[] PermitContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 39)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Address[] PermitAddress;
    }

    /// <remarks/>
    [System.SerializableAttribute()] //5.6
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class ReportableNonComplianceStatus
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 ReportableNonComplianceStatusCodeYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
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
    [System.Xml.Serialization.XmlRootAttribute("PermitStatusCode", Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public enum PermitStatusCodeType
    {

        /// <remarks/>
        NON,
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
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(60)]
        public string LocalityName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
        public string LocationAddressCountyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(12)]
        public string LocationAddressCityCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(2)]
        public string LocationStateCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(14)]
        public string LocationZipCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string LocationCountryCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string OrganizationDUNSNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(12)]
        public string StateFacilityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
        public string StateRegionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.SingleLeadingZeroInt32 FacilityCongressionalDistrictNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FacilityClassification", Order = 13)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] FacilityClassification;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PolicyCode", Order = 14)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] PolicyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OriginatingProgramsCode", Order = 15)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(9)]
        public string[] OriginatingProgramsCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string FacilityTypeOfOwnershipCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(12)]
        public string FederalFacilityIdentificationNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
        public string FederalAgencyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4)]
        public string TribalLandCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string ConstructionProjectName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("9", "7")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_56.RemoveTrailingZerosDecimal ConstructionProjectLatitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("10", "6")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_56.RemoveTrailingZerosDecimal ConstructionProjectLongitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SICCodeDetails", Order = 23)]
        public SICCodeDetails[] SICCodeDetails;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NAICSCodeDetails", Order = 24)]
        public NAICSCodeDetails[] NAICSCodeDetails;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 25)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string SectionTownshipRange;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 26)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string FacilityComments;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 27)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string FacilityUserDefinedField1;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 28)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string FacilityUserDefinedField2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 29)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string FacilityUserDefinedField3;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 30)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string FacilityUserDefinedField4;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 31)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string FacilityUserDefinedField5;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 32)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Contact[] FacilityContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 33)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Address[] FacilityAddress;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 34)]
        public GeographicCoordinates GeographicCoordinates;
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
    [System.SerializableAttribute()] //5.6
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute("MajorMinorStatusIndicator", Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public enum MajorMinorStatusIndicatorType
    {

        /// <remarks/>
        N,

        /// <remarks/>
        M,
    }

    /// <remarks/>
    [System.SerializableAttribute()] //5.6
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class MajorMinorStatus
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public MajorMinorStatusIndicatorType MajorMinorStatusIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MajorMinorStatusIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate MajorMinorStatusStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MajorMinorStatusStartDateSpecified;
    }

    [System.SerializableAttribute()] //5.6
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class DMRNonReceiptStatus
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public ActiveInactiveType DMRNonReceiptStatusIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DMRNonReceiptStatusIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate DMRNonReceiptStatusStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DMRNonReceiptStatusStartDateSpecified;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute("LimitSetStatusIndicator", Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public enum ActiveInactiveType
    {

        /// <remarks/>
        A,

        /// <remarks/>
        I,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class CSOPermit : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 CSSPopulationServedNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string CombinedSewerSystemLength;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 CollectionSystemCombinedPercent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SatelliteCollectionSystem", Order = 3)]
        public SatelliteCollectionSystem[] SatelliteCollectionSystem;
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
        public YesNoIndicatorTypeBase ImpairedWaterIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ImpairedWaterIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public YesNoIndicatorTypeBase HistoricPropertyIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool HistoricPropertyIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string HistoricPropertyCriterionMetCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public YesNoIndicatorTypeBase SpeciesCriticalHabitatIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SpeciesCriticalHabitatIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string SpeciesCriterionMetCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("10", "2")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_56.RemoveTrailingZerosDecimal IndustrialActivitySize;

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
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public YesNoIndicatorTypeBase TierTwoIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TierTwoIndicatorSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public YesNoIndicatorTypeBase TierThreeIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TierThreeIndicatorSpecified;

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
        [System.Xml.Serialization.XmlElementAttribute("ManureLitterProcessedWastewaterStorage", Order = 7)]
        public ManureLitterProcessedWastewaterStorage[] ManureLitterProcessedWastewaterStorage;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Containment", Order = 8)]
        public Containment[] Containment;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 NumberAcresContributingDrainage;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 ApplicationMeasureAvailableLandNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 SolidManureLitterGeneratedAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 LiquidManureWastewaterGeneratedAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 SolidManureLitterTransferAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 LiquidManureWastewaterTransferAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string NMPDevelopedCertifiedPlannerApprovedIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate NMPDevelopedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate NMPLastUpdatedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string EnvironmentalManagementSystemIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate EMSDevelopedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate EMSLastUpdatedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LandApplicationBMP", Order = 21)]
        public LandApplicationBMP[] LandApplicationBMP;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 LivestockMaximumCapacityNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 23)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 LivestockCapacityDeterminationBasedUponNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 24)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 AuthorizedLivestockCapacityNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 25)]
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
        [System.Xml.Serialization.XmlElementAttribute("BiosolidsTypeCode", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] BiosolidsTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("BiosolidsEndUseDisposalTypeCode", Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] BiosolidsEndUseDisposalTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 EQProductDistributedMarketedAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 LandAppliedAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 IncineratedAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 CodisposedInMSWLandfillAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 SurfaceDisposalAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 ManagedOtherMethodsAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 ReceivedOffsiteSourcesAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 TransferredAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 DisposedOutOfStateAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 BeneficiallyUsedOutOfStateAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 ManagedOtherMethodsOutOfStateAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 TotalRemovedAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 AnnualDrySludgeProductionNumber;

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
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 3)]
        public System.DateTime PermitIssueDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PermitIssueDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 4)]
        public System.DateTime PermitEffectiveDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PermitEffectiveDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 5)]
        public System.DateTime PermitExpirationDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PermitExpirationDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string ReissuancePriorityPermitIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(2000)]
        public string BacklogReasonText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string PermitIssuingOrganizationTypeName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OtherPermits", Order = 9)]
        public OtherPermits[] OtherPermits;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AssociatedPermit", Order = 10)]
        public AssociatedPermit[] AssociatedPermit;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string PermitAppealedIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SICCodeDetails", Order = 12)]
        public SICCodeDetails[] SICCodeDetails;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NAICSCodeDetails", Order = 13)]
        public NAICSCodeDetails[] NAICSCodeDetails;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string PermitUserDefinedDataElement1Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string PermitUserDefinedDataElement2Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string PermitUserDefinedDataElement3Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string PermitUserDefinedDataElement4Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string PermitUserDefinedDataElement5Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string PermitCommentsText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 MajorMinorRatingCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)] //5.6
        [Windsor.Commons.XsdOrm2.DbIgnore()]
        public MajorMinorStatus MajorMinorStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public MajorMinorStatusIndicatorType MajorMinorStatusIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MajorMinorStatusIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate MajorMinorStatusStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MajorMinorStatusStartDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("15", "7")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_56.RemoveTrailingZerosDecimal TotalApplicationDesignFlowNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 23)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("15", "7")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_56.RemoveTrailingZerosDecimal TotalApplicationAverageFlowNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 24)]
        public Facility Facility;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 25)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ApplicationReceivedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 26)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate PermitApplicationCompletionDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 27)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string NewSourceIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 28)]
        public ComplianceTrackingStatus ComplianceTrackingStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 29)] //5.6
        [Windsor.Commons.XsdOrm2.DbIgnoreAttribute()]
        public DMRNonReceiptStatus DMRNonReceiptStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public ActiveInactiveType DMRNonReceiptStatusIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DMRNonReceiptStatusIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate DMRNonReceiptStatusStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DMRNonReceiptStatusStartDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ReportableNonComplianceStatus", Order = 30)] //5.6
        public ReportableNonComplianceStatus[] ReportableNonComplianceStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EffluentGuidelineCode", Order = 31)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] EffluentGuidelineCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 32)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(12)]
        public string PermitStateWaterBodyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 33)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string PermitStateWaterBodyName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 34)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string FederalGrantIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 35)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string DMRCognizantOfficial;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 36)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(15)]
        public string DMRCognizantOfficialTelephoneNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 37)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Contact[] PermitContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 38)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Address[] PermitAddress;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 39)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string SignificantIUIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 40)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string ReceivingPermitIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class ProgramInspectionKeyElements : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string ComplianceMonitoringCategoryCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public System.DateTime ComplianceMonitoringDate;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PermitTrackingEvent))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class PermitTrackingEventKeyElements : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public string PermitTrackingEventCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
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
    public partial class PermittedFeatureKeyElements : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
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
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_56.RemoveTrailingZerosDecimal PermittedFeatureDesignFlowNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("15", "7")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_56.RemoveTrailingZerosDecimal PermittedFeatureActualAverageFlowNumber;

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
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public YesNoIndicatorTypeBase ImpairedWaterIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ImpairedWaterIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public YesNoIndicatorTypeBase TMDLCompletedIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TMDLCompletedIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string PermittedFeatureUserDefinedDataElement1;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string PermittedFeatureUserDefinedDataElement2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 FieldSize;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string IsSiteOwnByFacility;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string IsSystemLinedWithLeachate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string DoesUnitHaveDailyCover;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 PropertyBoundaryDistance;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string IsRequiredNitrateGroundWater;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 WellNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        public GeographicCoordinates GeographicCoordinates;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(200)]
        public string SourcePermittedFeatureDetailText;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 21)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Contact[] SiteOwnerContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 22)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Address[] SiteOwnerAddress;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class PermitScheduleEventViolationKeyElements : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 NarrativeConditionNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
        public string ScheduleEventCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 2)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public System.DateTime ScheduleDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(3)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public ScheduleViolationCodeType ScheduleViolationCode;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ParameterLimits))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class ParameterLimitKeyElements : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public string PermittedFeatureIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(2)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public string LimitSetDesignator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
        public string ParameterCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string MonitoringSiteDescriptionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
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
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)] //5.6
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
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LimitSet))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class LimitSetKeyElements : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public string PermittedFeatureIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(2)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public string LimitSetDesignator;
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
        public Windsor.Commons.XsdOrm2.SingleLeadingZeroInt32 NumberUnitsReportPeriodInteger;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.SingleLeadingZeroInt32 NumberSubmissionUnitsInteger;

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
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(Limits))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class LimitKeyElements : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public string PermittedFeatureIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(2)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public string LimitSetDesignator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
        public string ParameterCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string MonitoringSiteDescriptionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 LimitSeasonNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 5)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public System.DateTime LimitStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 6)]
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
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string LimitsUserDefinedField1;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string LimitsUserDefinedField2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(150)]
        public string LimitsUserDefinedField3;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(2)]
        public string ConcentrationNumericConditionUnitMeasureCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(2)]
        public string QuantityNumericConditionUnitMeasureCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NumericCondition", Order = 20)]
        public NumericCondition[] NumericCondition;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(HistoricalPermitScheduleEvents))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class HistoricalPermitScheduleKeyElements : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public System.DateTime PermitEffectiveDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 NarrativeConditionNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
        public string ScheduleEventCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 3)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
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
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(EffluentTradePartner))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute("EffluentTradePartnerReportIdentifier", Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class EffluentTradePartnerKeyElements : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public string PermittedFeatureIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(2)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public string LimitSetDesignator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
        public string ParameterCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string MonitoringSiteDescriptionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 LimitSeasonNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 5)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public System.DateTime LimitStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 6)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public System.DateTime LimitEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate LimitModificationEffectiveDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string TradeID;
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
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(DMRViolation))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class DMRViolationKeyElements : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public string PermittedFeatureIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(2)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public string LimitSetDesignator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 2)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public System.DateTime MonitoringPeriodEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
        public string ParameterCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string MonitoringSiteDescriptionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 LimitSeasonNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(2)]
        public NumericReportTextType NumericReportCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
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
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LinkageSWMS4Report))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SWMS4ProgramReport))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SWMS4ProgramReportKeyElements : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public System.DateTime StormWaterMS4ReportReceivedDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class LinkageSWMS4Report : SWMS4ProgramReportKeyElements
    {
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SWMS4ProgramReport : SWMS4ProgramReportKeyElements
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
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SSOMonthlyEventReport))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LinkageSSOMonthlyEventReport))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SSOMonthlyEventReportKeyElements : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
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
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 SSOMonthlyEventMonth;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 SSOMonthlyEventYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 NumberSSOEventsReachUSWatersPerMonth;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 VolumeSSOEventsReachUSWatersPerMonth;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class LinkageSSOMonthlyEventReport : SSOMonthlyEventReportKeyElements
    {
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SSOEventReport))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LinkageSSOEventReport))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SSOEventReportKeyElements : BasicPermitKeyElements
    {


        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public System.DateTime SSOEventDate;

        /// <summary>
        /// Added to support new element in v4.0 schema
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 SSOEventID;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SSOEventReport : SSOEventReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(1000)]
        public string CauseSSOOverflowEvent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("9", "7")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_56.RemoveTrailingZerosDecimal LatitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("10", "6")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_56.RemoveTrailingZerosDecimal LongitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string SSOOverflowLocationStreet;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("9", "2")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_56.RemoveTrailingZerosDecimal DurationSSOOverflowEvent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 SSOVolume;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(1000)]
        public string NameReceivingWater;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ImpactSSOEvent", Order = 7)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] ImpactSSOEvent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SSOSystemComponent", Order = 8)]
        public SSOSystemComponent[] SSOSystemComponent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SSOSteps", Order = 9)]
        public SSOSteps[] SSOSteps;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
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
    public partial class LinkageSSOEventReport : SSOEventReportKeyElements
    {
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SSOAnnualReport))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LinkageSSOAnnualReport))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SSOAnnualReportKeyElements : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public System.DateTime SSOAnnualReportReceivedDate;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SWIndustrialAnnualReport))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LinkageSWIndustrialAnnualReport))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SWIndustrialAnnualReportKeyElements : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public System.DateTime IndustrialStormWaterAnnualReportReceivedDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SSOAnnualReport : SSOAnnualReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 SSOAnnualReportYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 NumberSSOEventsPerYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 VolumeSSOEventsPerYear;
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
    public partial class LinkageSSOAnnualReport : SSOAnnualReportKeyElements
    {
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class LinkageSWIndustrialAnnualReport : SWIndustrialAnnualReportKeyElements
    {
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LinkagePretreatmentPerformanceReport))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PretreatmentPerformanceSummary))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class PretreatmentPerformanceSummaryReportKeyElements : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public System.DateTime PretreatmentPerformanceSummaryEndDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class LinkagePretreatmentPerformanceReport : PretreatmentPerformanceSummaryReportKeyElements
    {
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class PretreatmentPerformanceSummary : PretreatmentPerformanceSummaryReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate PretreatmentPerformanceSummaryStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(15)]
        public string SUOReference;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate SUODate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public YesNoIndicatorTypeBase AcceptanceHazardousWaste;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AcceptanceHazardousWasteSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public YesNoIndicatorTypeBase AcceptanceNonHazardousIndustrialWaste;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AcceptanceNonHazardousIndustrialWasteSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public YesNoIndicatorTypeBase AcceptanceHauledDomesticWastes;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AcceptanceHauledDomesticWastesSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 AnnualPretreatmentBudgetPPS;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public YesNoIndicatorTypeBase InadequacySamplingInspectionIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool InadequacySamplingInspectionIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public YesNoIndicatorTypeBase AdequacyPretreatmentResources;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AdequacyPretreatmentResourcesSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public YesNoIndicatorTypeBase DeficienciesIdentifiedDuringIUFileReview;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DeficienciesIdentifiedDuringIUFileReviewSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public YesNoIndicatorTypeBase ControlMechanismDeficiencies;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ControlMechanismDeficienciesSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public YesNoIndicatorTypeBase LegalAuthorityDeficiencies;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LegalAuthorityDeficienciesSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public YesNoIndicatorTypeBase DeficienciesInterpretationApplicationPretreatmentStandards;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DeficienciesInterpretationApplicationPretreatmentStandardsSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public YesNoIndicatorTypeBase DeficienciesDataManagementPublicParticipation;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DeficienciesDataManagementPublicParticipationSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public YesNoIndicatorTypeBase ViolationIUScheduleRemedialMeasures;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ViolationIUScheduleRemedialMeasuresSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string FormalResponseViolationIUScheduleRemedialMeasures;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 AnnualFrequencyInfluentToxicantSampling;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 AnnualFrequencyEffluentToxicantSampling;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 AnnualFrequencySludgeToxicantSampling;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 NumberSIUs;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 SIUsWithoutControlMechanism;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 SIUsNotInspected;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 SIUsNotSampled;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 23)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 SIUsOnSchedule;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 24)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 SIUsSNCWithPretreatmentStandards;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 25)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 SIUsSNCWithReportingRequirements;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 26)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 SIUsSNCWithPretreatmentSchedule;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 27)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 SIUsSNCPublishedNewspaper;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 28)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 ViolationNoticesIssuedSIUs;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 29)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 AdministrativeOrdersIssuedSIUs;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 30)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 CivilSuitsFiledAgainstSIUs;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 31)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 CriminalSuitsFiledAgainstSIUs;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 32)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 DollarAmountPenaltiesCollectedPPS;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 33)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 IUsWhichPenaltiesHaveBeenCollectedPPS;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 34)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 NumberCIUs;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 35)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 CIUsInSNC;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 36)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
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
    public partial class LocalLimits
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate MostRecentDateTechnicalEvaluationLocalLimits;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate MostRecentDateAdoptionTechnicallyBasedLocalLimits;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LocalLimitsPollutantCode", Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32[] LocalLimitsPollutantCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class RemovalCredits
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate MostRecentDateRemovalCreditsApproval;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string RemovalCreditsApplicationStatusCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("RemovalCreditsPollutantCode", Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32[] RemovalCreditsPollutantCode;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LinkageLocalLimitsReport))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LocalLimitsProgramReport))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class LocalLimitsProgramReportKeyElements : BasicPermitKeyElements
    {

        /// <summary>
        /// Element renamed between v3.1 and v4.0. Attribute parameter below handles new XML element name mapping to old v3.1 staging table field name.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("LocalLimitsPermittingAuthorityReportReceivedDate", DataType = "date", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public System.DateTime PermittingAuthorityReportReceivedDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class LinkageLocalLimitsReport : LocalLimitsProgramReportKeyElements
    {
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
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CSOEventReport))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LinkageCSOEventReport))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class CSOEventReportKeyElements : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public System.DateTime CSOEventDate;

        /// <summary>
        /// Added to support new element in v4.0 schema
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 CSOEventID;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class CSOEventReport : CSOEventReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public WetDryType DryOrWetWeatherIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DryOrWetWeatherIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4)]
        public string PermittedFeatureIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("9", "7")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_56.RemoveTrailingZerosDecimal LatitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("10", "6")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_56.RemoveTrailingZerosDecimal LongitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string CSOOverflowLocationStreet;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("9", "2")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_56.RemoveTrailingZerosDecimal DurationCSOOverflowEvent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 DischargeVolumeTreated;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 DischargeVolumeUntreated;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string CorrectiveActionTakenDescriptionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("8", "2")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_56.RemoveTrailingZerosDecimal InchesPrecipitation;
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
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class LinkageCSOEventReport : CSOEventReportKeyElements
    {
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LinkageSWEventReport))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SWEventReport))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SWEventReportKeyElements : BasicPermitKeyElements
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public System.DateTime DateStormEventSampled;

        /// <summary>
        /// Added to support new element in v4.0 schema
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 SWEventID;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class LinkageSWEventReport : SWEventReportKeyElements
    {
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SWEventReport : SWEventReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4)]
        public string PermittedFeatureIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("6", "1")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_56.RemoveTrailingZerosDecimal RainfallStormEventSampledNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string DurationStormEventSampled;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 VolumeDischargeSample;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 DurationSinceLastStormEvent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public SamplingBasisType SamplingBasisIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SamplingBasisIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public PrecipitationFormType PrecipitationForm;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PrecipitationFormSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string SampleTakenWithinTimeframeIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string TimeExceedanceRationaleCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string EssentiallyIdenticalOutfallNotification;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string MonitoringExemptionRationaleIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
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
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(DischargeMonitoringReportParameterViolation))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(DischargeMonitoringReportViolation))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(DMRProgramReportLinkage))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(DischargeMonitoringReport))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class DischargeMonitoringReportKeyElements : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public string PermittedFeatureIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(2)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public string LimitSetDesignator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 2)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
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
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
        public string ParameterCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string MonitoringSiteDescriptionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
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
    public partial class DMRProgramReportLinkage : DischargeMonitoringReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LinkageBiosolidsReport", typeof(LinkageBiosolidsReport), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("LinkageSWEventReport", typeof(LinkageSWEventReport), Order = 0)]
        // TSM:
        //public BasicPermitKeyElements Item;
        public object Item;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class LinkageBiosolidsReport : BiosolidsProgramReportKeyElements
    {
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LinkageBiosolidsReport))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(BiosolidsProgramReport))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class BiosolidsProgramReportKeyElements : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
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
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.SingleLeadingZeroInt32 NumberOfReportUnits;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 EQProductDistributedMarketedAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 LandAppliedAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 IncineratedAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 CodisposedInMSWLandfillAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 SurfaceDisposalAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 ManagedOtherMethodsAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 ReceivedOffsiteSourcesAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 TransferredAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 DisposedOutOfStateAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 BeneficiallyUsedOutOfStateAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 ManagedOtherMethodsOutOfStateAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 TotalRemovedAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 AnnualDrySludgeProductionNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate AnnualLoadingParameterDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 AnnualLoadingBiosolidGallons;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 AnnualLoadingBiosolidDMT;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 AnnualLoadingNutrientNitrogen;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 AnnualLoadingNutrientPhosphorous;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 TotalNumberLandApplicationViolations;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 TotalNumberIncineratorViolations;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 TotalNumberDistributionMarketingViolations;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 TotalNumberSludgeRelatedManagementPracticeViolations;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 23)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 TotalNumberSurfaceDisposalViolations;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 24)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 TotalNumberOtherSludgeViolations;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 25)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 TotalNumberCodisposalViolations;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 26)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string BiosolidsReportComments;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class DischargeMonitoringReport : DischargeMonitoringReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate SignatureDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string PrincipalExecutiveOfficerFirstName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string PrincipalExecutiveOfficerLastName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(40)]
        public string PrincipalExecutiveOfficerTitle;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(10)]
        public string PrincipalExecutiveOfficerTelephone;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string SignatoryFirstName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string SignatoryLastName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(10)]
        public string SignatoryTelephone;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string ReportCommentText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("DMRNoDischargeIndicator", typeof(string), Order = 9)]
        [System.Xml.Serialization.XmlElementAttribute("DMRNoDischargeReceivedDate", typeof(System.DateTime), DataType = "date", Order = 9)]
        [System.Xml.Serialization.XmlElementAttribute("ReportParameter", typeof(ReportParameter), Order = 9)]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        public object[] Items;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName", Order = 10)]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemsChoiceType[] ItemsElementName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        public LandApplicationSite LandApplicationSite;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        public SurfaceDisposalSite SurfaceDisposalSite;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        public Incinerator Incinerator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
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
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
        public string ParameterCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string MonitoringSiteDescriptionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 LimitSeasonNumber;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IncludeInSchema = false)]
    public enum ItemsChoiceType
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
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(NarrativeCondition))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PermitSchedule))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PermitScheduleViolation))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class PermitScheduleKeyElements : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
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
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
        public string ScheduleEventCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
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
    public partial class PermitScheduleViolation : PermitScheduleKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
        public string ScheduleEventCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public System.DateTime ScheduleDate;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SingleEventViolation))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SingleEventsViolation))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LinkageSingleEvent))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SingleEventKeyElements : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public string SingleEventViolationCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public System.DateTime SingleEventViolationDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SingleEventViolation : SingleEventKeyElements
    {

        /// <remarks/>
        //[System.Xml.Serialization.XmlElementAttribute(Order = 0)]//5.6
        //[Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        //public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate SingleEventViolationStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate SingleEventViolationEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string ReportableNonComplianceDetectionCode;

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
    public partial class SingleEventsViolation : SingleEventKeyElements
    {
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class LinkageSingleEvent : SingleEventKeyElements
    {
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ComplianceMonitoring))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LinkageStateComplianceMonitoring))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ComplianceMonitoringLinkage))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class ComplianceMonitoringKeyElements
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(25)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
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
        //[Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)] //5.6
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public ComplianceMonitoringActivityTypeCodeType ComplianceMonitoringActivityTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        //[Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string ComplianceMonitoringCategoryCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 3)]
        //[Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
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
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
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
        public YesNoIndicatorTypeBase MultimediaIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MultimediaIndicatorSpecified;

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
        public YesNoIndicatorTypeBase InspectionUserDefinedField1;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool InspectionUserDefinedField1Specified;

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
        [System.Xml.Serialization.XmlElementAttribute(Order = 32)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string InspectionCommentText;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 33)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Contact[] InspectionContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 34)]
        public CAFOInspection CAFOInspection;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 35)]
        public CSOInspection CSOInspection;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 36)]
        public PretreatmentInspection PretreatmentInspection;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 37)]
        public SSOInspection SSOInspection;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("StormWaterConstructionInspection", typeof(StormWaterConstructionInspection), Order = 38)]
        [System.Xml.Serialization.XmlElementAttribute("StormWaterConstructionNonConstructionInspections", typeof(StormWaterConstructionNonConstructionInspections), Order = 38)]
        [System.Xml.Serialization.XmlElementAttribute("StormWaterNonConstructionInspection", typeof(StormWaterNonConstructionInspection), Order = 38)]
        public object Item;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 39)]
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
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(2)]
        public DischargesFromProductionAreaType DischargesDuringYearProductionAreaIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DischargesDuringYearProductionAreaIndicatorSpecified;

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
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 NumberAcresContributingDrainage;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 ApplicationMeasureAvailableLandNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 SolidManureLitterGeneratedAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 LiquidManureWastewaterGeneratedAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 SolidManureLitterTransferAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 LiquidManureWastewaterTransferAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string NMPDevelopedCertifiedPlannerApprovedIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate NMPDevelopedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate NMPLastUpdatedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string EnvironmentalManagementSystemIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate EMSDevelopedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate EMSLastUpdatedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LandApplicationBMP", Order = 20)]
        public LandApplicationBMP[] LandApplicationBMP;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 LivestockMaximumCapacityNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 LivestockCapacityDeterminationBasedUponNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 23)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 AuthorizedLivestockCapacityNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CAFOInspectionViolationTypeCode", Order = 24)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] CAFOInspectionViolationTypeCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute("DischargesDuringYearProductionAreaIndicator", Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public enum DischargesFromProductionAreaType
    {

        /// <remarks/>
        NO,

        /// <remarks/>
        YA,

        /// <remarks/>
        YU,

        /// <remarks/>
        YB,
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
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("9", "7")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_56.RemoveTrailingZerosDecimal LatitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("10", "6")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_56.RemoveTrailingZerosDecimal LongitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string CSOOverflowLocationStreet;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("9", "2")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_56.RemoveTrailingZerosDecimal DurationCSOOverflowEvent;

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
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 InchesPrecipitation;
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
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_56.RemoveTrailingZerosDecimal DollarAmountPenaltiesCollected;

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
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("9", "7")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_56.RemoveTrailingZerosDecimal LatitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("10", "6")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_56.RemoveTrailingZerosDecimal LongitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string SSOOverflowLocationStreet;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("9", "2")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_56.RemoveTrailingZerosDecimal DurationSSOOverflowEvent;

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
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 EstimatedAreaDisturbedAcresNumber;

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
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class LinkageStateComplianceMonitoring : ComplianceMonitoringKeyElements
    {
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class ComplianceMonitoringLinkage : ComplianceMonitoringKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LinkageBiosolidsReport", typeof(LinkageBiosolidsReport), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("LinkageCAFOAnnualReport", typeof(LinkageCAFOAnnualReport), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("LinkageCSOEventReport", typeof(LinkageCSOEventReport), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("LinkageEnforcementAction", typeof(LinkageEnforcementAction), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("LinkageFederalComplianceMonitoring", typeof(LinkageFederalComplianceMonitoring), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("LinkageLocalLimitsReport", typeof(LinkageLocalLimitsReport), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("LinkagePretreatmentPerformanceReport", typeof(LinkagePretreatmentPerformanceReport), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("LinkageSSOAnnualReport", typeof(LinkageSSOAnnualReport), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("LinkageSSOEventReport", typeof(LinkageSSOEventReport), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("LinkageSSOMonthlyEventReport", typeof(LinkageSSOMonthlyEventReport), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("LinkageSWEventReport", typeof(LinkageSWEventReport), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("LinkageSWMS4Report", typeof(LinkageSWMS4Report), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("LinkageSingleEvent", typeof(LinkageSingleEvent), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("LinkageStateComplianceMonitoring", typeof(LinkageStateComplianceMonitoring), Order = 0)]
        public object Item;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class LinkageCAFOAnnualReport : CAFOAnnualProgramReportKeyElements
    {
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LinkageCAFOAnnualReport))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CAFOAnnualReport))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class CAFOAnnualProgramReportKeyElements : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
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
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string DischargesDuringYearProductionAreaIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DischargesDuringYearProductionAreaIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ReportedAnimalType", Order = 1)]
        public ReportedAnimalType[] ReportedAnimalType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 SolidManureLitterGeneratedAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 LiquidManureWastewaterGeneratedAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 SolidManureLitterTransferAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 LiquidManureWastewaterTransferAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string NMPDevelopedCertifiedPlannerApprovedIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 TotalNumberAcresNMPIdentified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 TotalNumberAcresUsedLandApplication;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class LinkageEnforcementAction : EnforcementActionKeyElements
    {
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(InformalEnforcementAction))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(FormalEnforcementAction))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(FinalOrderViolationLinkage))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(EnforcementActionViolationLinkage))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LinkageEnforcementAction))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class EnforcementActionKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(20)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
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
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(500)]
        public string ReasonDeletingRecord;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string FederalFacilityIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string FederalFacilityIndicatorComment;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string InformalEACommentText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string InformalEAUserDefinedField1;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string InformalEAUserDefinedField2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string InformalEAUserDefinedField3;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate InformalEAUserDefinedField4;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate InformalEAUserDefinedField5;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string InformalEAUserDefinedField6;

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
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string FederalFacilityIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string FederalFacilityIndicatorComment;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string FormalEAUserDefinedField1;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string FormalEAUserDefinedField2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string FormalEAUserDefinedField3;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate FormalEAUserDefinedField4;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate FormalEAUserDefinedField5;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string FormalEAUserDefinedField6;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FinalOrder", Order = 16)]
        public FinalOrder[] FinalOrder;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EnforcementAgency", Order = 17)]
        public EnforcementAgency[] EnforcementAgency;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string EnforcementAgencyName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EnforcementActionGovernmentContact", Order = 19)]
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
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
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
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("17", "2")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_56.RemoveTrailingZerosDecimal CashCivilPenaltyRequiredAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string OtherComments;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SupplementalEnvironmentalProject", Order = 8)] //5.6
        public SupplementalEnvironmentalProject[] SupplementalEnvironmentalProject;
    }

    /// <remarks/>
    [System.SerializableAttribute()] //5.6
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class SupplementalEnvironmentalProject
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 SupplementalEnvironmentalProjectIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string SupplementalEnvironmentalProjectDescription;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("17", "2")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_56.RemoveTrailingZerosDecimal SupplementalEnvironmentalProjectPenaltyAssessmentAmount;
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
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
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
    public partial class ComplianceScheduleViolation : ComplianceScheduleKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
        public string ScheduleEventCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public System.DateTime ScheduleDate;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ComplianceScheduleViolation))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ComplianceSchedule))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ComplianceScheduleEventViolationKeyElements))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class ComplianceScheduleKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(20)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
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
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 ComplianceScheduleNumber;
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
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("17", "2")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_56.RemoveTrailingZerosDecimal ComplianceSchedulePenaltyAmount;
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
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
        public string ScheduleEventCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public System.DateTime ScheduleDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class ComplianceScheduleEventViolationKeyElements : ComplianceScheduleKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
        public string ScheduleEventCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public System.DateTime ScheduleDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(3)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public ScheduleViolationCodeType ScheduleViolationCode;
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
    public partial class LinkageFederalComplianceMonitoring : FederalComplianceMonitoringKeyElements
    {
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(FederalComplianceMonitoring))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LinkageFederalComplianceMonitoring))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class FederalComplianceMonitoringKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(20)]
        public string ProgramSystemAcronym;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string ProgramSystemIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(6)]
        public string FederalStatuteCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(3)]
        public ComplianceMonitoringActivityTypeCodeType ComplianceMonitoringActivityTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string ComplianceMonitoringCategoryCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 5)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public System.DateTime ComplianceMonitoringDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class FederalComplianceMonitoring : FederalComplianceMonitoringKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ComplianceMonitoringStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ComplianceInspectionTypeCode", Order = 1)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] ComplianceInspectionTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string ComplianceMonitoringActivityName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string BiomonitoringInspectionMethod;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ComplianceMonitoringActionReasonCode", Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] ComplianceMonitoringActionReasonCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ComplianceMonitoringAgencyTypeCode", Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string[] ComplianceMonitoringAgencyTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 ComplianceMonitoringAgencyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProgramCode", Order = 7)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(9)]
        public string[] ProgramCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string EPAAssistanceIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public StateFederalJointType StateFederalJointIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StateFederalJointIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string JointInspectionReasonCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public LeadPartyType LeadParty;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LeadPartySpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 NumberDaysPhysicallyConductingActivity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 NumberHoursPhysicallyConductingActivity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 ComplianceMonitoringActionOutcomeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string InspectionRatingCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NationalPrioritiesCode", Order = 16)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32[] NationalPrioritiesCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public YesNoIndicatorTypeBase MultimediaIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MultimediaIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string FederalFacilityIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string FederalFacilityIndicatorComment;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public YesNoIndicatorTypeBase InspectionUserDefinedField1;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool InspectionUserDefinedField1Specified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string InspectionUserDefinedField2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string InspectionUserDefinedField3;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 23)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate InspectionUserDefinedField4;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 24)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate InspectionUserDefinedField5;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 25)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string InspectionUserDefinedField6;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 26)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string InspectionCommentText;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 27)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public Contact[] InspectionContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("InspectionGovernmentContact", Order = 28)]
        public InspectionGovernmentContact[] InspectionGovernmentContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 29)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ComplianceMonitoringPlannedStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 30)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate ComplianceMonitoringPlannedEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 31)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(2)]
        public string EPARegion;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LawSectionCode", Order = 32)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(15)]
        public string[] LawSectionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 33)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string ComplianceMonitoringMediaTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("RegionalPriorityCode", Order = 34)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32[] RegionalPriorityCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SICCode", Order = 35)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(4)]
        public string[] SICCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NAICSCode", Order = 36)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(6)]
        public string[] NAICSCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 37)]
        public InspectionConclusionDataSheet InspectionConclusionDataSheet;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Subactivity", Order = 38)]
        public Subactivity[] Subactivity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Citation", Order = 39)]
        public Citation[] Citation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 40)]
        public CAFOInspection CAFOInspection;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 41)]
        public CSOInspection CSOInspection;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 42)]
        public PretreatmentInspection PretreatmentInspection;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 43)]
        public SSOInspection SSOInspection;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 44)]
        public StormWaterConstructionNonConstructionInspections StormWaterConstructionNonConstructionInspections;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 45)]
        public StormWaterMS4Inspection StormWaterMS4Inspection;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
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
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32[] CorrectiveActionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AirPollutantCode", Order = 5)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32[] AirPollutantCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("WaterPollutantCode", Order = 6)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
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
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate SubactivityPlannedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate SubactivityDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
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
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(Milestone))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IsNullable = false)]
    public partial class EnforcementActionMilestoneKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(20)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public string EnforcementActionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
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
        [System.ComponentModel.DescriptionAttribute("The type of  information or warning that is being returned.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(11)]
        public InformationTypeCodeDataType InformationTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("A human readable description on a  information or warning.")]
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
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(6)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Unique number that identifies the total count of accepted records by transaction " +
            "type.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 TotalAcceptedTransactions;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
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
        [System.Xml.Serialization.XmlElementAttribute("BiosolidsProgramReportIdentifier", typeof(BiosolidsProgramReportKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("CAFOAnnualProgramReportIdentifier", typeof(CAFOAnnualProgramReportKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("CSOEventReportIdentifier", typeof(CSOEventReportKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("ComplianceMonitoringIdentifier", typeof(ComplianceMonitoringKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("ComplianceMonitoringLinkageIdentifier", typeof(ComplianceMonitoringLinkage), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("ComplianceScheduleEventIdentifier", typeof(ComplianceScheduleEventKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("ComplianceScheduleIdentifier", typeof(ComplianceScheduleKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("DMRParameterIdentifier", typeof(DischargeMonitoringReportParameterViolation), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("DMRProgramReportLinkageIdentifier", typeof(DMRProgramReportLinkage), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("DMRViolationIdentifier", typeof(DMRViolationKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("DischargeMonitoringReportIdentifier", typeof(DischargeMonitoringReportKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("EffluentTradePartnerReportIdentifier", typeof(EffluentTradePartnerKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("EnforcementActionMilestoneReportIdentifier", typeof(EnforcementActionMilestoneKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("EnforcementActionViolationLinkageIdentifier", typeof(EnforcementActionViolationLinkage), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("FederalComplianceMonitoringIdentifier", typeof(FederalComplianceMonitoringKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("FormalEnforcementActionIdentifier", typeof(EnforcementActionKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("HistoricalPermitScheduleEventIdentifier", typeof(HistoricalPermitScheduleKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("InformalEnforcementActionIdentifier", typeof(EnforcementActionKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("LimitSegmentIdentifier", typeof(LimitKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("LimitSetIdentifier", typeof(LimitSetKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("LocalLimitsProgramReportIdentifier", typeof(LocalLimitsProgramReportKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("NarrativeConditionScheduleIdentifier", typeof(PermitScheduleKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("ParameterLimitIdentifier", typeof(ParameterLimitKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("PermitRecordIdentifier", typeof(BasicPermitKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("PermitTrackingEventIdentifier", typeof(PermitTrackingEventKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("PermittedFeatureRecordIdentifier", typeof(PermittedFeatureKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("PretreatmentPerformanceSummaryIdentifier", typeof(PretreatmentPerformanceSummaryReportKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("SSOAnnualReportIdentifier", typeof(SSOAnnualReportKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("SSOEventReportIdentifier", typeof(SSOEventReportKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("SSOMonthlyEventReportIdentifier", typeof(SSOMonthlyEventReportKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("SWEventReportIdentifier", typeof(SWEventReportKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("SWMS4ProgramReportIdentifier", typeof(SWMS4ProgramReportKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("ScheduleEventViolationIdentifier", typeof(ScheduleEventViolationKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("SingleEventIdentifier", typeof(SingleEventKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
        public object Item;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemChoiceType ItemElementName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The type of transaction that was sent in the submission.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public SubmissionTransactionTypeCodeDataType SubmissionTransactionTypeCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IncludeInSchema = false)]
    public enum ItemChoiceType
    {

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a biosolids program report by including all the appropriate k" +
            "eys for it.")]
        BiosolidsProgramReportIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a CAFO annual program report by including all the appropriate" +
            " keys for it.")]
        CAFOAnnualProgramReportIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a CSO Event by including all the appropriate keys for it.")]
        CSOEventReportIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a compliance monitoring inspection by including all the appro" +
            "priate keys for it.")]
        ComplianceMonitoringIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a compliance monitoring linkage by including all the appropri" +
            "ate keys for it.  The type definition is found in the CMLinkage xsd file.")]
        ComplianceMonitoringLinkageIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a compliance schedule event by including all the appropriate " +
            "keys for it.")]
        ComplianceScheduleEventIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a compliance schedule by including all the appropriate keys f" +
            "or it.")]
        ComplianceScheduleIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a parameter within a specific DMR by including all the approp" +
            "riate keys for it. The type is defined in EAViolationLinkage xsd.")]
        DMRParameterIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a DMR Program Report Linkage by including all the appropriate" +
            " keys for it.  The type definition is found in the DMRProgramReportLinkage xsd f" +
            "ile.")]
        DMRProgramReportLinkageIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a DMR violation by including all the appropriate keys.")]
        DMRViolationIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a DMR by including all the appropriate keys for it.")]
        DischargeMonitoringReportIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies an Effluent Trade Partner by including all the appropriate ke" +
            "ys for it.")]
        EffluentTradePartnerReportIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies an Enforcement Action Milestone by including all the appropri" +
            "ate keys for it.")]
        EnforcementActionMilestoneReportIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies an Enforcement Action Violation Linkage by including all the " +
            "appropriate keys for it.  The type is defined in EAViolationLinkage xsd.")]
        EnforcementActionViolationLinkageIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a compliance monitoring inspection by including all the appro" +
            "priate keys for it.")]
        FederalComplianceMonitoringIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a Formal Enforcement Action by including all the appropriate " +
            "keys for it.")]
        FormalEnforcementActionIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a Historical Permit Schedule Event by including all the appro" +
            "priate keys for it.")]
        HistoricalPermitScheduleEventIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies an Informal Enforcement Action by including all the appropria" +
            "te keys for it.")]
        InformalEnforcementActionIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a limit segment by including all the appropriate keys for the" +
            " limit segment.")]
        LimitSegmentIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a limit set by including all the appropriate keys for the lim" +
            "it set.")]
        LimitSetIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a Local Limits Program Report by including all the appropriat" +
            "e keys for it.")]
        LocalLimitsProgramReportIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a narrative condition and its schedules by including all the " +
            "appropriate keys for the narrative condition.")]
        NarrativeConditionScheduleIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a parameter limit by including all the appropriate keys for t" +
            "he parameter limit.")]
        ParameterLimitIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a permit by including the appropriate key for the it.")]
        PermitRecordIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a permit tracking event by including all the appropriate keys" +
            " for the permit tracking event.")]
        PermitTrackingEventIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a permitted feature by including all the appropriate keys for" +
            " the permitted feature.")]
        PermittedFeatureRecordIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a Pretreatment Performance Summary by including all the appro" +
            "priate keys for it.")]
        PretreatmentPerformanceSummaryIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a SSO Annual Report by including all the appropriate keys for" +
            " it.")]
        SSOAnnualReportIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a SSO Event Report by including all the appropriate keys for " +
            "it.")]
        SSOEventReportIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a SSO Monthly Event Report by including all the appropriate k" +
            "eys for it.")]
        SSOMonthlyEventReportIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a Storm Water Event Report by including all the appropriate k" +
            "eys for it.")]
        SWEventReportIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a Storm Water MS4 Program Report by including all the appropr" +
            "iate keys for it.")]
        SWMS4ProgramReportIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a Schedule Event Violation by including all the appropriate k" +
            "eys for it.")]
        ScheduleEventViolationIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a Single Event Violation by including all the appropriate key" +
            "s for it.")]
        SingleEventIdentifier,
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
        [System.Xml.Serialization.XmlElementAttribute("BiosolidsProgramReportIdentifier", typeof(BiosolidsProgramReportKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("CAFOAnnualProgramReportIdentifier", typeof(CAFOAnnualProgramReportKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("CSOEventReportIdentifier", typeof(CSOEventReportKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("ComplianceMonitoringIdentifier", typeof(ComplianceMonitoringKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("ComplianceMonitoringLinkageIdentifier", typeof(ComplianceMonitoringLinkage), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("ComplianceScheduleEventIdentifier", typeof(ComplianceScheduleEventKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("ComplianceScheduleIdentifier", typeof(ComplianceScheduleKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("DMRParameterIdentifier", typeof(DischargeMonitoringReportParameterViolation), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("DMRProgramReportLinkageIdentifier", typeof(DMRProgramReportLinkage), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("DMRViolationIdentifier", typeof(DMRViolationKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("DischargeMonitoringReportIdentifier", typeof(DischargeMonitoringReportKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("EffluentTradePartnerReportIdentifier", typeof(EffluentTradePartnerKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("EnforcementActionMilestoneReportIdentifier", typeof(EnforcementActionMilestoneKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("EnforcementActionViolationLinkageIdentifier", typeof(EnforcementActionViolationLinkage), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("FederalComplianceMonitoringIdentifier", typeof(FederalComplianceMonitoringKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("FormalEnforcementActionIdentifier", typeof(EnforcementActionKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("HistoricalPermitScheduleEventIdentifier", typeof(HistoricalPermitScheduleKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("InformalEnforcementActionIdentifier", typeof(EnforcementActionKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("LimitSegmentIdentifier", typeof(LimitKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("LimitSetIdentifier", typeof(LimitSetKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("LocalLimitsProgramReportIdentifier", typeof(LocalLimitsProgramReportKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("NarrativeConditionScheduleIdentifier", typeof(PermitScheduleKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("ParameterLimitIdentifier", typeof(ParameterLimitKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("PermitRecordIdentifier", typeof(BasicPermitKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("PermitTrackingEventIdentifier", typeof(PermitTrackingEventKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("PermittedFeatureRecordIdentifier", typeof(PermittedFeatureKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("PretreatmentPerformanceSummaryIdentifier", typeof(PretreatmentPerformanceSummaryReportKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("SSOAnnualReportIdentifier", typeof(SSOAnnualReportKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("SSOEventReportIdentifier", typeof(SSOEventReportKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("SSOMonthlyEventReportIdentifier", typeof(SSOMonthlyEventReportKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("SWEventReportIdentifier", typeof(SWEventReportKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("SWMS4ProgramReportIdentifier", typeof(SWMS4ProgramReportKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("ScheduleEventViolationIdentifier", typeof(ScheduleEventViolationKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("SingleEventIdentifier", typeof(SingleEventKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
        public object Item;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemChoiceType1 ItemElementName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The type of transaction that was sent in the submission.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public SubmissionTransactionTypeCodeDataType SubmissionTransactionTypeCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5", IncludeInSchema = false)]
    public enum ItemChoiceType1
    {

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a biosolids program report by including all the appropriate k" +
            "eys for it.")]
        BiosolidsProgramReportIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a CAFO annual program report by including all the appropriate" +
            " keys for it.")]
        CAFOAnnualProgramReportIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a CSO Event by including all the appropriate keys for it.")]
        CSOEventReportIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a compliance monitoring inspection by including all the appro" +
            "priate keys for it.")]
        ComplianceMonitoringIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a compliance monitoring linkage by including all the appropri" +
            "ate keys for it.  The type definition is found in the CMLinkage xsd file.")]
        ComplianceMonitoringLinkageIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a compliance schedule event by including all the appropriate " +
            "keys for it.")]
        ComplianceScheduleEventIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a compliance schedule by including all the appropriate keys f" +
            "or it.")]
        ComplianceScheduleIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a parameter within a specific DMR by including all the approp" +
            "riate keys for it. The type is defined in EAViolationLinkage xsd.")]
        DMRParameterIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a DMR Program Report Linkage by including all the appropriate" +
            " keys for it.  The type definition is found in the DMRProgramReportLinkage xsd f" +
            "ile.")]
        DMRProgramReportLinkageIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a DMR violation by including all the appropriate keys.")]
        DMRViolationIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a DMR by including all the appropriate keys for it.")]
        DischargeMonitoringReportIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies an Effluent Trade Partner by including all the appropriate ke" +
            "ys for it.")]
        EffluentTradePartnerReportIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies an Enforcement Action Milestone by including all the appropri" +
            "ate keys for it.")]
        EnforcementActionMilestoneReportIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies an Enforcement Action Violation Linkage by including all the " +
            "appropriate keys for it.  The type is defined in EAViolationLinkage xsd.")]
        EnforcementActionViolationLinkageIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a compliance monitoring inspection by including all the appro" +
            "priate keys for it.")]
        FederalComplianceMonitoringIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a Formal Enforcement Action by including all the appropriate " +
            "keys for it.")]
        FormalEnforcementActionIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a Historical Permit Schedule Event by including all the appro" +
            "priate keys for it.")]
        HistoricalPermitScheduleEventIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies an Informal Enforcement Action by including all the appropria" +
            "te keys for it.")]
        InformalEnforcementActionIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a limit segment by including all the appropriate keys for the" +
            " limit segment.")]
        LimitSegmentIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a limit set by including all the appropriate keys for the lim" +
            "it set.")]
        LimitSetIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a Local Limits Program Report by including all the appropriat" +
            "e keys for it.")]
        LocalLimitsProgramReportIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a narrative condition and its schedules by including all the " +
            "appropriate keys for the narrative condition.")]
        NarrativeConditionScheduleIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a parameter limit by including all the appropriate keys for t" +
            "he parameter limit.")]
        ParameterLimitIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a permit by including the appropriate key for the it.")]
        PermitRecordIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a permit tracking event by including all the appropriate keys" +
            " for the permit tracking event.")]
        PermitTrackingEventIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a permitted feature by including all the appropriate keys for" +
            " the permitted feature.")]
        PermittedFeatureRecordIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a Pretreatment Performance Summary by including all the appro" +
            "priate keys for it.")]
        PretreatmentPerformanceSummaryIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a SSO Annual Report by including all the appropriate keys for" +
            " it.")]
        SSOAnnualReportIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a SSO Event Report by including all the appropriate keys for " +
            "it.")]
        SSOEventReportIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a SSO Monthly Event Report by including all the appropriate k" +
            "eys for it.")]
        SSOMonthlyEventReportIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a Storm Water Event Report by including all the appropriate k" +
            "eys for it.")]
        SWEventReportIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a Storm Water MS4 Program Report by including all the appropr" +
            "iate keys for it.")]
        SWMS4ProgramReportIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a Schedule Event Violation by including all the appropriate k" +
            "eys for it.")]
        ScheduleEventViolationIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a Single Event Violation by including all the appropriate key" +
            "s for it.")]
        SingleEventIdentifier,
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
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Unique number that identifies the total count of rejected records for an entire s" +
            "ubmission.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 TotalTransactions;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Percent of TotalTransactions that were accepted. The reports show 2 decimal place" +
            "s max.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public decimal PercentTransactionsAccepted;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Unique number that identifies the total transaction of records for an entire batc" +
            "h.")]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 BatchTotalTransactions;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Unique number that identifies the total count of records for an entire submission" +
            ".")]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatInt32 BatchTotalSubmissions;

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
        [System.ComponentModel.DescriptionAttribute("The date something was submitted.")]
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
        //TSM:
        [System.Xml.Serialization.XmlElementAttribute("BasicPermitData", typeof(BasicPermitData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("DischargeMonitoringReportData", typeof(DischargeMonitoringReportData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("PermittedFeatureData", typeof(PermittedFeatureData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("LimitSetData", typeof(LimitSetData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("LimitsData", typeof(LimitsData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("PermitTerminationData", typeof(PermitTerminationData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("PermitReissuanceData", typeof(PermitReissuanceData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("ParameterLimitsData", typeof(ParameterLimitsData), Order = 0)]

#if ONLY_NV_TYPES

#else // ONLY_NV_TYPES
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("BiosolidsPermitData", typeof(BiosolidsPermitData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("BiosolidsProgramReportData", typeof(BiosolidsProgramReportData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("CAFOAnnualReportData", typeof(CAFOAnnualReportData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("CAFOPermitData", typeof(CAFOPermitData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("CSOEventReportData", typeof(CSOEventReportData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("CSOPermitData", typeof(CSOPermitData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("ComplianceMonitoringData", typeof(ComplianceMonitoringData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("ComplianceMonitoringLinkageData", typeof(ComplianceMonitoringLinkageData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("ComplianceScheduleData", typeof(ComplianceScheduleData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("DMRProgramReportLinkageData", typeof(DMRProgramReportLinkageData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("DMRViolationData", typeof(DMRViolationData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("EffluentTradePartnerData", typeof(EffluentTradePartnerData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("EnforcementActionMilestoneData", typeof(EnforcementActionMilestoneData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("EnforcementActionViolationLinkageData", typeof(EnforcementActionViolationLinkageData), Order = 0)]
        //[System.Xml.Serialization.XmlElementAttribute("FederalComplianceMonitoringData", typeof(FederalComplianceMonitoringData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("FinalOrderViolationLinkageData", typeof(FinalOrderViolationLinkageData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("FormalEnforcementActionData", typeof(FormalEnforcementActionData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("GeneralPermitData", typeof(GeneralPermitData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("HistoricalPermitScheduleEventsData", typeof(HistoricalPermitScheduleEventsData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("InformalEnforcementActionData", typeof(InformalEnforcementActionData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("LocalLimitsProgramReportData", typeof(LocalLimitsProgramReportData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("MasterGeneralPermitData", typeof(MasterGeneralPermitData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("NarrativeConditionScheduleData", typeof(NarrativeConditionScheduleData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("POTWPermitData", typeof(POTWPermitData), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("PermitTrackingEventData", typeof(PermitTrackingEventData), Order = 0)]
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
#endif // ONLY_NV_TYPES
        public object[] Items;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public OperationType Operation;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class BasicPermitData : MainElementBase
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
        public BasicPermit BasicPermit;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class BiosolidsPermitData : MainElementBase
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
        public BiosolidsPermit BiosolidsPermit;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class BiosolidsProgramReportData : MainElementBase
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
        public BiosolidsProgramReport BiosolidsProgramReport;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class CAFOAnnualReportData : MainElementBase
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
        public CAFOAnnualReport CAFOAnnualReport;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class CAFOPermitData : MainElementBase
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
        public CAFOPermit CAFOPermit;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class CSOEventReportData : MainElementBase
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
        public CSOEventReport CSOEventReport;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class CSOPermitData : MainElementBase
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
        public CSOPermit CSOPermit;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class ComplianceMonitoringData : MainElementBase
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
        public ComplianceMonitoring ComplianceMonitoring;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class ComplianceMonitoringLinkageData : MainElementBase
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public TransactionHeader TransactionHeader;


        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a compliance monitoring linkage by including all the appropri" +
            "ate keys for it.  The type definition is found in the CMLinkage xsd file.")]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public ComplianceMonitoringLinkage ComplianceMonitoringLinkage;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class ComplianceScheduleData : MainElementBase
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
        public ComplianceSchedule ComplianceSchedule;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class DMRProgramReportLinkageData : MainElementBase
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public TransactionHeader TransactionHeader;


        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies a DMR Program Report Linkage by including all the appropriate" +
            " keys for it.  The type definition is found in the DMRProgramReportLinkage xsd f" +
            "ile.")]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public DMRProgramReportLinkage DMRProgramReportLinkage;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class DMRViolationData : MainElementBase
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
        public DMRViolation DMRViolation;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class DischargeMonitoringReportData : MainElementBase
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
        public DischargeMonitoringReport DischargeMonitoringReport;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class EffluentTradePartnerData : MainElementBase
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
        public EffluentTradePartner EffluentTradePartner;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class EnforcementActionMilestoneData : MainElementBase
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
        public Milestone Milestone;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class EnforcementActionViolationLinkageData : MainElementBase
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public TransactionHeader TransactionHeader;


        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies an Enforcement Action Violation Linkage by including all the " +
            "appropriate keys for it.  The type is defined in EAViolationLinkage xsd.")]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public EnforcementActionViolationLinkage EnforcementActionViolationLinkage;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class FederalComplianceMonitoringData : MainElementBase
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
        public FederalComplianceMonitoring FederalComplianceMonitoring;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class FinalOrderViolationLinkageData : MainElementBase
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public TransactionHeader TransactionHeader;


        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Uniquely identifies an Enforcement Action Violation Linkage by including all the " +
            "appropriate keys for it.  The type is defined in the FO ViolationLinkage xsd.")]
        [Windsor.Commons.XsdOrm2.SameTableAttribute()]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public FinalOrderViolationLinkage FinalOrderViolationLinkage;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class FormalEnforcementActionData : MainElementBase
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
        public FormalEnforcementAction FormalEnforcementAction;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class GeneralPermitData : MainElementBase
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
        public GeneralPermit GeneralPermit;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class HistoricalPermitScheduleEventsData : MainElementBase
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
        public HistoricalPermitScheduleEvents HistoricalPermitScheduleEvents;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class InformalEnforcementActionData : MainElementBase
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
        public InformalEnforcementAction InformalEnforcementAction;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class LimitSetData : MainElementBase
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
        public LimitSet LimitSet;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class LimitsData : MainElementBase
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
        public Limits Limits;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class LocalLimitsProgramReportData : MainElementBase
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
        public LocalLimitsProgramReport LocalLimitsProgramReport;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class MasterGeneralPermitData : MainElementBase
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
        public MasterGeneralPermit MasterGeneralPermit;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class NarrativeConditionScheduleData : MainElementBase
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
        public NarrativeCondition NarrativeCondition;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class POTWPermitData : MainElementBase
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
        public POTWPermit POTWPermit;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class ParameterLimitsData : MainElementBase
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
        public ParameterLimits ParameterLimits;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class PermitReissuanceData : MainElementBase
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
        public PermitReissuance PermitReissuance;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class PermitTerminationData : MainElementBase
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
        public PermitTermination PermitTermination;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class PermitTrackingEventData : MainElementBase
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
        public PermitTrackingEvent PermitTrackingEvent;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class PermittedFeatureData : MainElementBase
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
        public PermittedFeature PermittedFeature;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class PretreatmentPerformanceSummaryData : MainElementBase
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
        public PretreatmentPerformanceSummary PretreatmentPerformanceSummary;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class PretreatmentPermitData : MainElementBase
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
        public PretreatmentPermit PretreatmentPermit;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class SSOAnnualReportData : MainElementBase
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
        public SSOAnnualReport SSOAnnualReport;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class SWIndustrialAnnualReportData : MainElementBase
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
        public SWIndustrialAnnualReport SWIndustrialAnnualReport;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class SSOEventReportData : MainElementBase
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
        public SSOEventReport SSOEventReport;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class SSOMonthlyEventReportData : MainElementBase
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
        public SSOMonthlyEventReport SSOMonthlyEventReport;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class SWConstructionPermitData : MainElementBase
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
        public SWConstructionPermit SWConstructionPermit;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class SWEventReportData : MainElementBase
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
        public SWEventReport SWEventReport;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class SWIndustrialPermitData : MainElementBase
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
        public SWIndustrialPermit SWIndustrialPermit;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class SWMS4LargePermitData : MainElementBase
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
        public SWMS4LargePermit SWMS4LargePermit;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class SWMS4ProgramReportData : MainElementBase
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
        public SWMS4ProgramReport SWMS4ProgramReport;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class SWMS4SmallPermitData : MainElementBase
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
        public SWMS4SmallPermit SWMS4SmallPermit;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class ScheduleEventViolationData : MainElementBase
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
        public ScheduleEventViolation ScheduleEventViolation;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class SingleEventViolationData : MainElementBase
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
        public SingleEventViolation SingleEventViolation;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/5")]
    public partial class UnpermittedFacilityData : MainElementBase
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
        BiosolidsPermitSubmission,

        /// <remarks/>
        BiosolidsProgramReportSubmission,

        /// <remarks/>
        CAFOAnnualReportSubmission,

        /// <remarks/>
        CAFOPermitSubmission,

        /// <remarks/>
        ComplianceMonitoringSubmission,

        /// <remarks/>
        ComplianceMonitoringLinkageSubmission,

        /// <remarks/>
        ComplianceScheduleSubmission,

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
        PretreatmentPermitSubmission,

        /// <remarks/>
        PretreatmentPerformanceSummarySubmission,

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
        POTWPermitSubmission,

        /// <remarks/>
        SWConstructionPermitSubmission,

        /// <remarks/>
        SWEventReportSubmission,

        /// <remarks/>
        SWIndustrialPermitSubmission,
        
        /// <remarks/>
        SWIndustrialAnnualReportSubmission,

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
