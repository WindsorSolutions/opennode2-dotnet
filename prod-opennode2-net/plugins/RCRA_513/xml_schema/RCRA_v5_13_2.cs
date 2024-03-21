using System.Xml.Serialization;
using System.Data;
using System;
using System.Text;
using System.Collections.Generic;
using Windsor.Commons.XsdOrm;
using Windsor.Commons.Core;
using System.Linq;

namespace Windsor.Node2008.WNOSPlugin.RCRA_513
{
    internal static class RCRAHelper
    {
        public const string NAString = "N/A";
    }

    [DefaultTableNamePrefixAttribute("RCRA")]
    [DefaultStringDbValues(DbType.AnsiString, 255)]
    [DefaultDecimalPrecision(14, 6)]
    [UseTableNameForDefaultPrimaryKeysAttribute()]
    [DefaultFixedStringDbMaxLengthAttribute(2)]

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
    [AppliedAttribute(typeof(EnforcementActionDataType), "FinancialAssuranceReq", typeof(ColumnAttribute), "FA_REQUIRED", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(EnforcementActionDataType), "FinancialAssuranceReqD", typeof(DbIgnoreAttribute))]

    // EvaluationDataType
    [AppliedAttribute(typeof(EvaluationDataType), "", typeof(TableAttribute), "RCRA_CME_EVAL")]
    [AppliedAttribute(typeof(EvaluationDataType), "EvaluationStartDate", typeof(ColumnAttribute), DbType.Date)]
    [AppliedAttribute(typeof(EvaluationDataType), "DayZero", typeof(ColumnAttribute), DbType.Date)]
    [AppliedAttribute(typeof(EvaluationDataType), "Notes", typeof(ColumnAttribute), 2000)]
    [AppliedAttribute(typeof(EvaluationDataType), "EvaluationTypeText", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(EvaluationDataType), "FocusAreaText", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(EvaluationDataType), "AgencyText", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(EvaluationDataType), "NOCDate", typeof(ColumnAttribute), "NOC_DATE", DbType.Date)]

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
    [AppliedAttribute(typeof(PenaltyDataType), "CashCivilPenaltySoughtAmount", typeof(ColumnAttribute), DbType.Decimal, 13, 2)]


    // PaymentDataType
    [AppliedAttribute(typeof(PaymentDataType), "", typeof(TableAttribute), "RCRA_CME_PYMT")]
    [AppliedAttribute(typeof(PaymentDataType), "PaymentSequenceNumber", typeof(ColumnAttribute), DbType.Int32)]
    [AppliedAttribute(typeof(PaymentDataType), "PaymentDefaultedDate", typeof(ColumnAttribute), DbType.Date)]
    [AppliedAttribute(typeof(PaymentDataType), "ScheduledPaymentAmount", typeof(ColumnAttribute), DbType.Decimal, 13, 2)]
    [AppliedAttribute(typeof(PaymentDataType), "ScheduledPaymentDate", typeof(ColumnAttribute), DbType.Date)]
    [AppliedAttribute(typeof(PaymentDataType), "ActualPaidAmount", typeof(ColumnAttribute), DbType.Decimal, 13, 2)]
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
    [AppliedAttribute(typeof(SupplementalEnvironmentalProjectDataType), "SEPExpenditureAmount", typeof(ColumnAttribute), DbType.Decimal, 13, 2)]
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
    public partial class HazardousWasteCMESubmissionDataType : BaseDataType, IBeforeSaveToDatabase, IAfterLoadFromDatabase
    {
        public virtual void BeforeSaveToDatabase()
        {
            CollectionUtils.ForEach(CMEFacilitySubmission, delegate (CMEFacilitySubmissionDataType facility)
            {
                CollectionUtils.ForEach(facility.EnforcementAction, delegate (EnforcementActionDataType action)
                {
                    action.BeforeSaveToDatabase();
                });
            });
        }
        public virtual void AfterLoadFromDatabase()
        {
            CollectionUtils.ForEach(CMEFacilitySubmission, delegate (CMEFacilitySubmissionDataType facility)
            {
                CollectionUtils.ForEach(facility.EnforcementAction, delegate (EnforcementActionDataType action)
                {
                    action.AfterLoadFromDatabase();
                });
            });
        }
    }
    public partial class CMEFacilitySubmissionDataType : BaseChildDataType
    {
    }
    public partial class EnforcementActionDataType : BaseChildDataType, IBeforeSaveToDatabase, IAfterLoadFromDatabase
    {
        [XmlIgnore]
        public string FinancialAssuranceReq;

        public virtual void BeforeSaveToDatabase()
        {
            if (!CollectionUtils.IsNullOrEmpty(FinancialAssuranceReqD))
            {
                FinancialAssuranceReq = FinancialAssuranceReqD;
            }
        }
        public virtual void AfterLoadFromDatabase()
        {
            if (!string.IsNullOrEmpty(FinancialAssuranceReq))
            {
                FinancialAssuranceReqD = FinancialAssuranceReq;
            }
        }
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
    [DefaultFixedStringDbMaxLengthAttribute(2)]

    //RCRA_HD_CERTIFICATION
    [AppliedAttribute(typeof(CertificationDataType), "TransactionCode", typeof(ColumnAttribute), "TRANSACTION_CODE", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(CertificationDataType), "CertificationSequenceNumber", typeof(ColumnAttribute), "CERT_SEQ", DbType.Int32, false)]
    [AppliedAttribute(typeof(CertificationDataType), "SignedDate", typeof(ColumnAttribute), "CERT_SIGNED_DATE", DbType.AnsiString, 10)]
    [AppliedAttribute(typeof(CertificationDataType), "IndividualTitleText", typeof(ColumnAttribute), "CERT_TITLE", 45)]
    [AppliedAttribute(typeof(CertificationDataType), "FirstName", typeof(ColumnAttribute), "CERT_FIRST_NAME", 38)]
    [AppliedAttribute(typeof(CertificationDataType), "MiddleInitial", typeof(ColumnAttribute), "CERT_MIDDLE_INITIAL", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(CertificationDataType), "LastName", typeof(ColumnAttribute), "CERT_LAST_NAME", 38)]
    [AppliedAttribute(typeof(CertificationDataType), "CertificationEmailText", typeof(ColumnAttribute), "CERT_EMAIL_TEXT", 80)]
    // REMOVED: [AppliedAttribute(typeof(CertificationDataType), "CertificationSupplementalInformationText", typeof(ColumnAttribute), "NOTES", 245)]

