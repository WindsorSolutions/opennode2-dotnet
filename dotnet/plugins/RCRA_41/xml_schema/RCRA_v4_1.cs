namespace Windsor.Node2008.WNOSPlugin.RCRA_41 {
    
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.exchangenetwork.net/schema/RCRA/4")]
    [System.Xml.Serialization.XmlRootAttribute("CSNYDate", Namespace="http://www.exchangenetwork.net/schema/RCRA/4", IsNullable=false)]
    public partial class CSNYDateDataType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        public string TransactionCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=1)]
        [System.ComponentModel.DescriptionAttribute("Date of the SNY that the Action is Addressing")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public System.DateTime SNYDate;
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.exchangenetwork.net/schema/RCRA/4")]
    [System.Xml.Serialization.XmlRootAttribute("Payment", Namespace="http://www.exchangenetwork.net/schema/RCRA/4", IsNullable=false)]
    public partial class PaymentDataType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        public string TransactionCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="integer", Order=1)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string PaymentSequenceNumber;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=2)]
        public System.DateTime PaymentDefaultedDate;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PaymentDefaultedDateSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=3)]
        public System.DateTime ScheduledPaymentDate;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ScheduledPaymentDateSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public decimal ScheduledPaymentAmount;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ScheduledPaymentAmountSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=5)]
        public System.DateTime ActualPaymentDate;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ActualPaymentDateSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        [System.ComponentModel.DescriptionAttribute("The dollar amount of any cost recovery required to be paid pursuant to a Final Or" +
            "der.")]
        public decimal ActualPaidAmount;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ActualPaidAmountSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string Notes;
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.exchangenetwork.net/schema/RCRA/4")]
    [System.Xml.Serialization.XmlRootAttribute("Penalty", Namespace="http://www.exchangenetwork.net/schema/RCRA/4", IsNullable=false)]
    public partial class PenaltyDataType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        public string TransactionCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the penalty type")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string PenaltyTypeOwner;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [System.ComponentModel.DescriptionAttribute("Code which indicates the type of penalty associated with the penalty amount.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string PenaltyType;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        [System.ComponentModel.DescriptionAttribute("The dollar amount of any proposed cash civil penalty set forth in a Complaint/Pro" +
            "posed Order.")]
        public decimal CashCivilPenaltySoughtAmount;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CashCivilPenaltySoughtAmountSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string Notes;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Payment", Order=5)]
        [System.ComponentModel.DescriptionAttribute("Compliance Monitoring and Enforcement Payment Data")]
        public PaymentDataType[] Payment;
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.exchangenetwork.net/schema/RCRA/4")]
    [System.Xml.Serialization.XmlRootAttribute("Milestone", Namespace="http://www.exchangenetwork.net/schema/RCRA/4", IsNullable=false)]
    public partial class MilestoneDataType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        public string TransactionCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="integer", Order=1)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string MilestoneSequenceNumber;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string TechnicalRequirementIdentifier;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string TechnicalRequirementDescription;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=4)]
        public System.DateTime MilestoneScheduledCompletionDate;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MilestoneScheduledCompletionDateSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=5)]
        public System.DateTime MilestoneActualCompletionDate;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MilestoneActualCompletionDateSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=6)]
        public System.DateTime MilestoneDefaultedDate;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MilestoneDefaultedDateSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string Notes;
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.exchangenetwork.net/schema/RCRA/4")]
    [System.Xml.Serialization.XmlRootAttribute("ViolationEnforcement", Namespace="http://www.exchangenetwork.net/schema/RCRA/4", IsNullable=false)]
    public partial class ViolationEnforcementDataType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        public string TransactionCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="integer", Order=1)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ViolationSequenceNumber;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string AgencyWhichDeterminedViolation;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=3)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.exchangenetwork.net/schema/RCRA/4")]
    [System.Xml.Serialization.XmlRootAttribute("SupplementalEnvironmentalProject", Namespace="http://www.exchangenetwork.net/schema/RCRA/4", IsNullable=false)]
    public partial class SupplementalEnvironmentalProjectDataType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        public string TransactionCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="integer", Order=1)]
        [System.ComponentModel.DescriptionAttribute("SEP Sequence Number allowed value 01-99")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string SEPSequenceNumber;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [System.ComponentModel.DescriptionAttribute("Expenditure Amount")]
        public decimal SEPExpenditureAmount;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SEPExpenditureAmountSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=3)]
        [System.ComponentModel.DescriptionAttribute("Valid date greater than or equal to the Date of Enforcement Action.")]
        public System.DateTime SEPScheduledCompletionDate;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SEPScheduledCompletionDateSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=4)]
        [System.ComponentModel.DescriptionAttribute("SEP actual completion date")]
        public System.DateTime SEPActualDate;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SEPActualDateSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=5)]
        [System.ComponentModel.DescriptionAttribute("Date the SEP defaulted")]
        public System.DateTime SEPDefaultedDate;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SEPDefaultedDateSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        [System.ComponentModel.DescriptionAttribute("State postal code")]
        public string SEPCodeOwner;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        [System.ComponentModel.DescriptionAttribute("The narrative text describing any Supplemental Environmental Projects required to" +
            " be performed pursuant to a Final Order.")]
        public string SEPDescriptionText;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string Notes;
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.exchangenetwork.net/schema/RCRA/4")]
    [System.Xml.Serialization.XmlRootAttribute("Media", Namespace="http://www.exchangenetwork.net/schema/RCRA/4", IsNullable=false)]
    public partial class MediaDataType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        public string TransactionCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the multimedia code.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string MultimediaCodeOwner;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [System.ComponentModel.DescriptionAttribute("Code which indicates the medium or program other than RCRA participating in the e" +
            "nforcement action.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string MultimediaCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string Notes;
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.exchangenetwork.net/schema/RCRA/4")]
    [System.Xml.Serialization.XmlRootAttribute("EnforcementAction", Namespace="http://www.exchangenetwork.net/schema/RCRA/4", IsNullable=false)]
    public partial class EnforcementActionDataType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        public string TransactionCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("The U.S.Postal Service alphabetic code that represents the U.S.State or territory" +
            " in which a state or local government enforcement agency operates.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string EnforcementAgencyLocationName;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [System.ComponentModel.DescriptionAttribute("The unique alphanumeric identifier used in the applicable database to identify a " +
            "specific enforcement action pertaining to a regulated entity or facility.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string EnforcementActionIdentifier;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=3)]
        [System.ComponentModel.DescriptionAttribute("The calendar date the enforcement action was issued or filed.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public System.DateTime EnforcementActionDate;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        [System.ComponentModel.DescriptionAttribute("The full name of the agency, department, or organization that submitted the enfor" +
            "cement action data to EPA.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string EnforcementAgencyName;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        [System.ComponentModel.DescriptionAttribute("Notes the relevant docket number which enforcement staff have assigned for tracki" +
            "ng of enforcement actions.")]
        public string EnforcementDocketNumber;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        [System.ComponentModel.DescriptionAttribute("Identifies the attorney within the agency responsible for issuing the enforcement" +
            " action.")]
        public string EnforcementAttorney;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string CorrectiveActionComponent;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="integer", Order=8)]
        public string ConsentAgreementFinalOrderSequenceNumber;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=9)]
        public System.DateTime AppealInitiatedDate;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AppealInitiatedDateSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=10)]
        public System.DateTime AppealResolutionDate;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AppealResolutionDateSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=11)]
        public System.DateTime DispositionStatusDate;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DispositionStatusDateSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        public string DispositionStatusOwner;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        public string DispositionStatus;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
        [System.ComponentModel.DescriptionAttribute("State Postal Code")]
        public string EnforcementOwner;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=15)]
        [System.ComponentModel.DescriptionAttribute("A code that identifies the type of action being taken against a handler.")]
        public string EnforcementType;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=16)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the person identifier.")]
        public string EnforcementResponsiblePersonOwner;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=17)]
        [System.ComponentModel.DescriptionAttribute("Code indicating the person within the agency responsible for conducting the enfor" +
            "cement.")]
        public string EnforcementResponsiblePersonIdentifier;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=18)]
        public string EnforcementResponsibleSuborganizationOwner;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=19)]
        public string EnforcementResponsibleSuborganization;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=20)]
        public string Notes;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CSNYDate", Order=21)]
        [System.ComponentModel.DescriptionAttribute("Compliance Monitoring and Enforcement Significant Non-Complier Date Data")]
        public CSNYDateDataType[] CSNYDate;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Penalty", Order=22)]
        [System.ComponentModel.DescriptionAttribute("Compliance Monitoring and Enforcement Penalty Data")]
        public PenaltyDataType[] Penalty;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Milestone", Order=23)]
        [System.ComponentModel.DescriptionAttribute("Compliance Monitoring and Enforcement Milestone Data")]
        public MilestoneDataType[] Milestone;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ViolationEnforcement", Order=24)]
        [System.ComponentModel.DescriptionAttribute("Linking Data for Violation and Enforcement")]
        public ViolationEnforcementDataType[] ViolationEnforcement;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SupplementalEnvironmentalProject", Order=25)]
        [System.ComponentModel.DescriptionAttribute("Compliance Monitoring and Enforcement Supplemental Environmental Project Data")]
        public SupplementalEnvironmentalProjectDataType[] SupplementalEnvironmentalProject;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Media", Order=26)]
        [System.ComponentModel.DescriptionAttribute("Compliance Monitoring and Enfocement Multimedia Data")]
        public MediaDataType[] Media;
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.exchangenetwork.net/schema/RCRA/4")]
    [System.Xml.Serialization.XmlRootAttribute("Citation", Namespace="http://www.exchangenetwork.net/schema/RCRA/4", IsNullable=false)]
    public partial class CitationDataType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        public string TransactionCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="integer", Order=1)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string CitationNameSequenceNumber;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [System.ComponentModel.DescriptionAttribute("The citation(s) of the violations alleged.")]
        public string CitationName;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        [System.ComponentModel.DescriptionAttribute("State postal code")]
        public string CitationNameOwner;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        [System.ComponentModel.DescriptionAttribute("Existing nationally defined values: FR, FS, OC, PC,SR,SS,V3")]
        public string CitationNameType;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string Notes;
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.exchangenetwork.net/schema/RCRA/4")]
    [System.Xml.Serialization.XmlRootAttribute("Violation", Namespace="http://www.exchangenetwork.net/schema/RCRA/4", IsNullable=false)]
    public partial class ViolationDataType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        public string TransactionCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ViolationActivityLocation;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="integer", Order=2)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ViolationSequenceNumber;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string AgencyWhichDeterminedViolation;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        [System.ComponentModel.DescriptionAttribute("Allowed value HQ")]
        public string ViolationTypeOwner;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        [System.ComponentModel.DescriptionAttribute("Violation Type")]
        public string ViolationType;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string FormerCitationName;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=7)]
        [System.ComponentModel.DescriptionAttribute("The calendar date the Responsible Authority determines that a regulated entity is" +
            " in violation of a legally enforceable obligation.")]
        public System.DateTime ViolationDeterminedDate;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ViolationDeterminedDateSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=8)]
        [System.ComponentModel.DescriptionAttribute("The calendar date, determined by the Responsible Authority, on which the regulate" +
            "d entity actually returned to compliance with respect to the legal obligation th" +
            "at is the subject of the Violation Determined Date.")]
        public System.DateTime ReturnComplianceActualDate;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ReturnComplianceActualDateSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string ReturnToComplianceQualifier;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string ViolationResponsibleAgency;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public string Notes;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Citation", Order=12)]
        [System.ComponentModel.DescriptionAttribute("Compliance Monitoring and Enforcement Citation Data")]
        public CitationDataType[] Citation;
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.exchangenetwork.net/schema/RCRA/4")]
    [System.Xml.Serialization.XmlRootAttribute("Request", Namespace="http://www.exchangenetwork.net/schema/RCRA/4", IsNullable=false)]
    public partial class RequestDataType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        public string TransactionCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="integer", Order=1)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string RequestSequenceNumber;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=2)]
        public System.DateTime DateOfRequest;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DateOfRequestSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=3)]
        public System.DateTime DateResponseReceived;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DateResponseReceivedSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string RequestAgency;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string Notes;
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.exchangenetwork.net/schema/RCRA/4")]
    [System.Xml.Serialization.XmlRootAttribute("EvaluationCommitment", Namespace="http://www.exchangenetwork.net/schema/RCRA/4", IsNullable=false)]
    public partial class EvaluationCommitmentDataType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        public string TransactionCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string CommitmentLead;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="integer", Order=2)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string CommitmentSequenceNumber;
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.exchangenetwork.net/schema/RCRA/4")]
    [System.Xml.Serialization.XmlRootAttribute("EvaluationViolation", Namespace="http://www.exchangenetwork.net/schema/RCRA/4", IsNullable=false)]
    public partial class EvaluationViolationDataType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        public string TransactionCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ViolationActivityLocation;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="integer", Order=2)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ViolationSequenceNumber;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string AgencyWhichDeterminedViolation;
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.exchangenetwork.net/schema/RCRA/4")]
    [System.Xml.Serialization.XmlRootAttribute("Evaluation", Namespace="http://www.exchangenetwork.net/schema/RCRA/4", IsNullable=false)]
    public partial class EvaluationDataType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        public string TransactionCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Indicates the location of the agency regulating the EPA handler.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string EvaluationActivityLocation;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [System.ComponentModel.DescriptionAttribute("Name or number assigned by the implementing agency to identify an evaluation.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string EvaluationIdentifier;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=3)]
        [System.ComponentModel.DescriptionAttribute("The first day of the inspection or record review regardless of the duration of th" +
            "e inspection.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public System.DateTime EvaluationStartDate;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        [System.ComponentModel.DescriptionAttribute("Code indicating the agency responsible for conducting the evaluation.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string EvaluationResponsibleAgency;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=5)]
        [System.ComponentModel.DescriptionAttribute("Date fo the Last Non-Followup Evaluation (Applies to SNY/SNN Evaluations Only)")]
        public System.DateTime DayZero;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DayZeroSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        [System.ComponentModel.DescriptionAttribute("Flag indicating if a violation was found.")]
        public string FoundViolation;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        [System.ComponentModel.DescriptionAttribute("The inspection or record review was initiated because of a tip/complaint")]
        public string CitizenComplaintIndicator;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string MultimediaIndicator;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string SamplingIndicator;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        [System.ComponentModel.DescriptionAttribute("The inspection conducted pursuant to RCRA 3007 or State equivalent; determiniatio" +
            "n made: sit is Non-Hazardous Waste.")]
        public string NotSubtitleCIndicator;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the type of evaluation.")]
        public string EvaluationTypeOwner;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        [System.ComponentModel.DescriptionAttribute("Code to report the type of evaluation conducted at the handler.")]
        public string EvaluationType;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        public string FocusAreaOwner;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
        public string FocusArea;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=15)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the person identifier.")]
        public string EvaluationResponsiblePersonIdentifierOwner;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=16)]
        [System.ComponentModel.DescriptionAttribute("Code indicating the person within the agency responsible for conducting the evalu" +
            "ation.")]
        public string EvaluationResponsiblePersonIdentifier;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=17)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the suborganization identifier.")]
        public string EvaluationResponsibleSuborganizationOwner;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=18)]
        [System.ComponentModel.DescriptionAttribute("Code indicating the branch/district within the agency responsible for conducting " +
            "the evaluation.")]
        public string EvaluationResponsibleSuborganization;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=19)]
        public string Notes;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Request", Order=20)]
        [System.ComponentModel.DescriptionAttribute("Compliance Monitoring and Enforcement Request Data")]
        public RequestDataType[] Request;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EvaluationCommitment", Order=21)]
        [System.ComponentModel.DescriptionAttribute("Linking Data for Commitment/Initiative and Evaluation.")]
        public EvaluationCommitmentDataType[] EvaluationCommitment;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EvaluationViolation", Order=22)]
        [System.ComponentModel.DescriptionAttribute("Linking Data for Evaluation and Violation")]
        public EvaluationViolationDataType[] EvaluationViolation;
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.exchangenetwork.net/schema/RCRA/4")]
    [System.Xml.Serialization.XmlRootAttribute("HazardousWasteCMESubmission", Namespace="http://www.exchangenetwork.net/schema/RCRA/4", IsNullable=false)]
    public partial class HazardousWasteCMESubmissionDataType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CMEFacilitySubmission", Order=0)]
        [System.ComponentModel.DescriptionAttribute("This contains Hbasic Data")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public CMEFacilitySubmissionDataType[] CMEFacilitySubmission;
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.exchangenetwork.net/schema/RCRA/4")]
    [System.Xml.Serialization.XmlRootAttribute("CMEFacilitySubmission", Namespace="http://www.exchangenetwork.net/schema/RCRA/4", IsNullable=false)]
    public partial class CMEFacilitySubmissionDataType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Number that uniquely identifies the EPA handler.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string EPAHandlerID;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EnforcementAction", Order=1)]
        [System.ComponentModel.DescriptionAttribute("Compliance Monitoring and Enforcement Data")]
        public EnforcementActionDataType[] EnforcementAction;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Evaluation", Order=2)]
        [System.ComponentModel.DescriptionAttribute("Compliance Monitoring and Enforcement Evaluation Data")]
        public EvaluationDataType[] Evaluation;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Violation", Order=3)]
        [System.ComponentModel.DescriptionAttribute("Compliance Monitoring and Enforcement Violation Data")]
        public ViolationDataType[] Violation;
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.exchangenetwork.net/schema/RCRA/4")]
    [System.Xml.Serialization.XmlRootAttribute("OtherID", Namespace="http://www.exchangenetwork.net/schema/RCRA/4", IsNullable=false)]
    public partial class OtherIDDataType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        public string TransactionCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Alternate facility identifier.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string OtherHandlerID;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that owns the Relationship.")]
        public string RelationshipOwnerName;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        [System.ComponentModel.DescriptionAttribute("Indicates the type of the relationship.")]
        public string RelationshipTypeCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        [System.ComponentModel.DescriptionAttribute("Indicates whether the alternate Id references the same facility.")]
        public string SameFacilityIndicator;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        [System.ComponentModel.DescriptionAttribute("Notes regarding the alternative facility identifier.")]
        public string OtherIDSupplementalInformationText;
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.exchangenetwork.net/schema/RCRA/4")]
    [System.Xml.Serialization.XmlRootAttribute("LocationAddress", Namespace="http://www.exchangenetwork.net/schema/RCRA/4", IsNullable=false)]
    public partial class LocationAddressDataType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string LocationAddressText;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string SupplementalLocationText;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string LocalityName;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string StateUSPSCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string CountryName;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string LocationZIPCode;
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.exchangenetwork.net/schema/RCRA/4")]
    [System.Xml.Serialization.XmlRootAttribute("EnvironmentalPermit", Namespace="http://www.exchangenetwork.net/schema/RCRA/4", IsNullable=false)]
    public partial class EnvironmentalPermitDataType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        public string TransactionCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Identification number of an effective environmental permit issued to the handler," +
            " or the number of a filed application for which an environmental permit has not " +
            "yet been issued.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string EnvironmentalPermitID;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the other permit type.")]
        public string EnvironmentalPermitOwnerName;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        [System.ComponentModel.DescriptionAttribute(@"Code indicating the environmental program and/or jurisdictional authority under which an environmental permit was issued to the facility, or under which an application has been filed for which a permit has not yet been issued. This data element is applicable to TSD facilities only.")]
        public string EnvironmentalPermitTypeCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        [System.ComponentModel.DescriptionAttribute("Description of any permit type indicated as O (Other) in the Permit Type field.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string EnvironmentalPermitDescription;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        [System.ComponentModel.DescriptionAttribute("Notes for the handler Environmental Permit.")]
        public string EnvironmentalPermitSupplementalInformationText;
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.exchangenetwork.net/schema/RCRA/4")]
    [System.Xml.Serialization.XmlRootAttribute("Certification", Namespace="http://www.exchangenetwork.net/schema/RCRA/4", IsNullable=false)]
    public partial class CertificationDataType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        public string TransactionCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="integer", Order=1)]
        [System.ComponentModel.DescriptionAttribute("Sequence number for each certification for the handler.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string CertificationSequenceNumber;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=2)]
        [System.ComponentModel.DescriptionAttribute("Date on which the handler information was certified by the reporting site.")]
        public System.DateTime SignedDate;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SignedDateSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        [System.ComponentModel.DescriptionAttribute("Title of the person who certified the handler information reported to the authori" +
            "zing agency.")]
        public string IndividualTitleText;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        [System.ComponentModel.DescriptionAttribute("First name of a person.")]
        public string FirstName;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        [System.ComponentModel.DescriptionAttribute("Middle initial of a person.")]
        public string MiddleInitial;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        [System.ComponentModel.DescriptionAttribute("Last name of a person.")]
        public string LastName;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        [System.ComponentModel.DescriptionAttribute("Notes regarding the handler Certification.")]
        public string CertificationSupplementalInformationText;
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.exchangenetwork.net/schema/RCRA/4")]
    [System.Xml.Serialization.XmlRootAttribute("NAICSIdentity", Namespace="http://www.exchangenetwork.net/schema/RCRA/4", IsNullable=false)]
    public partial class NAICSIdentityDataType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        public string TransactionCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Sequence number for each NAICS code for the handler.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string NAICSSequenceNumber;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the NAICS Code.")]
        public string NAICSOwnerCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        [System.ComponentModel.DescriptionAttribute("The North American Industry Classification System Code that identifies the busine" +
            "ss activities of the facility.")]
        public string NAICSCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        [System.ComponentModel.DescriptionAttribute("Notes for the handler NAICS Code.")]
        public string NAICSSupplementalInformationText;
    }
    
    //TSM:
    ///// <remarks/>
    //[System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.exchangenetwork.net/schema/RCRA/4")]
    //[System.Xml.Serialization.XmlRootAttribute("Contact", Namespace="http://www.exchangenetwork.net/schema/RCRA/4", IsNullable=false)]
    //public partial class ContactDataType {
        
    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("FirstName", typeof(string), Order=0)]
    //    [System.Xml.Serialization.XmlElementAttribute("LastName", typeof(string), Order=0)]
    //    [System.Xml.Serialization.XmlElementAttribute("MiddleInitial", typeof(string), Order=0)]
    //    [System.Xml.Serialization.XmlElementAttribute("OrganizationFormalName", typeof(string), Order=0)]
    //    [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
    //    public string[] Items;
        
    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("ItemsElementName", Order=1)]
    //    [System.Xml.Serialization.XmlIgnoreAttribute()]
    //    public ItemsChoiceType[] ItemsElementName;
        
    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order=2)]
    //    [System.ComponentModel.DescriptionAttribute("Email address data")]
    //    public string EmailAddressText;
        
    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order=3)]
    //    [System.ComponentModel.DescriptionAttribute("Telephone Number data")]
    //    public string TelephoneNumberText;
        
    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order=4)]
    //    [System.ComponentModel.DescriptionAttribute("Telephone number extension")]
    //    public string PhoneExtensionText;
    //}
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.exchangenetwork.net/schema/RCRA/4", IncludeInSchema=false)]
    public enum ItemsChoiceType {
        
        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("First name of a person.")]
        FirstName,
        
        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Last name of a person.")]
        LastName,
        
        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Middle initial of a person.")]
        MiddleInitial,
        
        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("The legal, formal name of an organization that is affiliated with the facility si" +
            "te.")]
        OrganizationFormalName,
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.exchangenetwork.net/schema/RCRA/4")]
    [System.Xml.Serialization.XmlRootAttribute("MailingAddress", Namespace="http://www.exchangenetwork.net/schema/RCRA/4", IsNullable=false)]
    public partial class MailingAddressDataType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string MailingAddressText;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string SupplementalAddressText;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string MailingAddressCityName;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string MailingAddressStateUSPSCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string MailingAddressCountryName;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string MailingAddressZIPCode;
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.exchangenetwork.net/schema/RCRA/4")]
    [System.Xml.Serialization.XmlRootAttribute("ContactAddress", Namespace="http://www.exchangenetwork.net/schema/RCRA/4", IsNullable=false)]
    public partial class ContactAddressDataType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Contact information.")]
        public ContactDataType Contact;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Mailing address information.")]
        public MailingAddressDataType MailingAddress;
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.exchangenetwork.net/schema/RCRA/4")]
    [System.Xml.Serialization.XmlRootAttribute("FacilityOwnerOperator", Namespace="http://www.exchangenetwork.net/schema/RCRA/4", IsNullable=false)]
    public partial class FacilityOwnerOperatorDataType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        public string TransactionCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="integer", Order=1)]
        [System.ComponentModel.DescriptionAttribute("Sequential number used to order multiple occurrences of owners and operators.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string OwnerOperatorSequenceNumber;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [System.ComponentModel.DescriptionAttribute("Code indicating whether the data is associated with a current or previous owner o" +
            "r operator. The system will allow multiple current owners and operators.")]
        public string OwnerOperatorIndicator;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        [System.ComponentModel.DescriptionAttribute("Code indicating the owner/operator type.")]
        public string OwnerOperatorTypeCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=4)]
        [System.ComponentModel.DescriptionAttribute("Date indicating when the owner/operator became current.")]
        public System.DateTime CurrentStartDate;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CurrentStartDateSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=5)]
        [System.ComponentModel.DescriptionAttribute("Date indicating when the owner/operator changed to a different owner/operator.")]
        public System.DateTime CurrentEndDate;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CurrentEndDateSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        [System.ComponentModel.DescriptionAttribute("Dunn and Bradstreet number used as an identifier")]
        public string DUNSID;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        [System.ComponentModel.DescriptionAttribute("Notes for the facility Owner Operator.")]
        public string OwnerOperatorSupplementalInformationText;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        [System.ComponentModel.DescriptionAttribute("Contact address information for the facility owner/operator.")]
        public ContactAddressDataType ContactAddress;
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.exchangenetwork.net/schema/RCRA/4")]
    [System.Xml.Serialization.XmlRootAttribute("WasteActivitySite", Namespace="http://www.exchangenetwork.net/schema/RCRA/4", IsNullable=false)]
    public partial class SiteWasteActivityDataType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("The legal name of the site.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string FacilitySiteName;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Code indicating current ownership status of the land on which the facility is loc" +
            "ated.")]
        public string LandTypeCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [System.ComponentModel.DescriptionAttribute("Code indicating the state-designated legislative district(s) in which the site is" +
            " located.")]
        public string StateDistrictCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler is engaged in importing hazardous waste into the" +
            " United States.")]
        public string ImporterActivityCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler is engaged in generating mixed waste (waste that" +
            " is both hazardous and radioactive).")]
        public string MixedWasteGeneratorCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler is engaged in recycling hazardous waste.")]
        public string RecyclerActivityCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler is engaged in the transportation of hazardous wa" +
            "ste.")]
        public string TransporterActivityCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler is engaged in the treatment, storage, or disposa" +
            "l of hazardous waste.")]
        public string TreatmentStorageDisposalActivityCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler generates and or treats, stores, or disposes of " +
            "hazardous waste and has an injection well located at the installation.")]
        public string UndergroundInjectionActivityCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler treats, disposes of, or recycles hazardous waste" +
            " on site.")]
        public string UniversalWasteDestinationFacilityIndicator;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler qualifies for the Small Quantity Onsite Burner E" +
            "xemption.")]
        public string OnsiteBurnerExemptionCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler qualifies for the Smelting, Melting, and Refinin" +
            "g Furnace Exemption.")]
        public string FurnaceExemptionCode;
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.exchangenetwork.net/schema/RCRA/4")]
    [System.Xml.Serialization.XmlRootAttribute("StateActivity", Namespace="http://www.exchangenetwork.net/schema/RCRA/4", IsNullable=false)]
    public partial class StateActivityDataType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        public string TransactionCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the state activity type.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string StateActivityOwnerName;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [System.ComponentModel.DescriptionAttribute("Code indicating the type of state activity.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string StateActivityTypeCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        [System.ComponentModel.DescriptionAttribute("Notes regarding the Handler State Waste Activity.")]
        public string StateActivitySupplementalInformationText;
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.exchangenetwork.net/schema/RCRA/4")]
    [System.Xml.Serialization.XmlRootAttribute("HandlerUniversalWaste", Namespace="http://www.exchangenetwork.net/schema/RCRA/4", IsNullable=false)]
    public partial class UniversalWasteActivityDataType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        public string TransactionCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the universal waste type.")]
        public string UniversalWasteOwnerName;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [System.ComponentModel.DescriptionAttribute("Code indicating the type of universal waste.")]
        public string UniversalWasteTypeCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler is engaged in accumulating waste on site.")]
        public string AccumulatedWasteCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler is engaged in generating waste on site.")]
        public string GeneratedHandlerCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        [System.ComponentModel.DescriptionAttribute("Notes regarding the handler Universal Waste Activity.")]
        public string UniversalWasteSupplementalInformationText;
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.exchangenetwork.net/schema/RCRA/4")]
    [System.Xml.Serialization.XmlRootAttribute("UsedOil", Namespace="http://www.exchangenetwork.net/schema/RCRA/4", IsNullable=false)]
    public partial class UsedOilDataType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler is engaged in the burning of used oil fuel.")]
        public string FuelBurnerCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler is engaged in processing used oil activities.")]
        public string ProcessorCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler is engaged in re-refining used oil activities.")]
        public string RefinerCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler directs shipments of used oil to burners.")]
        public string MarketBurnerCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler is a marketer who first claims the used oil meet" +
            "s the specifications.")]
        public string SpecificationMarketerCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler owns or operates a used oil transfer facility.")]
        public string TransferFacilityCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler is engaged in used oil transportation and/or tra" +
            "nsfer facility activities.")]
        public string TransporterCode;
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.exchangenetwork.net/schema/RCRA/4")]
    [System.Xml.Serialization.XmlRootAttribute("HandlerWasteCodeDetails", Namespace="http://www.exchangenetwork.net/schema/RCRA/4", IsNullable=false)]
    public partial class HandlerWasteCodeDataType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        public string TransactionCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that owns the data record.")]
        public string WasteCodeOwnerName;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [System.ComponentModel.DescriptionAttribute("Code used to describe hazardous waste.")]
        public string WasteCode;
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.exchangenetwork.net/schema/RCRA/4")]
    [System.Xml.Serialization.XmlRootAttribute("Handler", Namespace="http://www.exchangenetwork.net/schema/RCRA/4", IsNullable=false)]
    public partial class HandlerDataType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        public string TransactionCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Indicates the location of the agency regulating the handler.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ActivityLocationCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [System.ComponentModel.DescriptionAttribute("Code indicating the source of information for the associated data (activity, wast" +
            "es, etc.).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string SourceTypeCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="integer", Order=3)]
        [System.ComponentModel.DescriptionAttribute("Sequence number for each source record about a handler.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string SourceRecordSequenceNumber;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=4)]
        [System.ComponentModel.DescriptionAttribute("Date that the form (indicated by the associated Source) was received from the han" +
            "dler by the appropriate authority.")]
        public System.DateTime ReceiveDate;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ReceiveDateSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=5)]
        [System.ComponentModel.DescriptionAttribute("Date information was received for the handler.")]
        public System.DateTime AcknowledgeReceiptDate;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AcknowledgeReceiptDateSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        [System.ComponentModel.DescriptionAttribute("Flag indicating that the handler has been identified through a source other than " +
            "Notification and is suspected of conducting RCRA-regulated activities without pr" +
            "oper authority.")]
        public string NonNotifierIndicator;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="integer", Order=7)]
        [System.ComponentModel.DescriptionAttribute("The number of employees currently working at the site.")]
        public string OnsiteEmployeeQuantity;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=8)]
        [System.ComponentModel.DescriptionAttribute("The date that operation of the facility commenced, the date construction on the f" +
            "acility commenced, or the date that operation is expected to begin.")]
        public System.DateTime TreatmentStorageDisposalDate;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TreatmentStorageDisposalDateSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        [System.ComponentModel.DescriptionAttribute(@"Code indicating that the handler, whether public or private, currently accepts hazardous waste from another site (site identified by a different EPA ID). If information is also available on the specific processes and wastes which are accepted, it is indicated by a flag at the process unit level (Process Unit Group Commercial Status).")]
        public string OffsiteWasteReceiptCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        [System.ComponentModel.DescriptionAttribute("Code indicating the reason why the handler is not accessible for normal RCRA trac" +
            "king and processing (previously called Bankrupt Indicator).")]
        public string AccessibilityCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the county code.")]
        public string CountyCodeOwner;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        [System.ComponentModel.DescriptionAttribute("The Federal Information Processing Standard (FIPS) code for the county in which t" +
            "he facility is located (Ref: FIPS Publication, 6-3, \"Counties and County Equival" +
            "ents of the States of the United States\").")]
        public string CountyCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        [System.ComponentModel.DescriptionAttribute("Notes regarding the Handler.")]
        public string HandlerSupplementalInformationText;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
        [System.ComponentModel.DescriptionAttribute("Location address information.")]
        public LocationAddressDataType LocationAddress;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=15)]
        [System.ComponentModel.DescriptionAttribute("Mailing address information.")]
        public MailingAddressDataType MailingAddress;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=16)]
        [System.ComponentModel.DescriptionAttribute("Contact address information for the facility owner/operator.")]
        public ContactAddressDataType ContactAddress;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=17)]
        [System.ComponentModel.DescriptionAttribute("Contains contact and contact address information for the holder of the permit.")]
        public ContactAddressDataType PermitContactAddress;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=18)]
        [System.ComponentModel.DescriptionAttribute("Used Oil codes.")]
        public UsedOilDataType UsedOil;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=19)]
        [System.ComponentModel.DescriptionAttribute("State and EPA hazardous waste activity codes.")]
        public SiteWasteActivityDataType WasteActivitySite;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=20)]
        [System.ComponentModel.DescriptionAttribute("State code indicating that the handler is engaged in the generation of hazardous " +
            "waste.")]
        public WasteGeneratorDataType StateWasteGenerator;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=21)]
        [System.ComponentModel.DescriptionAttribute("Federal code indicating that the handler is engaged in the generation of hazardou" +
            "s waste.")]
        public WasteGeneratorDataType FederalWasteGenerator;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Certification", Order=22)]
        [System.ComponentModel.DescriptionAttribute("Certification information for the person who certified report to the authorizing " +
            "agency.")]
        public CertificationDataType[] Certification;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NAICSIdentity", Order=23)]
        [System.ComponentModel.DescriptionAttribute("North American Industry Classification Status codes reported for the handler.")]
        public NAICSIdentityDataType[] NAICSIdentity;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FacilityOwnerOperator", Order=24)]
        [System.ComponentModel.DescriptionAttribute("Handler owner and operator information.")]
        public FacilityOwnerOperatorDataType[] FacilityOwnerOperator;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EnvironmentalPermit", Order=25)]
        [System.ComponentModel.DescriptionAttribute("Information about environmental permits issued to the handler.")]
        public EnvironmentalPermitDataType[] EnvironmentalPermit;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("StateActivity", Order=26)]
        [System.ComponentModel.DescriptionAttribute("State waste activity of the handler.")]
        public StateActivityDataType[] StateActivity;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("HandlerUniversalWaste", Order=27)]
        [System.ComponentModel.DescriptionAttribute("Information about universal waste generated by the handler.")]
        public UniversalWasteActivityDataType[] HandlerUniversalWaste;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("HandlerWasteCodeDetails", Order=28)]
        [System.ComponentModel.DescriptionAttribute("Hazardous waste codes describing the handler\'s hazardous waste streams.")]
        public HandlerWasteCodeDataType[] HandlerWasteCodeDetails;
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.exchangenetwork.net/schema/RCRA/4")]
    [System.Xml.Serialization.XmlRootAttribute("FederalWasteGenerator", Namespace="http://www.exchangenetwork.net/schema/RCRA/4", IsNullable=false)]
    public partial class WasteGeneratorDataType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the generator status type.")]
        public string WasteGeneratorOwnerName;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler is engaged in the generation of hazardous waste." +
            "")]
        public string WasteGeneratorStatusCode;
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.exchangenetwork.net/schema/RCRA/4")]
    [System.Xml.Serialization.XmlRootAttribute("HazardousWasteHandlerSubmission", Namespace="http://www.exchangenetwork.net/schema/RCRA/4", IsNullable=false)]
    public partial class HazardousWasteHandlerSubmissionDataType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FacilitySubmission", Order=0)]
        [System.ComponentModel.DescriptionAttribute("Details of facility submission.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public FacilitySubmissionDataType[] FacilitySubmission;
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.exchangenetwork.net/schema/RCRA/4")]
    [System.Xml.Serialization.XmlRootAttribute("FacilitySubmission", Namespace="http://www.exchangenetwork.net/schema/RCRA/4", IsNullable=false)]
    public partial class FacilitySubmissionDataType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
        public string TransactionCode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DescriptionAttribute("Number that uniquely identifies the handler.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string HandlerID;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        [System.ComponentModel.DescriptionAttribute("Designates that data is available for extract for public use.")]
        public string PublicUseExtractIndicator;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        [System.ComponentModel.DescriptionAttribute(@"Computer-generated primary facility-level key in the EPA FINDS data system used as an identifier to cross-reference entities regulated under different environmental programs. The Agency Facility Identification Data Standard (FIDS) requires that program offices store this key in their data systems.")]
        public string FacilityRegistryID;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        [System.ComponentModel.DescriptionAttribute("Notes for the HBasic Identification table.")]
        public string FacilitySupplementalInformationText;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Handler", Order=5)]
        [System.ComponentModel.DescriptionAttribute("Top level of all information about the handler.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public HandlerDataType[] Handler;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OtherID", Order=6)]
        [System.ComponentModel.DescriptionAttribute("Contains alternative identifiers for the facility.")]
        public OtherIDDataType[] OtherID;
    }
}
