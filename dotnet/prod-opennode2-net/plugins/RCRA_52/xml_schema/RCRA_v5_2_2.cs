using System.Xml.Serialization;
using System.Data;
using System;
using System.Text;
using System.Collections.Generic;
using Windsor.Commons.XsdOrm;
using Windsor.Commons.Core;

namespace Windsor.Node2008.WNOSPlugin.RCRA_52
{
    internal static class RCRAHelper
    {
        public const string NAString = "N/A";
    }

    [DefaultTableNamePrefixAttribute("RCRA")]
    [DefaultStringDbValues(DbType.AnsiString, 255)]
    [DefaultDecimalPrecision(14, 6)]
    [UseTableNameForDefaultPrimaryKeysAttribute()]

    // HazardousWasteCMESubmissionDataType

    // CMEFacilitySubmissionDataType
    [AppliedAttribute(typeof(CMEFacilitySubmissionDataType), "", typeof(TableAttribute), "RCRA_CME_FAC_SUBM")]

    // CitationDataType
    [AppliedAttribute(typeof(CitationDataType), "", typeof(TableAttribute), "RCRA_CME_CITATION")]
    [AppliedAttribute(typeof(CitationDataType), "CitationNameSequenceNumber", typeof(ColumnAttribute), DbType.Int32)]
    [AppliedAttribute(typeof(CitationDataType), "Notes", typeof(ColumnAttribute), 2000)]
    [AppliedAttribute(typeof(CitationDataType), "CitationDescription", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(CitationDataType), "CitationName", typeof(ColumnAttribute), 128)]

    // EnforcementActionDataType
    [AppliedAttribute(typeof(EnforcementActionDataType), "", typeof(TableAttribute), "RCRA_CME_ENFRC_ACT")]
    [AppliedAttribute(typeof(EnforcementActionDataType), "EnforcementActionDate", typeof(ColumnAttribute), DbType.Date)]
    [AppliedAttribute(typeof(EnforcementActionDataType), "AppealInitiatedDate", typeof(ColumnAttribute), DbType.Date)]
    [AppliedAttribute(typeof(EnforcementActionDataType), "AppealResolutionDate", typeof(ColumnAttribute), DbType.Date)]
    [AppliedAttribute(typeof(EnforcementActionDataType), "DispositionStatusDate", typeof(ColumnAttribute), DbType.Date)]
    [AppliedAttribute(typeof(EnforcementActionDataType), "ConsentAgreementFinalOrderSequenceNumber", typeof(ColumnAttribute), DbType.Int32)]
    [AppliedAttribute(typeof(EnforcementActionDataType), "Notes", typeof(ColumnAttribute), 2000)]
    [AppliedAttribute(typeof(EnforcementActionDataType), "DispositionStatusText", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(EnforcementActionDataType), "EnforcementTypeText", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(EnforcementActionDataType), "RespondentName", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(EnforcementActionDataType), "AgencyText", typeof(DbIgnoreAttribute))]

    // EvaluationDataType
    [AppliedAttribute(typeof(EvaluationDataType), "", typeof(TableAttribute), "RCRA_CME_EVAL")]
    [AppliedAttribute(typeof(EvaluationDataType), "EvaluationStartDate", typeof(ColumnAttribute), DbType.Date)]
    [AppliedAttribute(typeof(EvaluationDataType), "DayZero", typeof(ColumnAttribute), DbType.Date)]
    [AppliedAttribute(typeof(EvaluationDataType), "Notes", typeof(ColumnAttribute), 2000)]
    [AppliedAttribute(typeof(EvaluationDataType), "EvaluationTypeText", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(EvaluationDataType), "FocusAreaText", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(EvaluationDataType), "AgencyText", typeof(DbIgnoreAttribute))]

    // EvaluationCommitmentDataType
    [AppliedAttribute(typeof(EvaluationCommitmentDataType), "", typeof(TableAttribute), "RCRA_CME_EVAL_COMMIT")]
    [AppliedAttribute(typeof(EvaluationCommitmentDataType), "CommitmentSequenceNumber", typeof(ColumnAttribute), DbType.Int32)]

    // EvaluationViolationDataType
    [AppliedAttribute(typeof(EvaluationViolationDataType), "", typeof(TableAttribute), "RCRA_CME_EVAL_VIOL")]
    [AppliedAttribute(typeof(EvaluationViolationDataType), "ViolationSequenceNumber", typeof(ColumnAttribute), DbType.Int32)]
    [AppliedAttribute(typeof(EvaluationViolationDataType), "AgencyText", typeof(DbIgnoreAttribute))]

    // MediaDataType
    [AppliedAttribute(typeof(MediaDataType), "", typeof(TableAttribute), "RCRA_CME_MEDIA")]
    [AppliedAttribute(typeof(MediaDataType), "Notes", typeof(ColumnAttribute), 2000)]

    // MilestoneDataType
    [AppliedAttribute(typeof(MilestoneDataType), "", typeof(TableAttribute), "RCRA_CME_MILESTONE")]
    [AppliedAttribute(typeof(MilestoneDataType), "MilestoneSequenceNumber", typeof(ColumnAttribute), DbType.Int32)]
    [AppliedAttribute(typeof(MilestoneDataType), "MilestoneScheduledCompletionDate", typeof(ColumnAttribute), DbType.Date)]
    [AppliedAttribute(typeof(MilestoneDataType), "MilestoneActualCompletionDate", typeof(ColumnAttribute), DbType.Date)]
    [AppliedAttribute(typeof(MilestoneDataType), "MilestoneDefaultedDate", typeof(ColumnAttribute), DbType.Date)]
    [AppliedAttribute(typeof(MilestoneDataType), "Notes", typeof(ColumnAttribute), 2000)]

    // PenaltyDataType
    [AppliedAttribute(typeof(PenaltyDataType), "", typeof(TableAttribute), "RCRA_CME_PNLTY")]
    [AppliedAttribute(typeof(PenaltyDataType), "Notes", typeof(ColumnAttribute), 2000)]
    [AppliedAttribute(typeof(PenaltyDataType), "PenaltyTypeText", typeof(DbIgnoreAttribute))]

    // PaymentDataType
    [AppliedAttribute(typeof(PaymentDataType), "", typeof(TableAttribute), "RCRA_CME_PYMT")]
    [AppliedAttribute(typeof(PaymentDataType), "PaymentSequenceNumber", typeof(ColumnAttribute), DbType.Int32)]
    [AppliedAttribute(typeof(PaymentDataType), "PaymentDefaultedDate", typeof(ColumnAttribute), DbType.Date)]
    [AppliedAttribute(typeof(PaymentDataType), "ScheduledPaymentDate", typeof(ColumnAttribute), DbType.Date)]
    [AppliedAttribute(typeof(PaymentDataType), "ActualPaymentDate", typeof(ColumnAttribute), DbType.Date)]
    [AppliedAttribute(typeof(PaymentDataType), "Notes", typeof(ColumnAttribute), 2000)]

    // RequestDataType
    [AppliedAttribute(typeof(RequestDataType), "", typeof(TableAttribute), "RCRA_CME_RQST")]
    [AppliedAttribute(typeof(RequestDataType), "RequestSequenceNumber", typeof(ColumnAttribute), DbType.Int32)]
    [AppliedAttribute(typeof(RequestDataType), "DateOfRequest", typeof(ColumnAttribute), DbType.Date)]
    [AppliedAttribute(typeof(RequestDataType), "DateResponseReceived", typeof(ColumnAttribute), DbType.Date)]
    [AppliedAttribute(typeof(RequestDataType), "Notes", typeof(ColumnAttribute), 2000)]
    [AppliedAttribute(typeof(RequestDataType), "AgencyText", typeof(DbIgnoreAttribute))]

    // SupplementalEnvironmentalProjectDataType
    [AppliedAttribute(typeof(SupplementalEnvironmentalProjectDataType), "", typeof(TableAttribute), "RCRA_CME_SUPP_ENVR_PRJT")]
    [AppliedAttribute(typeof(SupplementalEnvironmentalProjectDataType), "SEPSequenceNumber", typeof(ColumnAttribute), DbType.Int32)]
    [AppliedAttribute(typeof(SupplementalEnvironmentalProjectDataType), "SEPScheduledCompletionDate", typeof(ColumnAttribute), DbType.Date)]
    [AppliedAttribute(typeof(SupplementalEnvironmentalProjectDataType), "SEPActualDate", typeof(ColumnAttribute), DbType.Date)]
    [AppliedAttribute(typeof(SupplementalEnvironmentalProjectDataType), "SEPDefaultedDate", typeof(ColumnAttribute), DbType.Date)]
    [AppliedAttribute(typeof(SupplementalEnvironmentalProjectDataType), "Notes", typeof(ColumnAttribute), 2000)]
    [AppliedAttribute(typeof(SupplementalEnvironmentalProjectDataType), "SEPLongDescriptionText", typeof(DbIgnoreAttribute))]