    //RCRA_HD_ENV_PERMIT
    [AppliedAttribute(typeof(EnvironmentalPermitDataType), "TransactionCode", typeof(ColumnAttribute), "TRANSACTION_CODE", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(EnvironmentalPermitDataType), "EnvironmentalPermitID", typeof(ColumnAttribute), "ENV_PERMIT_NUMBER", 13, false)]
    [AppliedAttribute(typeof(EnvironmentalPermitDataType), "EnvironmentalPermitOwnerName", typeof(ColumnAttribute), "ENV_PERMIT_OWNER", DbType.AnsiStringFixedLength, 2)]
    [AppliedAttribute(typeof(EnvironmentalPermitDataType), "EnvironmentalPermitTypeCode", typeof(ColumnAttribute), "ENV_PERMIT_TYPE", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(EnvironmentalPermitDataType), "EnvironmentalPermitDescription", typeof(ColumnAttribute), "ENV_PERMIT_DESC", 80)]
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
    [AppliedAttribute(typeof(HandlerDataType), "NonNotifierIndicatorText", typeof(ColumnAttribute), "NON_NOTIFIER_TEXT", DbType.AnsiString, 255)]
    // REMOVED: [AppliedAttribute(typeof(HandlerDataType), "OnsiteEmployeeQuantity", typeof(ColumnAttribute), "NUMBER_OF_EMPLOYEES", DbType.Int32)]
    [AppliedAttribute(typeof(LocationAddressDataType), "LocationAddressNumberText", typeof(ColumnAttribute), "LOCATION_STREET_NUMBER", 12)]
    [AppliedAttribute(typeof(LocationAddressDataType), "LocationAddressText", typeof(ColumnAttribute), "LOCATION_STREET1", 50)]
    [AppliedAttribute(typeof(LocationAddressDataType), "SupplementalLocationText", typeof(ColumnAttribute), "LOCATION_STREET2", 50)]
    [AppliedAttribute(typeof(LocationAddressDataType), "LocalityName", typeof(ColumnAttribute), "LOCATION_CITY", 25)]
    [AppliedAttribute(typeof(LocationAddressDataType), "StateUSPSCode", typeof(ColumnAttribute), "LOCATION_STATE", DbType.AnsiStringFixedLength, 2)]
    [AppliedAttribute(typeof(LocationAddressDataType), "LocationZIPCode", typeof(ColumnAttribute), "LOCATION_ZIP", 14)]
    [AppliedAttribute(typeof(LocationAddressDataType), "CountryName", typeof(ColumnAttribute), "LOCATION_COUNTRY", DbType.AnsiStringFixedLength, 2)]
    [AppliedPathAttribute("Handler.MailingAddress.MailingAddressNumberText", typeof(ColumnAttribute), "MAIL_STREET_NUMBER", 12)]
    [AppliedPathAttribute("Handler.MailingAddress.MailingAddressText", typeof(ColumnAttribute), "MAIL_STREET1", 50)]
    [AppliedPathAttribute("Handler.MailingAddress.SupplementalAddressText", typeof(ColumnAttribute), "MAIL_STREET2", 50)]
    [AppliedPathAttribute("Handler.MailingAddress.MailingAddressCityName", typeof(ColumnAttribute), "MAIL_CITY", 25)]
    [AppliedPathAttribute("Handler.MailingAddress.MailingAddressStateUSPSCode", typeof(ColumnAttribute), "MAIL_STATE", DbType.AnsiStringFixedLength, 2)]
    [AppliedPathAttribute("Handler.MailingAddress.MailingAddressZIPCode", typeof(ColumnAttribute), "MAIL_ZIP", 14)]
    [AppliedPathAttribute("Handler.MailingAddress.MailingAddressCountryName", typeof(ColumnAttribute), "MAIL_COUNTRY", DbType.AnsiStringFixedLength, 2)]
    [AppliedPathAttribute("Handler.ContactAddress.Contact.FirstName", typeof(ColumnAttribute), "CONTACT_FIRST_NAME", 38)]
    [AppliedPathAttribute("Handler.ContactAddress.Contact.MiddleInitial", typeof(ColumnAttribute), "CONTACT_MIDDLE_INITIAL", DbType.AnsiStringFixedLength, 1)]
    [AppliedPathAttribute("Handler.ContactAddress.Contact.LastName", typeof(ColumnAttribute), "CONTACT_LAST_NAME", 38)]
    [AppliedPathAttribute("Handler.ContactAddress.Contact.OrganizationFormalName", typeof(ColumnAttribute), "CONTACT_ORG_NAME", 80)]
    [AppliedPathAttribute("Handler.ContactAddress.MailingAddress.MailingAddressNumberText", typeof(ColumnAttribute), "CONTACT_STREET_NUMBER", 12)] //??
    [AppliedPathAttribute("Handler.ContactAddress.MailingAddress.MailingAddressText", typeof(ColumnAttribute), "CONTACT_STREET1", 30)]
    [AppliedPathAttribute("Handler.ContactAddress.MailingAddress.SupplementalAddressText", typeof(ColumnAttribute), "CONTACT_STREET2", 30)]
    [AppliedPathAttribute("Handler.ContactAddress.MailingAddress.MailingAddressCityName", typeof(ColumnAttribute), "CONTACT_CITY", 25)]
    [AppliedPathAttribute("Handler.ContactAddress.MailingAddress.MailingAddressStateUSPSCode", typeof(ColumnAttribute), "CONTACT_STATE", DbType.AnsiStringFixedLength, 2)]
    [AppliedPathAttribute("Handler.ContactAddress.MailingAddress.MailingAddressZIPCode", typeof(ColumnAttribute), "CONTACT_ZIP", 14)]
    [AppliedPathAttribute("Handler.ContactAddress.MailingAddress.MailingAddressCountryName", typeof(ColumnAttribute), "CONTACT_COUNTRY", DbType.AnsiStringFixedLength, 2)]
    [AppliedPathAttribute("Handler.ContactAddress.Contact.TelephoneNumberText", typeof(ColumnAttribute), "CONTACT_PHONE", 15)]
    [AppliedPathAttribute("Handler.ContactAddress.Contact.PhoneExtensionText", typeof(ColumnAttribute), "CONTACT_PHONE_EXT", 6)]
    [AppliedPathAttribute("Handler.ContactAddress.Contact.FaxNumberText", typeof(ColumnAttribute), "CONTACT_FAX", 15)]
    [AppliedPathAttribute("Handler.ContactAddress.Contact.ContactLanguageCode", typeof(ColumnAttribute), "CONTACT_LANG_CODE", 2)]
    [AppliedPathAttribute("Handler.ContactAddress.Contact.ContactLanguageDescription", typeof(ColumnAttribute), "CONTACT_LANG_DESC", 50)]
    [AppliedPathAttribute("Handler.ContactAddress.Contact.IndividualTitleText", typeof(ColumnAttribute), "CONTACT_TITLE", 80)]
    [AppliedPathAttribute("Handler.ContactAddress.Contact.EmailAddressText", typeof(ColumnAttribute), "CONTACT_EMAIL_ADDRESS", 80)]
    [AppliedPathAttribute("Handler.PermitContactAddress.Contact.FirstName", typeof(ColumnAttribute), "PCONTACT_FIRST_NAME", 38)]
    [AppliedPathAttribute("Handler.PermitContactAddress.Contact.MiddleInitial", typeof(ColumnAttribute), "PCONTACT_MIDDLE_NAME", DbType.AnsiStringFixedLength, 1)]
    [AppliedPathAttribute("Handler.PermitContactAddress.Contact.LastName", typeof(ColumnAttribute), "PCONTACT_LAST_NAME", 38)]
    [AppliedPathAttribute("Handler.PermitContactAddress.Contact.OrganizationFormalName", typeof(ColumnAttribute), "PCONTACT_ORG_NAME", 80)]
    [AppliedPathAttribute("Handler.PermitContactAddress.MailingAddress.MailingAddressNumberText", typeof(ColumnAttribute), "PCONTACT_STREET_NUMBER", 12)] //??
    [AppliedPathAttribute("Handler.PermitContactAddress.MailingAddress.MailingAddressText", typeof(ColumnAttribute), "PCONTACT_STREET1", 30)]
    [AppliedPathAttribute("Handler.PermitContactAddress.MailingAddress.SupplementalAddressText", typeof(ColumnAttribute), "PCONTACT_STREET2", 30)]
    [AppliedPathAttribute("Handler.PermitContactAddress.MailingAddress.MailingAddressCityName", typeof(ColumnAttribute), "PCONTACT_CITY", 25)]
    [AppliedPathAttribute("Handler.PermitContactAddress.MailingAddress.MailingAddressStateUSPSCode", typeof(ColumnAttribute), "PCONTACT_STATE", DbType.AnsiStringFixedLength, 2)]
    [AppliedPathAttribute("Handler.PermitContactAddress.MailingAddress.MailingAddressZIPCode", typeof(ColumnAttribute), "PCONTACT_ZIP", 14)]
    [AppliedPathAttribute("Handler.PermitContactAddress.MailingAddress.MailingAddressCountryName", typeof(ColumnAttribute), "PCONTACT_COUNTRY", DbType.AnsiStringFixedLength, 2)]
    [AppliedPathAttribute("Handler.PermitContactAddress.Contact.TelephoneNumberText", typeof(ColumnAttribute), "PCONTACT_PHONE", 15)]
    [AppliedPathAttribute("Handler.PermitContactAddress.Contact.PhoneExtensionText", typeof(ColumnAttribute), "PCONTACT_PHONE_EXT", 6)]
    [AppliedPathAttribute("Handler.PermitContactAddress.Contact.FaxNumberText", typeof(ColumnAttribute), "PCONTACT_FAX", 15)]
    [AppliedPathAttribute("Handler.PermitContactAddress.Contact.ContactLanguageCode", typeof(ColumnAttribute), "PCONTACT_LANG_CODE", 2)]
    [AppliedPathAttribute("Handler.PermitContactAddress.Contact.ContactLanguageDescription", typeof(ColumnAttribute), "PCONTACT_LANG_DESC", 50)]
    [AppliedPathAttribute("Handler.PermitContactAddress.Contact.IndividualTitleText", typeof(ColumnAttribute), "PCONTACT_TITLE", 80)]
    [AppliedPathAttribute("Handler.PermitContactAddress.Contact.EmailAddressText", typeof(ColumnAttribute), "PCONTACT_EMAIL_ADDRESS", 80)]
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
    [AppliedAttribute(typeof(SiteWasteActivityDataType), "StateDistrictCode", typeof(ColumnAttribute), "STATE_DISTRICT", DbType.AnsiString, 10)]
    [AppliedAttribute(typeof(SiteWasteActivityDataType), "StateDistrictCodeText", typeof(ColumnAttribute), "STATE_DISTRICT_TEXT", DbType.AnsiString, 255)]
    [AppliedAttribute(typeof(SiteWasteActivityDataType), "ShortTermGeneratorIndicator", typeof(ColumnAttribute), "SHORT_TERM_GEN_IND", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(SiteWasteActivityDataType), "TransferFacilityIndicator", typeof(ColumnAttribute), "TRANSFER_FACILITY_IND", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(SiteWasteActivityDataType), "LandTypeText", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(SiteWasteActivityDataType), "RecognizedTraderImporterIndicator", typeof(ColumnAttribute), "RECOGNIZED_TRADER_IMPORTER_IND", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(SiteWasteActivityDataType), "RecognizedTraderExporterIndicator", typeof(ColumnAttribute), "RECOGNIZED_TRADER_EXPORTER_IND", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(SiteWasteActivityDataType), "SlabImporterIndicator", typeof(ColumnAttribute), "SLAB_IMPORTER_IND", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(SiteWasteActivityDataType), "SlabExporterIndicator", typeof(ColumnAttribute), "SLAB_EXPORTER_IND", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(SiteWasteActivityDataType), "RecyclerActivityNonstorage", typeof(ColumnAttribute), "RECYCLER_ACT_NONSTORAGE", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(SiteWasteActivityDataType), "ManifestBroker", typeof(ColumnAttribute), "MANIFEST_BROKER", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(UsedOilDataType), "FuelBurnerCode", typeof(ColumnAttribute), "USED_OIL_BURNER", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(UsedOilDataType), "ProcessorCode", typeof(ColumnAttribute), "USED_OIL_PROCESSOR", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(UsedOilDataType), "RefinerCode", typeof(ColumnAttribute), "USED_OIL_REFINER", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(UsedOilDataType), "MarketBurnerCode", typeof(ColumnAttribute), "USED_OIL_MARKET_BURNER", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(UsedOilDataType), "SpecificationMarketerCode", typeof(ColumnAttribute), "USED_OIL_SPEC_MARKETER", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(UsedOilDataType), "TransferFacilityCode", typeof(ColumnAttribute), "USED_OIL_TRANSFER_FACILITY", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(UsedOilDataType), "TransporterCode", typeof(ColumnAttribute), "USED_OIL_TRANSPORTER", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(HandlerDataType), "TreatmentStorageDisposalDate", typeof(ColumnAttribute), "TSD_DATE", DbType.AnsiString, 10)]
    [AppliedAttribute(typeof(HandlerDataType), "NatureOfBusinessText", typeof(ColumnAttribute), "NATURE_OF_BUSINESS_TEXT", DbType.AnsiString, 4000)]
    [AppliedAttribute(typeof(HandlerDataType), "OffsiteWasteReceiptCode", typeof(ColumnAttribute), "OFF_SITE_RECEIPT", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(HandlerDataType), "AccessibilityCode", typeof(ColumnAttribute), "ACCESSIBILITY", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(HandlerDataType), "AccessibilityCodeText", typeof(ColumnAttribute), "ACCESSIBILITY_TEXT", DbType.AnsiString, 255)]
    [AppliedAttribute(typeof(HandlerDataType), "CountyCode", typeof(ColumnAttribute), "COUNTY_CODE", 5)]
    [AppliedAttribute(typeof(HandlerDataType), "CountyCodeOwner", typeof(ColumnAttribute), "COUNTY_CODE_OWNER", DbType.AnsiStringFixedLength, 2)]
    [AppliedPathAttribute("Handler.StateWasteGenerator.WasteGeneratorOwnerName", typeof(ColumnAttribute), "STATE_WASTE_GENERATOR_OWNER", DbType.AnsiStringFixedLength, 2)]
    [AppliedPathAttribute("Handler.StateWasteGenerator.WasteGeneratorStatusCode", typeof(ColumnAttribute), "STATE_WASTE_GENERATOR", DbType.AnsiStringFixedLength, 1)]
    [AppliedPathAttribute("Handler.StateWasteGenerator.WasteGeneratorStatusText", typeof(DbIgnoreAttribute))]
    [AppliedPathAttribute("Handler.FederalWasteGenerator.WasteGeneratorOwnerName", typeof(ColumnAttribute), "FED_WASTE_GENERATOR_OWNER", DbType.AnsiStringFixedLength, 2)]
    [AppliedPathAttribute("Handler.FederalWasteGenerator.WasteGeneratorStatusCode", typeof(ColumnAttribute), "FED_WASTE_GENERATOR", DbType.AnsiStringFixedLength, 1)]
    [AppliedPathAttribute("Handler.FederalWasteGenerator.WasteGeneratorStatusText", typeof(DbIgnoreAttribute))]
    [AppliedPathAttribute("Handler.LaboratoryHazardousWaste.CollegeIndicator", typeof(ColumnAttribute), "COLLEGE_IND", DbType.AnsiStringFixedLength, 1)]
    [AppliedPathAttribute("Handler.LaboratoryHazardousWaste.HospitalIndicator", typeof(ColumnAttribute), "HOSPITAL_IND", DbType.AnsiStringFixedLength, 1)]
    [AppliedPathAttribute("Handler.LaboratoryHazardousWaste.NonProfitIndicator", typeof(ColumnAttribute), "NON_PROFIT_IND", DbType.AnsiStringFixedLength, 1)]
    [AppliedPathAttribute("Handler.LaboratoryHazardousWaste.WithdrawalIndicator", typeof(ColumnAttribute), "WITHDRAWAL_IND", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(HandlerDataType), "HandlerSupplementalInformationText", typeof(ColumnAttribute), "NOTES", 4000)]
    [AppliedAttribute(typeof(HandlerDataType), "HandlerInternalSupplementalInformationText", typeof(ColumnAttribute), "INTRNL_NOTES", 4000)]
    [AppliedAttribute(typeof(HandlerDataType), "ShortTermSupplementalInformationText", typeof(ColumnAttribute), "SHORT_TERM_INTRNL_NOTES", 4000)]
    [AppliedAttribute(typeof(HandlerDataType), "CountyName", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(HandlerDataType), "SourceTypeText", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(HandlerDataType), "HandlerLqgConsolidation", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(HandlerDataType), "HandlerLqgClosure", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(HandlerDataType), "HandlerEpisodicEvent", typeof(DbIgnoreAttribute))]
    [AppliedPathAttribute("Handler.HazardousSecondaryMaterial.TransactionCode", typeof(ColumnAttribute), "TRANS_CODE", DbType.AnsiStringFixedLength, 1)]
    [AppliedPathAttribute("Handler.HazardousSecondaryMaterial.NotificationReasonCode", typeof(ColumnAttribute), "NOTIFICATION_RSN_CODE", DbType.AnsiStringFixedLength, 1)]
    [AppliedPathAttribute("Handler.HazardousSecondaryMaterial.NotificationReasonText", typeof(DbIgnoreAttribute))]
    [AppliedPathAttribute("Handler.HazardousSecondaryMaterial.EffectiveDate", typeof(ColumnAttribute), "EFFC_DATE", DbType.Date)]
    [AppliedPathAttribute("Handler.HazardousSecondaryMaterial.FinancialAssuranceIndicator", typeof(ColumnAttribute), "FINANCIAL_ASSURANCE_IND", DbType.AnsiStringFixedLength, 1)]
    [AppliedPathAttribute("Handler.HazardousSecondaryMaterial.RecyclingIndicator", typeof(ColumnAttribute), "RECYCLING_IND", DbType.AnsiStringFixedLength, 1)]
    [AppliedPathAttribute("Handler.HazardousSecondaryMaterial.RecyclerNotes", typeof(ColumnAttribute), "RECYCLER_NOTES", 4000)]
    [AppliedAttribute(typeof(HandlerDataType), "LocationLatitude", typeof(ColumnAttribute), "LOCATION_LATITUDE", DbType.Decimal, 19, 14)]
    [AppliedAttribute(typeof(HandlerDataType), "LocationLongitude", typeof(ColumnAttribute), "LOCATION_LONGITUDE", DbType.Decimal, 19, 14)]
    [AppliedAttribute(typeof(HandlerDataType), "LocationGisPrimary", typeof(ColumnAttribute), "LOCATION_GIS_PRIM", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(HandlerDataType), "LocationGisOrig", typeof(ColumnAttribute), "LOCATION_GIS_ORIG", DbType.AnsiString, 2)]

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
    [AppliedAttribute(typeof(OtherIDDataType), "OtherIDSupplementalInformationText", typeof(ColumnAttribute), "NOTES", 4000)]
    [AppliedAttribute(typeof(OtherIDDataType), "RelationshipTypeText", typeof(DbIgnoreAttribute))]

    //RCRA_HD_OWNEROP
    [AppliedAttribute(typeof(FacilityOwnerOperatorDataType), "TransactionCode", typeof(ColumnAttribute), "TRANSACTION_CODE", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(FacilityOwnerOperatorDataType), "OwnerOperatorSequenceNumber", typeof(ColumnAttribute), "OWNER_OP_SEQ", DbType.Int32, false)]
    [AppliedAttribute(typeof(FacilityOwnerOperatorDataType), "OwnerOperatorIndicator", typeof(ColumnAttribute), "OWNER_OP_IND", DbType.AnsiStringFixedLength, 2)]
    [AppliedPathAttribute("Handler.FacilityOwnerOperator.ContactAddress.Contact.FirstName", typeof(ColumnAttribute), "FIRST_NAME", 38)]
    [AppliedPathAttribute("Handler.FacilityOwnerOperator.ContactAddress.Contact.MiddleInitial", typeof(ColumnAttribute), "MIDDLE_INITIAL", DbType.AnsiStringFixedLength, 1)]
    [AppliedPathAttribute("Handler.FacilityOwnerOperator.ContactAddress.Contact.LastName", typeof(ColumnAttribute), "LAST_NAME", 38)]
    [AppliedPathAttribute("Handler.FacilityOwnerOperator.ContactAddress.Contact.OrganizationFormalName", typeof(ColumnAttribute), "ORG_NAME", 80)]
    [AppliedAttribute(typeof(FacilityOwnerOperatorDataType), "OwnerOperatorTypeCode", typeof(ColumnAttribute), "OWNER_OP_TYPE", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(FacilityOwnerOperatorDataType), "CurrentStartDate", typeof(ColumnAttribute), "DATE_BECAME_CURRENT", DbType.AnsiString, 10)]
    [AppliedAttribute(typeof(FacilityOwnerOperatorDataType), "CurrentEndDate", typeof(ColumnAttribute), "DATE_ENDED_CURRENT", DbType.AnsiString, 10)]
    [AppliedPathAttribute("Handler.FacilityOwnerOperator.ContactAddress.MailingAddress.MailingAddressNumberText", typeof(ColumnAttribute), "MAIL_ADDR_NUM_TXT", 12)]
    [AppliedPathAttribute("Handler.FacilityOwnerOperator.ContactAddress.MailingAddress.MailingAddressText", typeof(ColumnAttribute), "STREET1", 50)]
    [AppliedPathAttribute("Handler.FacilityOwnerOperator.ContactAddress.MailingAddress.SupplementalAddressText", typeof(ColumnAttribute), "STREET2", 50)]
    [AppliedPathAttribute("Handler.FacilityOwnerOperator.ContactAddress.MailingAddress.MailingAddressCityName", typeof(ColumnAttribute), "CITY", 25)]
    [AppliedPathAttribute("Handler.FacilityOwnerOperator.ContactAddress.MailingAddress.MailingAddressStateUSPSCode", typeof(ColumnAttribute), "STATE", DbType.AnsiStringFixedLength, 2)]
    [AppliedPathAttribute("Handler.FacilityOwnerOperator.ContactAddress.MailingAddress.MailingAddressCountryName", typeof(ColumnAttribute), "COUNTRY", DbType.AnsiStringFixedLength, 2)]
    [AppliedPathAttribute("Handler.FacilityOwnerOperator.ContactAddress.MailingAddress.MailingAddressZIPCode", typeof(ColumnAttribute), "ZIP", 14)]
    [AppliedPathAttribute("Handler.FacilityOwnerOperator.ContactAddress.Contact.TelephoneNumberText", typeof(ColumnAttribute), "PHONE", 15)]
    [AppliedPathAttribute("Handler.FacilityOwnerOperator.ContactAddress.Contact.PhoneExtensionText", typeof(ColumnAttribute), "PHONE_EXT", 6)]
    [AppliedPathAttribute("Handler.FacilityOwnerOperator.ContactAddress.Contact.FaxNumberText", typeof(ColumnAttribute), "FAX", 15)]
    [AppliedPathAttribute("Handler.FacilityOwnerOperator.ContactAddress.Contact.ContactLanguageCode", typeof(ColumnAttribute), "LANG_CODE", 2)]
    [AppliedPathAttribute("Handler.FacilityOwnerOperator.ContactAddress.Contact.ContactLanguageDescription", typeof(ColumnAttribute), "LANG_DESC", 50)]
    [AppliedPathAttribute("Handler.FacilityOwnerOperator.ContactAddress.Contact.IndividualTitleText", typeof(ColumnAttribute), "TITLE", 80)]
    [AppliedPathAttribute("Handler.FacilityOwnerOperator.ContactAddress.Contact.EmailAddressText", typeof(ColumnAttribute), "EMAIL_ADDRESS", 80)]
    // REMOVED: [AppliedAttribute(typeof(FacilityOwnerOperatorDataType), "DUNSID", typeof(ColumnAttribute), "DUNN_BRADSTREET_NUM", 10)]
    [AppliedAttribute(typeof(FacilityOwnerOperatorDataType), "OwnerOperatorSupplementalInformationText", typeof(ColumnAttribute), "NOTES", 4000)]
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
    [AppliedPathAttribute("Handler.HandlerWasteCodeDetails.TransactionCode", typeof(ColumnAttribute), "TRANSACTION_CODE", 1)]
    [AppliedPathAttribute("Handler.HandlerWasteCodeDetails.WasteCodeOwnerName", typeof(ColumnAttribute), "WASTE_CODE_OWNER", 2)]
    [AppliedPathAttribute("Handler.HandlerWasteCodeDetails.WasteCode", typeof(ColumnAttribute), "WASTE_CODE_TYPE", 6)]
    [AppliedPathAttribute("Handler.HandlerWasteCodeDetails.WasteCodeText", typeof(DbIgnoreAttribute))]
    //[AppliedAttribute(typeof(HandlerWasteCodeDataType), "TransactionCode", typeof(ColumnAttribute), "TRANSACTION_CODE", DbType.AnsiStringFixedLength, 1)]
    //[AppliedAttribute(typeof(HandlerWasteCodeDataType), "WasteCodeOwnerName", typeof(ColumnAttribute), "WASTE_CODE_OWNER", DbType.AnsiStringFixedLength, 2)]
    //[AppliedAttribute(typeof(HandlerWasteCodeDataType), "WasteCode", typeof(ColumnAttribute), "WASTE_CODE_TYPE", 6)]
    //[AppliedAttribute(typeof(HandlerWasteCodeDataType), "WasteCodeText", typeof(DbIgnoreAttribute))]

