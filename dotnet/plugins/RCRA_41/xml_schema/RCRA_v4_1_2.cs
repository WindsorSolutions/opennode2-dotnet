using System.Xml.Serialization;
using System.Data;
using Windsor.Commons.XsdOrm;

namespace Windsor.Node2008.WNOSPlugin.RCRA_41
{
    [DefaultDecimalPrecision(14,6)]

    // CitationDataType
    [AppliedAttribute(typeof(CitationDataType), "CitationNameSequenceNumber", typeof(ColumnAttribute), DbType.Int32)]
    [AppliedAttribute(typeof(CitationDataType), "Notes", typeof(ColumnAttribute), 2000)]

    // EnforcementActionDataType
    [AppliedAttribute(typeof(EnforcementActionDataType), "ConsentAgreementFinalOrderSequenceNumber", typeof(ColumnAttribute), DbType.Int32)]
    [AppliedAttribute(typeof(EnforcementActionDataType), "Notes", typeof(ColumnAttribute), 2000)]

    // EvaluationDataType
    [AppliedAttribute(typeof(EvaluationDataType), "Notes", typeof(ColumnAttribute), 2000)]

    // EvaluationCommitmentDataType
    [AppliedAttribute(typeof(EvaluationCommitmentDataType), "CommitmentSequenceNumber", typeof(ColumnAttribute), DbType.Int32)]

    // EvaluationViolationDataType
    [AppliedAttribute(typeof(EvaluationViolationDataType), "ViolationSequenceNumber", typeof(ColumnAttribute), DbType.Int32)]

    // MediaDataType
    [AppliedAttribute(typeof(MediaDataType), "Notes", typeof(ColumnAttribute), 2000)]

    // MilestoneDataType
    [AppliedAttribute(typeof(MilestoneDataType), "MilestoneSequenceNumber", typeof(ColumnAttribute), DbType.Int32)]
    [AppliedAttribute(typeof(MilestoneDataType), "Notes", typeof(ColumnAttribute), 2000)]

    // PenaltyDataType
    [AppliedAttribute(typeof(PenaltyDataType), "Notes", typeof(ColumnAttribute), 2000)]

    // PaymentDataType
    [AppliedAttribute(typeof(PaymentDataType), "PaymentSequenceNumber", typeof(ColumnAttribute), DbType.Int32)]
    [AppliedAttribute(typeof(PaymentDataType), "Notes", typeof(ColumnAttribute), 2000)]

    // RequestDataType
    [AppliedAttribute(typeof(RequestDataType), "RequestSequenceNumber", typeof(ColumnAttribute), DbType.Int32)]
    [AppliedAttribute(typeof(RequestDataType), "Notes", typeof(ColumnAttribute), 2000)]

    // SupplementalEnvironmentalProjectDataType
    [AppliedAttribute(typeof(SupplementalEnvironmentalProjectDataType), "SEPSequenceNumber", typeof(ColumnAttribute), DbType.Int32)]
    [AppliedAttribute(typeof(SupplementalEnvironmentalProjectDataType), "Notes", typeof(ColumnAttribute), 2000)]

    // ViolationDataType
    [AppliedAttribute(typeof(ViolationDataType), "ViolationSequenceNumber", typeof(ColumnAttribute), DbType.Int32)]
    [AppliedAttribute(typeof(ViolationDataType), "Notes", typeof(ColumnAttribute), 2000)]

    // ViolationEnforcementDataType
    [AppliedAttribute(typeof(ViolationEnforcementDataType), "ViolationSequenceNumber", typeof(ColumnAttribute), DbType.Int32)]

    [ShortenNamesByRemovingVowelsFirstAttribute]

