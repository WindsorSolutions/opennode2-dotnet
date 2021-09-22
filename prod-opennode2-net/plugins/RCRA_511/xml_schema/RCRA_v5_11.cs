namespace Windsor.Node2008.WNOSPlugin.RCRA_511
{


    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("CSNYDate", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class CSNYDateDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Date of the SNY that the Action is Addressing")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public System.DateTime SNYDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("Payment", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class PaymentDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 1)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string PaymentSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 2)]
        public System.DateTime PaymentDefaultedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PaymentDefaultedDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 3)]
        public System.DateTime ScheduledPaymentDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ScheduledPaymentDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public decimal ScheduledPaymentAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ScheduledPaymentAmountSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 5)]
        public System.DateTime ActualPaymentDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ActualPaymentDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("The dollar amount of any cost recovery required to be paid pursuant to a Final Or" +
            "der.")]
        public decimal ActualPaidAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ActualPaidAmountSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4000)]
        public string Notes;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("Penalty", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class PenaltyDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the penalty type")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(2)]
        public string PenaltyTypeOwner;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Code which indicates the type of penalty associated with the penalty amount.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(3)]
        public string PenaltyType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the type of penalty associated with the penalty amoun" +
            "t(Data publishing only).")]
        public string PenaltyTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The dollar amount of any proposed cash civil penalty set forth in a Complaint/Pro" +
            "posed Order.")]
        public decimal CashCivilPenaltySoughtAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CashCivilPenaltySoughtAmountSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4000)]
        public string Notes;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Payment", Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Compliance Monitoring and Enforcement Payment Data")]
        public PaymentDataType[] Payment;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("Milestone", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class MilestoneDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 1)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string MilestoneSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(50)]
        public string TechnicalRequirementIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(200)]
        public string TechnicalRequirementDescription;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 4)]
        public System.DateTime MilestoneScheduledCompletionDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MilestoneScheduledCompletionDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 5)]
        public System.DateTime MilestoneActualCompletionDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MilestoneActualCompletionDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 6)]
        public System.DateTime MilestoneDefaultedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MilestoneDefaultedDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4000)]
        public string Notes;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("ViolationEnforcement", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class ViolationEnforcementDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 1)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string ViolationSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string AgencyWhichDeterminedViolation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the agency responsible for the action(Data publishing" +
            " only).")]
        public string AgencyText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The calendar date, specified in the Compliance Schedule (if any), on which the re" +
            "gulated entity is scheduled to return to compliance with respect to the legal ob" +
            "ligation that is the subject of the Violation Determined Date.")]
        public System.DateTime ReturnComplianceScheduledDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ReturnComplianceScheduledDateSpecified;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("SupplementalEnvironmentalProject", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class SupplementalEnvironmentalProjectDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("SEP Sequence Number allowed value 01-99")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string SEPSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Expenditure Amount")]
        public decimal SEPExpenditureAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SEPExpenditureAmountSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Valid date greater than or equal to the Date of Enforcement Action.")]
        public System.DateTime SEPScheduledCompletionDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SEPScheduledCompletionDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("SEP actual completion date")]
        public System.DateTime SEPActualDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SEPActualDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Date the SEP defaulted")]
        public System.DateTime SEPDefaultedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SEPDefaultedDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("State postal code")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(2)]
        public string SEPCodeOwner;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("The narrative text describing any Supplemental Environmental Projects required to" +
            " be performed pursuant to a Final Order.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(3)]
        public string SEPDescriptionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the Supplemental Environmental Project required to be" +
            " performed pursuant to the final order(Data publishing only).")]
        public string SEPLongDescriptionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4000)]
        public string Notes;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("Media", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class MediaDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the multimedia code.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(2)]
        public string MultimediaCodeOwner;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Code which indicates the medium or program other than RCRA participating in the e" +
            "nforcement action.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(3)]
        public string MultimediaCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4000)]
        public string Notes;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("EnforcementAction", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class EnforcementActionDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The U.S.Postal Service alphabetic code that represents the U.S.State or territory" +
            " in which a state or local government enforcement agency operates.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(2)]
        public string EnforcementAgencyLocationName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The unique alphanumeric identifier used in the applicable database to identify a " +
            "specific enforcement action pertaining to a regulated entity or facility.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(3)]
        public string EnforcementActionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The calendar date the enforcement action was issued or filed.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public System.DateTime EnforcementActionDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The full name of the agency, department, or organization that submitted the enfor" +
            "cement action data to EPA.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string EnforcementAgencyName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the agency responsible for the action(Data publishing" +
            " only).")]
        public string AgencyText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Notes the relevant docket number which enforcement staff have assigned for tracki" +
            "ng of enforcement actions.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(15)]
        public string EnforcementDocketNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Identifies the attorney within the agency responsible for issuing the enforcement" +
            " action.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(5)]
        public string EnforcementAttorney;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string CorrectiveActionComponent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 9)]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string ConsentAgreementFinalOrderSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("Name of the CAFO Respondent(Data publishing only).")]
        public string RespondentName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 11)]
        public System.DateTime AppealInitiatedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AppealInitiatedDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 12)]
        public System.DateTime AppealResolutionDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AppealResolutionDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 13)]
        public System.DateTime DispositionStatusDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DispositionStatusDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(2)]
        public string DispositionStatusOwner;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(2)]
        public string DispositionStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing how the enforcement action was closed, terminated, or" +
            " discontinued(Data publishing only).")]
        public string DispositionStatusText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [System.ComponentModel.DescriptionAttribute("State Postal Code")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(2)]
        public string EnforcementOwner;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [System.ComponentModel.DescriptionAttribute("A code that identifies the type of action being taken against a handler.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(3)]
        public string EnforcementType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the Enforcement Type(Data publishing only).")]
        public string EnforcementTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the person identifier.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(2)]
        public string EnforcementResponsiblePersonOwner;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        [System.ComponentModel.DescriptionAttribute("Code indicating the person within the agency responsible for conducting the enfor" +
            "cement.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(5)]
        public string EnforcementResponsiblePersonIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(2)]
        public string EnforcementResponsibleSuborganizationOwner;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 23)]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(10)]
        public string EnforcementResponsibleSuborganization;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 24)]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4000)]
        public string Notes;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 25)]
        [System.ComponentModel.DescriptionAttribute("Financial assurance req d.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string FinancialAssuranceReqD;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CSNYDate", Order = 26)]
        [System.ComponentModel.DescriptionAttribute("Compliance Monitoring and Enforcement Significant Non-Complier Date Data")]
        public CSNYDateDataType[] CSNYDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Penalty", Order = 27)]
        [System.ComponentModel.DescriptionAttribute("Compliance Monitoring and Enforcement Penalty Data")]
        public PenaltyDataType[] Penalty;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Milestone", Order = 28)]
        [System.ComponentModel.DescriptionAttribute("Compliance Monitoring and Enforcement Milestone Data")]
        public MilestoneDataType[] Milestone;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ViolationEnforcement", Order = 29)]
        [System.ComponentModel.DescriptionAttribute("Linking Data for Violation and Enforcement")]
        public ViolationEnforcementDataType[] ViolationEnforcement;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SupplementalEnvironmentalProject", Order = 30)]
        [System.ComponentModel.DescriptionAttribute("Compliance Monitoring and Enforcement Supplemental Environmental Project Data")]
        public SupplementalEnvironmentalProjectDataType[] SupplementalEnvironmentalProject;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Media", Order = 31)]
        [System.ComponentModel.DescriptionAttribute("Compliance Monitoring and Enfocement Multimedia Data")]
        public MediaDataType[] Media;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 32)]
        [System.ComponentModel.DescriptionAttribute("User id of record creation")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(255)]
        public string CreatedByUserid;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 33)]
        [System.ComponentModel.DescriptionAttribute("Creation date")]
        public System.DateTime CCreatedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CCreatedDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 34)]
        [System.ComponentModel.DescriptionAttribute("Indicates data origination information.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(2)]
        public string DataOrig;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("Citation", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class CitationDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 1)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string CitationNameSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The citation(s) of the violations alleged (CME) or of the Authority used (CA).")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(80)]
        public string CitationName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("State postal code")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(2)]
        public string CitationNameOwner;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Existing nationally defined values: FR, FS, OC, PC,SR,SS,V3")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(2)]
        public string CitationNameType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the citation reference(Data publishing only).")]
        public string CitationDescription;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4000)]
        public string Notes;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("Violation", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class ViolationDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(2)]
        public string ViolationActivityLocation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 2)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string ViolationSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string AgencyWhichDeterminedViolation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the agency responsible for the action(Data publishing" +
            " only).")]
        public string AgencyText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Allowed value HQ")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(2)]
        public string ViolationTypeOwner;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Violation Type")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(10)]
        public string ViolationType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the specific area of the Federal Code of Regulations " +
            "covered by the evaluation that was found to be in violation with RCRA regulation" +
            "s or statutes(Data publishing only).")]
        public string ViolationTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(35)]
        public string FormerCitationName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 9)]
        [System.ComponentModel.DescriptionAttribute("The calendar date the Responsible Authority determines that a regulated entity is" +
            " in violation of a legally enforceable obligation.")]
        public System.DateTime ViolationDeterminedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ViolationDeterminedDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 10)]
        [System.ComponentModel.DescriptionAttribute("The calendar date, determined by the Responsible Authority, on which the regulate" +
            "d entity actually returned to compliance with respect to the legal obligation th" +
            "at is the subject of the Violation Determined Date.")]
        public System.DateTime ReturnComplianceActualDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ReturnComplianceActualDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string ReturnToComplianceQualifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the conditions under which the actual compliance occu" +
            "red(Data publishing only).")]
        public string ReturnToComplianceQualifierText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string ViolationResponsibleAgency;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the agency responsible for the violation(Data publish" +
            "ing only).")]
        public string ViolationResponsibleAgencyText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4000)]
        public string Notes;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Citation", Order = 16)]
        [System.ComponentModel.DescriptionAttribute("Compliance Monitoring and Enforcement Citation Data")]
        public CitationDataType[] Citation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [System.ComponentModel.DescriptionAttribute("User id of record creation")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(255)]
        public string CreatedByUserid;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 18)]
        [System.ComponentModel.DescriptionAttribute("Creation date")]
        public System.DateTime CCreatedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CCreatedDateSpecified;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("Request", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class RequestDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 1)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string RequestSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 2)]
        public System.DateTime DateOfRequest;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DateOfRequestSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 3)]
        public System.DateTime DateResponseReceived;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DateResponseReceivedSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string RequestAgency;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the agency responsible for the action(Data publishing" +
            " only).")]
        public string AgencyText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4000)]
        public string Notes;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("EvaluationCommitment", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class EvaluationCommitmentDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(2)]
        public string CommitmentLead;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 2)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string CommitmentSequenceNumber;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("EvaluationViolation", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class EvaluationViolationDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(2)]
        public string ViolationActivityLocation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 2)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string ViolationSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string AgencyWhichDeterminedViolation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the agency responsible for the action(Data publishing" +
            " only).")]
        public string AgencyText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("Evaluation", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class EvaluationDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Indicates the location of the agency regulating the EPA handler.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(2)]
        public string EvaluationActivityLocation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Name or number assigned by the implementing agency to identify an evaluation.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(3)]
        public string EvaluationIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The first day of the inspection or record review regardless of the duration of th" +
            "e inspection.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public System.DateTime EvaluationStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Code indicating the agency responsible for conducting the evaluation.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string EvaluationResponsibleAgency;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the agency responsible for the action(Data publishing" +
            " only).")]
        public string AgencyText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Date fo the Last Non-Followup Evaluation (Applies to SNY/SNN Evaluations Only)")]
        public System.DateTime DayZero;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DayZeroSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Flag indicating if a violation was found.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string FoundViolation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("The inspection or record review was initiated because of a tip/complaint")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string CitizenComplaintIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string MultimediaIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string SamplingIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("The inspection conducted pursuant to RCRA 3007 or State equivalent; determiniatio" +
            "n made: sit is Non-Hazardous Waste.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string NotSubtitleCIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the type of evaluation.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(2)]
        public string EvaluationTypeOwner;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [System.ComponentModel.DescriptionAttribute("Code to report the type of evaluation conducted at the handler.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(3)]
        public string EvaluationType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the type of evaluation performed at the Handler(Data " +
            "publishing only).")]
        public string EvaluationTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(2)]
        public string FocusAreaOwner;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(3)]
        public string FocusArea;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing subject of the Focused Compliance Inspection(Data pub" +
            "lishing only).")]
        public string FocusAreaText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the person identifier.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(2)]
        public string EvaluationResponsiblePersonIdentifierOwner;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        [System.ComponentModel.DescriptionAttribute("Code indicating the person within the agency responsible for conducting the evalu" +
            "ation.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(5)]
        public string EvaluationResponsiblePersonIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the suborganization identifier.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(2)]
        public string EvaluationResponsibleSuborganizationOwner;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        [System.ComponentModel.DescriptionAttribute("Code indicating the branch/district within the agency responsible for conducting " +
            "the evaluation.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(10)]
        public string EvaluationResponsibleSuborganization;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4000)]
        public string Notes;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 23)]
        [System.ComponentModel.DescriptionAttribute("NOC Date.")]
        public System.DateTime NOCDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NOCDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Request", Order = 24)]
        [System.ComponentModel.DescriptionAttribute("Compliance Monitoring and Enforcement Request Data")]
        public RequestDataType[] Request;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EvaluationCommitment", Order = 25)]
        [System.ComponentModel.DescriptionAttribute("Linking Data for Commitment/Initiative and Evaluation.")]
        public EvaluationCommitmentDataType[] EvaluationCommitment;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EvaluationViolation", Order = 26)]
        [System.ComponentModel.DescriptionAttribute("Linking Data for Evaluation and Violation")]
        public EvaluationViolationDataType[] EvaluationViolation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 27)]
        [System.ComponentModel.DescriptionAttribute("User id of record creation")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(255)]
        public string CreatedByUserid;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 28)]
        [System.ComponentModel.DescriptionAttribute("Creation date")]
        public System.DateTime CCreatedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CCreatedDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 29)]
        [System.ComponentModel.DescriptionAttribute("Indicates data origination information.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(2)]
        public string DataOrig;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("HazardousWasteCMESubmission", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class HazardousWasteCMESubmissionDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CMEFacilitySubmission", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("This contains Hbasic Data")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public CMEFacilitySubmissionDataType[] CMEFacilitySubmission;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("CMEFacilitySubmission", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class CMEFacilitySubmissionDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Number that uniquely identifies the EPA handler.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(12)]
        public string EPAHandlerID;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EnforcementAction", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Compliance Monitoring and Enforcement Data")]
        public EnforcementActionDataType[] EnforcementAction;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Evaluation", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Compliance Monitoring and Enforcement Evaluation Data")]
        public EvaluationDataType[] Evaluation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Violation", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Compliance Monitoring and Enforcement Violation Data")]
        public ViolationDataType[] Violation;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("OtherID", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class OtherIDDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Alternate facility identifier.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(12)]
        public string OtherHandlerID;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that owns the Relationship.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(2)]
        public string RelationshipOwnerName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Indicates the type of the relationship.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string RelationshipTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the relationship between another ID and the current I" +
            "D (Data publishing only).")]
        public string RelationshipTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Indicates whether the alternate Id references the same facility.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string SameFacilityIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Notes regarding the alternative facility identifier.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4000)]
        public string OtherIDSupplementalInformationText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("LocationAddress", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class LocationAddressDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(12)]
        public string LocationAddressNumberText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(50)]
        public string LocationAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(50)]
        public string SupplementalLocationText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(25)]
        public string LocalityName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(2)]
        public string StateUSPSCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(2)]
        public string CountryName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(14)]
        public string LocationZIPCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("EnvironmentalPermit", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class EnvironmentalPermitDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Identification number of an effective environmental permit issued to the handler," +
            " or the number of a filed application for which an environmental permit has not " +
            "yet been issued.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(13)]
        public string EnvironmentalPermitID;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the other permit type.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(2)]
        public string EnvironmentalPermitOwnerName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute(@"Code indicating the environmental program and/or jurisdictional authority under which an environmental permit was issued to the facility, or under which an application has been filed for which a permit has not yet been issued. This data element is applicable to TSD facilities only.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string EnvironmentalPermitTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the Environmental Permit Type (Data publishing only)." +
            "")]
        public string EnvironmentalPermitTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Description of any permit type indicated as O (Other) in the Permit Type field.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(80)]
        public string EnvironmentalPermitDescription;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("Certification", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class CertificationDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Sequence number for each certification for the handler.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string CertificationSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Date on which the handler information was certified by the reporting site.")]
        public System.DateTime SignedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SignedDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Title of the contact person or the title of the person who certified the handler " +
            "information reported to the authorizing agency.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(45)]
        public string IndividualTitleText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("First name of a person.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(38)]
        public string FirstName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Middle initial of a person.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string MiddleInitial;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Last name of a person.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(38)]
        public string LastName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Email address data")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(80)]
        public string CertificationEmailText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("NAICSIdentity", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class NAICSIdentityDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Sequence number for each NAICS code for the handler.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4)]
        public string NAICSSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the NAICS Code.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(2)]
        public string NAICSOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The North American Industry Classification System Code that identifies the busine" +
            "ss activities of the facility.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(6)]
        public string NAICSCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text NAICS Code(Data publishing only).")]
        public string NAICSText;
    }

    ///// <remarks/>
    //[System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    //[System.Xml.Serialization.XmlRootAttribute("Contact", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    //public partial class ContactDataType
    //{

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("FirstName", typeof(string), Order = 0)]
    //    [System.Xml.Serialization.XmlElementAttribute("LastName", typeof(string), Order = 0)]
    //    [System.Xml.Serialization.XmlElementAttribute("MiddleInitial", typeof(string), Order = 0)]
    //    [System.Xml.Serialization.XmlElementAttribute("OrganizationFormalName", typeof(string), Order = 0)]
    //    [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
    //    public string[] Items;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("ItemsElementName", Order = 1)]
    //    [System.Xml.Serialization.XmlIgnoreAttribute()]
    //    public ItemsElementName[] ItemsElementName;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
    //    [System.ComponentModel.DescriptionAttribute("Title of the contact person or the title of the person who certified the handler " +
    //        "information reported to the authorizing agency.")]
    //    [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(45)]
    //    public string IndividualTitleText;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
    //    [System.ComponentModel.DescriptionAttribute("Email address data")]
    //    [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(80)]
    //    public string EmailAddressText;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
    //    [System.ComponentModel.DescriptionAttribute("Telephone Number data")]
    //    [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(15)]
    //    public string TelephoneNumberText;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
    //    [System.ComponentModel.DescriptionAttribute("Telephone number extension")]
    //    [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(6)]
    //    public string PhoneExtensionText;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
    //    [System.ComponentModel.DescriptionAttribute("Contact fax number")]
    //    [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(15)]
    //    public string FaxNumberText;
    //}

    ///// <remarks/>
    //[System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IncludeInSchema = false)]
    //public enum ItemsElementName
    //{

    //    /// <remarks/>
    //    [System.ComponentModel.DescriptionAttribute("First name of a person.")]
    //    [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(38)]
    //    FirstName,

    //    /// <remarks/>
    //    [System.ComponentModel.DescriptionAttribute("Last name of a person.")]
    //    [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(38)]
    //    LastName,

    //    /// <remarks/>
    //    [System.ComponentModel.DescriptionAttribute("Middle initial of a person.")]
    //    [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
    //    MiddleInitial,

    //    /// <remarks/>
    //    [System.ComponentModel.DescriptionAttribute("The legal, formal name of an organization that is affiliated with the facility si" +
    //        "te.")]
    //    [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(80)]
    //    OrganizationFormalName,
    //}

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("MailingAddress", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class MailingAddress
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(12)]
        public string MailingAddressNumberText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(50)]
        public string MailingAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(50)]
        public string SupplementalAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(25)]
        public string MailingAddressCityName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(2)]
        public string MailingAddressStateUSPSCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(2)]
        public string MailingAddressCountryName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(14)]
        public string MailingAddressZIPCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("ContactAddress", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class ContactAddress
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Contact information.")]
        public ContactDataType Contact;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Mailing address information.")]
        public MailingAddress MailingAddress;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("FacilityOwnerOperator", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class FacilityOwnerOperatorDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Sequential number used to order multiple occurrences of owners and operators.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string OwnerOperatorSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Code indicating whether the data is associated with a current or previous owner o" +
            "r operator. The system will allow multiple current owners and operators.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(2)]
        public string OwnerOperatorIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the owner/operator(Data publishing only).")]
        public string OwnerOperatorText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Code indicating the owner/operator type.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string OwnerOperatorTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the Owner Operator Type (Data publishing only).")]
        public string OwnerOperatorTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Date indicating when the owner/operator became current.")]
        public System.DateTime CurrentStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CurrentStartDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Date indicating when the owner/operator changed to a different owner/operator.")]
        public System.DateTime CurrentEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CurrentEndDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Notes for the facility Owner Operator.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4000)]
        public string OwnerOperatorSupplementalInformationText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("Contact address information for the facility owner/operator.")]
        public ContactAddress ContactAddress;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("WasteActivitySite", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class SiteWasteActivityDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Code indicating current ownership status of the land on which the facility is loc" +
            "ated.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string LandTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the land type that the Handler is located on(Data pub" +
            "lishing only).")]
        public string LandTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Owner of the state district code. Usually 2-digit postal code (i.e. KS).")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(2)]
        public string StateDistrictOwnerName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Code indicating the state-designated legislative district(s) in which the site is" +
            " located.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(10)]
        public string StateDistrictCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the code indicating the state-designated legislative " +
            "district(s) in which the site is located.")]
        public string StateDistrictCodeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler is engaged in importing hazardous waste into the" +
            " United States.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string ImporterActivityCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler is engaged in generating mixed waste (waste that" +
            " is both hazardous and radioactive).")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string MixedWasteGeneratorCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Code for recycling hazardous waste.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string RecyclerActivityCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler is engaged in the transportation of hazardous wa" +
            "ste.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string TransporterActivityCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler is engaged in the treatment, storage, or disposa" +
            "l of hazardous waste.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string TreatmentStorageDisposalActivityCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler generates and or treats, stores, or disposes of " +
            "hazardous waste and has an injection well located at the installation.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string UndergroundInjectionActivityCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler treats, disposes of, or recycles hazardous waste" +
            " on site.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string UniversalWasteDestinationFacilityIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler qualifies for the Small Quantity Onsite Burner E" +
            "xemption.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string OnsiteBurnerExemptionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler qualifies for the Smelting, Melting, and Refinin" +
            "g Furnace Exemption.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string FurnaceExemptionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler is engaged in short-term hazardous waste generat" +
            "ion activities.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string ShortTermGeneratorIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler is a Hazardous Waste Transfer Facility (not to b" +
            "e confused with a used oil transfer facility).")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string TransferFacilityIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [System.ComponentModel.DescriptionAttribute("Indicates that the Handler is participating in Import Trading activity. Possible " +
            "values are: Y/N")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string RecognizedTraderImporterIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [System.ComponentModel.DescriptionAttribute("Indicates that the Handler is participating in Export Trading activity. Possible " +
            "values are: Y/N")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string RecognizedTraderExporterIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [System.ComponentModel.DescriptionAttribute("Indicates that the Handler is participating in Slab Import activity. Possible val" +
            "ues are: Y/N")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string SlabImporterIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        [System.ComponentModel.DescriptionAttribute("Indicates that the Handler is participating in Slab Export activity. Possible val" +
            "ues are: Y/N")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string SlabExporterIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        [System.ComponentModel.DescriptionAttribute("Identifies that Handler participates in Nonstorage Recycler Activity.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string RecyclerActivityNonstorage;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        [System.ComponentModel.DescriptionAttribute("Identifies that Handler is ManifestBroker.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string ManifestBroker;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("StateActivity", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class StateActivityDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the state activity type.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(2)]
        public string StateActivityOwnerName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Code indicating the type of state activity.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(5)]
        public string StateActivityTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the State Activity Type (Data publishing only).")]
        public string StateActivityTypeText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("HandlerUniversalWaste", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class UniversalWasteActivityDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the universal waste type.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(2)]
        public string UniversalWasteOwnerName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Code indicating the type of universal waste.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string UniversalWasteTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the Universal Waste Type (Data publishing only).")]
        public string UniversalWasteTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler is engaged in accumulating waste on site.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string AccumulatedWasteCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler is engaged in generating waste on site.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string GeneratedHandlerCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("UsedOil", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class UsedOilDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler is engaged in the burning of used oil fuel.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string FuelBurnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler is engaged in processing used oil activities.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string ProcessorCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler is engaged in re-refining used oil activities.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string RefinerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler directs shipments of used oil to burners.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string MarketBurnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler is a marketer who first claims the used oil meet" +
            "s the specifications.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string SpecificationMarketerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler owns or operates a used oil transfer facility.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string TransferFacilityCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler is engaged in used oil transportation and/or tra" +
            "nsfer facility activities.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string TransporterCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("HandlerWasteCodeDetails", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class HandlerWasteCodeDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that owns the data record.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(2)]
        public string WasteCodeOwnerName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Code used to describe hazardous waste.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(6)]
        public string WasteCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the Waste Code(Data publishing only).")]
        public string WasteCodeText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("LaboratoryHazardousWaste", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class LaboratoryHazardousWaste
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Indicates whether or not the Handler is a College or University opting into SubPa" +
            "rt K.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string CollegeIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Indicates whether or not the Handler is a Hospital opting into SubPart K.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string HospitalIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Indicates whether or not the Handler is a Non-Profit opting into SubPart K.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string NonProfitIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Indicates whether or not the Handler is withdrawing from SubPart K.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string WithdrawalIndicator;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("HazardousSecondaryMaterialActivity", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class HazardousSecondaryMaterialActivityDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Unique number identifying the HSM Activity for the Handler")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4)]
        public string HSMSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Owner of the Facility Code. Shoule be HQ or the state code (i.e. KS)")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(2)]
        public string FacilityCodeOwnerName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Type of facility generating Hazardous Secondary Material")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(2)]
        public string FacilityTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the type of facility opting to participate under the " +
            "Definition of Solid Waste Rule(Data publishing only).")]
        public string FacilityTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The estimated amount of HSM generated by the Handler")]
        public decimal EstimatedShortTonsQuantity;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EstimatedShortTonsQuantitySpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("The actual amount of HSM generated by the Handler")]
        public decimal ActualShortTonsQuantity;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ActualShortTonsQuantitySpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Code to indicate if the HSM is being managed in a Land Based Unit")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(2)]
        public string LandBasedUnitIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the code to indicate if the HSM is being managed in a" +
            " Land Based Unit")]
        public string LandBasedUnitIndicatorText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("HandlerWasteCodeDetails", Order = 9)]
        [System.ComponentModel.DescriptionAttribute("Hazardous waste codes describing the handler\'s hazardous waste streams.")]
        public SecondaryHandlerWasteCodeDataType[] HandlerWasteCodeDetails;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("HazardousSecondaryMaterial", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class HazardousSecondaryMaterialDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Indicates the reason for notifying Hazardous Secondary Material")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string NotificationReasonCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the reason for notifying under DSW(Data publishing on" +
            "ly).")]
        public string NotificationReasonText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The Effective Date of the action: 1. Hazardous Secondary Material notification in" +
            " Handler, 2. Corrective Action Authority, 3. Financial Assurance Mechanism.")]
        public System.DateTime EffectiveDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EffectiveDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Indicates whether or not the facility has provided Financial Assurance for the HS" +
            "M Activities")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string FinancialAssuranceIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("HazardousSecondaryMaterialActivity", Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Hazardous Secondary Material activity of the Handler")]
        public HazardousSecondaryMaterialActivityDataType[] HazardousSecondaryMaterialActivity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Code for recycling hazardous waste.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string RecyclerIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Notes for recycling hazardous waste.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4000)]
        public string RecyclerNotes;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("HandlerLqgConsolidation", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class HandlerLqgConsolidation
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Unique number that identifies the Consolidation.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string ConsolidationSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Code that uniquely identifies the handler.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(12)]
        public string HandlerID;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Name of the Handler")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(80)]
        public string HandlerName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Mailing address information.")]
        public MailingAddress MailingAddress;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Contact information.")]
        public ContactDataType Contact;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("HandlerLqgClosure", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class HandlerLqgClosure
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Type of the closure.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string ClosureType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Date of expected closure.")]
        public System.DateTime ExpectedClosureDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ExpectedClosureDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("New closure date.")]
        public System.DateTime NewClosureDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NewClosureDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Date of closed.")]
        public System.DateTime DateClosed;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DateClosedSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Type of in compliance.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string InComplianceIndicator;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("EpisodicWaste", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class EpisodicWaste
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Unique number that identifies the episodic waste.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string EpisodicWasteSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Waste description.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4000)]
        public string WasteDescription;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The quantity of waste that is handled by each process code. This element pertains" +
            " only to Part A submissions.")]
        public decimal EstimatedQuantity;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EstimatedQuantitySpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("HandlerWasteCodeDetails", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Hazardous waste codes describing the handler\'s hazardous waste streams.")]
        public EpisodicHandlerWasteCodeDataType[] HandlerWasteCodeDetails;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("HandlerEpisodicEvent", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class HandlerEpisodicEvent
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Owner of the episodic event.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(2)]
        public string EpisodicEventOwner;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Type of the episodic event.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string EpisodicEventType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EpisodicProject", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Episodic project of the Handler")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public EpisodicProjectDataType[] EpisodicProject;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Contact information.")]
        public ContactDataType Contact;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Episodic event start event.")]
        public System.DateTime EpisodicEventStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EpisodicEventStartDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Episodic event end date.")]
        public System.DateTime EpisodicEventEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EpisodicEventEndDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EpisodicWaste", Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Episodic waste of the Handler")]
        public EpisodicWaste[] EpisodicWaste;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("Handler", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class HandlerDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Indicates the location of the agency regulating the handler.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ActivityLocationCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Code indicating the source of information for the associated data (activity, wast" +
            "es, etc.).")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string SourceTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the Handler Source Type (Data publishing only).")]
        public string SourceTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Sequence number for each source record about a handler.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string SourceRecordSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Date that the form (indicated by the associated Source) was received from the han" +
            "dler by the appropriate authority.")]
        public System.DateTime ReceiveDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ReceiveDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Name of the Handler")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(80)]
        public string HandlerName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Date information was received for the handler.")]
        public System.DateTime AcknowledgeReceiptDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AcknowledgeReceiptDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Flag indicating that the handler has been identified through a source other than " +
            "Notification and is suspected of conducting RCRA-regulated activities without pr" +
            "oper authority.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string NonNotifierIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing Notification source(Data publishing only).")]
        public string NonNotifierIndicatorText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 10)]
        [System.ComponentModel.DescriptionAttribute("The date that operation of the facility commenced, the date construction on the f" +
            "acility commenced, or the date that operation is expected to begin. Part-A submi" +
            "ssions")]
        public System.DateTime TreatmentStorageDisposalDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TreatmentStorageDisposalDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("Notes regarding Handler Part-A submissions.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4000)]
        public string NatureOfBusinessText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute(@"Code indicating that the handler, whether public or private, currently accepts hazardous waste from another site (site identified by a different EPA ID). If information is also available on the specific processes and wastes which are accepted, it is indicated by a flag at the process unit level (Process Unit Group Commercial Status).")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string OffsiteWasteReceiptCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [System.ComponentModel.DescriptionAttribute("Code indicating the reason why the handler is not accessible for normal RCRA trac" +
            "king and processing (previously called Bankrupt Indicator).")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string AccessibilityCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing reason facility is not accessible(Data publishing onl" +
            "y).")]
        public string AccessibilityCodeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the county code.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(2)]
        public string CountyCodeOwner;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [System.ComponentModel.DescriptionAttribute("The Federal Information Processing Standard (FIPS) code for the county in which t" +
            "he facility is located (Ref: FIPS Publication, 6-3, \"Counties and County Equival" +
            "ents of the States of the United States\").")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(5)]
        public string CountyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the County Name(Data publishing only).")]
        public string CountyName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [System.ComponentModel.DescriptionAttribute("Notes regarding the Handler (these are public notes; will be available via all se" +
            "rvices).")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4000)]
        public string HandlerSupplementalInformationText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        [System.ComponentModel.DescriptionAttribute("Notes regarding the Handler (these are internal notes; will be available via auth" +
            "enticated services).")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4000)]
        public string HandlerInternalSupplementalInformationText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        [System.ComponentModel.DescriptionAttribute("Notes regarding the Handler (these are internal notes; will be available via auth" +
            "enticated services).")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4000)]
        public string ShortTermSupplementalInformationText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        [System.ComponentModel.DescriptionAttribute("Location address information.")]
        public LocationAddressDataType LocationAddress;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        [System.ComponentModel.DescriptionAttribute("Mailing address information.")]
        public MailingAddress MailingAddress;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 23)]
        [System.ComponentModel.DescriptionAttribute("Contact address information for the facility owner/operator.")]
        public ContactAddress ContactAddress;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 24)]
        [System.ComponentModel.DescriptionAttribute("Contains contact and contact address information for the holder of the permit.")]
        public ContactAddress PermitContactAddress;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 25)]
        [System.ComponentModel.DescriptionAttribute("Used Oil codes.")]
        public UsedOilDataType UsedOil;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 26)]
        [System.ComponentModel.DescriptionAttribute("State and EPA hazardous waste activity codes.")]
        public SiteWasteActivityDataType WasteActivitySite;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 27)]
        [System.ComponentModel.DescriptionAttribute("State code indicating that the handler is engaged in the generation of hazardous " +
            "waste.")]
        public StateWasteGenerator StateWasteGenerator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 28)]
        [System.ComponentModel.DescriptionAttribute("Federal code indicating that the handler is engaged in the generation of hazardou" +
            "s waste.")]
        public StateWasteGenerator FederalWasteGenerator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 29)]
        [System.ComponentModel.DescriptionAttribute("Types of Laboratory Waste that the Handler has opted to manage under SubPart K")]
        public LaboratoryHazardousWaste LaboratoryHazardousWaste;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 30)]
        [System.ComponentModel.DescriptionAttribute("Description of the Hazardous Secondary Material managed by the Handler")]
        public HazardousSecondaryMaterialDataType HazardousSecondaryMaterial;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Certification", Order = 31)]
        [System.ComponentModel.DescriptionAttribute("Certification information for the person who certified report to the authorizing " +
            "agency.")]
        public CertificationDataType[] Certification;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NAICSIdentity", Order = 32)]
        [System.ComponentModel.DescriptionAttribute("North American Industry Classification Status codes reported for the handler.")]
        public NAICSIdentityDataType[] NAICSIdentity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FacilityOwnerOperator", Order = 33)]
        [System.ComponentModel.DescriptionAttribute("Handler owner and operator information.")]
        public FacilityOwnerOperatorDataType[] FacilityOwnerOperator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EnvironmentalPermit", Order = 34)]
        [System.ComponentModel.DescriptionAttribute("Information about environmental permits issued to the handler.")]
        public EnvironmentalPermitDataType[] EnvironmentalPermit;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("StateActivity", Order = 35)]
        [System.ComponentModel.DescriptionAttribute("State waste activity of the handler.")]
        public StateActivityDataType[] StateActivity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("HandlerUniversalWaste", Order = 36)]
        [System.ComponentModel.DescriptionAttribute("Information about universal waste generated by the handler.")]
        public UniversalWasteActivityDataType[] HandlerUniversalWaste;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("HandlerWasteCodeDetails", Order = 37)]
        [System.ComponentModel.DescriptionAttribute("Hazardous waste codes describing the handler\'s hazardous waste streams.")]
        public HandlerWasteCodeDataType[] HandlerWasteCodeDetails;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("HandlerLqgConsolidation", Order = 38)]
        [System.ComponentModel.DescriptionAttribute("RCRA Handler Lqg Consolidation data")]
        public HandlerLqgConsolidation[] HandlerLqgConsolidation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 39)]
        [System.ComponentModel.DescriptionAttribute("RCRA Handler Lqg Closure data")]
        public HandlerLqgClosure HandlerLqgClosure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 40)]
        [System.ComponentModel.DescriptionAttribute("Episodic event describing the handler\'s episodic event streams.")]
        public HandlerEpisodicEvent HandlerEpisodicEvent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 41)]
        [System.ComponentModel.DescriptionAttribute("Flag indicating if it is acknowledged.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string AcknowledgeFlagIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 42)]
        [System.ComponentModel.DescriptionAttribute("Flag indicating if it is included in national report.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string IncludeInNationalReportIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 43)]
        [System.ComponentModel.DescriptionAttribute("Flag indicating if it is LQHUW.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string LQHUWIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 44)]
        [System.ComponentModel.DescriptionAttribute("Indicates the year of report cycle.")]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string HDReportCycleYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 45)]
        [System.ComponentModel.DescriptionAttribute("Indicates the health care facility.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string HealthcareFacility;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 46)]
        [System.ComponentModel.DescriptionAttribute("Indicates the reverse distributor.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string ReverseDistributor;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 47)]
        [System.ComponentModel.DescriptionAttribute("Indicates the withdrawal from Subpart P.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string SubpartPWithdrawal;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 48)]
        [System.ComponentModel.DescriptionAttribute("Flag indicating if it is current record.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string CurrentRecord;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 49)]
        [System.ComponentModel.DescriptionAttribute("User id of record creation")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(255)]
        public string CreatedByUserid;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 50)]
        [System.ComponentModel.DescriptionAttribute("Creation date")]
        public System.DateTime HCreatedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool HCreatedDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 51)]
        [System.ComponentModel.DescriptionAttribute("Indicates data origination information.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(2)]
        public string DataOrig;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 52)]
        [System.ComponentModel.DescriptionAttribute("Latitude data type")]
        public decimal LocationLatitude;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LocationLatitudeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 53)]
        [System.ComponentModel.DescriptionAttribute("Longitude data type")]
        public decimal LocationLongitude;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LocationLongitudeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 54)]
        [System.ComponentModel.DescriptionAttribute("Location GIS primary.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string LocationGisPrimary;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 55)]
        [System.ComponentModel.DescriptionAttribute("Location GIS data original source.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(2)]
        public string LocationGisOrig;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("FederalWasteGenerator", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class StateWasteGenerator
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the generator status type.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(2)]
        public string WasteGeneratorOwnerName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler is engaged in the generation of hazardous waste." +
            "")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string WasteGeneratorStatusCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the Generator Status(Data publishing only).")]
        public string WasteGeneratorStatusText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("HazardousWasteHandlerSubmission", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class HazardousWasteHandlerSubmissionDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FacilitySubmission", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Details of facility submission.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public FacilitySubmissionDataType[] FacilitySubmission;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("FacilitySubmission", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class FacilitySubmissionDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Code that uniquely identifies the handler.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(12)]
        public string HandlerID;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Designates that data is available for extract for public use.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string PublicUseExtractIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute(@"Computer-generated primary facility-level key in the EPA FINDS data system used as an identifier to cross-reference entities regulated under different environmental programs. The Agency Facility Identification Data Standard (FIDS) requires that program offices store this key in their data systems.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(12)]
        public string FacilityRegistryID;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing whether the data are public or private.")]
        public string DataAccessText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Handler", Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Top level of all information about the handler.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public HandlerDataType[] Handler;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OtherID", Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Contains alternative identifiers for the facility.")]
        public OtherIDDataType[] OtherID;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("CorrectiveActionRelatedEvent", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class CorrectiveActionRelatedEventDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Indicates the location of the agency regulating the handler.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ActivityLocationCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the corrective action event.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(2)]
        public string CorrectiveActionEventDataOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("A code which corresponds to a specific event or event type. The first two charact" +
            "ers indicate the event category and the last three characters the numeric event " +
            "number.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(7)]
        public string CorrectiveActionEventCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the Corrective Action event(Data publishing only).")]
        public string CorrectiveActionEventText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Agency responsible for the event.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string EventAgencyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the agency responsible for the action(Data publishing" +
            " only).")]
        public string AgencyText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 7)]
        [System.ComponentModel.DescriptionAttribute("System-generated value used to uniquely identify multiple occurrences of a correc" +
            "tive action event.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string EventSequenceNumber;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("CorrectiveActionRelatedPermitUnit", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class CorrectiveActionRelatedPermitUnitDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("System-generated value used to uniquely identify a process unit.")]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string PermitUnitSequenceNumber;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("CorrectiveActionArea", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class CorrectiveActionAreaDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Code used for administrative purposes to uniquely designate a group of units (or " +
            "a single unit) with a common history and projection of corrective action require" +
            "ments.")]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string AreaSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Indicates that the corrective action applies to the entire facility.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string FacilityWideIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The name of the Corrective Action area.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(40)]
        public string AreaName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Indicates that there has been a release to air (either within or beyond the facil" +
            "ity boundary) from the unit/area. This may include releases of subsurface gas.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string AirReleaseIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Indicates that there has been a release to groundwater from the unit/area.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string GroundwaterReleaseIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Indicates that there has been a release to soil (either within or beyond the faci" +
            "lity boundary) from the unit/area. This may include subsoil contamination beneat" +
            "h the unit/area.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string SoilReleaseIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Indicates that there has been a release to surface water (either within or beyond" +
            " the facility boundary) from the unit/area.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string SurfaceWaterReleaseIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Indicates that the corrective action applies to a regulated unit.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string RegulatedUnitIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the person identifier.")]
        public string EPAResponsiblePersonDataOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("The person currently responsible for the permit at the EPA level.")]
        public string EPAResponsiblePersonID;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the person identifier.")]
        public string StateResponsiblePersonDataOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("The state person currently responsible for overseeing the corrective action area." +
            "")]
        public string StateResponsiblePersonID;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [System.ComponentModel.DescriptionAttribute("Notes providing more information.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(2000)]
        public string SupplementalInformationText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CorrectiveActionRelatedEvent", Order = 14)]
        [System.ComponentModel.DescriptionAttribute("Linking Data for Corrective Action Areas and Events or Authorities and Events")]
        public CorrectiveActionAreaRelatedEventDataType[] CorrectiveActionRelatedEvent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CorrectiveActionRelatedPermitUnit", Order = 15)]
        [System.ComponentModel.DescriptionAttribute("A permitted unit related to a corrective action area.")]
        public CorrectiveActionRelatedPermitUnitDataType[] CorrectiveActionRelatedPermitUnit;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [System.ComponentModel.DescriptionAttribute("User id of record creation")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(255)]
        public string CreatedByUserid;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 17)]
        [System.ComponentModel.DescriptionAttribute("Creation date")]
        public System.DateTime ACreatedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ACreatedDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [System.ComponentModel.DescriptionAttribute("Indicates data origination information.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(2)]
        public string DataOrig;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("CorrectiveActionStatutoryCitation", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class CorrectiveActionStatutoryCitationDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Orgnaization responsible for the Statutory Citation (use two-digit postal code)")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(2)]
        public string StatutoryCitationDataOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Identifier that identifies the statutory authority under which the corrective act" +
            "ion event occured")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string StatutoryCitationIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the statutory authority under which the corrective ac" +
            "tion event was taken(Data publishing only).")]
        public string StatutoryCitationDescription;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("CorrectiveActionAuthority", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class CorrectiveActionAuthorityDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Indicates the location of the agency regulating the handler.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ActivityLocationCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the authority.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(2)]
        public string AuthorityDataOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("A code used to indicate whether a permit, administrative order, or other authorit" +
            "y has been issued to implement the corrective action process.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string AuthorityTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the Authority used implement the Corrective Action Ev" +
            "ent(Data publishing only).")]
        public string AuthorityTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Agency responsible for the Authority.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string AuthorityAgencyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the agency responsible for the action(Data publishing" +
            " only).")]
        public string AgencyText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Date that the authority became effective.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public System.DateTime AuthorityEffectiveDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Date the authorized agency official signs the order, permit, or permit modificati" +
            "on.")]
        public System.DateTime IssueDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IssueDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 9)]
        [System.ComponentModel.DescriptionAttribute("The date when the corrective action authority is revoked or ended.")]
        public System.DateTime EndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EndDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute(@"The action by which the Director requires the owner/operator to establish and maintain an information repository at a location near the facility for the purpose of making accessible to interested parties documents, reports, and other public information relevant to public understanding of the activities, findings, and plans for such corrective action initiatives.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string EstablishedRepositoryCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the action by which the Director requires the owner/o" +
            "perator to maintain an information repository(Data publishing only).")]
        public string EstablishedRepositoryText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("Code indicating the program in which the organization establishes the applicable " +
            "guidance that the authority should be issued.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string ResponsibleLeadProgramIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [System.ComponentModel.DescriptionAttribute("Descriptive Text describing the program in which the organization establishes the" +
            " applicable guidance that the authority should be used(Data publishing only).")]
        public string ResponsibleLeadProgramText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [System.ComponentModel.DescriptionAttribute("Authority responsible suborganization owner.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(2)]
        public string AuthoritySuborganizationDataOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [System.ComponentModel.DescriptionAttribute("Authority responsible suborganization.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(10)]
        public string AuthoritySuborganizationCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the person identifier.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(2)]
        public string ResponsiblePersonDataOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [System.ComponentModel.DescriptionAttribute("Code indicating the person within the agency responsible for conducting the evalu" +
            "ation or who is the responsible Authority.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(5)]
        public string ResponsiblePersonID;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [System.ComponentModel.DescriptionAttribute("Notes providing more information.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(2000)]
        public string SupplementalInformationText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CorrectiveActionStatutoryCitation", Order = 19)]
        [System.ComponentModel.DescriptionAttribute("Linking Data for Corrective Action Authorities and Statutory Citations")]
        public CorrectiveActionStatutoryCitationDataType[] CorrectiveActionStatutoryCitation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CorrectiveActionRelatedEvent", Order = 20)]
        [System.ComponentModel.DescriptionAttribute("Linking Data for Corrective Action Areas and Events or Authorities and Events")]
        public CorrectiveActionAuthorityRelatedEventDataType[] CorrectiveActionRelatedEvent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        [System.ComponentModel.DescriptionAttribute("User id of record creation")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(255)]
        public string CreatedByUserid;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 22)]
        [System.ComponentModel.DescriptionAttribute("Creation date")]
        public System.DateTime ACreatedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ACreatedDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 23)]
        [System.ComponentModel.DescriptionAttribute("Indicates data origination information.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(2)]
        public string DataOrig;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("EventCommitment", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class EventCommitmentDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(2)]
        public string CommitmentLead;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 2)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string CommitmentSequenceNumber;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("CorrectiveActionEvent", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class CorrectiveActionEventDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Indicates the location of the agency regulating the handler.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ActivityLocationCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the corrective action event.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(2)]
        public string CorrectiveActionEventDataOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("A code which corresponds to a specific event or event type. The first two charact" +
            "ers indicate the event category and the last three characters the numeric event " +
            "number.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(7)]
        public string CorrectiveActionEventCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the Corrective Action event(Data publishing only).")]
        public string CorrectiveActionEventText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Agency responsible for the event.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string EventAgencyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the agency responsible for the action(Data publishing" +
            " only).")]
        public string AgencyText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 7)]
        [System.ComponentModel.DescriptionAttribute("System-generated value used to uniquely identify multiple occurrences of a correc" +
            "tive action event.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string EventSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Date on which actual completion of an event occurs.")]
        public System.DateTime ActualDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ActualDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 9)]
        [System.ComponentModel.DescriptionAttribute("The original scheduled completion date for an event. This date cannot be changed " +
            "once entered. Slippage of the scheduled completion date is recorded in the NewSc" +
            "heduleDate Data Element.")]
        public System.DateTime OriginalScheduleDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool OriginalScheduleDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 10)]
        [System.ComponentModel.DescriptionAttribute(@"Revised scheduled completion date of the event. This date is used in conjunction with the Original Scheduled Event Date to allow tracking scheduled date slippage. As the scheduled date changes, this field is updated with the new date and the Original Scheduled Event Date is not changed.")]
        public System.DateTime NewScheduleDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NewScheduleDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("Event responsible suborganization owner.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(2)]
        public string EventSuborganizationDataOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("Event responsible suborganization.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(10)]
        public string EventSuborganizationCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the person identifier.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(2)]
        public string ResponsiblePersonDataOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [System.ComponentModel.DescriptionAttribute("Code indicating the person within the agency responsible for conducting the evalu" +
            "ation or who is the responsible Authority.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(5)]
        public string ResponsiblePersonID;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [System.ComponentModel.DescriptionAttribute("Notes providing more information.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(2000)]
        public string SupplementalInformationText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EventCommitment", Order = 16)]
        [System.ComponentModel.DescriptionAttribute("Linking Data for Commitment/Initiative and Corrective Action or Permitting Events" +
            ".")]
        public EventEventCommitmentDataType[] EventCommitment;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [System.ComponentModel.DescriptionAttribute("Public notes providing more information.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(2000)]
        public string PublicSupplementalInformationText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [System.ComponentModel.DescriptionAttribute("User id of record creation")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(255)]
        public string CreatedByUserid;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 19)]
        [System.ComponentModel.DescriptionAttribute("Creation date")]
        public System.DateTime ACreatedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ACreatedDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        [System.ComponentModel.DescriptionAttribute("Indicates data origination information.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(2)]
        public string DataOrig;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("HazardousWasteCorrectiveActionSubmission", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class HazardousWasteCorrectiveActionDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CorrectiveActionFacilitySubmission", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Supplies all of the relevant Corrective Action Data for a given Handler")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public CorrectiveActionFacilitySubmissionDataType[] CorrectiveActionFacilitySubmission;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("CorrectiveActionFacilitySubmission", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class CorrectiveActionFacilitySubmissionDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Code that uniquely identifies the handler.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(12)]
        public string HandlerID;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CorrectiveActionArea", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A list of Correction Action Areas for a particluar Handler")]
        public CorrectiveActionAreaDataType[] CorrectiveActionArea;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CorrectiveActionAuthority", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("A list of Correction Action Authorities for a particluar Handler")]
        public CorrectiveActionAuthorityDataType[] CorrectiveActionAuthority;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CorrectiveActionEvent", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("A list of Correction Action Events for a particluar Handler")]
        public CorrectiveActionEventDataType[] CorrectiveActionEvent;
    }

        /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("PermitModEvent", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class PermitModEventDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Handler id.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(12)]
        public string ModHandlerId;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Permit event activity location.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ModActivityLocationCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Permit series sequence number.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string ModSeriesSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Permit event sequence number.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string ModEventSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Permit event owner.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string ModEventAgencyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Permit event owner.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(2)]
        public string ModEventDataOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Permit event code.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(7)]
        public string ModEventCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("PermitEvent", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class PermitEventDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Indicates the location of the agency regulating the handler.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ActivityLocationCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the event.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(2)]
        public string PermitEventDataOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Code used to indicate a specific permitting/closure program event and status that" +
            " has actually occurred or is scheduled to occur.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(7)]
        public string PermitEventCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the Permitting Event(Data publishing only).")]
        public string PermitEventText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Agency responsible for the event.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string EventAgencyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the agency responsible for the action(Data publishing" +
            " only).")]
        public string AgencyText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 7)]
        [System.ComponentModel.DescriptionAttribute("System-generated value used to uniquely identify multiple occurrences of a correc" +
            "tive action event.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string EventSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Date on which actual completion of an event occurs.")]
        public System.DateTime ActualDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ActualDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 9)]
        [System.ComponentModel.DescriptionAttribute("The original scheduled completion date for an event. This date cannot be changed " +
            "once entered. Slippage of the scheduled completion date is recorded in the NewSc" +
            "heduleDate Data Element.")]
        public System.DateTime OriginalScheduleDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool OriginalScheduleDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 10)]
        [System.ComponentModel.DescriptionAttribute(@"Revised scheduled completion date of the event. This date is used in conjunction with the Original Scheduled Event Date to allow tracking scheduled date slippage. As the scheduled date changes, this field is updated with the new date and the Original Scheduled Event Date is not changed.")]
        public System.DateTime NewScheduleDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NewScheduleDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the person identifier.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(2)]
        public string ResponsiblePersonDataOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("Code indicating the person within the agency responsible for conducting the evalu" +
            "ation or who is the responsible Authority.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(5)]
        public string ResponsiblePersonID;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [System.ComponentModel.DescriptionAttribute("Event responsible suborganization owner.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(2)]
        public string EventSuborganizationDataOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [System.ComponentModel.DescriptionAttribute("Event responsible suborganization.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(10)]
        public string EventSuborganizationCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [System.ComponentModel.DescriptionAttribute("Notes providing more information.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(2000)]
        public string SupplementalInformationText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EventCommitment", Order = 16)]
        [System.ComponentModel.DescriptionAttribute("Linking Data for Commitment/Initiative and Corrective Action or Permitting Events" +
            ".")]
        public PermitEventCommitmentDataType[] EventCommitment;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [System.ComponentModel.DescriptionAttribute("User id of record creation")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(255)]
        public string CreatedByUserid;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 18)]
        [System.ComponentModel.DescriptionAttribute("Creation date")]
        public System.DateTime PCreatedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PCreatedDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PermitModEvent", Order = 19)]
        [System.ComponentModel.DescriptionAttribute("Linking mod event for Permitting Events.")]
        public PermitModEventDataType[] PermitModEvent;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("PermitSeries", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class PermitSeriesDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("System-generated value used to uniquely identify a permit series.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string PermitSeriesSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Name or number assigned by the implementing agency.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(40)]
        public string PermitSeriesName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the person identifier.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(2)]
        public string ResponsiblePersonDataOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Code indicating the person within the agency responsible for conducting the evalu" +
            "ation or who is the responsible Authority.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(5)]
        public string ResponsiblePersonID;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Notes providing more information.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(2000)]
        public string SupplementalInformationText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PermitEvent", Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Permit event Data")]
        public PermitEventDataType[] PermitEvent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Indicates if the permit series is active. Possible values are: Y/N")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string ActiveSeriesIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("User id of record creation")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(255)]
        public string CreatedByUserid;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 9)]
        [System.ComponentModel.DescriptionAttribute("Creation date")]
        public System.DateTime PCreatedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PCreatedDateSpecified;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("PermitRelatedEvent", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class PermitRelatedEventDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Indicates the location of the agency regulating the handler.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ActivityLocationCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("System-generated value used to uniquely identify a permit series.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string PermitSeriesSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the event.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(2)]
        public string PermitEventDataOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Code used to indicate a specific permitting/closure program event and status that" +
            " has actually occurred or is scheduled to occur.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(7)]
        public string PermitEventCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the Permitting Event(Data publishing only).")]
        public string PermitEventText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Agency responsible for the event.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string EventAgencyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the agency responsible for the action(Data publishing" +
            " only).")]
        public string AgencyText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 8)]
        [System.ComponentModel.DescriptionAttribute("System-generated value used to uniquely identify multiple occurrences of a correc" +
            "tive action event.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string EventSequenceNumber;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("PermitUnitDetail", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class PermitUnitDetailDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("System-generated value used to uniquely identify a process unit detail.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string PermitUnitDetailSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the process code.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(2)]
        public string ProcessUnitDataOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Code specifying the unit group\'s current waste treatment, storage, or disposal pr" +
            "ocess.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(3)]
        public string ProcessUnitCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the type of permitted unit(Data publishing only).")]
        public string ProcessUnitText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Date specifying when the other information in the process detail data record (i.e" +
            "., process, capacity, and operating and legal status) became effective.")]
        public System.DateTime PermitStatusEffectiveDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PermitStatusEffectiveDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Permitted capacity of the unit")]
        public decimal PermitUnitCapacityQuantity;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PermitUnitCapacityQuantitySpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Code indicating the type of capacity.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string CapacityTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the capacity of the unit(Data publishing only).")]
        public string CapacityTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the facility, whether public or private, accepts hazardous w" +
            "aste for the process unit group from a third party.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string CommercialStatusCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing whether or not the unit is permitted to receive hazar" +
            "dous waste commercially(Data publishing only).")]
        public string CommercialStatusText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the legal/operating status code.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(2)]
        public string LegalOperatingStatusDataOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("Code used to indicate programmatic (operating and legal status) conditions that r" +
            "eflect RCRA program activity requirements of a unit.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4)]
        public string LegalOperatingStatusCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing Legal/Operating status of the Unit(Data publishing on" +
            "ly).")]
        public string LegalOperatingStatusText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the unit of measure.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(2)]
        public string MeasurementUnitDataOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [System.ComponentModel.DescriptionAttribute("Indicates the unit of measure.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string MeasurementUnitCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing units for the capacity of the permitted unit(Data pub" +
            "lishing only).")]
        public string MeasurementUnitText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 17)]
        [System.ComponentModel.DescriptionAttribute("Total number of units of the same process grouped together to form a single proce" +
            "ss unit group.")]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string NumberOfUnitsCount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [System.ComponentModel.DescriptionAttribute("Indicates whether or not the permit is a standardized permit.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string StandardPermitIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        [System.ComponentModel.DescriptionAttribute("Notes providing more information.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(2000)]
        public string SupplementalInformationText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PermitRelatedEvent", Order = 20)]
        [System.ComponentModel.DescriptionAttribute("Linking Data for Permitted Units and Permitting Events")]
        public PermitRelatedEventDataType[] PermitRelatedEvent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("HandlerWasteCodeDetails", Order = 21)]
        [System.ComponentModel.DescriptionAttribute("Hazardous waste codes describing the handler\'s hazardous waste streams.")]
        public PermitHandlerWasteCodeDataType[] HandlerWasteCodeDetails;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        [System.ComponentModel.DescriptionAttribute("Indicates if the unit detail is current. Possible values are: Y/N")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string CurrentUnitDetailIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 23)]
        [System.ComponentModel.DescriptionAttribute("User id of record creation")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(255)]
        public string CreatedByUserid;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 24)]
        [System.ComponentModel.DescriptionAttribute("Creation date")]
        public System.DateTime PCreatedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PCreatedDateSpecified;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("PermitUnit", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class PermitUnitDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("System-generated value used to uniquely identify a process unit.")]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string PermitUnitSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Name or number assigned by the implementing agency to identify a process unit gro" +
            "up.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(40)]
        public string PermitUnitName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Notes providing more information.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(2000)]
        public string SupplementalInformationText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PermitUnitDetail", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Permit Unit Detail Data")]
        public PermitUnitDetailDataType[] PermitUnitDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Indicates if the permit unit is active. Possible values are: Y/N")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string ActiveUnitIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("User id of record creation")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(255)]
        public string CreatedByUserid;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Creation date")]
        public System.DateTime PCreatedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PCreatedDateSpecified;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("HazardousWastePermitSubmission", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class HazardousWastePermitDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PermitFacilitySubmission", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("This is the root element for this flow XML Schema.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public PermitFacilitySubmissionDataType[] PermitFacilitySubmission;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("PermitFacilitySubmission", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class PermitFacilitySubmissionDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Code that uniquely identifies the handler.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(12)]
        public string HandlerID;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PermitSeries", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Permit series Data")]
        public PermitSeriesDataType[] PermitSeries;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PermitUnit", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Permit Unit Data")]
        public PermitUnitDataType[] PermitUnit;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("CostEstimateRelatedMechanism", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class CostEstimateRelatedMechanismDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Indicates the location of the agency regulating the handler.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ActivityLocationCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The agency responsible for overseeing the review of the mechanism.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string MechanismAgencyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the agency responsible for the action(Data publishing" +
            " only).")]
        public string AgencyText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Unique numerical identier for the mechanism.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string MechanismSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Unique numerical code identifying the mechanism detail.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string MechanismDetailSequenceNumber;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("CostEstimate", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class CostEstimateDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Indicates the location of the agency regulating the handler.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ActivityLocationCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Indicates what type of Financial Assurance is Required.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string CostEstimateTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the type of Cost Estimate(Data publishing only).")]
        public string CostEstimateTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Code indicating the agency responsible for overseeing the review of the cost esti" +
            "mate.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string CostEstimateAgencyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the agency responsible for the action(Data publishing" +
            " only).")]
        public string AgencyText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Unique number that identifies the cost estimate.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string CostEstimateSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the person identifier.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(2)]
        public string ResponsiblePersonDataOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Code indicating the person within the agency responsible for conducting the evalu" +
            "ation or who is the responsible Authority.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(5)]
        public string ResponsiblePersonID;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("The dollar amount of the cost estimate for a given financial assurance type.")]
        public decimal CostEstimateAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CostEstimateAmountSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 10)]
        [System.ComponentModel.DescriptionAttribute("The date when the cost estimate for a given financial assurance type was submitte" +
            "d, adjusted, approved, or required to be in place.")]
        public System.DateTime CostEstimateDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CostEstimateDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("The reason the cost estimate for a financial assurance type is being reported.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string CostEstimateReasonCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the reason the cost estimate for financial assurance " +
            "is being reported(Data publishing only).")]
        public string CostEstimateReasonText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [System.ComponentModel.DescriptionAttribute("Notes regarding the corrective action area or permit unit that this cost estimate" +
            " applies.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(240)]
        public string AreaUnitNotesText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [System.ComponentModel.DescriptionAttribute("Notes providing more information.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(2000)]
        public string SupplementalInformationText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CostEstimateRelatedMechanism", Order = 15)]
        [System.ComponentModel.DescriptionAttribute("Linking Data for Cost Estimates and Related Mechanisms")]
        public CostEstimateRelatedMechanismDataType[] CostEstimateRelatedMechanism;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [System.ComponentModel.DescriptionAttribute("User id of record creation")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(255)]
        public string CreatedByUserid;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 17)]
        [System.ComponentModel.DescriptionAttribute("Creation date")]
        public System.DateTime FCreatedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool FCreatedDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [System.ComponentModel.DescriptionAttribute("Indicates data origination information.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(2)]
        public string DataOrig;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("MechanismDetail", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class MechanismDetailDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Unique numerical code identifying the mechanism detail.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string MechanismDetailSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The number assigned to the mechanism, such as a bond number or insurance policy n" +
            "umber.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(40)]
        public string MechanismIdentificationText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The total dollar value of the financial assurance mechanism.")]
        public decimal FaceValueAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool FaceValueAmountSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The Effective Date of the action: 1. Hazardous Secondary Material notification in" +
            " Handler, 2. Corrective Action Authority, 3. Financial Assurance Mechanism.")]
        public System.DateTime EffectiveDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EffectiveDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The date the instrument terminates, such as the end of the term of an insurance p" +
            "olicy.")]
        public System.DateTime ExpirationDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ExpirationDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Notes providing more information.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(2000)]
        public string SupplementalInformationText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Indicates if the machamism detail is current. Possible values are: Y/N")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string CurrentMechanismDetailIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("User id of record creation")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(255)]
        public string CreatedByUserid;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 9)]
        [System.ComponentModel.DescriptionAttribute("Creation date")]
        public System.DateTime FCreatedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool FCreatedDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("Indicates data origination information.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(2)]
        public string DataOrig;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("Mechanism", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class MechanismDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Indicates the location of the agency regulating the handler.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ActivityLocationCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The agency responsible for overseeing the review of the mechanism.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string MechanismAgencyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the agency responsible for the action(Data publishing" +
            " only).")]
        public string AgencyText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Unique numerical identier for the mechanism.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string MechanismSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defined the mechanism type.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(2)]
        public string MechanismTypeDataOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("The type of mechanism that addresses the cost estimate.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string MechanismTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing mechanism used to address the cost estimate(Data publ" +
            "ishing only).")]
        public string MechanismTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("The name of the financial institution with which the financial assurance mechanis" +
            "m is held, such as a bank (letter of credit) or a surety (surety bond); also ide" +
            "ntifies a facility (financial test), or a guarantor (corporate guarantee).")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(80)]
        public string ProviderText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("Contact Name of the provider.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(33)]
        public string ProviderFullContactName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("Telephone Number data")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(15)]
        public string TelephoneNumberText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("Notes providing more information.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(2000)]
        public string SupplementalInformationText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MechanismDetail", Order = 12)]
        [System.ComponentModel.DescriptionAttribute("Details of the mechanism used to address cost estimates of the Financial liabilit" +
            "y associated with a given Handler.")]
        public MechanismDetailDataType[] MechanismDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [System.ComponentModel.DescriptionAttribute("User id of record creation")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(255)]
        public string CreatedByUserid;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 14)]
        [System.ComponentModel.DescriptionAttribute("Creation date")]
        public System.DateTime FCreatedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool FCreatedDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [System.ComponentModel.DescriptionAttribute("Indicates data origination information.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(2)]
        public string DataOrig;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("FinancialAssuranceSubmission", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class FinancialAssuranceSubmissionDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FinancialAssuranceFacilitySubmission", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Supplies all of the relevant Financial Assurance Data for a given Handler")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public FinancialAssuranceFacilitySubmissionDataType[] FinancialAssuranceFacilitySubmission;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("FinancialAssuranceFacilitySubmission", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class FinancialAssuranceFacilitySubmissionDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Code that uniquely identifies the handler.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(12)]
        public string HandlerID;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CostEstimate", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Estimates of the Financial liability costs associated with a given Handler.")]
        public CostEstimateDataType[] CostEstimate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Mechanism", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Mechanisms used to address cost estimates of the Financial liability associated w" +
            "ith a given Handler.")]
        public MechanismDataType[] Mechanism;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("AreaAcreage", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class AreaAcreageDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The number of acres associated with the handler or area.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public decimal AreaAcreageMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defined the AreaMeasureSource.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(2)]
        public string AreaMeasureSourceDataOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The source of information used to determine the number of acres associated with t" +
            "he handler or area.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4)]
        public string AreaMeasureSourceCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the source used to determine the number of acres(Data" +
            " publishing only).")]
        public string AreaMeasureSourceText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The date acreage information for the handler or area was collected.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public System.DateTime AreaMeasureDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("GeographicMetadata", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class GeographicMetadataDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The calender date when data were collected")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public System.DateTime DataCollectionDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The horizontal measure, in meters, of the relative accuracy of the latitude and l" +
            "ongitude coordinates.")]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string HorizontalAccuracyMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The number that represents the proportional distance on the ground for one unit o" +
            "f measure on the map or photo.")]
        public decimal SourceMapScaleNumeric;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SourceMapScaleNumericSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The owner of the code. If provided, it should be HQ.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(2)]
        public string CoordinateDataSourceDataOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the party responsible for proiding the latitude and long" +
            "itude coordinates.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(3)]
        public string CoordinateDataSourceCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the party responsible for collecting or providing the" +
            " GIS Coordinates(Data publishing only).")]
        public string CoordinateDataSourceName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("The owner of the code. If provided, it should be HQ.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(2)]
        public string GeographicReferencePointDataOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the place for which the geographic codes were establishe" +
            "d")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(3)]
        public string GeographicReferencePointCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the place for which the coordinate/coordinates repres" +
            "ent(Data publishing only).")]
        public string GeographicReferencePointName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("The owner of the code. If provided, it should be HQ.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(2)]
        public string GeometricTypeDataOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the geometric entity represented by one point or a seque" +
            "nce of points")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(3)]
        public string GeometricTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the geometry of the point/points provided, i.e. Area," +
            " Point, Line, etc.(Data publishing only).")]
        public string GeometricTypeName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("The owner of the code. If provided, it should be HQ.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(2)]
        public string HorizontalCollectionMethodDataOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the method used to deterimine the latitude and longitude" +
            " coordinates for a point on the earth.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(3)]
        public string HorizontalCollectionMethodCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the method used to obtain the GIS Coordinates(Data pu" +
            "blishing only).")]
        public string HorizontalCollectionMethodName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [System.ComponentModel.DescriptionAttribute("The owner of the code. If provided, it should be HQ.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(2)]
        public string HorizontalCoordinateReferenceSystemDatumDataOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the datum used in determining latitude and longitude coo" +
            "rdinates")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(3)]
        public string HorizontalCoordinateReferenceSystemDatumCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the Horizontal Datum of the GIS Coordinates(Data publ" +
            "ishing only).")]
        public string HorizontalCoordinateReferenceSystemDatumName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [System.ComponentModel.DescriptionAttribute("The owner of the code. If provided, it should be HQ.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(2)]
        public string VerificationMethodDataOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the process used to verify the latitude and longitude co" +
            "ordinates.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(3)]
        public string VerificationMethodCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the method used to verify the GIS Coordinates(Data pu" +
            "blishing only).")]
        public string VerificationMethodName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("GeographicInformation", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class GeographicInformationDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Owner of Geographic Information. Should match state code (i.e. KS).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(2)]
        public string GeographicInformationOwner;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Unique identifier for the geographic information.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string GeographicInformationSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("System-generated value used to uniquely identify a process unit.")]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string PermitUnitSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Code used for administrative purposes to uniquely designate a group of units (or " +
            "a single unit) with a common history and projection of corrective action require" +
            "ments.")]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string AreaSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Used to define the acreage of a handler or area.")]
        public AreaAcreageDataType AreaAcreage;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Metadata for the geographic coordinates of the Handler.")]
        public GeographicMetadataDataType GeographicMetadata;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Geometry property element of a GeoRcra GML instance")]
        public whereType rcraWhere;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("The text that provides additional informaiton about the geographic coordinates.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(2000)]
        public string LocationCommentsText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("User id of record creation")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(255)]
        public string CreatedByUserid;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 10)]
        [System.ComponentModel.DescriptionAttribute("Creation date")]
        public System.DateTime GCreatedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool GCreatedDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("Indicates data origination information.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(2)]
        public string DataOrig;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.georss.org/georss")]
    [System.Xml.Serialization.XmlRootAttribute("where", Namespace = "http://www.georss.org/georss", IsNullable = false)]
    //TSM: public partial class whereType : abstractFeaturePropertyType
    public partial class whereType
    {

        //TSM: Only point type supported for now
        ///// <remarks/>
        //[System.Xml.Serialization.XmlElementAttribute("LineString", typeof(LineStringType), Namespace = "http://www.opengis.net/gml", Order = 0)]
        //[System.Xml.Serialization.XmlElementAttribute("Point", typeof(PointType), Namespace = "http://www.opengis.net/gml", Order = 0)]
        //[System.Xml.Serialization.XmlElementAttribute("Polygon", typeof(PolygonType), Namespace = "http://www.opengis.net/gml", Order = 0)]
        //public AbstractGeometricPrimitiveType Item;

        //TSM: Only do point type for now
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.opengis.net/gml", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Geometry property element of a GeoRSS GML instance")]
        public PointType Point;
    }

    ///// <remarks/>
    //[System.Xml.Serialization.XmlIncludeAttribute(typeof(whereType))]
    //[System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.georss.org/georss")]
    //[System.Xml.Serialization.XmlRootAttribute("_featureProperty", Namespace="http://www.georss.org/georss", IsNullable=false)]
    //public abstract partial class abstractFeaturePropertyType {
    //}

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("GeographicInformationSubmission", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class GeographicInformationSubmissionDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("GISFacilitySubmission", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Supplies all of the relevant GIS Data for a given Handler")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public GISFacilitySubmissionDataType[] GISFacilitySubmission;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("GISFacilitySubmission", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class GISFacilitySubmissionDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Code that uniquely identifies the handler.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(12)]
        public string HandlerID;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("GeographicInformation", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Used to define the geographic coordinates of the Handler.")]
        public GeographicInformationDataType[] GeographicInformation;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("ReportUniv", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class ReportUniv
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Handler ID")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(12)]
        public string HandlerIdCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Indicates the location of the agency regulating the handler.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ActivityLocationCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Code indicating the source of information for the associated data (activity, wast" +
            "es, etc.).")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string SourceTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Sequence number for each source record about a handler.")]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string SequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Date that the form (indicated by the associated Source) was received from the han" +
            "dler by the appropriate authority.")]
        public System.DateTime ReceiveDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ReceiveDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Name of the Handler")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(80)]
        public string HandlerName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Flag indicating that the handler has been identified through a source other than " +
            "Notification and is suspected of conducting RCRA-regulated activities without pr" +
            "oper authority.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string NonNotifierIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Reason why the handler is not accessible for normal processing (Bankrupt Indicato" +
            "r).")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string Accessibility;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Report cycle")]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string ReportCycle;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("Region")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(2)]
        public string Region;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("State")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(2)]
        public string State;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("Extract flag")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string ExtractFlag;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("Active site")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(5)]
        public string ActiveSite;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [System.ComponentModel.DescriptionAttribute("The Federal Information Processing Standard (FIPS) code for the county in which t" +
            "he facility is located (Ref: FIPS Publication, 6-3, \"Counties and County Equival" +
            "ents of the States of the United States\").")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(5)]
        public string CountyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the County Name(Data publishing only).")]
        public string CountyName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [System.ComponentModel.DescriptionAttribute("Location address information.")]
        public LocationAddressDataType LocationAddress;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [System.ComponentModel.DescriptionAttribute("Mailing address information.")]
        public MailingAddress MailingAddress;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [System.ComponentModel.DescriptionAttribute("RU contact address")]
        public MailingAddress RUContactAddress;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [System.ComponentModel.DescriptionAttribute("Contact name (first + last)")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(80)]
        public string ContactNameCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        [System.ComponentModel.DescriptionAttribute("Contact phone")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(22)]
        public string ContactPhoneCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        [System.ComponentModel.DescriptionAttribute("Contact fax")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(15)]
        public string ContactFaxCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        [System.ComponentModel.DescriptionAttribute("Contact email")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(80)]
        public string ContactEmailCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        [System.ComponentModel.DescriptionAttribute("Contact title")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(45)]
        public string ContactTitleCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 23)]
        [System.ComponentModel.DescriptionAttribute("Owner name")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(80)]
        public string OwnerNameCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 24)]
        [System.ComponentModel.DescriptionAttribute("Owner type")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string OwnerTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 25)]
        [System.ComponentModel.DescriptionAttribute("Owner seq")]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string OwnerSeqCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 26)]
        [System.ComponentModel.DescriptionAttribute("Operator name")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(80)]
        public string OperatorNameCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 27)]
        [System.ComponentModel.DescriptionAttribute("Operator type")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string OperatorTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 28)]
        [System.ComponentModel.DescriptionAttribute("Operator seq")]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string OperatorSeqCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 29)]
        [System.ComponentModel.DescriptionAttribute("NAIC 1")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(6)]
        public string NAIC1Code;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 30)]
        [System.ComponentModel.DescriptionAttribute("NAIC 2")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(6)]
        public string NAIC2Code;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 31)]
        [System.ComponentModel.DescriptionAttribute("NAIC 3")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(6)]
        public string NAIC3Code;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 32)]
        [System.ComponentModel.DescriptionAttribute("NAIC 4")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(6)]
        public string NAIC4Code;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 33)]
        [System.ComponentModel.DescriptionAttribute("In handler universe")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string InHandlerUniverseCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 34)]
        [System.ComponentModel.DescriptionAttribute("In A universe")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string InAUniverseCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 35)]
        [System.ComponentModel.DescriptionAttribute("Federal code indicating that the handler is engaged in the generation of hazardou" +
            "s waste.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(2)]
        public string FederalWasteGeneratorOwner;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 36)]
        [System.ComponentModel.DescriptionAttribute("Federal code indicating that the handler is engaged in the generation of hazardou" +
            "s waste.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string FederalWasteGeneratorCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 37)]
        [System.ComponentModel.DescriptionAttribute("State code indicating that the handler is engaged in the generation of hazardous " +
            "waste.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(2)]
        public string StateWasteGeneratorOwner;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 38)]
        [System.ComponentModel.DescriptionAttribute("State code indicating that the handler is engaged in the generation of hazardous " +
            "waste.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string StateWasteGeneratorCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 39)]
        [System.ComponentModel.DescriptionAttribute("Gen status")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(3)]
        public string GENSTATUS;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 40)]
        [System.ComponentModel.DescriptionAttribute("Univ waste")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string UNIVWASTE;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 41)]
        [System.ComponentModel.DescriptionAttribute("Code indicating current ownership status of the land on which the facility is loc" +
            "ated.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string LandTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 42)]
        [System.ComponentModel.DescriptionAttribute("Owner of the state district code. Usually 2-digit postal code (i.e. KS).")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(2)]
        public string StateDistrictOwnerName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 43)]
        [System.ComponentModel.DescriptionAttribute("Code indicating the state-designated legislative district(s) in which the site is" +
            " located.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(10)]
        public string StateDistrictCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 44)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler is engaged in short-term hazardous waste generat" +
            "ion activities.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string ShortTermGeneratorIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 45)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler is engaged in importing hazardous waste into the" +
            " United States.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string ImporterActivityCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 46)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler is engaged in generating mixed waste (waste that" +
            " is both hazardous and radioactive).")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string MixedWasteGeneratorCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 47)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler is engaged in the transportation of hazardous wa" +
            "ste.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string TransporterActivityCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 48)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler is a Hazardous Waste Transfer Facility (not to b" +
            "e confused with a used oil transfer facility).")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string TransferFacilityIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 49)]
        [System.ComponentModel.DescriptionAttribute("Code for recycling hazardous waste.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string RecyclerActivityCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 50)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler qualifies for the Small Quantity Onsite Burner E" +
            "xemption.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string OnsiteBurnerExemptionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 51)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler qualifies for the Smelting, Melting, and Refinin" +
            "g Furnace Exemption.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string FurnaceExemptionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 52)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler generates and or treats, stores, or disposes of " +
            "hazardous waste and has an injection well located at the installation.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string UndergroundInjectionActivityCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 53)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler treats, disposes of, or recycles hazardous waste" +
            " on site.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string UniversalWasteDestinationFacilityIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 54)]
        [System.ComponentModel.DescriptionAttribute("Off site waste receipt")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string OffSiteWasteReceiptCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 55)]
        [System.ComponentModel.DescriptionAttribute("Used oil")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(7)]
        public string UsedOilCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 56)]
        [System.ComponentModel.DescriptionAttribute("Federal universal waste")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string FederalUniversalWasteCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 57)]
        [System.ComponentModel.DescriptionAttribute("As federal regulated TSDF")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(6)]
        public string AsFederalRegulatedTSDFCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 58)]
        [System.ComponentModel.DescriptionAttribute("As converter TSDF")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(6)]
        public string AsConverterTSDFCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 59)]
        [System.ComponentModel.DescriptionAttribute("As state regulated TSDF")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(9)]
        public string AsStateRegulatedTSDFCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 60)]
        [System.ComponentModel.DescriptionAttribute("Federal indicator")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(3)]
        public string FederalIndicatorCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 61)]
        [System.ComponentModel.DescriptionAttribute("HSM code")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(2)]
        public string HSMCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 62)]
        [System.ComponentModel.DescriptionAttribute("Subpart K code")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4)]
        public string SubpartKCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 63)]
        [System.ComponentModel.DescriptionAttribute("Commercial TSD code")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string CommercialTSDCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 64)]
        [System.ComponentModel.DescriptionAttribute("TSD type")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(5)]
        public string TSDTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 65)]
        [System.ComponentModel.DescriptionAttribute("GPRA permit")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string GPRAPermitCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 66)]
        [System.ComponentModel.DescriptionAttribute("GPRA renewal code")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string GPRARenewalCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 67)]
        [System.ComponentModel.DescriptionAttribute("Permit renewal WRKLD")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(6)]
        public string PermitRenewalWRKLDCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 68)]
        [System.ComponentModel.DescriptionAttribute("Perm WRKLD")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(6)]
        public string PermWRKLDCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 69)]
        [System.ComponentModel.DescriptionAttribute("Perm PROG")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(6)]
        public string PermPROGCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 70)]
        [System.ComponentModel.DescriptionAttribute("PC WRKLD")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(6)]
        public string PCWRKLDCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 71)]
        [System.ComponentModel.DescriptionAttribute("Clos WRKLD")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(6)]
        public string ClosWRKLDCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 72)]
        [System.ComponentModel.DescriptionAttribute("GPRACA")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string GPRACACode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 73)]
        [System.ComponentModel.DescriptionAttribute("CAWRKLD")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string CAWRKLDCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 74)]
        [System.ComponentModel.DescriptionAttribute("Subj CA")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string SubjCACode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 75)]
        [System.ComponentModel.DescriptionAttribute("Subj CA non TSD")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string SubjCANonTSDCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 76)]
        [System.ComponentModel.DescriptionAttribute("Subj CA TSD 3004")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string SubjCATSD3004Code;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 77)]
        [System.ComponentModel.DescriptionAttribute("Subj CA discretion")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string SubjCADiscretionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 78)]
        [System.ComponentModel.DescriptionAttribute("NCAPS")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string NCAPSCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 79)]
        [System.ComponentModel.DescriptionAttribute("EC indicator")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string ECIndicatorCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 80)]
        [System.ComponentModel.DescriptionAttribute("IC indicator")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string ICIndicatorCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 81)]
        [System.ComponentModel.DescriptionAttribute("CA 725 indicator")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string CA725IndicatorCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 82)]
        [System.ComponentModel.DescriptionAttribute("CA 750 indicator")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string CA750IndicatorCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 83)]
        [System.ComponentModel.DescriptionAttribute("Operating TSDF")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(6)]
        public string OperatingTSDFCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 84)]
        [System.ComponentModel.DescriptionAttribute("Full enforcement")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(6)]
        public string FullEnforcementCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 85)]
        [System.ComponentModel.DescriptionAttribute("SNC")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string SNCCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 86)]
        [System.ComponentModel.DescriptionAttribute("BOY SNC")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string BOYSNCCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 87)]
        [System.ComponentModel.DescriptionAttribute("BOY state unaddressed SNC")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string BOYStateUnaddressedSNCCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 88)]
        [System.ComponentModel.DescriptionAttribute("State unaddressed")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string StateUnaddressedCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 89)]
        [System.ComponentModel.DescriptionAttribute("State addressed")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string StateAddressedCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 90)]
        [System.ComponentModel.DescriptionAttribute("BOY state addressed")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string BOYStateAddressedCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 91)]
        [System.ComponentModel.DescriptionAttribute("State SNC with comp sched")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string StateSNCWithCompSchedCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 92)]
        [System.ComponentModel.DescriptionAttribute("BOY state SNC with comp sched")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string BOYStateSNCWithCompSchedCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 93)]
        [System.ComponentModel.DescriptionAttribute("EPA unaddressed")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string EPAUnaddressedCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 94)]
        [System.ComponentModel.DescriptionAttribute("BOY EPA unaddressed")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string BOYEPAUnaddressedCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 95)]
        [System.ComponentModel.DescriptionAttribute("EPA addressed")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string EPAAddressedCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 96)]
        [System.ComponentModel.DescriptionAttribute("BOY EPA addressed")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string BOYEPAAddressedCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 97)]
        [System.ComponentModel.DescriptionAttribute("EPA SNC with comp sched")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string EPASNCWithcompSchedCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 98)]
        [System.ComponentModel.DescriptionAttribute("BOY EPA SNC with comp sched")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string BOYEPASNCWithcompSchedCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 99)]
        [System.ComponentModel.DescriptionAttribute("FA required")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(5)]
        public string FARequiredCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 100)]
        [System.ComponentModel.DescriptionAttribute("HHandler last change date")]
        public System.DateTime HHandlerLastChangeDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool HHandlerLastChangeDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 101)]
        [System.ComponentModel.DescriptionAttribute("Notes")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4000)]
        public string PublicNotesCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 102)]
        [System.ComponentModel.DescriptionAttribute("Notes")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4000)]
        public string NotesCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 103)]
        [System.ComponentModel.DescriptionAttribute("Indicates that the Handler is participating in Import Trading activity. Possible " +
            "values are: Y/N")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string RecognizedTraderImporterIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 104)]
        [System.ComponentModel.DescriptionAttribute("Indicates that the Handler is participating in Export Trading activity. Possible " +
            "values are: Y/N")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string RecognizedTraderExporterIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 105)]
        [System.ComponentModel.DescriptionAttribute("Indicates that the Handler is participating in Slab Import activity. Possible val" +
            "ues are: Y/N")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string SlabImporterIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 106)]
        [System.ComponentModel.DescriptionAttribute("Indicates that the Handler is participating in Slab Export activity. Possible val" +
            "ues are: Y/N")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string SlabExporterIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 107)]
        [System.ComponentModel.DescriptionAttribute("Recycle non storage")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string RecyclerNonStorageIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 108)]
        [System.ComponentModel.DescriptionAttribute("Manifest broker")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string ManifestBrokerIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 109)]
        [System.ComponentModel.DescriptionAttribute("Subpart P code")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string SubpartPIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 110)]
        [System.ComponentModel.DescriptionAttribute("Latitude data type")]
        public decimal LocationLatitude;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LocationLatitudeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 111)]
        [System.ComponentModel.DescriptionAttribute("Longitude data type")]
        public decimal LocationLongitude;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LocationLongitudeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 112)]
        [System.ComponentModel.DescriptionAttribute("Location GIS primary.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string LocationGisPrimary;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 113)]
        [System.ComponentModel.DescriptionAttribute("Location GIS data original source.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(2)]
        public string LocationGisOrig;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("HazardousWasteReportUniv", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class HazardousWasteReportUnivDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing whether the data are public or private.")]
        public string DataAccessText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ReportUnivs", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("This is the root element for this flow XML Schema.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public ReportUnivSubmission[] ReportUnivs;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("ReportUniv", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class ReportUnivSubmission
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ReportUniv", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("All information about the ReportUniv.")]
        public ReportUniv[] ReportUniv;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("ManifestHandlerSite", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class ManifestHandler
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Emanifest site type.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(11)]
        public SiteType SiteType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("EPA site id.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(15)]
        public string EpaSiteId;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Name description.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(80)]
        public string EmanifestName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Mailing address.")]
        public EmanifestMailingAddress EmanifestMailingAddress;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Site address.")]
        public EmanifestMailingAddress SiteAddress;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Contact information.")]
        public ManifestContact ManifestContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Emergency phone information.")]
        public EmergencyPhone EmergencyPhone;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Paper signature information.")]
        public PaperSignatureInfo PaperSignatureInfo;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Electronic signature information.")]
        public ElectronicSignatureInfo ElectronicSignatureInfo;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 9)]
        [System.ComponentModel.DescriptionAttribute("Order type.")]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string Order;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("Registered indicator.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string Registered;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("Modified indicator.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string Modified;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("SiteType", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public enum SiteType
    {

        /// <remarks/>
        Tsdf,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Generator information")]
        Generator,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Transporter list")]
        Transporter,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("EmanifestMailingAddress", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class EmanifestMailingAddress
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Identifies street number in address.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(12)]
        public string StreetNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Identifies address1.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(50)]
        public string Address1;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Identifies address2.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(50)]
        public string Address2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Identifies city in address.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(25)]
        public string City;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Identifies country in address.")]
        public Country Country;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Identifies state in address.")]
        public Country ManifestState;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Identifies zip in address.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(14)]
        public string Zip;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("Country", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class Country
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Locality code")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(2)]
        public string ManifestLocalityCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Locality name")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(100)]
        public string ManifestLocalityName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("ManifestContact", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class ManifestContact
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Identifies frist name in contact.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(38)]
        public string ManifestFirstName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Identifies middle initial in contact.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string ManifestMiddleInitial;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Identifies last name in contact.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(38)]
        public string ManifestLastName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Identifies phone in contact.")]
        public EmergencyPhone Phone;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Identifies email in contact.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(80)]
        public string Email;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Identifies company name in contact.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(80)]
        public string CompanyName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("EmergencyPhone", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class EmergencyPhone
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Identifies phone number")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(15)]
        public string PhoneNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Identifies phone extension.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(6)]
        public string PhoneExtension;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("PaperSignatureInfo", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class PaperSignatureInfo
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Identifies printed name")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(80)]
        public string PrintedName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Identifies paper signature date")]
        public System.DateTime PaperSignatureDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PaperSignatureDateSpecified;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("ElectronicSignatureInfo", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class ElectronicSignatureInfo
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Identifies a signer")]
        public Signer Signer;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Identifies electronic signature date")]
        public System.DateTime ElectronicSignatureDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ElectronicSignatureDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Identifies a readable document")]
        public HumanReadableDocument HumanReadableDocument;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Cromerr activity Id")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(50)]
        public string CromerrActivityId;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Cromerr document Id")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(50)]
        public string CromerrDocumentId;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("Signer", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class Signer
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Identifies frist name in contact.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(38)]
        public string ManifestFirstName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Identifies last name in contact.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(38)]
        public string ManifestLastName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Identifies a user id")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(255)]
        public string SignerUserId;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("HumanReadableDocument", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class HumanReadableDocument
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Identifies document name")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(255)]
        public string DocumentName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Identifies a size")]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string Size;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Identifies a mime type")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(50)]
        public string MimeType;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("ImportGenerator", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class ImportGenerator
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Import generator name")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(80)]
        public string ImportGeneratorName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Import generator address")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(50)]
        public string ImportGeneratorAddress;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Identifies city in address.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(100)]
        public string ImportCity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Identifies country in address.")]
        public Country Country;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Identifies postal code in address.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(25)]
        public string PostalCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Import generator province")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(50)]
        public string Province;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("ImportPortInfo", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class ImportPortInfo
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Identifies city in address.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(100)]
        public string ImportCity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Identifies state in address.")]
        public Country ManifestState;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("Comment", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class AdditionalComment
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Comment description")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4000)]
        public string CommentDescription;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Comment handler Id")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(15)]
        public string HandlerId;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Comment label")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(255)]
        public string CommentLabel;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("ManifestWaste", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class Waste
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Hazardous indicator.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string DotHazardous;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("DOT information.")]
        public DotInformation DotInformation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Waste description.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(500)]
        public string WastesDescription;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Quantity.")]
        public Quantity Quantity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("BR indicator.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string Br;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("BR information.")]
        public BrInfo BrInfo;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Hazardous waste information.")]
        public HazardousWaste HazardousWaste;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("PCB indicator.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string Pcb;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PcbInfo", Order = 8)]
        [System.ComponentModel.DescriptionAttribute("PCB information.")]
        public PcbInfo[] PcbInfo;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("Discrepancy residue information.")]
        public DiscrepancyResidueInfo DiscrepancyResidueInfo;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("Management method information.")]
        public ManagementMethod ManagementMethod;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AdditionalInfo", Order = 11)]
        [System.ComponentModel.DescriptionAttribute("Additional information")]
        public AdditionalInfo WasteAdditionalInfo;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 12)]
        [System.ComponentModel.DescriptionAttribute("Line number.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string LineNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [System.ComponentModel.DescriptionAttribute("Indicate if it\'s a waste")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string EpaWaste;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("DotInformation", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class DotInformation
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Id number information")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(255)]
        public string IdNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Printed DOT information")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(500)]
        public string PrintedDotInformation;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("Quantity", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class Quantity
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Container number information")]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string ContainerNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Quantity Valure information")]
        public decimal QuantityVal;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool QuantityValSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Container type information")]
        public ContainerType ContainerType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Quantity Unit of measurement information")]
        public QuantityUnitOfMeasurement QuantityUnitOfMeasurement;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("ContainerType", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class ContainerType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Code information")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(255)]
        public string Code;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Description information")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(255)]
        public string ManifestDescription;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("QuantityUnitOfMeasurement", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class QuantityUnitOfMeasurement
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Quantity UOM Code information")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public QuantityUOMCode QuantityUOMCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Quantity UOM description information")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(28)]
        public QuantityUOMDescription QuantityUOMDescription;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool QuantityUOMDescriptionSpecified;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("QuantityUOMCode", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public enum QuantityUOMCode
    {

        /// <remarks/>
        P,

        /// <remarks/>
        T,

        /// <remarks/>
        K,

        /// <remarks/>
        M,

        /// <remarks/>
        G,

        /// <remarks/>
        L,

        /// <remarks/>
        Y,

        /// <remarks/>
        N,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("QuantityUOMDescription", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public enum QuantityUOMDescription
    {

        /// <remarks/>
        Pounds,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Tons (2000 Pounds)")]
        Tons2000Pounds,

        /// <remarks/>
        Kilograms,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Metric Tons (1000 Kilograms)")]
        MetricTons1000Kilograms,

        /// <remarks/>
        Gallons,

        /// <remarks/>
        Liters,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Cubic Yards")]
        CubicYards,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Cubic Meters")]
        CubicMeters,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("BrInfo", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class BrInfo
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("BR density information")]
        public decimal Density;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DensitySpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("BR density unit of measurement information")]
        public DensityUnitOfMeasurement DensityUnitOfMeasurement;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("BR form code information")]
        public BrFormCode BrFormCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("BR source code information")]
        public BrSourceCode BrSourceCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Waste minimization description information")]
        public WasteMinimizationCode WasteMinimizationCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("DensityUnitOfMeasurement", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class DensityUnitOfMeasurement
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Quantity UOM Code information")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string UOMCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Quantity UOM description information")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(240)]
        public string UOMDescription;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("BrFormCode", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class BrFormCode
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Form code information")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4)]
        public string FormCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Form description information")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(240)]
        public string FormDescription;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("BrSourceCode", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class BrSourceCode
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Source code information")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(3)]
        public string SourceCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Source description information")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(240)]
        public string SourceDescription;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("WasteMinimizationCode", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class WasteMinimizationCode
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Waste minimization code information")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(1)]
        public string WMCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Waste minimization description information")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(240)]
        public string WMDescription;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("HazardousWaste", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class HazardousWaste
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FederalWasteCode", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Federal waste codes information")]
        public FederalWasteCode[] FederalWasteCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TsdfStateWasteCode", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Tsdf state waste codes information")]
        public FederalWasteCode[] TsdfStateWasteCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TxWasteCode", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("TX waste codes information")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(8)]
        public string[] TxWasteCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("GeneratorStateWasteCode", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Generator state waste codes information")]
        public FederalWasteCode[] GeneratorStateWasteCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("FederalWasteCode", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class FederalWasteCode
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Manifest waste code information")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(6)]
        public string ManifestWasteCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Manifest waste description information")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(2000)]
        public string ManifestWasteDescription;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("PcbInfo", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class PcbInfo
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Load type information")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(255)]
        public string LoadType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Article container Id")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(255)]
        public string ArticleContainerId;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Date of removal")]
        public System.DateTime DateOfRemoval;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DateOfRemovalSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Weight information")]
        public decimal Weight;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool WeightSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Waste type information")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(255)]
        public string WasteType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Bulk identity information")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(255)]
        public string BulkIdentity;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("DiscrepancyResidueInfo", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class DiscrepancyResidueInfo
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Indicate waste quantity")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string WasteQuantity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Indicate waste type")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string HasWasteType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Discrepancy comments information")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(255)]
        public string DiscrepancyComments;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Indicate residue information")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string Residue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Residue comments information")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(255)]
        public string ResidueComments;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("ManagementMethod", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class ManagementMethod
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Management method code information")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4)]
        public string ManagementMethodCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Management method description information")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(240)]
        public string ManagementMethodDescription;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("AdditionalInfo", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class AdditionalInfo
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OriginalManifestTrackingNumber", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Original Manifest Tracking Number list")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(12)]
        public string[] OriginalManifestTrackingNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("New Mmnifest destination")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(255)]
        public string NewManifestDestination;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Identifies a consent number")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(255)]
        public string ConsentNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AdditionalComment", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Comment list")]
        public AdditionalComment[] AdditionalComment;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Identifies a handling instructions")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4000)]
        public string HandlingInstructions;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("Emanifest", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class Emanifests
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Created date")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public System.DateTime CreatedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Updated date")]
        public System.DateTime UpdatedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool UpdatedDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Manifest tracking number")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(12)]
        public string ManifestTrackingNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Manifest status")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(17)]
        public Status Status;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Is public indicator")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string IsPublic;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Submission type")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(14)]
        public SubmissionType SubmissionType;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SubmissionTypeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Signature status")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string SignatureStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Original type")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(7)]
        public OriginType OriginType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Shipped date")]
        public System.DateTime ShippedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ShippedDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("Received date")]
        public System.DateTime ReceivedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ReceivedDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("Certified date")]
        public System.DateTime CertifiedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CertifiedDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("Certified person name and id")]
        public Signer CertifiedBy;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("Generator information")]
        public ManifestHandler Generator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Transporter", Order = 13)]
        [System.ComponentModel.DescriptionAttribute("Transporter list")]
        public ManifestHandler[] Transporter;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [System.ComponentModel.DescriptionAttribute("Designated facility")]
        public ManifestHandler DesignatedFacility;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Waste", Order = 15)]
        [System.ComponentModel.DescriptionAttribute("Wastes information")]
        public Waste[] Waste;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [System.ComponentModel.DescriptionAttribute("Rejection indicator")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string Rejection;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [System.ComponentModel.DescriptionAttribute("Reject information")]
        public RejectionInfo RejectionInfo;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [System.ComponentModel.DescriptionAttribute("Discrepancy indicator")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string Discrepancy;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        [System.ComponentModel.DescriptionAttribute("Indicate residue information")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string Residue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ResidueNewManifestTrackingNumber", Order = 20)]
        [System.ComponentModel.DescriptionAttribute("Residue new manifest tracking numbers list")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(12)]
        public string[] ResidueNewManifestTrackingNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        [System.ComponentModel.DescriptionAttribute("Import indicator")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string Import;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        [System.ComponentModel.DescriptionAttribute("Import information")]
        public ImportInfo ImportInfo;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 23)]
        [System.ComponentModel.DescriptionAttribute("Original manifest tracking number")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string ContainsPreviousRejectOrResidue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 24)]
        [System.ComponentModel.DescriptionAttribute("Printed document")]
        public HumanReadableDocument PrintedDocument;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 25)]
        [System.ComponentModel.DescriptionAttribute("Form document")]
        public HumanReadableDocument FormDocument;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AdditionalInfo", Order = 26)]
        [System.ComponentModel.DescriptionAttribute("Additional information")]
        public AdditionalInfo EmanifestsAdditionalInfo;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 27)]
        [System.ComponentModel.DescriptionAttribute("Correction information")]
        public CorrectionInfo CorrectionInfo;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("Status", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public enum Status
    {

        /// <remarks/>
        NotSelected,

        /// <remarks/>
        Pending,

        /// <remarks/>
        Scheduled,

        /// <remarks/>
        InTransit,

        /// <remarks/>
        ReadyForSignature,

        /// <remarks/>
        Signed,

        /// <remarks/>
        Corrected,

        /// <remarks/>
        UnderCorrection,

        /// <remarks/>
        NotAssigned,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("SubmissionType", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public enum SubmissionType
    {

        /// <remarks/>
        FullElectronic,

        /// <remarks/>
        DataImage5Copy,

        /// <remarks/>
        Hybrid,

        /// <remarks/>
        Image,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("OriginType", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public enum OriginType
    {

        /// <remarks/>
        Web,

        /// <remarks/>
        Service,

        /// <remarks/>
        Mail,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("RejectionInfo", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class RejectionInfo
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Indicates if transporter is on site")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string TransporterOnSite;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Rejection type")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(13)]
        public RejectionType RejectionType;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RejectionTypeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Alternate designated facility type")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(9)]
        public AlternateDesignatedFacilityType AlternateDesignatedFacilityType;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AlternateDesignatedFacilityTypeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Generator paper signature info")]
        public PaperSignatureInfo GeneratorPaperSignature;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Generator electronic signature info")]
        public ElectronicSignatureInfo GeneratorElectronicSignature;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Alternate designated facility")]
        public ManifestHandler AlternateDesignatedFacility;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NewManifestTrackingNumber", Order = 6)]
        [System.ComponentModel.DescriptionAttribute("New Manifest Tracking Number")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(12)]
        public string[] NewManifestTrackingNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Rejection comments")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(255)]
        public string RejectionComments;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("RejectionType", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public enum RejectionType
    {

        /// <remarks/>
        FullReject,

        /// <remarks/>
        PartialReject,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("AlternateDesignatedFacilityType", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public enum AlternateDesignatedFacilityType
    {

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Generator information")]
        Generator,

        /// <remarks/>
        Tsdf,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("ImportInfo", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class ImportInfo
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Import generator information.")]
        public ImportGenerator ImportGenerator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Import generator information.")]
        public ImportPortInfo ImportPortInfo;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("CorrectionInfo", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class CorrectionInfo
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Correction version number")]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string VersionNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Correction active flag")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string Active;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ElectronicSignatureInfo", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Electronic signature information.")]
        public ElectronicSignatureInfo CorrectionElectronicSignatureInfo;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("EPA site id.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(15)]
        public string EpaSiteId;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("HazardousWasteEmanifests", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class HazardousWasteEmanifestsDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Emanifests", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("This is the root element for emanifest XML Schema.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public EmanifestsDataType[] Emanifests;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("Emanifests", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class EmanifestsDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Emanifest", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("All information about the Emanifest.")]
        public Emanifests[] Emanifest;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml")]
    [System.Xml.Serialization.XmlRootAttribute("pos", Namespace = "http://www.opengis.net/gml", IsNullable = false)]
    public partial class DirectPositionType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        [System.ComponentModel.DescriptionAttribute("Name or number assigned by the implementing agency to identify a corrective actio" +
            "n area.")]
        public string srsName;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "positiveInteger")]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public string srsDimension;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        //TSM: public double[] Text;
        public string Text;
    }

    /// <remarks/>
    //TSM: Only point type supported for now
    //[System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractSurfaceType))]
    //[System.Xml.Serialization.XmlIncludeAttribute(typeof(PolygonType))]
    //[System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractCurveType))]
    //[System.Xml.Serialization.XmlIncludeAttribute(typeof(LineStringType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PointType))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml")]
    [System.Xml.Serialization.XmlRootAttribute("_GeometricPrimitive", Namespace = "http://www.opengis.net/gml", IsNullable = false)]
    public abstract partial class AbstractGeometricPrimitiveType : AbstractGeometryType
    {
    }

    /// <remarks/>
    //TSM: Only point type supported for now
    //[System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractRingType))]
    //[System.Xml.Serialization.XmlIncludeAttribute(typeof(LinearRingType))]
    //[System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractGeometricPrimitiveType))]
    //[System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractSurfaceType))]
    //[System.Xml.Serialization.XmlIncludeAttribute(typeof(PolygonType))]
    //[System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractCurveType))]
    //[System.Xml.Serialization.XmlIncludeAttribute(typeof(LineStringType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PointType))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml")]
    [System.Xml.Serialization.XmlRootAttribute("_Geometry", Namespace = "http://www.opengis.net/gml", IsNullable = false)]
    public abstract partial class AbstractGeometryType : AbstractGMLType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        [System.ComponentModel.DescriptionAttribute("Name or number assigned by the implementing agency to identify a corrective actio" +
            "n area.")]
        public string srsName;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "positiveInteger")]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public string srsDimension;
    }

    /// <remarks/>
    //TSM: Only point type supported for now
    //[System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractFeatureType))]
    //[System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractFeatureCollectionType))]
    //[System.Xml.Serialization.XmlIncludeAttribute(typeof(FeatureCollectionType))]
    //[System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractGeometryType))]
    //[System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractRingType))]
    //[System.Xml.Serialization.XmlIncludeAttribute(typeof(LinearRingType))]
    //[System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractGeometricPrimitiveType))]
    //[System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractSurfaceType))]
    //[System.Xml.Serialization.XmlIncludeAttribute(typeof(PolygonType))]
    //[System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractCurveType))]
    //[System.Xml.Serialization.XmlIncludeAttribute(typeof(LineStringType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PointType))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml")]
    [System.Xml.Serialization.XmlRootAttribute("_GML", Namespace = "http://www.opengis.net/gml", IsNullable = false)]
    public abstract partial class AbstractGMLType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, DataType = "ID")]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public string id;
    }












    ///// <remarks/>
    //[System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/gml")]
    //[System.Xml.Serialization.XmlRootAttribute("LineString", Namespace="http://www.opengis.net/gml", IsNullable=false)]
    //public partial class LineStringType : AbstractCurveType {

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("posList", Order=0)]
    //    public Item Item;
    //}

    ///// <remarks/>
    //[System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/gml")]
    //[System.Xml.Serialization.XmlRootAttribute("CircleByCenterPoint", Namespace="http://www.opengis.net/gml", IsNullable=false)]
    //public partial class CircleByCenterPointType : ArcByCenterPointType {
    //}

    ///// <remarks/>
    //[System.Xml.Serialization.XmlIncludeAttribute(typeof(CircleByCenterPointType))]
    //[System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/gml")]
    //[System.Xml.Serialization.XmlRootAttribute("ArcByCenterPoint", Namespace="http://www.opengis.net/gml", IsNullable=false)]
    //public partial class ArcByCenterPointType : AbstractCurveSegmentType {

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("pos", Order=0)]
    //    public Item Item;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order=1)]
    //    [System.ComponentModel.DescriptionAttribute("Additional georss property indicating the radius or buffer about the accompanying" +
    //        " geometric property which represents the referenced geographic entity.")]
    //    public radius radius;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlAttributeAttribute()]
    //    public interpolation interpolation;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlIgnoreAttribute()]
    //    public bool interpolationSpecified;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlAttributeAttribute(DataType="integer")]
    //    public string numArc;

    //    public ArcByCenterPointType() {
    //        this.interpolation = CurveInterpolationType.circularArcCenterPointWithRadius;
    //        this.numArc = "1";
    //    }
    //}

    ///// <remarks/>
    //[System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/gml")]
    //[System.Xml.Serialization.XmlRootAttribute("pos", Namespace="http://www.opengis.net/gml", IsNullable=false)]
    //public partial class Item {

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlAttributeAttribute(DataType="anyURI")]
    //    public string srsName;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlAttributeAttribute(DataType="positiveInteger")]
    //    public string srsDimension;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlTextAttribute()]
    //    public double[] Text;
    //}

    ///// <remarks/>
    //[System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/gml")]
    //public partial class radius : MeasureType {
    //}

    ///// <remarks/>
    //[System.Xml.Serialization.XmlIncludeAttribute(typeof(LengthType))]
    //[System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/gml")]
    //public partial class MeasureType {

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlAttributeAttribute(DataType="anyURI")]
    //    public string uom;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlTextAttribute()]
    //    public double Value;
    //}

    ///// <remarks/>
    //[System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/gml")]
    //public enum interpolation {

    //    /// <remarks/>
    //    linear,

    //    /// <remarks/>
    //    geodesic,

    //    /// <remarks/>
    //    circularArc3Points,

    //    /// <remarks/>
    //    circularArc2PointWithBulge,

    //    /// <remarks/>
    //    circularArcCenterPointWithRadius,

    //    /// <remarks/>
    //    elliptical,

    //    /// <remarks/>
    //    clothoid,

    //    /// <remarks/>
    //    conic,

    //    /// <remarks/>
    //    polynomialSpline,

    //    /// <remarks/>
    //    cubicSpline,

    //    /// <remarks/>
    //    rationalSpline,
    //}

    ///// <remarks/>
    //[System.Xml.Serialization.XmlIncludeAttribute(typeof(ArcByCenterPointType))]
    //[System.Xml.Serialization.XmlIncludeAttribute(typeof(CircleByCenterPointType))]
    //[System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/gml")]
    //[System.Xml.Serialization.XmlRootAttribute("_CurveSegment", Namespace="http://www.opengis.net/gml", IsNullable=false)]
    //public abstract partial class AbstractCurveSegmentType {
    //}

    ///// <remarks/>
    //[System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/gml")]
    //[System.Xml.Serialization.XmlRootAttribute("Envelope", Namespace="http://www.opengis.net/gml", IsNullable=false)]
    //public partial class Item {

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("lowerCorner", typeof(DirectPositionType), Order=0)]
    //    [System.Xml.Serialization.XmlElementAttribute("upperCorner", typeof(DirectPositionType), Order=0)]
    //    [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
    //    public Item[] Items;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("ItemsElementName", Order=1)]
    //    [System.Xml.Serialization.XmlIgnoreAttribute()]
    //    public ItemsElementName[] ItemsElementName;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlAttributeAttribute(DataType="anyURI")]
    //    public string srsName;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlAttributeAttribute(DataType="positiveInteger")]
    //    public string srsDimension;
    //}

    ///// <remarks/>
    //[System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/gml", IncludeInSchema=false)]
    //public enum ItemsElementName {

    //    /// <remarks/>
    //    lowerCorner,

    //    /// <remarks/>
    //    upperCorner,
    //}

    ///// <remarks/>
    //[System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/gml")]
    //[System.Xml.Serialization.XmlRootAttribute("posList", Namespace="http://www.opengis.net/gml", IsNullable=false)]
    //public partial class Item {

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlAttributeAttribute(DataType="anyURI")]
    //    public string srsName;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlAttributeAttribute(DataType="positiveInteger")]
    //    public string srsDimension;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlAttributeAttribute(DataType="positiveInteger")]
    //    public string count;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlTextAttribute()]
    //    public double[] Text;
    //}

    ///// <remarks/>
    //[System.Xml.Serialization.XmlIncludeAttribute(typeof(LineStringType))]
    //[System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/gml")]
    //[System.Xml.Serialization.XmlRootAttribute("_Curve", Namespace="http://www.opengis.net/gml", IsNullable=false)]
    //public abstract partial class AbstractCurveType : AbstractGeometricPrimitiveType {
    //}

    ///// <remarks/>
    //[System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractFeatureCollectionType))]
    //[System.Xml.Serialization.XmlIncludeAttribute(typeof(FeatureCollectionType))]
    //[System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/gml")]
    //[System.Xml.Serialization.XmlRootAttribute("_Feature", Namespace="http://www.opengis.net/gml", IsNullable=false)]
    //public abstract partial class AbstractFeatureType : AbstractGMLType {

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order=0)]
    //    public boundedBy boundedBy;
    //}

    ///// <remarks/>
    //[System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/gml")]
    //[System.Xml.Serialization.XmlRootAttribute("boundedBy", Namespace="http://www.opengis.net/gml", IsNullable=false)]
    //public partial class boundedBy {

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("Envelope", Order=0)]
    //    public Item Item;
    //}

    ///// <remarks/>
    //[System.Xml.Serialization.XmlIncludeAttribute(typeof(FeatureCollectionType))]
    //[System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/gml")]
    //[System.Xml.Serialization.XmlRootAttribute("_FeatureCollection", Namespace="http://www.opengis.net/gml", IsNullable=false)]
    //public abstract partial class AbstractFeatureCollectionType : AbstractFeatureType {

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("featureMember", Order=0)]
    //    public featureMember[] featureMember;
    //}

    ///// <remarks/>
    //[System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/gml")]
    //[System.Xml.Serialization.XmlRootAttribute("featureMember", Namespace="http://www.opengis.net/gml", IsNullable=false)]
    //public partial class featureMember {

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("FeatureCollection", Order=0)]
    //    public Item Item;
    //}

    ///// <remarks/>
    //[System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/gml")]
    //[System.Xml.Serialization.XmlRootAttribute("FeatureCollection", Namespace="http://www.opengis.net/gml", IsNullable=false)]
    //public partial class Item : AbstractFeatureCollectionType {
    //}

    ///// <remarks/>
    //[System.Xml.Serialization.XmlIncludeAttribute(typeof(LinearRingType))]
    //[System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/gml")]
    //[System.Xml.Serialization.XmlRootAttribute("_Ring", Namespace="http://www.opengis.net/gml", IsNullable=false)]
    //public abstract partial class AbstractRingType : AbstractGeometryType {
    //}

    ///// <remarks/>
    //[System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/gml")]
    //[System.Xml.Serialization.XmlRootAttribute("LinearRing", Namespace="http://www.opengis.net/gml", IsNullable=false)]
    //public partial class Item : AbstractRingType {

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("posList", Order=0)]
    //    public Item Item;
    //}

    ///// <remarks/>
    //[System.Xml.Serialization.XmlIncludeAttribute(typeof(PolygonType))]
    //[System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/gml")]
    //[System.Xml.Serialization.XmlRootAttribute("_Surface", Namespace="http://www.opengis.net/gml", IsNullable=false)]
    //public partial class AbstractSurfaceType : AbstractGeometricPrimitiveType {
    //}

    ///// <remarks/>
    //[System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/gml")]
    //[System.Xml.Serialization.XmlRootAttribute("Polygon", Namespace="http://www.opengis.net/gml", IsNullable=false)]
    //public partial class PolygonType : AbstractSurfaceType {

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order=0)]
    //    [System.ComponentModel.DescriptionAttribute(@"A boundary of a surface consists of a number of rings. In the normal 2D case, one of these rings is distinguished as being the exterior boundary. In a general manifold this is not always possible, in which case all boundaries shall be listed as interior boundaries, and the exterior will be empty.")]
    //    public exterior exterior;
    //}

    ///// <remarks/>
    //[System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/gml")]
    //[System.Xml.Serialization.XmlRootAttribute("exterior", Namespace="http://www.opengis.net/gml", IsNullable=false)]
    //public partial class exterior {

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("LinearRing", Order=0)]
    //    public Item Item;
    //}

    ///// <remarks/>
    //[System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/gml")]
    //[System.Xml.Serialization.XmlRootAttribute("Point", Namespace="http://www.opengis.net/gml", IsNullable=false)]
    //public partial class PointType : AbstractGeometricPrimitiveType {

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("pos", Order=0)]
    //    public Item Item;
    //}

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("EpisodicProject", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class EpisodicProjectDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(1)]
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Project code owner of the episodic project.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(2)]
        public string EpisodicProjectCodeOwner;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Project code of the episodic project.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbFixedColumnSizeAttribute(3)]
        public string EpisodicProjectCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Other project description.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(255)]
        public string OtherProjectDescription;
    }
}
