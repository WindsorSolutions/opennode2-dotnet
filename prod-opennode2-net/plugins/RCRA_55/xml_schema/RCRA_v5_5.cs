namespace Windsor.Node2008.WNOSPlugin.RCRA_55
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
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string PaymentSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public System.DateTime PaymentDefaultedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public bool PaymentDefaultedDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public System.DateTime ScheduledPaymentDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public bool ScheduledPaymentDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public decimal ScheduledPaymentAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public bool ScheduledPaymentAmountSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 5)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public System.DateTime ActualPaymentDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public bool ActualPaymentDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("The dollar amount of any cost recovery required to be paid pursuant to a Final Or" +
            "der.")]
        public decimal ActualPaidAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public bool ActualPaidAmountSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
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
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the penalty type")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string PenaltyTypeOwner;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Code which indicates the type of penalty associated with the penalty amount.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
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
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public bool CashCivilPenaltySoughtAmountSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
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
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string MilestoneSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public string TechnicalRequirementIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Description of the GM Form.")]
        public string TechnicalRequirementDescription;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public System.DateTime MilestoneScheduledCompletionDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public bool MilestoneScheduledCompletionDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 5)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public System.DateTime MilestoneActualCompletionDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public bool MilestoneActualCompletionDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 6)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public System.DateTime MilestoneDefaultedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public bool MilestoneDefaultedDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
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
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ViolationSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Compliance Monitoring and Enforcement Violation Data")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
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
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
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
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("SEP Sequence Number allowed value 01-99")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string SEPSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Expenditure Amount")]
        public decimal SEPExpenditureAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public bool SEPExpenditureAmountSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Valid date greater than or equal to the Date of Enforcement Action.")]
        public System.DateTime SEPScheduledCompletionDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public bool SEPScheduledCompletionDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Date on which actual completion of an event occurs.")]
        public System.DateTime SEPActualDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public bool SEPActualDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Date the SEP defaulted")]
        public System.DateTime SEPDefaultedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public bool SEPDefaultedDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("State postal code")]
        public string SEPCodeOwner;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("The narrative text describing any Supplemental Environmental Projects required to" +
            " be performed pursuant to a Final Order.")]
        public string SEPDescriptionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the Supplemental Environmental Project required to be" +
            " performed pursuant to the final order(Data publishing only).")]
        public string SEPLongDescriptionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
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
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the multimedia code.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string MultimediaCodeOwner;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Code which indicates the medium or program other than RCRA participating in the e" +
            "nforcement action.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string MultimediaCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
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
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Name or number assigned by the implementing agency to identify a corrective actio" +
            "n area.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string EnforcementAgencyLocationName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The unique alphanumeric identifier used in the applicable database to identify a " +
            "specific enforcement action pertaining to a regulated entity or facility.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string EnforcementActionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The calendar date the enforcement action was issued or filed.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public System.DateTime EnforcementActionDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Name or number assigned by the implementing agency to identify a corrective actio" +
            "n area.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
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
        public string EnforcementDocketNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Identifies the attorney within the agency responsible for issuing the enforcement" +
            " action.")]
        public string EnforcementAttorney;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public string CorrectiveActionComponent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 9)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public string ConsentAgreementFinalOrderSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("Name or number assigned by the implementing agency to identify a corrective actio" +
            "n area.")]
        public string RespondentName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 11)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public System.DateTime AppealInitiatedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public bool AppealInitiatedDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 12)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public System.DateTime AppealResolutionDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public bool AppealResolutionDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 13)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public System.DateTime DispositionStatusDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public bool DispositionStatusDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public string DispositionStatusOwner;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public string DispositionStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing how the enforcement action was closed, terminated, or" +
            " discontinued(Data publishing only).")]
        public string DispositionStatusText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [System.ComponentModel.DescriptionAttribute("State Postal Code")]
        public string EnforcementOwner;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [System.ComponentModel.DescriptionAttribute("A code that identifies the type of action being taken against a handler.")]
        public string EnforcementType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the Enforcement Type(Data publishing only).")]
        public string EnforcementTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the person identifier.")]
        public string EnforcementResponsiblePersonOwner;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        [System.ComponentModel.DescriptionAttribute("Code indicating the person within the agency responsible for conducting the enfor" +
            "cement.")]
        public string EnforcementResponsiblePersonIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public string EnforcementResponsibleSuborganizationOwner;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 23)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public string EnforcementResponsibleSuborganization;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 24)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public string Notes;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CSNYDate", Order = 25)]
        [System.ComponentModel.DescriptionAttribute("Date of the SNY that the Action is Addressing")]
        public CSNYDateDataType[] CSNYDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Penalty", Order = 26)]
        [System.ComponentModel.DescriptionAttribute("Compliance Monitoring and Enforcement Penalty Data")]
        public PenaltyDataType[] Penalty;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Milestone", Order = 27)]
        [System.ComponentModel.DescriptionAttribute("Compliance Monitoring and Enforcement Milestone Data")]
        public MilestoneDataType[] Milestone;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ViolationEnforcement", Order = 28)]
        [System.ComponentModel.DescriptionAttribute("Linking Data for Violation and Enforcement")]
        public ViolationEnforcementDataType[] ViolationEnforcement;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SupplementalEnvironmentalProject", Order = 29)]
        [System.ComponentModel.DescriptionAttribute("Compliance Monitoring and Enforcement Supplemental Environmental Project Data")]
        public SupplementalEnvironmentalProjectDataType[] SupplementalEnvironmentalProject;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Media", Order = 30)]
        [System.ComponentModel.DescriptionAttribute("Compliance Monitoring and Enfocement Multimedia Data")]
        public MediaDataType[] Media;
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
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string CitationNameSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Name or number assigned by the implementing agency to identify a corrective actio" +
            "n area.")]
        public string CitationName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("State postal code")]
        public string CitationNameOwner;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Existing nationally defined values: FR, FS, OC, PC,SR,SS,V3")]
        public string CitationNameType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Description of the GM Form.")]
        public string CitationDescription;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
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
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ViolationActivityLocation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ViolationSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Compliance Monitoring and Enforcement Violation Data")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string AgencyWhichDeterminedViolation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the agency responsible for the action(Data publishing" +
            " only).")]
        public string AgencyText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Allowed value HQ")]
        public string ViolationTypeOwner;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Violation Type")]
        public string ViolationType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the specific area of the Federal Code of Regulations " +
            "covered by the evaluation that was found to be in violation with RCRA regulation" +
            "s or statutes(Data publishing only).")]
        public string ViolationTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Name or number assigned by the implementing agency to identify a corrective actio" +
            "n area.")]
        public string FormerCitationName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 9)]
        [System.ComponentModel.DescriptionAttribute("The calendar date the Responsible Authority determines that a regulated entity is" +
            " in violation of a legally enforceable obligation.")]
        public System.DateTime ViolationDeterminedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public bool ViolationDeterminedDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 10)]
        [System.ComponentModel.DescriptionAttribute("Date on which actual completion of an event occurs.")]
        public System.DateTime ReturnComplianceActualDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public bool ReturnComplianceActualDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public string ReturnToComplianceQualifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the conditions under which the actual compliance occu" +
            "red(Data publishing only).")]
        public string ReturnToComplianceQualifierText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public string ViolationResponsibleAgency;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the agency responsible for the action(Data publishing" +
            " only).")]
        public string ViolationResponsibleAgencyText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public string Notes;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Citation", Order = 16)]
        [System.ComponentModel.DescriptionAttribute("Compliance Monitoring and Enforcement Citation Data")]
        public CitationDataType[] Citation;
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
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string RequestSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Compliance Monitoring and Enforcement Request Data")]
        public System.DateTime DateOfRequest;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public bool DateOfRequestSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public System.DateTime DateResponseReceived;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public bool DateResponseReceivedSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public string RequestAgency;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the agency responsible for the action(Data publishing" +
            " only).")]
        public string AgencyText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
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
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string CommitmentLead;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
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
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ViolationActivityLocation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ViolationSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Compliance Monitoring and Enforcement Violation Data")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
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
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Indicates the location of the agency regulating the EPA handler.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string EvaluationActivityLocation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Name or number assigned by the implementing agency to identify an evaluation.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
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
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public bool DayZeroSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Flag indicating if a violation was found.")]
        public string FoundViolation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("The inspection or record review was initiated because of a tip/complaint")]
        public string CitizenComplaintIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public string MultimediaIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public string SamplingIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("The inspection conducted pursuant to RCRA 3007 or State equivalent; determiniatio" +
            "n made: sit is Non-Hazardous Waste.")]
        public string NotSubtitleCIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the type of evaluation.")]
        public string EvaluationTypeOwner;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [System.ComponentModel.DescriptionAttribute("Code to report the type of evaluation conducted at the handler.")]
        public string EvaluationType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the type of evaluation performed at the Handler(Data " +
            "publishing only).")]
        public string EvaluationTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public string FocusAreaOwner;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public string FocusArea;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing subject of the Focused Compliance Inspection(Data pub" +
            "lishing only).")]
        public string FocusAreaText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the person identifier.")]
        public string EvaluationResponsiblePersonIdentifierOwner;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        [System.ComponentModel.DescriptionAttribute("Code indicating the person within the agency responsible for conducting the evalu" +
            "ation.")]
        public string EvaluationResponsiblePersonIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the suborganization identifier.")]
        public string EvaluationResponsibleSuborganizationOwner;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        [System.ComponentModel.DescriptionAttribute("Code indicating the branch/district within the agency responsible for conducting " +
            "the evaluation.")]
        public string EvaluationResponsibleSuborganization;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public string Notes;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Request", Order = 23)]
        [System.ComponentModel.DescriptionAttribute("Compliance Monitoring and Enforcement Request Data")]
        public RequestDataType[] Request;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EvaluationCommitment", Order = 24)]
        [System.ComponentModel.DescriptionAttribute("Linking Data for Commitment/Initiative and Evaluation.")]
        public EvaluationCommitmentDataType[] EvaluationCommitment;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EvaluationViolation", Order = 25)]
        [System.ComponentModel.DescriptionAttribute("Compliance Monitoring and Enforcement Violation Data")]
        public EvaluationViolationDataType[] EvaluationViolation;
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
        [System.ComponentModel.DescriptionAttribute("Code that uniquely identifies the handler.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
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
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Code that uniquely identifies the handler.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string OtherHandlerID;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Name or number assigned by the implementing agency to identify a corrective actio" +
            "n area.")]
        public string RelationshipOwnerName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Indicates the type of the relationship.")]
        public string RelationshipTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the relationship between another ID and the current I" +
            "D (Data publishing only).")]
        public string RelationshipTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Indicates whether the alternate Id references the same facility.")]
        public string SameFacilityIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Notes providing more information.")]
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
        [System.ComponentModel.DescriptionAttribute("Location Address Street Number")]
        public string LocationAddressNumberText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string LocationAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public string SupplementalLocationText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Name or number assigned by the implementing agency to identify a corrective actio" +
            "n area.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string LocalityName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public string StateUSPSCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Name or number assigned by the implementing agency to identify a corrective actio" +
            "n area.")]
        public string CountryName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
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
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Identification number of an effective environmental permit issued to the handler," +
            " or the number of a filed application for which an environmental permit has not " +
            "yet been issued.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string EnvironmentalPermitID;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Name or number assigned by the implementing agency to identify a corrective actio" +
            "n area.")]
        public string EnvironmentalPermitOwnerName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute(@"Code indicating the environmental program and/or jurisdictional authority under which an environmental permit was issued to the facility, or under which an application has been filed for which a permit has not yet been issued. This data element is applicable to TSD facilities only.")]
        public string EnvironmentalPermitTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the Environmental Permit Type (Data publishing only)." +
            "")]
        public string EnvironmentalPermitTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Description of the GM Form.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
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
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Sequence number for each certification for the handler.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string CertificationSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Date on which the handler information was certified by the reporting site.")]
        public System.DateTime SignedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public bool SignedDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Title of the contact person or the title of the person who certified the handler " +
            "information reported to the authorizing agency.")]
        public string IndividualTitleText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("First name of a person.")]
        public string FirstName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Middle initial of a person.")]
        public string MiddleInitial;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Last name of a person.")]
        public string LastName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Email address data.")]
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
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Sequence number for each NAICS code for the handler.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string NAICSSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the NAICS Code.")]
        public string NAICSOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The North American Industry Classification System Code that identifies the busine" +
            "ss activities of the facility.")]
        public string NAICSCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text NAICS Code(Data publishing only).")]
        public string NAICSText;
    }

    //TSM:
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
    //    [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
    //        "ntain either simpleContent or complexContent elements.  It is used to assert the" +
    //        " model position of \"class\" elements declared in other GML schemas.  ")]
    //    public string[] Items;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("ItemsElementName", Order = 1)]
    //    [System.Xml.Serialization.XmlIgnoreAttribute()]
    //    [System.ComponentModel.DescriptionAttribute("Name or number assigned by the implementing agency to identify a corrective actio" +
    //        "n area.")]
    //    [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
    //    public ItemsChoiceType[] ItemsElementName;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
    //    [System.ComponentModel.DescriptionAttribute("Title of the contact person or the title of the person who certified the handler " +
    //        "information reported to the authorizing agency.")]
    //    public string IndividualTitleText;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
    //    [System.ComponentModel.DescriptionAttribute("Email address data")]
    //    public string EmailAddressText;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
    //    [System.ComponentModel.DescriptionAttribute("Telephone Number data")]
    //    public string TelephoneNumberText;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
    //    [System.ComponentModel.DescriptionAttribute("Telephone number extension")]
    //    public string PhoneExtensionText;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
    //    [System.ComponentModel.DescriptionAttribute("Contact fax number")]
    //    public string FaxNumberText;
    //}

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IncludeInSchema = false)]
    public enum ItemsChoiceType
    {

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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("MailingAddress", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class MailingAddressDataType
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Mailing Address Street Number")]
        public string MailingAddressNumberText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public string MailingAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public string SupplementalAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Name or number assigned by the implementing agency to identify a corrective actio" +
            "n area.")]
        public string MailingAddressCityName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public string MailingAddressStateUSPSCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Name or number assigned by the implementing agency to identify a corrective actio" +
            "n area.")]
        public string MailingAddressCountryName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public string MailingAddressZIPCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("ContactAddress", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class ContactAddressDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Contact information.")]
        public ContactDataType Contact;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Mailing address information.")]
        public MailingAddressDataType MailingAddress;
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
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Sequential number used to order multiple occurrences of owners and operators.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string OwnerOperatorSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Code indicating whether the data is associated with a current or previous owner o" +
            "r operator. The system will allow multiple current owners and operators.")]
        public string OwnerOperatorIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the owner/operator(Data publishing only).")]
        public string OwnerOperatorText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Code indicating the owner/operator type.")]
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
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public bool CurrentStartDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Date indicating when the owner/operator changed to a different owner/operator.")]
        public System.DateTime CurrentEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public bool CurrentEndDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Notes providing more information.")]
        public string OwnerOperatorSupplementalInformationText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("Contact address information for the facility owner/operator.")]
        public ContactAddressDataType ContactAddress;
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
        public string LandTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the land type that the Handler is located on(Data pub" +
            "lishing only).")]
        public string LandTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Owner of the state district code.  Usually 2-digit postal code (i.e. KS).")]
        public string StateDistrictOwnerName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Code indicating the state-designated legislative district(s) in which the site is" +
            " located.")]
        public string StateDistrictCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the code indicating the state-designated legislative district(s) in which the site is located (Data publishing only)")]
        public string StateDistrictCodeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler is engaged in importing hazardous waste into the" +
            " United States.")]
        public string ImporterActivityCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler is engaged in generating mixed waste (waste that" +
            " is both hazardous and radioactive).")]
        public string MixedWasteGeneratorCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler is engaged in recycling hazardous waste.")]
        public string RecyclerActivityCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler is engaged in the transportation of hazardous wa" +
            "ste.")]
        public string TransporterActivityCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler is engaged in the treatment, storage, or disposa" +
            "l of hazardous waste.")]
        public string TreatmentStorageDisposalActivityCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler generates and or treats, stores, or disposes of " +
            "hazardous waste and has an injection well located at the installation.")]
        public string UndergroundInjectionActivityCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler treats, disposes of, or recycles hazardous waste" +
            " on site.")]
        public string UniversalWasteDestinationFacilityIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler qualifies for the Small Quantity Onsite Burner E" +
            "xemption.")]
        public string OnsiteBurnerExemptionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler qualifies for the Smelting, Melting, and Refinin" +
            "g Furnace Exemption.")]
        public string FurnaceExemptionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler is engaged in short-term hazardous waste generat" +
            "ion activities.")]
        public string ShortTermGeneratorIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler is a Hazardous Waste Transfer Facility (not to b" +
            "e confused with a used oil transfer facility).")]
        public string TransferFacilityIndicator;
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
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the state activity type.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string StateActivityOwnerName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Code indicating the type of state activity.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
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
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the universal waste type.")]
        public string UniversalWasteOwnerName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Code indicating the type of universal waste.")]
        public string UniversalWasteTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the Universal Waste Type (Data publishing only).")]
        public string UniversalWasteTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler is engaged in accumulating waste on site.")]
        public string AccumulatedWasteCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler is engaged in generating waste on site.")]
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
        public string FuelBurnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler is engaged in processing used oil activities.")]
        public string ProcessorCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler is engaged in re-refining used oil activities.")]
        public string RefinerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler directs shipments of used oil to burners.")]
        public string MarketBurnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler is a marketer who first claims the used oil meet" +
            "s the specifications.")]
        public string SpecificationMarketerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler owns or operates a used oil transfer facility.")]
        public string TransferFacilityCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler is engaged in used oil transportation and/or tra" +
            "nsfer facility activities.")]
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
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that owns the data record.")]
        public string WasteCodeOwnerName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Code used to describe hazardous waste.")]
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
    public partial class LaboratoryHazardousWasteDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Indicates whether or not the Handler is a College or University opting into SubPa" +
            "rt K.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string CollegeIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Indicates whether or not the Handler is a Hospital opting into SubPart K.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string HospitalIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Indicates whether or not the Handler is a Non-Profit opting into SubPart K.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string NonProfitIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Indicates whether or not the Handler is withdrawing from SubPart K.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
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
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Unique number identifying the HSM Activity for the Handler")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string HSMSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Owner of the Facility Code.  Shoule be HQ or the state code (i.e. KS)")]
        public string FacilityCodeOwnerName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Type of facility generating Hazardous Secondary Material")]
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
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public bool EstimatedShortTonsQuantitySpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("The actual amount of HSM generated by the Handler")]
        public decimal ActualShortTonsQuantity;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public bool ActualShortTonsQuantitySpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Code to indicate if the HSM is being managed in a Land Based Unit")]
        public string LandBasedUnitIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the code to indicate if the HSM is being managed in a Land Based Unit (Data publishing only)")]
        public string LandBasedUnitIndicatorText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("HandlerWasteCodeDetails", Order = 9)]
        [System.ComponentModel.DescriptionAttribute("Hazardous waste codes describing the handler\'s hazardous waste streams.")]
        //TSM:
        //public HandlerWasteCodeDataType[] HandlerWasteCodeDetails;
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
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Indicates the reason for notifying Hazardous Secondary Material")]
        public string NotificationReasonCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the reason for notifying under DSW(Data publishing on" +
            "ly).")]
        public string NotificationReasonText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The Effective Date of the action: 1. Hazardous Secondary Material notification in" +
            " Handler, 2. Corrective Action Authority, 3. Financial Assurance Mechanism. ")]
        public System.DateTime EffectiveDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public bool EffectiveDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Indicates whether or not the facility has provided Financial Assurance for the HS" +
            "M Activities")]
        public string FinancialAssuranceIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Indicates the facility has a recycling process which the product has levels of " +
            "hazardous constituents that are not comparable to or unable to be compared to a legitimate product or intermediate but that the recycling is still legitimate")]
        public string RecyclingIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("HazardousSecondaryMaterialActivity", Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Hazardous Secondary Material activity of the Handler")]
        public HazardousSecondaryMaterialActivityDataType[] HazardousSecondaryMaterialActivity;
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
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string SourceTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the Handler Source Type (Data publishing only).")]
        public string SourceTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Sequence number for each source record about a handler.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string SourceRecordSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Date that the form (indicated by the associated Source) was received from the han" +
            "dler by the appropriate authority.")]
        public System.DateTime ReceiveDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public bool ReceiveDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Name of the Handler")]
        public string HandlerName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Date information was received for the handler.")]
        public System.DateTime AcknowledgeReceiptDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public bool AcknowledgeReceiptDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Flag indicating that the handler has been identified through a source other than " +
            "Notification and is suspected of conducting RCRA-regulated activities without pr" +
            "oper authority.")]
        public string NonNotifierIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute(@"Descriptive text describing Notification source(Data publishing only).")]
        public string NonNotifierIndicatorText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 10)]
        [System.ComponentModel.DescriptionAttribute("The date that operation of the facility commenced, the date construction on the f" +
            "acility commenced, or the date that operation is expected to begin.")]
        public System.DateTime TreatmentStorageDisposalDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public bool TreatmentStorageDisposalDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute(@"Notes regarding Handler Part-A submissions.")]
        public string NatureOfBusinessText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute(@"Code indicating that the handler, whether public or private, currently accepts hazardous waste from another site (site identified by a different EPA ID). If information is also available on the specific processes and wastes which are accepted, it is indicated by a flag at the process unit level (Process Unit Group Commercial Status).")]
        public string OffsiteWasteReceiptCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [System.ComponentModel.DescriptionAttribute("Code indicating the reason why the handler is not accessible for normal RCRA trac" +
            "king and processing (previously called Bankrupt Indicator).")]
        public string AccessibilityCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [System.ComponentModel.DescriptionAttribute(@"Descriptive text describing reason facility is not accessible(Data publishing only).")]
        public string AccessibilityCodeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the county code.")]
        public string CountyCodeOwner;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [System.ComponentModel.DescriptionAttribute("The Federal Information Processing Standard (FIPS) code for the county in which t" +
            "he facility is located (Ref: FIPS Publication, 6-3, \"Counties and County Equival" +
            "ents of the States of the United States\").")]
        public string CountyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [System.ComponentModel.DescriptionAttribute("Name or number assigned by the implementing agency to identify a corrective actio" +
            "n area.")]
        public string CountyName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [System.ComponentModel.DescriptionAttribute("Notes regarding the Handler (these are public notes; will be available via all services).")]
        public string HandlerSupplementalInformationText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        [System.ComponentModel.DescriptionAttribute("Notes regarding the Handler (these are internal notes; will be available via authenticated services).")]
        public string HandlerInternalSupplementalInformationText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        [System.ComponentModel.DescriptionAttribute("Notes regarding the Handler (these are internal notes; will be available via authenticated services).")]
        public string ShortTermSupplementalInformationText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        [System.ComponentModel.DescriptionAttribute("Location address information.")]
        public LocationAddressDataType LocationAddress;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        [System.ComponentModel.DescriptionAttribute("Mailing address information.")]
        public MailingAddressDataType MailingAddress;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 23)]
        [System.ComponentModel.DescriptionAttribute("Contact address information for the facility owner/operator.")]
        public ContactAddressDataType ContactAddress;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 24)]
        [System.ComponentModel.DescriptionAttribute("Contact address information for the facility owner/operator.")]
        public ContactAddressDataType PermitContactAddress;

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
        public WasteGeneratorDataType StateWasteGenerator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 28)]
        [System.ComponentModel.DescriptionAttribute("Federal code indicating that the handler is engaged in the generation of hazardou" +
            "s waste.")]
        public WasteGeneratorDataType FederalWasteGenerator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 29)]
        [System.ComponentModel.DescriptionAttribute("Types of Laboratory Waste that the Handler has opted to manage under SubPart K")]
        public LaboratoryHazardousWasteDataType LaboratoryHazardousWaste;

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
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("FederalWasteGenerator", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class WasteGeneratorDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the generator status type.")]
        public string WasteGeneratorOwnerName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the handler is engaged in the generation of hazardous waste." +
            "")]
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
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Code that uniquely identifies the handler.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string HandlerID;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Designates that data is available for extract for public use.")]
        public string PublicUseExtractIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute(@"Computer-generated primary facility-level key in the EPA FINDS data system used as an identifier to cross-reference entities regulated under different environmental programs. The Agency Facility Identification Data Standard (FIDS) requires that program offices store this key in their data systems.")]
        public string FacilityRegistryID;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing whether the data are public or private.")]
        public string DataAccessText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Handler", Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Top level of all information about the handler.")]
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
        public string CorrectiveActionEventDataOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("A code which corresponds to a specific event or event type. The first two charact" +
            "ers indicate the event category and the last three characters the numeric event " +
            "number.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string CorrectiveActionEventCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the Corrective Action event(Data publishing only).")]
        public string CorrectiveActionEventText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Agency responsible for the event.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
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
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("System-generated value used to uniquely identify a process unit.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
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
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Code used for administrative purposes to uniquely designate a group of units (or " +
            "a single unit) with a common history and projection of corrective action require" +
            "ments.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string AreaSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Indicates that the corrective action applies to the entire facility.")]
        public string FacilityWideIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Name or number assigned by the implementing agency to identify a corrective actio" +
            "n area.")]
        public string AreaName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Indicates that there has been a release to air (either within or beyond the facil" +
            "ity boundary) from the unit/area. This may include releases of subsurface gas.")]
        public string AirReleaseIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Indicates that there has been a release to groundwater from the unit/area.")]
        public string GroundwaterReleaseIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Indicates that there has been a release to soil (either within or beyond the faci" +
            "lity boundary) from the unit/area. This may include subsoil contamination beneat" +
            "h the unit/area.")]
        public string SoilReleaseIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Indicates that there has been a release to surface water (either within or beyond" +
            " the facility boundary) from the unit/area.")]
        public string SurfaceWaterReleaseIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Indicates that the corrective action applies to a regulated unit.")]
        public string RegulatedUnitIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the person identifier.")]
        public string EPAResponsiblePersonDataOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("Code indicating the person within the agency responsible for conducting the evalu" +
            "ation or who is the responsible Authority.")]
        public string EPAResponsiblePersonID;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the person identifier.")]
        public string StateResponsiblePersonDataOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("Code indicating the person within the agency responsible for conducting the evalu" +
            "ation or who is the responsible Authority.")]
        public string StateResponsiblePersonID;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [System.ComponentModel.DescriptionAttribute("Notes providing more information.")]
        public string SupplementalInformationText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CorrectiveActionRelatedEvent", Order = 14)]
        [System.ComponentModel.DescriptionAttribute("Linking Data for Corrective Action Areas and Events or Authorities and Events")]
        //TSM:
        //public CorrectiveActionRelatedEventDataType[] CorrectiveActionRelatedEvent;
        public CorrectiveActionAreaRelatedEventDataType[] CorrectiveActionRelatedEvent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CorrectiveActionRelatedPermitUnit", Order = 15)]
        [System.ComponentModel.DescriptionAttribute("A permitted unit related to a corrective action area.")]
        public CorrectiveActionRelatedPermitUnitDataType[] CorrectiveActionRelatedPermitUnit;
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
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Orgnaization responsible for the Statutory Citation (use two-digit postal code)")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string StatutoryCitationDataOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Identifier that identifies the statutory authority under which the corrective act" +
            "ion event occured")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string StatutoryCitationIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Description of the GM Form.")]
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
        public string AuthorityDataOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("A code used to indicate whether a permit, administrative order, or other authorit" +
            "y has been issued to implement the corrective action process.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
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
        public string AuthorityAgencyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the agency responsible for the action(Data publishing" +
            " only).")]
        public string AgencyText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 7)]
        [System.ComponentModel.DescriptionAttribute("The Effective Date of the action: 1. Hazardous Secondary Material notification in" +
            " Handler, 2. Corrective Action Authority, 3. Financial Assurance Mechanism. ")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public System.DateTime AuthorityEffectiveDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Date the authorized agency official signs the order, permit, or permit modificati" +
            "on.")]
        public System.DateTime IssueDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public bool IssueDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 9)]
        [System.ComponentModel.DescriptionAttribute("The date when the corrective action authority is revoked or ended.")]
        public System.DateTime EndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public bool EndDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute(@"The action by which the Director requires the owner/operator to establish and maintain an information repository at a location near the facility for the purpose of making accessible to interested parties documents, reports, and other public information relevant to public understanding of the activities, findings, and plans for such corrective action initiatives.")]
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
        public string ResponsibleLeadProgramIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [System.ComponentModel.DescriptionAttribute("Descriptive Text describing the program in which the organization establishes the" +
            " applicable guidance that the authority should be used(Data publishing only).")]
        public string ResponsibleLeadProgramText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [System.ComponentModel.DescriptionAttribute("Authority responsible suborganization owner.")]
        public string AuthoritySuborganizationDataOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [System.ComponentModel.DescriptionAttribute("Authority responsible suborganization.")]
        public string AuthoritySuborganizationCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the person identifier.")]
        public string ResponsiblePersonDataOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [System.ComponentModel.DescriptionAttribute("Code indicating the person within the agency responsible for conducting the evalu" +
            "ation or who is the responsible Authority.")]
        public string ResponsiblePersonID;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [System.ComponentModel.DescriptionAttribute("Notes providing more information.")]
        public string SupplementalInformationText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CorrectiveActionStatutoryCitation", Order = 19)]
        [System.ComponentModel.DescriptionAttribute("Compliance Monitoring and Enforcement Citation Data")]
        public CorrectiveActionStatutoryCitationDataType[] CorrectiveActionStatutoryCitation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CorrectiveActionRelatedEvent", Order = 20)]
        [System.ComponentModel.DescriptionAttribute("Linking Data for Corrective Action Areas and Events or Authorities and Events")]
        //TSM:
        //public CorrectiveActionRelatedEventDataType[] CorrectiveActionRelatedEvent;
        public CorrectiveActionAuthorityRelatedEventDataType[] CorrectiveActionRelatedEvent;
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
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string CommitmentLead;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
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
        public string CorrectiveActionEventDataOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("A code which corresponds to a specific event or event type. The first two charact" +
            "ers indicate the event category and the last three characters the numeric event " +
            "number.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string CorrectiveActionEventCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the Corrective Action event(Data publishing only).")]
        public string CorrectiveActionEventText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Agency responsible for the event.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
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
        public string EventSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Date on which actual completion of an event occurs.")]
        public System.DateTime ActualDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public bool ActualDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 9)]
        [System.ComponentModel.DescriptionAttribute("The original scheduled completion date for an event. This date cannot be changed " +
            "once entered. Slippage of the scheduled completion date is recorded in the NewSc" +
            "heduleDate Data Element.")]
        public System.DateTime OriginalScheduleDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public bool OriginalScheduleDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 10)]
        [System.ComponentModel.DescriptionAttribute(@"Revised scheduled completion date of the event. This date is used in conjunction with the Original Scheduled Event Date to allow tracking scheduled date slippage. As the scheduled date changes, this field is updated with the new date and the Original Scheduled Event Date is not changed.")]
        public System.DateTime NewScheduleDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public bool NewScheduleDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("Event responsible suborganization owner.")]
        public string EventSuborganizationDataOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("Event responsible suborganization.")]
        public string EventSuborganizationCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the person identifier.")]
        public string ResponsiblePersonDataOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [System.ComponentModel.DescriptionAttribute("Code indicating the person within the agency responsible for conducting the evalu" +
            "ation or who is the responsible Authority.")]
        public string ResponsiblePersonID;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [System.ComponentModel.DescriptionAttribute("Notes providing more information.")]
        public string SupplementalInformationText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EventCommitment", Order = 16)]
        [System.ComponentModel.DescriptionAttribute("Linking Data for Commitment/Initiative and Corrective Action or Permitting Events" +
            ".")]
        //TSM:
        //public EventCommitmentDataType[] EventCommitment;
        public EventEventCommitmentDataType[] EventCommitment;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("HazardousWasteCorrectiveActionSubmission", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class HazardousWasteCorrectiveActionDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CorrectiveActionFacilitySubmission", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Details of facility submission.")]
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
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
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
    [System.Xml.Serialization.XmlRootAttribute("PermitEvent", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class PermitEventDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Transaction code used to define the add, update, or delete.")]
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
        public string PermitEventDataOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Code used to indicate a specific permitting/closure program event and status that" +
            " has actually occurred or is scheduled to occur.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string PermitEventCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the Permitting Event(Data publishing only).")]
        public string PermitEventText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Agency responsible for the event.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
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
        public string EventSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Date on which actual completion of an event occurs.")]
        public System.DateTime ActualDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public bool ActualDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 9)]
        [System.ComponentModel.DescriptionAttribute("The original scheduled completion date for an event. This date cannot be changed " +
            "once entered. Slippage of the scheduled completion date is recorded in the NewSc" +
            "heduleDate Data Element.")]
        public System.DateTime OriginalScheduleDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public bool OriginalScheduleDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 10)]
        [System.ComponentModel.DescriptionAttribute(@"Revised scheduled completion date of the event. This date is used in conjunction with the Original Scheduled Event Date to allow tracking scheduled date slippage. As the scheduled date changes, this field is updated with the new date and the Original Scheduled Event Date is not changed.")]
        public System.DateTime NewScheduleDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public bool NewScheduleDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the person identifier.")]
        public string ResponsiblePersonDataOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("Code indicating the person within the agency responsible for conducting the evalu" +
            "ation or who is the responsible Authority.")]
        public string ResponsiblePersonID;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [System.ComponentModel.DescriptionAttribute("Event responsible suborganization owner.")]
        public string EventSuborganizationDataOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [System.ComponentModel.DescriptionAttribute("Event responsible suborganization.")]
        public string EventSuborganizationCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [System.ComponentModel.DescriptionAttribute("Notes providing more information.")]
        public string SupplementalInformationText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EventCommitment", Order = 16)]
        [System.ComponentModel.DescriptionAttribute("Linking Data for Commitment/Initiative and Corrective Action or Permitting Events" +
            ".")]
        //TSM:
        //public EventCommitmentDataType[] EventCommitment;
        public PermitEventCommitmentDataType[] EventCommitment;
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
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("System-generated value used to uniquely identify a permit series.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string PermitSeriesSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Name or number assigned by the implementing agency to identify a corrective actio" +
            "n area.")]
        public string PermitSeriesName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the person identifier.")]
        public string ResponsiblePersonDataOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Code indicating the person within the agency responsible for conducting the evalu" +
            "ation or who is the responsible Authority.")]
        public string ResponsiblePersonID;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Notes providing more information.")]
        public string SupplementalInformationText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PermitEvent", Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Permit event Data")]
        public PermitEventDataType[] PermitEvent;
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
        public string PermitSeriesSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the event.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string PermitEventDataOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Code used to indicate a specific permitting/closure program event and status that" +
            " has actually occurred or is scheduled to occur.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string PermitEventCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the Permitting Event(Data publishing only).")]
        public string PermitEventText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Agency responsible for the event.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
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
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("System-generated value used to uniquely identify a process unit detail.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string PermitUnitDetailSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the process code.")]
        public string ProcessUnitDataOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Code specifying the unit group\'s current waste treatment, storage, or disposal pr" +
            "ocess.")]
        public string ProcessUnitCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the type of permitted unit(Data publishing only).")]
        public string ProcessUnitText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The Effective Date of the action: 1. Hazardous Secondary Material notification in" +
            " Handler, 2. Corrective Action Authority, 3. Financial Assurance Mechanism. ")]
        public System.DateTime PermitStatusEffectiveDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public bool PermitStatusEffectiveDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Permitted capacity of the unit")]
        public decimal PermitUnitCapacityQuantity;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public bool PermitUnitCapacityQuantitySpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Code indicating the type of capacity.")]
        public string CapacityTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing the capacity of the unit(Data publishing only).")]
        public string CapacityTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("Code indicating that the facility, whether public or private, accepts hazardous w" +
            "aste for the process unit group from a third party.")]
        public string CommercialStatusCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing whether or not the unit is permitted to receive hazar" +
            "dous waste commercially(Data publishing only).")]
        public string CommercialStatusText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the legal/operating status code.")]
        public string LegalOperatingStatusDataOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("Code used to indicate programmatic (operating and legal status) conditions that r" +
            "eflect RCRA program activity requirements of a unit.")]
        public string LegalOperatingStatusCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [System.ComponentModel.DescriptionAttribute("Descriptive text describing Legal/Operating status of the Unit(Data publishing on" +
            "ly).")]
        public string LegalOperatingStatusText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the unit of measure.")]
        public string MeasurementUnitDataOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [System.ComponentModel.DescriptionAttribute("Indicates the unit of measure.")]
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
        public string NumberOfUnitsCount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [System.ComponentModel.DescriptionAttribute("Indicates whether or not the permit is a standardized permit.")]
        public string StandardPermitIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        [System.ComponentModel.DescriptionAttribute("Notes providing more information.")]
        public string SupplementalInformationText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PermitRelatedEvent", Order = 20)]
        [System.ComponentModel.DescriptionAttribute("Linking Data for Permitted Units and Permitting Events")]
        public PermitRelatedEventDataType[] PermitRelatedEvent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("HandlerWasteCodeDetails", Order = 21)]
        [System.ComponentModel.DescriptionAttribute("Hazardous waste codes describing the handler\'s hazardous waste streams.")]
        //TSM:
        //public HandlerWasteCodeDataType[] HandlerWasteCodeDetails;
        public PermitHandlerWasteCodeDataType[] HandlerWasteCodeDetails;
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
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("System-generated value used to uniquely identify a process unit.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string PermitUnitSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Name or number assigned by the implementing agency to identify a corrective actio" +
            "n area.")]
        public string PermitUnitName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Notes providing more information.")]
        public string SupplementalInformationText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PermitUnitDetail", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Permit Unit Detail Data")]
        public PermitUnitDetailDataType[] PermitUnitDetail;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("HazardousWastePermitSubmission", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class HazardousWastePermitDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PermitFacilitySubmission", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Details of facility submission.")]
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
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
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
        public string MechanismSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Unique numerical code identifying the mechanism detail.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
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
        public string CostEstimateSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defines the person identifier.")]
        public string ResponsiblePersonDataOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Code indicating the person within the agency responsible for conducting the evalu" +
            "ation or who is the responsible Authority.")]
        public string ResponsiblePersonID;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("The dollar amount of the cost estimate for a given financial assurance type.")]
        public decimal CostEstimateAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public bool CostEstimateAmountSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 10)]
        [System.ComponentModel.DescriptionAttribute("The date when the cost estimate for a given financial assurance type was submitte" +
            "d, adjusted, approved, or required to be in place.")]
        public System.DateTime CostEstimateDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public bool CostEstimateDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("The reason the cost estimate for a financial assurance type is being reported.")]
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
        public string AreaUnitNotesText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [System.ComponentModel.DescriptionAttribute("Notes providing more information.")]
        public string SupplementalInformationText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CostEstimateRelatedMechanism", Order = 15)]
        [System.ComponentModel.DescriptionAttribute("Linking Data for Cost Estimates and Related Mechanisms")]
        public CostEstimateRelatedMechanismDataType[] CostEstimateRelatedMechanism;
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
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Unique numerical code identifying the mechanism detail.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string MechanismDetailSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The number assigned to the mechanism, such as a bond number or insurance policy n" +
            "umber.")]
        public string MechanismIdentificationText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The total dollar value of the financial assurance mechanism.")]
        public decimal FaceValueAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public bool FaceValueAmountSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The Effective Date of the action: 1. Hazardous Secondary Material notification in" +
            " Handler, 2. Corrective Action Authority, 3. Financial Assurance Mechanism. ")]
        public System.DateTime EffectiveDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public bool EffectiveDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The date the instrument terminates, such as the end of the term of an insurance p" +
            "olicy.")]
        public System.DateTime ExpirationDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public bool ExpirationDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Notes providing more information.")]
        public string SupplementalInformationText;
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
        public string MechanismSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Indicates the agency that defined the mechanism type.")]
        public string MechanismTypeDataOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("The type of mechanism that addresses the cost estimate.")]
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
        public string ProviderText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("Name or number assigned by the implementing agency to identify a corrective actio" +
            "n area.")]
        public string ProviderFullContactName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("Telephone Number data")]
        public string TelephoneNumberText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("Notes providing more information.")]
        public string SupplementalInformationText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MechanismDetail", Order = 12)]
        [System.ComponentModel.DescriptionAttribute("Details of the mechanism used to address cost estimates of the Financial liabilit" +
            "y associated with a given Handler.")]
        public MechanismDetailDataType[] MechanismDetail;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("FinancialAssuranceSubmission", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class FinancialAssuranceSubmissionDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FinancialAssuranceFacilitySubmission", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Details of facility submission.")]
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
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
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
        public string AreaMeasureSourceDataOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The source of information used to determine the number of acres associated with t" +
            "he handler or area.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
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
        public string HorizontalAccuracyMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The number that represents the proportional distance on the ground for one unit o" +
            "f measure on the map or photo.")]
        public decimal SourceMapScaleNumeric;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public bool SourceMapScaleNumericSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The owner of the code.  If provided, it should be HQ.")]
        public string CoordinateDataSourceDataOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the party responsible for proiding the latitude and long" +
            "itude coordinates.")]
        public string CoordinateDataSourceCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Name or number assigned by the implementing agency to identify a corrective actio" +
            "n area.")]
        public string CoordinateDataSourceName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("The owner of the code.  If provided, it should be HQ.")]
        public string GeographicReferencePointDataOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the place for which the geographic codes were establishe" +
            "d")]
        public string GeographicReferencePointCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Name or number assigned by the implementing agency to identify a corrective actio" +
            "n area.")]
        public string GeographicReferencePointName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("The owner of the code.  If provided, it should be HQ.")]
        public string GeometricTypeDataOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the geometric entity represented by one point or a seque" +
            "nce of points")]
        public string GeometricTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("Name or number assigned by the implementing agency to identify a corrective actio" +
            "n area.")]
        public string GeometricTypeName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("The owner of the code.  If provided, it should be HQ.")]
        public string HorizontalCollectionMethodDataOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the method used to deterimine the latitude and longitude" +
            " coordinates for a point on the earth.")]
        public string HorizontalCollectionMethodCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [System.ComponentModel.DescriptionAttribute("Name or number assigned by the implementing agency to identify a corrective actio" +
            "n area.")]
        public string HorizontalCollectionMethodName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [System.ComponentModel.DescriptionAttribute("The owner of the code.  If provided, it should be HQ.")]
        public string HorizontalCoordinateReferenceSystemDatumDataOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the datum used in determining latitude and longitude coo" +
            "rdinates")]
        public string HorizontalCoordinateReferenceSystemDatumCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [System.ComponentModel.DescriptionAttribute("Name or number assigned by the implementing agency to identify a corrective actio" +
            "n area.")]
        public string HorizontalCoordinateReferenceSystemDatumName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [System.ComponentModel.DescriptionAttribute("The owner of the code.  If provided, it should be HQ.")]
        public string VerificationMethodDataOwnerCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the process used to verify the latitude and longitude co" +
            "ordinates.")]
        public string VerificationMethodCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        [System.ComponentModel.DescriptionAttribute("Name or number assigned by the implementing agency to identify a corrective actio" +
            "n area.")]
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
        public string TransactionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Owner of Geographic Information.  Should match state code (i.e. KS).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string GeographicInformationOwner;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Unique identifier for the geographic information.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string GeographicInformationSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("System-generated value used to uniquely identify a process unit.")]
        public string PermitUnitSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Code used for administrative purposes to uniquely designate a group of units (or " +
            "a single unit) with a common history and projection of corrective action require" +
            "ments.")]
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
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.georss.org/georss/10", Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Geometry property element of a GeoRSS GML instance")]
        public whereType @where;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("The text that provides additional informaiton about the geographic coordinates.")]
        public string LocationCommentsText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.georss.org/georss/10")]
    [System.Xml.Serialization.XmlRootAttribute("where", Namespace = "http://www.georss.org/georss/10", IsNullable = false)]
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

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml")]
    [System.Xml.Serialization.XmlRootAttribute("LineString", Namespace = "http://www.opengis.net/gml", IsNullable = false)]
    public partial class LineStringType : AbstractCurveType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("posList", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public DirectPositionListType Item;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml")]
    [System.Xml.Serialization.XmlRootAttribute("posList", Namespace = "http://www.opengis.net/gml", IsNullable = false)]
    public partial class DirectPositionListType
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
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "positiveInteger")]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public string count;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public double[] Text;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LineStringType))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml")]
    [System.Xml.Serialization.XmlRootAttribute("_Curve", Namespace = "http://www.opengis.net/gml", IsNullable = false)]
    public abstract partial class AbstractCurveType : AbstractGeometricPrimitiveType
    {
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

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractFeatureCollectionType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(FeatureCollectionType))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml")]
    [System.Xml.Serialization.XmlRootAttribute("_Feature", Namespace = "http://www.opengis.net/gml", IsNullable = false)]
    public abstract partial class AbstractFeatureType : AbstractGMLType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public BoundingShapeType boundedBy;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml")]
    [System.Xml.Serialization.XmlRootAttribute("boundedBy", Namespace = "http://www.opengis.net/gml", IsNullable = false)]
    public partial class BoundingShapeType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Envelope", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public EnvelopeType Item;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml")]
    [System.Xml.Serialization.XmlRootAttribute("Envelope", Namespace = "http://www.opengis.net/gml", IsNullable = false)]
    public partial class EnvelopeType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("lowerCorner", typeof(DirectPositionType), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("upperCorner", typeof(DirectPositionType), Order = 0)]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public DirectPositionType[] Items;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName", Order = 1)]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.DescriptionAttribute("Name or number assigned by the implementing agency to identify a corrective actio" +
            "n area.")]
        public ItemsChoiceType1[] ItemsElementName;

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
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml", IncludeInSchema = false)]
    public enum ItemsChoiceType1
    {

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        lowerCorner,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        upperCorner,
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(FeatureCollectionType))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml")]
    [System.Xml.Serialization.XmlRootAttribute("_FeatureCollection", Namespace = "http://www.opengis.net/gml", IsNullable = false)]
    public abstract partial class AbstractFeatureCollectionType : AbstractFeatureType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("featureMember", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public FeaturePropertyType[] featureMember;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml")]
    [System.Xml.Serialization.XmlRootAttribute("featureMember", Namespace = "http://www.opengis.net/gml", IsNullable = false)]
    public partial class FeaturePropertyType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FeatureCollection", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public FeatureCollectionType Item;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml")]
    [System.Xml.Serialization.XmlRootAttribute("FeatureCollection", Namespace = "http://www.opengis.net/gml", IsNullable = false)]
    public partial class FeatureCollectionType : AbstractFeatureCollectionType
    {
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LinearRingType))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml")]
    [System.Xml.Serialization.XmlRootAttribute("_Ring", Namespace = "http://www.opengis.net/gml", IsNullable = false)]
    public abstract partial class AbstractRingType : AbstractGeometryType
    {
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml")]
    [System.Xml.Serialization.XmlRootAttribute("LinearRing", Namespace = "http://www.opengis.net/gml", IsNullable = false)]
    public partial class LinearRingType : AbstractRingType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("posList", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public DirectPositionListType Item;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PolygonType))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml")]
    [System.Xml.Serialization.XmlRootAttribute("_Surface", Namespace = "http://www.opengis.net/gml", IsNullable = false)]
    public partial class AbstractSurfaceType : AbstractGeometricPrimitiveType
    {
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml")]
    [System.Xml.Serialization.XmlRootAttribute("Polygon", Namespace = "http://www.opengis.net/gml", IsNullable = false)]
    public partial class PolygonType : AbstractSurfaceType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute(@"A boundary of a surface consists of a number of rings. In the normal 2D case, one of these rings is distinguished as being the exterior boundary. In a general manifold this is not always possible, in which case all boundaries shall be listed as interior boundaries, and the exterior will be empty.")]
        public AbstractRingPropertyType exterior;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml")]
    [System.Xml.Serialization.XmlRootAttribute("exterior", Namespace = "http://www.opengis.net/gml", IsNullable = false)]
    public partial class AbstractRingPropertyType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LinearRing", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public LinearRingType Item;
    }

    //TSM:
    ///// <remarks/>
    //[System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml")]
    //[System.Xml.Serialization.XmlRootAttribute("Point", Namespace = "http://www.opengis.net/gml", IsNullable = false)]
    //public partial class PointType : AbstractGeometricPrimitiveType
    //{

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("pos", Order = 0)]
    //    [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
    //        "ntain either simpleContent or complexContent elements.  It is used to assert the" +
    //        " model position of \"class\" elements declared in other GML schemas.  ")]
    //    public DirectPositionType Item;
    //}

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(whereType))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.georss.org/georss/10")]
    [System.Xml.Serialization.XmlRootAttribute("_featureProperty", Namespace = "http://www.georss.org/georss/10", IsNullable = false)]
    public abstract partial class abstractFeaturePropertyType
    {
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/RCRA/5")]
    [System.Xml.Serialization.XmlRootAttribute("GeographicInformationSubmission", Namespace = "http://www.exchangenetwork.net/schema/RCRA/5", IsNullable = false)]
    public partial class GeographicInformationSubmissionDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("GISFacilitySubmission", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Details of facility submission.")]
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
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string HandlerID;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("GeographicInformation", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Used to define the geographic coordinates of the Handler.")]
        public GeographicInformationDataType[] GeographicInformation;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml")]
    [System.Xml.Serialization.XmlRootAttribute("CircleByCenterPoint", Namespace = "http://www.opengis.net/gml", IsNullable = false)]
    public partial class CircleByCenterPointType : ArcByCenterPointType
    {
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CircleByCenterPointType))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml")]
    [System.Xml.Serialization.XmlRootAttribute("ArcByCenterPoint", Namespace = "http://www.opengis.net/gml", IsNullable = false)]
    public partial class ArcByCenterPointType : AbstractCurveSegmentType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("pos", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public DirectPositionType Item;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Additional georss property indicating the radius or buffer about the accompanying" +
            " geometric property which represents the referenced geographic entity.")]
        public LengthType radius;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public CurveInterpolationType interpolation;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public bool interpolationSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public string numArc;

        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public ArcByCenterPointType()
        {
            this.interpolation = CurveInterpolationType.circularArcCenterPointWithRadius;
            this.numArc = "1";
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml")]
    public partial class LengthType : MeasureType
    {
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LengthType))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml")]
    public partial class MeasureType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public string uom;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        public double Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml")]
    public enum CurveInterpolationType
    {

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        linear,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        geodesic,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        circularArc3Points,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        circularArc2PointWithBulge,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        circularArcCenterPointWithRadius,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        elliptical,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        clothoid,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("This abstract element is the head of a substitutionGroup hierararchy which may co" +
            "ntain either simpleContent or complexContent elements.  It is used to assert the" +
            " model position of \"class\" elements declared in other GML schemas.  ")]
        conic,

        /// <remarks/>
        polynomialSpline,

        /// <remarks/>
        cubicSpline,

        /// <remarks/>
        rationalSpline,
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ArcByCenterPointType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CircleByCenterPointType))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml")]
    [System.Xml.Serialization.XmlRootAttribute("_CurveSegment", Namespace = "http://www.opengis.net/gml", IsNullable = false)]
    public abstract partial class AbstractCurveSegmentType
    {
    }
}