    //RCRA_HD_SEC_WASTE_CODE
    [AppliedPathAttribute("Handler.HazardousSecondaryMaterial.HazardousSecondaryMaterialActivity.HandlerWasteCodeDetails.TransactionCode", typeof(ColumnAttribute), "TRANSACTION_CODE", 1)]
    [AppliedPathAttribute("Handler.HazardousSecondaryMaterial.HazardousSecondaryMaterialActivity.HandlerWasteCodeDetails.WasteCodeOwnerName", typeof(ColumnAttribute), "WASTE_CODE_OWNER", 2)]
    [AppliedPathAttribute("Handler.HazardousSecondaryMaterial.HazardousSecondaryMaterialActivity.HandlerWasteCodeDetails.WasteCode", typeof(ColumnAttribute), "WASTE_CODE_TYPE", 6)]
    [AppliedPathAttribute("Handler.HazardousSecondaryMaterial.HazardousSecondaryMaterialActivity.HandlerWasteCodeDetails.WasteCodeText", typeof(DbIgnoreAttribute))]
    //[AppliedAttribute(typeof(SecondaryHandlerWasteCodeDataType), "TransactionCode", typeof(ColumnAttribute), "TRANSACTION_CODE", DbType.AnsiStringFixedLength, 1)]
    //[AppliedAttribute(typeof(SecondaryHandlerWasteCodeDataType), "WasteCodeOwnerName", typeof(ColumnAttribute), "WASTE_CODE_OWNER", DbType.AnsiStringFixedLength, 2)]
    //[AppliedAttribute(typeof(SecondaryHandlerWasteCodeDataType), "WasteCode", typeof(ColumnAttribute), "WASTE_CODE_TYPE", 6)]
    //[AppliedAttribute(typeof(SecondaryHandlerWasteCodeDataType), "WasteCodeText", typeof(DbIgnoreAttribute))]

    //RCRA_HD_EPISODIC_WASTE_CODE
    [AppliedPathAttribute("Handler.HandlerEpisodicEventArray.EpisodicWaste.HandlerWasteCodeDetails.TransactionCode", typeof(ColumnAttribute), "TRANSACTION_CODE", 1)]
    [AppliedPathAttribute("Handler.HandlerEpisodicEventArray.EpisodicWaste.HandlerWasteCodeDetails.WasteCodeOwnerName", typeof(ColumnAttribute), "WASTE_CODE_OWNER", 2)]
    [AppliedPathAttribute("Handler.HandlerEpisodicEventArray.EpisodicWaste.HandlerWasteCodeDetails.WasteCode", typeof(ColumnAttribute), "WASTE_CODE", 6)]
    [AppliedPathAttribute("Handler.HandlerEpisodicEventArray.EpisodicWaste.HandlerWasteCodeDetails.WasteCodeText", typeof(DbIgnoreAttribute))]
    [AppliedPathAttribute("Handler.HandlerEpisodicEventArray.EpisodicWaste.HandlerWasteCodeDetails.WasteCodeText", typeof(ColumnAttribute), "WASTE_CODE_TEXT", 80)]
    //[AppliedAttribute(typeof(EpisodicHandlerWasteCodeDataType), "TransactionCode", typeof(ColumnAttribute), "TRANSACTION_CODE", DbType.AnsiStringFixedLength, 1)]
    //[AppliedAttribute(typeof(EpisodicHandlerWasteCodeDataType), "WasteCodeOwnerName", typeof(ColumnAttribute), "WASTE_CODE_OWNER", DbType.AnsiStringFixedLength, 2)]
    //[AppliedAttribute(typeof(EpisodicHandlerWasteCodeDataType), "WasteCode", typeof(ColumnAttribute), "WASTE_CODE", 6)]
    //[AppliedAttribute(typeof(EpisodicHandlerWasteCodeDataType), "WasteCodeText", typeof(ColumnAttribute), "WASTE_CODE_TEXT", 80)]

    //RCRA_HD_ADD_CONTACT
    [AppliedAttribute(typeof(AdditionalContactDataType), "TransactionCode", typeof(ColumnAttribute), "TRANSACTION_CODE", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(AdditionalContactDataType), "AdditionalContactSequenceNumber", typeof(ColumnAttribute), "ADD_CONTACT_SEQ", DbType.Int32, false)]
    [AppliedAttribute(typeof(AdditionalContactDataType), "ContactType", typeof(ColumnAttribute), "CONTACT_TYPE", DbType.AnsiString, 2)]
    [AppliedAttribute(typeof(AdditionalContactDataType), "ContactTypeOwner", typeof(ColumnAttribute), "CONTACT_TYPE_OWNER", DbType.AnsiString, 2)]
    [AppliedAttribute(typeof(AdditionalContactDataType), "FirstName", typeof(ColumnAttribute), "CONTACT_FIRST_NAME", 38)]
    [AppliedAttribute(typeof(AdditionalContactDataType), "MiddleInitial", typeof(ColumnAttribute), "CONTACT_MIDDLE_INITIAL", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(AdditionalContactDataType), "LastName", typeof(ColumnAttribute), "CONTACT_LAST_NAME", 38)]
    [AppliedAttribute(typeof(AdditionalContactDataType), "ContactStreetNumber", typeof(ColumnAttribute), "CONTACT_STREET_NUMBER", 12)]
    [AppliedAttribute(typeof(AdditionalContactDataType), "ContactStreet1", typeof(ColumnAttribute), "CONTACT_STREET_1", 50)]
    [AppliedAttribute(typeof(AdditionalContactDataType), "ContactStreet2", typeof(ColumnAttribute), "CONTACT_STREET_2", 50)]
    [AppliedAttribute(typeof(AdditionalContactDataType), "ContactCity", typeof(ColumnAttribute), "CONTACT_CITY", 25)]
    [AppliedAttribute(typeof(AdditionalContactDataType), "ContactState", typeof(ColumnAttribute), "CONTACT_STATE", DbType.AnsiStringFixedLength, 2)]
    [AppliedAttribute(typeof(AdditionalContactDataType), "ContactZip", typeof(ColumnAttribute), "CONTACT_ZIP", 14)]
    [AppliedAttribute(typeof(AdditionalContactDataType), "ContactCountry", typeof(ColumnAttribute), "CONTACT_COUNTRY", DbType.AnsiStringFixedLength, 2)]
    [AppliedAttribute(typeof(AdditionalContactDataType), "ContactPhone", typeof(ColumnAttribute), "CONTACT_PHONE", 15)]
    [AppliedAttribute(typeof(AdditionalContactDataType), "ContactPhoneExt", typeof(ColumnAttribute), "CONTACT_PHONE_EXT", 6)]
    [AppliedAttribute(typeof(AdditionalContactDataType), "ContactFax", typeof(ColumnAttribute), "CONTACT_FAX", 15)]
    [AppliedAttribute(typeof(AdditionalContactDataType), "ContactEmail", typeof(ColumnAttribute), "CONTACT_EMAIL", 80)]
    [AppliedAttribute(typeof(AdditionalContactDataType), "ContactTitle", typeof(ColumnAttribute), "CONTACT_TITLE", 45)]
    [AppliedAttribute(typeof(AdditionalContactDataType), "ContactLanguageCode", typeof(ColumnAttribute), "CONTACT_LANG_CODE", 2)]
    [AppliedAttribute(typeof(AdditionalContactDataType), "ContactLanguageDescription", typeof(ColumnAttribute), "CONTACT_LANG_DESC", 50)]

    // HazardousSecondaryMaterialActivityDataType
    [AppliedAttribute(typeof(HazardousSecondaryMaterialActivityDataType), "EstimatedShortTonsQuantity", typeof(ColumnAttribute), DbType.Int32)]
    [AppliedAttribute(typeof(HazardousSecondaryMaterialActivityDataType), "ActualShortTonsQuantity", typeof(ColumnAttribute), DbType.Int32)]
    [AppliedAttribute(typeof(HazardousSecondaryMaterialActivityDataType), "LandBasedUnitIndicator", typeof(ColumnAttribute), "LAND_BASED_UNIT_IND", DbType.AnsiString, 50)]
    [AppliedAttribute(typeof(HazardousSecondaryMaterialActivityDataType), "LandBasedUnitIndicatorText", typeof(ColumnAttribute), "LAND_BASED_UNIT_IND_TEXT", DbType.AnsiString, 255)]
    [AppliedAttribute(typeof(HazardousSecondaryMaterialActivityDataType), "FacilityTypeText", typeof(DbIgnoreAttribute))]

    //RCRA_HD_LQG_CONSOLIDATION
    [AppliedAttribute(typeof(HandlerLqgConsolidation), "TransactionCode", typeof(ColumnAttribute), "TRANSACTION_CODE", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(HandlerLqgConsolidation), "ConsolidationSequenceNumber", typeof(ColumnAttribute), "SEQ_NUMBER", DbType.Int32)]
    [AppliedAttribute(typeof(HandlerLqgConsolidation), "HandlerID", typeof(ColumnAttribute), "HANDLER_ID", DbType.AnsiString, 12)]
    [AppliedAttribute(typeof(HandlerLqgConsolidation), "HandlerName", typeof(ColumnAttribute), "HANDLER_NAME", DbType.AnsiString, 80)]
    //??
    //[AppliedAttribute(typeof(HandlerLqgConsolidation), "MailingAddressNumberText", typeof(ColumnAttribute), "MAIL_STREET_NUMBER", DbType.AnsiString, 12)]
    [AppliedPathAttribute("Handler.HandlerLqgConsolidationArray.MailingAddress.MailingAddressNumberText", typeof(ColumnAttribute), "MAIL_STREET_NUMBER", DbType.AnsiString, 12)]
    [AppliedPathAttribute("Handler.HandlerLqgConsolidationArray.MailingAddress.MailingAddressText", typeof(ColumnAttribute), "MAIL_STREET1", DbType.AnsiString, 50)]
    [AppliedPathAttribute("Handler.HandlerLqgConsolidationArray.MailingAddress.SupplementalAddressText", typeof(ColumnAttribute), "MAIL_STREET2", DbType.AnsiString, 50)]
    [AppliedPathAttribute("Handler.HandlerLqgConsolidationArray.MailingAddress.MailingAddressCityName", typeof(ColumnAttribute), "MAIL_CITY", DbType.AnsiString, 25)]
    [AppliedPathAttribute("Handler.HandlerLqgConsolidationArray.MailingAddress.MailingAddressStateUSPSCode", typeof(ColumnAttribute), "MAIL_STATE", DbType.AnsiStringFixedLength, 2)]
    [AppliedPathAttribute("Handler.HandlerLqgConsolidationArray.MailingAddress.MailingAddressCountryName", typeof(ColumnAttribute), "MAIL_COUNTRY", DbType.AnsiStringFixedLength, 2)]
    [AppliedPathAttribute("Handler.HandlerLqgConsolidationArray.MailingAddress.MailingAddressZIPCode", typeof(ColumnAttribute), "MAIL_ZIP", DbType.AnsiString, 14)]
    [AppliedPathAttribute("Handler.HandlerLqgConsolidationArray.Contact.FirstName", typeof(ColumnAttribute), "CONTACT_FIRST_NAME", 38)]
    [AppliedPathAttribute("Handler.HandlerLqgConsolidationArray.Contact.MiddleInitial", typeof(ColumnAttribute), "CONTACT_MIDDLE_INITIAL", DbType.AnsiStringFixedLength, 1)]
    [AppliedPathAttribute("Handler.HandlerLqgConsolidationArray.Contact.LastName", typeof(ColumnAttribute), "CONTACT_LAST_NAME", 38)]
    [AppliedPathAttribute("Handler.HandlerLqgConsolidationArray.Contact.OrganizationFormalName", typeof(ColumnAttribute), "CONTACT_ORG_NAME", 80)]
    [AppliedPathAttribute("Handler.HandlerLqgConsolidationArray.Contact.IndividualTitleText", typeof(ColumnAttribute), "CONTACT_TITLE", DbType.AnsiString, 80)]
    [AppliedPathAttribute("Handler.HandlerLqgConsolidationArray.Contact.EmailAddressText", typeof(ColumnAttribute), "CONTACT_EMAIL_ADDRESS", DbType.AnsiString, 80)]
    [AppliedPathAttribute("Handler.HandlerLqgConsolidationArray.Contact.TelephoneNumberText", typeof(ColumnAttribute), "CONTACT_PHONE", DbType.AnsiString, 15)]
    [AppliedPathAttribute("Handler.HandlerLqgConsolidationArray.Contact.PhoneExtensionText", typeof(ColumnAttribute), "CONTACT_PHONE_EXT", DbType.AnsiString, 6)]
    [AppliedPathAttribute("Handler.HandlerLqgConsolidationArray.Contact.FaxNumberText", typeof(ColumnAttribute), "CONTACT_FAX", DbType.AnsiString, 15)]
    [AppliedPathAttribute("Handler.HandlerLqgConsolidationArray.Contact.ContactLanguageCode", typeof(ColumnAttribute), "CONTACT_LANG_CODE", 2)]
    [AppliedPathAttribute("Handler.HandlerLqgConsolidationArray.Contact.ContactLanguageDescription", typeof(ColumnAttribute), "CONTACT_LANG_DESC", 50)]