    // ViolationDataType
    [AppliedAttribute(typeof(ViolationDataType), "", typeof(TableAttribute), "RCRA_CME_VIOL")]
    [AppliedAttribute(typeof(ViolationDataType), "ViolationSequenceNumber", typeof(ColumnAttribute), DbType.Int32)]
    [AppliedAttribute(typeof(ViolationDataType), "ViolationDeterminedDate", typeof(ColumnAttribute), DbType.Date)]
    [AppliedAttribute(typeof(ViolationDataType), "ReturnComplianceActualDate", typeof(ColumnAttribute), DbType.Date)]
    [AppliedAttribute(typeof(ViolationDataType), "Notes", typeof(ColumnAttribute), 2000)]
    [AppliedAttribute(typeof(ViolationDataType), "ReturnToComplianceQualifierText", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(ViolationDataType), "ViolationResponsibleAgencyText", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(ViolationDataType), "ViolationTypeText", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(ViolationDataType), "AgencyText", typeof(DbIgnoreAttribute))]

    // CSNYDateDataType
    [AppliedAttribute(typeof(CSNYDateDataType), "", typeof(TableAttribute), "RCRA_CME_CSNY_DATE")]
    [AppliedAttribute(typeof(CSNYDateDataType), "SNYDate", typeof(ColumnAttribute), DbType.Date)]

    // ViolationEnforcementDataType
    [AppliedAttribute(typeof(ViolationEnforcementDataType), "", typeof(TableAttribute), "RCRA_CME_VIOL_ENFRC")]
    [AppliedAttribute(typeof(ViolationEnforcementDataType), "ReturnComplianceScheduledDate", typeof(ColumnAttribute), DbType.Date)]
    [AppliedAttribute(typeof(ViolationEnforcementDataType), "ViolationSequenceNumber", typeof(ColumnAttribute), DbType.Int32)]
    [AppliedAttribute(typeof(ViolationEnforcementDataType), "AgencyText", typeof(DbIgnoreAttribute))]

    [ShortenNamesByRemovingVowelsFirstAttribute]

    [Table("RCRA_CME_SUBM")]
    public partial class HazardousWasteCMESubmissionDataType : BaseDataType
    {
    }
    public partial class CMEFacilitySubmissionDataType : BaseChildDataType
    {
    }
    public partial class EnforcementActionDataType : BaseChildDataType
    {
    }
    public partial class EvaluationDataType : BaseChildDataType
    {
    }
    public partial class ViolationDataType : BaseChildDataType
    {
    }
    public partial class CSNYDateDataType : BaseChildDataType
    {
    }
    public partial class PenaltyDataType : BaseChildDataType
    {
    }
    public partial class MilestoneDataType : BaseChildDataType
    {
    }
    public partial class ViolationEnforcementDataType : BaseChildDataType
    {
    }
    public partial class SupplementalEnvironmentalProjectDataType : BaseChildDataType
    {
    }
    public partial class MediaDataType : BaseChildDataType
    {
    }
    public partial class RequestDataType : BaseChildDataType
    {
    }
    public partial class EvaluationCommitmentDataType : BaseChildDataType
    {
    }
    public partial class EvaluationViolationDataType : BaseChildDataType
    {
    }
    public partial class CitationDataType : BaseChildDataType
    {
    }
    public partial class PaymentDataType : BaseChildDataType
    {
    }

    [DefaultTableNamePrefixAttribute("RCRA")]
    [DefaultStringDbValues(DbType.AnsiString, 255)]
    [DefaultDecimalPrecision(14, 6)]
    [UseTableNameForDefaultPrimaryKeysAttribute()]

    //RCRA_HD_CERTIFICATION
    [AppliedAttribute(typeof(CertificationDataType), "TransactionCode", typeof(ColumnAttribute), "TRANSACTION_CODE", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(CertificationDataType), "CertificationSequenceNumber", typeof(ColumnAttribute), "CERT_SEQ", DbType.Int32, false)]
    [AppliedAttribute(typeof(CertificationDataType), "SignedDate", typeof(ColumnAttribute), "CERT_SIGNED_DATE", DbType.AnsiString, 10)]
    [AppliedAttribute(typeof(CertificationDataType), "IndividualTitleText", typeof(ColumnAttribute), "CERT_TITLE", 45)]
    [AppliedAttribute(typeof(CertificationDataType), "FirstName", typeof(ColumnAttribute), "CERT_FIRST_NAME", 15)]
    [AppliedAttribute(typeof(CertificationDataType), "MiddleInitial", typeof(ColumnAttribute), "CERT_MIDDLE_INITIAL", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(CertificationDataType), "LastName", typeof(ColumnAttribute), "CERT_LAST_NAME", 15)]
    // REMOVED: [AppliedAttribute(typeof(CertificationDataType), "CertificationSupplementalInformationText", typeof(ColumnAttribute), "NOTES", 245)]

    //RCRA_HD_ENV_PERMIT
    [AppliedAttribute(typeof(EnvironmentalPermitDataType), "TransactionCode", typeof(ColumnAttribute), "TRANSACTION_CODE", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(EnvironmentalPermitDataType), "EnvironmentalPermitID", typeof(ColumnAttribute), "ENV_PERMIT_NUMBER", 13, false)]
    [AppliedAttribute(typeof(EnvironmentalPermitDataType), "EnvironmentalPermitOwnerName", typeof(ColumnAttribute), "ENV_PERMIT_OWNER", DbType.AnsiStringFixedLength, 2)]
    [AppliedAttribute(typeof(EnvironmentalPermitDataType), "EnvironmentalPermitTypeCode", typeof(ColumnAttribute), "ENV_PERMIT_TYPE", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(EnvironmentalPermitDataType), "EnvironmentalPermitDescription", typeof(ColumnAttribute), "ENV_PERMIT_DESC", 20)]
    // REMOVED: [AppliedAttribute(typeof(EnvironmentalPermitDataType), "EnvironmentalPermitSupplementalInformationText", typeof(ColumnAttribute), "NOTES", 240)]
    [AppliedAttribute(typeof(EnvironmentalPermitDataType), "EnvironmentalPermitTypeText", typeof(DbIgnoreAttribute))]

    //RCRA_HD_HANDLER
    [AppliedAttribute(typeof(HandlerDataType), "TransactionCode", typeof(ColumnAttribute), "TRANSACTION_CODE", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(HandlerDataType), "ActivityLocationCode", typeof(ColumnAttribute), "ACTIVITY_LOCATION", DbType.AnsiStringFixedLength, 2, false)]
    [AppliedAttribute(typeof(HandlerDataType), "SourceTypeCode", typeof(ColumnAttribute), "SOURCE_TYPE", DbType.AnsiStringFixedLength, 1, false)]
    [AppliedAttribute(typeof(HandlerDataType), "SourceRecordSequenceNumber", typeof(ColumnAttribute), "SEQ_NUMBER", DbType.Int32, false)]
    [AppliedAttribute(typeof(HandlerDataType), "ReceiveDate", typeof(ColumnAttribute), "RECEIVE_DATE", DbType.AnsiString, 10)]
    [AppliedAttribute(typeof(HandlerDataType), "HandlerName", typeof(ColumnAttribute), "HANDLER_NAME", DbType.AnsiString, 80)]
    [AppliedAttribute(typeof(HandlerDataType), "NonNotifierIndicator", typeof(ColumnAttribute), "NON_NOTIFIER", DbType.AnsiStringFixedLength, 1)]
    // REMOVED: [AppliedAttribute(typeof(HandlerDataType), "OnsiteEmployeeQuantity", typeof(ColumnAttribute), "NUMBER_OF_EMPLOYEES", DbType.Int32)]
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
    [AppliedPathAttribute("Handler.ContactAddress.Contact.FaxNumberText", typeof(ColumnAttribute), "CONTACT_FAX", 15)]
    [AppliedPathAttribute("Handler.ContactAddress.Contact.IndividualTitleText", typeof(ColumnAttribute), "CONTACT_TITLE", 80)]
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
    [AppliedPathAttribute("Handler.PermitContactAddress.Contact.FaxNumberText", typeof(ColumnAttribute), "PCONTACT_FAX", 15)]
    [AppliedPathAttribute("Handler.PermitContactAddress.Contact.IndividualTitleText", typeof(ColumnAttribute), "PCONTACT_TITLE", 80)]
    [AppliedPathAttribute("Handler.PermitContactAddress.Contact.EmailAddressText", typeof(ColumnAttribute), "PCONTACT_EMAIL_ADDRESS", 240)]
    [AppliedAttribute(typeof(HandlerDataType), "AcknowledgeReceiptDate", typeof(ColumnAttribute), "ACKNOWLEDGE_DATE", DbType.AnsiString, 10)]
    [AppliedAttribute(typeof(HandlerDataType), "AcknowledgeFlag", typeof(ColumnAttribute), "ACKNOWLEDGE_FLAG", DbType.AnsiStringFixedLength, 1)]
    // REMOVED: [AppliedAttribute(typeof(SiteWasteActivityDataType), "FacilitySiteName", typeof(ColumnAttribute), "SITE_NAME", 80)]
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
    [AppliedAttribute(typeof(SiteWasteActivityDataType), "StateDistrictOwnerName", typeof(ColumnAttribute), "STATE_DISTRICT_OWNER", DbType.AnsiStringFixedLength, 2)]
    [AppliedAttribute(typeof(SiteWasteActivityDataType), "StateDistrictCode", typeof(ColumnAttribute), "STATE_DISTRICT", 10)]
    [AppliedAttribute(typeof(SiteWasteActivityDataType), "ShortTermGeneratorIndicator", typeof(ColumnAttribute), "SHORT_TERM_GEN_IND", 50)]
    [AppliedAttribute(typeof(SiteWasteActivityDataType), "TransferFacilityIndicator", typeof(ColumnAttribute), "TRANSFER_FACILITY_IND", 50)]
    [AppliedAttribute(typeof(SiteWasteActivityDataType), "LandTypeText", typeof(DbIgnoreAttribute))]
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
    [AppliedAttribute(typeof(HandlerDataType), "CountyName", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(HandlerDataType), "SourceTypeText", typeof(DbIgnoreAttribute))]
    [AppliedPathAttribute("Handler.StateWasteGenerator.WasteGeneratorStatusText", typeof(DbIgnoreAttribute))]
    [AppliedPathAttribute("Handler.FederalWasteGenerator.WasteGeneratorStatusText", typeof(DbIgnoreAttribute))]
    [AppliedPathAttribute("Handler.HazardousSecondaryMaterial.NotificationReasonText", typeof(DbIgnoreAttribute))]