    [Table("RCRA_CME_HAZRD_WASTE_CME_SUBM")]
    public partial class HazardousWasteCMESubmissionDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey]
        public string _PK;
    }
    [Table("RCRA_CME_FAC_SUBM")]
    public partial class CMEFacilitySubmissionDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey]
        public string _PK;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey]
        public string _FK;
    }
    [Table("RCRA_CME_ENFRC_ACT")]
    public partial class EnforcementActionDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey]
        public string _PK;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey]
        public string _FK;
    }
    [Table("RCRA_CME_EVAL")]
    public partial class EvaluationDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey]
        public string _PK;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey]
        public string _FK;
    }
    [Table("RCRA_CME_VIOL")]
    public partial class ViolationDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey]
        public string _PK;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey]
        public string _FK;
    }
    [Table("RCRA_CME_CSNY_DATE")]
    public partial class CSNYDateDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey]
        public string _PK;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey]
        public string _FK;
    }
    [Table("RCRA_CME_PNLTY")]
    public partial class PenaltyDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey]
        public string _PK;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey]
        public string _FK;
    }
    [Table("RCRA_CME_MILESTONE")]
    public partial class MilestoneDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey]
        public string _PK;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey]
        public string _FK;
    }
    [Table("RCRA_CME_VIOL_ENFRC")]
    public partial class ViolationEnforcementDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey]
        public string _PK;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey]
        public string _FK;
    }
    [Table("RCRA_CME_SUPP_ENVR_PRJT")]
    public partial class SupplementalEnvironmentalProjectDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey]
        public string _PK;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey]
        public string _FK;
    }
    [Table("RCRA_CME_MEDIA")]
    public partial class MediaDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey]
        public string _PK;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey]
        public string _FK;
    }
    [Table("RCRA_CME_RQST")]
    public partial class RequestDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey]
        public string _PK;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey]
        public string _FK;
    }
    [Table("RCRA_CME_EVAL_COMMIT")]
    public partial class EvaluationCommitmentDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey]
        public string _PK;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey]
        public string _FK;
    }
    [Table("RCRA_CME_EVAL_VIOL")]
    public partial class EvaluationViolationDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey]
        public string _PK;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey]
        public string _FK;
    }
    [Table("RCRA_CME_CITATION")]
    public partial class CitationDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey]
        public string _PK;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey]
        public string _FK;
    }
    [Table("RCRA_CME_PYMT")]
    public partial class PaymentDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey]
        public string _PK;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey]
        public string _FK;
    }


    [DefaultTableNamePrefixAttribute("")]
    [DefaultStringDbValues(DbType.AnsiString, 255)]

    //RCRA_HD_CERTIFICATION
    [AppliedAttribute(typeof(CertificationDataType), "TransactionCode", typeof(ColumnAttribute), "TRANSACTION_CODE", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(CertificationDataType), "CertificationSequenceNumber", typeof(ColumnAttribute), "CERT_SEQ", DbType.Int32, false)]
    [AppliedAttribute(typeof(CertificationDataType), "SignedDate", typeof(ColumnAttribute), "CERT_SIGNED_DATE", DbType.AnsiString, 10)]
    [AppliedAttribute(typeof(CertificationDataType), "IndividualTitleText", typeof(ColumnAttribute), "CERT_TITLE", 45)]
    [AppliedAttribute(typeof(CertificationDataType), "FirstName", typeof(ColumnAttribute), "CERT_FIRST_NAME", 15)]
    [AppliedAttribute(typeof(CertificationDataType), "MiddleInitial", typeof(ColumnAttribute), "CERT_MIDDLE_INITIAL", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(CertificationDataType), "LastName", typeof(ColumnAttribute), "CERT_LAST_NAME", 15)]
    [AppliedAttribute(typeof(CertificationDataType), "CertificationSupplementalInformationText", typeof(ColumnAttribute), "NOTES", 245)]

    //RCRA_HD_ENV_PERMIT
    [AppliedAttribute(typeof(EnvironmentalPermitDataType), "TransactionCode", typeof(ColumnAttribute), "TRANSACTION_CODE", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(EnvironmentalPermitDataType), "EnvironmentalPermitID", typeof(ColumnAttribute), "ENV_PERMIT_NUMBER", 13, false)]
    [AppliedAttribute(typeof(EnvironmentalPermitDataType), "EnvironmentalPermitOwnerName", typeof(ColumnAttribute), "ENV_PERMIT_OWNER", DbType.AnsiStringFixedLength, 2)]
    [AppliedAttribute(typeof(EnvironmentalPermitDataType), "EnvironmentalPermitTypeCode", typeof(ColumnAttribute), "ENV_PERMIT_TYPE", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(EnvironmentalPermitDataType), "EnvironmentalPermitDescription", typeof(ColumnAttribute), "ENV_PERMIT_DESC", 20)]
    [AppliedAttribute(typeof(EnvironmentalPermitDataType), "EnvironmentalPermitSupplementalInformationText", typeof(ColumnAttribute), "NOTES", 240)]

    //RCRA_HD_HANDLER
    [AppliedAttribute(typeof(HandlerDataType), "TransactionCode", typeof(ColumnAttribute), "TRANSACTION_CODE", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(HandlerDataType), "ActivityLocationCode", typeof(ColumnAttribute), "ACTIVITY_LOCATION", DbType.AnsiStringFixedLength, 2, false)]
    [AppliedAttribute(typeof(HandlerDataType), "SourceTypeCode", typeof(ColumnAttribute), "SOURCE_TYPE", DbType.AnsiStringFixedLength, 1, false)]
    [AppliedAttribute(typeof(HandlerDataType), "SourceRecordSequenceNumber", typeof(ColumnAttribute), "SEQ_NUMBER", DbType.Int32, false)]
    [AppliedAttribute(typeof(HandlerDataType), "ReceiveDate", typeof(ColumnAttribute), "RECEIVE_DATE", DbType.AnsiString, 10)]
    [AppliedAttribute(typeof(HandlerDataType), "NonNotifierIndicator", typeof(ColumnAttribute), "NON_NOTIFIER", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(HandlerDataType), "OnsiteEmployeeQuantity", typeof(ColumnAttribute), "NUMBER_OF_EMPLOYEES", DbType.Int32)]
    [AppliedAttribute(typeof(LocationAddressDataType), "LocationAddressText", typeof(ColumnAttribute), "LOCATION_STREET1", 30)]
    [AppliedAttribute(typeof(LocationAddressDataType), "SupplementalLocationText", typeof(ColumnAttribute), "LOCATION_STREET2", 30)]
    [AppliedAttribute(typeof(LocationAddressDataType), "LocalityName", typeof(ColumnAttribute), "LOCATION_CITY", 25)]
    [AppliedAttribute(typeof(LocationAddressDataType), "StateUSPSCode", typeof(ColumnAttribute), "LOCATION_STATE", DbType.AnsiStringFixedLength, 2)]
    [AppliedAttribute(typeof(LocationAddressDataType), "LocationZIPCode", typeof(ColumnAttribute), "LOCATION_ZIP", 14)]
    [AppliedAttribute(typeof(LocationAddressDataType), "CountryName", typeof(ColumnAttribute), "LOCATION_COUNTRY", DbType.AnsiStringFixedLength, 2)]
    [AppliedPathAttribute("Handler.MailingAddress.MailingAddressText", typeof(ColumnAttribute), "MAIL_STREET1", 30)]
    [AppliedPathAttribute("Handler.MailingAddress.SupplementalAddressText", typeof(ColumnAttribute), "MAIL_STREET2", 30)]
    [AppliedPathAttribute("Handler.MailingAddress.MailingAddressCityName", typeof(ColumnAttribute), "MAIL_CITY", 25)]
    [AppliedPathAttribute("Handler.MailingAddress.MailingAddressStateUSPSCode", typeof(ColumnAttribute), "MAIL_STATE", DbType.AnsiStringFixedLength, 2)]
    [AppliedPathAttribute("Handler.MailingAddress.MailingAddressZIPCode", typeof(ColumnAttribute), "MAIL_ZIP", 14)]
    [AppliedPathAttribute("Handler.MailingAddress.MailingAddressCountryName", typeof(ColumnAttribute), "MAIL_COUNTRY", DbType.AnsiStringFixedLength, 2)]
    [AppliedPathAttribute("Handler.ContactAddress.Contact.FirstName", typeof(ColumnAttribute), "CONTACT_FIRST_NAME", 15)]
    [AppliedPathAttribute("Handler.ContactAddress.Contact.MiddleInitial", typeof(ColumnAttribute), "CONTACT_MIDDLE_INITIAL", DbType.AnsiStringFixedLength, 1)]
    [AppliedPathAttribute("Handler.ContactAddress.Contact.LastName", typeof(ColumnAttribute), "CONTACT_LAST_NAME", 15)]
    [AppliedPathAttribute("Handler.ContactAddress.Contact.OrganizationFormalName", typeof(ColumnAttribute), "CONTACT_ORG_NAME", 80)]
    [AppliedPathAttribute("Handler.ContactAddress.MailingAddress.MailingAddressText", typeof(ColumnAttribute), "CONTACT_STREET1", 30)]
    [AppliedPathAttribute("Handler.ContactAddress.MailingAddress.SupplementalAddressText", typeof(ColumnAttribute), "CONTACT_STREET2", 30)]
    [AppliedPathAttribute("Handler.ContactAddress.MailingAddress.MailingAddressCityName", typeof(ColumnAttribute), "CONTACT_CITY", 25)]
    [AppliedPathAttribute("Handler.ContactAddress.MailingAddress.MailingAddressStateUSPSCode", typeof(ColumnAttribute), "CONTACT_STATE", DbType.AnsiStringFixedLength, 2)]
    [AppliedPathAttribute("Handler.ContactAddress.MailingAddress.MailingAddressZIPCode", typeof(ColumnAttribute), "CONTACT_ZIP", 14)]
    [AppliedPathAttribute("Handler.ContactAddress.MailingAddress.MailingAddressCountryName", typeof(ColumnAttribute), "CONTACT_COUNTRY", DbType.AnsiStringFixedLength, 2)]
    [AppliedPathAttribute("Handler.ContactAddress.Contact.TelephoneNumberText", typeof(ColumnAttribute), "CONTACT_PHONE", 15)]
    [AppliedPathAttribute("Handler.ContactAddress.Contact.PhoneExtensionText", typeof(ColumnAttribute), "CONTACT_PHONE_EXT", 6)]
    [AppliedPathAttribute("Handler.ContactAddress.Contact.EmailAddressText", typeof(ColumnAttribute), "CONTACT_EMAIL_ADDRESS", 240)]
    [AppliedPathAttribute("Handler.PermitContactAddress.Contact.FirstName", typeof(ColumnAttribute), "PCONTACT_FIRST_NAME", 15)]
    [AppliedPathAttribute("Handler.PermitContactAddress.Contact.MiddleInitial", typeof(ColumnAttribute), "PCONTACT_MIDDLE_NAME", DbType.AnsiStringFixedLength, 1)]
    [AppliedPathAttribute("Handler.PermitContactAddress.Contact.LastName", typeof(ColumnAttribute), "PCONTACT_LAST_NAME", 15)]
    [AppliedPathAttribute("Handler.PermitContactAddress.Contact.OrganizationFormalName", typeof(ColumnAttribute), "PCONTACT_ORG_NAME", 80)]
    [AppliedPathAttribute("Handler.PermitContactAddress.MailingAddress.MailingAddressText", typeof(ColumnAttribute), "PCONTACT_STREET1", 30)]
    [AppliedPathAttribute("Handler.PermitContactAddress.MailingAddress.SupplementalAddressText", typeof(ColumnAttribute), "PCONTACT_STREET2", 30)]
    [AppliedPathAttribute("Handler.PermitContactAddress.MailingAddress.MailingAddressCityName", typeof(ColumnAttribute), "PCONTACT_CITY", 25)]
    [AppliedPathAttribute("Handler.PermitContactAddress.MailingAddress.MailingAddressStateUSPSCode", typeof(ColumnAttribute), "PCONTACT_STATE", DbType.AnsiStringFixedLength, 2)]
    [AppliedPathAttribute("Handler.PermitContactAddress.MailingAddress.MailingAddressZIPCode", typeof(ColumnAttribute), "PCONTACT_ZIP", 14)]
    [AppliedPathAttribute("Handler.PermitContactAddress.MailingAddress.MailingAddressCountryName", typeof(ColumnAttribute), "PCONTACT_COUNTRY", DbType.AnsiStringFixedLength, 2)]
    [AppliedPathAttribute("Handler.PermitContactAddress.Contact.TelephoneNumberText", typeof(ColumnAttribute), "PCONTACT_PHONE", 15)]
    [AppliedPathAttribute("Handler.PermitContactAddress.Contact.PhoneExtensionText", typeof(ColumnAttribute), "PCONTACT_PHONE_EXT", 6)]
    [AppliedPathAttribute("Handler.PermitContactAddress.Contact.EmailAddressText", typeof(ColumnAttribute), "PCONTACT_EMAIL_ADDRESS", 240)]
    [AppliedAttribute(typeof(HandlerDataType), "AcknowledgeReceiptDate", typeof(ColumnAttribute), "ACKNOWLEDGE_DATE", DbType.AnsiString, 10)]
    [AppliedAttribute(typeof(HandlerDataType), "AcknowledgeFlag", typeof(ColumnAttribute), "ACKNOWLEDGE_FLAG", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(SiteWasteActivityDataType), "FacilitySiteName", typeof(ColumnAttribute), "SITE_NAME", 80)]
    [AppliedAttribute(typeof(SiteWasteActivityDataType), "ImporterActivityCode", typeof(ColumnAttribute), "IMPORTER_ACTIVITY", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(SiteWasteActivityDataType), "MixedWasteGeneratorCode", typeof(ColumnAttribute), "MIXED_WASTE_GENERATOR", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(SiteWasteActivityDataType), "RecyclerActivityCode", typeof(ColumnAttribute), "RECYCLER_ACTIVITY", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(SiteWasteActivityDataType), "TransporterActivityCode", typeof(ColumnAttribute), "TRANSPORTER_ACTIVITY", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(SiteWasteActivityDataType), "TreatmentStorageDisposalActivityCode", typeof(ColumnAttribute), "TSD_ACTIVITY", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(SiteWasteActivityDataType), "UndergroundInjectionActivityCode", typeof(ColumnAttribute), "UNDERGROUND_INJECTION_ACTIVITY", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(SiteWasteActivityDataType), "UniversalWasteDestinationFacilityIndicator", typeof(ColumnAttribute), "UNIVERSAL_WASTE_DEST_FACILITY", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(SiteWasteActivityDataType), "OnsiteBurnerExemptionCode", typeof(ColumnAttribute), "ONSITE_BURNER_EXEMPTION", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(SiteWasteActivityDataType), "FurnaceExemptionCode", typeof(ColumnAttribute), "FURNACE_EXEMPTION", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(SiteWasteActivityDataType), "LandTypeCode", typeof(ColumnAttribute), "LAND_TYPE", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(SiteWasteActivityDataType), "StateDistrictCode", typeof(ColumnAttribute), "STATE_DISTRICT", 10)]
    [AppliedAttribute(typeof(UsedOilDataType), "FuelBurnerCode", typeof(ColumnAttribute), "USED_OIL_BURNER", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(UsedOilDataType), "ProcessorCode", typeof(ColumnAttribute), "USED_OIL_PROCESSOR", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(UsedOilDataType), "RefinerCode", typeof(ColumnAttribute), "USED_OIL_REFINER", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(UsedOilDataType), "MarketBurnerCode", typeof(ColumnAttribute), "USED_OIL_MARKET_BURNER", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(UsedOilDataType), "SpecificationMarketerCode", typeof(ColumnAttribute), "USED_OIL_SPEC_MARKETER", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(UsedOilDataType), "TransferFacilityCode", typeof(ColumnAttribute), "USED_OIL_TRANSFER_FACILITY", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(UsedOilDataType), "TransporterCode", typeof(ColumnAttribute), "USED_OIL_TRANSPORTER", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(HandlerDataType), "TreatmentStorageDisposalDate", typeof(ColumnAttribute), "TSD_DATE", DbType.AnsiString, 10)]
    [AppliedAttribute(typeof(HandlerDataType), "OffsiteWasteReceiptCode", typeof(ColumnAttribute), "OFF_SITE_RECEIPT", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(HandlerDataType), "AccessibilityCode", typeof(ColumnAttribute), "ACCESSIBILITY", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(HandlerDataType), "CountyCode", typeof(ColumnAttribute), "COUNTY_CODE", 5)]
    [AppliedAttribute(typeof(HandlerDataType), "CountyCodeOwner", typeof(ColumnAttribute), "COUNTY_CODE_OWNER", DbType.AnsiStringFixedLength, 2)]
    [AppliedPathAttribute("Handler.StateWasteGenerator.WasteGeneratorOwnerName", typeof(ColumnAttribute), "STATE_WASTE_GENERATOR_OWNER", DbType.AnsiStringFixedLength, 2)]
    [AppliedPathAttribute("Handler.StateWasteGenerator.WasteGeneratorStatusCode", typeof(ColumnAttribute), "STATE_WASTE_GENERATOR", DbType.AnsiStringFixedLength, 1)]
    [AppliedPathAttribute("Handler.FederalWasteGenerator.WasteGeneratorOwnerName", typeof(ColumnAttribute), "FED_WASTE_GENERATOR_OWNER", DbType.AnsiStringFixedLength, 2)]
    [AppliedPathAttribute("Handler.FederalWasteGenerator.WasteGeneratorStatusCode", typeof(ColumnAttribute), "FED_WASTE_GENERATOR", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(HandlerDataType), "HandlerSupplementalInformationText", typeof(ColumnAttribute), "NOTES", 2000)]

    //RCRA_HD_HBASIC
    [AppliedAttribute(typeof(FacilitySubmissionDataType), "TransactionCode", typeof(ColumnAttribute), "TRANSACTION_CODE", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(FacilitySubmissionDataType), "HandlerID", typeof(ColumnAttribute), "HANDLER_ID", 12)]
    [AppliedAttribute(typeof(FacilitySubmissionDataType), "PublicUseExtractIndicator", typeof(ColumnAttribute), "EXTRACT_FLAG", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(FacilitySubmissionDataType), "FacilityRegistryID", typeof(ColumnAttribute), "FACILITY_IDENTIFIER", 12)]
    [AppliedAttribute(typeof(FacilitySubmissionDataType), "FacilitySupplementalInformationText", typeof(ColumnAttribute), "NOTES", 240)]
    [AppliedAttribute(typeof(FacilitySubmissionDataType), "LastUpdateDate", typeof(ColumnAttribute), "LAST_UPDATE_DATE", DbType.Binary, 8)]

    //RCRA_HD_NAICS
    [AppliedAttribute(typeof(NAICSIdentityDataType), "TransactionCode", typeof(ColumnAttribute), "TRANSACTION_CODE", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(NAICSIdentityDataType), "NAICSSequenceNumber", typeof(ColumnAttribute), "NAICS_SEQ", DbType.Int32, false)]
    [AppliedAttribute(typeof(NAICSIdentityDataType), "NAICSOwnerCode", typeof(ColumnAttribute), "NAICS_OWNER", DbType.AnsiStringFixedLength, 2)]
    [AppliedAttribute(typeof(NAICSIdentityDataType), "NAICSCode", typeof(ColumnAttribute), "NAICS_CODE", 6)]
    [AppliedAttribute(typeof(NAICSIdentityDataType), "NAICSSupplementalInformationText", typeof(ColumnAttribute), "NOTES", 240)]

    //RCRA_HD_OTHER_ID
    [AppliedAttribute(typeof(OtherIDDataType), "TransactionCode", typeof(ColumnAttribute), "TRANSACTION_CODE", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(OtherIDDataType), "OtherHandlerID", typeof(ColumnAttribute), "OTHER_ID", 12)]
    [AppliedAttribute(typeof(OtherIDDataType), "RelationshipOwnerName", typeof(ColumnAttribute), "RELATIONSHIP_OWNER", DbType.AnsiStringFixedLength, 2)]
    [AppliedAttribute(typeof(OtherIDDataType), "RelationshipTypeCode", typeof(ColumnAttribute), "RELATIONSHIP_TYPE", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(OtherIDDataType), "SameFacilityIndicator", typeof(ColumnAttribute), "SAME_FACILITY", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(OtherIDDataType), "OtherIDSupplementalInformationText", typeof(ColumnAttribute), "NOTES", 2000)]

    //RCRA_HD_OWNEROP
    [AppliedAttribute(typeof(FacilityOwnerOperatorDataType), "TransactionCode", typeof(ColumnAttribute), "TRANSACTION_CODE", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(FacilityOwnerOperatorDataType), "OwnerOperatorSequenceNumber", typeof(ColumnAttribute), "OWNER_OP_SEQ", DbType.Int32, false)]
    [AppliedAttribute(typeof(FacilityOwnerOperatorDataType), "OwnerOperatorIndicator", typeof(ColumnAttribute), "OWNER_OP_IND", DbType.AnsiStringFixedLength, 2)]
    [AppliedPathAttribute("Handler.FacilityOwnerOperator.ContactAddress.Contact.FirstName", typeof(ColumnAttribute), "FIRST_NAME", 15)]
    [AppliedPathAttribute("Handler.FacilityOwnerOperator.ContactAddress.Contact.MiddleInitial", typeof(ColumnAttribute), "MIDDLE_INITIAL", DbType.AnsiStringFixedLength, 1)]
    [AppliedPathAttribute("Handler.FacilityOwnerOperator.ContactAddress.Contact.LastName", typeof(ColumnAttribute), "LAST_NAME", 15)]
    [AppliedPathAttribute("Handler.FacilityOwnerOperator.ContactAddress.Contact.OrganizationFormalName", typeof(ColumnAttribute), "ORG_NAME", 80)]
    [AppliedAttribute(typeof(FacilityOwnerOperatorDataType), "OwnerOperatorTypeCode", typeof(ColumnAttribute), "OWNER_OP_TYPE", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(FacilityOwnerOperatorDataType), "CurrentStartDate", typeof(ColumnAttribute), "DATE_BECAME_CURRENT", DbType.AnsiString, 10)]
    [AppliedAttribute(typeof(FacilityOwnerOperatorDataType), "CurrentEndDate", typeof(ColumnAttribute), "DATE_ENDED_CURRENT", DbType.AnsiString, 10)]
    [AppliedPathAttribute("Handler.FacilityOwnerOperator.ContactAddress.MailingAddress.MailingAddressText", typeof(ColumnAttribute), "STREET1", 30)]
    [AppliedPathAttribute("Handler.FacilityOwnerOperator.ContactAddress.MailingAddress.SupplementalAddressText", typeof(ColumnAttribute), "STREET2", 30)]
    [AppliedPathAttribute("Handler.FacilityOwnerOperator.ContactAddress.MailingAddress.MailingAddressCityName", typeof(ColumnAttribute), "CITY", 25)]
    [AppliedPathAttribute("Handler.FacilityOwnerOperator.ContactAddress.MailingAddress.MailingAddressStateUSPSCode", typeof(ColumnAttribute), "STATE", DbType.AnsiStringFixedLength, 2)]
    [AppliedPathAttribute("Handler.FacilityOwnerOperator.ContactAddress.MailingAddress.MailingAddressCountryName", typeof(ColumnAttribute), "COUNTRY", DbType.AnsiStringFixedLength, 2)]
    [AppliedPathAttribute("Handler.FacilityOwnerOperator.ContactAddress.MailingAddress.MailingAddressZIPCode", typeof(ColumnAttribute), "ZIP", 14)]
    [AppliedPathAttribute("Handler.FacilityOwnerOperator.ContactAddress.Contact.TelephoneNumberText", typeof(ColumnAttribute), "PHONE", 15)]
    [AppliedPathAttribute("Handler.FacilityOwnerOperator.ContactAddress.Contact.PhoneExtensionText", typeof(ColumnAttribute), "PHONE_EXT", 6)]
    [AppliedPathAttribute("Handler.FacilityOwnerOperator.ContactAddress.Contact.EmailAddressText", typeof(ColumnAttribute), "EMAIL_ADDRESS", 240)]
    [AppliedAttribute(typeof(FacilityOwnerOperatorDataType), "DUNSID", typeof(ColumnAttribute), "DUNN_BRADSTREET_NUM", 10)]
    [AppliedAttribute(typeof(FacilityOwnerOperatorDataType), "OwnerOperatorSupplementalInformationText", typeof(ColumnAttribute), "NOTES", 240)]

    //RCRA_HD_STATE_ACTIVITY
    [AppliedAttribute(typeof(StateActivityDataType), "TransactionCode", typeof(ColumnAttribute), "TRANSACTION_CODE", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(StateActivityDataType), "StateActivityOwnerName", typeof(ColumnAttribute), "STATE_ACTIVITY_OWNER", DbType.AnsiStringFixedLength, 2, false)]
    [AppliedAttribute(typeof(StateActivityDataType), "StateActivityTypeCode", typeof(ColumnAttribute), "STATE_ACTIVITY_TYPE", 5, false)]
    [AppliedAttribute(typeof(StateActivityDataType), "StateActivitySupplementalInformationText", typeof(ColumnAttribute), "NOTES", 2000)]

    //RCRA_HD_UNIVERSAL_WASTE
    [AppliedAttribute(typeof(UniversalWasteActivityDataType), "TransactionCode", typeof(ColumnAttribute), "TRANSACTION_CODE", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(UniversalWasteActivityDataType), "UniversalWasteOwnerName", typeof(ColumnAttribute), "UNIVERSAL_WASTE_OWNER", DbType.AnsiStringFixedLength, 2)]
    [AppliedAttribute(typeof(UniversalWasteActivityDataType), "UniversalWasteTypeCode", typeof(ColumnAttribute), "UNIVERSAL_WASTE_TYPE", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(UniversalWasteActivityDataType), "AccumulatedWasteCode", typeof(ColumnAttribute), "ACCUMULATED", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(UniversalWasteActivityDataType), "GeneratedHandlerCode", typeof(ColumnAttribute), "GENERATED", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(UniversalWasteActivityDataType), "UniversalWasteSupplementalInformationText", typeof(ColumnAttribute), "NOTES", 240)]

    //RCRA_HD_WASTE_CODE
    [AppliedAttribute(typeof(HandlerWasteCodeDataType), "TransactionCode", typeof(ColumnAttribute), "TRANSACTION_CODE", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(HandlerWasteCodeDataType), "WasteCodeOwnerName", typeof(ColumnAttribute), "WASTE_CODE_OWNER", DbType.AnsiStringFixedLength, 2)]
    [AppliedAttribute(typeof(HandlerWasteCodeDataType), "WasteCode", typeof(ColumnAttribute), "WASTE_CODE_TYPE", 6)]

    [Table("RCRA_HD_HBASIC")]
    public partial class FacilitySubmissionDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey]
        public string PkGuid;

        [System.Xml.Serialization.XmlIgnore]
        public string LastUpdateDate;
    }

    [Table("RCRA_HD_HANDLER")]
    public partial class HandlerDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey]
        public string PkGuid;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey]
        public string FkGuid;

        [System.Xml.Serialization.XmlIgnore]
        public string AcknowledgeFlag;
    }

    [Table("RCRA_HD_OTHER_ID")]
    public partial class OtherIDDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey]
        public string PkGuid;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey]
        public string FkGuid;
    }
    [Table("RCRA_HD_CERTIFICATION")]
    public partial class CertificationDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey]
        public string PkGuid;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey]
        public string FkGuid;
    }

    [Table("RCRA_HD_NAICS")]
    public partial class NAICSIdentityDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey]
        public string PkGuid;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey]
        public string FkGuid;
    }

    [Table("RCRA_HD_OWNEROP")]
    public partial class FacilityOwnerOperatorDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey]
        public string PkGuid;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey]
        public string FkGuid;
    }

    [Table("RCRA_HD_ENV_PERMIT")]
    public partial class EnvironmentalPermitDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey]
        public string PkGuid;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey]
        public string FkGuid;
    }
    [Table("RCRA_HD_STATE_ACTIVITY")]
    public partial class StateActivityDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey]
        public string PkGuid;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey]
        public string FkGuid;
    }
    [Table("RCRA_HD_UNIVERSAL_WASTE")]
    public partial class UniversalWasteActivityDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey]
        public string PkGuid;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey]
        public string FkGuid;
    }
    [Table("RCRA_HD_WASTE_CODE")]
    public partial class HandlerWasteCodeDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey]
        public string PkGuid;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey]
        public string FkGuid;
    }
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/4")]
    [System.Xml.Serialization.XmlRootAttribute("Contact", Namespace = "http://www.exchangenetwork.net/schema/RCRA/4", IsNullable = false)]
    public partial class ContactDataType
    {
        /// <remarks/>
        //[System.Xml.Serialization.XmlElementAttribute("FirstName", typeof(string), Order = 0)]
        //[System.Xml.Serialization.XmlElementAttribute("LastName", typeof(string), Order = 0)]
        //[System.Xml.Serialization.XmlElementAttribute("MiddleInitial", typeof(string), Order = 0)]
        //[System.Xml.Serialization.XmlElementAttribute("OrganizationFormalName", typeof(string), Order = 0)]
        //[System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        //public string[] Items;

        /// <remarks/>
        //[System.Xml.Serialization.XmlElementAttribute("ItemsElementName", Order = 1)]
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public ItemsChoiceType[] ItemsElementName;

        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string FirstName;

        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string LastName;

        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string MiddleInitial;

        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string OrganizationFormalName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Email address data")]
        public string EmailAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Telephone Number data")]
        public string TelephoneNumberText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Telephone number extension")]
        public string PhoneExtensionText;
    }
}