    //RCRA_HD_LQG_CLOSURE
    [AppliedAttribute(typeof(HandlerLqgClosure), "TransactionCode", typeof(ColumnAttribute), "TRANSACTION_CODE", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(HandlerLqgClosure), "ClosureType", typeof(ColumnAttribute), "CLOSURE_TYPE", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(HandlerLqgClosure), "ExpectedClosureDate", typeof(ColumnAttribute), "EXPECTED_CLOSURE_DATE", DbType.Date)]
    [AppliedAttribute(typeof(HandlerLqgClosure), "NewClosureDate", typeof(ColumnAttribute), "NEW_CLOSURE_DATE", DbType.Date)]
    [AppliedAttribute(typeof(HandlerLqgClosure), "DateClosed", typeof(ColumnAttribute), "DATE_CLOSED", DbType.Date)]
    [AppliedAttribute(typeof(HandlerLqgClosure), "InComplianceIndicator", typeof(ColumnAttribute), "IN_COMPLIANCE_IND", DbType.AnsiStringFixedLength, 1)]

    //RCRA_HD_EPISODIC_WASTE
    [AppliedAttribute(typeof(EpisodicWaste), "TransactionCode", typeof(ColumnAttribute), "TRANSACTION_CODE", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(EpisodicWaste), "EpisodicWasteSequenceNumber", typeof(ColumnAttribute), "SEQ_NUMBER", DbType.Int32)]
    [AppliedAttribute(typeof(EpisodicWaste), "WasteDescription", typeof(ColumnAttribute), "WASTE_DESC", DbType.AnsiString, 4000)]
    [AppliedAttribute(typeof(EpisodicWaste), "EstimatedQuantity", typeof(ColumnAttribute), "EST_QNTY", DbType.Int32)]

    //RCRA_HD_EPISODIC_EVENT
    [AppliedAttribute(typeof(HandlerEpisodicEvent), "TransactionCode", typeof(ColumnAttribute), "TRANSACTION_CODE", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(HandlerEpisodicEvent), "EpisodicEventOwner", typeof(ColumnAttribute), "EVENT_OWNER", DbType.AnsiStringFixedLength, 2)]
    [AppliedAttribute(typeof(HandlerEpisodicEvent), "EpisodicEventType", typeof(ColumnAttribute), "EVENT_TYPE", DbType.AnsiStringFixedLength, 1)]
    [AppliedPathAttribute("Handler.HandlerEpisodicEventArray.Contact.FirstName", typeof(ColumnAttribute), "CONTACT_FIRST_NAME", DbType.AnsiString, 38)]
    [AppliedPathAttribute("Handler.HandlerEpisodicEventArray.Contact.MiddleInitial", typeof(ColumnAttribute), "CONTACT_MIDDLE_INITIAL", DbType.AnsiStringFixedLength, 1)]
    [AppliedPathAttribute("Handler.HandlerEpisodicEventArray.Contact.LastName", typeof(ColumnAttribute), "CONTACT_LAST_NAME", DbType.AnsiString, 38)]
    [AppliedPathAttribute("Handler.HandlerEpisodicEventArray.Contact.OrganizationFormalName", typeof(ColumnAttribute), "CONTACT_ORG_NAME", DbType.AnsiString, 80)]
    [AppliedPathAttribute("Handler.HandlerEpisodicEventArray.Contact.IndividualTitleText", typeof(ColumnAttribute), "CONTACT_TITLE", DbType.AnsiString, 80)]
    [AppliedPathAttribute("Handler.HandlerEpisodicEventArray.Contact.EmailAddressText", typeof(ColumnAttribute), "CONTACT_EMAIL_ADDRESS", DbType.AnsiString, 80)]
    [AppliedPathAttribute("Handler.HandlerEpisodicEventArray.Contact.TelephoneNumberText", typeof(ColumnAttribute), "CONTACT_PHONE", DbType.AnsiString, 15)]
    [AppliedPathAttribute("Handler.HandlerEpisodicEventArray.Contact.PhoneExtensionText", typeof(ColumnAttribute), "CONTACT_PHONE_EXT", DbType.AnsiString, 6)]
    [AppliedPathAttribute("Handler.HandlerEpisodicEventArray.Contact.FaxNumberText", typeof(ColumnAttribute), "CONTACT_FAX", DbType.AnsiString, 15)]
    [AppliedPathAttribute("Handler.HandlerEpisodicEventArray.Contact.ContactLanguageCode", typeof(ColumnAttribute), "CONTACT_LANG_CODE", 2)]
    [AppliedPathAttribute("Handler.HandlerEpisodicEventArray.Contact.ContactLanguageDescription", typeof(ColumnAttribute), "CONTACT_LANG_DESC", 50)]
    [AppliedAttribute(typeof(HandlerEpisodicEvent), "EpisodicEventStartDate", typeof(ColumnAttribute), "START_DATE", DbType.Date)]
    [AppliedAttribute(typeof(HandlerEpisodicEvent), "EpisodicEventEndDate", typeof(ColumnAttribute), "END_DATE", DbType.Date)]

    //RCRA_HD_EPISODIC_PRJT
    [AppliedAttribute(typeof(EpisodicProjectDataType), "TransactionCode", typeof(ColumnAttribute), "TRANSACTION_CODE", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(EpisodicProjectDataType), "EpisodicProjectCodeOwner", typeof(ColumnAttribute), "PRJT_CODE_OWNER", DbType.AnsiStringFixedLength, 2)]
    [AppliedAttribute(typeof(EpisodicProjectDataType), "EpisodicProjectCode", typeof(ColumnAttribute), "PRJT_CODE", DbType.AnsiStringFixedLength, 3)]
    [AppliedAttribute(typeof(EpisodicProjectDataType), "OtherProjectDescription", typeof(ColumnAttribute), "OTHER_PRJT_DESC", DbType.AnsiString, 255)]

    [Table("RCRA_HD_SUBM")]
    public partial class HazardousWasteHandlerSubmissionDataType : BaseDataType, IBeforeSaveToDatabase, IAfterLoadFromDatabase
    {
        public virtual void BeforeSaveToDatabase()
        {
            CollectionUtils.ForEach(FacilitySubmission, delegate (FacilitySubmissionDataType facility)
            {
                CollectionUtils.ForEach(facility.Handler, delegate (HandlerDataType handler)
                {
                    handler.BeforeSaveToDatabase();
                    CollectionUtils.ForEach(handler.EnvironmentalPermit, delegate (EnvironmentalPermitDataType environmentalPermit)
                    {
                        if (string.IsNullOrEmpty(environmentalPermit.EnvironmentalPermitDescription))
                        {
                            environmentalPermit.EnvironmentalPermitDescription = RCRAHelper.NAString;
                        }
                    });
                });
            });
        }
        public virtual void AfterLoadFromDatabase()
        {
            CollectionUtils.ForEach(FacilitySubmission, delegate (FacilitySubmissionDataType facility)
            {
                CollectionUtils.ForEach(facility.Handler, delegate (HandlerDataType handler)
                {
                    handler.AfterLoadFromDatabase();
                });
            });
        }
    }

    [Table("RCRA_HD_HBASIC")]
    public partial class FacilitySubmissionDataType : BaseChildDataType
    {
    }

    [Table("RCRA_HD_HANDLER")]
    public partial class HandlerDataType : BaseChildDataType, IBeforeSaveToDatabase, IAfterLoadFromDatabase
    {
        public virtual void BeforeSaveToDatabase()
        {
            if (HandlerLqgConsolidation != null)
            {
                HandlerLqgConsolidationArray = HandlerLqgConsolidation;
            }
            if (HandlerLqgClosure != null)
            {
                HandlerLqgClosureArray = new HandlerLqgClosure[] { HandlerLqgClosure };
            }
            if (HandlerEpisodicEvent != null)
            {
                HandlerEpisodicEventArray = new HandlerEpisodicEvent[] { HandlerEpisodicEvent };
            }
            if ((HazardousSecondaryMaterial != null) && !CollectionUtils.IsNullOrEmpty(HazardousSecondaryMaterial.RecyclerIndicator))
            {
                HazardousSecondaryMaterial.RecyclingIndicator = HazardousSecondaryMaterial.RecyclerIndicator;
            }
        }

        public virtual void AfterLoadFromDatabase()
        {
            if (!CollectionUtils.IsNullOrEmpty(HandlerLqgConsolidationArray))
            {
                HandlerLqgConsolidation = HandlerLqgConsolidationArray;
            }
            if (!CollectionUtils.IsNullOrEmpty(HandlerLqgClosureArray))
            {
                HandlerLqgClosure = HandlerLqgClosureArray[0];
            }
            if (!CollectionUtils.IsNullOrEmpty(HandlerEpisodicEventArray))
            {
                HandlerEpisodicEvent = HandlerEpisodicEventArray[0];
            }
            if ((HazardousSecondaryMaterial != null) && !string.IsNullOrEmpty(HazardousSecondaryMaterial.RecyclerIndicator))
            {
                HazardousSecondaryMaterial.RecyclerIndicator = HazardousSecondaryMaterial.RecyclingIndicator;
            }
        }

        [System.Xml.Serialization.XmlIgnore]
        public string AcknowledgeFlag;

        [XmlIgnore]
        public HandlerLqgConsolidation[] HandlerLqgConsolidationArray;

        [XmlIgnore]
        public HandlerLqgClosure[] HandlerLqgClosureArray;

        [XmlIgnore]
        public HandlerEpisodicEvent[] HandlerEpisodicEventArray;
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
    [Table("RCRA_HD_EPISODIC_WASTE_CODE")]
    public partial class EpisodicHandlerWasteCodeDataType : HandlerWasteCodeDataType
    {
    }
    [Table("RCRA_HD_LQG_CONSOLIDATION")]
    public partial class HandlerLqgConsolidation : BaseChildDataType
    {
    }
    [Table("RCRA_HD_LQG_CLOSURE")]
    public partial class HandlerLqgClosure : BaseChildDataType
    {
    }
    [Table("RCRA_HD_EPISODIC_EVENT")]
    public partial class HandlerEpisodicEvent : BaseChildDataType
    {
    }
    [Table("RCRA_HD_EPISODIC_WASTE")]
    public partial class EpisodicWaste : BaseChildDataType
    {
    }
    [Table("RCRA_HD_EPISODIC_PRJT")]
    public partial class EpisodicProjectDataType : BaseChildDataType
    {
    }
    [Table("RCRA_HD_ADD_CONTACT")]
    public partial class AdditionalContactDataType : BaseChildDataType
    {
    }
    public partial class HazardousSecondaryMaterialDataType
    {
        [XmlIgnore]
        public string RecyclingIndicator;
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

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("Contact prefered language")]
        public string ContactLanguageCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("Contact prefered language description")]
        public string ContactLanguageDescription;
    }

    [DefaultTableNamePrefixAttribute("RCRA")]
    [DefaultStringDbValues(DbType.AnsiString, 255)]
    [DefaultDecimalPrecision(14, 6)]
    [ShortenNamesByRemovingVowelsFirstAttribute]
    [FixShortenNameBreakBugAttribute]
    [InheritAppliedAttributesAttribute]
    [UseTableNameForDefaultPrimaryKeysAttribute()]
    [DefaultFixedStringDbMaxLengthAttribute(2)]

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

    [AppliedAttribute(typeof(CorrectiveActionRelatedEventDataType), "AgencyText", typeof(DbIgnoreAttribute))]

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
    [DefaultFixedStringDbMaxLengthAttribute(2)]

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
    [AppliedAttribute(typeof(PermitUnitDetailDataType), "PermitUnitCapacityQuantity", typeof(ColumnAttribute), DbType.Decimal, 14, 3)]
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
    [AppliedPathAttribute("PermitFacilitySubmission.PermitUnit.PermitUnitDetail.HandlerWasteCodeDetails.TransactionCode", typeof(ColumnAttribute), "TRANSACTION_CODE", 1)]
    [AppliedPathAttribute("PermitFacilitySubmission.PermitUnit.PermitUnitDetail.HandlerWasteCodeDetails.WasteCodeOwnerName", typeof(ColumnAttribute), "WASTE_CODE_OWNER", 2)]
    [AppliedPathAttribute("PermitFacilitySubmission.PermitUnit.PermitUnitDetail.HandlerWasteCodeDetails.WasteCode", typeof(ColumnAttribute), "WASTE_CODE_TYPE", 6)]
    [AppliedPathAttribute("PermitFacilitySubmission.PermitUnit.PermitUnitDetail.HandlerWasteCodeDetails.WasteCodeText", typeof(DbIgnoreAttribute))]
    //[AppliedAttribute(typeof(PermitHandlerWasteCodeDataType), "TransactionCode", typeof(ColumnAttribute), "TRANSACTION_CODE", 1)]
    //[AppliedAttribute(typeof(PermitHandlerWasteCodeDataType), "WasteCodeOwnerName", typeof(ColumnAttribute), "WASTE_CODE_OWNER", 2)]
    //[AppliedAttribute(typeof(PermitHandlerWasteCodeDataType), "WasteCode", typeof(ColumnAttribute), "WASTE_CODE_TYPE", 6)]
    //[AppliedAttribute(typeof(PermitHandlerWasteCodeDataType), "WasteCodeText", typeof(DbIgnoreAttribute))]