    //RCRA_HD_HBASIC
    [AppliedAttribute(typeof(FacilitySubmissionDataType), "TransactionCode", typeof(ColumnAttribute), "TRANSACTION_CODE", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(FacilitySubmissionDataType), "HandlerID", typeof(ColumnAttribute), "HANDLER_ID", 12)]
    [AppliedAttribute(typeof(FacilitySubmissionDataType), "PublicUseExtractIndicator", typeof(ColumnAttribute), "EXTRACT_FLAG", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(FacilitySubmissionDataType), "FacilityRegistryID", typeof(ColumnAttribute), "FACILITY_IDENTIFIER", 12)]
    // REMOVED: [AppliedAttribute(typeof(FacilitySubmissionDataType), "FacilitySupplementalInformationText", typeof(ColumnAttribute), "NOTES", 240)]
    [AppliedAttribute(typeof(FacilitySubmissionDataType), "DataAccessText", typeof(DbIgnoreAttribute))]

    //RCRA_HD_NAICS
    [AppliedAttribute(typeof(NAICSIdentityDataType), "TransactionCode", typeof(ColumnAttribute), "TRANSACTION_CODE", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(NAICSIdentityDataType), "NAICSSequenceNumber", typeof(ColumnAttribute), "NAICS_SEQ", DbType.Int32, false)]
    [AppliedAttribute(typeof(NAICSIdentityDataType), "NAICSOwnerCode", typeof(ColumnAttribute), "NAICS_OWNER", DbType.AnsiStringFixedLength, 2)]
    [AppliedAttribute(typeof(NAICSIdentityDataType), "NAICSCode", typeof(ColumnAttribute), "NAICS_CODE", 6)]
    // REMOVED: [AppliedAttribute(typeof(NAICSIdentityDataType), "NAICSSupplementalInformationText", typeof(ColumnAttribute), "NOTES", 240)]
    [AppliedAttribute(typeof(NAICSIdentityDataType), "NAICSText", typeof(DbIgnoreAttribute))]

    //RCRA_HD_OTHER_ID
    [AppliedAttribute(typeof(OtherIDDataType), "TransactionCode", typeof(ColumnAttribute), "TRANSACTION_CODE", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(OtherIDDataType), "OtherHandlerID", typeof(ColumnAttribute), "OTHER_ID", 12)]
    [AppliedAttribute(typeof(OtherIDDataType), "RelationshipOwnerName", typeof(ColumnAttribute), "RELATIONSHIP_OWNER", DbType.AnsiStringFixedLength, 2)]
    [AppliedAttribute(typeof(OtherIDDataType), "RelationshipTypeCode", typeof(ColumnAttribute), "RELATIONSHIP_TYPE", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(OtherIDDataType), "SameFacilityIndicator", typeof(ColumnAttribute), "SAME_FACILITY", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(OtherIDDataType), "OtherIDSupplementalInformationText", typeof(ColumnAttribute), "NOTES", 2000)]
    [AppliedAttribute(typeof(OtherIDDataType), "RelationshipTypeText", typeof(DbIgnoreAttribute))]

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
    [AppliedPathAttribute("Handler.FacilityOwnerOperator.ContactAddress.Contact.FaxNumberText", typeof(ColumnAttribute), "FAX", 15)]
    [AppliedPathAttribute("Handler.FacilityOwnerOperator.ContactAddress.Contact.IndividualTitleText", typeof(ColumnAttribute), "TITLE", 80)]
    [AppliedPathAttribute("Handler.FacilityOwnerOperator.ContactAddress.Contact.EmailAddressText", typeof(ColumnAttribute), "EMAIL_ADDRESS", 240)]
    // REMOVED: [AppliedAttribute(typeof(FacilityOwnerOperatorDataType), "DUNSID", typeof(ColumnAttribute), "DUNN_BRADSTREET_NUM", 10)]
    [AppliedAttribute(typeof(FacilityOwnerOperatorDataType), "OwnerOperatorSupplementalInformationText", typeof(ColumnAttribute), "NOTES", 240)]
    [AppliedAttribute(typeof(FacilityOwnerOperatorDataType), "OwnerOperatorText", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(FacilityOwnerOperatorDataType), "OwnerOperatorTypeText", typeof(DbIgnoreAttribute))]

    //RCRA_HD_STATE_ACTIVITY
    [AppliedAttribute(typeof(StateActivityDataType), "TransactionCode", typeof(ColumnAttribute), "TRANSACTION_CODE", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(StateActivityDataType), "StateActivityOwnerName", typeof(ColumnAttribute), "STATE_ACTIVITY_OWNER", DbType.AnsiStringFixedLength, 2, false)]
    [AppliedAttribute(typeof(StateActivityDataType), "StateActivityTypeCode", typeof(ColumnAttribute), "STATE_ACTIVITY_TYPE", 5, false)]
    // REMOVED: [AppliedAttribute(typeof(StateActivityDataType), "StateActivitySupplementalInformationText", typeof(ColumnAttribute), "NOTES", 2000)]
    [AppliedAttribute(typeof(StateActivityDataType), "StateActivityTypeText", typeof(DbIgnoreAttribute))]

    //RCRA_HD_UNIVERSAL_WASTE
    [AppliedAttribute(typeof(UniversalWasteActivityDataType), "TransactionCode", typeof(ColumnAttribute), "TRANSACTION_CODE", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(UniversalWasteActivityDataType), "UniversalWasteOwnerName", typeof(ColumnAttribute), "UNIVERSAL_WASTE_OWNER", DbType.AnsiStringFixedLength, 2)]
    [AppliedAttribute(typeof(UniversalWasteActivityDataType), "UniversalWasteTypeCode", typeof(ColumnAttribute), "UNIVERSAL_WASTE_TYPE", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(UniversalWasteActivityDataType), "AccumulatedWasteCode", typeof(ColumnAttribute), "ACCUMULATED", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(UniversalWasteActivityDataType), "GeneratedHandlerCode", typeof(ColumnAttribute), "GENERATED", DbType.AnsiStringFixedLength, 1)]
    // REMOVED: [AppliedAttribute(typeof(UniversalWasteActivityDataType), "UniversalWasteSupplementalInformationText", typeof(ColumnAttribute), "NOTES", 240)]
    [AppliedAttribute(typeof(UniversalWasteActivityDataType), "UniversalWasteTypeText", typeof(DbIgnoreAttribute))]

    //RCRA_HD_WASTE_CODE
    [AppliedAttribute(typeof(HandlerWasteCodeDataType), "TransactionCode", typeof(ColumnAttribute), "TRANSACTION_CODE", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(HandlerWasteCodeDataType), "WasteCodeOwnerName", typeof(ColumnAttribute), "WASTE_CODE_OWNER", DbType.AnsiStringFixedLength, 2)]
    [AppliedAttribute(typeof(HandlerWasteCodeDataType), "WasteCode", typeof(ColumnAttribute), "WASTE_CODE_TYPE", 6)]
    [AppliedAttribute(typeof(HandlerWasteCodeDataType), "WasteCodeText", typeof(DbIgnoreAttribute))]

    //RCRA_HD_SEC_WASTE_CODE
    [AppliedAttribute(typeof(SecondaryHandlerWasteCodeDataType), "TransactionCode", typeof(ColumnAttribute), "TRANSACTION_CODE", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(SecondaryHandlerWasteCodeDataType), "WasteCodeOwnerName", typeof(ColumnAttribute), "WASTE_CODE_OWNER", DbType.AnsiStringFixedLength, 2)]
    [AppliedAttribute(typeof(SecondaryHandlerWasteCodeDataType), "WasteCode", typeof(ColumnAttribute), "WASTE_CODE_TYPE", 6)]
    [AppliedAttribute(typeof(SecondaryHandlerWasteCodeDataType), "WasteCodeText", typeof(DbIgnoreAttribute))]

    // HazardousSecondaryMaterialActivityDataType
    [AppliedAttribute(typeof(HazardousSecondaryMaterialActivityDataType), "EstimatedShortTonsQuantity", typeof(ColumnAttribute), DbType.Int32)]
    [AppliedAttribute(typeof(HazardousSecondaryMaterialActivityDataType), "ActualShortTonsQuantity", typeof(ColumnAttribute), DbType.Int32)]
    [AppliedAttribute(typeof(HazardousSecondaryMaterialActivityDataType), "FacilityTypeText", typeof(DbIgnoreAttribute))]