    //EventCommitmentDataType
    [AppliedAttribute(typeof(EventCommitmentDataType), "TransactionCode", typeof(ColumnAttribute), 1)]
    [AppliedAttribute(typeof(EventCommitmentDataType), "CommitmentLead", typeof(ColumnAttribute), 2)]
    [AppliedAttribute(typeof(EventCommitmentDataType), "CommitmentSequenceNumber", typeof(ColumnAttribute), DbType.Int32)]

    //HazardousWastePermitDataType

    //EventCommitmentDataType
    [AppliedAttribute(typeof(PermitModEventDataType), "ModHandlerId", typeof(ColumnAttribute), "MOD_HANDLER_ID")]

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
    [Table("RCRA_PRM_MOD_EVENT")]
    public partial class PermitModEventDataType : BaseChildDataType
    {
    }

    [DefaultTableNamePrefixAttribute("RCRA")]
    [DefaultStringDbValues(DbType.AnsiString, 255)]
    [DefaultDecimalPrecision(14, 6)]
    [ShortenNamesByRemovingVowelsFirstAttribute]
    [FixShortenNameBreakBugAttribute]
    [InheritAppliedAttributesAttribute]
    [UseTableNameForDefaultPrimaryKeysAttribute()]
    [DefaultFixedStringDbMaxLengthAttribute(2)]

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