    [Table("RCRA_HD_SUBM")]
    public partial class HazardousWasteHandlerSubmissionDataType : BaseDataType, IBeforeSaveToDatabase
    {
        public virtual void BeforeSaveToDatabase()
        {
            CollectionUtils.ForEach(FacilitySubmission, delegate(FacilitySubmissionDataType facility)
            {
                CollectionUtils.ForEach(facility.Handler, delegate(HandlerDataType handler)
                {
                    CollectionUtils.ForEach(handler.EnvironmentalPermit, delegate(EnvironmentalPermitDataType environmentalPermit)
                    {
                        if (string.IsNullOrEmpty(environmentalPermit.EnvironmentalPermitDescription))
                        {
                            environmentalPermit.EnvironmentalPermitDescription = RCRAHelper.NAString;
                        }
                    });

                });
            });
        }
    }

    [Table("RCRA_HD_HBASIC")]
    public partial class FacilitySubmissionDataType : BaseChildDataType
    {
    }

    [Table("RCRA_HD_HANDLER")]
    public partial class HandlerDataType : BaseChildDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        public string AcknowledgeFlag;
    }

    [Table("RCRA_HD_OTHER_ID")]
    public partial class OtherIDDataType : BaseChildDataType
    {
    }
    [Table("RCRA_HD_CERTIFICATION")]
    public partial class CertificationDataType : BaseChildDataType
    {
    }

    [Table("RCRA_HD_NAICS")]
    public partial class NAICSIdentityDataType : BaseChildDataType
    {
    }

    [Table("RCRA_HD_OWNEROP")]
    public partial class FacilityOwnerOperatorDataType : BaseChildDataType
    {
    }

    [Table("RCRA_HD_ENV_PERMIT")]
    public partial class EnvironmentalPermitDataType : BaseChildDataType
    {
    }
    [Table("RCRA_HD_STATE_ACTIVITY")]
    public partial class StateActivityDataType : BaseChildDataType
    {
    }
    [Table("RCRA_HD_UNIVERSAL_WASTE")]
    public partial class UniversalWasteActivityDataType : BaseChildDataType
    {
    }
    [Table("RCRA_HD_WASTE_CODE")]
    public partial class HandlerWasteCodeDataType : BaseChildDataType
    {
    }
    [Table("RCRA_HD_SEC_WASTE_CODE")]
    public partial class SecondaryHandlerWasteCodeDataType : HandlerWasteCodeDataType
    {
    }
    [Table("RCRA_HD_SEC_MATERIAL_ACTIVITY")]
    public partial class HazardousSecondaryMaterialActivityDataType : BaseChildDataType
    {
    }
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("Contact", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
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
        public string MiddleInitial;

        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string LastName;

        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string OrganizationFormalName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Title of the contact person or the title of the person who certified the handler " +
            "information reported to the authorizing agency.")]
        public string IndividualTitleText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Email address data")]
        public string EmailAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Telephone Number data")]
        public string TelephoneNumberText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Telephone number extension")]
        public string PhoneExtensionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Contact fax number")]
        public string FaxNumberText;
    }

    [DefaultTableNamePrefixAttribute("RCRA")]
    [DefaultStringDbValues(DbType.AnsiString, 255)]
    [DefaultDecimalPrecision(14, 6)]
    [ShortenNamesByRemovingVowelsFirstAttribute]
    [FixShortenNameBreakBugAttribute]
    [InheritAppliedAttributesAttribute]
    [UseTableNameForDefaultPrimaryKeysAttribute()]

    //CorrectiveActionFacilitySubmissionDataType
    [AppliedAttribute(typeof(CorrectiveActionFacilitySubmissionDataType), "HandlerID", typeof(ColumnAttribute), "HANDLER_ID", 12, false)]

    //CorrectiveActionAreaDataType
    [AppliedAttribute(typeof(CorrectiveActionAreaDataType), "TransactionCode", typeof(ColumnAttribute), 1)]
    [AppliedAttribute(typeof(CorrectiveActionAreaDataType), "AreaSequenceNumber", typeof(ColumnAttribute), DbType.Int32)]
    [AppliedAttribute(typeof(CorrectiveActionAreaDataType), "FacilityWideIndicator", typeof(ColumnAttribute), 1)]
    [AppliedAttribute(typeof(CorrectiveActionAreaDataType), "AreaName", typeof(ColumnAttribute), 40)]
    [AppliedAttribute(typeof(CorrectiveActionAreaDataType), "AirReleaseIndicator", typeof(ColumnAttribute), 1)]
    [AppliedAttribute(typeof(CorrectiveActionAreaDataType), "GroundwaterReleaseIndicator", typeof(ColumnAttribute), 1)]
    [AppliedAttribute(typeof(CorrectiveActionAreaDataType), "SoilReleaseIndicator", typeof(ColumnAttribute), 1)]
    [AppliedAttribute(typeof(CorrectiveActionAreaDataType), "SurfaceWaterReleaseIndicator", typeof(ColumnAttribute), 1)]
    [AppliedAttribute(typeof(CorrectiveActionAreaDataType), "RegulatedUnitIndicator", typeof(ColumnAttribute), 1)]
    [AppliedAttribute(typeof(CorrectiveActionAreaDataType), "EPAResponsiblePersonDataOwnerCode", typeof(ColumnAttribute), 2)]
    [AppliedAttribute(typeof(CorrectiveActionAreaDataType), "EPAResponsiblePersonID", typeof(ColumnAttribute), 5)]
    [AppliedAttribute(typeof(CorrectiveActionAreaDataType), "StateResponsiblePersonDataOwnerCode", typeof(ColumnAttribute), 2)]
    [AppliedAttribute(typeof(CorrectiveActionAreaDataType), "StateResponsiblePersonID", typeof(ColumnAttribute), 5)]
    [AppliedAttribute(typeof(CorrectiveActionAreaDataType), "SupplementalInformationText", typeof(ColumnAttribute), 2000)]

    //CorrectiveActionRelatedEventDataType
    [AppliedAttribute(typeof(CorrectiveActionRelatedEventDataType), "TransactionCode", typeof(ColumnAttribute), 1)]
    [AppliedAttribute(typeof(CorrectiveActionRelatedEventDataType), "ActivityLocationCode", typeof(ColumnAttribute), 2)]
    [AppliedAttribute(typeof(CorrectiveActionRelatedEventDataType), "CorrectiveActionEventDataOwnerCode", typeof(ColumnAttribute), 2)]
    [AppliedAttribute(typeof(CorrectiveActionRelatedEventDataType), "CorrectiveActionEventCode", typeof(ColumnAttribute), 7)]
    [AppliedAttribute(typeof(CorrectiveActionRelatedEventDataType), "EventAgencyCode", typeof(ColumnAttribute), 1)]
    [AppliedAttribute(typeof(CorrectiveActionRelatedEventDataType), "EventSequenceNumber", typeof(ColumnAttribute), DbType.Int32)]
    [AppliedAttribute(typeof(CorrectiveActionRelatedEventDataType), "CorrectiveActionEventText", typeof(DbIgnoreAttribute))]

    //CorrectiveActionRelatedPermitUnitDataType
    [AppliedAttribute(typeof(CorrectiveActionRelatedPermitUnitDataType), "TransactionCode", typeof(ColumnAttribute), 1)]
    [AppliedAttribute(typeof(CorrectiveActionRelatedPermitUnitDataType), "PermitUnitSequenceNumber", typeof(ColumnAttribute), DbType.Int32)]

    //CorrectiveActionAuthorityDataType
    [AppliedAttribute(typeof(CorrectiveActionAuthorityDataType), "TransactionCode", typeof(ColumnAttribute), 1)]
    [AppliedAttribute(typeof(CorrectiveActionAuthorityDataType), "ActivityLocationCode", typeof(ColumnAttribute), 2)]
    [AppliedAttribute(typeof(CorrectiveActionAuthorityDataType), "AuthorityDataOwnerCode", typeof(ColumnAttribute), 2)]
    [AppliedAttribute(typeof(CorrectiveActionAuthorityDataType), "AuthorityTypeCode", typeof(ColumnAttribute), 1)]
    [AppliedAttribute(typeof(CorrectiveActionAuthorityDataType), "AuthorityAgencyCode", typeof(ColumnAttribute), 1)]
    [AppliedAttribute(typeof(CorrectiveActionAuthorityDataType), "AuthorityEffectiveDate", typeof(ColumnAttribute), DbType.Date)]
    [AppliedAttribute(typeof(CorrectiveActionAuthorityDataType), "IssueDate", typeof(ColumnAttribute), DbType.Date)]
    [AppliedAttribute(typeof(CorrectiveActionAuthorityDataType), "EndDate", typeof(ColumnAttribute), DbType.Date)]
    [AppliedAttribute(typeof(CorrectiveActionAuthorityDataType), "EstablishedRepositoryCode", typeof(ColumnAttribute), 1)]
    [AppliedAttribute(typeof(CorrectiveActionAuthorityDataType), "ResponsibleLeadProgramIdentifier", typeof(ColumnAttribute), 1)]
    [AppliedAttribute(typeof(CorrectiveActionAuthorityDataType), "AuthoritySuborganizationDataOwnerCode", typeof(ColumnAttribute), 2)]
    [AppliedAttribute(typeof(CorrectiveActionAuthorityDataType), "AuthoritySuborganizationCode", typeof(ColumnAttribute), 10)]
    [AppliedAttribute(typeof(CorrectiveActionAuthorityDataType), "ResponsiblePersonDataOwnerCode", typeof(ColumnAttribute), 2)]
    [AppliedAttribute(typeof(CorrectiveActionAuthorityDataType), "ResponsiblePersonID", typeof(ColumnAttribute), 5)]
    [AppliedAttribute(typeof(CorrectiveActionAuthorityDataType), "SupplementalInformationText", typeof(ColumnAttribute), 2000)]
    [AppliedAttribute(typeof(CorrectiveActionAuthorityDataType), "AgencyText", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(CorrectiveActionAuthorityDataType), "AuthorityTypeText", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(CorrectiveActionAuthorityDataType), "EstablishedRepositoryText", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(CorrectiveActionAuthorityDataType), "ResponsibleLeadProgramText", typeof(DbIgnoreAttribute))]

    //CorrectiveActionStatutoryCitationDataType
    [AppliedAttribute(typeof(CorrectiveActionStatutoryCitationDataType), "TransactionCode", typeof(ColumnAttribute), 1)]
    [AppliedAttribute(typeof(CorrectiveActionStatutoryCitationDataType), "StatutoryCitationDataOwnerCode", typeof(ColumnAttribute), 2)]
    [AppliedAttribute(typeof(CorrectiveActionStatutoryCitationDataType), "StatutoryCitationIdentifier", typeof(ColumnAttribute), 1)]
    [AppliedAttribute(typeof(CorrectiveActionStatutoryCitationDataType), "StatutoryCitationDescription", typeof(DbIgnoreAttribute))]

    //CorrectiveActionEventDataType
    [AppliedAttribute(typeof(CorrectiveActionEventDataType), "TransactionCode", typeof(ColumnAttribute), 1)]
    [AppliedAttribute(typeof(CorrectiveActionEventDataType), "ActivityLocationCode", typeof(ColumnAttribute), 2)]
    [AppliedAttribute(typeof(CorrectiveActionEventDataType), "CorrectiveActionEventDataOwnerCode", typeof(ColumnAttribute), 2)]
    [AppliedAttribute(typeof(CorrectiveActionEventDataType), "CorrectiveActionEventCode", typeof(ColumnAttribute), 7)]
    [AppliedAttribute(typeof(CorrectiveActionEventDataType), "EventAgencyCode", typeof(ColumnAttribute), 1)]
    [AppliedAttribute(typeof(CorrectiveActionEventDataType), "EventSequenceNumber", typeof(ColumnAttribute), DbType.Int32)]
    [AppliedAttribute(typeof(CorrectiveActionEventDataType), "ActualDate", typeof(ColumnAttribute), DbType.Date)]
    [AppliedAttribute(typeof(CorrectiveActionEventDataType), "OriginalScheduleDate", typeof(ColumnAttribute), DbType.Date)]
    [AppliedAttribute(typeof(CorrectiveActionEventDataType), "NewScheduleDate", typeof(ColumnAttribute), DbType.Date)]
    [AppliedAttribute(typeof(CorrectiveActionEventDataType), "EventSuborganizationDataOwnerCode", typeof(ColumnAttribute), 2)]
    [AppliedAttribute(typeof(CorrectiveActionEventDataType), "EventSuborganizationCode", typeof(ColumnAttribute), 10)]
    [AppliedAttribute(typeof(CorrectiveActionEventDataType), "ResponsiblePersonDataOwnerCode", typeof(ColumnAttribute), 2)]
    [AppliedAttribute(typeof(CorrectiveActionEventDataType), "ResponsiblePersonID", typeof(ColumnAttribute), 5)]
    [AppliedAttribute(typeof(CorrectiveActionEventDataType), "SupplementalInformationText", typeof(ColumnAttribute), 2000)]
    [AppliedAttribute(typeof(CorrectiveActionEventDataType), "AgencyText", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(CorrectiveActionEventDataType), "CorrectiveActionEventText", typeof(DbIgnoreAttribute))]

    //EventCommitmentDataType
    [AppliedAttribute(typeof(EventCommitmentDataType), "TransactionCode", typeof(ColumnAttribute), 1)]
    [AppliedAttribute(typeof(EventCommitmentDataType), "CommitmentLead", typeof(ColumnAttribute), 2)]
    [AppliedAttribute(typeof(EventCommitmentDataType), "CommitmentSequenceNumber", typeof(ColumnAttribute), DbType.Int32)]

    //HazardousWasteCorrectiveActionDataType

    [AppliedAttribute(typeof(CorrectiveActionAreaRelatedEventDataType), "AgencyText", typeof(DbIgnoreAttribute))]

    [AppliedAttribute(typeof(CorrectiveActionAuthorityRelatedEventDataType), "AgencyText", typeof(DbIgnoreAttribute))]

    [Table("RCRA_CA_SUBM")]
    public partial class HazardousWasteCorrectiveActionDataType : BaseDataType
    {
    }
    [Table("RCRA_CA_FAC_SUBM")]
    public partial class CorrectiveActionFacilitySubmissionDataType : BaseChildDataType
    {
    }
    [Table("RCRA_CA_AREA")]
    public partial class CorrectiveActionAreaDataType : BaseChildDataType
    {
    }
    [Table("RCRA_CA_AUTHORITY")]
    public partial class CorrectiveActionAuthorityDataType : BaseChildDataType
    {
    }
    [Table("RCRA_CA_EVENT")]
    public partial class CorrectiveActionEventDataType : BaseChildDataType
    {
    }
    public partial class CorrectiveActionRelatedEventDataType : BaseChildDataType
    {
    }
    [Table("RCRA_CA_AREA_REL_EVENT")]
    public class CorrectiveActionAreaRelatedEventDataType : CorrectiveActionRelatedEventDataType
    {
    }
    [Table("RCRA_CA_REL_PERMIT_UNIT")]
    public partial class CorrectiveActionRelatedPermitUnitDataType : BaseChildDataType
    {
    }
    [Table("RCRA_CA_STATUTORY_CITATION")]
    public partial class CorrectiveActionStatutoryCitationDataType : BaseChildDataType
    {
    }
    [Table("RCRA_CA_AUTH_REL_EVENT")]
    public class CorrectiveActionAuthorityRelatedEventDataType : CorrectiveActionRelatedEventDataType
    {
    }
    public partial class EventCommitmentDataType : BaseChildDataType
    {
    }
    [Table("RCRA_CA_EVENT_COMMITMENT")]
    public class EventEventCommitmentDataType : EventCommitmentDataType
    {
    }

    [DefaultTableNamePrefixAttribute("RCRA")]
    [DefaultStringDbValues(DbType.AnsiString, 255)]
    [DefaultDecimalPrecision(14, 6)]
    [ShortenNamesByRemovingVowelsFirstAttribute]
    [FixShortenNameBreakBugAttribute]
    [InheritAppliedAttributesAttribute]
    [UseTableNameForDefaultPrimaryKeysAttribute()]

    //PermitFacilitySubmissionDataType
    [AppliedAttribute(typeof(PermitFacilitySubmissionDataType), "HandlerID", typeof(ColumnAttribute), "HANDLER_ID", 12, false)]

    //PermitSeriesDataType
    [AppliedAttribute(typeof(PermitSeriesDataType), "TransactionCode", typeof(ColumnAttribute), 1)]
    [AppliedAttribute(typeof(PermitSeriesDataType), "PermitSeriesSequenceNumber", typeof(ColumnAttribute), DbType.Int32)]
    [AppliedAttribute(typeof(PermitSeriesDataType), "PermitSeriesName", typeof(ColumnAttribute), 40)]
    [AppliedAttribute(typeof(PermitSeriesDataType), "ResponsiblePersonDataOwnerCode", typeof(ColumnAttribute), 2)]
    [AppliedAttribute(typeof(PermitSeriesDataType), "ResponsiblePersonID", typeof(ColumnAttribute), 5)]
    [AppliedAttribute(typeof(PermitSeriesDataType), "SupplementalInformationText", typeof(ColumnAttribute), 2000)]

    //PermitEventDataType
    [AppliedAttribute(typeof(PermitEventDataType), "TransactionCode", typeof(ColumnAttribute), 1)]
    [AppliedAttribute(typeof(PermitEventDataType), "ActivityLocationCode", typeof(ColumnAttribute), 2)]
    [AppliedAttribute(typeof(PermitEventDataType), "PermitEventDataOwnerCode", typeof(ColumnAttribute), 2)]
    [AppliedAttribute(typeof(PermitEventDataType), "PermitEventCode", typeof(ColumnAttribute), 7)]
    [AppliedAttribute(typeof(PermitEventDataType), "EventAgencyCode", typeof(ColumnAttribute), 1)]
    [AppliedAttribute(typeof(PermitEventDataType), "EventSequenceNumber", typeof(ColumnAttribute), DbType.Int32)]
    [AppliedAttribute(typeof(PermitEventDataType), "ActualDate", typeof(ColumnAttribute), DbType.Date)]
    [AppliedAttribute(typeof(PermitEventDataType), "OriginalScheduleDate", typeof(ColumnAttribute), DbType.Date)]
    [AppliedAttribute(typeof(PermitEventDataType), "NewScheduleDate", typeof(ColumnAttribute), DbType.Date)]
    [AppliedAttribute(typeof(PermitEventDataType), "ResponsiblePersonDataOwnerCode", typeof(ColumnAttribute), 2)]
    [AppliedAttribute(typeof(PermitEventDataType), "ResponsiblePersonID", typeof(ColumnAttribute), 5)]
    [AppliedAttribute(typeof(PermitEventDataType), "EventSuborganizationDataOwnerCode", typeof(ColumnAttribute), 2)]
    [AppliedAttribute(typeof(PermitEventDataType), "EventSuborganizationCode", typeof(ColumnAttribute), 10)]
    [AppliedAttribute(typeof(PermitEventDataType), "SupplementalInformationText", typeof(ColumnAttribute), 2000)]
    [AppliedAttribute(typeof(PermitEventDataType), "AgencyText", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(PermitEventDataType), "PermitEventText", typeof(DbIgnoreAttribute))]

    //PermitUnitDataType
    [AppliedAttribute(typeof(PermitUnitDataType), "TransactionCode", typeof(ColumnAttribute), 1)]
    [AppliedAttribute(typeof(PermitUnitDataType), "PermitUnitSequenceNumber", typeof(ColumnAttribute), DbType.Int32)]
    [AppliedAttribute(typeof(PermitUnitDataType), "PermitUnitName", typeof(ColumnAttribute), 40)]
    [AppliedAttribute(typeof(PermitUnitDataType), "SupplementalInformationText", typeof(ColumnAttribute), 2000)]

    //PermitUnitDetailDataType
    [AppliedAttribute(typeof(PermitUnitDetailDataType), "TransactionCode", typeof(ColumnAttribute), 1)]
    [AppliedAttribute(typeof(PermitUnitDetailDataType), "PermitUnitDetailSequenceNumber", typeof(ColumnAttribute), DbType.Int32)]
    [AppliedAttribute(typeof(PermitUnitDetailDataType), "ProcessUnitDataOwnerCode", typeof(ColumnAttribute), 2)]
    [AppliedAttribute(typeof(PermitUnitDetailDataType), "ProcessUnitCode", typeof(ColumnAttribute), 3)]
    [AppliedAttribute(typeof(PermitUnitDetailDataType), "PermitStatusEffectiveDate", typeof(ColumnAttribute), DbType.Date)]
    //Not needed: [AppliedAttribute(typeof(PermitUnitDetailDataType), "PermitUnitCapacityQuantity", typeof(ColumnAttribute))]
    [AppliedAttribute(typeof(PermitUnitDetailDataType), "CapacityTypeCode", typeof(ColumnAttribute), 1)]
    [AppliedAttribute(typeof(PermitUnitDetailDataType), "CommercialStatusCode", typeof(ColumnAttribute), 1)]
    [AppliedAttribute(typeof(PermitUnitDetailDataType), "LegalOperatingStatusDataOwnerCode", typeof(ColumnAttribute), 2)]
    [AppliedAttribute(typeof(PermitUnitDetailDataType), "LegalOperatingStatusCode", typeof(ColumnAttribute), 4)]
    [AppliedAttribute(typeof(PermitUnitDetailDataType), "MeasurementUnitDataOwnerCode", typeof(ColumnAttribute), 2)]
    [AppliedAttribute(typeof(PermitUnitDetailDataType), "MeasurementUnitCode", typeof(ColumnAttribute), 1)]
    [AppliedAttribute(typeof(PermitUnitDetailDataType), "NumberOfUnitsCount", typeof(ColumnAttribute), DbType.Int32)]
    [AppliedAttribute(typeof(PermitUnitDetailDataType), "StandardPermitIndicator", typeof(ColumnAttribute), 1)]
    [AppliedAttribute(typeof(PermitUnitDetailDataType), "SupplementalInformationText", typeof(ColumnAttribute), 2000)]
    [AppliedAttribute(typeof(PermitUnitDetailDataType), "CapacityTypeText", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(PermitUnitDetailDataType), "CommercialStatusText", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(PermitUnitDetailDataType), "LegalOperatingStatusText", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(PermitUnitDetailDataType), "MeasurementUnitText", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(PermitUnitDetailDataType), "ProcessUnitText", typeof(DbIgnoreAttribute))]

    //PermitRelatedEventDataType
    [AppliedAttribute(typeof(PermitRelatedEventDataType), "TransactionCode", typeof(ColumnAttribute), 1)]
    [AppliedAttribute(typeof(PermitRelatedEventDataType), "ActivityLocationCode", typeof(ColumnAttribute), 2)]
    [AppliedAttribute(typeof(PermitRelatedEventDataType), "PermitSeriesSequenceNumber", typeof(ColumnAttribute), DbType.Int32)]
    [AppliedAttribute(typeof(PermitRelatedEventDataType), "PermitEventDataOwnerCode", typeof(ColumnAttribute), 2)]
    [AppliedAttribute(typeof(PermitRelatedEventDataType), "PermitEventCode", typeof(ColumnAttribute), 7)]
    [AppliedAttribute(typeof(PermitRelatedEventDataType), "EventAgencyCode", typeof(ColumnAttribute), 1)]
    [AppliedAttribute(typeof(PermitRelatedEventDataType), "EventSequenceNumber", typeof(ColumnAttribute), DbType.Int32)]
    [AppliedAttribute(typeof(PermitRelatedEventDataType), "AgencyText", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(PermitRelatedEventDataType), "PermitEventText", typeof(DbIgnoreAttribute))]

    //PermitHandlerWasteCodeDataType
    [AppliedAttribute(typeof(PermitHandlerWasteCodeDataType), "TransactionCode", typeof(ColumnAttribute), "TRANSACTION_CODE", 1)]
    [AppliedAttribute(typeof(PermitHandlerWasteCodeDataType), "WasteCodeOwnerName", typeof(ColumnAttribute), "WASTE_CODE_OWNER", 2)]
    [AppliedAttribute(typeof(PermitHandlerWasteCodeDataType), "WasteCode", typeof(ColumnAttribute), "WASTE_CODE_TYPE", 6)]
    [AppliedAttribute(typeof(PermitHandlerWasteCodeDataType), "WasteCodeText", typeof(DbIgnoreAttribute))]

    //EventCommitmentDataType
    [AppliedAttribute(typeof(EventCommitmentDataType), "TransactionCode", typeof(ColumnAttribute), 1)]
    [AppliedAttribute(typeof(EventCommitmentDataType), "CommitmentLead", typeof(ColumnAttribute), 2)]
    [AppliedAttribute(typeof(EventCommitmentDataType), "CommitmentSequenceNumber", typeof(ColumnAttribute), DbType.Int32)]

    //HazardousWastePermitDataType

    [Table("RCRA_PRM_SUBM")]
    public partial class HazardousWastePermitDataType : BaseDataType
    {
    }
    [Table("RCRA_PRM_FAC_SUBM")]
    public partial class PermitFacilitySubmissionDataType : BaseChildDataType
    {
    }
    [Table("RCRA_PRM_SERIES")]
    public partial class PermitSeriesDataType : BaseChildDataType
    {
    }
    [Table("RCRA_PRM_UNIT")]
    public partial class PermitUnitDataType : BaseChildDataType
    {
    }
    [Table("RCRA_PRM_EVENT")]
    public partial class PermitEventDataType : BaseChildDataType
    {
    }
    [Table("RCRA_PRM_UNIT_DETAIL")]
    public partial class PermitUnitDetailDataType : BaseChildDataType
    {
    }
    [Table("RCRA_PRM_EVENT_COMMITMENT")]
    public class PermitEventCommitmentDataType : EventCommitmentDataType
    {
    }
    [Table("RCRA_PRM_RELATED_EVENT")]
    public partial class PermitRelatedEventDataType : BaseChildDataType
    {
    }
    [Table("RCRA_PRM_WASTE_CODE")]
    public partial class PermitHandlerWasteCodeDataType : HandlerWasteCodeDataType
    {
    }

    [DefaultTableNamePrefixAttribute("RCRA")]
    [DefaultStringDbValues(DbType.AnsiString, 255)]
    [DefaultDecimalPrecision(14, 6)]
    [ShortenNamesByRemovingVowelsFirstAttribute]
    [FixShortenNameBreakBugAttribute]
    [InheritAppliedAttributesAttribute]
    [UseTableNameForDefaultPrimaryKeysAttribute()]

    //FinancialAssuranceFacilitySubmissionDataType
    [AppliedAttribute(typeof(FinancialAssuranceFacilitySubmissionDataType), "HandlerID", typeof(ColumnAttribute), "HANDLER_ID", 12, false)]

    //CostEstimateDataType
    [AppliedAttribute(typeof(CostEstimateDataType), "TransactionCode", typeof(ColumnAttribute), 1)]
    [AppliedAttribute(typeof(CostEstimateDataType), "ActivityLocationCode", typeof(ColumnAttribute), 2)]
    [AppliedAttribute(typeof(CostEstimateDataType), "CostEstimateTypeCode", typeof(ColumnAttribute), 1)]
    [AppliedAttribute(typeof(CostEstimateDataType), "CostEstimateAgencyCode", typeof(ColumnAttribute), 1)]
    [AppliedAttribute(typeof(CostEstimateDataType), "CostEstimateSequenceNumber", typeof(ColumnAttribute), DbType.Int32)]
    [AppliedAttribute(typeof(CostEstimateDataType), "ResponsiblePersonDataOwnerCode", typeof(ColumnAttribute), 2)]
    [AppliedAttribute(typeof(CostEstimateDataType), "ResponsiblePersonID", typeof(ColumnAttribute), 5)]
    //Not needed: [AppliedAttribute(typeof(CostEstimateDataType), "CostEstimateAmount", typeof(ColumnAttribute))]
    [AppliedAttribute(typeof(CostEstimateDataType), "CostEstimateDate", typeof(ColumnAttribute), DbType.Date)]
    [AppliedAttribute(typeof(CostEstimateDataType), "CostEstimateReasonCode", typeof(ColumnAttribute), 1)]
    [AppliedAttribute(typeof(CostEstimateDataType), "AreaUnitNotesText", typeof(ColumnAttribute), 240)]
    [AppliedAttribute(typeof(CostEstimateDataType), "SupplementalInformationText", typeof(ColumnAttribute), 2000)]
    [AppliedAttribute(typeof(CostEstimateDataType), "AgencyText", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(CostEstimateDataType), "CostEstimateReasonText", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(CostEstimateDataType), "CostEstimateTypeText", typeof(DbIgnoreAttribute))]

    //CostEstimateRelatedMechanismDataType
    [AppliedAttribute(typeof(CostEstimateRelatedMechanismDataType), "TransactionCode", typeof(ColumnAttribute), 1)]
    [AppliedAttribute(typeof(CostEstimateRelatedMechanismDataType), "ActivityLocationCode", typeof(ColumnAttribute), 2)]
    [AppliedAttribute(typeof(CostEstimateRelatedMechanismDataType), "MechanismAgencyCode", typeof(ColumnAttribute), 1)]
    [AppliedAttribute(typeof(CostEstimateRelatedMechanismDataType), "MechanismSequenceNumber", typeof(ColumnAttribute), DbType.Int32)]
    [AppliedAttribute(typeof(CostEstimateRelatedMechanismDataType), "MechanismDetailSequenceNumber", typeof(ColumnAttribute), DbType.Int32)]
    [AppliedAttribute(typeof(CostEstimateRelatedMechanismDataType), "AgencyText", typeof(DbIgnoreAttribute))]

    //MechanismDataType
    [AppliedAttribute(typeof(MechanismDataType), "TransactionCode", typeof(ColumnAttribute), 1)]
    [AppliedAttribute(typeof(MechanismDataType), "ActivityLocationCode", typeof(ColumnAttribute), 2)]
    [AppliedAttribute(typeof(MechanismDataType), "MechanismAgencyCode", typeof(ColumnAttribute), 1)]
    [AppliedAttribute(typeof(MechanismDataType), "MechanismSequenceNumber", typeof(ColumnAttribute), DbType.Int32)]
    [AppliedAttribute(typeof(MechanismDataType), "MechanismTypeDataOwnerCode", typeof(ColumnAttribute), 2)]
    [AppliedAttribute(typeof(MechanismDataType), "MechanismTypeCode", typeof(ColumnAttribute), 1)]
    [AppliedAttribute(typeof(MechanismDataType), "ProviderText", typeof(ColumnAttribute), 80)]
    [AppliedAttribute(typeof(MechanismDataType), "ProviderFullContactName", typeof(ColumnAttribute), 33)]
    [AppliedAttribute(typeof(MechanismDataType), "TelephoneNumberText", typeof(ColumnAttribute), 15)]
    [AppliedAttribute(typeof(MechanismDataType), "SupplementalInformationText", typeof(ColumnAttribute), 2000)]
    [AppliedAttribute(typeof(MechanismDataType), "AgencyText", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(MechanismDataType), "MechanismTypeText", typeof(DbIgnoreAttribute))]

    //MechanismDetailDataType
    [AppliedAttribute(typeof(MechanismDetailDataType), "TransactionCode", typeof(ColumnAttribute), 1)]
    [AppliedAttribute(typeof(MechanismDetailDataType), "MechanismDetailSequenceNumber", typeof(ColumnAttribute), DbType.Int32)]
    [AppliedAttribute(typeof(MechanismDetailDataType), "MechanismIdentificationText", typeof(ColumnAttribute), 40)]
    //Not needed: [AppliedAttribute(typeof(MechanismDetailDataType), "FaceValueAmount", typeof(ColumnAttribute))]
    [AppliedAttribute(typeof(MechanismDetailDataType), "EffectiveDate", typeof(ColumnAttribute), DbType.Date)]
    [AppliedAttribute(typeof(MechanismDetailDataType), "ExpirationDate", typeof(ColumnAttribute), DbType.Date)]
    [AppliedAttribute(typeof(MechanismDetailDataType), "SupplementalInformationText", typeof(ColumnAttribute), 2000)]

    //FinancialAssuranceSubmissionDataType

    [Table("RCRA_FA_SUBM")]
    public partial class FinancialAssuranceSubmissionDataType : BaseDataType
    {
    }
    [Table("RCRA_FA_FAC_SUBM")]
    public partial class FinancialAssuranceFacilitySubmissionDataType : BaseChildDataType
    {
    }
    [Table("RCRA_FA_COST_EST")]
    public partial class CostEstimateDataType : BaseChildDataType
    {
    }
    [Table("RCRA_FA_MECHANISM")]
    public partial class MechanismDataType : BaseChildDataType
    {
    }
    [Table("RCRA_FA_COST_EST_REL_MECHANISM")]
    public partial class CostEstimateRelatedMechanismDataType : BaseChildDataType
    {
    }
    [Table("RCRA_FA_MECHANISM_DETAIL")]
    public partial class MechanismDetailDataType : BaseChildDataType
    {
    }

    [DefaultTableNamePrefixAttribute("RCRA")]
    [DefaultStringDbValues(DbType.AnsiString, 255)]
    [DefaultDecimalPrecision(14, 6)]
    [ShortenNamesByRemovingVowelsFirstAttribute]
    [FixShortenNameBreakBugAttribute]
    [InheritAppliedAttributesAttribute]
    [UseTableNameForDefaultPrimaryKeysAttribute()]

    //GISFacilitySubmissionDataType
    [AppliedAttribute(typeof(GISFacilitySubmissionDataType), "HandlerID", typeof(ColumnAttribute), "HANDLER_ID", 12, false)]

    //GeographicInformationDataType
    [AppliedAttribute(typeof(GeographicInformationDataType), "TransactionCode", typeof(ColumnAttribute), 1)]
    [AppliedAttribute(typeof(GeographicInformationDataType), "GeographicInformationOwner", typeof(ColumnAttribute), 2, false)]
    [AppliedAttribute(typeof(GeographicInformationDataType), "GeographicInformationSequenceNumber", typeof(ColumnAttribute), DbType.Int32)]
    [AppliedAttribute(typeof(GeographicInformationDataType), "PermitUnitSequenceNumber", typeof(ColumnAttribute), DbType.Int32)]
    [AppliedAttribute(typeof(GeographicInformationDataType), "AreaSequenceNumber", typeof(ColumnAttribute), DbType.Int32)]
    [AppliedAttribute(typeof(GeographicInformationDataType), "LocationCommentsText", typeof(ColumnAttribute), 2000)]

    //AreaAcreageDataType
    //Not needed: [AppliedAttribute(typeof(AreaAcreageDataType), "AreaAcreageMeasure", typeof(ColumnAttribute))]
    [AppliedAttribute(typeof(AreaAcreageDataType), "AreaMeasureSourceDataOwnerCode", typeof(ColumnAttribute), 2)]
    [AppliedAttribute(typeof(AreaAcreageDataType), "AreaMeasureSourceCode", typeof(ColumnAttribute), 8)]
    [AppliedAttribute(typeof(AreaAcreageDataType), "AreaMeasureDate", typeof(ColumnAttribute), DbType.Date)]
    [AppliedAttribute(typeof(AreaAcreageDataType), "AreaMeasureSourceText", typeof(DbIgnoreAttribute))]

    //GeographicMetadataDataType
    [AppliedAttribute(typeof(GeographicMetadataDataType), "DataCollectionDate", typeof(ColumnAttribute), DbType.Date, false)]
    [AppliedAttribute(typeof(GeographicMetadataDataType), "HorizontalAccuracyMeasure", typeof(ColumnAttribute), DbType.Int32)]
    [AppliedAttribute(typeof(GeographicMetadataDataType), "SourceMapScaleNumeric", typeof(ColumnAttribute), DbType.Int32)]
    [AppliedAttribute(typeof(GeographicMetadataDataType), "CoordinateDataSourceDataOwnerCode", typeof(ColumnAttribute), 2)]
    [AppliedAttribute(typeof(GeographicMetadataDataType), "CoordinateDataSourceCode", typeof(ColumnAttribute), 3)]
    [AppliedAttribute(typeof(GeographicMetadataDataType), "GeographicReferencePointDataOwnerCode", typeof(ColumnAttribute), 2)]
    [AppliedAttribute(typeof(GeographicMetadataDataType), "GeographicReferencePointCode", typeof(ColumnAttribute), 3)]
    [AppliedAttribute(typeof(GeographicMetadataDataType), "GeometricTypeDataOwnerCode", typeof(ColumnAttribute), 2)]
    [AppliedAttribute(typeof(GeographicMetadataDataType), "GeometricTypeCode", typeof(ColumnAttribute), 3)]
    [AppliedAttribute(typeof(GeographicMetadataDataType), "HorizontalCollectionMethodDataOwnerCode", typeof(ColumnAttribute), 2)]
    [AppliedAttribute(typeof(GeographicMetadataDataType), "HorizontalCollectionMethodCode", typeof(ColumnAttribute), 3)]
    [AppliedAttribute(typeof(GeographicMetadataDataType), "HorizontalCoordinateReferenceSystemDatumDataOwnerCode", typeof(ColumnAttribute), 2)]
    [AppliedAttribute(typeof(GeographicMetadataDataType), "HorizontalCoordinateReferenceSystemDatumCode", typeof(ColumnAttribute), 3)]
    [AppliedAttribute(typeof(GeographicMetadataDataType), "VerificationMethodDataOwnerCode", typeof(ColumnAttribute), 2)]
    [AppliedAttribute(typeof(GeographicMetadataDataType), "VerificationMethodCode", typeof(ColumnAttribute), 3)]
    [AppliedAttribute(typeof(GeographicMetadataDataType), "CoordinateDataSourceName", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(GeographicMetadataDataType), "GeographicReferencePointName", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(GeographicMetadataDataType), "GeometricTypeName", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(GeographicMetadataDataType), "HorizontalCollectionMethodName", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(GeographicMetadataDataType), "HorizontalCoordinateReferenceSystemDatumName", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(GeographicMetadataDataType), "VerificationMethodName", typeof(DbIgnoreAttribute))]

    //PointType
    [AppliedAttribute(typeof(PointType), "id", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(AbstractGMLType), "id", typeof(DbIgnoreAttribute))]

    //AbstractGeometryType
    [AppliedAttribute(typeof(AbstractGeometryType), "srsName", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(AbstractGeometryType), "srsDimension", typeof(DbIgnoreAttribute))]

    //GeographicInformationSubmissionDataType

    [Table("RCRA_GIS_SUBM")]
    public partial class GeographicInformationSubmissionDataType : BaseDataType, IBeforeSaveToDatabase, IAfterLoadFromDatabase
    {
        public void BeforeSaveToDatabase()
        {
            ProcessPoints(true);
        }
        public void AfterLoadFromDatabase()
        {
            ProcessPoints(false);
        }
        protected void ProcessPoints(bool isBeforeSaveToDatabase)
        {
            if (GISFacilitySubmission != null)
            {
                foreach (GISFacilitySubmissionDataType facSubm in GISFacilitySubmission)
                {
                    if (facSubm.GeographicInformation != null)
                    {
                        foreach (GeographicInformationDataType geoInfo in facSubm.GeographicInformation)
                        {
                            if ((geoInfo.where != null) && (geoInfo.where.Point != null))
                            {
                                if (isBeforeSaveToDatabase)
                                {
                                    geoInfo.where.Point.BeforeSaveToDatabase();
                                }
                                else
                                {
                                    geoInfo.where.Point.AfterLoadFromDatabase();
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    [Table("RCRA_GIS_FAC_SUBM")]
    public partial class GISFacilitySubmissionDataType : BaseChildDataType
    {
    }
    [Table("RCRA_GIS_GEO_INFORMATION")]
    public partial class GeographicInformationDataType : BaseChildDataType
    {
    }
    public class LatLongElev
    {
        public LatLongElev()
        {
        }
        public LatLongElev(decimal latitude, decimal longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
        [XmlIgnore]
        [Column("LATITUDE", ColumnSize = 19, ColumnScale = 14)]
        public decimal Latitude;

        [XmlIgnore]
        [Column("LONGITUDE", ColumnSize = 19, ColumnScale = 14)]
        public decimal Longitude;

        [XmlIgnore]
        [Column("ELEVATION", ColumnSize = 19, ColumnScale = 14)]
        public decimal Elevation;

        [XmlIgnore]
        public bool ElevationSpecified;

        public static string DecToStr(decimal value)
        {
            return value.ToString().TrimEnd('0').TrimEnd('.');
        }
        public override string ToString()
        {
            if (ElevationSpecified)
            {
                return string.Format("{0} {1} {2}", DecToStr(Latitude), DecToStr(Longitude),
                                     DecToStr(Elevation));
            }
            else
            {
                return string.Format("{0} {1}", DecToStr(Latitude), DecToStr(Longitude));
            }
        }
        public void InitFromText(string latLongText, string srsDimension)
        {
            if (string.IsNullOrEmpty(latLongText))
            {
                throw new MappingException("string.IsNullOrEmpty(latLongText)");
            }
            if (string.IsNullOrEmpty(srsDimension))
            {
                srsDimension = "2";
                // Assume 2 if not specified
                //                throw new MappingException("string.IsNullOrEmpty(srsDimension)");
            }
            decimal[] decimals = LatLongElev.ParseDecimalText(latLongText);

            if (srsDimension == "2")
            {
                if (decimals.Length != 2)
                {
                    throw new MappingException("srsDimension == 2, but digitsStrings.Length == {0}, {1}",
                                               decimals.Length, latLongText);
                }
                ElevationSpecified = false;
            }
            else if (srsDimension == "3")
            {
                if (decimals.Length != 3)
                {
                    throw new MappingException("srsDimension == 3, but digitsStrings.Length == {0}, {1}",
                                               decimals.Length, latLongText);
                }
                ElevationSpecified = true;
                Elevation = decimals[2];
            }
            else
            {
                throw new MappingException("srsDimension not supported: {0}",
                                           srsDimension);
            }
            Latitude = decimals[0];
            Longitude = decimals[1];
        }
        public static LatLongElev FromText(string latLongText, string srsDimension)
        {
            LatLongElev latLongElev = new LatLongElev();
            latLongElev.InitFromText(latLongText, srsDimension);
            return latLongElev;
        }
        public static decimal[] ParseDecimalText(string text)
        {
            string trimmedText = text.Trim();
            if (string.IsNullOrEmpty(text))
            {
                return null;
            }
            string[] elements = trimmedText.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (elements.Length == 0)
            {
                return null;
            }
            List<decimal> decimals = new List<decimal>(elements.Length);
            foreach (string element in elements)
            {
                string decimalString = element.Trim();
                if (string.IsNullOrEmpty(decimalString))
                {
                    continue;
                }
                decimal value;
                if (!decimal.TryParse(decimalString, out value))
                {
                    throw new MappingException("Failed to parse decimal value \"{0}\" from text \"{1}\"",
                                               decimalString, text);
                }
                decimals.Add(value);
            }
            return decimals.ToArray();
        }
    }
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml")]
    [System.Xml.Serialization.XmlRootAttribute("Point", Namespace = "http://www.opengis.net/gml", IsNullable = false)]
    public partial class PointType : AbstractGeometricPrimitiveType
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("pos", Order = 0)]
        [DbIgnore]
        public DirectPositionType Item;

        [XmlIgnore]
        public LatLongElev LatLongElev;

        public void BeforeSaveToDatabase()
        {
            if (Item != null)
            {
                if (!string.IsNullOrEmpty(Item.srsName))
                {
                    this.srsName = Item.srsName;
                }
                else
                {
                    Item.srsName = this.srsName;
                }
                if (!string.IsNullOrEmpty(Item.srsDimension))
                {
                    this.srsDimension = Item.srsDimension;
                }
                else
                {
                    Item.srsDimension = this.srsDimension;
                }
                if (LatLongElev == null)
                {
                    LatLongElev = LatLongElev.FromText(Item.Text, srsDimension);
                }
            }
        }
        public void AfterLoadFromDatabase()
        {
            if (LatLongElev != null)
            {
                Item = new DirectPositionType();
                Item.srsDimension = LatLongElev.ElevationSpecified ? "3" : "2";
                Item.Text = LatLongElev.ToString();
            }
        }

    }

    [DefaultTableNamePrefixAttribute("RCRA")]
    [UseTableNameForDefaultPrimaryKeysAttribute()]

    [AppliedAttribute(typeof(SubmissionHistoryDataType), "ScheduleRunDate", typeof(ColumnAttribute), "SCHEDULERUNDATE", DbType.Date)]
    [AppliedAttribute(typeof(SubmissionHistoryDataType), "TransactionId", typeof(ColumnAttribute), "TRANSACTIONID", 50)]
    [AppliedAttribute(typeof(SubmissionHistoryDataType), "ProcessingStatus", typeof(ColumnAttribute), "PROCESSINGSTATUS", 50)]

    [Table("RCRA_SUBMISSIONHISTORY")]
    public partial class SubmissionHistoryDataType : BaseDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [DbNotNull]
        public DateTime ScheduleRunDate;

        [System.Xml.Serialization.XmlIgnore]
        [DbNotNull]
        public string TransactionId;

        [System.Xml.Serialization.XmlIgnore]
        [DbNotNull]
        public string ProcessingStatus;
    }
}