    [AppliedAttribute(typeof(CostEstimateDataType), "CostEstimateAmount", typeof(ColumnAttribute), DbType.Decimal, 13, 2)]
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
    [AppliedAttribute(typeof(MechanismDetailDataType), "FaceValueAmount", typeof(ColumnAttribute), DbType.Decimal, 13, 2)]
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
    [DefaultFixedStringDbMaxLengthAttribute(2)]

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
    [AppliedAttribute(typeof(AreaAcreageDataType), "AreaAcreageMeasure", typeof(ColumnAttribute), DbType.Decimal, 13, 2)]
    [AppliedAttribute(typeof(AreaAcreageDataType), "AreaMeasureSourceDataOwnerCode", typeof(ColumnAttribute), 2)]
    [AppliedAttribute(typeof(AreaAcreageDataType), "AreaMeasureSourceCode", typeof(ColumnAttribute))]
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
                            if ((geoInfo.rcraWhere != null) && (geoInfo.rcraWhere.Point != null))
                            {
                                if (isBeforeSaveToDatabase)
                                {
                                    geoInfo.rcraWhere.Point.BeforeSaveToDatabase();
                                }
                                else
                                {
                                    geoInfo.rcraWhere.Point.AfterLoadFromDatabase();
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



    [DefaultTableNamePrefixAttribute("RCRA")]
    [DefaultStringDbValues(DbType.AnsiString, 255)]
    [DefaultDecimalPrecision(14, 6)]
    [ShortenNamesByRemovingVowelsFirstAttribute]
    [FixShortenNameBreakBugAttribute]
    [InheritAppliedAttributesAttribute]
    [UseTableNameForDefaultPrimaryKeysAttribute()]
    [DefaultFixedStringDbMaxLengthAttribute(2)]

    //RCRA_RU_SUBM
    // TSM: Removed element:
    //[AppliedAttribute(typeof(ReportUnivSubmission), "HandlerID", typeof(ColumnAttribute), "HANDLER_ID", 12, false)]

    //RCRA_RU_REPORT_UNIV
    [AppliedAttribute(typeof(ReportUniv), "HandlerIdCode", typeof(ColumnAttribute), "HANDLER_ID", DbType.AnsiString, 12)]
    [AppliedAttribute(typeof(ReportUniv), "ActivityLocationCode", typeof(ColumnAttribute), "ACTIVITY_LOCATION", DbType.AnsiStringFixedLength, 2)]
    [AppliedAttribute(typeof(ReportUniv), "SourceTypeCode", typeof(ColumnAttribute), "SOURCE_TYPE", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "SequenceNumber", typeof(ColumnAttribute), "SEQ_NUMBER", DbType.Int32)]
    [AppliedAttribute(typeof(ReportUniv), "ReceiveDate", typeof(ColumnAttribute), "RECEIVE_DATE", DbType.DateTime)]
    [AppliedAttribute(typeof(ReportUniv), "HandlerName", typeof(ColumnAttribute), "HANDLER_NAME", DbType.AnsiString, 80)]
    [AppliedAttribute(typeof(ReportUniv), "NonNotifierIndicator", typeof(ColumnAttribute), "NON_NOTIFIER_IND", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "Accessibility", typeof(ColumnAttribute), "ACCESSIBILITY", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "ReportCycle", typeof(ColumnAttribute), "REPORT_CYCLE", DbType.Int32)]
    [AppliedAttribute(typeof(ReportUniv), "Region", typeof(ColumnAttribute), "REGION", DbType.AnsiStringFixedLength, 2)]
    [AppliedAttribute(typeof(ReportUniv), "State", typeof(ColumnAttribute), "STATE", DbType.AnsiStringFixedLength, 2)]
    [AppliedAttribute(typeof(ReportUniv), "ExtractFlag", typeof(ColumnAttribute), "EXTRACT_FLAG", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "ActiveSite", typeof(ColumnAttribute), "ACTIVE_SITE", DbType.AnsiString, 5)]
    [AppliedAttribute(typeof(ReportUniv), "CountyCode", typeof(ColumnAttribute), "COUNTY_CODE", DbType.AnsiString, 5)]
    [AppliedAttribute(typeof(ReportUniv), "CountyName", typeof(ColumnAttribute), "COUNTY_NAME", DbType.AnsiString, 80)]
    [AppliedPathAttribute("ReportUniv.LocationAddress.LocationAddressNumberText", typeof(ColumnAttribute), "LOCATION_STREET_NUMBER", DbType.AnsiString, 12)]
    [AppliedPathAttribute("ReportUniv.LocationAddress.LocationAddressText", typeof(ColumnAttribute), "LOCATION_STREET1", DbType.AnsiString, 50)]
    [AppliedPathAttribute("ReportUniv.LocationAddress.SupplementalLocationText", typeof(ColumnAttribute), "LOCATION_STREET2", DbType.AnsiString, 50)]
    [AppliedPathAttribute("ReportUniv.LocationAddress.LocalityName", typeof(ColumnAttribute), "LOCATION_CITY", DbType.AnsiString, 25)]
    [AppliedPathAttribute("ReportUniv.LocationAddress.StateUSPSCode", typeof(ColumnAttribute), "LOCATION_STATE", DbType.AnsiStringFixedLength, 2)]
    [AppliedPathAttribute("ReportUniv.LocationAddress.CountryName", typeof(ColumnAttribute), "LOCATION_COUNTRY", DbType.AnsiStringFixedLength, 2)]
    [AppliedPathAttribute("ReportUniv.LocationAddress.LocationZIPCode", typeof(ColumnAttribute), "LOCATION_ZIP", DbType.AnsiStringFixedLength, 14)]
    [AppliedPathAttribute("ReportUniv.MailingAddress.MailingAddressNumberText", typeof(ColumnAttribute), "MAIL_STREET_NUMBER", DbType.AnsiString, 12)]
    [AppliedPathAttribute("ReportUniv.MailingAddress.MailingAddressText", typeof(ColumnAttribute), "MAIL_STREET1", DbType.AnsiString, 50)]
    [AppliedPathAttribute("ReportUniv.MailingAddress.SupplementalAddressText", typeof(ColumnAttribute), "MAIL_STREET2", DbType.AnsiString, 50)]
    [AppliedPathAttribute("ReportUniv.MailingAddress.MailingAddressCityName", typeof(ColumnAttribute), "MAIL_CITY", DbType.AnsiString, 25)]
    [AppliedPathAttribute("ReportUniv.MailingAddress.MailingAddressStateUSPSCode", typeof(ColumnAttribute), "MAIL_STATE", DbType.AnsiStringFixedLength, 2)]
    [AppliedPathAttribute("ReportUniv.MailingAddress.MailingAddressCountryName", typeof(ColumnAttribute), "MAIL_COUNTRY", DbType.AnsiStringFixedLength, 2)]
    [AppliedPathAttribute("ReportUniv.MailingAddress.MailingAddressZIPCode", typeof(ColumnAttribute), "MAIL_ZIP", DbType.AnsiString, 14)]
    [AppliedPathAttribute("ReportUniv.RUContactAddress.MailingAddressNumberText", typeof(ColumnAttribute), "CONTACT_STREET_NUMBER", DbType.AnsiString, 12)]
    [AppliedPathAttribute("ReportUniv.RUContactAddress.MailingAddressText", typeof(ColumnAttribute), "CONTACT_STREET1", DbType.AnsiString, 50)]
    [AppliedPathAttribute("ReportUniv.RUContactAddress.SupplementalAddressText", typeof(ColumnAttribute), "CONTACT_STREET2", DbType.AnsiString, 50)]
    [AppliedPathAttribute("ReportUniv.RUContactAddress.MailingAddressCityName", typeof(ColumnAttribute), "CONTACT_CITY", DbType.AnsiString, 25)]
    [AppliedPathAttribute("ReportUniv.RUContactAddress.MailingAddressStateUSPSCode", typeof(ColumnAttribute), "CONTACT_STATE", DbType.AnsiStringFixedLength, 2)]
    [AppliedPathAttribute("ReportUniv.RUContactAddress.MailingAddressCountryName", typeof(ColumnAttribute), "CONTACT_COUNTRY", DbType.AnsiStringFixedLength, 2)]
    [AppliedPathAttribute("ReportUniv.RUContactAddress.MailingAddressZIPCode", typeof(ColumnAttribute), "CONTACT_ZIP", DbType.AnsiString, 14)]
    [AppliedAttribute(typeof(ReportUniv), "ContactNameCode", typeof(ColumnAttribute), "CONTACT_NAME", DbType.AnsiString, 80)]
    [AppliedAttribute(typeof(ReportUniv), "ContactPhoneCode", typeof(ColumnAttribute), "CONTACT_PHONE", DbType.AnsiString, 22)]
    [AppliedAttribute(typeof(ReportUniv), "ContactFaxCode", typeof(ColumnAttribute), "CONTACT_FAX", DbType.AnsiString, 15)]
    [AppliedAttribute(typeof(ReportUniv), "ContactEmailCode", typeof(ColumnAttribute), "CONTACT_EMAIL", DbType.AnsiString, 80)]
    [AppliedAttribute(typeof(ReportUniv), "ContactTitleCode", typeof(ColumnAttribute), "CONTACT_TITLE", DbType.AnsiString, 45)]
    [AppliedAttribute(typeof(ReportUniv), "ContactLanguageCode", typeof(ColumnAttribute), "CONTACT_LANG_CODE", 2)]
    [AppliedAttribute(typeof(ReportUniv), "ContactLanguageDescription", typeof(ColumnAttribute), "CONTACT_LANG_DESC", 50)]
    [AppliedAttribute(typeof(ReportUniv), "OwnerNameCode", typeof(ColumnAttribute), "OWNER_NAME", DbType.AnsiString, 80)]
    [AppliedAttribute(typeof(ReportUniv), "OwnerTypeCode", typeof(ColumnAttribute), "OWNER_TYPE", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "OwnerSeqCode", typeof(ColumnAttribute), "OWNER_SEQ_NUM", DbType.Int32)]
    [AppliedAttribute(typeof(ReportUniv), "OperatorNameCode", typeof(ColumnAttribute), "OPER_NAME", DbType.AnsiString, 80)]
    [AppliedAttribute(typeof(ReportUniv), "OperatorTypeCode", typeof(ColumnAttribute), "OPER_TYPE", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "OperatorSeqCode", typeof(ColumnAttribute), "OPER_SEQ_NUM", DbType.Int32)]
    [AppliedAttribute(typeof(ReportUniv), "NAIC1Code", typeof(ColumnAttribute), "NAIC1_CODE", DbType.AnsiString, 6)]
    [AppliedAttribute(typeof(ReportUniv), "NAIC2Code", typeof(ColumnAttribute), "NAIC2_CODE", DbType.AnsiString, 6)]
    [AppliedAttribute(typeof(ReportUniv), "NAIC3Code", typeof(ColumnAttribute), "NAIC3_CODE", DbType.AnsiString, 6)]
    [AppliedAttribute(typeof(ReportUniv), "NAIC4Code", typeof(ColumnAttribute), "NAIC4_CODE", DbType.AnsiString, 6)]
    [AppliedAttribute(typeof(ReportUniv), "InHandlerUniverseCode", typeof(ColumnAttribute), "IN_HANDLER_UNIVERSE", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "InAUniverseCode", typeof(ColumnAttribute), "IN_A_UNIVERSE", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "FederalWasteGeneratorOwner", typeof(ColumnAttribute), "FED_WASTE_GENERATOR_OWNER", DbType.AnsiStringFixedLength, 2)]
    [AppliedAttribute(typeof(ReportUniv), "FederalWasteGeneratorCode", typeof(ColumnAttribute), "FED_WASTE_GENERATOR", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "StateWasteGeneratorOwner", typeof(ColumnAttribute), "STATE_WASTE_GENERATOR_OWNER", DbType.AnsiStringFixedLength, 2)]
    [AppliedAttribute(typeof(ReportUniv), "StateWasteGeneratorCode", typeof(ColumnAttribute), "STATE_WASTE_GENERATOR", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "GENSTATUS", typeof(ColumnAttribute), "GEN_STATUS", DbType.AnsiString, 3)]
    [AppliedAttribute(typeof(ReportUniv), "UNIVWASTE", typeof(ColumnAttribute), "UNIV_WASTE", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "LandTypeCode", typeof(ColumnAttribute), "LAND_TYPE", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "StateDistrictOwnerName", typeof(ColumnAttribute), "STATE_DISTRICT_OWNER", DbType.AnsiStringFixedLength, 2)]
    [AppliedAttribute(typeof(ReportUniv), "StateDistrictCode", typeof(ColumnAttribute), "STATE_DISTRICT", DbType.AnsiString, 10)]
    [AppliedAttribute(typeof(ReportUniv), "ShortTermGeneratorIndicator", typeof(ColumnAttribute), "SHORT_TERM_GEN_IND", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "ImporterActivityCode", typeof(ColumnAttribute), "IMPORTER_ACTIVITY", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "MixedWasteGeneratorCode", typeof(ColumnAttribute), "MIXED_WASTE_GENERATOR", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "TransporterActivityCode", typeof(ColumnAttribute), "TRANSPORTER_ACTIVITY", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "TransferFacilityIndicator", typeof(ColumnAttribute), "TRANSFER_FACILITY_IND", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "RecyclerActivityCode", typeof(ColumnAttribute), "RECYCLER_ACTIVITY", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "OnsiteBurnerExemptionCode", typeof(ColumnAttribute), "ONSITE_BURNER_EXEMPTION", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "FurnaceExemptionCode", typeof(ColumnAttribute), "FURNACE_EXEMPTION", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "UndergroundInjectionActivityCode", typeof(ColumnAttribute), "UNDERGROUND_INJECTION_ACTIVITY", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "UniversalWasteDestinationFacilityIndicator", typeof(ColumnAttribute), "UNIVERSAL_WASTE_DEST_FACILITY", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "OffSiteWasteReceiptCode", typeof(ColumnAttribute), "OFFSITE_WASTE_RECEIPT", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "UsedOilCode", typeof(ColumnAttribute), "USED_OIL", DbType.AnsiString, 7)]
    [AppliedAttribute(typeof(ReportUniv), "FederalUniversalWasteCode", typeof(ColumnAttribute), "FEDERAL_UNIVERSAL_WASTE", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "AsFederalRegulatedTSDFCode", typeof(ColumnAttribute), "AS_FEDERAL_REGULATED_TSDF", DbType.AnsiString, 6)]
    [AppliedAttribute(typeof(ReportUniv), "AsConverterTSDFCode", typeof(ColumnAttribute), "AS_CONVERTED_TSDF", DbType.AnsiString, 6)]
    [AppliedAttribute(typeof(ReportUniv), "AsStateRegulatedTSDFCode", typeof(ColumnAttribute), "AS_STATE_REGULATED_TSDF", DbType.AnsiString, 9)]
    [AppliedAttribute(typeof(ReportUniv), "FederalIndicatorCode", typeof(ColumnAttribute), "FEDERAL_IND", DbType.AnsiString, 3)]
    [AppliedAttribute(typeof(ReportUniv), "HSMCode", typeof(ColumnAttribute), "HSM", DbType.AnsiStringFixedLength, 2)]
    [AppliedAttribute(typeof(ReportUniv), "SubpartKCode", typeof(ColumnAttribute), "SUBPART_K", DbType.AnsiString, 4)]
    [AppliedAttribute(typeof(ReportUniv), "CommercialTSDCode", typeof(ColumnAttribute), "COMMERCIAL_TSD", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "TSDTypeCode", typeof(ColumnAttribute), "TSD", DbType.AnsiString, 5)]
    [AppliedAttribute(typeof(ReportUniv), "GPRAPermitCode", typeof(ColumnAttribute), "GPRA_PERMIT", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "GPRARenewalCode", typeof(ColumnAttribute), "GPRA_RENEWAL", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "PermitRenewalWRKLDCode", typeof(ColumnAttribute), "PERMIT_RENEWAL_WRKLD", DbType.AnsiString, 6)]
    [AppliedAttribute(typeof(ReportUniv), "PermWRKLDCode", typeof(ColumnAttribute), "PERM_WRKLD", DbType.AnsiString, 6)]
    [AppliedAttribute(typeof(ReportUniv), "PermPROGCode", typeof(ColumnAttribute), "PERM_PROG", DbType.AnsiString, 6)]
    [AppliedAttribute(typeof(ReportUniv), "PCWRKLDCode", typeof(ColumnAttribute), "PC_WRKLD", DbType.AnsiString, 6)]
    [AppliedAttribute(typeof(ReportUniv), "ClosWRKLDCode", typeof(ColumnAttribute), "CLOS_WRKLD", DbType.AnsiString, 6)]
    [AppliedAttribute(typeof(ReportUniv), "GPRACACode", typeof(ColumnAttribute), "GPRACA", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "CAWRKLDCode", typeof(ColumnAttribute), "CA_WRKLD", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "SubjCACode", typeof(ColumnAttribute), "SUBJ_CA", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "SubjCANonTSDCode", typeof(ColumnAttribute), "SUBJ_CA_NON_TSD", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "SubjCATSD3004Code", typeof(ColumnAttribute), "SUBJ_CA_TSD_3004", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "SubjCADiscretionCode", typeof(ColumnAttribute), "SUBJ_CA_DISCRETION", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "NCAPSCode", typeof(ColumnAttribute), "NCAPS", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "ECIndicatorCode", typeof(ColumnAttribute), "EC_IND", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "ICIndicatorCode", typeof(ColumnAttribute), "IC_IND", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "CA725IndicatorCode", typeof(ColumnAttribute), "CA_725_IND", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "CA750IndicatorCode", typeof(ColumnAttribute), "CA_750_IND", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "OperatingTSDFCode", typeof(ColumnAttribute), "OPERATING_TSDF", DbType.AnsiString, 6)]
    [AppliedAttribute(typeof(ReportUniv), "FullEnforcementCode", typeof(ColumnAttribute), "FULL_ENFORCEMENT", DbType.AnsiString, 6)]
    [AppliedAttribute(typeof(ReportUniv), "SNCCode", typeof(ColumnAttribute), "SNC", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "BOYSNCCode", typeof(ColumnAttribute), "BOY_SNC", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "BOYStateUnaddressedSNCCode", typeof(ColumnAttribute), "BOY_STATE_UNADDRESSED_SNC", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "StateUnaddressedCode", typeof(ColumnAttribute), "STATE_UNADDRESSED", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "StateAddressedCode", typeof(ColumnAttribute), "STATE_ADDRESSED", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "BOYStateAddressedCode", typeof(ColumnAttribute), "BOY_STATE_ADDRESSED", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "StateSNCWithCompSchedCode", typeof(ColumnAttribute), "STATE_SNC_WITH_COMP_SCHED", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "BOYStateSNCWithCompSchedCode", typeof(ColumnAttribute), "BOY_STATE_SNC_WITH_COMP_SCHED", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "EPAUnaddressedCode", typeof(ColumnAttribute), "EPA_UNADDRESSED", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "BOYEPAUnaddressedCode", typeof(ColumnAttribute), "BOY_EPA_UNADDRESSED", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "EPAAddressedCode", typeof(ColumnAttribute), "EPA_ADDRESSED", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "BOYEPAAddressedCode", typeof(ColumnAttribute), "BOY_EPA_ADDRESSED", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "EPASNCWithcompSchedCode", typeof(ColumnAttribute), "EPA_SNC_WITH_COMP_SCHED", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "BOYEPASNCWithcompSchedCode", typeof(ColumnAttribute), "BOY_EPA_SNC_WITH_COMP_SCHED", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "FARequiredCode", typeof(ColumnAttribute), "FA_REQUIRED", DbType.AnsiString, 5)]
    [AppliedAttribute(typeof(ReportUniv), "HHandlerLastChangeDate", typeof(ColumnAttribute), "HHANDLER_LAST_CHANGE_DATE", DbType.DateTime)]
    [AppliedAttribute(typeof(ReportUniv), "PublicNotesCode", typeof(ColumnAttribute), "PUBLIC_NOTES", DbType.AnsiString, 4000)]
    [AppliedAttribute(typeof(ReportUniv), "NotesCode", typeof(ColumnAttribute), "NOTES", DbType.AnsiString, 4000)]
    [AppliedAttribute(typeof(ReportUniv), "RecognizedTraderImporterIndicator", typeof(ColumnAttribute), "RECOGNIZED_TRADER_IMPORTER_IND", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "RecognizedTraderExporterIndicator", typeof(ColumnAttribute), "RECOGNIZED_TRADER_EXPORTER_IND", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "SlabImporterIndicator", typeof(ColumnAttribute), "SLAB_IMPORTER_IND", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "SlabExporterIndicator", typeof(ColumnAttribute), "SLAB_EXPORTER_IND", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "RecyclerNonStorageIndicator", typeof(ColumnAttribute), "RECYCLER_NON_STORAGE_IND", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "ManifestBrokerIndicator", typeof(ColumnAttribute), "MANIFEST_BROKER_IND", DbType.AnsiStringFixedLength, 1)]
    //[AppliedAttribute(typeof(ReportUniv), "LqgConsolidationIndicator", typeof(ColumnAttribute), "LQG_CONSOLIDATION_IND", DbType.AnsiStringFixedLength, 1)]
    //[AppliedAttribute(typeof(ReportUniv), "LqgClosureIndicator", typeof(ColumnAttribute), "LQG_CLOSURE_IND", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "LocationLatitude", typeof(ColumnAttribute), "LOCATION_LATITUDE", DbType.Decimal, 19, 14)]
    [AppliedAttribute(typeof(ReportUniv), "LocationLongitude", typeof(ColumnAttribute), "LOCATION_LONGITUDE", DbType.Decimal, 19, 14)]
    [AppliedAttribute(typeof(ReportUniv), "LocationGisPrimary", typeof(ColumnAttribute), "LOCATION_GIS_PRIM", DbType.AnsiStringFixedLength, 1)]
    [AppliedAttribute(typeof(ReportUniv), "LocationGisOrig", typeof(ColumnAttribute), "LOCATION_GIS_ORIG", DbType.AnsiString, 2)]

    [AppliedAttribute(typeof(HazardousWasteReportUnivDataType), "DataAccessText", typeof(ColumnAttribute), "DATA_ACCESS", 10)]

    [Table("RCRA_RU_SUBM")]
    public partial class HazardousWasteReportUnivDataType : BaseDataType
    {
    }
    [Table("RCRA_RU_REPORT_UNIV_SUBM")]
    public partial class ReportUnivSubmission : BaseChildDataType
    {
    }
    [Table("RCRA_RU_REPORT_UNIV")]
    public partial class ReportUniv : BaseChildDataType
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
    [DefaultStringDbValues(DbType.AnsiString, 255)]
    [DefaultDecimalPrecision(14, 6)]
    [ShortenNamesByRemovingVowelsFirstAttribute]
    [FixShortenNameBreakBugAttribute]
    [InheritAppliedAttributesAttribute]
    [UseTableNameForDefaultPrimaryKeysAttribute()]
    [DefaultFixedStringDbMaxLengthAttribute(2)]


    [AppliedAttribute(typeof(Emanifests), "CreatedDate", typeof(ColumnAttribute), "CREATED_DATE")]
    [AppliedAttribute(typeof(Emanifests), "UpdatedDate", typeof(ColumnAttribute), "UPDATED_DATE")]
    [AppliedAttribute(typeof(Emanifests), "ManifestTrackingNumber", typeof(ColumnAttribute), "MAN_TRACKING_NUM")]
    [AppliedAttribute(typeof(Emanifests), "Status", typeof(ColumnAttribute), "STATUS")]
    [AppliedAttribute(typeof(Emanifests), "SubmissionType", typeof(ColumnAttribute), "SUBM_TYPE")]
    [AppliedAttribute(typeof(Emanifests), "OriginType", typeof(ColumnAttribute), "ORIGIN_TYPE")]
    [AppliedAttribute(typeof(Emanifests), "ShippedDate", typeof(ColumnAttribute), "SHIPPED_DATE")]
    [AppliedAttribute(typeof(Emanifests), "ReceivedDate", typeof(ColumnAttribute), "RECEIVED_DATE")]
    [AppliedAttribute(typeof(Emanifests), "CertifiedDate", typeof(ColumnAttribute), "CERT_DATE")]
    [AppliedAttribute(typeof(Emanifests), "Rejection", typeof(ColumnAttribute), "REJ_IND")]


    //[AppliedPathAttribute("CertifiedBy.ManifestFirstName", typeof(ColumnAttribute), "CERT_BY_FIRST_NAME")]
    //[AppliedPathAttribute("CertifiedBy.ManifestLastName", typeof(ColumnAttribute), "CERT_BY_LAST_NAME")]
    //[AppliedPathAttribute("CertifiedBy.SignerUserId", typeof(ColumnAttribute), "CERT_BY_USER_ID")]
    //[AppliedPathAttribute("RejectionInfo.TransporterOnSite", typeof(ColumnAttribute), "REJ_TRANS_ON_SITE_IND")]
    //[AppliedPathAttribute("RejectionInfo.RejectionType", typeof(ColumnAttribute), "REJ_TYPE")]
    //[AppliedPathAttribute("RejectionInfo.AlternateDesignatedFacilityType", typeof(ColumnAttribute), "REJ_ALT_DES_FAC_TYPE")]
    //[AppliedPathAttribute("RejectionInfo.GeneratorPaperSignature.PrintedName", typeof(ColumnAttribute), "REJ_GEN_PS_NAME")]
    //[AppliedPathAttribute("RejectionInfo.GeneratorPaperSignature.PaperSignatureDate", typeof(ColumnAttribute), "REJ_GEN_PS_DATE")]
    //[AppliedPathAttribute("RejectionInfo.GeneratorElectronicSignature.Signer.ManifestFirstName", typeof(ColumnAttribute), "REJ_GEN_ES_SIGNER_FIRST_NAME")]
    //[AppliedPathAttribute("RejectionInfo.GeneratorElectronicSignature.Signer.ManifestLastName", typeof(ColumnAttribute), "REJ_GEN_ES_SIGNER_LAST_NAME")]
    //[AppliedPathAttribute("RejectionInfo.GeneratorElectronicSignature.Signer.SignerUserId", typeof(ColumnAttribute), "REJ_GEN_ES_SIGNER_USER_ID")]
    //[AppliedPathAttribute("RejectionInfo.GeneratorElectronicSignature.ElectronicSignatureDate", typeof(ColumnAttribute), "REJ_GEN_ES_SIGN_DATE")]
    //[AppliedPathAttribute("RejectionInfo.GeneratorElectronicSignature.HumanReadableDocument.DocumentName", typeof(ColumnAttribute), "REJ_GEN_ES_DOC_NAME")]
    //[AppliedPathAttribute("RejectionInfo.GeneratorElectronicSignature.HumanReadableDocument.Size", typeof(ColumnAttribute), "REJ_GEN_ES_DOC_SIZE")]
    //[AppliedPathAttribute("RejectionInfo.GeneratorElectronicSignature.HumanReadableDocument.MimeType", typeof(ColumnAttribute), "REJ_GEN_ES_DOC_MIME_TYPE")]
    //[AppliedPathAttribute("RejectionInfo.GeneratorElectronicSignature.CromerrActivityId", typeof(ColumnAttribute), "REJ_GEN_ES_CROMERR_ACT_ID")]
    //[AppliedPathAttribute("RejectionInfo.GeneratorElectronicSignature.CromerrDocumentId", typeof(ColumnAttribute), "REJ_GEN_ES_CROMERR_DOC_ID")]
    //[AppliedPathAttribute("RejectionInfo.RejectionComments", typeof(ColumnAttribute), "REJ_COMMENTS")]
    //[AppliedAttribute(typeof(Emanifests), "Discrepancy", typeof(ColumnAttribute), "DISCREPANCY_IND")]
    //[AppliedAttribute(typeof(Emanifests), "Residue", typeof(ColumnAttribute), "RESIDUE_IND")]
    //[AppliedAttribute(typeof(Emanifests), "Import", typeof(ColumnAttribute), "IMP_IND")]
    //[AppliedPathAttribute("ImportInfo.ImportGenerator.ImportGeneratorName", typeof(ColumnAttribute), "IMP_GEN_NAME")]
    //[AppliedPathAttribute("ImportInfo.ImportGenerator.ImportGeneratorAddress", typeof(ColumnAttribute), "IMP_GEN_ADDRESS")]
    //[AppliedPathAttribute("ImportInfo.ImportGenerator.ImportCity", typeof(ColumnAttribute), "IMP_GEN_CITY")]
    //[AppliedPathAttribute("ImportInfo.ImportGenerator.Country.ManifestLocalityCode", typeof(ColumnAttribute), "IMP_GEN_CNTRY_CODE")]
    //[AppliedPathAttribute("ImportInfo.ImportGenerator.Country.ManifestLocalityName", typeof(ColumnAttribute), "IMP_GEN_CNTRY_NAME")]
    //[AppliedPathAttribute("ImportInfo.ImportGenerator.PostalCode", typeof(ColumnAttribute), "IMP_GEN_POSTAL_CODE")]
    //[AppliedPathAttribute("ImportInfo.ImportGenerator.Province", typeof(ColumnAttribute), "IMP_GEN_PROVINCE")]
    //[AppliedPathAttribute("ImportInfo.ImportPortInfo.ImportCity", typeof(ColumnAttribute), "IMP_PORT_CITY")]
    //[AppliedPathAttribute("ImportInfo.ImportPortInfo.ManifestState.ManifestLocalityCode", typeof(ColumnAttribute), "IMP_PORT_STATE_CODE")]
    //[AppliedPathAttribute("ImportInfo.ImportPortInfo.ManifestState.ManifestLocalityName", typeof(ColumnAttribute), "IMP_PORT_STATE_NAME")]
    //[AppliedAttribute(typeof(Emanifests), "ContainsPreviousRejectOrResidue", typeof(ColumnAttribute), "CONT_PREV_REJ_RES_IND")]
    //[AppliedPathAttribute("PrintedDocument.DocumentName", typeof(ColumnAttribute), "PRINTED_DOC_NAME")]
    //[AppliedPathAttribute("PrintedDocument.Size", typeof(ColumnAttribute), "PRINTED_DOC_SIZE")]
    //[AppliedPathAttribute("PrintedDocument.MimeType", typeof(ColumnAttribute), "PRINTED_DOC_MIME_TYPE")]
    //[AppliedPathAttribute("FormDocument.DocumentName", typeof(ColumnAttribute), "FORM_DOC_NAME")]
    //[AppliedPathAttribute("FormDocument.Size", typeof(ColumnAttribute), "FORM_DOC_SIZE")]
    //[AppliedPathAttribute("FormDocument.MimeType", typeof(ColumnAttribute), "FORM_DOC_MIME_TYPE")]
    //[AppliedPathAttribute("EmanifestsAdditionalInfo.NewManifestDestination", typeof(ColumnAttribute), "ADD_INFO_NEW_MAN_DEST")]
    //[AppliedPathAttribute("EmanifestsAdditionalInfo.ConsentNumber", typeof(ColumnAttribute), "ADD_INFO_CONSENT_NUM")]
    //[AppliedPathAttribute("EmanifestsAdditionalInfo.HandlingInstructions", typeof(ColumnAttribute), "ADD_INFO_HAND_INSTR")]
    //[AppliedPathAttribute("CorrectionInfo.VersionNumber", typeof(ColumnAttribute), "CORR_VERSION_NUM")]
    //[AppliedPathAttribute("CorrectionInfo.Active", typeof(ColumnAttribute), "CORR_ACTIVE_IND")]
    //[AppliedPathAttribute("CorrectionInfo.CorrectionElectronicSignatureInfo.Signer.ManifestFirstName", typeof(ColumnAttribute), "CORR_ES_SIGNER_FIRST_NAME")]
    //[AppliedPathAttribute("CorrectionInfo.CorrectionElectronicSignatureInfo.Signer.ManifestLastName", typeof(ColumnAttribute), "CORR_ES_SIGNER_LAST_NAME")]
    //[AppliedPathAttribute("CorrectionInfo.CorrectionElectronicSignatureInfo.Signer.SignerUserId", typeof(ColumnAttribute), "CORR_ES_SIGNER_USER_ID")]
    //[AppliedPathAttribute("CorrectionInfo.CorrectionElectronicSignatureInfo.ElectronicSignatureDate", typeof(ColumnAttribute), "CORR_ES_SIGN_DATE")]
    //[AppliedPathAttribute("CorrectionInfo.CorrectionElectronicSignatureInfo.HumanReadableDocument.DocumentName", typeof(ColumnAttribute), "CORR_ES_DOC_NAME")]
    //[AppliedPathAttribute("CorrectionInfo.CorrectionElectronicSignatureInfo.HumanReadableDocument.Size", typeof(ColumnAttribute), "CORR_ES_DOC_SIZE")]
    //[AppliedPathAttribute("CorrectionInfo.CorrectionElectronicSignatureInfo.HumanReadableDocument.MimeType", typeof(ColumnAttribute), "CORR_ES_DOC_MIME_TYPE")]
    //[AppliedPathAttribute("CorrectionInfo.CorrectionElectronicSignatureInfo.CromerrActivityId", typeof(ColumnAttribute), "CORR_ES_CROMERR_ACT_ID")]
    //[AppliedPathAttribute("CorrectionInfo.CorrectionElectronicSignatureInfo.CromerrDocumentId", typeof(ColumnAttribute), "CORR_ES_CROMERR_DOC_ID")]
    //[AppliedPathAttribute("CorrectionInfo.EpaSiteId", typeof(ColumnAttribute), "CORR_EPA_SITE_ID")]


    //[AppliedAttribute(typeof(ManifestHandler), "SiteType", typeof(ColumnAttribute), "SITE_TYPE")]
    //[AppliedAttribute(typeof(ManifestHandler), "EpaSiteId", typeof(ColumnAttribute), "EPA_SITE_ID")]
    //[AppliedAttribute(typeof(ManifestHandler), "EmanifestName", typeof(ColumnAttribute), "MANIFEST_NAME")]
    //[AppliedPathAttribute("EmanifestMailingAddress.StreetNumber", typeof(ColumnAttribute), "MAIL_STREET_NUM")]
    //[AppliedPathAttribute("EmanifestMailingAddress.Address1", typeof(ColumnAttribute), "MAIL_STREET1")]
    //[AppliedPathAttribute("EmanifestMailingAddress.Address2", typeof(ColumnAttribute), "MAIL_STREET2")]
    //[AppliedPathAttribute("EmanifestMailingAddress.City", typeof(ColumnAttribute), "MAIL_CITY")]
    //[AppliedPathAttribute("EmanifestMailingAddress.Country.ManifestLocalityCode", typeof(ColumnAttribute), "MAIL_CNTRY_CODE")]
    //[AppliedPathAttribute("EmanifestMailingAddress.Country.ManifestLocalityName", typeof(ColumnAttribute), "MAIL_CNTRY_NAME")]
    //[AppliedPathAttribute("EmanifestMailingAddress.ManifestState.ManifestLocalityCode", typeof(ColumnAttribute), "MAIL_STATE_CODE")]
    //[AppliedPathAttribute("EmanifestMailingAddress.ManifestState.ManifestLocalityName", typeof(ColumnAttribute), "MAIL_STATE_NAME")]
    //[AppliedPathAttribute("EmanifestMailingAddress.Zip", typeof(ColumnAttribute), "MAIL_ZIP")]
    //[AppliedPathAttribute("SiteAddress.StreetNumber", typeof(ColumnAttribute), "SITE_STREET_NUM")]
    //[AppliedPathAttribute("SiteAddress.Address1", typeof(ColumnAttribute), "SITE_STREET1")]
    //[AppliedPathAttribute("SiteAddress.Address2", typeof(ColumnAttribute), "SITE_STREET2")]
    //[AppliedPathAttribute("SiteAddress.City", typeof(ColumnAttribute), "SITE_CITY")]
    //[AppliedPathAttribute("SiteAddress.Country.ManifestLocalityCode", typeof(ColumnAttribute), "SITE_CNTRY_CODE")]
    //[AppliedPathAttribute("SiteAddress.Country.ManifestLocalityName", typeof(ColumnAttribute), "SITE_CNTRY_NAME")]
    //[AppliedPathAttribute("SiteAddress.ManifestState.ManifestLocalityCode", typeof(ColumnAttribute), "SITE_STATE_CODE")]
    //[AppliedPathAttribute("SiteAddress.ManifestState.ManifestLocalityName", typeof(ColumnAttribute), "SITE_STATE_NAME")]
    //[AppliedPathAttribute("SiteAddress.Zip", typeof(ColumnAttribute), "SITE_ZIP")]
    //[AppliedPathAttribute("ManifestContact.ManifestFirstName", typeof(ColumnAttribute), "CONTACT_FIRST_NAME")]
    //[AppliedPathAttribute("ManifestContact.ManifestMiddleInitial", typeof(ColumnAttribute), "CONTACT_MIDDLE_INITIAL")]
    //[AppliedPathAttribute("ManifestContact.ManifestLastName", typeof(ColumnAttribute), "CONTACT_LAST_NAME")]
    //[AppliedPathAttribute("ManifestContact.Phone.PhoneNumber", typeof(ColumnAttribute), "CONTACT_PHONE_NUM")]
    //[AppliedPathAttribute("ManifestContact.Phone.PhoneExtension", typeof(ColumnAttribute), "CONTACT_PHONE_EXT")]
    //[AppliedPathAttribute("ManifestContact.Email", typeof(ColumnAttribute), "CONTACT_EMAIL")]
    //[AppliedPathAttribute("ManifestContact.CompanyName", typeof(ColumnAttribute), "CONTACT_COMPANY_NAME")]
    //[AppliedPathAttribute("EmergencyPhone.PhoneNumber", typeof(ColumnAttribute), "EMERG_PHONE_NUM")]
    //[AppliedPathAttribute("EmergencyPhone.PhoneExtension", typeof(ColumnAttribute), "EMERG_PHONE_EXT")]
    //[AppliedPathAttribute("PaperSignatureInfo.PrintedName", typeof(ColumnAttribute), "PS_NAME")]
    //[AppliedPathAttribute("PaperSignatureInfo.PaperSignatureDate", typeof(ColumnAttribute), "PS_DATE")]
    //[AppliedPathAttribute("ElectronicSignatureInfo.Signer.ManifestFirstName", typeof(ColumnAttribute), "ES_SIGNER_FIRST_NAME")]
    //[AppliedPathAttribute("ElectronicSignatureInfo.Signer.ManifestLastName", typeof(ColumnAttribute), "ES_SIGNER_LAST_NAME")]
    //[AppliedPathAttribute("ElectronicSignatureInfo.Signer.SignerUserId", typeof(ColumnAttribute), "ES_SIGNER_USER_ID")]
    //[AppliedPathAttribute("ElectronicSignatureInfo.ElectronicSignatureDate", typeof(ColumnAttribute), "ES_SIGN_DATE")]
    //[AppliedPathAttribute("ElectronicSignatureInfo.HumanReadableDocument.DocumentName", typeof(ColumnAttribute), "ES_DOC_NAME")]
    //[AppliedPathAttribute("ElectronicSignatureInfo.HumanReadableDocument.Size", typeof(ColumnAttribute), "ES_DOC_SIZE")]
    //[AppliedPathAttribute("ElectronicSignatureInfo.HumanReadableDocument.MimeType", typeof(ColumnAttribute), "ES_DOC_MIME_TYPE")]
    //[AppliedPathAttribute("ElectronicSignatureInfo.CromerrActivityId", typeof(ColumnAttribute), "ES_CROMERR_ACT_ID")]
    //[AppliedPathAttribute("ElectronicSignatureInfo.CromerrDocumentId", typeof(ColumnAttribute), "ES_CROMERR_DOC_ID")]
    //[AppliedAttribute(typeof(ManifestHandler), "Order", typeof(ColumnAttribute), "ORDER_NUM")]
    //[AppliedAttribute(typeof(ManifestHandler), "Registered", typeof(ColumnAttribute), "REG_IND")]
    //[AppliedAttribute(typeof(ManifestHandler), "Modified", typeof(ColumnAttribute), "MOD_IND")]
    //[AppliedAttribute(typeof(ManifestHandler), "ManifestHandlerType", typeof(ColumnAttribute), "MANIFEST_HANDLER_TYPE", DbType.AnsiString, 40)]


    //[AppliedAttribute(typeof(Waste), "HazardousWaste", typeof(DbIgnoreAttribute))]
    //[AppliedAttribute(typeof(Waste), "DotHazardous", typeof(ColumnAttribute), "DOT_HAZ_IND")]
    //[AppliedPathAttribute("DotInformation.IdNumber", typeof(ColumnAttribute), "DOT_ID_NUM")]
    //[AppliedPathAttribute("DotInformation.PrintedDotInformation", typeof(ColumnAttribute), "DOT_PRINTED_INFO")]
    //[AppliedAttribute(typeof(Waste), "WastesDescription", typeof(ColumnAttribute), "WASTES_DESC")]
    //[AppliedPathAttribute("Quantity.ContainerNumber", typeof(ColumnAttribute), "QNT_CONT_NUM")]
    //[AppliedPathAttribute("Quantity.QuantityVal", typeof(ColumnAttribute), "QNT_VAL")]
    //[AppliedPathAttribute("Quantity.ContainerType.Code", typeof(ColumnAttribute), "QNT_CONT_TYPE_CODE")]
    //[AppliedPathAttribute("Quantity.ContainerType.ManifestDescription", typeof(ColumnAttribute), "QNT_CONT_TYPE_DESC")]
    //[AppliedPathAttribute("Quantity.QuantityUnitOfMeasurement.QuantityUOMCode", typeof(ColumnAttribute), "QNT_UOM_CODE")]
    //[AppliedPathAttribute("Quantity.QuantityUnitOfMeasurement.QuantityUOMDescription", typeof(ColumnAttribute), "QNT_UOM_DESC")]
    //[AppliedAttribute(typeof(Waste), "Br", typeof(ColumnAttribute), "BR_IND")]
    //[AppliedPathAttribute("BrInfo.Density", typeof(ColumnAttribute), "BR_DENSITY")]
    //[AppliedPathAttribute("BrInfo.DensityUnitOfMeasurement.UOMCode", typeof(ColumnAttribute), "BR_DENSITY_UOM_CODE")]
    //[AppliedPathAttribute("BrInfo.DensityUnitOfMeasurement.UOMDescription", typeof(ColumnAttribute), "BR_DENSITY_UOM_DESC")]
    //[AppliedPathAttribute("BrInfo.BrFormCode.FormCode", typeof(ColumnAttribute), "BR_FORM_CODE")]
    //[AppliedPathAttribute("BrInfo.BrFormCode.FormDescription", typeof(ColumnAttribute), "BR_FORM_DESC")]
    //[AppliedPathAttribute("BrInfo.BrSourceCode.SourceCode", typeof(ColumnAttribute), "BR_SRC_CODE")]
    //[AppliedPathAttribute("BrInfo.BrSourceCode.SourceDescription", typeof(ColumnAttribute), "BR_SRC_DESC")]
    //[AppliedPathAttribute("BrInfo.WasteMinimizationCode.WMCode", typeof(ColumnAttribute), "BR_WM_CODE")]
    //[AppliedPathAttribute("BrInfo.WasteMinimizationCode.WMDescription", typeof(ColumnAttribute), "BR_WM_DESC")]
    //[AppliedAttribute(typeof(Waste), "Pcb", typeof(ColumnAttribute), "PCB_IND")]
    //[AppliedPathAttribute("DiscrepancyResidueInfo.WasteQuantity", typeof(ColumnAttribute), "DISC_WASTE_QTY_IND")]
    //[AppliedPathAttribute("DiscrepancyResidueInfo.HasWasteType", typeof(ColumnAttribute), "DISC_WASTE_TYPE_IND")]
    //[AppliedPathAttribute("DiscrepancyResidueInfo.DiscrepancyComments", typeof(ColumnAttribute), "DISC_COMMENTS")]
    //[AppliedPathAttribute("DiscrepancyResidueInfo.Residue", typeof(ColumnAttribute), "DISC_RESIDUE_IND")]
    //[AppliedPathAttribute("DiscrepancyResidueInfo.ResidueComments", typeof(ColumnAttribute), "DISC_RESIDUE_COMMENTS")]
    //[AppliedPathAttribute("ManagementMethod.ManagementMethodCode", typeof(ColumnAttribute), "MGMT_METHOD_CODE")]
    //[AppliedPathAttribute("ManagementMethod.ManagementMethodDescription", typeof(ColumnAttribute), "MGMT_METHOD_DESC")]
    //[AppliedPathAttribute("WasteAdditionalInfo.NewManifestDestination", typeof(ColumnAttribute), "ADD_INFO_NEW_MAN_DEST")]
    //[AppliedPathAttribute("WasteAdditionalInfo.ConsentNumber", typeof(ColumnAttribute), "ADD_INFO_CONSENT_NUM")]
    //[AppliedPathAttribute("WasteAdditionalInfo.HandlingInstructions", typeof(ColumnAttribute), "ADD_INFO_HAND_INSTR")]
    //[AppliedAttribute(typeof(Waste), "LineNumber", typeof(ColumnAttribute), "LINE_NUM")]
    //[AppliedAttribute(typeof(Waste), "EpaWaste", typeof(ColumnAttribute), "EPA_WASTE_IND")]


    [AppliedAttribute(typeof(PcbInfo), "LoadTypeCode", typeof(ColumnAttribute), "PCB_LOAD_TYPE_CODE")]
    [AppliedAttribute(typeof(PcbInfo), "ArticleContainerId", typeof(ColumnAttribute), "PCB_ARTICLE_CONT_ID")]
    [AppliedAttribute(typeof(PcbInfo), "DateOfRemoval", typeof(ColumnAttribute), "PCB_REMOVAL_DATE")]
    [AppliedAttribute(typeof(PcbInfo), "Weight", typeof(ColumnAttribute), "PCB_WEIGHT")]
    [AppliedAttribute(typeof(PcbInfo), "WasteType", typeof(ColumnAttribute), "PCB_WASTE_TYPE")]
    [AppliedAttribute(typeof(PcbInfo), "BulkIdentity", typeof(ColumnAttribute), "PCB_BULK_IDENTITY")]

    [AppliedAttribute(typeof(ManifestWaste), "HazardousWaste", typeof(DbIgnoreAttribute))]


    //[AppliedAttribute(typeof(AdditionalInfo), "OriginalManifestTrackingNumber", typeof(DbIgnoreAttribute))]


    //[AppliedAttribute(typeof(RejectionInfo), "AlternateDesignatedFacility", typeof(DbIgnoreAttribute))]
    //[AppliedAttribute(typeof(RejectionInfo), "NewManifestTrackingNumber", typeof(DbIgnoreAttribute))]


    //[AppliedAttribute(typeof(AdditionalComment), "CommentDescription", typeof(ColumnAttribute), "COMMENT_DESC")]
    //[AppliedAttribute(typeof(AdditionalComment), "HandlerId", typeof(ColumnAttribute), "HANDLER_ID")]
    //[AppliedAttribute(typeof(AdditionalComment), "CommentLabel", typeof(ColumnAttribute), "COMMENT_LABEL")]


    //[AppliedAttribute(typeof(ManifestTrackingNumber), "TrackingNumber", typeof(ColumnAttribute), "MANIFEST_TRACKING_NUM")]


    [AppliedAttribute(typeof(TxWasteCode), "WasteCode", typeof(ColumnAttribute), "WASTE_CODE")]


    //[AppliedAttribute(typeof(FederalWasteCode), "ManifestWasteCode", typeof(ColumnAttribute), "WASTE_CODE")]
    //[AppliedAttribute(typeof(FederalWasteCode), "ManifestWasteDescription", typeof(ColumnAttribute), "WASTE_DESC")]


    //[AppliedAttribute(typeof(HazardousWaste), "FederalWasteCode", typeof(DbIgnoreAttribute))]
    //[AppliedAttribute(typeof(HazardousWaste), "TsdfStateWasteCode", typeof(DbIgnoreAttribute))]
    //[AppliedAttribute(typeof(HazardousWaste), "TxWasteCode", typeof(DbIgnoreAttribute))]
    //[AppliedAttribute(typeof(HazardousWaste), "GeneratorStateWasteCode", typeof(DbIgnoreAttribute))]


    [AppliedAttribute(typeof(HazardousWasteEmanifestsDataType), "Emanifests", typeof(DbIgnoreAttribute))]


    [Table("RCRA_EM_SUBM")]
    public partial class HazardousWasteEmanifestsDataType : BaseDataType, IBeforeSaveToDatabase, IAfterLoadFromDatabase
    {
        [XmlIgnore]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public Emanifests[] EmanifestsList;

        public virtual void BeforeSaveToDatabase()
        {
            if (!CollectionUtils.IsNullOrEmpty(Emanifests))
            {
                List<Emanifests> list = null;
                CollectionUtils.ForEach(Emanifests, delegate (EmanifestsDataType e)
                {
                    if (!CollectionUtils.IsNullOrEmpty(e.Emanifest))
                    {
                        CollectionUtils.AddRange(e.Emanifest, ref list);
                    }
                });
                if (list != null)
                {
                    EmanifestsList = list.ToArray();
                    CollectionUtils.ForEach(list, delegate (Emanifests e)
                    {
                        e.BeforeSaveToDatabase();
                    });
                }
            }
        }

        public virtual void AfterLoadFromDatabase()
        {
            if (!CollectionUtils.IsNullOrEmpty(EmanifestsList))
            {
                CollectionUtils.ForEach(EmanifestsList, delegate (Emanifests e)
                {
                    e.AfterLoadFromDatabase();
                });
                Emanifests = new EmanifestsDataType[]
                {
                    new EmanifestsDataType()
                    {
                        Emanifest = EmanifestsList.ToArray()
                    }
                };
            }
        }
    }

    [Table("RCRA_EM_EMANIFEST")]
    public partial class Emanifests : BaseChildDataType, IBeforeSaveToDatabase, IAfterLoadFromDatabase
    {
        public virtual void BeforeSaveToDatabase()
        {
            CollectionUtils.ForEach(Transporter, delegate (ManifestTransporter e)
            {
                e.BeforeSaveToDatabase();
            });
            CollectionUtils.ForEach(ManifestWaste, delegate (ManifestWaste e)
            {
                e.BeforeSaveToDatabase();
            });
        }

        public virtual void AfterLoadFromDatabase()
        {
            CollectionUtils.ForEach(Transporter, delegate (ManifestTransporter e)
            {
                e.AfterLoadFromDatabase();
            });
            CollectionUtils.ForEach(ManifestWaste, delegate (ManifestWaste e)
            {
                e.AfterLoadFromDatabase();
            });
        }
    }

    [Table("RCRA_EM_TRANSPORTER")]
    public partial class ManifestTransporter : BaseChildDataType, IBeforeSaveToDatabase, IAfterLoadFromDatabase
    {
        public virtual void BeforeSaveToDatabase()
        {
        }

        public virtual void AfterLoadFromDatabase()
        {
        }
    }

    [Table("RCRA_EM_WASTE")]
    public partial class ManifestWaste : BaseChildDataType, IBeforeSaveToDatabase, IAfterLoadFromDatabase
    {
        [XmlIgnore]
        public FedManifestWasteCodeDescription[] FederalWasteCodeList;

        [XmlIgnore]
        public StateManifestWasteCodeDescription[] StateWasteCodeList;

        [XmlIgnore]
        public TxWasteCode[] TxWasteCodeList;

        public virtual void BeforeSaveToDatabase()
        {
            if ((HazardousWaste != null) && !CollectionUtils.IsNullOrEmpty(HazardousWaste.FederalWasteCode))
            {
                FederalWasteCodeList = HazardousWaste.FederalWasteCode.ToArray();
            }
            if ((HazardousWaste != null) && !CollectionUtils.IsNullOrEmpty(HazardousWaste.StateWasteCode))
            {
                StateWasteCodeList = HazardousWaste.StateWasteCode.ToArray();
            }
            if ((HazardousWaste != null) && !CollectionUtils.IsNullOrEmpty(HazardousWaste.TxWasteCode))
            {
                TxWasteCodeList = HazardousWaste.TxWasteCode.Select(e => new TxWasteCode()
                {
                    WasteCode = e
                }).ToArray();
            }
        }

        public virtual void AfterLoadFromDatabase()
        {
            if (!CollectionUtils.IsNullOrEmpty(FederalWasteCodeList))
            {
                if (HazardousWaste == null)
                {
                    HazardousWaste = new HazardousWaste();
                }
                HazardousWaste.FederalWasteCode = FederalWasteCodeList.ToArray();
            }
            if (!CollectionUtils.IsNullOrEmpty(StateWasteCodeList))
            {
                if (HazardousWaste == null)
                {
                    HazardousWaste = new HazardousWaste();
                }
                HazardousWaste.StateWasteCode = StateWasteCodeList.ToArray();
            }
            if (!CollectionUtils.IsNullOrEmpty(TxWasteCodeList))
            {
                if (HazardousWaste == null)
                {
                    HazardousWaste = new HazardousWaste();
                }
                HazardousWaste.TxWasteCode = TxWasteCodeList.Select(e => e.WasteCode).ToArray();
            }
        }
    }

    [Table("RCRA_EM_WASTE_PCB")]
    public partial class PcbInfo : BaseChildDataType
    {
    }

    [Table("RCRA_EM_FED_WASTE_CODE_DESC")]
    public partial class FedManifestWasteCodeDescription : BaseChildDataType
    {
    }

    [Table("RCRA_EM_STATE_WASTE_CODE_DESC")]
    public partial class StateManifestWasteCodeDescription : BaseChildDataType
    {
    }

    public partial class AdditionalComment : BaseChildDataType
    {
    }

    [Table("RCRA_EM_EMANIFEST_COMMENT")]
    public partial class EmanifestsAdditionalComment : AdditionalComment
    {
    }

    [Table("RCRA_EM_WASTE_COMMENT")]
    public partial class WasteAdditionalComment : AdditionalComment
    {
    }

    [Table("RCRA_EM_WASTE_CD_TRANS")]
    public partial class TxWasteCode : BaseChildDataType
    {
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(12)]
        public string WasteCode;
    }

    [DefaultTableNamePrefixAttribute("RCRA")]
    [UseTableNameForDefaultPrimaryKeysAttribute()]
    [DefaultFixedStringDbMaxLengthAttribute(2)]

    [AppliedAttribute(typeof(SubmissionHistoryDataType), "ScheduleRunDate", typeof(ColumnAttribute), "SCHEDULERUNDATE", DbType.Date)]
    [AppliedAttribute(typeof(SubmissionHistoryDataType), "TransactionId", typeof(ColumnAttribute), "TRANSACTIONID", 50)]
    [AppliedAttribute(typeof(SubmissionHistoryDataType), "ProcessingStatus", typeof(ColumnAttribute), "PROCESSINGSTATUS", 50)]
    [AppliedAttribute(typeof(SubmissionHistoryDataType), "SubmissionType", typeof(ColumnAttribute), "SUBMISSIONTYPE", 50)]

    [Table("RCRA_SUBMISSIONHISTORY")]
    public partial class SubmissionHistoryDataType : BaseDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [DbNotNull]
        public string SubmissionType;

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